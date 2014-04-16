using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class OLEDBQueryCollectorConfig : ICollectorConfig
    {
        public OLEDBQueryCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public List<ICollectorConfigEntry> Entries { get; set; }
        public ConfigEntryType ConfigEntryType { get { return QuickMon.ConfigEntryType.Multiple; } }
        public bool CanEdit { get { return true; } }
        #endregion

        #region IAgentConfig Members
        public void ReadConfiguration(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement queryNode in root.SelectNodes("queries/query"))
            {
                OLEDBQueryInstance queryEntry = new OLEDBQueryInstance();
                queryEntry.Name = queryNode.ReadXmlElementAttr("name", "");
                queryEntry.DataSource = queryNode.ReadXmlElementAttr("dataSource", "");
                queryEntry.Provider = queryNode.ReadXmlElementAttr("provider", "Microsoft.Jet.OLEDB.4.0");
                queryEntry.UserName = queryNode.ReadXmlElementAttr("userName", "");
                queryEntry.Password = queryNode.ReadXmlElementAttr("password", "");
                queryEntry.ConnectionString = queryNode.ReadXmlElementAttr("connectionString", "");
                queryEntry.CmndTimeOut = int.Parse(queryNode.ReadXmlElementAttr("cmndTimeOut", "60"));
                queryEntry.UsePersistentConnection = bool.Parse(queryNode.ReadXmlElementAttr("usePersistentConnection", "False"));

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
            config.LoadXml(Properties.Resources.OLEDBQueryCollectorDefaultConfig);
            XmlElement root = config.DocumentElement;
            XmlNode queriesNode = root.SelectSingleNode("queries");
            queriesNode.InnerXml = "";

            foreach (OLEDBQueryInstance queryEntry in Entries)
            {
                XmlElement queryNode = config.CreateElement("query");
                queryNode.SetAttributeValue("name", queryEntry.Name);
                queryNode.SetAttributeValue("dataSource", queryEntry.DataSource);
                queryNode.SetAttributeValue("provider", queryEntry.Provider);
                queryNode.SetAttributeValue("userName", queryEntry.UserName);
                queryNode.SetAttributeValue("password", queryEntry.Password);
                queryNode.SetAttributeValue("connectionString", queryEntry.ConnectionString);
                queryNode.SetAttributeValue("cmndTimeOut", queryEntry.CmndTimeOut);
                queryNode.SetAttributeValue("usePersistentConnection", queryEntry.UsePersistentConnection);

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
