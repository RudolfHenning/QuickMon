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

        public virtual MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();
            int errors = 0;
            int warnings = 0;
            int success = 0;
            string lastAction = "";
            try
            {
                lastAction = "Get agent entry states";
                foreach (ICollectorConfigEntry entry in ((ICollectorConfig)AgentConfig).Entries)
                {
                    lastAction = "Getting state for agent: " + entry.Description;
                    returnState.ChildStates.Add(entry.GetCurrentState());
                }

                lastAction = "Getting state counts";
                errors = returnState.ChildStates.Where(cs => cs.State == CollectorState.Error).Count();
                warnings = returnState.ChildStates.Where(cs => cs.State == CollectorState.Warning).Count();
                success = returnState.ChildStates.Where(cs => cs.State == CollectorState.Good).Count();

                if (errors > 0 && warnings == 0 && success == 0) // any errors
                    returnState.State = CollectorState.Error;
                else if (errors > 0 || warnings > 0) //any warnings
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;
            }
            catch (Exception ex)
            {
                returnState.RawDetails = string.Format("Error in RefreshState: Last action: {0}, Details: {1}", lastAction, ex.Message);
                returnState.HtmlDetails = string.Format("<p><b>Last action:</b> {0}</p><blockquote>{1}</blockquote>", lastAction, ex.Message);
                returnState.State = CollectorState.Error;
            }
            return CurrentState;
        }
        public abstract List<System.Data.DataTable> GetDetailDataTables();
    }
}
