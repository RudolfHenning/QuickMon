using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Notifiers
{
    public class SMTPNotifierUI : WinFormsUINotifierBase
    {
        public override string AgentType { get { return "SMTPNotifier"; } }
        public override IAgentConfigEntryEditWindow DetailEditor { get { return new SMTPNotifierEdit(); } }
        //public override IAgentDetailWindow DetailViewWindow { get { return null; } }
    }
}
