using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class RegistryQueryCollectorConfig : ICollectorConfig
    {
        public RegistryQueryCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }
        #region ICollectorConfig Members
        public List<ICollectorConfigEntry> Entries { get; set; }
        public ConfigEntryType ConfigEntryType { get { return QuickMon.ConfigEntryType.Multiple; } }
        public bool CanEdit { get { return true; } }
        #endregion

        //public List<RegistryQueryInstance> Queries = new List<RegistryQueryInstance>();

        #region IAgentConfig Members
        public void ReadConfiguration(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            if (configurationString == null || configurationString.Length == 0)
            {
                config.LoadXml(Properties.Resources.RegistryQueryCollectorDefaultConfig);
            }
            else
            {
                config.LoadXml(configurationString);
            }
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement queryNode in root.SelectNodes("queries/query"))
            {
                RegistryQueryInstance queryEntry = new RegistryQueryInstance();
                queryEntry.Name = queryNode.ReadXmlElementAttr("name", "");
                queryEntry.UseRemoteServer = bool.Parse(queryNode.ReadXmlElementAttr("useRemoteServer", "False"));
                queryEntry.Server = queryNode.ReadXmlElementAttr("server", "");
                queryEntry.RegistryHive = RegistryQueryInstance.GetRegistryHiveFromString(queryNode.ReadXmlElementAttr("registryHive", ""));
                queryEntry.Path = queryNode.ReadXmlElementAttr("path", "");
                queryEntry.KeyName = queryNode.ReadXmlElementAttr("keyName", "");
                queryEntry.ExpandEnvironmentNames = bool.Parse(queryNode.ReadXmlElementAttr("expandEnvironmentNames", "False"));

                queryEntry.ReturnValueIsNumber = bool.Parse(queryNode.ReadXmlElementAttr("returnValueIsNumber", "False"));
                queryEntry.SuccessValue = queryNode.ReadXmlElementAttr("successValue", "");
                queryEntry.WarningValue = queryNode.ReadXmlElementAttr("warningValue", "");
                queryEntry.ErrorValue = queryNode.ReadXmlElementAttr("errorValue", "");
                queryEntry.ReturnValueInARange = bool.Parse(queryNode.ReadXmlElementAttr("returnValueInARange", "False"));
                queryEntry.ReturnValueInverted = bool.Parse(queryNode.ReadXmlElementAttr("returnValueInverted", "False"));
                Entries.Add(queryEntry);
            }
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.RegistryQueryCollectorDefaultConfig);
            XmlElement root = config.DocumentElement;
            XmlNode queriesNode = root.SelectSingleNode("queries");
            queriesNode.InnerXml = "";

            foreach (RegistryQueryInstance queryEntry in Entries)
            {
                XmlElement queryNode = config.CreateElement("query");
                queryNode.SetAttributeValue("name", queryEntry.Name);
                queryNode.SetAttributeValue("useRemoteServer", queryEntry.UseRemoteServer);
                queryNode.SetAttributeValue("server", queryEntry.Server);
                queryNode.SetAttributeValue("registryHive", queryEntry.RegistryHive.ToString());
                queryNode.SetAttributeValue("path", queryEntry.Path);
                queryNode.SetAttributeValue("keyName", queryEntry.KeyName);
                queryNode.SetAttributeValue("expandEnvironmentNames", queryEntry.ExpandEnvironmentNames);
                queryNode.SetAttributeValue("returnValueIsNumber", queryEntry.ReturnValueIsNumber);
                queryNode.SetAttributeValue("successValue", queryEntry.SuccessValue);
                queryNode.SetAttributeValue("warningValue", queryEntry.WarningValue);
                queryNode.SetAttributeValue("errorValue", queryEntry.ErrorValue);
                queryNode.SetAttributeValue("returnValueInARange", queryEntry.ReturnValueInARange);
                queryNode.SetAttributeValue("returnValueInverted", queryEntry.ReturnValueInverted);
                queriesNode.AppendChild(queryNode);
            }
            return config.OuterXml;
        }
        #endregion
    }
}
