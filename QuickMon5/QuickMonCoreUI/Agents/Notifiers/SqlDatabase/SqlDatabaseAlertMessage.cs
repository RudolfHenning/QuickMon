using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon.UI
{
    public class SqlDatabaseAlertMessage
    {
        public DateTime InsertDate { get; set; }
        public AlertLevel AlertLevel { get; set; }
        public string Collector { get; set; }
        public CollectorState PreviousState { get; set; }
        public CollectorState CurrentState { get; set; }
        public string Details { get; set; }
    }
}
