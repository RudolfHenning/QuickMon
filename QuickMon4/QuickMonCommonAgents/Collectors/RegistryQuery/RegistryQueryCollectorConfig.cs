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
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            if (configurationString == null || configurationString.Length == 0)
            {
                config.LoadXml(GetDefaultOrEmptyXml());
            }
            else
            {
                config.LoadXml(configurationString);
            }
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement queryNode in root.SelectNodes("queries/query"))
            {
                RegistryQueryCollectorConfigEntry queryEntry = new RegistryQueryCollectorConfigEntry();
                queryEntry.Name = queryNode.ReadXmlElementAttr("name", "");
                queryEntry.UseRemoteServer = bool.Parse(queryNode.ReadXmlElementAttr("useRemoteServer", "False"));
                queryEntry.Server = queryNode.ReadXmlElementAttr("server", "");
                queryEntry.RegistryHive = RegistryQueryCollectorConfigEntry.GetRegistryHiveFromString(queryNode.ReadXmlElementAttr("registryHive", ""));
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

        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode queriesNode = root.SelectSingleNode("queries");
            queriesNode.InnerXml = "";

            foreach (RegistryQueryCollectorConfigEntry queryEntry in Entries)
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

        public string GetDefaultOrEmptyXml()
        {
            return "<config><queries></queries></config>";
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
