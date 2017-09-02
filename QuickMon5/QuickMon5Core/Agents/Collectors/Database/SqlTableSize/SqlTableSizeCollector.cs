using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("Sql Table Size Collector"), Category("Database")]
    public class SqlTableSizeCollector : CollectorAgentBase
    {
        public SqlTableSizeCollector()
        {
            AgentConfig = new SqlTableSizeCollectorConfig();
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
        //        SqlTableSizeCollectorConfig currentConfig = (SqlTableSizeCollectorConfig)AgentConfig;

        //        returnState.RawDetails = string.Format("Querying {0} database(s)", currentConfig.Entries.Count);
        //        returnState.HtmlDetails = string.Format("<b>Querying {0} database(s)</b>", currentConfig.Entries.Count);
        //        returnState.CurrentValue = 0;
        //        foreach (SqlTableSizeCollectorEntry entry in currentConfig.Entries)
        //        {
        //            entry.RefreshRowCounts();
        //            List<Tuple<TableSizeEntry, CollectorState>> states = entry.GetStates();

        //            MonitorState entryState = new MonitorState() { ForAgent = entry.Description };

        //            foreach (var tableEntryState in states)
        //            {
        //                if (tableEntryState.Item1.RowCount > 0)
        //                    totalValue += tableEntryState.Item1.RowCount;
        //                if (tableEntryState.Item2 == CollectorState.Error)
        //                {
        //                    errors++;                            
        //                    entryState.ChildStates.Add(
        //                            new MonitorState()
        //                            {
        //                                State = CollectorState.Error,
        //                                ForAgent = tableEntryState.Item1.TableName,
        //                                CurrentValue = string.Format("{0} row(s)", tableEntryState.Item1.RowCount),
        //                                RawDetails = tableEntryState.Item1.RowCount > 0 ? "(Trigger '" + tableEntryState.Item1.ErrorValue.ToString() + "')" : tableEntryState.Item1.ErrorStr
        //                                //RawDetails = string.Format("'{0}' - {1} (Error, {2})", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount, (tableEntryState.Item1.RowCount > 0 ? "Trigger " + tableEntryState.Item1.ErrorValue.ToString() : tableEntryState.Item1.ErrorStr)),
        //                                //HtmlDetails = string.Format("'{0}' - {1} (<b>Error, {2}</b>)", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount, (tableEntryState.Item1.RowCount > 0 ? "Trigger " + tableEntryState.Item1.ErrorValue.ToString() : tableEntryState.Item1.ErrorStr))
        //                            });
        //                }
        //                else if (tableEntryState.Item2 == CollectorState.Warning)
        //                {
        //                    warnings++;
        //                    entryState.ChildStates.Add(
        //                        new MonitorState()
        //                        {
        //                            State = CollectorState.Warning,
        //                            ForAgent = tableEntryState.Item1.TableName,
        //                            CurrentValue = string.Format("{0} row(s)", tableEntryState.Item1.RowCount),
        //                            RawDetails = string.Format("(Trigger '{0}')", tableEntryState.Item1.WarningValue)
        //                            //RawDetails = string.Format("'{0}' - {1} (Warning, Trigger {2})", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount, tableEntryState.Item1.WarningValue),
        //                            //HtmlDetails = string.Format("'{0}' - {1} (<b>Warning, Trigger {2}</b>)", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount, tableEntryState.Item1.WarningValue)
        //                        });
        //                }
        //                else
        //                {
        //                    success++;
        //                    entryState.ChildStates.Add(
        //                        new MonitorState()
        //                        {
        //                            State = CollectorState.Good,
        //                            ForAgent = tableEntryState.Item1.TableName,
        //                            CurrentValue = string.Format("{0} row(s)", tableEntryState.Item1.RowCount) //,
        //                            //RawDetails = string.Format("'{0}' - {1}", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount),
        //                            //HtmlDetails = string.Format("'{0}' - {1}", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount)
        //                        });
        //                }
        //            }
        //            entryState.CurrentValue = totalValue;
        //            returnState.ChildStates.Add(entryState);                    
        //        }

        //        if (errors > 0 && warnings == 0 && success == 0) // any errors
        //            returnState.State = CollectorState.Error;
        //        else if (errors > 0 || warnings > 0) //any warnings
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
        //    SqlTableSizeCollectorConfig currentConfig = (SqlTableSizeCollectorConfig)AgentConfig;
        //    foreach (SqlTableSizeCollectorEntry entry in currentConfig.Entries)
        //    {
        //        entry.RefreshRowCounts();
        //        tables.Add(entry.GetDetailDataTable());
        //    }

        //    return tables;
        //}
    }
    public class SqlTableSizeCollectorConfig : ICollectorConfig
    {
        public SqlTableSizeCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement databaseNode in root.SelectNodes("databases/database"))
            {
                SqlTableSizeCollectorEntry entry = new SqlTableSizeCollectorEntry();
                entry.SqlServer = databaseNode.ReadXmlElementAttr("server", "");
                entry.Database = databaseNode.ReadXmlElementAttr("name", "");
                entry.IntegratedSecurity = databaseNode.ReadXmlElementAttr("integratedSec", true);
                entry.UserName = databaseNode.ReadXmlElementAttr("userName", "");
                entry.Password = databaseNode.ReadXmlElementAttr("password", "");
                entry.SqlCmndTimeOutSec = databaseNode.ReadXmlElementAttr("sqlCmndTimeOutSec", 30);
                entry.PrimaryUIValue = databaseNode.ReadXmlElementAttr("primaryUIValue", true);

                foreach (XmlElement tableNode in databaseNode.SelectNodes("table"))
                {
                    TableSizeEntry tableSizeEntry = new TableSizeEntry();
                    tableSizeEntry.TableName = tableNode.ReadXmlElementAttr("name", "");
                    tableSizeEntry.WarningValue = long.Parse(tableNode.ReadXmlElementAttr("warningValue", "1"));
                    tableSizeEntry.ErrorValue = long.Parse(tableNode.ReadXmlElementAttr("errorValue", "2"));
                    entry.Tables.Add(tableSizeEntry);
                }

                Entries.Add(entry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode databasesNode = root.SelectSingleNode("databases");
            databasesNode.InnerXml = "";

            foreach (SqlTableSizeCollectorEntry databaseEntry in Entries)
            {
                XmlElement databaseNode = config.CreateElement("database");
                databaseNode.SetAttributeValue("name", databaseEntry.Database);
                databaseNode.SetAttributeValue("server", databaseEntry.SqlServer);
                databaseNode.SetAttributeValue("integratedSec", databaseEntry.IntegratedSecurity);
                databaseNode.SetAttributeValue("userName", databaseEntry.UserName);
                databaseNode.SetAttributeValue("password", databaseEntry.Password);
                databaseNode.SetAttributeValue("sqlCmndTimeOutSec", databaseEntry.SqlCmndTimeOutSec);
                databaseNode.SetAttributeValue("primaryUIValue", databaseEntry.PrimaryUIValue);

                foreach (TableSizeEntry tableSizeEntry in databaseEntry.Tables)
                {
                    XmlElement tableNode = config.CreateElement("table");
                    tableNode.SetAttributeValue("name", tableSizeEntry.TableName);
                    tableNode.SetAttributeValue("warningValue", tableSizeEntry.WarningValue);
                    tableNode.SetAttributeValue("errorValue", tableSizeEntry.ErrorValue);
                    databaseNode.AppendChild(tableNode);
                }
                databasesNode.AppendChild(databaseNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config><databases><database name=\"\" server=\"\" integratedSec=\"True\" userName=\"\" password=\"\" sqlCmndTimeOutSec=\"30\"></database></databases></config>";
        }
        public string ConfigSummary
        {
            get { throw new NotImplementedException(); }
        }
    }
    public class SqlTableSizeCollectorEntry : ICollectorConfigEntry
    {
        public SqlTableSizeCollectorEntry()
        {
            IntegratedSecurity = true;
            SqlCmndTimeOutSec = 30;
            Tables = new List<TableSizeEntry>();
        }

        #region ICollectorConfigEntry Members
        public string Description
        {
            get { return string.Format("[{0}].{1}", SqlServer, Database); }
        }
        public string TriggerSummary
        {
            get
            {
                return string.Format("Table(s): {0}", Tables.Count);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        public object CurrentAgentValue { get; set; }
        public bool PrimaryUIValue { get; set; }
        public MonitorState GetCurrentState()
        {
            RefreshRowCounts();
            MonitorState currentState = new MonitorState() { ForAgent = Description };
            List<Tuple<TableSizeEntry, CollectorState>> states = GetStates();
            long totalValue = 0;
            int goods = 0;
            int warnings = 0;
            int errors = 0;
            int totalCount = 0;
            foreach (var tableEntryState in states)
            {
                if (tableEntryState.Item1.RowCount > 0)
                    totalValue += tableEntryState.Item1.RowCount;

                MonitorState tableState = new MonitorState() {
                    ForAgent = tableEntryState.Item1.TableName,
                    State = tableEntryState.Item2,
                    CurrentValue = tableEntryState.Item1.RowCount,
                    CurrentValueUnit = "row(s)"
                };
                
                if (tableEntryState.Item2 == CollectorState.Error)
                {
                    tableState.RawDetails = tableEntryState.Item1.RowCount > 0 ? "(Trigger '" + tableEntryState.Item1.ErrorValue.ToString() + "')" : tableEntryState.Item1.ErrorStr;
                    errors++;
                }
                else if (tableEntryState.Item2 == CollectorState.Warning)
                {
                    tableState.RawDetails = string.Format("(Trigger '{0}')", tableEntryState.Item1.WarningValue);
                    warnings++;
                }                
                else
                {
                    goods++;
                }
                totalCount++;
                currentState.ChildStates.Add(tableState);
            }
            currentState.CurrentValue = totalValue;
            currentState.CurrentValueUnit = "row(s)";
            CurrentAgentValue = totalValue;
            if (totalCount > 0)
            {
                if (errors == totalCount)
                    currentState.State = CollectorState.Error;
                else if (goods == totalCount)
                    currentState.State = CollectorState.Good;
                else
                    currentState.State = CollectorState.Warning;
            }

            return currentState;
        }
        #endregion

        #region Properties        
        public string SqlServer { get; set; }
        public string Database { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int SqlCmndTimeOutSec { get; set; }
        public List<TableSizeEntry> Tables { get; set; }
        #endregion

        public void RefreshRowCounts()
        {
            List<TableSizeInfo> tableSizes = GetAllTableRowCounts();
            foreach (TableSizeEntry tableEntry in Tables)
            {
                TableSizeInfo tableSizeInfo = (from ti in tableSizes
                                               where ti.Name == tableEntry.TableName
                                               select ti).FirstOrDefault();
                if (tableSizeInfo == null)
                {
                    tableEntry.RowCount = -1;
                    tableEntry.ErrorStr = "Table not found!";
                }
                else
                {
                    tableEntry.RowCount = tableSizeInfo.Rows;
                    tableEntry.ErrorStr = "";
                }
            }
        }
        private List<TableSizeInfo> GetAllTableRowCounts()
        {
            return GetAllTableRowCounts(SqlServer, Database, IntegratedSecurity, UserName, Password, SqlCmndTimeOutSec);
        }
        public static List<TableSizeInfo> GetAllTableRowCounts(string sqlServer, string database, bool integratedSecurity, string userName, string password, int sqlCmndTimeOutSec)
        {
            List<TableSizeInfo> list = new List<TableSizeInfo>();
            string sql = "select t.name, i.[rows] from sys.sysindexes i inner join sys.tables t on t.object_id = i.id where i.indid in (0, 1, 255) order by t.name";
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = sqlServer;
            scsb.InitialCatalog = database;
            scsb.IntegratedSecurity = integratedSecurity;
            if (!integratedSecurity)
            {
                scsb.UserID = userName;
                scsb.Password = password;
            }

            using (SqlConnection conn = new SqlConnection(scsb.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmnd = new SqlCommand(sql, conn))
                {
                    cmnd.CommandType = CommandType.Text;
                    cmnd.CommandTimeout = sqlCmndTimeOutSec;
                    using (SqlDataReader r = cmnd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            TableSizeInfo tableSizeInfo = new TableSizeInfo();
                            tableSizeInfo.Name = r[0].ToString();
                            tableSizeInfo.Rows = long.Parse(r[1].ToString());
                            list.Add(tableSizeInfo);
                        }
                    }
                }
            }
            return list;
        }
        public List<Tuple<TableSizeEntry, CollectorState>> GetStates()
        {
            List<Tuple<TableSizeEntry, CollectorState>> states = new List<Tuple<TableSizeEntry, CollectorState>>();
            foreach (TableSizeEntry tableEntry in Tables)
            {
                Tuple<TableSizeEntry, CollectorState> currentEntry; //= new Tuple<TableSizeEntry, CollectorState>(tableEntry, CollectorState.NotAvailable);
                if (tableEntry.RowCount > tableEntry.ErrorValue)
                    currentEntry = new Tuple<TableSizeEntry, CollectorState>(tableEntry, CollectorState.Error);
                else if (tableEntry.RowCount > tableEntry.WarningValue)
                    currentEntry = new Tuple<TableSizeEntry, CollectorState>(tableEntry, CollectorState.Warning);
                else
                    currentEntry = new Tuple<TableSizeEntry, CollectorState>(tableEntry, CollectorState.Good);
                states.Add(currentEntry);
            }
            return states;
        }

        //public DataTable GetDetailDataTable()
        //{
        //    DataTable dt = new DataTable(Description);
        //    dt.Columns.Add(new System.Data.DataColumn("Table Name", typeof(string)));
        //    dt.Columns.Add(new System.Data.DataColumn("Row count", typeof(int)));
        //    foreach (TableSizeEntry tab in Tables)
        //    {
        //        dt.Rows.Add(tab.TableName, tab.RowCount);
        //    }

        //    return dt;
        //}
    }

    public class TableSizeEntry
    {
        public string TableName { get; set; }
        public long WarningValue { get; set; }
        public long ErrorValue { get; set; }
        public long RowCount { get; set; }
        public string ErrorStr { get; set; }
    }
    public class TableSizeInfo
    {
        public string Name { get; set; }
        public long Rows { get; set; }
    }
}
