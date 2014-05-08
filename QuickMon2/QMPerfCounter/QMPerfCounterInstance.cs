using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace QuickMon
{
    public class QMPerfCounterInstance
    {
        public QMPerfCounterInstance() { }

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

            //pcList = new List<PerformanceCounter>();
            //if (Instance != "*")
            //{
            //    pcList.Add(new PerformanceCounter(Category, Counter, Instance, Computer));
            //}
            //else
            //{
            //    PerformanceCounterCategory pcCat = new PerformanceCounterCategory(Category, Computer);
            //    if (pcCat.CategoryType == PerformanceCounterCategoryType.MultiInstance)
            //    {
            //        string[] instances = pcCat.GetInstanceNames();
            //        foreach (string instance in instances)
            //        {
            //            pcList.Add(new PerformanceCounter(Category, Counter, instance, Computer));
            //        }
            //    }
            //}
            //foreach (PerformanceCounter pc in pcList)
            //{
            //    pc.NextValue();
            //}
        }
        public float GetNextValue()
        {
            float value = 0;
            try
            {
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
        public MonitorStates GetState(float value)
        {
            MonitorStates state = MonitorStates.Good;
            if (!ReturnValueInverted)
            {
                if (ErrorValue <= value)
                    state = MonitorStates.Error;
                else if (WarningValue <= value)
                    state = MonitorStates.Warning;
            }
            else
            {
                if (ErrorValue >= value)
                    state = MonitorStates.Error;
                else if (WarningValue >= value)
                    state = MonitorStates.Warning;
            }
            return state;
        }
        public override string ToString()
        {
            return string.Format("{0}\\{1}\\{2}\\{3}", Computer, Category, Counter, Instance);
        }

    }
}
