using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class TableSizeEntry
    {        
        public string TableName { get; set; }
        public long WarningValue { get; set; }
        public long ErrorValue { get; set; }
    }
}
