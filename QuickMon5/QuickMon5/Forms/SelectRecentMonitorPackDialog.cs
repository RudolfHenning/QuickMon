using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class SelectRecentMonitorPackDialog : Form
    {
        public SelectRecentMonitorPackDialog()
        {
            InitializeComponent();
        }

        public string SelectedMonitorPack { get; set; }

        private void SelectRecentMonitorPackDialog_Load(object sender, EventArgs e)
        {
            LoadRecentMonitorPackList();
            lvwMonitorPacks.AutoResizeColumnEnabled = true;
        }

        private void SelectRecentMonitorPackDialog_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (lvwMonitorPacks.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to remove the selected entry?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        foreach(ListViewItem lvi in lvwMonitorPacks.SelectedItems)
                        {
                            Properties.Settings.Default.RecentQMConfigFiles.Remove(lvi.Text);
                            lvwMonitorPacks.Items.Remove(lvi);
                        }                        
                        Properties.Settings.Default.Save();
                    }
                }
            }
        }

        private void lvwMonitorPacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = lvwMonitorPacks.SelectedItems.Count == 1;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lvwMonitorPacks.SelectedItems.Count == 1)
            {
                SelectedMonitorPack = lvwMonitorPacks.SelectedItems[0].Text;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void lvwMonitorPacks_DoubleClick(object sender, EventArgs e)
        {
            cmdOK_Click(null, null);
        }

        private void lvwMonitorPacks_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (lvwMonitorPacks.SelectedItems.Count == 1)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }

        private void llblResetList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the recent list?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Properties.Settings.Default.RecentQMConfigFiles.Clear();
                Properties.Settings.Default.Save();
                lvwMonitorPacks.Items.Clear();
            }
        }

        private void llblClearInvalid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove invalid entries?", "Clear invalid", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                List<string> invalids = new List<string>();
                foreach (string filePath in Properties.Settings.Default.RecentQMConfigFiles)
                {
                    if (!System.IO.File.Exists(filePath))
                    {
                        invalids.Add(filePath);
                    }
                }
                foreach (string invalid in invalids)
                {
                    Properties.Settings.Default.RecentQMConfigFiles.Remove(invalid);
                    Properties.Settings.Default.Save();
                }
                LoadRecentMonitorPackList();
            }
        }

        private void LoadRecentMonitorPackList()
        {
            int widest = 400;
            Graphics g = this.CreateGraphics();
            lvwMonitorPacks.Items.Clear();
            lvwMonitorPacks.Groups.Clear();
            List<MonitorPack.NameAndTypeSummary> recentMPs = new List<MonitorPack.NameAndTypeSummary>();
            List<ListViewGroup> groups = new List<ListViewGroup>();
            ListViewGroup naGroup = new ListViewGroup("<None>");
            groups.Add(naGroup);
            lvwMonitorPacks.Groups.Add(naGroup);

            foreach (string filePath in (from string s in Properties.Settings.Default.RecentQMConfigFiles
                                         orderby s
                                         select s))
            {
                MonitorPack.NameAndTypeSummary summaryInfo = MonitorPack.GetMonitorPackTypeName(filePath);
                recentMPs.Add(summaryInfo);
                //if (summaryInfo.Exists)
                //{
                //    if (summaryInfo.TypeName.Trim().Length > 0)
                //    {
                //        ListViewGroup currentGroup = (from ListViewGroup grp in groups
                //                                      where grp.Header.ToLower() == summaryInfo.TypeName.ToLower()
                //                                      select grp).FirstOrDefault();
                //        if (currentGroup == null)
                //        {
                //            currentGroup = new ListViewGroup(summaryInfo.TypeName);
                //            groups.Add(currentGroup);
                //            lvwMonitorPacks.Groups.Add(currentGroup);
                //        }
                //    }
                //}
            }
            foreach (MonitorPack.NameAndTypeSummary summaryInfo in (from MonitorPack.NameAndTypeSummary r in recentMPs
                                                                        orderby r.TypeName, r.Path
                                                                        select r))
            {
                ListViewItem lvi = new ListViewItem(summaryInfo.Path);
                if (!summaryInfo.Exists || summaryInfo.TypeName.Trim().Length == 0)
                {
                    lvi.Group = naGroup;
                }
                else
                {
                    ListViewGroup currentGroup = (from ListViewGroup grp in groups
                                                  where grp.Header.ToLower() == summaryInfo.TypeName.ToLower()
                                                  select grp).FirstOrDefault();
                    if (currentGroup == null)
                    {
                        currentGroup = new ListViewGroup(summaryInfo.TypeName);
                        groups.Add(currentGroup);
                        lvwMonitorPacks.Groups.Add(currentGroup);
                    }
                    lvi.Group = currentGroup;
                }
                lvwMonitorPacks.Items.Add(lvi);
                SizeF sz = g.MeasureString(summaryInfo.Path, lvwMonitorPacks.Font);
                if (sz.Width > widest)
                    widest = (int)sz.Width;
            }

            /*
            foreach (string filePath in (from string s in Properties.Settings.Default.RecentQMConfigFiles
                                         orderby s
                                         select s))
            {
                
                MonitorPack.NameAndTypeSummary summaryInfo = MonitorPack.GetMonitorPackTypeName(filePath);
                recentMPs.Add(summaryInfo);

                ListViewItem lvi = new ListViewItem(filePath);
                if (!summaryInfo.Exists)
                {
                    lvi.Text = "!" + lvi.Text;
                    lvi.Group = naGroup;
                }
                else
                {
                    if (summaryInfo.TypeName.Trim().Length == 0)
                    {
                        lvi.Group = naGroup;
                    }
                    else
                    {
                        ListViewGroup currentGroup = (from ListViewGroup grp in groups
                                                      where grp.Header.ToLower() == summaryInfo.TypeName.ToLower()
                                                      select grp).FirstOrDefault();
                        if (currentGroup == null)
                        {
                            currentGroup = new ListViewGroup(summaryInfo.TypeName);
                            groups.Add(currentGroup);
                            lvwMonitorPacks.Groups.Add(currentGroup);
                        }
                        lvi.Group = currentGroup;
                    }
                }

                lvwMonitorPacks.Items.Add(lvi);
                SizeF sz = g.MeasureString(filePath, lvwMonitorPacks.Font);
                if (sz.Width > widest)
                    widest = (int)sz.Width;
            }
            */


            if (widest + 50 < Screen.PrimaryScreen.WorkingArea.Width)
            {
                Width = widest + 50;
            }
        }

        private void llblImportMonitorPacks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.DefaultExt = "qmp4";
            fd.Filter = "Monitor Pack files|*qmp4";
            fd.Multiselect = true;
            fd.Title = "Import Monitor Packs";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in fd.FileNames)
                {
                    if (!Properties.Settings.Default.RecentQMConfigFiles.Contains(file))
                    {
                        Properties.Settings.Default.RecentQMConfigFiles.Add(file);
                    }
                }
                LoadRecentMonitorPackList();
            }
        }
    }
}
