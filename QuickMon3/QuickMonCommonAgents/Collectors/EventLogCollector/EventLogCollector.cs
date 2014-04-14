using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Event Log Collector"), Category("General")]
    public class EventLogCollector : CollectorBase
    {
        public EventLogCollector()
        {
            AgentConfig = new EventLogCollectorConfig();
        }
        public override MonitorState GetState()
        {
            MonitorState returnState = new MonitorState();
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            string lastAction = "Querying event logs";
            int errors = 0;
            int warnings = 0;
            int success = 0;
            long totalCount = 0;
            try
            {
                EventLogCollectorConfig currentConfig = (EventLogCollectorConfig)AgentConfig;
                plainTextDetails.AppendLine(string.Format("Event logs"));
                htmlTextTextDetails.AppendLine(string.Format("Event logs"));
                htmlTextTextDetails.AppendLine("<ul>");
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
                        plainTextDetails.AppendLine(string.Format("\t'{0}\\{1}' - count: '{2}' - Error (trigger {3})", eventLogEntry.Computer, eventLogEntry.EventLog, count, eventLogEntry.ErrorValue));
                        htmlTextTextDetails.AppendLine(string.Format("<li>'{0}\\{1}' - count: '{2}' - <b>Error</b> (trigger {3})</li>", eventLogEntry.Computer, eventLogEntry.EventLog, count, eventLogEntry.ErrorValue));
                    }
                    else if (warningCondition)
                    {
                        warnings++;
                        plainTextDetails.AppendLine(string.Format("\t'{0}\\{1}' - count: '{2}' - Warning (trigger {3})", eventLogEntry.Computer, eventLogEntry.EventLog, count, eventLogEntry.WarningValue));
                        htmlTextTextDetails.AppendLine(string.Format("<li>'{0}\\{1}' - count: '{2}' - <b>Warning</b> (trigger {3})</li>", eventLogEntry.Computer, eventLogEntry.EventLog, count, eventLogEntry.WarningValue));
                    }
                    else
                    {
                        success++;
                        plainTextDetails.AppendLine(string.Format("\t'{0}\\{1}' - count: '{2}'", eventLogEntry.Computer, eventLogEntry.EventLog, count));
                        htmlTextTextDetails.AppendLine(string.Format("<li>'{0}\\{1}' - count: '{2}'</li>", eventLogEntry.Computer, eventLogEntry.EventLog, count));
                    }
                }
                htmlTextTextDetails.AppendLine("</ul>");
                if (errors > 0 && warnings == 0 && success == 0)
                    returnState.State = CollectorState.Error;
                else if (errors > 0 || warnings > 0)
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;
                returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                returnState.HtmlDetails = htmlTextTextDetails.ToString();
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
        public override ICollectorDetailView GetCollectorDetailView()
        {
            return new EventLogCollectorViewDetails();
        }
        public override IEditConfigWindow GetEditConfigWindow()
        {
            return new EventLogCollectorEditConfig();
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.EventLogCollectorDefaultConfig;
        }

        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new EventLogCollectorEditEntry();
        }
    }
}
