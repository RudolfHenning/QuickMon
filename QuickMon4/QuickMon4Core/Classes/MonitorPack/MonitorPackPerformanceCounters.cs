using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public partial class MonitorPack
    {
        private string quickMonPCCategory = "QuickMon 4";

        #region Performance counters
        #region Performance Counter Vars
        private PerformanceCounter collectorErrorStatePerSec = null;
        private PerformanceCounter collectorWarningStatePerSec = null;
        private PerformanceCounter collectorInfoStatePerSec = null;
        private PerformanceCounter notifierAlertSendPerSec = null;
        private PerformanceCounter collectorsQueriedPerSecond = null;
        private PerformanceCounter notifiersCalledPerSecond = null;
        private PerformanceCounter collectorsQueryTime = null;
        private PerformanceCounter notifiersSendTime = null;
        #endregion
        private void InitializeGlobalPerformanceCounters()
        {
            try
            {
                CounterCreationData[] quickMonCreationData = new CounterCreationData[]
					{
						new CounterCreationData("Collector success states/Sec", "Collector successful states per second", PerformanceCounterType.RateOfCountsPerSecond32),
						new CounterCreationData("Collector warning states/Sec", "Collector warning states per second", PerformanceCounterType.RateOfCountsPerSecond32),
						new CounterCreationData("Collector error states/Sec", "Collector error states per second", PerformanceCounterType.RateOfCountsPerSecond32),
						new CounterCreationData("Notifier alerts send/Sec", "Notifier alerts send per second", PerformanceCounterType.RateOfCountsPerSecond32),
						new CounterCreationData("Collectors queried/Sec", "Number of Collectors queried per second", PerformanceCounterType.RateOfCountsPerSecond32),
						new CounterCreationData("Notifiers called/Sec", "Number of Notifiers called per second", PerformanceCounterType.RateOfCountsPerSecond32),
						new CounterCreationData("Collectors query time", "Collector total query time (ms)", PerformanceCounterType.NumberOfItems32),
						new CounterCreationData("Notifiers send time", "Notifiers total send time (ms)", PerformanceCounterType.NumberOfItems32)
					};

                if (PerformanceCounterCategory.Exists(quickMonPCCategory))
                {
                    PerformanceCounterCategory pcC = new PerformanceCounterCategory(quickMonPCCategory);
                    if (pcC.GetCounters().Length != quickMonCreationData.Length)
                    {
                        PerformanceCounterCategory.Delete(quickMonPCCategory);
                    }
                }

                if (!PerformanceCounterCategory.Exists(quickMonPCCategory))
                {
                    PerformanceCounterCategory.Create(quickMonPCCategory, "QuickMon General Counters", PerformanceCounterCategoryType.SingleInstance, new CounterCreationDataCollection(quickMonCreationData));
                }
                try
                {
                    collectorErrorStatePerSec = InitializePerfCounterInstance(quickMonPCCategory, "Collector error states/Sec");
                    collectorWarningStatePerSec = InitializePerfCounterInstance(quickMonPCCategory, "Collector warning states/Sec");
                    collectorInfoStatePerSec = InitializePerfCounterInstance(quickMonPCCategory, "Collector success states/Sec");
                    notifierAlertSendPerSec = InitializePerfCounterInstance(quickMonPCCategory, "Notifier alerts send/Sec");
                    collectorsQueriedPerSecond = InitializePerfCounterInstance(quickMonPCCategory, "Collectors queried/Sec");
                    notifiersCalledPerSecond = InitializePerfCounterInstance(quickMonPCCategory, "Notifiers called/Sec");
                    collectorsQueryTime = InitializePerfCounterInstance(quickMonPCCategory, "Collectors query time");
                    notifiersSendTime = InitializePerfCounterInstance(quickMonPCCategory, "Notifiers send time");
                }
                catch (Exception ex)
                {
                    RaiseRaiseMonitorPackError(string.Format("Initialize global performance counters error!: {0}", ex.Message));
                }
            }
            catch (Exception ex)
            {
                RaiseRaiseMonitorPackError(string.Format("Create global performance counters category error!: {0}", ex.Message));
            }
        }
        public void ClosePerformanceCounters()
        {
            PCSetCollectorsQueryTime(0);
        }
        private PerformanceCounter InitializePerfCounterInstance(string categoryName, string counterName)
        {
            PerformanceCounter counter = new PerformanceCounter(categoryName, counterName, false);
            counter.BeginInit();
            counter.RawValue = 0;
            counter.EndInit();
            return counter;
        }
        private PerformanceCounter GetPerfCounterInstance(string categoryName, string counterName)
        {
            PerformanceCounter counter = new PerformanceCounter(categoryName, counterName, false);
            return counter;
        }
        private void PCRaiseCollectorSuccessState()
        {
            IncrementCounter(collectorInfoStatePerSec, "Collector successful states per second");
        }
        private void PCRaiseCollectorWarningState()
        {
            IncrementCounter(collectorWarningStatePerSec, "Collector warning states per second");
        }
        private void PCRaiseCollectorErrorState()
        {
            IncrementCounter(collectorErrorStatePerSec, "Collector error states per second");
        }
        private void PCRaiseNotifierAlertSend()
        {
            IncrementCounter(notifierAlertSendPerSec, "Notifier alerts send per second");
        }
        private void PCRaiseCollectorsQueried()
        {
            IncrementCounter(collectorsQueriedPerSecond, "Collectors queried per second");
        }
        private void PCRaiseNotifiersCalled()
        {
            IncrementCounter(notifiersCalledPerSecond, "Notifiers called per second");
        }
        private void PCSetCollectorsQueryTime(long time)
        {
            SetCounterValue(collectorsQueryTime, time, "Collector total query time (ms)");
        }
        private void PCSetNotifiersSendTime(long time)
        {
            SetCounterValue(notifiersSendTime, time, "Notifiers total send time (ms)");
        }
        private void SetCounterValue(PerformanceCounter counter, long value, string description)
        {
            try
            {
                if (counter == null)
                {
                    RaiseRaiseMonitorPackError("Performance counter not set up or installed! : " + description);
                }
                else
                {
                    counter.RawValue = value;
                }
            }
            catch (Exception ex)
            {
                RaiseRaiseMonitorPackError(string.Format("Increment performance counter error! : {0}\r\n{1}", description, ex.ToString()));
            }
        }
        private void IncrementCounter(PerformanceCounter counter, string description)
        {
            try
            {
                if (counter == null)
                {
                    RaiseRaiseMonitorPackError("Performance counter not set up or installed! : " + description);
                }
                else
                {
                    counter.Increment();
                }
            }
            catch (Exception ex)
            {
                RaiseRaiseMonitorPackError(string.Format("Increment performance counter error! : {0}\r\n{1}", description, ex.ToString()));
            }
        }
        private void DecrementCounter(PerformanceCounter counter, string description)
        {
            try
            {
                if (counter == null)
                {
                    RaiseRaiseMonitorPackError("Performance counter not set up or installed! : " + description);
                }
                else
                {
                    if (counter.RawValue > 0)
                        counter.Decrement();
                }
            }
            catch (Exception ex)
            {
                RaiseRaiseMonitorPackError(string.Format("Increment performance counter error! : {0}\r\n{1}", description, ex.ToString()));
            }
        }
        #endregion
    }
}
