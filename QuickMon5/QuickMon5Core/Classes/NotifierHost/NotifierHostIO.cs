﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public partial class NotifierHost
    {
        public static List<NotifierHost> GetNotifierHosts(XmlNode notifierHostsNode, MonitorPack parentMonitorPack = null) //, List<ConfigVariable> monitorPackVars = null)
        {
            List<NotifierHost> notifierHosts = new List<NotifierHost>();
            foreach (XmlElement xmlNotifierHost in notifierHostsNode.SelectNodes("notifierHost"))
            {
                NotifierHost newNotifierHost = NotifierHost.FromConfig(null, xmlNotifierHost); //, monitorPackVars);
                newNotifierHost.ParentMonitorPack = parentMonitorPack;
                notifierHosts.Add(newNotifierHost);
            }
            return notifierHosts;
        }
        public static List<NotifierHost> GetNotifierHostsFromString(string xmlString, List<ConfigVariable> monitorPackVars = null)
        {
            if (xmlString != null && xmlString.StartsWith("<?xml "))
            {
                xmlString = xmlString.Substring(xmlString.IndexOf('>') + 1).Trim(' ', '\r', '\n');
            }
            List<NotifierHost> notifierHosts = new List<NotifierHost>();
            XmlDocument notifierHostsXml = new XmlDocument();
            notifierHostsXml.LoadXml(xmlString);
            notifierHosts = GetNotifierHosts(notifierHostsXml.DocumentElement); //, monitorPackVars);            
            return notifierHosts;
        }
        public static NotifierHost FromXml(string xmlString, List<ConfigVariable> monitorPackVars = null, bool applyConfigVars = false)
        {
            if (xmlString != null && xmlString.StartsWith("<?xml "))
            {
                xmlString = xmlString.Substring(xmlString.IndexOf('>') + 1).Trim(' ', '\r', '\n');
            }
            if (xmlString != null && xmlString.Length > 0 && xmlString.StartsWith("<notifierHost"))
            {
                XmlDocument notifierHostDoc = new XmlDocument();
                notifierHostDoc.LoadXml(xmlString);
                XmlElement root = notifierHostDoc.DocumentElement;
                return FromConfig(null, root); //, monitorPackVars, applyConfigVars);
            }
            else
                return null;
        }
        public void ReconfigureFromXml(string xmlString) //, List<ConfigVariable> monitorPackVars = null, bool applyConfigVars = true)
        {
            if (xmlString != null && xmlString.StartsWith("<?xml "))
            {
                xmlString = xmlString.Substring(xmlString.IndexOf('>') + 1).Trim(' ', '\r', '\n');
            }
            if (xmlString != null && xmlString.Length > 0 && xmlString.StartsWith("<notifierHost"))
            {
                XmlDocument notifierHostDoc = new XmlDocument();
                notifierHostDoc.LoadXml(xmlString);
                XmlElement root = notifierHostDoc.DocumentElement;
                FromConfig(this, root); //, monitorPackVars, applyConfigVars);
            }
        }

        private static NotifierHost FromConfig(NotifierHost newNotifierHost, XmlElement xmlNotifierHost) //, List<ConfigVariable> monitorPackVars, bool applyConfigVars = true)
        {
            if (newNotifierHost == null)
                newNotifierHost = new NotifierHost();
            newNotifierHost.Name = xmlNotifierHost.ReadXmlElementAttr("name", "").Trim();
            newNotifierHost.Enabled = xmlNotifierHost.ReadXmlElementAttr("enabled", true);
            newNotifierHost.AlertLevel = (AlertLevel)Enum.Parse(typeof(AlertLevel), xmlNotifierHost.ReadXmlElementAttr("alertLevel", "Warning"));
            newNotifierHost.DetailLevel = (DetailLevel)Enum.Parse(typeof(DetailLevel), xmlNotifierHost.ReadXmlElementAttr("detailLevel", "Detail"));
            newNotifierHost.AttendedOptionOverride = (AttendedOption)Enum.Parse(typeof(AttendedOption), xmlNotifierHost.ReadXmlElementAttr("attendedOptionOverride", "AttendedAndUnAttended"));

            //Service windows config
            newNotifierHost.ServiceWindows = new ServiceWindows();
            XmlNode serviceWindowsNode = xmlNotifierHost.SelectSingleNode("serviceWindows");
            if (serviceWindowsNode != null) //Load service windows info
                newNotifierHost.ServiceWindows.CreateFromConfig(serviceWindowsNode.OuterXml);
            else
            {
                newNotifierHost.ServiceWindows.CreateFromConfig("<serviceWindows />");
            }
            //Categories
            XmlNode categoriesNode = xmlNotifierHost.SelectSingleNode("categories");
            if (categoriesNode != null)
                newNotifierHost.CategoriesCreateFromConfig(categoriesNode.OuterXml);
            else
                newNotifierHost.Categories = new List<string>();

            XmlNode collectorsNode = xmlNotifierHost.SelectSingleNode("collectorHosts");
            if (collectorsNode != null)
            {
                newNotifierHost.AlertForCollectors = new List<string>();
                foreach (XmlElement colNode in collectorsNode.SelectNodes("collectorHost"))
                {
                    string collectorName = colNode.ReadXmlElementAttr("name", "");
                    if (collectorName.Length > 0)
                        newNotifierHost.AlertForCollectors.Add(collectorName);
                }
            }
            XmlNode configVarsNode = xmlNotifierHost.SelectSingleNode("configVars");
            if (configVarsNode != null)
            {
                newNotifierHost.ConfigVariables = new List<ConfigVariable>();
                foreach (XmlNode configVarNode in configVarsNode.SelectNodes("configVar"))
                {
                    newNotifierHost.ConfigVariables.Add(ConfigVariable.FromXml(configVarNode.OuterXml));
                }
            }

            //OnlyRecordAlertOnHosts
            XmlNode recordOnHostsNode = xmlNotifierHost.SelectSingleNode("recordOnHosts");
            if (recordOnHostsNode != null)
            {
                newNotifierHost.OnlyRecordAlertOnHosts = new List<string>();
                foreach (XmlElement hostNode in recordOnHostsNode.SelectNodes("host"))
                {
                    newNotifierHost.OnlyRecordAlertOnHosts.Add(hostNode.ReadXmlElementAttr("name", ""));
                }
            }

            #region notifierAgents
            XmlNode notifierAgentsNode = xmlNotifierHost.SelectSingleNode("notifierAgents");
            if (notifierAgentsNode != null)
            {
                newNotifierHost.NotifierAgents = new List<INotifier>();
                foreach (XmlElement notifierAgentNode in notifierAgentsNode.SelectNodes("notifierAgent"))
                {
                    string name = notifierAgentNode.ReadXmlElementAttr("name", "");
                    string typeName = notifierAgentNode.ReadXmlElementAttr("type", "");
                    bool enabled = notifierAgentNode.ReadXmlElementAttr("enabled", true);
                    string configXml = "";
                    XmlNode configNode = notifierAgentNode.SelectSingleNode("config");
                    if (configNode != null)
                    {
                        configXml = configNode.OuterXml;
                    }
                    INotifier newAgent = CreateNotifierFromClassName(typeName);
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
                                    newNotifierHost.Enabled = false;
                            }
                            //string appliedConfig = newAgent.InitialConfiguration;
                            //if (applyConfigVars)
                            //{
                            //    appliedConfig = monitorPackVars.ApplyOn(appliedConfig);
                            //    appliedConfig = newNotifierHost.ConfigVariables.ApplyOn(appliedConfig);
                            //}
                            //newAgent.ActiveConfiguration = appliedConfig;
                            newNotifierHost.NotifierAgents.Add(newAgent);
                            newAgent.AgentConfig.FromXml(newAgent.InitialConfiguration);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine(ex.ToString());
                            newNotifierHost.Enabled = false;
                        }
                    }
                }
            }
            #endregion

            return newNotifierHost;
        }
        public static INotifier GetNotifierAgentFromString(string xmlString, List<ConfigVariable> configVars = null, bool applyConfigVars = true)
        {
            if (xmlString != null && xmlString.StartsWith("<?xml "))
            {
                xmlString = xmlString.Substring(xmlString.IndexOf('>') + 1).Trim(' ', '\r', '\n');
            }
            if (xmlString.StartsWith("<notifierAgent"))
            {
                XmlDocument collectorAgentXml = new XmlDocument();
                collectorAgentXml.LoadXml(xmlString);
                return GetNotifierAgentFromString(collectorAgentXml.DocumentElement, configVars, applyConfigVars);
            }
            else
                return null;
        }

        private static INotifier GetNotifierAgentFromString(XmlElement notifierAgentNode, List<ConfigVariable> configVars = null, bool applyConfigVars = true)
        {
            string name = notifierAgentNode.ReadXmlElementAttr("name", "");
            string typeName = notifierAgentNode.ReadXmlElementAttr("type", "");
            bool enabled = notifierAgentNode.ReadXmlElementAttr("enabled", true);
            string configXml = "";
            XmlNode configNode = notifierAgentNode.SelectSingleNode("config");
            if (configNode != null)
            {
                configXml = configNode.OuterXml;
            }
            INotifier newAgent = CreateNotifierFromClassName(typeName);
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
                            throw new Exception("Could not create AgentConfig!");
                    }
                    string appliedConfig = newAgent.InitialConfiguration;
                    if (applyConfigVars)
                    {
                        appliedConfig = configVars.ApplyOn(appliedConfig);
                    }
                    newAgent.ActiveConfiguration = appliedConfig;
                    newAgent.AgentConfig.FromXml(appliedConfig);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.ToString());
                    throw new Exception("Could not create AgentConfig!");
                }
            }
            return newAgent;
        }
        public static INotifier CreateNotifierFromClassName(string agentClassName)
        {
            INotifier currentAgent = null;
            if (!agentClassName.Contains("."))
                agentClassName = "." + agentClassName;
            RegisteredAgent currentRA = RegisteredAgentCache.GetRegisteredAgentByClassName(agentClassName, false);
            if (currentRA != null)
            {
                if (System.IO.File.Exists(currentRA.AssemblyPath))
                {
                    Assembly notifierEntryAssembly = Assembly.LoadFile(currentRA.AssemblyPath);
                    currentAgent = (INotifier)notifierEntryAssembly.CreateInstance(currentRA.ClassName);
                    currentAgent.AgentClassName = currentRA.ClassName;//.Replace("QuickMon.Notifiers.", "");
                    currentAgent.AgentClassDisplayName = currentRA.DisplayName;
                }
            }
            return currentAgent;
        }

        public XmlNode ToXmlNode()
        {
            XmlDocument notifierHostNode = new XmlDocument();
            StringBuilder configXml = new StringBuilder();
            configXml.AppendLine(string.Format("<notifierHost name=\"{0}\" enabled=\"{1}\" alertLevel=\"{2}\" " +
                      "detailLevel=\"{3}\" attendedOptionOverride=\"{4}\">\r\n",
                        Name.EscapeXml(), Enabled, AlertLevel, DetailLevel, AttendedOptionOverride));

            configXml.AppendLine("<!-- collectorHosts -->");
            if (AlertForCollectors == null || AlertForCollectors.Count == 0)
                configXml.AppendLine("<collectorHosts />");
            else
            {
                configXml.AppendLine("<collectorHosts>");
                foreach (string collectorHostName in AlertForCollectors)
                {
                    configXml.AppendLine(string.Format("<collectorHost name=\"{0}\" />", collectorHostName.EscapeXml()));
                }
                configXml.AppendLine("</collectorHosts>");
            }
            configXml.AppendLine("<!-- ServiceWindows -->");
            configXml.AppendLine(ServiceWindows.ToXml());

            configXml.AppendLine("<!-- Categories -->");
            configXml.AppendLine(GetCategoriesXML());

            configXml.AppendLine("<!-- Config variables -->");
            if (ConfigVariables == null || ConfigVariables.Count == 0)
                configXml.AppendLine("<configVars />");
            else
            {
                configXml.AppendLine("<configVars>");
                foreach (ConfigVariable cv in ConfigVariables)
                {
                    configXml.AppendLine(cv.ToXml());
                }
                configXml.AppendLine("</configVars>");
            }

            if (OnlyRecordAlertOnHosts != null && OnlyRecordAlertOnHosts.Count > 0)
            {
                configXml.AppendLine("<recordOnHosts>");
                foreach (string host in OnlyRecordAlertOnHosts)
                {
                    configXml.AppendLine(string.Format("<host name=\"{0}\" />", host.EscapeXml()));
                }
                configXml.AppendLine("</recordOnHosts>");
            }
            else
                configXml.AppendLine("<recordOnHosts />");

            configXml.AppendLine("<!-- notifierAgents -->");
            configXml.AppendLine("<notifierAgents>");
            foreach (INotifier notifierAgent in NotifierAgents)
            {
                configXml.AppendLine(string.Format("<notifierAgent name=\"{0}\" type=\"{1}\" enabled=\"{2}\">",
                    notifierAgent.Name.EscapeXml(), notifierAgent.AgentClassName.EscapeXml(), notifierAgent.Enabled));
                configXml.AppendLine(notifierAgent.AgentConfig.ToXml());
                configXml.AppendLine("</notifierAgent>");
            }
            configXml.AppendLine("</notifierAgents>");
            configXml.AppendLine("</notifierHost>");
            notifierHostNode.LoadXml(configXml.ToString());
            return notifierHostNode.DocumentElement;
        }
        /// <summary>
        /// Export current NotifierHost config as XML string
        /// </summary>
        /// <returns>XML config string</returns>
        public string ToXml()
        {
            StringBuilder configXml = new StringBuilder();
            configXml.AppendLine(string.Format("<notifierHost name=\"{0}\" enabled=\"{1}\" alertLevel=\"{2}\" " +
                      "detailLevel=\"{3}\" attendedOptionOverride=\"{4}\">\r\n",
                        Name.EscapeXml(), Enabled, AlertLevel, DetailLevel, AttendedOptionOverride));

            configXml.AppendLine("<!-- collectorHosts -->");
            if (AlertForCollectors == null || AlertForCollectors.Count == 0)
                configXml.AppendLine("<collectorHosts />");
            else
            {
                configXml.AppendLine("<collectorHosts>");
                foreach (string collectorHostName in AlertForCollectors)
                {
                    configXml.AppendLine(string.Format("<collectorHost name=\"{0}\" />", collectorHostName.EscapeXml()));
                }
                configXml.AppendLine("</collectorHosts>");
            }
            configXml.AppendLine("<!-- ServiceWindows -->");
            configXml.AppendLine(ServiceWindows.ToXml());

            configXml.AppendLine("<!-- Categories -->");
            configXml.AppendLine(GetCategoriesXML());

            configXml.AppendLine("<!-- Config variables -->");
            if (ConfigVariables == null || ConfigVariables.Count == 0)
                configXml.AppendLine("<configVars />");
            else
            {
                configXml.AppendLine("<configVars>");
                foreach (ConfigVariable cv in ConfigVariables)
                {
                    configXml.AppendLine(cv.ToXml());
                }
                configXml.AppendLine("</configVars>");
            }

            if (OnlyRecordAlertOnHosts != null && OnlyRecordAlertOnHosts.Count > 0)
            {
                configXml.AppendLine("<recordOnHosts>");
                foreach (string host in OnlyRecordAlertOnHosts)
                {
                    configXml.AppendLine(string.Format("<host name=\"{0}\" />", host.EscapeXml()));
                }
                configXml.AppendLine("</recordOnHosts>");
            }
            else
                configXml.AppendLine("<recordOnHosts />");

            configXml.AppendLine("<!-- notifierAgents -->");
            configXml.AppendLine("<notifierAgents>");
            foreach (INotifier notifierAgent in NotifierAgents)
            {
                configXml.AppendLine(string.Format("<notifierAgent name=\"{0}\" type=\"{1}\" enabled=\"{2}\">",
                    notifierAgent.Name.EscapeXml(), notifierAgent.AgentClassName.EscapeXml(), notifierAgent.Enabled));
                configXml.AppendLine(notifierAgent.AgentConfig.ToXml());
                configXml.AppendLine("</notifierAgent>");
            }
            configXml.AppendLine("</notifierAgents>");
            configXml.AppendLine("</notifierHost>");
            return configXml.ToString();
        }

        public void ApplyConfigVarsNow()
        {
            List<ConfigVariable> allConfigVars = new List<ConfigVariable>();
            //applying its own first
            foreach (ConfigVariable cv in ConfigVariables)
            {
                ConfigVariable existingCV = (from ConfigVariable c in allConfigVars
                                             where c.FindValue == cv.FindValue
                                             select c).FirstOrDefault();
                if (existingCV == null)
                {
                    allConfigVars.Add(cv.Clone());
                }
            }
            if (ParentMonitorPack != null)
            {
                //then applying parent monitor pack variables
                foreach (ConfigVariable cv in ParentMonitorPack.ConfigVariables)
                {
                    ConfigVariable existingCV = (from ConfigVariable c in allConfigVars
                                                 where c.FindValue == cv.FindValue
                                                 select c).FirstOrDefault();
                    if (existingCV == null)
                    {
                        allConfigVars.Add(cv.Clone());
                    }
                }
            }

            foreach (IAgent agent in NotifierAgents)
            {
                string appliedConfig = agent.InitialConfiguration;
                appliedConfig = allConfigVars.ApplyOn(appliedConfig);
                //only reapply if it is different from existing
                if (agent.ActiveConfiguration != appliedConfig)
                {
                    agent.ActiveConfiguration = appliedConfig;
                    agent.AgentConfig.FromXml(appliedConfig);
                }
            }
        }
    }
}
