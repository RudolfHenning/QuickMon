using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class ServiceStateDefinition
    {
        public string MachineName { get; set; }
        public List<string> Services { get; set; }
    }
}
