using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Notifiers
{
    public class AlertMessage
    {
        public DateTime InsertDate { get; set; }
        public AlertLevel AlertLevel { get; set; }
        public string Collector { get; set; }
        public CollectorState PreviousState { get; set; }
        public CollectorState CurrentState { get; set; }
        public string Details { get; set; }
    }
}
