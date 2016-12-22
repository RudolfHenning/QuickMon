using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public partial class MonitorPack
    {
        public class NameAndTypeSummary
        {
            public string Name { get; set; }
            public bool Exists { get; set; }
            public string Path { get; set; }
            public string TypeName { get; set; }
            public string Version { get; set; }
            public bool Enabled { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }

        public void LoadXml(string xmlConfig)
        {
        }
    }
}
