using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class SqlDatabaseSizeEntry : ICollectorConfigEntry
    {
        public SqlDatabaseSizeEntry()
        {
            IntegratedSecurity = true;
            SqlCmndTimeOutSec = 30;
            WarningSizeMB = 1024;
            ErrorSizeMB = 4096;
        }

        #region Properties
        public string SqlServer { get; set; }
        public string Database { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int SqlCmndTimeOutSec { get; set; }
        public long WarningSizeMB { get; set; }
        public long ErrorSizeMB { get; set; } 
        #endregion

        #region ICollectorConfigEntry Members
        public string Description
        {
            get { return string.Format("[{0}].{1}", SqlServer, Database); }
        }
        public string TriggerSummary
        {
            get
            {
                return string.Format("Warn: {0}MB, Err: {1}MB", WarningSizeMB, ErrorSizeMB);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        #endregion

        public override string ToString()
        {
            return string.Format("[{0}].{1}", SqlServer, Database);
        }

        private string GetConnectionString()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = SqlServer;
            scsb.InitialCatalog = "master";
            scsb.IntegratedSecurity = IntegratedSecurity;
            if (!IntegratedSecurity)
            {
                scsb.UserID = UserName;
                scsb.Password = Password;
            }
            return scsb.ConnectionString;
        }
        public long GetDBSize()
        {
            long sizeMB = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                string sql = Properties.Resources.SelectDatabaseSizesScript.Replace("<Database>", Database);
                using (SqlCommand cmnd = new SqlCommand(sql, conn))
                {
                    cmnd.CommandTimeout = SqlCmndTimeOutSec;
                    object tmp = cmnd.ExecuteScalar();
                    if (tmp != null)
                        sizeMB = long.Parse(tmp.ToString());
                    else
                        throw new Exception("No or invalid database specified!");
                }
            }
            return sizeMB;
        }

        internal CollectorState GetState(long sizeMB)
        {
            CollectorState currentState = CollectorState.Good;
            if (sizeMB < WarningSizeMB)
                currentState = CollectorState.Good;
            else if (sizeMB < ErrorSizeMB)
                currentState = CollectorState.Warning;
            else
                currentState = CollectorState.Error;
            return currentState;
        }
    }
}
