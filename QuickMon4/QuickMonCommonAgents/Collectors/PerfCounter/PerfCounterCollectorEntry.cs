using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class PerfCounterCollectorEntry : ICollectorConfigEntry
    {
        public PerfCounterCollectorEntry() { MultiSampleWaitMS = 100; }

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
        #endregion

        public void InitializePerfCounter()
        {
            pc = new PerformanceCounter(Category, Counter, Instance, Computer);
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
                    for(int i = 0; i < NumberOfSamplesPerRefresh; i++)
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
            return value;
        }
        public CollectorState GetState(float value)
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
                    tmp.Instance = arr[3]; //for when there is no instance (like Category 'Memory')
                else
                    tmp.Instance = "";
                return tmp;
            }
            else
                return null;
        }
    }
}
