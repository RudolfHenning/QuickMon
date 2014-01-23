using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class FileSystemCollectorEditConfig : SimpleListEditConfig
    {
        public FileSystemCollectorEditConfig()
        {
            InitializeComponent();
        }

        #region Overrides
        public override void LoadList()
        {
            try
            {
                if (SelectedConfig != null)
                {
                    FileSystemCollectorConfig fscc = (FileSystemCollectorConfig)SelectedConfig;
                    foreach (FileSystemDirectoryFilterEntry de in fscc.Entries)
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

                        lvwEntries.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.LoadList();
        }
        public override void AddItem()
        {
            FileSystemCollectorEditFilterEntry editDirectory = new FileSystemCollectorEditFilterEntry();
            if (editDirectory.ShowDialog() == DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editDirectory.SelectedFilterEntry.FilterFullPath);
                lvi.SubItems.Add(editDirectory.SelectedFilterEntry.CountWarningIndicator.ToString());
                lvi.SubItems.Add(editDirectory.SelectedFilterEntry.CountErrorIndicator.ToString());
                lvi.SubItems.Add(editDirectory.SelectedFilterEntry.SizeKBWarningIndicator.ToString());
                lvi.SubItems.Add(editDirectory.SelectedFilterEntry.SizeKBErrorIndicator.ToString());
                lvi.SubItems.Add(editDirectory.SelectedFilterEntry.FileMinAgeSec.ToString());
                lvi.SubItems.Add(editDirectory.SelectedFilterEntry.FileMaxAgeSec.ToString());
                lvi.SubItems.Add(editDirectory.SelectedFilterEntry.FileMinSizeKB.ToString());
                lvi.SubItems.Add(editDirectory.SelectedFilterEntry.FileMaxSizeKB.ToString());
                lvi.Tag = editDirectory.SelectedFilterEntry;

                lvwEntries.Items.Add(lvi);
            }
        }
        public override void EditItem()
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                FileSystemCollectorEditFilterEntry editDirectory = new FileSystemCollectorEditFilterEntry();
                editDirectory.SelectedFilterEntry = (FileSystemDirectoryFilterEntry)lvwEntries.SelectedItems[0].Tag;

                if (editDirectory.ShowDialog() == DialogResult.OK)
                {
                    ListViewItem lvi = lvwEntries.SelectedItems[0];
                    lvi.Text = editDirectory.SelectedFilterEntry.FilterFullPath;
                    lvi.SubItems[1].Text = editDirectory.SelectedFilterEntry.CountWarningIndicator.ToString();
                    lvi.SubItems[2].Text = editDirectory.SelectedFilterEntry.CountErrorIndicator.ToString();
                    lvi.SubItems[3].Text = editDirectory.SelectedFilterEntry.SizeKBWarningIndicator.ToString();
                    lvi.SubItems[4].Text = editDirectory.SelectedFilterEntry.SizeKBErrorIndicator.ToString();
                    lvi.SubItems[5].Text = editDirectory.SelectedFilterEntry.FileMinAgeSec.ToString();
                    lvi.SubItems[6].Text = editDirectory.SelectedFilterEntry.FileMaxAgeSec.ToString();
                    lvi.SubItems[7].Text = editDirectory.SelectedFilterEntry.FileMinSizeKB.ToString();
                    lvi.SubItems[8].Text = editDirectory.SelectedFilterEntry.FileMaxSizeKB.ToString();
                    lvi.Tag = editDirectory.SelectedFilterEntry;
                }
            }
        }
        public override void DeleteItems()
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to remove this entry(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwEntries.SelectedItems)
                    {
                        lvwEntries.Items.Remove(lvi);
                    }
                }
            }
        }
        public override void OKClicked()
        {
            if (SelectedConfig != null)
            {
                SelectedConfig = new FileSystemCollectorConfig();
            }
            FileSystemCollectorConfig fscc = (FileSystemCollectorConfig)SelectedConfig;
            fscc.Entries.Clear();
            foreach (ListViewItem lvi in lvwEntries.Items)
            {
                FileSystemDirectoryFilterEntry de = (FileSystemDirectoryFilterEntry)lvi.Tag;
                fscc.Entries.Add(de);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        #endregion
    }
}
