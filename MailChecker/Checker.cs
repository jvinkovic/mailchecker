using Resolver.DNS;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailChecker
{
    public class Checker
    {
        private enum SMTPResponse : int
        {
            CONNECT_SUCCESS = 220,
            GENERIC_SUCCESS = 250,
            DATA_SUCCESS = 354,
            QUIT_SUCCESS = 221
        }

        private static Regex regex = new Regex(@"[^@\s]+@[^@\s]+\.[^@\s]+", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
        private static string[] disposableDomains = Properties.Resources.disposable.Replace("\r", string.Empty).Split('\n');

        private string[] _mails;

        private MailChecker _uiForm;
        private string _hostname;
        private string _from;
        private bool _sendToYahoo;

        public Checker(string[] mails, MailChecker form, bool sendToYahoo, string hostname = "", string from = "")
        {
            _sendToYahoo = sendToYahoo;
            _from = from;
            _hostname = hostname;
            _uiForm = form;
            _mails = mails;
        }

        /// <summary>
        /// parallel checking for mails array
        /// </summary>
        public void Check()
        {
            string status;

            Parallel.For(0, _mails.Length, i =>
            //for (int i = 0; i < _mails.Length; i++)
            {
                string mail = _mails[i].Trim();

                // check format
                bool valid = CheckFormat(mail);

                if (valid)
                {
                    // check disposable
                    bool disposable = CheckDisposable(mail);

                    if (!disposable)
                    {
                        string domain = mail.Split('@')[1];

                        MethodInvoker actionStartDomain = () => _uiForm.UpdateLog(i, "Started domain '" + domain + "' check on DNS servers ");
                        _uiForm.BeginInvoke(actionStartDomain);

                        // check domain
                        RecordMX[] mxRecords;
                        bool domainValid = CheckDomain(mail, out mxRecords);

                        if (domainValid)
                        {
                            MethodInvoker actionStart = () => _uiForm.UpdateLog(i, "Started inbox check on mail servers: " + string.Join(" | ", mxRecords.Select(mx => mx.EXCHANGE.TrimEnd('.')).ToArray()));
                            _uiForm.BeginInvoke(actionStart);

                            try
                            {
                                // check inbox
                                bool inboxValid = CheckInbox(mail, mxRecords, out status, _sendToYahoo, _hostname, _from);

                                if (inboxValid)
                                {
                                    MethodInvoker action = () => _uiForm.UpdateProgress(Validity.Valid, i, mail, "Valid");
                                    _uiForm.BeginInvoke(action);
                                }
                                else
                                {
                                    string stat = "No mail on domain mail servers OR NOT RECHABLE: " + status;
                                    Validity val = Validity.Invalid;
                                    if (status.Contains("#UNCERTAIN#"))
                                    {
                                        stat = status;
                                        val = Validity.Unknown;
                                    }

                                    MethodInvoker action = () => _uiForm.UpdateProgress(val, i, mail, stat);
                                    _uiForm.BeginInvoke(action);
                                }
                            }
                            catch (Exception e)
                            {
                                MethodInvoker action = () => _uiForm.UpdateProgress(Validity.Unknown, i, mail, e.Message);
                                _uiForm.BeginInvoke(action);
                            }
                        }
                        else
                        {
                            MethodInvoker action = () => _uiForm.UpdateProgress(Validity.Invalid, i, mail, "Invalid domain: " + domain);
                            _uiForm.BeginInvoke(action);
                        }
                    }
                    else
                    {
                        MethodInvoker action = () => _uiForm.UpdateProgress(Validity.Disposable, i, mail, "This is disposable address");
                        _uiForm.BeginInvoke(action);
                    }
                }
                else
                {
                    MethodInvoker action = () => _uiForm.UpdateProgress(Validity.Invalid, i, mail, "Invalid email address format");
                    _uiForm.BeginInvoke(action);
                }

                //} // end of for
            });// end of parallel for

            MethodInvoker actionFinish = () => _uiForm.FinishCheck();
            _uiForm.BeginInvoke(actionFinish);
        }

        private bool CheckInbox(string mail, RecordMX[] mxRecords, out string status, bool sendForYahoo, string hostname = "", string from = "")
        {
            status = "-";

            bool valid = false;
            for (int i = 0; i < mxRecords.Length; i++)
            {
                try
                {
                    if (from != "")
                    {
                        valid = Helpers.VerifySmtpResponse(mxRecords[i].EXCHANGE, mail, out status, sendForYahoo, hostname, from);
                    }
                    else
                    {
                        valid = Helpers.VerifySmtpResponse(mxRecords[i].EXCHANGE, mail, out status, sendForYahoo, hostname);
                    }

                    if (valid)
                        break;
                }
                catch (Exception e)
                {
                    if (i == mxRecords.Length - 1)
                        throw e;
                }
            }

            return valid;
        }

        /// <summary>
        /// checks existance of MX record for domain of email
        /// </summary>
        /// <param name="mail">mail to check</param>
        /// <returns>true if ok</returns>
        private bool CheckDomain(string mail, out RecordMX[] mxRecords)
        {
            #region oldCheck

            /*
            try
            {
                string hostname = mail.Split('@')[1];

            // check for MX record
            IPAddress dnsServer = IPAddress.Parse(DnsIp);
            mxRecords = Resolver.MXLookup(hostname, dnsServer);

            if (mxRecords.Length == 0)
            {
                return false;
            }

            return true;
        }
            catch
            {
                mxRecords = new MXRecord[0];
                return false;
            }

    */

            #endregion oldCheck

            string strHostName = string.Empty;
            try
            {
                string[] arrHost = mail.Split('@');
                strHostName = arrHost[1];

                Resolver.DNS.Resolver objResolver = new Resolver.DNS.Resolver();
                Response objResponse = objResolver.Query(strHostName, QType.MX, QClass.IN);

                mxRecords = objResponse.RecordsMX;
                if (mxRecords.Length > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                mxRecords = new RecordMX[0];
                return false;
            }
        }

        private bool Check_Response(Socket s, SMTPResponse response_expected)
        {
            string sResponse;
            int response;
            byte[] bytes = new byte[1024];
            while (s.Available == 0)
            {
                System.Threading.Thread.Sleep(100);
            }

            s.Receive(bytes, 0, s.Available, SocketFlags.None);
            sResponse = Encoding.ASCII.GetString(bytes);
            response = Convert.ToInt32(sResponse.Substring(0, 3));
            if (response != (int)response_expected)
                return false;
            return true;
        }

        private bool CheckDisposable(string mail)
        {
            string domain = mail.Split('@')[1];

            if (disposableDomains.Contains(domain))
            {
                return true;
            }

            return false;
        }

        private bool CheckFormat(string mail)
        {
            if (regex.IsMatch(mail) && mail.Count(c => c == '@') == 1)
                return true;
            else
                return false;
        }
    }
}