using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net.Sockets;
using System.Diagnostics;

namespace QuickMon.Collectors
{
    [Description("Ping Collector"), Category("General")]
    public class PingCollector : CollectorAgentBase
    {
        public PingCollector()
        {
            AgentConfig = new PingCollectorConfig();
        }
        //public override List<System.Data.DataTable> GetDetailDataTables()
        //{
        //    List<System.Data.DataTable> tables = new List<System.Data.DataTable>();
        //    System.Data.DataTable dt = new System.Data.DataTable();
        //    try
        //    {
        //        dt.Columns.Add(new System.Data.DataColumn("Host name", typeof(string)));
        //        dt.Columns.Add(new System.Data.DataColumn("Success", typeof(bool)));
        //        dt.Columns.Add(new System.Data.DataColumn("Ping time", typeof(int)));
        //        dt.Columns.Add(new System.Data.DataColumn("Response", typeof(string)));                

        //        PingCollectorConfig currentConfig = (PingCollectorConfig)AgentConfig;
        //        foreach (PingCollectorHostEntry host in currentConfig.Entries) //.OrderBy(h => ((PingCollectorHostEntry)h).Address))
        //        {
        //            PingCollectorResult pingResult = host.Ping();
        //            dt.Rows.Add(host.Address, pingResult.Success, pingResult.PingTime, pingResult.ResponseDetails);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dt = new System.Data.DataTable("Exception");
        //        dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
        //        dt.Rows.Add(ex.ToString());
        //    }
        //    tables.Add(dt);
        //    return tables;
        //}
    }

    public class PingCollectorConfig : ICollectorConfig
    {
        public PingCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            Entries.Clear();
            XmlElement root = config.DocumentElement;

