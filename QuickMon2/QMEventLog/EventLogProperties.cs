using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class EventLogProperties
    {
        public string MachineName { get; set; }
        public string Name { get; set; }
        public long MaxSize { get; set; }
        public long Retention { get; set; }
        public long AutoBackupLogFiles { get; set; }

        public override string ToString()
        {
            return string.Format("Machine: {0}\r\nName: {1}\r\nMaxSize: {2}\r\nRetention {3}",
                MachineName, Name, MaxSize, Retention == 0 ? "Overwrite" : AutoBackupLogFiles == 0 ? "No overwrite" : "Archive");
        }
    }
}
