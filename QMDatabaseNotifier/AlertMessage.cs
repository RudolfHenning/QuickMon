using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class AlertMessage
    {
        public DateTime InsertDate { get; set; }
        public AlertLevel AlertLevel { get; set; }
        public string CollectorType { get; set; }
        public string Category { get; set; }
        public MonitorStates PreviousState { get; set; }
        public MonitorStates CurrentState { get; set; }
        public string Details { get; set; }
    }
}
