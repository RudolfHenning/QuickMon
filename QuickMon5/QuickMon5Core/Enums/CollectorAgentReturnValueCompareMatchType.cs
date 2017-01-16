using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public enum CollectorAgentReturnValueCompareMatchType
    {
        Match,
        DoesNotMatch,
        Contains,
        DoesNotContain,
        StartsWith,
        DoesNotStartWith,
        EndsWith,
        DoesNotEndWith,
        RegEx,
        IsNumber,
        IsNotANumber,
        LargerThan,
        SmallerThan,
        Between,
        NotBetween
    }
}
