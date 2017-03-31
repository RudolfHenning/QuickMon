using QuickMon.Notifiers;
using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuickMon.UI
{
    public class LogFileNotifierUI : WinFormsUINotifierBase
    {
        public override string AgentType { get { return "QuickMon.Notifiers.LogFileNotifier"; } }
        public override IAgentConfigEntryEditWindow DetailEditor { get { return new LogFileNotifierEdit(); } }
        public override bool HasDetailView { get { return true; } }
        public override INotivierViewer Viewer { get { return new LogFileNotifierUIViewer(); } }
    }

    public class LogFileNotifierUIViewer : INotivierViewer, IChildWindowIdentity
    {
        public INotifier SelectedNotifier { get; set; }

        public void ShowNotifierViewer()
        {
            if (SelectedNotifier != null)
            {
                LogFileNotifier thisNotifier = (LogFileNotifier)SelectedNotifier;
                LogFileNotifierConfig currentConfig = (LogFileNotifierConfig)thisNotifier.AgentConfig;
                if (File.Exists(currentConfig.OutputPath))
                {
                    try
                    {
                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        p.StartInfo = new System.Diagnostics.ProcessStartInfo() { FileName = currentConfig.OutputPath };
                        p.Start();
                    }
                    catch { }
                }
                else
                    System.Windows.Forms.MessageBox.Show("Log file not found or it might be empty!", "Log file", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
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
                LogFileNotifier thisNotifier = (LogFileNotifier)SelectedNotifier;
                LogFileNotifierConfig currentConfig = (LogFileNotifierConfig)thisNotifier.AgentConfig;
                if (File.Exists(currentConfig.OutputPath))
                {
                    try
                    {
                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        p.StartInfo = new System.Diagnostics.ProcessStartInfo() { FileName = currentConfig.OutputPath };
                        p.Start();
                    }
                    catch { }
                }
                else
                    System.Windows.Forms.MessageBox.Show("Log file not found or it might be empty!", "Log file", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            }
        }
        #endregion
    }
}
