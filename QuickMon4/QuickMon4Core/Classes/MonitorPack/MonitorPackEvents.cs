﻿using System;
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
        public event SimpleMessageDelegate RaiseMonitorPackError;
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
        public event CollectorHostDelegate RunCollectorCorrectiveWarningScript;
        private void RaiseRunCollectorCorrectiveWarningScript(CollectorHost collectorHostEntry)
        {
            try
            {
                if (RunCorrectiveScripts &&
                    RunCollectorCorrectiveWarningScript != null &&
                    collectorHostEntry != null &&
                    !collectorHostEntry.CorrectiveScriptDisabled &&
                    collectorHostEntry.CorrectiveScriptOnWarningPath.Length > 0)
                {
                    RunCollectorCorrectiveWarningScript(collectorHostEntry);
                    LogCorrectiveScriptAction(collectorHostEntry, false);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRunCollectorCorrectiveWarningScript: {0}", ex.Message));
            }
        }
        public event CollectorHostDelegate RunCollectorCorrectiveErrorScript;
        private void RaiseRunCollectorCorrectiveErrorScript(CollectorHost collectorHostEntry)
        {
            try
            {
                if (RunCorrectiveScripts &&
                    RunCollectorCorrectiveErrorScript != null &&
                    collectorHostEntry != null &&
                    !collectorHostEntry.CorrectiveScriptDisabled &&
                    collectorHostEntry.CorrectiveScriptOnErrorPath.Length > 0)
                {
                    RunCollectorCorrectiveErrorScript(collectorHostEntry);
                    LogCorrectiveScriptAction(collectorHostEntry, true);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRunCollectorCorrectiveErrorScript: {0}", ex.Message));
            }
        }
        public event CollectorHostDelegate RunRestorationScript;
        private void RaiseRunCollectorRestorationScript(CollectorHost collectorHostEntry)
        {
            try
            {
                if (RunCorrectiveScripts &&
                    RunRestorationScript != null &&
                    collectorHostEntry != null &&
                    !collectorHostEntry.CorrectiveScriptDisabled &&
                    collectorHostEntry.RestorationScriptPath.Length > 0)
                {
                    RunRestorationScript(collectorHostEntry);
                    LogRestorationScriptAction(collectorHostEntry);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Error in RaiseRunCollectorCorrectiveErrorScript: {0}", ex.Message));
            }
        }
        #endregion

        #region CollectorHost events
        private void collectorHost_AlertGoodState(CollectorHost collectorHost)
        {
            throw new NotImplementedException();
        }
        private void collectorHost_AlertWarningState(CollectorHost collectorHost)
        {
            throw new NotImplementedException();
        }
        private void collectorHost_AlertErrorState(CollectorHost collectorHost)
        {
            throw new NotImplementedException();
        }
        void collectorHost_NoStateChanged(CollectorHost collectorHost)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
