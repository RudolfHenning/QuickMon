using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickMon.UI;

namespace QuickMon.Notifiers
{
    public class InMemoryNotifierUI : WinFormsUINotifierBase
    {
        public override string AgentType { get { return "InMemoryNotifier"; } }
        public override IAgentConfigEntryEditWindow DetailEditor { get { return new InMemoryNotifierEdit(); } }
    }
}
