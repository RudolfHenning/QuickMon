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
        private PerformanceCounter collectorHostErrorStatesPerSec = null;
        private PerformanceCounter collectorHostWarningStatesPerSec = null;
        private PerformanceCounter collectorHostInfoStatesPerSec = null;
        private PerformanceCounter collectorHostsQueriedPerSecond = null;
        private PerformanceCounter collectorAgentsQueriedPerSecond = null;

        private PerformanceCounter notifierAlertSendPerSec = null;        
        private PerformanceCounter notifiersCalledPerSecond = null;

        private PerformanceCounter collectorHostsQueryTime = null;
        private PerformanceCounter notifierHostsSendTime = null;
        #endregion
        private void InitializeGlobalPerformanceCounters()
        {
            try
            {
                CounterCreationData[] quickMonCreationData = new CounterCreationData[]
					{
						new CounterCreationData("Collector Host Success states/Sec", "Collector Host successful states per second", PerformanceCounterType.RateOfCountsPerSecond32),
						new CounterCreationData("Collector Host Warning states/Sec", "Collector Host warning states per second", PerformanceCounterType.RateOfCountsPerSecond32),
						new CounterCreationData("Collector Host Error states/Sec",   "Collector Host error states per second", PerformanceCounterType.RateOfCountsPerSecond32),
                        new CounterCreationData("Collector Hosts queried/Sec",  "Number of Collector Hosts queried per second", PerformanceCounterType.RateOfCountsPerSecond32),
                        new CounterCreationData("Collector Agents queried/Sec", "Number of Collector Agents queried per second", PerformanceCounterType.RateOfCountsPerSecond32),

                        new CounterCreationData("Notifier Hosts called/Sec", "Number of Notifier Hosts called per second", PerformanceCounterType.RateOfCountsPerSecond32),
						new CounterCreationData("Notifier Alerts send/Sec", "Notifier alerts send per second", PerformanceCounterType.RateOfCountsPerSecond32),
						
						new CounterCreationData("Collector Hosts Query time", "Collector Hosts total query time (ms)", PerformanceCounterType.NumberOfItems32),
						new CounterCreationData("Notifiers Hosts Send time", "Notifier Hosts total send time (ms)", PerformanceCounterType.NumberOfItems32)
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
                    collectorHostErrorStatesPerSec = InitializePerfCounterInstance(quickMonPCCategory,      "Collector Host Error states/Sec");
                    collectorHostWarningStatesPerSec = InitializePerfCounterInstance(quickMonPCCategory,    "Collector Host Warning states/Sec");
                    collectorHostInfoStatesPerSec = InitializePerfCounterInstance(quickMonPCCategory,       "Collector Host Success states/Sec");                    
                    collectorHostsQueriedPerSecond = InitializePerfCounterInstance(quickMonPCCategory,      "Collector Hosts queried/Sec");
                    collectorAgentsQueriedPerSecond = InitializePerfCounterInstance(quickMonPCCategory,     "Collector Agents queried/Sec");

                    notifierAlertSendPerSec = InitializePerfCounterInstance(quickMonPCCategory,             "Notifier Alerts send/Sec");
                    notifiersCalledPerSecond = InitializePerfCounterInstance(quickMonPCCategory,            "Notifier Hosts called/Sec");

                    collectorHostsQueryTime = InitializePerfCounterInstance(quickMonPCCategory,             "Collector Hosts Query time");
                    notifierHostsSendTime = InitializePerfCounterInstance(quickMonPCCategory,               "Notifiers Hosts Send time");
                }
                catch (Exception ex)
                {
                    RaiseMonitorPackError(string.Format("Initialize global performance counters error!: {0}", ex.Message));
                }
            }
            catch (Exception ex)
            {
                RaiseMonitorPackError(string.Format("Create global performance counters category error!: {0}", ex.Message));
            }
        }
        private void ClosePerformanceCounters()
        {
            try
            {
                PCSetCollectorsQueryTime(0);
            }
            catch { }
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
            IncrementCounter(collectorHostInfoStatesPerSec, "Collector Host Successful states per second");
        }
        private void PCRaiseCollectorWarningState()
        {
            IncrementCounter(collectorHostWarningStatesPerSec, "Collector Host Warning states per second");
        }
        private void PCRaiseCollectorErrorState()
        {
            IncrementCounter(collectorHostErrorStatesPerSec, "Collector Host Error states per second");
        }
        private void PCRaiseCollectorHostsQueried()
        {
            IncrementCounter(collectorHostsQueriedPerSecond, "Collector Hosts queried per second");
        }
        private void PCRaiseCollectorAgentsQueried(int agentCount = 1)
        {
            IncrementCounter(collectorAgentsQueriedPerSecond, "Collector Agents queried per second");
        }
        private void PCRaiseNotifierAlertSend()
        {
            IncrementCounter(notifierAlertSendPerSec, "Notifier alerts send per second");
        }        
        private void PCRaiseNotifiersCalled()
        {
            IncrementCounter(notifiersCalledPerSecond, "Notifiers called per second");
        }
        private void PCSetCollectorsQueryTime(long time)
        {
            SetCounterValue(collectorHostsQueryTime, time, "Collector total query time (ms)");
        }
        private void PCSetNotifiersSendTime(long time)
        {
            SetCounterValue(notifierHostsSendTime, time, "Notifiers total send time (ms)");
        }
        private void SetCounterValue(PerformanceCounter counter, long value, string description)
        {
            try
            {
                if (counter == null)
                {
                    RaiseMonitorPackError("Performance counter not set up or installed! : " + description);
                }
                else
                {
                    counter.RawValue = value;
                }
            }
            catch (Exception ex)
            {
                RaiseMonitorPackError(string.Format("Increment performance counter error! : {0}\r\n{1}", description, ex.ToString()));
            }
        }
        private void IncrementCounter(PerformanceCounter counter, string description, long increment = 1)
        {
            try
            {
                if (counter == null)
                {
                    RaiseMonitorPackError("Performance counter not set up or installed! : " + description);
                }
                else
                {
                    if (increment == 1)
                        counter.Increment();
                    else
                        counter.IncrementBy(increment);
                }
            }
            catch (Exception ex)
            {
                RaiseMonitorPackError(string.Format("Increment performance counter error! : {0}\r\n{1}", description, ex.ToString()));
            }
        }
        private void DecrementCounter(PerformanceCounter counter, string description)
        {
            try
            {
                if (counter == null)
                {
                    RaiseMonitorPackError("Performance counter not set up or installed! : " + description);
                }
                else
                {
                    if (counter.RawValue > 0)
                        counter.Decrement();
                }
            }
            catch (Exception ex)
            {
                RaiseMonitorPackError(string.Format("Increment performance counter error! : {0}\r\n{1}", description, ex.ToString()));
            }
        }
        #endregion
    }
}
