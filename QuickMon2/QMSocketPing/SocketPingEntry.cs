using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Net.Sockets;

//based on code found at CodeProject
//from Tom Janssens http://www.codeproject.com/Articles/19071/Quick-tool-A-minimalistic-Telnet-library 

namespace QuickMon
{
    public class SocketPingEntry
    {
        enum Verbs
        {
            WILL = 251,
            WONT = 252,
            DO = 253,
            DONT = 254,
            IAC = 255
        }
        enum Options
        {
            SGA = 3
        }

        public SocketPingEntry()
        {
            PortNumber = 23;
            ReceiveTimeoutMS = 30000;
            SendTimeoutMS = 30000;
            UseTelnetLogin = false;
            LastError = "";
        }
        public string HostName { get; set; }
        public int PortNumber { get; set; }
        public int ReceiveTimeoutMS { get; set; }
        public int SendTimeoutMS { get; set; }
        public bool UseTelnetLogin { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        private int pingTimeOutMS = 5000;
        public int PingTimeOutMS { get { return pingTimeOutMS; } set { pingTimeOutMS = value; } }
        public string LastError { get; private set; }

        public int Ping()
        {
            int pingTime = 0;
            TcpClient tcpSocket = new TcpClient();
            Stopwatch sw = new Stopwatch();
            string s = "";
            LastError = "";
            try
            {
                tcpSocket.ReceiveTimeout = ReceiveTimeoutMS;
                tcpSocket.SendTimeout = SendTimeoutMS;
                sw.Start();
                tcpSocket.Connect(HostName, PortNumber);
                if (UseTelnetLogin)
                {
                    //the following is a Telnet protocol login so other protocals probably won't work with this.
                    s = Read(tcpSocket);
                    if (!s.TrimEnd().EndsWith(":"))
                        throw new Exception("Failed to connect : no login prompt");
                    WriteLine(tcpSocket, UserName);
                    s += Read(tcpSocket);
                    if (!s.TrimEnd().EndsWith(":"))
                        throw new Exception("Failed to connect : no password prompt");
                    WriteLine(tcpSocket, Password);

                    s += Read(tcpSocket);
                }
                Write(tcpSocket, "Hello");
                s = Read(tcpSocket); // not doing anything with response
                LastError = "Success";
                
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                pingTime = int.MaxValue;
            }
            finally
            {
                sw.Stop();
                pingTime = (int)sw.ElapsedMilliseconds;
                try
                {
                    if (tcpSocket != null)
                        tcpSocket.Close();
                    tcpSocket = null;
                }
                catch { }
            }
            return pingTime;
        }

        private string Read(TcpClient tcpSocket)
        {
            if (tcpSocket == null || !tcpSocket.Connected) return "";
            StringBuilder sb = new StringBuilder();
            do
            {
                ParseTelnet(tcpSocket, sb);
                //System.Threading.Thread.Sleep(2);
            } while (tcpSocket.Available > 0);
            return sb.ToString();
        }
        private void WriteLine(TcpClient tcpSocket, string cmd)
        {
            Write(tcpSocket, cmd + "\n");
        }
        public void Write(TcpClient tcpSocket, string cmd)
        {
            if (!tcpSocket.Connected) return;
            byte[] buf = System.Text.ASCIIEncoding.ASCII.GetBytes(cmd.Replace("\0xFF", "\0xFF\0xFF"));
            tcpSocket.GetStream().Write(buf, 0, buf.Length);
        }
        private void ParseTelnet(TcpClient tcpSocket, StringBuilder sb)
        {
            while (tcpSocket.Available > 0)
            {
                int input = tcpSocket.GetStream().ReadByte();
                switch (input)
                {
                    case -1:
                        break;
                    case (int)Verbs.IAC:
                        // interpret as command
                        int inputverb = tcpSocket.GetStream().ReadByte();
                        if (inputverb == -1) break;
                        switch (inputverb)
                        {
                            case (int)Verbs.IAC:
                                //literal IAC = 255 escaped, so append char 255 to string
                                sb.Append(inputverb);
                                break;
                            case (int)Verbs.DO:
                            case (int)Verbs.DONT:
                            case (int)Verbs.WILL:
                            case (int)Verbs.WONT:
                                // reply to all commands with "WONT", unless it is SGA (suppres go ahead)
                                int inputoption = tcpSocket.GetStream().ReadByte();
                                if (inputoption == -1) break;
                                tcpSocket.GetStream().WriteByte((byte)Verbs.IAC);
                                if (inputoption == (int)Options.SGA)
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WILL : (byte)Verbs.DO);
                                else
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WONT : (byte)Verbs.DONT);
                                tcpSocket.GetStream().WriteByte((byte)inputoption);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        sb.Append((char)input);
                        break;
                }
            }
        }
    }
}
