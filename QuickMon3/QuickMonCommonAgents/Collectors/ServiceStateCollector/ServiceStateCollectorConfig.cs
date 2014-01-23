using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class ServiceStateCollectorConfig : ICollectorConfig
    {
        public ServiceStateCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }
        #region ICollectorConfig Members
        public List<ICollectorConfigEntry> Entries { get; set; }
        public ConfigEntryType ConfigEntryType { get { return QuickMon.ConfigEntryType.Tree; } }
        public bool CanEdit { get { return true; } }
        #endregion

        //public List<ServiceStateDefinition> Services { get; set; }

        #region IAgentConfig Members
        public void ReadConfiguration(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            Entries.Clear();
            XmlElement root = config.DocumentElement;
            foreach (XmlElement machine in root.SelectNodes("machine"))
            {
                ServiceStateDefinition serviceStateDefinition = new ServiceStateDefinition();
                serviceStateDefinition.MachineName = machine.Attributes.GetNamedItem("name").Value;
                serviceStateDefinition.SubItems = new List<ICollectorConfigSubEntry>();
                foreach (XmlElement service in machine.SelectNodes("service"))
                {
                    serviceStateDefinition.SubItems.Add(new ServiceStateServiceEntry() { Description = service.Attributes.GetNamedItem("name").Value });
                }
                Entries.Add(serviceStateDefinition);
            }
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml("<config></config>");
            XmlNode root = config.SelectSingleNode("config");
            foreach (ServiceStateDefinition ssd in Entries)
            {
                XmlNode machineXmlNode = config.CreateElement("machine");
                XmlAttribute machineNameXmlAttribute = config.CreateAttribute("name");
                machineNameXmlAttribute.Value = ssd.MachineName;
                machineXmlNode.Attributes.Append(machineNameXmlAttribute);

                foreach (ServiceStateServiceEntry serviceEntry in ssd.SubItems)
                {
                    XmlNode serviceXmlNode = config.CreateElement("service");
                    XmlAttribute nameXmlAttribute = config.CreateAttribute("name");
                    nameXmlAttribute.Value = serviceEntry.Description;
                    serviceXmlNode.Attributes.Append(nameXmlAttribute);
                    machineXmlNode.AppendChild(serviceXmlNode);
                }
                root.AppendChild(machineXmlNode);
            }
            return config.OuterXml;
        }
        #endregion


    }
}
