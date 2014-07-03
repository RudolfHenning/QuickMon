using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class NotifierEntry
    {
        public NotifierEntry()
        {
            AlertForCollectors = new List<string>();
            AttendedOptionOverride = AttendedOption.AttendedAndUnAttended;
            Enabled = true;
            AlertLevel = AlertLevel.Warning;
            DetailLevel = DetailLevel.Detail;
            ConfigVariables = new List<ConfigVariable>();
        }

        #region Properties
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public string NotifierRegistrationName { get; set; }
        public INotifier Notifier { get; set; }
        public AlertLevel AlertLevel { get; set; }
        public DetailLevel DetailLevel { get; set; }
        public string InitialConfiguration { get; set; }
        public List<string> AlertForCollectors { get; private set; }
        public AttendedOption AttendedOptionOverride { get; set; }
        #region Dynamic Config Variables
        public List<ConfigVariable> ConfigVariables { get; set; }
        #endregion
        #endregion

        #region Create Notifier Instance
        public void CreateAndConfigureEntry(string agentClassName, bool useConfigVars = true, string overrideWithConfig = "")
        {
            RegisteredAgent ra = null;
            ra = (from a in RegisteredAgentCache.Agents
                  where a.IsNotifier && a.ClassName.EndsWith(agentClassName)
                  orderby a.Name
                  select a).FirstOrDefault();
            if (ra == null) //in case agent is not loaded or available
                throw new Exception("Notifier '" + Name + "' with type of '" + agentClassName + "' cannot be loaded! No Assembly of this Agent type found!");
            else
            {
                if (overrideWithConfig.Trim().Length > 0)
                    Notifier = CreateAndConfigureEntry(ra, overrideWithConfig, (useConfigVars ? ConfigVariables : null));
                else if (InitialConfiguration != null && InitialConfiguration.Length > 0)
                    Notifier = CreateAndConfigureEntry(ra, InitialConfiguration, (useConfigVars ? ConfigVariables : null));
                else
                {
                    Notifier = CreateAndConfigureEntry(ra, "", (useConfigVars ? ConfigVariables : null));
                }
                NotifierRegistrationName = ra.Name;
                if (InitialConfiguration == null && InitialConfiguration.Length == 0)
                    InitialConfiguration = overrideWithConfig.Trim().Length == 0 ? Notifier.GetDefaultOrEmptyConfigString() : overrideWithConfig;
            }
        }
        private INotifier CreateAndConfigureEntry(RegisteredAgent ra, string appliedConfig = "", List<ConfigVariable> configVariables = null)
        {
            INotifier newEntry = CreateNotifierEntry(ra);
            if (newEntry != null)
            {
                if (appliedConfig.Length == 0)
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
