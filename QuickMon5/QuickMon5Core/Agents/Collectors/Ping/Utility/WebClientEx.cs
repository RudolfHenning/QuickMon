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
        public bool AllowRedirect { get; set; } = true;
        public WebResponse LastWebResponse { get; private set; }
        

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
                ((HttpWebRequest)request).AllowAutoRedirect = AllowRedirect;
            }

            return request;
        }
        protected override WebResponse GetWebResponse(WebRequest request)
        {
            try
            {
                LastWebResponse = base.GetWebResponse(request);
            }
            catch (Exception ex)
            {
                LastWebResponse = null;
                if (ex is System.Net.WebException)
                {
                    if (((System.Net.WebException)ex).Response != null && ((System.Net.WebException)ex).Response is System.Net.HttpWebResponse)
                    {
                        LastWebResponse = ((System.Net.HttpWebResponse)((System.Net.WebException)ex).Response);                        
                    }
                }
            }
            return LastWebResponse;
        }
    }
}
