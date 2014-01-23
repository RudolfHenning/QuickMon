using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class SqlQueryCollectorConfig : ICollectorConfig
    {
        public SqlQueryCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public List<ICollectorConfigEntry> Entries { get; set; }
        public ConfigEntryType ConfigEntryType { get { return QuickMon.ConfigEntryType.Multiple; } }
        public bool CanEdit { get { return true; } }
        #endregion

        //public List<QueryInstance> Queries { get; set; }

        //public SqlQueryCollectorConfig()
        //{
        //    Queries = new List<QueryInstance>();
        //}

        #region IAgentConfig Members
        public void ReadConfiguration(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement queryNode in root.SelectNodes("queries/query"))
            {
                QueryInstance queryEntry = new QueryInstance();
                queryEntry.Name = queryNode.ReadXmlElementAttr("name", "");
                queryEntry.SqlServer = queryNode.ReadXmlElementAttr("sqlServer", "");
                queryEntry.Database = queryNode.ReadXmlElementAttr("database", "");
                queryEntry.IntegratedSecurity = bool.Parse(queryNode.ReadXmlElementAttr("integratedSec", "True"));
                queryEntry.UserName = queryNode.ReadXmlElementAttr("userName", "");
                queryEntry.Password = queryNode.ReadXmlElementAttr("password", "");
                queryEntry.CmndTimeOut = int.Parse(queryNode.ReadXmlElementAttr("cmndTimeOut", "60"));
                queryEntry.UsePersistentConnection = bool.Parse(queryNode.ReadXmlElementAttr("usePersistentConnection", "False"));
                queryEntry.ApplicationName = queryNode.ReadXmlElementAttr("applicationName", "QuickMon");

                XmlNode summaryQueryNode = queryNode.SelectSingleNode("summaryQuery");
                queryEntry.UseSPForSummary = bool.Parse(summaryQueryNode.ReadXmlElementAttr("useSP", "False"));
                queryEntry.ReturnValueIsNumber = bool.Parse(summaryQueryNode.ReadXmlElementAttr("returnValueIsNumber", "True"));
                queryEntry.ReturnValueInverted = bool.Parse(summaryQueryNode.ReadXmlElementAttr("returnValueInverted", "False"));
                queryEntry.WarningValue = summaryQueryNode.ReadXmlElementAttr("warningValue", "1");
                queryEntry.ErrorValue = summaryQueryNode.ReadXmlElementAttr("errorValue", "2");
                queryEntry.SuccessValue = summaryQueryNode.ReadXmlElementAttr("successValue", "[any]");
                queryEntry.UseRowCountAsValue = bool.Parse(summaryQueryNode.ReadXmlElementAttr("useRowCountAsValue", "False"));
                queryEntry.UseExecuteTimeAsValue = bool.Parse(summaryQueryNode.ReadXmlElementAttr("useExecuteTimeAsValue", "False"));
                queryEntry.SummaryQuery = summaryQueryNode.InnerText;

                XmlNode detailQueryNode = queryNode.SelectSingleNode("detailQuery");
                queryEntry.UseSPForDetail = bool.Parse(detailQueryNode.ReadXmlElementAttr("useSP", "False"));
                queryEntry.DetailQuery = detailQueryNode.InnerText;
                Entries.Add(queryEntry);
            }
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.SqlQueryCollectorDefaultConfig);
            XmlElement root = config.DocumentElement;
            XmlNode queriesNode = root.SelectSingleNode("queries");
            queriesNode.InnerXml = "";

            foreach (QueryInstance queryEntry in Entries)
            {
                XmlElement queryNode = config.CreateElement("query");
                queryNode.SetAttributeValue("name", queryEntry.Name);
                queryNode.SetAttributeValue("sqlServer", queryEntry.SqlServer);
                queryNode.SetAttributeValue("database", queryEntry.Database);
                queryNode.SetAttributeValue("integratedSec", queryEntry.IntegratedSecurity);
                queryNode.SetAttributeValue("userName", queryEntry.UserName);
                queryNode.SetAttributeValue("password", queryEntry.Password);
                queryNode.SetAttributeValue("cmndTimeOut", queryEntry.CmndTimeOut);
                queryNode.SetAttributeValue("usePersistentConnection", queryEntry.UsePersistentConnection);
                queryNode.SetAttributeValue("applicationName", queryEntry.ApplicationName);

                XmlNode summaryQueryNode = queryNode.AppendElementWithText("summaryQuery", queryEntry.SummaryQuery);
                summaryQueryNode.SetAttributeValue("useSP", queryEntry.UseSPForSummary);
                summaryQueryNode.SetAttributeValue("returnValueIsNumber", queryEntry.ReturnValueIsNumber);
                summaryQueryNode.SetAttributeValue("returnValueInverted", queryEntry.ReturnValueInverted);
                summaryQueryNode.SetAttributeValue("warningValue", queryEntry.WarningValue);
                summaryQueryNode.SetAttributeValue("errorValue", queryEntry.ErrorValue);
                summaryQueryNode.SetAttributeValue("successValue", queryEntry.SuccessValue);
                summaryQueryNode.SetAttributeValue("useRowCountAsValue", queryEntry.UseRowCountAsValue);
                summaryQueryNode.SetAttributeValue("useExecuteTimeAsValue", queryEntry.UseExecuteTimeAsValue);

                XmlNode detailQueryNode = queryNode.AppendElementWithText("detailQuery", queryEntry.DetailQuery);
                detailQueryNode.SetAttributeValue("useSP", queryEntry.UseSPForDetail);
                queriesNode.AppendChild(queryNode);
            }
            return config.OuterXml;
        }
        #endregion
    }
}
