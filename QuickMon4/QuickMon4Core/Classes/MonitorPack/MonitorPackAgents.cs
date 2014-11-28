using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public partial class MonitorPack
    {
        public static string ApplyAgentConfigVars(string configXml, List<ConfigVariable> configVars)
        {
            string appliedConfig = configXml;
            if (configVars != null)
                foreach (ConfigVariable cv in configVars)
                    appliedConfig = cv.ApplyOn(appliedConfig);
            return appliedConfig;
        }
    }
}
