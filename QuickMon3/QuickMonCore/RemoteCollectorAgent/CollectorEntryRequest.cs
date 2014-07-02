using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace QuickMon
{
    [Serializable, DataContract]
    public class CollectorEntryRequest
    {
        #region Properties
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "UniqueId")]
        public string UniqueId { get; set; }
        [DataMember(Name = "ParentCollectorId")]
        public string ParentCollectorId { get; set; }
        [DataMember(Name = "IsFolder")]
        public bool IsFolder { get; set; }
        [DataMember(Name = "Enabled")]
        public bool Enabled { get; set; }
        [DataMember(Name = "ProcessChildrenOnWarning")]
        public bool ProcessChildrenOnWarning { get; set; }
        [DataMember(Name = "CollectorTypeName")]
        public string CollectorTypeName { get; set; }
        [DataMember(Name = "ConfigString")]
        public string ConfigString { get; set; }
        [DataMember(Name = "ConfigVarsString")]
        public string ConfigVarsString { get; set; }

        #region CorrectiveScripts
        [DataMember(Name = "CorrectiveScriptDisabled")]
        public bool CorrectiveScriptDisabled { get; set; }
        [DataMember(Name = "CorrectiveScriptOnWarningPath")]
        public string CorrectiveScriptOnWarningPath { get; set; }
        [DataMember(Name = "CorrectiveScriptOnErrorPath")]
        public string CorrectiveScriptOnErrorPath { get; set; }
        [DataMember(Name = "RestorationScriptPath")]
        public string RestorationScriptPath { get; set; }
        [DataMember(Name = "CorrectiveScriptsOnlyOnStateChange")]
        public bool CorrectiveScriptsOnlyOnStateChange { get; set; }
        #endregion

        #region Alerting
        /// <summary>
        /// Repeat raising alert after X minutes if state remains in error/warning
        /// </summary>
        [DataMember(Name = "RepeatAlertInXMin")]
        public int RepeatAlertInXMin { get; set; }
        [DataMember(Name = "RepeatAlertInXPolls")]
        public int RepeatAlertInXPolls { get; set; }
        /// <summary>
        /// Only raise an alert once in X minutes. Used in conjunction with LastAlertTime
        /// </summary>
        [DataMember(Name = "AlertOnceInXMin")]
        public int AlertOnceInXMin { get; set; }
        [DataMember(Name = "AlertOnceInXPolls")]
        public int AlertOnceInXPolls { get; set; }
        /// <summary>
        /// Only raise an alert if the LastMonitorState remains Error or Warning.
        /// After each alert is generated this time gets updated
        /// </summary>
        [DataMember(Name = "DelayErrWarnAlertForXSec")]
        public int DelayErrWarnAlertForXSec { get; set; }
        [DataMember(Name = "DelayErrWarnAlertForXPolls")]
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
                false,//for Remote Agent there is no need for blocking of parent host override.

                false, //enabledPollingOverride not used in Remote collectors
                1, //onlyAllowUpdateOncePerXSec not used in Remote collectors
                false, //enablePollFrequencySliding not used in Remote collectors
                0, //pollSlideFrequencyAfterFirstRepeatSec not used in Remote collectors
                0, //pollSlideFrequencyAfterSecondRepeatSec not used in Remote collectors
                0, //pollSlideFrequencyAfterThirdRepeatSec not used in Remote collectors

                ConfigString,
                "",  //No service windows for remote agent
                ConfigVarsString);
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
            if (fullEntry.ConfigVariables != null)
            {
                StringBuilder configVarXml = new StringBuilder();
                configVarXml.AppendLine("<configVar>");
                foreach (ConfigVariable cv in fullEntry.ConfigVariables)
                {
                    configVarXml.AppendLine(cv.ToXml());
                }
                configVarXml.AppendLine("</configVar>");
                ConfigVarsString = configVarXml.ToString();
            }
            else
                ConfigVarsString = "";
        }
    }
}
