using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class IISAppPoolCollectorConfig : ICollectorConfig
    {
        public IISAppPoolCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public bool CanEdit { get { return true; } }
        public ConfigEntryType ConfigEntryType { get { return QuickMon.ConfigEntryType.Tree; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        #region IAgentConfig Members

        public void ReadConfiguration(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            Entries.Clear();
            XmlElement root = config.DocumentElement;
            foreach (XmlElement machine in root.SelectNodes("machine"))
            {
                IISAppPoolMachine serviceStateDefinition = new IISAppPoolMachine();
                serviceStateDefinition.MachineName = machine.ReadXmlElementAttr("name", "");
                serviceStateDefinition.UsePerfCounter = machine.ReadXmlElementAttr("usePerfCounter", false);
                serviceStateDefinition.SubItems = new List<ICollectorConfigSubEntry>();
                foreach (XmlElement service in machine.SelectNodes("appPool"))
                {
                    serviceStateDefinition.SubItems.Add(new IISAppPoolEntry() { Description = service.Attributes.GetNamedItem("name").Value });
                }
                Entries.Add(serviceStateDefinition);
            }
        }

        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml("<config></config>");
            XmlNode root = config.SelectSingleNode("config");
            foreach (IISAppPoolMachine ssd in Entries)
            {
                XmlNode machineXmlNode = config.CreateElement("machine");
                machineXmlNode.SetAttributeValue("name", ssd.MachineName);
                machineXmlNode.SetAttributeValue("usePerfCounter", ssd.UsePerfCounter);
                foreach (IISAppPoolEntry serviceEntry in ssd.SubItems)
                {
                    XmlNode serviceXmlNode = config.CreateElement("appPool");
                    serviceXmlNode.SetAttributeValue("name", serviceEntry.Description);
                    machineXmlNode.AppendChild(serviceXmlNode);
                }
                root.AppendChild(machineXmlNode);
            }
            return config.OuterXml;
        }

        #endregion
    }
}
