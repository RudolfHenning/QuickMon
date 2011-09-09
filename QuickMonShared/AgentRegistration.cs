using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class AgentRegistration
    {
        public string Name { get; set; }
        public string AssemblyPath { get; set; }
        public string ClassName { get; set; }
        private bool isCollector = true;
        public bool IsCollector { get { return isCollector; } set { isCollector = value; } }
        public bool IsNotifier { get { return ! isCollector; } set { isCollector = !value; } }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, ClassName);
        }
    }
}
