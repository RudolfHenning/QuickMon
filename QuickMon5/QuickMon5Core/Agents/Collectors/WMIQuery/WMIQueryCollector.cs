﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.Management;

namespace QuickMon.Collectors
{
    [Description("WMI Query Collector"), Category("General")]
    public class WMIQueryCollector : CollectorAgentBase
    {
        public WMIQueryCollector()
        {
            AgentConfig = new WMIQueryCollectorConfig();
        }

        //public override MonitorState RefreshState()
        //{
        //    MonitorState returnState = new MonitorState();
        //    string lastAction = "";
        //    int errors = 0;
        //    int warnings = 0;
        //    int success = 0;
        //    double totalValue = 0;
        //    try
        //    {
        //        WMIQueryCollectorConfig currentConfig = (WMIQueryCollectorConfig)AgentConfig;
        //        returnState.RawDetails = string.Format("Running {0} WMI queries", currentConfig.Entries.Count);
        //        returnState.HtmlDetails = string.Format("<b>Running {0} WMI queries</b>", currentConfig.Entries.Count);

        //        foreach (WMIQueryCollectorConfigEntry wmiConfigEntry in currentConfig.Entries)
        //        {
        //            lastAction = string.Format("Running WMI query for {0} - ", wmiConfigEntry.Name);

        //            object val = wmiConfigEntry.RunQuery();
        //            CollectorState currentState = wmiConfigEntry.GetState(val);
        //            if (currentState == CollectorState.Error)
        //            {
        //                errors++;
        //                returnState.ChildStates.Add(
        //                       new MonitorState()
        //                       {
        //                           ForAgent = wmiConfigEntry.Name,
        //                           State = CollectorState.Error,
        //                           CurrentValue = val,
        //                           RawDetails = string.Format("(Trigger '{0}')", wmiConfigEntry.ErrorValue)
        //                           //RawDetails = string.Format("Machine '{0}' - value '{1}' - Error (trigger {2})", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]"), wmiConfigEntry.ErrorValue),
        //                           //HtmlDetails = string.Format("Machine '{0}' - Value '{1}' - <b>Error</b> (trigger {2})", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]"), wmiConfigEntry.ErrorValue)
        //                       });                        
        //            }
        //            else if (currentState == CollectorState.Warning)
        //            {
        //                warnings++;
        //                returnState.ChildStates.Add(
        //                       new MonitorState()
        //                       {
        //                           ForAgent = wmiConfigEntry.Name,
        //                           State = CollectorState.Warning,
        //                           CurrentValue = val,
        //                           RawDetails = string.Format("(Trigger '{0}')", wmiConfigEntry.WarningValue)
        //                           //RawDetails = string.Format("Machine '{0}' - value '{1}' - Warning (trigger {2})", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]"), wmiConfigEntry.WarningValue),
        //                           //HtmlDetails = string.Format("Machine '{0}' - Value '{1}' - <b>Warning</b> (trigger {2})", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]"), wmiConfigEntry.WarningValue)
        //                       });                        
        //            }
        //            else
        //            {
        //                success++;
        //                returnState.ChildStates.Add(
        //                       new MonitorState()
        //                       {
        //                           ForAgent = wmiConfigEntry.Name,
        //                           State = CollectorState.Good,
        //                           CurrentValue = val //,
        //                           //RawDetails = string.Format("Machine '{0}' - value '{1}'", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]")),
        //                           //HtmlDetails = string.Format("Machine '{0}' - Value '{1}'", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]"))
        //                       });
        //            }
        //            if (val != null && val.IsNumber())
        //                totalValue += double.Parse(val.ToString());
        //        }
        //        returnState.CurrentValue = totalValue;
        //        if (errors > 0 && warnings == 0)
        //            returnState.State = CollectorState.Error;
        //        else if (warnings > 0)
        //            returnState.State = CollectorState.Warning;
        //        else
        //            returnState.State = CollectorState.Good;
        //    }
        //    catch (Exception ex)
        //    {
        //        returnState.RawDetails = ex.Message;
        //        returnState.HtmlDetails = string.Format("<p><b>Last action:</b> {0}</p><blockquote>{1}</blockquote>", lastAction, ex.Message);
        //        returnState.State = CollectorState.Error;
        //    }
        //    return returnState;
        //}

