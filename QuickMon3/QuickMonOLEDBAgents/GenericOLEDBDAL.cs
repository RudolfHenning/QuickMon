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
            get { return password; }
            set { password = value; }
        }
        private string initialCatalogue = string.Empty;
        public string InitialCatalogue
        {
            get { return initialCatalogue; }
            set { initialCatalogue = value; }
        }
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
        private bool persistSecurityInfo = false;
        public bool PersistSecurityInfo
        {
            get { return persistSecurityInfo; }
            set { persistSecurityInfo = value; }
        }
        private byte trustedConnection = 2;
        public byte TrustedConnection
        {
            get { return trustedConnection; }
            set { trustedConnection = value; }
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
            set {
                connectionString = value; 
                OleDbConnectionStringBuilder connbuilder = new OleDbConnectionStringBuilder();
                connbuilder.ConnectionString = connectionString;
                provider = connbuilder.Provider;
                try
                {
                    if (provider.Length == 0)
                        provider = connbuilder["Provider"].ToString();
                }
                catch { }
                try
                {
                    dataSource = connbuilder.DataSource;
                    if (dataSource.Length == 0)
                        dataSource = connbuilder["Data Source"].ToString();
                }
                catch { }
                try
                {
                    if (connbuilder["User Id"] != null)
                        userName = connbuilder["User Id"].ToString();
                }
                catch { }
                try
                {
                    if (connbuilder["Password"] != null)
                        password = connbuilder["Password"].ToString();
                }
                catch { }
                try
                {
                    if (connbuilder["Initial Catalog"] != null)
                        initialCatalogue = connbuilder["Initial Catalog"].ToString();
                }
                catch { }
                try
                {
                    if (connbuilder["Server"] != null)
                        server = connbuilder["Server"].ToString();
                }
                catch { }
                try
                {
                    if (connbuilder["Database"] != null)
                        database = connbuilder["Database"].ToString();
                }
                catch { }
                persistSecurityInfo = connbuilder.PersistSecurityInfo;
                try
                {
                    if (connbuilder["Trusted_Connection"] != null)
                        trustedConnection = (connbuilder["Trusted_Connection"].ToString().ToLower() == "true" || connbuilder["Trusted_Connection"].ToString().ToLower() == "yes") ? (byte)1 : (byte)0;
                    else
                        trustedConnection = 2;
                }
                catch { }
            }
        }

        public string GetConnectionString()
        {
            return GetConnectionString(dataSource, provider, userName, password, initialCatalogue, server, database, persistSecurityInfo, trustedConnection);
        }
        public static string GetConnectionString(string dataSource, string provider, string userName = "", string password = "",
            string initialCatalogue = "", string server = "", string database = "", bool persistSecurityInfo = false, byte trustedConnection = 2)
        {
            string connStr = "";
            if (provider.Length > 0)
            {
                OleDbConnectionStringBuilder connbuilder = new OleDbConnectionStringBuilder();
                if (dataSource.Length > 0)
                    connbuilder.DataSource = dataSource;
                connbuilder.Provider = provider;
                if (userName.Length > 0 && (!(userName.ToLower() == "admin" && password.Length == 0)))
                {
                    connbuilder["User Id"] = userName;
                    if (password.Length > 0)
                        connbuilder["Password"] = password;
                }
                if (initialCatalogue.Length > 0)
                    connbuilder["Initial Catalog"] = initialCatalogue;
                if (server.Length > 0)
                    connbuilder["Server"] = server;
                if (database.Length > 0)
                    connbuilder["Database"] = database;
                if (persistSecurityInfo)
                    connbuilder.PersistSecurityInfo = persistSecurityInfo;
                if (trustedConnection != 2)
                {
                    connbuilder["Trusted_Connection"] = trustedConnection == 1;
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
