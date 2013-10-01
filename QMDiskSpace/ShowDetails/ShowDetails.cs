using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QuickMon
{
    public partial class ShowDetails : Form, ICollectorDetailView
    {        
        public List<DriveSpaceEntry> Drives { get; set; }
        public ShowDetails()
        {
            InitializeComponent();
        }

        #region ICollectorDetailView Members
        public void ShowCollectorDetails(ICollector collector)
        {
            base.Show();
            Drives = null;
            Drives = ((DiskSpace)collector).Drives;
            LoadList();
            RefreshList();
        }
        public void RefreshConfig(ICollector collector)
        {
            Drives = null;
            Drives = ((DiskSpace)collector).Drives;
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

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void LoadList()
        {
            if (Drives != null)
            {
                lvwDrives.Items.Clear();
                foreach (DriveSpaceEntry dse in Drives)
                {
                    ListViewItem lvi = new ListViewItem(dse.DriveLetter);
                    lvi.SubItems.Add("N/A");
                    lvi.SubItems.Add("N/A");
                    lvi.Tag = dse;
                    lvwDrives.Items.Add(lvi);
                }
            }
        }
        private void RefreshList()
        {
            foreach (ListViewItem lvi in lvwDrives.Items)
            {
                if (lvi.Tag != null && lvi.Tag is DriveSpaceEntry)
                {
                    try
                    {
                        DriveSpaceEntry dse = (DriveSpaceEntry)lvi.Tag;
                        DriveInfo di = new DriveInfo(dse.DriveLetter);
                        if (di.IsReady)
                        {
                            lvi.SubItems[1].Text = (di.TotalFreeSpace / 1048576).ToString("N0");
                            lvi.SubItems[2].Text = di.DriveType.ToString();
                        }
                        else
                        {
                            lvi.SubItems[1].Text = "N/A";
                            lvi.SubItems[2].Text = "Drive not available!";
                        }
                    }
                    catch (Exception ex)
                    {
                        lvi.SubItems[1].Text = "Err";
                        lvi.SubItems[2].Text = ex.Message;
                    }
                }
            }
        }

        private void ShowDetails_Shown(object sender, EventArgs e)
        {

        }
    }
}
