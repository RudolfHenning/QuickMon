using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace QuickMon.Notifiers
{
    [Description("Log File Notifier")]
    public class LogFileNotifier : NotifierBase
    {
        public LogFileNotifier()
        {
            AgentConfig = new LogFileNotifierConfig();
        }
        public override void RecordMessage(AlertRaised alertRaised)
        {
            LogFileNotifierConfig currentConfig = (LogFileNotifierConfig)AgentConfig;
            string lastStep = "";
            try
            {
                if (currentConfig.CreateNewFileSizeKB > 0)
                {
                    lastStep = "Checking if log file exists";
                    FileInfo fi = new FileInfo(currentConfig.OutputPath);
                    if (fi.Exists)
                    {
                        lastStep = "Checking log file size";
                        if (fi.Length > currentConfig.CreateNewFileSizeKB * 1024)
                        {
                            lastStep = "Create new log file";
                            CreateBackupFile(currentConfig.OutputPath, 1);
                        }
                    }
                }

                lastStep = "Append text to log file";

                string collectorName = "QuickMon Global Alert";
                string collectorType = "None";
                string oldState = "N/A";
                string newState = "N/A";
                string detailMessage = "N/A";
                string viaHost = "N/A";
                if (alertRaised.RaisedFor != null)
                {
                    collectorName = alertRaised.RaisedFor.Name;
                    collectorType = alertRaised.RaisedFor.CollectorRegistrationName;
                    oldState = Enum.GetName(typeof(CollectorState), alertRaised.RaisedFor.LastMonitorState.State);
                    newState = Enum.GetName(typeof(CollectorState), alertRaised.RaisedFor.CurrentState.State);
                    detailMessage = alertRaised.RaisedFor.CurrentState.RawDetails;
                    if (alertRaised.RaisedFor.OverrideRemoteAgentHost)
                        viaHost = string.Format("{0}:{1}", alertRaised.RaisedFor.OverrideRemoteAgentHostAddress, alertRaised.RaisedFor.OverrideRemoteAgentHostPort);
                    else if (alertRaised.RaisedFor.EnableRemoteExecute)
                        viaHost = string.Format("{0}:{1}", alertRaised.RaisedFor.RemoteAgentHostAddress, alertRaised.RaisedFor.RemoteAgentHostPort);
                }

                File.AppendAllText(currentConfig.OutputPath,
                    string.Format("Time: {0}\r\nAlert level: {1}\r\nCollector: {2}\r\nCategory: {3}\r\nOld state: {4}\r\nCurrent state: {5}\r\nVia host: {6}\r\nDetails: {7}",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Enum.GetName(typeof(AlertLevel), alertRaised.Level),
                        collectorType,
                        collectorName,
                        oldState,
                        newState,
                        viaHost,
                        detailMessage + "\r\n" + new string('-', 79) + "\r\n"
                    ));
            }
            catch (Exception ex)
            {
                throw new Exception("Error recording message in log file notifier '{0}'\r\nLast step: " + lastStep, ex);
            }
        }
        private void CreateBackupFile(string baseFilePath, int counter)
        {
            string newFileName = Path.Combine(Path.GetDirectoryName(baseFilePath), Path.GetFileNameWithoutExtension(baseFilePath) + counter.ToString() + Path.GetExtension(baseFilePath));
            if (File.Exists(newFileName))
            {
                CreateBackupFile(baseFilePath, counter + 1);
            }
            else
            {
                File.Move(baseFilePath, newFileName);
            }
        }

        public override bool HasViewer
        {
            get { return true; }
        }
        public override INotivierViewer GetNotivierViewer()
        {
            return new LogFileNotifierShowViewer();
        }
        public override IEditConfigWindow GetEditConfigWindow()
        {
            return new LogFileNotifierEditConfig();
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.LogFileNotifierDefaultConfig;
        }

        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new LogFileNotifierEditConfig();
        }
    }
}
