using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Text;

namespace HenIT.WMI
{
    public class WMIQueryParser
    {
        public WMIQueryParser()
        {
            Machines = new List<string>();
            Fields = new List<string>();
            TimeOut = 0;
        }
        public List<string> Machines { get; set; }
        public string Namespace { get; set; }
        private string queryText = "";
        public string QueryText
        {
            get { return queryText; }
            set
            {
                queryText = value;
                ParseText();
            }
        }
        public bool IsParsed { get; private set; }
        public List<string> Fields { get; private set; }
        public string TableName { get; private set; }
        public string WhereText { get; private set; }
        public int TimeOut { get; set; }

        public void ParseText()
        {
            Fields = new List<string>();
            string[] parts = queryText.Split(new char[] { ' ', ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (!queryText.ToLower().Trim().StartsWith("select") &&
                (from part in parts
                 where part.Trim().ToLower() == "from"
                 select part).FirstOrDefault() == null)
            {
                IsParsed = false;
            }
            else
            {
                int fromIndex = 0;
                for (int i = 1; i < parts.Length && parts[i].ToLower() != "from"; i++)
                {
                    Fields.Add(parts[i]);
                    fromIndex = i + 1;
                }
                if (fromIndex + 1 < parts.Length)
                {
                    TableName = parts[fromIndex + 1];
                    WhereText = "";
                    if (fromIndex + 2 < parts.Length && parts[fromIndex + 2].ToLower() == "where")
                    {
                        for (int i = fromIndex + 3; i < parts.Length; i++)
                        {
                            WhereText += parts[i] + " ";
                        }
                        WhereText = WhereText.Trim();
                    }
                    IsParsed = true;
                }
                else
                    IsParsed = false;
            }

        }

        public DataSet RunQuery()
        {
            DataSet results = new DataSet();
            if (Machines != null && Machines.Count > 0 && Namespace.Length > 0)
            {
                string firstMachineName = Machines[0];
                DataTable dtab = new DataTable(firstMachineName);
                dtab.Columns.AddRange(GetQueryColumns().ToArray());

                foreach (string machineName in Machines)
                {
                    foreach (DataRow row in GetQueryRows(dtab, machineName))
                        dtab.Rows.Add(row);
                }

                results.Tables.Add(dtab);
            }
            return results;
        }
        private List<DataColumn> GetQueryColumns()
        {
            List<DataColumn> columns = new List<DataColumn>();
            columns.Add(new DataColumn("Machine", typeof(string)));
            string firstMachineName = Machines[0];
            ManagementScope managementScope = new ManagementScope(new ManagementPath(Namespace) { Server = firstMachineName });
            using (ManagementObjectSearcher searcherInstance = new ManagementObjectSearcher(managementScope, new WqlObjectQuery(QueryText), null))
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
                                    bool isArray = prop.IsArray;
                                    string typeStr = prop.Type.ToString().ToLower();
                                    if (!isArray)
                                    {
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
                                    }
                                    else
                                    {
                                        if (typeStr == "uint16")
                                            newColum.DataType = typeof(UInt16[]);
                                        else
                                            newColum.DataType = typeof(string[]);
                                    }
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
        private List<DataRow> GetQueryRows(DataTable dtab, string machineName)
        {
            List<DataRow> rows = new List<DataRow>();
            ManagementScope managementScope = new ManagementScope(new ManagementPath(Namespace) { Server = machineName });
            if (TimeOut > 0)
                managementScope.Options.Timeout = new TimeSpan(0, 0, TimeOut);
            using (ManagementObjectSearcher searcherInstance = new ManagementObjectSearcher(managementScope, new WqlObjectQuery(QueryText), null))
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
                                    else if (prop.IsArray)
                                    {
                                        row[fieldIndex] = prop.Cim2SystemValue();
                                    }
                                    else if (prop.Type.ToString() == "DateTime")
                                    {
                                        row[fieldIndex] = WMIDateStringToDate(prop.Value.ToString());
                                    }
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
        private DateTime WMIDateStringToDate(string dtmInstallDate)
        {
            string dt = dtmInstallDate.Substring(0, 4) + "/" + dtmInstallDate.Substring(4, 2) + "/" + dtmInstallDate.Substring(6, 2) + " " +
                    dtmInstallDate.Substring(8, 2) + ":" + dtmInstallDate.Substring(10, 2) + ":" + dtmInstallDate.Substring(12, 2);
            DateTime output;
            if (DateTime.TryParse(dt, out output))
                return output;
            else
                return DateTime.Now;
        }
    }

    public static class CimConvert
    {

        private readonly static IDictionary<CimType, Type> Cim2TypeTable =
            new Dictionary<CimType, Type>
        {
            {CimType.Boolean, typeof (bool)},
            {CimType.Char16, typeof (string)},
            {CimType.DateTime, typeof (DateTime)},
            {CimType.Object, typeof (object)},
            {CimType.Real32, typeof (decimal)},
            {CimType.Real64, typeof (decimal)},
            {CimType.Reference, typeof (object)},
            {CimType.SInt16, typeof (short)},
            {CimType.SInt32, typeof (int)},
            {CimType.SInt8, typeof (sbyte)},
            {CimType.String, typeof (string)},
            {CimType.UInt8, typeof (byte)},
            {CimType.UInt16, typeof (ushort)},
            {CimType.UInt32, typeof (uint)},
            {CimType.UInt64, typeof (ulong)}
        };

        public static Type Cim2SystemType(this PropertyData data)
        {
            Type type = Cim2TypeTable[data.Type];
            if (data.IsArray)
                type = type.MakeArrayType();
            return type;
        }

        public static object Cim2SystemValue(this PropertyData data)
        {
            Type type = Cim2SystemType(data);
            if (data.Type == CimType.DateTime)
                return DateTime.ParseExact(data.Value.ToString(), "yyyyMMddHHmmss.ffffff-000", CultureInfo.InvariantCulture);
            return Convert.ChangeType(data.Value, type);
        }
    }
}
