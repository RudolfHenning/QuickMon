using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public class BaseDetailView: Form, INotivierViewer, ICollectorDetailView
    {
        public ICollector Collector { get; set; }
        public INotifier Notifier { get; set; }

        public BaseDetailView()
        {
            LocalInitializeComponent();
        }

        private void LocalInitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseDetailView
            // 
            this.Name = "Detail View";
            this.Text = "Detail View";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #region Generic Interface methods
        public bool IsStillVisible()
        {
            return (!(this.Disposing || this.IsDisposed)) && this.Visible;
        }
        public void SetWindowTitle(string title)
        {
            this.Text = title;
        }
        public void CloseWindow()
        {
            this.Close();
        }
        #endregion

        #region Interfaces Members
        public void ShowNotifierViewer(INotifier notifier)
        {
            Notifier = notifier;
            Show();
            LoadDisplayData();
            RefreshDisplayData();
        }
        public void ShowCollectorDetails(ICollector collector)
        {
            Collector = collector;
            Show();
            LoadDisplayData();
            RefreshDisplayData();
        }
        public void RefreshConfig(INotifier notifier)
        {
            this.Notifier = null;
            this.Notifier = notifier;
            LoadDisplayData();
            RefreshDisplayData();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }
        public void RefreshConfig(ICollector collector)
        {
            this.Collector = null;
            this.Collector = collector;
            LoadDisplayData();
            RefreshDisplayData();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }
        public virtual void RefreshDisplayData() { }
        public virtual void LoadDisplayData() { }
        #endregion
    }
}
