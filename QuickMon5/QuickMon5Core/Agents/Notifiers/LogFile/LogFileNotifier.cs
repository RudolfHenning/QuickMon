using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Notifiers
{
    [Description("Log File Notifier")]
    public class LogFileNotifier : NotifierAgentBase
    {
        public LogFileNotifier()
        {
            AgentConfig = new LogFileNotifierConfig();
        }

        public override void RecordMessage(AlertRaised alertRaised)
        {
            LogFileNotifierConfig currentConfig = (LogFileNotifierConfig)AgentConfig;
            string outputFile = currentConfig.GetCurrentLogFileName();
            string lastStep = "";            
            try
            {
                if (currentConfig.CreateNewFileSizeKB > 0)
                {
                    lastStep = "Checking if log file exists";
                    FileInfo fi = new FileInfo(outputFile);
                    if (fi.Exists)
                    {
                        lastStep = "Checking log file size";
                        if (fi.Length > currentConfig.CreateNewFileSizeKB * 1024)
                        {
                            lastStep = "Create new log file";
                            CreateBackupFile(outputFile, 1);
                        }
                    }
                }

                lastStep = "Append text to log file";

                string collectorName = "QuickMon Global Alert";
                string collectorAgents = "None";
                string oldState = "N/A";
                string newState = "N/A";
                string detailMessage = alertRaised.MessageRaw;
                string viaHost = "N/A";
                if (alertRaised.RaisedFor != null)
                {
                    collectorName = alertRaised.RaisedFor.Name;
                    collectorAgents = string.Format("{0} agent(s)", alertRaised.RaisedFor.CollectorAgents.Count);
                    if (alertRaised.RaisedFor.CollectorAgents.Count > 0)
                    {
                        collectorAgents += " {";
                        alertRaised.RaisedFor.CollectorAgents.ForEach(ca => collectorAgents += ca.AgentClassDisplayName + ",");
                        collectorAgents = collectorAgents.TrimEnd(',') + "}";
                    }
                    oldState = Enum.GetName(typeof(CollectorState), alertRaised.RaisedFor.PreviousState.State);
                    newState = Enum.GetName(typeof(CollectorState), alertRaised.RaisedFor.CurrentState.State);
                    if (alertRaised.RaisedFor.OverrideRemoteAgentHost)
                        viaHost = string.Format("{0}:{1}", alertRaised.RaisedFor.OverrideRemoteAgentHostAddress, alertRaised.RaisedFor.OverrideRemoteAgentHostPort);
                    else if (alertRaised.RaisedFor.EnableRemoteExecute)
                        viaHost = string.Format("{0}:{1}", alertRaised.RaisedFor.RemoteAgentHostAddress, alertRaised.RaisedFor.RemoteAgentHostPort);
                }
                //                DateTime.Now.ToLocalTime
                string formattedTime = "";
                if (currentConfig.UseLocalTimeFormat || currentConfig.CustomTimeFormat.Trim().Length == 0)
                    formattedTime = DateTime.Now.ToString();
                else
                    formattedTime = DateTime.Now.ToString(currentConfig.CustomTimeFormat);

                File.AppendAllText(outputFile,
                    string.Format("Time: {0}\r\nAlert level: {1}\r\nCollector: {2}\r\nAgents: {3}\r\nOld state: {4}\r\nCurrent state: {5}\r\nVia host: {6}\r\nDetails: {7}",
                        formattedTime,
                        Enum.GetName(typeof(AlertLevel), alertRaised.Level),                        
                        collectorName,
                        collectorAgents,
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

        public override AttendedOption AttendedRunOption { get { return AttendedOption.AttendedAndUnAttended; } }
    }
    public class LogFileNotifierConfig : INotifierConfig
    {
        public string OutputPath { get; set; }
        public long CreateNewFileSizeKB { get; set; }
        public bool AppendDate { get; set; }
        public bool UseLocalTimeFormat { get; set; } = true;
        public string CustomTimeFormat { get; set; } = "yyyy-MM-dd HH:mm:ss";

        #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            XmlNode logFileNode = root.SelectSingleNode("logFile");
            OutputPath = logFileNode.ReadXmlElementAttr("path", "");
            CreateNewFileSizeKB = logFileNode.ReadXmlElementAttr("createNewFileSizeKB", (long)0);
            AppendDate = logFileNode.ReadXmlElementAttr("appendDate", false);
            UseLocalTimeFormat = logFileNode.ReadXmlElementAttr("useLocalTimeFormat", true);
            CustomTimeFormat = logFileNode.ReadXmlElementAttr("customTimeFormat", "yyyy-MM-dd HH:mm:ss");
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlNode root = config.SelectSingleNode("config/logFile");
            root.SetAttributeValue("path", OutputPath);
            root.SetAttributeValue("createNewFileSizeKB",CreateNewFileSizeKB);
            root.SetAttributeValue("appendDate", AppendDate);
            root.SetAttributeValue("useLocalTimeFormat", UseLocalTimeFormat);
            root.SetAttributeValue("customTimeFormat", CustomTimeFormat);
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config><logFile path=\"c:\\Temp\\QuickMonLog.log\" createNewFileSizeKB=\"0\" appendDate=\"false\" /></config>";
        }
        public string ConfigSummary
        {
            get
            {
                string summary = "Output path: '" + OutputPath;
                summary += "',Create new file size: " + CreateNewFileSizeKB.ToString() + "KB";
                summary += AppendDate ? ",Append Date" : "";
                return summary;
            }
        }
        #endregion

        public string GetCurrentLogFileName()
        {
            string outputFile = OutputPath;
            if (AppendDate)
            {
                outputFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(outputFile), System.IO.Path.GetFileNameWithoutExtension(outputFile) + DateTime.Now.ToString("yyyyMMdd") + System.IO.Path.GetExtension(outputFile));
            }
            return outputFile;
        }
    }
}
