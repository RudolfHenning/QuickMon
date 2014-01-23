using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class MonitorState
    {
        public CollectorState State { get; set; }
        public object CurrentValue { get; set; }
        public string RawDetails { get; set; }
        public string HtmlDetails { get; set; }
    }
}
