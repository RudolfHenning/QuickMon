using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public enum CollectorAgentReturnValueCheckSequence
    {
        GWE, //Test first for Good then Warning and then assume Error
        EWG,  //Test first for Error then Warning and then assume good
        GEW,
        EGW,
        WGE,
        WEG
    }
}