        //public override List<System.Data.DataTable> GetDetailDataTables()
        //{
        //    List<System.Data.DataTable> tables = new List<System.Data.DataTable>();
        //    try
        //    {
        //        WMIQueryCollectorConfig currentConfig = (WMIQueryCollectorConfig)AgentConfig;
        //        foreach (WMIQueryCollectorConfigEntry entry in currentConfig.Entries)
        //        {
        //            System.Data.DataTable dt = entry.GetDetailDataTable();
        //            dt.TableName = Name + " (" + entry.Name + ")";
        //            tables.Add(dt);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Data.DataTable dt = new System.Data.DataTable("Exception");
        //        dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
        //        dt.Rows.Add(ex.ToString());
        //        tables.Add(dt);
        //    }
        //    return tables;
        //}
    }

    public class WMIQueryCollectorConfig : ICollectorConfig
    {
        public WMIQueryCollectorConfig()
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
            //version 4 type config
            foreach (XmlElement wmiQueryNode in root.SelectNodes("wmiQueries/wmiQuery"))
            {
                WMIQueryCollectorConfigEntry entry = new WMIQueryCollectorConfigEntry();
                entry.Name = wmiQueryNode.ReadXmlElementAttr("name", entry.Machinename);
                entry.Namespace = wmiQueryNode.ReadXmlElementAttr("namespace", "root\\CIMV2");
                entry.Machinename = wmiQueryNode.ReadXmlElementAttr("machineName", ".");
                entry.PrimaryUIValue = wmiQueryNode.ReadXmlElementAttr("primaryUIValue", false);
                entry.OutputValueUnit = wmiQueryNode.ReadXmlElementAttr("outputValueUnit", "");
                entry.OutputValueScaleFactor = wmiQueryNode.ReadXmlElementAttr("valueScale", 1);
                if (entry.OutputValueScaleFactor == 0)
                    entry.OutputValueScaleFactor = 1;
                entry.OutputValueScaleFactorInverse = wmiQueryNode.ReadXmlElementAttr("valueScaleInverse", false);

                XmlNode stateQueryNode = wmiQueryNode.SelectSingleNode("stateQuery");
                entry.StateQuery = stateQueryNode.ReadXmlElementAttr("syntax", "");
                //entry.ReturnValueIsInt = bool.Parse(stateQueryNode.ReadXmlElementAttr("returnValueIsInt", "True"));
                //entry.ReturnValueInverted = bool.Parse(stateQueryNode.ReadXmlElementAttr("returnValueInverted", "False"));

                if (stateQueryNode.ReadXmlElementAttr("returnValueInverted", false))
                {
                    entry.ReturnCheckSequence = CollectorAgentReturnValueCheckSequence.EWG;
                }
                else
                {
                    entry.ReturnCheckSequence = CollectorAgentReturnValueCheckSequence.GWE;
                }
                entry.GoodResultMatchType = CollectorAgentReturnValueCompareMatchType.Match;
                entry.WarningResultMatchType = CollectorAgentReturnValueCompareMatchType.Match;
                entry.ErrorResultMatchType = CollectorAgentReturnValueCompareMatchType.Match;
                entry.WarningValue = stateQueryNode.ReadXmlElementAttr("warningValue", "0");
                entry.ErrorValue = stateQueryNode.ReadXmlElementAttr("errorValue", "0");
                entry.GoodValue = stateQueryNode.ReadXmlElementAttr("successValue", "0");
                entry.UseRowCountAsValue = stateQueryNode.ReadXmlElementAttr("useRowCountAsValue", true);
                //XmlNode detailQueryNode = wmiQueryNode.SelectSingleNode("detailQuery");
                //entry.DetailQuery = detailQueryNode.ReadXmlElementAttr("syntax", "");
                //string columns = detailQueryNode.ReadXmlElementAttr("columnNames", "");
                //entry.ColumnNames = new List<string>();
                //if (columns.Length > 0 && columns.IndexOf(',') > -1)
                //    entry.ColumnNames = columns.ToListFromCSVString();
                //else if (columns.Length > 0)
                //    entry.ColumnNames.Add(columns);
                Entries.Add(entry);
            }

