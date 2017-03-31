using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.UI
{
    public class AudioNotifierUI : WinFormsUINotifierBase
    {
        public override string AgentType { get { return "QuickMon.Notifiers.AudioNotifier"; } }
        public override IAgentConfigEntryEditWindow DetailEditor { get { return new AudioNotifierEdit(); } }
    }
}
