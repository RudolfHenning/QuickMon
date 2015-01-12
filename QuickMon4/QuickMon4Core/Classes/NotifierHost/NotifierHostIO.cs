using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public partial class NotifierHost
    {
        public static List<NotifierHost> GetNotifierHostsFromString(string xmlString, List<ConfigVariable> monitorPackVars = null)
        {
            List<NotifierHost> notifierHosts = new List<NotifierHost>();
            XmlDocument notifierHostsXml = new XmlDocument();
            notifierHostsXml.LoadXml(xmlString);
            XmlElement root = notifierHostsXml.DocumentElement;
            foreach (XmlElement xmlNotifierHost in root.SelectNodes("notifierHost"))
            {
                NotifierHost newNotifierHost = NotifierHost.FromConfig(null, xmlNotifierHost, monitorPackVars);
                notifierHosts.Add(newNotifierHost);
            }
            return notifierHosts;
        }
        public static NotifierHost FromXml(string xmlString, List<ConfigVariable> monitorPackVars = null, bool applyConfigVars = false)
        {
            if (xmlString != null && xmlString.Length > 0 && xmlString.StartsWith("<notifierHost"))
            {
                XmlDocument notifierHostDoc = new XmlDocument();
                notifierHostDoc.LoadXml(xmlString);
                XmlElement root = notifierHostDoc.DocumentElement;
                return FromConfig(null, root, monitorPackVars, applyConfigVars);
            }
            else
                return null;
        }
        public void ReconfigureFromXml(string xmlString, List<ConfigVariable> monitorPackVars = null, bool applyConfigVars = true)
        {
            if (xmlString != null && xmlString.Length > 0 && xmlString.StartsWith("<notifierHost"))
            {
                XmlDocument notifierHostDoc = new XmlDocument();
                notifierHostDoc.LoadXml(xmlString);
                XmlElement root = notifierHostDoc.DocumentElement;
                FromConfig(this, root, monitorPackVars, applyConfigVars);
            }
        }
        private static NotifierHost FromConfig(NotifierHost newNotifierHost, XmlElement xmlNotifierHost, List<ConfigVariable> monitorPackVars, bool applyConfigVars = true)
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

            XmlNode collectorsNode = xmlNotifierHost.SelectSingleNode("collectorHosts");
            if (collectorsNode != null)
            {
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
                foreach (XmlNode configVarNode in configVarsNode.SelectNodes("configVar"))
                {
                    newNotifierHost.ConfigVariables.Add(ConfigVariable.FromXml(configVarNode.OuterXml));
                }
            }

            XmlNode notifierAgentsNode = xmlNotifierHost.SelectSingleNode("notifierAgents");
            if (notifierAgentsNode != null)
            {
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
                            string appliedConfig = newAgent.InitialConfiguration;
                            if (applyConfigVars)
                            {
                                appliedConfig = monitorPackVars.ApplyOn(appliedConfig);
                                appliedConfig = newNotifierHost.ConfigVariables.ApplyOn(appliedConfig);
                            }
                            newAgent.ActiveConfiguration = appliedConfig;
                            newNotifierHost.NotifierAgents.Add(newAgent);

                            newAgent.AgentConfig.FromXml(appliedConfig);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine(ex.ToString());
                            newNotifierHost.Enabled = false;
                        }
                    }
                }
            }

            return newNotifierHost;
        }
        private static INotifier CreateNotifierFromClassName(string agentClassName)
        {
            INotifier currentAgent = null;
            RegisteredAgent currentRA = RegisteredAgentCache.GetRegisteredAgentByClassName("." + agentClassName, false);
            if (currentRA != null)
            {
                if (System.IO.File.Exists(currentRA.AssemblyPath))
                {
                    Assembly notifierEntryAssembly = Assembly.LoadFile(currentRA.AssemblyPath);
                    currentAgent = (INotifier)notifierEntryAssembly.CreateInstance(currentRA.ClassName);
                    currentAgent.AgentClassName = currentRA.ClassName.Replace("QuickMon.Notifiers.", "");
                    currentAgent.AgentClassDisplayName = currentRA.DisplayName;
                }
            }
            return currentAgent;
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
            configXml.AppendLine("<collectorHosts>");
            foreach (string collectorHostName in AlertForCollectors)
            {
                configXml.AppendLine(string.Format("<collectorHost name=\"{0}\">", collectorHostName));                
            }
            configXml.AppendLine("</collectorHosts>");

            configXml.AppendLine("<!-- ServiceWindows -->");
            configXml.AppendLine(ServiceWindows.ToXml());
            configXml.AppendLine("<!-- Config variables -->");
            configXml.AppendLine("<configVars>");
            foreach (ConfigVariable cv in ConfigVariables)
            {
                configXml.AppendLine(cv.ToXml());
            }
            configXml.AppendLine("</configVars>");

            configXml.AppendLine("<!-- notifierAgents -->");
            configXml.AppendLine("<notifierAgents>");
            foreach (INotifier notifierAgent in NotifierAgents)
            {
                configXml.AppendLine(string.Format("<notifierAgent name=\"{0}\" type=\"{1}\" enabled=\"{2}\">", notifierAgent.Name, notifierAgent.AgentClassName, notifierAgent.Enabled));
                configXml.AppendLine(notifierAgent.AgentConfig.ToXml());
                configXml.AppendLine("</notifierAgent>");
            }
            configXml.AppendLine("</notifierAgents>");
            configXml.AppendLine("</notifierHost>");
            return configXml.ToString();
        }
    }
}
