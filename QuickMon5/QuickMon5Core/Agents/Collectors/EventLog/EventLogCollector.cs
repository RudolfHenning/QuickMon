using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Event Log Collector"), Category("General")]
    public class EventLogCollector : CollectorAgentBase
    {
        public EventLogCollector()
        {
            AgentConfig = new EventLogCollectorConfig();
        }

        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();            
            string lastAction = "Querying event logs";
            int errors = 0;
            int warnings = 0;
            int success = 0;
            long totalCount = 0;
            try
            {
                EventLogCollectorConfig currentConfig = (EventLogCollectorConfig)AgentConfig;
                returnState.RawDetails = string.Format("{0} Event log(s)", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<b>{0} Event log(s)</b>", currentConfig.Entries.Count);

                foreach (EventLogCollectorEntry eventLogEntry in currentConfig.Entries)
                {
                    bool errorCondition = false;
                    bool warningCondition = false;
                    lastAction = string.Format("Querying Event log '{0}\\{1}'", eventLogEntry.Computer, eventLogEntry.EventLog);

                    int count = eventLogEntry.GetMatchingEventLogCount();
                    if (count >= eventLogEntry.ErrorValue)
                        errorCondition = true;
                    else if (count >= eventLogEntry.WarningValue)
                        warningCondition = true;
                    totalCount += count;

                    if (errorCondition)
                    {
                        errors++;
                        returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    State = CollectorState.Error,
                                    ForAgent = string.Format("{0}\\{1}", eventLogEntry.Computer, eventLogEntry.EventLog),
                                    CurrentValue = count,
                                    RawDetails = string.Format("(Trigger: {0})", eventLogEntry.ErrorValue)

                                    //RawDetails = string.Format("'{0}\\{1}' - count: '{2}' - Error (trigger {3})", eventLogEntry.Computer, eventLogEntry.EventLog, count, eventLogEntry.ErrorValue),
                                    //HtmlDetails = string.Format("'{0}\\{1}' - count: '{2}' - <b>Error</b> (trigger {3})", eventLogEntry.Computer, eventLogEntry.EventLog, count, eventLogEntry.ErrorValue)
                                });                        
                    }
                    else if (warningCondition)
                    {
                        warnings++;
                        returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    State = CollectorState.Warning,
                                    ForAgent = string.Format("{0}\\{1}", eventLogEntry.Computer, eventLogEntry.EventLog),
                                    CurrentValue = count,
                                    RawDetails = string.Format("(Trigger: {0})", eventLogEntry.WarningValue)
                                    //RawDetails = string.Format("'{0}\\{1}' - count: '{2}' - Warning (trigger {3})", eventLogEntry.Computer, eventLogEntry.EventLog, count, eventLogEntry.WarningValue),
                                    //HtmlDetails = string.Format("'{0}\\{1}' - count: '{2}' - <b>Warning</b> (trigger {3})", eventLogEntry.Computer, eventLogEntry.EventLog, count, eventLogEntry.WarningValue)
                                });
                    }
                    else
                    {
                        success++;
                        returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    State = CollectorState.Good,
                                    ForAgent = string.Format("{0}\\{1}", eventLogEntry.Computer, eventLogEntry.EventLog),
                                    CurrentValue = count
                                    //,
                                    //RawDetails = string.Format("'{0}\\{1}' - count: '{2}'", eventLogEntry.Computer, eventLogEntry.EventLog, count),
                                    //HtmlDetails = string.Format("'{0}\\{1}' - count: '{2}'", eventLogEntry.Computer, eventLogEntry.EventLog, count)
                                });
                    }
                }
                if (errors > 0 && warnings == 0 && success == 0)
                    returnState.State = CollectorState.Error;
                else if (errors > 0 || warnings > 0)
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;
                returnState.CurrentValue = totalCount;
            }
            catch (Exception ex)
            {
                returnState.RawDetails = string.Format("Last step: '{0}\r\n{1}", lastAction, ex.Message);
                returnState.HtmlDetails = string.Format("<blockquote>Last step: '{0}<br />{1}</blockquote>", lastAction, ex.Message);
                returnState.State = CollectorState.Error;
            }
            return returnState;
        }

        public override List<System.Data.DataTable> GetDetailDataTables()
        {
            List<System.Data.DataTable> tables = new List<System.Data.DataTable>();
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                dt.Columns.Add(new System.Data.DataColumn("Computer", typeof(string)));
                dt.Columns[0].ExtendedProperties.Add("groupby", "true");
                dt.Columns.Add(new System.Data.DataColumn("Log", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Level", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Time", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Source", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Event ID", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Summary", typeof(string)));

                EventLogCollectorConfig currentConfig = (EventLogCollectorConfig)AgentConfig;
                foreach (EventLogCollectorEntry eventLog in currentConfig.Entries)
                {
                    foreach(EventLogEntryEx entry in  eventLog.GetMatchingEventLogEntries())
                    {
                        dt.Rows.Add(entry.MachineName, entry.LogName, entry.EntryType.ToString(), entry.TimeGenerated.Date.ToString("yyyy-MM-dd"), entry.TimeGenerated.ToString("HH:mm:ss"),
                            entry.Source, entry.EventId, entry.MessageSummary);
                    }
                }
            }
            catch (Exception ex)
            {
                dt = new System.Data.DataTable("Exception");
                dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
                dt.Rows.Add(ex.ToString());
            }
            tables.Add(dt);
            return tables;
        }
    }
}
