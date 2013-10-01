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
    public partial class ShowDetails : Form, ICollectorDetailView
    {
        public RegistryQueryConfig SelectedRegistryQueryConfig { get; set; }

        public ShowDetails()
        {
            InitializeComponent();
        }

        #region ICollectorDetailView Members
        public void ShowCollectorDetails(ICollector collector)
        {
            base.Show();
            SelectedRegistryQueryConfig = null;
            SelectedRegistryQueryConfig = ((RegistryQuery)collector).RegistryQueryConfig;
            LoadList();
            RefreshList();
            columnResizeTimer.Enabled = true;
        }
        public void RefreshConfig(ICollector collector)
        {
            SelectedRegistryQueryConfig = null;
            SelectedRegistryQueryConfig = ((RegistryQuery)collector).RegistryQueryConfig;
            LoadList();
            RefreshList();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Show();
        }
        public bool IsStillVisible()
        {
            return (!(this.Disposing || this.IsDisposed)) && this.Visible;
        }
        #endregion

        #region Form events
        private void ShowDetails_Load(object sender, EventArgs e)
        {
            
        }
        private void ShowDetails_Shown(object sender, EventArgs e)
        {
            //LoadList();
            //columnResizeTimer.Enabled = true;
        }
        #endregion

        #region Timer events
        private void columnResizeTimer_Tick(object sender, EventArgs e)
        {
            columnResizeTimer.Enabled = false;
            lvwDetails.Columns[1].Width = lvwDetails.ClientSize.Width - lvwDetails.Columns[0].Width - lvwDetails.Columns[2].Width;
        } 
        #endregion

        #region ListView events
        private void lvwDetails_Resize(object sender, EventArgs e)
        {
            columnResizeTimer.Enabled = true;
        } 
        private void lvwDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyPathToolStripMenuItem.Enabled = lvwDetails.SelectedItems.Count == 1;
            copyValueToolStripMenuItem.Enabled = lvwDetails.SelectedItems.Count == 1;
        }
        #endregion

        #region Private methods
        private void LoadList()
        {
            if (SelectedRegistryQueryConfig != null)
            {
                lvwDetails.Items.Clear();
                foreach (RegistryQueryInstance rq in SelectedRegistryQueryConfig.Queries)
                {
                    ListViewItem lvi = new ListViewItem(rq.Name);
                    lvi.SubItems.Add((rq.UseRemoteServer ? "[" + rq.Server + "]\\" : "") + RegistryQueryInstance.GetRegistryHiveFromString(rq.RegistryHive.ToString()).ToString() + "\\" + rq.Path + "\\@[" + rq.KeyName + "]");
                    lvi.SubItems.Add("-");
                    lvi.Tag = rq;
                    lvwDetails.Items.Add(lvi);
                }
            }
            RefreshList();
        }
        private void RefreshList()
        {
            try
            {
                lvwDetails.BeginUpdate();
                if (SelectedRegistryQueryConfig != null)
                {                    
                    foreach (ListViewItem lvi in lvwDetails.Items)
                    {
                        if (lvi.Tag is RegistryQueryInstance)
                        {
                            RegistryQueryInstance rq = (RegistryQueryInstance)lvi.Tag;
                            
                            try
                            {
                                object value = rq.GetValue();
                                MonitorStates currentState = rq.EvaluateValue(value);
                                if (value == null)
                                    lvi.SubItems[2].Text = "Null";
                                else
                                    lvi.SubItems[2].Text = value.ToString();
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
                                lvi.SubItems[2].Text = ex.Message;
                                lvi.ImageIndex = 2;
                                lvi.BackColor = Color.Salmon;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvwDetails.EndUpdate();
                toolStripStatusLabel1.Text = "Last updated " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        } 
        #endregion

        #region Toolbar and menu events
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList();
        } 
        #endregion

        #region Context menu events
        private void copyPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwDetails.SelectedItems.Count == 1)
            {
                Clipboard.SetText(lvwDetails.SelectedItems[0].SubItems[1].Text);
            }
        }
        private void copyValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwDetails.SelectedItems.Count == 1)
            {
                Clipboard.SetText(lvwDetails.SelectedItems[0].SubItems[2].Text);
            }
        } 
        #endregion

        #region Auto refreshing
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
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void autoRefreshToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            autoRefreshToolStripButton.Checked = autoRefreshToolStripMenuItem.Checked;
        }
        #endregion
    }
}
