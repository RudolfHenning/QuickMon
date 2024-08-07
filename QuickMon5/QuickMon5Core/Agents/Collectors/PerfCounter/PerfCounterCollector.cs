﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("Performance Counter Collector"), Category("General")]
    public class PerfCounterCollector : CollectorAgentBase
    {
        public PerfCounterCollector()
        {
            AgentConfig = new PerfCounterCollectorConfig();
        }
    }

    public class PerfCounterCollectorConfig : ICollectorConfig
    {
        public PerfCounterCollectorConfig()
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
            foreach (XmlElement pcNode in root.SelectNodes("performanceCounters/performanceCounter"))
            {
                PerfCounterCollectorEntry entry = new PerfCounterCollectorEntry();
                entry.Computer = pcNode.ReadXmlElementAttr("computer", ".");
                entry.Category = pcNode.ReadXmlElementAttr("category", "Processor");
                entry.Counter = pcNode.ReadXmlElementAttr("counter", "% Processor Time");
                entry.Instance = pcNode.ReadXmlElementAttr("instance", "");
                entry.WarningValue = float.Parse(pcNode.ReadXmlElementAttr("warningValue", "80"));
                entry.ErrorValue = float.Parse(pcNode.ReadXmlElementAttr("errorValue", "100"));
                entry.NumberOfSamplesPerRefresh = pcNode.ReadXmlElementAttr("numberOfSamples", 1);
                entry.MultiSampleWaitMS = pcNode.ReadXmlElementAttr("multiSampleWaitMS", 100);
                entry.OutputValueUnit = pcNode.ReadXmlElementAttr("outputValueUnit", "");
                entry.PrimaryUIValue = pcNode.ReadXmlElementAttr("primaryUIValue", false);
                entry.OutputValueScaleFactor = pcNode.ReadXmlElementAttr("valueScale", 1);
                if (entry.OutputValueScaleFactor == 0)
                    entry.OutputValueScaleFactor = 1;
                entry.OutputValueScaleFactorInverse = pcNode.ReadXmlElementAttr("valueScaleInverse", false);
                entry.InstanceValueAggregationStyle = (AggregationStyle)pcNode.ReadXmlElementAttr("instanceAggrStyle", 0);

                Entries.Add(entry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode performanceCountersNode = root.SelectSingleNode("performanceCounters");
            performanceCountersNode.InnerXml = "";
            foreach (PerfCounterCollectorEntry entry in Entries)
            {
                XmlElement performanceCounterNode = config.CreateElement("performanceCounter");
                performanceCounterNode.SetAttributeValue("computer", entry.Computer);
                performanceCounterNode.SetAttributeValue("category", entry.Category);
                performanceCounterNode.SetAttributeValue("counter", entry.Counter);
                performanceCounterNode.SetAttributeValue("instance", entry.Instance);
                performanceCounterNode.SetAttributeValue("warningValue", entry.WarningValue);
                performanceCounterNode.SetAttributeValue("errorValue", entry.ErrorValue);
                performanceCounterNode.SetAttributeValue("numberOfSamples", entry.NumberOfSamplesPerRefresh);
                performanceCounterNode.SetAttributeValue("multiSampleWaitMS", entry.MultiSampleWaitMS);
                performanceCounterNode.SetAttributeValue("outputValueUnit", entry.OutputValueUnit);
                performanceCounterNode.SetAttributeValue("primaryUIValue", entry.PrimaryUIValue);
                performanceCounterNode.SetAttributeValue("valueScale", entry.OutputValueScaleFactor);
                performanceCounterNode.SetAttributeValue("valueScaleInverse", entry.OutputValueScaleFactorInverse);
                performanceCounterNode.SetAttributeValue("instanceAggrStyle", (int)entry.InstanceValueAggregationStyle);

                performanceCountersNode.AppendChild(performanceCounterNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config><performanceCounters></performanceCounters></config>";
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

    public class PerfCounterCollectorEntry : ICollectorConfigEntry
    {
        public PerfCounterCollectorEntry()
        {
            MultiSampleWaitMS = 100;
            OutputValueUnit = "";
            OutputValueScaleFactor = 1;
            OutputValueScaleFactorInverse = false;
            InstanceValueAggregationStyle = AggregationStyle.None;
        }

        #region Properties
        public string Computer { get; set; }
        public string Category { get; set; }
        public string Counter { get; set; }
        public string Instance { get; set; }
        public float WarningValue { get; set; }
        public float ErrorValue { get; set; }
        public int NumberOfSamplesPerRefresh { get; set; }
        public int MultiSampleWaitMS { get; set; }
        public string OutputValueUnit { get; set; }
        public int OutputValueScaleFactor { get; set; }
        public bool OutputValueScaleFactorInverse { get; set; }

        public AggregationStyle InstanceValueAggregationStyle { get; set; }
        #endregion

        #region ICollectorConfigEntry Members
        public string Description
        {
            get
            {
                return string.Format("{0}\\{1}\\{2}\\{3}", Computer, Category, Counter, Instance);
            }
        }
        private string RunTimeDescription
        {
            get
            {
                try
                {
                    if (pcList == null || pcList.Count == 0 || (pcList.Count > 0 && DateTime.Now.Subtract(lastInstanceRefresh).TotalSeconds > minimumInstanceNameRefreshSec)) // InstanceValueAggregationStyle != AggregationStyle.None)
                    {
                        InitializePerfCounter();
                    }
                }
                catch
                {
                    return string.Format("{0}\\{1}\\{2}\\{3}", Computer, Category, Counter, Instance);
                }

                if (pcList != null && pcList.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var perfc in pcList)
                    {
                        sb.Append(string.Format("{0}\\{1}\\{2}\\{3},", Computer, Category, Counter, perfc.InstanceName));
                    }
                    return sb.ToString().TrimEnd(',');
                }
                else
                    return string.Format("{0}\\{1}\\{2}\\{3}", Computer, Category, Counter, Instance);
            }
        }
        public string TriggerSummary
        {
            get
            {
                return string.Format("Warn: {0}, Err: {1}", WarningValue, ErrorValue);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        public object CurrentAgentValue { get; set; }
        public bool PrimaryUIValue { get; set; }
        public MonitorState GetCurrentState()
        {
            float value = 0;

            MonitorState currentState = new MonitorState()
            {
                ForAgent = RunTimeDescription
            };
            try
            {
                value = GetNextValue();
                CurrentAgentValue = value;
                //if (value > 9999)
                //    outputFormat = "F0";
                //else if (value > 99)
                //    outputFormat = "F1";

                currentState.CurrentValue = value.ToStringAuto();//.ToString(outputFormat);
                currentState.State = GetState(value);
                currentState.CurrentValueUnit = OutputValueUnit;
                if (currentState.State == CollectorState.Error)
                {
                    currentState.RawDetails = string.Format("(Trigger {0})", ErrorValue.ToStringAuto());
                }
                else if (currentState.State == CollectorState.Warning)
                {
                    currentState.RawDetails = string.Format("(Trigger {0})", WarningValue.ToStringAuto());
                }
                if (multiValues.Count > 1)
                {
                    for (int i = 0; i < multiValues.Count; i++)
                    {
                        currentState.ChildStates.Add(
                                  new MonitorState()
                                  {
                                      ForAgent = multiValues[i].Item1,
                                      ForAgentType = "PerformanceCounter",
                                      CurrentValue = multiValues[i].Item2.ToStringAuto(),
                                      CurrentValueUnit = OutputValueUnit
                    });
                    }
                }
            }
            catch (Exception ex)
            {
                currentState.State = CollectorState.Error;
                if (ex.Message.Contains("Instance") && ex.Message.Contains("does not exist in the specified Category"))
                {
                    currentState.CurrentValue = "Instance not found!";
                }
                currentState.RawDetails = ex.Message;
            }

            return currentState;
        }
        #endregion


        private List<PerformanceCounter> pcList = new List<PerformanceCounter>();
        private List<Tuple<string, float>> multiValues = new List<Tuple<string, float>>();
        private DateTime lastInstanceRefresh = DateTime.Now;
        private int minimumInstanceNameRefreshSec = 10;

        private void InitializePerfCounter()
        {
            string computername = ".";

            //If the list had previous entries do cleanup first
            try
            {
                if (pcList != null)
                {
                    foreach(PerformanceCounter p in pcList)
                    {
                        p.Close();
                        p.Dispose();                        
                    }
                    pcList.Clear();
                    pcList = null;
                }
            }
            catch { }

            pcList = new List<PerformanceCounter>();
            if (Computer != "" && Computer.ToLower() != "localhost")
                computername = Computer;

            PerformanceCounterCategory pcCat = new PerformanceCounterCategory(Category, computername);
            if (pcCat.CategoryType == PerformanceCounterCategoryType.SingleInstance)
            {
                PerformanceCounter pc = new PerformanceCounter(Category, Counter, "", computername);
                pc.NextValue();
                pcList.Add(pc);
            }
            else //if ($"{Instance}".Contains("*"))
            {
                string[] instances = pcCat.GetInstanceNames();
                foreach (string instanceNameItem in (from string s in instances
                                                     orderby s
                                                     select s))
                {
                    if (Instance == null || Instance == "" || Instance == "*" || Instance.ToLower() == instanceNameItem.ToLower() || (Instance.Contains("*") && HenIT.Data.StringCompareUtils.MatchStarWildcard(instanceNameItem, Instance)))
                    {
                        PerformanceCounter pci = new PerformanceCounter(Category, Counter, instanceNameItem, computername);
                        float tmpval = pci.NextValue();
                        pcList.Add(pci);
                    }
                }
            }
            lastInstanceRefresh = DateTime.Now;

            //if (InstanceValueAggregationStyle == AggregationStyle.None)
            //{
            //    PerformanceCounter pc = new PerformanceCounter(Category, Counter, Instance, computername);
            //    pc.NextValue();
            //    pcList.Add(pc);
            //}
            //else
            //{
            //    //PerformanceCounterCategory pcCat = new PerformanceCounterCategory(Category, computername);
            //    if (pcCat.CategoryType == PerformanceCounterCategoryType.MultiInstance)
            //    {
            //        string[] instances = pcCat.GetInstanceNames();
            //        foreach (string instanceNameItem in (from string s in instances
            //                                             orderby s
            //                                             select s))
            //        {
            //            if (Instance == null || Instance == "" || !Instance.Contains("*") || (Instance.Contains("*") && HenIT.Data.StringCompareUtils.MatchStarWildcard(instanceNameItem, Instance)))
            //            {
            //                PerformanceCounter pci = new PerformanceCounter(Category, Counter, instanceNameItem, computername);
            //                float tmpval = pci.NextValue();
            //                pcList.Add(pci);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        PerformanceCounter pc = new PerformanceCounter(Category, Counter, Instance, computername);
            //        pc.NextValue();
            //        pcList.Add(pc);
            //    }
            //}
        }
        public float GetNextValue(int retries = 3)
        {
            float value = 0;
            if (NumberOfSamplesPerRefresh == 0)
                NumberOfSamplesPerRefresh = 1;
            if (MultiSampleWaitMS == 0)
                MultiSampleWaitMS = 100;
            try
            {
                if (pcList == null || pcList.Count == 0 || (pcList.Count > 0 && DateTime.Now.Subtract( lastInstanceRefresh).TotalSeconds > minimumInstanceNameRefreshSec)) // InstanceValueAggregationStyle != AggregationStyle.None)
                {
                    InitializePerfCounter();
                }
                multiValues = new List<Tuple<string, float>>();
                if (pcList != null && pcList.Count > 0)
                {
                    List<float> values = new List<float>();
                    foreach (PerformanceCounter perf in pcList)
                    {
                        for (int i = 0; i < NumberOfSamplesPerRefresh; i++)
                        {
                            if (i > 0)
                                System.Threading.Thread.Sleep(MultiSampleWaitMS);

                            try
                            {
                                value = perf.NextValue();
                                if (value > 99.0 && perf.CounterName == "% Processor Time")
                                {
                                    System.Threading.Thread.Sleep(13);
                                    value = perf.NextValue();
                                }
                                values.Add(value);
                            }
                            catch (Exception exReadVal)
                            {
                                if (InstanceValueAggregationStyle == AggregationStyle.None || !exReadVal.Message.Contains("does not exist in the specified Category"))
                                {
                                    throw exReadVal;
                                }
                            }
                        }
                        if (perf.InstanceName != null)
                            multiValues.Add(new Tuple<string, float>(perf.InstanceName, value));
                    }
                    if (values.Count > 0)
                    {
                        if (InstanceValueAggregationStyle == AggregationStyle.None)
                        {
                            value = values.Average();
                        }
                        if (InstanceValueAggregationStyle == AggregationStyle.First)
                        {
                            value = values[0];
                        }
                        else if (InstanceValueAggregationStyle == AggregationStyle.Last)
                        {
                            value = values[values.Count - 1];
                        }
                        else if (InstanceValueAggregationStyle == AggregationStyle.Max)
                        {
                            value = values.Max();
                        }
                        else if (InstanceValueAggregationStyle == AggregationStyle.Min)
                        {
                            value = values.Min();
                        }
                        else if (InstanceValueAggregationStyle == AggregationStyle.Sum)
                        {
                            value = values.Sum();
                        }
                        else if (InstanceValueAggregationStyle == AggregationStyle.Count)
                        {
                            value = values.Count;
                        }
                        else
                        {
                            value = values.Average();
                        }
                    }
                }

                ////OLD Code
                //if (pc == null)
                //    InitializePerfCounter();
                //if (pc != null)
                //{
                //    if (NumberOfSamplesPerRefresh == 0)
                //        NumberOfSamplesPerRefresh = 1;
                //    if (MultiSampleWaitMS == 0)
                //        MultiSampleWaitMS = 100;
                //    for (int i = 0; i < NumberOfSamplesPerRefresh; i++)
                //    {
                //        if (i > 0)
                //            System.Threading.Thread.Sleep(MultiSampleWaitMS);
                //        value = pc.NextValue();
                //        if (value > 99.0 && pc.CounterName == "% Processor Time")
                //        {
                //            System.Threading.Thread.Sleep(13);
                //            value = pc.NextValue();
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine($"GetNextValue:{ex}");
                if (retries > 0)
                {
                    InitializePerfCounter();
                    System.Threading.Thread.Sleep(10);
                    value = GetNextValue(retries - 1);
                }
                else
                {
                    value = 0;
                }
            }
            if (OutputValueScaleFactor > 0)
            {
                if (!OutputValueScaleFactorInverse)
                    value = value * OutputValueScaleFactor;
                else
                    value = value / OutputValueScaleFactor;
            }
            return value;
        }
        private CollectorState GetState(float value)
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
        public PerfCounterCollectorEntry Clone()
        {
            PerfCounterCollectorEntry currentEntry = new PerfCounterCollectorEntry();
            currentEntry.Computer = Computer;
            currentEntry.Category = Category;
            currentEntry.Counter = Counter;
            currentEntry.Instance = Instance;
            currentEntry.WarningValue = WarningValue;
            currentEntry.ErrorValue = ErrorValue;
            return currentEntry;
        }
        public string PCNameWithoutComputerName
        {
            get { return string.Format("{0}\\{1}\\{2}", Category, Counter, Instance); }
        }

        public static PerfCounterCollectorEntry FromStringDefinition(string definition)
        {
            if (definition != null && definition.Length > 0 && definition.Contains('\\') && definition.Split('\\').Length >= 3)
            {
                PerfCounterCollectorEntry tmp = new PerfCounterCollectorEntry();
                string[] arr = definition.Split('\\');
                tmp.Computer = arr[0];
                tmp.Category = arr[1];
                tmp.Counter = arr[2];
                if (arr.Length > 3)
                {
                    tmp.Instance = "";
                    for (int i = 3; i < arr.Length; i++)
                    {
                        tmp.Instance += arr[i] + "\\";
                    }
                    tmp.Instance = tmp.Instance.TrimEnd('\\'); //for when there is no instance (like Category 'Memory')
                }
                else
                    tmp.Instance = "";
                return tmp;
            }
            else
                return null;
        }

        public static PerformanceCounter GetProcessCPUPercTime(int processId, string processFilter = "*", string computerName = ".")
        {
            PerformanceCounter pc = null;
            try
            {
                List<string> instanceIds = GetInstanceNamesByCategory("Process", computerName).Where(p => processFilter == "*" || p.StartsWith(processFilter)).ToList();
                foreach (string instance in instanceIds)
                {
                    pc = new PerformanceCounter("Process", "ID Process", instance, computerName);
                    float pid = pc.NextValue();
                    if (pid == processId)
                    {
                        pc = new PerformanceCounter("Process", "% Processor Time", instance, computerName);
                        pc.NextValue();
                        return pc;
                    }
                }
            }
            catch { }

            return null;
        }

        public static List<string> GetInstanceNamesByCategory(string category, string computername = ".")
        {
            List<string> list = new List<string>();
            PerformanceCounterCategory pcCat = new PerformanceCounterCategory(category, computername);
            list.AddRange(pcCat.GetInstanceNames());

            return list;
        }

    }
}
