using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class DatabaseEntry
    {
        public string Name { get; set; }
        public int WarningSizeMB { get; set; }
        public int ErrorSizeMB { get; set; }
    }
}
