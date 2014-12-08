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

        [DataMember(Name = "Agents")]
        public List<RemoteCollectorAgent> Agents { get; set; }
        #endregion

        public string ToCollectorHostXml()
        {
            StringBuilder collectorAgentsXml = new StringBuilder();
            collectorAgentsXml.AppendLine("<collectorAgents>");
            foreach (RemoteCollectorAgent c in Agents)
            {
                collectorAgentsXml.AppendLine(c.ToXml());                
            }
            collectorAgentsXml.AppendLine("</collectorAgents>");

            return CollectorHost.ToXml(UniqueId,
                Name,
                Enabled,
                true,
                "", //No parent
               AgentCheckSequence,
                ChildCheckBehaviour.OnlyRunOnSuccess,
                0, 0, 0, 0, 0, 0, true, "", "", "", false, //Corrective scripts
                false, false, "", 48181, false, false, //Remote hosts
                false, 0, false, 0, 0, 0, //Polling overides
                false, //alerts paused
                collectorAgentsXml.ToString(),
                "", //Service windows
                "" //config vars
                );

        }
        public void FromCollectorHost(CollectorHost fullEntry)
        {
            Name = fullEntry.Name;
            UniqueId = fullEntry.UniqueId;
            Enabled = fullEntry.Enabled;
            AgentCheckSequence = fullEntry.AgentCheckSequence;

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
        [DataMember(Name = "Type")]
        public string TypeName { get; set; }
        [DataMember(Name = "ConfigString")]
        public string ConfigString { get; set; }

        public string ToXml()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<collectorAgent type=\"" + TypeName.EscapeXml() + "\">");
            
            string configString = ConfigString;
            if (!configString.Trim().StartsWith("<config", StringComparison.CurrentCultureIgnoreCase))
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
            TypeName = root.ReadXmlElementAttr("type", "");
            XmlNode configNode = root.SelectSingleNode("config");
            if (configNode != null)
            {
                ConfigString = configNode.OuterXml;
            }
        }
        public void FromICollector(ICollector c)
        {
            TypeName = c.AgentClassName;
            ConfigString = c.ActiveConfiguration;
        }
    }
}
