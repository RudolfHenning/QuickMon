using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;

namespace QuickMon
{
    public class NotifierEntry
    {
        public NotifierEntry()
        {
            AlertForCollectors = new List<string>();
        }

        #region Properties
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public string NotifierRegistrationName { get; set; }
        public INotifier Notifier { get; set; }
        public AlertLevel AlertLevel { get; set; }
        public DetailLevel DetailLevel { get; set; }
        public string Configuration { get; set; }
        public List<string> AlertForCollectors { get; private set; } 
        #endregion

        #region Get/Set configuration
        public static NotifierEntry FromConfig(XmlElement xmlNotifierEntry)
        {
            NotifierEntry notifierEntry = new NotifierEntry();
            notifierEntry.Name = xmlNotifierEntry.Attributes.GetNamedItem("name").Value;
            notifierEntry.NotifierRegistrationName = xmlNotifierEntry.Attributes.GetNamedItem("notifier").Value;
            notifierEntry.Enabled = bool.Parse(xmlNotifierEntry.Attributes.GetNamedItem("enabled").Value);
            notifierEntry.AlertLevel = (AlertLevel)Enum.Parse(typeof(AlertLevel), xmlNotifierEntry.Attributes.GetNamedItem("alertLevel").Value);
            notifierEntry.DetailLevel = (DetailLevel)Enum.Parse(typeof(DetailLevel), xmlNotifierEntry.Attributes.GetNamedItem("detailLevel").Value);
            notifierEntry.Configuration = xmlNotifierEntry.SelectSingleNode("config").OuterXml;

            XmlNode serviceWindowsNode = xmlNotifierEntry.SelectSingleNode("collectors");
            if (serviceWindowsNode != null)
            {
                foreach (XmlElement colNode in serviceWindowsNode.SelectNodes("collector"))
                {
                    string collectorName = colNode.ReadXmlElementAttr("name", "");
                    if (collectorName.Length > 0)
                        notifierEntry.AlertForCollectors.Add(collectorName);
                }
            }
            
            return notifierEntry;
        }
        public string ToConfig()
        {
            string config = string.Format(Properties.Resources.NotifierEntryXml,
                Name.EscapeXml(),
                NotifierRegistrationName,
                Enabled,
                Enum.GetName(typeof(QuickMon.AlertLevel), this.AlertLevel),
                Enum.GetName(typeof(QuickMon.DetailLevel), this.DetailLevel),
                Configuration,
                AlertForCollectorsConfig());
            return config;
        }

        private string AlertForCollectorsConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml("<collectors />");
            foreach (string c in AlertForCollectors)
            {
                XmlElement colNode = config.CreateElement("collector");
                colNode.SetAttributeValue("name", c);
                config.DocumentElement.AppendChild(colNode);
            }
            return config.OuterXml;
        }
        #endregion

        public static INotifier CreateNotifierEntry(string assemblyPath, string className)
        {
            Assembly notifierEntryAssembly = Assembly.LoadFile(assemblyPath);
            INotifier newNotifierEntry = (INotifier)notifierEntryAssembly.CreateInstance(className);
            return newNotifierEntry;
        }
        public void OpenViewer()
        {
            if (Notifier != null && Notifier.HasViewer)
            {
                Notifier.OpenViewer(Name);
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
