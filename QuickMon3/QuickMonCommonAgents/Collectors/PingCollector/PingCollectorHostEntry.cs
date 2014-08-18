using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace QuickMon.Collectors
{
    public class PingCollectorResult
    {
        public bool Success { get; set; }
        public int PingTime { get; set; }
        public string ResponseDetails { get; set; }
    }

    #region Enums
    public enum PingCollectorType
    {
        Ping = 0,
        HTTP = 1,
        Socket = 2
    }
    #region Socket enums
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
    #endregion 
    #endregion

    public static class PingCollectorTypeHelper
    {
        public static PingCollectorType FromText(string typeName)
        {
            if (typeName.ToUpper() == "HTTP")
                return PingCollectorType.HTTP;
            else if (typeName.ToUpper() == "SOCKET")
                return PingCollectorType.Socket;
            else
                return PingCollectorType.Ping;
        }
        public static string ToString(PingCollectorType type)
        {
            if (type == PingCollectorType.Ping)
                return "Ping";
            else if (type == PingCollectorType.HTTP)
                return "Http";
            else
                return "Socket";
        }
    }

    public class PingCollectorHostEntry : ICollectorConfigEntry
    {
        public PingCollectorHostEntry()
        {
            IgnoreInvalidHTTPSCerts = false;
        }

        #region ICollectorConfigEntry Members
        public string Description
        {
            get {
                string sdesc = description.Length == 0 ? "" : "(" + description + ") ";
                return string.Format("[{0}] {1} {2}", PingCollectorTypeHelper.ToString(pingType), address + (pingType == PingCollectorType.Socket ? (":" + socketPort.ToString()) : ""), sdesc); 
            }
        }
        public string TriggerSummary
        {
            get
            {
                return string.Format("Max: {0}ms, Time-out: {1}ms", maxTimeMS, timeOutMS);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        #endregion

        private PingCollectorType pingType = PingCollectorType.Ping;
        public PingCollectorType PingType { get { return pingType; } set { pingType = value; } }
        public PingCollectorResult LastPingResult { get; set; }

        #region General properties
        private string address = "";
        public string Address { get { return address; } set { address = value; } }
        private string description = "";
        public string DescriptionLocal { get { return description; } set { description = value; } }
        private int maxTimeMS = 1000;
        public int MaxTimeMS { get { return maxTimeMS; } set { maxTimeMS = value; } }
        private int timeOutMS = 5000;
        public int TimeOutMS { get { return timeOutMS; } set { timeOutMS = value; } }
        public bool IgnoreInvalidHTTPSCerts { get; set; }
        #endregion

        #region HTTP ping
        public string HttpProxyServer { get; set; } 
        #endregion

        #region Socket ping
        private int socketPort = 23;
        public int SocketPort { get { return socketPort; } set { socketPort = value; } }
        private int receiveTimeOutMS = 30000;
        public int ReceiveTimeOutMS { get { return receiveTimeOutMS; } set { receiveTimeOutMS = value; } }
        private int sendTimeOutMS = 30000;
        public int SendTimeOutMS { get { return sendTimeOutMS; } set { sendTimeOutMS = value; } }
        public bool UseTelnetLogin { get; set; }
        public string TelnetUserName { get; set; }
        public string TelnetPassword { get; set; }
        #endregion

        #region Ping methods
        public PingCollectorResult Ping()
        {
            PingCollectorResult result = new PingCollectorResult();
            if (pingType == PingCollectorType.Ping)
                result = PingICMP();
            else if (pingType == PingCollectorType.HTTP)
                result = PingHTTP();
            else
                result = PingSocket();

            LastPingResult = result;
            return result;
        }
        private PingCollectorResult PingICMP()
        {
            PingCollectorResult result = new PingCollectorResult();
            result.Success = false;
            result.PingTime = -1;
            result.ResponseDetails = "";
            try
            {
                if (Address.ToLower() == "localhost" || Address.ToLower() == System.Net.Dns.GetHostName().ToLower())
                {
                    System.Net.IPHostEntry host;
                    host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                    foreach (System.Net.IPAddress ip in host.AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            result.ResponseDetails = ip.ToString();
                            result.PingTime = 0;
                            result.Success = true;
                            break;
                        }
                    }
                }
                else
                {
                    using (System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping())
                    {
                        System.Net.NetworkInformation.PingReply reply = ping.Send(Address, TimeOutMS);
                        if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                        {
                            result.PingTime = Convert.ToInt32(reply.RoundtripTime);
                            result.Success = true;
                            if (reply.Address != null)
                                result.ResponseDetails = reply.Address.ToString();
                        }
                        else // if (reply.Status == System.Net.NetworkInformation.IPStatus.TimedOut)
                        {
                            result.Success = false;
                            result.PingTime = -1;
                            result.ResponseDetails = reply.Status.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.PingTime = -1;
                if (ex.InnerException != null)
                    result.ResponseDetails = ex.InnerException.Message;
                else
                    result.ResponseDetails = ex.Message;
            }

            return result;
        }
        private PingCollectorResult PingHTTP()
        {
            PingCollectorResult result = new PingCollectorResult();
            string lastStep = "[Create WebClientEx]";
            result.Success = false;
            result.PingTime = -1;
            result.ResponseDetails = "";
            try
            {
                lastStep = "[HTTPSSetup]";
                if (Address.ToLower().StartsWith("https://"))
                {

                    System.Net.ServicePointManager.Expect100Continue = true;
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3;
                    if (IgnoreInvalidHTTPSCerts)
                        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    else
                        System.Net.ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate; // = delegate { return true; };
                }

                Stopwatch sw = new Stopwatch();
                using (WebClientEx wc = new WebClientEx())
                {
                    wc.Timeout = (TimeOutMS * 1000);
                    wc.UseDefaultCredentials = true;
                    if (HttpProxyServer.Length > 0)
                    {
                        wc.Proxy = new System.Net.WebProxy(HttpProxyServer);
                        wc.Proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                    }
                    else
                    {
                        wc.Proxy = null;
                    }
                    wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
                    sw.Start();
                    
                    lastStep = "[OpenRead]";
                    using (System.IO.Stream webRequest = wc.OpenRead(Address))
                    {
                        int chars = 0;
                        lastStep = "[CanRead]";
                        if (webRequest.CanRead)
                        {
                            lastStep = "[ReadByte]";
                            int readByte = webRequest.ReadByte();
                            while (readByte != -1) // && chars < 256)
                            {
                                readByte = webRequest.ReadByte();
                                chars++;
                                if (sw.ElapsedMilliseconds > TimeOutMS)
                                {
                                    break;
                                }
                            }
                            result.ResponseDetails = "Characters returned:" + chars.ToString();
                        }
                        else
                            throw new Exception("Could not read web request stream");
                    }
                    sw.Stop();
                }
                result.PingTime = (int)sw.ElapsedMilliseconds;
                if (sw.ElapsedMilliseconds < TimeOutMS)
                    result.Success = true;
                else
                {
                    result.Success = false;
                    result.ResponseDetails = "Operation timed out!\r\n" + result.ResponseDetails;
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.PingTime = -1;
                if (ex.InnerException != null)
                    result.ResponseDetails = lastStep + " " + ex.InnerException.Message;
                else
                    result.ResponseDetails = lastStep + " " + ex.Message;
            }
            return result;
        }
        /// <summary>
        /// Certificate validation callback.
        /// </summary>
        private static bool ValidateRemoteCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate cert, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors error)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (error == System.Net.Security.SslPolicyErrors.None)
            {
                return true;
            }

            //Console.WriteLine("X509Certificate [{0}] Policy Error: '{1}'",
            //    cert.Subject,
            //    error.ToString());

            return false;
        }
        private PingCollectorResult PingSocket()
        {
            PingCollectorResult result = new PingCollectorResult();
            result.Success = false;
            result.PingTime = -1;
            result.ResponseDetails = "";
            try
            {
                TcpClient tcpSocket = new TcpClient();
                Stopwatch sw = new Stopwatch();
                string s = "";

                tcpSocket.ReceiveTimeout = receiveTimeOutMS;
                tcpSocket.SendTimeout = sendTimeOutMS;
                sw.Start();
                tcpSocket.Connect(address, socketPort);
                if (UseTelnetLogin)
                {
                    //the following is a Telnet protocol login so other protocals probably won't work with this.
                    s = Read(tcpSocket);
                    if (!s.TrimEnd().EndsWith(":"))
                        throw new Exception("Failed to connect : no login prompt");
                    WriteLine(tcpSocket, TelnetUserName);
                    s += Read(tcpSocket);
                    if (!s.TrimEnd().EndsWith(":"))
                        throw new Exception("Failed to connect : no password prompt");
                    WriteLine(tcpSocket, TelnetPassword);

                    s += Read(tcpSocket);
                }
                Write(tcpSocket, "Hello");
                s = Read(tcpSocket); // not doing anything with response
                sw.Stop();
                try
                {
                    if (tcpSocket != null)
                        tcpSocket.Close();
                    tcpSocket = null;
                }
                catch { }
                result.PingTime = (int)sw.ElapsedMilliseconds;
                result.ResponseDetails = "Success";
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.PingTime = -1;
                if (ex.InnerException != null)
                    result.ResponseDetails = ex.InnerException.Message;
                else
                    result.ResponseDetails = ex.Message;
            }
            return result;
        }
        #region Socket tools
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
        #endregion
        #endregion

        #region GetState
        public CollectorState GetState(PingCollectorResult pingResult)
        {
            CollectorState result = CollectorState.Good;
            if (pingResult.PingTime > -1)//  pingResult.Success)
            {
                if (pingResult.PingTime > TimeOutMS)
                {
                    result = CollectorState.Error;
                    pingResult.ResponseDetails = string.Format("Operation timed out! Max time allowed: {0}ms, {1}", TimeOutMS, pingResult.ResponseDetails);
                }
                else if (pingResult.PingTime > MaxTimeMS)
                {
                    result = CollectorState.Warning;
                    pingResult.ResponseDetails = string.Format("Operation did not finished in allowed time! Excepted time: {0}ms, {1}", MaxTimeMS, pingResult.ResponseDetails);
                }
                else
                {
                    result = CollectorState.Good;
                }
            }
            else
            {
                result = CollectorState.Error;
            }
            return result;
        } 
        #endregion

        public override string ToString()
        {
            return string.Format("[{0}] {1}", PingCollectorTypeHelper.ToString(pingType), address + (pingType == PingCollectorType.Socket ? (":" + socketPort.ToString()) : ""));
        }
    }
}
