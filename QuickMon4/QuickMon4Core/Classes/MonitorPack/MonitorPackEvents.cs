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
                if (MonitorPackPathChanged != null)
                    MonitorPackPathChanged(newMonitorPackPath);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRunCollectorCorrectiveErrorScript: {0}", ex.Message));
            }
        }
        public event SimpleMessageDelegate MonitorPackEventReported;
        private void RaiseMonitorPackEventReported(string message)
        {
            if (MonitorPackEventReported != null)
            {
                MonitorPackEventReported(message);
            }
        }
        #endregion

        #region Monitor Pack Logging
        public event SimpleMessageDelegate LoggingEvent;
        private void RaiseLoggingEvent(string message)
        {
            try
            {
                if (LoggingEvent != null)
                    LoggingEvent(message);
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
                if (OnNotifierError != null)
                    OnNotifierError(notifier, errorMessage);
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
                if (OnCollectorError != null)
                {
                    OnCollectorError(collector, errorMessage);
                }
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
                if (MonitorPackError != null)
                    RaiseMonitorPackError(errorMessage);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRaiseMonitorPackError: {0}", ex.Message));
            }
        }
        #endregion

        #region Corrective script events
        public event CollectorHostDelegate RunCollectorHostCorrectiveWarningScript;
        public event CollectorHostDelegate RunCollectorHostCorrectiveErrorScript;
        public event CollectorHostDelegate RunCollectorHostRestorationScript;
        private void collectorHost_RunCollectorHostCorrectiveErrorScript(CollectorHost collectorHost)
        {
            try
            {
                if (RunCorrectiveScripts && RunCollectorHostCorrectiveErrorScript != null && collectorHost != null && !collectorHost.CorrectiveScriptDisabled && collectorHost.CorrectiveScriptOnErrorPath.Length > 0)
                {
                    RunCollectorHostCorrectiveErrorScript(collectorHost);
                    LogCorrectiveScriptAction(collectorHost, true);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in collectorHost_RunCollectorHostCorrectiveErrorScript: {0}", ex.ToString()));
            }
        }
        private void collectorHost_RunCollectorHostCorrectiveWarningScript(CollectorHost collectorHost)
        {
            try
            {
                if (RunCorrectiveScripts && RunCollectorHostCorrectiveWarningScript != null && collectorHost != null && !collectorHost.CorrectiveScriptDisabled && collectorHost.CorrectiveScriptOnWarningPath.Length > 0)
                {
                    RunCollectorHostCorrectiveWarningScript(collectorHost);
                    LogCorrectiveScriptAction(collectorHost, false);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in collectorHost_RunCollectorHostCorrectiveErrorScript: {0}", ex.ToString()));
            }
        }
        private void collectorHost_RunCollectorHostRestorationScript(CollectorHost collectorHost)
        {
            try
            {
                if (RunCorrectiveScripts && RunCollectorHostRestorationScript != null && collectorHost != null && !collectorHost.CorrectiveScriptDisabled && collectorHost.RestorationScriptPath.Length > 0)
                {
                    RunCollectorHostRestorationScript(collectorHost);
                    LogRestorationScriptAction(collectorHost);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in collectorHost_RunCollectorHostRestorationScript: {0}", ex.ToString()));
            }
        }
        #endregion

        #region CollectorHost events
        /// <summary>
        /// Event raised before Collector host state gets updated
        /// </summary>
        public event CollectorHostDelegate CollectorHostCalled;
        private void RaiseCollectorHostCalled(CollectorHost collectorHost)
        {
            if (CollectorHostCalled != null)
            {
                CollectorHostCalled(collectorHost);
            }
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
            
            if (CollectorHostStateUpdated != null)
                CollectorHostStateUpdated(collectorHost);
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
            if (CollectorHost_AlertRaised_Good != null)
                CollectorHost_AlertRaised_Good(collectorHost);
            SendNotifierAlert(AlertLevel.Info, DetailLevel.Detail, collectorHost);            
        }
        private void collectorHost_AlertWarningState(CollectorHost collectorHost)
        {
            if (CollectorHost_AlertRaised_Warning != null)
                CollectorHost_AlertRaised_Warning(collectorHost);
            SendNotifierAlert(AlertLevel.Warning, DetailLevel.Detail, collectorHost);            
        }
        private void collectorHost_AlertErrorState(CollectorHost collectorHost)
        {
            if (CollectorHost_AlertRaised_Error != null)
                CollectorHost_AlertRaised_Error(collectorHost);

            SendNotifierAlert(AlertLevel.Error, DetailLevel.Detail, collectorHost);            
        }
        private void collectorHost_NoStateChanged(CollectorHost collectorHost)
        {
            if (CollectorHost_AlertRaised_NoStateChanged != null)
                CollectorHost_AlertRaised_NoStateChanged(collectorHost);
            SendNotifierAlert(AlertLevel.Debug, DetailLevel.Detail, collectorHost);
        } 
        private void collectorHost_AllAgentsExecutionTime(CollectorHost collectorHost, long msTime)
        {
            if (CollectorHostAllAgentsExecutionTime != null)
                CollectorHostAllAgentsExecutionTime(collectorHost, msTime);
        }
        private void collectorHost_LoggingPollingOverridesTriggeredEvent(CollectorHost collectorHost, string message)
        {
            LoggingPollingOverridesTriggeredEvent(message, collectorHost);
        }
        #endregion
    }
}
