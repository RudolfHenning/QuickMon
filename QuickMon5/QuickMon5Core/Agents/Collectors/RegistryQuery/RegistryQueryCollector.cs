using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("Registry Query Collector"), Category("General")]
    public class RegistryQueryCollector : CollectorAgentBase
    {
        public RegistryQueryCollector()
        {
            AgentConfig = new RegistryQueryCollectorConfig();
        }
    }
    public class RegistryQueryCollectorConfig : ICollectorConfig
    {
        public RegistryQueryCollectorConfig()
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
            if (configurationString == null || configurationString.Length == 0)
            {
                config.LoadXml(GetDefaultOrEmptyXml());
            }
            else
            {
                config.LoadXml(configurationString);
            }
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            //Version 4 config
            foreach (XmlElement queryNode in root.SelectNodes("queries/query"))
            {
                RegistryQueryCollectorConfigEntry queryEntry = new RegistryQueryCollectorConfigEntry();
                queryEntry.Name = queryNode.ReadXmlElementAttr("name", "");
                queryEntry.UseRemoteServer = bool.Parse(queryNode.ReadXmlElementAttr("useRemoteServer", "False"));
                queryEntry.Server = queryNode.ReadXmlElementAttr("server", "");
                queryEntry.RegistryHive = RegistryQueryCollectorConfigEntry.GetRegistryHiveFromString(queryNode.ReadXmlElementAttr("registryHive", ""));
                queryEntry.Path = queryNode.ReadXmlElementAttr("path", "");
                queryEntry.KeyName = queryNode.ReadXmlElementAttr("keyName", "");
                queryEntry.ExpandEnvironmentNames = bool.Parse(queryNode.ReadXmlElementAttr("expandEnvironmentNames", "False"));

                //queryEntry.ReturnValueIsNumber = bool.Parse(queryNode.ReadXmlElementAttr("returnValueIsNumber", "False"));
                queryEntry.GoodValue = queryNode.ReadXmlElementAttr("successValue", "");
                queryEntry.GoodResultMatchType = CollectorAgentReturnValueCompareMatchType.Match;
                queryEntry.WarningValue = queryNode.ReadXmlElementAttr("warningValue", "");
                queryEntry.WarningResultMatchType = CollectorAgentReturnValueCompareMatchType.Match;
                queryEntry.ErrorValue = queryNode.ReadXmlElementAttr("errorValue", "");
                queryEntry.ErrorResultMatchType = CollectorAgentReturnValueCompareMatchType.Match;

                //queryEntry.ReturnValueInARange = bool.Parse(queryNode.ReadXmlElementAttr("returnValueInARange", "False"));
                //queryEntry.ReturnValueInverted = bool.Parse(queryNode.ReadXmlElementAttr("returnValueInverted", "False"));
                queryEntry.PrimaryUIValue = queryNode.ReadXmlElementAttr("primaryUIValue", false);
                Entries.Add(queryEntry);
            }
            //version 5 config
            foreach (XmlElement carvceEntryNode in root.SelectNodes("carvcesEntries/carvceEntry"))
            {
                XmlNode dataSourceNode = carvceEntryNode.SelectSingleNode("dataSource");
                RegistryQueryCollectorConfigEntry queryEntry = new RegistryQueryCollectorConfigEntry();
                queryEntry.Name = dataSourceNode.ReadXmlElementAttr("name", "");
                queryEntry.UseRemoteServer = bool.Parse(dataSourceNode.ReadXmlElementAttr("useRemoteServer", "False"));
                queryEntry.Server = dataSourceNode.ReadXmlElementAttr("server", "");
                queryEntry.RegistryHive = RegistryQueryCollectorConfigEntry.GetRegistryHiveFromString(dataSourceNode.ReadXmlElementAttr("registryHive", ""));
                queryEntry.Path = dataSourceNode.ReadXmlElementAttr("path", "");
                queryEntry.KeyName = dataSourceNode.ReadXmlElementAttr("keyName", "");
                queryEntry.ExpandEnvironmentNames = bool.Parse(dataSourceNode.ReadXmlElementAttr("expandEnvironmentNames", "False"));
                //queryEntry.ReturnValueIsNumber = bool.Parse(dataSourceNode.ReadXmlElementAttr("returnValueIsNumber", "False"));
                queryEntry.PrimaryUIValue = dataSourceNode.ReadXmlElementAttr("primaryUIValue", false);
                queryEntry.OutputValueUnit = dataSourceNode.ReadXmlElementAttr("outputValueUnit", "");

                XmlNode testConditionsNode = carvceEntryNode.SelectSingleNode("testConditions");
                if (testConditionsNode != null)
                {
                    queryEntry.ReturnCheckSequence = CollectorAgentReturnValueCompareEngine.CheckSequenceTypeFromString(testConditionsNode.ReadXmlElementAttr("testSequence", "gwe"));
                    XmlNode goodScriptNode = testConditionsNode.SelectSingleNode("success");
                    queryEntry.GoodResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(goodScriptNode.ReadXmlElementAttr("testType", "match"));
                    queryEntry.GoodValue = goodScriptNode.InnerText;                    

                    XmlNode warningScriptNode = testConditionsNode.SelectSingleNode("warning");
                    queryEntry.WarningResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(warningScriptNode.ReadXmlElementAttr("testType", "match"));
                    queryEntry.WarningValue = warningScriptNode.InnerText;

                    XmlNode errorScriptNode = testConditionsNode.SelectSingleNode("error");
                    queryEntry.ErrorResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(errorScriptNode.ReadXmlElementAttr("testType", "match"));
                    queryEntry.ErrorValue = errorScriptNode.InnerText;
                }
                else
                    queryEntry.ReturnCheckSequence = CollectorAgentReturnValueCheckSequence.GWE;

                Entries.Add(queryEntry);
            }
        }

        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode carvcesEntriesNode = root.SelectSingleNode("carvcesEntries");
            carvcesEntriesNode.InnerXml = "";

            foreach (RegistryQueryCollectorConfigEntry queryEntry in Entries)
            {
                XmlElement carvceEntryNode = config.CreateElement("carvceEntry");
                XmlElement dataSourceNode = config.CreateElement("dataSource");

                dataSourceNode.SetAttributeValue("name", queryEntry.Name);
                dataSourceNode.SetAttributeValue("useRemoteServer", queryEntry.UseRemoteServer);
                dataSourceNode.SetAttributeValue("server", queryEntry.Server);
                dataSourceNode.SetAttributeValue("registryHive", queryEntry.RegistryHive.ToString());
                dataSourceNode.SetAttributeValue("path", queryEntry.Path);
                dataSourceNode.SetAttributeValue("keyName", queryEntry.KeyName);
                dataSourceNode.SetAttributeValue("expandEnvironmentNames", queryEntry.ExpandEnvironmentNames);
                //dataSourceNode.SetAttributeValue("returnValueIsNumber", queryEntry.ReturnValueIsNumber);
                dataSourceNode.SetAttributeValue("primaryUIValue", queryEntry.PrimaryUIValue);
                dataSourceNode.SetAttributeValue("outputValueUnit", queryEntry.OutputValueUnit);

                XmlElement testConditionsNode = config.CreateElement("testConditions");
                testConditionsNode.SetAttributeValue("testSequence", queryEntry.ReturnCheckSequence.ToString());
                XmlElement successNode = config.CreateElement("success");
                successNode.SetAttributeValue("testType", queryEntry.GoodResultMatchType.ToString());
                successNode.InnerText = queryEntry.GoodValue;
                XmlElement warningNode = config.CreateElement("warning");
                warningNode.SetAttributeValue("testType", queryEntry.WarningResultMatchType.ToString());
                warningNode.InnerText = queryEntry.WarningValue;
                XmlElement errorNode = config.CreateElement("error");
                errorNode.SetAttributeValue("testType", queryEntry.ErrorResultMatchType.ToString());
                errorNode.InnerText = queryEntry.ErrorValue;

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
    public class RegistryQueryCollectorConfigEntry : ICollectorConfigEntry
    {
        #region ICollectorConfigEntry Members
        public MonitorState GetCurrentState()
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
        public string Description
        {
            get
            {
                if (Name == null || Name.Length == 0)
                    return (UseRemoteServer ? Server + "\\" : "") + GetRegistryHiveFromString(RegistryHive.ToString()).ToString() + "\\" + Path + "\\[" + KeyName + "]";
                else
                    return Name;
            }
        }
        public string TriggerSummary
        {
            get
            {
                return string.Format("Success: {0}, Warn: {1}, Err: {2}", GoodValue, WarningValue, ErrorValue);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        public object CurrentAgentValue { get; set; }
        public bool PrimaryUIValue { get; set; }
        #endregion

        #region Properties
        public string Name { get; set; }
        public bool UseRemoteServer { get; set; }
        public string Server { get; set; }
        public RegistryHive RegistryHive { get; set; }
        public string Path { get; set; }
        public string KeyName { get; set; }
        public bool ExpandEnvironmentNames { get; set; }

        public CollectorAgentReturnValueCheckSequence ReturnCheckSequence { get; set; }
        public CollectorAgentReturnValueCompareMatchType GoodResultMatchType { get; set; }
        public string GoodValue { get; set; }
        public CollectorAgentReturnValueCompareMatchType WarningResultMatchType { get; set; }
        public string WarningValue { get; set; }
        public CollectorAgentReturnValueCompareMatchType ErrorResultMatchType { get; set; }
        public string ErrorValue { get; set; }
        public string OutputValueUnit { get; set; }
        #endregion

        #region Static methods
        public static RegistryHive GetRegistryHiveFromString(string registryHiveName)
        {
            if (registryHiveName.IndexOf("LocalMachine", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                registryHiveName.IndexOf("HKEY_LOCAL_MACHINE", StringComparison.CurrentCultureIgnoreCase) > -1)
            {
                return Microsoft.Win32.RegistryHive.LocalMachine;
            }
            else if (registryHiveName.IndexOf("ClassesRoot", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                registryHiveName.IndexOf("HKEY_CLASSES_ROOT", StringComparison.CurrentCultureIgnoreCase) > -1)
            {
                return Microsoft.Win32.RegistryHive.ClassesRoot;
            }
            else if (registryHiveName.IndexOf("CurrentConfig", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                registryHiveName.IndexOf("HKEY_CURRENT_CONFIG", StringComparison.CurrentCultureIgnoreCase) > -1)
            {
                return Microsoft.Win32.RegistryHive.CurrentConfig;
            }
            else if (registryHiveName.IndexOf("Users", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                registryHiveName.IndexOf("HKEY_USERS", StringComparison.CurrentCultureIgnoreCase) > -1)
            {
                return Microsoft.Win32.RegistryHive.Users;
            }
            else if (registryHiveName.IndexOf("CurrentUser", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                registryHiveName.IndexOf("HKEY_CURRENT_USER", StringComparison.CurrentCultureIgnoreCase) > -1)
            {
                return Microsoft.Win32.RegistryHive.CurrentUser;
            }
            else
                return Microsoft.Win32.RegistryHive.LocalMachine;
        }
        #endregion

        #region Public methods        
        public object GetValue()
        {
            object result = null;
            RegistryKey remoteKey = null;
            if (UseRemoteServer)
            {
                remoteKey = RegistryKey.OpenRemoteBaseKey(RegistryHive, Server);
            }
            else
                remoteKey = RegistryKey.OpenBaseKey(RegistryHive, RegistryView.Default);            

            if (remoteKey != null)
            {
                RegistryKey valKey = remoteKey.OpenSubKey(Path);
                if (valKey != null)
                {
                    result = valKey.GetValue(KeyName, "[notExists]", ExpandEnvironmentNames ? RegistryValueOptions.None : RegistryValueOptions.DoNotExpandEnvironmentNames);
                }
                else if (valKey == null && Environment.Is64BitOperatingSystem)
                {
                    
                    remoteKey = RegistryKey.OpenBaseKey(RegistryHive, RegistryView.Registry64);
                    if (remoteKey != null)
                    {
                        valKey = remoteKey.OpenSubKey(Path);
                        if (valKey != null)
                        {
                            result = valKey.GetValue(KeyName, "[notExists]", ExpandEnvironmentNames ? RegistryValueOptions.None : RegistryValueOptions.DoNotExpandEnvironmentNames);
                        }
                        else
                        {
                            result = "[notExists]";
                        }
                    }
                }
                else
                    result = "[notExists]";
            }
            else
            {
                result = "[notExists]";
            }
            return result;
        }

        #endregion
    }
}
