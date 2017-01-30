using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Resolver.DNS
{
    public static class Helpers
    {
        private class ResponseData
        {
            public string ResponseText { get; set; }
            public bool Esmtp { get; set; }
            public bool Gsmtp { get; set; }
        }

        private static int[] uncertainCodes = new int[] { 420, 421,432, 441, 442, 446, 447, 449, 451, 471, 500, 501,
                                                          502, 503, 504, 541, 554 };

        public static bool VerifySmtpResponse(string strSmtpServerURL, string strEmailAddress, out string status, bool sendForYahoo, string hostname = "", string MailFrom = "noreply.mailchecker@yahoo.com")
        {
            Resolver objResolver = new Resolver();
            IPHostEntry hostEntry = objResolver.GetHostEntry(strSmtpServerURL);

            IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], 25);

            Socket tcpSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            for (int i = 0; i < hostEntry.AddressList.Count(); i++)
            {
                try
                {
                    endPoint = new IPEndPoint(hostEntry.AddressList[i], 25);
                    tcpSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                    tcpSocket.Connect(endPoint);
                    break;
                }
                catch (Exception e)
                {
                    if (i == hostEntry.AddressList.Count() - 1)
                        throw e;
                }
            }

            ResponseData response;

            if (!CheckResponse(tcpSocket, new int[] { 220, 200 }, out response))
            {
                tcpSocket.Close();
                status = "Could not connect: " + response.ResponseText;
                return false;
            }

            string host = Dns.GetHostName();
            if (hostname != "")
            {
                host = hostname;
            }

            if (response.Esmtp)
            {
                //EHLO server
                SendData(tcpSocket, string.Format("EHLO {0}\r\n", host));
                if (!CheckResponse(tcpSocket, new int[] { 200, 250 }, out response))
                {
                    tcpSocket.Close();
                    status = "EHLO refused: " + response.ResponseText;
                    return false;
                }
            }
            else
            {
                //HELO server
                SendData(tcpSocket, string.Format("HELO {0}\r\n", host));
                if (!CheckResponse(tcpSocket, new int[] { 200, 250 }, out response))
                {
                    tcpSocket.Close();
                    status = "HELO refused: " + response.ResponseText;
                    return false;
                }
            }

            //Identify yourself
            //Servers may resolve your domain and check whether
            //you are listed in BlackLists etc.
            SendData(tcpSocket, string.Format("MAIL From:<{0}>\r\n", MailFrom));
            if (!CheckResponse(tcpSocket, new int[] { 200, 250 }, out response))
            {
                if (response.ResponseText.ToLower().Contains("block"))
                {
                    tcpSocket.Close();
                    throw new Exception(response.ResponseText);
                }

                SendData(tcpSocket, string.Format("MAIL From:{0}\r\n", MailFrom));
                if (!CheckResponse(tcpSocket, new int[] { 200, 250 }, out response))
                {
                    tcpSocket.Close();
                    status = "MAIL refused: " + response.ResponseText;
                    return false;
                }
            }

            //RCPT TO
            SendData(tcpSocket, string.Format("RCPT TO:<{0}>\r\n", strEmailAddress));
            if (!CheckResponse(tcpSocket, new int[] { 200, 250, 251 }, out response))
            {
                if (response.ResponseText.ToLower().Contains("not exist"))
                {
                    tcpSocket.Close();
                    status = "Account does not exists: " + response.ResponseText;
                    return false;
                }

                if (response.ResponseText.ToLower().Contains("block"))
                {
                    tcpSocket.Close();
                    throw new Exception(response.ResponseText);
                }

                if (response.Gsmtp)
                {
                    SendData(tcpSocket, string.Format("RCPT TO:{0} <{0}>\r\n", strEmailAddress));
                    if (!CheckResponse(tcpSocket, new int[] { 200, 250, 251 }, out response))
                    {
                        if (response.ResponseText.ToLower().Contains("block"))
                        {
                            tcpSocket.Close();
                            throw new Exception(response.ResponseText);
                        }

                        tcpSocket.Close();
                        status = "RCPT refused: " + response.ResponseText;
                        return false;
                    }
                }
                else
                {
                    SendData(tcpSocket, string.Format("RCPT TO:{0}\r\n", strEmailAddress));
                    if (!CheckResponse(tcpSocket, new int[] { 200, 250, 251 }, out response))
                    {
                        if (response.ResponseText.ToLower().Contains("block"))
                        {
                            tcpSocket.Close();
                            throw new Exception(response.ResponseText);
                        }

                        tcpSocket.Close();
                        status = "RCPT refused: " + response.ResponseText;
                        return false;
                    }
                }
            }

            if (sendForYahoo && strEmailAddress.Split('@')[1].ToLower() == "yahoo.com")
            {
                SendData(tcpSocket, "DATA\r\n");
                if (!CheckResponse(tcpSocket, new int[] { 354 }, out response))
                {
                    tcpSocket.Close();
                    status = "could not send mail - " + response.ResponseText;

                    return false;
                }

                SendData(tcpSocket, "Subject: test sending\r\n\r\ntest msg\r\n.\r\n");
                if (!CheckResponse(tcpSocket, new int[] { 200, 250, 251 }, out response))
                {
                    tcpSocket.Close();
                    status = "recipient does not exist - " + response.ResponseText;

                    return false;
                }
            }

            tcpSocket.Close();

            status = "All ok: " + response.ResponseText;
            return true;
        }

        private static void SendData(Socket socket, string data)
        {
            byte[] dataArray = Encoding.ASCII.GetBytes(data);
            socket.Send(dataArray, 0, dataArray.Length, SocketFlags.None);
        }

        private static bool CheckResponse(Socket socket, int[] expectedCode, out ResponseData response)
        {
            response = new ResponseData();

            int counter = 0;
            while (socket.Available == 0)
            {
                if (counter > 50)
                {
                    response.ResponseText = "Server socket not available";
                    return false;
                }

                System.Threading.Thread.Sleep(100);
                counter++;
            }

            byte[] responseArray = new byte[1024];
            socket.Receive(responseArray, 0, socket.Available, SocketFlags.None);
            string responseData = Encoding.ASCII.GetString(responseArray);

            response.ResponseText = responseData;

            if (responseData.ToLower().Contains("esmtp"))
            {
                response.Esmtp = true;
            }

            if (responseData.ToLower().Contains("gsmtp"))
            {
                response.Gsmtp = true;
            }

            int responseCode = Convert.ToInt32(responseData.Substring(0, 3));
            if (expectedCode.Contains(responseCode))
            {
                return true;
            }

            if (uncertainCodes.Contains(responseCode))
            {
                response.ResponseText += " #UNCERTAIN# ";
            }
            return false;
        }
    }
}