            //version 5 type config
            foreach (XmlElement carvceEntryNode in root.SelectNodes("carvcesEntries/carvceEntry"))
            {
                XmlNode dataSourceNode = carvceEntryNode.SelectSingleNode("dataSource");
                WMIQueryCollectorConfigEntry entry = new WMIQueryCollectorConfigEntry();
                entry.Name = dataSourceNode.ReadXmlElementAttr("name", "");
                entry.Namespace = dataSourceNode.ReadXmlElementAttr("namespace", "root\\CIMV2");
                entry.Machinename = dataSourceNode.ReadXmlElementAttr("machineName", ".");
                entry.PrimaryUIValue = dataSourceNode.ReadXmlElementAttr("primaryUIValue", false);
                entry.OutputValueUnit = dataSourceNode.ReadXmlElementAttr("outputValueUnit", "");
                entry.OutputValueScaleFactor = dataSourceNode.ReadXmlElementAttr("valueScale", 1);
                if (entry.OutputValueScaleFactor == 0)
                    entry.OutputValueScaleFactor = 1;
                entry.OutputValueScaleFactorInverse = dataSourceNode.ReadXmlElementAttr("valueScaleInverse", false);

                XmlNode stateQueryNode = dataSourceNode.SelectSingleNode("stateQuery");
                //entry.ReturnValueIsInt = bool.Parse(stateQueryNode.ReadXmlElementAttr("returnValueIsInt", "False"));
                entry.UseRowCountAsValue = bool.Parse(stateQueryNode.ReadXmlElementAttr("useRowCountAsValue", "False"));
                entry.StateQuery = stateQueryNode.InnerText;

                //XmlNode detailQueryNode = dataSourceNode.SelectSingleNode("detailQuery");
                //string columns = detailQueryNode.ReadXmlElementAttr("columnNames", "");
                //entry.ColumnNames = new List<string>();
                //if (columns.Length > 0 && columns.IndexOf(',') > -1)
                //    entry.ColumnNames = columns.ToListFromCSVString();
                //else if (columns.Length > 0)
                //    entry.ColumnNames.Add(columns);
                //entry.DetailQuery = detailQueryNode.InnerText;

                XmlNode testConditionsNode = carvceEntryNode.SelectSingleNode("testConditions");
                if (testConditionsNode != null)
                {
                    entry.ReturnCheckSequence = CollectorAgentReturnValueCompareEngine.CheckSequenceTypeFromString(testConditionsNode.ReadXmlElementAttr("testSequence", "gwe"));
                    XmlNode goodScriptNode = testConditionsNode.SelectSingleNode("success");
                    entry.GoodResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(goodScriptNode.ReadXmlElementAttr("testType", "match"));
                    entry.GoodValue = goodScriptNode.InnerText;

                    XmlNode warningScriptNode = testConditionsNode.SelectSingleNode("warning");
                    entry.WarningResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(warningScriptNode.ReadXmlElementAttr("testType", "match"));
                    entry.WarningValue = warningScriptNode.InnerText;

                    XmlNode errorScriptNode = testConditionsNode.SelectSingleNode("error");
                    entry.ErrorResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(errorScriptNode.ReadXmlElementAttr("testType", "match"));
                    entry.ErrorValue = errorScriptNode.InnerText;
                }
                else
                    entry.ReturnCheckSequence = CollectorAgentReturnValueCheckSequence.GWE;

                Entries.Add(entry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode carvcesEntriesNode = root.SelectSingleNode("carvcesEntries");
            carvcesEntriesNode.InnerXml = "";
            foreach (WMIQueryCollectorConfigEntry queryEntry in Entries)
            {
                XmlElement carvceEntryNode = config.CreateElement("carvceEntry");
                XmlElement dataSourceNode = config.CreateElement("dataSource");

                dataSourceNode.SetAttributeValue("name", queryEntry.Name);
                dataSourceNode.SetAttributeValue("namespace", queryEntry.Namespace);
                dataSourceNode.SetAttributeValue("machineName", queryEntry.Machinename);
                dataSourceNode.SetAttributeValue("primaryUIValue", queryEntry.PrimaryUIValue);
                dataSourceNode.SetAttributeValue("outputValueUnit", queryEntry.OutputValueUnit);
                dataSourceNode.SetAttributeValue("valueScale", queryEntry.OutputValueScaleFactor);
                dataSourceNode.SetAttributeValue("valueScaleInverse", queryEntry.OutputValueScaleFactorInverse);

                XmlElement stateQueryNode = dataSourceNode.AppendElementWithText("stateQuery", queryEntry.StateQuery);
                //stateQueryNode.SetAttributeValue("returnValueIsInt", queryEntry.ReturnValueIsInt);
                stateQueryNode.SetAttributeValue("useRowCountAsValue", queryEntry.UseRowCountAsValue);

                //XmlElement detailQueryNode = dataSourceNode.AppendElementWithText("detailQuery", queryEntry.DetailQuery);
                //detailQueryNode.SetAttributeValue("columnNames", queryEntry.ColumnNames.ToCSVString());

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


            //XmlNode wmiNode = root.SelectSingleNode("wmiQueries");
            //wmiNode.InnerXml = "";
            //foreach (WMIQueryCollectorConfigEntry entry in Entries)
            //{


            //    XmlElement entryNode = config.CreateElement("wmiQuery");
            //    entryNode.SetAttributeValue("name", entry.Name);
            //    entryNode.SetAttributeValue("namespace", entry.Namespace);
            //    entryNode.SetAttributeValue("machineName", entry.Machinename);
            //    entryNode.SetAttributeValue("primaryUIValue", entry.PrimaryUIValue);
            //    entryNode.SetAttributeValue("outputValueUnit", entry.OutputValueUnit);
            //    XmlElement stateQueryNode = config.CreateElement("stateQuery");
            //    stateQueryNode.SetAttributeValue("syntax", entry.StateQuery);
            //    stateQueryNode.SetAttributeValue("returnValueIsInt", entry.ReturnValueIsInt);
            //    stateQueryNode.SetAttributeValue("returnValueInverted", entry.ReturnValueInverted);
            //    stateQueryNode.SetAttributeValue("warningValue", entry.WarningValue);
            //    stateQueryNode.SetAttributeValue("errorValue", entry.ErrorValue);
            //    stateQueryNode.SetAttributeValue("successValue", entry.SuccessValue);
            //    stateQueryNode.SetAttributeValue("useRowCountAsValue", entry.UseRowCountAsValue);
            //    entryNode.AppendChild(stateQueryNode);

            //    XmlElement detailQueryNode = config.CreateElement("detailQuery");
            //    detailQueryNode.SetAttributeValue("syntax", entry.DetailQuery);
            //    detailQueryNode.SetAttributeValue("columnNames", entry.ColumnNames.ToCSVString());
            //    entryNode.AppendChild(detailQueryNode);
            //    wmiNode.AppendChild(entryNode);
            //}
            //return config.OuterXml;
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

            //return "<config><wmiQueries><wmiQuery name=\"Example\" namespace=\"root\\CIMV2\" machineName=\".\">" +
            //        "<stateQuery syntax=\"SELECT FreeSpace FROM Win32_LogicalDisk where Caption = 'C:'\" " +
            //            "returnValueIsInt=\"True\" returnValueInverted=\"True\" useRowCountAsValue=\"False\" " +
            //            "warningValue=\"1048576000\" errorValue=\"524288000\" successValue=\"[any]\" />" +
            //        "<detailQuery syntax=\"SELECT Caption, Size, FreeSpace, Description FROM Win32_LogicalDisk where Caption = 'C:'\" " + 
            //            "columnNames=\"Caption, Size, FreeSpace, Description\" keyColumn=\"0\" />" +
            //    "</wmiQuery></wmiQueries></config>";
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

    public class WMIQueryCollectorConfigEntry : ICollectorConfigEntry
    {
        #region ICollectorConfigEntry
        public MonitorState GetCurrentState()
        {
            MonitorState currentState = new MonitorState()
            {
                ForAgent = Name                
            };
            try
            {
                object value = RunQuery();
                string unitName = OutputValueUnit;
                if (UseRowCountAsValue && OutputValueUnit.Length == 0)
                    unitName = "row(s)";
                currentState.State = CollectorAgentReturnValueCompareEngine.GetState(ReturnCheckSequence, GoodResultMatchType, GoodValue,
                 WarningResultMatchType, WarningValue, ErrorResultMatchType, ErrorValue, value);
                currentState.CurrentValue = value;
                currentState.CurrentValueUnit = unitName;
                if (currentState.State == CollectorState.Error)
                {
                    currentState.RawDetails = string.Format("(Trigger '{0}')", ErrorValue);
                }
                else if (currentState.State == CollectorState.Warning)
                {
                    currentState.RawDetails = string.Format("(Trigger '{0}')", WarningValue);
                }
            }
            catch(Exception ex)
            {
                currentState.State = CollectorState.Error;
                currentState.RawDetails = ex.Message;
                if (ex.Message.Contains("Invalid class"))
                {
                    currentState.CurrentValue = "Invalid class";
                }
                else if (ex.Message.Contains("Invalid query"))
                {
                    currentState.CurrentValue = "Invalid query";
                }
            }
            return currentState;
        }
        public string Description
        {
            get {
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
        public bool PrimaryUIValue { get; set; }
        #endregion

        #region Properties
        public string Name { get; set; }
        public object CurrentAgentValue { get; set; }
        public string OutputValueUnit { get; set; }
        public string Namespace { get; set; }
        public string Machinename { get; set; }
        public string StateQuery { get; set; }
        //public bool ReturnValueIsInt { get; set; }
        //public bool ReturnValueInverted { get; set; }
        public bool UseRowCountAsValue { get; set; }
        public int OutputValueScaleFactor { get; set; }
        public bool OutputValueScaleFactorInverse { get; set; }
        //public string DetailQuery { get; set; }
        //public List<string> ColumnNames { get; set; }

        #region Alert trigger tests
        public CollectorAgentReturnValueCheckSequence ReturnCheckSequence { get; set; }
        public CollectorAgentReturnValueCompareMatchType GoodResultMatchType { get; set; }
        public string GoodValue { get; set; }
        public CollectorAgentReturnValueCompareMatchType WarningResultMatchType { get; set; }
        public string WarningValue { get; set; }
        public CollectorAgentReturnValueCompareMatchType ErrorResultMatchType { get; set; }
        public string ErrorValue { get; set; }
        #endregion
        #endregion

        public object RunQuery()
        {
            object value = null;
            if (UseRowCountAsValue)
            {
                value = RunQueryWithCountResult();
            }
            else
            {
                value = RunQueryWithSingleResult();
            }
            if (value != null && value.IsNumber())
            {
                double dvalue = double.Parse($"{value}");
                if (OutputValueScaleFactor > 0)
                {
                    if (!OutputValueScaleFactorInverse)
                        dvalue = dvalue * OutputValueScaleFactor;
                    else
                        dvalue = dvalue / OutputValueScaleFactor;
                }
                if (dvalue.IsIntegerTypeNumber())
                {
                    value = Convert.ToInt32(dvalue);
                }
                else
                {
                    value = dvalue.ToString("0.00");
                }                
            }
            return value;
        }
        //private CollectorState GetState(object value)
        //{
        //    CollectorState currentState = CollectorState.Good;
        //    if (value == null)
        //    {
        //        if (ErrorValue == "[null]")
        //            currentState = CollectorState.Error;
        //        else if (WarningValue == "[null]")
        //            currentState = CollectorState.Warning;
        //    }
        //    else //non null value
        //    {
        //        if (!ReturnValueIsInt)
        //        {
        //            if (value.ToString() == ErrorValue)
        //                currentState = CollectorState.Error;
        //            else if (value.ToString() == WarningValue)
        //                currentState = CollectorState.Warning;
        //            else if (value.ToString() == SuccessValue || SuccessValue == "[any]")
        //                currentState = CollectorState.Good; //just to flag condition
        //            else if (WarningValue == "[any]")
        //                currentState = CollectorState.Warning;
        //            else if (ErrorValue == "[any]")
        //                currentState = CollectorState.Error;
        //        }
        //        else //now we know the value is not null and must be in a range
        //        {
        //            if (!value.IsIntegerTypeNumber()) //value must be a number!
        //            {
        //                currentState = CollectorState.Error;
        //            }
        //            else if (ErrorValue != "[any]" && ErrorValue != "[null]" &&
        //                    (
        //                     (!ReturnValueInverted && decimal.Parse(value.ToString()) >= decimal.Parse(ErrorValue)) ||
        //                     (ReturnValueInverted && decimal.Parse(value.ToString()) <= decimal.Parse(ErrorValue))
        //                    )
        //                )
        //            {
        //                currentState = CollectorState.Error;
        //            }
        //            else if (WarningValue != "[any]" && WarningValue != "[null]" &&
        //                   (
        //                    (!ReturnValueInverted && decimal.Parse(value.ToString()) >= decimal.Parse(WarningValue)) ||
        //                    (ReturnValueInverted && decimal.Parse(value.ToString()) <= decimal.Parse(WarningValue))
        //                   )
        //                )
        //            {
        //                currentState = CollectorState.Warning;
        //            }
        //        }
        //    }
        //    return currentState;
        //}
        private decimal RunQueryWithCountResult()
        {
            decimal result = 0;
            ManagementScope managementScope = new ManagementScope(new ManagementPath(Namespace) { Server = Machinename });
            EnumerationOptions enumerationOptions = new EnumerationOptions();
            enumerationOptions.ReturnImmediately = true;
            using (ManagementObjectSearcher searcherInstance = new ManagementObjectSearcher(managementScope, new WqlObjectQuery(StateQuery), enumerationOptions)) // null))
            {
                if (searcherInstance != null)
                {
                    using (ManagementObjectCollection results = searcherInstance.Get())
                    {
                        result += results.Count;
                    }
                }
            }
            enumerationOptions = null;
            managementScope = null;
            return result;
        }
        private object RunQueryWithSingleResult()
        {
            ManagementScope managementScope = new ManagementScope(new ManagementPath(Namespace) { Server = Machinename });
            EnumerationOptions enumerationOptions = new EnumerationOptions();
            enumerationOptions.ReturnImmediately = true;
            using (ManagementObjectSearcher searcherInstance = new ManagementObjectSearcher(managementScope, new WqlObjectQuery(StateQuery), enumerationOptions))
            {
                if (searcherInstance != null)
                {
                    using (ManagementObjectCollection results = searcherInstance.Get())
                    {
                        int nItems = results.Count;
                        if (nItems > 0)
                        {
                            foreach (ManagementObject objServiceInstance in results)
                            {
                                foreach (var prop in objServiceInstance.Properties)
                                {
                                    return prop.Value; //return first value it encounters
                                }
                            }
                        }
                    }
                }
            }
            enumerationOptions = null;
            managementScope = null;
            return null;
        }

        //public List<DataColumn> GetDetailQueryColumns()
        //{
        //    List<DataColumn> columns = new List<DataColumn>();
        //    //columns.Add(new DataColumn("Machine", typeof(string)));
        //    //string firstMachineName = Machinename;
        //    ManagementScope managementScope = new ManagementScope(new ManagementPath(Namespace) { Server = Machinename });
        //    using (ManagementObjectSearcher searcherInstance = new ManagementObjectSearcher(managementScope, new WqlObjectQuery(DetailQuery), null))
        //    {
        //        if (searcherInstance != null)
        //        {
        //            using (ManagementObjectCollection results = searcherInstance.Get())
        //            {
        //                int nItems = results.Count;
        //                if (nItems > 0)
        //                {
        //                    foreach (ManagementObject objServiceInstance in results)
        //                    {
        //                        if (ColumnNames == null || ColumnNames.Count == 0)
        //                        {
        //                            foreach (var prop in objServiceInstance.Properties)
        //                            {
        //                                DataColumn newColum = new DataColumn(prop.Name);
        //                                string typeStr = prop.Type.ToString().ToLower();
        //                                if (typeStr == "string")
        //                                    newColum.DataType = typeof(string);
        //                                else if (typeStr == "uint64")
        //                                    newColum.DataType = typeof(UInt64);
        //                                else if (typeStr == "uint32")
        //                                    newColum.DataType = typeof(UInt32);
        //                                else if (typeStr == "uint16")
        //                                    newColum.DataType = typeof(UInt16);
        //                                else if (typeStr == "sint64")
        //                                    newColum.DataType = typeof(Int64);
        //                                else if (typeStr == "sint32")
        //                                    newColum.DataType = typeof(Int32);
        //                                else if (typeStr == "sint16")
        //                                    newColum.DataType = typeof(Int16);
        //                                else if (typeStr == "boolean")
        //                                    newColum.DataType = typeof(bool);
        //                                else if (typeStr == "datetime")
        //                                    newColum.DataType = typeof(DateTime);
        //                                else
        //                                    newColum.DataType = typeof(string);
        //                                newColum.AllowDBNull = true;
        //                                columns.Add(newColum);
        //                            }
        //                            break;
        //                        }
        //                        else
        //                        {
        //                            foreach (string columnName in ColumnNames)
        //                            {

        //                                var prop = objServiceInstance.Properties[columnName];
        //                                DataColumn newColum = new DataColumn(prop.Name);
        //                                string typeStr = prop.Type.ToString().ToLower();
        //                                if (typeStr == "string")
        //                                    newColum.DataType = typeof(string);
        //                                else if (typeStr == "uint64")
        //                                    newColum.DataType = typeof(UInt64);
        //                                else if (typeStr == "uint32")
        //                                    newColum.DataType = typeof(UInt32);
        //                                else if (typeStr == "uint16")
        //                                    newColum.DataType = typeof(UInt16);
        //                                else if (typeStr == "sint64")
        //                                    newColum.DataType = typeof(Int64);
        //                                else if (typeStr == "sint32")
        //                                    newColum.DataType = typeof(Int32);
        //                                else if (typeStr == "sint16")
        //                                    newColum.DataType = typeof(Int16);
        //                                else if (typeStr == "boolean")
        //                                    newColum.DataType = typeof(bool);
        //                                else if (typeStr == "datetime")
        //                                    newColum.DataType = typeof(DateTime);
        //                                else
        //                                    newColum.DataType = typeof(string);
        //                                newColum.AllowDBNull = true;
        //                                columns.Add(newColum);
        //                            }
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return columns;
        //}
        //private List<DataRow> GetDetailQueryRows(DataTable dtab, string machineName)
        //{
        //    List<DataRow> rows = new List<DataRow>();
        //    ManagementScope managementScope = new ManagementScope(new ManagementPath(Namespace) { Server = machineName });
        //    using (ManagementObjectSearcher searcherInstance = new ManagementObjectSearcher(managementScope, new WqlObjectQuery(DetailQuery), null))
        //    {
        //        if (searcherInstance != null)
        //        {
        //            using (ManagementObjectCollection results = searcherInstance.Get())
        //            {
        //                int nItems = results.Count;
        //                if (nItems > 0)
        //                {
        //                    foreach (ManagementObject objServiceInstance in results)
        //                    {
        //                        DataRow row = dtab.NewRow();
        //                        int fieldIndex = 0;
        //                        if (ColumnNames == null || ColumnNames.Count == 0)
        //                        {
        //                            foreach (var prop in objServiceInstance.Properties)
        //                            {
        //                                if (prop.Value == null)
        //                                    row[fieldIndex] = DBNull.Value;
        //                                else
        //                                    row[fieldIndex] = prop.Value;
        //                                fieldIndex++;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            foreach (string columnName in ColumnNames)
        //                            {
        //                                var prop = objServiceInstance.Properties[columnName];
        //                                if (prop.Value == null)
        //                                    row[fieldIndex] = DBNull.Value;
        //                                else
        //                                    row[fieldIndex] = prop.Value;
        //                                fieldIndex++;
        //                            }
        //                        }
        //                        rows.Add(row);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return rows;
        //}
        //public DataTable GetDetailDataTable()
        //{
        //    DataTable dtab = new DataTable(Machinename);
        //    dtab.Columns.AddRange(GetDetailQueryColumns().ToArray());
        //    foreach (DataRow row in GetDetailQueryRows(dtab, Machinename))
        //        dtab.Rows.Add(row);
        //    return dtab;
        //}
        //public DataSet RunDetailQuery()
        //{
        //    DataSet results = new DataSet();
        //    //string firstMachineName = Machinename;
        //    DataTable dtab = new DataTable(Machinename);
        //    dtab.Columns.AddRange(GetDetailQueryColumns().ToArray());

        //    foreach (DataRow row in GetDetailQueryRows(dtab, Machinename))
        //        dtab.Rows.Add(row);

        //    results.Tables.Add(dtab);
        //    return results;
        //}

    }
}
