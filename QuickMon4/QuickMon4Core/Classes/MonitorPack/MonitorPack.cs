using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon
{
    public partial class MonitorPack
    {
        public MonitorPack()
        {
            CollectorHosts = new List<CollectorHost>();
            NotifierHosts = new List<NotifierHost>();
            ConfigVariables = new List<ConfigVariable>();
            Enabled = true;
            PollingFreq = 1000;
            IsPollingEnabled = false;
            CurrentState = CollectorState.NotAvailable;
            PreviousState = CollectorState.NotAvailable;
            DefaultViewerNotifier = null;
            ConcurrencyLevel = 1;
            BusyPolling = false;
            CollectorStateHistorySize = 100;
            RunningAttended = AttendedOption.AttendedAndUnAttended;
            AgentLoadingErrors = "";
        }

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
        public NotifierHost DefaultViewerNotifier { get; set; }

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
        public bool BusyPolling { get; private set; }
        public bool AbortPolling { get; set; }
        #endregion
        #endregion

        #region Settings set by the hosting application
        /// <summary>
        /// Degree of parallelism
        /// </summary>
        public int ConcurrencyLevel { get; set; }
        public AttendedOption RunningAttended { get; set; }
        #endregion        

        #endregion

        #region Refreshing states
        private void SendNotifierAlert(AlertRaised alertRaised)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (alertRaised != null && alertRaised.RaisedFor != null && alertRaised.RaisedFor.CurrentState != null)
            {
                alertRaised.RaisedFor.CurrentState.AlertsRaised = new List<string>();
            }
            if (alertRaised != null && alertRaised.RaisedFor != null && alertRaised.RaisedFor.AlertsPaused)
            {
                //alertRaised.State.RawDetails += "\r\nAlerts are paused for this collector.";
                //alertRaised.RaisedFor.CurrentState.AlertsRaised.Add("Alerts are paused for this collector");
            }
            else
            {
                foreach (NotifierHost notifierEntry in (from n in NotifierHosts
                                                         where //n.Enabled && 
                                                            n.IsEnabledNow() &&
                                                            (int)n.AlertLevel <= (int)alertRaised.Level &&
                                                            (alertRaised.DetailLevel == DetailLevel.All || alertRaised.DetailLevel == n.DetailLevel) &&
                                                            (alertRaised.RaisedFor == null || n.AlertForCollectors.Count == 0 || n.AlertForCollectors.Contains(alertRaised.RaisedFor.Name))
                                                         select n))
                {
                    try
                    {
                        foreach (INotifier notifierAgent in notifierEntry.NotifierAgents)
                        {
                            bool allowedToRun = true;
                            if (RunningAttended == AttendedOption.AttendedAndUnAttended) //no Attended option set on MonitorPack
                            {
                                allowedToRun = true;
                            }
                            else if (RunningAttended == AttendedOption.OnlyAttended) //Running in Attended mode
                            {
                                if (notifierAgent.AttendedRunOption == AttendedOption.OnlyUnAttended || notifierEntry.AttendedOptionOverride == AttendedOption.OnlyUnAttended)
                                    allowedToRun = false;
                            }
                            else //unattended mode
                            {
                                if (notifierAgent.AttendedRunOption == AttendedOption.OnlyAttended || notifierEntry.AttendedOptionOverride == AttendedOption.OnlyAttended)
                                    allowedToRun = false;
                            }

                            if (allowedToRun)
                            {
                                PCRaiseNotifiersCalled();
                                notifierAgent.RecordMessage(alertRaised);
                                if (alertRaised.RaisedFor != null && alertRaised.RaisedFor.CurrentState != null && notifierAgent.AgentConfig != null)
                                {
                                    string configSummary = ((INotifierConfig)notifierAgent.AgentConfig).ConfigSummary;
                                    alertRaised.RaisedFor.CurrentState.AlertsRaised.Add(string.Format("{0} ({1}) {2}", notifierEntry.Name, notifierEntry.NotifierRegistrationName, configSummary));
                                }
                            }
                        }
                      
                    }
                    catch (Exception ex)
                    {
                        RaiseNotifierError(notifierEntry, ex.ToString());
                    }
                }
            }
            if (alertRaised != null && alertRaised.RaisedFor != null && alertRaised.RaisedFor.CurrentState != null)
            {
                alertRaised.RaisedFor.UpdateLatestHistoryWithAlertDetails(alertRaised.RaisedFor.CurrentState);
            }
            sw.Stop();
            PCSetNotifiersSendTime(sw.ElapsedMilliseconds);
        }
        #endregion

        #region Corrective script actions
        private void LogRestorationScriptAction(CollectorHost collectorEntry)
        {
            collectorEntry.CurrentState.RawDetails += "\r\n" + string.Format("Due to an earlier alert raised on the collector '{0}' the following restoration script was executed: '{1}'",
                collectorEntry.Name, collectorEntry.RestorationScriptPath);
            SendNotifierAlert(new AlertRaised()
            {
                Level = collectorEntry.PreviousState.State == CollectorState.Warning ? AlertLevel.Warning : AlertLevel.Error,
                DetailLevel = DetailLevel.Detail,
                RaisedFor = collectorEntry,
                State = collectorEntry.CurrentState.Clone()
            });
        }
        private void LogCorrectiveScriptAction(CollectorHost collectorEntry, bool error)
        {
            collectorEntry.CurrentState.RawDetails += "\r\n" + string.Format("Due to an alert raised on the collector '{0}' the following corrective script was executed: '{1}'",
                collectorEntry.Name, error ? collectorEntry.CorrectiveScriptOnErrorPath : collectorEntry.CorrectiveScriptOnWarningPath);
            SendNotifierAlert(new AlertRaised()
            {
                Level = error ? AlertLevel.Error : AlertLevel.Warning,
                DetailLevel = DetailLevel.Detail,
                RaisedFor = collectorEntry,
                State = collectorEntry.CurrentState.Clone()
            });
        }
        #endregion

        #region GetCollectorLists
        public List<CollectorHost> GetRootCollectorHosts()
        {
            return (from c in CollectorHosts
                    where c.ParentCollectorId.Length == 0
                    select c).ToList();
        }
        public List<CollectorHost> GetChildCollectorHosts(CollectorHost parentCE)
        {
            return (from c in CollectorHosts
                    where c.ParentCollectorId == parentCE.UniqueId
                    select c).ToList();
        }
        public List<CollectorHost> GetAllChildCollectorHosts(CollectorHost parentCE)
        {
            List<CollectorHost> list = new List<CollectorHost>();
            List<CollectorHost> listChildren = new List<CollectorHost>();
            listChildren = GetChildCollectorHosts(parentCE);
            foreach (CollectorHost child in listChildren)
            {
                list.Add(child);
                list.AddRange(GetAllChildCollectorHosts(child));
            }
            return list;
        }
        #endregion

        #region Sorting/Swapping
        internal void SwapCollectorEntries(CollectorHost c1, CollectorHost c2)
        {
            int index1 = CollectorHosts.FindIndex(c => c.UniqueId == c1.UniqueId);
            int index2 = CollectorHosts.FindIndex(c => c.UniqueId == c2.UniqueId);

            if (index1 < index2)
            {
                int tmp = index1;
                index1 = index2;
                index2 = tmp;
            }

            if (index1 > -1 && index2 > -1 && index1 != index2)
            {

                CollectorHosts.RemoveAt(index1);
                CollectorHosts.RemoveAt(index2);
                CollectorHosts.Insert(index2, c1);
                CollectorHosts.Insert(index1, c2);
            }
        }
        internal void SwapNotifierEntries(NotifierHost n1, NotifierHost n2)
        {
            int index1 = NotifierHosts.FindIndex(c => c.Name == n1.Name);
            int index2 = NotifierHosts.FindIndex(c => c.Name == n2.Name);

            if (index1 > -1 && index2 > -1 && index1 != index2)
            {
                NotifierHosts.RemoveAt(index1);
                NotifierHosts.RemoveAt(index2);
                NotifierHosts.Insert(index2, n1);
                NotifierHosts.Insert(index1, n2);
            }
        }
        #endregion
    }
}

