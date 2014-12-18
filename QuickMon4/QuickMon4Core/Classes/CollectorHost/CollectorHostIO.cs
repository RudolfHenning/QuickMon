using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public partial class CollectorHost
    {
        public static List<CollectorHost> GetCollectorHostsFromString(string xmlString, List<ConfigVariable> monitorPackVars = null)
        {
            List<CollectorHost> collectorHosts = new List<CollectorHost>();
            XmlDocument collectorHostsXml = new XmlDocument();
            collectorHostsXml.LoadXml(xmlString);
            XmlElement root = collectorHostsXml.DocumentElement;
            foreach (XmlElement xmlCollectorHost in root.SelectNodes("collectorHost"))
            {
                CollectorHost newCollectorHost = CollectorHost.FromConfig(xmlCollectorHost, monitorPackVars);                
                collectorHosts.Add(newCollectorHost);
            }
            return collectorHosts;
        }
        public static CollectorHost FromXml(string xmlString, bool applyConfigVars = true)
        {
            if (xmlString != null && xmlString.Length > 0 && xmlString.StartsWith("<collectorHost"))
            {
                XmlDocument collectorHostDoc = new XmlDocument();
                collectorHostDoc.LoadXml(xmlString);
                XmlElement root = collectorHostDoc.DocumentElement;
                return FromConfig(root, null, applyConfigVars);
            }
            else
                return null;
        }
        private static CollectorHost FromConfig(XmlElement xmlCollectorEntry, List<ConfigVariable> monitorPackVars = null, bool applyConfigVars = true)
        {
            CollectorHost newCollectorHost = new CollectorHost();
            newCollectorHost.Name = xmlCollectorEntry.ReadXmlElementAttr("name", "").Trim();
            newCollectorHost.UniqueId = xmlCollectorEntry.ReadXmlElementAttr("uniqueId", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            newCollectorHost.Enabled = xmlCollectorEntry.ReadXmlElementAttr("enabled", true);
            newCollectorHost.ExpandOnStart = xmlCollectorEntry.ReadXmlElementAttr("expandOnStart", true);
            newCollectorHost.ParentCollectorId = xmlCollectorEntry.ReadXmlElementAttr("dependOnParentId");
            newCollectorHost.AgentCheckSequence = AgentCheckSequenceConverter.FromString(xmlCollectorEntry.ReadXmlElementAttr("agentCheckSequence", "All")); //  "All|FirstSuccess|FirstError"
            newCollectorHost.ChildCheckBehaviour = ChildCheckBehaviourConverter.FromString(xmlCollectorEntry.ReadXmlElementAttr("childCheckBehaviour", "OnlyRunOnSuccess")); // "OnlyRunOnSuccess|ContinueOnWarning|ContinueOnWarningOrError|IncludeChildStatus"

            //Alert supression
            newCollectorHost.RepeatAlertInXMin = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("repeatAlertInXMin", "0"));
            newCollectorHost.AlertOnceInXMin = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("alertOnceInXMin", "0"));
            newCollectorHost.DelayErrWarnAlertForXSec = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("delayErrWarnAlertForXSec", "0"));
            newCollectorHost.RepeatAlertInXPolls = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("repeatAlertInXPolls", "0"));
            newCollectorHost.AlertOnceInXPolls = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("alertOnceInXPolls", "0"));
            newCollectorHost.DelayErrWarnAlertForXPolls = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("delayErrWarnAlertForXPolls", "0"));
            newCollectorHost.AlertsPaused = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("alertsPaused", "False"));

            //Corrective scripts
            newCollectorHost.CorrectiveScriptDisabled = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptDisabled", "False"));
            newCollectorHost.CorrectiveScriptOnWarningPath = xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptOnWarningPath");
            newCollectorHost.CorrectiveScriptOnErrorPath = xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptOnErrorPath");
            newCollectorHost.RestorationScriptPath = xmlCollectorEntry.ReadXmlElementAttr("restorationScriptPath");
            newCollectorHost.CorrectiveScriptsOnlyOnStateChange = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptsOnlyOnStateChange", "False"));

            //remote hosts
            newCollectorHost.EnableRemoteExecute = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("enableRemoteExecute", "False"));
            newCollectorHost.ForceRemoteExcuteOnChildCollectors = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("forceRemoteExcuteOnChildCollectors", "False"));
            newCollectorHost.RemoteAgentHostAddress = xmlCollectorEntry.ReadXmlElementAttr("remoteAgentHostAddress");
            newCollectorHost.RemoteAgentHostPort = xmlCollectorEntry.ReadXmlElementAttr("remoteAgentHostPort", GlobalConstants.DefaultRemoteHostPort);
            newCollectorHost.BlockParentOverrideRemoteAgentHostSettings = xmlCollectorEntry.ReadXmlElementAttr("blockParentRemoteAgentHostSettings", false);
            newCollectorHost.RunLocalOnRemoteHostConnectionFailure = xmlCollectorEntry.ReadXmlElementAttr("runLocalOnRemoteHostConnectionFailure", false);            

            //Polling overrides
            newCollectorHost.EnabledPollingOverride = xmlCollectorEntry.ReadXmlElementAttr("enabledPollingOverride", false);
            newCollectorHost.OnlyAllowUpdateOncePerXSec = xmlCollectorEntry.ReadXmlElementAttr("onlyAllowUpdateOncePerXSec", 1);
            newCollectorHost.EnablePollFrequencySliding = xmlCollectorEntry.ReadXmlElementAttr("enablePollFrequencySliding", false);
            newCollectorHost.PollSlideFrequencyAfterFirstRepeatSec = xmlCollectorEntry.ReadXmlElementAttr("pollSlideFrequencyAfterFirstRepeatSec", 2);
            newCollectorHost.PollSlideFrequencyAfterSecondRepeatSec = xmlCollectorEntry.ReadXmlElementAttr("pollSlideFrequencyAfterSecondRepeatSec", 5);
            newCollectorHost.PollSlideFrequencyAfterThirdRepeatSec = xmlCollectorEntry.ReadXmlElementAttr("pollSlideFrequencyAfterThirdRepeatSec", 30);            

            //Service windows config
            newCollectorHost.ServiceWindows = new ServiceWindows();
            XmlNode serviceWindowsNode = xmlCollectorEntry.SelectSingleNode("serviceWindows");
            if (serviceWindowsNode != null) //Load service windows info
                newCollectorHost.ServiceWindows.CreateFromConfig(serviceWindowsNode.OuterXml);
            else
            {
                newCollectorHost.ServiceWindows.CreateFromConfig("<serviceWindows />");
            }
            //Config vars
            XmlNode configVarsNode = xmlCollectorEntry.SelectSingleNode("configVars");
            if (configVarsNode != null)
            {
                foreach (XmlNode configVarNode in configVarsNode.SelectNodes("configVar"))
                {
                    newCollectorHost.ConfigVariables.Add(ConfigVariable.FromXml(configVarNode.OuterXml));
                }
            }

            XmlNode collectorAgentsNode = xmlCollectorEntry.SelectSingleNode("collectorAgents");
            if (collectorAgentsNode != null)
            {
                newCollectorHost.CollectorAgents = new List<ICollector>();
                foreach (XmlElement collectorAgentNode in collectorAgentsNode.SelectNodes("collectorAgent"))
                {
                    string name = collectorAgentNode.ReadXmlElementAttr("name", "");
                    string typeName = collectorAgentNode.ReadXmlElementAttr("type", "");
                    bool enabled = collectorAgentNode.ReadXmlElementAttr("enabled", true);
                    string configXml = "";
                    XmlNode configNode = collectorAgentNode.SelectSingleNode("config");
                    if (configNode != null)
                    {
                        configXml = configNode.OuterXml;
                    }

                    ICollector newAgent = CreateCollectorFromClassName(typeName);
                    if (newAgent != null)
                    {
                        try
                        {
                            newAgent.Name = name;
                            newAgent.Enabled = enabled;
                            if (configXml.Length > 0)
                                newAgent.InitialConfiguration = configXml;
                            else
                            {
                                if (newAgent.AgentConfig != null)
                                    newAgent.InitialConfiguration = newAgent.AgentConfig.GetDefaultOrEmptyXml();
                                else
                                    newCollectorHost.UpdateCurrentCollectorState(CollectorState.ConfigurationError);
                            }
                            string appliedConfig = newAgent.InitialConfiguration;
                            if (applyConfigVars)
                            {
                                appliedConfig = monitorPackVars.ApplyOn(appliedConfig);
                                appliedConfig = newCollectorHost.ConfigVariables.ApplyOn(appliedConfig);
                                newAgent.ActiveConfiguration = appliedConfig;
                            }
                            newCollectorHost.CollectorAgents.Add(newAgent);

                            newAgent.AgentConfig.FromXml(appliedConfig);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine(ex.ToString());
                            newCollectorHost.UpdateCurrentCollectorState(CollectorState.ConfigurationError);
                            newCollectorHost.currentState.ChildStates.Add(new MonitorState() { RawDetails = string.Format("Error loading config for {0}: {1}", name, ex.Message), State = CollectorState.ConfigurationError });
                        }
                    }
                    else
                    {
                        newCollectorHost.UpdateCurrentCollectorState(CollectorState.ConfigurationError);
                        newCollectorHost.currentState.ChildStates.Add(new MonitorState() { RawDetails = string.Format("The Collector Host type of '{0}' could not be loaded!", typeName), State = CollectorState.ConfigurationError });
                    }
                }
            }
            return newCollectorHost;
        }
        private static ICollector CreateCollectorFromClassName(string agentClassName)
        {
            ICollector currentAgent = null;
            RegisteredAgent currentRA = RegisteredAgentCache.GetRegisteredAgentByClassName("." + agentClassName, true);
            if (currentRA != null)
            {
                if (System.IO.File.Exists(currentRA.AssemblyPath))
                {
                    Assembly collectorEntryAssembly = Assembly.LoadFile(currentRA.AssemblyPath);
                    currentAgent = (ICollector)collectorEntryAssembly.CreateInstance(currentRA.ClassName);
                    currentAgent.AgentClassName = currentRA.ClassName.Replace("QuickMon.Collectors.", "");
                    currentAgent.AgentClassDisplayName = currentRA.DisplayName;
                }
            }
            return currentAgent;
        }
        /// <summary>
        /// Export current CollectorHost config as XML string
        /// </summary>
        /// <returns>XML config string</returns>
        public string ToXml()
        {
            StringBuilder collectorAgentsXml = new StringBuilder();
            collectorAgentsXml.AppendLine("<collectorAgents>");
            foreach (ICollector c in CollectorAgents)
            {
                collectorAgentsXml.AppendLine(string.Format("<collectorAgent name=\"{0}\" type=\"{1}\" enabled=\"{2}\">", c.Name, c.AgentClassName, c.Enabled));
                collectorAgentsXml.AppendLine(c.AgentConfig.ToXml());
                collectorAgentsXml.AppendLine("</collectorAgent>");
            }
            collectorAgentsXml.AppendLine("</collectorAgents>");

            StringBuilder configVarXml = new StringBuilder();
            configVarXml.AppendLine("<configVars>");
            foreach (ConfigVariable cv in ConfigVariables)
            {
                configVarXml.AppendLine(cv.ToXml());
            }
            configVarXml.AppendLine("</configVars>");

            return ToXml(UniqueId,
                Name,
                Enabled,
                ExpandOnStart,
                ParentCollectorId,
                AgentCheckSequence, ChildCheckBehaviour,
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

                collectorAgentsXml.ToString(),
                ServiceWindows.ToXml(),
                configVarXml.ToString());
        }
        public static string ToXml(string uniqueId,
                string name,
                bool enabled,
                bool expandOnStart,
                string parentCollectorId,
                AgentCheckSequence agentCheckSequence,
                ChildCheckBehaviour childCheckBehaviour,
                int repeatAlertInXMin, int alertOnceInXMin, int delayErrWarnAlertForXSec,
                int repeatAlertInXPolls, int alertOnceInXPolls, int delayErrWarnAlertForXPolls,
                bool correctiveScriptDisabled, string correctiveScriptOnWarningPath, string correctiveScriptOnErrorPath,
                string restorationScriptPath, bool correctiveScriptsOnlyOnStateChange, bool enableRemoteExecute,
                bool forceRemoteExcuteOnChildCollectors, string remoteAgentHostAddress, int remoteAgentHostPort,
                bool blockParentOverrideRemoteAgentHostSettings, bool runLocalOnRemoteHostConnectionFailure,
                bool enabledPollingOverride,
                int onlyAllowUpdateOncePerXSec,
                bool enablePollFrequencySliding,
                int pollSlideFrequencyAfterFirstRepeatSec,
                int pollSlideFrequencyAfterSecondRepeatSec,
                int pollSlideFrequencyAfterThirdRepeatSec,
                bool alertsPaused,
                string collectorAgentsXml,
                string serviceWindowsXml,
                string configVariablesXml
            )
        {
            StringBuilder configXml = new StringBuilder();
            configXml.AppendLine(string.Format("<collectorHost uniqueId=\"{0}\" name=\"{1}\" enabled=\"{2}\" expandOnStart=\"{3}\" dependOnParentId=\"{4}\" " +
                      "agentCheckSequence=\"{5}\" childCheckBehaviour=\"{6}\" " +
                      "repeatAlertInXMin=\"{7}\" alertOnceInXMin=\"{8}\" delayErrWarnAlertForXSec=\"{9}\" " +
                      "repeatAlertInXPolls=\"{10}\" alertOnceInXPolls=\"{11}\" delayErrWarnAlertForXPolls=\"{12}\" " +
                      "correctiveScriptDisabled=\"{13}\" correctiveScriptOnWarningPath=\"{14}\" correctiveScriptOnErrorPath=\"{15}\" " +
                      "restorationScriptPath=\"{16}\" correctiveScriptsOnlyOnStateChange=\"{17}\" enableRemoteExecute=\"{18}\" " +
                      "forceRemoteExcuteOnChildCollectors=\"{19}\" remoteAgentHostAddress=\"{20}\" remoteAgentHostPort=\"{21}\" " +
                      "blockParentRemoteAgentHostSettings=\"{22}\" runLocalOnRemoteHostConnectionFailure=\"{23}\" " +
                      "enabledPollingOverride=\"{24}\" onlyAllowUpdateOncePerXSec=\"{25}\" enablePollFrequencySliding=\"{26}\" " +
                      "pollSlideFrequencyAfterFirstRepeatSec=\"{27}\" pollSlideFrequencyAfterSecondRepeatSec=\"{28}\" pollSlideFrequencyAfterThirdRepeatSec=\"{29}\" alertsPaused=\"{30}\">",
                        uniqueId, name.EscapeXml(), enabled, expandOnStart, parentCollectorId,
                        agentCheckSequence, childCheckBehaviour,
                        repeatAlertInXMin, alertOnceInXMin, delayErrWarnAlertForXSec,
                        repeatAlertInXPolls, alertOnceInXPolls, delayErrWarnAlertForXPolls,
                        correctiveScriptDisabled, correctiveScriptOnWarningPath, correctiveScriptOnErrorPath,
                        restorationScriptPath, correctiveScriptsOnlyOnStateChange, enableRemoteExecute,
                        forceRemoteExcuteOnChildCollectors, remoteAgentHostAddress, remoteAgentHostPort,
                        blockParentOverrideRemoteAgentHostSettings, runLocalOnRemoteHostConnectionFailure,
                        enabledPollingOverride, onlyAllowUpdateOncePerXSec, enablePollFrequencySliding,
                        pollSlideFrequencyAfterFirstRepeatSec, pollSlideFrequencyAfterSecondRepeatSec, pollSlideFrequencyAfterThirdRepeatSec,
                        alertsPaused
                      )
                     );
            configXml.AppendLine("<!-- CollectorAgents -->");
            configXml.AppendLine(collectorAgentsXml);
            configXml.AppendLine("<!-- ServiceWindows -->");
            configXml.AppendLine(serviceWindowsXml);
            configXml.AppendLine("<!-- Config variables -->");
            configXml.AppendLine(configVariablesXml);
            configXml.AppendLine("</collectorHost>");
            return configXml.ToString();
        }
    }
}
