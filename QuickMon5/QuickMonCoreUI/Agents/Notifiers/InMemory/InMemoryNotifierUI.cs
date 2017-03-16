using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon.UI
{
    public class InMemoryNotifierUI : WinFormsUINotifierBase
    {
        public override string AgentType { get { return "QuickMon.Notifiers.InMemoryNotifier"; } }
        public override IAgentConfigEntryEditWindow DetailEditor { get { return new InMemoryNotifierEdit(); } }
        public override bool HasDetailView { get { return true; } }
        public override INotivierViewer Viewer { get { return new InMemoryNotifierViewer(); } }
    }
}
