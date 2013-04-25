using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace QuickMon
{
    public partial class EditConfig : Form
    {
        public EditConfig()
        {
            InitializeComponent();
        }

        public string CustomConfig { get; set; }

        public DialogResult ShowConfig()
        {
            if (CustomConfig.Length > 0)
            {
                try
                {
                    foreach(DirectoryFilterEntry de in ReadConfig())
                    {
                        ListViewItem lvi = new ListViewItem(de.FilterFullPath);
                        lvi.SubItems.Add(de.CountWarningIndicator.ToString());
                        lvi.SubItems.Add(de.CountErrorIndicator.ToString());
                        lvi.SubItems.Add(de.SizeKBWarningIndicator.ToString());
                        lvi.SubItems.Add(de.SizeKBErrorIndicator.ToString());
                        lvi.SubItems.Add(de.FileMinAgeSec.ToString());
                        lvi.SubItems.Add(de.FileMaxAgeSec.ToString());
                        lvi.SubItems.Add(de.FileMinSizeKB.ToString());
                        lvi.SubItems.Add(de.FileMaxSizeKB.ToString());
                        lvi.Tag = de;

                        lvwDirectories.Items.Add(lvi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ShowDialog();
        }

        private List<DirectoryFilterEntry> ReadConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(CustomConfig);
            List<DirectoryFilterEntry> directorieFilters = new List<DirectoryFilterEntry>();
            System.Xml.XmlElement root = config.DocumentElement;
            foreach (XmlElement host in root.SelectNodes("directoryList/directory"))
            {
                DirectoryFilterEntry directoryFilterEntry = new DirectoryFilterEntry();
                directoryFilterEntry.FilterFullPath = host.Attributes.GetNamedItem("directoryPathFilter").Value;
                directoryFilterEntry.DirectoryExistOnly = bool.Parse(host.ReadXmlElementAttr("testDirectoryExistOnly", "False"));

                int tmp = 0;
                if (int.TryParse(host.ReadXmlElementAttr("warningFileCountMax", "0"), out tmp))
                    directoryFilterEntry.CountWarningIndicator = tmp;
                if (int.TryParse(host.ReadXmlElementAttr("errorFileCountMax", "0"), out tmp))
                    directoryFilterEntry.CountErrorIndicator = tmp;
                long tmpl;

                if (long.TryParse(host.ReadXmlElementAttr("warningFileSizeMaxKB", "0"), out tmpl))
                    directoryFilterEntry.SizeKBWarningIndicator = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("errorFileSizeMaxKB", "0"), out tmpl))
                    directoryFilterEntry.SizeKBErrorIndicator = tmpl;

                if (long.TryParse(host.ReadXmlElementAttr("fileMaxAgeSec", "0"), out tmpl))
                    directoryFilterEntry.FileMaxAgeSec = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("fileMinAgeSec", "0"), out tmpl))
                    directoryFilterEntry.FileMinAgeSec = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("fileMinSizeKB", "0"), out tmpl))
                    directoryFilterEntry.FileMinSizeKB = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("fileMaxSizeKB", "0"), out tmpl))
                    directoryFilterEntry.FileMaxSizeKB = tmpl;

                directorieFilters.Add(directoryFilterEntry);
            }
            return directorieFilters;
        }

        private void lvwDirectories_Resize(object sender, EventArgs e)
        {
            //lvwDirectories.Columns[0].Width = lvwDirectories.Width - 25 - lvwDirectories.Columns[1].Width - lvwDirectories.Columns[2].Width;
        }

        private void lvwDirectories_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdEdit.Enabled = (lvwDirectories.SelectedItems.Count > 0);
            cmdRemove.Enabled = (lvwDirectories.SelectedItems.Count > 0);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml("<config><directoryList></directoryList></config>");
            XmlNode directoryList = config.SelectSingleNode("config/directoryList");
            foreach (ListViewItem lvi in lvwDirectories.Items)
            {
                DirectoryFilterEntry de = (DirectoryFilterEntry)lvi.Tag;
                XmlNode directoryXmlNode = config.CreateElement("directory");                

                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("directoryPathFilter", de.FilterFullPath));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("testDirectoryExistOnly", de.DirectoryExistOnly));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("warningFileCountMax", de.CountWarningIndicator));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("errorFileCountMax", de.CountErrorIndicator));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("warningFileSizeMaxKB", de.SizeKBWarningIndicator));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("errorFileSizeMaxKB", de.SizeKBErrorIndicator));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("fileMinAgeSec", de.FileMinAgeSec));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("fileMaxAgeSec", de.FileMaxAgeSec));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("fileMinSizeKB", de.FileMinSizeKB));
                directoryXmlNode.Attributes.Append(config.CreateAttributeWithValue("fileMaxSizeKB", de.FileMaxSizeKB));

                directoryList.AppendChild(directoryXmlNode);
            }

            CustomConfig = config.OuterXml;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            EditDirectory editDirectory = new EditDirectory();
            if (editDirectory.ShowDirectoryDetail() == DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editDirectory.SelectedDirectoryFilterEntry.FilterFullPath);
                lvi.SubItems.Add(editDirectory.SelectedDirectoryFilterEntry.CountWarningIndicator.ToString());
                lvi.SubItems.Add(editDirectory.SelectedDirectoryFilterEntry.CountErrorIndicator.ToString());
                lvi.SubItems.Add(editDirectory.SelectedDirectoryFilterEntry.SizeKBWarningIndicator.ToString());
                lvi.SubItems.Add(editDirectory.SelectedDirectoryFilterEntry.SizeKBErrorIndicator.ToString());
                lvi.SubItems.Add(editDirectory.SelectedDirectoryFilterEntry.FileMinAgeSec.ToString());
                lvi.SubItems.Add(editDirectory.SelectedDirectoryFilterEntry.FileMaxAgeSec.ToString());
                lvi.SubItems.Add(editDirectory.SelectedDirectoryFilterEntry.FileMinSizeKB.ToString());
                lvi.SubItems.Add(editDirectory.SelectedDirectoryFilterEntry.FileMaxSizeKB.ToString());
                lvi.Tag = editDirectory.SelectedDirectoryFilterEntry;

                lvwDirectories.Items.Add(lvi);
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (lvwDirectories.SelectedItems.Count > 0)
            {
                EditDirectory editDirectory = new EditDirectory();
                editDirectory.SelectedDirectoryFilterEntry = (DirectoryFilterEntry)lvwDirectories.SelectedItems[0].Tag;

                if (editDirectory.ShowDirectoryDetail() == DialogResult.OK)
                {
                    ListViewItem lvi = lvwDirectories.SelectedItems[0];
                    lvi.Text = editDirectory.SelectedDirectoryFilterEntry.FilterFullPath;
                    lvi.SubItems[1].Text = editDirectory.SelectedDirectoryFilterEntry.CountWarningIndicator.ToString();
                    lvi.SubItems[2].Text = editDirectory.SelectedDirectoryFilterEntry.CountErrorIndicator.ToString();
                    lvi.SubItems[3].Text = editDirectory.SelectedDirectoryFilterEntry.SizeKBWarningIndicator.ToString();
                    lvi.SubItems[4].Text = editDirectory.SelectedDirectoryFilterEntry.SizeKBErrorIndicator.ToString();
                    lvi.SubItems[5].Text = editDirectory.SelectedDirectoryFilterEntry.FileMinAgeSec.ToString();
                    lvi.SubItems[6].Text = editDirectory.SelectedDirectoryFilterEntry.FileMaxAgeSec.ToString();
                    lvi.SubItems[7].Text = editDirectory.SelectedDirectoryFilterEntry.FileMinSizeKB.ToString();
                    lvi.SubItems[8].Text = editDirectory.SelectedDirectoryFilterEntry.FileMaxSizeKB.ToString();
                    lvi.Tag = editDirectory.SelectedDirectoryFilterEntry;
                }
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (lvwDirectories.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to remove this entry(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwDirectories.SelectedItems)
                    {
                        lvwDirectories.Items.Remove(lvi);
                    }
                }
            }
        }

        //private string GetDirectoryFromPath(string path)
        //{
        //    string directory = path;
        //    if (path.Contains("*"))
        //    {
        //        directory = path.Substring(0, path.LastIndexOf('\\')).Trim();
        //    }
        //    return directory;
        //}
        //private string GetFilterFromPath(string path)
        //{
        //    string filter = "*.*";
        //    if (path.Contains("*"))
        //    {
        //        filter = path.Substring(path.LastIndexOf('\\') + 1).Trim();
        //    }
        //    return filter;
        //}
    }
}
