using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class NotifierEntry : AgentHostEntryBase
    {
        public NotifierEntry()
        {
            ServiceWindows = new ServiceWindows();
            ServiceWindows.CreateFromConfig("<serviceWindows/>");
            AlertForCollectors = new List<string>();
            AttendedOptionOverride = AttendedOption.AttendedAndUnAttended;
            Enabled = true;
            AlertLevel = AlertLevel.Warning;
            DetailLevel = DetailLevel.Detail;
            ConfigVariables = new List<ConfigVariable>();
        }

        #region Properties
        //public string Name { get; set; }
        #region Is this notifier entry enabled now
        //public bool Enabled { get; set; }
        /// <summary>
        /// List if service windows when collector can operate
        /// </summary>
        //public ServiceWindows ServiceWindows { get; set; }
        //public bool IsEnabledNow()
        //{
        //    if (Enabled)
        //    {
        //        if (ServiceWindows.IsInTimeWindow())
        //            return true;
        //        else
        //            return false;
        //    }
        //    else
        //        return false;
        //}
        #endregion

        public string NotifierRegistrationName { get; set; }
        public INotifier Notifier { get; set; }
        public AlertLevel AlertLevel { get; set; }
        public DetailLevel DetailLevel { get; set; }
        public string InitialConfiguration { get; set; }
        public List<string> AlertForCollectors { get; private set; }
        public AttendedOption AttendedOptionOverride { get; set; }
        //#region Dynamic Config Variables
        //public List<ConfigVariable> ConfigVariables { get; set; }
        //#endregion
        #endregion

        #region Create Notifier Instance
        public void CreateAndConfigureEntry(string agentClassName, string overrideWithConfig = "", bool setAsInitialConfig = false, bool useConfigVars = true)
        {
            RegisteredAgent ra = null;
            ra = RegisteredAgentCache.GetRegisteredAgentByClassName(agentClassName, false);
            if (ra == null) //in case agent is not loaded or available
                throw new Exception("Notifier '" + Name + "' with type of '" + agentClassName + "' cannot be loaded! No Assembly of this Agent type found!");
            else
            {
                string appliedConfig = "";
                if (overrideWithConfig != null && overrideWithConfig.Trim().Length > 0)
                    appliedConfig = FormatUtils.N(overrideWithConfig);
                else
                    appliedConfig = FormatUtils.N(InitialConfiguration);
                //Create Notifier instance
                Notifier = CreateAndConfigureEntry(ra, appliedConfig, (useConfigVars ? ConfigVariables : null));
                if (setAsInitialConfig)
                {
                    if (overrideWithConfig != null && overrideWithConfig.Length > 0)
                        InitialConfiguration = overrideWithConfig;
                    else if (Notifier != null)
                        InitialConfiguration = Notifier.GetDefaultOrEmptyConfigString();
                }
                NotifierRegistrationName = ra.Name;                
            }
        }
        private INotifier CreateAndConfigureEntry(RegisteredAgent ra, string appliedConfig, List<ConfigVariable> configVariables)
        {
            INotifier newEntry = CreateNotifierEntry(ra);
            if (newEntry != null)
            {
                if (appliedConfig == null || appliedConfig.Length == 0)
                    appliedConfig = newEntry.GetDefaultOrEmptyConfigString();
                if (configVariables != null && configVariables.Count > 0)
                {
                    foreach (ConfigVariable vc in configVariables)
                        if (vc.Name.Length > 0)
                            appliedConfig = appliedConfig.Replace(vc.Name, vc.Value);
                }
                newEntry.AgentConfig.ReadConfiguration(appliedConfig);
            }
            return newEntry;
        }
        public static INotifier CreateNotifierEntry(RegisteredAgent ra)
        {
            if (ra != null)
            {
                return CreateNotifierEntry(ra.AssemblyPath, ra.ClassName);
            }
            else
                return null;
        }
        private static INotifier CreateNotifierEntry(string assemblyPath, string className)
        {
            Assembly notifierEntryAssembly = Assembly.LoadFile(assemblyPath);
            INotifier newNotifierEntry = (INotifier)notifierEntryAssembly.CreateInstance(className);
            return newNotifierEntry;
        }
        #endregion

        #region Get/Set configuration
        public static NotifierEntry FromConfig(string stringNotifierEntry)
        {
            XmlDocument xmlCollectorEntry = new XmlDocument();
            xmlCollectorEntry.LoadXml(stringNotifierEntry);
            return FromConfig(xmlCollectorEntry.DocumentElement);
        }
        public static NotifierEntry FromConfig(XmlElement xmlNotifierEntry)
        {
            NotifierEntry notifierEntry = new NotifierEntry();
            notifierEntry.Name = xmlNotifierEntry.ReadXmlElementAttr("name");
            notifierEntry.NotifierRegistrationName = xmlNotifierEntry.ReadXmlElementAttr("notifier");
            notifierEntry.Enabled = xmlNotifierEntry.ReadXmlElementAttr("enabled", false);
            notifierEntry.AlertLevel = (AlertLevel)Enum.Parse(typeof(AlertLevel), xmlNotifierEntry.ReadXmlElementAttr("alertLevel", "Warning"));
            notifierEntry.DetailLevel = (DetailLevel)Enum.Parse(typeof(DetailLevel), xmlNotifierEntry.ReadXmlElementAttr("detailLevel", "Detail"));
            notifierEntry.AttendedOptionOverride = (AttendedOption)Enum.Parse(typeof(AttendedOption), xmlNotifierEntry.ReadXmlElementAttr("attendedOptionOverride", "AttendedAndUnAttended"));
            if (xmlNotifierEntry.SelectSingleNode("config") != null)
                notifierEntry.InitialConfiguration = xmlNotifierEntry.SelectSingleNode("config").OuterXml;

            //Service windows config
            notifierEntry.ServiceWindows = new ServiceWindows();
            XmlNode serviceWindowsNode = xmlNotifierEntry.SelectSingleNode("serviceWindows");
            if (serviceWindowsNode != null) //Load service windows info
                notifierEntry.ServiceWindows.CreateFromConfig(serviceWindowsNode.OuterXml);
            else
            {
                notifierEntry.ServiceWindows.CreateFromConfig("<serviceWindows />");
            }

            XmlNode collectorsNode = xmlNotifierEntry.SelectSingleNode("collectors");
            if (collectorsNode != null)
            {
                foreach (XmlElement colNode in collectorsNode.SelectNodes("collector"))
                {
                    string collectorName = colNode.ReadXmlElementAttr("name", "");
                    if (collectorName.Length > 0)
                        notifierEntry.AlertForCollectors.Add(collectorName);
                }
            }
            XmlNode configVarsNode = xmlNotifierEntry.SelectSingleNode("configVars");
            if (configVarsNode != null)
            {
                foreach (XmlNode configVarNode in configVarsNode.SelectNodes("configVar"))
                {
                    notifierEntry.ConfigVariables.Add(ConfigVariable.FromXml(configVarNode.OuterXml));
                }
            }
            return notifierEntry;
        }
        public string ToConfig()
        {
            StringBuilder configVarXml = new StringBuilder();
            configVarXml.AppendLine("<configVars>");
            foreach (ConfigVariable cv in ConfigVariables)
            {
                configVarXml.AppendLine(cv.ToXml());
            }
            configVarXml.AppendLine("</configVars>");
            string config = string.Format(Properties.Resources.NotifierEntryXml,
                Name.EscapeXml(),
                NotifierRegistrationName,
                Enabled,
                Enum.GetName(typeof(QuickMon.AlertLevel), this.AlertLevel),
                Enum.GetName(typeof(QuickMon.DetailLevel), this.DetailLevel),
                AttendedOptionOverride.ToString(),
                InitialConfiguration,
                ServiceWindows.ToConfig(),
                AlertForCollectorsConfig(),
                configVarXml.ToString()
                );
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

        #region Viewer
        private INotivierViewer notifierViewer = null;
        public void ShowViewer()
        {
            if (Notifier != null && Notifier.HasViewer)
            {
                if (notifierViewer == null || (!notifierViewer.IsStillVisible()))
                {
                    notifierViewer = Notifier.GetNotivierViewer();
                    notifierViewer.SetWindowTitle(Name + " (" + this.NotifierRegistrationName + ")");
                    notifierViewer.ShowNotifierViewer(Notifier);
                }
                else
                {
                    notifierViewer.RefreshConfig(Notifier);
                }
            }
        }
        public void CloseViewer()
        {
            if (Notifier != null && Notifier.HasViewer)
            {
                if (notifierViewer != null && (notifierViewer.IsStillVisible()))
                {
                    try
                    {
                        notifierViewer.CloseWindow();
                    }
                    catch { }
                }
            }
        }
        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}
