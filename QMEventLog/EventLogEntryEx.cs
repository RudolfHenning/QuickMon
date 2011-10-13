using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace QuickMon
{
    internal class EventLogEntryEx
    {
        public string Category { get; set; }
        public EventLogEntryType EntryType { get; set; }
        public int EventId { get; set; }
        public string MachineName { get; set; }
        public string LogName { get; set; }
        public string Message { get; set; }
        public string MessageSummary { get; set; }
        public string Source { get; set; }
        public DateTime TimeGenerated { get; set; }
        public string UserName { get; set; }
    }
}
