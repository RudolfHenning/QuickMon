using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon.UI
{
    public class FileSystemCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "QuickMon.Collectors.FileSystemCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new FileSystemCollectorEditFilterEntry(); } }
    }
}
