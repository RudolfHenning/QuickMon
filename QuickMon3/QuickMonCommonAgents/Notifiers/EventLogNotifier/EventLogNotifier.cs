using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace QuickMon.Notifiers.EventLogNotifier
{
    [Description("Event Log Notifier")]
    public class EventLogNotifier : NotifierBase
    {
        public EventLogNotifier()
        {
            AgentConfig = new EventLogNotifierConfig();
        }
        public override void RecordMessage(AlertRaised alertRaised)
        {
            string lastStep = "";
            try
            {
                EventLogNotifierConfig currentConfig = (EventLogNotifierConfig)AgentConfig;
                if (currentConfig.MachineName.Length == 0)
                {
                    throw new Exception("Computer name not specified!");
                }
                if (currentConfig.EventSource.Length == 0)
                {
                    throw new Exception("Event source not specified!");
                }
                string currentEventSource = currentConfig.EventSource;
                string collectorName = "QuickMon Global Alert";
                string collectorType = "None";
                string oldState = "N/A";
                string newState = "N/A";
                string detailMessage = "N/A";
                if (alertRaised.RaisedFor != null)
                {
                    collectorName = alertRaised.RaisedFor.Name;
                    collectorType = alertRaised.RaisedFor.CollectorRegistrationName;
                    oldState = Enum.GetName(typeof(CollectorState), alertRaised.RaisedFor.LastMonitorState.State);
                    newState = Enum.GetName(typeof(CollectorState), alertRaised.RaisedFor.CurrentState.State);
                    detailMessage = alertRaised.RaisedFor.CurrentState.RawDetails;
                }
                currentEventSource = currentConfig.EventSource
                    .Replace("%CollectorName%", collectorName)
                    .Replace("%CollectorType%", collectorType);

                lastStep = "Test if source exists";
                if (!EventLog.SourceExists(currentEventSource))
                {
                    lastStep = "Attempt to create event source " + currentEventSource;
                    EventSourceCreationData escd = new EventSourceCreationData(currentEventSource, "Application");
                    escd.MachineName = currentConfig.MachineName;
                    EventLog.CreateEventSource(escd);
                }
                lastStep = "Opening event log on " + currentConfig.MachineName;
                EventLog outputLog = new EventLog("Application", currentConfig.MachineName, currentEventSource);
                EventLogEntryType eventLogEntryType = (alertRaised.Level == AlertLevel.Info || alertRaised.Level == AlertLevel.Debug) ? EventLogEntryType.Information :
                    alertRaised.Level == AlertLevel.Warning ? EventLogEntryType.Warning : EventLogEntryType.Error;
                int eventID = (alertRaised.Level == AlertLevel.Info || alertRaised.Level == AlertLevel.Debug) ? currentConfig.SuccessEventID :
                    alertRaised.Level == AlertLevel.Warning ? currentConfig.WarningEventID : currentConfig.ErrorEventID;

                lastStep = "Generate output stream";
                
                string outputStr = string.Format("Time: {0}\r\nAlert level: {1}\r\nType: {2}\r\nCategory: {3}\r\nOld state: {4}\r\nCurrent state: {5}\r\nDetails: {6}",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Enum.GetName(typeof(AlertLevel), alertRaised.Level),
                        collectorType,
                        collectorName,
                        oldState,
                        newState,
                        detailMessage);

                lastStep = "Write the event log entry";
                outputLog.WriteEntry(outputStr, eventLogEntryType, eventID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error recording message in Event log notifier\r\nLast step: " + lastStep, ex);
            }
            finally
            {
                //eventLogWriteMutex.ReleaseMutex();
            }
        }

        public override bool HasViewer
        {
            get { return true; }
        }

        public override INotivierViewer GetNotivierViewer()
        {
            return new EventLogNotifierShowViewer();
        }

        public override IEditConfigWindow GetEditConfigWindow()
        {
            return new EventLogNotifierEditConfig();
        }

        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.EventLogNotifierDefaultConfig;
        }

        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new EventLogNotifierEditConfig();
        }
    }
}
