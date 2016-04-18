using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class LinuxCPUCollectorConfig : ICollectorConfig
    {
        public LinuxCPUCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        public void FromXml(string configurationString)
        {
            throw new NotImplementedException();
        }

        public string ToXml()
        {
            throw new NotImplementedException();
        }

        public string GetDefaultOrEmptyXml()
        {
            throw new NotImplementedException();
        }

        public string ConfigSummary
        {
            get { throw new NotImplementedException(); }
        }
    }
}
