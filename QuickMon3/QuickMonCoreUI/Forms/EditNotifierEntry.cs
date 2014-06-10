using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using QuickMon.Forms;

namespace QuickMon.Management
{
    public partial class EditNotifierEntry : Form
    {
        public EditNotifierEntry()
        {
            InitializeComponent();
        }

        private MonitorPack monitorPack;
        private Size collapsedSize = new Size(500, 250);
        private Size expandedSize = new Size(500, 400);
        private NotifierEntry editingNotifierEntry;

        public NotifierEntry SelectedEntry { get; set; }
        public bool LaunchAddEntry { get; set; }
        public bool ShowRawEditOnStart { get; set; }
        public bool ShowSelectPresetOnStart { get; set; }

        public DialogResult ShowDialog(MonitorPack monitorPack)
        {
            this.monitorPack = monitorPack;
            if (SelectedEntry == null)
            {
                return System.Windows.Forms.DialogResult.No;
            }
            else
                editingNotifierEntry = NotifierEntry.FromConfig(SelectedEntry.ToConfig());

            monitorPack.ApplyNotifierConfig(editingNotifierEntry);             
            return ShowDialog();
        }

        #region Form events
        private void EditNotifierEntry_Load(object sender, EventArgs e)
        {
            if (LaunchAddEntry)
            {
                cmdConfigure_Click(null, null);
            }
            else if (ShowRawEditOnStart && editingNotifierEntry != null && editingNotifierEntry.Notifier != null && editingNotifierEntry.Notifier.AgentConfig != null)
            {
                llblRawEdit_LinkClicked(null, null);
            }
        }
        private void EditNotifierEntry_Shown(object sender, EventArgs e)
        {
            LoadConfig();
        }        
        #endregion

        #region Button and link events
        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedEntry == null)
                    SelectedEntry = new NotifierEntry();
                SelectedEntry.Name = txtName.Text;
                SelectedEntry.Enabled = chkEnabled.Checked;
                SelectedEntry.AlertLevel = (AlertLevel)cboAlertLevel.SelectedIndex;
                SelectedEntry.DetailLevel = (DetailLevel)cboDetailLevel.SelectedIndex;
                SelectedEntry.NotifierRegistrationName = editingNotifierEntry.NotifierRegistrationName;
                SelectedEntry.InitialConfiguration = editingNotifierEntry.Notifier.AgentConfig.ToConfig();
                SelectedEntry.AlertForCollectors.Clear();
                if (editingNotifierEntry.AlertForCollectors != null && editingNotifierEntry.AlertForCollectors.Count > 0)
                    SelectedEntry.AlertForCollectors.AddRange(editingNotifierEntry.AlertForCollectors.ToArray());
                SelectedEntry.AttendedOptionOverride = (AttendedOption)cboAttendedOptionOverride.SelectedIndex;

