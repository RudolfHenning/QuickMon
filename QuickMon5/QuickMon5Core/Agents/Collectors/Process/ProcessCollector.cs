﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("Process Collector"), Category("General")]
    public class ProcessCollector : CollectorAgentBase
    {
        public ProcessCollector()
        {
            AgentConfig = new ProcessCollectorConfig();
        }
    }
    public class ProcessCollectorConfig : ICollectorConfig
    {
        public ProcessCollectorConfig()
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
            XmlDocument config = new XmlDocument();
            if (configurationString == null || configurationString.Length == 0)
            {
                config.LoadXml(GetDefaultOrEmptyXml());
            }
            else
            {
                config.LoadXml(configurationString);
            }
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            
            foreach (XmlElement carvceEntryNode in root.SelectNodes("processes/process"))
            {                
                ProcessCollectorConfigEntry processEntry = new ProcessCollectorConfigEntry();

                processEntry.Name = carvceEntryNode.ReadXmlElementAttr("name", "");
                processEntry.ProcessFilterType = (ProcessCollectorFilterType)carvceEntryNode.ReadXmlElementAttr("filterType", 0);
                processEntry.ProcessFilter = carvceEntryNode.ReadXmlElementAttr("filter", "");

                processEntry.ProcessCollectorTestType = (ProcessCollectorTestType)carvceEntryNode.ReadXmlElementAttr("testType", 0);
                //processEntry.InstanceCount = carvceEntryNode.ReadXmlElementAttr("instanceCount", 1);
                processEntry.MinimumRunningInstanceCount = carvceEntryNode.ReadXmlElementAttr("minInstances", 1);
                processEntry.MaximumRunningInstanceCount = carvceEntryNode.ReadXmlElementAttr("maxInstances", 1);
                processEntry.CheckPerformance = carvceEntryNode.ReadXmlElementAttr("checkPerf", false);
                processEntry.ProcessorPercWarningTrigger = carvceEntryNode.ReadXmlElementAttr("cpuWarn", 20);
                processEntry.ProcessorPercErrorTrigger = carvceEntryNode.ReadXmlElementAttr("cpuErr", 50);
                processEntry.MemoryKBWarningTrigger = carvceEntryNode.ReadXmlElementAttr("memWarn", 51200);
                processEntry.MemoryKBErrorTrigger = carvceEntryNode.ReadXmlElementAttr("memErr", 102400);
                processEntry.ThreadCountWarningTrigger = carvceEntryNode.ReadXmlElementAttr("threadWarn", 20);
                processEntry.ThreadCountErrorTrigger = carvceEntryNode.ReadXmlElementAttr("threadErr", 100);
                Entries.Add(processEntry);
            }
        }

        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode processesNode = root.SelectSingleNode("processes");
            processesNode.InnerXml = "";

            foreach (ProcessCollectorConfigEntry processEntry in Entries)
            {
                XmlElement processNode = config.CreateElement("process");

                processNode.SetAttributeValue("name", processEntry.Name);
                processNode.SetAttributeValue("filterType", processEntry.ProcessFilterType.ToString());
                processNode.SetAttributeValue("filter", processEntry.ProcessFilter);

                processNode.SetAttributeValue("testType", processEntry.ProcessCollectorTestType.ToString());
                //processNode.SetAttributeValue("instanceCount", processEntry.InstanceCount);
                processNode.SetAttributeValue("minInstances", processEntry.MinimumRunningInstanceCount);
                processNode.SetAttributeValue("maxInstances", processEntry.MaximumRunningInstanceCount);
                processNode.SetAttributeValue("checkPerf", processEntry.CheckPerformance);
                processNode.SetAttributeValue("cpuWarn", processEntry.ProcessorPercWarningTrigger);
                processNode.SetAttributeValue("cpuErr", processEntry.ProcessorPercErrorTrigger);
                processNode.SetAttributeValue("memWarn", processEntry.MemoryKBWarningTrigger);
                processNode.SetAttributeValue("memErr", processEntry.MemoryKBErrorTrigger);
                processNode.SetAttributeValue("threadWarn", processEntry.ThreadCountWarningTrigger);
                processNode.SetAttributeValue("threadErr", processEntry.ThreadCountErrorTrigger);
                processesNode.AppendChild(processNode);
            }
            return config.OuterXml;
        }

        public string GetDefaultOrEmptyXml()
        {
            return "<config>" +
               "<processes>" +
               "<process name=\"\" filterType=\"\" filter=\"\" testType=\"\" " + 
                 "instanceCount=\"1\" minInstances=\"1\" maxInstances=\"1\" checkPerf=\"false\" />" +
               "</processes>" +
               "</config>";
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
    public class ProcessCollectorConfigEntry : ICollectorConfigEntry
    {
        public class ProcessInfo
        {
            public int ProcessId { get; set; }

            public string ProcessName { get; set; }
            public string DisplayName { get; set; }
            public string ExecutableName { get; set; }
            public string Path { get; set; }
            public string CommandLine { get; set; }
            public int ThreadCount { get; set; }
            public long WorkingSetSize { get; set; }
            public long PrivateBytes { get; set; }
            public double CPUPerc { get; set; }
            public long NetworkIOTotalPerSec { get; set; }

            public override string ToString()
            {
                return DisplayName.Length > 0 ? DisplayName : ProcessName;
            }

            public static ProcessInfo CreateFromProcess(Process p, bool includePerfStats = false)
            {
                ProcessInfo pi = new ProcessInfo()
                {
                    ProcessId = p.Id,
                    ExecutableName = "",
                    Path= "",
                    ProcessName = p.ProcessName,
                    DisplayName = p.MainWindowTitle,
                    ThreadCount = p.Threads.Count,
                    WorkingSetSize = p.WorkingSet64,
                    PrivateBytes = p.PrivateMemorySize64
                };

                //CPU
                DateTime lastTime = DateTime.Now;
                TimeSpan lastTotalProcessorTime = p.TotalProcessorTime;

                try
                {
                    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Name,CommandLine,ExecutablePath,ReadTransferCount,WriteTransferCount FROM Win32_Process WHERE ProcessId = " + p.Id))
                    {
                        long readTransferCount1 = 0;
                        long writeTransferCount1 = 0;
                        long readTransferCount2 = 0;
                        long writeTransferCount2 = 0;
                        DateTime firstTm = DateTime.Now;
                        using (ManagementObjectCollection objects = searcher.Get())
                        {
                            pi.ExecutableName = objects.Cast<ManagementBaseObject>().SingleOrDefault()?["Name"]?.ToString();
                            pi.CommandLine = objects.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"]?.ToString();
                            pi.Path = objects.Cast<ManagementBaseObject>().SingleOrDefault()?["ExecutablePath"]?.ToString();
                            if (includePerfStats)
                            {
                                readTransferCount1 = long.Parse(objects.Cast<ManagementBaseObject>().SingleOrDefault()?["ReadTransferCount"]?.ToString());
                                writeTransferCount1 = long.Parse(objects.Cast<ManagementBaseObject>().SingleOrDefault()?["WriteTransferCount"]?.ToString());
                            }
                        }
                        if (includePerfStats)
                        {
                            System.Threading.Thread.Sleep(100);
                            DateTime secondTm = DateTime.Now;
                            using (ManagementObjectCollection objects = searcher.Get())
                            {
                                readTransferCount2 = long.Parse(objects.Cast<ManagementBaseObject>().SingleOrDefault()?["ReadTransferCount"]?.ToString());
                                writeTransferCount2 = long.Parse(objects.Cast<ManagementBaseObject>().SingleOrDefault()?["WriteTransferCount"]?.ToString());
                            }
                            pi.NetworkIOTotalPerSec = Convert.ToInt64(((readTransferCount2 - readTransferCount1) + (writeTransferCount2 - writeTransferCount1)) / (secondTm.Subtract(firstTm).TotalSeconds));
                        }
                    }
                }
                catch { }
                try
                {
                    if ((pi.ExecutableName == "" || pi.Path == "") && p.MainModule != null)
                    {
                        pi.Path = p.MainModule.FileName;
                        pi.ExecutableName = p.MainModule.ModuleName;
                    }
                }
                catch { }

                if (includePerfStats)
                {
                    DateTime curTime = DateTime.Now;
                    p.Refresh();
                    TimeSpan curTotalProcessorTime = p.TotalProcessorTime;
                    pi.CPUPerc = 100.0 * (curTotalProcessorTime.TotalMilliseconds - lastTotalProcessorTime.TotalMilliseconds) / curTime.Subtract(lastTime).TotalMilliseconds / Convert.ToDouble(Environment.ProcessorCount);
                }
                return pi;
            }
        }

        #region ICollectorConfigEntry Members
        public MonitorState GetCurrentState()
        {
            List<ProcessInfo> processes = null;
            CollectorState agentState = CollectorState.NotAvailable;
            StringBuilder sbRawDetails = new StringBuilder();
            try
            {
                processes = GetValue();
                agentState = GetStateFromValue(processes);

                if (processes == null || processes.Count == 0)
                {
                    sbRawDetails.Append("No process found!");
                }
                else
                {
                    foreach (ProcessInfo p in processes)
                    {
                        sbRawDetails.Append($"{p}");
                        if (CheckPerformance)
                        {
                            sbRawDetails.Append($"mId:{p.ProcessId},CPU:{p.CPUPerc.ToString("0.00")},Mem:{(p.PrivateBytes / 1024).ToString("0.00")}KB");
                        }
                        sbRawDetails.AppendLine();
                    }
                }
            }
            catch (Exception ex)
            {
                agentState = CollectorState.Error;
                sbRawDetails.AppendLine(ex.Message);
            }

            MonitorState currentState = new MonitorState()
            {
                ForAgent = Description,
                State = agentState,
                CurrentValue = processes != null ? processes.Count.ToString() : "No",
                CurrentValueUnit = "process(es)",
                RawDetails = sbRawDetails.ToString()
            };

            return currentState;
        }        

        public string Description
        {
            get
            {
                return Name;
            }
        }
        public string TriggerSummary
        {
            get
            {
                string output = "";
                switch (ProcessFilterType)
                {
                    case ProcessCollectorFilterType.ProcessName:
                        output = "Name:";
                        break;
                    case ProcessCollectorFilterType.ExecutableName:
                        output = "Exe:";
                        break;
                    case ProcessCollectorFilterType.DisplayName:
                        output = "Display:";
                        break;
                    case ProcessCollectorFilterType.FullPath:
                        output = "Path:";
                        break;
                    case ProcessCollectorFilterType.StartUpCommandLine:
                        output = "CMD:";
                        break;
                    default:
                        break;
                }
                output += ProcessFilter;
                if (ProcessCollectorTestType == ProcessCollectorTestType.ProcessInstanceRunning)
                    output += " : IsRunning";
                else if (ProcessCollectorTestType == ProcessCollectorTestType.ProcessInstanceNotRunning)
                    output += " : NotRunning";
                else 
                    output += " : Count";
                if (CheckPerformance)
                    output += " (Incl Perf)";
                return output;
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        public object CurrentAgentValue { get; set; }
        public bool PrimaryUIValue { get; set; }
        #endregion

        #region Properties
        public string Name { get; set; }
        public ProcessCollectorFilterType ProcessFilterType { get; set; }
        public string ProcessFilter { get; set; }

        //State triggers
        #region State triggers
        public ProcessCollectorTestType ProcessCollectorTestType { get; set; }
        //[DefaultValue(1)]
        //public int InstanceCount { get; set; }
        [DefaultValue(1)]
        public int MinimumRunningInstanceCount { get; set; }
        [DefaultValue(1)]
        public int MaximumRunningInstanceCount { get; set; }
        public bool CheckPerformance { get; set; }
        [DefaultValue(20)]
        public int ProcessorPercWarningTrigger { get; set; }
        [DefaultValue(50)]
        public int ProcessorPercErrorTrigger { get; set; }
        [DefaultValue(51200)]
        public long MemoryKBWarningTrigger { get; set; }
        [DefaultValue(102400)]
        public long MemoryKBErrorTrigger { get; set; }
        [DefaultValue(20)]
        public int ThreadCountWarningTrigger { get; set; }
        [DefaultValue(100)]
        public int ThreadCountErrorTrigger { get; set; } 
        #endregion
        #endregion

        #region Public methods        
        public List<ProcessInfo> GetValue()
        {
            List<ProcessInfo> procesInfos = new List<ProcessInfo>();
            List<Process> processes = new List<Process>();
            try
            {
                switch (ProcessFilterType)
                {
                    case ProcessCollectorFilterType.ProcessName:
                        processes.AddRange(Process.GetProcessesByName(ProcessFilter));
                        break;
                    case ProcessCollectorFilterType.ExecutableName:
                        processes.AddRange((from p in Process.GetProcesses()
                                            where p.MainModule != null && p.MainModule.ModuleName.ToLower() == ProcessFilter.ToLower()
                                            select p));
                        break;
                    case ProcessCollectorFilterType.DisplayName:
                        processes.AddRange((from p in Process.GetProcesses()
                                            where p.MainWindowTitle.ToLower() == ProcessFilter.ToLower()
                                            select p));
                        break;
                    case ProcessCollectorFilterType.FullPath:
                        processes.AddRange((from p in Process.GetProcesses()
                                            where p.MainModule != null && p.MainModule.FileName.ToLower() == ProcessFilter.ToLower()
                                            select p));
                        break;
                    case ProcessCollectorFilterType.StartUpCommandLine:
                        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT ProcessId,CommandLine FROM Win32_Process WHERE CommandLine like '%{ProcessFilter}%'"))
                        {
                            using (ManagementObjectCollection results = searcher.Get())
                            {
                                int nItems = results.Count;
                                if (nItems > 0)
                                {
                                    foreach (ManagementObject objServiceInstance in results)
                                    {
                                        object val = objServiceInstance.Properties["ProcessId"].Value;
                                        try
                                        {
                                            //int processId = 0;
                                            if (int.TryParse(val.ToString(), out int processId))
                                            {
                                                processes.Add(Process.GetProcessById(processId));
                                            }
                                        }
                                        catch { }
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {

            }

            if (processes.Count > 0)
            {
                foreach(Process process in processes)
                {
                    procesInfos.Add(ProcessInfo.CreateFromProcess(process, CheckPerformance));                    
                }
            }

            return procesInfos;
        }
        public CollectorState GetStateFromValue(List<ProcessInfo> processes)
        {
            CollectorState collectorState = CollectorState.NotAvailable;

            if (ProcessCollectorTestType == ProcessCollectorTestType.ProcessInstanceNotRunning)
            {
                if (processes == null || processes.Count == 0)
                    collectorState = CollectorState.Good;
                else if (processes.Count > 0)
                    collectorState = CollectorState.Error;
            }
            else if (ProcessCollectorTestType == ProcessCollectorTestType.ProcessInstanceRunning)
            {
                if (processes == null || processes.Count == 0)
                    collectorState = CollectorState.Error;
                else if (processes.Count > 0)
                    collectorState = CollectorState.Good;
            }
            //else if (ProcessCollectorTestType == ProcessCollectorTestType.ProcessInstanceFixedCount)
            //{
            //    if (processes == null || processes.Count != InstanceCount)
            //        collectorState = CollectorState.Error;
            //    else 
            //        collectorState = CollectorState.Good;
            //}
            else if (ProcessCollectorTestType == ProcessCollectorTestType.ProcessInstanceMinMaxCount)
            {
                if (processes == null)
                    collectorState = CollectorState.Error;
                else if (processes.Count < MinimumRunningInstanceCount || processes.Count > MaximumRunningInstanceCount)
                    collectorState = CollectorState.Good;
                else
                    collectorState = CollectorState.Error;
            }
            if (CheckPerformance && collectorState != CollectorState.Error && processes.Count > 0)
            {
                foreach(ProcessInfo p in processes)
                {
                    if (p.CPUPerc > ProcessorPercWarningTrigger)
                        collectorState = CollectorState.Warning;
                    else if (p.CPUPerc > ProcessorPercErrorTrigger)
                        collectorState = CollectorState.Warning;
                    else if ((p.PrivateBytes * 1024) > MemoryKBWarningTrigger)
                        collectorState = CollectorState.Warning;
                    else if ((p.PrivateBytes * 1024) > MemoryKBErrorTrigger)
                        collectorState = CollectorState.Error;
                    else if (p.ThreadCount >= ThreadCountWarningTrigger)
                        collectorState = CollectorState.Warning;
                    else if (p.ThreadCount >= ThreadCountErrorTrigger)
                        collectorState = CollectorState.Error;
                    if (collectorState == CollectorState.Error)
                        break;
                }
            }

            return collectorState;
        }
        #endregion
    }
    public enum ProcessCollectorTestType
    {
        ProcessInstanceRunning,
        ProcessInstanceNotRunning,
        ProcessInstanceMinMaxCount,
    }
    public enum ProcessCollectorFilterType
    {
        ProcessName,
        ExecutableName,
        DisplayName,
        FullPath,
        StartUpCommandLine
    }
}
