using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public abstract class AgentBase : IAgent
    {
        #region IAgent Members
        //public string Name { get; set; }
        public string AgentClassName { get; set; }
        public string InitialConfiguration { get; set; }
        public string ActiveConfiguration { get; set; }
        public IAgentConfig AgentConfig { get; set; }
        public virtual void Close() { }        
        #endregion
    }
}
