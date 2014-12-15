using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Net.Mail;

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
}
