using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public enum ScriptType
    {
        DOS,
        PowerShell
    }

    public static class ScriptTypeConverter
    {
        public static ScriptType FromString(string s)
        {
            if (s.ToLower() == "dos")
                return ScriptType.DOS;
            else if (s.ToLower() == "powershell")
                return ScriptType.PowerShell;            
            else
                return ScriptType.DOS;
        }
    }
}
