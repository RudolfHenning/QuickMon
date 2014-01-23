using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Notifiers
{
    class EventLogNotifierShowViewer: INotivierViewer
    {
        #region INotivierViewer Members
        public void ShowNotifierViewer(INotifier notifier)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo() { FileName = "eventvwr.msc" };
                p.Start();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public void RefreshConfig(INotifier notifier)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo() { FileName = "eventvwr.msc" };
                p.Start();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            } 
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
            throw new NotImplementedException();
        }

        #endregion
    }
}
