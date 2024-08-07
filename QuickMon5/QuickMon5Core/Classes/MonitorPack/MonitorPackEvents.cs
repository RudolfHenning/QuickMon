using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public partial class MonitorPack
    {
        #region Monitor pack general events
        public event SimpleMessageDelegate MonitorPackPathChanged;
        private void RaiseMonitorPackPathChanged(string newMonitorPackPath)
        {
            try
            {
                MonitorPackPathChanged?.Invoke(newMonitorPackPath);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRunCollectorCorrectiveErrorScript: {0}", ex.Message));
            }
        }
        public event SimpleMessageDelegate MonitorPackEventReported;
        private void RaiseMonitorPackEventReported(string message)
        {
            MonitorPackEventReported?.Invoke(message);
        }

        public event SimpleMessageDelegate BeforeMonitorPackReload;
        public event SimpleMessageDelegate AfterMonitorPackReload;
        public event SimpleMessageDelegate AfterMonitorPackRefresh;
        #endregion

        #region Monitor Pack Logging
        public event SimpleMessageDelegate LoggingEvent;
        private void RaiseLoggingEvent(string message)
        {
            try
            {
                LoggingEvent?.Invoke(message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseLoggingEvent: {0}", ex.Message));
            }
        }
        #endregion

        #region Error messages
        public event NotifierHostWithMessageDelegate OnNotifierError;
        private void RaiseNotifierError(NotifierHost notifier, string errorMessage)
        {
            try
            {
                OnNotifierError?.Invoke(notifier, errorMessage);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseNotifierError: {0}", ex.Message));
            }
        }
        public event CollectorHostWithMessageDelegate OnCollectorError;
        private void RaiseCollectorError(CollectorHost collector, string errorMessage)
        {
            try
            {
                OnCollectorError?.Invoke(collector, errorMessage);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseCollectorError: {0}", ex.Message));
            }
        }
        public event SimpleMessageDelegate MonitorPackError;
        private void RaiseMonitorPackError(string errorMessage)
        {
            try
            {
                MonitorPackError?.Invoke(errorMessage);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRaiseMonitorPackError: {0}", ex.Message));
            }
        }
        #endregion

        #region Corrective script events
        public event CollectorHostWithMessageDelegate CollectorHostRestorationScriptExecuted;
        public event CollectorHostWith2MessagesDelegate CollectorHostRestorationScriptFailed;
        public event CollectorHostWithMessageDelegate CollectorHostWarningCorrectiveScriptExecuted;
        public event CollectorHostWith2MessagesDelegate CollectorHostWarningCorrectiveScriptFailed;
        public event CollectorHostWithMessageDelegate CollectorHostErrorCorrectiveScriptExecuted;
        public event CollectorHostWith2MessagesDelegate CollectorHostErrorCorrectiveScriptFailed;
        public event CollectorHostWithMessageDelegate CorrectiveScriptMinRepeatTimeBlockedEvent;
        private void CollectorHost_RestorationScriptExecuted(CollectorHost collectorHost, string scriptName)
        {
            LogRestorationScriptAction(collectorHost, scriptName);
            CollectorHostRestorationScriptExecuted?.Invoke(collectorHost, scriptName);
        }
        private void CollectorHost_RestorationScriptFailed(CollectorHost collectorHost, string scriptName, string errorMsg)
        {
            LogRestorationScriptFailedAction(collectorHost, scriptName, errorMsg);
            CollectorHostRestorationScriptFailed?.Invoke(collectorHost, scriptName, errorMsg);
        }
        private void CollectorHost_WarningCorrectiveScriptExecuted(CollectorHost collectorHost, string scriptName)
        {
            LogCorrectiveScriptAction(collectorHost, scriptName);
            CollectorHostWarningCorrectiveScriptExecuted?.Invoke(collectorHost, scriptName);
        }
        private void CollectorHost_WarningCorrectiveScriptFailed(CollectorHost collectorHost, string scriptName, string errorMsg)
        {
            LogCorrectiveScriptFailedAction(collectorHost, scriptName, errorMsg);
            CollectorHostWarningCorrectiveScriptFailed?.Invoke(collectorHost, scriptName, errorMsg);
        }
        private void CollectorHost_ErrorCorrectiveScriptExecuted(CollectorHost collectorHost, string scriptName)
        {
            LogCorrectiveScriptAction(collectorHost, scriptName);
            CollectorHostErrorCorrectiveScriptExecuted?.Invoke(collectorHost, scriptName);
        }
        private void CollectorHost_ErrorCorrectiveScriptFailed(CollectorHost collectorHost, string scriptName, string errorMsg)
        {
            LogCorrectiveScriptFailedAction(collectorHost, scriptName, errorMsg);
            CollectorHostErrorCorrectiveScriptFailed?.Invoke(collectorHost, scriptName, errorMsg);
        }
        private void collectorHost_CorrectiveScriptMinRepeatTimeBlockedEvent(CollectorHost collectorHost, string message)
        {
            LogCorrectiveScriptMinRepeatTimeBlockedEvent(collectorHost, message);
            CorrectiveScriptMinRepeatTimeBlockedEvent?.Invoke(collectorHost, message);            
        }

        //public event CollectorHostDelegate RunCollectorHostCorrectiveWarningScript;
        //public event CollectorHostDelegate RunCollectorHostCorrectiveErrorScript;
        //public event CollectorHostDelegate RunCollectorHostRestorationScript;

        //
        //private void collectorHost_RunCollectorHostCorrectiveErrorScript(CollectorHost collectorHost)
        //{
        //    try
        //    {
        //        if (CorrectiveScriptsEnabled && RunCollectorHostCorrectiveErrorScript != null && collectorHost != null && !collectorHost.CorrectiveScriptDisabled && collectorHost.CorrectiveScriptOnErrorPath.Length > 0)
        //        {
        //            RunCollectorHostCorrectiveErrorScript(collectorHost);
        //            LogCorrectiveScriptAction(collectorHost, true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Trace.WriteLine(string.Format("Error in collectorHost_RunCollectorHostCorrectiveErrorScript: {0}", ex.ToString()));
        //    }
        //}
        //private void collectorHost_RunCollectorHostCorrectiveWarningScript(CollectorHost collectorHost)
        //{
        //    try
        //    {
        //        if (CorrectiveScriptsEnabled && RunCollectorHostCorrectiveWarningScript != null && collectorHost != null && !collectorHost.CorrectiveScriptDisabled && collectorHost.CorrectiveScriptOnWarningPath.Length > 0)
        //        {
        //            RunCollectorHostCorrectiveWarningScript(collectorHost);
        //            LogCorrectiveScriptAction(collectorHost, false);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Trace.WriteLine(string.Format("Error in collectorHost_RunCollectorHostCorrectiveWarningScript: {0}", ex.ToString()));
        //    }
        //}
        //private void collectorHost_RunCollectorHostRestorationScript(CollectorHost collectorHost)
        //{
        //    try
        //    {
        //        if (CorrectiveScriptsEnabled && RunCollectorHostRestorationScript != null && collectorHost != null && !collectorHost.CorrectiveScriptDisabled && collectorHost.RestorationScriptPath.Length > 0)
        //        {
        //            RunCollectorHostRestorationScript(collectorHost);
        //            LogRestorationScriptAction(collectorHost);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Trace.WriteLine(string.Format("Error in collectorHost_RunCollectorHostRestorationScript: {0}", ex.ToString()));
        //    }
        //}


        #endregion

        #region CollectorHost events
        /// <summary>
        /// Event raised before Collector host state gets updated
        /// </summary>
        public event CollectorHostDelegate CollectorHostCalled;
        private void RaiseCollectorHostCalled(CollectorHost collectorHost)
        {
            CollectorHostCalled?.Invoke(collectorHost);
        }
        /// <summary>
        /// Event raised agter Collector host state has been updated
        /// </summary>
        public event CollectorHostDelegate CollectorHostStateUpdated;
        public event CollectorHostExecutionTimeDelegate CollectorHostAllAgentsExecutionTime;

        //to Bubble up the Collector host events
        public event CollectorHostDelegate CollectorHost_AlertRaised_Good;
        public event CollectorHostDelegate CollectorHost_AlertRaised_Warning;
        public event CollectorHostDelegate CollectorHost_AlertRaised_Error;
        public event CollectorHostDelegate CollectorHost_AlertRaised_NoStateChanged;

        private void collectorHost_StateUpdated(CollectorHost collectorHost)
        {
            PCRaiseCollectorHostsQueried();

            CollectorHostStateUpdated?.Invoke(collectorHost);
            if (collectorHost != null)
            {
                if (collectorHost.CollectorAgents != null)
                    PCRaiseCollectorAgentsQueried(collectorHost.CollectorAgents.Count);
                switch (collectorHost.CurrentState.State)
                {
                    case CollectorState.NotAvailable:
                        break;
                    case CollectorState.Good:
                        PCRaiseCollectorSuccessState();
                        break;
                    case CollectorState.Warning:
                        PCRaiseCollectorWarningState();
                        break;
                    case CollectorState.Error:
                    case CollectorState.ConfigurationError:
                        PCRaiseCollectorErrorState();
                        break;
                    case CollectorState.Disabled:
                        break;
                    case CollectorState.None:
                        break;
                    default:
                        break;
                }
            }
        }
        private void collectorHost_AlertGoodState(CollectorHost collectorHost)
        {
            CollectorHost_AlertRaised_Good?.Invoke(collectorHost);
            SendNotifierAlert(AlertLevel.Info, DetailLevel.Detail, collectorHost);
        }
        private void collectorHost_AlertWarningState(CollectorHost collectorHost)
        {
            CollectorHost_AlertRaised_Warning?.Invoke(collectorHost);
            SendNotifierAlert(AlertLevel.Warning, DetailLevel.Detail, collectorHost);
        }
        private void collectorHost_AlertErrorState(CollectorHost collectorHost)
        {
            CollectorHost_AlertRaised_Error?.Invoke(collectorHost);

            SendNotifierAlert(AlertLevel.Error, DetailLevel.Detail, collectorHost);
        }
        private void collectorHost_NoStateChanged(CollectorHost collectorHost)
        {
            CollectorHost_AlertRaised_NoStateChanged?.Invoke(collectorHost);
            SendNotifierAlert(AlertLevel.Debug, DetailLevel.Detail, collectorHost);
        }
        private void collectorHost_AllAgentsExecutionTime(CollectorHost collectorHost, long msTime)
        {
            CollectorHostAllAgentsExecutionTime?.Invoke(collectorHost, msTime);
        }
        private void collectorHost_LoggingPollingOverridesTriggeredEvent(CollectorHost collectorHost, string message)
        {
            LoggingPollingOverridesTriggeredEvent(message, collectorHost);
        }
        private void collectorHost_EntereringServiceWindow(CollectorHost collectorHost)
        {
            LoggingServiceWindowEvent(collectorHost, true);
        }
        private void collectorHost_ExitingServiceWindow(CollectorHost collectorHost)
        {
            LoggingServiceWindowEvent(collectorHost, false);
        }
        #endregion

        #region Alerts
        public event NotifierAgentAlertDelegate NotifierAgentAlertRaised;
        private void RaiseNotifierAgentAlertRaised(INotifier notifierAgent, AlertRaised alertRaised)
        {
            try
            {
                NotifierAgentAlertRaised?.Invoke(notifierAgent, alertRaised);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRaiseMonitorPackError: {0}", ex.Message));
            }
        }
        #endregion

        #region Collector History Load/Save events
        public event SimpleMessageDelegate HistoryLoading;
        public event SimpleMessageDelegate HistoryLoaded;
        public event SimpleMessageDelegate HistorySaving;
        public event SimpleMessageDelegate HistorySaved;
        public event SimpleMessageDelegate HistorySaveError;
        public event SimpleMessageDelegate CollectorHistoryLoaded;
        public void RaiseCollectorHistoryLoaded(CollectorHost collectorHost)
        {
            CollectorHistoryLoaded?.Invoke($"History loaded for {collectorHost.Name}");
        }
        #endregion
    }
}
