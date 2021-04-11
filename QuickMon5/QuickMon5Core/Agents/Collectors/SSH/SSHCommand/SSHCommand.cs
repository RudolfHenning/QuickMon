using QuickMon.SSH;
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
            
            //version 5 config
            foreach (XmlElement carvceEntryNode in root.SelectNodes("carvcesEntries/carvceEntry"))
            {
                XmlNode dataSourceNode = carvceEntryNode.SelectSingleNode("dataSource");
                SSHCommandCollectorConfigEntry sshEntry = new SSHCommandCollectorConfigEntry();
                sshEntry.Name = dataSourceNode.ReadXmlElementAttr("name", "");
                sshEntry.PrimaryUIValue = dataSourceNode.ReadXmlElementAttr("primaryUIValue", false);
                sshEntry.OutputValueUnit = dataSourceNode.ReadXmlElementAttr("outputValueUnit", "");
                sshEntry.SSHConnection = SSHConnectionDetails.FromXmlElement((XmlElement)dataSourceNode);
                

                XmlNode stateQueryNode = dataSourceNode.SelectSingleNode("stateQuery");
                sshEntry.ValueReturnType = SSHCommandValueReturnTypeConverter.FromString(stateQueryNode.ReadXmlElementAttr("valueReturnType", "RawValue"));
                sshEntry.CommandString = stateQueryNode.InnerText;                

                XmlNode testConditionsNode = carvceEntryNode.SelectSingleNode("testConditions");
                if (testConditionsNode != null)
                {
                    sshEntry.ReturnCheckSequence = CollectorAgentReturnValueCompareEngine.CheckSequenceTypeFromString(testConditionsNode.ReadXmlElementAttr("testSequence", "gwe"));
                    XmlNode goodScriptNode = testConditionsNode.SelectSingleNode("success");
                    sshEntry.GoodResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(goodScriptNode.ReadXmlElementAttr("testType", "match"));
                    sshEntry.GoodValue = goodScriptNode.InnerText;

                    XmlNode warningScriptNode = testConditionsNode.SelectSingleNode("warning");
                    sshEntry.WarningResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(warningScriptNode.ReadXmlElementAttr("testType", "match"));
                    sshEntry.WarningValue = warningScriptNode.InnerText;

                    XmlNode errorScriptNode = testConditionsNode.SelectSingleNode("error");
                    sshEntry.ErrorResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(errorScriptNode.ReadXmlElementAttr("testType", "match"));
                    sshEntry.ErrorValue = errorScriptNode.InnerText;
                }
                else
                    sshEntry.ReturnCheckSequence = CollectorAgentReturnValueCheckSequence.GWE;

                Entries.Add(sshEntry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode carvcesEntriesNode = root.SelectSingleNode("carvcesEntries");
            carvcesEntriesNode.InnerXml = "";
            foreach (SSHCommandCollectorConfigEntry sshEntry in Entries)
            {
                XmlElement carvceEntryNode = config.CreateElement("carvceEntry");
                XmlElement dataSourceNode = config.CreateElement("dataSource");

                dataSourceNode.SetAttributeValue("name", sshEntry.Name);                
                dataSourceNode.SetAttributeValue("primaryUIValue", sshEntry.PrimaryUIValue);
                dataSourceNode.SetAttributeValue("outputValueUnit", sshEntry.OutputValueUnit);
                sshEntry.SSHConnection.SaveToXmlElementAttr(dataSourceNode);

                XmlElement stateQueryNode = dataSourceNode.AppendElementWithText("stateQuery", sshEntry.CommandString);
                stateQueryNode.SetAttributeValue("valueReturnType", sshEntry.ValueReturnType.ToString());
                
                XmlElement testConditionsNode = config.CreateElement("testConditions");
                testConditionsNode.SetAttributeValue("testSequence", sshEntry.ReturnCheckSequence.ToString());
                XmlElement successNode = config.CreateElement("success");
                successNode.SetAttributeValue("testType", sshEntry.GoodResultMatchType.ToString());
                successNode.InnerText = sshEntry.GoodValue;
                XmlElement warningNode = config.CreateElement("warning");
                warningNode.SetAttributeValue("testType", sshEntry.WarningResultMatchType.ToString());
                warningNode.InnerText = sshEntry.WarningValue;
                XmlElement errorNode = config.CreateElement("error");
                errorNode.SetAttributeValue("testType", sshEntry.ErrorResultMatchType.ToString());
                errorNode.InnerText = sshEntry.ErrorValue;

                testConditionsNode.AppendChild(successNode);
                testConditionsNode.AppendChild(warningNode);
                testConditionsNode.AppendChild(errorNode);
                carvceEntryNode.AppendChild(dataSourceNode);
                carvceEntryNode.AppendChild(testConditionsNode);
                carvcesEntriesNode.AppendChild(carvceEntryNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config>" +
               "<carvcesEntries>" +
               "<carvceEntry name=\"\">" +
               "<dataSource><stateQuery /></dataSource>" +
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
                    GoodValue, GoodResultMatchType,
                    WarningValue, WarningResultMatchType,
                    ErrorValue, ErrorResultMatchType, ReturnCheckSequence) +
                    (ValueReturnType == SSHCommandValueReturnType.ReturnedText ? ", Text" : "") +
                    (ValueReturnType == SSHCommandValueReturnType.LineCount ? ", Lines" : "") +
                    (ValueReturnType == SSHCommandValueReturnType.TextLength ? ", Length" : "");

            }
        }
        #region ICollectorConfigEntry Members
        public override MonitorState GetCurrentState()
        {
            string returnedData = "";
            CollectorState agentState = CollectorState.NotAvailable;
            try
            {
                returnedData = ExecuteCommand();
                
                CurrentAgentValue = FormatUtils.FormatArrayToString(returnedData, "[null]");
                agentState = CollectorAgentReturnValueCompareEngine.GetState(ReturnCheckSequence,
                       GoodResultMatchType, GoodValue,
                       WarningResultMatchType, WarningValue,
                       ErrorResultMatchType, ErrorValue,
                       CurrentAgentValue);
            }
            catch (Exception wsException)
            {
                agentState = CollectorState.Error;
                returnedData = wsException.Message;
            }

            MonitorState currentState = new MonitorState()
            {
                ForAgent = Description,
                State = agentState,
                CurrentValue = returnedData == null ? "N/A" : returnedData,
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
                        output = sshClient.RunCommand(CommandString).Result;
                        
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
                        else
                        {
                            output = output.Trim(' ', '\r', '\n');
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
