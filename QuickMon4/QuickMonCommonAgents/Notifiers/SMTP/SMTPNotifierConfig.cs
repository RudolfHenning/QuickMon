using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Notifiers
{
    public class SMTPNotifierConfig : INotifierConfig
    {
        #region Properties
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
        #endregion

        #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            XmlNode connectionNode = root.SelectSingleNode("smtp");
            HostServer = connectionNode.ReadXmlElementAttr("hostServer", "");
            UseDefaultCredentials = bool.Parse(connectionNode.ReadXmlElementAttr("useDefaultCredentials", "True"));
            UseTLS = bool.Parse(connectionNode.ReadXmlElementAttr("useTLS", "False"));
            Port = int.Parse(connectionNode.ReadXmlElementAttr("port", "25"));
            Domain = connectionNode.ReadXmlElementAttr("domain", "");
            UserName = connectionNode.ReadXmlElementAttr("userName", "");
            Password = connectionNode.ReadXmlElementAttr("password", "");
            FromAddress = connectionNode.ReadXmlElementAttr("fromAddress", "");
            SenderAddress = connectionNode.ReadXmlElementAttr("senderAddress", "");
            ReplyToAddress = connectionNode.ReadXmlElementAttr("replyToAddress", "");
            MailPriority = int.Parse(connectionNode.ReadXmlElementAttr("mailPriority", "1"));
            ToAddress = connectionNode.ReadXmlElementAttr("toAddress", "");
            IsBodyHtml = bool.Parse(connectionNode.ReadXmlElementAttr("isBodyHtml", "True"));
            Subject = connectionNode.ReadXmlElementAttr("subject", "");
            Body = connectionNode.ReadXmlElementAttr("body", "");
        }
        public string ToXml()
        {
            XmlDocument configXml = new XmlDocument();
            configXml.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = configXml.DocumentElement;
            XmlNode connectionNode = root.SelectSingleNode("smtp");
            connectionNode.SetAttributeValue("hostServer", HostServer);
            connectionNode.SetAttributeValue("useDefaultCredentials", UseDefaultCredentials.ToString());
            connectionNode.SetAttributeValue("domain", Domain);
            connectionNode.SetAttributeValue("userName", UserName);
            connectionNode.SetAttributeValue("password", Password);
            connectionNode.SetAttributeValue("fromAddress", FromAddress);
            connectionNode.SetAttributeValue("toAddress", ToAddress);
            connectionNode.SetAttributeValue("senderAddress", SenderAddress);
            connectionNode.SetAttributeValue("replyToAddress", ReplyToAddress);
            connectionNode.SetAttributeValue("mailPriority", MailPriority);
            connectionNode.SetAttributeValue("isBodyHtml", IsBodyHtml.ToString());
            connectionNode.SetAttributeValue("subject", Subject);
            connectionNode.SetAttributeValue("body", Body);
            connectionNode.SetAttributeValue("useTLS", UseTLS.ToString());
            connectionNode.SetAttributeValue("port", Port.ToString());
            return configXml.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config>\r\n<smtp hostServer=\"\" useDefaultCredentials=\"True\" domain=\"\" userName=\"\" password=\"\" " +
                 "fromAddress=\"\" toAddress=\"\" senderAddress=\"\" replyToAddress=\"\" mailPriority=\"1\" useTLS=\"false\" isBodyHtml=\"True\" port=\"25\" " +
                 "subject=\"%AlertLevel% - %CollectorName%\" body=\"QuickMon alert raised for &lt;b&gt;'%CollectorName%'&lt;/b&gt;&lt;br /&gt;\r\n" +
                     "&lt;b&gt;Date Time:&lt;/b&gt; %DateTime%&lt;br /&gt;\r\n" +
                     "&lt;b&gt;Current state:&lt;/b&gt; %CurrentState%&lt;br /&gt;\r\n" +
                     "&lt;b&gt;Agents:&lt;/b&gt; %CollectorAgents%&lt;br /&gt;\r\n" +
                     "&lt;b&gt;Details&lt;/b&gt;&lt;blockquote&gt;%Details%&lt;/blockquote&gt;\" />\r\n</config>";
        }
        public string ConfigSummary
        {
            get
            {
                string summary = string.Format("SMTP server: {0}, Port: {1}, From address: {2}, To addresses: {3}, Priority: {4}, Format: {5}, Subject: {6}",
                    HostServer, Port, FromAddress, ToAddress,
                    (MailPriority == 0 ? "Normal" : MailPriority == 0 ? "Low" : "High"),
                    (IsBodyHtml ? "HTML" : "Plain"),
                    Subject);
                return summary;
            }
        }
        #endregion
    }
}
