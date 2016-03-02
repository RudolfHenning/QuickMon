using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace QuickMon
{
    public partial class MonitorPack
    {
        private DateTime lastLoggingCleanupEvent;
        private string loggingFileName = "";
        private static object loggingSyncLock = new object();

        #region Event Logging Properties
        public bool LoggingEnabled { get; set; }
        public string LoggingPath { get; set; }
        public bool LoggingCollectorEvents { get; set; }
        public bool LoggingNotifierEvents { get; set; }
        public List<string> LoggingCollectorCategories { get; set; }
        public bool LoggingAlertsRaised { get; set; }
        public bool LoggingCorrectiveScriptRun { get; set; }
        public bool LoggingPollingOverridesTriggered { get; set; }
        public bool LoggingServiceWindowEvents { get; set; }
        public int LoggingKeepLogFilesXDays { get; set; }
        public string LoggingFileName { get { return loggingFileName; } }
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

                        lock (loggingSyncLock)
                        {
                            System.IO.File.AppendAllText(loggingFileName, output);
                        }

                        //Logging files clearups
                        if (lastLoggingCleanupEvent.AddMinutes(1) < DateTime.Now)
                        {
                            List<string> filesCleared = new List<string>();
                            foreach (string fileName in System.IO.Directory.GetFiles(LoggingPath, logFileName + "*.log"))
                            {
                                System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
                                if (fi.LastWriteTime.AddDays(LoggingKeepLogFilesXDays) < DateTime.Now)
                                {
                                    filesCleared.Add(fi.FullName);
                                    fi.Delete();
                                }
                            }

                            lastLoggingCleanupEvent = DateTime.Now;
                            foreach (string fileName in filesCleared)
                            {
                                WriteLogging(string.Format("The logging file '{0}' has been deleted because it is older than {1} days.", fileName, LoggingKeepLogFilesXDays));
                            }
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
            WriteLogging("Monitor pack was changed");
        }

        private void LoggingMonitorPackClosed()
        {
            WriteLogging("Monitor pack was closed or stopped");
        }

        private void LoggingCollectorEvent(string message, CollectorHost collectorHost)
        {
            bool allCollectors = LoggingCollectorCategories == null || LoggingCollectorCategories.Count == 0;
            bool matchCategories = false;
            if (!allCollectors)
            {
                foreach (string category in LoggingCollectorCategories)
	            {
                    if (IsCollectorInLoggingCategory(category, collectorHost))
                    {
                        matchCategories = true;
                        break;
                    }
                }

                //if (collectorHost.Categories != null && collectorHost.Categories.Count > 0)
                //{
                    
                //    foreach(string cat in collectorHost.Categories)
                //        if (LoggingCollectorCategories.Contains(cat))
                //        {
                //            matchCategories = true;
                //            break;
                //        }
                //}
            }
            if (LoggingCollectorEvents && (allCollectors || matchCategories))
                WriteLogging(message);
        }

        private bool IsCollectorInLoggingCategory(string category, CollectorHost collectorHost)
        {
            if (category == "*") //don't bother further testing
                return true;
            else if (category.StartsWith("*"))
            {
                string endsWith = category.Substring(1);
                if ((from s in collectorHost.Categories
                     where s.EndsWith(endsWith, StringComparison.InvariantCultureIgnoreCase)
                     select s).Count() > 0)
                    return true;
            }
            else if (category.EndsWith("*"))
            {
                string startsWith = category.Substring(0, category.Length - 1);
                if ((from s in collectorHost.Categories
                     where s.StartsWith(startsWith, StringComparison.InvariantCultureIgnoreCase)
                     select s).Count() > 0)
                    return true;
            }
            else if (collectorHost.Categories.Contains(category))
                return true;
            return false;
        }

        private void LoggingNotifierEvent(string message)
        {
            if (LoggingNotifierEvents)
                WriteLogging(message);
        }

        private void LoggingAlertsRaisedEvent(string message)
        {
            if (LoggingAlertsRaised)
                WriteLogging(message);
        }

        private void LoggingCorrectiveScriptRunEvent(string message)
        {
            if (LoggingCorrectiveScriptRun)
                WriteLogging(message);
        }

        private void LoggingPollingOverridesTriggeredEvent(string message, CollectorHost collectorHost)
        {
            if (LoggingPollingOverridesTriggered)
            {
                WriteLogging(string.Format("Collector '{0}' encoutered polling override event: {1}", collectorHost.Name, message));
            }
        }

        private void LoggingServiceWindowEvent(CollectorHost collectorHost, bool entered)
        {
            if (LoggingServiceWindowEvents)
            {
                if (entered)
                    WriteLogging(string.Format("Collector '{0}' entered a service window.", collectorHost.Name));
                else
                    WriteLogging(string.Format("Collector '{0}' exited a service window.", collectorHost.Name));
            }
        }     
    }
}
