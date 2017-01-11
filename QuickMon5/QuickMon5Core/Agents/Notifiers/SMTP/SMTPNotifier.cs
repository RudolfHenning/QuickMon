using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Xml;

namespace QuickMon.Notifiers
{
    [Description("SMTP Notifier")]
    public class SMTPNotifier : NotifierAgentBase
    {
        public SMTPNotifier()
        {
            AgentConfig = new SMTPNotifierConfig();
        }

        public override void RecordMessage(AlertRaised alertRaised)
        {
            string lastStep = "";
            try
            {
                SMTPNotifierConfig mailSettings = (SMTPNotifierConfig)AgentConfig;
                if (mailSettings.HostServer.Length == 0)
                {
                    throw new Exception("SMTP host server not specified!");
                }
                lastStep = "Setting up SMTP client details";
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Host = mailSettings.HostServer;
                    smtpClient.UseDefaultCredentials = mailSettings.UseDefaultCredentials;
                    smtpClient.Port = mailSettings.Port;

                    if (!mailSettings.UseDefaultCredentials)
                    {
                        lastStep = "Setting up non default credentials";
                        System.Net.NetworkCredential cr = new System.Net.NetworkCredential();
                        cr.Domain = mailSettings.Domain;
                        cr.UserName = mailSettings.UserName;
                        cr.Password = mailSettings.Password;
                        smtpClient.Credentials = cr;
                    }
                    if (mailSettings.UseTLS)
                    {
                        smtpClient.EnableSsl = true;
                    }
                    MailMessage mailMessage = new MailMessage(mailSettings.FromAddress, mailSettings.ToAddress);

                    string collectorName = "QuickMon Global Alert";
                    string collectorAgents = "None";
                    string oldState = "N/A";
                    string newState = "N/A";
                    string detailMessage = "N/A";
                    string viaHost = "";
                    if (alertRaised.RaisedFor != null)
                    {
                        collectorName = alertRaised.RaisedFor.Name;
                        collectorAgents = string.Format("{0} agent(s)", alertRaised.RaisedFor.CollectorAgents.Count);
                        if (alertRaised.RaisedFor.CollectorAgents.Count > 0)
                        {
                            collectorAgents += " {";
                            alertRaised.RaisedFor.CollectorAgents.ForEach(ca => collectorAgents += ca.AgentClassDisplayName + ",");
                            collectorAgents = collectorAgents.TrimEnd(',') + "}";
                        }
                        oldState = Enum.GetName(typeof(CollectorState), alertRaised.RaisedFor.PreviousState.State);
                        newState = Enum.GetName(typeof(CollectorState), alertRaised.RaisedFor.CurrentState.State);
                        detailMessage = mailSettings.IsBodyHtml ? alertRaised.RaisedFor.CurrentState.ReadAllHtmlDetails() : alertRaised.RaisedFor.CurrentState.ReadAllRawDetails();
                        if (alertRaised.RaisedFor.OverrideRemoteAgentHost)
                            viaHost = string.Format(" (via {0}:{1})", alertRaised.RaisedFor.OverrideRemoteAgentHostAddress, alertRaised.RaisedFor.OverrideRemoteAgentHostPort);
                        else if (alertRaised.RaisedFor.EnableRemoteExecute)
                            viaHost = string.Format(" (via {0}:{1})", alertRaised.RaisedFor.RemoteAgentHostAddress, alertRaised.RaisedFor.RemoteAgentHostPort);
                    }

                    lastStep = "Setting up mail body";
                    string body = mailSettings.Body
                        .Replace("%Details%", detailMessage)
                    .Replace("%DateTime%", DateTime.Now.ToString("F"))
                    .Replace("%AlertLevel%", Enum.GetName(typeof(AlertLevel), alertRaised.Level))
                    .Replace("%PreviousState%", oldState)
                    .Replace("%CurrentState%", newState)
                    .Replace("%CollectorName%", collectorName + viaHost)
                    .Replace("%CollectorAgents%", collectorAgents);

                    string subject = mailSettings.Subject
                       .Replace("%DateTime%", DateTime.Now.ToString("F"))
                       .Replace("%AlertLevel%", Enum.GetName(typeof(AlertLevel), alertRaised.Level))
                       .Replace("%PreviousState%", oldState)
                       .Replace("%CurrentState%", newState)
                       .Replace("%CollectorName%", collectorName + viaHost)
                       .Replace("%CollectorAgents%", collectorAgents);

                    mailMessage.Priority = (MailPriority)mailSettings.MailPriority;
                    if (mailSettings.SenderAddress.Length > 0)
                        mailMessage.Sender = new MailAddress(mailSettings.SenderAddress);
                    if (mailSettings.ReplyToAddress.Length > 0)
                    {
                        mailMessage.ReplyToList.Add(mailSettings.ReplyToAddress);
                    }

                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = mailSettings.IsBodyHtml;

                    mailMessage.Subject = subject;
                    lastStep = "Sending SMTP mail";
                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error recording message in SMTP notifier\r\nLast step: " + lastStep, ex);
            }
        }

        public override AttendedOption AttendedRunOption { get { return AttendedOption.AttendedAndUnAttended; } }
    }
    public class SMTPNotifierConfig : INotifierConfig
    {
        public SMTPNotifierConfig()
        {
            MailPriority = 0;
        }
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
            MailPriority = int.Parse(connectionNode.ReadXmlElementAttr("mailPriority", "0"));
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
