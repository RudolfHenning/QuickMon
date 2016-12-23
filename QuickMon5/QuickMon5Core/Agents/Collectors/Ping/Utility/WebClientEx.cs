using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace QuickMon.Collectors
{
    public class WebClientEx : WebClient
    {
        private System.Net.CookieContainer cookieContainer;
        private string userAgent;
        private int timeout;
        private bool keepAlive;

        public System.Net.CookieContainer CookieContainer
        {
            get { return cookieContainer; }
            set { cookieContainer = value; }
        }

        public string UserAgent
        {
            get { return userAgent; }
            set { userAgent = value; }
        }

        public int Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }

        public bool KeepAlive
        {
            get { return keepAlive; }
            set { keepAlive = value; }
        }

        public WebClientEx()
        {
            timeout = -1;
            userAgent = @"HTTPPing v1.0";
            cookieContainer = new CookieContainer();
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);

            if (request.GetType() == typeof(HttpWebRequest))
            {
                ((HttpWebRequest)request).CookieContainer = cookieContainer;
                ((HttpWebRequest)request).UserAgent = userAgent;
                ((HttpWebRequest)request).Timeout = timeout;
                ((HttpWebRequest)request).KeepAlive = keepAlive;
            }

            return request;
        }
    }
}
