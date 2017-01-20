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

        //public override MonitorState RefreshState()
        //{
        //    MonitorState returnState = new MonitorState();            
        //    string lastAction = "";
        //    int errors = 0;
        //    int success = 0;
        //    int warnings = 0;
        //    double totalValue = 0;
        //    try
        //    {
        //        RegistryQueryCollectorConfig currentConfig = (RegistryQueryCollectorConfig)AgentConfig;
        //        returnState.RawDetails = string.Format("Running {0} registry query(s)", currentConfig.Entries.Count);
        //        returnState.HtmlDetails = string.Format("<b>Running {0} registry query(s)</b>", currentConfig.Entries.Count);

        //        foreach (RegistryQueryCollectorConfigEntry queryInstance in currentConfig.Entries)
        //        {
        //            object value = null;
        //            if (queryInstance.UseRemoteServer)
        //                lastAction = string.Format("Running Registry query '{0}' on '{1}'", queryInstance.Name, queryInstance.Server);
        //            else
        //                lastAction = string.Format("Running Registry query '{0}'", queryInstance.Name);

        //            value = queryInstance.GetValue();
        //            if (!queryInstance.ReturnValueIsNumber && value.IsNumber())
        //                totalValue += double.Parse(value.ToString());

        //            CollectorState instanceState = queryInstance.EvaluateValue(value);

        //            if (instanceState == CollectorState.Error)
        //            {
        //                errors++;
        //                returnState.ChildStates.Add(
        //                       new MonitorState()
        //                       {
        //                           ForAgent = queryInstance.Name,
        //                           State = CollectorState.Error,
        //                           CurrentValue = value,
        //                           RawDetails = string.Format("'{0}' - value '{1}' - Error (trigger {2})", queryInstance.Name, FormatUtils.FormatArrayToString(value, "[null]"), queryInstance.ErrorValue),
        //                           HtmlDetails = string.Format("'{0}' - value '{1}' - <b>Error</b> (trigger {2})", queryInstance.Name, FormatUtils.FormatArrayToString(value, "[null]"), queryInstance.ErrorValue),
        //                       });
        //            }
        //            else if (instanceState == CollectorState.Warning)
        //            {
        //                warnings++;
        //                returnState.ChildStates.Add(
        //                       new MonitorState()
        //                       {
        //                           ForAgent = queryInstance.Name,
        //                           State = CollectorState.Warning,
        //                           CurrentValue = value,
        //                           RawDetails = string.Format("'{0}' - value '{1}' - Warning (trigger {2})", queryInstance.Name, FormatUtils.FormatArrayToString(value, "[null]"), queryInstance.WarningValue),
        //                           HtmlDetails = string.Format("'{0}' - value '{1}' - <b>Warning</b> (trigger {2})", queryInstance.Name, FormatUtils.FormatArrayToString(value, "[null]"), queryInstance.WarningValue),
        //                       });
        //            }
        //            else
        //            {
        //                success++;
        //                returnState.ChildStates.Add(
        //                       new MonitorState()
        //                       {
        //                           ForAgent = queryInstance.Name,
        //                           State = CollectorState.Good,
        //                           CurrentValue = value,
        //                           RawDetails = string.Format("'{0}' - value '{1}'", queryInstance.Name, FormatUtils.FormatArrayToString(value, "[null]")),
        //                           HtmlDetails = string.Format("'{0}' - value '{1}'", queryInstance.Name, FormatUtils.FormatArrayToString(value, "[null]")),
        //                       });

                        
        //            }
        //        }
        //        if (errors > 0 && warnings == 0)
        //            returnState.State = CollectorState.Error;
        //        else if (warnings > 0)
        //            returnState.State = CollectorState.Warning;
        //        else
        //            returnState.State = CollectorState.Good;
        //        returnState.CurrentValue = totalValue;
        //    }
        //    catch (Exception ex)
        //    {
        //        returnState.RawDetails = ex.Message;
        //        returnState.HtmlDetails = string.Format("<p><b>Last action:</b> {0}</p><blockquote>{1}</blockquote>", lastAction, ex.Message);
        //        returnState.State = CollectorState.Error;
        //    }
        //    return returnState;
        //}

        public override List<System.Data.DataTable> GetDetailDataTables()
        {
            List<System.Data.DataTable> tables = new List<System.Data.DataTable>();
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                dt.Columns.Add(new System.Data.DataColumn("Path", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Value", typeof(string)));                

                RegistryQueryCollectorConfig currentConfig = (RegistryQueryCollectorConfig)AgentConfig;
                foreach (RegistryQueryCollectorConfigEntry entry in currentConfig.Entries)
                {

                    object value = entry.GetValue();
                    if (value.GetType().IsArray)
                    {
                        value = FormatUtils.FormatArrayToString(value);
                    }

                    dt.Rows.Add(entry.Description, value);
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

                queryEntry.ReturnValueIsNumber = bool.Parse(queryNode.ReadXmlElementAttr("returnValueIsNumber", "False"));
                queryEntry.SuccessValue = queryNode.ReadXmlElementAttr("successValue", "");
                queryEntry.WarningValue = queryNode.ReadXmlElementAttr("warningValue", "");
                queryEntry.ErrorValue = queryNode.ReadXmlElementAttr("errorValue", "");
                queryEntry.ReturnValueInARange = bool.Parse(queryNode.ReadXmlElementAttr("returnValueInARange", "False"));
                queryEntry.ReturnValueInverted = bool.Parse(queryNode.ReadXmlElementAttr("returnValueInverted", "False"));
                Entries.Add(queryEntry);
            }
        }

        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode queriesNode = root.SelectSingleNode("queries");
            queriesNode.InnerXml = "";

            foreach (RegistryQueryCollectorConfigEntry queryEntry in Entries)
            {
                XmlElement queryNode = config.CreateElement("query");
                queryNode.SetAttributeValue("name", queryEntry.Name);
                queryNode.SetAttributeValue("useRemoteServer", queryEntry.UseRemoteServer);
                queryNode.SetAttributeValue("server", queryEntry.Server);
                queryNode.SetAttributeValue("registryHive", queryEntry.RegistryHive.ToString());
                queryNode.SetAttributeValue("path", queryEntry.Path);
                queryNode.SetAttributeValue("keyName", queryEntry.KeyName);
                queryNode.SetAttributeValue("expandEnvironmentNames", queryEntry.ExpandEnvironmentNames);
                queryNode.SetAttributeValue("returnValueIsNumber", queryEntry.ReturnValueIsNumber);
                queryNode.SetAttributeValue("successValue", queryEntry.SuccessValue);
                queryNode.SetAttributeValue("warningValue", queryEntry.WarningValue);
                queryNode.SetAttributeValue("errorValue", queryEntry.ErrorValue);
                queryNode.SetAttributeValue("returnValueInARange", queryEntry.ReturnValueInARange);
                queryNode.SetAttributeValue("returnValueInverted", queryEntry.ReturnValueInverted);
                queriesNode.AppendChild(queryNode);
            }
            return config.OuterXml;
        }

        public string GetDefaultOrEmptyXml()
        {
            return "<config><queries></queries></config>";
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
            object value = GetValue();
            CurrentAgentValue = value;
            MonitorState currentState = new MonitorState()
            {
                ForAgent = Name,
                CurrentValue = FormatUtils.FormatArrayToString(value, "[null]"),
                State = EvaluateValue(value)
            };

            if (currentState.State == CollectorState.Error)
            {
                currentState.RawDetails = string.Format("'{0}' - value '{1}' - Error (trigger {2})", Name, FormatUtils.FormatArrayToString(value, "[null]"), ErrorValue);
                currentState.HtmlDetails = string.Format("'{0}' - value '{1}' - <b>Error</b> (trigger {2})", Name, FormatUtils.FormatArrayToString(value, "[null]"), ErrorValue);
            }
            else if (currentState.State == CollectorState.Warning)
            {
                currentState.RawDetails = string.Format("'{0}' - value '{1}' - Warning (trigger {2})", Name, FormatUtils.FormatArrayToString(value, "[null]"), WarningValue);
                currentState.HtmlDetails = string.Format("'{0}' - value '{1}' - <b>Warning</b> (trigger {2})", Name, FormatUtils.FormatArrayToString(value, "[null]"), WarningValue);
            }
            else
            {
                currentState.RawDetails = string.Format("'{0}' - value '{1}'", Name, FormatUtils.FormatArrayToString(value, "[null]"));
                currentState.HtmlDetails = string.Format("'{0}' - value '{1}'", Name, FormatUtils.FormatArrayToString(value, "[null]"));
            }

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
                return string.Format("Success: {0}, Warn: {1}, Err: {2}", SuccessValue, WarningValue, ErrorValue);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        #endregion

        #region Properties
        public string Name { get; set; }
        public bool UseRemoteServer { get; set; }
        public string Server { get; set; }
        public RegistryHive RegistryHive { get; set; }
        public string Path { get; set; }
        public string KeyName { get; set; }
        public bool ExpandEnvironmentNames { get; set; }
        public bool ReturnValueIsNumber { get; set; }
        public bool ReturnValueInARange { get; set; }
        public bool ReturnValueInverted { get; set; }
        public string SuccessValue { get; set; }
        public string WarningValue { get; set; }
        public string ErrorValue { get; set; }
        public object CurrentAgentValue { get; set; }        
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
        public CollectorState EvaluateValue(object value)
        {
            CollectorState result = CollectorState.Good;
            if (value == null || value == DBNull.Value)
            {
                if (ErrorValue == "[null]")
                    result = CollectorState.Error;
                else if (WarningValue == "[null]")
                    result = CollectorState.Warning;
                else if (SuccessValue == "[null]")
                    result = CollectorState.Good;
                else if (SuccessValue != "[any]")
                    result = CollectorState.Error;
            }
            else if (value.ToString() == "[notExists]")
            {
                if (ErrorValue == "[notExists]")
                    result = CollectorState.Error;
                else if (WarningValue == "[notExists]")
                    result = CollectorState.Warning;
                else if (SuccessValue == "[notExists]")
                    result = CollectorState.Good;
                else
                    result = CollectorState.Error;
            }
            else //non empty value but it DOES exist
            {
                if (!ReturnValueIsNumber || !ReturnValueInARange) //so it's not a number
                {
                    if (value.GetType().IsArray)
                    {
                        value = FormatUtils.FormatArrayToString(value);
                    }

                    //first eliminate matching values
                    if (SuccessValue == value.ToString())
                        result = CollectorState.Good;
                    else if (value.ToString() == ErrorValue)
                        result = CollectorState.Error;
                    else if (value.ToString() == WarningValue)
                        result = CollectorState.Warning;

                    //test for [contains] <value>, [beginswith] <value> or [endswith] <value>
                    else if (SuccessValue.StartsWith("[contains]") && value.ToString().Contains(SuccessValue.Substring(("[contains]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (SuccessValue.StartsWith("[beginswith]") && value.ToString().StartsWith(SuccessValue.Substring(("[beginswith]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (SuccessValue.StartsWith("[endswith]") && value.ToString().EndsWith(SuccessValue.Substring(("[endswith]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (WarningValue.StartsWith("[contains]") && value.ToString().Contains(WarningValue.Substring(("[contains]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (WarningValue.StartsWith("[beginswith]") && value.ToString().StartsWith(WarningValue.Substring(("[beginswith]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (WarningValue.StartsWith("[endswith]") && value.ToString().EndsWith(WarningValue.Substring(("[endswith]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (ErrorValue.StartsWith("[contains]") && value.ToString().Contains(ErrorValue.Substring(("[contains]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (ErrorValue.StartsWith("[beginswith]") && value.ToString().StartsWith(ErrorValue.Substring(("[beginswith]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (ErrorValue.StartsWith("[endswith]") && value.ToString().EndsWith(ErrorValue.Substring(("[endswith]").Length).Trim()))
                        result = CollectorState.Good;

                    //Existing tests
                    else if (ErrorValue == "[exists]")
                        result = CollectorState.Error;
                    else if (WarningValue == "[exists]")
                        result = CollectorState.Warning;
                    else if (SuccessValue == "[exists]")
                        result = CollectorState.Good;

                    //Any tests
                    else if (ErrorValue == "[any]")
                        result = CollectorState.Error;
                    else if (WarningValue == "[any]")
                        result = CollectorState.Warning;

                    //Not matching success
                    else if (SuccessValue != "[any]")
                        result = CollectorState.Warning;
                }
                else if (!value.IsNumber()) //value must be a number!
                {
                    result = CollectorState.Error;
                }
                else //so it is a number and must be inside a range
                {
                    if (ErrorValue != "[any]" && ErrorValue != "[null]" &&
                                    (
                                     (!ReturnValueInverted && double.Parse(value.ToString()) >= double.Parse(ErrorValue)) ||
                                     (ReturnValueInverted && double.Parse(value.ToString()) <= double.Parse(ErrorValue))
                                    )
                                )
                    {
                        result = CollectorState.Error;
                    }
                    else if (WarningValue != "[any]" && WarningValue != "[null]" &&
                           (
                            (!ReturnValueInverted && double.Parse(value.ToString()) >= double.Parse(WarningValue)) ||
                            (ReturnValueInverted && double.Parse(value.ToString()) <= double.Parse(WarningValue))
                           )
                        )
                    {
                        result = CollectorState.Warning;
                    }
                }
            }

            return result;
        }
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
                else
                {
                    result = "[notExists]";
                }
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
