using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.UI
{
    public class RSSNotifierUI : WinFormsUINotifierBase
    {
        public override string AgentType { get { return "QuickMon.Notifiers.RSSNotifier"; } }
        public override IAgentConfigEntryEditWindow DetailEditor { get { return new RSSNotifierEdit(); } }        
    }
}
