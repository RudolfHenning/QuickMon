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
        public ShowDetails()
        {
            InitializeComponent();
        }

        public DatabaseSizeConfig DatabaseSizeConfig { get; set; }

        #region ICollectorDetailView Members
        public void ShowCollectorDetails(ICollector collector)
        {
            base.Show();
            DatabaseSizeConfig = null;
            DatabaseSizeConfig = ((DatabaseSize)collector).DatabaseSizeConfig;
            LoadList();
            RefreshList();
            ShowDetails_Resize(null, null);
        }
        public void RefreshConfig(ICollector collector)
        {
            DatabaseSizeConfig = null;
            DatabaseSizeConfig = ((DatabaseSize)collector).DatabaseSizeConfig;
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
        private void ShowDetails_Resize(object sender, EventArgs e)
        {
            lvwDatabases.Columns[0].Width = lvwDatabases.ClientSize.Width - lvwDatabases.Columns[1].Width;
        }
        #endregion

        #region Toolbar events
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        } 
        #endregion

        #region Private events
        private void LoadList()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lvwDatabases.BeginUpdate();
                lvwDatabases.Items.Clear();
                lvwDatabases.Groups.Clear();
                ListViewGroup group = new ListViewGroup(DatabaseSizeConfig.SqlServer, DatabaseSizeConfig.SqlServer);
                lvwDatabases.Groups.Add(group);
                foreach (DatabaseEntry dbe in DatabaseSizeConfig.Databases)
                {
                    ListViewItem lvi = new ListViewItem(dbe.Name);
                    lvi.Group = group;
                    lvi.SubItems.Add("-");
                    lvi.Tag = dbe;
                    lvwDatabases.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvwDatabases.EndUpdate();
                Cursor.Current = Cursors.Default;
            }
        }
        private void RefreshList()
        {
            try
            {
                lvwDatabases.BeginUpdate();
                Cursor.Current = Cursors.WaitCursor;

                DatabaseSizeInfo databaseSizeInfo = new DatabaseSizeInfo();
                databaseSizeInfo.OpenConnection(DatabaseSizeConfig.SqlServer, DatabaseSizeConfig.IntegratedSec, DatabaseSizeConfig.UserName, DatabaseSizeConfig.Password, DatabaseSizeConfig.CmndTimeOut);
                foreach (ListViewItem lvi in lvwDatabases.Items)
                {
                    DatabaseEntry dbe = (DatabaseEntry)lvi.Tag;
                    try
                    {
                        long size = databaseSizeInfo.GetDatabaseSize(dbe.Name);
                        lvi.SubItems[1].Text = size.ToString();
                        if (size >= dbe.ErrorSizeMB)
                        {
                            lvi.ImageIndex = 2;
                            lvi.BackColor = Color.Salmon;
                        }
                        else if (size >= dbe.WarningSizeMB)
                        {
                            lvi.ImageIndex = 1;
                            lvi.BackColor = Color.SandyBrown;
                        }
                        else
                        {
                            lvi.ImageIndex = 0;
                            lvi.BackColor = SystemColors.Window;
                        }
                    }
                    catch (Exception innerEx)
                    {
                        lvi.SubItems[1].Text = innerEx.Message;
                        lvi.ImageIndex = 2;
                        lvi.BackColor = Color.Salmon;
                    }
                }
                databaseSizeInfo.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvwDatabases.EndUpdate();
                Cursor.Current = Cursors.Default;
                toolStripStatusLabel1.Text = "Last updated " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
