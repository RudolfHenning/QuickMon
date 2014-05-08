using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Management;
using System.Data;

namespace QuickMon
{
    public class WMIConfig
    {
        public List<WMIConfigEntry> Entries { get; set; }
        //public string Namespace { get; set; }
        //public string Machinename { get; set; }
        //public string StateQuery { get; set; }
        //public bool ReturnValueIsInt { get; set; }
        //public bool ReturnValueInverted { get; set; }
        //public string WarningValue { get; set; }
        //public string ErrorValue { get; set; }
        //public string SuccessValue { get; set; }
        //public bool UseRowCountAsValue { get; set; }

        //public string DetailQuery { get; set; }
        //public List<string> ColumnNames { get; set; }
        //public int KeyColumn { get; set; }

        public void ReadConfig(XmlDocument config)
        {
            Entries = new List<WMIConfigEntry>();
            XmlElement root = config.DocumentElement;
            ReadOldConfig(root);
            foreach (XmlElement wmiQueryNode in root.SelectNodes("wmiQueries/wmiQuery"))
            {
                WMIConfigEntry entry = new WMIConfigEntry();                
                entry.Namespace = wmiQueryNode.ReadXmlElementAttr("namespace", "root\\CIMV2");
                entry.Machinename = wmiQueryNode.ReadXmlElementAttr("machineName", ".");
                entry.Name = wmiQueryNode.ReadXmlElementAttr("name", entry.Machinename);
                XmlNode stateQueryNode = wmiQueryNode.SelectSingleNode("stateQuery");
                entry.StateQuery = stateQueryNode.ReadXmlElementAttr("syntax", "");
                entry.ReturnValueIsInt = bool.Parse(stateQueryNode.ReadXmlElementAttr("returnValueIsInt", "True"));
                entry.ReturnValueInverted = bool.Parse(stateQueryNode.ReadXmlElementAttr("returnValueInverted", "False"));
                entry.WarningValue = stateQueryNode.ReadXmlElementAttr("warningValue", "0");
                entry.ErrorValue = stateQueryNode.ReadXmlElementAttr("errorValue", "0");
                entry.SuccessValue = stateQueryNode.ReadXmlElementAttr("successValue", "[any]");
                entry.UseRowCountAsValue = bool.Parse(stateQueryNode.ReadXmlElementAttr("useRowCountAsValue", "True"));
                XmlNode detailQueryNode = wmiQueryNode.SelectSingleNode("detailQuery");
                entry.DetailQuery = detailQueryNode.ReadXmlElementAttr("syntax", "");
                string columns = detailQueryNode.ReadXmlElementAttr("columnNames", "");
                entry.ColumnNames = new List<string>();
                if (columns.Length > 0 && columns.IndexOf(',') > -1)
                    entry.ColumnNames = columns.ToListFromCSVString(); 
                else if (columns.Length > 0)
                    entry.ColumnNames.Add(columns);
                Entries.Add(entry);
            }
            //XmlNode wmiNode = root.SelectSingleNode("wmi");
            //Namespace = wmiNode.ReadXmlElementAttr("namespace", "root\\CIMV2");

            //try
            //{
            //    Machinename = wmiNode.ReadXmlElementAttr("machineName", ".");
            //    if (Machinename == ".")
            //    {
            //        string machineNames = wmiNode.ReadXmlElementAttr("machines", "."); //old node
            //        Machinename = machineNames.ToListFromCSVString(true)[0];
            //    }
            //}
            //catch 
            //{
            //    Machinename = ".";
            //}

            //XmlNode stateQueryNode = root.SelectSingleNode("wmi/stateQuery");
            //StateQuery = stateQueryNode.ReadXmlElementAttr("syntax", "");
            //ReturnValueIsInt = bool.Parse(stateQueryNode.ReadXmlElementAttr("returnValueIsInt", "True"));
            //ReturnValueInverted = bool.Parse(stateQueryNode.ReadXmlElementAttr("returnValueInverted", "False"));
            //WarningValue = stateQueryNode.ReadXmlElementAttr("warningValue", "0");
            //ErrorValue = stateQueryNode.ReadXmlElementAttr("errorValue", "0");
            //SuccessValue = stateQueryNode.ReadXmlElementAttr("successValue", "[any]");
            //UseRowCountAsValue = bool.Parse(stateQueryNode.ReadXmlElementAttr("useRowCountAsValue", "True"));

            //XmlNode detailQueryNode = root.SelectSingleNode("wmi/detailQuery");
            //DetailQuery = detailQueryNode.ReadXmlElementAttr("syntax", "");
            //string columns = detailQueryNode.ReadXmlElementAttr("columnNames", "");
            //ColumnNames = new List<string>();
            //if (columns.Length > 0 && columns.IndexOf(',') > -1)
            //    ColumnNames = columns.ToListFromCSVString(); 
            //else if (columns.Length > 0)
            //    ColumnNames.Add(columns);
            ////KeyColumn = int.Parse(detailQueryNode.ReadXmlElementAttr("keyColumn", "0"));
        }

