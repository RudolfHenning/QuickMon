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

            //XmlDocument config = new XmlDocument();
            //config.LoadXml(CustomConfig);
            //System.Xml.XmlElement root = config.DocumentElement;
            //foreach (System.Xml.XmlElement host in root.SelectNodes("directoryList/directory"))
            //{
            //    DirectoryFilterEntry directoryFilterEntry = new DirectoryFilterEntry();
            //    directoryFilterEntry.FilterFullPath = host.Attributes.GetNamedItem("directoryPathFilter").Value;

            //    int tmp = 0;
            //    if (int.TryParse(host.ReadXmlElementAttr("warningFileCountMax", "0"), out tmp))
            //        directoryFilterEntry.CountWarningIndicator = tmp;
            //    if (int.TryParse(host.ReadXmlElementAttr("errorFileCountMax", "0"), out tmp))
            //        directoryFilterEntry.CountErrorIndicator = tmp;
            //    long tmpl;

            //    if (long.TryParse(host.ReadXmlElementAttr("warningFileSizeMaxKB", "0"), out tmpl))
            //        directoryFilterEntry.SizeKBWarningIndicator = tmpl;
            //    if (long.TryParse(host.ReadXmlElementAttr("errorFileSizeMaxKB", "0"), out tmpl))
            //        directoryFilterEntry.SizeKBErrorIndicator = tmpl;

            //    if (long.TryParse(host.ReadXmlElementAttr("fileMaxAgeSec", "0"), out tmpl))
            //        directoryFilterEntry.FileMaxAgeSec = tmpl;
            //    if (long.TryParse(host.ReadXmlElementAttr( "fileMinAgeSec", "0"), out tmpl))
            //        directoryFilterEntry.FileMinAgeSec = tmpl;
            //    if (long.TryParse(host.ReadXmlElementAttr("fileMinSizeKB", "0"), out tmpl))
            //        directoryFilterEntry.FileMinSizeKB = tmpl;
            //    if (long.TryParse(host.ReadXmlElementAttr("fileMaxSizeKB", "0"), out tmpl))
            //        directoryFilterEntry.FileMaxSizeKB = tmpl;

            //    ListViewItem lvwi = new ListViewItem(directoryFilterEntry.FilterFullPath);
            //    lvwi.SubItems.Add("-");
            //    lvwi.SubItems.Add("-");
            //    lvwi.Tag = directoryFilterEntry;

            //    lvwDirectories.Items.Add(lvwi);
            //}
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
            int count = 0;
            string countString;
            try
            {
                count = GetDirFileCount(itm);
                if (count == -1)
                {
                    countString = "N/A";
                }
                else
                {
                    countString = count.ToString();
                }
            }
            catch (Exception anyex)
            {
                countString = "err:" + anyex.Message;
            }
            string oldValue = itm.SubItems[1].Text;
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

        private int GetDirFileCount(ListViewItem itm)
        {
            string path = itm.Text;
            string filter = "*.*";
            if (path.Contains("*"))
            {
                filter = path.Substring(path.LastIndexOf('\\') + 1);
                path = path.Substring(0, path.LastIndexOf('\\'));
            }
            DirectoryFileInfo fileInfo;
            fileInfo.FileCount = 0;
            fileInfo.FileSize = 0;
            try
            {
                if (Directory.Exists(path))
                {
                    fileInfo = SHFunctions.GetDirectoryFileInfo(path, filter);
                }
                else
                {
                    fileInfo.FileCount = -1;
                    fileInfo.FileSize = -1;
                }
            }
            catch
            {
                fileInfo.FileCount = -1;
                fileInfo.FileSize = -1;
            }
            if (fileInfo.FileSize >= 0)
            {
                itm.SubItems[2].Text = fileInfo.FileSize.ToString();
            }
            else
            {
                itm.SubItems[2].Text = "N/A";
            }
            return fileInfo.FileCount;
        } 
        #endregion
        
    }
}
