using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class DirectoryServicesQueryCollectorConfig : ICollectorConfig
    {
        public DirectoryServicesQueryCollectorConfig()
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
            foreach (XmlElement queryNode in root.SelectNodes("directoryServices/query"))
            {
                DirectoryServicesQueryCollectorConfigEntry dirSrvsQryEntry = new DirectoryServicesQueryCollectorConfigEntry();
                dirSrvsQryEntry.Name = queryNode.ReadXmlElementAttr("name", "");
                dirSrvsQryEntry.DomainController = queryNode.ReadXmlElementAttr("domainController", "");
                dirSrvsQryEntry.PropertiesToLoad = queryNode.ReadXmlElementAttr("propertiesToLoad", "sAMAccountName");
                dirSrvsQryEntry.UseRowCountAsValue = queryNode.ReadXmlElementAttr("useRowCountAsValue", false);
                dirSrvsQryEntry.MaxRowsToEvaluate = queryNode.ReadXmlElementAttr("maxRows", 1);
                dirSrvsQryEntry.ReturnCheckSequence = CollectorReturnValueCompareEngine.CheckSequenceTypeFromString(queryNode.ReadXmlElementAttr("returnCheckSequence", "gwe"));
                XmlNode queryFilterNode = queryNode.SelectSingleNode("queryFilter");
                dirSrvsQryEntry.QueryFilterText = queryFilterNode.InnerText;
                XmlNode goodConditionNode = queryNode.SelectSingleNode("goodCondition");
                dirSrvsQryEntry.GoodResultMatchType = CollectorReturnValueCompareEngine.MatchTypeFromString(goodConditionNode.ReadXmlElementAttr("resultMatchType", "match"));
                dirSrvsQryEntry.GoodScriptText = goodConditionNode.InnerText;
                XmlNode warningConditionNode = queryNode.SelectSingleNode("warningCondition");
                dirSrvsQryEntry.WarningResultMatchType = CollectorReturnValueCompareEngine.MatchTypeFromString(warningConditionNode.ReadXmlElementAttr("resultMatchType", "match"));
                dirSrvsQryEntry.WarningScriptText = warningConditionNode.InnerText;
                XmlNode errorConditionNode = queryNode.SelectSingleNode("errorCondition");
                dirSrvsQryEntry.ErrorResultMatchType = CollectorReturnValueCompareEngine.MatchTypeFromString(errorConditionNode.ReadXmlElementAttr("resultMatchType", "match"));
                dirSrvsQryEntry.ErrorScriptText = errorConditionNode.InnerText;
                Entries.Add(dirSrvsQryEntry);
            }
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.DirectoryServicesQueryDefaultConfig);
            XmlElement root = config.DocumentElement;

            XmlNode directoryServicesNode = root.SelectSingleNode("directoryServices");
            directoryServicesNode.InnerXml = "";

            foreach (DirectoryServicesQueryCollectorConfigEntry dirSrvsQryEntry in Entries)
            {
                XmlElement queryNode = config.CreateElement("query");
                queryNode.SetAttributeValue("name", dirSrvsQryEntry.Name);
                queryNode.SetAttributeValue("domainController", dirSrvsQryEntry.DomainController);
                queryNode.SetAttributeValue("propertiesToLoad", dirSrvsQryEntry.PropertiesToLoad);
                queryNode.SetAttributeValue("useRowCountAsValue", dirSrvsQryEntry.UseRowCountAsValue);
                queryNode.SetAttributeValue("maxRows", dirSrvsQryEntry.MaxRowsToEvaluate);
                queryNode.SetAttributeValue("returnCheckSequence", dirSrvsQryEntry.ReturnCheckSequence.ToString());
                XmlNode queryFilterNode = queryNode.AppendElementWithText("queryFilter", dirSrvsQryEntry.QueryFilterText);
                XmlNode goodConditionNode = queryNode.AppendElementWithText("goodCondition", dirSrvsQryEntry.GoodScriptText);
                goodConditionNode.SetAttributeValue("resultMatchType", dirSrvsQryEntry.GoodResultMatchType.ToString());
                XmlNode warningConditionNode = queryNode.AppendElementWithText("warningCondition", dirSrvsQryEntry.WarningScriptText);
                warningConditionNode.SetAttributeValue("resultMatchType", dirSrvsQryEntry.WarningResultMatchType.ToString());
                XmlNode errorConditionNode = queryNode.AppendElementWithText("errorCondition", dirSrvsQryEntry.ErrorScriptText);
                errorConditionNode.SetAttributeValue("resultMatchType", dirSrvsQryEntry.ErrorResultMatchType.ToString());
                directoryServicesNode.AppendChild(queryNode);
            }
            return config.OuterXml;
        }
        #endregion
    }
}
