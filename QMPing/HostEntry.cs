using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class HostEntry
    {
        private string hostName = "";
        public string HostName { get { return hostName; } set { hostName = value; } }
        private string description = "";
        public string Description { get { return description; } set { description = value; } }
        private int maxTime = 1000;
        public int MaxTime { get { return maxTime; } set { maxTime = value; } }
        private int timeOut = 5000;
        public int TimeOut { get { return timeOut; } set { timeOut = value; } }
    }
}
