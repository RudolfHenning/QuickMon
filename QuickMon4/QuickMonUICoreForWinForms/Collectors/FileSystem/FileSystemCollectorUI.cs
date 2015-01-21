using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class FileSystemCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "FileSystemCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new FileSystemCollectorEditFilterEntry(); } }
        public override IAgentDetailWindow DetailViewWindow { get { return null; } }
    }
}
