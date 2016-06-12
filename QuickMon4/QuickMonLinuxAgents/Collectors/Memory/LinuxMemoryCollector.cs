using QuickMon.Linux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("Memory Free % Collector"), Category("SSH")]
    public class LinuxMemoryCollector : CollectorAgentBase
    {
        public LinuxMemoryCollector()
        {
            AgentConfig = new LinuxMemoryCollectorConfig();
        }

        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();
            string lastAction = "";
            double lowestVal = 100;
            int errors = 0;
            int warnings = 0;
            int success = 0;

            try
            {
                LinuxMemoryCollectorConfig currentConfig = (LinuxMemoryCollectorConfig)AgentConfig;
                foreach (LinuxMemoryEntry entry in currentConfig.Entries)
                {
                    Linux.MemInfo memInfo = entry.GetMemoryInfo();
                    double percVal = entry.GetMonitoredValue(memInfo);
                    CollectorState currentState = entry.GetState(memInfo);
                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                    }
                    else
                    {
                        success++;
                    }
                    returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                ForAgent = entry.SSHConnection.ComputerName,
                                State = currentState,
                                CurrentValue = percVal,
                                CurrentValueUnit = "%"
                            });
                    if (lowestVal > percVal)
                        lowestVal = percVal;

                }
                returnState.CurrentValue = lowestVal;
                returnState.CurrentValueUnit = "% (lowest value)";

                if (errors > 0 && warnings == 0 && success == 0) // any errors
                    returnState.State = CollectorState.Error;
                else if (errors > 0 || warnings > 0) //any warnings
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;
            }
            catch (Exception ex)
            {
                returnState.RawDetails = ex.Message;
                returnState.HtmlDetails = string.Format("<p><b>Last action:</b> {0}</p><blockquote>{1}</blockquote>", lastAction, ex.Message);
                returnState.State = CollectorState.Error;
            }
            return returnState;
        }

        public override List<System.Data.DataTable> GetDetailDataTables()
        {
            List<System.Data.DataTable> tables = new List<System.Data.DataTable>();
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                dt.Columns.Add(new System.Data.DataColumn("Computer", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Percentage Usage", typeof(double)));

                LinuxMemoryCollectorConfig currentConfig = (LinuxMemoryCollectorConfig)AgentConfig;
                foreach (LinuxMemoryEntry entry in currentConfig.Entries)
                {
                    Linux.MemInfo memInfo = entry.GetMemoryInfo();
                    double percVal = memInfo.AvailablePerc;
                    if (percVal == 0)
                        percVal = memInfo.FreePerc;
                    dt.Rows.Add(entry.SSHConnection.ComputerName, percVal);                    
                }
            }
            catch (Exception ex)
            {
                dt = new System.Data.DataTable("Exception");
                dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
                dt.Rows.Add(ex.ToString());
            }
            tables.Add(dt);
            return tables;
        }
    }

    public class LinuxMemoryCollectorConfig : ICollectorConfig
    {
        public LinuxMemoryCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            if (configurationString == null || configurationString.Length == 0)
                return;
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement pcNode in root.SelectNodes("linux/memory"))
            {
                LinuxMemoryEntry entry = new LinuxMemoryEntry();
                entry.SSHConnection = SSHConnectionDetails.FromXmlElement(pcNode);

                //entry.SSHConnection.SSHSecurityOption = SSHSecurityOptionTypeConverter.FromString(pcNode.ReadXmlElementAttr("sshSecOpt", "password"));
                //entry.SSHConnection.ComputerName = pcNode.ReadXmlElementAttr("machine", ".");
                //entry.SSHConnection.SSHPort = pcNode.ReadXmlElementAttr("sshPort", 22);   
                //entry.SSHConnection.UserName = pcNode.ReadXmlElementAttr("userName", "");
                //entry.SSHConnection.Password = pcNode.ReadXmlElementAttr("password", "");
                //entry.SSHConnection.PrivateKeyFile = pcNode.ReadXmlElementAttr("privateKeyFile", "");
                //entry.SSHConnection.PassPhrase = pcNode.ReadXmlElementAttr("passPhrase", "");    

                entry.LinuxMemoryType = LinuxMemoryTypeTypeConverter.FromString(pcNode.ReadXmlElementAttr("memoryType", "MemAvailable"));
                entry.WarningValue = float.Parse(pcNode.ReadXmlElementAttr("warningValue", "20"));
                entry.ErrorValue = float.Parse(pcNode.ReadXmlElementAttr("errorValue", "10"));
                Entries.Add(entry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode linuxCPUNode = root.SelectSingleNode("linux");
            linuxCPUNode.InnerXml = "";
            foreach (LinuxMemoryEntry entry in Entries)
            {
                XmlElement memNode = config.CreateElement("memory");
                entry.SSHConnection.SaveToXmlElementAttr(memNode);
                //cpuNode.SetAttributeValue("sshSecOpt", entry.SSHConnection.SSHSecurityOption.ToString());
                //cpuNode.SetAttributeValue("machine", entry.SSHConnection.ComputerName);
                //cpuNode.SetAttributeValue("sshPort", entry.SSHConnection.SSHPort);
                //cpuNode.SetAttributeValue("userName", entry.SSHConnection.UserName);
                //cpuNode.SetAttributeValue("password", entry.SSHConnection.Password);
                //cpuNode.SetAttributeValue("privateKeyFile", entry.SSHConnection.PrivateKeyFile);
                //cpuNode.SetAttributeValue("passPhrase", entry.SSHConnection.PassPhrase);
                memNode.SetAttributeValue("memoryType", entry.LinuxMemoryType.ToString());
                memNode.SetAttributeValue("warningValue", entry.WarningValue);
                memNode.SetAttributeValue("errorValue", entry.ErrorValue);
                linuxCPUNode.AppendChild(memNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config>\r\n<linux>\r\n</linux>\r\n</config>";
        }
        public string ConfigSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("{0} entry(s): ", Entries.Count));
                if (Entries.Count == 0)
                    sb.Append("None");
                else
                {
                    foreach (ICollectorConfigEntry entry in Entries)
                    {
                        sb.Append(entry.Description + ", ");
                    }
                }
                return sb.ToString().TrimEnd(' ', ',');
            }
        }
        #endregion
    }

    public class LinuxMemoryEntry : LinuxBaseEntry
    {
        public LinuxMemoryEntry()
        {
            LinuxMemoryType = Collectors.LinuxMemoryType.MemAvailable;
            WarningValue = 20;
            ErrorValue = 10;
        }

        public LinuxMemoryType LinuxMemoryType { get; set; }
        public double WarningValue { get; set; }
        public double ErrorValue { get; set; }

        public MemInfo GetMemoryInfo()
        {
            MemInfo mi = new MemInfo();
            Renci.SshNet.SshClient sshClient = SSHConnection.GetConnection();
            mi = MemInfo.FromCatProcMeminfo(sshClient);
            SSHConnection.CloseConnection();
            return mi;
        }
        public CollectorState GetState(MemInfo mi)
        {
            CollectorState state = CollectorState.Good;
            if (ErrorValue >= GetMonitoredValue(mi))
                state = CollectorState.Error;
            else if (WarningValue >= GetMonitoredValue(mi))
                state = CollectorState.Warning;

            return state;
        }
        public double GetMonitoredValue(MemInfo mi)
        {
            double outputValue=0;
            if (LinuxMemoryType == Collectors.LinuxMemoryType.MemAvailable)
            {
                outputValue = mi.AvailablePerc;
                if (outputValue == 0)
                {
                    outputValue = (mi.FreeKB + mi.Buffers + mi.Cached) / mi.TotalKB;
                }
            }
            else if (LinuxMemoryType == Collectors.LinuxMemoryType.MemFree)
            {
                outputValue = mi.FreePerc;
            }
            else
            {
                outputValue = mi.SwapFreePerc;
            }
            return outputValue;
        }

        #region ICollectorConfigEntry Members
        public override string TriggerSummary
        {
            get
            {
                return string.Format("Warn: {0}%, Err: {1}%", WarningValue, ErrorValue);
            }
        }
        #endregion
    }

    public enum LinuxMemoryType
    {
        MemAvailable,
        MemFree,        
        SwapFree
    }

    public static class LinuxMemoryTypeTypeConverter
    {
        public static LinuxMemoryType FromString(string value)
        {
            if (value.ToLower() == "memavailable")
                return LinuxMemoryType.MemAvailable;
            else if (value.ToLower() == "memfree")
                return LinuxMemoryType.MemFree;
            else
                return LinuxMemoryType.SwapFree;
        }
    }
}
