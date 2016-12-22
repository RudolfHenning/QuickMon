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
        public static CollectorHost FromXml(string xmlString, List<ConfigVariable> monitorPackVars = null, bool applyConfigVars = false)
        {
            if (xmlString != null && xmlString.Length > 0 && xmlString.StartsWith("<collectorHost"))
            {
                XmlDocument collectorHostDoc = new XmlDocument();
                collectorHostDoc.LoadXml(xmlString);
                XmlElement root = collectorHostDoc.DocumentElement;
                return FromConfig(null, root, monitorPackVars, applyConfigVars);
            }
            else
                return null;
        }
        private static CollectorHost FromConfig(CollectorHost newCollectorHost, XmlElement xmlCollectorEntry, List<ConfigVariable> monitorPackVars = null, bool applyConfigVars = true)
        {
            if (newCollectorHost == null)
                newCollectorHost = new CollectorHost();
            newCollectorHost.Name = xmlCollectorEntry.ReadXmlElementAttr("name", "").Trim();
            string uniqueId = xmlCollectorEntry.ReadXmlElementAttr("uniqueId", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
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
                newCollectorHost.CorrectiveScriptsOnlyOnStateChange = correctiveScriptsNode.ReadXmlElementAttr("onlyOnStateChange", true);
                XmlNode warningCorrectiveScriptsNode = correctiveScriptsNode.SelectSingleNode("warning");
                if (warningCorrectiveScriptsNode != null)
                {
                    newCollectorHost.CorrectiveScriptOnWarningPath = warningCorrectiveScriptsNode.InnerText;
                }
                XmlNode errorCorrectiveScriptsNode = correctiveScriptsNode.SelectSingleNode("error");
                if (errorCorrectiveScriptsNode != null)
                {
                    newCollectorHost.CorrectiveScriptOnErrorPath = errorCorrectiveScriptsNode.InnerText;
                }
                XmlNode restorationCorrectiveScriptsNode = correctiveScriptsNode.SelectSingleNode("restoration");
                if (restorationCorrectiveScriptsNode != null)
                {
                    newCollectorHost.RestorationScriptPath = restorationCorrectiveScriptsNode.InnerText;
                }
            }
            else
            {
                newCollectorHost.CorrectiveScriptDisabled = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptDisabled", "False"));
                newCollectorHost.CorrectiveScriptOnWarningPath = xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptOnWarningPath");
                newCollectorHost.CorrectiveScriptOnErrorPath = xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptOnErrorPath");
                newCollectorHost.RestorationScriptPath = xmlCollectorEntry.ReadXmlElementAttr("restorationScriptPath");
                newCollectorHost.CorrectiveScriptsOnlyOnStateChange = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptsOnlyOnStateChange", "False"));
            }
            #endregion

            #region Action scripts
            XmlNode actionScriptsNode = xmlCollectorEntry.SelectSingleNode("actionScripts");
            if (actionScriptsNode != null)
            {
                newCollectorHost.ActionScripts = ActionScript.FromXml(actionScriptsNode.OuterXml);
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
        public static ICollector CreateCollectorFromClassName(string agentClassName)
        {
            ICollector currentAgent = null;
            RegisteredAgent currentRA = RegisteredAgentCache.GetRegisteredAgentByClassName("." + agentClassName, true);
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
                "<!-- Collector Agents -->" + collectorAgentsXml + "</collectorHost>");
            collectorHostDoc.DocumentElement.SetAttributeValue("uniqueId", uniqueId);
            collectorHostDoc.DocumentElement.SetAttributeValue("name", name);
            collectorHostDoc.DocumentElement.SetAttributeValue("enabled", enabled);
            collectorHostDoc.DocumentElement.SetAttributeValue("childCheckBehaviour", childCheckBehaviour.ToString());
            collectorHostDoc.DocumentElement.SetAttributeValue("runAsEnabled", runAsEnabled);
            collectorHostDoc.DocumentElement.SetAttributeValue("runAs", runAs);

            return collectorHostDoc.DocumentElement.OuterXml;
        }
        public static string GetRemoteCollectorAgentsConfigXml(List<RemoteCollectorAgent> collectorAgents, AgentCheckSequence agentCheckSequence)
        {
            StringBuilder collectorAgentsXml = new StringBuilder();
            collectorAgentsXml.AppendLine(string.Format("<collectorAgents agentCheckSequence=\"{0}\" >", agentCheckSequence));

            foreach (RemoteCollectorAgent c in collectorAgents)
            {
                collectorAgentsXml.AppendLine(string.Format("<collectorAgent name=\"{0}\" type=\"{1}\" enabled=\"{2}\">", c.Name, c.TypeName, c.Enabled));
                System.Diagnostics.Trace.WriteLine("Initial config: " + c.ConfigString);
                System.Diagnostics.Trace.WriteLine("Applied config: " + c.ConfigString);
                collectorAgentsXml.AppendLine(c.ConfigString);
                collectorAgentsXml.AppendLine("</collectorAgent>");
            }
            collectorAgentsXml.AppendLine("</collectorAgents>");
            return collectorAgentsXml.ToString();
        }
        #endregion
    }
}
