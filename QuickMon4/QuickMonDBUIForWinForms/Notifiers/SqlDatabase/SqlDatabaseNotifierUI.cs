using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Notifiers
{
    public class SqlDatabaseNotifierUI : WinFormsUINotifierBase
    {
        public override string AgentType { get { return "SqlDatabaseNotifier"; } }
        public override IAgentConfigEntryEditWindow DetailEditor { get { return new SqlDatabaseNotifierEdit(); } }

        public override bool HasDetailView { get { return true; } }
        public override INotivierViewer Viewer { get { return new SqlDatabaseNotifierShowViewer(); } }
    }
}
