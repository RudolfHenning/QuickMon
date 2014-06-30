using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace QuickMon
{
    #region Delegates
    public delegate void CollectorNameLoadingDelegate(string name);
    public delegate void RaiseCollectorCalledDelegate(CollectorEntry collectorEntry);
    public delegate void RaiseCurrentStateDelegate(CollectorEntry collectorEntry);
    public delegate void RaiseNotifierErrorDelegare(NotifierEntry notifier, string errorMessage);
    public delegate void RaiseCollectorErrorDelegare(CollectorEntry collector, string errorMessage);
    public delegate void RaiseMonitorPackErrorDelegate(string errorMessage);
    public delegate void StateChangedDelegate(AlertLevel alertLevel, CollectorEntry collectorEntry);
    public delegate void CollectorExecutionTimeDelegate(CollectorEntry collector, long msTime);
    public delegate void MonitorPackPathChangedDelegate(string newMonitorPackPath);
    #endregion

    public class MonitorPack
    {
        public MonitorPack()
        {
            Collectors = new List<CollectorEntry>();
            Notifiers = new List<NotifierEntry>();
            Enabled = true;
            PollingFreq = 1000;
            IsPollingEnabled = false;
            CurrentState = CollectorState.NotAvailable;
            LastGlobalState = new MonitorState() { State = CollectorState.NotAvailable };
            DefaultViewerNotifier = null;
            //RegisteredAgents = RegistrationHelper.GetAllRegisteredAgentsByDirectory(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            ConcurrencyLevel = 1;
            BusyPolling = false;
            CollectorStateHistorySize = 100;
            RunningAttended = AttendedOption.AttendedAndUnAttended;
        }

        private string quickMonPCCategory = "QuickMon 3";

        #region Events
        #region Collector Events
        public event RaiseCurrentStateDelegate CollectorCurrentStateReported;
        private void RaiseRaiseCurrentStateDelegate(CollectorEntry collector)
        {
            try
            {
                if (CollectorCurrentStateReported != null)
                {
                    CollectorCurrentStateReported(collector);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRaiseCurrentStateDelegate: {0}", ex.Message));
            }
        }
        public event CollectorNameLoadingDelegate CollecterLoading;
        private void RaiseCollecterLoading(string collectorName)
        {
            try
            {
                if (CollecterLoading != null)
                {
                    CollecterLoading(collectorName);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseCollecterLoaded: {0}", ex.Message));
            }
        }
        public event RaiseCurrentStateDelegate CollecterLoaded;
        private void RaiseCollecterLoaded(CollectorEntry collector)
        {
            try
            {
                if (CollecterLoaded != null)
                {
                    CollecterLoaded(collector);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseCollecterLoaded: {0}", ex.Message));
            }
        }
        public event StateChangedDelegate CollectorStateChanged;
        private void RaiseCollectorStateChanged(AlertLevel alertLevel, CollectorEntry collectorEntry)
        {
            try
            {
                if (CollectorStateChanged != null)
                    CollectorStateChanged(alertLevel, collectorEntry);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseStateChanged: {0}", ex.Message));
            }
        }
        public event RaiseCollectorCalledDelegate CollectorCalled;
        private void RaiseCollectorCalled(CollectorEntry collector)
        {
            try
            {
                if (CollectorCalled != null)
                {
                    CollectorCalled(collector);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseCollectorCalled: {0}", ex.Message));
            }
        }
        public event CollectorExecutionTimeDelegate CollectorExecutionTimeEvent;
        private void RaiseCollectorExecutionTime(CollectorEntry collector, long msTime)
        {
            try
            {
                if (CollectorExecutionTimeEvent != null)
                {
                    CollectorExecutionTimeEvent(collector, msTime);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseCollectorExecutionTime: {0}", ex.Message));
            }
        }
        #endregion

        #region Notifier Events

        #endregion

        #region Error messages
        public event RaiseNotifierErrorDelegare OnNotifierError;
        private void RaiseRaiseNotifierError(NotifierEntry notifier, string errorMessage)
        {
            try
            {
                if (OnNotifierError != null)
                    OnNotifierError(notifier, errorMessage);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRaiseNotifierError: {0}", ex.Message));
            }
        }
        public event RaiseCollectorErrorDelegare RaiseCollectorError;
        private void RaiseRaiseCollectorError(CollectorEntry collector, string errorMessage)
        {
            try
            {
                if (RaiseCollectorError != null)
                {
                    RaiseCollectorError(collector, errorMessage);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRaiseCollectorError: {0}", ex.Message));
            }
        }
        public event RaiseMonitorPackErrorDelegate RaiseMonitorPackError;
        private void RaiseRaiseMonitorPackError(string errorMessage)
        {
            try
            {
                if (RaiseMonitorPackError != null)
                    RaiseMonitorPackError(errorMessage);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRaiseMonitorPackError: {0}", ex.Message));
            }
        }
        #endregion

        #region Corrective script events
        public event RaiseCollectorCalledDelegate RunCollectorCorrectiveWarningScript;
        private void RaiseRunCollectorCorrectiveWarningScript(CollectorEntry collector)
        {
            try
            {
                if (RunCorrectiveScripts &&
                    RunCollectorCorrectiveWarningScript != null &&
                    collector != null &&
                    !collector.CorrectiveScriptDisabled &&
                    collector.CorrectiveScriptOnWarningPath.Length > 0)
                {
                    RunCollectorCorrectiveWarningScript(collector);
                    LogCorrectiveScriptAction(collector, false);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRunCollectorCorrectiveWarningScript: {0}", ex.Message));
            }
        }
        public event RaiseCollectorCalledDelegate RunCollectorCorrectiveErrorScript;
        private void RaiseRunCollectorCorrectiveErrorScript(CollectorEntry collector)
        {
            try
            {
                if (RunCorrectiveScripts &&
                    RunCollectorCorrectiveErrorScript != null &&
                    collector != null &&
                    !collector.CorrectiveScriptDisabled &&
                    collector.CorrectiveScriptOnErrorPath.Length > 0)
                {
                    RunCollectorCorrectiveErrorScript(collector);
                    LogCorrectiveScriptAction(collector, true);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRunCollectorCorrectiveErrorScript: {0}", ex.Message));
            }
        }
        public event RaiseCollectorCalledDelegate RunRestorationScript;
        private void RaiseRunCollectorRestorationScript(CollectorEntry collector)
        {
            try
            {
                if (RunCorrectiveScripts &&
                    RunRestorationScript != null &&
                    collector != null &&
                    !collector.CorrectiveScriptDisabled &&
                    collector.RestorationScriptPath.Length > 0)
                {
                    RunRestorationScript(collector);
                    LogRestorationScriptAction(collector);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRunCollectorCorrectiveErrorScript: {0}", ex.Message));
            }
        }
        #endregion

        #region Monitor pack general events
        public event MonitorPackPathChangedDelegate MonitorPackPathChanged;
        private void RaiseMonitorPackPathChanged(string newMonitorPackPath)
        {
            try
            {
                if (MonitorPackPathChanged != null)
                    MonitorPackPathChanged(newMonitorPackPath);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRunCollectorCorrectiveErrorScript: {0}", ex.Message));
            }
        }
        #endregion
        #endregion

        #region Properties
        #region User configurable
        public string Name { get; set; }
        public string Version { get; set; }
        public bool Enabled { get; set; }
        public bool RunCorrectiveScripts { get; set; }
        public NotifierEntry DefaultViewerNotifier { get; set; }
        public string MonitorPackPath { get; set; }
        public int ConcurrencyLevel { get; set; }
        /// <summary>
        /// Polling frequency for background operations. Measured in milliseconds. Default 1 Second
        /// </summary>
        public int PollingFreq { get; set; }
        /// <summary>
        /// Overridding polling frequency as specified in config. If 0 then PollingFreq is used.
        /// </summary>
        public int PollingFrequencyOverrideSec { get; set; }
        public bool PreloadCollectorInstances { get; set; }
        #endregion

        public string AgentLoadingErrors { get; set; }
        public List<CollectorEntry> Collectors { get; private set; }
        public List<NotifierEntry> Notifiers { get; private set; }
        public CollectorState CurrentState { get; set; }
        public MonitorState LastGlobalState { get; set; }

        #region Poling related properties
        /// <summary>
        /// Is background polling active
        /// </summary>
        public bool IsPollingEnabled { get; set; }
        public bool BusyPolling { get; private set; }
        public bool AbortPolling { get; set; }        
        #endregion

        public int CollectorStateHistorySize { get; set; }
        public AttendedOption RunningAttended { get; set; }
        #endregion

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

        #region Refreshing states
        public CollectorState RefreshStates(bool disablePollingOverrides = false)
        {
            AbortPolling = false;
            BusyPolling = true;
            CollectorState globalState = CollectorState.Good;
            ResetAllOverrides();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //First get collectors with no dependancies
            List<CollectorEntry> noDependantCollectors = (from c in Collectors
                                                          where c.ParentCollectorId.Length == 0
                                                          select c).ToList();

            //Using .Net 4 Parralel processing extensions
            //int threads = ConcurrencyLevel;
#if DEBUG
            //threads = 5;
#endif
            if (ConcurrencyLevel > 1)
            {
                ParallelOptions po = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = ConcurrencyLevel
                };
                ParallelLoopResult parResult = Parallel.ForEach(noDependantCollectors, po, collector => RefreshCollectorState(collector, disablePollingOverrides));
                if (!parResult.IsCompleted)
                {
                    SendNotifierAlert(new AlertRaised()
                    {
                        Level = AlertLevel.Error,
                        DetailLevel = DetailLevel.Summary,
                        RaisedFor = null, // "",
                        State = new MonitorState() { RawDetails = "Error querying collectors in parralel", State = CollectorState.Error }
                    });
                }
            }
            else //use old single threaded way
            {
                //Refresh states
                foreach (CollectorEntry collector in noDependantCollectors)
                {
                    RefreshCollectorState(collector, disablePollingOverrides);
                }
            }
            sw.Stop();
            PCSetCollectorsQueryTime(sw.ElapsedMilliseconds);
#if DEBUG
            Trace.WriteLine(string.Format("RefreshStates - Global time: {0}ms", sw.ElapsedMilliseconds));
#endif

            //set global state
            //All disabled
            if (Collectors.Count == Collectors.Count(c => c.CurrentState.State == CollectorState.Disabled || c.CurrentState.State == CollectorState.Folder))
                globalState = CollectorState.Disabled;
            //All NotAvailable
            else if (Collectors.Count == Collectors.Count(c => c.CurrentState.State == CollectorState.NotAvailable || c.CurrentState.State == CollectorState.Folder))
                globalState = CollectorState.NotAvailable;
            //All good
            else if (Collectors.Count == Collectors.Count(c => c.CurrentState.State == CollectorState.Good || c.CurrentState.State == CollectorState.Disabled || c.CurrentState.State == CollectorState.NotAvailable || c.CurrentState.State == CollectorState.Folder))
                globalState = CollectorState.Good;
            //Error state
            else if (Collectors.Count == Collectors.Count(c => c.CurrentState.State == CollectorState.Error || c.CurrentState.State == CollectorState.ConfigurationError || c.CurrentState.State == CollectorState.Disabled || c.CurrentState.State == CollectorState.Folder))
                globalState = CollectorState.Error;
            else
                globalState = CollectorState.Warning;

            AlertLevel globalAlertLevel = AlertLevel.Info;
            if (globalState == CollectorState.Error || globalState == CollectorState.ConfigurationError)
                globalAlertLevel = AlertLevel.Error;
            else if (globalState == CollectorState.Warning)
                globalAlertLevel = AlertLevel.Warning;

            sw.Restart();
            SendNotifierAlert(new AlertRaised()
            {
                Level = globalAlertLevel,
                DetailLevel = DetailLevel.Summary,
                RaisedFor = null,
                State = new MonitorState() { RawDetails = "GlobalState", State = CollectorState.NotAvailable }
            });
            sw.Stop();
            PCSetNotifiersSendTime(sw.ElapsedMilliseconds);
#if DEBUG
            Trace.WriteLine(string.Format("RefreshStates - Global notification time: {0}ms", sw.ElapsedMilliseconds));
#endif

            BusyPolling = false;
            CurrentState = globalState;
            return globalState;
        } 
        private void RefreshCollectorState(CollectorEntry collector, bool disablePollingOverrides)
        {
            if (!AbortPolling)
            {
                RaiseCollectorCalled(collector);
                CollectorState currentState = CollectorState.NotAvailable;
                Stopwatch sw = new Stopwatch();

                #region Getting current state
                sw.Start();
                try
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("Starting: {0}", collector.Name));

                    //for lazy load check if Collector == null and then create instance...
                    if (collector.Collector == null)
                    {
                        ApplyCollectorConfig(collector);
                    }

                    if (disablePollingOverrides)
                        currentState = collector.GetCurrentState(true).State;
                    else
                        currentState = collector.GetCurrentState().State;

                    if (currentState == CollectorState.Good ||
                        currentState == CollectorState.Warning ||
                        currentState == CollectorState.Error)
                    {
                        PCRaiseCollectorsQueried();
                    }
                }
                catch (Exception ex)
                {
                    RaiseRaiseCollectorError(collector, ex.Message);
                    currentState = CollectorState.Error;
                    if (collector.LastMonitorState == null)
                        collector.LastMonitorState = new MonitorState();
                    collector.LastMonitorState.RawDetails = ex.Message;
                    System.Diagnostics.Trace.WriteLine(string.Format("Error: {0} - {1}", collector.Name, ex.Message));
                }
                finally
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("Ending: {0}", collector.Name));
                }

                sw.Stop();
                RaiseCollectorExecutionTime(collector, sw.ElapsedMilliseconds);
                RaiseRaiseCurrentStateDelegate(collector);
#if DEBUG
                Trace.WriteLine(string.Format("RefreshCollectorState - {0}: {1}ms", collector.Name, sw.ElapsedMilliseconds));
#endif
                #endregion

                #region Raising alerts or events
                if (!collector.IsFolder)
                {
                    AlertLevel alertLevel = AlertLevel.Debug;
                    if (currentState == CollectorState.Good)
                    {
                        alertLevel = AlertLevel.Info;
                        PCRaiseCollectorSuccessState();
                    }
                    else if (currentState == CollectorState.Disabled || currentState == CollectorState.NotAvailable)
                    {
                        alertLevel = AlertLevel.Info;
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        alertLevel = AlertLevel.Warning;
                        PCRaiseCollectorWarningState();
                    }
                    else if (currentState == CollectorState.Error || currentState == CollectorState.ConfigurationError)
                    {
                        alertLevel = AlertLevel.Error;
                        PCRaiseCollectorErrorState();
                    }

                    //Check if alert should be raised now
                    if (collector.RaiseAlert())
                    {
                        //SendNotifierAlert(alertLevel, DetailLevel.Detail, collector);
                        SendNotifierAlert(new AlertRaised()
                        {
                            Level = alertLevel,
                            DetailLevel = DetailLevel.Detail,
                            RaisedFor = collector,
                            State = collector.CurrentState.Clone()
                        });
                        PCRaiseNotifierAlertSend();
                    }
                    else //otherwise raise only Debug info
                    {
                        RaiseCollectorStateChanged(AlertLevel.Debug, collector);
                        SendNotifierAlert(new AlertRaised()
                        {
                            Level = AlertLevel.Debug,
                            DetailLevel = DetailLevel.Detail,
                            RaisedFor = collector,
                            State = collector.CurrentState.Clone()
                        });
                    }
                    //Did the state changed?
                    bool stateChanged = collector.StateChanged();
                    if (stateChanged)
                    {
                        RaiseCollectorStateChanged(alertLevel, collector);
                    }

                    try
                    {
                        //run corrective script only after alert has been raised
                        if (RunCorrectiveScripts)
                        {
                            if (currentState == CollectorState.Warning &&
                                    (stateChanged || !collector.CorrectiveScriptsOnlyOnStateChange))
                                RaiseRunCollectorCorrectiveWarningScript(collector);
                            else if (currentState == CollectorState.Error &&
                                    (stateChanged || !collector.CorrectiveScriptsOnlyOnStateChange))
                                RaiseRunCollectorCorrectiveErrorScript(collector);
                            else if (stateChanged &&
                                    currentState == CollectorState.Good &&
                                    (collector.LastMonitorState.State == CollectorState.Warning || collector.LastMonitorState.State == CollectorState.Error))
                            {
                                RaiseRunCollectorRestorationScript(collector);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        RaiseRaiseCollectorError(collector, ex.Message);
                    }

                    //collector.LastMonitorState.State = currentState;
                }
                #endregion

                #region Set or check dependants
                if (currentState == CollectorState.Error)
                {
                    SetChildCollectorStates(collector, CollectorState.NotAvailable);
                }
                else if ((currentState == CollectorState.Warning && !collector.CollectOnParentWarning) || currentState == CollectorState.NotAvailable)
                {
                    SetChildCollectorStates(collector, CollectorState.NotAvailable);
                }
                else if (currentState == CollectorState.Disabled || currentState == CollectorState.ConfigurationError || (collector.IsFolder && !collector.Enabled))
                {
                    SetChildCollectorStates(collector, CollectorState.Disabled);
                }
                else
                {
                    try
                    {
                        //if ForceRemoteExcuteOnChildCollectors is set then apply set ParentOverrideRemoteExcuteHostAddress and ParentOverrideRemoteExcutePort
                        if (collector.ForceRemoteExcuteOnChildCollectors)
                        {
                            collector.OverrideForceRemoteExcuteOnChildCollectors = true;
                            SetChildCollectorRemoteExecuteDetails(collector, collector.RemoteAgentHostAddress, collector.RemoteAgentHostPort);
                        }
                        //else if (!collector.OverrideForceRemoteExcuteOnChildCollectors)
                        //{
                        //    collector.OverrideForceRemoteExcuteOnChildCollectors = false;
                        //    SetChildCollectorRemoteExecuteDetails(collector, "", 8181);
                        //}

                        //check if polling overrides apply - if it does then apply to child collectors
                        if (collector.EnabledPollingOverride)
                        {
                            foreach (CollectorEntry childCollector in (from c in Collectors
                                                                       where c.ParentCollectorId == collector.UniqueId
                                                                       select c))
                            {
                                SetChildCollectorPollingOverrides(collector, childCollector);
                            }
                        }

                        if (ConcurrencyLevel > 1)
                        {
                            ParallelOptions po = new ParallelOptions()
                            {
                                MaxDegreeOfParallelism = ConcurrencyLevel
                            };
                            ParallelLoopResult parResult = Parallel.ForEach((from c in Collectors
                                                                             where c.ParentCollectorId == collector.UniqueId
                                                                             select c), po, childCollector => RefreshCollectorState(childCollector, disablePollingOverrides));
                            if (!parResult.IsCompleted)
                            {
                                SendNotifierAlert(new AlertRaised()
                                {
                                    Level = AlertLevel.Error,
                                    DetailLevel = DetailLevel.Summary,
                                    RaisedFor = null, //"",
                                    State = new MonitorState() { RawDetails = "Error querying collectors in parralel", State = CollectorState.Error }
                                });
                            }
                        }
                        else //use old single threaded way
                        {
                            foreach (CollectorEntry childCollector in (from c in Collectors
                                                                       where c.ParentCollectorId == collector.UniqueId
                                                                       select c))
                            {
                                RefreshCollectorState(childCollector, disablePollingOverrides);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!ex.Message.Contains("Collection was modified; enumeration operation may not execute"))
                            RaiseRaiseMonitorPackError("Internal error. Collector config was modified while in use!");
                        else
                            RaiseRaiseCollectorError(collector, ex.Message);
                    }
                }
                #endregion
            }
        }

        #region Recursively set child properties
        private void ResetAllOverrides(CollectorEntry parentCollector = null)
        {
            List<CollectorEntry> collectors = null;
            if (parentCollector == null)
                collectors = (from c in Collectors
                              where c.ParentCollectorId.Length == 0
                              select c).ToList();
            else
                collectors = (from c in Collectors
                              where c.ParentCollectorId == parentCollector.UniqueId
                              select c).ToList();
            foreach (CollectorEntry childCollector in collectors)
            {
                childCollector.StateHistorySize = CollectorStateHistorySize;
                //Remote agent host
                childCollector.OverrideForceRemoteExcuteOnChildCollectors = false;
                childCollector.OverrideRemoteAgentHost = false;
                childCollector.OverrideRemoteAgentHostAddress = "";
                childCollector.OverrideRemoteAgentHostPort = 8181;
                ResetAllOverrides(childCollector);
            }
        }
        private void SetChildCollectorPollingOverrides(CollectorEntry parentCollector, CollectorEntry collector)
        {
            if (!collector.EnabledPollingOverride)
            {
                collector.OnlyAllowUpdateOncePerXSec = parentCollector.OnlyAllowUpdateOncePerXSec;
                //to make sure child collector does not miss the poll event
                collector.LastStateUpdate = parentCollector.LastStateUpdate;
            }
            else
                if (collector.OnlyAllowUpdateOncePerXSec < parentCollector.OnlyAllowUpdateOncePerXSec)
                {
                    collector.OnlyAllowUpdateOncePerXSec = parentCollector.OnlyAllowUpdateOncePerXSec;
                    //to make sure child collector does not miss the poll event
                    collector.LastStateUpdate = parentCollector.LastStateUpdate;
                }
            collector.EnabledPollingOverride = true;

            foreach (CollectorEntry childCollector in (from c in Collectors
                                                       where c.ParentCollectorId == collector.UniqueId
                                                       select c))
            {
                SetChildCollectorPollingOverrides(collector, childCollector);
            }
        }
        private void SetChildCollectorRemoteExecuteDetails(CollectorEntry collector, string remoteAgentHostAddress, int remoteAgentHostPort)
        {
            foreach (CollectorEntry childCollector in (from c in Collectors
                                                       where c.ParentCollectorId == collector.UniqueId
                                                       select c))
            {
                childCollector.OverrideForceRemoteExcuteOnChildCollectors = collector.OverrideForceRemoteExcuteOnChildCollectors;
                childCollector.OverrideRemoteAgentHost = remoteAgentHostAddress.Length > 0;
                childCollector.OverrideRemoteAgentHostAddress = remoteAgentHostAddress;
                childCollector.OverrideRemoteAgentHostPort = remoteAgentHostPort;

                //Set grand children
                SetChildCollectorRemoteExecuteDetails(childCollector, remoteAgentHostAddress, remoteAgentHostPort);
            }
        }
        private void SetChildCollectorStates(CollectorEntry collector, CollectorState childState)
        {
            try
            {
                foreach (CollectorEntry childCollector in (from c in Collectors
                                                           where c.ParentCollectorId == collector.UniqueId
                                                           select c))
                {
                    childCollector.CurrentState.State = childState;
                    RaiseRaiseCurrentStateDelegate(childCollector);
                    SetChildCollectorStates(childCollector, childState);
                }
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("Collection was modified; enumeration operation may not execute"))
                    throw;
            }
        } 
        #endregion

        private void SendNotifierAlert(AlertRaised alertRaised)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (alertRaised != null && alertRaised.RaisedFor != null && alertRaised.RaisedFor.CurrentState != null)
            {
                alertRaised.RaisedFor.CurrentState.AlertsRaised = new List<string>();
            }
            foreach (NotifierEntry notifierEntry in (from n in Notifiers
                                                     where n.Enabled && (int)n.AlertLevel <= (int)alertRaised.Level &&
                                                        (alertRaised.DetailLevel == DetailLevel.All || alertRaised.DetailLevel == n.DetailLevel) &&
                                                        (alertRaised.RaisedFor == null || n.AlertForCollectors.Count == 0 || n.AlertForCollectors.Contains(alertRaised.RaisedFor.Name))
                                                     select n))
            {
                try
                {
                    bool allowedToRun = true;
                    if (RunningAttended != AttendedOption.AttendedAndUnAttended)
                    {
                        if (RunningAttended != notifierEntry.Notifier.AttendedRunOption && notifierEntry.Notifier.AttendedRunOption != AttendedOption.AttendedAndUnAttended)
                            allowedToRun = false;
                    }
                    if (notifierEntry.AttendedOptionOverride != AttendedOption.AttendedAndUnAttended)
                    {
                        if (notifierEntry.AttendedOptionOverride != notifierEntry.Notifier.AttendedRunOption)
                            allowedToRun = false;
                    }

                    if (allowedToRun)
                    {
                        PCRaiseNotifiersCalled();
                        notifierEntry.Notifier.RecordMessage(alertRaised);
                        if (alertRaised.RaisedFor != null && alertRaised.RaisedFor.CurrentState != null)
                        {
                            alertRaised.RaisedFor.CurrentState.AlertsRaised.Add(string.Format("{0} ({1})", notifierEntry.Name, notifierEntry.NotifierRegistrationName));
                        }
                    }
                }
                catch (Exception ex)
                {
                    RaiseRaiseNotifierError(notifierEntry, ex.ToString());
                }
            }
            if (alertRaised != null && alertRaised.RaisedFor != null && alertRaised.RaisedFor.CurrentState != null)
            {
                alertRaised.RaisedFor.UpdateLatestHistoryWithAlertDetails(alertRaised.RaisedFor.CurrentState);
            }
            sw.Stop();
            PCSetNotifiersSendTime(sw.ElapsedMilliseconds);
        }
        private void SendNotifierAlert(AlertLevel level, DetailLevel detailLevel, CollectorEntry collectorEntry, MonitorState state)
        {
            SendNotifierAlert(new AlertRaised()
            {
                Level = level,
                DetailLevel = detailLevel,
                RaisedFor = collectorEntry,
                State = state
            });
        }
        private void LogRestorationScriptAction(CollectorEntry collectorEntry)
        {
            collectorEntry.CurrentState.RawDetails += "\r\n" + string.Format("Due to an earlier alert raised on the collector '{0}' the following restoration script was executed: '{1}'",
                collectorEntry.Name, collectorEntry.RestorationScriptPath);
            SendNotifierAlert(
                collectorEntry.LastMonitorState.State == CollectorState.Warning ? AlertLevel.Warning : AlertLevel.Error,
                DetailLevel.Detail,
                collectorEntry,
                collectorEntry.CurrentState.Clone());            
        }
        private void LogCorrectiveScriptAction(CollectorEntry collectorEntry, bool error)
        {
            collectorEntry.CurrentState.RawDetails += "\r\n" + string.Format("Due to an alert raised on the collector '{0}' the following corrective script was executed: '{1}'",
                collectorEntry.Name, error ? collectorEntry.CorrectiveScriptOnErrorPath : collectorEntry.CorrectiveScriptOnWarningPath);
            SendNotifierAlert(
                        (error ? AlertLevel.Error : AlertLevel.Warning),
                        DetailLevel.Detail,
                        collectorEntry,
                        collectorEntry.CurrentState.Clone());
        }
        #endregion

        #region Async refreshing
        public void StartPolling()
        {
            IsPollingEnabled = true;
            if (PollingFrequencyOverrideSec > 0)
                PollingFreq = PollingFrequencyOverrideSec * 1000;
            ThreadPool.QueueUserWorkItem(new WaitCallback(BackgroundPolling));
        }
        private void BackgroundPolling(object o)
        {
            while (IsPollingEnabled)
            {
                try
                {
                    LastGlobalState.State = RefreshStates();
                }
                catch (Exception ex)
                {
                    RaiseRaiseMonitorPackError(ex.Message);
                }
                BackgroundWaitIsPolling(PollingFreq);
            }
            ClosePerformanceCounters();
        }
        private void BackgroundWaitIsPolling(int nextWaitInterval)
        {
            int waitTimeRemaining;
            int decrementBy = 2000;
            if (IsPollingEnabled)
            {
                try
                {
                    if ((nextWaitInterval <= decrementBy) && (nextWaitInterval > 0))
                    {
                        Thread.Sleep(nextWaitInterval);
                    }
                    else
                    {
                        waitTimeRemaining = nextWaitInterval;
                        while (IsPollingEnabled && (waitTimeRemaining > 0))
                        {
                            if (waitTimeRemaining <= decrementBy)
                            {
                                waitTimeRemaining = 0;
                            }
                            else
                            {
                                waitTimeRemaining -= decrementBy;
                            }
                            if (decrementBy > 0)
                            {
                                Thread.Sleep(decrementBy);
                            }
                        }
                    }
                }
                catch { }
            }
        }
        #endregion

        #region Sorting/Swapping
        internal void SwapCollectorEntries(CollectorEntry c1, CollectorEntry c2)
        {
            int index1 = Collectors.FindIndex(c => c.UniqueId == c1.UniqueId);
            int index2 = Collectors.FindIndex(c => c.UniqueId == c2.UniqueId);

            if (index1 < index2)
            {
                int tmp = index1;
                index1 = index2;
                index2 = tmp;
            }

            if (index1 > -1 && index2 > -1 && index1 != index2)
            {

                Collectors.RemoveAt(index1);
                Collectors.RemoveAt(index2);
                Collectors.Insert(index2, c1);
                Collectors.Insert(index1, c2);
            }
        }
        internal void SwapNotifierEntries(NotifierEntry n1, NotifierEntry n2)
        {
            int index1 = Notifiers.FindIndex(c => c.Name == n1.Name);
            int index2 = Notifiers.FindIndex(c => c.Name == n2.Name);

            if (index1 > -1 && index2 > -1 && index1 != index2)
            {
                Notifiers.RemoveAt(index1);
                Notifiers.RemoveAt(index2);
                Notifiers.Insert(index2, n1);
                Notifiers.Insert(index1, n2);
            }
        }
        #endregion

        #region GetCollectorLists
        public List<CollectorEntry> GetRootCollectors()
        {
            return (from c in Collectors
                    where c.ParentCollectorId.Length == 0
                    select c).ToList();
        }
        public List<CollectorEntry> GetChildCollectors(CollectorEntry parentCE)
        {
            return (from c in Collectors
                    where c.ParentCollectorId == parentCE.UniqueId
                    select c).ToList();
        }
        public List<CollectorEntry> GetAllChildCollectors(CollectorEntry parentCE)
        {
            List<CollectorEntry> list = new List<CollectorEntry>();
            List<CollectorEntry> listChildren = new List<CollectorEntry>();
            listChildren = GetChildCollectors(parentCE);
            foreach (CollectorEntry child in listChildren)
            {
                list.Add(child);
                list.AddRange(GetAllChildCollectors(child));
            }
            return list;
        }
        #endregion

        #region Loading and saving configuration
        public void ApplyCollectorConfig(CollectorEntry collectorEntry)
        {
            if (collectorEntry == null)
                return;
            RegisteredAgent currentRA = null;
            if (collectorEntry.IsFolder)
            {
                collectorEntry.Collector = null;
            }
            else
            {
                //first clear/release any existing references
                if (collectorEntry.Collector != null)
                    collectorEntry.Collector = null;

                currentRA = (from r in RegisteredAgentCache.Agents
                                  where r.IsCollector && r.ClassName.EndsWith("." + collectorEntry.CollectorRegistrationName)
                                  select r).FirstOrDefault();

                //if (RegisteredAgents != null)
                //    currentCollector = (from o in RegisteredAgents
                //                        where o.IsCollector && 
                //                            (o.Name == collectorEntry.CollectorRegistrationName)
                //                        select o).FirstOrDefault();
                

                if (currentRA != null)
                {
                    try
                    {
                        collectorEntry.Collector = CollectorEntry.CreateCollectorEntry(currentRA);
                        collectorEntry.Collector.SetConfigurationFromXmlString(collectorEntry.InitialConfiguration);
                        collectorEntry.CollectorRegistrationDisplayName = currentRA.DisplayName;
                    }
                    catch (Exception ex)
                    {
                        collectorEntry.LastMonitorState.State = CollectorState.ConfigurationError;
                        collectorEntry.Enabled = false;
                        collectorEntry.LastMonitorState.RawDetails = ex.Message;
                    }
                }
                else
                {
                    collectorEntry.LastMonitorState.State = CollectorState.ConfigurationError;
                    collectorEntry.Enabled = false;
                    collectorEntry.LastMonitorState.RawDetails = string.Format("Collector '{0}' cannot be loaded as the type '{1}' is not registered!", collectorEntry.Name, collectorEntry.CollectorRegistrationName);
                    RaiseRaiseMonitorPackError(string.Format("Collector '{0}' cannot be loaded as the type '{1}' is not registered!", collectorEntry.Name, collectorEntry.CollectorRegistrationName));
                }
            }
        }
        public void ApplyNotifierConfig(NotifierEntry notifierEntry)
        {
            if (notifierEntry == null)
                return;
            RegisteredAgent currentNotifier = null;
            
                //first clear/release any existing references
            if (notifierEntry.Notifier != null)
                notifierEntry.Notifier = null;


            currentNotifier = (from n in RegisteredAgentCache.Agents
                               where n.IsNotifier && n.Name == notifierEntry.NotifierRegistrationName
                               select n).FirstOrDefault();
                //if (RegisteredAgents != null)
                //    currentNotifier = (from o in RegisteredAgents
                //                        where o.IsNotifier &&
                //                            (o.Name == notifierEntry.NotifierRegistrationName)
                //                        select o).FirstOrDefault();
                if (currentNotifier != null)
                {
                    try
                    {
                        notifierEntry.Notifier = NotifierEntry.CreateNotifierEntry(currentNotifier);
                        notifierEntry.Notifier.SetConfigurationFromXmlString(notifierEntry.InitialConfiguration);
                    }
                    catch// (Exception ex)
                    {

                        notifierEntry.Enabled = false;
                        //notifierEntry.l.LastMonitorState.RawDetails = ex.Message;
                    }
                }
                else
                {
                    //notifierEntry.LastMonitorState.State = CollectorState.ConfigurationError;
                    notifierEntry.Enabled = false;
                    //notifierEntry.LastMonitorState.RawDetails = string.Format("Collector '{0}' cannot be loaded as the type '{1}' is not registered!", collectorEntry.Name, collectorEntry.CollectorRegistrationName);
                    RaiseRaiseMonitorPackError(string.Format("Notifier '{0}' cannot be loaded as the type '{1}' is not registered!", notifierEntry.Name, notifierEntry.NotifierRegistrationName));
                }
            
        }
        public void LoadXml(string xmlConfig)
        {
            Stopwatch sw = new Stopwatch();
            XmlDocument configurationXml = new XmlDocument();
            sw.Start();
            configurationXml.LoadXml(xmlConfig);
            sw.Stop();
            System.Diagnostics.Trace.WriteLine(string.Format("MonitorPack Loading XML time:{0}ms", sw.ElapsedMilliseconds));

            sw.Reset();
            sw.Start();
            XmlElement root = configurationXml.DocumentElement;
            Name = root.Attributes.GetNamedItem("name").Value;
            this.Version = root.Attributes.GetNamedItem("version").Value;
            Enabled = bool.Parse(root.Attributes.GetNamedItem("enabled").Value);
            try
            {
                CollectorStateHistorySize = int.Parse(root.ReadXmlElementAttr("collectorStateHistorySize", "1"));
            }
            catch { }
            try
            {
                PollingFrequencyOverrideSec = int.Parse(root.ReadXmlElementAttr("pollingFreqSecOverride", "0"));
            }
            catch { }

            string defaultViewerNotifierName = root.ReadXmlElementAttr("defaultViewerNotifier");
            RunCorrectiveScripts = bool.Parse(root.ReadXmlElementAttr("runCorrectiveScripts", "false"));
            foreach (XmlElement xmlCollectorEntry in root.SelectNodes("collectorEntries/collectorEntry"))
            {
                RaiseCollecterLoading(xmlCollectorEntry.ReadXmlElementAttr("name", "").Trim());
                CollectorEntry newCollectorEntry = CollectorEntry.FromConfig(xmlCollectorEntry);
                if (PreloadCollectorInstances)
                    ApplyCollectorConfig(newCollectorEntry);
                Collectors.Add(newCollectorEntry);
                RaiseCollecterLoaded(newCollectorEntry);
            }
            foreach (XmlElement xmlNotifierEntry in root.SelectNodes("notifierEntries/notifierEntry"))
            {
                NotifierEntry newNotifierEntry = NotifierEntry.FromConfig(xmlNotifierEntry);
                RegisteredAgent currentNotifier = null;
                currentNotifier = (from n in RegisteredAgentCache.Agents
                                   where n.IsNotifier && n.Name == newNotifierEntry.NotifierRegistrationName
                                   select n).FirstOrDefault();

                if (currentNotifier != null)
                {
                    try
                    {
                        newNotifierEntry.Notifier = NotifierEntry.CreateNotifierEntry(currentNotifier);
                        newNotifierEntry.Notifier.SetConfigurationFromXmlString(newNotifierEntry.InitialConfiguration);
                    }
                    catch // (Exception ex)
                    {
                        newNotifierEntry.Enabled = false;
                    }
                }
                else
                {
                    newNotifierEntry.Enabled = false;
                }
                Notifiers.Add(newNotifierEntry);
                if (newNotifierEntry.Name.ToUpper() == defaultViewerNotifierName.ToUpper())
                    DefaultViewerNotifier = newNotifierEntry;
            }
            sw.Stop();
            System.Diagnostics.Trace.WriteLine(string.Format("MonitorPack Parsing XML time:{0}ms", sw.ElapsedMilliseconds));
            InitializeGlobalPerformanceCounters();
        }
        public void Load()
        {
            if (MonitorPackPath != null && MonitorPackPath.Length > 0 && System.IO.File.Exists(MonitorPackPath))
                Load(MonitorPackPath);
        }
        /// <summary>
        /// Loading QuickMon monitor pack file
        /// </summary>
        /// <param name="configurationFile">Serialzed monitor pack file</param>
        public void Load(string configurationFile)
        {
            LoadXml(System.IO.File.ReadAllText(configurationFile, Encoding.UTF8));
            MonitorPackPath = configurationFile;
            RaiseMonitorPackPathChanged(MonitorPackPath);
        }
        public bool Save()
        {
            if (MonitorPackPath != null && MonitorPackPath.Length > 0 && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(MonitorPackPath)))
            {
                Save(MonitorPackPath);
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Saving QuickMon monitor pack file
        /// </summary>
        /// <param name="configurationFile"></param>
        public void Save(string configurationFile)
        {
            string defaultViewerNotifier = "";
            if (DefaultViewerNotifier != null)
                defaultViewerNotifier = DefaultViewerNotifier.Name;
            string outputXml = string.Format(Properties.Resources.MonitorPackXml,
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version,
                Name, Enabled, defaultViewerNotifier,
                RunCorrectiveScripts,
                CollectorStateHistorySize,
                PollingFrequencyOverrideSec,
                GetConfigForCollectors(),
                GetConfigForNotifiers());
            XmlDocument outputDoc = new XmlDocument();
            outputDoc.LoadXml(outputXml);
            outputDoc.PreserveWhitespace = false;
            outputDoc.Normalize();
            outputDoc.Save(configurationFile);

            MonitorPackPath = configurationFile;
            RaiseMonitorPackPathChanged(MonitorPackPath);            
        }

        private string GetConfigForNotifiers()
        {
            StringBuilder sb = new StringBuilder();
            foreach (NotifierEntry notifierEntry in Notifiers)
            {
                sb.AppendLine(notifierEntry.ToConfig());
            }
            return sb.ToString();
        }
        private string GetConfigForCollectors()
        {
            StringBuilder sb = new StringBuilder();
            foreach (CollectorEntry collectorEntry in Collectors)
            {
                sb.AppendLine(collectorEntry.ToConfig());
            }
            return sb.ToString();
        }
        #endregion 

        #region Global settings
        public static string GetQuickMonUserDataDirectory()
        {
            string dataDir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.DoNotVerify), "Hen IT\\QuickMon 3");
            try
            {
                if (!System.IO.Directory.Exists(dataDir))
                {
                    System.IO.Directory.CreateDirectory(dataDir);
                }
            }
            catch { }
            return dataDir;
        }
        public static string GetQuickMonUserDataTemplatesFile()
        {
            return System.IO.Path.Combine(MonitorPack.GetQuickMonUserDataDirectory(), "QuickMon3Templates.qps");
        }
        #endregion
    }
}
