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
    public partial class EditCollectorEntry : Form
    {
        public EditCollectorEntry()
        {
            InitializeComponent();
            SelectedEntry = new CollectorEntry();
            SelectedEntry.Enabled = true;
            SelectedEntry.UniqueId = Guid.NewGuid().ToString();
            SelectedEntry.ServiceWindows = new ServiceWindows();

            editingCollectorEntry = new CollectorEntry();
            editingCollectorEntry.Enabled = true;
            editingCollectorEntry.UniqueId = Guid.NewGuid().ToString();
            editingCollectorEntry.ServiceWindows = new ServiceWindows();
        }

        #region Private
        private MonitorPack monitorPack;
        private Size collapsedSize = new Size(600, 290);
        private Size expandedSize = new Size(600, 600);
        private CollectorEntry editingCollectorEntry;
        #endregion

        #region Properties
        public CollectorEntry SelectedEntry { get; set; }
        private bool allowCollectorChange = true;
        public bool AllowCollectorChange { get { return allowCollectorChange; } set { allowCollectorChange = value; } } 
        #endregion

        public DialogResult ShowDialog(MonitorPack monitorPack)
        {
            this.monitorPack = monitorPack;
            editingCollectorEntry = CollectorEntry.FromConfig(SelectedEntry.ToConfig());
            if (SelectedEntry.Collector != null)
            {
                monitorPack.ApplyCollectorConfig(editingCollectorEntry);
            }
            return ShowDialog();
        }

        #region Form events
        private void EditCollectorEntry_Shown(object sender, EventArgs e)
        {
            txtName.Text = SelectedEntry.Name;
            chkEnabled.Checked = SelectedEntry.Enabled;
            chkFolder.Checked = SelectedEntry.IsFolder;
            chkFolder.Enabled = allowCollectorChange;
            lblId.Text = SelectedEntry.UniqueId;
            cboParentCollector.Items.Add("<None>");
            cboParentCollector.SelectedIndex = 0;
            foreach (CollectorEntry ce in monitorPack.Collectors)
            {
                if (IsNotInCurrentDependantTree(SelectedEntry.UniqueId, ce))
                {
                    cboParentCollector.Items.Add(ce);
                }
                if (ce.UniqueId == SelectedEntry.ParentCollectorId)
                    cboParentCollector.SelectedItem = ce;
            }
            cboParentCollector.Enabled = allowCollectorChange;

            foreach (RegisteredAgent ar in (from a in RegisteredAgentCache.Agents
                                              where a.IsCollector                                              
                                              orderby a.Name
                                              select a))
            {
                cboCollector.Items.Add(ar);
                if (ar.Name == SelectedEntry.CollectorRegistrationName)
                    cboCollector.SelectedItem = ar;
            }
            if (SelectedEntry.CollectorRegistrationName != null &&  !SelectedEntry.IsFolder && cboCollector.SelectedItem == null && SelectedEntry.Name != null)
            {
                MessageBox.Show("Specified collector agent is not registered!", "Collector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            chkCollectOnParentWarning.Checked = SelectedEntry.CollectOnParentWarning;
            numericUpDownRepeatAlertInXMin.Value = SelectedEntry.RepeatAlertInXMin;
            AlertOnceInXMinNumericUpDown.Value = SelectedEntry.AlertOnceInXMin;
            delayAlertSecNumericUpDown.Value = SelectedEntry.DelayErrWarnAlertForXSec;
            linkLabelServiceWindows.Text = SelectedEntry.ServiceWindows.ToString();
            chkCorrectiveScriptDisabled.Checked = SelectedEntry.CorrectiveScriptDisabled;
            txtCorrectiveScriptOnWarning.Text = SelectedEntry.CorrectiveScriptOnWarningPath;
            txtCorrectiveScriptOnError.Text = SelectedEntry.CorrectiveScriptOnErrorPath;
            chkRemoteAgentEnabled.Checked = SelectedEntry.EnableRemoteExecute;
            txtRemoteAgentServer.Text = SelectedEntry.RemoteAgentHostAddress;
            remoteportNumericUpDown.Value = SelectedEntry.RemoteAgentHostPort;
            CheckOkEnable();
            toolTip1.SetToolTip(linkLabelServiceWindows, "Only operate within specified times. Return 'disabled' status otherwise\r\n" + SelectedEntry.ServiceWindows.ToString());
        }
        private void EditCollectorEntry_Load(object sender, EventArgs e)
        {
            this.Size = collapsedSize;
            this.MinimumSize = collapsedSize;
            this.MaximumSize = collapsedSize;
            manualEditPanel.Visible = false;
        }
        #endregion

        #region Button events
        private void chkFolder_CheckedChanged(object sender, EventArgs e)
        {
            CheckOkEnable();
            if (cboCollector.SelectedIndex > -1 && chkFolder.Checked)
                cboCollector.SelectedIndex = -1;
        }
        private void cmdConfig_Click(object sender, EventArgs e)
        {
            if (cboCollector.SelectedItem != null)
            {
                try
                {
                    RegisteredAgent ar = (RegisteredAgent)cboCollector.SelectedItem;
                    ICollector tmpcollector;
                    if (editingCollectorEntry == null)
                    {
                        editingCollectorEntry = new CollectorEntry();                        
                    }
                    tmpcollector = CollectorEntry.CreateCollectorEntry(ar);
                    if (tmpcollector != null)
                    {
                        if (editingCollectorEntry.Collector != null &&
                            (ar.Name == editingCollectorEntry.CollectorRegistrationName))
                        {
                            tmpcollector.SetConfigurationFromXmlString(editingCollectorEntry.Collector.AgentConfig.ToConfig());
                        }
                        else
                        {                        
                            tmpcollector.SetConfigurationFromXmlString(tmpcollector.GetDefaultOrEmptyConfigString());
                        }
                        if (txtName.Text.Length == 0)
                            txtName.Text = "No Name";
                        if (tmpcollector.ShowEditConfiguration("Edit '" + txtName.Text + "' Config"))
                        {
                            editingCollectorEntry.Collector = tmpcollector;
                            editingCollectorEntry.InitialConfiguration = tmpcollector.AgentConfig.ToConfig();
                            editingCollectorEntry.CollectorRegistrationName = ar.Name;
                        }
                    }
                    CheckOkEnable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cmdManualConfig_Click(object sender, EventArgs e)
        {
            try
            {
                if ((editingCollectorEntry.Collector == null || editingCollectorEntry.Collector.AgentConfig == null) && cboCollector.SelectedItem != null) // || SelectedEntry.Collector.AgentConfig.to .Configuration == null || SelectedEntry.Configuration.Length == 0) && cboCollector.SelectedItem != null)
                {
                    RegisteredAgent ar = (RegisteredAgent)cboCollector.SelectedItem;
                    ICollector col = CollectorEntry.CreateCollectorEntry(ar);
                    txtConfig.Text = XmlFormattingUtils.NormalizeXML(col.GetDefaultOrEmptyConfigString());
                }
                else
                {
                    txtConfig.Text = XmlFormattingUtils.NormalizeXML(editingCollectorEntry.Collector.AgentConfig.ToConfig());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error getting new/existing configuration\r\n{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            ShowManualConfig();
        }
        private void configureEditButton1_ImportConfigurationClicked(object sender, EventArgs e)
        {
            ImportCollectorConfig importCollectorConfig = new ImportCollectorConfig();
            importCollectorConfig.IsCollector = true;
            importCollectorConfig.MonitorPackPath = monitorPack.MonitorPackPath;
            importCollectorConfig.AgentType = ((RegisteredAgent)cboCollector.SelectedItem).Name;
            if (importCollectorConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                editingCollectorEntry.InitialConfiguration = importCollectorConfig.SelectedConfig;
                RegisteredAgent ar = (RegisteredAgent)cboCollector.SelectedItem;
                editingCollectorEntry.Collector = CollectorEntry.CreateCollectorEntry(ar);
                editingCollectorEntry.Collector.SetConfigurationFromXmlString(importCollectorConfig.SelectedConfig);
                editingCollectorEntry.CollectorRegistrationName = ar.Name;                
            }
        }
        private void lblServiceWindows_DoubleClick(object sender, EventArgs e)
        {
            linkLabelServiceWindows_LinkClicked(null, null);
        }
        private void linkLabelServiceWindows_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditServiceWindows editServiceWindows = new EditServiceWindows();
            editServiceWindows.SelectedServiceWindows = editingCollectorEntry.ServiceWindows;
            if (editServiceWindows.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                editingCollectorEntry.ServiceWindows = editServiceWindows.SelectedServiceWindows;
                linkLabelServiceWindows.Text = editServiceWindows.SelectedServiceWindows.ToString();
                toolTip1.SetToolTip(linkLabelServiceWindows, "Only operate within specified times. Return 'disabled' status otherwise\r\n" + editingCollectorEntry.ServiceWindows.ToString());
                if (!backgroundWorkerCheckOk.IsBusy)
                    backgroundWorkerCheckOk.RunWorkerAsync();
            }
        }
        private void cmdBrowseForWarningCorrectiveScript_Click(object sender, EventArgs e)
        {
            correctiveScriptOpenFileDialog.Title = "Corrective script for Warning Alert";
            if (System.IO.File.Exists(txtCorrectiveScriptOnWarning.Text))
            {
                correctiveScriptOpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(txtCorrectiveScriptOnWarning.Text);
                correctiveScriptOpenFileDialog.FileName = txtCorrectiveScriptOnWarning.Text;
            }
            if (correctiveScriptOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtCorrectiveScriptOnWarning.Text = correctiveScriptOpenFileDialog.FileName;
            }
        }
        private void cmdBrowseForErrorCorrectiveScript_Click(object sender, EventArgs e)
        {
            correctiveScriptOpenFileDialog.Title = "Corrective script for Error Alert";
            if (System.IO.File.Exists(txtCorrectiveScriptOnError.Text))
            {
                correctiveScriptOpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(txtCorrectiveScriptOnError.Text);
                correctiveScriptOpenFileDialog.FileName = txtCorrectiveScriptOnError.Text;
            }
            if (correctiveScriptOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtCorrectiveScriptOnError.Text = correctiveScriptOpenFileDialog.FileName;
            }
        }
        private void cmdSaveConfig_Click(object sender, EventArgs e)
        {
            XmlDocument testXml = new XmlDocument();
            try
            {
                testXml.LoadXml(txtConfig.Text);
                editingCollectorEntry.InitialConfiguration = txtConfig.Text;
                RegisteredAgent ar = (RegisteredAgent)cboCollector.SelectedItem;
                ICollector  tmpcollector = CollectorEntry.CreateCollectorEntry(ar);
                editingCollectorEntry.Collector = tmpcollector;
                editingCollectorEntry.Collector.SetConfigurationFromXmlString(txtConfig.Text);
                editingCollectorEntry.CollectorRegistrationName = ar.Name;
                HideManualConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error parsing xml\r\n{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void cmdCancelConfig_Click(object sender, EventArgs e)
        {
            HideManualConfig();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SelectedEntry.UniqueId = lblId.Text;
            SelectedEntry.Name = txtName.Text.Trim();
            SelectedEntry.Enabled = chkEnabled.Checked;
            SelectedEntry.IsFolder = chkFolder.Checked;
            if (cboParentCollector.SelectedIndex > 0)
                SelectedEntry.ParentCollectorId = ((CollectorEntry)cboParentCollector.SelectedItem).UniqueId;
            else
                SelectedEntry.ParentCollectorId = "";

            if (chkFolder.Checked)
                SelectedEntry.CollectorRegistrationName = "Folder";
            else
            {
                SelectedEntry.CollectorRegistrationName = ((RegisteredAgent)cboCollector.SelectedItem).Name;
                SelectedEntry.CollectorRegistrationDisplayName = ((RegisteredAgent)cboCollector.SelectedItem).DisplayName;
                SelectedEntry.InitialConfiguration = editingCollectorEntry.Collector.AgentConfig.ToConfig();
            }
            SelectedEntry.CollectOnParentWarning = chkCollectOnParentWarning.Checked && !chkFolder.Checked;
            SelectedEntry.RepeatAlertInXMin = (int)numericUpDownRepeatAlertInXMin.Value;
            SelectedEntry.AlertOnceInXMin = (int)AlertOnceInXMinNumericUpDown.Value;
            SelectedEntry.DelayErrWarnAlertForXSec = (int)delayAlertSecNumericUpDown.Value;
            SelectedEntry.CorrectiveScriptDisabled = chkCorrectiveScriptDisabled.Checked;
            SelectedEntry.CorrectiveScriptOnWarningPath = txtCorrectiveScriptOnWarning.Text;
            SelectedEntry.CorrectiveScriptOnErrorPath = txtCorrectiveScriptOnError.Text;
            SelectedEntry.EnableRemoteExecute = chkRemoteAgentEnabled.Checked;
            SelectedEntry.RemoteAgentHostAddress = txtRemoteAgentServer.Text;
            SelectedEntry.RemoteAgentHostPort = (int)remoteportNumericUpDown.Value;
            SelectedEntry.ServiceWindows.CreateFromConfig(editingCollectorEntry.ServiceWindows.ToConfig());

            monitorPack.ApplyCollectorConfig(SelectedEntry);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        #endregion

        #region Change checking
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (!backgroundWorkerCheckOk.IsBusy)
                backgroundWorkerCheckOk.RunWorkerAsync();
        }
        private void cboParentCollector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!backgroundWorkerCheckOk.IsBusy)
                backgroundWorkerCheckOk.RunWorkerAsync();
        }
        private void cboCollector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!backgroundWorkerCheckOk.IsBusy)
                backgroundWorkerCheckOk.RunWorkerAsync();
        }
        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (!backgroundWorkerCheckOk.IsBusy)
                backgroundWorkerCheckOk.RunWorkerAsync();
        }
        private void chkCollectOnParentWarning_CheckedChanged(object sender, EventArgs e)
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
        #endregion

        #region Private methods
        private bool IsNotInCurrentDependantTree(string uniqueId, CollectorEntry ce)
        {
            if (ce.UniqueId != uniqueId)
            {
                if (ce.ParentCollectorId != null)
                {
                    CollectorEntry parentCe = (from pce in monitorPack.Collectors
                                               where pce.UniqueId == ce.ParentCollectorId
                                               select pce).FirstOrDefault();
                    if (parentCe != null)
                    {
                        return IsNotInCurrentDependantTree(uniqueId, parentCe);
                    }
                }
                return true;
            }
            return false;
        }
        private void ShowManualConfig()
        {
            this.MaximumSize = new Size(0, 0);            
            manualEditPanel.Visible = true;
            chkFolder.Enabled = false;
            this.Size = expandedSize;
            this.MinimumSize = expandedSize;
            configureEditButtonCollector.Enabled = false;
            cboCollector.Enabled = false;
            CheckOkEnable();
        }
        private void HideManualConfig()
        {
            manualEditPanel.Visible = false;    
            chkFolder.Enabled = true;
            this.Size = collapsedSize;
            this.MaximumSize = collapsedSize;
            this.MinimumSize = collapsedSize;
            configureEditButtonCollector.Enabled = true;
            cboCollector.Enabled = allowCollectorChange;
            CheckOkEnable();
            txtConfig.Text = "";
            //cmdCancel.Enabled = true;
        }
        private void CheckOkEnable()
        {
            bool isEnable = !manualEditPanel.Visible;
            if (txtName.Text.Length == 0 || cboParentCollector.SelectedIndex < 0 ||
                (!chkFolder.Checked && (cboCollector.SelectedIndex < 0 || editingCollectorEntry.InitialConfiguration == null || editingCollectorEntry.InitialConfiguration.Length == 0)))
                isEnable = false;

            cmdOK.Enabled = isEnable;

            configureEditButtonCollector.Enabled = cboCollector.SelectedIndex > -1 && !txtConfig.Visible && !chkFolder.Checked;
            cboCollector.Enabled = !chkFolder.Checked && allowCollectorChange && !manualEditPanel.Visible;
            chkCollectOnParentWarning.Enabled = !chkFolder.Checked;
            numericUpDownRepeatAlertInXMin.Enabled = !chkFolder.Checked;            
            AlertOnceInXMinNumericUpDown.Enabled = !chkFolder.Checked;
            delayAlertSecNumericUpDown.Enabled = !chkFolder.Checked;

            lblAgentDescription.Text = "";
            if (cboCollector.SelectedIndex > -1)
            {
                try
                {
                    RegisteredAgent ar = (RegisteredAgent)cboCollector.SelectedItem;
                    lblAgentDescription.Text = "Description: " + ar.ClassName;
                    System.Reflection.Assembly a = System.Reflection.Assembly.LoadFrom(ar.AssemblyPath);
                    lblAgentDescription.Text += ", Version: " + a.GetName().Version.ToString();
                    lblAgentDescription.Text += ", Assembly: " + System.IO.Path.GetFileName(a.Location);

                    //System.Reflection.AssemblyDescriptionAttribute ad = (System.Reflection.AssemblyDescriptionAttribute)System.Reflection.AssemblyDescriptionAttribute.GetCustomAttribute(
                    //    a, typeof(System.Reflection.AssemblyDescriptionAttribute));
                    //lblAgentDescription.Text = "Description: " + ad.Description;
                }
                catch { }
            }
        }
        #endregion

        #region Manual config edit context menu events
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtConfig.Copy();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtConfig.Paste();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtConfig.SelectAll();
        } 
        #endregion

        private void cmdRemoteAgentTest_Click(object sender, EventArgs e)
        {
            CollectorEntry textCollector = new CollectorEntry();
            textCollector.UniqueId = lblId.Text;
            textCollector.Name = txtName.Text.Trim();
            textCollector.Enabled = chkEnabled.Checked;
            textCollector.IsFolder = chkFolder.Checked;
            if (cboParentCollector.SelectedIndex > 0)
                textCollector.ParentCollectorId = ((CollectorEntry)cboParentCollector.SelectedItem).UniqueId;
            else
                textCollector.ParentCollectorId = "";

            if (chkFolder.Checked)
                textCollector.CollectorRegistrationName = "Folder";
            else
            {
                textCollector.CollectorRegistrationName = ((RegisteredAgent)cboCollector.SelectedItem).Name;
                textCollector.CollectorRegistrationDisplayName = ((RegisteredAgent)cboCollector.SelectedItem).DisplayName;
                textCollector.InitialConfiguration = editingCollectorEntry.Collector.AgentConfig.ToConfig();
            }
            textCollector.CollectOnParentWarning = chkCollectOnParentWarning.Checked && !chkFolder.Checked;
            textCollector.RepeatAlertInXMin = (int)numericUpDownRepeatAlertInXMin.Value;
            textCollector.AlertOnceInXMin = (int)AlertOnceInXMinNumericUpDown.Value;
            textCollector.DelayErrWarnAlertForXSec = (int)delayAlertSecNumericUpDown.Value;
            textCollector.CorrectiveScriptDisabled = chkCorrectiveScriptDisabled.Checked;
            textCollector.CorrectiveScriptOnWarningPath = txtCorrectiveScriptOnWarning.Text;
            textCollector.CorrectiveScriptOnErrorPath = txtCorrectiveScriptOnError.Text;
            textCollector.EnableRemoteExecute = chkRemoteAgentEnabled.Checked;
            textCollector.RemoteAgentHostAddress = txtRemoteAgentServer.Text;
            textCollector.RemoteAgentHostPort = (int)remoteportNumericUpDown.Value;

            try
            {
                MonitorState testState = CollectorEntryRelay.GetRemoteAgentState(textCollector);
                if (testState.State == CollectorState.Good)
                {
                    MessageBox.Show("Success", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format("State: {0}\r\nDetails: {1}", testState.State, testState.RawDetails), "Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkRemoteAgentEnabled_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
