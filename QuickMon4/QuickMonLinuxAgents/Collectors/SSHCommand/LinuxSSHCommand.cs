using QuickMon.Linux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("SSH Command Collector"), Category("Linux")]
    public class LinuxSSHCommandCollector : CollectorAgentBase
    {
        public LinuxSSHCommandCollector()
        {
            AgentConfig = new LinuxSSHCommandCollectorConfig();
        }

        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();
            string lastAction = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;

            try
            {
                LinuxSSHCommandCollectorConfig currentConfig = (LinuxSSHCommandCollectorConfig)AgentConfig;

                returnState.RawDetails = string.Format("Running {0} commands", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<b>Running {0} commands</b>", currentConfig.Entries.Count);
                returnState.CurrentValue = 0;
                foreach (LinuxSSHCommandEntry entry in currentConfig.Entries)
                {
                    string value = entry.ExecuteCommand();
                    CollectorState currentState = CollectorAgentReturnValueCompareEngine.GetState(entry.ValueReturnCheckSequence, entry.SuccessMatchType, entry.SuccessValueOrMacro,
                        entry.WarningMatchType, entry.WarningValueOrMacro, entry.ErrorMatchType, entry.ErrorValueOrMacro, value);
                    if (value.IsNumber())
                    {
                        returnState.CurrentValue = Double.Parse(returnState.CurrentValue.ToString()) + Double.Parse(value.ToString());
                    }
                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                State = CollectorState.Error,
                                ForAgent = entry.Name,
                                CurrentValue = value,
                                RawDetails = string.Format("'{0}' - {1} (Error)", entry.Name, value),
                                HtmlDetails = string.Format("'{0}' - {1} (<b>Error</b>)", entry.Name, value)
                            });
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                State = CollectorState.Warning,
                                ForAgent = entry.Name,
                                CurrentValue = value,
                                RawDetails = string.Format("'{0}' - {1} (Warning)", entry.Name, value),
                                HtmlDetails = string.Format("'{0}' - {1} (<b>Warning</b>)", entry.Name, value)
                            });
                    }
                    else
                    {
                        success++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                State = CollectorState.Good,
                                ForAgent = entry.Name,
                                CurrentValue = value,
                                RawDetails = string.Format("'{0}' - {1}", entry.Name, value),
                                HtmlDetails = string.Format("'{0}' - {1}", entry.Name, value)
                            });
                    }
                }

                if (errors > 0 && warnings == 0 && success == 0) // any errors
                    returnState.State = CollectorState.Error;
                else if (errors > 0 || warnings > 0) //any warnings
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;
            }
            catch (Exception ex)
            {
                returnState.RawDetails = ex.Message;
                returnState.HtmlDetails = string.Format("<p><b>Last action:</b> {0}</p><blockquote>{1}</blockquote>", lastAction, ex.Message);
                returnState.State = CollectorState.Error;
            }
            return returnState;
        }

        public override List<System.Data.DataTable> GetDetailDataTables()
        {
            List<System.Data.DataTable> tables = new List<System.Data.DataTable>();
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                dt.Columns.Add(new System.Data.DataColumn("Computer", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Name", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Output", typeof(string)));

                LinuxSSHCommandCollectorConfig currentConfig = (LinuxSSHCommandCollectorConfig)AgentConfig;
                foreach (LinuxSSHCommandEntry entry in currentConfig.Entries)
                {
                    string output = entry.ExecuteCommand();

                    dt.Rows.Add(entry.SSHConnection.ComputerName, entry.Name, output);
                }
            }
            catch (Exception ex)
            {
                dt = new System.Data.DataTable("Exception");
                dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
                dt.Rows.Add(ex.ToString());
            }
            tables.Add(dt);
            return tables;
        }
    }

    public class LinuxSSHCommandCollectorConfig : ICollectorConfig
    {
        public LinuxSSHCommandCollectorConfig()
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
            if (configurationString == null || configurationString.Length == 0)
                return;
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement cmndNode in root.SelectNodes("linux/sshCommand"))
            {
                LinuxSSHCommandEntry entry = new LinuxSSHCommandEntry();
                entry.SSHConnection.SSHSecurityOption = SSHSecurityOptionTypeConverter.FromString(cmndNode.ReadXmlElementAttr("sshSecOpt", "password"));
                entry.SSHConnection.ComputerName = cmndNode.ReadXmlElementAttr("machine", ".");
                entry.SSHConnection.SSHPort = cmndNode.ReadXmlElementAttr("sshPort", 22);                
                entry.SSHConnection.UserName = cmndNode.ReadXmlElementAttr("userName", "");
                entry.SSHConnection.Password = cmndNode.ReadXmlElementAttr("password", "");
                entry.SSHConnection.PrivateKeyFile = cmndNode.ReadXmlElementAttr("privateKeyFile", "");
                entry.SSHConnection.PassPhrase = cmndNode.ReadXmlElementAttr("passPhrase", "");

                entry.Name = cmndNode.ReadXmlElementAttr("name", "");                

                XmlNode commandStringNode = cmndNode.SelectSingleNode("commandString");
                entry.CommandString = cmndNode.InnerText;

                XmlNode alertTriggersNode = cmndNode.SelectSingleNode("alertTriggers");
                entry.ValueReturnType = SSHCommandValueReturnTypeConverter.FromString(alertTriggersNode.ReadXmlElementAttr("valueReturnType", "RawValue"));
                entry.ValueReturnCheckSequence = CollectorAgentReturnValueCompareEngine.CheckSequenceTypeFromString(alertTriggersNode.ReadXmlElementAttr("checkSequence", "EWG"));

                XmlNode successNode = alertTriggersNode.SelectSingleNode("success");
                entry.SuccessMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(successNode.ReadXmlElementAttr("matchType", "Match"));
                entry.SuccessValueOrMacro = successNode.ReadXmlElementAttr("value", "[any]");

                XmlNode warningNode = alertTriggersNode.SelectSingleNode("warning");
                entry.WarningMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(warningNode.ReadXmlElementAttr("matchType", "Match"));
                entry.WarningValueOrMacro = warningNode.ReadXmlElementAttr("value", "0");

                XmlNode errorNode = alertTriggersNode.SelectSingleNode("error");
                entry.ErrorMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(errorNode.ReadXmlElementAttr("matchType", "Match"));
                entry.ErrorValueOrMacro = errorNode.ReadXmlElementAttr("value", "[null]");

                Entries.Add(entry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode linuxNode = root.SelectSingleNode("linux");
            linuxNode.InnerXml = "";
            foreach (LinuxSSHCommandEntry entry in Entries)
            {
                XmlElement sshCommmandNode = config.CreateElement("sshCommand");
                sshCommmandNode.SetAttributeValue("sshSecOpt", entry.SSHConnection.SSHSecurityOption.ToString());
                sshCommmandNode.SetAttributeValue("machine", entry.SSHConnection.ComputerName);
                sshCommmandNode.SetAttributeValue("sshPort", entry.SSHConnection.SSHPort);
                sshCommmandNode.SetAttributeValue("userName", entry.SSHConnection.UserName);
                sshCommmandNode.SetAttributeValue("password", entry.SSHConnection.Password);
                sshCommmandNode.SetAttributeValue("privateKeyFile", entry.SSHConnection.PrivateKeyFile);
                sshCommmandNode.SetAttributeValue("passPhrase", entry.SSHConnection.PassPhrase);

                sshCommmandNode.SetAttributeValue("name", entry.Name);

                XmlElement commandStringNode = sshCommmandNode.AppendElementWithText("commandString", entry.CommandString);

                XmlElement alertTriggersNode = config.CreateElement("alertTriggers");
                alertTriggersNode.SetAttributeValue("valueReturnType", entry.ValueReturnType.ToString());
                alertTriggersNode.SetAttributeValue("checkSequence", entry.ValueReturnCheckSequence.ToString());
                XmlElement successNode = config.CreateElement("success");
                successNode.SetAttributeValue("matchType", entry.SuccessMatchType.ToString());
                successNode.SetAttributeValue("value", entry.SuccessValueOrMacro);
                alertTriggersNode.AppendChild(successNode);
                XmlElement warningNode = config.CreateElement("warning");
                warningNode.SetAttributeValue("matchType", entry.WarningMatchType.ToString());
                warningNode.SetAttributeValue("value", entry.WarningValueOrMacro);
                alertTriggersNode.AppendChild(warningNode);
                XmlElement errorNode = config.CreateElement("error");
                errorNode.SetAttributeValue("matchType", entry.ErrorMatchType.ToString());
                errorNode.SetAttributeValue("value", entry.ErrorValueOrMacro);
                alertTriggersNode.AppendChild(errorNode);
                sshCommmandNode.AppendChild(alertTriggersNode);

                linuxNode.AppendChild(sshCommmandNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config>\r\n<linux>\r\n</linux>\r\n</config>";
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

    public class LinuxSSHCommandEntry : LinuxBaseEntry
    {
        public string Name { get; set; }
        public string CommandString { get; set; }

        #region Alert settings
        public SSHCommandValueReturnType ValueReturnType { get; set; }
        public CollectorAgentReturnValueCheckSequence ValueReturnCheckSequence { get; set; }
        public CollectorAgentReturnValueCompareMatchType SuccessMatchType { get; set; }
        public string SuccessValueOrMacro { get; set; }
        public CollectorAgentReturnValueCompareMatchType WarningMatchType { get; set; }
        public string WarningValueOrMacro { get; set; }
        public CollectorAgentReturnValueCompareMatchType ErrorMatchType { get; set; }
        public string ErrorValueOrMacro { get; set; }
        #endregion

        public string ExecuteCommand()
        {
            string output = "";
            Renci.SshNet.SshClient sshClient = null;
            try
            {
                sshClient = SshClientTools.GetSSHConnection(SSHConnection);

            }
            catch (Exception ex)
            {
                throw new Exception( string.Format("Connection failed to '{0}' : {1}", SSHConnection.ComputerName, ex.Message));
            }
            try
            {
                if (sshClient.IsConnected)
                {
                    output = sshClient.RunCommand(CommandString).Result;
                }
                sshClient.Disconnect();

                if (ValueReturnType == SSHCommandValueReturnType.LineCount)
                {
                    int lines = output.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries).Length;
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
            return output;
        }

        public override string Description
        {
            get
            {
                return Name + " (" + base.Description + ")";
            }
        }
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
    }

    public enum SSHCommandValueReturnType
    {
        ReturnedText,
        LineCount,
        TextLength
    }
    public static class SSHCommandValueReturnTypeConverter
    {
        public static SSHCommandValueReturnType FromString(string value)
        {
            if (value.ToLower() == "linecount")
                return SSHCommandValueReturnType.LineCount;
            else if (value.ToLower() == "textlength")
                return SSHCommandValueReturnType.TextLength;
            else
                return SSHCommandValueReturnType.ReturnedText;
        }
    }
}
