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
            if (AlertGoodState != null)
            {
                AlertGoodState(this);
            }
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
            if (NoStateChanged != null)
            {
                NoStateChanged(this);
            }
        }

        public event CollectorHostDelegate StateUpdated;
        private void RaiseStateUpdated()
        {
            if (StateUpdated != null)
            {
                StateUpdated(this);
            }
        }

        public event CollectorHostExecutionTimeDelegate AllAgentsExecutionTime;
        private void RaiseAllAgentsExecutionTime(long msTime)
        {
            if (AllAgentsExecutionTime != null)
                AllAgentsExecutionTime(this, msTime);
        }

        #region CorrectiveScripts
        public event CollectorHostDelegate RunCollectorHostCorrectiveWarningScript;
        private void RaiseRunCollectorHostCorrectiveWarningScript()
        {
            if (CorrectiveScriptOnWarningMinimumRepeatTimeMin > 0 && DateTime.Now < LastWarningCorrectiveScriptRun.AddMinutes(CorrectiveScriptOnWarningMinimumRepeatTimeMin))
            {
                RaiseCorrectiveScriptMinRepeatTimeBlockedEvent("Warning corrective script blocked from running. The specified minimum number of seconds have not passed since the last time the script ran!");
            }
            else if (RunCollectorHostCorrectiveWarningScript != null)
            {
                RunCollectorHostCorrectiveWarningScript(this);
                LastWarningCorrectiveScriptRun = DateTime.Now;
                TimesWarningCorrectiveScriptRan++;
            }
        }
        public event CollectorHostDelegate RunCollectorHostCorrectiveErrorScript;
        private void RaiseRunCollectorHostCorrectiveErrorScript()
        {
            if (CorrectiveScriptOnErrorMinimumRepeatTimeMin > 0 && DateTime.Now < LastErrorCorrectiveScriptRun.AddMinutes(CorrectiveScriptOnErrorMinimumRepeatTimeMin))
            {
                RaiseCorrectiveScriptMinRepeatTimeBlockedEvent("Error corrective script blocked from running. The specified minimum number of seconds have not passed since the last time the script ran!");
            }
            else if (RunCollectorHostCorrectiveErrorScript != null)
            {
                RunCollectorHostCorrectiveErrorScript(this);
                LastErrorCorrectiveScriptRun = DateTime.Now;
                TimesErrorCorrectiveScriptRan++;
            }
        }
        public event CollectorHostDelegate RunCollectorHostRestorationScript;
        private void RaiseRunCollectorHostRestorationScript()
        {
            if (RestorationScriptMinimumRepeatTimeMin > 0 && DateTime.Now < LastRestorationScriptRun.AddMinutes(RestorationScriptMinimumRepeatTimeMin))
            {
                RaiseCorrectiveScriptMinRepeatTimeBlockedEvent("Restoration script blocked from running. The specified minimum number of seconds have not passed since the last time the script ran!");
            }
            else if (RunCollectorHostRestorationScript != null)
            {
                RunCollectorHostRestorationScript(this);
                LastRestorationScriptRun = DateTime.Now;
                TimesRestorationScriptRan++;
            }
        }
        public event CollectorHostWithMessageDelegate CorrectiveScriptMinRepeatTimeBlockedEvent;
        private void RaiseCorrectiveScriptMinRepeatTimeBlockedEvent(string message)
        {
            if (CorrectiveScriptMinRepeatTimeBlockedEvent != null)
            {
                CorrectiveScriptMinRepeatTimeBlockedEvent(this, message);
            }
        }
        #endregion

        public event CollectorHostWithMessageDelegate LoggingPollingOverridesTriggeredEvent;
        private void RaiseLoggingPollingOverridesTriggeredEvent(string message)
        {
            if (LoggingPollingOverridesTriggeredEvent != null)
            {
                LoggingPollingOverridesTriggeredEvent(this, message);
            }
        }

        public event CollectorHostDelegate EntereringServiceWindow;
        private void RaiseEntereringServiceWindow()
        {
            if (EntereringServiceWindow != null)
            {
                EntereringServiceWindow(this);
            }
        }
        public event CollectorHostDelegate ExitingServiceWindow;
        private void RaiseExitingServiceWindow()
        {
            if (ExitingServiceWindow != null)
            {
                ExitingServiceWindow(this);
            }
        }
    }
}