// <monitorPack version="4.x" name="" typeName="" enabled="True" defaultNotifier="In Memory" runCorrectiveScripts="False" 
//         collectorStateHistorySize="100" pollingFreqSecOverride="0">
//   <configVars />
//   <collectorHosts>
//      <collectorHost uniqueId="..." name="..." enabled="True" expandOnStart="True" dependOnParentId="" 
//                      agentCheckSequence="All|FirstSuccess|FirstError"
//                      childCheckBehaviour="OnlyRunOnSuccess|ContinueOnWarning|ContinueOnWarningOrError|IncludeChildStatus"
//                      repeatAlertInXMin="0" alertOnceInXMin="0" delayErrWarnAlertForXSec="0" 
//                      repeatAlertInXPolls="0" alertOnceInXPolls="0" delayErrWarnAlertForXPolls="0" 
//                      correctiveScriptDisabled="False" correctiveScriptOnWarningPath="" correctiveScriptOnErrorPath="" 
//                      restorationScriptPath="" correctiveScriptsOnlyOnStateChange="False" enableRemoteExecute="False" 
//                      forceRemoteExcuteOnChildCollectors="False" remoteAgentHostAddress="" remoteAgentHostPort="8181" 
//                      blockParentRemoteAgentHostSettings="False" 
//                      enabledPollingOverride="False" onlyAllowUpdateOncePerXSec="1" enablePollFrequencySliding="False" 
//                      pollSlideFrequencyAfterFirstRepeatSec="2" pollSlideFrequencyAfterSecondRepeatSec="5" pollSlideFrequencyAfterThirdRepeatSec="30">
//          <collectorAgent type="PingCollector">
//            <config />
//          </collectorAgent>
//          <!-- ServiceWindows -->
//          <serviceWindows />
//          <!-- Config variables -->
//          <configVars />
//      </collectorHost>
//   </collectorHosts>
//   <notifierHosts>
//      <notifierHost name="..." enabled="True" alertLevel="Warning" detailLevel="Detail" attendedOptionOverride="AttendedAndUnAttended">
//        <notifierAgent type="InMemoryNotifier">
//           <config />
//        </notifierAgent>
//        <collectorHosts />
//         <!-- ServiceWindows -->
//        <serviceWindows />
//        <!-- Config variables -->
//        <configVars />
//      </notifierHost>
//   </notifierHosts>
// </monitorPack>