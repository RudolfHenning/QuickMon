using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public partial class CollectorHost
    {
        public bool CorrectiveScriptDisabled { get; set; }
        public string CorrectiveScriptOnWarningPath { get; set; }
        public string CorrectiveScriptOnErrorPath { get; set; }
        public string RestorationScriptPath { get; set; }
        public bool CorrectiveScriptsOnlyOnStateChange { get; set; }
        public int CorrectiveScriptOnWarningMinimumRepeatTimeMin { get; set; }
        public int CorrectiveScriptOnErrorMinimumRepeatTimeMin { get; set; }
        public int RestorationScriptMinimumRepeatTimeMin { get; set; }
        public DateTime LastErrorCorrectiveScriptRun { get; set; }
        public DateTime LastWarningCorrectiveScriptRun { get; set; }
        public DateTime LastRestorationScriptRun { get; set; }
        public int TimesErrorCorrectiveScriptRan { get; set; }
        public int TimesWarningCorrectiveScriptRan { get; set; }
        public int TimesRestorationScriptRan { get; set; }
    }
}
