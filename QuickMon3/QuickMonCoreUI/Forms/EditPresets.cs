using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public partial class EditPresets : Form
    {
        public EditPresets()
        {
            InitializeComponent();
        }
        private bool isLoadingEditPreset = false;
        private bool templateChange = false;

        #region Form events
        private void EditPresets_Load(object sender, EventArgs e)
        {
            lvwPresets.AutoResizeColumnIndex = 0;
            lvwPresets.AutoResizeColumnEnabled = true;
            LoadAgents();
        }
        private void EditPresets_Shown(object sender, EventArgs e)
        {
            LoadPresets();
        } 
        #endregion

        #region ListView events
        private void lvwPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            deletePresetToolStripButton.Enabled = lvwPresets.SelectedItems.Count > 0;
            if (lvwPresets.SelectedItems.Count > 0 && lvwPresets.SelectedItems[0].Tag is AgentPresetConfig)
            {
                LoadSelectedPreset((AgentPresetConfig)lvwPresets.SelectedItems[0].Tag);
            }
        }

        private void LoadSelectedPreset(AgentPresetConfig agentPresetConfig)
        {
            if (!isLoadingEditPreset)
            {
                isLoadingEditPreset = true;
                cboAgentType.SelectedItem = (from RegisteredAgent a in cboAgentType.Items
                                             where a.ClassName.EndsWith(agentPresetConfig.AgentClassName)
                                             select a).FirstOrDefault();
                txtDescription.Text = agentPresetConfig.Description;
                txtConfig.Text = XmlFormattingUtils.NormalizeXML(agentPresetConfig.Config);
                txtConfig.SelectionStart = 0;
                txtConfig.DoCaretVisible();
                isLoadingEditPreset = false;
            }
        } 
        #endregion

        private void SetTitleChanged()
        {
            if (!isLoadingEditPreset)
            {
                this.Text = "Manage Templates*";
                templateChange = true;
            }
        }
        private void SetTitleSaved()
        {
            this.Text = "Manage Templates";
            templateChange = false;
        }
        private void LoadAgents()
        {
            cboAgentType.Items.Clear();
            cboAgentType.Items.AddRange((from a in RegisteredAgentCache.Agents
                                         orderby a.Name
                                         select a).ToArray());
        } 
        private void LoadPresets()
        {
            List<AgentPresetConfig> allPresets = AgentPresetConfig.GetAllPresets();
            lvwPresets.Groups.Clear();
            foreach(string agentType in (from p in allPresets
                                         group p by p.AgentClassName into g 
                                         select g.Key).OrderBy(p1=>p1))
            {
                lvwPresets.Groups.Add(new ListViewGroup(agentType));
            }

            lvwPresets.Items.Clear();
            foreach(AgentPresetConfig preset in (from p in allPresets
                                                     orderby p.Description
                                                     select p))
            {
                ListViewItem lvi = new ListViewItem(preset.Description);
                lvi.ImageIndex = 0;
                lvi.Group = (from ListViewGroup gr in lvwPresets.Groups
                             where gr.Header == preset.AgentClassName
                             select gr).FirstOrDefault();
                lvi.Tag = preset;
                lvwPresets.Items.Add(lvi);
            }
            lvwPresets.SetGroupState(QuickMon.Controls.ListViewGroupState.Collapsible);
            SetTitleSaved();
        }

        private void chkWrapText_CheckedChanged(object sender, EventArgs e)
        {
            txtConfig.WordWrap = chkWrapText.Checked;
        }
        private void cboAgentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTitleChanged();
        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            SetTitleChanged();
        }
        private void txtDefaultName_TextChanged(object sender, EventArgs e)
        {
            SetTitleChanged();
        }
        private void txtConfig_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            
        }  
        private void txtConfig_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            SetTitleChanged();
        }

        private void addTemplateToolStripButton_Click(object sender, EventArgs e)
        {
            if (templateChange)
            {
                if (MessageBox.Show("Do you want to save any changes first?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!SaveChanges())
                        return;
                }
            }
            isLoadingEditPreset = true;
            txtDescription.Text = "";
            txtConfig.Text = "";
            isLoadingEditPreset = false;
            SetTitleSaved();
        }

        private bool SaveChanges()
        {
            bool success = false;
            try
            {
                //first add currently edited record to list
                if (templateChange)
                {
                    #region Validation
                    if (cboAgentType.SelectedIndex == -1)
                    {
                        MessageBox.Show("You must specify an agent type!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboAgentType.Focus();
                        return false;
                    }
                    else if (txtDescription.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("You must specify a description!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtDescription.Focus();
                        return false;
                    }
                    else if (txtConfig.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("You must specify some config details!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtConfig.Focus();
                        return false;
                    }
                    try
                    {
                        System.Xml.XmlDocument testDoc = new System.Xml.XmlDocument();
                        testDoc.LoadXml(txtConfig.Text);
                    }
                    catch (Exception exValidation)
                    {
                        MessageBox.Show("You must specify a valid config string!\r\n" + exValidation.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtConfig.Focus();
                        return false;
                    }
                    #endregion

                    ListViewItem lvi = (from ListViewItem lv in lvwPresets.Items
                                        where lv.Tag is AgentPresetConfig &&
                                            ((AgentPresetConfig)lv.Tag).AgentClassName == ((RegisteredAgent)cboAgentType.SelectedItem).Name &&
                                            lv.Text.ToLower() == txtDescription.Text.ToLower()
                                        select lv).FirstOrDefault();
                    if (lvi != null)
                    {
                        AgentPresetConfig preset = (AgentPresetConfig)lvi.Tag;
                        preset.AgentClassName = ((RegisteredAgent)cboAgentType.SelectedItem).Name;
                        lvi.Group = (from ListViewGroup gr in lvwPresets.Groups
                                     where gr.Header == preset.AgentClassName
                                     select gr).FirstOrDefault();
                        preset.Config = txtConfig.Text;
                    }
                    else
                    {
                        AgentPresetConfig preset = new AgentPresetConfig();
                        preset.Description = txtDescription.Text;
                        preset.AgentClassName = ((RegisteredAgent)cboAgentType.SelectedItem).Name;
                        preset.Config = txtConfig.Text;

                        lvi = new ListViewItem(preset.Description);
                        lvi.ImageIndex = 0;
                        lvi.Group = (from ListViewGroup gr in lvwPresets.Groups
                                     where gr.Header == preset.AgentClassName
                                     select gr).FirstOrDefault();
                        lvi.Tag = preset;
                        lvwPresets.Items.Add(lvi);
                        lvwPresets.SelectedItems.Clear();
                        lvi.Selected = true;
                    }                    
                }
                //Second save all Presets to file
                List<AgentPresetConfig> list = new List<AgentPresetConfig>();
                foreach (ListViewItem lvi in lvwPresets.Items)
                {
                    if (lvi.Tag is AgentPresetConfig)
                    {
                        list.Add((AgentPresetConfig)lvi.Tag);
                    }
                }
                AgentPresetConfig.SaveAllPresetsToFile(list);

                SetTitleSaved();
                success = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Save failed!\r\n" + ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return success;
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            if (templateChange)
            {
                if (MessageBox.Show("Do you want to save any changes first?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!SaveChanges())
                        return;
                }
            }
            LoadPresets();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void lvwPresets_DeleteKeyPressed()
        {
            deletePresetToolStripButton_Click(null, null);
        }

        private void deletePresetToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwPresets.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected entry(s)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (int index in (from int i in lvwPresets.SelectedIndices
                                           orderby i descending
                                           select i))
                    {
                        lvwPresets.Items.RemoveAt(index);
                    }
                    SetTitleChanged();
                }
            }
        }

        private void importToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Do you want any similar named (description) templates that are imported to overwrite existing templates?", "Import", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (r == System.Windows.Forms.DialogResult.Cancel)
                    return;
                if (openFileDialogOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int importCount = 0;
                    List<AgentPresetConfig> newPresets = AgentPresetConfig.ReadPresetsFromFile(openFileDialogOpen.FileName);

                    foreach (string agentType in (from p in newPresets
                                                  group p by p.AgentClassName into g
                                                  select g.Key))
                    {
                        if ((from ListViewGroup gr in lvwPresets.Groups
                             where gr.Header == agentType
                             select gr).Count() == 0)
                            lvwPresets.Groups.Add(new ListViewGroup(agentType));
                    }

                    foreach (AgentPresetConfig preset in newPresets)
                    {
                        ListViewItem lvi = (from ListViewItem lv in lvwPresets.Items
                                            where lv.Tag is AgentPresetConfig &&
                                                ((AgentPresetConfig)lv.Tag).AgentClassName == preset.AgentClassName &&
                                                lv.Text.ToLower() == preset.Description.ToLower()
                                            select lv).FirstOrDefault();

                        if (lvi == null)
                        {
                            lvi = new ListViewItem(preset.Description);
                            lvi.ImageIndex = 0;
                            lvi.Group = (from ListViewGroup gr in lvwPresets.Groups
                                         where gr.Header == preset.AgentClassName
                                         select gr).FirstOrDefault();
                            lvi.Tag = preset;
                            lvwPresets.Items.Add(lvi);
                            importCount++;
                        }
                        else if (r == System.Windows.Forms.DialogResult.Yes)
                        {
                            lvi.Group = (from ListViewGroup gr in lvwPresets.Groups
                                         where gr.Header == preset.AgentClassName
                                         select gr).FirstOrDefault();
                            lvi.Tag = preset;                            
                            importCount++;
                        }
                    }
                    //SetTitleChanged();
                    SaveChanges();
                    MessageBox.Show(string.Format("{0} item(s) imported", importCount), "Import", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Import failed!\r\n" + ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void resetToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("This will reset all templates to the installed ones! This cannot be undone once completed.\r\nAre you sure you want to continue?", "Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == System.Windows.Forms.DialogResult.Yes)
                {
                    AgentPresetConfig.ResetAllPresets();
                    LoadPresets();

                    //string commonAppData = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Hen IT\\QuickMon 3");
                    //string userAppData = MonitorPack.GetQuickMonUserDataDirectory(); // System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Hen IT\\QuickMon 3");
                    //foreach (string commonPresetFilePath in System.IO.Directory.GetFiles(commonAppData, "*.qps"))
                    //{
                    //    string fileNameOnly = System.IO.Path.GetFileName(commonPresetFilePath);
                    //    string userPresetFilePath = System.IO.Path.Combine(userAppData, fileNameOnly);
                    //    System.IO.File.Copy(commonPresetFilePath, userPresetFilePath, true);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reset failed!\r\n" + ex.Message, "Reset templates", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
