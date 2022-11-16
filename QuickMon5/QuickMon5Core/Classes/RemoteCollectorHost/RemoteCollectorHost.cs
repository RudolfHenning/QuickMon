using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace QuickMon
{
    [Serializable, DataContract]
    public class RemoteCollectorHost
    {
        public RemoteCollectorHost()
        {
            Agents = new List<RemoteCollectorAgent>();
        }

        #region Properties
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "UniqueId")]
        public string UniqueId { get; set; }
        [DataMember(Name = "Enabled")]
        public bool Enabled { get; set; }
        [DataMember(Name = "AgentCheckSequence")]
        public AgentCheckSequence AgentCheckSequence { get; set; }
        [DataMember(Name = "RunAsEnabled")]
        public bool RunAsEnabled { get; set; }
        [DataMember(Name = "RunAs")]
        public string RunAs { get; set; }

        [DataMember(Name = "Agents")]
        public List<RemoteCollectorAgent> Agents { get; set; }
        #endregion

        public string ToCollectorHostXml()
        {
            string collectorAgentsXml = CollectorHost.GetRemoteCollectorAgentsConfigXml(Agents, AgentCheckSequence);

            return CollectorHost.ToXml(UniqueId,
                Name,
                Enabled,
                ChildCheckBehaviour.OnlyRunOnSuccess,
                RunAsEnabled,
                RunAs,
                collectorAgentsXml
                );
        }
        public void FromCollectorHost(CollectorHost fullEntry)
        {
            Name = fullEntry.Name;
            UniqueId = fullEntry.UniqueId;
            Enabled = fullEntry.Enabled;
            AgentCheckSequence = fullEntry.AgentCheckSequence;
            RunAsEnabled = fullEntry.RunAsEnabled;
            RunAs = fullEntry.RunAs;

            foreach(ICollector c in fullEntry.CollectorAgents)
            {
                RemoteCollectorAgent rca = new RemoteCollectorAgent();
                rca.FromICollector(c);
                Agents.Add(rca);
            }            
        }
    }

    [Serializable, DataContract]
    public class RemoteCollectorAgent
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Type")]
        public string TypeName { get; set; }
        [DataMember(Name = "Enabled")]
        public bool Enabled { get; set; }
        [DataMember(Name = "ConfigString")]
        public string ConfigString { get; set; }

        public string ToXml()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<collectorAgent name=\"" + Name.EscapeXml() + "\" type=\"" + TypeName.EscapeXml() + "\" enabled=\"" + Enabled.ToString() + "\">");
            
            string configString = ConfigString;
            if (configString.Trim().StartsWith("<config", StringComparison.CurrentCultureIgnoreCase))
                sb.AppendLine(configString);
            else
            {
                sb.AppendLine("<config>");
                sb.AppendLine(configString);
                sb.AppendLine("</config>");
            }
            
            sb.AppendLine("</collectorAgent>");
            return sb.ToString();
        }
        public void FromXml(string xmlString)
        {
            XmlDocument configurationXml = new XmlDocument();
            configurationXml.LoadXml(xmlString);
            XmlElement root = configurationXml.DocumentElement;

            Name = configurationXml.ReadXmlElementAttr("name", "");
            TypeName = configurationXml.ReadXmlElementAttr("type", "");
            Enabled = configurationXml.ReadXmlElementAttr("enabled", true);

            XmlNode configNode = root.SelectSingleNode("config");
            if (configNode != null)
            {
                ConfigString = configNode.OuterXml;
            }
        }
        public void FromICollector(ICollector c)
        {
            Name = c.Name;
            TypeName = c.AgentClassName;
            Enabled = c.Enabled;
            ConfigString = c.ActiveConfiguration;
        }
    }
}
