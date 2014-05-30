using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class PerfCounterCollectorConfig : ICollectorConfig
    {
        public PerfCounterCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }
        #region ICollectorConfig Members
        public List<ICollectorConfigEntry> Entries { get; set; }
        public ConfigEntryType ConfigEntryType { get { return QuickMon.ConfigEntryType.Multiple; } }
        public bool CanEdit { get { return true; } }
        #endregion

        //public List<PerfCounterCollectorEntry> Entries = new List<PerfCounterCollectorEntry>();

        //public PerfCounterCollectorConfig()
        //{
        //    Entries = new List<PerfCounterCollectorEntry>();
        //}

        #region IAgentConfig Members
        public void ReadConfiguration(string configurationString)
        {
            if (configurationString == null || configurationString.Length == 0)
                return;
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement pcNode in root.SelectNodes("performanceCounters/performanceCounter"))
            {
                PerfCounterCollectorEntry entry = new PerfCounterCollectorEntry();
                entry.Computer = pcNode.ReadXmlElementAttr("computer", ".");
                entry.Category = pcNode.ReadXmlElementAttr("category", "Processor");
                entry.Counter = pcNode.ReadXmlElementAttr("counter", "% Processor Time");
                entry.Instance = pcNode.ReadXmlElementAttr("instance", "");
                entry.ReturnValueInverted = bool.Parse(pcNode.ReadXmlElementAttr("returnValueInverted", "False"));
                entry.WarningValue = float.Parse(pcNode.ReadXmlElementAttr("warningValue", "80"));
                entry.ErrorValue = float.Parse(pcNode.ReadXmlElementAttr("errorValue", "100"));
                Entries.Add(entry);
            }
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.PerfCounterCollectorDefaultConfig);
            XmlElement root = config.DocumentElement;
            XmlNode performanceCountersNode = root.SelectSingleNode("performanceCounters");
            performanceCountersNode.InnerXml = "";
            foreach (PerfCounterCollectorEntry entry in Entries)
            {
                XmlElement performanceCounterNode = config.CreateElement("performanceCounter");
                performanceCounterNode.SetAttributeValue("computer", entry.Computer);
                performanceCounterNode.SetAttributeValue("category", entry.Category);
                performanceCounterNode.SetAttributeValue("counter", entry.Counter);
                performanceCounterNode.SetAttributeValue("instance", entry.Instance);
                performanceCounterNode.SetAttributeValue("returnValueInverted", entry.ReturnValueInverted);
                performanceCounterNode.SetAttributeValue("warningValue", entry.WarningValue);
                performanceCounterNode.SetAttributeValue("errorValue", entry.ErrorValue);
                performanceCountersNode.AppendChild(performanceCounterNode);
            }
            return config.OuterXml;
        }
        #endregion
    }
}
