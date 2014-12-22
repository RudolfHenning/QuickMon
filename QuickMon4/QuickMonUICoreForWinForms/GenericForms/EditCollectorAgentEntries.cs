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
    public partial class EditCollectorAgentEntries : Form
    {
        public EditCollectorAgentEntries()
        {
            InitializeComponent();
        }

        public IAgentConfigEntryEditWindow DetailEditor { get; set; }
        public ICollector SelectedEntry { get; set; }
        public bool ShowTreeView { get; set; }

        #region Form events
        private void EditEntriesInListView_Load(object sender, EventArgs e)
        {
            if (!ShowTreeView)
            {
                tvwEntries.Visible = false;
                lvwEntries.Visible = true;
                lvwEntries.Dock = DockStyle.Fill;
                lvwEntries.AutoResizeColumnIndex = 1;
                lvwEntries.AutoResizeColumnEnabled = true;
            }
            else
            {
                tvwEntries.Visible = true;
                lvwEntries.Visible = false;
            }
        }
        private void EditEntriesInListView_Shown(object sender, EventArgs e)
        {
            LoadEntries();
        } 
        #endregion

        #region Private methods
        private void LoadEntries()
        {
            if (SelectedEntry != null && SelectedEntry.AgentConfig != null)
            {
                txtName.Text = SelectedEntry.Name;
                chkEnabled.Checked = SelectedEntry.Enabled;
                txtAgentType.Text = SelectedEntry.AgentClassDisplayName;
                if (((ICollectorConfig)SelectedEntry.AgentConfig).Entries != null)
                {
                    if (!ShowTreeView)
                    {
                        lvwEntries.Items.Clear();
                        foreach (ICollectorConfigEntry item in ((ICollectorConfig)SelectedEntry.AgentConfig).Entries)
                        {
                            ListViewItem lvi = new ListViewItem(item.Description);
                            lvi.ImageIndex = 1;
                            lvi.SubItems.Add(item.TriggerSummary);
                            lvi.Tag = item;
                            lvwEntries.Items.Add(lvi);
                        }
                    }
                    else //Treeview
                    {
                        tvwEntries.Nodes.Clear();
                        foreach (ICollectorConfigEntry entry in ((ICollectorConfig)SelectedEntry.AgentConfig).Entries)
                        {
                            TreeNode tni = new TreeNode(entry.Description);
                            tni.ImageIndex = 0;
                            tni.SelectedImageIndex = 0;
                            tni.Tag = entry;
                            foreach (var subEntry in entry.SubItems)
                            {
                                TreeNode tnisub = new TreeNode(subEntry.Description);
                                tnisub.ImageIndex = 1;
                                tnisub.SelectedImageIndex = 1;
                                //tnisub.Tag = entry;
                                tni.Nodes.Add(tnisub);
                            }
                            tni.Expand();
                            tvwEntries.Nodes.Add(tni);
                        }
                    }
                }
            }
        }
        private void CheckOkEnabled()
        {
            cmdOK.Enabled = SelectedEntry != null && (txtName.Text.Length > 0);
        } 
        #endregion

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }

        #region Edit entries
        private void lvwEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            editCollectorAgentEntryToolStripButton.Enabled = lvwEntries.SelectedItems.Count == 1;
            deleteCollectorAgentEntriesToolStripButton.Enabled = lvwEntries.SelectedItems.Count > 0;
        }
        private void tvwEntries_AfterSelect(object sender, TreeViewEventArgs e)
        {
            editCollectorAgentEntryToolStripButton.Enabled = e.Node.ImageIndex > -1;
            deleteCollectorAgentEntriesToolStripButton.Enabled = e.Node.ImageIndex > -1;
        }
        private void addCollectorConfigEntryToolStripButton_Click(object sender, EventArgs e)
        {
            if (DetailEditor != null)
            {
                DetailEditor.SelectedEntry = null;
                if (DetailEditor.ShowEditEntry() == QuickMonDialogResult.Ok)
                {
                    if (!ShowTreeView)
                    {
                        ListViewItem lvi = new ListViewItem(DetailEditor.SelectedEntry.Description);
                        lvi.ImageIndex = 1;
                        lvi.SubItems.Add(DetailEditor.SelectedEntry.TriggerSummary);
                        lvi.Tag = DetailEditor.SelectedEntry;
                        lvwEntries.Items.Add(lvi);
                    }
                    else
                    {
                        TreeNode tni = new TreeNode(DetailEditor.SelectedEntry.Description);
                        tni.ImageIndex = 0;
                        tni.SelectedImageIndex = 0;
                        tni.Tag = DetailEditor.SelectedEntry;
                        foreach (var subEntry in DetailEditor.SelectedEntry.SubItems)
                        {
                            TreeNode tnisub = new TreeNode(subEntry.Description);
                            tnisub.ImageIndex = 1;
                            tnisub.SelectedImageIndex = 1;
                            tni.Nodes.Add(tnisub);
                        }
                        tni.Expand();
                        tvwEntries.Nodes.Add(tni);
                    }
                }
            }
        }
        private void lvwEntries_EnterKeyPressed()
        {
            editCollectorAgentEntryToolStripButton_Click(null, null);
        }
        private void tvwEntries_EnterKeyPressed()
        {
            editCollectorAgentEntryToolStripButton_Click(null, null);
        }
        private void lvwEntries_DeleteKeyPressed()
        {
            deleteCollectorAgentEntriesToolStripButton_Click(null, null);
        }
        private void lvwEntries_DoubleClick(object sender, EventArgs e)
        {
            editCollectorAgentEntryToolStripButton_Click(null, null);
        }
        private void tvwEntries_DoubleClick(object sender, EventArgs e)
        {
            editCollectorAgentEntryToolStripButton_Click(null, null);
        }
        private void editCollectorAgentEntryToolStripButton_Click(object sender, EventArgs e)
        {
            EditEntry();
        }
        private void EditEntry()
        {
            if (DetailEditor != null)
            {
                if (!ShowTreeView  && lvwEntries.SelectedItems.Count == 1)
                {
                    ListViewItem lvi = lvwEntries.SelectedItems[0];
                    DetailEditor.SelectedEntry = (ICollectorConfigEntry)lvi.Tag;
                    if (DetailEditor.ShowEditEntry() == QuickMonDialogResult.Ok)
                    {
                        lvi.Text = DetailEditor.SelectedEntry.Description;
                        lvi.SubItems[1].Text = DetailEditor.SelectedEntry.TriggerSummary;
                        lvi.Tag = DetailEditor.SelectedEntry;
                    }
                }
                else if (ShowTreeView && tvwEntries.SelectedNode != null)
                {
                    if (tvwEntries.SelectedNode.Tag is ICollectorConfigEntry)
                        DetailEditor.SelectedEntry = (ICollectorConfigEntry)tvwEntries.SelectedNode.Tag;
                    else
                        DetailEditor.SelectedEntry = (ICollectorConfigEntry)tvwEntries.SelectedNode.Parent.Tag;
                    if (DetailEditor.ShowEditEntry() == QuickMonDialogResult.Ok)
                    {
                        TreeNode tni;
                        if (tvwEntries.SelectedNode.Tag is ICollectorConfigEntry)
                            tni = tvwEntries.SelectedNode;
                        else
                            tni = tvwEntries.SelectedNode.Parent;
                        tni.Tag = DetailEditor.SelectedEntry;
                        tni.Nodes.Clear();
                        foreach (var subEntry in DetailEditor.SelectedEntry.SubItems)
                        {
                            TreeNode tnisub = new TreeNode(subEntry.Description);
                            tnisub.ImageIndex = 1;
                            tnisub.SelectedImageIndex = 1;
                            tni.Nodes.Add(tnisub);
                        }
                        tni.Expand();
                        tvwEntries.SelectedNode = tni;
                    }
                }
            }
        }
        private void tvwEntries_DeleteKeyPressed()
        {
            deleteCollectorAgentEntriesToolStripButton_Click(null, null);
        }
        private void deleteCollectorAgentEntriesToolStripButton_Click(object sender, EventArgs e)
        {
            if (!ShowTreeView)
            {
                if (lvwEntries.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to delete the seleted entry(s)?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        foreach (ListViewItem lvi in lvwEntries.SelectedItems)
                            lvwEntries.Items.Remove(lvi);
                    }
                }
            }
            else if (tvwEntries.SelectedNode != null)
            {
                if (MessageBox.Show("Are you sure you want to delete the seleted entry(s)?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    TreeNode selectedNode = tvwEntries.SelectedNode;
                    if (tvwEntries.SelectedNode.Tag is ICollectorConfigEntry)
                    {
                        tvwEntries.Nodes.Remove(selectedNode);
                    }
                    else
                    {
                        TreeNode parentNode = tvwEntries.SelectedNode.Parent;
                        if (parentNode != null)
                        {
                            ICollectorConfigEntry entry = (ICollectorConfigEntry)parentNode.Tag;
                            ICollectorConfigSubEntry subEntry = (from si in entry.SubItems
                                                                 where si.Description == selectedNode.Text
                                                                 select si).FirstOrDefault();
                            if (subEntry != null)
                                entry.SubItems.Remove(subEntry);
                            tvwEntries.Nodes.Remove(selectedNode);
                            if (parentNode.Nodes.Count == 0)
                            {
                                tvwEntries.Nodes.Remove(parentNode);
                            }
                        }
                    }
                }
            }
        } 
        #endregion

        #region Button events
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (SelectedEntry != null)
            {
                SelectedEntry.Name = txtName.Text;
                SelectedEntry.Enabled = chkEnabled.Checked;
                ICollectorConfig conf = (ICollectorConfig)SelectedEntry.AgentConfig;
                conf.Entries.Clear();
                if (!ShowTreeView)
                {
                    foreach (ListViewItem lvi in lvwEntries.Items)
                    {
                        conf.Entries.Add((ICollectorConfigEntry)lvi.Tag);
                    }
                }
                else //TreeView
                {
                    foreach(TreeNode nod in tvwEntries.Nodes)
                    {
                        conf.Entries.Add((ICollectorConfigEntry)nod.Tag);
                    }
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion

        private void llblRawEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SelectedEntry != null)
            {
                ICollectorConfig conf = (ICollectorConfig)SelectedEntry.AgentConfig;
                conf.Entries.Clear();
                if (!ShowTreeView)
                {
                    foreach (ListViewItem lvi in lvwEntries.Items)
                    {
                        conf.Entries.Add((ICollectorConfigEntry)lvi.Tag);
                    }
                }
                else //TreeView
                {

                }
                RAWXmlEditor editor = new RAWXmlEditor();
                string oldMarkUp = conf.ToXml();
                editor.SelectedMarkup = oldMarkUp;
                if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        conf.FromXml(editor.SelectedMarkup);
                        if (editor.SelectedMarkup != null && editor.SelectedMarkup.Length > 0 && conf.Entries.Count == 0)
                        {
                            if (MessageBox.Show("Editing the raw config resulted in no loadable entries!\r\nDo you want to accept this?", "No entries",  MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                            {
                                conf.FromXml(oldMarkUp);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occured while processing the config!\r\n" + ex.Message, "Edit config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    LoadEntries();
                }
                
            }
        }  

    }
}
