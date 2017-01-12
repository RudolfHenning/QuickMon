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
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement databaseNode in root.SelectNodes("databases/database"))
            {
                SqlDatabaseSizeCollectorEntry databaseEntry = new SqlDatabaseSizeCollectorEntry();
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
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode dbsNode = root.SelectSingleNode("databases");
            dbsNode.InnerXml = "";

            foreach (SqlDatabaseSizeCollectorEntry entry in Entries)
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
        public string GetDefaultOrEmptyXml()
        {
            return "<config>\r\n<databases>\r\n<!--\r\n<database server=\".\" name=\"master\" integratedSec=\"True\" userName=\"\"  password=\"\" sqlCmndTimeOutSec=\"30\" warningValueMB=\"1024\" errorValueMB=\"4096\" />\r\n-->\r\n</databases>\r\n</config>";
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
}
