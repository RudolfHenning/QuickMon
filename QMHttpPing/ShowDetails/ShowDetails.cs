using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace QuickMon
{
    public partial class ShowDetails : Form
    {
        public HttpPingConfig HttpPingConfig { get; set; }

        public ShowDetails()
        {
            InitializeComponent();
        }

        #region Form events
        private void ShowDetails_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        private void ShowDetails_Shown(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region ListView events
        private void ShowDetails_Resize(object sender, EventArgs e)
        {
            lvwHosts.Columns[0].Width = lvwHosts.Width - 25 - lvwHosts.Columns[1].Width;
        }
        #endregion

        #region Context menu events
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region Toolbar events
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region Local methods
        private void LoadList()
        {
            if (HttpPingConfig != null)
            {
                foreach (HttpPingEntry httpPingEntry in HttpPingConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(httpPingEntry.Url);
                    lvi.UseItemStyleForSubItems = false;
                    lvi.SubItems.Add("-");
                    lvi.Tag = httpPingEntry;
                    lvwHosts.Items.Add(lvi);
                }
            }
        } 
        private void RefreshList()
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            lvwHosts.BeginUpdate();
            foreach (ListViewItem itmX in lvwHosts.Items)
            {
                HttpPingEntry httpPingEntry = (HttpPingEntry)itmX.Tag;
                try
                {
                    int pingTime = httpPingEntry.Ping();
                    
                    itmX.SubItems[1].Text = pingTime.ToString();
                    if (pingTime > httpPingEntry.TimeOut)
                    {
                        itmX.SubItems[1].ForeColor = Color.Red;
                        itmX.SubItems[1].Text = "Time-out";
                    }
                    else if (pingTime > httpPingEntry.MaxTime)
                    {
                        itmX.SubItems[1].ForeColor = Color.DarkRed;
                    }
                    else
                    {
                        itmX.SubItems[1].ForeColor = SystemColors.WindowText;
                    }

                }
                catch (Exception ex)
                {
                    itmX.SubItems[1].Text = ex.Message;
                    itmX.SubItems[1].ForeColor = Color.Red;
                }
            }
            lvwHosts.EndUpdate();
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            toolStripStatusLabel1.Text = "Last updated " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion       
        
    }
}
