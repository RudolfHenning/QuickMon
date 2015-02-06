using System;
using System.Collections.Generic;
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
        /// Server/Instance name. Only used for DataSourceType = SqlServer
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Database name. Only used for DataSourceType = SqlServer
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
