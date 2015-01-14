using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Notifiers
{
    public class LogFileNotifierConfig : INotifierConfig
    {
        public string OutputPath { get; set; }
        public long CreateNewFileSizeKB { get; set; }

        #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            XmlNode logFileNode = root.SelectSingleNode("logFile");
            OutputPath = logFileNode.ReadXmlElementAttr("path", "");
            CreateNewFileSizeKB = long.Parse(logFileNode.ReadXmlElementAttr("createNewFileSizeKB", "0"));
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlNode root = config.SelectSingleNode("config/logFile");
            root.Attributes["path"].Value = OutputPath;
            root.Attributes["createNewFileSizeKB"].Value = CreateNewFileSizeKB.ToString();
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config><logFile path=\"c:\\Temp\\QuickMonLog.log\" createNewFileSizeKB=\"0\" /></config>";
        }
        public string ConfigSummary
        {
            get
            {
                string summary = "Output path: '" + OutputPath;
                summary += "', Create new file size: " + CreateNewFileSizeKB.ToString() + "KB";
                return summary;
            } 
        }
        #endregion
    }
}
