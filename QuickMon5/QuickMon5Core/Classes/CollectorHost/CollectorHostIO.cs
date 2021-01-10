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
        #region FromXml
        public static List<CollectorHost> GetCollectorHosts(XmlNode collectorHostsNode, MonitorPack parentMonitorPack = null) //, List<ConfigVariable> monitorPackVars = null)
        {
            List<CollectorHost> collectorHosts = new List<CollectorHost>();            
            foreach (XmlElement xmlCollectorHost in collectorHostsNode.SelectNodes("collectorHost"))
            {
                CollectorHost newCollectorHost = FromConfig(null, xmlCollectorHost); //, monitorPackVars);
                newCollectorHost.ParentMonitorPack = parentMonitorPack;
                collectorHosts.Add(newCollectorHost);
            }
            return collectorHosts;
        }
        public static List<CollectorHost> GetCollectorHostsFromString(string xmlString)
        {
            if (xmlString != null && xmlString.StartsWith("<?xml "))
            {
                xmlString = xmlString.Substring(xmlString.IndexOf('>') + 1).Trim(' ', '\r', '\n');
            }
            List<CollectorHost> collectorHosts = new List<CollectorHost>();
            XmlDocument collectorHostsXml = new XmlDocument();
            collectorHostsXml.LoadXml(xmlString);
            collectorHosts = GetCollectorHosts(collectorHostsXml.DocumentElement);
            return collectorHosts;
        }

        public static CollectorHost FromXml(string xmlString)
        {
            if (xmlString != null && xmlString.StartsWith("<?xml "))
            {
                xmlString = xmlString.Substring(xmlString.IndexOf('>') + 1).Trim(' ', '\r', '\n');
            }
            if (xmlString != null && xmlString.Length > 0 && xmlString.StartsWith("<collectorHost"))
            {
                XmlDocument collectorHostDoc = new XmlDocument();
                collectorHostDoc.LoadXml(xmlString);
                XmlElement root = collectorHostDoc.DocumentElement;
                return FromConfig(null, root);
            }
            else
                return null;
        }
        /// <summary>
        /// Load configuration without loosing state history and other statistics
        /// </summary>
        /// <param name="xmlString">xml xonfig string</param>
        /// <param name="monitorPackVars">Any monitor pack level config variables</param>
        /// <param name="applyConfigVars">Should config variables be applied</param>
        public void ReconfigureFromXml(string xmlString) //, List<ConfigVariable> monitorPackVars = null, bool applyConfigVars = true)
        {
            if (xmlString != null && xmlString.StartsWith("<?xml "))
            {
                xmlString = xmlString.Substring(xmlString.IndexOf('>') + 1).Trim(' ', '\r','\n');
            }
            if (xmlString != null && xmlString.Length > 0 && xmlString.StartsWith("<collectorHost"))
            {
                XmlDocument collectorHostDoc = new XmlDocument();
                collectorHostDoc.LoadXml(xmlString);
                XmlElement root = collectorHostDoc.DocumentElement;
                FromConfig(this, root); //, monitorPackVars, applyConfigVars);
                //SetCurrentState(new MonitorState() { State = CollectorState.ConfigurationChanged, RawDetails = "Reconfigured", HtmlDetails = "<p>Reconfigured</p>" });
                AddStateToHistory(new MonitorState() { State = CollectorState.ConfigurationChanged, RawDetails = "Reconfigured", HtmlDetails = "<p>Reconfigured</p>" });
            }
        }
        private static CollectorHost FromConfig(CollectorHost newCollectorHost, XmlElement xmlCollectorEntry) //, List<ConfigVariable> monitorPackVars = null, bool applyConfigVars = true)
        {
            if (newCollectorHost == null)
                newCollectorHost = new CollectorHost();
            newCollectorHost.Name = xmlCollectorEntry.ReadXmlElementAttr("name", "").Trim();
            
            string uniqueId = xmlCollectorEntry.ReadXmlElementAttr("uniqueId", Guid.NewGuid().ToString() );  //DateTime.Now.ToString(  "yyyy-MM-ddTHH:mm:ss")
            if (uniqueId.Length > 0) //Blank unique id not allowed
                newCollectorHost.UniqueId = uniqueId;
            newCollectorHost.Enabled = xmlCollectorEntry.ReadXmlElementAttr("enabled", true);

            newCollectorHost.ExpandOnStartOption = ExpandOnStartOptionConverter.FromString(xmlCollectorEntry.ReadXmlElementAttr("expandOnStart", "Always"));
            newCollectorHost.ParentCollectorId = xmlCollectorEntry.ReadXmlElementAttr("dependOnParentId");
            newCollectorHost.AgentCheckSequence = AgentCheckSequenceConverter.FromString(xmlCollectorEntry.ReadXmlElementAttr("agentCheckSequence", "All")); //  "All|FirstSuccess|FirstError"
            newCollectorHost.ChildCheckBehaviour = ChildCheckBehaviourConverter.FromString(xmlCollectorEntry.ReadXmlElementAttr("childCheckBehaviour", "OnlyRunOnSuccess")); // "OnlyRunOnSuccess|ContinueOnWarning|ContinueOnWarningOrError|IncludeChildStatus"

            //Impersonation
            newCollectorHost.RunAsEnabled = xmlCollectorEntry.ReadXmlElementAttr("runAsEnabled", false);
            newCollectorHost.RunAs = xmlCollectorEntry.ReadXmlElementAttr("runAs", "");

            #region Notes/documentation
            XmlNode notesNode = xmlCollectorEntry.SelectSingleNode("notes");
            if (notesNode != null && notesNode.InnerText.Trim(' ', '\r', '\n').Length > 0)
                newCollectorHost.Notes = notesNode.InnerText.Trim(' ', '\r', '\n');
            #endregion

            #region Alerting
            XmlNode alertingNode = xmlCollectorEntry.SelectSingleNode("alerting");
            if (alertingNode != null)
            {
                #region Suppression
                XmlNode supressionNode = alertingNode.SelectSingleNode("suppression");
                if (supressionNode != null)
                {
                    newCollectorHost.RepeatAlertInXMin = int.Parse(supressionNode.ReadXmlElementAttr("repeatAlertInXMin", "0"));
                    newCollectorHost.AlertOnceInXMin = int.Parse(supressionNode.ReadXmlElementAttr("alertOnceInXMin", "0"));
                    newCollectorHost.DelayErrWarnAlertForXSec = int.Parse(supressionNode.ReadXmlElementAttr("delayErrWarnAlertForXSec", "0"));
                    newCollectorHost.RepeatAlertInXPolls = int.Parse(supressionNode.ReadXmlElementAttr("repeatAlertInXPolls", "0"));
                    newCollectorHost.AlertOnceInXPolls = int.Parse(supressionNode.ReadXmlElementAttr("alertOnceInXPolls", "0"));
                    newCollectorHost.DelayErrWarnAlertForXPolls = int.Parse(supressionNode.ReadXmlElementAttr("delayErrWarnAlertForXPolls", "0"));
                    newCollectorHost.AlertsPaused = bool.Parse(supressionNode.ReadXmlElementAttr("alertsPaused", "False"));
                }
                #endregion

                #region Alerting texts
                XmlNode textsNode = alertingNode.SelectSingleNode("texts");
                if (textsNode != null)
                {
                    XmlNode headerNode = textsNode.SelectSingleNode("header");
                    if (headerNode != null)
                        newCollectorHost.AlertHeaderText = headerNode.InnerText;
                    XmlNode footerNode = textsNode.SelectSingleNode("footer");
                    if (footerNode != null)
                        newCollectorHost.AlertFooterText = footerNode.InnerText;
                    XmlNode errorNode = textsNode.SelectSingleNode("error");
                    if (errorNode != null)
                        newCollectorHost.ErrorAlertText = errorNode.InnerText;
                    XmlNode warningNode = textsNode.SelectSingleNode("warning");
                    if (warningNode != null)
                        newCollectorHost.WarningAlertText = warningNode.InnerText;
                    XmlNode goodNode = textsNode.SelectSingleNode("good");
                    if (goodNode != null)
                        newCollectorHost.GoodAlertText = goodNode.InnerText;
                }
                #endregion
            }
            else
            {
                newCollectorHost.RepeatAlertInXMin = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("repeatAlertInXMin", "0"));
                newCollectorHost.AlertOnceInXMin = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("alertOnceInXMin", "0"));
                newCollectorHost.DelayErrWarnAlertForXSec = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("delayErrWarnAlertForXSec", "0"));
                newCollectorHost.RepeatAlertInXPolls = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("repeatAlertInXPolls", "0"));
                newCollectorHost.AlertOnceInXPolls = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("alertOnceInXPolls", "0"));
                newCollectorHost.DelayErrWarnAlertForXPolls = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("delayErrWarnAlertForXPolls", "0"));
                newCollectorHost.AlertsPaused = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("alertsPaused", "False"));
            }
            #endregion

            #region Corrective scripts
            XmlNode correctiveScriptsNode = xmlCollectorEntry.SelectSingleNode("correctiveScripts");
            if (correctiveScriptsNode != null)
            {
                newCollectorHost.CorrectiveScriptDisabled = !(correctiveScriptsNode.ReadXmlElementAttr("enabled", true));
                //newCollectorHost.CorrectiveScriptsOnlyOnStateChange = correctiveScriptsNode.ReadXmlElementAttr("onlyOnStateChange", true);
                XmlNode warningCorrectiveScriptsNode = correctiveScriptsNode.SelectSingleNode("warning");
                if (warningCorrectiveScriptsNode != null)
                {
                    newCollectorHost.CorrectiveScriptOnWarningMinimumRepeatTimeMin = warningCorrectiveScriptsNode.ReadXmlElementAttr("warningMinRepeatTimeMin", 0);
                    //newCollectorHost.CorrectiveScriptOnWarningPath = warningCorrectiveScriptsNode.InnerText;
                }
                XmlNode errorCorrectiveScriptsNode = correctiveScriptsNode.SelectSingleNode("error");
                if (errorCorrectiveScriptsNode != null)
                {
                    newCollectorHost.CorrectiveScriptOnErrorMinimumRepeatTimeMin = errorCorrectiveScriptsNode.ReadXmlElementAttr("errorMinRepeatTimeMin", 0);
                    //newCollectorHost.CorrectiveScriptOnErrorPath = errorCorrectiveScriptsNode.InnerText;
                }
                XmlNode restorationCorrectiveScriptsNode = correctiveScriptsNode.SelectSingleNode("restoration");
                if (restorationCorrectiveScriptsNode != null)
                {
                    newCollectorHost.RestorationScriptMinimumRepeatTimeMin = restorationCorrectiveScriptsNode.ReadXmlElementAttr("restoreMinRepeatTimeMin", 0);
                    //newCollectorHost.RestorationScriptPath = restorationCorrectiveScriptsNode.InnerText;                    
                }
            }
            else
            {
                newCollectorHost.CorrectiveScriptDisabled = xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptDisabled", false);
                //newCollectorHost.CorrectiveScriptOnWarningPath = xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptOnWarningPath");
                //newCollectorHost.CorrectiveScriptOnErrorPath = xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptOnErrorPath");
                //newCollectorHost.RestorationScriptPath = xmlCollectorEntry.ReadXmlElementAttr("restorationScriptPath");
                //newCollectorHost.CorrectiveScriptsOnlyOnStateChange = xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptsOnlyOnStateChange", false);
            }
            #endregion

            #region Action scripts
            //old idea
            //XmlNode actionScriptsNode = xmlCollectorEntry.SelectSingleNode("collectorActionScripts");
            //if (actionScriptsNode != null)
            //{
            //    newCollectorHost.ActionScripts = CollectorActionScript.FromXml(actionScriptsNode);
            //}
            XmlNode actionScriptsNode = xmlCollectorEntry.SelectSingleNode("actionScripts");
            if (actionScriptsNode != null)
            {
                newCollectorHost.ActionScripts = ActionScript.FromXml(actionScriptsNode);
            }
            #endregion

            #region Service windows
                newCollectorHost.ServiceWindows = new ServiceWindows();
            XmlNode serviceWindowsNode = xmlCollectorEntry.SelectSingleNode("serviceWindows");
            if (serviceWindowsNode != null) //Load service windows info
                newCollectorHost.ServiceWindows.CreateFromConfig(serviceWindowsNode.OuterXml);
            else
            {
                newCollectorHost.ServiceWindows.CreateFromConfig("<serviceWindows />");
            }
            #endregion

            #region Config vars
            newCollectorHost.ConfigVariables = new List<ConfigVariable>();
            XmlNode configVarsNode = xmlCollectorEntry.SelectSingleNode("configVars");
            if (configVarsNode != null)
            {
                foreach (XmlNode configVarNode in configVarsNode.SelectNodes("configVar"))
                {
                    newCollectorHost.ConfigVariables.Add(ConfigVariable.FromXml(configVarNode.OuterXml));
                }
            }
            #endregion

            #region Categories
            newCollectorHost.Categories = new List<string>();
            XmlNode categoriesNode = xmlCollectorEntry.SelectSingleNode("categories");
            if (categoriesNode != null)
                newCollectorHost.CategoriesCreateFromConfig(categoriesNode.OuterXml);
            else
                newCollectorHost.Categories = new List<string>();
            #endregion

            #region Polling
            XmlNode pollingNode = xmlCollectorEntry.SelectSingleNode("polling");
            if (pollingNode != null)
            {
                newCollectorHost.EnabledPollingOverride = pollingNode.ReadXmlElementAttr("enabledPollingOverride", false);
                newCollectorHost.OnlyAllowUpdateOncePerXSec = pollingNode.ReadXmlElementAttr("onlyAllowUpdateOncePerXSec", 1);
                newCollectorHost.EnablePollFrequencySliding = pollingNode.ReadXmlElementAttr("enablePollFrequencySliding", false);
                newCollectorHost.PollSlideFrequencyAfterFirstRepeatSec = pollingNode.ReadXmlElementAttr("pollSlideFrequencyAfterFirstRepeatSec", 2);
                newCollectorHost.PollSlideFrequencyAfterSecondRepeatSec = pollingNode.ReadXmlElementAttr("pollSlideFrequencyAfterSecondRepeatSec", 5);
                newCollectorHost.PollSlideFrequencyAfterThirdRepeatSec = pollingNode.ReadXmlElementAttr("pollSlideFrequencyAfterThirdRepeatSec", 30);
            }
            else
            {
                newCollectorHost.EnabledPollingOverride = xmlCollectorEntry.ReadXmlElementAttr("enabledPollingOverride", false);
                newCollectorHost.OnlyAllowUpdateOncePerXSec = xmlCollectorEntry.ReadXmlElementAttr("onlyAllowUpdateOncePerXSec", 1);
                newCollectorHost.EnablePollFrequencySliding = xmlCollectorEntry.ReadXmlElementAttr("enablePollFrequencySliding", false);
                newCollectorHost.PollSlideFrequencyAfterFirstRepeatSec = xmlCollectorEntry.ReadXmlElementAttr("pollSlideFrequencyAfterFirstRepeatSec", 2);
                newCollectorHost.PollSlideFrequencyAfterSecondRepeatSec = xmlCollectorEntry.ReadXmlElementAttr("pollSlideFrequencyAfterSecondRepeatSec", 5);
                newCollectorHost.PollSlideFrequencyAfterThirdRepeatSec = xmlCollectorEntry.ReadXmlElementAttr("pollSlideFrequencyAfterThirdRepeatSec", 30);
            }
            #endregion

            #region Remote agent/remote hosts
            XmlNode remoteAgentNode = xmlCollectorEntry.SelectSingleNode("remoteAgent");
            if (remoteAgentNode != null)
            {
                newCollectorHost.EnableRemoteExecute = bool.Parse(remoteAgentNode.ReadXmlElementAttr("enableRemoteExecute", "False"));
                newCollectorHost.ForceRemoteExcuteOnChildCollectors = bool.Parse(remoteAgentNode.ReadXmlElementAttr("forceRemoteExcuteOnChildCollectors", "False"));
                newCollectorHost.RemoteAgentHostAddress = remoteAgentNode.ReadXmlElementAttr("remoteAgentHostAddress", "");
                newCollectorHost.RemoteAgentHostPort = remoteAgentNode.ReadXmlElementAttr("remoteAgentHostPort", GlobalConstants.DefaultRemoteHostPort);
                newCollectorHost.BlockParentOverrideRemoteAgentHostSettings = remoteAgentNode.ReadXmlElementAttr("blockParentRemoteAgentHostSettings", false);
                newCollectorHost.RunLocalOnRemoteHostConnectionFailure = remoteAgentNode.ReadXmlElementAttr("runLocalOnRemoteHostConnectionFailure", false);
            }
            else
            {
                newCollectorHost.EnableRemoteExecute = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("enableRemoteExecute", "False"));
                newCollectorHost.ForceRemoteExcuteOnChildCollectors = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("forceRemoteExcuteOnChildCollectors", "False"));
                newCollectorHost.RemoteAgentHostAddress = xmlCollectorEntry.ReadXmlElementAttr("remoteAgentHostAddress");
                newCollectorHost.RemoteAgentHostPort = xmlCollectorEntry.ReadXmlElementAttr("remoteAgentHostPort", GlobalConstants.DefaultRemoteHostPort);
                newCollectorHost.BlockParentOverrideRemoteAgentHostSettings = xmlCollectorEntry.ReadXmlElementAttr("blockParentRemoteAgentHostSettings", false);
                newCollectorHost.RunLocalOnRemoteHostConnectionFailure = xmlCollectorEntry.ReadXmlElementAttr("runLocalOnRemoteHostConnectionFailure", false);
            }
            #endregion

            #region Metrics exports
            XmlNode metricsExportNode = xmlCollectorEntry.SelectSingleNode("metricsExport");
            if (metricsExportNode != null)
            {
                newCollectorHost.ExcludeFromMetrics = metricsExportNode.ReadXmlElementAttr("exclude", false);
            }
            #endregion

            #region collector Agents
            XmlNode collectorAgentsNode = xmlCollectorEntry.SelectSingleNode("collectorAgents");
            if (collectorAgentsNode != null)
            {
                newCollectorHost.AgentCheckSequence = AgentCheckSequenceConverter.FromString(collectorAgentsNode.ReadXmlElementAttr("agentCheckSequence", "All")); //  "All|FirstSuccess|FirstError"
                newCollectorHost.CollectorAgents = new List<ICollector>();
                foreach (XmlElement collectorAgentNode in collectorAgentsNode.SelectNodes("collectorAgent"))
                {
                    string name = collectorAgentNode.ReadXmlElementAttr("name", "");
                    string typeName = collectorAgentNode.ReadXmlElementAttr("type", "");
                    bool enabled = collectorAgentNode.ReadXmlElementAttr("enabled", true);
                    bool primaryUIValue = collectorAgentNode.ReadXmlElementAttr("primaryUIValue", true);
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
                            newAgent.PrimaryUIValue = primaryUIValue;
                            if (configXml.Length > 0)
                                newAgent.InitialConfiguration = configXml;
                            else
                            {
                                if (newAgent.AgentConfig != null)
                                    newAgent.InitialConfiguration = newAgent.AgentConfig.GetDefaultOrEmptyXml();
                                else
                                    newCollectorHost.UpdateCurrentCollectorState(CollectorState.ConfigurationError);
                            }
                            newCollectorHost.CollectorAgents.Add(newAgent);
                            newAgent.AgentConfig.FromXml(newAgent.InitialConfiguration);
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
            #endregion
            return newCollectorHost;
        }

        //public static ICollector GetCollectorAgentFromString(string xmlString, List<ConfigVariable> configVars = null, bool applyConfigVars = true)
        //{
        //    if (xmlString.StartsWith("<collectorAgent"))
        //    {
        //        XmlDocument collectorAgentXml = new XmlDocument();
        //        collectorAgentXml.LoadXml(xmlString);
        //        return GetCollectorAgentFromString(collectorAgentXml.DocumentElement, configVars, applyConfigVars);
        //    }
        //    else
        //        return null;
        //}
        //private static ICollector GetCollectorAgentFromString(XmlElement collectorAgentNode, List<ConfigVariable> configVars = null, bool applyConfigVars = true) //)
        //{
        //    string name = collectorAgentNode.ReadXmlElementAttr("name", "");
        //    string typeName = collectorAgentNode.ReadXmlElementAttr("type", "");
        //    bool enabled = collectorAgentNode.ReadXmlElementAttr("enabled", true);
        //    string configXml = "";
        //    XmlNode configNode = collectorAgentNode.SelectSingleNode("config");
        //    if (configNode != null)
        //    {
        //        configXml = configNode.OuterXml;
        //    }

        //    ICollector newAgent = CreateCollectorFromClassName(typeName);
        //    if (newAgent != null)
        //    {
        //        try
        //        {
        //            newAgent.Name = name;
        //            newAgent.Enabled = enabled;
        //            if (configXml.Length > 0)
        //                newAgent.InitialConfiguration = configXml;
        //            else
        //            {
        //                if (newAgent.AgentConfig != null)
        //                    newAgent.InitialConfiguration = newAgent.AgentConfig.GetDefaultOrEmptyXml();
        //                else
        //                    throw new Exception("Could not create AgentConfig!");
        //            }
        //            string appliedConfig = newAgent.InitialConfiguration;
        //            if (applyConfigVars)
        //            {
        //                appliedConfig = configVars.ApplyOn(appliedConfig);
        //            }
        //            newAgent.ActiveConfiguration = appliedConfig;
        //            newAgent.AgentConfig.FromXml(appliedConfig);
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Diagnostics.Trace.WriteLine(ex.ToString());
        //            throw new Exception(string.Format("Error loading config for {0}: {1}", name, ex.Message));
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception(string.Format("The Collector Host type of '{0}' could not be loaded!", typeName));
        //    }
        //    return newAgent;
        //}
        public static ICollector CreateCollectorFromClassName(string agentClassName)
        {
            ICollector currentAgent = null;
            if (!agentClassName.Contains("."))
                agentClassName = "." + agentClassName;
            RegisteredAgent currentRA = RegisteredAgentCache.GetRegisteredAgentByClassName(agentClassName, true);
            if (currentRA != null)
            {
                if (System.IO.File.Exists(currentRA.AssemblyPath))
                {
                    Assembly collectorEntryAssembly = Assembly.LoadFile(currentRA.AssemblyPath);
                    currentAgent = (ICollector)collectorEntryAssembly.CreateInstance(currentRA.ClassName);
                    currentAgent.AgentClassName = currentRA.ClassName; //.Replace("QuickMon.Collectors.", "");
                    currentAgent.AgentClassDisplayName = currentRA.DisplayName;
                }
            }
            return currentAgent;
        }
        #endregion

        #region ToXml
        public XmlNode ToXmlNode()
        {
            XmlDocument collectorHostNode = new XmlDocument(); 
            string alertingSettingsXml = GetAlertingToXml(RepeatAlertInXMin, AlertOnceInXMin, DelayErrWarnAlertForXSec, RepeatAlertInXPolls, AlertOnceInXPolls, DelayErrWarnAlertForXPolls, AlertsPaused, AlertHeaderText, AlertFooterText, ErrorAlertText, WarningAlertText, GoodAlertText);
            string remoteAgentSettingsXml = GetRemoteAgentConfigXml(EnableRemoteExecute, ForceRemoteExcuteOnChildCollectors, RemoteAgentHostAddress, RemoteAgentHostPort, BlockParentOverrideRemoteAgentHostSettings, RunLocalOnRemoteHostConnectionFailure);
            string metricsExportXml = GetMetricsExportXml(ExcludeFromMetrics);
            string pollingSettingsXml = GetPollingConfigXml(EnabledPollingOverride, OnlyAllowUpdateOncePerXSec, EnablePollFrequencySliding, PollSlideFrequencyAfterFirstRepeatSec, PollSlideFrequencyAfterSecondRepeatSec, PollSlideFrequencyAfterThirdRepeatSec);
            string correctiveScriptsXml = GetCorrectiveScriptsConfigXml(CorrectiveScriptDisabled, CorrectiveScriptOnErrorMinimumRepeatTimeMin, CorrectiveScriptOnWarningMinimumRepeatTimeMin, RestorationScriptMinimumRepeatTimeMin);
            string actionScriptsXml = GetActionScriptsXml(ActionScripts);
            string serviceWindowsXml = ServiceWindows.ToXml();
            string configVariablesXml = GetConfigVarXml(ConfigVariables);
            string categoriesXml = GetCategoriesXML();
            string collectorAgentsXml = GetCollectorAgentsConfigXml(CollectorAgents, AgentCheckSequence);

            collectorHostNode.LoadXml(ToXml(UniqueId,
                ParentCollectorId,
                Name,
                Enabled,
                ExpandOnStartOption,
                ChildCheckBehaviour,
                RunAsEnabled, RunAs,
                Notes,
                alertingSettingsXml,
                remoteAgentSettingsXml,
                metricsExportXml,
                pollingSettingsXml,
                collectorAgentsXml,
                correctiveScriptsXml,
                actionScriptsXml,
                serviceWindowsXml,
                configVariablesXml,
                categoriesXml));
            return collectorHostNode.DocumentElement;
        }

        /// <summary>
        /// Export current (Initial) CollectorHost config as XML string
        /// This is the config before config variables have been applied
        /// </summary>
        /// <returns>XML config string</returns>
        public string ToXml()
        {
            string alertingSettingsXml = GetAlertingToXml(RepeatAlertInXMin, AlertOnceInXMin, DelayErrWarnAlertForXSec, RepeatAlertInXPolls, AlertOnceInXPolls, DelayErrWarnAlertForXPolls, AlertsPaused, AlertHeaderText, AlertFooterText, ErrorAlertText, WarningAlertText, GoodAlertText);
            string remoteAgentSettingsXml = GetRemoteAgentConfigXml(EnableRemoteExecute, ForceRemoteExcuteOnChildCollectors, RemoteAgentHostAddress, RemoteAgentHostPort, BlockParentOverrideRemoteAgentHostSettings, RunLocalOnRemoteHostConnectionFailure);
            string metricsExportXml = GetMetricsExportXml(ExcludeFromMetrics);
            string pollingSettingsXml = GetPollingConfigXml(EnabledPollingOverride, OnlyAllowUpdateOncePerXSec, EnablePollFrequencySliding, PollSlideFrequencyAfterFirstRepeatSec, PollSlideFrequencyAfterSecondRepeatSec, PollSlideFrequencyAfterThirdRepeatSec);
            string correctiveScriptsXml = GetCorrectiveScriptsConfigXml(CorrectiveScriptDisabled, CorrectiveScriptOnErrorMinimumRepeatTimeMin, CorrectiveScriptOnWarningMinimumRepeatTimeMin, RestorationScriptMinimumRepeatTimeMin);
            string actionScriptsXml = GetActionScriptsXml(ActionScripts);           
            string serviceWindowsXml = ServiceWindows.ToXml();
            string configVariablesXml = GetConfigVarXml(ConfigVariables);
            string categoriesXml = GetCategoriesXML();
            string collectorAgentsXml = GetCollectorAgentsConfigXml(CollectorAgents, AgentCheckSequence);

            return ToXml(UniqueId,
                ParentCollectorId,
                Name,
                Enabled,
                ExpandOnStartOption,
                ChildCheckBehaviour,
                RunAsEnabled, RunAs,
                Notes,
                alertingSettingsXml,
                remoteAgentSettingsXml,
                metricsExportXml,
                pollingSettingsXml,
                collectorAgentsXml,
                correctiveScriptsXml,
                actionScriptsXml,
                serviceWindowsXml,
                configVariablesXml,
                categoriesXml);
        }
        public static string ToXml(string uniqueId,
                string parentCollectorId,
                string name,
                bool enabled,
                ExpandOnStartOption expandOnStartOption,
                ChildCheckBehaviour childCheckBehaviour,
                bool runAsEnabled,
                string runAs,
                string notes,

                string alertingSettingsXml,
                string remoteAgentSettingsXml,
                string metricsExportXml,
                string pollingSettingsXml,
                string collectorAgentsXml,
                string correctiveScriptsXml,
                string actionScriptsXml,
                string serviceWindowsXml,
                string configVariablesXml,
                string categoriesXml)
        {
            XmlDocument collectorHostDoc = new XmlDocument();
            collectorHostDoc.LoadXml("<collectorHost>" +
                "<!-- Alerting -->" + alertingSettingsXml +
                "<!-- Collector Agents -->" + collectorAgentsXml +
                "<!-- Polling settings -->" + pollingSettingsXml +
                "<!-- Remote agent settings -->" + remoteAgentSettingsXml +
                "<!-- Metrics Export settings -->" + metricsExportXml +
                "<!-- Corrective Scripts -->" + correctiveScriptsXml +
                "<!-- Action scripts -->" + actionScriptsXml +
                "<!-- ServiceWindows -->" + serviceWindowsXml +
                "<!-- Config variables -->" + configVariablesXml +
                "<!-- Categories -->" + categoriesXml +
                "<notes />" +
                "</collectorHost>");
            collectorHostDoc.DocumentElement.SetAttributeValue("uniqueId", uniqueId);
            collectorHostDoc.DocumentElement.SetAttributeValue("dependOnParentId", parentCollectorId);
            collectorHostDoc.DocumentElement.SetAttributeValue("name", name);
            collectorHostDoc.DocumentElement.SetAttributeValue("enabled", enabled);
            collectorHostDoc.DocumentElement.SetAttributeValue("expandOnStart", expandOnStartOption.ToString());
            collectorHostDoc.DocumentElement.SetAttributeValue("childCheckBehaviour", childCheckBehaviour.ToString());
            collectorHostDoc.DocumentElement.SetAttributeValue("runAsEnabled", runAsEnabled);
            collectorHostDoc.DocumentElement.SetAttributeValue("runAs", runAs);
            if (notes != null && notes.Trim(' ', '\r', '\n').Length > 0)
                collectorHostDoc.DocumentElement.SelectSingleNode("notes").InnerText = notes.Trim(' ', '\r', '\n');

            return collectorHostDoc.DocumentElement.OuterXml;
        }
        /// <summary>
        /// For use to create CollectorHost instance from RemoteCollectorAgent
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <param name="name"></param>
        /// <param name="enabled"></param>
        /// <param name="childCheckBehaviour"></param>
        /// <param name="runAsEnabled"></param>
        /// <param name="runAs"></param>
        /// <param name="collectorAgentsXml"></param>
        /// <returns></returns>
        public static string ToXml(string uniqueId,
                string name,
                bool enabled,
                ChildCheckBehaviour childCheckBehaviour,
                bool runAsEnabled,
                string runAs,
                string collectorAgentsXml
                )
        {
            XmlDocument collectorHostDoc = new XmlDocument();
            collectorHostDoc.LoadXml("<collectorHost>" +
                "<!-- Collector Agents -->" + collectorAgentsXml +
                "</collectorHost>");
            collectorHostDoc.DocumentElement.SetAttributeValue("uniqueId", uniqueId);
            collectorHostDoc.DocumentElement.SetAttributeValue("name", name);
            collectorHostDoc.DocumentElement.SetAttributeValue("enabled", enabled);
            collectorHostDoc.DocumentElement.SetAttributeValue("childCheckBehaviour", childCheckBehaviour.ToString());
            collectorHostDoc.DocumentElement.SetAttributeValue("runAsEnabled", runAsEnabled);
            collectorHostDoc.DocumentElement.SetAttributeValue("runAs", runAs);

            return collectorHostDoc.DocumentElement.OuterXml;
        }

        public static string CollectorHostListToString(List<CollectorHost> entries)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<collectorHosts>");
            foreach (CollectorHost entry in entries)
            {
                sb.AppendLine(entry.ToXml());
            }
            sb.AppendLine("</collectorHosts>");
            return sb.ToString();
        }
        //public static string ToXml(string uniqueId,
        //        string name,
        //        bool enabled,
        //        ExpandOnStartOption expandOnStartOption,
        //        string parentCollectorId,
        //        AgentCheckSequence agentCheckSequence,
        //        ChildCheckBehaviour childCheckBehaviour,
        //        int repeatAlertInXMin, int alertOnceInXMin, int delayErrWarnAlertForXSec,
        //        int repeatAlertInXPolls, int alertOnceInXPolls, int delayErrWarnAlertForXPolls,
        //        bool correctiveScriptDisabled, string correctiveScriptOnWarningPath, string correctiveScriptOnErrorPath,
        //        string restorationScriptPath, bool correctiveScriptsOnlyOnStateChange, bool enableRemoteExecute,
        //        bool forceRemoteExcuteOnChildCollectors, string remoteAgentHostAddress, int remoteAgentHostPort,
        //        bool blockParentOverrideRemoteAgentHostSettings, bool runLocalOnRemoteHostConnectionFailure,
        //        bool enabledPollingOverride,
        //        int onlyAllowUpdateOncePerXSec,
        //        bool enablePollFrequencySliding,
        //        int pollSlideFrequencyAfterFirstRepeatSec,
        //        int pollSlideFrequencyAfterSecondRepeatSec,
        //        int pollSlideFrequencyAfterThirdRepeatSec,
        //        bool alertsPaused,
        //        bool runAsEnabled,
        //        string runAs,
        //        string collectorAgentsXml,
        //        string actionScriptsXml,
        //        string serviceWindowsXml,
        //        string configVariablesXml,
        //        string categoriesXml,
        //        string notes,
        //        string generalAlertText,
        //        string errorAlertText,
        //        string warningAlertText,
        //        string goodAlertText 
        //    )
        //{
        //    string correctiveScriptsXml = GetCorrectiveScriptsConfigXml(correctiveScriptDisabled, correctiveScriptsOnlyOnStateChange, correctiveScriptOnWarningPath, correctiveScriptOnErrorPath, restorationScriptPath);

        //    StringBuilder configXml = new StringBuilder();
        //    XmlDocument collectorHostDoc = new XmlDocument();
        //    collectorHostDoc.LoadXml("<collectorHost>" +
        //        "<!-- alerting -->" + GetAlertingToXml(repeatAlertInXMin, alertOnceInXMin, delayErrWarnAlertForXSec, repeatAlertInXPolls, alertOnceInXPolls, delayErrWarnAlertForXPolls, alertsPaused, generalAlertText, errorAlertText, warningAlertText, goodAlertText) +
        //        "<!-- Corrective Scripts -->" + correctiveScriptsXml +
        //        "<!-- CollectorAgents -->" + collectorAgentsXml +
        //        "<!-- Action scripts -->" + actionScriptsXml +
        //        "<!-- ServiceWindows -->" + serviceWindowsXml +
        //        "<!-- Config variables -->" + configVariablesXml +
        //        "<!-- Categories -->" + categoriesXml +
        //        "<notes />" +
        //        "</collectorHost>");
        //    collectorHostDoc.DocumentElement.SetAttributeValue("uniqueId", uniqueId);
        //    collectorHostDoc.DocumentElement.SetAttributeValue("dependOnParentId", parentCollectorId);
        //    collectorHostDoc.DocumentElement.SetAttributeValue("name", name);
        //    collectorHostDoc.DocumentElement.SetAttributeValue("enabled", enabled);
        //    collectorHostDoc.DocumentElement.SetAttributeValue("expandOnStart", expandOnStartOption.ToString());
        //    collectorHostDoc.DocumentElement.SetAttributeValue("agentCheckSequence", agentCheckSequence.ToString());
        //    collectorHostDoc.DocumentElement.SetAttributeValue("childCheckBehaviour", childCheckBehaviour.ToString());

        //    collectorHostDoc.DocumentElement.SetAttributeValue("enableRemoteExecute", enableRemoteExecute);
        //    collectorHostDoc.DocumentElement.SetAttributeValue("forceRemoteExcuteOnChildCollectors", forceRemoteExcuteOnChildCollectors);
        //    collectorHostDoc.DocumentElement.SetAttributeValue("remoteAgentHostAddress", remoteAgentHostAddress);
        //    collectorHostDoc.DocumentElement.SetAttributeValue("remoteAgentHostPort", remoteAgentHostPort);
        //    collectorHostDoc.DocumentElement.SetAttributeValue("blockParentRemoteAgentHostSettings", blockParentOverrideRemoteAgentHostSettings);
        //    collectorHostDoc.DocumentElement.SetAttributeValue("runLocalOnRemoteHostConnectionFailure", runLocalOnRemoteHostConnectionFailure);

        //    collectorHostDoc.DocumentElement.SetAttributeValue("enabledPollingOverride", enabledPollingOverride);
        //    collectorHostDoc.DocumentElement.SetAttributeValue("onlyAllowUpdateOncePerXSec", onlyAllowUpdateOncePerXSec);
        //    collectorHostDoc.DocumentElement.SetAttributeValue("enablePollFrequencySliding", enablePollFrequencySliding);
        //    collectorHostDoc.DocumentElement.SetAttributeValue("pollSlideFrequencyAfterFirstRepeatSec", pollSlideFrequencyAfterFirstRepeatSec);
        //    collectorHostDoc.DocumentElement.SetAttributeValue("pollSlideFrequencyAfterSecondRepeatSec", pollSlideFrequencyAfterSecondRepeatSec);
        //    collectorHostDoc.DocumentElement.SetAttributeValue("pollSlideFrequencyAfterThirdRepeatSec", pollSlideFrequencyAfterThirdRepeatSec);

        //    collectorHostDoc.DocumentElement.SetAttributeValue("runAsEnabled", runAsEnabled);
        //    collectorHostDoc.DocumentElement.SetAttributeValue("runAs", runAs);
        //    collectorHostDoc.DocumentElement.SelectSingleNode("notes").InnerText = notes;

        //    return collectorHostDoc.DocumentElement.OuterXml;

        //    /*
        //    configXml.AppendLine(string.Format("<collectorHost uniqueId=\"{0}\" name=\"{1}\" enabled=\"{2}\" expandOnStart=\"{3}\" dependOnParentId=\"{4}\" " +
        //              "agentCheckSequence=\"{5}\" childCheckBehaviour=\"{6}\" " +
        //              "repeatAlertInXMin=\"{7}\" alertOnceInXMin=\"{8}\" delayErrWarnAlertForXSec=\"{9}\" " +
        //              "repeatAlertInXPolls=\"{10}\" alertOnceInXPolls=\"{11}\" delayErrWarnAlertForXPolls=\"{12}\" " +
        //              "correctiveScriptDisabled=\"{13}\" correctiveScriptOnWarningPath=\"{14}\" correctiveScriptOnErrorPath=\"{15}\" " +
        //              "restorationScriptPath=\"{16}\" correctiveScriptsOnlyOnStateChange=\"{17}\" enableRemoteExecute=\"{18}\" " +
        //              "forceRemoteExcuteOnChildCollectors=\"{19}\" remoteAgentHostAddress=\"{20}\" remoteAgentHostPort=\"{21}\" " +
        //              "blockParentRemoteAgentHostSettings=\"{22}\" runLocalOnRemoteHostConnectionFailure=\"{23}\" " +
        //              "enabledPollingOverride=\"{24}\" onlyAllowUpdateOncePerXSec=\"{25}\" enablePollFrequencySliding=\"{26}\" " +
        //              "pollSlideFrequencyAfterFirstRepeatSec=\"{27}\" pollSlideFrequencyAfterSecondRepeatSec=\"{28}\" " + 
        //              "pollSlideFrequencyAfterThirdRepeatSec=\"{29}\" alertsPaused=\"{30}\" runAsEnabled=\"{31}\" runAs=\"{32}\" >",
        //                uniqueId, name.EscapeXml(), enabled, 
        //                expandOnStartOption.ToString(),
        //                parentCollectorId,
        //                agentCheckSequence, childCheckBehaviour,

        //                repeatAlertInXMin, alertOnceInXMin, delayErrWarnAlertForXSec,
        //                repeatAlertInXPolls, alertOnceInXPolls, delayErrWarnAlertForXPolls,

        //                correctiveScriptDisabled, correctiveScriptOnWarningPath.EscapeXml(), correctiveScriptOnErrorPath.EscapeXml(),
        //                restorationScriptPath.EscapeXml(), correctiveScriptsOnlyOnStateChange, 

        //                enableRemoteExecute, forceRemoteExcuteOnChildCollectors, remoteAgentHostAddress, remoteAgentHostPort,
        //                blockParentOverrideRemoteAgentHostSettings, runLocalOnRemoteHostConnectionFailure,
        //                enabledPollingOverride, onlyAllowUpdateOncePerXSec, enablePollFrequencySliding,
        //                pollSlideFrequencyAfterFirstRepeatSec, pollSlideFrequencyAfterSecondRepeatSec, pollSlideFrequencyAfterThirdRepeatSec,

        //                alertsPaused, runAsEnabled, runAs.EscapeXml()
        //              )
        //             );

        //    configXml.AppendLine("<!-- alerting -->");
        //    configXml.AppendLine(GetAlertingToXml(repeatAlertInXMin, alertOnceInXMin, delayErrWarnAlertForXSec,
        //                repeatAlertInXPolls, alertOnceInXPolls, delayErrWarnAlertForXPolls, alertsPaused));


        //    configXml.AppendLine("<!-- Corrective Scripts -->");
        //    configXml.AppendLine("<correctiveScripts enabled=\"" + (correctiveScriptDisabled ? "False" : "True") + "\" onlyOnStateChange=\"" + (correctiveScriptsOnlyOnStateChange ? "True" : "False") + "\">");
        //    if (correctiveScriptOnWarningPath == null || correctiveScriptOnWarningPath.Trim().Length == 0)
        //        configXml.AppendLine("<warning />");
        //    else
        //        configXml.AppendLine("<warning>" + correctiveScriptOnWarningPath.Trim('\r','\n').EscapeXml() + "</warning>");
        //    if (correctiveScriptOnErrorPath == null || correctiveScriptOnErrorPath.Trim().Length == 0)
        //        configXml.AppendLine("<error/>");
        //    else
        //        configXml.AppendLine("<error>" + correctiveScriptOnErrorPath.Trim('\r', '\n').EscapeXml() + "</error>");
        //    if (restorationScriptPath == null || restorationScriptPath.Trim().Length == 0)
        //        configXml.AppendLine("<restoration/>");
        //    else
        //        configXml.AppendLine("<restoration>" + restorationScriptPath.Trim('\r', '\n').EscapeXml() + "</restoration>");
        //    configXml.AppendLine("</correctiveScripts>");

        //    configXml.AppendLine("<!-- CollectorAgents -->");
        //    configXml.AppendLine(collectorAgentsXml);

        //    configXml.AppendLine("<!-- Action scripts -->");
        //    configXml.AppendLine(actionScriptsXml);

        //    configXml.AppendLine("<!-- ServiceWindows -->");
        //    configXml.AppendLine(serviceWindowsXml);
        //    configXml.AppendLine("<!-- Config variables -->");
        //    configXml.AppendLine(configVariablesXml);
        //    configXml.AppendLine("<!-- Categories -->");
        //    configXml.AppendLine(categoriesXml);
        //    configXml.AppendLine("</collectorHost>");
        //    return configXml.ToString();
        //    */
        //}

        public static string GetCollectorAgentsConfigXml(List<ICollector> collectorAgents, AgentCheckSequence agentCheckSequence)
        {
            StringBuilder collectorAgentsXml = new StringBuilder();
            collectorAgentsXml.AppendLine(string.Format("<collectorAgents agentCheckSequence=\"{0}\" >", agentCheckSequence));

            foreach (ICollector c in collectorAgents)
            {
                collectorAgentsXml.AppendLine(string.Format("<collectorAgent name=\"{0}\" type=\"{1}\" enabled=\"{2}\" primaryUIValue=\"{3}\">", c.Name.EscapeXml(), c.AgentClassName.EscapeXml(), c.Enabled, c.PrimaryUIValue));
#if DEBUG
                System.Diagnostics.Trace.WriteLine("Initial config: " + c.InitialConfiguration);
                System.Diagnostics.Trace.WriteLine("Active config: " + c.ActiveConfiguration);
                System.Diagnostics.Trace.WriteLine("Applied config: " + c.AgentConfig.ToXml());
#endif
                collectorAgentsXml.AppendLine(c.InitialConfiguration);
                collectorAgentsXml.AppendLine("</collectorAgent>");
            }
            collectorAgentsXml.AppendLine("</collectorAgents>");
            return collectorAgentsXml.ToString();
        }

        public static string GetRemoteCollectorAgentsConfigXml(List<RemoteCollectorAgent> collectorAgents, AgentCheckSequence agentCheckSequence)
        {
            StringBuilder collectorAgentsXml = new StringBuilder();
            collectorAgentsXml.AppendLine(string.Format("<collectorAgents agentCheckSequence=\"{0}\" >", agentCheckSequence));

            foreach (RemoteCollectorAgent c in collectorAgents)
            {
                collectorAgentsXml.AppendLine(string.Format("<collectorAgent name=\"{0}\" type=\"{1}\" enabled=\"{2}\">", c.Name, c.TypeName, c.Enabled));
#if DEBUG
                System.Diagnostics.Trace.WriteLine("Applied config: " + c.ConfigString);
#endif
                collectorAgentsXml.AppendLine(c.ConfigString);
                collectorAgentsXml.AppendLine("</collectorAgent>");
            }
            collectorAgentsXml.AppendLine("</collectorAgents>");
            return collectorAgentsXml.ToString();
        }
        private static string GetAlertingToXml(int repeatAlertInXMin, int alertOnceInXMin, int delayErrWarnAlertForXSec,
                int repeatAlertInXPolls, int alertOnceInXPolls, int delayErrWarnAlertForXPolls, bool alertsPaused,
                string alertHeaderText, string alertFooterText,
                string errorAlertText,
                string warningAlertText,
                string goodAlertText
            )
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<alerting><suppression /><texts><header /><footer /><error /><warning /><good /></texts></alerting>");
            XmlNode suppressionNode = xdoc.DocumentElement.SelectSingleNode("suppression");
            suppressionNode.SetAttributeValue("repeatAlertInXMin", repeatAlertInXMin);
            suppressionNode.SetAttributeValue("alertOnceInXMin", alertOnceInXMin);
            suppressionNode.SetAttributeValue("delayErrWarnAlertForXSec", delayErrWarnAlertForXSec);
            suppressionNode.SetAttributeValue("repeatAlertInXPolls", repeatAlertInXPolls);
            suppressionNode.SetAttributeValue("alertOnceInXPolls", alertOnceInXPolls);
            suppressionNode.SetAttributeValue("delayErrWarnAlertForXPolls", delayErrWarnAlertForXPolls);
            suppressionNode.SetAttributeValue("alertsPaused", alertsPaused);
            if (alertHeaderText != null && alertHeaderText.Trim(' ', '\r', '\n').Length > 0)
                xdoc.DocumentElement.SelectSingleNode("texts/header").InnerText = alertHeaderText.Trim(' ', '\r', '\n');
            if (alertFooterText != null && alertFooterText.Trim(' ', '\r', '\n').Length > 0)
                xdoc.DocumentElement.SelectSingleNode("texts/footer").InnerText = alertFooterText.Trim(' ', '\r', '\n');
            if (errorAlertText != null && errorAlertText.Trim(' ', '\r', '\n').Length > 0)
                xdoc.DocumentElement.SelectSingleNode("texts/error").InnerText = errorAlertText.Trim(' ', '\r', '\n');
            if (warningAlertText != null && warningAlertText.Trim(' ', '\r', '\n').Length > 0)
                xdoc.DocumentElement.SelectSingleNode("texts/warning").InnerText = warningAlertText.Trim(' ', '\r', '\n');
            if (goodAlertText != null && goodAlertText.Trim(' ', '\r', '\n').Length > 0)
                xdoc.DocumentElement.SelectSingleNode("texts/good").InnerText = goodAlertText.Trim(' ', '\r', '\n');

            return xdoc.DocumentElement.OuterXml;
        }

        private static string GetRemoteAgentConfigXml(bool enableRemoteExecute,
            bool forceRemoteExcuteOnChildCollectors,
            string remoteAgentHostAddress,
            int remoteAgentHostPort,
            bool blockParentOverrideRemoteAgentHostSettings,
            bool runLocalOnRemoteHostConnectionFailure)
        {
            XmlDocument remoteDoc = new XmlDocument();
            remoteDoc.LoadXml("<remoteAgent />");

            remoteDoc.DocumentElement.SetAttributeValue("enableRemoteExecute", enableRemoteExecute);
            remoteDoc.DocumentElement.SetAttributeValue("forceRemoteExcuteOnChildCollectors", forceRemoteExcuteOnChildCollectors);
            remoteDoc.DocumentElement.SetAttributeValue("remoteAgentHostAddress", remoteAgentHostAddress);
            remoteDoc.DocumentElement.SetAttributeValue("remoteAgentHostPort", remoteAgentHostPort);
            remoteDoc.DocumentElement.SetAttributeValue("blockParentRemoteAgentHostSettings", blockParentOverrideRemoteAgentHostSettings);
            remoteDoc.DocumentElement.SetAttributeValue("runLocalOnRemoteHostConnectionFailure", runLocalOnRemoteHostConnectionFailure);

            return remoteDoc.DocumentElement.OuterXml;
        }

        private static string GetMetricsExportXml(bool excludeFromMetrics)
        {
            XmlDocument metricsExportDoc = new XmlDocument();
            metricsExportDoc.LoadXml("<metricsExport />");
            metricsExportDoc.DocumentElement.SetAttributeValue("exclude", excludeFromMetrics);
            return metricsExportDoc.DocumentElement.OuterXml;
        }

        private static string GetPollingConfigXml(bool enabledPollingOverride, int onlyAllowUpdateOncePerXSec,
            bool enablePollFrequencySliding, int pollSlideFrequencyAfterFirstRepeatSec, int pollSlideFrequencyAfterSecondRepeatSec, int pollSlideFrequencyAfterThirdRepeatSec)
        {
            XmlDocument pollingSettingsDoc = new XmlDocument();
            pollingSettingsDoc.LoadXml("<polling />");

            pollingSettingsDoc.DocumentElement.SetAttributeValue("enabledPollingOverride", enabledPollingOverride);
            pollingSettingsDoc.DocumentElement.SetAttributeValue("onlyAllowUpdateOncePerXSec", onlyAllowUpdateOncePerXSec);
            pollingSettingsDoc.DocumentElement.SetAttributeValue("enablePollFrequencySliding", enablePollFrequencySliding);
            pollingSettingsDoc.DocumentElement.SetAttributeValue("pollSlideFrequencyAfterFirstRepeatSec", pollSlideFrequencyAfterFirstRepeatSec);
            pollingSettingsDoc.DocumentElement.SetAttributeValue("pollSlideFrequencyAfterSecondRepeatSec", pollSlideFrequencyAfterSecondRepeatSec);
            pollingSettingsDoc.DocumentElement.SetAttributeValue("pollSlideFrequencyAfterThirdRepeatSec", pollSlideFrequencyAfterThirdRepeatSec);

            return pollingSettingsDoc.DocumentElement.OuterXml;
        }
        private static string GetCorrectiveScriptsConfigXml(bool correctiveScriptDisabled, // bool correctiveScriptsOnlyOnStateChange,
            //string correctiveScriptOnWarningPath, string correctiveScriptOnErrorPath, string restorationScriptPath,
            int correctiveScriptOnErrorMinimumRepeatTimeMin, int correctiveScriptOnWarningMinimumRepeatTimeMin, int restorationScriptMinimumRepeatTimeMin) 
        {
            XmlDocument correctiveScriptsDoc = new XmlDocument();
            correctiveScriptsDoc.LoadXml("<correctiveScripts><warning /><error/><restoration/></correctiveScripts>");

            correctiveScriptsDoc.DocumentElement.SetAttributeValue("enabled", (correctiveScriptDisabled ? "False" : "True"));
            //correctiveScriptsDoc.DocumentElement.SetAttributeValue("onlyOnStateChange", correctiveScriptsOnlyOnStateChange);

            XmlNode warningNode = correctiveScriptsDoc.DocumentElement.SelectSingleNode("warning");
            warningNode.SetAttributeValue("warningMinRepeatTimeMin", correctiveScriptOnWarningMinimumRepeatTimeMin);
            XmlNode errorNode = correctiveScriptsDoc.DocumentElement.SelectSingleNode("error");
            errorNode.SetAttributeValue("errorMinRepeatTimeMin", correctiveScriptOnErrorMinimumRepeatTimeMin);
            XmlNode restoreNode = correctiveScriptsDoc.DocumentElement.SelectSingleNode("restoration");
            restoreNode.SetAttributeValue("restoreMinRepeatTimeMin", restorationScriptMinimumRepeatTimeMin);

            //if (correctiveScriptOnWarningPath != null && correctiveScriptOnWarningPath.Trim(' ', '\r', '\n').Length > 0)
            //    warningNode.InnerText = correctiveScriptOnWarningPath.Trim(' ', '\r', '\n');            
            //if (correctiveScriptOnErrorPath != null && correctiveScriptOnErrorPath.Trim(' ', '\r', '\n').Length > 0)
            //    errorNode.InnerText = correctiveScriptOnErrorPath.Trim(' ', '\r', '\n');
            //if (restorationScriptPath != null && restorationScriptPath.Trim(' ', '\r','\n').Length > 0)
            //    restoreNode.InnerText = restorationScriptPath.Trim(' ', '\r', '\n');
            return correctiveScriptsDoc.DocumentElement.OuterXml;       
        }
        private static string GetConfigVarXml(List<ConfigVariable> configVariables)
        {
            StringBuilder configVarXml = new StringBuilder();
            if (configVariables == null || configVariables.Count == 0)
                configVarXml.AppendLine("<configVars />");
            else
            {
                configVarXml.AppendLine("<configVars>");
                foreach (ConfigVariable cv in configVariables)
                {
                    configVarXml.AppendLine(cv.ToXml());
                }
                configVarXml.AppendLine("</configVars>");
            }
            return configVarXml.ToString();
        }
        private static string GetActionScriptsXml(List<ActionScript> actionScripts)
        {
            StringBuilder actionScriptsXml = new StringBuilder();
            if (actionScripts != null && actionScripts.Count > 0)
            {
                actionScriptsXml.AppendLine("<actionScripts>");
                foreach (ActionScript acs in actionScripts)
                {
                    actionScriptsXml.AppendLine(acs.ToXml());
                }
                actionScriptsXml.AppendLine("</actionScripts>");
            }
            else
                actionScriptsXml.AppendLine("<actionScripts />");
            return actionScriptsXml.ToString();
        }
        #endregion

        public CollectorHost Clone(bool newId = false)
        {
            CollectorHost clone = FromXml(ToXml());
            if (newId)
                clone.UniqueId = Guid.NewGuid().ToString();
            return clone;
        }
    }
}
