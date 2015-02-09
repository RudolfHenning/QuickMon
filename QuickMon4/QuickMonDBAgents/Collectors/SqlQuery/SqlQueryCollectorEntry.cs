using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class SqlQueryCollectorEntry : ICollectorConfigEntry
    {
        public SqlQueryCollectorEntry()
        {
            IntegratedSecurity = true;
            CmndTimeOut = 60;
            DataSourceType = Collectors.DataSourceType.SqlServer;
            ValueReturnType = DataBaseQueryValueReturnType.RawValue;
            ValueReturnCheckSequence = CollectorAgentReturnValueCheckSequence.GWE;
        }

        #region ICollectorConfigEntry Members
        public string Description
        {
            get 
            {
                string connectionString = ConnectionString;
                if (connectionString == "" && DataSourceType == Collectors.DataSourceType.SqlServer)
                    connectionString = string.Format("Server={0};Database={1};{2}", Server, Database, IntegratedSecurity ? "Trusted_Connection=True;" : string.Format("User Id={0};Password={1};", UserName, Password));
                return Name + " (" + connectionString + ")";
            }
        }
        public string TriggerSummary
        {
            get {
                return string.Format("Success: {0} ({1}), Warn: {2} ({3}), Err: {4} ({5}), Check seq: {6}", 
                    SuccessValueOrMacro, SuccessMatchType ,
                    WarningValueOrMacro, WarningMatchType,
                    ErrorValueOrMacro, ErrorMatchType, ValueReturnCheckSequence) +                    
                    (ValueReturnType == DataBaseQueryValueReturnType.RowCount ? ", RowCnt" : "") +
                    (ValueReturnType == DataBaseQueryValueReturnType.QueryTime ? ", QryTime" : "");
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        #endregion

        #region Properties
        public string Name { get; set; }
        public DataSourceType DataSourceType { get; set; }
        /// <summary>
        /// Full connectionstring. If specified then Server/Database settings are ignored
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// For OLEDb. The provider name
        /// </summary>
        public string ProviderName { get; set; }
        /// <summary>
        /// For OLEDb. The file name (e.g. c:\somedir\db.mdb)
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Server/Instance name. Only used for DataSourceType = SqlServer
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Database name.
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// Use integrated security or not. Only used for DataSourceType = SqlServer
        /// </summary>
        public bool IntegratedSecurity { get; set; }
        /// <summary>
        /// User name. Only used for DataSourceType = SqlServer
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Password. Only used for DataSourceType = SqlServer
        /// </summary>
        public string Password { get; set; }
        public int CmndTimeOut { get; set; }
        public string ApplicationName { get; set; }
        public bool UsePersistentConnection { get; set; }
        private System.Data.Common.DbConnection PersistentConnection = null;

        #region State query
        public string StateQuery { get; set; }
        public bool UseSPForStateQuery { get; set; }
        #endregion

        #region Detail query
        public string DetailQuery { get; set; }
        public bool UseSPForDetailQuery { get; set; }
        #endregion

        #region Alert settings
        public DataBaseQueryValueReturnType ValueReturnType { get; set; }
        public CollectorAgentReturnValueCheckSequence ValueReturnCheckSequence { get; set; }
        public CollectorAgentReturnValueCompareMatchType SuccessMatchType { get; set; }
        public string SuccessValueOrMacro { get; set; }
        public CollectorAgentReturnValueCompareMatchType WarningMatchType { get; set; }
        public string WarningValueOrMacro { get; set; }
        public CollectorAgentReturnValueCompareMatchType ErrorMatchType { get; set; }
        public string ErrorValueOrMacro { get; set; }        
        #endregion

        #endregion

        #region GetStateQueryValue
        public object GetStateQueryValue()
        {
            object value = null;

            if (ValueReturnType == DataBaseQueryValueReturnType.RawValue)
                value = GetQuerySingleValue();
            else if (ValueReturnType == DataBaseQueryValueReturnType.RowCount)
                value = GetQueryRowCount();
            else // if (ValueReturnType == DataBaseQueryValueReturnType.QueryTime)
                value = GetQueryRunTime();

            return value;
        }
        private object GetQuerySingleValue()
        {
            object returnValue = null;
            try
            {
                using (System.Data.Common.DbCommand cmnd = GetCommand(StateQuery, UseSPForStateQuery))
                {
                    cmnd.CommandType = UseSPForStateQuery ? CommandType.StoredProcedure : CommandType.Text;
                    cmnd.CommandTimeout = CmndTimeOut;
                    using (System.Data.Common.DbDataReader r = cmnd.ExecuteReader())
                    {
                        if (r.Read())
                            returnValue = r[0];
                    }
                }
                CloseConnection();
            }
            catch
            {
                CloseConnection(true);
                throw;
            }
            return returnValue;
        }
        private object GetQueryRowCount()
        {
            int returnValue = 0;
            try
            {
                using (System.Data.Common.DbCommand cmnd = GetCommand(StateQuery, UseSPForStateQuery))
                {
                    cmnd.CommandType = UseSPForStateQuery ? CommandType.StoredProcedure : CommandType.Text;
                    cmnd.CommandTimeout = CmndTimeOut;
                    using (System.Data.Common.DbDataReader r = cmnd.ExecuteReader())
                    {
                        if (r.HasRows)
                            while (r.Read())
                            {
                                returnValue++;
                            }
                        else
                            returnValue = 0;
                    }
                }
                CloseConnection();
            }
            catch
            {
                CloseConnection(true);
                throw;
            }
            return returnValue;
        }
        private object GetQueryRunTime()
        {
            long returnValue = 0;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            try
            {
                
                using (System.Data.Common.DbCommand cmnd = GetCommand(StateQuery, UseSPForStateQuery))
                {
                    cmnd.CommandType = UseSPForStateQuery ? CommandType.StoredProcedure : CommandType.Text;
                    cmnd.CommandTimeout = CmndTimeOut;
                    cmnd.Prepare();
                    sw.Start();
                    using (System.Data.Common.DbDataReader r = cmnd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                returnValue = 0; //do something
                            }
                        }
                    } 
                    sw.Stop();
                    returnValue = sw.ElapsedMilliseconds;                 
                }
               
                CloseConnection();
            }
            catch
            {
                CloseConnection(true);
                throw;
            }
            return returnValue;
        } 
        #endregion

        #region GetDetailQueryDataTable
        public DataTable GetDetailQueryDataTable()
        {
            DataTable dt = new DataTable(Name);
            try
            {
                using (System.Data.Common.DbCommand cmnd = GetCommand(DetailQuery, UseSPForDetailQuery))
                {
                    cmnd.CommandType = UseSPForStateQuery ? CommandType.StoredProcedure : CommandType.Text;
                    cmnd.CommandTimeout = CmndTimeOut;
                    cmnd.Prepare();
                    if (DataSourceType == Collectors.DataSourceType.SqlServer)
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmnd))
                        {
                            DataSet returnValues = new DataSet();
                            da.Fill(returnValues);
                            dt = returnValues.Tables[0].Copy();
                        }
                    }
                    else
                    {
                        using (System.Data.Common.DbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter((System.Data.OleDb.OleDbCommand)cmnd))
                        {
                            DataSet returnValues = new DataSet();
                            da.Fill(returnValues);
                            dt = returnValues.Tables[0].Copy();
                        }
                    }
                }
                CloseConnection();
            }
            catch(Exception ex)
            {
                dt = new System.Data.DataTable("Exception");
                dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
                dt.Rows.Add(ex.ToString());
                CloseConnection(true);                
            }
            return dt;
        }
        #endregion

        #region Generic Db functions
        private System.Data.Common.DbConnection CreateNewConnection()
        {
            if (DataSourceType == Collectors.DataSourceType.SqlServer)
            {
                return new SqlConnection(GetConnectionString());
            }
            else
            {
                return new System.Data.OleDb.OleDbConnection(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            if (ConnectionString.Length > 0)
                return ConnectionString;
            else
            {
                if (DataSourceType == Collectors.DataSourceType.SqlServer)
                {
                    SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
                    sb.ApplicationName = ApplicationName;
                    sb.DataSource = Server;
                    sb.InitialCatalog = Database;
                    sb.IntegratedSecurity = IntegratedSecurity;
                    if (!IntegratedSecurity)
                    {
                        sb.UserID = UserName;
                        sb.Password = Password;
                    }
                    return sb.ConnectionString;
                }
                else
                {
                    System.Data.OleDb.OleDbConnectionStringBuilder sb = new System.Data.OleDb.OleDbConnectionStringBuilder();
                    sb.DataSource = Server;
                    sb.Provider = ProviderName;
                    sb.FileName = FileName;
                    return sb.ConnectionString;
                }
            }
        }
        private System.Data.Common.DbConnection GetConnection()
        {
            try
            {
                if (UsePersistentConnection)
                {
                    if (PersistentConnection == null || PersistentConnection.State == ConnectionState.Closed)
                    {
                        PersistentConnection = CreateNewConnection();
                        PersistentConnection.Open();
                    }
                }
                else
                {
                    if (PersistentConnection != null)
                    {
                        CloseConnection();
                    }
                    PersistentConnection = CreateNewConnection();
                    PersistentConnection.Open();
                }
            }
            catch
            {
                CloseConnection(true);
                throw;
            }
            return PersistentConnection;

            
        }
        private System.Data.Common.DbCommand GetCommand(string queryText, bool useSP)
        {
            System.Data.Common.DbConnection conn = GetConnection();
            
            if (DataSourceType == Collectors.DataSourceType.SqlServer)
            {
                return new SqlCommand(queryText,(SqlConnection) conn) { CommandType = useSP ? CommandType.StoredProcedure : CommandType.Text, CommandTimeout = CmndTimeOut };
            }
            else //if (DataSourceType == Collectors.DataSourceType.OLEDB)
            {
                return new System.Data.OleDb.OleDbCommand(queryText, (System.Data.OleDb.OleDbConnection)conn) { CommandType = useSP ? CommandType.StoredProcedure : CommandType.Text, CommandTimeout = CmndTimeOut };
            }
        }
        private void CloseConnection(bool closeNonPersistent = false)
        {
            try
            {
                if (closeNonPersistent && UsePersistentConnection && PersistentConnection != null)
                {
                    PersistentConnection.Close();
                    PersistentConnection = null;
                }
            }
            catch { }
        }
        #endregion
    }

    public enum DataBaseQueryValueReturnType
    {
        RawValue,
        RowCount,
        QueryTime
    }
    public static class DataBaseQueryValueReturnTypeConverter
    {
        public static DataBaseQueryValueReturnType FromString(string value)
        {
            if (value.ToLower() == "rowcount")
                return DataBaseQueryValueReturnType.RowCount;
            else if (value.ToLower() == "querytime")
                return DataBaseQueryValueReturnType.QueryTime;
            else
                return DataBaseQueryValueReturnType.RawValue;
        }
    }
    public enum DataSourceType
    {
        SqlServer,
        OLEDB
    }
}
