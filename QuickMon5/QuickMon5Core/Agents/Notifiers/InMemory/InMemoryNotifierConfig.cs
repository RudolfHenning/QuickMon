using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Notifiers
{
    public class InMemoryNotifierConfig : INotifierConfig
    {
        public int MaxEntryCount { get; set; }

        #region INotifierConfig Members
        public string ConfigSummary
        {
            get
            {
                string summary = "Max entry count: " + MaxEntryCount.ToString();
                return summary;
            }
        }
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
            XmlNode inMemoryNode = root.SelectSingleNode("inMemory");
            MaxEntryCount = int.Parse(inMemoryNode.Attributes.GetNamedItem("maxEntryCount").Value);
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode inMemoryNode = root.SelectSingleNode("inMemory");
            inMemoryNode.SetAttributeValue("maxEntryCount", MaxEntryCount.ToString());
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config>\r\n<inMemory maxEntryCount=\"99999\" />\r\n</config>";
        }
        #endregion
    }
}
