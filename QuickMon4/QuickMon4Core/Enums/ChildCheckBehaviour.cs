using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public enum ChildCheckBehaviour
    {
        OnlyRunOnSuccess,
        ContinueOnWarning,
        ContinueOnWarningOrError,
        IncludeChildStatus
    }
    public static class ChildCheckBehaviourConverter
    {
        public static ChildCheckBehaviour FromString(string s)
        {
            if (s.ToLower() == "continueonwarning")
                return ChildCheckBehaviour.ContinueOnWarning;
            else if (s.ToLower() == "continueonwarningorerror")
                return ChildCheckBehaviour.ContinueOnWarningOrError;
            else if (s.ToLower() == "includechildstatus")
                return ChildCheckBehaviour.IncludeChildStatus;
            else
                return ChildCheckBehaviour.OnlyRunOnSuccess;
        }
    }
}
