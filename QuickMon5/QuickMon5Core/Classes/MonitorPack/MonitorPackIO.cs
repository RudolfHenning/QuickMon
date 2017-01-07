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
            public bool Exists { get; set; }
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
            NameAndTypeSummary summaryInfo = new NameAndTypeSummary() { Name = System.IO.Path.GetFileNameWithoutExtension(filePath), Exists = false, Path = filePath, Enabled = false, TypeName = "", Version = "4.0.0.0" };
            try
            {
                XmlDocument configurationXml = new XmlDocument();
                configurationXml.Load(filePath);
                summaryInfo.Exists = true;
                XmlElement root = configurationXml.DocumentElement;
                summaryInfo.Name = root.ReadXmlElementAttr("name", System.IO.Path.GetFileNameWithoutExtension(filePath));
                if (summaryInfo.Name.Length == 0)
                    summaryInfo.Name = System.IO.Path.GetFileNameWithoutExtension(filePath);
                summaryInfo.TypeName = root.ReadXmlElementAttr("typeName", "");
                summaryInfo.Version = root.ReadXmlElementAttr("version", "5.0.0.0");
                summaryInfo.Enabled = root.ReadXmlElementAttr("enabled", true);
            }
            catch { }
            return summaryInfo;
        }

        private string emptyConfig = "<monitorPack>\r\n" + 
            "<configVars />\r\n" +
            "<collectorHosts>\r\n<actionScripts />\r\n</collectorHosts>\r\n" + 
            "<notifierHosts>\r\n</notifierHosts>\r\n" + 
            "<logging>\r\n<collectorCategories/>\r\n</logging>\r\n</monitorPack>";

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
            try
            {
                LastMPLoadError = "";
                Stopwatch sw = new Stopwatch();
                XmlDocument configurationXml = new XmlDocument();
                sw.Start();
                configurationXml.LoadXml(xmlConfig);
                sw.Stop();
                System.Diagnostics.Trace.WriteLine(string.Format("MonitorPack Loading XML time:{0}ms", sw.ElapsedMilliseconds));

                sw.Reset();
                sw.Start();
                XmlElement root = configurationXml.DocumentElement;
                Name = root.ReadXmlElementAttr("name", "");
                TypeName = root.ReadXmlElementAttr("typeName", "");
                this.Version = root.ReadXmlElementAttr("version", "5.0.0.0");
                Enabled = root.ReadXmlElementAttr("enabled", true);
                CollectorStateHistorySize = root.ReadXmlElementAttr("stateHistorySize", 100); //Depricated
                PollingFrequencyOverrideSec = root.ReadXmlElementAttr("pollingFreqSecOverride", 0); //Depricated
                CorrectiveScriptsEnabled = root.ReadXmlElementAttr("runCorrectiveScripts", true); //Depricated
                LoggingEnabled = root.ReadXmlElementAttr("loggingEnabled", false); //Deprecated

                /***************** Load config variables ****************/
                #region Load config variables
                XmlNode configVarsNode = root.SelectSingleNode("configVars");
                ConfigVariables = new List<ConfigVariable>();
                if (configVarsNode != null)
                {
                    foreach (XmlElement configVarNode in configVarsNode.SelectNodes("configVar"))
                    {
                        ConfigVariables.Add(ConfigVariable.FromXml(configVarNode));
                    }
                }
                #endregion
                /***************** Load Collectors ****************/
                #region Load Collectors
                XmlNode collectorHostsNode = root.SelectSingleNode("collectorHosts");
                if (collectorHostsNode != null)
                {
                    CorrectiveScriptsEnabled = collectorHostsNode.ReadXmlElementAttr("correctiveScriptsEnabled", CorrectiveScriptsEnabled);
                    CollectorStateHistorySize = collectorHostsNode.ReadXmlElementAttr("stateHistorySize", CollectorStateHistorySize);
                    PollingFrequencyOverrideSec = collectorHostsNode.ReadXmlElementAttr("pollingFreqSecOverride", PollingFrequencyOverrideSec);

                    XmlNode actionScriptsNode = collectorHostsNode.SelectSingleNode("actionScripts");
                    if (actionScriptsNode != null)
                    {
                        ActionScripts = ActionScript.FromXml(actionScriptsNode);                        
                    }

                    CollectorHosts = CollectorHost.GetCollectorHosts(collectorHostsNode, ConfigVariables);
                    foreach (CollectorHost collectorHost in CollectorHosts)
                    {
                        SetCollectorHostEvents(collectorHost);
                        InitializeCollectorActionScripts(collectorHost);
                    }
                }
                #endregion
                /***************** Load Notifiers ****************/
                #region Load Notifiers
                XmlNode notifierHostsNode = root.SelectSingleNode("notifierHosts");
                if (notifierHostsNode != null)
                {
                    NotifierHosts = NotifierHost.GetNotifierHosts(notifierHostsNode, ConfigVariables);
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
                    LoggingEnabled = loggingNode.ReadXmlElementAttr("enabled", LoggingEnabled);
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
            catch(Exception ex)
            {
                LastMPLoadError = ex.ToString();
            }
            if (LastMPLoadError.Length == 0)
                WriteLogging("Monitor config loaded with no errors");
            else
                WriteLogging("Monitor config loaded with errors - " + LastMPLoadError);
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
            collectorHost.RestorationScriptExecuted += CollectorHost_RestorationScriptExecuted;
            collectorHost.RestorationScriptFailed += CollectorHost_RestorationScriptFailed;
            collectorHost.WarningCorrectiveScriptExecuted += CollectorHost_WarningCorrectiveScriptExecuted;
            collectorHost.WarningCorrectiveScriptFailed += CollectorHost_WarningCorrectiveScriptFailed;
            collectorHost.ErrorCorrectiveScriptExecuted += CollectorHost_ErrorCorrectiveScriptExecuted;
            collectorHost.ErrorCorrectiveScriptFailed += CollectorHost_ErrorCorrectiveScriptFailed;
            collectorHost.CorrectiveScriptMinRepeatTimeBlockedEvent += collectorHost_CorrectiveScriptMinRepeatTimeBlockedEvent;
            collectorHost.LoggingPollingOverridesTriggeredEvent += collectorHost_LoggingPollingOverridesTriggeredEvent;
            collectorHost.EntereringServiceWindow += collectorHost_EntereringServiceWindow;
            collectorHost.ExitingServiceWindow += collectorHost_ExitingServiceWindow;
        }



        public void InitializeCollectorActionScripts(CollectorHost collectorHost)
        {
            if (collectorHost != null && collectorHost.ActionScripts != null)
            {
                foreach(var collectorActionScript in collectorHost.ActionScripts)
                {
                    ActionScript currentActionScript = (from acs in ActionScripts
                                                        where acs.Id == collectorActionScript.MPId
                                                        select acs).FirstOrDefault();
                    if (currentActionScript != null)
                        collectorActionScript.InitializeScript(currentActionScript);
                }
            }
        }

        /// <summary>
        /// When adding a new collector host manually or by editing it needs to be initialized for events, config vars, scripts etc.
        /// </summary>
        /// <param name="collectorHost"></param>
        public void AddCollectorHost(CollectorHost collectorHost)
        {
            SetCollectorHostEvents(collectorHost);
            InitializeCollectorActionScripts(collectorHost);
            CollectorHosts.Add(collectorHost);
        }
        /// <summary>
        /// When adding a new notifier host manually or by editing it needs to be initialized for events, config vars etc.
        /// </summary>
        /// <param name="notifierHost"></param>
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
            outDoc.LoadXml(ToXml()); 

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

            #region security
            root.SetAttributeValue("usernameCacheMasterKey", UserNameCacheMasterKey);
            root.SetAttributeValue("usernameCacheFilePath", UserNameCacheFilePath);
            #endregion

            root.SelectSingleNode("configVars").InnerXml = GetConfigVarXml();

            XmlNode collectorHostsNode = root.SelectSingleNode("collectorHosts");
            collectorHostsNode.SetAttributeValue("runCorrectiveScripts", CorrectiveScriptsEnabled);
            collectorHostsNode.SetAttributeValue("stateHistorySize", CollectorStateHistorySize);
            collectorHostsNode.SetAttributeValue("pollingFreqSecOverride", PollingFrequencyOverrideSec);
            XmlNode actionScriptsNode = collectorHostsNode.SelectSingleNode("actionScripts");

            foreach (ActionScript ascr in ActionScripts)
            {
                XmlNode scriptParameterNode = outDoc.ImportNode(ascr.ToXmlNode(), true);
                actionScriptsNode.AppendChild(scriptParameterNode);
            }

            foreach(CollectorHost collectorHost in CollectorHosts)
            {
                XmlNode collectorHostNode = outDoc.ImportNode(collectorHost.ToXmlNode(), true);
                collectorHostsNode.AppendChild(collectorHostNode);
            }
            XmlNode notifierHostsNode = root.SelectSingleNode("notifierHosts");

            foreach (NotifierHost notifierHost in NotifierHosts)
            {
                XmlNode notifierHostNode = outDoc.ImportNode(notifierHost.ToXmlNode(), true);
                notifierHostsNode.AppendChild(notifierHostNode);
            }

            #region Logging
            XmlNode loggingNode = root.SelectSingleNode("logging");
            loggingNode.SetAttributeValue("enabled", LoggingEnabled);
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
        //private string GetConfigForCollectors()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (CollectorHost collectorHost in CollectorHosts)
        //    {
        //        sb.AppendLine(collectorHost.ToXml());
        //    }
        //    return sb.ToString();
        //}
        //private string GetConfigForNotifiers()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (NotifierHost notifierHost in NotifierHosts)
        //    {
        //        sb.AppendLine(notifierHost.ToXml());
        //    }
        //    return sb.ToString();
        //}
        #endregion

        #region Global settings
        public static string GetQuickMonUserDataDirectory()
        {
            string dataDir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.DoNotVerify), "Hen IT\\QuickMon 5");
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
            return System.IO.Path.Combine(MonitorPack.GetQuickMonUserDataDirectory(), "Templates", "QuickMon5Templates.qmtemplate");
        }
        #endregion

    }
}