            foreach (XmlElement host in root.SelectNodes("entries/entry"))
            {
                PingCollectorHostEntry hostEntry = new PingCollectorHostEntry();
                hostEntry.PingType = PingCollectorTypeHelper.FromText(host.ReadXmlElementAttr("pingMethod", "Ping"));
                hostEntry.Address = host.ReadXmlElementAttr("address");
                hostEntry.DescriptionLocal = host.ReadXmlElementAttr("description");
                int tmp = 0;
                if (int.TryParse(host.ReadXmlElementAttr("maxTimeMS", "1000"), out tmp))
                    hostEntry.MaxTimeMS = tmp;
                if (int.TryParse(host.ReadXmlElementAttr("timeOutMS", "5000"), out tmp))
                    hostEntry.TimeOutMS = tmp;

                hostEntry.HttpHeaderUserName = host.ReadXmlElementAttr("httpHeaderUser");
                hostEntry.HttpHeaderPassword = host.ReadXmlElementAttr("httpHeaderPwd");

                hostEntry.HttpProxyServer = host.ReadXmlElementAttr("httpProxyServer");
                hostEntry.HttpProxyUserName = host.ReadXmlElementAttr("httpProxyUser");
                hostEntry.HttpProxyPassword = host.ReadXmlElementAttr("httpProxyPwd");

                if (hostEntry.PingType == PingCollectorType.HTTP)
                {
                    XmlNode htmlContentMatchNode = host.SelectSingleNode("htmlContentMatch");
                    if (htmlContentMatchNode != null)
                    {
                        hostEntry.HTMLContentContain = htmlContentMatchNode.InnerText;
                    }
                }

                if (int.TryParse(host.ReadXmlElementAttr("socketPort", "23"), out tmp))
                    hostEntry.SocketPort = tmp;
                if (int.TryParse(host.ReadXmlElementAttr("receiveTimeoutMS", "30000"), out tmp))
                    hostEntry.ReceiveTimeOutMS = tmp;
                if (int.TryParse(host.ReadXmlElementAttr("sendTimeoutMS", "30000"), out tmp))
                    hostEntry.SendTimeOutMS = tmp;
                bool btmp;
                if (bool.TryParse(host.ReadXmlElementAttr("useTelnetLogin", "false"), out btmp))
                    hostEntry.UseTelnetLogin = btmp;
                hostEntry.TelnetUserName = host.ReadXmlElementAttr("userName");
                hostEntry.TelnetPassword = host.ReadXmlElementAttr("password");
                hostEntry.IgnoreInvalidHTTPSCerts = host.ReadXmlElementAttr("ignoreInvalidHTTPSCerts", false);
                hostEntry.HttpsSecurityProtocol = host.ReadXmlElementAttr("httpsSecurityProtocol");
                hostEntry.AllowHTTP3xx = host.ReadXmlElementAttr("allowHTTP3xx", false);
                hostEntry.SocketPingMsgBody = host.ReadXmlElementAttr("socketPingMsgBody", "QuickMon Ping Test");
                hostEntry.PrimaryUIValue = host.ReadXmlElementAttr("primaryUIValue", false);

                Entries.Add(hostEntry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlNode hostsListNode = config.SelectSingleNode("config/entries");
            foreach (PingCollectorHostEntry hostEntry in Entries)
            {
                XmlNode hostXmlNode = config.CreateElement("entry");
                hostXmlNode.SetAttributeValue("pingMethod", PingCollectorTypeHelper.ToString(hostEntry.PingType));
                hostXmlNode.SetAttributeValue("address", hostEntry.Address);
                hostXmlNode.SetAttributeValue("description", hostEntry.DescriptionLocal);
                hostXmlNode.SetAttributeValue("maxTimeMS", hostEntry.MaxTimeMS);
                hostXmlNode.SetAttributeValue("timeOutMS", hostEntry.TimeOutMS);
                hostXmlNode.SetAttributeValue("httpHeaderUser", hostEntry.HttpHeaderUserName);
                hostXmlNode.SetAttributeValue("httpHeaderPwd", hostEntry.HttpHeaderPassword);
                hostXmlNode.SetAttributeValue("httpProxyServer", hostEntry.HttpProxyServer);
                hostXmlNode.SetAttributeValue("httpProxyUser", hostEntry.HttpProxyUserName);
                hostXmlNode.SetAttributeValue("httpProxyPwd", hostEntry.HttpProxyPassword);
                hostXmlNode.SetAttributeValue("socketPort", hostEntry.SocketPort);
                hostXmlNode.SetAttributeValue("receiveTimeoutMS", hostEntry.ReceiveTimeOutMS);
                hostXmlNode.SetAttributeValue("sendTimeoutMS", hostEntry.SendTimeOutMS);
                hostXmlNode.SetAttributeValue("useTelnetLogin", hostEntry.UseTelnetLogin);
                hostXmlNode.SetAttributeValue("userName", hostEntry.TelnetUserName);
                hostXmlNode.SetAttributeValue("password", hostEntry.TelnetPassword);
                hostXmlNode.SetAttributeValue("ignoreInvalidHTTPSCerts", hostEntry.IgnoreInvalidHTTPSCerts);
                hostXmlNode.SetAttributeValue("httpsSecurityProtocol", hostEntry.HttpsSecurityProtocol);
                hostXmlNode.SetAttributeValue("allowHTTP3xx", hostEntry.AllowHTTP3xx);
                hostXmlNode.SetAttributeValue("socketPingMsgBody", hostEntry.SocketPingMsgBody);
                hostXmlNode.SetAttributeValue("primaryUIValue", hostEntry.PrimaryUIValue);

                if (hostEntry.PingType == PingCollectorType.HTTP && hostEntry.HTMLContentContain.Trim().Length > 0)
                {
                    XmlNode htmlContentMatchNode = config.CreateElement("htmlContentMatch");
                    htmlContentMatchNode.InnerText = hostEntry.HTMLContentContain;
                    hostXmlNode.AppendChild(htmlContentMatchNode);
                }
                hostsListNode.AppendChild(hostXmlNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config><entries></entries></config>";
        }
        public string ConfigSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("{0} entry(s): ", Entries.Count));
                if (Entries.Count == 0)
                    sb.Append("None");
                else
                {
                    foreach (ICollectorConfigEntry entry in Entries)
                    {
                        sb.Append(entry.Description + ", ");
                    }
                }
                return sb.ToString().TrimEnd(' ', ',');
            }
        }
        #endregion
    }

