using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

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
        }

        #region Private
        private MonitorPack monitorPack;
        private Size collapsedSize = new Size(600, 260);
        private Size expandedSize = new Size(600, 500); 
        #endregion

        public CollectorEntry SelectedEntry { get; set; }
        private bool allowCollectorChange = true;
        public bool AllowCollectorChange { get { return allowCollectorChange; } set { allowCollectorChange = value; } }

        public DialogResult ShowDialog(MonitorPack monitorPack)
        {
            this.monitorPack = monitorPack;
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

            foreach (AgentRegistration ar in (from a in monitorPack.AgentRegistrations
                                              where a.IsCollector
                                              orderby a.Name
                                              select a))
            {
                cboCollector.Items.Add(ar);
                if (ar.Name == SelectedEntry.CollectorRegistrationName)
                    cboCollector.SelectedItem = ar;
            }
            if (!SelectedEntry.IsFolder && cboCollector.SelectedItem == null && SelectedEntry.Name != null)
            {
                MessageBox.Show("Specified collector agent is not registered!", "Collector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            chkCollectOnParentWarning.Checked = SelectedEntry.CollectOnParentWarning;
            numericUpDownRepeatAlertInXMin.Value = SelectedEntry.RepeatAlertInXMin;
            AlertOnceInXMinNumericUpDown.Value = SelectedEntry.AlertOnceInXMin;
            delayAlertSecNumericUpDown.Value = SelectedEntry.DelayErrWarnAlertForXSec;
            linkLabelServiceWindows.Text = SelectedEntry.ServiceWindows.ToString();
            CheckOkEnable();
        }
        private void EditCollectorEntry_Load(object sender, EventArgs e)
        {
            this.Size = collapsedSize;
            this.MinimumSize = collapsedSize;
            this.MaximumSize = collapsedSize;
            lblConfig.Visible = false;
            txtConfig.Visible = false;
            lblConfigWarn.Visible = false;
            cmdSaveConfig.Visible = false;
            cmdCancelConfig.Visible = false;
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
                    AgentRegistration ar = (AgentRegistration)cboCollector.SelectedItem;
                    ICollector col = CollectorEntry.CreateCollectorEntry(ar.AssemblyPath, ar.ClassName);
                    if (col != null)
                    {
                        SelectedEntry.Collector = col;
                        if (SelectedEntry.Configuration == null)
                            SelectedEntry.Configuration = "";
                        string newConfig = col.ConfigureAgent(SelectedEntry.Configuration);
                        if (newConfig.Length > 0)
                        {
                            SelectedEntry.Configuration = newConfig;
                            CheckOkEnable();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cmdManualConfig_Click(object sender, EventArgs e)
        {
            txtConfig.Text = SelectedEntry.Configuration;
            if (txtConfig.Text.Length == 0 && cboCollector.SelectedItem != null)
            {
                try
                {
                    AgentRegistration ar = (AgentRegistration)cboCollector.SelectedItem;
                    ICollector col = CollectorEntry.CreateCollectorEntry(ar.AssemblyPath, ar.ClassName);
                    txtConfig.Text = col.GetDefaultOrEmptyConfigString();
                }
                catch { }
            }
            ShowManualConfig();
        }
        private void linkLabelServiceWindows_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditServiceWindows editServiceWindows = new EditServiceWindows();
            editServiceWindows.SelectedServiceWindows = SelectedEntry.ServiceWindows;
            if (editServiceWindows.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SelectedEntry.ServiceWindows = editServiceWindows.SelectedServiceWindows;
                linkLabelServiceWindows.Text = editServiceWindows.SelectedServiceWindows.ToString();
            }
        }
        private void importLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ImportCollectorConfig importCollectorConfig = new ImportCollectorConfig();
            importCollectorConfig.IsCollector = true;
            importCollectorConfig.MonitorPackPath = monitorPack.MonitorPackPath;
            importCollectorConfig.AgentType = ((AgentRegistration)cboCollector.SelectedItem).Name;
            if (importCollectorConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SelectedEntry.Configuration = importCollectorConfig.SelectedConfig;
            }
        }
        private void cmdSaveConfig_Click(object sender, EventArgs e)
        {
            XmlDocument testXml = new XmlDocument();
            try
            {
                testXml.LoadXml(txtConfig.Text);
                SelectedEntry.Configuration = txtConfig.Text;
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
                SelectedEntry.CollectorRegistrationName = ((AgentRegistration)cboCollector.SelectedItem).Name;
            SelectedEntry.CollectOnParentWarning = chkCollectOnParentWarning.Checked && !chkFolder.Checked;
            SelectedEntry.RepeatAlertInXMin = (int)numericUpDownRepeatAlertInXMin.Value;
            SelectedEntry.AlertOnceInXMin = (int)AlertOnceInXMinNumericUpDown.Value;
            SelectedEntry.DelayErrWarnAlertForXSec = (int)delayAlertSecNumericUpDown.Value;
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
            lblConfig.Visible = true;
            txtConfig.Visible = true;
            lblConfigWarn.Visible = true;
            this.Size = expandedSize;
            this.MinimumSize = expandedSize;
            manualEditlinkLabel.Enabled = false;
            cmdConfig.Enabled = false;
            cmdSaveConfig.Visible = true;
            cmdCancelConfig.Visible = true;
            cboCollector.Enabled = false;
            CheckOkEnable();
        }
        private void HideManualConfig()
        {
            lblConfig.Visible = false;
            txtConfig.Visible = false;
            lblConfigWarn.Visible = false;
            cmdSaveConfig.Visible = false;
            cmdCancelConfig.Visible = false;
            this.Size = collapsedSize;
            this.MaximumSize = collapsedSize;
            this.MinimumSize = collapsedSize;
            manualEditlinkLabel.Enabled = true;
            cmdConfig.Enabled = true;
            cboCollector.Enabled = allowCollectorChange;
            CheckOkEnable();
            txtConfig.Text = "";
        }
        private void CheckOkEnable()
        {
            bool isEnable = !txtConfig.Visible;
            if (txtName.Text.Length == 0 || cboParentCollector.SelectedIndex < 0 ||
                (!chkFolder.Checked && (cboCollector.SelectedIndex < 0 || SelectedEntry.Configuration == null || SelectedEntry.Configuration.Length == 0)))
                isEnable = false;

            cmdOK.Enabled = isEnable;

            cmdConfig.Enabled = cboCollector.SelectedIndex > -1 && !txtConfig.Visible && !chkFolder.Checked;
            manualEditlinkLabel.Enabled = cboCollector.SelectedIndex > -1 && !txtConfig.Visible && !chkFolder.Checked;
            importLinkLabel.Enabled = cboCollector.SelectedIndex > -1 && !txtConfig.Visible && !chkFolder.Checked;
            cboCollector.Enabled = !chkFolder.Checked && allowCollectorChange;
            chkCollectOnParentWarning.Enabled = !chkFolder.Checked;
            numericUpDownRepeatAlertInXMin.Enabled = !chkFolder.Checked;            
            AlertOnceInXMinNumericUpDown.Enabled = !chkFolder.Checked;
            delayAlertSecNumericUpDown.Enabled = !chkFolder.Checked;
        }
        #endregion       

    }
}
