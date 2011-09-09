using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class CollectorListx
    {
        public string Name { get; set; }
        private List<CollectorBase> collectors = new List<CollectorBase>();
        public List<CollectorBase> Collectors { get { return collectors; } }
        public bool CollectorsAreDependant { get; set; }
        public bool ContinueCollectorsOnWarning { get; set; }
        public bool Enabled { get; set; }
    }
}
