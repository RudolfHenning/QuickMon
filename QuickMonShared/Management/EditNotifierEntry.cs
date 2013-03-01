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
    public partial class EditNotifierEntry : Form
    {
        public EditNotifierEntry()
        {
            InitializeComponent();
            SelectedEntry = new NotifierEntry();
            SelectedEntry.Enabled = true;
            SelectedEntry.AlertLevel = AlertLevel.Warning;
            SelectedEntry.DetailLevel = DetailLevel.Detail;
        }

        private MonitorPack monitorPack;
        private Size collapsedSize = new Size(500, 250);
        private Size expandedSize = new Size(500, 400);

        public NotifierEntry SelectedEntry { get; set; }

        public DialogResult ShowDialog(MonitorPack monitorPack)
        {
            this.monitorPack = monitorPack;
            return ShowDialog();
        }

        #region Form events
        private void EditNotifierEntry_Load(object sender, EventArgs e)
        {
            this.Size = collapsedSize;
            this.MaximumSize = collapsedSize;
            //lblConfig.Visible = false;
            txtConfig.Visible = false;
            lblConfigWarn.Visible = false;
            cmdSaveConfig.Visible = false;
            cmdCancelConfig.Visible = false;
        }
        private void EditNotifierEntry_Shown(object sender, EventArgs e)
        {
            txtName.Text = SelectedEntry.Name;
            chkEnabled.Checked = SelectedEntry.Enabled;

            foreach (AgentRegistration ar in (from a in monitorPack.AgentRegistrations
                                              orderby a.Name
                                              where a.IsNotifier
                                              select a))
            {
                cboNotifier.Items.Add(ar);
                if (ar.Name == SelectedEntry.NotifierRegistrationName)
                    cboNotifier.SelectedItem = ar;
            }
            cboAlertLevel.SelectedIndex = (int)SelectedEntry.AlertLevel;
            cboDetailLevel.SelectedIndex = (int)SelectedEntry.DetailLevel;
            SetAlertForCollectors();
            
            CheckOkEnable();
        }

        
        #endregion

        #region Button events
        private void cmdConfig_Click(object sender, EventArgs e)
        {
            if (cboNotifier.SelectedItem != null)
            {
                try
                {
                    AgentRegistration ar = (AgentRegistration)cboNotifier.SelectedItem;
                    INotifier notifier = NotifierEntry.CreateNotifierEntry(ar.AssemblyPath, ar.ClassName);
                    if (notifier != null)
                    {
                        SelectedEntry.Notifier = notifier;
                        if (SelectedEntry.Configuration == null)
                            SelectedEntry.Configuration = "";
                        string newConfig = notifier.ConfigureAgent(SelectedEntry.Configuration);
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
            try
            {
                if ((SelectedEntry.Configuration == null || SelectedEntry.Configuration.Length == 0) && cboNotifier.SelectedItem != null)
                {
                    AgentRegistration ar = (AgentRegistration)cboNotifier.SelectedItem;
                    INotifier col = NotifierEntry.CreateNotifierEntry(ar.AssemblyPath, ar.ClassName);
                    txtConfig.Text = XmlFormattingUtils.NormalizeXML(col.GetDefaultOrEmptyConfigString());
                }
                else
                {
                    txtConfig.Text = XmlFormattingUtils.NormalizeXML(SelectedEntry.Configuration);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error getting new/existing configuration\r\n{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            ShowManualConfig();
        }
        private void cmdSaveConfig_Click(object sender, EventArgs e)        {
            
            try
            {
                if (txtConfig.Text.Length > 0)
                {
                    XmlDocument testXml = new XmlDocument();
                    testXml.LoadXml(txtConfig.Text);
                }
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
            try
            {
                SelectedEntry.Name = txtName.Text;
                SelectedEntry.Enabled = chkEnabled.Checked;
                SelectedEntry.AlertLevel = (AlertLevel)cboAlertLevel.SelectedIndex;
                SelectedEntry.DetailLevel = (DetailLevel)cboDetailLevel.SelectedIndex;
                SelectedEntry.NotifierRegistrationName = ((AgentRegistration)cboNotifier.SelectedItem).Name;
                AgentRegistration ar = (AgentRegistration)cboNotifier.SelectedItem;
                SelectedEntry.Notifier = NotifierEntry.CreateNotifierEntry(ar.AssemblyPath, ar.ClassName);

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
            selectNotifierCollectors.SelectedCollectors.AddRange(SelectedEntry.AlertForCollectors.ToArray());
            if (selectNotifierCollectors.ShowNotifierCollectors(monitorPack) == System.Windows.Forms.DialogResult.OK)
            {
                SelectedEntry.AlertForCollectors.Clear();
                SelectedEntry.AlertForCollectors.AddRange(selectNotifierCollectors.SelectedCollectors.ToArray());
                SetAlertForCollectors();
            }
        }
        private void configureEditButtonNotifier_ImportConfigurationClicked(object sender, EventArgs e)
        {
            ImportCollectorConfig importCollectorConfig = new ImportCollectorConfig();
            importCollectorConfig.IsCollector = false;
            importCollectorConfig.MonitorPackPath = monitorPack.MonitorPackPath;
            importCollectorConfig.AgentType = ((AgentRegistration)cboNotifier.SelectedItem).Name;
            if (importCollectorConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SelectedEntry.Configuration = importCollectorConfig.SelectedConfig;
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
        #endregion

        #region Private methods
        private void CheckOkEnable()
        {
            bool isEnable = !txtConfig.Visible;
            if (txtName.Text.Length == 0 || cboNotifier.SelectedIndex < 0 || SelectedEntry.Configuration == null || SelectedEntry.Configuration.Length == 0)
                isEnable = false;

            cmdOK.Enabled = isEnable;
            configureEditButtonNotifier.Enabled = cboNotifier.SelectedIndex > -1 && !txtConfig.Visible;
            lblAgentDescription.Text = "";
            if (cboNotifier.SelectedIndex > -1)
            {
                try
                {
                    AgentRegistration ar = (AgentRegistration)cboNotifier.SelectedItem;
                    System.Reflection.Assembly a = System.Reflection.Assembly.LoadFrom(ar.AssemblyPath);
                    System.Reflection.AssemblyDescriptionAttribute ad = (System.Reflection.AssemblyDescriptionAttribute)System.Reflection.AssemblyDescriptionAttribute.GetCustomAttribute(
                        a, typeof(System.Reflection.AssemblyDescriptionAttribute));
                    lblAgentDescription.Text = "Description: " + ad.Description;
                }
                catch { }
            }
        }
        private void ShowManualConfig()
        {
            this.MaximumSize = new Size(0, 0);
            lblConfig.Visible = true;
            txtConfig.Visible = true;
            lblConfigWarn.Visible = true;
            this.Size = expandedSize;
            this.MinimumSize = expandedSize;
            this.MinimumSize = expandedSize;
            configureEditButtonNotifier.Enabled = false;
            cmdSaveConfig.Visible = true;
            cmdCancelConfig.Visible = true;
            cboNotifier.Enabled = false;
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
            configureEditButtonNotifier.Enabled = true;
            cboNotifier.Enabled = true;
            CheckOkEnable();
            txtConfig.Text = "";
        }
        private void SetAlertForCollectors()
        {
            if (SelectedEntry.AlertForCollectors == null || SelectedEntry.AlertForCollectors.Count == 0)
                alertForCollectorslinkLabel.Text = "All Collectors";
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < SelectedEntry.AlertForCollectors.Count && i < 100; i++)
                {
                    sb.Append(SelectedEntry.AlertForCollectors[i] + ", ");
                }
                alertForCollectorslinkLabel.Text = sb.ToString().TrimEnd(' ', ',');
                if (SelectedEntry.AlertForCollectors.Count > 100)
                    alertForCollectorslinkLabel.Text += "...";
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

    }
}
