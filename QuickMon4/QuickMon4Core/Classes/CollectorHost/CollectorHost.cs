﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public partial class CollectorHost : AgentHostBase
    {
        public CollectorHost()
        {
            ServiceWindows = new ServiceWindows();
            ServiceWindows.CreateFromConfig("<serviceWindows/>");
            Name = "";
            Enabled = true;
            UniqueId = Guid.NewGuid().ToString();
            CollectorAgents = new List<ICollector>();
            RemoteAgentHostPort = 8181;

            //Stats
            PollCount = 0;
            RefreshCount = 0;
            GoodStateCount = 0;
            WarningStateCount = 0;
            ErrorStateCount = 0;
            LastGoodState = null;
            LastWarningState = null;
            LastErrorState = null;
            ExpandOnStart = true;

            //Polling overrides
            EnabledPollingOverride = false;
            OnlyAllowUpdateOncePerXSec = 1;
            EnablePollFrequencySliding = false;
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
        /// <summary>
        /// Any unique identifier for this collector entry. Used in collector parent-child relatioships
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        /// The parent collector entry's unique identifier
        /// </summary>
        public string ParentCollectorId { get; set; }
        /// <summary>
        /// Reference to containing MonitorPack
        /// </summary>
        public MonitorPack ParentMonitorPack { get; set; }
        #endregion

        #region UI specific
        public bool ExpandOnStart { get; set; }
        #endregion

        #region Collector agents
        public List<ICollector> CollectorAgents { get; set; }
        public AgentCheckSequence AgentCheckSequence { get; set; }
        public ChildCheckBehaviour ChildCheckBehaviour { get; set; }
        #endregion

        #region Current State and state history
        private MonitorState currentState = new MonitorState() { State = CollectorState.NotAvailable };
        /// <summary>
        /// 'Current' monitor state
        /// </summary>
        public MonitorState CurrentState { get { return currentState; } }
        /// <summary>
        /// Records the last monitor state
        /// </summary>
        public MonitorState PreviousState 
        {
            get
            {
                if (stateHistory == null || stateHistory.Count == 0)
                    return new MonitorState() { State = CollectorState.NotAvailable, Timestamp = DateTime.Now };
                else
                    return stateHistory[stateHistory.Count - 1];
            }
        }
        /// <summary>
        /// Records when the last MonitorState.State value change was. Set in SetCurrentState() method
        /// </summary>
        public DateTime LastStateChange { get; private set; }
        private List<MonitorState> stateHistory = new List<MonitorState>();
        public List<MonitorState> StateHistory
        {
            get
            {
                if (stateHistory.Count > MaxStateHistorySize)
                {
                    DateTime? oldestDate = (from h in stateHistory
                                            orderby h.Timestamp descending
                                            select h.Timestamp).Take(MaxStateHistorySize).Min();
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
        private int maxStateHistorySize = 100;
        /// <summary>
        /// Set max state history size. Minimum is 1
        /// </summary>
        public int MaxStateHistorySize
        {
            get { return maxStateHistorySize; }
            set
            {
                if (value > 1)
                    maxStateHistorySize = value;
                else
                    maxStateHistorySize = 1;
            }
        }
        #endregion

        #region Alerting
        //public bool ContinueToCheckSubEntriesOnWarning { get; set; }
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

        #region Alerts for this CH is Paused
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
        public string OverrideRemoteAgentHostAddress { get; set; }
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
        #endregion

    }
}