using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    [Serializable]
    public class CollectorEntryRequest
    {
        public string Name { get; set; }
        public string UniqueId { get; set; }
        public string ParentCollectorId { get; set; }
        public bool IsFolder { get; set; }
        public bool Enabled { get; set; }
        public bool ProcessChildrenOnWarning { get; set; }

        #region CorrectiveScripts
        public bool CorrectiveScriptDisabled { get; set; }
        public string CorrectiveScriptOnWarningPath { get; set; }
        public string CorrectiveScriptOnErrorPath { get; set; }
        #endregion

        public string CollectorTypeName { get; set; }
        public string ConfigString { get; set; }

        #region Alerting
        /// <summary>
        /// Repeat raising alert after X minutes if state remains in error/warning
        /// </summary>
        public int RepeatAlertInXMin { get; set; }
        /// <summary>
        /// Only raise an alert once in X minutes. Used in conjunction with LastAlertTime
        /// </summary>
        public int AlertOnceInXMin { get; set; }
        /// <summary>
        /// Only raise an alert if the LastMonitorState remains Error or Warning.
        /// After each alert is generated this time gets updated
        /// </summary>
        public int DelayErrWarnAlertForXSec { get; set; }
        #endregion

        public string ToConfig()
        {
            string serviceWindows = "";
            string config = string.Format(Properties.Resources.CollectorEntryXml,
                UniqueId,
                Name,
                Enabled,
                IsFolder,
                CollectorTypeName,
                ParentCollectorId,
                ProcessChildrenOnWarning,
                RepeatAlertInXMin,
                AlertOnceInXMin,
                DelayErrWarnAlertForXSec,
                CorrectiveScriptDisabled,
                CorrectiveScriptOnWarningPath,
                CorrectiveScriptOnErrorPath,
                "False",
                "",
                "8181",
                ConfigString,
                serviceWindows);
            return config;
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
            CollectorTypeName = fullEntry.CollectorRegistrationName;
            ProcessChildrenOnWarning = fullEntry.CollectOnParentWarning;
            RepeatAlertInXMin = fullEntry.RepeatAlertInXMin;
            AlertOnceInXMin = fullEntry.AlertOnceInXMin;
            DelayErrWarnAlertForXSec = fullEntry.DelayErrWarnAlertForXSec;
            ConfigString = fullEntry.InitialConfiguration;
        }
    }
}
