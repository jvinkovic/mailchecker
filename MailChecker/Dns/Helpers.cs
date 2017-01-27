﻿using System;
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

        public static bool VerifySmtpResponse(string strSmtpServerURL, string strEmailAddress, out string status, string MailFrom = "noreply.mailchecker@yahoo.com")
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(strSmtpServerURL);
            IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], 25);

            bool esmtp = false;
            bool gsmtp = false;

            ResponseData response;
            Socket tcpSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            tcpSocket.Connect(endPoint);

            if (!CheckResponse(tcpSocket, new int[] { 220, 200 }, out response))
            {
                tcpSocket.Close();
                status = "Could not connect: " + response.ResponseText;
                return false;
            }

            string host = Dns.GetHostName();

            // HACK always HELLO
            //esmtp = false;
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

                if (response.Gsmtp)
                {
                    SendData(tcpSocket, string.Format("RCPT TO:{0} <{0}>\r\n", strEmailAddress));
                    if (!CheckResponse(tcpSocket, new int[] { 200, 250, 251 }, out response))
                    {
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
                        tcpSocket.Close();
                        status = "RCPT refused: " + response.ResponseText;
                        return false;
                    }
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
            return false;
        }
    }
}