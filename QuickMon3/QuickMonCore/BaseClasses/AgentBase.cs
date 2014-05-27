using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public abstract class AgentBase : IAgent
    {
        #region IAgent Members
        public string Name { get;  set; }
        public IAgentConfig AgentConfig { get; set; }
        
        public abstract string GetDefaultOrEmptyConfigString();
        public virtual void SetConfigurationFromXmlString(string configurationString)
        {
            AgentConfig.ReadConfiguration(configurationString);
        }
        public virtual void Close() { }
        #endregion
    }
}
