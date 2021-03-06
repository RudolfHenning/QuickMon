﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

// Alert and Metric logging
namespace QuickMon
{
    public partial class MonitorPack
    {
        #region Event Logging
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

        #region Event Logging Methods
        private void WriteLogging(string message)
        {
            try
            {
                if (LoggingEnabled)
                {
                    string logFileName = "";

                    if (MonitorPackPath != null && MonitorPackPath.Length > 0)
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
        #endregion

        #endregion

        #region Metrics exporting
        public string ExportCurrentCollectorMetricsToCSV()
        {
            StringBuilder sb = new StringBuilder();
            foreach (CollectorHost ch in CollectorHosts)
            {
                if (CollectorMetricsExportIncludeDisabled || (ch.CurrentState != null && ch.CurrentState.State != CollectorState.None && ch.CurrentState.State != CollectorState.Disabled && ch.CurrentState.State != CollectorState.NotAvailable && ch.CurrentState.State != CollectorState.NotInServiceWindow))
                    sb.Append(ch.ExportCurrentMetricsToCSV());
            }
            return sb.ToString();
        }
        public string ExportCollectorHistoryToCSV(bool addheader = true)
        {
            StringBuilder sb = new StringBuilder();
            if (addheader)
                sb.Append(CollectorHost.ExportHistoryToCSVHeaders());
            foreach (CollectorHost ch in CollectorHosts)
            {
                sb.Append(ch.ExportHistoryToCSV());
            }
            return sb.ToString();
        }
        public string ExportCollectorHistoryToXML()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<collectorHostHistories>");
            foreach (CollectorHost ch in CollectorHosts)
            {
                sb.AppendLine(ch.ExportHistoryToXML());
            }
            sb.AppendLine("</collectorHostHistories>");
            return sb.ToString().BeautifyXML();// XmlFormattingUtils.NormalizeXML(sb.ToString());
        }        
        #endregion

        #region Metrics exporting Properties
        public bool CollectorMetricsExportToCSVEnabled { get; set; }
        public bool CollectorMetricsExportToXMLEnabled { get; set; }
        public bool CollectorMetricsExportIncludeDisabled { get; set; }
        public string CollectorMetricsExportPath { get; set; }
        private static object collectorMetricsSyncLock = new object();
        #endregion

        #region Metrics exporting Methods
        public void ExportCollectorMetricsToCSV()
        {
            string outputPath = CollectorMetricsExportPath;
            string outputFileName = Name.StringToSaveFileName() + DateTime.Now.Date.ToString("yyyyMMdd") + ".csv";
            if (outputPath.Length == 0)
            {
                if (MonitorPackPath != null && MonitorPackPath.Length > 0)
                {
                    outputPath = System.IO.Path.GetDirectoryName(MonitorPackPath);
                }
                else
                {
                    outputPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }
                outputPath = System.IO.Path.Combine(outputPath, outputFileName);
            }
            else if (System.IO.Directory.Exists(outputPath))
            {
                outputPath = System.IO.Path.Combine(outputPath, outputFileName);
            }
            
            ////Get output directory
            //if (outputPath.Length == 0 || (!System.IO.Directory.Exists(outputPath) && !System.IO.File.Exists(outputPath)))
            //{
            //    if (MonitorPackPath != null && MonitorPackPath.Length > 0)
            //    {
            //        outputPath = System.IO.Path.GetDirectoryName(MonitorPackPath);
            //    }
            //    else
            //    {
            //        outputPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //    }
            //}
            //outputPath = System.IO.Path.Combine(outputPath, outputFileName);
            try
            {
                lock (collectorMetricsSyncLock)
                {
                    if (!System.IO.File.Exists(outputPath))
                        System.IO.File.WriteAllText(outputPath, CollectorHost.ExportHistoryToCSVHeaders());
                        
                    System.IO.File.AppendAllText(outputPath, ExportCurrentCollectorMetricsToCSV());
                }
            }
            catch (Exception ex)
            {
                WriteLogging(string.Format("Error performing ExportCollectorMetricsToCSV: {0}", ex.Message));
                RaiseMonitorPackError(string.Format("Error performing ExportCollectorMetricsToCSV: {0}", ex.Message));
            }
        }
        public void ExportCollectorMetricsToXML()
        {
            string outputPath = CollectorMetricsExportPath;
            string outputFileName = Name.StringToSaveFileName() + DateTime.Now.Date.ToString("yyyyMMdd") + ".xml";
            //Get output directory
            if (outputPath.Length == 0 || !System.IO.Directory.Exists(outputPath))
            {
                if (MonitorPackPath != null && MonitorPackPath.Length > 0)
                {
                    outputPath = System.IO.Path.GetDirectoryName(MonitorPackPath);
                }
                else
                {
                    outputPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }
            }
            outputPath = System.IO.Path.Combine(outputPath, outputFileName);
            try
            {
                lock (collectorMetricsSyncLock)
                {
                    System.IO.File.WriteAllText(outputPath, ExportCollectorHistoryToXML());                    
                }
            }
            catch (Exception ex)
            {
                WriteLogging(string.Format("Error performing ExportCollectorMetricsToCSV: {0}", ex.Message));
                RaiseMonitorPackError(string.Format("Error performing ExportCollectorMetricsToCSV: {0}", ex.Message));
            }
        }
        #endregion
    }
}
