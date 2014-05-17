using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    [Serializable]
    public class CollectorEntryRequest
    {
        #region Properties
        public string Name { get; set; }
        public string UniqueId { get; set; }
        public string ParentCollectorId { get; set; }
        public bool IsFolder { get; set; }
        public bool Enabled { get; set; }
        public bool ProcessChildrenOnWarning { get; set; }
        public string CollectorTypeName { get; set; }
        public string ConfigString { get; set; }

        #region CorrectiveScripts
        public bool CorrectiveScriptDisabled { get; set; }
        public string CorrectiveScriptOnWarningPath { get; set; }
        public string CorrectiveScriptOnErrorPath { get; set; }
        public string RestorationScriptPath { get; set; }
        public bool CorrectiveScriptsOnlyOnStateChange { get; set; }
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
        #endregion 
        #endregion

        public string ToConfig()
        {
            return CollectorEntry.ToConfig(UniqueId,
                Name,
                Enabled,
                IsFolder,
                CollectorTypeName,
                ParentCollectorId,
                ProcessChildrenOnWarning,
                RepeatAlertInXMin, AlertOnceInXMin, DelayErrWarnAlertForXSec,
                RepeatAlertInXPolls, AlertOnceInXPolls,  DelayErrWarnAlertForXPolls,
                CorrectiveScriptDisabled,
                CorrectiveScriptOnWarningPath,
                CorrectiveScriptOnErrorPath,
                RestorationScriptPath,
                CorrectiveScriptsOnlyOnStateChange,
                false, //for Remote Agent usage corrective are not supported on host yet.
                false, //No child collectors to worry about
                "", //for Remote Agent there is no further nested Remote host.
                8181, //for Remote Agent there is no further nested Remote host.

                false, //enabledPollingOverride not used in Remote collectors
                1, //onlyAllowUpdateOncePerXSec not used in Remote collectors
                false, //enablePollFrequencySliding not used in Remote collectors
                0, //pollSlideFrequencyAfterFirstRepeatSec not used in Remote collectors
                0, //pollSlideFrequencyAfterSecondRepeatSec not used in Remote collectors
                0, //pollSlideFrequencyAfterThirdRepeatSec not used in Remote collectors

                ConfigString,
                ""  //No service windows for remote agent
                );
        }
        public void FromCollectorEntry(CollectorEntry fullEntry)
        {
            Name = fullEntry.Name;
            UniqueId = fullEntry.UniqueId;
            Enabled = fullEntry.Enabled;
            IsFolder = fullEntry.IsFolder;
            ParentCollectorId = fullEntry.ParentCollectorId;
            CorrectiveScriptDisabled = fullEntry.CorrectiveScriptDisabled;
            CorrectiveScriptOnWarningPath = fullEntry.CorrectiveScriptOnWarningPath;
            CorrectiveScriptOnErrorPath = fullEntry.CorrectiveScriptOnErrorPath;
            RestorationScriptPath = fullEntry.RestorationScriptPath;
            CorrectiveScriptsOnlyOnStateChange = fullEntry.CorrectiveScriptsOnlyOnStateChange;
            CollectorTypeName = fullEntry.CollectorRegistrationName;
            ProcessChildrenOnWarning = fullEntry.CollectOnParentWarning;
            RepeatAlertInXMin = fullEntry.RepeatAlertInXMin;
            AlertOnceInXMin = fullEntry.AlertOnceInXMin;
            DelayErrWarnAlertForXSec = fullEntry.DelayErrWarnAlertForXSec;
            ConfigString = fullEntry.InitialConfiguration;
        }
    }
}
