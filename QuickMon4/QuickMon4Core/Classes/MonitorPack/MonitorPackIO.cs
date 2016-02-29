using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public partial class MonitorPack
    {
        public class NameAndTypeSummary
        {
            public string Name { get; set; }
            public string Path { get; set; }
            public string TypeName { get; set; }
            public string Version { get; set; }
            public bool Enabled { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }

        public static NameAndTypeSummary GetMonitorPackTypeName(string filePath)
        {
            NameAndTypeSummary summaryInfo = new NameAndTypeSummary() { Name = System.IO.Path.GetFileNameWithoutExtension(filePath), Path = filePath,  Enabled = false, TypeName = "", Version = "4.0.0.0" };
            try
            {
                XmlDocument configurationXml = new XmlDocument();
                configurationXml.Load(filePath);
                XmlElement root = configurationXml.DocumentElement;
                summaryInfo.Name = root.ReadXmlElementAttr("name", System.IO.Path.GetFileNameWithoutExtension(filePath));
                if (summaryInfo.Name.Length == 0)
                    summaryInfo.Name = System.IO.Path.GetFileNameWithoutExtension(filePath);
                summaryInfo.TypeName = root.ReadXmlElementAttr("typeName", "");
                summaryInfo.Version = root.ReadXmlElementAttr("version", "4.0.0.0");
                summaryInfo.Enabled = root.ReadXmlElementAttr("enabled", true);
            }
            catch { }
            return summaryInfo;
        }

        private string emptyConfig = "<monitorPack>\r\n<configVars>\r\n</configVars>\r\n<collectorHosts>\r\n</collectorHosts>\r\n<notifierHosts>\r\n</notifierHosts>\r\n<logging>\r\n<collectorCategories/>\r\n</logging>\r\n</monitorPack>";

        #region Loading
        public void Load()
        {
            if (MonitorPackPath != null && MonitorPackPath.Length > 0 && System.IO.File.Exists(MonitorPackPath))
                Load(MonitorPackPath);
        }
        /// <summary>
        /// Loading QuickMon monitor pack file
        /// </summary>
        /// <param name="configurationFile">Serialzed monitor pack file</param>
        public void Load(string configurationFile)
        {
            LoadXml(System.IO.File.ReadAllText(configurationFile, Encoding.UTF8));
            MonitorPackPath = configurationFile;
            RaiseMonitorPackPathChanged(MonitorPackPath);
            WriteLogging("Monitor pack loaded");
        }
        public void LoadXml(string xmlConfig)
        {
            Stopwatch sw = new Stopwatch();
            XmlDocument configurationXml = new XmlDocument();
            sw.Start();
            configurationXml.LoadXml(xmlConfig);
            sw.Stop();
            System.Diagnostics.Trace.WriteLine(string.Format("MonitorPack Loading XML time:{0}ms", sw.ElapsedMilliseconds));

            sw.Reset();
            sw.Start();
            XmlElement root = configurationXml.DocumentElement;
            Name = root.Attributes.GetNamedItem("name").Value;
            TypeName = root.ReadXmlElementAttr("typeName", "");
            this.Version = root.ReadXmlElementAttr("version", "4.0.0.0");
            Enabled = root.ReadXmlElementAttr("enabled", true);
            CollectorStateHistorySize = root.ReadXmlElementAttr("stateHistorySize", 1);
            PollingFrequencyOverrideSec = root.ReadXmlElementAttr("pollingFreqSecOverride", 0);
            string defaultNotifierName = root.ReadXmlElementAttr("defaultNotifier");
            RunCorrectiveScripts = root.ReadXmlElementAttr("runCorrectiveScripts", true);
            LoggingEnabled = root.ReadXmlElementAttr("loggingEnabled", false);

            /***************** Load config variables ****************/
            #region Load config variables
            XmlNode configVarsNode = root.SelectSingleNode("configVars");
            ConfigVariables = new List<ConfigVariable>();
            if (configVarsNode != null)
            {
                foreach (XmlElement configVarNodeEntry in configVarsNode.SelectNodes("configVar"))
                {
                    ConfigVariables.Add(ConfigVariable.FromXml(configVarNodeEntry.OuterXml));
                }
            }
            #endregion
            /***************** Load Collectors ****************/
            #region Load Collectors
            XmlNode collectorHostsNode = root.SelectSingleNode("collectorHosts");
            if (collectorHostsNode != null)
            {
                CollectorHosts = CollectorHost.GetCollectorHostsFromString(collectorHostsNode.OuterXml, ConfigVariables);
                foreach (CollectorHost collectorHost in CollectorHosts)
                {
                    SetCollectorHostEvents(collectorHost);
                    //collectorHost.ParentMonitorPack = this;
                    //collectorHost.AlertGoodState += collectorHost_AlertGoodState;
                    //collectorHost.AlertWarningState += collectorHost_AlertWarningState;
                    //collectorHost.AlertErrorState += collectorHost_AlertErrorState;
                    //collectorHost.NoStateChanged += collectorHost_NoStateChanged;
                    //collectorHost.StateUpdated += collectorHost_StateUpdated;
                    //collectorHost.AllAgentsExecutionTime += collectorHost_AllAgentsExecutionTime;
                    //collectorHost.RunCollectorHostRestorationScript += collectorHost_RunCollectorHostRestorationScript;                    
                    //collectorHost.RunCollectorHostCorrectiveWarningScript += collectorHost_RunCollectorHostCorrectiveWarningScript;
                    //collectorHost.RunCollectorHostCorrectiveErrorScript += collectorHost_RunCollectorHostCorrectiveErrorScript;
                }
            }
            #endregion
            /***************** Load Notifiers ****************/
            #region Load Notifiers
            XmlNode notifierHostsNode = root.SelectSingleNode("notifierHosts");
            if (notifierHostsNode != null)
            {
                NotifierHosts = NotifierHost.GetNotifierHostsFromString(notifierHostsNode.OuterXml, ConfigVariables);
            }
            #endregion

            #region security
            UserNameCacheMasterKey = root.ReadXmlElementAttr("usernameCacheMasterKey", "");
            UserNameCacheFilePath = root.ReadXmlElementAttr("usernameCacheFilePath", "");
            #endregion

            #region Logging
            LoggingCollectorCategories = new List<string>();
            XmlNode loggingNode = root.SelectSingleNode("logging");
            if (loggingNode != null)
            {
                LoggingPath = loggingNode.ReadXmlElementAttr("loggingPath", "");
                LoggingCollectorEvents = loggingNode.ReadXmlElementAttr("loggingCollectorEvents", false);
                LoggingNotifierEvents = loggingNode.ReadXmlElementAttr("loggingNotifierEvents", false);
                LoggingAlertsRaised = loggingNode.ReadXmlElementAttr("loggingAlertsRaised", false);
                LoggingCorrectiveScriptRun = loggingNode.ReadXmlElementAttr("loggingCorrectiveScriptRun", false);
                LoggingPollingOverridesTriggered = loggingNode.ReadXmlElementAttr("loggingPollingOverridesTriggered", false);
                LoggingServiceWindowEvents = loggingNode.ReadXmlElementAttr("loggingServiceWindowEvents", false);
                LoggingKeepLogFilesXDays = loggingNode.ReadXmlElementAttr("loggingKeepLogFilesXDays", 180);
                
                XmlNode loggingCollectorCategoriesNode = loggingNode.SelectSingleNode("collectorCategories");
                if (loggingCollectorCategoriesNode != null)
                {
                    foreach (XmlNode categoryNode in loggingCollectorCategoriesNode.SelectNodes("category"))
                    {
                        LoggingCollectorCategories.Add(categoryNode.InnerText.UnEscapeXml());
                    }
                }
            }
            else
            {
                LoggingEnabled = false;
            }
            #endregion

            sw.Stop();
            System.Diagnostics.Trace.WriteLine(string.Format("MonitorPack Parsing XML time:{0}ms", sw.ElapsedMilliseconds));
            InitializeGlobalPerformanceCounters();
        }
        private void SetCollectorHostEvents(CollectorHost collectorHost)
        {
            collectorHost.ParentMonitorPack = this;
            collectorHost.AlertGoodState += collectorHost_AlertGoodState;
            collectorHost.AlertWarningState += collectorHost_AlertWarningState;
            collectorHost.AlertErrorState += collectorHost_AlertErrorState;
            collectorHost.NoStateChanged += collectorHost_NoStateChanged;
            collectorHost.StateUpdated += collectorHost_StateUpdated;
            collectorHost.AllAgentsExecutionTime += collectorHost_AllAgentsExecutionTime;
            collectorHost.RunCollectorHostRestorationScript += collectorHost_RunCollectorHostRestorationScript;
            collectorHost.RunCollectorHostCorrectiveWarningScript += collectorHost_RunCollectorHostCorrectiveWarningScript;
            collectorHost.RunCollectorHostCorrectiveErrorScript += collectorHost_RunCollectorHostCorrectiveErrorScript;
            collectorHost.LoggingPollingOverridesTriggeredEvent += collectorHost_LoggingPollingOverridesTriggeredEvent;
            collectorHost.EntereringServiceWindow += collectorHost_EntereringServiceWindow;
            collectorHost.ExitingServiceWindow += collectorHost_ExitingServiceWindow;

        }

        
        public void AddCollectorHost(CollectorHost collectorHost)
        {
            SetCollectorHostEvents(collectorHost);
            CollectorHosts.Add(collectorHost);
        }
        public void AddNotifierHost(NotifierHost notifierHost)
        {
            NotifierHosts.Add(notifierHost);
        }
        #endregion

        #region Saving
        public bool Save()
        {
            if (MonitorPackPath != null && MonitorPackPath.Length > 0 && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(MonitorPackPath)))
            {
                Save(MonitorPackPath);
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Saving QuickMon monitor pack file
        /// </summary>
        /// <param name="configurationFile"></param>
        public void Save(string configurationFile)
        {
            XmlDocument outDoc = new XmlDocument();
            outDoc.LoadXml(emptyConfig);
            XmlElement root = outDoc.DocumentElement;
            root.SetAttributeValue("version", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            root.SetAttributeValue("name", Name);
            root.SetAttributeValue("typeName", TypeName);
            root.SetAttributeValue("enabled", Enabled);
            root.SetAttributeValue("runCorrectiveScripts", RunCorrectiveScripts);
            root.SetAttributeValue("stateHistorySize", CollectorStateHistorySize);
            root.SetAttributeValue("pollingFreqSecOverride", PollingFrequencyOverrideSec);
            root.SetAttributeValue("loggingEnabled", LoggingEnabled);

            #region security
            root.SetAttributeValue("usernameCacheMasterKey", UserNameCacheMasterKey);
            root.SetAttributeValue("usernameCacheFilePath", UserNameCacheFilePath);
            #endregion

            root.SelectSingleNode("configVars").InnerXml = GetConfigVarXml();
            root.SelectSingleNode("collectorHosts").InnerXml = GetConfigForCollectors();
            root.SelectSingleNode("notifierHosts").InnerXml = GetConfigForNotifiers();

            #region Logging
            XmlNode loggingNode = root.SelectSingleNode("logging");
            loggingNode.SetAttributeValue("loggingPath", LoggingPath);
            loggingNode.SetAttributeValue("loggingCollectorEvents", LoggingCollectorEvents);
            loggingNode.SetAttributeValue("loggingNotifierEvents", LoggingNotifierEvents);
            loggingNode.SetAttributeValue("loggingAlertsRaised", LoggingAlertsRaised);
            loggingNode.SetAttributeValue("loggingCorrectiveScriptRun", LoggingCorrectiveScriptRun);
            loggingNode.SetAttributeValue("loggingPollingOverridesTriggered", LoggingPollingOverridesTriggered);
            loggingNode.SetAttributeValue("loggingServiceWindowEvents", LoggingServiceWindowEvents);
            loggingNode.SetAttributeValue("loggingKeepLogFilesXDays", LoggingKeepLogFilesXDays);
            XmlNode loggingCollectorCategoriesNode = loggingNode.SelectSingleNode("collectorCategories");
            foreach (string s in LoggingCollectorCategories)
            {
                XmlNode category = outDoc.CreateElement("category");
                category.InnerText = s;
                loggingCollectorCategoriesNode.AppendChild(category);
            }
            #endregion

            outDoc.PreserveWhitespace = false;
            outDoc.Normalize();
            outDoc.Save(configurationFile);

            MonitorPackPath = configurationFile;
            RaiseMonitorPackPathChanged(MonitorPackPath);
            WriteLogging("Monitor pack saved");
        }
        public void BackupSavedFile()
        {
            try
            {
                if (System.IO.File.Exists(MonitorPackPath))
                {
                    string path = System.IO.Path.GetDirectoryName(MonitorPackPath);
                    string fileNameWithoutExtention = System.IO.Path.GetFileNameWithoutExtension(MonitorPackPath);
                    string backupFile = System.IO.Path.Combine(path, fileNameWithoutExtention + ".bak");
                    if (System.IO.File.Exists(backupFile))
                    {
                        System.IO.File.SetAttributes(backupFile, System.IO.FileAttributes.Normal);
                        System.IO.File.Delete(backupFile);
                    }
                    System.IO.File.Copy(MonitorPackPath, backupFile);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while creating a backup for : " + MonitorPackPath, ex);
            }
        }
        public string ToXml()
        {
            XmlDocument outDoc = new XmlDocument();
            outDoc.LoadXml(emptyConfig);
            XmlElement root = outDoc.DocumentElement;
            root.SetAttributeValue("version", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            root.SetAttributeValue("name", Name);
            root.SetAttributeValue("typeName", TypeName);
            root.SetAttributeValue("enabled", Enabled);
            root.SetAttributeValue("runCorrectiveScripts", RunCorrectiveScripts);
            root.SetAttributeValue("stateHistorySize", CollectorStateHistorySize);
            root.SetAttributeValue("pollingFreqSecOverride", PollingFrequencyOverrideSec);

            #region security
            root.SetAttributeValue("usernameCacheMasterKey", UserNameCacheMasterKey);
            root.SetAttributeValue("usernameCacheFilePath", UserNameCacheFilePath);
            #endregion

            root.SelectSingleNode("configVars").InnerXml = GetConfigVarXml();
            root.SelectSingleNode("collectorHosts").InnerXml = GetConfigForCollectors();
            root.SelectSingleNode("notifierHosts").InnerXml = GetConfigForNotifiers();

            #region Logging
            XmlNode loggingNode = root.SelectSingleNode("logging");
            loggingNode.SetAttributeValue("loggingPath", LoggingPath);
            loggingNode.SetAttributeValue("loggingCollectorEvents", LoggingCollectorEvents);
            loggingNode.SetAttributeValue("loggingNotifierEvents", LoggingNotifierEvents);
            loggingNode.SetAttributeValue("loggingAlertsRaised", LoggingAlertsRaised);
            loggingNode.SetAttributeValue("loggingCorrectiveScriptRun", LoggingCorrectiveScriptRun);
            loggingNode.SetAttributeValue("loggingPollingOverridesTriggered", LoggingPollingOverridesTriggered);
            loggingNode.SetAttributeValue("loggingServiceWindowEvents", LoggingServiceWindowEvents);
            loggingNode.SetAttributeValue("loggingKeepLogFilesXDays", LoggingKeepLogFilesXDays);
            XmlNode loggingCollectorCategoriesNode = loggingNode.SelectSingleNode("collectorCategories");
            foreach (string s in LoggingCollectorCategories)
            {
                XmlNode category = outDoc.CreateElement("category");
                category.InnerText = s;
                loggingCollectorCategoriesNode.AppendChild(category);
            }
            #endregion

            //outDoc.PreserveWhitespace = false;
            //outDoc.Normalize();
            return XmlFormattingUtils.NormalizeXML(outDoc.OuterXml);
        }
        private string GetConfigVarXml()
        {
            StringBuilder configVarXml = new StringBuilder();
            foreach (ConfigVariable cv in ConfigVariables)
            {
                configVarXml.AppendLine(cv.ToXml());
            }
            return configVarXml.ToString();
        }
        private string GetConfigForCollectors()
        {
            StringBuilder sb = new StringBuilder();
            foreach (CollectorHost collectorHost in CollectorHosts)
            {
                sb.AppendLine(collectorHost.ToXml());
            }
            return sb.ToString();
        }
        private string GetConfigForNotifiers()
        {
            StringBuilder sb = new StringBuilder();
            foreach (NotifierHost notifierHost in NotifierHosts)
            {
                sb.AppendLine(notifierHost.ToXml());
            }
            return sb.ToString();
        } 
        #endregion

        #region Global settings
        public static string GetQuickMonUserDataDirectory()
        {
            string dataDir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.DoNotVerify), "Hen IT\\QuickMon 4");
            try
            {
                if (!System.IO.Directory.Exists(dataDir))
                {
                    System.IO.Directory.CreateDirectory(dataDir);
                }
            }
            catch { }
            return dataDir;
        }
        public static string GetQuickMonUserDataTemplatesFile()
        {
            return System.IO.Path.Combine(MonitorPack.GetQuickMonUserDataDirectory(), "Templates" ,"QuickMon4Templates.qmtemplate");
        }
        #endregion
               
    }
}
