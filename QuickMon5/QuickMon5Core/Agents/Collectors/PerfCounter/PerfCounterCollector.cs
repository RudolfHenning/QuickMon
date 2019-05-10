using System;
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

        //public override List<System.Data.DataTable> GetDetailDataTables()
        //{
        //    List<System.Data.DataTable> tables = new List<System.Data.DataTable>();
        //    System.Data.DataTable dt = new System.Data.DataTable();
        //    try
        //    {
        //        dt.Columns.Add(new System.Data.DataColumn("Computer", typeof(string)));
        //        dt.Columns[0].ExtendedProperties.Add("groupby", "true");
        //        dt.Columns.Add(new System.Data.DataColumn("Perf counter", typeof(string)));
        //        dt.Columns.Add(new System.Data.DataColumn("Value", typeof(float)));

        //        PerfCounterCollectorConfig currentConfig = (PerfCounterCollectorConfig)AgentConfig;
        //        foreach (PerfCounterCollectorEntry entry in currentConfig.Entries)
        //        {
        //            float value = 0;
        //            try
        //            {
        //                value = entry.GetNextValue();
        //            }
        //            catch
        //            {
        //                value = -1;
        //            }
        //            dt.Rows.Add(entry.Computer, entry.PCNameWithoutComputerName, value);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dt = new System.Data.DataTable("Exception");
        //        dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
        //        dt.Rows.Add(ex.ToString());
        //    }
        //    tables.Add(dt);
        //    return tables;
        //}
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
        }

        private PerformanceCounter pc = null;

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
        #endregion

        #region ICollectorConfigEntry Members
        public string Description
        {
            get { return string.Format("{0}\\{1}\\{2}\\{3}", Computer, Category, Counter, Instance); }
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
            string outputFormat = "F2";
            float value = 0;
            MonitorState currentState = new MonitorState()
            {
                ForAgent = Description                
            };
            try
            {
                value = GetNextValue();
                CurrentAgentValue = value;
                if (value > 9999)
                    outputFormat = "F0";
                else if (value > 99)
                    outputFormat = "F1";

                currentState.CurrentValue = value.ToString(outputFormat);
                currentState.State = GetState(value);
                currentState.CurrentValueUnit = OutputValueUnit;
                if (currentState.State == CollectorState.Error)
                {
                    currentState.RawDetails = string.Format("(Trigger {0})", ErrorValue.ToString(outputFormat));
                }
                else if (currentState.State == CollectorState.Warning)
                {
                    currentState.RawDetails = string.Format("(Trigger {0})", WarningValue.ToString(outputFormat));
                }
            }
            catch(Exception ex)
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

        public void InitializePerfCounter()
        {
            string computername = ".";
            if (Computer != "" && Computer.ToLower() != "localhost")
                computername = Computer;
            pc = new PerformanceCounter(Category, Counter, Instance, computername);
            pc.NextValue();
        }
        public float GetNextValue()
        {
            float value = 0;
            try
            {
                if (pc == null)
                    InitializePerfCounter();
                if (pc != null)
                {
                    if (NumberOfSamplesPerRefresh == 0)
                        NumberOfSamplesPerRefresh = 1;
                    if (MultiSampleWaitMS == 0)
                        MultiSampleWaitMS = 100;
                    for (int i = 0; i < NumberOfSamplesPerRefresh; i++)
                    {
                        if (i > 0)
                            System.Threading.Thread.Sleep(MultiSampleWaitMS);
                        value = pc.NextValue();
                        if (value > 99.0 && pc.CounterName == "% Processor Time")
                        {
                            System.Threading.Thread.Sleep(13);
                            value = pc.NextValue();
                        }
                    }
                }
            }
            catch
            {
                InitializePerfCounter();
                System.Threading.Thread.Sleep(10);
                value = GetNextValue();
            }
            if (OutputValueScaleFactor > 0) {
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


    }
}
