using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace QuickMon
{
    public class HttpPingEntry
    {
        public HttpPingEntry()
        {
            Url = "";
            ProxyServer = "";
        }
        public string Url { get; set; }
        public string ProxyServer { get; set; }
        private int maxTime = 1000;
        public int MaxTime { get { return maxTime; } set { maxTime = value; } }
        private int timeOut = 5000;
        public int TimeOut { get { return timeOut; } set { timeOut = value; } }
        public string LastError { get; private set; }

        public int Ping()
        {
            int pingTime = 0;
            try
            {
                Stopwatch sw = new Stopwatch();
                LastError = "";
                
                using (WebClientEx wc = new WebClientEx())
                {
                    wc.Timeout = (timeOut * 1000);
                    wc.UseDefaultCredentials = true;
                    
                    if (ProxyServer.Length > 0)
                    {
                        wc.Proxy = new System.Net.WebProxy(ProxyServer);
                        wc.Proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                    }
                    else
                    {
                        wc.Proxy = null;
                    }                    
                    wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);

                    sw.Start();
                    using (System.IO.Stream webRequest = wc.OpenRead(Url))
                    {
                        if (webRequest.CanRead)
                        {
                            int readByte = webRequest.ReadByte();
                            while (readByte != -1)
                            {
                                readByte = webRequest.ReadByte();
                            }
                        }
                        else
                            throw new Exception("Could not read web request stream");
                    }
                    sw.Stop();
                }                
                pingTime = (int)sw.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                pingTime = int.MaxValue;
            }

            return pingTime;
        }
    }
}
