﻿using QuickMon.Notifiers;
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

    public class LogFileNotifierUIViewer : NotifierNoViewerBase
    {
        #region IChildWindowIdentity
        public  override void ShowChildWindow(IParentWindow parentWindow = null)
        {
            //if (ParentWindow != null)
            //    ParentWindow.RegisterChildWindow(this);
            if (SelectedNotifier != null)
            {
                LogFileNotifier thisNotifier = (LogFileNotifier)SelectedNotifier;
                LogFileNotifierConfig currentConfig = (LogFileNotifierConfig)thisNotifier.AgentConfig;
                if (File.Exists(currentConfig.GetCurrentLogFileName()))
                {
                    try
                    {
                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        p.StartInfo = new System.Diagnostics.ProcessStartInfo() { FileName = currentConfig.GetCurrentLogFileName() };
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
