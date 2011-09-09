using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class ReceiveLocationInfo
    {
        public string ReceivePortName { get; set; }
        public string ReceiveLocationName { get; set; }
        public string HostName { get; set; }
        public bool Disabled { get; set; }
    }
}
