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
        string InitialConfiguration { get; set; }
        string ActiveConfiguration { get; set; }
        IAgentConfig AgentConfig { get; set; }
        //In case some agents needs to close some resources
        void Close();
    }
}
