using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class CollectorDetailViewBase : Form, ICollectorDetailView 
    {
        public CollectorDetailViewBase()
        {
            InitializeComponent();
        }

        #region ICollectorDetailView Members
        public virtual void ShowCollectorDetails(ICollector Collector)
        {
            throw new NotImplementedException();
        }

        public virtual void RefreshConfig(ICollector Collector)
        {
            throw new NotImplementedException();
        }

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

        #region Toolbar events
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void autoRefreshToolStripButton_CheckStateChanged(object sender, EventArgs e)
        {
            autoRefreshToolStripMenuItem.Checked = autoRefreshToolStripButton.Checked;
            if (autoRefreshToolStripButton.Checked)
            {
                refreshTimer.Enabled = false;
                refreshTimer.Enabled = true;
                autoRefreshToolStripButton.BackColor = Color.LightGreen;
            }
            else
            {
                refreshTimer.Enabled = false;
                autoRefreshToolStripButton.BackColor = SystemColors.Control;
            }
        }
        #endregion

        public virtual void RefreshList()
        {
        }


        #region ICollectorDetailView Members


        public void LoadDisplayData()
        {
            throw new NotImplementedException();
        }

        public void RefreshDisplayData()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
