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
        public static string GetMonitorPackTypeName(string filePath)
        {
            string typeName = "";
            try
            {
                XmlDocument configurationXml = new XmlDocument();
                configurationXml.Load(filePath);
                XmlElement root = configurationXml.DocumentElement;
                typeName = root.ReadXmlElementAttr("typeName", "");
            }
            catch { }
            return typeName;
        }

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
                    collectorHost.ParentMonitorPack = this;
                    collectorHost.AlertGoodState += collectorHost_AlertGoodState;
                    collectorHost.AlertWarningState += collectorHost_AlertWarningState;
                    collectorHost.AlertErrorState += collectorHost_AlertErrorState;
                    collectorHost.NoStateChanged += collectorHost_NoStateChanged;
                }
            }
            #endregion
            /***************** Load Notifiers ****************/
            #region Load Notifiers
            XmlNode notifierHostsNode = root.SelectSingleNode("notifierHosts");
            if (notifierHostsNode != null)
            {
                NotifierHosts = NotifierHost.GetNotifierHostsFromString(notifierHostsNode.OuterXml, ConfigVariables);
                foreach (NotifierHost newNotifierEntry in NotifierHosts)
                {
                    if (newNotifierEntry.Name.ToUpper() == defaultNotifierName.ToUpper())
                        DefaultViewerNotifier = newNotifierEntry;
                }
            }
            #endregion

            sw.Stop();
            System.Diagnostics.Trace.WriteLine(string.Format("MonitorPack Parsing XML time:{0}ms", sw.ElapsedMilliseconds));
            InitializeGlobalPerformanceCounters();
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
            string defaultViewerNotifier = "";
            if (DefaultViewerNotifier != null)
                defaultViewerNotifier = DefaultViewerNotifier.Name;
            string outputXml = string.Format(
                @"<monitorPack version=""{0}"" name=""{1}"" typeName=""{2}"" enabled=""{3}"" defaultNotifier=""{4}"" " +
                  @"runCorrectiveScripts=""{5}"" stateHistorySize=""{6}"" pollingFreqSecOverride=""{7}"">" + "\r\n" +
                  "<configVars>\r\n" +
                  "{8}\r\n" +
                  "</configVars>\r\n" +
                  "<collectorHosts>\r\n" +
                  "{9}\r\n" +
                  "</collectorHosts>\r\n" +
                  "<notifierHosts>\r\n" +
                  "{10}\r\n" +
                  "</notifierHosts>\r\n" +
                "</monitorPack>",
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version,
                Name, TypeName, Enabled, defaultViewerNotifier,
                RunCorrectiveScripts,
                CollectorStateHistorySize,
                PollingFrequencyOverrideSec,
                GetConfigVarXml(),
                GetConfigForCollectors(),
                GetConfigForNotifiers());
            XmlDocument outputDoc = new XmlDocument();
            outputDoc.LoadXml(outputXml);
            outputDoc.PreserveWhitespace = false;
            outputDoc.Normalize();
            outputDoc.Save(configurationFile);

            MonitorPackPath = configurationFile;
            RaiseMonitorPackPathChanged(MonitorPackPath);
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
            string dataDir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.DoNotVerify), "Hen IT\\QuickMon 3");
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
            return System.IO.Path.Combine(MonitorPack.GetQuickMonUserDataDirectory(), "QuickMon3Templates.qps");
        }
        #endregion
    }
}
