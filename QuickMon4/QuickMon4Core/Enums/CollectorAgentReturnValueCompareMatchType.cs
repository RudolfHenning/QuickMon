using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public enum CollectorAgentReturnValueCompareMatchType
    {
        Match,
        Contains,
        StartsWith,
        EndsWith,
        RegEx,
        IsNumber,
        LargerThan,
        SmallerThan,
        Between
    }
}
