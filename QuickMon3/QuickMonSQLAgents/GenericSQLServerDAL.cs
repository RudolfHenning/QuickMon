using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace HenIT.Data.SqlClient
{
    public delegate void RaiseDBAccessDelegate();
    public delegate void RaiseDBInsertsDelegate(int inserts);
    public delegate void DBAccessDurationDelegate(long milliseconds);
    public delegate void RaiseMessageDelegate(string message);

    public class GenericSQLServerDAL
    {
        #region Events
        public event RaiseDBAccessDelegate RaiseDBAccess;
        protected void DoRaiseDBAccessEvent()
        {
            if (RaiseDBAccess != null)
            {
                RaiseDBAccess();
            }
        }
        public event RaiseDBAccessDelegate RaiseDBAccessErrors;
        protected void DoRaiseDBAccessErrorsEvent()
        {
            if (RaiseDBAccessErrors != null)
            {
                RaiseDBAccessErrors();
            }
        }
        public event RaiseDBInsertsDelegate RaiseDBAccessInserts;
        protected void DoRaiseDBAccessInsertsEvent(int inserts)
        {
            if (RaiseDBAccessInserts != null)
            {
                RaiseDBAccessInserts(inserts);
            }
        }
        public event RaiseDBAccessDelegate RaiseDBAccessInsertDuplicates;
        protected void DoRaiseDBAccessInsertDuplicates()
        {
            if (RaiseDBAccessInsertDuplicates != null)
            {
                RaiseDBAccessInsertDuplicates();
            }
        }
        public event DBAccessDurationDelegate DBAccessDurationInfoMessage;
        protected void RaiseDBAccessDurationInfoMessage(long milliseconds)
        {
            if (DBAccessDurationInfoMessage != null)
            {
                DBAccessDurationInfoMessage(milliseconds);
            }
        }
        public event RaiseMessageDelegate RaiseInfoMessage;
        protected void DoRaiseInfoMessage(string message)
        {
            if (RaiseInfoMessage != null)
            {
                RaiseInfoMessage(message);
            }
        }
        public event RaiseMessageDelegate RaiseErrorMessage;
        protected void DoRaiseErrorMessage(string message)
        {
            if (RaiseErrorMessage != null)
            {
                RaiseErrorMessage(message);
            }
        }
        public event RaiseMessageDelegate RaiseSyncInfoMessage;
        protected void DoRaiseSyncInfoMessage(string message)
        {
            if (RaiseSyncInfoMessage != null)
            {
                RaiseSyncInfoMessage(message);
            }
        }
        #endregion

        #region Connection details
        #region Connection properties
        private string server = string.Empty;
        public string Server
        {
            get { return server; }
            set { server = value; }
        }
        private string database = string.Empty;
        public string Database
        {
            get { return database; }
            set { database = value; }
        }
        private string userName = string.Empty;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password = string.Empty;
        public string Password
        {
            protected get { return password; }
            set { password = value; }
        }
        private int commandTimeout = 120;
        public int CommandTimeout
        {
            get { return commandTimeout; }
            set { commandTimeout = value; }
        }
        #endregion

        protected string lastError = "";
        public string LastError
        {
            get { return lastError; }
        }
        protected string connectionString;
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        public void SetConnection()
        {
            if (server.Length > 0 && database.Length > 0)
            {
                SqlConnectionStringBuilder sqlbuilder = new SqlConnectionStringBuilder();
                sqlbuilder.DataSource = server;
                sqlbuilder.InitialCatalog = database;
                if (userName.Length > 0)
                {
                    sqlbuilder.UserID = userName;
                    sqlbuilder.Password = password;
                    sqlbuilder.IntegratedSecurity = false;
                }
                else
                    sqlbuilder.IntegratedSecurity = true;
                connectionString = sqlbuilder.ConnectionString;
            }
            else
            {
                throw new Exception("Connection settings not set properly!");
            }
        }

        public void SetConnection(string sqlServer, string database)
        {
            server = sqlServer;
            this.database = database;
            SetConnection();
        }
        public void SetConnection(string sqlServer, string database, string userName, string password)
        {
            server = sqlServer;
            this.database = database;
            this.userName = userName;
            this.password = password;
            SetConnection();
        }
        #endregion

        #region GetSingleValue
        public object GetSingleValue(string sql)
        {
            return GetSingleValue(sql, CommandType.StoredProcedure, new SqlParameter[] { });
        }
        public object GetSingleValue(string sql, CommandType commandType)
        {
            return GetSingleValue(sql, commandType, new SqlParameter[] { });
        }
        public object GetSingleValue(string sql, CommandType commandType, SqlParameter[] parms)
        {
            object returnValue = null;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DoRaiseDBAccessEvent();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmnd = new SqlCommand(sql, conn))
                    {
                        cmnd.CommandTimeout = commandTimeout;
                        cmnd.CommandType = commandType;
                        if (parms != null)
                            cmnd.Parameters.AddRange(parms);
                        returnValue = cmnd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
                DoRaiseDBAccessErrorsEvent();
                throw;
            }
            sw.Stop();
            RaiseDBAccessDurationInfoMessage(sw.ElapsedMilliseconds);
            return returnValue;
        }
        #endregion

        #region GetDataSet
        public DataSet GetDataSet(string sql)
        {
            return GetDataSet(sql, CommandType.StoredProcedure, null);
        }
        public DataSet GetDataSet(string sql, CommandType commandType)
        {
            return GetDataSet(sql, commandType, null);
        }
        public DataSet GetDataSet(string sql, CommandType commandType, SqlParameter[] parms)
        {
            DataSet returnDS = new DataSet();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DoRaiseDBAccessEvent();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmnd = new SqlCommand(sql, conn))
                    {
                        cmnd.CommandTimeout = commandTimeout;
                        cmnd.CommandType = commandType;
                        if (parms != null)
                            cmnd.Parameters.AddRange(parms);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmnd))
                        {
                            da.Fill(returnDS);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
                DoRaiseDBAccessErrorsEvent();
                throw;
            }
            sw.Stop();
            RaiseDBAccessDurationInfoMessage(sw.ElapsedMilliseconds);
            return returnDS;
        }
        #endregion

        #region Execute
        public void ExecuteSP(string spName)
        {
            ExecuteSP(spName, null, commandTimeout);
        }
        public void ExecuteSP(string spName, SqlParameter[] parms)
        {
            ExecuteSP(spName, parms, commandTimeout);
        }
        public void ExecuteSP(string sql, SqlParameter[] parms, int commandTimeout)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DoRaiseDBAccessEvent();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmnd = new SqlCommand(sql, conn))
                    {
                        cmnd.CommandType = CommandType.StoredProcedure;
                        cmnd.CommandTimeout = commandTimeout;
                        if (parms != null)
                            cmnd.Parameters.AddRange(parms);
                        cmnd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
                DoRaiseDBAccessErrorsEvent();
                throw;
            }
            sw.Stop();
            RaiseDBAccessDurationInfoMessage(sw.ElapsedMilliseconds);
        }

        public void ExecuteSQL(string sql)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DoRaiseDBAccessEvent();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmnd = new SqlCommand(sql, conn))
                    {
                        cmnd.CommandType = CommandType.Text;
                        cmnd.CommandTimeout = commandTimeout;
                        cmnd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
                DoRaiseDBAccessErrorsEvent();
                throw;
            }
            sw.Stop();
            RaiseDBAccessDurationInfoMessage(sw.ElapsedMilliseconds);
        }
        #endregion
    }
}