        private void ReadOldConfig(XmlElement root)
        {            
            XmlNode wmiNode = root.SelectSingleNode("wmi");
            if (wmiNode != null)
            {
                WMIConfigEntry entry = new WMIConfigEntry();
                entry.Name = "Previous version entry";
                entry.Namespace = wmiNode.ReadXmlElementAttr("namespace", "root\\CIMV2");

                try
                {
                    entry.Machinename = wmiNode.ReadXmlElementAttr("machineName", ".");
                    if (entry.Machinename == ".")
                    {
                        string machineNames = wmiNode.ReadXmlElementAttr("machines", "."); //old node
                        entry.Machinename = machineNames.ToListFromCSVString(true)[0];
                    }
                }
                catch
                {
                    entry.Machinename = ".";
                }

                XmlNode stateQueryNode = root.SelectSingleNode("wmi/stateQuery");
                entry.StateQuery = stateQueryNode.ReadXmlElementAttr("syntax", "");
                entry.ReturnValueIsInt = bool.Parse(stateQueryNode.ReadXmlElementAttr("returnValueIsInt", "True"));
                entry.ReturnValueInverted = bool.Parse(stateQueryNode.ReadXmlElementAttr("returnValueInverted", "False"));
                entry.WarningValue = stateQueryNode.ReadXmlElementAttr("warningValue", "0");
                entry.ErrorValue = stateQueryNode.ReadXmlElementAttr("errorValue", "0");
                entry.SuccessValue = stateQueryNode.ReadXmlElementAttr("successValue", "[any]");
                entry.UseRowCountAsValue = bool.Parse(stateQueryNode.ReadXmlElementAttr("useRowCountAsValue", "True"));

                XmlNode detailQueryNode = root.SelectSingleNode("wmi/detailQuery");
                entry.DetailQuery = detailQueryNode.ReadXmlElementAttr("syntax", "");
                string columns = detailQueryNode.ReadXmlElementAttr("columnNames", "");
                entry.ColumnNames = new List<string>();
                if (columns.Length > 0 && columns.IndexOf(',') > -1)
                    entry.ColumnNames = columns.ToListFromCSVString();
                else if (columns.Length > 0)
                    entry.ColumnNames.Add(columns);

                Entries.Add(entry);
            }
        }

        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();            
            config.LoadXml(Properties.Resources.WMIQueryEmptyConfig);
            XmlElement root = config.DocumentElement;
            XmlNode wmiNode = root.SelectSingleNode("wmiQueries");
            wmiNode.InnerXml = "";
            foreach (WMIConfigEntry entry in Entries)
            {
                XmlElement entryNode = config.CreateElement("wmiQuery");
                entryNode.SetAttributeValue("name", entry.Name);
                entryNode.SetAttributeValue("namespace", entry.Namespace);
                entryNode.SetAttributeValue("machineName", entry.Machinename);
                XmlElement stateQueryNode = config.CreateElement("stateQuery");
                stateQueryNode.SetAttributeValue("syntax", entry.StateQuery);
                stateQueryNode.SetAttributeValue("returnValueIsInt", entry.ReturnValueIsInt);
                stateQueryNode.SetAttributeValue("returnValueInverted", entry.ReturnValueInverted);
                stateQueryNode.SetAttributeValue("warningValue", entry.WarningValue);
                stateQueryNode.SetAttributeValue("errorValue", entry.ErrorValue);
                stateQueryNode.SetAttributeValue("successValue", entry.SuccessValue);
                stateQueryNode.SetAttributeValue("useRowCountAsValue", entry.UseRowCountAsValue);
                entryNode.AppendChild(stateQueryNode);

                XmlElement detailQueryNode = config.CreateElement("detailQuery");
                detailQueryNode.SetAttributeValue("syntax", entry.DetailQuery);
                detailQueryNode.SetAttributeValue("columnNames", entry.ColumnNames.ToCSVString());
                entryNode.AppendChild(detailQueryNode);
                wmiNode.AppendChild(entryNode);
            }

            //XmlNode wmiNode = root.SelectSingleNode("wmi");
            //wmiNode.SetAttributeValue("namespace", Namespace);
            //wmiNode.SetAttributeValue("machineName", Machinename);

            //XmlNode stateQueryNode = root.SelectSingleNode("wmi/stateQuery");
            

            //XmlNode detailQueryNode = root.SelectSingleNode("wmi/detailQuery");
            //detailQueryNode.SetAttributeValue("syntax", DetailQuery);
            //detailQueryNode.SetAttributeValue("columnNames", ColumnNames.ToCSVString());
            ////detailQueryNode.SetAttributeValue("keyColumn", KeyColumn);

            return config.OuterXml;
        }

        //internal decimal RunQueryWithCountResult(string machineName)
        //{
        //    decimal result = 0;
        //    ManagementScope managementScope = new ManagementScope(new ManagementPath(Namespace) { Server = machineName });
        //    using (ManagementObjectSearcher searcherInstance = new ManagementObjectSearcher(managementScope, new WqlObjectQuery(StateQuery), null))
        //    {
        //        if (searcherInstance != null)
        //        {
        //            using (ManagementObjectCollection results = searcherInstance.Get())
        //            {
        //                result += results.Count;
        //            }
        //        }
        //    }
        //    return result;
        //}
        //internal object RunQueryWithSingleResult(string machineName)
        //{
        //    ManagementScope managementScope = new ManagementScope(new ManagementPath(Namespace) { Server = machineName });
        //    using (ManagementObjectSearcher searcherInstance = new ManagementObjectSearcher(managementScope, new WqlObjectQuery(StateQuery), null))
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
        //                        foreach (var prop in objServiceInstance.Properties)
        //                        {
        //                            return prop.Value; //return first value it encounters
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return null;
        //}

