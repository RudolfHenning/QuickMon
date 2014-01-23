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
        public CollectorEntry RaisedFor { get; set; }
        //public string RaisedFor { get; set; }
        public MonitorState State { get; set; }

        //public CollectorEntry collectorEntryRaisedFor { get; set; }
        /// <summary>
        /// In case the specified State is null(not specified)
        /// </summary>
        //public string RawDetails { get; set; } 
    }
}
