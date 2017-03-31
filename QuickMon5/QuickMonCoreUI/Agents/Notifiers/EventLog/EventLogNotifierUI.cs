using QuickMon.Notifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.UI
{
    public class EventLogNotifierUI : WinFormsUINotifierBase
    {
        public override string AgentType { get { return "QuickMon.Notifiers.EventLogNotifier"; } }
        public override IAgentConfigEntryEditWindow DetailEditor { get { return new EventLogNotifierEdit(); } }
       // public override IAgentDetailWindow DetailViewWindow { get { return null; } }

        public override bool HasDetailView { get { return true; } }
        public override INotivierViewer Viewer { get { return new EventLogNotifierUIViewer(); } }
    }

    public class EventLogNotifierUIViewer : INotivierViewer, IChildWindowIdentity
    {

        public INotifier SelectedNotifier { get; set; }

        public void ShowNotifierViewer()
        {
            if (SelectedNotifier != null)
            {
                EventLogNotifier thisNotifier = (EventLogNotifier)SelectedNotifier;
                EventLogNotifierConfig currentConfig = (EventLogNotifierConfig)thisNotifier.AgentConfig;
                string command = "eventvwr.exe";
                try
                {
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo = new System.Diagnostics.ProcessStartInfo() { FileName = command };
                    if (currentConfig.MachineName.Length > 1)
                    {
                        p.StartInfo.Arguments = "\\\\" + currentConfig.MachineName;
                    }
                    p.Start();
                }
                catch { }
            }
        }

        public bool IsViewerStillVisible()
        {
            return false;//always new window
        }
        public void CloseViewer()
        {
         
        }

        #region IChildWindowIdentity
        public bool AutoRefreshEnabled { get; set; }
        public string Identifier { get; set; }
        public IParentWindow ParentWindow { get; set; }
        public void RefreshDetails()
        {
            //does nothing
        }
        public void CloseChildWindow()
        {
            if (ParentWindow != null)
                ParentWindow.RemoveChildWindow(this);
        }
        public void ShowChildWindow()
        {
            //if (ParentWindow != null)
            //    ParentWindow.RegisterChildWindow(this);
            if (SelectedNotifier != null)
            {
                EventLogNotifier thisNotifier = (EventLogNotifier)SelectedNotifier;
                EventLogNotifierConfig currentConfig = (EventLogNotifierConfig)thisNotifier.AgentConfig;
                string command = "eventvwr.exe";
                try
                {
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo = new System.Diagnostics.ProcessStartInfo() { FileName = command };
                    if (currentConfig.MachineName.Length > 1)
                    {
                        p.StartInfo.Arguments = "\\\\" + currentConfig.MachineName;
                    }
                    p.Start();
                }
                catch { }
            }
        }
        #endregion
    }
}
