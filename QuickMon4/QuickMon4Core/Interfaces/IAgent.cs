using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface IAgent
    {
        string AgentClassName { get; set; }
        string InitialConfiguration { get; set; }
        string AppliedConfiguration { get; set; }
        IAgentConfig AgentConfig { get; set; }
        //In case some agents needs to close some resources
        void Close();
    }
}
