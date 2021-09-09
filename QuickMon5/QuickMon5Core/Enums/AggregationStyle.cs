using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon
{
    public enum AggregationStyle
    {
        None = 0,
        Sum = 1,
        Avg = 2,
        Min = 3,
        Max = 4,
        First = 5,
        Last = 6,
        Count = 7
    }
}
