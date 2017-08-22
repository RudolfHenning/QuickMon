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

            //Version 4 config
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
                queryEntry.PrimaryUIValue = queryNode.ReadXmlElementAttr("primaryUIValue", false);
                

                XmlNode alertTriggersNode = queryNode.SelectSingleNode("alertTriggers");
                queryEntry.ValueReturnType = DataBaseQueryValueReturnTypeConverter.FromString(alertTriggersNode.ReadXmlElementAttr("valueReturnType", "RawValue"));
                queryEntry.ReturnCheckSequence = CollectorAgentReturnValueCompareEngine.CheckSequenceTypeFromString(alertTriggersNode.ReadXmlElementAttr("checkSequence", "EWG"));

                XmlNode successNode = alertTriggersNode.SelectSingleNode("success");
                queryEntry.GoodResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(successNode.ReadXmlElementAttr("matchType", "Match"));
                queryEntry.GoodValue = successNode.ReadXmlElementAttr("value", "[any]");

                XmlNode warningNode = alertTriggersNode.SelectSingleNode("warning");
                queryEntry.WarningResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(warningNode.ReadXmlElementAttr("matchType", "Match"));
                queryEntry.WarningValue = warningNode.ReadXmlElementAttr("value", "0");

                XmlNode errorNode = alertTriggersNode.SelectSingleNode("error");
                queryEntry.ErrorResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(errorNode.ReadXmlElementAttr("matchType", "Match"));
                queryEntry.ErrorValue = errorNode.ReadXmlElementAttr("value", "[null]");

                XmlNode stateQueryNode = queryNode.SelectSingleNode("stateQuery");
                queryEntry.UseSPForStateQuery = stateQueryNode.ReadXmlElementAttr("useSP", false);
                queryEntry.StateQuery = stateQueryNode.InnerText;

                XmlNode detailQueryNode = queryNode.SelectSingleNode("detailQuery");
                queryEntry.UseSPForDetailQuery = detailQueryNode.ReadXmlElementAttr("useSP", false);
                queryEntry.DetailQuery = detailQueryNode.InnerText;

                Entries.Add(queryEntry);
            }

            //version 5 config
            foreach (XmlElement carvceEntryNode in root.SelectNodes("carvcesEntries/carvceEntry"))
            {
                XmlNode dataSourceNode = carvceEntryNode.SelectSingleNode("dataSource");
                SqlQueryCollectorEntry queryEntry = new SqlQueryCollectorEntry();
                queryEntry.Name = dataSourceNode.ReadXmlElementAttr("name", "");
                queryEntry.DataSourceType = dataSourceNode.ReadXmlElementAttr("dataSourceType", "SqlServer").ToLower() == "oledb" ? DataSourceType.OLEDB : DataSourceType.SqlServer;
                queryEntry.ConnectionString = dataSourceNode.ReadXmlElementAttr("connStr", "");
                queryEntry.ProviderName = dataSourceNode.ReadXmlElementAttr("provider", "");
                queryEntry.FileName = dataSourceNode.ReadXmlElementAttr("fileName", "");
                queryEntry.Server = dataSourceNode.ReadXmlElementAttr("server", "");
                queryEntry.Database = dataSourceNode.ReadXmlElementAttr("database", "");
                queryEntry.IntegratedSecurity = bool.Parse(dataSourceNode.ReadXmlElementAttr("integratedSec", "True"));
                queryEntry.UserName = dataSourceNode.ReadXmlElementAttr("userName", "");
                queryEntry.Password = dataSourceNode.ReadXmlElementAttr("password", "");
                queryEntry.CmndTimeOut = int.Parse(dataSourceNode.ReadXmlElementAttr("cmndTimeOut", "60"));
                queryEntry.UsePersistentConnection = bool.Parse(dataSourceNode.ReadXmlElementAttr("usePersistentConnection", "False"));
                queryEntry.ApplicationName = dataSourceNode.ReadXmlElementAttr("applicationName", "QuickMon");
                queryEntry.PrimaryUIValue = dataSourceNode.ReadXmlElementAttr("primaryUIValue", false);
                queryEntry.OutputValueUnit = dataSourceNode.ReadXmlElementAttr("outputValueUnit", "");

                XmlNode stateQueryNode = dataSourceNode.SelectSingleNode("stateQuery");
                queryEntry.UseSPForStateQuery = stateQueryNode.ReadXmlElementAttr("useSP", false);
                queryEntry.StateQuery = stateQueryNode.InnerText;

                XmlNode detailQueryNode = dataSourceNode.SelectSingleNode("detailQuery");
                queryEntry.UseSPForDetailQuery = detailQueryNode.ReadXmlElementAttr("useSP", false);
                queryEntry.DetailQuery = detailQueryNode.InnerText;

                XmlNode testConditionsNode = carvceEntryNode.SelectSingleNode("testConditions");
                if (testConditionsNode != null)
                {
                    queryEntry.ReturnCheckSequence = CollectorAgentReturnValueCompareEngine.CheckSequenceTypeFromString(testConditionsNode.ReadXmlElementAttr("testSequence", "gwe"));
                    queryEntry.ValueReturnType = DataBaseQueryValueReturnTypeConverter.FromString(testConditionsNode.ReadXmlElementAttr("valueReturnType", "RawValue"));
                    XmlNode goodScriptNode = testConditionsNode.SelectSingleNode("success");
                    queryEntry.GoodResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(goodScriptNode.ReadXmlElementAttr("testType", "match"));
                    queryEntry.GoodValue = goodScriptNode.InnerText;

                    XmlNode warningScriptNode = testConditionsNode.SelectSingleNode("warning");
                    queryEntry.WarningResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(warningScriptNode.ReadXmlElementAttr("testType", "match"));
                    queryEntry.WarningValue = warningScriptNode.InnerText;

                    XmlNode errorScriptNode = testConditionsNode.SelectSingleNode("error");
                    queryEntry.ErrorResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(errorScriptNode.ReadXmlElementAttr("testType", "match"));
                    queryEntry.ErrorValue = errorScriptNode.InnerText;
                }
                else
                {
                    queryEntry.ReturnCheckSequence = CollectorAgentReturnValueCheckSequence.GWE;
                    queryEntry.ValueReturnType = DataBaseQueryValueReturnType.RawValue;
                }

                Entries.Add(queryEntry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode carvcesEntriesNode = root.SelectSingleNode("carvcesEntries");
            carvcesEntriesNode.InnerXml = "";
            foreach (SqlQueryCollectorEntry queryEntry in Entries)
            {
                XmlElement carvceEntryNode = config.CreateElement("carvceEntry");
                XmlElement dataSourceNode = config.CreateElement("dataSource");

                dataSourceNode.SetAttributeValue("name", queryEntry.Name);
                dataSourceNode.SetAttributeValue("dataSourceType", queryEntry.DataSourceType.ToString());
                dataSourceNode.SetAttributeValue("connStr", queryEntry.ConnectionString);
                dataSourceNode.SetAttributeValue("provider", queryEntry.ProviderName);
                dataSourceNode.SetAttributeValue("fileName", queryEntry.FileName);
                dataSourceNode.SetAttributeValue("server", queryEntry.Server);
                dataSourceNode.SetAttributeValue("database", queryEntry.Database);
                dataSourceNode.SetAttributeValue("integratedSec", queryEntry.IntegratedSecurity);
                dataSourceNode.SetAttributeValue("userName", queryEntry.UserName);
                dataSourceNode.SetAttributeValue("password", queryEntry.Password);
                dataSourceNode.SetAttributeValue("cmndTimeOut", queryEntry.CmndTimeOut);
                dataSourceNode.SetAttributeValue("usePersistentConnection", queryEntry.UsePersistentConnection);
                dataSourceNode.SetAttributeValue("applicationName", queryEntry.ApplicationName);
                dataSourceNode.SetAttributeValue("primaryUIValue", queryEntry.PrimaryUIValue);
                dataSourceNode.SetAttributeValue("outputValueUnit", queryEntry.OutputValueUnit);

                XmlElement stateQueryNode = dataSourceNode.AppendElementWithText("stateQuery", queryEntry.StateQuery);
                stateQueryNode.SetAttributeValue("useSP", queryEntry.UseSPForStateQuery);

                XmlElement detailQueryNode = dataSourceNode.AppendElementWithText("detailQuery", queryEntry.DetailQuery);
                detailQueryNode.SetAttributeValue("useSP", queryEntry.UseSPForDetailQuery);

                XmlElement testConditionsNode = config.CreateElement("testConditions");
                testConditionsNode.SetAttributeValue("testSequence", queryEntry.ReturnCheckSequence.ToString());
                testConditionsNode.SetAttributeValue("valueReturnType", queryEntry.ValueReturnType.ToString());
                XmlElement successNode = config.CreateElement("success");
                successNode.SetAttributeValue("testType", queryEntry.GoodResultMatchType.ToString());
                successNode.InnerText = queryEntry.GoodValue;
                XmlElement warningNode = config.CreateElement("warning");
                warningNode.SetAttributeValue("testType", queryEntry.WarningResultMatchType.ToString());
                warningNode.InnerText = queryEntry.WarningValue;
                XmlElement errorNode = config.CreateElement("error");
                errorNode.SetAttributeValue("testType", queryEntry.ErrorResultMatchType.ToString());
                errorNode.InnerText = queryEntry.ErrorValue;                

                testConditionsNode.AppendChild(successNode);
                testConditionsNode.AppendChild(warningNode);
                testConditionsNode.AppendChild(errorNode);
                carvceEntryNode.AppendChild(dataSourceNode);
                carvceEntryNode.AppendChild(testConditionsNode);
                carvcesEntriesNode.AppendChild(carvceEntryNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config>" +
               "<carvcesEntries>" +
               "<carvceEntry name=\"\">" +
               "<dataSource><stateQuery /><detailQuery /></dataSource>" +
               "<testConditions testSequence=\"GWE\">" +
               "<success testType=\"match\"></success>" +
               "<warning testType=\"match\"></warning>" +
               "<error testType=\"match\"></error>" +
               "</testConditions>" +
               "</carvceEntry>" +
               "</carvcesEntries>" +
               "</config>";

          //  return "<config><queries>" +
          //  "<query name=\"\" dataSourceType=\"SqlServer\" connStr=\"\" provider=\"\" " +
          //      "server=\"\" database=\"\" integratedSec=\"True\" userName=\"\" password=\"\" " +
          //      "cmndTimeOut=\"60\" usePersistentConnection=\"False\" applicationName=\"QuickMon\">" +
          //      "<alertTriggers valueReturnType=\"RawValue\" checkSequence=\"EWG\">" +
          //          "<success matchType=\"Match\" value=\"[any]\" />" +
          //          "<warning matchType=\"Match\" value=\"0\" />" +
          //          "<error matchType=\"Match\" value=\"[null]\" />" +
          //      "</alertTriggers>" +
          //      "<stateQuery useSP=\"False\" />" +
          //      "<detailQuery useSP=\"False\" />" +
          //  "</query>" +
          //"</queries></config>";
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
            ReturnCheckSequence = CollectorAgentReturnValueCheckSequence.GWE;
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
                    GoodValue, GoodResultMatchType,
                    WarningValue, WarningResultMatchType,
                    ErrorValue, ErrorResultMatchType, ReturnCheckSequence) +
                    (ValueReturnType == DataBaseQueryValueReturnType.RowCount ? ", RowCnt" : "") +
                    (ValueReturnType == DataBaseQueryValueReturnType.QueryTime ? ", QryTime" : "");
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        public object CurrentAgentValue { get; set; }
        public bool PrimaryUIValue { get; set; }
        public MonitorState GetCurrentState()
        {
            object value = GetStateQueryValue();
            string unitName = ValueReturnType == DataBaseQueryValueReturnType.RowCount ? "row(s)" : ValueReturnType == DataBaseQueryValueReturnType.QueryTime ? "ms" : OutputValueUnit;
            MonitorState currentState = new MonitorState()
            {
                State = CollectorAgentReturnValueCompareEngine.GetState(ReturnCheckSequence, GoodResultMatchType, GoodValue,
                 WarningResultMatchType, WarningValue, ErrorResultMatchType, ErrorValue, value),
                ForAgent = Name,
                CurrentValue = value,
                CurrentValueUnit = unitName
            };

            return currentState;
        }
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
        public string OutputValueUnit { get; set; }

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
        public CollectorAgentReturnValueCheckSequence ReturnCheckSequence { get; set; }
        public CollectorAgentReturnValueCompareMatchType GoodResultMatchType { get; set; }
        public string GoodValue { get; set; }
        public CollectorAgentReturnValueCompareMatchType WarningResultMatchType { get; set; }
        public string WarningValue { get; set; }
        public CollectorAgentReturnValueCompareMatchType ErrorResultMatchType { get; set; }
        public string ErrorValue { get; set; }        
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
