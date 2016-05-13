using QuickMon.Linux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("Process Performance Collector"), Category("Linux")]
    public class LinuxProcessCollector : CollectorAgentBase
    {
        public LinuxProcessCollector()
        {
            AgentConfig = new LinuxProcessCollectorConfig();
        }

        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();
            string lastAction = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;

            try
            {
                LinuxProcessCollectorConfig currentConfig = (LinuxProcessCollectorConfig)AgentConfig;
                foreach (LinuxProcessEntry entry in currentConfig.Entries)
                {
                    MonitorState entryState = new MonitorState() { 
                        ForAgent = entry.Name + " (" + entry.SSHConnection.ComputerName + ")"
                    };
                    List<ProcessInfoState> pss = entry.GetStates();
                    foreach (ProcessInfoState ps in pss)
                    {
                        string currentValueFormat = "CPU%:" + ps.ProcessInfo.percCPU.ToString("0.00") + ",MEM%:" + ps.ProcessInfo.percMEM.ToString("0.00");
                        if (ps.State == CollectorState.Error)
                        {
                            errors++;
                        }
                        else if (ps.State == CollectorState.Warning)
                        {
                            warnings++;                            
                        }
                        else
                        {
                            success++;
                        }

                        entryState.ChildStates.Add(
                                new MonitorState()
                                {
                                    ForAgent = ps.ProcessInfo.ProcessName,
                                    State = ps.State,
                                    CurrentValue = currentValueFormat
                                });
                    }
                    returnState.ChildStates.Add(entryState);
                }
                returnState.CurrentValue = null;

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
                dt.Columns.Add(new System.Data.DataColumn("Process", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("CPU%", typeof(double)));
                dt.Columns.Add(new System.Data.DataColumn("Mem%", typeof(double)));

                LinuxProcessCollectorConfig currentConfig = (LinuxProcessCollectorConfig)AgentConfig;
                foreach (LinuxProcessEntry entry in currentConfig.Entries)
                {
                    foreach (ProcessInfoState pi in entry.GetStates())
                    {
                        dt.Rows.Add(entry.SSHConnection.ComputerName, pi.ProcessInfo.ProcessName, pi.ProcessInfo.percCPU, pi.ProcessInfo.percMEM);
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

    public class LinuxProcessCollectorConfig : ICollectorConfig
    {
        public LinuxProcessCollectorConfig()
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
            foreach (XmlElement procNode in root.SelectNodes("linuxProcess"))
            {
                LinuxProcessEntry entry = new LinuxProcessEntry();
                entry.SSHConnection = SSHConnectionDetails.FromXmlElement(procNode);

                //entry.SSHConnection.SSHSecurityOption = SSHSecurityOptionTypeConverter.FromString(procNode.ReadXmlElementAttr("sshSecOpt", "password"));
                //entry.SSHConnection.ComputerName = procNode.ReadXmlElementAttr("machine", ".");
                //entry.SSHConnection.SSHPort = procNode.ReadXmlElementAttr("sshPort", 22);
                //entry.SSHConnection.UserName = procNode.ReadXmlElementAttr("userName", "");
                //entry.SSHConnection.Password = procNode.ReadXmlElementAttr("password", "");
                //entry.SSHConnection.PrivateKeyFile = procNode.ReadXmlElementAttr("privateKeyFile", "");
                //entry.SSHConnection.PassPhrase = procNode.ReadXmlElementAttr("passPhrase", "");

                entry.Name = procNode.ReadXmlElementAttr("name", "");
                entry.ProcessCheckOption = ProcessCheckOptionTypeConverter.FromString(procNode.ReadXmlElementAttr("processCheckOption", ""));
                entry.TopProcessCount = procNode.ReadXmlElementAttr("topProcessCount", 10);
                entry.CPUPercWarningValue = procNode.ReadXmlElementAttr("cpuPercWarningValue", 80);
                entry.CPUPercErrorValue = procNode.ReadXmlElementAttr("cpuPercErrorValue", 90);
                entry.MemPercWarningValue = procNode.ReadXmlElementAttr("memPercWarningValue", 80);
                entry.MemPercErrorValue = procNode.ReadXmlElementAttr("memPercErrorValue", 90);

                entry.SubItems = new List<ICollectorConfigSubEntry>();
                foreach (XmlElement fileSystemNode in procNode.SelectNodes("specificEntry"))
                {
                    LinuxProcessSubEntry fse = new LinuxProcessSubEntry();
                    fse.ProcessName = fileSystemNode.ReadXmlElementAttr("name", "");
                    fse.CPUPercWarningValue = fileSystemNode.ReadXmlElementAttr("cpuPercWarningValue", 80);
                    fse.CPUPercErrorValue = fileSystemNode.ReadXmlElementAttr("cpuPercErrorValue", 90);
                    fse.MemPercWarningValue = fileSystemNode.ReadXmlElementAttr("memPercWarningValue", 80);
                    fse.MemPercErrorValue = fileSystemNode.ReadXmlElementAttr("memPercErrorValue", 90);

                    entry.SubItems.Add(fse);
                }
                Entries.Add(entry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            root.InnerXml = "";
            foreach (LinuxProcessEntry entry in Entries)
            {
                XmlElement processNode = config.CreateElement("linuxProcess");
                entry.SSHConnection.SaveToXmlElementAttr(processNode);
                //processNode.SetAttributeValue("machine", entry.SSHConnection.ComputerName);
                //processNode.SetAttributeValue("sshPort", entry.SSHConnection.SSHPort);
                //processNode.SetAttributeValue("sshSecOpt", entry.SSHConnection.SSHSecurityOption.ToString());
                //processNode.SetAttributeValue("userName", entry.SSHConnection.UserName);
                //processNode.SetAttributeValue("password", entry.SSHConnection.Password);
                //processNode.SetAttributeValue("privateKeyFile", entry.SSHConnection.PrivateKeyFile);
                //processNode.SetAttributeValue("passPhrase", entry.SSHConnection.PassPhrase);

                processNode.SetAttributeValue("name", entry.Name);
                processNode.SetAttributeValue("processCheckOption", entry.ProcessCheckOption.ToString());
                processNode.SetAttributeValue("topProcessCount", entry.TopProcessCount);
                processNode.SetAttributeValue("cpuPercWarningValue", entry.CPUPercWarningValue);
                processNode.SetAttributeValue("cpuPercErrorValue", entry.CPUPercErrorValue);
                processNode.SetAttributeValue("memPercWarningValue", entry.MemPercWarningValue);
                processNode.SetAttributeValue("memPercErrorValue", entry.MemPercErrorValue);

                foreach (LinuxProcessSubEntry fse in entry.SubItems)
                {
                    XmlElement specificNode = config.CreateElement("specificEntry");
                    specificNode.SetAttributeValue("name", fse.ProcessName);
                    specificNode.SetAttributeValue("cpuPercWarningValue", fse.CPUPercWarningValue);
                    specificNode.SetAttributeValue("cpuPercErrorValue", fse.CPUPercErrorValue);
                    specificNode.SetAttributeValue("memPercWarningValue", fse.MemPercWarningValue);
                    specificNode.SetAttributeValue("memPercErrorValue", fse.MemPercErrorValue);
                    processNode.AppendChild(specificNode);
                }

                root.AppendChild(processNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config>\r\n</config>";
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

    public class LinuxProcessEntry : LinuxBaseEntry
    {
        public LinuxProcessEntry()
        {
            ProcessCheckOption = ProcessCheckOption.TopXByCPU;
            TopProcessCount = 10;
            CPUPercWarningValue = 80;
            CPUPercErrorValue = 90;
            MemPercWarningValue = 50;
            MemPercErrorValue = 80;
        }
        public string Name { get; set; }
        public ProcessCheckOption ProcessCheckOption { get; set; }
        public int TopProcessCount { get; set; }
        public int CPUPercWarningValue { get; set; }
        public int CPUPercErrorValue { get; set; }
        public int MemPercWarningValue { get; set; }
        public int MemPercErrorValue { get; set; }

        public List<ProcessInfoState> GetStates()
        {
            List<ProcessInfoState> processEntries = new List<ProcessInfoState>();
            Renci.SshNet.SshClient sshClient = SSHConnection.GetConnection();

            LinuxProcessSubEntry globalAlertDef = new LinuxProcessSubEntry();
            globalAlertDef.CPUPercWarningValue = CPUPercWarningValue;
            globalAlertDef.CPUPercErrorValue = CPUPercErrorValue;
            globalAlertDef.MemPercWarningValue = MemPercWarningValue;
            globalAlertDef.MemPercErrorValue = MemPercErrorValue;

            List<ProcessInfo> runningProcesses = ProcessInfo.FromPsAux(sshClient);
            if (ProcessCheckOption == ProcessCheckOption.TopXByCPU)
            {
                foreach (ProcessInfo p in (from p in runningProcesses
                                           orderby p.percCPU descending
                                           select p).Take(TopProcessCount))
                {
                    processEntries.Add(new ProcessInfoState() { ProcessInfo = p, AlertDefinition = globalAlertDef });
                }

            }
            else if (ProcessCheckOption == ProcessCheckOption.TopXByMem)
            {
                foreach (ProcessInfo p in (from p in runningProcesses
                                           orderby p.percMEM descending
                                           select p).Take(TopProcessCount))
                {
                    processEntries.Add(new ProcessInfoState() { ProcessInfo = p, AlertDefinition = globalAlertDef });
                }
            }
            else
            {
                foreach (ProcessInfo p in runningProcesses)
                {
                    LinuxProcessSubEntry se = (from LinuxProcessSubEntry sdef in SubItems
                                               where FileNameMatch(p.ProcessName, sdef.ProcessName)
                                               select sdef).FirstOrDefault();
                    if (se != null)
                    {
                        processEntries.Add(new ProcessInfoState() { ProcessInfo = p, AlertDefinition = se });
                    }
                }
            }
            SSHConnection.CloseConnection();
            return processEntries;
        }
        private bool FileNameMatch(string fileName, string mask)
        {
            if (mask.Contains('*') || mask.Contains('?'))
            {
                Regex regex = FindFilesPatternToRegex.Convert(mask);
                return (regex.IsMatch(fileName));
            }
            else
                return fileName.ToLower() == mask.ToLower();
        }

        public override string TriggerSummary
        {
            get
            {
                if (ProcessCheckOption == Collectors.ProcessCheckOption.Specified)
                    return string.Format("{0} Process entry(s)", SubItems.Count);
                else if (ProcessCheckOption == Collectors.ProcessCheckOption.TopXByCPU)
                {
                    return string.Format("Top {0} Processes by CPU %", TopProcessCount);
                }
                else 
                {
                    return string.Format("Top {0} Processes by Memory %", TopProcessCount);
                }
            }
        }
    }

    public class LinuxProcessSubEntry : ICollectorConfigSubEntry
    {
        public LinuxProcessSubEntry()
        {
            CPUPercWarningValue = 80;
            CPUPercErrorValue = 90;
            MemPercWarningValue = 50;
            MemPercErrorValue = 80;
        }
        public string ProcessName { get; set; }
        public int CPUPercWarningValue { get; set; }
        public int CPUPercErrorValue { get; set; }
        public int MemPercWarningValue { get; set; }
        public int MemPercErrorValue { get; set; }

        public string Description
        {
            get { return string.Format("{0}:CPU%(W {1}, E{2}),MEM%(W {3},E {4})", ProcessName, CPUPercWarningValue, CPUPercErrorValue, MemPercWarningValue, MemPercErrorValue); }
        }
    }
    public class ProcessInfoState
    {
        public ProcessInfo ProcessInfo { get; set; }
        public LinuxProcessSubEntry AlertDefinition { get; set; }
        public CollectorState State {
            get 
            {
                CollectorState returnState = CollectorState.Good;
                if (AlertDefinition.CPUPercWarningValue < AlertDefinition.CPUPercErrorValue)
                {
                    if (AlertDefinition.CPUPercErrorValue < ProcessInfo.percCPU)
                    {
                        return CollectorState.Error;
                    }
                    else if (AlertDefinition.CPUPercWarningValue < ProcessInfo.percCPU)
                    {
                        returnState = CollectorState.Warning;
                    }
                }
                if (AlertDefinition.MemPercWarningValue < AlertDefinition.MemPercErrorValue)
                {
                    if (AlertDefinition.MemPercErrorValue < ProcessInfo.percMEM)
                    {
                        return CollectorState.Error;
                    }
                    else if (AlertDefinition.MemPercWarningValue < ProcessInfo.percMEM)
                    {
                        returnState = CollectorState.Warning;
                    }
                }
                return returnState;
            }
        }

    }
    public enum ProcessCheckOption
    {
        TopXByCPU,
        TopXByMem,
        Specified
    }
    public static class ProcessCheckOptionTypeConverter
    {
        public static ProcessCheckOption FromString(string typeName)
        {
            if (typeName.ToLower() == "TopXByCPU".ToLower())
                return ProcessCheckOption.TopXByCPU;
            else if (typeName.ToLower() == "TopXByMem".ToLower())
                return ProcessCheckOption.TopXByMem;
            else
                return ProcessCheckOption.Specified;
        }
    }

    //http://stackoverflow.com/questions/652037/how-do-i-check-if-a-filename-matches-a-wildcard-pattern
    internal static class FindFilesPatternToRegex
    {
        private static Regex HasQuestionMarkRegEx = new Regex(@"\?", RegexOptions.Compiled);
        private static Regex IllegalCharactersRegex = new Regex("[" + @"\/:<>|" + "\"]", RegexOptions.Compiled);
        private static Regex CatchExtentionRegex = new Regex(@"^\s*.+\.([^\.]+)\s*$", RegexOptions.Compiled);
        private static string NonDotCharacters = @"[^.]*";
        public static Regex Convert(string pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException();
            }
            pattern = pattern.Trim();
            if (pattern.Length == 0)
            {
                throw new ArgumentException("Pattern is empty.");
            }
            if (IllegalCharactersRegex.IsMatch(pattern))
            {
                throw new ArgumentException("Pattern contains illegal characters.");
            }
            bool hasExtension = CatchExtentionRegex.IsMatch(pattern);
            bool matchExact = false;
            if (HasQuestionMarkRegEx.IsMatch(pattern))
            {
                matchExact = true;
            }
            else if (hasExtension)
            {
                matchExact = CatchExtentionRegex.Match(pattern).Groups[1].Length != 3;
            }
            string regexString = Regex.Escape(pattern);
            regexString = "^" + Regex.Replace(regexString, @"\\\*", ".*");
            regexString = Regex.Replace(regexString, @"\\\?", ".");
            if (!matchExact && hasExtension)
            {
                regexString += NonDotCharacters;
            }
            regexString += "$";
            Regex regex = new Regex(regexString, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex;
        }
    }
}
