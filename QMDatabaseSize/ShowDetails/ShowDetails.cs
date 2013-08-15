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
        public ShowDetails()
        {
            InitializeComponent();
        }

        public string SqlServer { get; set; }
        public bool IntegratedSec { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CmndTimeOut { get; set; }
        public List<DatabaseEntry> Databases { get; set; }

        #region Form events
        private void ShowDetails_Load(object sender, EventArgs e)
        {
            LoadDatabases();
        }
        private void ShowDetails_Shown(object sender, EventArgs e)
        {
            RefreshList();
            ShowDetails_Resize(null, null);
        }
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
        private void LoadDatabases()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lvwDatabases.BeginUpdate();
                lvwDatabases.Items.Clear();
                lvwDatabases.Groups.Clear();
                ListViewGroup group = new ListViewGroup(SqlServer, SqlServer);
                lvwDatabases.Groups.Add(group);
                foreach (DatabaseEntry dbe in Databases)
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
                databaseSizeInfo.OpenConnection(SqlServer, IntegratedSec, UserName, Password, CmndTimeOut);
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
