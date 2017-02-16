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
    [Description("Sql Query Collector"), Category("Database")]
    public class SqlQueryCollector : CollectorAgentBase
    {
        public SqlQueryCollector()
        {
            AgentConfig = new SqlQueryCollectorConfig();
        }

        //public override MonitorState RefreshState()
        //{
        //    MonitorState returnState = new MonitorState();
        //    string lastAction = "";
        //    int errors = 0;
        //    int warnings = 0;
        //    int success = 0;

        //    try
        //    {
        //        SqlQueryCollectorConfig currentConfig = (SqlQueryCollectorConfig)AgentConfig;

        //        returnState.RawDetails = string.Format("Running {0} queries", currentConfig.Entries.Count);
        //        returnState.HtmlDetails = string.Format("<b>Running {0} queries</b>", currentConfig.Entries.Count);
        //        returnState.CurrentValue = 0;
        //        foreach (SqlQueryCollectorEntry entry in currentConfig.Entries)
        //        {
        //            object value = entry.GetStateQueryValue();
        //            CollectorState currentState = CollectorAgentReturnValueCompareEngine.GetState(entry.ValueReturnCheckSequence, entry.SuccessMatchType, entry.SuccessValueOrMacro,
        //                entry.WarningMatchType, entry.WarningValueOrMacro, entry.ErrorMatchType, entry.ErrorValueOrMacro, value);
        //            if (value.IsNumber())
        //            {
        //                returnState.CurrentValue = Double.Parse(returnState.CurrentValue.ToString()) + Double.Parse(value.ToString());
        //            }
        //            if (currentState == CollectorState.Error)
        //            {
        //                errors++;
        //                returnState.ChildStates.Add(
        //                    new MonitorState()
        //                    {
        //                        State = CollectorState.Error,
        //                        ForAgent = entry.Name,
        //                        CurrentValue = value//,
        //                        //RawDetails = string.Format("(Trigger '{0}')", entry.TriggerSummary)
        //                    });
        //            }
        //            else if (currentState == CollectorState.Warning)
        //            {
        //                warnings++;
        //                returnState.ChildStates.Add(
        //                    new MonitorState()
        //                    {
        //                        State = CollectorState.Warning,
        //                        ForAgent = entry.Name,
        //                        CurrentValue = value//,
        //                        //RawDetails = string.Format("(Trigger '{0}')", entry.TriggerSummary)
        //                    });
        //            }
        //            else
        //            {
        //                success++;
        //                returnState.ChildStates.Add(
        //                    new MonitorState()
        //                    {
        //                        State = CollectorState.Good,
        //                        ForAgent = entry.Name,
        //                        CurrentValue = value
        //                    });
        //            }                    
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

        public override List<System.Data.DataTable> GetDetailDataTables()
        {
            List<System.Data.DataTable> tables = new List<System.Data.DataTable>();
            SqlQueryCollectorConfig currentConfig = (SqlQueryCollectorConfig)AgentConfig;
            int tableNo = 1;
            foreach (SqlQueryCollectorEntry entry in currentConfig.Entries)
            {
                System.Data.DataTable dt = entry.GetDetailQueryDataTable();
                if (entry.Name.Length > 0)
                    dt.TableName = entry.Name;
                else
                    dt.TableName = "Table " + tableNo.ToString();
                while ( (from t in tables
                         where t.TableName == dt.TableName
                         select t).Count() > 0)
                {
                    dt.TableName = "Table " + tableNo.ToString();
                    tableNo++;
                }
                tables.Add(dt);
                tableNo++;
            }            
            return tables;
        }
    }
    public class SqlQueryCollectorConfig : ICollectorConfig
    {
        public SqlQueryCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            Entries.Clear();
            XmlElement root = config.DocumentElement;
            foreach (XmlElement queryNode in root.SelectNodes("queries/query"))
            {
                SqlQueryCollectorEntry queryEntry = new SqlQueryCollectorEntry();
                queryEntry.Name = queryNode.ReadXmlElementAttr("name", "");
                queryEntry.DataSourceType = queryNode.ReadXmlElementAttr("dataSourceType", "SqlServer").ToLower() == "oledb" ? DataSourceType.OLEDB : DataSourceType.SqlServer;
                queryEntry.ConnectionString = queryNode.ReadXmlElementAttr("connStr", "");
                queryEntry.ProviderName = queryNode.ReadXmlElementAttr("provider", "");
                queryEntry.FileName = queryNode.ReadXmlElementAttr("fileName", "");
                queryEntry.Server = queryNode.ReadXmlElementAttr("server", "");
                queryEntry.Database = queryNode.ReadXmlElementAttr("database", "");
                queryEntry.IntegratedSecurity = bool.Parse(queryNode.ReadXmlElementAttr("integratedSec", "True"));
                queryEntry.UserName = queryNode.ReadXmlElementAttr("userName", "");
                queryEntry.Password = queryNode.ReadXmlElementAttr("password", "");
                queryEntry.CmndTimeOut = int.Parse(queryNode.ReadXmlElementAttr("cmndTimeOut", "60"));
                queryEntry.UsePersistentConnection = bool.Parse(queryNode.ReadXmlElementAttr("usePersistentConnection", "False"));
                queryEntry.ApplicationName = queryNode.ReadXmlElementAttr("applicationName", "QuickMon");

                XmlNode alertTriggersNode = queryNode.SelectSingleNode("alertTriggers");
                queryEntry.ValueReturnType = DataBaseQueryValueReturnTypeConverter.FromString(alertTriggersNode.ReadXmlElementAttr("valueReturnType", "RawValue"));
                queryEntry.ValueReturnCheckSequence = CollectorAgentReturnValueCompareEngine.CheckSequenceTypeFromString(alertTriggersNode.ReadXmlElementAttr("checkSequence", "EWG"));

                XmlNode successNode = alertTriggersNode.SelectSingleNode("success");
                queryEntry.SuccessMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(successNode.ReadXmlElementAttr("matchType", "Match"));
                queryEntry.SuccessValueOrMacro = successNode.ReadXmlElementAttr("value", "[any]");

                XmlNode warningNode = alertTriggersNode.SelectSingleNode("warning");
                queryEntry.WarningMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(warningNode.ReadXmlElementAttr("matchType", "Match"));
                queryEntry.WarningValueOrMacro = warningNode.ReadXmlElementAttr("value", "0");

                XmlNode errorNode = alertTriggersNode.SelectSingleNode("error");
                queryEntry.ErrorMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(errorNode.ReadXmlElementAttr("matchType", "Match"));
                queryEntry.ErrorValueOrMacro = errorNode.ReadXmlElementAttr("value", "[null]");

                XmlNode stateQueryNode = queryNode.SelectSingleNode("stateQuery");
                queryEntry.UseSPForStateQuery = stateQueryNode.ReadXmlElementAttr("useSP", false);
                queryEntry.StateQuery = stateQueryNode.InnerText;

                XmlNode detailQueryNode = queryNode.SelectSingleNode("detailQuery");
                queryEntry.UseSPForDetailQuery = detailQueryNode.ReadXmlElementAttr("useSP", false);
                queryEntry.DetailQuery = detailQueryNode.InnerText;

                Entries.Add(queryEntry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode queriesNode = root.SelectSingleNode("queries");
            queriesNode.InnerXml = "";
            foreach (SqlQueryCollectorEntry queryEntry in Entries)
            {
                XmlElement queryNode = config.CreateElement("query");
                queryNode.SetAttributeValue("name", queryEntry.Name);
                queryNode.SetAttributeValue("dataSourceType", queryEntry.DataSourceType.ToString());
                queryNode.SetAttributeValue("connStr", queryEntry.ConnectionString);
                queryNode.SetAttributeValue("provider", queryEntry.ProviderName);
                queryNode.SetAttributeValue("fileName", queryEntry.FileName);
                queryNode.SetAttributeValue("server", queryEntry.Server);
                queryNode.SetAttributeValue("database", queryEntry.Database);
                queryNode.SetAttributeValue("integratedSec", queryEntry.IntegratedSecurity);
                queryNode.SetAttributeValue("userName", queryEntry.UserName);
                queryNode.SetAttributeValue("password", queryEntry.Password);
                queryNode.SetAttributeValue("cmndTimeOut", queryEntry.CmndTimeOut);
                queryNode.SetAttributeValue("usePersistentConnection", queryEntry.UsePersistentConnection);
                queryNode.SetAttributeValue("applicationName", queryEntry.ApplicationName);

                XmlElement alertTriggersNode = config.CreateElement("alertTriggers");
                alertTriggersNode.SetAttributeValue("valueReturnType", queryEntry.ValueReturnType.ToString());
                alertTriggersNode.SetAttributeValue("checkSequence", queryEntry.ValueReturnCheckSequence.ToString());
                XmlElement successNode = config.CreateElement("success");
                successNode.SetAttributeValue("matchType", queryEntry.SuccessMatchType.ToString());
                successNode.SetAttributeValue("value", queryEntry.SuccessValueOrMacro);
                alertTriggersNode.AppendChild(successNode);
                XmlElement warningNode = config.CreateElement("warning");
                warningNode.SetAttributeValue("matchType", queryEntry.WarningMatchType.ToString());
                warningNode.SetAttributeValue("value", queryEntry.WarningValueOrMacro);
                alertTriggersNode.AppendChild(warningNode);
                XmlElement errorNode = config.CreateElement("error");
                errorNode.SetAttributeValue("matchType", queryEntry.ErrorMatchType.ToString());
                errorNode.SetAttributeValue("value", queryEntry.ErrorValueOrMacro);
                alertTriggersNode.AppendChild(errorNode);
                queryNode.AppendChild(alertTriggersNode);

                XmlElement stateQueryNode = queryNode.AppendElementWithText("stateQuery", queryEntry.StateQuery);
                stateQueryNode.SetAttributeValue("useSP", queryEntry.UseSPForStateQuery);

                XmlElement detailQueryNode = queryNode.AppendElementWithText("detailQuery", queryEntry.DetailQuery);
                detailQueryNode.SetAttributeValue("useSP", queryEntry.UseSPForDetailQuery);

                queriesNode.AppendChild(queryNode);
            }
            return config.OuterXml;

        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config><queries>" +
            "<query name=\"\" dataSourceType=\"SqlServer\" connStr=\"\" provider=\"\" " +
                "server=\"\" database=\"\" integratedSec=\"True\" userName=\"\" password=\"\" " +
                "cmndTimeOut=\"60\" usePersistentConnection=\"False\" applicationName=\"QuickMon\">" +
                "<alertTriggers valueReturnType=\"RawValue\" checkSequence=\"EWG\">" +
                    "<success matchType=\"Match\" value=\"[any]\" />" +
                    "<warning matchType=\"Match\" value=\"0\" />" +
                    "<error matchType=\"Match\" value=\"[null]\" />" +
                "</alertTriggers>" +
                "<stateQuery useSP=\"False\" />" +
                "<detailQuery useSP=\"False\" />" +
            "</query>" +
          "</queries></config>";
        }
        public string ConfigSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("{0} entry(s): ", Entries.Count));
                if (Entries.Count == 0)
                    sb.Append("None");
                else
                {
                    foreach (ICollectorConfigEntry entry in Entries)
                    {
                        sb.Append(entry.Description + ", ");
                    }
                }
                return sb.ToString().TrimEnd(' ', ',');
            }
        }
        #endregion
    }
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
                return Name;// +" (" + connectionString + ")";
            }
        }
        public string TriggerSummary
        {
            get
            {
                string connectionString = ConnectionString;
                if (connectionString == "" && DataSourceType == Collectors.DataSourceType.SqlServer)
                    connectionString = string.Format("DB={0}\\{1}; ", Server, Database);

                return string.Format("{0} Success: {1} ({2}), Warn: {3} ({4}), Err: {5} ({6}), Check seq: {7}",
                    connectionString,
                    SuccessValueOrMacro, SuccessMatchType,
                    WarningValueOrMacro, WarningMatchType,
                    ErrorValueOrMacro, ErrorMatchType, ValueReturnCheckSequence) +
                    (ValueReturnType == DataBaseQueryValueReturnType.RowCount ? ", RowCnt" : "") +
                    (ValueReturnType == DataBaseQueryValueReturnType.QueryTime ? ", QryTime" : "");
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        public MonitorState GetCurrentState()
        {
            object value = GetStateQueryValue();
            string unitName = ValueReturnType == DataBaseQueryValueReturnType.RowCount ? "row(s)" : ValueReturnType == DataBaseQueryValueReturnType.QueryTime ? "ms" : "";
            MonitorState currentState = new MonitorState()
            {
                State = CollectorAgentReturnValueCompareEngine.GetState(ValueReturnCheckSequence, SuccessMatchType, SuccessValueOrMacro,
                 WarningMatchType, WarningValueOrMacro, ErrorMatchType, ErrorValueOrMacro, value),
                ForAgent = Name,
                CurrentValue = value,
                CurrentValueUnit = unitName
            };

            return currentState;
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        public object CurrentAgentValue { get; set; }
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
            catch (Exception ex)
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
                return new SqlCommand(queryText, (SqlConnection)conn) { CommandType = useSP ? CommandType.StoredProcedure : CommandType.Text, CommandTimeout = CmndTimeOut };
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
