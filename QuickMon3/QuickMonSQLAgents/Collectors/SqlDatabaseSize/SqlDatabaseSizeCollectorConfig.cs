using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class SqlDatabaseSizeCollectorConfig : ICollectorConfig
    {
        public SqlDatabaseSizeCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public List<ICollectorConfigEntry> Entries { get; set; }
        public ConfigEntryType ConfigEntryType { get { return QuickMon.ConfigEntryType.Multiple; } }
        public bool CanEdit { get { return true; } }
        #endregion
        //public List<SqlDatabaseSizeEntry> Entries = new List<SqlDatabaseSizeEntry>();

        #region IAgentConfig Members
        public void ReadConfiguration(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement databaseNode in root.SelectNodes("databases/database"))
            {
                SqlDatabaseSizeEntry databaseEntry = new SqlDatabaseSizeEntry();
                databaseEntry.Database = databaseNode.ReadXmlElementAttr("name", "");
                databaseEntry.SqlServer = databaseNode.ReadXmlElementAttr("server", "");                
                databaseEntry.IntegratedSecurity = databaseNode.ReadXmlElementAttr("integratedSec", true);
                databaseEntry.UserName = databaseNode.ReadXmlElementAttr("userName", "");
                databaseEntry.Password = databaseNode.ReadXmlElementAttr("password", "");
                databaseEntry.SqlCmndTimeOutSec = databaseNode.ReadXmlElementAttr("sqlCmndTimeOutSec", 30);
                databaseEntry.WarningSizeMB = databaseNode.ReadXmlElementAttr("warningValueMB", 1024);
                databaseEntry.ErrorSizeMB = databaseNode.ReadXmlElementAttr("errorValueMB", 4096);
                Entries.Add(databaseEntry);
            }
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.SqlDatabaseSizeCollectorDefaultConfig);
            XmlElement root = config.DocumentElement;
            XmlNode dbsNode = root.SelectSingleNode("databases");
            dbsNode.InnerXml = "";

            foreach (SqlDatabaseSizeEntry entry in Entries)
            {
                XmlElement dbSizeNode = config.CreateElement("database");
                dbSizeNode.SetAttributeValue("name", entry.Database);
                dbSizeNode.SetAttributeValue("server", entry.SqlServer);
                dbSizeNode.SetAttributeValue("integratedSec", entry.IntegratedSecurity);
                dbSizeNode.SetAttributeValue("userName", entry.UserName);
                dbSizeNode.SetAttributeValue("password", entry.Password);
                dbSizeNode.SetAttributeValue("sqlCmndTimeOutSec", entry.SqlCmndTimeOutSec);
                dbSizeNode.SetAttributeValue("warningValueMB", entry.WarningSizeMB);
                dbSizeNode.SetAttributeValue("errorValueMB", entry.ErrorSizeMB);
                dbsNode.AppendChild(dbSizeNode);
            }
            return config.OuterXml;
        }
        #endregion
    }
}
