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
        public string Namespace { get; set; }
        public List<string> Machines { get; set; }
        public string StateQuery { get; set; }
        public bool ReturnValueIsInt { get; set; }
        public bool ReturnValueInverted { get; set; }
        public string WarningValue { get; set; }
        public string ErrorValue { get; set; }
        public string SuccessValue { get; set; }
        public bool UseRowCountAsValue { get; set; }

        public string DetailQuery { get; set; }
        public List<string> ColumnNames { get; set; }
        //public int KeyColumn { get; set; }

        public void ReadConfig(XmlDocument config)
        {
            XmlElement root = config.DocumentElement;
            XmlNode wmiNode = root.SelectSingleNode("wmi");
            Namespace = wmiNode.ReadXmlElementAttr("namespace", "root\\CIMV2");
            Machines = new List<string>();
            string machineNames = wmiNode.ReadXmlElementAttr("machines", "."); //;
            Machines = machineNames.ToListFromCSVString(true);

            XmlNode stateQueryNode = root.SelectSingleNode("wmi/stateQuery");
            StateQuery = stateQueryNode.ReadXmlElementAttr("syntax", "");
            ReturnValueIsInt = bool.Parse(stateQueryNode.ReadXmlElementAttr("returnValueIsInt", "True"));
            ReturnValueInverted = bool.Parse(stateQueryNode.ReadXmlElementAttr("returnValueInverted", "False"));
            WarningValue = stateQueryNode.ReadXmlElementAttr("warningValue", "0");
            ErrorValue = stateQueryNode.ReadXmlElementAttr("errorValue", "0");
            SuccessValue = stateQueryNode.ReadXmlElementAttr("successValue", "[any]");
            UseRowCountAsValue = bool.Parse(stateQueryNode.ReadXmlElementAttr("useRowCountAsValue", "True"));

            XmlNode detailQueryNode = root.SelectSingleNode("wmi/detailQuery");
            DetailQuery = detailQueryNode.ReadXmlElementAttr("syntax", "");
            string columns = detailQueryNode.ReadXmlElementAttr("columnNames", "");
            ColumnNames = new List<string>();
            if (columns.Length > 0 && columns.IndexOf(',') > -1)
                ColumnNames = columns.ToListFromCSVString(); 
            else if (columns.Length > 0)
                ColumnNames.Add(columns);
            //KeyColumn = int.Parse(detailQueryNode.ReadXmlElementAttr("keyColumn", "0"));
        }

        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();            
            config.LoadXml(Properties.Resources.WMIQueryEmptyConfig);
            XmlElement root = config.DocumentElement;

            XmlNode wmiNode = root.SelectSingleNode("wmi");
            wmiNode.SetAttributeValue("namespace", Namespace);            
            wmiNode.SetAttributeValue("machines", Machines.ToCSVString());

            XmlNode stateQueryNode = root.SelectSingleNode("wmi/stateQuery");
            stateQueryNode.SetAttributeValue("syntax", StateQuery);
            stateQueryNode.SetAttributeValue("returnValueIsInt", ReturnValueIsInt);
            stateQueryNode.SetAttributeValue("returnValueInverted", ReturnValueInverted);
            stateQueryNode.SetAttributeValue("warningValue", WarningValue);
            stateQueryNode.SetAttributeValue("errorValue", ErrorValue);
            stateQueryNode.SetAttributeValue("successValue", SuccessValue);
            stateQueryNode.SetAttributeValue("useRowCountAsValue", UseRowCountAsValue);

            XmlNode detailQueryNode = root.SelectSingleNode("wmi/detailQuery");
            detailQueryNode.SetAttributeValue("syntax", DetailQuery);
            detailQueryNode.SetAttributeValue("columnNames", ColumnNames.ToCSVString());
            //detailQueryNode.SetAttributeValue("keyColumn", KeyColumn);

            return config.OuterXml;
        }

        internal decimal RunQueryWithCountResult(string machineName)
        {
            decimal result = 0;
            ManagementScope managementScope = new ManagementScope(new ManagementPath(Namespace) { Server = machineName });
            using (ManagementObjectSearcher searcherInstance = new ManagementObjectSearcher(managementScope, new WqlObjectQuery(StateQuery), null))
            {
                if (searcherInstance != null)
                {
                    using (ManagementObjectCollection results = searcherInstance.Get())
                    {
                        result = results.Count;                        
                    }
                }
            }
            return result;
        }
        internal object RunQueryWithSingleResult(string machineName)
        {
            ManagementScope managementScope = new ManagementScope(new ManagementPath(Namespace) { Server = machineName });
            using (ManagementObjectSearcher searcherInstance = new ManagementObjectSearcher(managementScope, new WqlObjectQuery(StateQuery), null))
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
            return null;
        }

        internal List<DataColumn> GetDetailQueryColumns()
        {
            List<DataColumn> columns = new List<DataColumn>();
            columns.Add(new DataColumn("Machine", typeof(string)));
            string firstMachineName = Machines[0];
            ManagementScope managementScope = new ManagementScope(new ManagementPath(Namespace) { Server = firstMachineName });
            using (ManagementObjectSearcher searcherInstance = new ManagementObjectSearcher(managementScope, new WqlObjectQuery(DetailQuery), null))
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
                                    DataColumn newColum = new DataColumn(prop.Name);
                                    string typeStr = prop.Type.ToString().ToLower();
                                    if (typeStr == "string")
                                        newColum.DataType = typeof(string);
                                    else if (typeStr == "uint64")
                                        newColum.DataType = typeof(UInt64);
                                    else if (typeStr == "uint32")
                                        newColum.DataType = typeof(UInt32);
                                    else if (typeStr == "uint16")
                                        newColum.DataType = typeof(UInt16);
                                    else if (typeStr == "sint64")
                                        newColum.DataType = typeof(Int64);
                                    else if (typeStr == "sint32")
                                        newColum.DataType = typeof(Int32);
                                    else if (typeStr == "sint16")
                                        newColum.DataType = typeof(Int16);
                                    else if (typeStr == "boolean")
                                        newColum.DataType = typeof(bool);
                                    else if (typeStr == "datetime")
                                        newColum.DataType = typeof(DateTime);
                                    else
                                        newColum.DataType = typeof(string);
                                    newColum.AllowDBNull = true;
                                    columns.Add(newColum);
                                }
                                break;                                
                            }
                        }
                    }
                }
            }
            return columns;
        }
        private List<DataRow> GetDetailQueryRows(DataTable dtab, string machineName)
        {
            List<DataRow> rows = new List<DataRow>();
            ManagementScope managementScope = new ManagementScope(new ManagementPath(Namespace) { Server = machineName });
            using (ManagementObjectSearcher searcherInstance = new ManagementObjectSearcher(managementScope, new WqlObjectQuery(DetailQuery), null))
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
                                DataRow row = dtab.NewRow();
                                row["Machine"] = machineName;
                                int fieldIndex = 1;
                                foreach (var prop in objServiceInstance.Properties)
                                {
                                    if (prop.Value == null)
                                        row[fieldIndex] = DBNull.Value;
                                    else
                                        row[fieldIndex] = prop.Value;
                                    fieldIndex++;
                                }
                                rows.Add(row);
                            }
                        }
                    }
                }
            }
            return rows;
        }
        internal DataSet RunDetailQuery()
        {
            DataSet results = new DataSet();
            string firstMachineName = Machines[0];
            DataTable dtab = new DataTable(firstMachineName);
            dtab.Columns.AddRange(GetDetailQueryColumns().ToArray());

            foreach (string machineName in Machines)
            {
                foreach (DataRow row in GetDetailQueryRows(dtab, machineName))
                    dtab.Rows.Add(row);
            }

            results.Tables.Add(dtab);
            return results;
        }
    }
}
