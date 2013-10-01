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
        public TableSizeConfig TableSizeConfig { get; set; }

        public ShowDetails()
        {
            InitializeComponent();
        }

        #region ICollectorDetailView Members
        public void ShowCollectorDetails(ICollector collector)
        {
            base.Show();
            TableSizeConfig = null;
            TableSizeConfig = ((SQLTableSize)collector).TableSizeConfig;
            //LoadList();
            RefreshList();
            //ShowDetails_Resize(null, null);
        }
        public void RefreshConfig(ICollector collector)
        {
            TableSizeConfig = null;
            TableSizeConfig = ((SQLTableSize)collector).TableSizeConfig;
            //LoadList();
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
        private void ShowDetails_Shown(object sender, EventArgs e)
        {
            //RefreshList();
            timerColumnWidthChanged.Enabled = true;
        }
        #endregion

        #region ListView events
        private void lvwDatabases_Resize(object sender, EventArgs e)
        {
            timerColumnWidthChanged.Enabled = false;
            timerColumnWidthChanged.Enabled = true;
        }
        #endregion

        #region Timer events
        private void timerColumnWidthChanged_Tick(object sender, EventArgs e)
        {
            timerColumnWidthChanged.Enabled = false;
            lvwDatabases.Columns[0].Width = lvwDatabases.ClientSize.Width - lvwDatabases.Columns[1].Width;
        }
        #endregion        

        #region Toolbar events
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        } 
        #endregion

        #region Private methods
        private void RefreshList()
        {
            lvwDatabases.Items.Clear();
            lvwDatabases.Groups.Clear();
            if (TableSizeConfig != null)
            {
                foreach (DatabaseEntry db in TableSizeConfig.DatabaseEntries)
                {
                    List<TableSizeInfo> tableSizes;
                    try
                    {
                        tableSizes = db.GetTableRowCount();
                    }
                    catch { tableSizes = new List<TableSizeInfo>(); }
                    ListViewGroup group = new ListViewGroup(db.ToString(), db.ToString());
                    lvwDatabases.Groups.Add(group);
                    foreach (TableSizeEntry tableEntry in (from t in db.TableSizeEntries
                                                           orderby t.TableName
                                                           select t))
                    {
                        TableSizeInfo tableSizeInfo = (from ti in tableSizes
                                                       where ti.Name == tableEntry.TableName
                                                       select ti).FirstOrDefault();

                        ListViewItem lvi = new ListViewItem(tableEntry.TableName);
                        lvi.Group = group;
                        if (tableSizeInfo == null)
                        {
                            lvi.SubItems.Add("Table not found!");
                            lvi.ImageIndex = 2;
                        }
                        else
                        {
                            lvi.SubItems.Add(tableSizeInfo.Rows.ToString());
                            if (tableSizeInfo.Rows >= tableEntry.ErrorValue)
                                lvi.ImageIndex = 2;
                            else if (tableSizeInfo.Rows >= tableEntry.WarningValue)
                                lvi.ImageIndex = 1;
                            else
                                lvi.ImageIndex = 0;
                        }
                        lvwDatabases.Items.Add(lvi);
                    }
                }
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
