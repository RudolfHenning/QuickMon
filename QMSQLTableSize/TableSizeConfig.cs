using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class TableSizeConfig
    {
        public TableSizeConfig()
        {
            DatabaseEntries = new List<DatabaseEntry>();
        }
        public List<DatabaseEntry> DatabaseEntries { get; set; }

        public void ReadConfiguration(XmlDocument config)
        {
            XmlElement root = config.DocumentElement;
            DatabaseEntries.Clear();
            foreach (XmlElement databaseNode in root.SelectNodes("databases/database"))
            {
                DatabaseEntry databaseEntry = new DatabaseEntry();
                databaseEntry.Name = databaseNode.ReadXmlElementAttr("name", "");
                databaseEntry.SqlServer = databaseNode.ReadXmlElementAttr("server", "");
                databaseEntry.IntegratedSecurity = bool.Parse(databaseNode.ReadXmlElementAttr("integratedSec", "True"));
                databaseEntry.UserName = databaseNode.ReadXmlElementAttr("userName", "");
                databaseEntry.Password = databaseNode.ReadXmlElementAttr("password", "");

                foreach (XmlElement tableNode in databaseNode.SelectNodes("table"))
                {
                    TableSizeEntry tableSizeEntry = new TableSizeEntry();
                    tableSizeEntry.TableName = tableNode.ReadXmlElementAttr("name", "");
                    tableSizeEntry.WarningValue = long.Parse(tableNode.ReadXmlElementAttr("warningValue", "1"));
                    tableSizeEntry.ErrorValue = long.Parse(tableNode.ReadXmlElementAttr("errorValue", "2"));
                    databaseEntry.TableSizeEntries.Add(tableSizeEntry);
                }
                DatabaseEntries.Add(databaseEntry);
            }
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.SqlTableSizeEmptyConfig);
            XmlElement root = config.DocumentElement;
            XmlNode databasesNode = root.SelectSingleNode("databases");
            databasesNode.InnerXml = "";

            foreach (DatabaseEntry databaseEntry in DatabaseEntries)
            {
                XmlElement databaseNode = config.CreateElement("database");
                databaseNode.SetAttributeValue("name", databaseEntry.Name);
                databaseNode.SetAttributeValue("server", databaseEntry.SqlServer);                
                databaseNode.SetAttributeValue("integratedSec", databaseEntry.IntegratedSecurity);
                databaseNode.SetAttributeValue("userName", databaseEntry.UserName);
                databaseNode.SetAttributeValue("password", databaseEntry.Password);

                foreach (TableSizeEntry tableSizeEntry in databaseEntry.TableSizeEntries)
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
    }
}
