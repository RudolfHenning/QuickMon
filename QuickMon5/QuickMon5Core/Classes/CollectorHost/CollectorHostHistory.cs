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
            sb.Append("Display Value,");
            sb.Append("Display Value Unit,");
            sb.Append("State,");
            sb.Append("Duration (ms),");
            
            sb.Append("Child states,");
            sb.Append("S,W,E,");
            sb.Append("Alert count");

            //sb.Append("Executed on,");
            //sb.Append("Run as");
            sb.AppendLine();
            return sb.ToString();
        }
        private string ExportMonitorStateEntryToSCV(MonitorState ms)
        {
            StringBuilder sb = new StringBuilder();
            if (ms != null)
            {
                sb.Append(ms.Timestamp.ToString("yyyy-MM-dd HH:mm:ss") + ",");
                sb.AppendFormat("\"{0}\",", Path.Replace("\"", "\"\"" + "\","));
                
                string displayValue = ms.ReadPrimaryOrFirstUIValue(false);
                string displayValueUnit = ms.ReadFirstValueUnit();
                if (displayValue.IsNumber())
                    sb.AppendFormat("{0},", displayValue);
                else if (displayValue.Trim().Length > 0)
                    sb.AppendFormat("\"{0}\",", displayValue.Replace("\"", "\"\""));
                else
                    sb.Append(",");
                if (displayValueUnit.Trim().Length > 0)
                    sb.AppendFormat("\"{0}\",", displayValueUnit.Replace("\"", "\"\""));
                else
                    sb.Append(",");

                sb.AppendFormat("{0},", ms.State);
                sb.AppendFormat("{0},", ms.CallDurationMS);


                if (ms.ChildStates == null || ms.ChildStates.Count == 0)
                    sb.AppendFormat("{0},", 0);
                else
                {
                    int childStateCount = ms.ChildStates.ChildStateCount();
                    //if (childStateCount > 0)
                    //    childStateCount--;
                    sb.AppendFormat("{0},", childStateCount);
                }
                int[] stateMetrics = ms.GetStateMetrics();
                sb.AppendFormat("{0},", stateMetrics[0]);
                sb.AppendFormat("{0},", stateMetrics[1]);
                sb.AppendFormat("{0},", stateMetrics[2]);

                sb.AppendFormat("{0}", ms.AlertsRaised.Count);

                //sb.AppendFormat("{0},", ms.ExecutedOnHostComputer);
                //sb.AppendFormat("{0}", ms.RanAs);
                sb.AppendLine();
            }
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
                sb.Append(ExportMonitorStateEntryToSCV(h));
            }
            
            if (CurrentState != null)
            {
                sb.Append(ExportMonitorStateEntryToSCV(CurrentState));
            }

            return sb.ToString();
        }
        public string ExportHistoryToXML()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<collectorHostHistory name=\"{0}\" id=\"{1}\" pid=\"{2}\">", Name.EscapeXml(), UniqueId, ParentCollectorId);
            foreach (var h in stateHistory.OrderBy(s => s.Timestamp))
            {
                sb.Append(h.ToXml());
            }

            if (CurrentState != null)
            {
                sb.Append(CurrentState.ToXml());
            }
            sb.Append("</collectorHostHistory>");
            return sb.ToString();
        }
    }
}
