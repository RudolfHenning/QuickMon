using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class RegistryQueryConfig
    {
        public RegistryQueryConfig()
        {
            Queries = new List<RegistryQueryInstance>();
        }
        public List<RegistryQueryInstance> Queries { get; set; }

        public void ReadConfiguration(XmlDocument config)
        {
            XmlElement root = config.DocumentElement;
            Queries.Clear();
            foreach (XmlElement queryNode in root.SelectNodes("queries/query"))
            {
                RegistryQueryInstance queryEntry = new RegistryQueryInstance();
                queryEntry.Name = queryNode.ReadXmlElementAttr("name", "");
                queryEntry.UseRemoteServer = bool.Parse(queryNode.ReadXmlElementAttr("useRemoteServer", "False"));
                queryEntry.Server = queryNode.ReadXmlElementAttr("server", "");
                queryEntry.RegistryHive = RegistryQueryInstance.GetRegistryHiveFromString(queryNode.ReadXmlElementAttr("registryHive", ""));
                queryEntry.Path = queryNode.ReadXmlElementAttr("path", "");
                queryEntry.KeyName = queryNode.ReadXmlElementAttr("keyName", "");

                queryEntry.ReturnValueIsNumber = bool.Parse(queryNode.ReadXmlElementAttr("returnValueIsNumber", "False"));
                queryEntry.SuccessValue = queryNode.ReadXmlElementAttr("successValue", "");
                queryEntry.WarningValue = queryNode.ReadXmlElementAttr("warningValue", ""); 
                queryEntry.ErrorValue = queryNode.ReadXmlElementAttr("errorValue", "");
                queryEntry.ReturnValueInARange = bool.Parse(queryNode.ReadXmlElementAttr("returnValueInARange","False"));
                queryEntry.ReturnValueInverted = bool.Parse(queryNode.ReadXmlElementAttr("returnValueInverted", "False"));
                Queries.Add(queryEntry);
            }
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.RegistryQueryEmptyConfig);
            XmlElement root = config.DocumentElement;
            XmlNode queriesNode = root.SelectSingleNode("queries");
            queriesNode.InnerXml = "";

            foreach (RegistryQueryInstance queryEntry in Queries)
            {
                XmlElement queryNode = config.CreateElement("query");
                queryNode.SetAttributeValue("name", queryEntry.Name);
                queryNode.SetAttributeValue("useRemoteServer", queryEntry.UseRemoteServer);
                queryNode.SetAttributeValue("server", queryEntry.Server);
                queryNode.SetAttributeValue("registryHive", queryEntry.RegistryHive.ToString());
                queryNode.SetAttributeValue("path", queryEntry.Path);
                queryNode.SetAttributeValue("keyName", queryEntry.KeyName);
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
    }
}
