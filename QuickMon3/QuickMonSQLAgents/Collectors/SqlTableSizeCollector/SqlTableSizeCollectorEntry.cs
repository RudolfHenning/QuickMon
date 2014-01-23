using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
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

        public List<TableSizeInfo> GetAllTableRowCounts()
        {
            return GetAllTableRowCounts(SqlServer, Database, IntegratedSecurity, UserName, Password, SqlCmndTimeOutSec);            
        }
     
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

        public override string ToString()
        {
            return "[" + SqlServer + "]." + Database;
        }
    }

    public class TableSizeEntry
    {
        public string TableName { get; set; }
        public long WarningValue { get; set; }
        public long ErrorValue { get; set; }
        public long RowCount { get; set; }
        public string ErrorStr { get; set; }
    }
}
