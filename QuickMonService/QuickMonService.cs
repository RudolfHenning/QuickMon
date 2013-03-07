using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace QuickMon
{
    public partial class QuickMonService : ServiceBase
    {
        public QuickMonService()
        {
            InitializeComponent();
        }

        private List<MonitorPack> packs = new List<MonitorPack>();
        private string serviceEventSource = "QuickMon Service";
        private int concurrencyLevel = 5;
        #region Performance Counter Vars
        private PerformanceCounter monitorPacksLoaded = null;
        private PerformanceCounter collectionExecutionTimePerSec = null;
        #endregion

        #region Service events
        protected override void OnStart(string[] args)
        {
            #region Provide way to attach debugger by Waiting for specified time
#if DEBUG
            //The following code is simply to ease attaching the debugger to the service to debug the startup routine
            DateTime startTime = DateTime.Now;
            while ((!Debugger.IsAttached) && ((TimeSpan)DateTime.Now.Subtract(startTime)).TotalSeconds < 20)  // Waiting until debugger is attached
            {
                RequestAdditionalTime(1000);  // Prevents the service from timeout
                Thread.Sleep(1000);           // Gives you time to attach the debugger   
            }
            // increase as needed to prevent timeouts
            RequestAdditionalTime(5000);     // for Debugging the OnStart method,     
#endif
            #endregion

            InitializeGlobalPerformanceCounters();
            concurrencyLevel = Properties.Settings.Default.ParralelThreads;
            int monitorPacksLoaded = 0;
            if (Properties.Settings.Default.MonitorPackPaths != null && Properties.Settings.Default.MonitorPackPaths.Count > 0)
            {
                foreach (string monitorPackPath in Properties.Settings.Default.MonitorPackPaths)
                {
                    if (System.IO.File.Exists(monitorPackPath))
                    {
                        AddAndStartMonitorPack(monitorPackPath);
                        monitorPacksLoaded++;
                    }
                }
            }
            if (monitorPacksLoaded == 0)
            {
                throw new Exception("No MonitorPack specified! Please edit 'QuickMonService.exe.config' and add an entry under 'MonitorPackPaths'");
            }

            EventLog.WriteEntry(serviceEventSource,
                string.Format("Started QuickMon monitoring and alerting service with '{0}' monitor pack(s)\r\nService version: {1}\r\nShared components version: {2}\r\nConcurrency level: {3}",
                    packs.Count,
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                    System.Reflection.Assembly.GetAssembly(typeof(MonitorPack)).GetName().Version.ToString(),
                    concurrencyLevel
                    ),
                EventLogEntryType.Information, 0);
        }
        protected override void OnStop()
        {
            foreach (MonitorPack monitorPack in packs)
                monitorPack.IsPolling = false;
            ClosePerformanceCounters();
        }
        protected override void OnPause()
        {
            foreach (MonitorPack monitorPack in packs)
                monitorPack.IsPolling = false;
            base.OnPause();
        }
        protected override void OnContinue()
        {
            foreach (MonitorPack monitorPack in packs)
                monitorPack.StartPolling();
            base.OnContinue();
        } 
        #endregion

        #region Private methods
        private void AddAndStartMonitorPack(string monitorPackPath)
        {
            try
            {
                StringBuilder sbNotifiers = new StringBuilder();
                MonitorPack monitorPack = new MonitorPack();
                EventLog.WriteEntry(serviceEventSource, string.Format("Starting QuickMon MonitorPack '{0}'", monitorPackPath), EventLogEntryType.Information, 0);
                monitorPack.Load(monitorPackPath);
                if (monitorPack.Notifiers != null && monitorPack.Notifiers.Count > 0)
                {
                    foreach (var notifier in monitorPack.Notifiers)
                        sbNotifiers.AppendLine("\t" + notifier.Name);
                }
                EventLog.WriteEntry(serviceEventSource, string.Format("MonitorPack '{0}' has the following notifiers\r\n{1}", monitorPack.Name, sbNotifiers.ToString()), EventLogEntryType.Information, 0);
                monitorPack.RaiseNotifierError += new RaiseNotifierErrorDelegare(monitorPack_RaiseNotifierError);
                monitorPack.RaiseCollectorError += new RaiseCollectorErrorDelegare(monitorPack_RaiseCollectorError);
                monitorPack.CollectorExecutionTimeEvent += new CollectorExecutionTimeDelegate(monitorPack_CollectorExecutionTimeEvent);
                monitorPack.PollingFreq = Properties.Settings.Default.PollingFreqSec * 1000;
                monitorPack.ConcurrencyLevel = concurrencyLevel;
                packs.Add(monitorPack);
                monitorPack.StartPolling();
                PCSetMonitorPacksLoaded(packs.Count);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(serviceEventSource, string.Format("Error loading/starting MonitorPack '{0}'\r\n{1}", monitorPackPath, ex.Message), EventLogEntryType.Error, 11);
            }
        }
        #endregion

        #region Monitor pack events
        private void monitorPack_RaiseCollectorError(CollectorEntry collector, string errorMessage)
        {
            EventLog.WriteEntry(serviceEventSource, string.Format("Collector error\r\n" +
                "Collector name: {0}\r\n" +
                "Last details: {1}\r\n" +
                "Error details: {2}", collector.Name, collector.LastMonitorDetails, errorMessage), EventLogEntryType.Error, 2);
        }
        private void monitorPack_RaiseNotifierError(NotifierEntry notifier, string errorMessage)
        {
            EventLog.WriteEntry(serviceEventSource, string.Format("There was a problem recording an alert with notifier {0}\r\n{1}", notifier.Name, errorMessage), EventLogEntryType.Error, 1);
        }
        private void monitorPack_CollectorExecutionTimeEvent(CollectorEntry collector, long msTime)
        {
            PCRaiseCollectorExecutionTime(msTime);
        } 
        #endregion

        #region Performance counters
        private void InitializeGlobalPerformanceCounters()
        {
            try
            {
                CounterCreationData[] quickMonCreationData = new CounterCreationData[]
                    {
                        new CounterCreationData("Monitor Packs Loaded", "Monitor Packs Loaded", PerformanceCounterType.NumberOfItems32),
                        new CounterCreationData("Collector execution time/Sec", "Collector executiontime per second", PerformanceCounterType.RateOfCountsPerSecond32)
                    };

                if (PerformanceCounterCategory.Exists(serviceEventSource))
                {
                    PerformanceCounterCategory pcC = new PerformanceCounterCategory(serviceEventSource);
                    if (pcC.GetCounters().Length != quickMonCreationData.Length)
                    {
                        PerformanceCounterCategory.Delete(serviceEventSource);
                    }
                }

                if (!PerformanceCounterCategory.Exists(serviceEventSource))
                {
                    PerformanceCounterCategory.Create(serviceEventSource, serviceEventSource, PerformanceCounterCategoryType.SingleInstance, new CounterCreationDataCollection(quickMonCreationData));
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(serviceEventSource, string.Format("Create global performance counters category error!: {0}", ex.Message), EventLogEntryType.Error,10);
            }
            try
            {
                monitorPacksLoaded = InitializePerfCounterInstance(serviceEventSource, "Monitor Packs Loaded");
                collectionExecutionTimePerSec = InitializePerfCounterInstance(serviceEventSource, "Collector execution time/Sec");
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(serviceEventSource, string.Format("Initialize global performance counters error!: {0}", ex.Message),  EventLogEntryType.Error, 10);
            }
        }
        public void ClosePerformanceCounters()
        {
            PCSetMonitorPacksLoaded(0);
            SetCounterValue(collectionExecutionTimePerSec, 0, "Collector execution time/Sec");
        }
        private PerformanceCounter InitializePerfCounterInstance(string categoryName, string counterName)
        {
            PerformanceCounter counter = new PerformanceCounter(categoryName, counterName, false);
            counter.BeginInit();
            counter.RawValue = 0;
            counter.EndInit();
            return counter;
        }
        private void SetCounterValue(PerformanceCounter counter, long value, string description)
        {
            try
            {
                if (counter == null)
                {
                    EventLog.WriteEntry(serviceEventSource, "Performance counter not set up or installed! : " + description, EventLogEntryType.Warning, 11);
                }
                else
                {
                    counter.RawValue = value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(serviceEventSource, string.Format("Increment performance counter error! : {0}\r\n{1}", description, ex.ToString()), EventLogEntryType.Error, 11);
            }
        }
        private void IncrementCounter(PerformanceCounter counter, string description, long incrementBy = 1)
        {
            try
            {
                if (counter == null)
                {
                    EventLog.WriteEntry(serviceEventSource, "Performance counter not set up or installed! : " + description, EventLogEntryType.Warning, 11);
                }
                else
                {
                    counter.IncrementBy(incrementBy);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(serviceEventSource, string.Format("Increment performance counter error! : {0}\r\n{1}", description, ex.ToString()), EventLogEntryType.Error, 11);
            }
        }

        private void PCSetMonitorPacksLoaded(long count)
        {
            SetCounterValue(monitorPacksLoaded, count, "Monitor Packs Loaded");
        }
        private void PCRaiseCollectorExecutionTime(long time)
        {
            IncrementCounter(collectionExecutionTimePerSec, "Collector successful states per second", time);
        }
        #endregion
    }
}
