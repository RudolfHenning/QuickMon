using QuickMon.MeansurementUnits;
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
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        #region IAgentConfig Members
        public void FromXml(string configurationString)
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
                directoryFilterEntry.FilesExistOnly = bool.Parse(host.ReadXmlElementAttr("testFilesExistOnly", "False"));
                directoryFilterEntry.ErrorOnFilesExist = bool.Parse(host.ReadXmlElementAttr("errorOnFilesExist", "False"));
                directoryFilterEntry.ContainsText = host.ReadXmlElementAttr("containsText", "");
                directoryFilterEntry.UseRegEx = host.ReadXmlElementAttr("useRegEx", false);

                int tmp = 0;
                if (int.TryParse(host.ReadXmlElementAttr("warningFileCountMax", "0"), out tmp))
                    directoryFilterEntry.CountWarningIndicator = tmp;
                if (int.TryParse(host.ReadXmlElementAttr("errorFileCountMax", "0"), out tmp))
                    directoryFilterEntry.CountErrorIndicator = tmp;
                long tmpl;

                directoryFilterEntry.FileSizeIndicatorUnit = (FileSizeUnits)Enum.Parse(typeof(FileSizeUnits), host.ReadXmlElementAttr("fileSizeIndicatorUnit", "KB"));
                if (long.TryParse(host.ReadXmlElementAttr("warningFileSizeMax", "0"), out tmpl))
                    directoryFilterEntry.SizeWarningIndicator = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("errorFileSizeMax", "0"), out tmpl))
                    directoryFilterEntry.SizeErrorIndicator = tmpl;

                directoryFilterEntry.FileAgeUnit = (TimeUnits)Enum.Parse(typeof(TimeUnits), host.ReadXmlElementAttr("fileAgeUnit", "Minute"));
                if (long.TryParse(host.ReadXmlElementAttr("fileMinAge", "0"), out tmpl))
                    directoryFilterEntry.FileMinAge = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("fileMaxAge", "0"), out tmpl))
                    directoryFilterEntry.FileMaxAge = tmpl;
                directoryFilterEntry.FileSizeUnit = (FileSizeUnits)Enum.Parse(typeof(FileSizeUnits), host.ReadXmlElementAttr("fileSizeUnit", "KB"));
                if (long.TryParse(host.ReadXmlElementAttr("fileMinSize", "0"), out tmpl))
                    directoryFilterEntry.FileMinSize = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("fileMaxSize", "0"), out tmpl))
                    directoryFilterEntry.FileMaxSize = tmpl;

                directoryFilterEntry.ShowFilenamesInDetails = host.ReadXmlElementAttr("showFilenamesInDetails", false);

                Entries.Add(directoryFilterEntry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlNode directoryList = config.SelectSingleNode("config/directoryList");
            foreach (FileSystemDirectoryFilterEntry de in Entries)
            {
                XmlNode directoryXmlNode = config.CreateElement("directory");

                directoryXmlNode.SetAttributeValue("directoryPathFilter", de.FilterFullPath);
                directoryXmlNode.SetAttributeValue("testDirectoryExistOnly", de.DirectoryExistOnly);
                directoryXmlNode.SetAttributeValue("testFilesExistOnly", de.FilesExistOnly);
                directoryXmlNode.SetAttributeValue("errorOnFilesExist", de.ErrorOnFilesExist);
                directoryXmlNode.SetAttributeValue("containsText", de.ContainsText);
                directoryXmlNode.SetAttributeValue("useRegEx", de.UseRegEx);
                directoryXmlNode.SetAttributeValue("warningFileCountMax", de.CountWarningIndicator);
                directoryXmlNode.SetAttributeValue("errorFileCountMax", de.CountErrorIndicator);
                directoryXmlNode.SetAttributeValue("fileSizeIndicatorUnit", de.FileSizeIndicatorUnit.ToString());
                directoryXmlNode.SetAttributeValue("warningFileSizeMax", de.SizeWarningIndicator);
                directoryXmlNode.SetAttributeValue("errorFileSizeMax", de.SizeErrorIndicator);
                directoryXmlNode.SetAttributeValue("fileAgeUnit", de.FileAgeUnit.ToString());
                directoryXmlNode.SetAttributeValue("fileMinAge", de.FileMinAge);
                directoryXmlNode.SetAttributeValue("fileMaxAge", de.FileMaxAge);
                directoryXmlNode.SetAttributeValue("fileSizeUnit", de.FileSizeUnit.ToString());
                directoryXmlNode.SetAttributeValue("fileMinSize", de.FileMinSize);
                directoryXmlNode.SetAttributeValue("fileMaxSize", de.FileMaxSize);
                directoryXmlNode.SetAttributeValue("showFilenamesInDetails", de.ShowFilenamesInDetails);

                directoryList.AppendChild(directoryXmlNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config><directoryList></directoryList></config>";
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
