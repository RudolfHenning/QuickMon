using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public abstract class AgentBase : IAgent
    {
        #region IAgent Members
        public string Name { get; set; }
        public string AgentClassName { get; set; }
        public string AgentClassDisplayName { get; set; }
        public bool Enabled { get; set; }
        private string initialConfiguration = "";
        public string InitialConfiguration
        {
            get
            {
                if (initialConfiguration == null || initialConfiguration.Length == 0)
                {
                    if (AgentConfig != null)
                    {
                        initialConfiguration = AgentConfig.ToXml();
                    }
                }
                return initialConfiguration;
            }
            set { initialConfiguration = value; }
        }
        private string activeConfiguration = "";
        public string ActiveConfiguration
        {
            get
            {
                if (activeConfiguration == null || activeConfiguration.Length == 0)
                {
                    if (initialConfiguration != null && initialConfiguration.Length > 0)
                        activeConfiguration = initialConfiguration;
                    else if (AgentConfig != null)
                        activeConfiguration = AgentConfig.ToXml();
                }
                return activeConfiguration;
            }
            set { activeConfiguration = value; }
        }
        public IAgentConfig AgentConfig { get; set; }
        public virtual void Close() { }        
        #endregion
    }
}
