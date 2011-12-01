using System;
using System.Diagnostics;
using System.Threading;
using System.Xml;

namespace QuickMon
{
    public class EventLogNotifier : NotifierBase
    {
        private Mutex eventLogWriteMutex = new Mutex();
        private EventLogNotifierConfig eventLogNotifierConfig = new EventLogNotifierConfig();

        public override void RecordMessage(AlertLevel alertLevel, string collectorType, string category, MonitorStates oldState, MonitorStates newState, CollectorMessage collectorMessage)
        {
            string lastStep = "";
            try
            {
                eventLogWriteMutex.WaitOne();
                if (eventLogNotifierConfig.MachineName.Length == 0)
                {
                    throw new Exception("Computer name not specified!");
                }
                if (eventLogNotifierConfig.EventSource.Length == 0)
                {
                    throw new Exception("Event source not specified!");
                }
                string currentEventSource = eventLogNotifierConfig.EventSource
                    .Replace("%CollectorName%", category)
                    .Replace("%CollectorType%", collectorType);

                lastStep = "Test if source exists";
                if (!EventLog.SourceExists(currentEventSource))
                {
                    lastStep = "Attempt to create event source " + currentEventSource;
                    EventSourceCreationData escd = new EventSourceCreationData(currentEventSource, "Application");
                    escd.MachineName = eventLogNotifierConfig.MachineName;
                    EventLog.CreateEventSource(escd);
                }
                lastStep = "Opening event log on " + eventLogNotifierConfig.MachineName;
                EventLog outputLog = new EventLog("Application", eventLogNotifierConfig.MachineName, currentEventSource);
                EventLogEntryType eventLogEntryType = (alertLevel == AlertLevel.Info || alertLevel == AlertLevel.Debug) ?  EventLogEntryType.Information :
                    alertLevel == AlertLevel.Warning ? EventLogEntryType.Warning :EventLogEntryType.Error;

                lastStep = "Generate output stream";
                string outputStr = string.Format("Time: {0}\r\nAlert level: {1}\r\nCollector: {2}\r\nCategory: {3}\r\nOld state: {4}\r\nCurrent state: {5}\r\nDetails: {6}",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Enum.GetName(typeof(AlertLevel), alertLevel),
                        collectorType,
                        category,
                        Enum.GetName(typeof(MonitorStates), oldState),
                        Enum.GetName(typeof(MonitorStates), newState),
                        collectorMessage.PlainText);

                lastStep = "Write the event log entry";
                outputLog.WriteEntry(outputStr, eventLogEntryType);         
            }
            catch (Exception ex)
            {
                throw new Exception("Error recording message in Event log notifier\r\nLast step: " + lastStep, ex);
            }
            finally
            {
                eventLogWriteMutex.ReleaseMutex();
            }
        }

        public override void OpenViewer(string notifierName)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = new System.Diagnostics.ProcessStartInfo() { FileName = "eventvwr.msc" };
            p.Start();
        }

        public override bool HasViewer
        {
            get { return true; }
        }

        public override string ConfigureAgent(string config)
        {
            EditConfig editConfig = new EditConfig();
            XmlDocument configXml = new XmlDocument();
            if (config.Length > 0)
            {
                try
                {
                    configXml.LoadXml(config);
                }
                catch
                {
                    configXml.LoadXml(Properties.Resources.QMEventLogNotifierDefaultConfig);
                }
            }
            else
            {
                configXml.LoadXml(Properties.Resources.QMEventLogNotifierDefaultConfig);
            }

            ReadConfiguration(configXml);
            editConfig.SelectedEventLogNotifierConfig = eventLogNotifierConfig;
            if (editConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                config = editConfig.SelectedEventLogNotifierConfig.ToConfig();
            }
            return config;
        }

        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.QMEventLogNotifierDefaultConfig;
        }

        public override void ReadConfiguration(System.Xml.XmlDocument configDoc)
        {
            eventLogNotifierConfig.ReadConfiguration(configDoc);
        }
    }
}
