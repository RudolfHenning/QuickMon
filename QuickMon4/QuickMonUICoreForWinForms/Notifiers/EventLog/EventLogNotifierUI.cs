using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Notifiers
{
    public class EventLogNotifierUI : WinFormsUINotifierBase
    {
        public override string AgentType { get { return "EventLogNotifier"; } }
        public override IAgentConfigEntryEditWindow DetailEditor { get { return new EventLogNotifierEdit(); } }
    }
}