    public class PingCollectorResult
    {
        public PingCollectorResult()
        {
            Success = false;
            PingTime = 0;
            ResponseDetails = "";
            ResponseContent = "";
        }
        public bool Success { get; set; }
        public int PingTime { get; set; }
        public string ResponseDetails { get; set; }
        public string ResponseContent { get; set; }
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
            HTMLContentContain = "";
            SocketPingMsgBody = "QuickMon Ping Test";
            HttpsSecurityProtocol = System.Net.SecurityProtocolType.Ssl3.ToString();
        }

        #region ICollectorConfigEntry Members
        public string Description
        {
            get
            {
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
        public MonitorState GetCurrentState()
        {
            PingCollectorResult pingResult = Ping();
            CurrentAgentValue = pingResult;
            MonitorState currentState = new MonitorState()
            {
                ForAgent = Address,
                CurrentValue = pingResult.PingTime,
                CurrentValueUnit = "ms"
            };

            if (!pingResult.Success)
            {
                currentState.CurrentValue = pingResult.ResponseDetails;
                currentState.State = CollectorState.Error;
                currentState.RawDetails = pingResult.ResponseDetails;
                if (pingResult.ResponseContent != null && pingResult.ResponseContent.Length > 0)
                {
                    currentState.RawDetails += $"\r\n{pingResult.ResponseContent}";
                }
                currentState.CurrentValueUnit = "";
            }
            else if (pingResult.PingTime > -1)
            {
                if (pingResult.PingTime >= TimeOutMS)
                {
                    //currentState.CurrentValue += " (Time out)";
                    currentState.CurrentValueUnit = "ms (Time out)";
                    currentState.State = CollectorState.Error;
                    currentState.RawDetails = string.Format("Operation timed out! Max time allowed: {0}ms, {1}", TimeOutMS, pingResult.ResponseDetails);
                }
                else if (pingResult.PingTime > MaxTimeMS)
                {
                    currentState.State = CollectorState.Warning;
                    currentState.RawDetails = string.Format("Operation did not finished in allowed time! Excepted time: {0}ms, {1}", MaxTimeMS, pingResult.ResponseDetails);
                }
                else if (pingType == PingCollectorType.HTTP && HTMLContentContain != null && pingResult.ResponseContent.Trim().Length > 0 && HTMLContentContain.Trim().Length > 0 && !pingResult.ResponseContent.Contains(HTMLContentContain))
                {
                    currentState.State = CollectorState.Warning;
                    currentState.RawDetails = string.Format("The returned HTML does not contain the specified string '{0}'", HTMLContentContain);
                    if (pingResult.ResponseContent != null && pingResult.ResponseContent.Length > 0)
                    {
                        currentState.RawDetails += $"\r\n{pingResult.ResponseContent}";
                    }
                }
                else
                {
                    currentState.State = CollectorState.Good;
                    currentState.RawDetails = pingResult.ResponseDetails;
                    if (pingResult.ResponseContent != null && pingResult.ResponseContent.Length > 0)
                    {
                        if (currentState.RawDetails.Length > 0) currentState.RawDetails += "\r\n";
                        currentState.RawDetails += $"{pingResult.ResponseContent}";
                    }
                }
            }
            else
            {
                currentState.State = CollectorState.Error;
                if (pingResult.ResponseDetails == "No such host is known")
                {
                    currentState.CurrentValue = "Host not found";
                    currentState.CurrentValueUnit = "";
                }
                else if (pingResult.ResponseDetails == "DestinationHostUnreachable")
                {
                    currentState.CurrentValue = "Host unreachable";
                    currentState.CurrentValueUnit = "";
                }
                else
                {
                    currentState.CurrentValue = pingResult.ResponseDetails;
                    currentState.CurrentValueUnit = "";
                }
                currentState.RawDetails = pingResult.ResponseDetails;
            }
           
            return currentState;
        }
        public object CurrentAgentValue { get; set; }
        public bool PrimaryUIValue { get; set; }
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
        #endregion

        #region HTTP ping
        public string HttpHeaderUserName { get; set; }
        public string HttpHeaderPassword { get; set; }
        public string HttpProxyServer { get; set; }
        public string HttpProxyUserName { get; set; }
        public string HttpProxyPassword { get; set; }
        public string HTMLContentContain { get; set; }
        public string HttpsSecurityProtocol { get; set; }
        public bool IgnoreInvalidHTTPSCerts { get; set; }
        public bool AllowHTTP3xx { get; set; }
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
        public string SocketPingMsgBody { get; set; }
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
                    System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
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
                    host = null;
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
                        else  if (reply.Status == System.Net.NetworkInformation.IPStatus.TimedOut)
                        {
                            result.PingTime = TimeOutMS;
                            result.Success = true; //the operation was still successfull
                            result.ResponseDetails = "Timed out";
                        }
                        else if (reply.Status == System.Net.NetworkInformation.IPStatus.DestinationHostUnreachable)
                        {
                            result.PingTime = -1;
                            result.ResponseDetails = "Host unreachable";
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
            int httpCode = 200;
            string httpCodeStr = "OK";
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
                    if (HttpsSecurityProtocol == "Tls")
                        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls;
                    else if (HttpsSecurityProtocol == "Tls11")
                        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;
                    else if (HttpsSecurityProtocol == "Tls12")
                        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                    else
                        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3;

                    //TLS13 = 12288 - only in .Net 4.8

                    if (IgnoreInvalidHTTPSCerts)
                        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    else
                        System.Net.ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
                }

                Stopwatch sw = new Stopwatch();
                using (WebClientEx wc = new WebClientEx())
                {
                    wc.Timeout = (TimeOutMS * 1000);
                    if (HttpProxyServer.Length > 0)
                    {
                        System.Net.WebProxy proxy = null;
                        System.Net.ICredentials credentials = null;
                        if (HttpProxyUserName.Length == 0)
                        {
                            credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                            proxy = new System.Net.WebProxy(HttpProxyServer, true, null, credentials);
                            proxy.UseDefaultCredentials = true;
                        }
                        else
                        {
                            if (HttpProxyUserName.Contains('\\'))
                            {
                                string domain = HttpProxyUserName.Split('\\')[0];
                                string userName = HttpProxyUserName.Split('\\')[1];
                                credentials = new System.Net.NetworkCredential(userName, HttpProxyPassword, domain);
                            }
                            else
                                credentials = new System.Net.NetworkCredential(HttpProxyUserName, HttpProxyPassword);
                            proxy = new System.Net.WebProxy(HttpProxyServer, true, null, credentials);
                            proxy.UseDefaultCredentials = false;
                            proxy.Credentials = credentials;
                        }
                        wc.Proxy = proxy;
                    }
                    else
                    {
                        wc.Proxy = null;
                    }
                    wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);

                    if (HttpHeaderUserName.Trim().Length > 0)
                    {
                        wc.UseDefaultCredentials = false;
                        wc.Credentials = new System.Net.NetworkCredential(HttpHeaderUserName, HttpHeaderPassword);
                    }
                    else
                        wc.UseDefaultCredentials = true;
                    wc.AllowRedirect = AllowHTTP3xx;

                    sw.Start();
                    lastStep = "[OpenRead]";
                    using (System.IO.Stream webRequest = wc.OpenRead(Address))
                    {
                        lastStep = "[CheckHTTPStatus]";
                        if (wc.LastWebResponse != null)
                        {
                            httpCode = (int)(((System.Net.HttpWebResponse)wc.LastWebResponse).StatusCode);
                            httpCodeStr = (((System.Net.HttpWebResponse)wc.LastWebResponse).StatusCode).ToString();
                            Trace.WriteLine($"HTTP Status Code: {httpCode}");
                        }

                        int chars = 0;
                        StringBuilder docContents = new StringBuilder();
                        lastStep = "[CanRead]";
                        if (webRequest.CanRead)
                        {
                            lastStep = "[ReadByte]";
                            int readByte = webRequest.ReadByte();
                            while (readByte != -1) // && chars < 256)
                            {
                                chars++;
                                docContents.Append(Char.ConvertFromUtf32(readByte));
                                readByte = webRequest.ReadByte();

                                if (sw.ElapsedMilliseconds > TimeOutMS)
                                {
                                    break;
                                }
                            }
                            if (chars > 1)
                            {                                
                                result.ResponseContent = $"Response length: {chars}\r\n{docContents}";                                
                                foreach (var rh in wc.ResponseHeaders)
                                {
                                    Trace.WriteLine(rh.ToString());
                                }                                
                            }
                        }
                        else
                            throw new Exception("Could not read web request stream");
                    }
                    sw.Stop();
                }

                if (httpCode < 300)
                {
                    result.PingTime = (int)sw.ElapsedMilliseconds;
                    result.Success = true;
                    //if (sw.ElapsedMilliseconds < TimeOutMS)
                    //{
                    //    result.Success = true;
                    //}
                    //else
                    //{
                    //    result.Success = false;
                    //}
                } 
                else if (httpCode < 400 && !AllowHTTP3xx)
                {
                    result.PingTime = -1; // (int)sw.ElapsedMilliseconds;
                    result.Success = false;
                    result.ResponseDetails = $"HTTP code: {httpCode}";
                }
                else if (httpCode < 400)
                {
                    result.PingTime = (int)sw.ElapsedMilliseconds;
                    result.Success = true;
                    //result.ResponseDetails = $"HTTP code: {httpCode}";
                }
                else
                {
                    result.Success = false;
                    result.PingTime = -1;
                    result.ResponseDetails = $"HTTP code: {httpCode}";
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.PingTime = -1;

                if (ex is System.Net.WebException)
                {
                    if (((System.Net.WebException)ex).Response != null && ((System.Net.WebException)ex).Response is System.Net.HttpWebResponse)
                    {
                        System.Net.HttpWebResponse httpResp = ((System.Net.HttpWebResponse)((System.Net.WebException)ex).Response);
                        if (httpResp.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            result.ResponseDetails = string.Format("The URL '{0}' requires authorization to connect - i.e. Username/Password", Address);
                        }
                        else
                        {
                            result.ResponseDetails = string.Format("The URL '{0}' returned an HTTP error: {1}", httpResp, ex);
                        }
                    }
                    else
                    {
                        result.ResponseDetails = lastStep + " " + ex.Message;
                    }
                }
                else
                {
                    if (ex.InnerException != null)
                        result.ResponseDetails = lastStep + " " + ex.InnerException.Message;
                    else
                        result.ResponseDetails = lastStep + " " + ex.Message;
                }
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
                Stopwatch sw = new Stopwatch();
                using (TcpClient tcpSocket = new TcpClient())
                {
                    sw.Reset();
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
                    Write(tcpSocket, SocketPingMsgBody);
                    s = Read(tcpSocket); // not doing anything with response
                    sw.Stop();
                }
                //try
                //{
                //    if (tcpSocket != null)
                //        tcpSocket.Close();
                //    tcpSocket = null;
                //}
                //catch { }
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

        #region GetCurrentState
        //public CollectorState GetState(PingCollectorResult pingResult)
        //{
        //    CollectorState result = CollectorState.Good;
        //    if (pingResult.PingTime > -1)
        //    {
        //        if (pingResult.PingTime > TimeOutMS)
        //        {
        //            result = CollectorState.Error;
        //            pingResult.ResponseDetails = string.Format("Operation timed out! Max time allowed: {0}ms, {1}", TimeOutMS, pingResult.ResponseDetails);
        //        }
        //        else if (pingResult.PingTime > MaxTimeMS)
        //        {
        //            result = CollectorState.Warning;
        //            pingResult.ResponseDetails = string.Format("Operation did not finished in allowed time! Excepted time: {0}ms, {1}", MaxTimeMS, pingResult.ResponseDetails);
        //        }
        //        else if (pingType == PingCollectorType.HTTP && HTMLContentContain != null && pingResult.ResponseContent.Trim().Length > 0 && HTMLContentContain.Trim().Length > 0 && !pingResult.ResponseContent.Contains(HTMLContentContain))
        //        {
        //            result = CollectorState.Warning;
        //            pingResult.ResponseDetails = string.Format("The returned HTML does not contain the specified string '{0}'", HTMLContentContain);
        //        }
        //        else
        //        {
        //            result = CollectorState.Good;
        //        }
        //    }
        //    else
        //    {
        //        result = CollectorState.Error;
        //    }
        //    return result;
        //}
        

        #endregion
    }
}
