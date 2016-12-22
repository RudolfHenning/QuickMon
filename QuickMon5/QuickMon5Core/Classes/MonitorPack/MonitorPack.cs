using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public partial class MonitorPack
    {

        #region Properties

        #region User configurable
        public string Name { get; set; }
        public string Version { get; set; }
        public bool Enabled { get; set; }
        public string TypeName { get; set; }
        public bool RunCorrectiveScripts { get; set; }
        public string MonitorPackPath { get; set; }
        public int CollectorStateHistorySize { get; set; }
        /// <summary>
        /// Polling frequency for background operations. Measured in milliseconds. Default 1 Second
        /// </summary>
        public int PollingFreq { get; set; }
        /// <summary>
        /// Overridding polling frequency as specified in config. If 0 then PollingFreq is used.
        /// </summary>
        public int PollingFrequencyOverrideSec { get; set; }
        public bool PreloadCollectorInstances { get; set; }

        public List<CollectorHost> CollectorHosts { get; private set; }
        public List<NotifierHost> NotifierHosts { get; private set; }
        //public NotifierHost DefaultViewerNotifier { get; set; }

        #region Dynamic Config Variables
        public List<ConfigVariable> ConfigVariables { get; set; }
        #endregion
        #endregion

        #region Run-time properties
        public string AgentLoadingErrors { get; set; }
        public CollectorState CurrentState { get; set; }
        public CollectorState PreviousState { get; set; }
        #region Polling related properties
        /// <summary>
        /// Is background polling active
        /// </summary>
        public bool IsPollingEnabled { get; set; }
        public bool IsBusyPolling { get; private set; }
        public bool AbortPolling { get; set; }
        #endregion
        public long LastRefreshDurationMS { get; private set; }
        #endregion

        #region Settings set by the hosting application
        /// <summary>
        /// Degree of parallelism
        /// </summary>
        public int ConcurrencyLevel { get; set; }
        public AttendedOption RunningAttended { get; set; }
        #endregion        

        #region Security
        public string UserNameCacheMasterKey { get; set; }
        public string UserNameCacheFilePath { get; set; }
        //Run time setting only
        public string ApplicationUserNameCacheMasterKey { get; set; }
        public string ApplicationUserNameCacheFilePath { get; set; }
        #endregion

        #region Globally Disable/block Agent types if it is not supported for some reason
        public List<string> BlockedCollectorAgentTypes { get; set; }
        #endregion

        #endregion

        #region Refreshing states
        public CollectorState RefreshStates(bool disablePollingOverrides = false)
        {
            AbortPolling = false;
            IsBusyPolling = true;
            CollectorState globalState = CollectorState.Good;

            return globalState;
        }
        #endregion
    }
}
