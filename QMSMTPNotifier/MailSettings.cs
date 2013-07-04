using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class MailSettings
    {
        public string HostServer { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string Domain { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FromAddress { get; set; }
        public string SenderAddress { get; set; }
        public string ReplyToAddress { get; set; }
        public string ToAddress { get; set; }
        public int MailPriority { get; set; }
        public bool IsBodyHtml { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool UseTLS { get; set; }
        public int Port { get; set; }
    }
}
