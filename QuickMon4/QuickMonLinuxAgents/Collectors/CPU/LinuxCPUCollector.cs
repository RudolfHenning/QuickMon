using QuickMon.Linux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("CPU Collector"), Category("Linux")]
    public class LinuxCPUCollector : CollectorAgentBase
    {
        public LinuxCPUCollector()
        {
            AgentConfig = new LinuxCPUCollectorConfig();
        }

        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();
            string lastAction = "";
            double highestVal = 0;
            int errors = 0;
            int warnings = 0;
            int success = 0;

            try
            {
                LinuxCPUCollectorConfig currentConfig = (LinuxCPUCollectorConfig)AgentConfig;
                returnState.RawDetails = string.Format("Querying {0} entries", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<b>Querying {0} entries</b>", currentConfig.Entries.Count);
                foreach (LinuxCPUEntry entry in currentConfig.Entries)
                {
                    foreach(Linux.CPUInfo cpuInfo in  entry.GetCPUInfos())
                    {
                        if (highestVal < cpuInfo.CPUPerc)
                            highestVal = cpuInfo.CPUPerc;
                        CollectorState currentState = entry.GetState(cpuInfo.CPUPerc);
                        if (currentState == CollectorState.Error)
                        {
                            errors++;
                            returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    ForAgent = entry.MachineName + "(" + cpuInfo.Name + ")",
                                    State = CollectorState.Error,
                                    CurrentValue = cpuInfo.CPUPerc,
                                    RawDetails = string.Format("'{0}': {1} (Error)", entry.MachineName + "(" + cpuInfo.Name + ")", cpuInfo.CPUPerc),
                                    HtmlDetails = string.Format("'{0}': {1} (<b>Error</b>)", entry.MachineName + "(" + cpuInfo.Name + ")", cpuInfo.CPUPerc)
                                });
                        }
                        else if (currentState == CollectorState.Warning)
                        {
                            warnings++;
                            returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    ForAgent = entry.MachineName + "(" + cpuInfo.Name + ")",
                                    State = CollectorState.Warning,
                                    CurrentValue = cpuInfo.CPUPerc,
                                    RawDetails = string.Format("'{0}': {1} (Warning)", entry.MachineName + "(" + cpuInfo.Name + ")", cpuInfo.CPUPerc),
                                    HtmlDetails = string.Format("'{0}': {1} (<b>Warning</b>)", entry.MachineName + "(" + cpuInfo.Name + ")", cpuInfo.CPUPerc)
                                });
                        }
                        else
                        {
                            success++;
                            returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    ForAgent = entry.MachineName + "(" + cpuInfo.Name + ")",
                                    State = CollectorState.Good,
                                    CurrentValue = cpuInfo.CPUPerc,
                                    RawDetails = string.Format("'{0}': {1}", entry.MachineName + "(" + cpuInfo.Name + ")", cpuInfo.CPUPerc),
                                    HtmlDetails = string.Format("'{0}': {1}", entry.MachineName + "(" + cpuInfo.Name + ")", cpuInfo.CPUPerc)
                                });
                        }
                    }                    
                }
                returnState.CurrentValue = highestVal;

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
                dt.Columns.Add(new System.Data.DataColumn("CPU", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Percentage Usage", typeof(double)));

                LinuxCPUCollectorConfig currentConfig = (LinuxCPUCollectorConfig)AgentConfig;
                foreach (LinuxCPUEntry entry in currentConfig.Entries)
                {
                    foreach (Linux.CPUInfo cpuInfo in entry.GetCPUInfos())
                    {
                        dt.Rows.Add(entry.MachineName, cpuInfo.Name, cpuInfo.CPUPerc);
                    }                    
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

    public class LinuxCPUCollectorConfig : ICollectorConfig
    {
        public LinuxCPUCollectorConfig()
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
            foreach (XmlElement pcNode in root.SelectNodes("linux/cpu"))
            {
                LinuxCPUEntry entry = new LinuxCPUEntry();
                entry.MachineName = pcNode.ReadXmlElementAttr("machine", ".");
                entry.SSHPort = pcNode.ReadXmlElementAttr("sshPort", 22);
                entry.UseOnlyTotalCPUvalue = pcNode.ReadXmlElementAttr("totalCPU", true);
                entry.SSHSecurityOption = SSHSecurityOptionTypeConverter.FromString(pcNode.ReadXmlElementAttr("sshSecOpt", "password"));
                entry.WarningValue = float.Parse(pcNode.ReadXmlElementAttr("warningValue", "80"));
                entry.ErrorValue = float.Parse(pcNode.ReadXmlElementAttr("errorValue", "99"));
                entry.UserName = pcNode.ReadXmlElementAttr("userName", "");
                entry.Password = pcNode.ReadXmlElementAttr("password", "");
                entry.PrivateKeyFile = pcNode.ReadXmlElementAttr("privateKeyFile", "");
                entry.PassPhrase = pcNode.ReadXmlElementAttr("passPhrase", "");
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
            foreach (LinuxCPUEntry entry in Entries)
            {
                XmlElement cpuNode = config.CreateElement("cpu");
                cpuNode.SetAttributeValue("machine", entry.MachineName);
                cpuNode.SetAttributeValue("sshPort", entry.SSHPort);
                cpuNode.SetAttributeValue("totalCPU", entry.UseOnlyTotalCPUvalue);
                cpuNode.SetAttributeValue("sshSecOpt", entry.SSHSecurityOption.ToString());
                cpuNode.SetAttributeValue("warningValue", entry.WarningValue);
                cpuNode.SetAttributeValue("errorValue", entry.ErrorValue);
                cpuNode.SetAttributeValue("userName", entry.UserName);
                cpuNode.SetAttributeValue("password", entry.Password);
                cpuNode.SetAttributeValue("privateKeyFile", entry.PrivateKeyFile);
                cpuNode.SetAttributeValue("passPhrase", entry.PassPhrase);
                linuxCPUNode.AppendChild(cpuNode);
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

    public class LinuxCPUEntry : LinuxBaseEntry
    {
        public LinuxCPUEntry()
        {
            UseOnlyTotalCPUvalue = true;
            WarningValue = 80;
            ErrorValue = 99;
        }
        public bool UseOnlyTotalCPUvalue { get; set; }
        public double WarningValue { get; set; }
        public double ErrorValue { get; set; }

        public List<Linux.CPUInfo> GetCPUInfos()
        {
            List<Linux.CPUInfo> cpus = new List<Linux.CPUInfo>();
            Renci.SshNet.SshClient sshClient = SshClientTools.GetSSHConnection(SSHSecurityOption, MachineName, SSHPort, UserName, Password, PrivateKeyFile, PassPhrase);

            if (sshClient.IsConnected)
            {
                foreach (Linux.CPUInfo ci in Linux.CPUInfo.GetCurrentCPUPerc(sshClient))
                {
                    if (UseOnlyTotalCPUvalue && ci.IsTotalCPU)
                        cpus.Add(ci);
                    else if (!UseOnlyTotalCPUvalue)
                        cpus.Add(ci);
                }
            }
            sshClient.Disconnect();

            return cpus;
        }

        public CollectorState GetState(double value)
        {
            CollectorState state = CollectorState.Good;
            if (WarningValue < ErrorValue)
            {
                if (ErrorValue <= value)
                    state = CollectorState.Error;
                else if (WarningValue <= value)
                    state = CollectorState.Warning;
            }
            else
            {
                if (ErrorValue >= value)
                    state = CollectorState.Error;
                else if (WarningValue >= value)
                    state = CollectorState.Warning;
            }
            return state;
        }

        #region ICollectorConfigEntry Members
        public override string Description
        {
            get
            {
                return string.Format("{0}:{1} ({2})", MachineName, SSHPort, UseOnlyTotalCPUvalue ? "Total" : "All Cores/CPUs");
            }
        }
        public override string TriggerSummary
        {
            get
            {
                return string.Format("Warn: {0}%, Err: {1}%", WarningValue, ErrorValue);
            }
        }
        #endregion
    }
}
