using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public partial class CollectorEntry
    {
        #region Get/Set configuration
        /// <summary>
        /// Create CollectorEntry instance based on configuration string
        /// </summary>
        /// <param name="stringCollectorEntry">configuration string</param>
        /// <returns>CollectorEntry instance</returns>
        public static CollectorEntry FromConfig(string stringCollectorEntry)
        {
            XmlDocument xmlCollectorEntry = new XmlDocument();
            xmlCollectorEntry.LoadXml(stringCollectorEntry);
            return FromConfig(xmlCollectorEntry.DocumentElement);
        }
        /// <summary>
        /// Create CollectorEntry instance based on configuration string
        /// </summary>
        /// <param name="xmlCollectorEntry">configuration XmlElement instance</param>
        /// <returns>CollectorEntry instance</returns>
        public static CollectorEntry FromConfig(XmlElement xmlCollectorEntry)
        {
            CollectorEntry collectorEntry = new CollectorEntry();
            collectorEntry.LastStateChange = DateTime.Now;
            collectorEntry.Name = xmlCollectorEntry.ReadXmlElementAttr("name", "").Trim();
            collectorEntry.UniqueId = xmlCollectorEntry.ReadXmlElementAttr("uniqueID", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            collectorEntry.Enabled = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("enabled", "True"));
            collectorEntry.ExpandOnStart = xmlCollectorEntry.ReadXmlElementAttr("expandOnStart", true);
            collectorEntry.IsFolder = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("isFolder", "False"));
            collectorEntry.ParentCollectorId = xmlCollectorEntry.ReadXmlElementAttr("dependOnParent");
            collectorEntry.CorrectiveScriptDisabled = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptDisabled", "False"));
            collectorEntry.CorrectiveScriptOnWarningPath = xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptOnWarningPath");
            collectorEntry.CorrectiveScriptOnErrorPath = xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptOnErrorPath");
            collectorEntry.RestorationScriptPath = xmlCollectorEntry.ReadXmlElementAttr("restorationScriptPath");
            collectorEntry.CorrectiveScriptsOnlyOnStateChange = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptsOnlyOnStateChange", "False"));
            collectorEntry.EnableRemoteExecute = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("enableRemoteExecute", "False"));
            collectorEntry.ForceRemoteExcuteOnChildCollectors = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("forceRemoteExcuteOnChildCollectors", "False"));
            collectorEntry.RemoteAgentHostAddress = xmlCollectorEntry.ReadXmlElementAttr("remoteAgentHostAddress");
            collectorEntry.RemoteAgentHostPort = xmlCollectorEntry.ReadXmlElementAttr("remoteAgentHostPort", 8181);
            collectorEntry.BlockParentOverrideRemoteAgentHostSettings = xmlCollectorEntry.ReadXmlElementAttr("blockParentRemoteAgentHostSettings", false);
            collectorEntry.RunLocalOnRemoteHostConnectionFailure = xmlCollectorEntry.ReadXmlElementAttr("runLocalOnRemoteHostConnectionFailure", false);
            collectorEntry.AlertsPaused = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("alertsPaused", "False"));

            //Polling overrides
            collectorEntry.EnabledPollingOverride = xmlCollectorEntry.ReadXmlElementAttr("enabledPollingOverride", false);
            collectorEntry.OnlyAllowUpdateOncePerXSec = xmlCollectorEntry.ReadXmlElementAttr("onlyAllowUpdateOncePerXSec", 1);
            collectorEntry.EnablePollFrequencySliding = xmlCollectorEntry.ReadXmlElementAttr("enablePollFrequencySliding", false);
            collectorEntry.PollSlideFrequencyAfterFirstRepeatSec = xmlCollectorEntry.ReadXmlElementAttr("pollSlideFrequencyAfterFirstRepeatSec", 2);
            collectorEntry.PollSlideFrequencyAfterSecondRepeatSec = xmlCollectorEntry.ReadXmlElementAttr("pollSlideFrequencyAfterSecondRepeatSec", 5);
            collectorEntry.PollSlideFrequencyAfterThirdRepeatSec = xmlCollectorEntry.ReadXmlElementAttr("pollSlideFrequencyAfterThirdRepeatSec", 30);

            //Service windows config
            collectorEntry.ServiceWindows = new ServiceWindows();
            XmlNode serviceWindowsNode = xmlCollectorEntry.SelectSingleNode("serviceWindows");
            if (serviceWindowsNode != null) //Load service windows info
                collectorEntry.ServiceWindows.CreateFromConfig(serviceWindowsNode.OuterXml);
            else
            {
                collectorEntry.ServiceWindows.CreateFromConfig("<serviceWindows />");
            }

            if (!collectorEntry.IsFolder)
            {
                collectorEntry.CollectorRegistrationName = xmlCollectorEntry.ReadXmlElementAttr("collector", "No collector");
                collectorEntry.CollectOnParentWarning = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("collectOnParentWarning", "False"));
                collectorEntry.RepeatAlertInXMin = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("repeatAlertInXMin", "0"));
                collectorEntry.AlertOnceInXMin = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("alertOnceInXMin", "0"));
                collectorEntry.DelayErrWarnAlertForXSec = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("delayErrWarnAlertForXSec", "0"));

                collectorEntry.RepeatAlertInXPolls = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("repeatAlertInXPolls", "0"));
                collectorEntry.AlertOnceInXPolls = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("alertOnceInXPolls", "0"));
                collectorEntry.DelayErrWarnAlertForXPolls = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("delayErrWarnAlertForXPolls", "0"));

                collectorEntry.LastAlertTime = new DateTime(2000, 1, 1); //long ago
                collectorEntry.LastGoodStateTime = new DateTime(2000, 1, 1); //long ago
                collectorEntry.LastMonitorState = new MonitorState() { State = CollectorState.NotAvailable, CurrentValue = null, RawDetails = "", HtmlDetails = "" };
                XmlNode configNode = xmlCollectorEntry.SelectSingleNode("config");
                if (configNode != null)
                {
                    collectorEntry.InitialConfiguration = configNode.OuterXml;
                }
                else
                {
                    collectorEntry.LastMonitorState.State = CollectorState.ConfigurationError;
                    collectorEntry.InitialConfiguration = "";
                }
                XmlNode configVarsNode = xmlCollectorEntry.SelectSingleNode("configVars");
                if (configVarsNode != null)
                {
                    foreach (XmlNode configVarNode in configVarsNode.SelectNodes("configVar"))
                    {
                        collectorEntry.ConfigVariables.Add(ConfigVariable.FromXml(configVarNode.OuterXml));
                    }
                }
            }
            else
            {
                collectorEntry.CollectorRegistrationName = "Folder";
                collectorEntry.CollectorRegistrationDisplayName = "Folder";
                collectorEntry.InitialConfiguration = "";
                collectorEntry.LastMonitorState.State = CollectorState.Folder;
            }
            return collectorEntry;
        }
        /// <summary>
        /// Export current CollectorEntry config as XML string
        /// </summary>
        /// <returns>XML config string</returns>
        public string ToConfig()
        {
            string collectorConfig = (InitialConfiguration == null || InitialConfiguration.Length == 0) && (Collector != null) && (Collector.AgentConfig != null) ? Collector.AgentConfig.ToConfig() : InitialConfiguration;
            StringBuilder configVarXml = new StringBuilder();
            configVarXml.AppendLine("<configVars>");
            foreach (ConfigVariable cv in ConfigVariables)
            {
                configVarXml.AppendLine(cv.ToXml());
            }
            configVarXml.AppendLine("</configVars>");
            string config = ToConfig(UniqueId,
                Name.EscapeXml(),
                Enabled,
                ExpandOnStart,
                IsFolder,
                CollectorRegistrationName,
                ParentCollectorId,
                CollectOnParentWarning,
                RepeatAlertInXMin, AlertOnceInXMin, DelayErrWarnAlertForXSec,
                RepeatAlertInXPolls, AlertOnceInXPolls, DelayErrWarnAlertForXPolls,
                CorrectiveScriptDisabled,
                CorrectiveScriptOnWarningPath,
                CorrectiveScriptOnErrorPath,
                RestorationScriptPath,
                CorrectiveScriptsOnlyOnStateChange,
                EnableRemoteExecute,
                ForceRemoteExcuteOnChildCollectors,
                RemoteAgentHostAddress,
                RemoteAgentHostPort,
                BlockParentOverrideRemoteAgentHostSettings,
                RunLocalOnRemoteHostConnectionFailure,

                EnabledPollingOverride,
                OnlyAllowUpdateOncePerXSec,
                EnablePollFrequencySliding,
                PollSlideFrequencyAfterFirstRepeatSec,
                PollSlideFrequencyAfterSecondRepeatSec,
                PollSlideFrequencyAfterThirdRepeatSec,
                AlertsPaused,

                collectorConfig,
                ServiceWindows.ToConfig(),
                configVarXml.ToString()
                );
            return config;
        }
        /// <summary>
        /// Export current CollectorEntry config as XML string
        /// </summary>
        /// <param name="uniqueId">Unique id of Collector entry</param>
        /// <param name="name">Display name of Collector entry</param>
        /// <param name="enabled">Is Collector entry enables (True/False)</param>
        /// <param name="isFolder">Is this Collector entry a folder (True/False)</param>
        /// <param name="collectorRegistrationName">Agent registration name</param>
        /// <param name="parentCollectorId">Parent  Collector entry id</param>
        /// <param name="collectOnParentWarning">Show 'child' collector entries be checked if this collector entry returns a warning state</param>
        /// <param name="repeatAlertInXMin">Repeat warning/error alert if state remains warning/error</param>
        /// <param name="alertOnceInXMin">Only alert once in specified minutes regardless of state changes</param>
        /// <param name="delayErrWarnAlertForXSec">Only raise alert if state remains warning/error for specified number of seconds</param>
        /// <param name="correctiveScriptDisabled">Is corrective scripts disabled? (True/False)</param>
        /// <param name="correctiveScriptOnWarningPath">Path to script if warning state is reached</param>
        /// <param name="correctiveScriptOnErrorPath">Path to script if error state is reached</param>
        /// <param name="restorationScriptPath">Path to script if good state is reached after state was warning/error before</param>
        /// <param name="correctiveScriptsOnlyOnStateChange"></param>
        /// <param name="enableRemoteExecute">Is remote agent checking enabled (True/False)</param>
        /// <param name="remoteAgentHostAddress">Name of the remote agent host</param>
        /// <param name="remoteAgentHostPort">Port number of remote agent host (default is 8181)</param>
        /// <param name="collectorConfig">Full xml config string of collector agent</param>
        /// <param name="serviceWindows">Full xml config of service windows</param>
        /// <returns>XML config string</returns>
        public static string ToConfig(string uniqueId,
                string name,
                bool enabled,
                bool expandOnStart,
                bool isFolder,
                string collectorRegistrationName,
                string parentCollectorId,
                bool collectOnParentWarning,
                int repeatAlertInXMin, int alertOnceInXMin, int delayErrWarnAlertForXSec,
                int repeatAlertInXPolls, int alertOnceInXPolls, int delayErrWarnAlertForXPolls,
                bool correctiveScriptDisabled,
                string correctiveScriptOnWarningPath,
                string correctiveScriptOnErrorPath,
                string restorationScriptPath,
                bool correctiveScriptsOnlyOnStateChange,
                bool enableRemoteExecute,
                bool forceRemoteExcuteOnChildCollectors,
                string remoteAgentHostAddress,
                int remoteAgentHostPort,
                bool blockParentOverrideRemoteAgentHostSettings,
                bool runLocalOnRemoteHostConnectionFailure,
                bool enabledPollingOverride,
                int onlyAllowUpdateOncePerXSec,
                bool enablePollFrequencySliding,
                int pollSlideFrequencyAfterFirstRepeatSec,
                int pollSlideFrequencyAfterSecondRepeatSec,
                int pollSlideFrequencyAfterThirdRepeatSec,
                bool alertsPaused,
                string collectorConfig,
                string serviceWindows,
                string configVariablesXml)
        {
            string config = string.Format(Properties.Resources.CollectorEntryXml,
                uniqueId,
                name,
                enabled,
                expandOnStart,
                isFolder,
                collectorRegistrationName,
                parentCollectorId,
                collectOnParentWarning,
                repeatAlertInXMin, alertOnceInXMin, delayErrWarnAlertForXSec,
                repeatAlertInXPolls, alertOnceInXPolls, delayErrWarnAlertForXPolls,
                correctiveScriptDisabled,
                correctiveScriptOnWarningPath,
                correctiveScriptOnErrorPath,
                restorationScriptPath,
                correctiveScriptsOnlyOnStateChange,
                enableRemoteExecute,
                forceRemoteExcuteOnChildCollectors,
                remoteAgentHostAddress,
                remoteAgentHostPort,
                blockParentOverrideRemoteAgentHostSettings,
                runLocalOnRemoteHostConnectionFailure,
                enabledPollingOverride,
                onlyAllowUpdateOncePerXSec,
                enablePollFrequencySliding,
                pollSlideFrequencyAfterFirstRepeatSec,
                pollSlideFrequencyAfterSecondRepeatSec,
                pollSlideFrequencyAfterThirdRepeatSec,
                alertsPaused,
                collectorConfig,
                serviceWindows,
                configVariablesXml);
            return config;
        }
        #endregion

        public static string EntriesConfigToString(List<CollectorEntry> entries)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<collectorEntries>");
            foreach (CollectorEntry entry in entries)
            {
                sb.AppendLine(entry.ToConfig());
            }
            sb.AppendLine("</collectorEntries>");
            return sb.ToString();
        }
        public static List<CollectorEntry> GetCollectorEntriesFromString(string xmlString, bool preloadCollectorInstances = false, List<ConfigVariable> monitorPackVars = null)
        {
            List<CollectorEntry> collectors = new List<CollectorEntry>();
            XmlDocument collectorEntryXml = new XmlDocument();
            collectorEntryXml.LoadXml(xmlString);
            XmlElement root = collectorEntryXml.DocumentElement;

            foreach (XmlElement xmlCollectorEntry in root.SelectNodes("collectorEntry"))
            {
                CollectorEntry newCollectorEntry = CollectorEntry.FromConfig(xmlCollectorEntry);
                if (preloadCollectorInstances && !newCollectorEntry.IsFolder)
                {
                    RegisteredAgent currentRA = RegisteredAgentCache.GetRegisteredAgentByClassName("." + newCollectorEntry.CollectorRegistrationName);
                    if (currentRA != null)
                    {
                        newCollectorEntry.CreateAndConfigureEntry(currentRA, monitorPackVars);
                    }
                }
                collectors.Add(newCollectorEntry);
            }
            return collectors;
        }
    }
}
