using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Management
{
    public partial class SelectNotifierCollectors : Form
    {
        public SelectNotifierCollectors()
        {
            InitializeComponent();
        }

        private MonitorPack monitorPack;
        private int collectorImgIndex = 1;        
        private int folderImgIndex = 6;
        private string indentationChars = "  ";
        private bool loading = false;
        private bool selfCheckingOn = false;

        public List<string> SelectedCollectors { get; set; }

        public DialogResult ShowNotifierCollectors(MonitorPack monitorPack)
        {
            if (SelectedCollectors == null)
                SelectedCollectors = new List<string>();
            this.monitorPack = monitorPack;
            return ShowDialog();
        }

        private void SelectNotifierCollectors_Shown(object sender, EventArgs e)
        {
            LoadCollectors();
        }

        private void LoadCollectors()
        {
            if (monitorPack == null)
                return;
            loading = true;
            lvwCollectors.Items.Clear();
            try
            {
                lvwCollectors.BeginUpdate();
                List<CollectorEntry> noDependantCollectors = (from c in monitorPack.Collectors
                                                              where c.ParentCollectorId.Length == 0
                                                              select c).ToList();
                foreach (CollectorEntry col in noDependantCollectors)
                {
                    ListViewItem lvi = new ListViewItem(col.Name);
                    lvi.SubItems.Add(col.CollectorRegistrationName);
                    lvi.Tag = col;
                    if (SelectedCollectors.Contains(col.Name))
                        lvi.Checked = true;
                    if (col.IsFolder)
                        lvi.ImageIndex = folderImgIndex;
                    else
                        lvi.ImageIndex = collectorImgIndex;
                    lvwCollectors.Items.Add(lvi);
                    LoadCollectors(col, indentationChars);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvwCollectors.EndUpdate();
            }
            loading = false;
        }

        private void LoadCollectors(CollectorEntry collector, string indentation)
        {
            foreach (CollectorEntry childCollector in (from c in monitorPack.Collectors
                                                       where c.ParentCollectorId == collector.UniqueId
                                                       select c))
            {
                ListViewItem lvi = new ListViewItem(indentation + childCollector.Name);
                lvi.SubItems.Add(childCollector.CollectorRegistrationName);
                lvi.Tag = childCollector;
                if (SelectedCollectors.Contains(childCollector.Name))
                    lvi.Checked = true;
                if (childCollector.IsFolder)
                    lvi.ImageIndex = folderImgIndex;
                else
                    lvi.ImageIndex = collectorImgIndex;
                lvwCollectors.Items.Add(lvi);
                LoadCollectors(childCollector, indentation + indentationChars);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SelectedCollectors = new List<string>();
            foreach (ListViewItem lvi in lvwCollectors.Items)
            {
                if (lvi.Checked)
                {
                    CollectorEntry col = (CollectorEntry)lvi.Tag;
                    if (!col.IsFolder)
                        SelectedCollectors.Add(col.Name);
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void lvwCollectors_Resize(object sender, EventArgs e)
        {
            lvwCollectors.Columns[0].Width = lvwCollectors.ClientSize.Width - lvwCollectors.Columns[1].Width;
        }

        private void lvwCollectors_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (selfCheckingOn || loading)
                return;
            selfCheckingOn = true;
            ListViewItem lvi = e.Item;
            if (lvi.ImageIndex == folderImgIndex)
            {
                string currentIndent = lvi.Text;
                if (!currentIndent.StartsWith(" "))
                    currentIndent = indentationChars;
                else
                {
                    foreach (char c in lvi.Text.TakeWhile(cr => cr == ' '))
                    {
                        currentIndent += c.ToString();
                    }
                    currentIndent += indentationChars;
                }
                int currentIndex = lvi.Index;
                for (int i = currentIndex + 1; i < lvwCollectors.Items.Count && lvwCollectors.Items[i].Text.StartsWith(currentIndent); i++)
                {
                    lvwCollectors.Items[i].Checked = lvi.Checked;
                }
            }
            selfCheckingOn = false;
        }

        private void allLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selfCheckingOn = true;
            foreach (ListViewItem lvi in lvwCollectors.Items)
                lvi.Checked = false;
            selfCheckingOn = false;
        }
    }
}
