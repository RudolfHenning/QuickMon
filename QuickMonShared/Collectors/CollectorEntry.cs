using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;

namespace QuickMon
{
    public class CollectorEntry
    {
        #region Properties
        public string Name { get; set; }
        public string UniqueId { get; set; }
        /// <summary>
        /// User/config based setting to disable this CollectorEntry
        /// </summary>
        public bool Enabled { get; set; }
        public bool IsFolder { get; set; }
        public string CollectorRegistrationName { get; set; }
        public ICollector Collector { get; set; }
        public string Configuration { get; set; }
        public string ParentCollectorId { get; set; }
        public bool CollectOnParentWarning { get; set; }
        public MonitorStates LastMonitorState { get; set; }
        public CollectorMessage LastMonitorDetails { get; set; }
        public DateTime LastStateChange { get; set; }
        public int RepeatAlertInXMin { get; set; }
        public ServiceWindows ServiceWindows { get; set; }
        public int AlertOnceInXMin { get; set; }
        public DateTime LastAlertTime { get; set; }
        /// <summary>
        /// Any object you wish to link with this instance
        /// </summary>
        public object Tag { get; set; }
        #endregion

        #region Get/Set configuration
        public static CollectorEntry FromConfig(XmlElement xmlCollectorEntry)
        {
            CollectorEntry collectorEntry = new CollectorEntry();
            collectorEntry.LastStateChange = DateTime.Now;
            collectorEntry.Name = xmlCollectorEntry.ReadXmlElementAttr("name", "").Trim();
            collectorEntry.UniqueId = xmlCollectorEntry.ReadXmlElementAttr("uniqueID", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            collectorEntry.Enabled = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("enabled", "True"));
            collectorEntry.IsFolder = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("isFolder", "False"));
            collectorEntry.ParentCollectorId = xmlCollectorEntry.ReadXmlElementAttr("dependOnParent");

            //Service windows config
            collectorEntry.ServiceWindows = new ServiceWindows();
            XmlNode serviceWindowsNode = xmlCollectorEntry.SelectSingleNode("serviceWindows");
            if (serviceWindowsNode != null) //Load service windows info
                collectorEntry.ServiceWindows.CreateFromConfig(serviceWindowsNode.OuterXml);

            if (!collectorEntry.IsFolder)
            {
                collectorEntry.CollectorRegistrationName = xmlCollectorEntry.ReadXmlElementAttr("collector", "No collector");
                collectorEntry.CollectOnParentWarning = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("collectOnParentWarning", "False"));
                collectorEntry.RepeatAlertInXMin = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("repeatAlertInXMin", "0"));
                collectorEntry.AlertOnceInXMin = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("alertOnceInXMin", "0"));
                collectorEntry.LastAlertTime = new DateTime(2000, 1, 1); //long ago
                XmlNode configNode = xmlCollectorEntry.SelectSingleNode("config");
                if (configNode != null)
                    collectorEntry.Configuration = configNode.OuterXml;
                else
                    collectorEntry.Configuration = "";                

                collectorEntry.LastMonitorState = MonitorStates.NotAvailable;
            }
            else
            {
                collectorEntry.CollectorRegistrationName = "Folder";
                collectorEntry.Configuration = "";
                collectorEntry.LastMonitorState = MonitorStates.Folder;
            }
            
            collectorEntry.LastMonitorDetails = new CollectorMessage();
            return collectorEntry;
        }
        public string ToConfig()
        {
            string config = string.Format(Properties.Resources.CollectorEntryXml,
                UniqueId,
                Name.EscapeXml(),
                Enabled,
                IsFolder,
                CollectorRegistrationName,
                ParentCollectorId,
                CollectOnParentWarning,                
                RepeatAlertInXMin,
                AlertOnceInXMin,
                Configuration,
                ServiceWindows.ToConfig());
            return config;
        }
        #endregion

        public static ICollector CreateCollectorEntry(string assemblyPath, string className)
        {
            Assembly collectorEntryAssembly = Assembly.LoadFile(assemblyPath);
            ICollector newCollectorEntry = (ICollector)collectorEntryAssembly.CreateInstance(className);
            newCollectorEntry.LastDetailMsg = new CollectorMessage("");
            return newCollectorEntry;
        }

        public void ShowStatusDetails()
        {
            Collector.ShowStatusDetails();
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, CollectorRegistrationName);
        }
    }
}
