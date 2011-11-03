using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Threading;

namespace QuickMon
{
    public class LogFile : NotifierBase
    {
        private string outputPath = "";
        private long createNewFileSizeKB = 0;
        private Mutex logWriteMutex = new Mutex();

        public override void RecordMessage(AlertLevel alertLevel, string collectorType, string category, MonitorStates oldState, MonitorStates newState, CollectorMessage collectorMessage)
        {
            try
            {
                logWriteMutex.WaitOne();
                if (createNewFileSizeKB > 0)
                {
                    FileInfo fi = new FileInfo(outputPath);
                    if (fi.Exists)
                    {
                        if (fi.Length > createNewFileSizeKB * 1024)
                        {
                            CreateBackupFile(outputPath, 1);
                        }
                    }
                }

                File.AppendAllText(outputPath,
                    string.Format("Time: {0}\r\nAlert level: {1}\r\nCollector: {2}\r\nCategory: {3}\r\nOld state: {4}\r\nCurrent state: {5}\r\nDetails: {6}",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Enum.GetName(typeof(AlertLevel), alertLevel),
                        collectorType,
                        category,
                        Enum.GetName(typeof(MonitorStates), oldState),
                        Enum.GetName(typeof(MonitorStates), newState),
                        collectorMessage.PlainText + "\r\n" + new string('-', 79) + "\r\n"
                    ));
            }
            catch{ }
            finally
            {
                logWriteMutex.ReleaseMutex();
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
        public override string ConfigureAgent(string config)
        {
            EditConfig editConfig = new EditConfig();
            editConfig.CustomConfig = config;
            if (editConfig.ShowConfig() == System.Windows.Forms.DialogResult.OK)
                config = editConfig.CustomConfig;
            return config;
        }
        public override void ReadConfiguration(XmlDocument config)
        {
            XmlElement root = config.DocumentElement;
            XmlNode logFileNode = root.SelectSingleNode("logFile");
            outputPath = logFileNode.ReadXmlElementAttr("path", "");
            createNewFileSizeKB = long.Parse(logFileNode.ReadXmlElementAttr("createNewFileSizeKB", "0"));
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.LogFileEmptyConfig_xml;
        }
        public override bool HasViewer { get { return true; } }
        public override void OpenViewer(string notifierName)
        {
            if (File.Exists(outputPath))
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo() { FileName = outputPath };
                p.Start();
            }
        }
    }
}
