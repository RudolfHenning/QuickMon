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
    }
}
