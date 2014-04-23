using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class PerfCounterCollectorEntry : ICollectorConfigEntry
    {  
        public PerfCounterCollectorEntry() { }

        #region ICollectorConfigEntry Members
        public string Description
        {
            get { return string.Format("{0}\\{1}\\{2}\\{3}", Computer, Category, Counter, Instance); }
        }
        public string TriggerSummary
        {
            get
            {
                return string.Format("Warn: {0}, Err: {1}",  WarningValue, ErrorValue);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        #endregion

        private PerformanceCounter pc = null;

        #region Properties
        public string Computer { get; set; }
        public string Category { get; set; }
        public string Counter { get; set; }
        public string Instance { get; set; }
        public bool ReturnValueInverted { get; set; }
        public float WarningValue { get; set; }
        public float ErrorValue { get; set; } 
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
                value = pc.NextValue();

                //the next section is to overcome the 'bug' that querying the 'Processor\% Processor Time\_Total' counter in itself (first time) can lead to 100% CPU spike.
                if (value > 99.0 && pc.CounterName =="% Processor Time")
                {
                    System.Threading.Thread.Sleep(13);
                    value = pc.NextValue();

                    //if for some reason it is still 100%...
                    if (value > 99.0 && pc.CounterName == "% Processor Time")
                    {
                        System.Threading.Thread.Sleep(99);
                        value = pc.NextValue();
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
            if (!ReturnValueInverted)
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
        public override string ToString()
        {
            return string.Format("{0}\\{1}\\{2}\\{3}", Computer, Category, Counter, Instance);
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
    }
}
