﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class SqlTableSizeCollectorConfig : ICollectorConfig
    {
        public SqlTableSizeCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement databaseNode in root.SelectNodes("databases/database"))
            {
                SqlTableSizeCollectorEntry entry = new SqlTableSizeCollectorEntry();
                entry.SqlServer = databaseNode.ReadXmlElementAttr("server", "");
                entry.Database = databaseNode.ReadXmlElementAttr("name", "");
                entry.IntegratedSecurity = databaseNode.ReadXmlElementAttr("integratedSec", true);
                entry.UserName = databaseNode.ReadXmlElementAttr("userName", "");
                entry.Password = databaseNode.ReadXmlElementAttr("password", "");
                entry.SqlCmndTimeOutSec = databaseNode.ReadXmlElementAttr("sqlCmndTimeOutSec", 30);

                foreach (XmlElement tableNode in databaseNode.SelectNodes("table"))
                {
                    TableSizeEntry tableSizeEntry = new TableSizeEntry();
                    tableSizeEntry.TableName = tableNode.ReadXmlElementAttr("name", "");
                    tableSizeEntry.WarningValue = long.Parse(tableNode.ReadXmlElementAttr("warningValue", "1"));
                    tableSizeEntry.ErrorValue = long.Parse(tableNode.ReadXmlElementAttr("errorValue", "2"));
                    entry.Tables.Add(tableSizeEntry);
                }

                Entries.Add(entry);
            }
        }

        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode databasesNode = root.SelectSingleNode("databases");
            databasesNode.InnerXml = "";

            foreach (SqlTableSizeCollectorEntry databaseEntry in Entries)
            {
                XmlElement databaseNode = config.CreateElement("database");
                databaseNode.SetAttributeValue("name", databaseEntry.Database);
                databaseNode.SetAttributeValue("server", databaseEntry.SqlServer);
                databaseNode.SetAttributeValue("integratedSec", databaseEntry.IntegratedSecurity);
                databaseNode.SetAttributeValue("userName", databaseEntry.UserName);
                databaseNode.SetAttributeValue("password", databaseEntry.Password);
                databaseNode.SetAttributeValue("sqlCmndTimeOutSec", databaseEntry.SqlCmndTimeOutSec);

                foreach (TableSizeEntry tableSizeEntry in databaseEntry.Tables)
                {
                    XmlElement tableNode = config.CreateElement("table");
                    tableNode.SetAttributeValue("name", tableSizeEntry.TableName);
                    tableNode.SetAttributeValue("warningValue", tableSizeEntry.WarningValue);
                    tableNode.SetAttributeValue("errorValue", tableSizeEntry.ErrorValue);
                    databaseNode.AppendChild(tableNode);
                }
                databasesNode.AppendChild(databaseNode);
            }
            return config.OuterXml;
        }

        public string GetDefaultOrEmptyXml()
        {
            return "<config><databases><database name=\"\" server=\"\" integratedSec=\"True\" userName=\"\" password=\"\" sqlCmndTimeOutSec=\"30\"></database></databases></config>";
        }

        public string ConfigSummary
        {
            get { throw new NotImplementedException(); }
        }
    }
}
