using System;
using System.Drawing;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class FileSystemCollectorViewDetails : SimpleDetailView, ICollectorDetailView
    {
        public FileSystemCollectorViewDetails()
        {
            InitializeComponent();
            refreshContextMenuStrip.Items.AddRange(new ToolStripItem[] {
                toolStripMenuItem1,
                exploreToolStripMenuItem});
        }

        #region ICollectorDetailView Members
        public override void LoadDisplayData()
        {
            if (Collector != null && Collector.AgentConfig != null && ((FileSystemCollectorConfig)Collector.AgentConfig).Entries != null)
            {
                FileSystemCollectorConfig fscc = (FileSystemCollectorConfig)Collector.AgentConfig;
                lvwEntries.Items.Clear();
                foreach (FileSystemDirectoryFilterEntry directoryFilterEntry in fscc.Entries)
                {
                    ListViewItem lvwi = new ListViewItem(directoryFilterEntry.FilterFullPath);
                    if (directoryFilterEntry.DirectoryExistOnly)
                        lvwi.Text += " (Exists only)";
                    lvwi.SubItems.Add("-");
                    lvwi.SubItems.Add("-");
                    lvwi.Tag = directoryFilterEntry;

                    lvwEntries.Items.Add(lvwi);
                }                
            }
        }
        public override void RefreshDisplayData()
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            lvwEntries.BeginUpdate();
            foreach (ListViewItem itmX in lvwEntries.Items)
            {
                LoadDirInfo(itmX);
            }
            lvwEntries.EndUpdate();
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            toolStripStatusLabelDetails.Text = "Last updated " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); base.RefreshDisplayData();
        }
        #endregion

        #region Private methods
        private void LoadDirInfo(ListViewItem itm)
        {
            //int count = 0;
            string countString = "-";
            string oldValue = "-";
            try
            {
                FileSystemDirectoryFilterEntry filterEntry = (FileSystemDirectoryFilterEntry)itm.Tag;
                DirectoryFileInfo fileInfo = filterEntry.GetDirFileInfo();
                CollectorState currentState = filterEntry.GetState(fileInfo);

                oldValue = itm.SubItems[1].Text;
                if (!fileInfo.Exists)
                {
                    if (filterEntry.DirectoryExistOnly)
                        countString = "No";
                    else
                        countString = "N/A";
                }
                else
                {
                    if (filterEntry.DirectoryExistOnly)
                        countString = "Yes";
                    else
                        countString = fileInfo.FileCount.ToString();
                }
                if (!filterEntry.DirectoryExistOnly && fileInfo.FileSize >= 0)
                {
                    itm.SubItems[2].Text = (fileInfo.FileSize/1024).ToString();
                }
                else
                {
                    itm.SubItems[2].Text = "N/A";
                }
                if (currentState == CollectorState.Good)
                    itm.BackColor = SystemColors.Window;
                else if (currentState == CollectorState.Warning)
                    itm.BackColor = Color.SandyBrown;
                else
                    itm.BackColor = Color.Salmon;
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
        #endregion

        private void lvwEntries_DoubleClick(object sender, EventArgs e)
        {
            if (lvwEntries.SelectedItems.Count == 1)
            {
                FileSystemDirectoryFilterEntry filterEntry = (FileSystemDirectoryFilterEntry)lvwEntries.SelectedItems[0].Tag;
                if (System.IO.Directory.Exists ( filterEntry.DirectoryPath))
                {
                    System.Diagnostics.Process.Start("Explorer.exe", filterEntry.DirectoryPath.Replace("'", "''"));
                }
            }
        }

        private void lvwEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            exploreToolStripMenuItem.Enabled = lvwEntries.SelectedItems.Count == 1;
        }

        private void exploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvwEntries_DoubleClick(sender, e);
        }
    }
}
