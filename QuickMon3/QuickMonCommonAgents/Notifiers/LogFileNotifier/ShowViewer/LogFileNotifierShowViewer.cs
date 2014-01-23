using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuickMon.Notifiers
{
    public class LogFileNotifierShowViewer : INotivierViewer
    {

        #region INotivierViewer Members
        public void ShowNotifierViewer(INotifier notifier)
        {
            ShowViewer(notifier);
        }
        public void RefreshConfig(INotifier notifier)
        {
            ShowViewer(notifier);
        }
        public bool IsStillVisible()
        {
            return false;
        }
        public void SetWindowTitle(string title)
        {

        }
        public void CloseWindow()
        {
            
        }
        public void LoadDisplayData()
        {
            
        }
        public void RefreshDisplayData()
        {
            
        }
        #endregion

        private void ShowViewer(INotifier notifier)
        {
            LogFileNotifierConfig currentConfig = (LogFileNotifierConfig)notifier.AgentConfig;
            if (File.Exists(currentConfig.OutputPath))
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo() { FileName = currentConfig.OutputPath };
                p.Start();
            }
        }
    }
}
