using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Notifiers
{
    public class LogFileNotifierUI : WinFormsUINotifierBase
    {
        public override string AgentType { get { return "LogFileNotifier"; } }
        public override IAgentConfigEntryEditWindow DetailEditor { get { return new LogFileNotifierEdit(); } }
    }
}
