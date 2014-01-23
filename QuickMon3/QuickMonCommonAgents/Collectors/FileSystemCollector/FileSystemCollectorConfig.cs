using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class FileSystemCollectorConfig : ICollectorConfig
    {
        public FileSystemCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public List<ICollectorConfigEntry> Entries { get; set; }
        public ConfigEntryType ConfigEntryType { get { return QuickMon.ConfigEntryType.Multiple; } }
        public bool CanEdit { get { return true; } }
        #endregion

        //public List<FileSystemDirectoryFilterEntry> Entries = new List<FileSystemDirectoryFilterEntry>();

        #region IAgentConfig Members
        public void ReadConfiguration(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            Entries.Clear();
            System.Xml.XmlElement root = config.DocumentElement;
            foreach (System.Xml.XmlElement host in root.SelectNodes("directoryList/directory"))
            {
                FileSystemDirectoryFilterEntry directoryFilterEntry = new FileSystemDirectoryFilterEntry();
                directoryFilterEntry.FilterFullPath = host.Attributes.GetNamedItem("directoryPathFilter").Value;
                directoryFilterEntry.DirectoryExistOnly = bool.Parse(host.ReadXmlElementAttr("testDirectoryExistOnly", "False"));

                int tmp = 0;
                if (int.TryParse(host.ReadXmlElementAttr("warningFileCountMax", "0"), out tmp))
                    directoryFilterEntry.CountWarningIndicator = tmp;
                if (int.TryParse(host.ReadXmlElementAttr("errorFileCountMax", "0"), out tmp))
                    directoryFilterEntry.CountErrorIndicator = tmp;
                long tmpl;

                if (long.TryParse(host.ReadXmlElementAttr("warningFileSizeMaxKB", "0"), out tmpl))
                    directoryFilterEntry.SizeKBWarningIndicator = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("errorFileSizeMaxKB", "0"), out tmpl))
                    directoryFilterEntry.SizeKBErrorIndicator = tmpl;

                if (long.TryParse(host.ReadXmlElementAttr("fileMaxAgeSec", "0"), out tmpl))
                    directoryFilterEntry.FileMaxAgeSec = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("fileMinAgeSec", "0"), out tmpl))
                    directoryFilterEntry.FileMinAgeSec = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("fileMinSizeKB", "0"), out tmpl))
                    directoryFilterEntry.FileMinSizeKB = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("fileMaxSizeKB", "0"), out tmpl))
                    directoryFilterEntry.FileMaxSizeKB = tmpl;

                Entries.Add(directoryFilterEntry);
            }
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml("<config><directoryList></directoryList></config>");
            XmlNode directoryList = config.SelectSingleNode("config/directoryList");
            foreach (FileSystemDirectoryFilterEntry de in Entries)
            {
                XmlNode directoryXmlNode = config.CreateElement("directory");

                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("directoryPathFilter", de.FilterFullPath));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("testDirectoryExistOnly", de.DirectoryExistOnly));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("warningFileCountMax", de.CountWarningIndicator));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("errorFileCountMax", de.CountErrorIndicator));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("warningFileSizeMaxKB", de.SizeKBWarningIndicator));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("errorFileSizeMaxKB", de.SizeKBErrorIndicator));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("fileMinAgeSec", de.FileMinAgeSec));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("fileMaxAgeSec", de.FileMaxAgeSec));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("fileMinSizeKB", de.FileMinSizeKB));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("fileMaxSizeKB", de.FileMaxSizeKB));

                directoryList.AppendChild(directoryXmlNode);
            }

            return config.OuterXml;
        }
        #endregion
    }
}
