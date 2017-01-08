using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public partial class CollectorHost
    {

        //http://stackoverflow.com/questions/937181/c-sharp-pattern-to-prevent-an-event-handler-hooked-twice
        public event CollectorHostDelegate AlertGoodState;
        private void RaiseAlertGoodState()
        {
            AlertGoodState?.Invoke(this);
        }
        public event CollectorHostDelegate AlertWarningState;
        private void RaiseAlertWarningState()
        {
            if (AlertWarningState != null)
            {
                AlertWarningState(this);
                LastWarningAlertTime = DateTime.Now;
            }
        }
        public event CollectorHostDelegate AlertErrorState;
        private void RaiseAlertErrorState()
        {
            if (AlertErrorState != null)
            {
                AlertErrorState(this);
                LastErrorAlertTime = DateTime.Now;
            }
        }
        public event CollectorHostDelegate NoStateChanged;
        private void RaiseNoStateChanged()
        {
            NoStateChanged?.Invoke(this);
        }

        public event CollectorHostDelegate StateUpdated;
        private void RaiseStateUpdated()
        {
            StateUpdated?.Invoke(this);
        }

        public event CollectorHostExecutionTimeDelegate AllAgentsExecutionTime;
        private void RaiseAllAgentsExecutionTime(long msTime)
        {
            AllAgentsExecutionTime?.Invoke(this, msTime);
        }

        #region CorrectiveScripts
        public event CollectorHostWithMessageDelegate RestorationScriptExecuted;
        public event CollectorHostWith2MessagesDelegate RestorationScriptFailed;
        public event CollectorHostWithMessageDelegate WarningCorrectiveScriptExecuted;
        public event CollectorHostWith2MessagesDelegate WarningCorrectiveScriptFailed;
        public event CollectorHostWithMessageDelegate ErrorCorrectiveScriptExecuted;
        public event CollectorHostWith2MessagesDelegate ErrorCorrectiveScriptFailed;
        public event CollectorHostWithMessageDelegate CorrectiveScriptMinRepeatTimeBlockedEvent;

        //public event CollectorHostDelegate RunCollectorHostCorrectiveWarningScript;
        //private void RaiseRunCollectorHostCorrectiveWarningScript()
        //{
        //    if (CorrectiveScriptOnWarningMinimumRepeatTimeMin > 0 && DateTime.Now < LastWarningCorrectiveScriptRun.AddMinutes(CorrectiveScriptOnWarningMinimumRepeatTimeMin))
        //    {
        //        RaiseCorrectiveScriptMinRepeatTimeBlockedEvent("Warning corrective script blocked from running. The specified minimum number of seconds have not passed since the last time the script ran!");
        //    }
        //    else if (RunCollectorHostCorrectiveWarningScript != null)
        //    {
        //        RunCollectorHostCorrectiveWarningScript(this);
        //        LastWarningCorrectiveScriptRun = DateTime.Now;
        //        TimesWarningCorrectiveScriptRan++;
        //    }
        //}
        //public event CollectorHostDelegate RunCollectorHostCorrectiveErrorScript;
        //private void RaiseRunCollectorHostCorrectiveErrorScript()
        //{
        //    if (CorrectiveScriptOnErrorMinimumRepeatTimeMin > 0 && DateTime.Now < LastErrorCorrectiveScriptRun.AddMinutes(CorrectiveScriptOnErrorMinimumRepeatTimeMin))
        //    {
        //        RaiseCorrectiveScriptMinRepeatTimeBlockedEvent("Error corrective script blocked from running. The specified minimum number of seconds have not passed since the last time the script ran!");
        //    }
        //    else if (RunCollectorHostCorrectiveErrorScript != null)
        //    {
        //        RunCollectorHostCorrectiveErrorScript(this);
        //        LastErrorCorrectiveScriptRun = DateTime.Now;
        //        TimesErrorCorrectiveScriptRan++;
        //    }
        //}
        //public event CollectorHostDelegate RunCollectorHostRestorationScript;
        //private void RaiseRunCollectorHostRestorationScript()
        //{
        //    if (RestorationScriptMinimumRepeatTimeMin > 0 && DateTime.Now < LastRestorationScriptRun.AddMinutes(RestorationScriptMinimumRepeatTimeMin))
        //    {
        //        RaiseCorrectiveScriptMinRepeatTimeBlockedEvent("Restoration script blocked from running. The specified minimum number of seconds have not passed since the last time the script ran!");
        //    }
        //    else if (RunCollectorHostRestorationScript != null)
        //    {
        //        RunCollectorHostRestorationScript(this);
        //        LastRestorationScriptRun = DateTime.Now;
        //        TimesRestorationScriptRan++;
        //    }
        //}
        //private void RaiseCorrectiveScriptMinRepeatTimeBlockedEvent(string message)
        //{
        //    if (CorrectiveScriptMinRepeatTimeBlockedEvent != null)
        //    {
        //        CorrectiveScriptMinRepeatTimeBlockedEvent(this, message);
        //    }
        //}
        #endregion

        public event CollectorHostWithMessageDelegate LoggingPollingOverridesTriggeredEvent;
        private void RaiseLoggingPollingOverridesTriggeredEvent(string message)
        {
            LoggingPollingOverridesTriggeredEvent?.Invoke(this, message);
        }

        #region Service windows
        public event CollectorHostDelegate EntereringServiceWindow;
        private void RaiseEntereringServiceWindow()
        {
            EntereringServiceWindow?.Invoke(this);
        }
        public event CollectorHostDelegate ExitingServiceWindow;
        private void RaiseExitingServiceWindow()
        {
            ExitingServiceWindow?.Invoke(this);
        } 
        #endregion
    }
}
