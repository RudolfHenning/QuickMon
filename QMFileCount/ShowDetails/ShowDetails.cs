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
        //public string CustomConfig { get; set; }
        public List<DirectoryFilterEntry> DirectorieFilters { get; set; }

        public ShowDetails()
        {
            InitializeComponent();
        }

        #region Show detail
        public void ShowDetail()
        {
            //if (CustomConfig.Length > 0)
            //{
            //    try
            //    {
            //        LoadDirFilters();
            //        //XmlDocument config = new XmlDocument();
            //        //config.LoadXml(CustomConfig);
            //        //XmlNode directoryList = config.SelectSingleNode("config/directoryList");

            //        //XmlNodeList directoriesXmlNodes = config.GetElementsByTagName("directory");
            //        //foreach (XmlNode directoryXmlNode in directoriesXmlNodes)
            //        //{
            //        //    DirectoryFilterEntry directoryFilterEntry = new DirectoryFilterEntry();
            //        //    directoryFilterEntry.FilterFullPath = directoryXmlNode.InnerText;
            //        //    if (directoryXmlNode.Attributes.GetNamedItem("warningFileCountMax") != null)
            //        //        directoryFilterEntry.WarningIndicator = int.Parse(directoryXmlNode.Attributes.GetNamedItem("warningFileCountMax").Value);
            //        //    if (directoryXmlNode.Attributes.GetNamedItem("errorFileCountMax") != null)
            //        //        directoryFilterEntry.ErrorIndicator = int.Parse(directoryXmlNode.Attributes.GetNamedItem("errorFileCountMax").Value);
            //        //    ListViewItem lvwi = new ListViewItem(directoryFilterEntry.FilterFullPath);
            //        //    lvwi.SubItems.Add("-");
            //        //    lvwi.SubItems.Add("-");
            //        //    lvwi.Tag = directoryFilterEntry;
            //        //    lvwDirectories.Items.Add(lvwi);
            //        //}
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            base.Show();
            LoadDirFilters();
            RefreshList();
        } 
        #endregion

        #region ListView events
        private void lvwDirectories_Resize(object sender, EventArgs e)
        {
            lvwDirectories.Columns[0].Width = lvwDirectories.Width - 25 - lvwDirectories.Columns[1].Width - lvwDirectories.Columns[2].Width;
        }
        private void lvwDirectories_DoubleClick(object sender, EventArgs e)
        {
            viewDirectoryToolStripMenuItem_Click(sender, e);
        }
        private void lvwDirectories_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                viewDirectoryToolStripMenuItem_Click(sender, e);
            }
        }
        #endregion

        #region Context menu events
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void viewDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem lvwi in lvwDirectories.SelectedItems)
            {
                string path = lvwi.Text;
                string filter = "*.*";
                if (path.Contains("*"))
                {
                    filter = path.Substring(path.LastIndexOf('\\') + 1);
                    path = path.Substring(0, path.LastIndexOf('\\'));
                }
                if (System.IO.Directory.Exists(path))
                {
                    System.Diagnostics.Process.Start("Explorer.exe", path.Replace("'", "''"));
                }
            }
        }
        #endregion

        #region Toolbar events
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region Local methods
        private void LoadDirFilters()
        {
            if (DirectorieFilters != null)
            {
                foreach (DirectoryFilterEntry directoryFilterEntry in DirectorieFilters)
                {
                    ListViewItem lvwi = new ListViewItem(directoryFilterEntry.FilterFullPath);
                    lvwi.SubItems.Add("-");
                    lvwi.SubItems.Add("-");
                    lvwi.Tag = directoryFilterEntry;

                    lvwDirectories.Items.Add(lvwi);
                }
            }
        }
        private void RefreshList()
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            lvwDirectories.BeginUpdate();
            foreach (ListViewItem itmX in lvwDirectories.Items)
            {
                LoadDirInfo(itmX);
            }
            lvwDirectories.EndUpdate();
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            toolStripStatusLabel1.Text = "Last updated " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void LoadDirInfo(ListViewItem itm)
        {
            //int count = 0;
            string countString="-";
            string oldValue = "-";
            try
            {
                DirectoryFilterEntry filterEntry = (DirectoryFilterEntry)itm.Tag;
                DirectoryFileInfo fileInfo = filterEntry.GetDirFileInfo();
                MonitorStates currentState = filterEntry.GetState(fileInfo);

                oldValue = itm.SubItems[1].Text;
                if (!fileInfo.Exists)
                {
                    countString = "N/A";
                }
                else
                {
                    countString = fileInfo.FileCount.ToString();
                }
                if (fileInfo.FileSize >= 0)
                {
                    itm.SubItems[2].Text = fileInfo.FileSize.ToString();
                }
                else
                {
                    itm.SubItems[2].Text = "N/A";
                }
                if (currentState == MonitorStates.Good)
                    itm.BackColor = SystemColors.Window;
                else if (currentState == MonitorStates.Warning)
                    itm.BackColor = Color.SandyBrown;
                else
                    itm.BackColor = Color.Salmon;

                //count = GetDirFileCount(itm);
                //if (count == -1)
                //{
                //    countString = "N/A";
                //}
                //else
                //{
                //    countString = count.ToString();
                //}
            }
            catch (Exception anyex)
            {
                itm.SubItems[1].Text = "err:" + anyex.Message;
            }
            //string oldValue = itm.SubItems[1].Text;
            itm.SubItems[1].Text = countString;
            if ((oldValue != "-") && (oldValue != countString))
            {
                UpdateFont(itm, new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold));
            }
            else
                UpdateFont(itm, new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular));
        }

        private void UpdateFont(ListViewItem itm, System.Drawing.Font f)
        {

            if (!itm.Font.Equals(f))
            {
                itm.Font = f;
            }
        }

        //private int GetDirFileCount(ListViewItem itm)
        //{
        //    string path = itm.Text;
        //    string filter = "*.*";
        //    if (path.Contains("*"))
        //    {
        //        filter = path.Substring(path.LastIndexOf('\\') + 1);
        //        path = path.Substring(0, path.LastIndexOf('\\'));
        //    }
        //    DirectoryFileInfo fileInfo;
        //    fileInfo.FileCount = 0;
        //    fileInfo.FileSize = 0;
        //    try
        //    {
        //        if (Directory.Exists(path))
        //        {
        //            fileInfo = SHFunctions.GetDirectoryFileInfo(path, filter);
        //        }
        //        else
        //        {
        //            fileInfo.FileCount = -1;
        //            fileInfo.FileSize = -1;
        //        }
        //    }
        //    catch
        //    {
        //        fileInfo.FileCount = -1;
        //        fileInfo.FileSize = -1;
        //    }
        //    if (fileInfo.FileSize >= 0)
        //    {
        //        itm.SubItems[2].Text = fileInfo.FileSize.ToString();
        //    }
        //    else
        //    {
        //        itm.SubItems[2].Text = "N/A";
        //    }
        //    return fileInfo.FileCount;
        //} 
        #endregion

        #region Auto refresh
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
