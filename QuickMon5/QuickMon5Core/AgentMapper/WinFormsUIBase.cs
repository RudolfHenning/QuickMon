using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.UI
{
    public abstract class WinFormsUIBase : IWinFormsUI
    {

        public abstract string AgentType { get; }
        public string AgentName { get; set; }
        public bool AgentEnabled { get; set; }
        public string SelectedAgentConfig { get; set; }
        //public abstract bool EditAgent();
        public abstract bool HasDetailView { get; }
    }
    public abstract class WinFormsUICollectorBase : WinFormsUIBase
    {
        public abstract ICollectorConfigEntryEditWindow DetailEditor { get; }

        public override bool HasDetailView
        {
            get { return true; }
        }
    }

    public abstract class WinFormsUINotifierBase : WinFormsUIBase
    {
        public abstract IAgentConfigEntryEditWindow DetailEditor { get; }
        public override bool HasDetailView
        {
            get { return false; }
        }
        public virtual INotivierViewer Viewer { get { return null; } }
    }
}
