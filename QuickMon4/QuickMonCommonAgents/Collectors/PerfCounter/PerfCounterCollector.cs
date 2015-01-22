using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Performance Counter Collector"), Category("General")]
    public class PerfCounterCollector : CollectorAgentBase
    {
        public PerfCounterCollector()
        {
            AgentConfig = new PerfCounterCollectorConfig();
        }

        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();
            string lastAction = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;
            string outputFormat = "F3";
            try
            {
                PerfCounterCollectorConfig currentConfig = (PerfCounterCollectorConfig)AgentConfig;
                returnState.RawDetails = string.Format("Querying {0} performance counters", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<i>Querying {0} performance counters</i>", currentConfig.Entries.Count);
                foreach (PerfCounterCollectorEntry entry in currentConfig.Entries)
                {
                    CollectorState currentState = CollectorState.Good;
                    float value = 0;
                    outputFormat = "F3";
                    try
                    {
                        value = entry.GetNextValue();
                        if (value > 9999)
                            outputFormat = "F1";
                        currentState = entry.GetState(value);

                        if (currentState == CollectorState.Error)
                        {
                            errors++;
                            returnState.ChildStates.Add(
                                new MonitorState() { 
                                    State = CollectorState.Error, 
                                    CurrentValue = value,
                                    RawDetails = string.Format("{0} - Val: '{1}' - Error (trigger '{2}')", entry.Description, value.ToString(outputFormat), entry.ErrorValue.ToString(outputFormat)),
                                                     HtmlDetails = string.Format("{0} - Val: '{1}' - <b>Error</b> (trigger '{2}')", entry.Description, value.ToString(outputFormat), entry.ErrorValue.ToString(outputFormat))
                            });
                        }
                        else if (currentState == CollectorState.Warning)
                        {
                            warnings++;
                            returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    State = CollectorState.Warning,
                                    CurrentValue = value,
                                    RawDetails = string.Format("{0} - Val: '{1}' - Warning (trigger '{2}')", entry.Description, value.ToString(outputFormat), entry.ErrorValue.ToString(outputFormat)),
                                    HtmlDetails = string.Format("{0} - Val: '{1}' - <b>Warning</b> (trigger '{2}')", entry.Description, value.ToString(outputFormat), entry.ErrorValue.ToString(outputFormat))
                                });
                        }
                        else
                        {
                            success++;
                            returnState.ChildStates.Add(
                                 new MonitorState()
                                 {
                                     State = CollectorState.Good,
                                     CurrentValue = value,
                                     RawDetails = string.Format("{0} - Val: '{1}'", entry.Description, value.ToString(outputFormat)),
                                     HtmlDetails = string.Format("{0} - Val: '{1}'", entry.Description, value.ToString(outputFormat))
                                 });
                        }
                    }
                    catch (Exception ex)
                    {
                        errors++;
                        returnState.ChildStates.Add(new MonitorState() { State = CollectorState.Error, ForAgent = entry.Description, RawDetails = ex.Message});
                    }                    
                }
                if (errors > 0 && warnings == 0 && success == 0)
                    returnState.State = CollectorState.Error;
                else if (errors > 0 || warnings > 0)
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;
            }
            catch (Exception ex)
            {
                returnState.RawDetails = ex.Message;
                returnState.HtmlDetails = string.Format("<p><b>Last action:</b> {0}</p><blockquote>{1}</blockquote>", lastAction, ex.Message);
                returnState.State = CollectorState.Error;
            }

            return returnState;
        }

        public override System.Data.DataTable GetDetailDataTable()
        {
            System.Data.DataTable dt = new System.Data.DataTable(AgentClassName);
            try
            {

            }
            catch (Exception ex)
            {
                dt = new System.Data.DataTable("Exception");
                dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
                dt.Rows.Add(ex.ToString());
            }
            return dt;
        }
    }
}
