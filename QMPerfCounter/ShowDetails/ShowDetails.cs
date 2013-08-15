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
    public partial class ShowDetails : Form
    {
        public PerfCounterConfig PFConfig { get; set; }

        public ShowDetails()
        {
            InitializeComponent();
            PFConfig = new PerfCounterConfig();
        }

        #region Form events
        private void ShowDetails_Shown(object sender, EventArgs e)
        {
            RefreshList();
            lvwPerfCounters_Resize(null, null);
        }
        private void ShowDetails_Load(object sender, EventArgs e)
        {
            foreach (var pc in PFConfig.QMPerfCounters)
            {
                ListViewItem lvi = new ListViewItem(pc.ToString());
                lvi.ImageIndex = 0;
                lvi.SubItems.Add("-");
                lvi.SubItems.Add(pc.WarningValue.ToString("F1") + "/" + pc.ErrorValue.ToString("F1"));
                lvi.Tag = pc;
                lvwPerfCounters.Items.Add(lvi);
            }
        }
        #endregion

        #region ListView events
        private void lvwPerfCounters_Resize(object sender, EventArgs e)
        {
            lvwPerfCounters.Columns[0].Width = lvwPerfCounters.ClientSize.Width - lvwPerfCounters.Columns[1].Width - lvwPerfCounters.Columns[2].Width;
        }
        #endregion

        #region Toolbar buttons
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region Private methods
        private void RefreshList()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                lvwPerfCounters.BeginUpdate();
                foreach (ListViewItem lvi in lvwPerfCounters.Items)
                {
                    try
                    {
                        QMPerfCounterInstance pc = (QMPerfCounterInstance)lvi.Tag;
                        float currentValue = pc.GetNextValue();
                        lvi.SubItems[1].Text = currentValue.ToString("F3");
                        MonitorStates currentState = pc.GetState(currentValue);
                        if (currentState == MonitorStates.Good)
                        {
                            lvi.ImageIndex = 0;
                            lvi.BackColor = SystemColors.Window;
                        }
                        else if (currentState == MonitorStates.Warning)
                        {
                            lvi.ImageIndex = 1;
                            lvi.BackColor = Color.SandyBrown;
                        }
                        else
                        {
                            lvi.ImageIndex = 2;
                            lvi.BackColor = Color.Salmon;
                        }
                    }
                    catch (Exception ex)
                    {
                        lvi.SubItems[1].Text = ex.Message;
                    }
                }
                toolStripStatusLabel1.Text = "Last updated: " + DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lvwPerfCounters.EndUpdate();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Auto refreshing
        private void autoRefreshtoolStripButton_CheckStateChanged(object sender, EventArgs e)
        {
            autoRefreshToolStripMenuItem.Checked = autoRefreshtoolStripButton.Checked;
            if (autoRefreshtoolStripButton.Checked)
            {
                refreshTimer.Enabled = false;
                refreshTimer.Enabled = true;
                autoRefreshtoolStripButton.BackColor = Color.LightGreen;
            }
            else
            {
                refreshTimer.Enabled = false;
                autoRefreshtoolStripButton.BackColor = SystemColors.Control;
            }
        }
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void autoRefreshToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            autoRefreshtoolStripButton.Checked = autoRefreshToolStripMenuItem.Checked;
        } 
        #endregion
    }
}