                monitorPack.ApplyNotifierConfig(SelectedEntry);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void alertForCollectorslinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SelectNotifierCollectors selectNotifierCollectors = new SelectNotifierCollectors();
            selectNotifierCollectors.SelectedCollectors = new List<string>();
            selectNotifierCollectors.SelectedCollectors.AddRange(editingNotifierEntry.AlertForCollectors.ToArray());
            if (selectNotifierCollectors.ShowNotifierCollectors(monitorPack) == System.Windows.Forms.DialogResult.OK)
            {
                editingNotifierEntry.AlertForCollectors.Clear();
                editingNotifierEntry.AlertForCollectors.AddRange(selectNotifierCollectors.SelectedCollectors.ToArray());
                SetAlertForCollectors();
                if (!backgroundWorkerCheckOk.IsBusy)
                    backgroundWorkerCheckOk.RunWorkerAsync();
            }
        }
        private void cmdConfigure_Click(object sender, EventArgs e)
        {
            if (editingNotifierEntry != null && editingNotifierEntry.Notifier != null)
            {
                try
                {
                    RegisteredAgent ar = (from a in RegisteredAgentCache.Agents // monitorPack.RegisteredAgents
                                      where a.IsNotifier && a.Name == editingNotifierEntry.NotifierRegistrationName
                                      select a).FirstOrDefault();
                    if (ar != null)
                    {
                        INotifier tmpnotifier;
                        tmpnotifier = NotifierEntry.CreateNotifierEntry(ar);
                        if (tmpnotifier != null)
                        {
                            if (editingNotifierEntry.Notifier != null &&
                                ar.Name == editingNotifierEntry.NotifierRegistrationName)
                            {
                                tmpnotifier.SetConfigurationFromXmlString(editingNotifierEntry.Notifier.AgentConfig.ToConfig());
                            }
                            else
                            {
                                tmpnotifier.SetConfigurationFromXmlString(tmpnotifier.GetDefaultOrEmptyConfigString());
                            }
                            if (txtName.Text.Length == 0)
                                txtName.Text = "No Name";
                            if (tmpnotifier.ShowEditConfiguration("Edit '" + txtName.Text + "' Config"))
                            {
                                editingNotifierEntry.Notifier = tmpnotifier;
                                editingNotifierEntry.InitialConfiguration = tmpnotifier.AgentConfig.ToConfig();
                                editingNotifierEntry.NotifierRegistrationName = ar.Name;

                                if (editingNotifierEntry.Notifier != null && editingNotifierEntry.Notifier.AgentConfig != null)
                                {
                                    INotifierConfig config = (INotifierConfig)editingNotifierEntry.Notifier.AgentConfig;
                                    lblConfigSummary.Text = config.ConfigSummary;
                                }
                            }
                        }
                        CheckOkEnable();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void llblNotifierType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to change the Notifier type?\r\n\r\nIf you continue this will reset any existing configuration.", "Notifier type", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                NotifierEntry newNotifierEntry = AgentHelper.CreateNewNotifier();
                if (newNotifierEntry != null)
                {
                    editingNotifierEntry = null;
                    editingNotifierEntry = newNotifierEntry;
                    LoadConfig();
                }

                //AgentTypeSelect agentTypeSelect = new AgentTypeSelect();
                //if (agentTypeSelect.ShowNotifierSelection(editingNotifierEntry.NotifierRegistrationName) == System.Windows.Forms.DialogResult.OK)
                //{
                //    RegisteredAgent ar = agentTypeSelect.SelectedAgent;
                //    editingNotifierEntry.NotifierRegistrationName = ar.Name;
                //    llblNotifierType.Text = ar.DisplayName;

                //    LoadConfig();
                //}
            }
        }
        private void llblRawEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (editingNotifierEntry.Notifier != null && editingNotifierEntry.Notifier.AgentConfig != null)
                {
                    EditRAWMarkup editRaw = new EditRAWMarkup();
                    editRaw.SelectedMarkup = XmlFormattingUtils.NormalizeXML(editingNotifierEntry.Notifier.AgentConfig.ToConfig());
                    editRaw.AgentType = editingNotifierEntry.NotifierRegistrationName;
                    editRaw.UseNotifierType = true;
                    editRaw.CurrentMonitorPack = monitorPack;
                    if (editRaw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        editingNotifierEntry.Notifier.SetConfigurationFromXmlString(editRaw.SelectedMarkup);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error setting configuration\r\n{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void llblUsePreset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (editingNotifierEntry != null && editingNotifierEntry.Notifier != null)
            {
                bool presetsAvailable = false;
                List<AgentPresetConfig> presets = null;
                try
                {
                    presets = AgentPresetConfig.GetPresetsForClass(editingNotifierEntry.Notifier.GetType().Name);
                    presetsAvailable = (presets != null && presets.Count > 0);
                }
                catch { }
                if (presetsAvailable)
                {
                    INotifierConfig currentConfig = (INotifierConfig)editingNotifierEntry.Notifier.AgentConfig;
                    AddFromCollectorPreset addFromCollectorPreset = new AddFromCollectorPreset();
                    addFromCollectorPreset.AvailablePresets = presets;
                    if (addFromCollectorPreset.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (editingNotifierEntry.Notifier != null && editingNotifierEntry.Notifier.AgentConfig != null)
                        {
                            txtName.Text = addFromCollectorPreset.SelectedPreset.Description;
                            editingNotifierEntry.Name = addFromCollectorPreset.SelectedPreset.Description;
                            editingNotifierEntry.Notifier.SetConfigurationFromXmlString(AgentPresetConfig.FormatVariables(addFromCollectorPreset.SelectedPreset.Config));
                            LoadConfig();
                        }
                    }
                }
            }
        }
        private void llblExportConfigAsTemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (editingNotifierEntry != null && editingNotifierEntry.Notifier != null && txtName.Text.Trim().Length > 0)
            {
                if (MessageBox.Show("Are you sure you want to export the current config as a template?\r\nThe notifier entry name will be used as name for the template.", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        AgentPresetConfig newPreset = new AgentPresetConfig();
                        newPreset.AgentClassName = editingNotifierEntry.NotifierRegistrationName;
                        newPreset.Description = txtName.Text;
                        newPreset.Config = editingNotifierEntry.Notifier.AgentConfig.ToConfig();
                        List<AgentPresetConfig> allExistingPresets = AgentPresetConfig.GetAllPresets();

                        if ((from p in allExistingPresets
                                 where p.AgentClassName == newPreset.AgentClassName && p.Description == newPreset.Description
                             select p).Count() > 0)
                        {
                            if (MessageBox.Show("A template with the name '" + newPreset.Description + "' already exist!\r\nDo you want to replace it?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                            {
                                return;
                            }
                            else
                            {
                                AgentPresetConfig existingEntry = (from p in allExistingPresets
                                                                   where p.AgentClassName == newPreset.AgentClassName && p.Description == newPreset.Description
                                                                   select p).FirstOrDefault();
                                existingEntry.Config = newPreset.Config;
                            }
                        }
                        else
                            allExistingPresets.Add(newPreset);
                        AgentPresetConfig.SaveAllPresetsToFile(allExistingPresets);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Change checking
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (!backgroundWorkerCheckOk.IsBusy)
                backgroundWorkerCheckOk.RunWorkerAsync();
        }
        private void cboNotifier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!backgroundWorkerCheckOk.IsBusy)
                backgroundWorkerCheckOk.RunWorkerAsync();
        }
        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (!backgroundWorkerCheckOk.IsBusy)
                backgroundWorkerCheckOk.RunWorkerAsync();
        }
        private void backgroundWorkerCheckOk_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate()
            {
                CheckOkEnable();
            });
        }
        private void cboAlertLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!backgroundWorkerCheckOk.IsBusy)
                backgroundWorkerCheckOk.RunWorkerAsync();
        }
        private void cboDetailLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!backgroundWorkerCheckOk.IsBusy)
                backgroundWorkerCheckOk.RunWorkerAsync();
        }
        #endregion

        #region Private methods
        private void CheckOkEnable()
        {
            bool isEnable = true;
            if (txtName.Text.Length == 0 || editingNotifierEntry == null || editingNotifierEntry.InitialConfiguration == null || editingNotifierEntry.InitialConfiguration.Length == 0)
                isEnable = false;

            cmdOK.Enabled = isEnable;
            cmdConfigure.Enabled = editingNotifierEntry!= null && editingNotifierEntry.NotifierRegistrationName != null && editingNotifierEntry.NotifierRegistrationName.Length > 0;
            //lblAgentDescription.Text = "";
            //if (cboNotifier.SelectedIndex > -1)
            //{
            //    try
            //    {
            //        RegisteredAgent ar = (RegisteredAgent)cboNotifier.SelectedItem;
            //        lblAgentDescription.Text = "Description: " + ar.ClassName;
            //        System.Reflection.Assembly a = System.Reflection.Assembly.LoadFrom(ar.AssemblyPath);
            //        lblAgentDescription.Text += ", Version: " + a.GetName().Version.ToString();
            //        lblAgentDescription.Text += ", Assembly: " + System.IO.Path.GetFileName(a.Location);

            //    }
            //    catch { }
            //}
        }
        private void SetAlertForCollectors()
        {
            if (editingNotifierEntry.AlertForCollectors == null || editingNotifierEntry.AlertForCollectors.Count == 0)
                alertForCollectorslinkLabel.Text = "All Collectors";
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < editingNotifierEntry.AlertForCollectors.Count && i < 100; i++)
                {
                    sb.Append(editingNotifierEntry.AlertForCollectors[i] + ", ");
                }
                alertForCollectorslinkLabel.Text = sb.ToString().TrimEnd(' ', ',');
                if (editingNotifierEntry.AlertForCollectors.Count > 100)
                    alertForCollectorslinkLabel.Text += "...";
            }
        } 
        private void LoadConfig()
        {
            cmdConfigure.Enabled = editingNotifierEntry == null;
            cboAttendedOptionOverride.SelectedIndex = 0;
            if (editingNotifierEntry != null)
            {
                txtName.Text = editingNotifierEntry.Name;
                chkEnabled.Checked = editingNotifierEntry.Enabled;

                //bool presetsAvailable = false;
                //List<AgentPresetConfig> presets = null;
                //try
                //{
                //    presets = AgentPresetConfig.GetPresetsForClass(editingNotifierEntry.NotifierRegistrationName);
                //    presetsAvailable = (presets != null && presets.Count > 0);
                //}
                //catch { }
                //llblUsePreset.Visible = presetsAvailable;

                RegisteredAgent ar = (from a in RegisteredAgentCache.Agents 
                                      where a.IsNotifier && a.Name == editingNotifierEntry.NotifierRegistrationName
                                      select a).FirstOrDefault();
                if (ar != null)
                {
                    llblNotifierType.Text = ar.DisplayName;
                }
                cboAlertLevel.SelectedIndex = (int)editingNotifierEntry.AlertLevel;
                cboDetailLevel.SelectedIndex = (int)editingNotifierEntry.DetailLevel;
                if (editingNotifierEntry.Notifier != null && editingNotifierEntry.Notifier.AgentConfig != null)
                {
                    INotifierConfig config = (INotifierConfig)editingNotifierEntry.Notifier.AgentConfig;
                    lblConfigSummary.Text = config.ConfigSummary;
                    if (editingNotifierEntry.Notifier.AttendedRunOption != AttendedOption.AttendedAndUnAttended)
                    {
                        editingNotifierEntry.AttendedOptionOverride = editingNotifierEntry.Notifier.AttendedRunOption;
                        cboAttendedOptionOverride.Enabled = false;
                    }
                    else
                        cboAttendedOptionOverride.Enabled = true;
                }
                cboAttendedOptionOverride.SelectedIndex = (int)editingNotifierEntry.AttendedOptionOverride;
                SetAlertForCollectors();
                CheckOkEnable();
            }
        }
        #endregion        



        #region Manual config edit context menu events
        //private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    txtConfig.Copy();
        //}
        //private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    txtConfig.Paste();
        //}
        //private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    txtConfig.SelectAll();
        //}
        #endregion
       
    }
}