        //internal List<DataColumn> GetDetailQueryColumns()
        //{
        //    List<DataColumn> columns = new List<DataColumn>();
        //    columns.Add(new DataColumn("Machine", typeof(string)));
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
        //                        foreach (var prop in objServiceInstance.Properties)
        //                        {
        //                            DataColumn newColum = new DataColumn(prop.Name);
        //                            string typeStr = prop.Type.ToString().ToLower();
        //                            if (typeStr == "string")
        //                                newColum.DataType = typeof(string);
        //                            else if (typeStr == "uint64")
        //                                newColum.DataType = typeof(UInt64);
        //                            else if (typeStr == "uint32")
        //                                newColum.DataType = typeof(UInt32);
        //                            else if (typeStr == "uint16")
        //                                newColum.DataType = typeof(UInt16);
        //                            else if (typeStr == "sint64")
        //                                newColum.DataType = typeof(Int64);
        //                            else if (typeStr == "sint32")
        //                                newColum.DataType = typeof(Int32);
        //                            else if (typeStr == "sint16")
        //                                newColum.DataType = typeof(Int16);
        //                            else if (typeStr == "boolean")
        //                                newColum.DataType = typeof(bool);
        //                            else if (typeStr == "datetime")
        //                                newColum.DataType = typeof(DateTime);
        //                            else
        //                                newColum.DataType = typeof(string);
        //                            newColum.AllowDBNull = true;
        //                            columns.Add(newColum);
        //                        }
        //                        break;                                
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
        //                        row["Machine"] = machineName;
        //                        int fieldIndex = 1;
        //                        foreach (var prop in objServiceInstance.Properties)
        //                        {
        //                            if (prop.Value == null)
        //                                row[fieldIndex] = DBNull.Value;
        //                            else
        //                                row[fieldIndex] = prop.Value;
        //                            fieldIndex++;
        //                        }
        //                        rows.Add(row);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return rows;
        //}
        //internal DataSet RunDetailQuery()
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

        //internal object RunQuery()
        //{
        //    object value = null;
        //    if (!ReturnValueIsInt)
        //    {
        //        value = RunQueryWithSingleResult(Machinename);
        //    }
        //    else
        //    {
        //        if (UseRowCountAsValue)
        //        {
        //            value = RunQueryWithCountResult(Machinename);
        //        }
        //        else
        //        {
        //            value = RunQueryWithSingleResult(Machinename);
        //        }
        //    }
        //    return value;
        //}

        //internal MonitorStates GetState(object value)
        //{
        //    MonitorStates currentState = MonitorStates.Good;
        //    if (value == null)
        //    {
        //        if (ErrorValue == "[null]")
        //            currentState = MonitorStates.Error;
        //        else if (WarningValue == "[null]")
        //            currentState = MonitorStates.Warning;
        //    }
        //    else //non null value
        //    {
        //        if (!ReturnValueIsInt)
        //        {
        //            if (value.ToString() == ErrorValue)
        //                currentState = MonitorStates.Error;
        //            else if (value.ToString() == WarningValue)
        //                currentState = MonitorStates.Warning;
        //            else if (value.ToString() == SuccessValue || SuccessValue == "[any]")
        //                currentState = MonitorStates.Good; //just to flag condition
        //            else if (WarningValue == "[any]")
        //                currentState = MonitorStates.Warning;
        //            else if (ErrorValue == "[any]")
        //                currentState = MonitorStates.Error;
        //        }
        //        else //now we know the value is not null and must be in a range
        //        {
        //            if (!value.IsIntegerTypeNumber()) //value must be a number!
        //            {
        //                currentState = MonitorStates.Error;
        //            }
        //            else if (ErrorValue != "[any]" && ErrorValue != "[null]" &&
        //                    (
        //                     (!ReturnValueInverted && decimal.Parse(value.ToString()) >= decimal.Parse(ErrorValue)) ||
        //                     (ReturnValueInverted && decimal.Parse(value.ToString()) <= decimal.Parse(ErrorValue))
        //                    )
        //                )
        //            {
        //                currentState = MonitorStates.Error;
        //            }
        //            else if (WarningValue != "[any]" && WarningValue != "[null]" &&
        //                   (
        //                    (!ReturnValueInverted && decimal.Parse(value.ToString()) >= decimal.Parse(WarningValue)) ||
        //                    (ReturnValueInverted && decimal.Parse(value.ToString()) <= decimal.Parse(WarningValue))
        //                   )
        //                )
        //            {
        //                currentState = MonitorStates.Warning;
        //            }
        //        }
        //    }
        //    return currentState;
        //}
    }
}
