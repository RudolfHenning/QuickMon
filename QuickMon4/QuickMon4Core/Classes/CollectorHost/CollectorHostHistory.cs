using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public partial class CollectorHost
    {   
        
        private void AddStateToHistory(MonitorState newState)
        {
            try
            {
                if (stateHistory == null)
                    stateHistory = new List<MonitorState>();
                if (stateHistory.Count > MaxStateHistorySize)
                {
                    DateTime? oldestDate = (from h in stateHistory
                                            orderby h.Timestamp descending
                                            select h.Timestamp).Take(MaxStateHistorySize - 1).Min();
                    if (oldestDate != null)
                    {
                        stateHistory.RemoveAll(h => h.Timestamp < oldestDate.Value);
                    }
                }
#if DEBUG
                if (AlertsPaused)
                    newState.RawDetails += "\r\n(Alerts are paused for this collector)";
#endif
                stateHistory.Add(newState);
            }
            catch { }
        }
        public void UpdateLatestHistoryWithAlertDetails(MonitorState currentState)
        {
            try
            {
                if (stateHistory.Count  > 0)
                {
                    stateHistory[stateHistory.Count - 1].AlertsRaised = new List<string>();
                    stateHistory[stateHistory.Count - 1].AlertsRaised.AddRange(currentState.AlertsRaised.ToArray());
                }
            }
            catch { }
        }
    }
}
