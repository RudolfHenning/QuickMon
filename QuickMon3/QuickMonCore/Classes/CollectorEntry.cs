using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public partial class CollectorEntry
    {
        public CollectorEntry()
        {
            ServiceWindows = new ServiceWindows();
            ServiceWindows.CreateFromConfig("<serviceWindows/>");
            Name = "";
            Enabled = true;
            UniqueId = Guid.NewGuid().ToString();
            RemoteAgentHostPort = 8181;
            PollCount = 0;
            RefreshCount = 0;
            GoodStateCount = 0;
            WarningStateCount = 0;
            ErrorStateCount = 0;
            LastGoodState = null;
            LastWarningState = null;
            LastErrorState = null;
            StateHistorySize = 1;
            ExpandOnStart = true;

            //Polling overrides
            EnabledPollingOverride = false;
            OnlyAllowUpdateOncePerXSec = 1;
            EnablePollFrequencySliding =  false;
            PollSlideFrequencyAfterFirstRepeatSec = 2;
            PollSlideFrequencyAfterSecondRepeatSec = 5;
            PollSlideFrequencyAfterThirdRepeatSec = 30;
            ConfigVariables = new List<ConfigVariable>();
        }

        #region Private vars
        private bool waitAlertTimeErrWarnInMinFlagged = false;
        private DateTime delayErrWarnAlertTime = new DateTime(2000, 1, 1);
        private int numberOfPollingsInErrWarn = 0;
        #endregion

        #region Properties
        #region General properties
        public string Name { get; set; }
        /// <summary>
        /// Any unique identifier for this collector entry. Used in collector parent-child relatioships
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        /// The parent collector entry's unique identifier
        /// </summary>
        public string ParentCollectorId { get; set; }
        /// <summary>
        /// Any object you wish to link with this instance
        /// </summary>
        public object Tag { get; set; }
        #endregion

        #region UI specific
        public bool ExpandOnStart { get; set; }
        #endregion

        #region Is this collector entry enabled now
        /// <summary>
        /// User/config based setting to disable this CollectorEntry
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// List if service windows when collector can operate
        /// </summary>
        public ServiceWindows ServiceWindows { get; set; }
        #endregion

        #region Collector agent related
        /// <summary>
        /// Is this collector entry just a folder/container
        /// </summary>
        public bool IsFolder { get; set; }
        public bool CollectOnParentWarning { get; set; } 
        public string CollectorRegistrationName { get; set; }
        public string CollectorRegistrationDisplayName { get; set; }
        public ICollector Collector { get; set; }
        private string initialConfiguration = "";
        public string InitialConfiguration
        {
            get { return initialConfiguration; }
            set
            {
                LastMonitorState = new MonitorState() { State = CollectorState.NotAvailable };
                CurrentState = new MonitorState() { State = CollectorState.NotAvailable };
                initialConfiguration = value;
            }
        }
        //derived config based on initialConfiguration with config vars applied
        public string ActiveConfiguration { get; set; }
        #endregion

        #region Corrective Script related
        public bool CorrectiveScriptDisabled { get; set; }
        public string CorrectiveScriptOnWarningPath { get; set; }
        public string CorrectiveScriptOnErrorPath { get; set; }
        public string RestorationScriptPath { get; set; }
        public bool CorrectiveScriptsOnlyOnStateChange { get; set; } 
        #endregion

        #region Last State update details
        /// <summary>
        /// 'Current' monitor state
        /// </summary>
        public MonitorState CurrentState { get; set; }
        /// <summary>
        /// Records the last monitor state
        /// </summary>
        public MonitorState LastMonitorState { get; set; }
        /// <summary>
        /// Records when the last state change was
        /// </summary>
        public DateTime LastStateChange { get; set; }
        #endregion

        #region State history
        public int StateHistorySize { get; set; }
        private List<MonitorState> stateHistory = new List<MonitorState>();
        public List<MonitorState> StateHistory
        {
            get
            {
                if (stateHistory.Count > StateHistorySize)
                {
                    DateTime? oldestDate = (from h in stateHistory
                                            orderby h.Timestamp descending
                                            select h.Timestamp).Take(StateHistorySize).Min();
                    if (oldestDate != null)
                    {
                        stateHistory.RemoveAll(h => h.Timestamp < oldestDate.Value);
                    }
                }
                return stateHistory;
            }
            private set
            {
                stateHistory = value;
            }
        }
        private void AddStateToHistory (MonitorState newState)
        {
            try
            {
                if (StateHistorySize > 1)
                {
                    if (stateHistory.Count > StateHistorySize)
                    {
                        DateTime? oldestDate = (from h in stateHistory
                                                orderby h.Timestamp descending
                                                select h.Timestamp).Take(StateHistorySize - 1).Min();
                        if (oldestDate != null)
                        {
                            stateHistory.RemoveAll(h => h.Timestamp < oldestDate.Value);
                        }
                    }
#if DEBUG
                    if (AlertsPaused)
                        newState.RawDetails += "\r\n(Alerts are paused for this collector)";
#endif
                    stateHistory.Add(newState);
                }
            }
            catch { }
        }
        public void UpdateLatestHistoryWithAlertDetails(MonitorState currentState)
        {
            try
            {
                if (StateHistorySize > 1)
                {
                    stateHistory[stateHistory.Count - 1].AlertsRaised = new List<string>();
                    stateHistory[stateHistory.Count - 1].AlertsRaised.AddRange(currentState.AlertsRaised.ToArray());
                }
            }
            catch { }
        }
        #endregion

        #region Stats
        /// <summary>
        /// Record the last time an alert was raised. Used in conjunction with AlertOnceInXMin
        /// </summary>
        public DateTime LastAlertTime { get; set; }
        /// <summary>
        /// Records when the last good state was recorded
        /// </summary>
        public DateTime LastGoodStateTime { get; set; }
        public DateTime LastWarningStateTime { get; set; }
        public DateTime LastErrorStateTime { get; set; }
        public DateTime LastStateCheckAttemptBegin { get; set; }
        public DateTime LastStateUpdate { get; set; }
        //public long LastStateCheckDurationMS { get; set; } //replaced by CurrentState.CallDurationMS
        /// <summary>
        /// Number of times Collector Agent has been executed
        /// </summary>
        public int PollCount { get; set; }
        /// <summary>
        /// Number of times this Collector 's GetCurrentState method has been called
        /// </summary>
        public int RefreshCount { get; set; }
        public DateTime FirstStateUpdate { get; set; }
        public int GoodStateCount { get; set; }
        public int WarningStateCount { get; set; }
        public int ErrorStateCount { get; set; }
        public DateTime LastWarningAlertTime { get; set; }
        public DateTime LastErrorAlertTime { get; set; }

        public MonitorState LastGoodState { get; set; }
        public MonitorState LastWarningState { get; set; }
        public MonitorState LastErrorState { get; set; }
        #endregion

        #region Alerting
        /// <summary>
        /// Repeat raising alert after X minutes if state remains in error/warning
        /// </summary>
        public int RepeatAlertInXMin { get; set; }
        public int RepeatAlertInXPolls { get; set; }
        /// <summary>
        /// Only raise an alert once in X minutes. Used in conjunction with LastAlertTime
        /// </summary>
        public int AlertOnceInXMin { get; set; }
        public int AlertOnceInXPolls { get; set; }
        /// <summary>
        /// Only raise an alert if the LastMonitorState remains Error or Warning.
        /// After each alert is generated this time gets updated
        /// </summary>
        public int DelayErrWarnAlertForXSec { get; set; }
        public int DelayErrWarnAlertForXPolls { get; set; }

        #region Alerts Paused (when alerting is temporarily disabled but child collectors can still be called when CollectOnParentWarning is on)
        public bool AlertsPaused { get; set; }
        #endregion
        #endregion

        #region Remote Execution
        /// <summary>
        /// Enable remote agent execution on THIS collector using RemoteAgentHostAddress:RemoteAgentHostAddress.
        /// This automatically overrides any remote agent host settings from parent collectorEntry 
        /// </summary>
        public bool EnableRemoteExecute { get; set; }
        /// <summary>
        /// The remote agent host URL to be used for THIS collector Entry
        /// </summary>
        public string RemoteAgentHostAddress { get; set; }
        /// <summary>
        /// The remote agent host PORT to be used for THIS collector Entry
        /// </summary>
        public int RemoteAgentHostPort { get; set; }
        /// <summary>
        /// Automatically use THIS collector's RemoteAgentHostAddress:RemoteAgentHostAddress for child collectorEntries
        /// </summary>
        public bool ForceRemoteExcuteOnChildCollectors { get; set; }
        /// <summary>
        /// Set at run-time. Indication that the parent collectorEntry has overrided remote agent host settings
        /// </summary>
        public bool OverrideForceRemoteExcuteOnChildCollectors { get; set; }
        /// <summary>
        /// Set at run-time. Indication that the parent collectorEntry has overrided remote agent host settings
        /// </summary>
        public bool OverrideRemoteAgentHost { get; set; }
        /// <summary>
        /// Set at run-time. Indication that the parent collectorEntry has overrided remote agent host settings
        /// </summary>
        public string OverrideRemoteAgentHostAddress  { get; set; }
        /// <summary>
        /// Set at run-time. Indication that the parent collectorEntry has overrided remote agent host settings
        /// </summary>
        public int OverrideRemoteAgentHostPort { get; set; }
        /// <summary>
        /// If set to true any override remote agent host settings are ignored for THIS collector (but still applies to grandchildren of parent)
        /// </summary>
        public bool BlockParentOverrideRemoteAgentHostSettings { get; set; }
        /// <summary>
        /// If enabled - if connection to remote host (WCF) fails the collector will be run locally as a backup
        /// </summary>
        public bool RunLocalOnRemoteHostConnectionFailure { get; set; }
        #endregion

        #region Polling override
        public bool EnabledPollingOverride { get; set; }
        public int OnlyAllowUpdateOncePerXSec { get; set; }
        public bool EnablePollFrequencySliding { get; set; }
        public int PollSlideFrequencyAfterFirstRepeatSec { get; set; }
        public int PollSlideFrequencyAfterSecondRepeatSec { get; set; }
        public int PollSlideFrequencyAfterThirdRepeatSec { get; set; }
        public bool StagnantStateFirstRepeat { get; private set; }
        public bool StagnantStateSecondRepeat { get; private set; }
        public bool StagnantStateThirdRepeat { get; private set; }
        public bool CurrentPollAborted { get; set; }
        #endregion

        #region Dynamic Config Variables
        public List<ConfigVariable> ConfigVariables { get; set; }
        #endregion

        #endregion

        #region Refreshing state and getting alerts
        /// <summary>
        /// Queries the agent to get the latest state.
        /// </summary>
        /// <returns>True or False but not both I hope</returns>
        public MonitorState GetCurrentState(bool disablePollingOverrides = false)
        {
            RefreshCount++;
            CurrentPollAborted = false;
            if (LastMonitorState == null)
                LastMonitorState = new MonitorState() { State = CollectorState.NotAvailable };
            if (CurrentState == null)
            {
                CurrentState = new MonitorState() { State = CollectorState.NotAvailable };
                LastStateUpdate = DateTime.Now;
            }
            if (LastMonitorState.State != CollectorState.ConfigurationError)            
            {                
                if (!Enabled)
                {
                    CurrentState.State = CollectorState.Disabled;
                    StagnantStateFirstRepeat = false;
                    StagnantStateSecondRepeat = false;
                    StagnantStateThirdRepeat = false;
                }
                else if (!ServiceWindows.IsInTimeWindow())
                {
                    LastMonitorState = CurrentState.Clone();
                    CurrentState.State = CollectorState.Disabled;
                    StagnantStateFirstRepeat = false;
                    StagnantStateSecondRepeat = false;
                    StagnantStateThirdRepeat = false;
                }
                else if (IsFolder)
                {
                    LastMonitorState = CurrentState.Clone();
                    CurrentState.State = CollectorState.Folder;
                    StagnantStateFirstRepeat = false;
                    StagnantStateSecondRepeat = false;
                    StagnantStateThirdRepeat = false;
                }
                else if (CurrentState.State != CollectorState.NotAvailable && !disablePollingOverrides && EnabledPollingOverride && !EnablePollFrequencySliding && (LastStateUpdate.AddSeconds(OnlyAllowUpdateOncePerXSec) > DateTime.Now))
                {
                    //Not time yet for update
                    CurrentPollAborted = true;
                }
                else if (CurrentState.State != CollectorState.NotAvailable && !disablePollingOverrides && EnabledPollingOverride && EnablePollFrequencySliding && 
                    (
                        (StagnantStateThirdRepeat && (LastStateUpdate.AddSeconds(PollSlideFrequencyAfterThirdRepeatSec) > DateTime.Now)) ||
                        (!StagnantStateThirdRepeat && StagnantStateSecondRepeat && (LastStateUpdate.AddSeconds(PollSlideFrequencyAfterSecondRepeatSec) > DateTime.Now)) ||
                        (!StagnantStateThirdRepeat && !StagnantStateSecondRepeat && StagnantStateFirstRepeat && (LastStateUpdate.AddSeconds(PollSlideFrequencyAfterFirstRepeatSec) > DateTime.Now)) ||
                        (!StagnantStateFirstRepeat && !StagnantStateThirdRepeat && !StagnantStateSecondRepeat && (LastStateUpdate.AddSeconds(OnlyAllowUpdateOncePerXSec) > DateTime.Now))
                    )
                   )
                {
                    //Not time yet for update
                    CurrentPollAborted = true;
                }
                else
                {
                    //*********** Call actual collector GetState **********
                    LastStateCheckAttemptBegin = DateTime.Now;                    
                    LastMonitorState = CurrentState.Clone();                    
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();

                    if (EnableRemoteExecute || (OverrideRemoteAgentHost && !BlockParentOverrideRemoteAgentHostSettings))
                    {
                        string currentHostAddress = EnableRemoteExecute ? this.RemoteAgentHostAddress : OverrideRemoteAgentHostAddress;
                        int currentHostPort = EnableRemoteExecute ? this.RemoteAgentHostPort : OverrideRemoteAgentHostPort;
                        try
                        {
                            CurrentState = CollectorEntryRelay.GetRemoteAgentState(this, currentHostAddress, currentHostPort);
                        }
                        catch (Exception ex)
                        {
                            CurrentState.Timestamp = DateTime.Now;
                            if (RunLocalOnRemoteHostConnectionFailure && ex.Message.Contains("There was no endpoint listening"))
                            {
                                //attempting to run locally
                                try
                                {
                                    CurrentState = Collector.GetState();
                                }
                                catch (Exception exLocal)
                                {
                                    CurrentState.State = CollectorState.Error;
                                    CurrentState.RawDetails = exLocal.ToString();
                                }
                                CurrentState.RawDetails = "Remote excution failed. Attempting to run locally\r\n" + CurrentState.RawDetails;
                            }
                            else
                            {
                                CurrentState.State = CollectorState.Error;
                                CurrentState.RawDetails = ex.ToString();
                            }
                            CurrentState.ExecutedOnHostComputer = System.Net.Dns.GetHostName();
                        }
                    }

                    //if (EnableRemoteExecute)
                    //{
                    //    try
                    //    {
                    //        CurrentState = CollectorEntryRelay.GetRemoteAgentState(this);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        CurrentState.Timestamp = DateTime.Now;
                    //        if (ex.Message.Contains("There was no endpoint listening"))
                    //        {
                    //            //attempting to run locally
                    //            try
                    //            {
                    //                CurrentState = Collector.GetState();                                    
                    //            }
                    //            catch (Exception exLocal)
                    //            {
                    //                CurrentState.State = CollectorState.Error;
                    //                CurrentState.RawDetails = exLocal.ToString();
                    //            }
                    //            CurrentState.RawDetails = "Remote excution failed. Attempting to run locally\r\n" + CurrentState.RawDetails;
                    //        }
                    //        else
                    //        {
                    //            CurrentState.State = CollectorState.Error;
                    //            CurrentState.RawDetails = ex.ToString();
                    //        }
                    //        CurrentState.ExecutedOnHostComputer = System.Net.Dns.GetHostName();
                    //    }
                    //}
                    //else if (OverrideRemoteAgentHost && !BlockParentOverrideRemoteAgentHostSettings)
                    //{
                    //    try
                    //    {
                    //        CurrentState = CollectorEntryRelay.GetRemoteAgentState(this, OverrideRemoteAgentHostAddress, OverrideRemoteAgentHostPort);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        CurrentState.Timestamp = DateTime.Now;
                    //        if (ex.Message.Contains("There was no endpoint listening"))
                    //        {
                    //            //attempting to run locally
                    //            try
                    //            {
                    //                CurrentState = Collector.GetState();
                    //            }
                    //            catch (Exception exLocal)
                    //            {
                    //                CurrentState.State = CollectorState.Error;
                    //                CurrentState.RawDetails = exLocal.ToString();
                    //            }
                    //            CurrentState.RawDetails = "Remote excution failed. Attempting to run locally\r\n" + CurrentState.RawDetails;
                    //        }
                    //        else
                    //        {
                    //            CurrentState.State = CollectorState.Error;
                    //            CurrentState.RawDetails = ex.ToString();
                    //        }
                    //        CurrentState.ExecutedOnHostComputer = System.Net.Dns.GetHostName();
                    //    }
                    //}
                    else //Use LOCAL execution
                    {
                        CurrentState = Collector.GetState();
                        CurrentState.ExecutedOnHostComputer = System.Net.Dns.GetHostName();
                    }
                    sw.Stop();

                    if (LastMonitorState.State != CurrentState.State)
                    {
                        StagnantStateFirstRepeat = false;
                        StagnantStateSecondRepeat = false;
                        StagnantStateThirdRepeat = false;
                    }
                    else if (!StagnantStateFirstRepeat)
                    {
                        StagnantStateFirstRepeat = true;
                        StagnantStateSecondRepeat = false;
                        StagnantStateThirdRepeat = false;
                    }
                    else if (!StagnantStateSecondRepeat)
                    {
                        StagnantStateSecondRepeat = true;
                        StagnantStateThirdRepeat = false;
                    }
                    else if (!StagnantStateThirdRepeat)
                    {
                        StagnantStateThirdRepeat = true;
                    }

                    //Updating stats
                    CurrentState.CallDurationMS = (int)sw.ElapsedMilliseconds;
                    LastStateUpdate = DateTime.Now;
                    if (FirstStateUpdate < (new DateTime(2000, 1, 1)))
                        FirstStateUpdate = DateTime.Now;
                    PollCount++;
                    if (CurrentState.State == CollectorState.Good)
                    {
                        LastGoodState = CurrentState.Clone();
                        LastGoodStateTime = DateTime.Now;
                        GoodStateCount++;
                    }
                    else if (CurrentState.State == CollectorState.Warning)
                    {
                        LastWarningState = CurrentState.Clone();
                        LastWarningStateTime = DateTime.Now;
                        WarningStateCount++;
                    }
                    else if (CurrentState.State == CollectorState.Error)
                    {
                        LastErrorState = CurrentState.Clone();
                        LastErrorStateTime = DateTime.Now;
                        ErrorStateCount++;
                    }
                    AddStateToHistory(CurrentState.Clone()); //add details for historic details - still missing alert details though....hmmm
                }
            }
            else
            {
                CurrentState.State = CollectorState.ConfigurationError;
            }
            return CurrentState;
        }

        /// <summary>
        /// Check if the Collector state changed from previous poll
        /// </summary>
        /// <returns>True or False, you decide</returns>
        public bool StateChanged()
        {
            bool stateChanged = false;
            if (IsFolder || !Enabled) //don't bother raising events for folders
                stateChanged = false;
            else
            {
                stateChanged = (LastMonitorState.State != CurrentState.State);
                if (stateChanged)
                    LastStateChange = DateTime.Now; //reset time
            }
            return stateChanged;
        }
        #endregion

        #region Viewing details
        private ICollectorDetailView collectorDetailView = null;
        public void ShowDetails()
        {
            if (Collector != null)
            {
                if (collectorDetailView == null || (!collectorDetailView.IsStillVisible()))
                {
                    collectorDetailView = Collector.GetCollectorDetailView();
                    if (collectorDetailView != null)
                    {
                        collectorDetailView.SetWindowTitle(Name + " (" + this.CollectorRegistrationDisplayName + ")");
                        collectorDetailView.ShowCollectorDetails(Collector);
                    }
                }
                else
                {
                    collectorDetailView.RefreshConfig(Collector);
                }
            }
        }
        public bool ShowEditConfigEntry(ref ICollectorConfigEntry entry)
        {
            bool changed = false;
            if (Collector != null)
            {
                changed = Collector.ShowEditEntry(ref entry);
            }
            return changed;
        }
        public void RefreshDetailsIfOpen()
        {
            if (Collector != null)
            {
                if (collectorDetailView != null && (collectorDetailView.IsStillVisible()))
                {
                    collectorDetailView.SetWindowTitle(Name + " (" + this.CollectorRegistrationName + ")");
                    collectorDetailView.RefreshConfig(Collector);
                }
            }
        }
        public void CloseDetails()
        {
            if (Collector != null)
            {
                if (collectorDetailView != null && (collectorDetailView.IsStillVisible()))
                {
                    try
                    {
                        collectorDetailView.CloseWindow();
                    }
                    catch { }
                }
            }
        }
        #endregion

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, CollectorRegistrationName);
        }
        public string ToRemoteHostName()
        {
            if (EnableRemoteExecute)
                return string.Format("{0}:{1}", RemoteAgentHostAddress, RemoteAgentHostPort);
            else if (OverrideRemoteAgentHost && !BlockParentOverrideRemoteAgentHostSettings)
                return string.Format("{0}:{1}", OverrideRemoteAgentHostAddress, OverrideRemoteAgentHostPort);
            else
                return "";
        }
        /// <summary>
        /// Creates a new copy of the current Collector Entry
        /// </summary>
        /// <returns>CollectorEntry instance</returns>
        public CollectorEntry Clone(bool newId = false)
        {
            CollectorEntry clone = FromConfig(ToConfig());
            if (newId)
                clone.UniqueId = Guid.NewGuid().ToString();
            clone.CollectorRegistrationDisplayName = this.CollectorRegistrationDisplayName; //have to add it afterwards since config does not specify it
            return clone;
        }
    }
}
