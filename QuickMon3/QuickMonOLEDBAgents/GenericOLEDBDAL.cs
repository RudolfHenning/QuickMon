using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;

namespace HenIT.Data.OLEDB
{
    public delegate void RaiseOLEDBAccessDelegate();
    public delegate void RaiseOLEDBInsertsDelegate(int inserts);
    public delegate void OLEDBAccessDurationDelegate(long milliseconds);
    public delegate void RaiseOLEDBMessageDelegate(string message);

    public class GenericOLEDBDAL
    {
        #region Events
        public event RaiseOLEDBAccessDelegate RaiseDBAccess;
        protected void DoRaiseDBAccessEvent()
        {
            if (RaiseDBAccess != null)
            {
                RaiseDBAccess();
            }
        }
        public event RaiseOLEDBAccessDelegate RaiseDBAccessErrors;
        protected void DoRaiseDBAccessErrorsEvent()
        {
            if (RaiseDBAccessErrors != null)
            {
                RaiseDBAccessErrors();
            }
        }
        public event RaiseOLEDBInsertsDelegate RaiseDBAccessInserts;
        protected void DoRaiseDBAccessInsertsEvent(int inserts)
        {
            if (RaiseDBAccessInserts != null)
            {
                RaiseDBAccessInserts(inserts);
            }
        }
        public event RaiseOLEDBAccessDelegate RaiseDBAccessInsertDuplicates;
        protected void DoRaiseDBAccessInsertDuplicates()
        {
            if (RaiseDBAccessInsertDuplicates != null)
            {
                RaiseDBAccessInsertDuplicates();
            }
        }
        public event OLEDBAccessDurationDelegate DBAccessDurationInfoMessage;
        protected void RaiseDBAccessDurationInfoMessage(long milliseconds)
        {
            if (DBAccessDurationInfoMessage != null)
            {
                DBAccessDurationInfoMessage(milliseconds);
            }
        }
        public event RaiseOLEDBMessageDelegate RaiseInfoMessage;
        protected void DoRaiseInfoMessage(string message)
        {
            if (RaiseInfoMessage != null)
            {
                RaiseInfoMessage(message);
            }
        }
        public event RaiseOLEDBMessageDelegate RaiseErrorMessage;
        protected void DoRaiseErrorMessage(string message)
        {
            if (RaiseErrorMessage != null)
            {
                RaiseErrorMessage(message);
            }
        }
        public event RaiseOLEDBMessageDelegate RaiseSyncInfoMessage;
        protected void DoRaiseSyncInfoMessage(string message)
        {
            if (RaiseSyncInfoMessage != null)
            {
                RaiseSyncInfoMessage(message);
            }
        }
        #endregion

        #region Connection properties
        private string dataSource = string.Empty;
        public string DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }
        private string provider = "Microsoft.Jet.OLEDB.4.0";
        public string Provider
        {
            get { return provider; }
            set { provider = value; }
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
        #endregion
        private int commandTimeout = 120;
        public int CommandTimeout
        {
            get { return commandTimeout; }
            set { commandTimeout = value; }
        }
        protected string lastError = "";
        public string LastError
        {
            get { return lastError; }
        }
        protected long lastDurationMS = 0;
        public long LastDurationMS
        {
            get { return lastDurationMS; }
        }
        protected string connectionString;
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public string GetConnectionString()
        {
            return GetConnectionString(dataSource, provider, userName, password);            
        }
        public static string GetConnectionString(string dataSource, string provider, string userName = "", string password = "")
        {
            string connStr = "";
            if (dataSource.Length > 0 && provider.Length > 0)
            {
                OleDbConnectionStringBuilder connbuilder = new OleDbConnectionStringBuilder();
                connbuilder.DataSource = dataSource;
                connbuilder.Provider = provider;
                if (userName.Length > 0)
                {
                    connbuilder["User Id"] = userName;
                    connbuilder["Password"] = password;
                }
                connStr = connbuilder.ConnectionString;
            }
            else
            {
                throw new Exception("Connection settings not set properly!");
            }
            return connStr;
        }

        #region GetSingleValue
        public object GetSingleValue(string sql)
        {
            return GetSingleValue(sql, CommandType.Text, new OleDbParameter[] { });
        }
        public object GetSingleValue(string sql, CommandType commandType)
        {
            return GetSingleValue(sql, commandType, new OleDbParameter[] { });
        }
        public object GetSingleValue(string sql, CommandType commandType, OleDbParameter[] parms)
        {
            object returnValue = null;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DoRaiseDBAccessEvent();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    using (OleDbCommand cmnd = new OleDbCommand(sql, conn))
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
            lastDurationMS = sw.ElapsedMilliseconds;
            RaiseDBAccessDurationInfoMessage(sw.ElapsedMilliseconds);
            return returnValue;
        }
        #endregion

        #region GetDataSet
        public DataSet GetDataSet(string sql)
        {
            return GetDataSet(sql, CommandType.Text, null);
        }
        public DataSet GetDataSet(string sql, CommandType commandType)
        {
            return GetDataSet(sql, commandType, null);
        }
        public DataSet GetDataSet(string sql, CommandType commandType, OleDbParameter[] parms)
        {
            DataSet returnDS = new DataSet();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DoRaiseDBAccessEvent();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    using (OleDbCommand cmnd = new OleDbCommand(sql, conn))
                    {
                        cmnd.CommandTimeout = commandTimeout;
                        cmnd.CommandType = commandType;
                        if (parms != null)
                            cmnd.Parameters.AddRange(parms);
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmnd))
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
            lastDurationMS = sw.ElapsedMilliseconds;
            RaiseDBAccessDurationInfoMessage(sw.ElapsedMilliseconds);
            return returnDS;
        }
        #endregion

        #region Execute
        public void ExecuteSP(string spName)
        {
            ExecuteSP(spName, null, commandTimeout);
        }
        public void ExecuteSP(string spName, OleDbParameter[] parms)
        {
            ExecuteSP(spName, parms, commandTimeout);
        }
        public void ExecuteSP(string sql, OleDbParameter[] parms, int commandTimeout)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DoRaiseDBAccessEvent();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    using (OleDbCommand cmnd = new OleDbCommand(sql, conn))
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
            lastDurationMS = sw.ElapsedMilliseconds;
            RaiseDBAccessDurationInfoMessage(sw.ElapsedMilliseconds);
        }

        public void ExecuteSQL(string sql)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DoRaiseDBAccessEvent();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    using (OleDbCommand cmnd = new OleDbCommand(sql, conn))
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
            lastDurationMS = sw.ElapsedMilliseconds;
            RaiseDBAccessDurationInfoMessage(sw.ElapsedMilliseconds);
        }
        #endregion
    }
}
