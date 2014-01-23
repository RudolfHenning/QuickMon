using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Notifiers
{
    public class SQLDatabaseNotifierConfig : INotifierConfig
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
        private string collectorTypeFieldName;
        public string CollectorTypeFieldName { get { return collectorTypeFieldName; } set { collectorTypeFieldName = value; } }
        private string categoryFieldName;
        public string CategoryFieldName { get { return categoryFieldName; } set { categoryFieldName = value; } }
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

        #region IAgentConfig Members
        public void ReadConfiguration(string configurationString)
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
            CollectorTypeFieldName = cmndNode.ReadXmlElementAttr("collectorTypeFieldName", "CollectorType");
            CategoryFieldName = cmndNode.ReadXmlElementAttr("categoryFieldName", "Category");
            PreviousStateFieldName = cmndNode.ReadXmlElementAttr("previousStateFieldName", "PreviousState");
            CurrentStateFieldName = cmndNode.ReadXmlElementAttr("currentStateFieldName", "CurrentState");
            DetailsFieldName = cmndNode.ReadXmlElementAttr("detailsFieldName", "Details");
            UseSPForViewer = bool.Parse(cmndNode.ReadXmlElementAttr("useSPForViewer", "True"));
            ViewerName = cmndNode.ReadXmlElementAttr("viewer", "QueryMessages");
            DateTimeFieldName = cmndNode.ReadXmlElementAttr("dateTimeFieldName", "InsertDate");
        }
        public string ToConfig()
        {
            XmlDocument configXml = new XmlDocument();
            configXml.LoadXml(Properties.Resources.SqlDatabaseNotifierDefaultConfig);
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
            cmndNode.SetAttributeValue("collectorTypeFieldName", CollectorTypeFieldName);
            cmndNode.SetAttributeValue("categoryFieldName", CategoryFieldName);
            cmndNode.SetAttributeValue("previousStateFieldName", PreviousStateFieldName);
            cmndNode.SetAttributeValue("currentStateFieldName", CurrentStateFieldName);
            cmndNode.SetAttributeValue("detailsFieldName", DetailsFieldName);
            cmndNode.SetAttributeValue("useSPForViewer", UseSPForViewer.ToString());
            cmndNode.SetAttributeValue("viewer", ViewerName);
            cmndNode.SetAttributeValue("dateTimeFieldName", DateTimeFieldName);
            return configXml.OuterXml;
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
    }
}
