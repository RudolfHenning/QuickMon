using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("SSH Command Collector"), Category("SSH")]
    public class SSHCommandCollector : CollectorAgentBase
    {
        public SSHCommandCollector()
        {
            AgentConfig = new SSHCommandCollectorConfig();
        }
        public override List<DataTable> GetDetailDataTables()
        {
            throw new NotImplementedException();
        }
    }

    public class SSHCommandCollectorConfig : ICollectorConfig
    {
        public SSHCommandCollectorConfig()
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

            foreach (XmlElement host in root.SelectNodes("entries/carvcesEntries"))
            {
                SSHCommandCollectorConfigEntry sshEntry = new SSHCommandCollectorConfigEntry();
                //hostEntry.PingType = PingCollectorTypeHelper.FromText(host.ReadXmlElementAttr("pingMethod", "Ping"));
                //hostEntry.Address = host.ReadXmlElementAttr("address");
                //hostEntry.DescriptionLocal = host.ReadXmlElementAttr("description");
                //int tmp = 0;
                //if (int.TryParse(host.ReadXmlElementAttr("maxTimeMS", "1000"), out tmp))
                //    hostEntry.MaxTimeMS = tmp;
                //if (int.TryParse(host.ReadXmlElementAttr("timeOutMS", "5000"), out tmp))
                //    hostEntry.TimeOutMS = tmp;

                //hostEntry.HttpHeaderUserName = host.ReadXmlElementAttr("httpHeaderUser");
                //hostEntry.HttpHeaderPassword = host.ReadXmlElementAttr("httpHeaderPwd");

                //hostEntry.HttpProxyServer = host.ReadXmlElementAttr("httpProxyServer");
                //hostEntry.HttpProxyUserName = host.ReadXmlElementAttr("httpProxyUser");
                //hostEntry.HttpProxyPassword = host.ReadXmlElementAttr("httpProxyPwd");

                //if (hostEntry.PingType == PingCollectorType.HTTP)
                //{
                //    XmlNode htmlContentMatchNode = host.SelectSingleNode("htmlContentMatch");
                //    if (htmlContentMatchNode != null)
                //    {
                //        hostEntry.HTMLContentContain = htmlContentMatchNode.InnerText;
                //    }
                //}

                //if (int.TryParse(host.ReadXmlElementAttr("socketPort", "23"), out tmp))
                //    hostEntry.SocketPort = tmp;
                //if (int.TryParse(host.ReadXmlElementAttr("receiveTimeoutMS", "30000"), out tmp))
                //    hostEntry.ReceiveTimeOutMS = tmp;
                //if (int.TryParse(host.ReadXmlElementAttr("sendTimeoutMS", "30000"), out tmp))
                //    hostEntry.SendTimeOutMS = tmp;
                //bool btmp;
                //if (bool.TryParse(host.ReadXmlElementAttr("useTelnetLogin", "false"), out btmp))
                //    hostEntry.UseTelnetLogin = btmp;
                //hostEntry.TelnetUserName = host.ReadXmlElementAttr("userName");
                //hostEntry.TelnetPassword = host.ReadXmlElementAttr("password");
                //hostEntry.IgnoreInvalidHTTPSCerts = host.ReadXmlElementAttr("ignoreInvalidHTTPSCerts", false);
                //hostEntry.SocketPingMsgBody = host.ReadXmlElementAttr("socketPingMsgBody", "QuickMon Ping Test");
                //hostEntry.PrimaryUIValue = host.ReadXmlElementAttr("primaryUIValue", false);

                //Entries.Add(hostEntry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlNode carvcesEntriesNode = config.SelectSingleNode("config/carvcesEntries");
            foreach (PingCollectorHostEntry hostEntry in Entries)
            {
                //XmlNode hostXmlNode = config.CreateElement("entry");
                //hostXmlNode.SetAttributeValue("pingMethod", PingCollectorTypeHelper.ToString(hostEntry.PingType));
                //hostXmlNode.SetAttributeValue("address", hostEntry.Address);
                //hostXmlNode.SetAttributeValue("description", hostEntry.DescriptionLocal);
                //hostXmlNode.SetAttributeValue("maxTimeMS", hostEntry.MaxTimeMS);
                //hostXmlNode.SetAttributeValue("timeOutMS", hostEntry.TimeOutMS);
                //hostXmlNode.SetAttributeValue("httpHeaderUser", hostEntry.HttpHeaderUserName);
                //hostXmlNode.SetAttributeValue("httpHeaderPwd", hostEntry.HttpHeaderPassword);
                //hostXmlNode.SetAttributeValue("httpProxyServer", hostEntry.HttpProxyServer);
                //hostXmlNode.SetAttributeValue("httpProxyUser", hostEntry.HttpProxyUserName);
                //hostXmlNode.SetAttributeValue("httpProxyPwd", hostEntry.HttpProxyPassword);
                //hostXmlNode.SetAttributeValue("socketPort", hostEntry.SocketPort);
                //hostXmlNode.SetAttributeValue("receiveTimeoutMS", hostEntry.ReceiveTimeOutMS);
                //hostXmlNode.SetAttributeValue("sendTimeoutMS", hostEntry.SendTimeOutMS);
                //hostXmlNode.SetAttributeValue("useTelnetLogin", hostEntry.UseTelnetLogin);
                //hostXmlNode.SetAttributeValue("userName", hostEntry.TelnetUserName);
                //hostXmlNode.SetAttributeValue("password", hostEntry.TelnetPassword);
                //hostXmlNode.SetAttributeValue("ignoreInvalidHTTPSCerts", hostEntry.IgnoreInvalidHTTPSCerts);
                //hostXmlNode.SetAttributeValue("socketPingMsgBody", hostEntry.SocketPingMsgBody);
                //hostXmlNode.SetAttributeValue("primaryUIValue", hostEntry.PrimaryUIValue);

                //if (hostEntry.PingType == PingCollectorType.HTTP && hostEntry.HTMLContentContain.Trim().Length > 0)
                //{
                //    XmlNode htmlContentMatchNode = config.CreateElement("htmlContentMatch");
                //    htmlContentMatchNode.InnerText = hostEntry.HTMLContentContain;
                //    hostXmlNode.AppendChild(htmlContentMatchNode);
                //}
                //hostsListNode.AppendChild(hostXmlNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config>" +
               "<carvcesEntries>" +
               "<carvceEntry name=\"\">" +
               "<dataSource></dataSource>" +
               "<testConditions testSequence=\"GWE\">" +
               "<success testType=\"match\"></success>" +
               "<warning testType=\"match\"></warning>" +
               "<error testType=\"match\"></error>" +
               "</testConditions>" +
               "</carvceEntry>" +
               "</carvcesEntries>" +
               "</config>";
        }
        public string ConfigSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                
                return sb.ToString().TrimEnd(' ', ',');
            }
        }
        #endregion
    }

    public class SSHCommandCollectorConfigEntry : SSHBaseConfigEntry
    {
        public string Name { get; set; }
        public string CommandString { get; set; }
        public SSHCommandValueReturnType ValueReturnType { get; set; }
        public CollectorAgentReturnValueCheckSequence ReturnCheckSequence { get; set; }
        public CollectorAgentReturnValueCompareMatchType GoodResultMatchType { get; set; }
        public string GoodValue { get; set; }
        public CollectorAgentReturnValueCompareMatchType WarningResultMatchType { get; set; }
        public string WarningValue { get; set; }
        public CollectorAgentReturnValueCompareMatchType ErrorResultMatchType { get; set; }
        public string ErrorValue { get; set; }
        

        public override string TriggerSummary
        {
            get
            {
                return string.Format("Success: {0} ({1}), Warn: {2} ({3}), Err: {4} ({5}), Check seq: {6}",
                    SuccessValueOrMacro, SuccessMatchType,
                    WarningValueOrMacro, WarningMatchType,
                    ErrorValueOrMacro, ErrorMatchType, ValueReturnCheckSequence) +
                    (ValueReturnType == SSHCommandValueReturnType.ReturnedText ? ", Text" : "") +
                    (ValueReturnType == SSHCommandValueReturnType.LineCount ? ", Lines" : "") +
                    (ValueReturnType == SSHCommandValueReturnType.TextLength ? ", Length" : "");

            }
        }
        #region ICollectorConfigEntry Members
        public override MonitorState GetCurrentState()
        {
            object wsData = null;
            CollectorState agentState = CollectorState.NotAvailable;
            try
            {

                wsData = GetValue();
                CurrentAgentValue = FormatUtils.FormatArrayToString(wsData, "[null]");
                agentState = CollectorAgentReturnValueCompareEngine.GetState(ReturnCheckSequence,
                       GoodResultMatchType, GoodValue,
                       WarningResultMatchType, WarningValue,
                       ErrorResultMatchType, ErrorValue,
                       CurrentAgentValue);
            }
            catch (Exception wsException)
            {
                agentState = CollectorState.Error;
                wsData = wsException.Message;
            }

            MonitorState currentState = new MonitorState()
            {
                ForAgent = Description,
                State = agentState,
                CurrentValue = wsData == null ? "N/A" : wsData.ToString(),
                CurrentValueUnit = OutputValueUnit
            };

            return currentState;
        }
        #endregion

        public string ExecuteCommand()
        {
            string output = "";
            try
            {
                Renci.SshNet.SshClient sshClient = SSHConnection.GetConnection();
                {
                    try
                    {
                        //if (sshClient.IsConnected)
                        {
                            output = sshClient.RunCommand(CommandString).Result;
                        }
                        SSHConnection.CloseConnection();

                        if (ValueReturnType == SSHCommandValueReturnType.LineCount)
                        {
                            int lines = output.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
                            output = lines.ToString();
                        }
                        else if (ValueReturnType == SSHCommandValueReturnType.TextLength)
                        {
                            int length = output.Length;
                            output = length.ToString();
                        }

                    }
                    catch (Exception ex)
                    {
                        output = string.Format("The Command '{0}' failed to execute!\r\n{1}", CommandString, ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Connection failed to '{0}' : {1}", SSHConnection.ComputerName, ex.Message));
            }

            return output;
        }
    }
    public enum SSHCommandValueReturnType
    {
        ReturnedText,
        LineCount,
        TextLength
    }
}
