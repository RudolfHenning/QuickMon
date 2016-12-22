using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class AlertRaised
    {
        public AlertRaised()
        {
            RaisedTime = DateTime.Now;
        }
        public DateTime RaisedTime { get; private set; }
        public AlertLevel Level { get; set; }
        public DetailLevel DetailLevel { get; set; }
        public string MessageRaw { get; set; }
        /// <summary>
        /// For notifier agents that supports this.
        /// </summary>
        public string MessageHTML { get; set; }
        public CollectorHost RaisedFor { get; set; }
        //public MonitorState State { get; set; }
    }
}
