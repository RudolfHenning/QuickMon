using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Notifiers.Audio
{
    public class AudioNotifierUI : WinFormsUINotifierBase
    {
        public override string AgentType { get { return "AudioNotifier"; } }
        public override IAgentConfigEntryEditWindow DetailEditor { get { return new AudioNotifierEdit(); } }
        public override IAgentDetailWindow DetailViewWindow { get { return null; } }
    }
}
