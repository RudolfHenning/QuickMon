using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class EventLogCount : CollectorBase
    {
        private EventLogConfig evConfig = new EventLogConfig();

        public override MonitorStates GetState()
        {
            MonitorStates returnState = MonitorStates.Good;
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            LastDetailMsg.PlainText = "Querying event logs";
            LastDetailMsg.HtmlText = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;
            long totalCount = 0;
            try
            {
                plainTextDetails.AppendLine(string.Format("Event logs"));
                htmlTextTextDetails.AppendLine(string.Format("Event logs"));
                htmlTextTextDetails.AppendLine("<ul>");
                foreach (QMEventLogEntry eventLogEntry in evConfig.Entries)
                {
                    bool errorCondition = false;
                    bool warningCondition = false;
                    LastDetailMsg.PlainText = string.Format("Querying Event log '{0}\\{1}'", eventLogEntry.Computer, eventLogEntry.EventLog);

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
                if (errors > 0 && warnings == 0)
                    returnState = MonitorStates.Error;
                else if (warnings > 0)
                    returnState = MonitorStates.Warning;
                LastDetailMsg.PlainText = plainTextDetails.ToString().TrimEnd('\r', '\n');
                LastDetailMsg.HtmlText = htmlTextTextDetails.ToString();
                LastDetailMsg.LastValue = totalCount;
            }
            catch (Exception ex)
            {
                LastError = 1;
                LastErrorMsg = ex.Message;
                LastDetailMsg.PlainText = string.Format("Last step: '{0}\r\n{1}", LastDetailMsg.PlainText, ex.Message);
                LastDetailMsg.HtmlText = string.Format("<blockquote>Last step: '{0}<br />{1}</blockquote>", LastDetailMsg.PlainText, ex.Message);
                returnState = MonitorStates.Error;
            }
            return returnState;
        }

        public override void ShowStatusDetails(string collectorName)
        {
            ShowDetails showDetails = new ShowDetails();
            showDetails.Text = "Show details - " + collectorName;
            showDetails.SelectedEventLogConfig = evConfig;
            showDetails.Show();
        }

        public override string ConfigureAgent(string config)
        {
            XmlDocument configDoc = new XmlDocument();
            if (config.Length > 0)
                configDoc.LoadXml(config);
            else
                configDoc.LoadXml(GetDefaultOrEmptyConfigString());
            ReadConfiguration(configDoc);

            EditConfig editConfig = new EditConfig();
            editConfig.SelectedEventLogConfig = evConfig;
            if (editConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                config = editConfig.SelectedEventLogConfig.ToConfig();
            }
            return config;
        }

        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.QMEventLogEmptyConfig;
        }

        public override void ReadConfiguration(XmlDocument configDoc)
        {
            evConfig.ReadConfiguration(configDoc);
        }
    }
}
