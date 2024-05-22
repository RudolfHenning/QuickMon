using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Notifiers
{
    [Description("Sql Server Database Notifier")]
    public class SqlDatabaseNotifier : NotifierAgentBase
    {
        public SqlDatabaseNotifier()
        {
            AgentConfig = new SqlDatabaseNotifierConfig();
        }
        private SqlConnection cacheConn = null;

        public override void RecordMessage(AlertRaised alertRaised)
        {
            string lastStep = "";
            try
            {
                SqlDatabaseNotifierConfig currentConfig = (SqlDatabaseNotifierConfig)AgentConfig;

                if (cacheConn == null || cacheConn.State != ConnectionState.Open)
                {
                    cacheConn = null;
                    cacheConn = new SqlConnection(currentConfig.GetConnectionString());
                    for (int i = 0; i < 3; i++)
                    {
                        try
                        {
                            cacheConn.Open();
                            break;
                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            if (ex.Message.Contains("The timeout period elapsed while attempting to consume the pre-login handshake acknowledgement"))
                            {
                                System.Threading.Thread.Sleep(3000);
                                //try again                                
                            }
                            else
                                throw;
                        }
                    }
                }

                lastStep = string.Format("Inserting test message into database {0}\\{1}", currentConfig.SqlServer, currentConfig.Database);

                string alertParamName = currentConfig.AlertFieldName.Replace("'", "''").Replace("@", "");
                string collectorParamName = currentConfig.CollectorFieldName.Replace("'", "''").Replace("@", "");
                string previousStateParamName = currentConfig.PreviousStateFieldName.Replace("'", "''").Replace("@", "");
                string currentStateParamName = currentConfig.CurrentStateFieldName.Replace("'", "''").Replace("@", "");
                string detailsParamName = currentConfig.DetailsFieldName.Replace("'", "''").Replace("@", "");

                string sql = currentConfig.UseSP ? currentConfig.CmndValue :
                    string.Format("Insert {0} ({1}, {2}, {3}, {4}, {5}) values(@{1}, @{2}, @{3}, @{4}, @{5})",
                        currentConfig.CmndValue,
                        currentConfig.AlertFieldName,
                        collectorParamName,
                        previousStateParamName,
                        currentStateParamName,
                        detailsParamName);

                string collectorName = "QuickMon Global Alert";
                //string collectorAgents = "None";
                int oldState = 0;
                int newState = 0;
                string detailMessage = "N/A";
                string viaHost = "";
                if (alertRaised.RaisedFor != null)
                {
                    collectorName = alertRaised.RaisedFor.NameFormatted;
                    oldState = (byte)alertRaised.RaisedFor.PreviousState.State;
                    newState = (byte)alertRaised.RaisedFor.CurrentState.State;
                    detailMessage = FormatUtils.N(alertRaised.RaisedFor.CurrentState.ReadAllRawDetails(), "No details available");
                    if (alertRaised.RaisedFor.OverrideRemoteAgentHost)
                        viaHost = string.Format(" (via {0}:{1})", alertRaised.RaisedFor.OverrideRemoteAgentHostAddress, alertRaised.RaisedFor.OverrideRemoteAgentHostPort);
                    else if (alertRaised.RaisedFor.EnableRemoteExecute)
                        viaHost = string.Format(" (via {0}:{1})", alertRaised.RaisedFor.RemoteAgentHostAddress, alertRaised.RaisedFor.RemoteAgentHostPort);
                }

                using (SqlCommand cmnd = new SqlCommand(sql, cacheConn))
                {
                    SqlParameter[] paramArr = new SqlParameter[] 
                            { 
                                new SqlParameter("@" + alertParamName,  (byte)alertRaised.Level),
                                new SqlParameter("@" + collectorParamName,  collectorName + viaHost),
                                new SqlParameter("@" + previousStateParamName,  oldState),
                                new SqlParameter("@" + currentStateParamName,  newState),
                                new SqlParameter("@" + detailsParamName, detailMessage)
                            };
                    cmnd.Parameters.AddRange(paramArr);
                    if (currentConfig.UseSP)
                        cmnd.CommandType = CommandType.StoredProcedure;
                    else
                        cmnd.CommandType = CommandType.Text;
                    cmnd.CommandTimeout = currentConfig.CmndTimeOut;
                    cmnd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error recording message in Database notifier\r\nLast step: " + lastStep, ex);
            }
        }
        public override AttendedOption AttendedRunOption { get { return AttendedOption.AttendedAndUnAttended; } }
    }

    public class SqlDatabaseNotifierConfig : INotifierConfig
    {
        #region Properties
        private string sqlServer;
        public string SqlServer { get { return sqlServer; } set { sqlServer = value; } }
        string database = "QuickMon";
        public string Database { get { return database; } set { database = value; } }
        private bool integratedSec;
        public bool IntegratedSec { get { return integratedSec; } set { integratedSec = value; } }
        private string userName;
        public string UserName { get { return userName; } set { userName = value; } }
        private string password;
        public string Password { get { return password; } set { password = value; } }
        private int cmndTimeOut = 60;
        public int CmndTimeOut { get { return cmndTimeOut; } set { cmndTimeOut = value; } }
        private bool useSP;
        public bool UseSP { get { return useSP; } set { useSP = value; } }
        private string cmndValue;
        public string CmndValue { get { return cmndValue; } set { cmndValue = value; } }
        private string alertFieldName;
        public string AlertFieldName { get { return alertFieldName; } set { alertFieldName = value; } }
        private string collectorFieldName;
        public string CollectorFieldName { get { return collectorFieldName; } set { collectorFieldName = value; } }
        private string previousStateFieldName;
        public string PreviousStateFieldName { get { return previousStateFieldName; } set { previousStateFieldName = value; } }
        private string currentStateFieldName;
        public string CurrentStateFieldName { get { return currentStateFieldName; } set { currentStateFieldName = value; } }
        private string detailsFieldName;
        public string DetailsFieldName { get { return detailsFieldName; } set { detailsFieldName = value; } }
        private bool useSPForViewer = true;
        public bool UseSPForViewer { get { return useSPForViewer; } set { useSPForViewer = value; } }
        private string viewerName;
        public string ViewerName { get { return viewerName; } set { viewerName = value; } }
        private string dateTimeFieldName;
        public string DateTimeFieldName { get { return dateTimeFieldName; } set { dateTimeFieldName = value; } }
        #endregion

        #region INotifierConfig members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            XmlNode connectionNode = root.SelectSingleNode("connection");
            SqlServer = connectionNode.ReadXmlElementAttr("sqlServer", "");
            Database = connectionNode.ReadXmlElementAttr("database", "");
            IntegratedSec = bool.Parse(connectionNode.ReadXmlElementAttr("integratedSec", "True"));
            UserName = connectionNode.ReadXmlElementAttr("userName", "");
            Password = connectionNode.ReadXmlElementAttr("password", "");
            XmlNode cmndNode = connectionNode.SelectSingleNode("command");
            CmndTimeOut = int.Parse(cmndNode.ReadXmlElementAttr("cmndTimeOut", ""));
            UseSP = bool.Parse(cmndNode.ReadXmlElementAttr("useSP", "True"));
            CmndValue = cmndNode.ReadXmlElementAttr("value", "InsertMessage");
            AlertFieldName = cmndNode.ReadXmlElementAttr("alertFieldName", "AlertLevel");
            CollectorFieldName = cmndNode.ReadXmlElementAttr("collectorFieldName", "Collector");
            PreviousStateFieldName = cmndNode.ReadXmlElementAttr("previousStateFieldName", "PreviousState");
            CurrentStateFieldName = cmndNode.ReadXmlElementAttr("currentStateFieldName", "CurrentState");
            DetailsFieldName = cmndNode.ReadXmlElementAttr("detailsFieldName", "Details");
            UseSPForViewer = bool.Parse(cmndNode.ReadXmlElementAttr("useSPForViewer", "True"));
            ViewerName = cmndNode.ReadXmlElementAttr("viewer", "QueryMessages");
            DateTimeFieldName = cmndNode.ReadXmlElementAttr("dateTimeFieldName", "InsertDate");
        }
        public string ToXml()
        {
            XmlDocument configXml = new XmlDocument();
            configXml.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = configXml.DocumentElement;
            XmlNode connectionNode = root.SelectSingleNode("connection");
            connectionNode.SetAttributeValue("sqlServer", SqlServer);
            connectionNode.SetAttributeValue("database", Database);
            connectionNode.SetAttributeValue("integratedSec", IntegratedSec.ToString());
            connectionNode.SetAttributeValue("userName", UserName);
            connectionNode.SetAttributeValue("password", Password);
            XmlNode cmndNode = connectionNode.SelectSingleNode("command");
            cmndNode.SetAttributeValue("cmndTimeOut", CmndTimeOut.ToString());
            cmndNode.SetAttributeValue("useSP", UseSP.ToString());
            cmndNode.SetAttributeValue("value", CmndValue);
            cmndNode.SetAttributeValue("alertFieldName", AlertFieldName);
            //cmndNode.SetAttributeValue("collectorAgentsDetail", CollectorAgentsDetailFieldName);
            cmndNode.SetAttributeValue("collectorFieldName", CollectorFieldName);
            cmndNode.SetAttributeValue("previousStateFieldName", PreviousStateFieldName);
            cmndNode.SetAttributeValue("currentStateFieldName", CurrentStateFieldName);
            cmndNode.SetAttributeValue("detailsFieldName", DetailsFieldName);
            cmndNode.SetAttributeValue("useSPForViewer", UseSPForViewer.ToString());
            cmndNode.SetAttributeValue("viewer", ViewerName);
            cmndNode.SetAttributeValue("dateTimeFieldName", DateTimeFieldName);
            return configXml.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config>\r\n" +
                "  <connection sqlServer=\"\" database=\"QuickMon\" integratedSec=\"True\" userName=\"\" password=\"\" >\r\n" +
                "    <command cmndTimeOut=\"60\" useSP=\"True\" value=\"InsertMessage\" \r\n" +
                "             alertFieldName=\"AlertLevel\" \r\n" +
                "             collectorFieldName=\"Collector\"\r\n" +
                "             previousStateFieldName=\"PreviousState\"\r\n" +
                "             currentStateFieldName=\"CurrentState\"\r\n" +
                "             detailsFieldName=\"Details\"\r\n" +
                "             useSPForViewer=\"True\"\r\n" +
                "             viewer=\"QueryMessages\"\r\n" +
                "             dateTimeFieldName=\"InsertDate\"/>\r\n" +
                "  </connection>\r\n" +
                "</config>";
        }
        public string ConfigSummary
        {
            get
            {
                string summary = string.Format("Server: {0}, Database: {1}, Logon: {2}",
                    sqlServer, database,
                    (integratedSec ? "Integrated security" : "UserName: " + userName)
                    );
                return summary;
            }
        }
        #endregion

        public string GetConnectionString()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = sqlServer;
            scsb.InitialCatalog = database;
            scsb.IntegratedSecurity = integratedSec;
            if (!integratedSec)
            {
                scsb.UserID = userName;
                scsb.Password = password;
            }
            return scsb.ConnectionString;
        }
    }
}
