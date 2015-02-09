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

                XmlNode alertTriggersNode = queryNode.SelectSingleNode("alertTriggers");
                queryEntry.ValueReturnType = DataBaseQueryValueReturnTypeConverter.FromString(alertTriggersNode.ReadXmlElementAttr("valueReturnType", "RawValue"));
                queryEntry.ValueReturnCheckSequence = CollectorAgentReturnValueCompareEngine.CheckSequenceTypeFromString(alertTriggersNode.ReadXmlElementAttr("checkSequence", "EWG"));

                XmlNode successNode = alertTriggersNode.SelectSingleNode("success");
                queryEntry.SuccessMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(successNode.ReadXmlElementAttr("matchType", "Match"));
                queryEntry.SuccessValueOrMacro = successNode.ReadXmlElementAttr("value", "[any]");

                XmlNode warningNode = alertTriggersNode.SelectSingleNode("warning");
                queryEntry.WarningMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(warningNode.ReadXmlElementAttr("matchType", "Match"));
                queryEntry.WarningValueOrMacro = warningNode.ReadXmlElementAttr("value", "0");

                XmlNode errorNode = alertTriggersNode.SelectSingleNode("error");
                queryEntry.ErrorMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(errorNode.ReadXmlElementAttr("matchType", "Match"));
                queryEntry.ErrorValueOrMacro = warningNode.ReadXmlElementAttr("value", "[null]");

                XmlNode stateQueryNode = queryNode.SelectSingleNode("stateQuery");
                queryEntry.UseSPForStateQuery = stateQueryNode.ReadXmlElementAttr("useSP", false);
                queryEntry.StateQuery = stateQueryNode.InnerText;

                XmlNode detailQueryNode = queryNode.SelectSingleNode("detailQuery");
                queryEntry.UseSPForDetailQuery = detailQueryNode.ReadXmlElementAttr("useSP", false);
                queryEntry.DetailQuery = detailQueryNode.InnerText;

                Entries.Add(queryEntry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode queriesNode = root.SelectSingleNode("queries");
            queriesNode.InnerXml = "";
            foreach (SqlQueryCollectorEntry queryEntry in Entries)
            {
                XmlElement queryNode = config.CreateElement("query");
                queryNode.SetAttributeValue("name", queryEntry.Name);
                queryNode.SetAttributeValue("dataSourceType", queryEntry.DataSourceType.ToString());
                queryNode.SetAttributeValue("connStr", queryEntry.ConnectionString);
                queryNode.SetAttributeValue("provider", queryEntry.ProviderName);
                queryNode.SetAttributeValue("fileName", queryEntry.FileName);
                queryNode.SetAttributeValue("server", queryEntry.Server);
                queryNode.SetAttributeValue("database", queryEntry.Database);
                queryNode.SetAttributeValue("integratedSec", queryEntry.IntegratedSecurity);
                queryNode.SetAttributeValue("userName", queryEntry.UserName);
                queryNode.SetAttributeValue("password", queryEntry.Password);
                queryNode.SetAttributeValue("cmndTimeOut", queryEntry.CmndTimeOut);
                queryNode.SetAttributeValue("usePersistentConnection", queryEntry.UsePersistentConnection);
                queryNode.SetAttributeValue("applicationName", queryEntry.ApplicationName);

                XmlElement alertTriggersNode = config.CreateElement("alertTriggers");
                alertTriggersNode.SetAttributeValue("valueReturnType", queryEntry.ValueReturnType.ToString());
                alertTriggersNode.SetAttributeValue("checkSequence", queryEntry.ValueReturnCheckSequence.ToString());
                XmlElement successNode = config.CreateElement("success");
                successNode.SetAttributeValue("matchType", queryEntry.SuccessMatchType.ToString());
                successNode.SetAttributeValue("value", queryEntry.SuccessValueOrMacro);
                alertTriggersNode.AppendChild(successNode);
                XmlElement warningNode = config.CreateElement("warning");
                warningNode.SetAttributeValue("matchType", queryEntry.WarningMatchType.ToString());
                warningNode.SetAttributeValue("value", queryEntry.WarningValueOrMacro);
                alertTriggersNode.AppendChild(warningNode);
                XmlElement errorNode = config.CreateElement("error");
                errorNode.SetAttributeValue("matchType", queryEntry.ErrorMatchType.ToString());
                errorNode.SetAttributeValue("value", queryEntry.ErrorValueOrMacro);
                alertTriggersNode.AppendChild(errorNode);
                queryNode.AppendChild(alertTriggersNode);

                XmlElement stateQueryNode = queryNode.AppendElementWithText("stateQuery", queryEntry.StateQuery);
                stateQueryNode.SetAttributeValue("useSP", queryEntry.UseSPForStateQuery);
                
                XmlElement detailQueryNode = queryNode.AppendElementWithText("detailQuery", queryEntry.DetailQuery);
                detailQueryNode.SetAttributeValue("useSP", queryEntry.UseSPForDetailQuery);
                
                queriesNode.AppendChild(queryNode);
            }
            return config.OuterXml;

        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config><queries>" +
                "<query name=\"\" dataSourceType=\"SqlServer\" connStr=\"\" provider=\"\" " +
                    "server=\"\" database=\"\" integratedSec=\"True\" userName=\"\" password=\"\" " + 
                    "cmndTimeOut=\"60\" usePersistentConnection=\"False\" applicationName=\"QuickMon\">" +
                    "<alertTriggers valueReturnType=\"RawValue\" checkSequence=\"EWG\">" +
                        "<success matchType=\"Match\" value=\"[any]\" />" +
                        "<warning matchType=\"Match\" value=\"0\" />" +
                        "<error matchType=\"Match\" value=\"[null]\" />" +
                    "</alertTriggers>" +
                    "<stateQuery useSP=\"False\" />" +
                    "<detailQuery useSP=\"False\" />" +
                "</query>" +
              "</queries></config>";
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
