using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public abstract class CollectorAgentBase : AgentBase, ICollector
    {
        #region ICollector Members
        public virtual MonitorState GetState()
        {
            CurrentState = RefreshState();
            return CurrentState;
        }
        public virtual MonitorState CurrentState { get; set; }
        #endregion

        public abstract MonitorState RefreshState();
    }
}
