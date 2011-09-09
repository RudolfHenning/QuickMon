using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class DriveSpaceEntry
    {
        public DriveSpaceEntry()
        {
            DriveLetter = "C";
            WarningSizeLeftMB = 500;
            ErrorSizeLeftMB = 100;
            WarnOnNotReady = false;
        }
        public string DriveLetter { get; set; }
        public long WarningSizeLeftMB { get; set; }
        public long ErrorSizeLeftMB { get; set; }
        public bool WarnOnNotReady { get; set; }
    }
}
