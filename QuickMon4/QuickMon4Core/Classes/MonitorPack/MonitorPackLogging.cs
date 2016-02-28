using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public partial class MonitorPack
    {
        private DateTime lastLoggingCleanupEvent;
        private string loggingFileName = "";

        #region Event Logging Properties
        public bool LoggingEnabled { get; set; }
        public string LoggingPath { get; set; }
        public bool LoggingCollectorEvents { get; set; }
        public bool LoggingNotifierEvents { get; set; }
        public List<string> LoggingCollectorCategories { get; set; }
        public bool LoggingAlertsRaised { get; set; }
        public bool LoggingCorrectiveScriptRun { get; set; }
        public bool LoggingMonitorPackChangedEvents { get; set; }
        public bool LoggingPollingOverridesTriggered { get; set; }
        public bool LoggingServiceWindowEvents { get; set; }
        public int LoggingKeepLogFilesXDays { get; set; }
        #endregion

        private void WriteLogging(string message)
        {
            try
            {
                if (LoggingEnabled)
                {
                    string logFileName = "";

                    if (MonitorPackPath.Length > 0)
                    {
                        logFileName = System.IO.Path.GetFileNameWithoutExtension(MonitorPackPath);
                    }
                    else
                    {
                        logFileName = Name;
                    }

                    if (System.IO.Directory.Exists(LoggingPath))
                    {
                        loggingFileName = System.IO.Path.Combine(LoggingPath, logFileName + DateTime.Now.Date.ToString("yyyyMMdd") + ".log");
                        string output = new string('*', 80) + "\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": " + message + "\r\n";
                        System.IO.File.AppendAllText(loggingFileName, output);

                        //Logging files clearups
                        if (lastLoggingCleanupEvent.AddHours(1) < DateTime.Now)
                        {
                            foreach (string fileName in System.IO.Directory.GetFiles(LoggingPath, logFileName + "*.log"))
                            {
                                System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
                                if (fi.LastWriteTime.AddDays(LoggingKeepLogFilesXDays) < DateTime.Now)
                                {
                                    fi.Delete();
                                }
                            }

                            lastLoggingCleanupEvent = DateTime.Now;
                        }
                    }
                    else
                    {
                        RaiseMonitorPackError(string.Format("The LoggingPath '{0}' does not exist!", LoggingPath));
                    }
                }
            }
            catch (Exception ex)
            {
                RaiseMonitorPackError(string.Format("Error performing WriteLogging: {0}", ex.Message));
            }
        }

        public void LoggingMonitorPackChanged()
        {
            if (LoggingMonitorPackChangedEvents)
                WriteLogging("Monitor pack changed");
        }
    }
}
