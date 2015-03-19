using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
using System.Text;

namespace QuickMon.Collectors
{
    public class WMIQueryCollectorConfigEntry : ICollectorConfigEntry
    {
        #region ICollectorConfigEntry
        public string Description
        {
            get { return string.Format("{0}: {1}\\{2} - {3} -> S:{4},W:{5},E:{6}", Name, Machinename, Namespace, StateQuery, SuccessValue, WarningValue, ErrorValue); }
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
        #endregion

        public object RunQuery()
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
        public CollectorState GetState(object value)
        {
            CollectorState currentState = CollectorState.Good;
            if (value == null)
            {
                if (ErrorValue == "[null]")
                    currentState = CollectorState.Error;
                else if (WarningValue == "[null]")
                    currentState = CollectorState.Warning;
            }
            else //non null value
            {
                if (!ReturnValueIsInt)
                {
                    if (value.ToString() == ErrorValue)
                        currentState = CollectorState.Error;
                    else if (value.ToString() == WarningValue)
                        currentState = CollectorState.Warning;
                    else if (value.ToString() == SuccessValue || SuccessValue == "[any]")
                        currentState = CollectorState.Good; //just to flag condition
                    else if (WarningValue == "[any]")
                        currentState = CollectorState.Warning;
                    else if (ErrorValue == "[any]")
                        currentState = CollectorState.Error;
                }
                else //now we know the value is not null and must be in a range
                {
                    if (!value.IsIntegerTypeNumber()) //value must be a number!
                    {
                        currentState = CollectorState.Error;
                    }
                    else if (ErrorValue != "[any]" && ErrorValue != "[null]" &&
                            (
                             (!ReturnValueInverted && decimal.Parse(value.ToString()) >= decimal.Parse(ErrorValue)) ||
                             (ReturnValueInverted && decimal.Parse(value.ToString()) <= decimal.Parse(ErrorValue))
                            )
                        )
                    {
                        currentState = CollectorState.Error;
                    }
                    else if (WarningValue != "[any]" && WarningValue != "[null]" &&
                           (
                            (!ReturnValueInverted && decimal.Parse(value.ToString()) >= decimal.Parse(WarningValue)) ||
                            (ReturnValueInverted && decimal.Parse(value.ToString()) <= decimal.Parse(WarningValue))
                           )
                        )
                    {
                        currentState = CollectorState.Warning;
                    }
                }
            }
            return currentState;
        }
        public decimal RunQueryWithCountResult()
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
        public object RunQueryWithSingleResult()
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

        public List<DataColumn> GetDetailQueryColumns()
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
                                if (ColumnNames == null || ColumnNames.Count == 0)
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
                                else
                                {
                                    foreach (string columnName in ColumnNames)
                                    {

                                        var prop = objServiceInstance.Properties[columnName];
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
                                int fieldIndex = 0;
                                if (ColumnNames == null || ColumnNames.Count == 0)
                                {
                                    foreach (var prop in objServiceInstance.Properties)
                                    {
                                        if (prop.Value == null)
                                            row[fieldIndex] = DBNull.Value;
                                        else
                                            row[fieldIndex] = prop.Value;
                                        fieldIndex++;
                                    }
                                }
                                else
                                {
                                    foreach (string columnName in ColumnNames)
                                    {
                                        var prop = objServiceInstance.Properties[columnName];
                                        if (prop.Value == null)
                                            row[fieldIndex] = DBNull.Value;
                                        else
                                            row[fieldIndex] = prop.Value;
                                        fieldIndex++;
                                    }
                                }
                                rows.Add(row);
                            }
                        }
                    }
                }
            }
            return rows;
        }
        public DataTable GetDetailDataTable()
        {
            DataTable dtab = new DataTable(Machinename);
            dtab.Columns.AddRange(GetDetailQueryColumns().ToArray());
            foreach (DataRow row in GetDetailQueryRows(dtab, Machinename))
                dtab.Rows.Add(row);
            return dtab;
        }
        public DataSet RunDetailQuery()
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
