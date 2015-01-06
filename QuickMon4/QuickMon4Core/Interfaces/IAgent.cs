using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface IAgent
    {
        string Name { get; set; }
        string AgentClassName { get; set; }
        string AgentClassDisplayName { get; set; }
        bool Enabled { get; set; }
        /// <summary>
        /// This is the initial config as loaded from the original config.
        /// </summary>
        string InitialConfiguration { get; set; }
        /// <summary>
        /// This is the config after all config variables have been applied
        /// </summary>
        string ActiveConfiguration { get; set; }
        IAgentConfig AgentConfig { get; set; }
        //In case some agents needs to close some resources
        void Close();
    }
}
