using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Data;

namespace QuickMon
{
    public class WMIConfigEntry
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public string Machinename { get; set; }
        public string StateQuery { get; set; }
        public bool ReturnValueIsInt { get; set; }
        public bool ReturnValueInverted { get; set; }
        public string WarningValue { get; set; }
        public string ErrorValue { get; set; }
        public string SuccessValue { get; set; }
        public bool UseRowCountAsValue { get; set; }

        public string DetailQuery { get; set; }
        public List<string> ColumnNames { get; set; }

        internal object RunQuery()
        {
            object value = null;
            if (!ReturnValueIsInt)
            {
                value = RunQueryWithSingleResult();
            }
            else
            {
                if (UseRowCountAsValue)
                {
                    value = RunQueryWithCountResult();
                }
                else
                {
                    value = RunQueryWithSingleResult();
                }
            }
            return value;
        }
        internal MonitorStates GetState(object value)
        {
            MonitorStates currentState = MonitorStates.Good;
            if (value == null)
            {
                if (ErrorValue == "[null]")
                    currentState = MonitorStates.Error;
                else if (WarningValue == "[null]")
                    currentState = MonitorStates.Warning;
            }
            else //non null value
            {
                if (!ReturnValueIsInt)
                {
                    if (value.ToString() == ErrorValue)
                        currentState = MonitorStates.Error;
                    else if (value.ToString() == WarningValue)
                        currentState = MonitorStates.Warning;
                    else if (value.ToString() == SuccessValue || SuccessValue == "[any]")
                        currentState = MonitorStates.Good; //just to flag condition
                    else if (WarningValue == "[any]")
                        currentState = MonitorStates.Warning;
                    else if (ErrorValue == "[any]")
                        currentState = MonitorStates.Error;
                }
                else //now we know the value is not null and must be in a range
                {
                    if (!value.IsIntegerTypeNumber()) //value must be a number!
                    {
                        currentState = MonitorStates.Error;
                    }
                    else if (ErrorValue != "[any]" && ErrorValue != "[null]" &&
                            (
                             (!ReturnValueInverted && decimal.Parse(value.ToString()) >= decimal.Parse(ErrorValue)) ||
                             (ReturnValueInverted && decimal.Parse(value.ToString()) <= decimal.Parse(ErrorValue))
                            )
                        )
                    {
                        currentState = MonitorStates.Error;
                    }
                    else if (WarningValue != "[any]" && WarningValue != "[null]" &&
                           (
                            (!ReturnValueInverted && decimal.Parse(value.ToString()) >= decimal.Parse(WarningValue)) ||
                            (ReturnValueInverted && decimal.Parse(value.ToString()) <= decimal.Parse(WarningValue))
                           )
                        )
                    {
                        currentState = MonitorStates.Warning;
                    }
                }
            }
            return currentState;
        }
        internal decimal RunQueryWithCountResult()
        {
            decimal result = 0;
            ManagementScope managementScope = new ManagementScope(new ManagementPath(Namespace) { Server = Machinename });
            using (ManagementObjectSearcher searcherInstance = new ManagementObjectSearcher(managementScope, new WqlObjectQuery(StateQuery), null))
            {
                if (searcherInstance != null)
                {
                    using (ManagementObjectCollection results = searcherInstance.Get())
                    {
                        result += results.Count;
                    }
                }
            }
            return result;
        }
        internal object RunQueryWithSingleResult()
        {
            ManagementScope managementScope = new ManagementScope(new ManagementPath(Namespace) { Server = Machinename });
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
            //columns.Add(new DataColumn("Machine", typeof(string)));
            //string firstMachineName = Machinename;
            ManagementScope managementScope = new ManagementScope(new ManagementPath(Namespace) { Server = Machinename });
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
                                //row["Machine"] = machineName;
                                int fieldIndex = 0;
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
            //string firstMachineName = Machinename;
            DataTable dtab = new DataTable(Machinename);
            dtab.Columns.AddRange(GetDetailQueryColumns().ToArray());

            foreach (DataRow row in GetDetailQueryRows(dtab, Machinename))
                dtab.Rows.Add(row);

            results.Tables.Add(dtab);
            return results;
        }
    }
}
