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


    }
}
