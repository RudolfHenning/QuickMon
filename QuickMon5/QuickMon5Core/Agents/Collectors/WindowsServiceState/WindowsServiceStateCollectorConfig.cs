using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class WindowsServiceStateCollectorConfig : ICollectorConfig
    {
        public WindowsServiceStateCollectorConfig()
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
            foreach (XmlElement machine in root.SelectNodes("machine"))
            {
                WindowsServiceStateHostEntry serviceStateDefinition = new WindowsServiceStateHostEntry();
                serviceStateDefinition.MachineName = machine.Attributes.GetNamedItem("name").Value;
                serviceStateDefinition.SubItems = new List<ICollectorConfigSubEntry>();
                foreach (XmlElement service in machine.SelectNodes("service"))
                {
                    serviceStateDefinition.SubItems.Add(new WindowsServiceStateServiceEntry() { Description = service.Attributes.GetNamedItem("name").Value });
                }
                Entries.Add(serviceStateDefinition);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlNode root = config.SelectSingleNode("config");
            foreach (WindowsServiceStateHostEntry ssd in Entries)
            {
                XmlNode machineXmlNode = config.CreateElement("machine");
                XmlAttribute machineNameXmlAttribute = config.CreateAttribute("name");
                machineNameXmlAttribute.Value = ssd.MachineName;
                machineXmlNode.Attributes.Append(machineNameXmlAttribute);

                foreach (WindowsServiceStateServiceEntry serviceEntry in ssd.SubItems)
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
        public string GetDefaultOrEmptyXml()
        {
            return "<config></config>";
        }
        public string ConfigSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("{0} host(s): ", Entries.Count));
                if (Entries.Count == 0)
                    sb.Append("None");
                else
                {
                    foreach (ICollectorConfigEntry entry in Entries)
                    {
                        sb.Append(string.Format("{0} ({1} Services), ", entry.Description, entry.SubItems.Count));
                    }
                }
                return sb.ToString().TrimEnd(' ', ',');
            }
        }
        #endregion
    }
}
