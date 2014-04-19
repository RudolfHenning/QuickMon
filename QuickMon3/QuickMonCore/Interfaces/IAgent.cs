using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public interface IAgent
    {
        string Name { get; set; }        
        IAgentConfig AgentConfig { get; set; }
        string GetDefaultOrEmptyConfigString();
        void SetConfigurationFromXmlString(string configurationString);
        //In case some agents needs to close some resources
        void Close();

        bool ShowEditEntry(ref ICollectorConfigEntry entry);
        
    }
}
