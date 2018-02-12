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
                if (stateHistory.Count > 0)
                {
                    stateHistory[stateHistory.Count - 1].AlertsRaised = new List<string>();
                    stateHistory[stateHistory.Count - 1].AlertsRaised.AddRange(currentState.AlertsRaised.ToArray());
                }
            }
            catch { }
        }

        /** Export history **/
        public static string ExportHistoryToCSVHeaders()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Date,");            
            sb.Append("Collector path,");
            sb.Append("State,");
            sb.Append("Display Value,");
            sb.Append("Display Value Unit,");
            sb.Append("Duration,");
            sb.Append("Executed on,");
            sb.Append("Run as,");
            sb.Append("Alert count");
            sb.AppendLine();
            return sb.ToString();
        }
        public string ExportHistoryToCSV(bool addHeaders = false)
        {
            StringBuilder sb = new StringBuilder();
            if (addHeaders)
            {
                sb.Append(ExportHistoryToCSVHeaders());                
            }
            foreach(var h in stateHistory.OrderBy(s=>s.Timestamp))
            {
                sb.Append(h.Timestamp.ToString("yyyy-MM-dd HH:mm:ss") + ",");
                //sb.Append(h.Timestamp.ToShortDateString() + ",");
                //sb.Append(h.Timestamp.ToLongTimeString() + ",");
                //sb.AppendFormat("\"{0}\",", Name.Replace("\"", "\"\"" + "\","));
                sb.AppendFormat("\"{0}\",", Path.Replace("\"", "\"\"" + "\","));
                sb.Append(h.State.ToString() + ",");
                string displayValue = h.ReadPrimaryOrFirstUIValue(false);                
                if (displayValue.IsNumber())
                    sb.AppendFormat("{0},", displayValue);
                else
                    sb.AppendFormat("\"{0}\",", displayValue.Replace("\"", "\"\"") );
                sb.AppendFormat("\"{0}\",", h.ReadFirstValueUnit().Replace("\"", "\"\""));
                sb.Append(h.CallDurationMS.ToString() + " ms,");
                sb.Append(h.ExecutedOnHostComputer + ",");
                sb.Append(h.RanAs + ",");
                sb.Append(h.AlertsRaised.Count.ToString());
                sb.AppendLine();
            }
            
            if (CurrentState != null)
            {
                sb.Append(CurrentState.Timestamp.ToString("yyyy-MM-dd HH:mm:ss") + ",");
                sb.AppendFormat("\"{0}\",", Path.Replace("\"", "\"\"" + "\","));
                sb.Append(CurrentState.State.ToString() + ",");
                string displayValue = CurrentState.ReadPrimaryOrFirstUIValue(false);
                if (displayValue.IsNumber())
                    sb.AppendFormat("{0},", displayValue);
                else
                    sb.AppendFormat("\"{0}\",", displayValue.Replace("\"", "\"\""));
                sb.AppendFormat("\"{0}\",", CurrentState.ReadFirstValueUnit().Replace("\"", "\"\""));
                sb.Append(CurrentState.CallDurationMS.ToString() + " ms,");
                sb.Append(CurrentState.ExecutedOnHostComputer + ",");
                sb.Append(CurrentState.RanAs + ",");
                sb.Append(CurrentState.AlertsRaised.Count.ToString());
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
