using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class TemplateEditor : Form, IChildWindowIdentity
    {   
        public TemplateEditor()
        {
            InitializeComponent();
        }

        #region IChildWindowIdentity
        public bool AutoRefreshEnabled { get; set; }
        public string Identifier { get; set; }
        public IParentWindow ParentWindow { get; set; }
        public void RefreshDetails()
        {
            LoadTemplates();
        }
        public void DeRegisterChildWindow()
        {
            if (ParentWindow != null)
                ParentWindow.RemoveChildWindow(this);
        }
        public void ShowChildWindow(IParentWindow parentWindow = null)
        {
            if (parentWindow != null)
                ParentWindow = parentWindow;
            if (ParentWindow != null)
                ParentWindow.RegisterChildWindow(this);
            Show();
        }
        #endregion

        #region Form events
        private void TemplateEditor_Load(object sender, EventArgs e)
        {
            lvwTemplates.Groups.Add(new ListViewGroup("Monitor Pack"));
            lvwTemplates.Groups.Add(new ListViewGroup("Collector Host"));
            lvwTemplates.Groups.Add(new ListViewGroup("Collector Agent"));
            lvwTemplates.Groups.Add(new ListViewGroup("Notifier Host"));
            lvwTemplates.Groups.Add(new ListViewGroup("Notifier Agent"));
        }

        private void TemplateEditor_Shown(object sender, EventArgs e)
        {
            cboTypeFilter.SelectedIndex = 5;
        }
        private void TemplateEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeRegisterChildWindow();
        }
        #endregion

        #region Control events
        private void cboTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTypeFilter.SelectedIndex < 5)
            {
                cboType.SelectedIndex = cboTypeFilter.SelectedIndex;
                cboType.Enabled = false;
            }
            else
            {
                cboType.Enabled = true;
            }
            LoadTemplates();
        }
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadClassesCombo();
            SetDefaultConfigStringForType();
            IsSaveEnabled();
        }
        private void chkWrapText_CheckedChanged(object sender, EventArgs e)
        {
            txtConfig.WordWrap = chkWrapText.Checked;
        }
        private void cmdFormat_Click(object sender, EventArgs e)
        {
            bool changedBefore = cmdSaveTemplate.Enabled;
            try
            {
                txtConfig.Text = txtConfig.Text.BeautifyXML(); // XmlFormattingUtils.NormalizeXML(txtConfig.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error formatting xml\r\n{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            cmdSaveTemplate.Enabled = changedBefore;
        }
        private void cmdSaveTemplate_Click(object sender, EventArgs e)
        {
            SaveSelectedTemplate();
        }
        #endregion

        #region Toolbar events
        private void addTemplateToolStripButton_Click(object sender, EventArgs e)
        {
            CreateNewTemplate();
        }
        private void deletePresetToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all selected templates?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (ListViewItem lvi in lvwTemplates.SelectedItems)
                    lvwTemplates.Items.Remove(lvi);
                SaveAllTemplates();
                CreateNewTemplate(); //to blank out everything
                IsSaveEnabled();
            }
        }
        private void resetToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset all templates to the defaults that came with the original installation?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                QuickMonTemplate.ResetTemplates();
                CreateNewTemplate(); //to blank out everything
                LoadTemplates();
            }
        }
        private void exportToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (exportFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.File.Copy(MonitorPack.GetQuickMonUserDataTemplatesFile(), exportFileDialog.FileName, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void importToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to import and reset all existing templates?", "Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (importFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        System.IO.File.Copy(importFileDialog.FileName, MonitorPack.GetQuickMonUserDataTemplatesFile(), true);
                        LoadTemplates();
                        CreateNewTemplate();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveAllTemplates();
        }
        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            LoadTemplates();
            CreateNewTemplate();
        }
        #endregion

        #region ListView events
        private void lvwTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedTemplate();
            deletePresetToolStripButton.Enabled = lvwTemplates.SelectedItems.Count > 0;
        }
        #endregion

        #region Private methods
        private void LoadClassesCombo()
        {
            cboClass.Items.Clear();
            if (cboType.SelectedIndex == 0)
            {
                cboClass.Items.Add("MonitorPack");
                cboClass.Text = "MonitorPack";
                cboClass.Enabled = false;
            }
            else if (cboType.SelectedIndex == 1)
            {
                cboClass.Items.Add("CollectorHost");
                cboClass.Text = "CollectorHost";
                cboClass.Enabled = false;
            }
            else if (cboType.SelectedIndex == 3)
            {
                cboClass.Items.Add("NotifierHost");
                cboClass.Text = "NotifierHost";
                cboClass.Enabled = false;
            }
            else if (cboType.SelectedIndex == 2)
            {
                foreach (RegisteredAgent ra in (from r in RegisteredAgentCache.Agents
                                                where r.IsCollector
                                                orderby r.ClassName
                                                select r))
                {
                    cboClass.Items.Add(ra.ClassName);
                }
                cboClass.Text = "";
                cboClass.Enabled = true;
            }
            else
            {
                foreach (RegisteredAgent ra in (from r in RegisteredAgentCache.Agents
                                                where !r.IsCollector
                                                orderby r.ClassName
                                                select r))
                {
                    cboClass.Items.Add(ra.ClassName);
                }
                cboClass.Text = "";
                cboClass.Enabled = true;
            }
        }
        private void LoadTemplates()
        {
            lvwTemplates.Items.Clear();
            foreach (QuickMonTemplate t in (from t in QuickMonTemplate.GetAllTemplates()
                                            orderby t.Name
                                            select t))
            {
                if (
                    cboTypeFilter.SelectedIndex == 5 ||
                    (
                        (cboTypeFilter.SelectedIndex == 0 && t.TemplateType == TemplateType.MonitorPack) ||
                        (cboTypeFilter.SelectedIndex == 1 && t.TemplateType == TemplateType.CollectorHost) ||
                        (cboTypeFilter.SelectedIndex == 2 && t.TemplateType == TemplateType.CollectorAgent) ||
                        (cboTypeFilter.SelectedIndex == 3 && t.TemplateType == TemplateType.NotifierHost) ||
                        (cboTypeFilter.SelectedIndex == 4 && t.TemplateType == TemplateType.NotifierAgent)
                    )
                    )
                {
                    ListViewGroup lg = (from ListViewGroup g in lvwTemplates.Groups
                                        where
                                            (g.Header == "Monitor Pack" && t.TemplateType == TemplateType.MonitorPack) ||
                                            (g.Header == "Collector Host" && t.TemplateType == TemplateType.CollectorHost) ||
                                            (g.Header == "Collector Agent" && t.TemplateType == TemplateType.CollectorAgent) ||
                                            (g.Header == "Notifier Host" && t.TemplateType == TemplateType.NotifierHost) ||
                                            (g.Header == "Notifier Agent" && t.TemplateType == TemplateType.NotifierAgent)
                                        select g).FirstOrDefault();
                    ListViewItem lvi = new ListViewItem(t.Name);
                    lvi.SubItems.Add(t.ForClass);
                    lvi.SubItems.Add(t.Description);
                    lvi.Group = lg;
                    lvi.Tag = t;
                    lvwTemplates.Items.Add(lvi);
                }
            }
        }
        private void LoadSelectedTemplate()
        {
            if (lvwTemplates.SelectedItems.Count == 1 && lvwTemplates.SelectedItems[0].Tag is QuickMonTemplate)
            {
                cboType.Enabled = cboTypeFilter.SelectedIndex == 5;
                txtName.Enabled = true;
                cboClass.Enabled = true;
                txtDescription.Enabled = true;

                QuickMonTemplate t = (QuickMonTemplate)lvwTemplates.SelectedItems[0].Tag;
                cboType.SelectedIndex = (int)t.TemplateType;
                txtName.Text = t.Name;
                cboClass.Text = t.ForClass;
                txtDescription.Text = t.Description;
                txtConfig.Text = t.Config;
                try
                {
                    txtConfig.Text = txtConfig.Text.BeautifyXML(); // XmlFormattingUtils.NormalizeXML(txtConfig.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Error formatting xml\r\n{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                SetSaveButton(false);
            }
            else
            {
                cboType.Enabled = lvwTemplates.SelectedItems.Count == 0 && cboTypeFilter.SelectedIndex == 5;
                txtName.Enabled = lvwTemplates.SelectedItems.Count == 0;
                cboClass.Enabled = lvwTemplates.SelectedItems.Count == 0;
                txtDescription.Enabled = lvwTemplates.SelectedItems.Count == 0;
                txtName.Text = "";
                cboClass.Text = "";
                txtDescription.Text = "";
                txtConfig.Text = "";
                SetSaveButton(false);
            }
        }
        private void SaveSelectedTemplate()
        {
            ListViewItem lvi;
            QuickMonTemplate t;
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must specify the a name for the template!", "Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtName.Focus();
                return;
            }
            if (cboType.SelectedIndex == -1)
            {
                MessageBox.Show("You must specify the template type!", "Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboType.Focus();
                return;
            }
            if (txtConfig.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must specify the config for the template!", "Config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtConfig.Focus();
                return;
            }
            if (((TemplateType)cboType.SelectedIndex) == TemplateType.CollectorHost)
            {
                try
                {
                    System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
                    xdoc.LoadXml(txtConfig.Text);
                    System.Xml.XmlElement root = xdoc.DocumentElement;
                    if (root.ReadXmlElementAttr("uniqueId", "") == "" || root.ReadXmlElementAttr("dependOnParentId", "") == "")
                    {
                        root.SetAttributeValue("uniqueId", "");
                        root.SetAttributeValue("dependOnParentId", "");
                        //txtConfig.Text = XmlFormattingUtils.NormalizeXML(xdoc.OuterXml);
                        txtConfig.Text = xdoc.OuterXml.BeautifyXML();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Invalid config!\r\n" + ex.Message, "Config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (lvwTemplates.SelectedItems.Count == 1 && lvwTemplates.SelectedItems[0].Tag is QuickMonTemplate)
            {
                lvi = lvwTemplates.SelectedItems[0];
                t = (QuickMonTemplate)lvwTemplates.SelectedItems[0].Tag;
            }
            else
            {
                lvi = new ListViewItem(txtName.Text);
                lvi.SubItems.Add(cboClass.Text);
                lvi.SubItems.Add(txtDescription.Text);
                t = new QuickMonTemplate();
                lvwTemplates.Items.Add(lvi);
            }
            t.Name = txtName.Text;
            t.TemplateType = (TemplateType)cboType.SelectedIndex;
            t.ForClass = cboClass.Text;
            t.Description = txtDescription.Text;
            t.Config = txtConfig.Text;

            ListViewGroup lg = (from ListViewGroup g in lvwTemplates.Groups
                                where
                                    (g.Header == "Monitor Pack" && t.TemplateType == TemplateType.MonitorPack) ||
                                    (g.Header == "Collector Host" && t.TemplateType == TemplateType.CollectorHost) ||
                                    (g.Header == "Collector Agent" && t.TemplateType == TemplateType.CollectorAgent) ||
                                    (g.Header == "Notifier Host" && t.TemplateType == TemplateType.NotifierHost) ||
                                    (g.Header == "Notifier Agent" && t.TemplateType == TemplateType.NotifierAgent)
                                select g).FirstOrDefault();
            lvi.Selected = true;
            lvi.Text = t.Name;
            lvi.SubItems[1].Text = t.ForClass;
            lvi.SubItems[2].Text = t.Description;
            lvi.Group = lg;
            lvi.Tag = t;
            SaveAllTemplates();
            SetSaveButton(false);
        }
        private void SaveAllTemplates()
        {
            List<QuickMonTemplate> list = new List<QuickMonTemplate>();
            foreach (ListViewItem lvi in lvwTemplates.Items)
            {
                if (lvi.Tag is QuickMonTemplate)
                {
                    QuickMonTemplate t = (QuickMonTemplate)lvi.Tag;
                    list.Add(t);
                }
            }
            QuickMonTemplate.SaveTemplates(list);
        }
        private void CreateNewTemplate()
        {
            lvwTemplates.SelectedItems.Clear();
            cboType.Enabled = cboTypeFilter.SelectedIndex == 5;
            txtName.Enabled = true;
            cboClass.Enabled = true;
            txtDescription.Enabled = true;
            txtName.Text = "";
            cboClass.Text = "";
            txtDescription.Text = "";
            txtConfig.Text = "";
            cmdSaveTemplate.Enabled = false;
        }
        private void IsSaveEnabled()
        {
            SetSaveButton(cboType.SelectedIndex > -1 && txtName.Text.Trim().Length > 0 && cboClass.Text.Trim().Length > 0 && txtConfig.Text.Trim().Length > 0 && lvwTemplates.SelectedItems.Count <= 1);
        }
        private void SetSaveButton(bool enabled)
        {
            saveToolStripButton.Enabled = enabled;
            cmdSaveTemplate.Enabled = enabled;
        }
        private void SetDefaultConfigStringForType()
        {
            if (lvwTemplates.SelectedItems.Count == 1 && txtConfig.Text.Length > 0)
            {
                if (MessageBox.Show("Are you sure you want to change the template type and reset the existing configuration?", "Type", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;
            }
            if (cboType.SelectedIndex == 0)
                txtConfig.Text = Properties.Resources.BlankTemplateMonitorPack;
            else if (cboType.SelectedIndex == 1)
                txtConfig.Text = Properties.Resources.BlankTemplateCollectorHost;
            else if (cboType.SelectedIndex == 2)
                txtConfig.Text = Properties.Resources.BlankTemplateCollectorAgent;
            else if (cboType.SelectedIndex == 3)
                txtConfig.Text = Properties.Resources.BlankTemplateNotifierHost;
            else if (cboType.SelectedIndex == 4)
                txtConfig.Text = Properties.Resources.BlankTemplateNotifierAgent;
        }
        #endregion

        #region Change tracking
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            IsSaveEnabled();
        }
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (txtConfig.Text.Length == 0)
            if (cboType.SelectedIndex == 2 || cboType.SelectedIndex == 4)
            {
                RegisteredAgent ra = (from r in RegisteredAgentCache.Agents
                                      where r.ClassName.EndsWith(cboClass.Text)
                                      select r).FirstOrDefault();
                if (ra != null)
                {
                    IAgent a;

                    if (ra.IsCollector)
                    {
                        a = CollectorHost.CreateCollectorFromClassName(ra.ClassName.Replace("QuickMon.Collectors.", ""));
                    }
                    else
                        a = NotifierHost.CreateNotifierFromClassName(ra.ClassName.Replace("QuickMon.Notifiers.", ""));
                    if (a != null)
                    {
                        string agentConfig = a.AgentConfig.GetDefaultOrEmptyXml();
                        if (cboType.SelectedIndex == 2)
                            txtConfig.Text = Properties.Resources.BlankTemplateCollectorAgent.Replace("{0}", agentConfig);
                        else if (cboType.SelectedIndex == 4)
                            txtConfig.Text = Properties.Resources.BlankTemplateNotifierAgent.Replace("{0}", agentConfig);
                        //txtConfig.Text = XmlFormattingUtils.NormalizeXML(txtConfig.Text);
                        try
                        {
                            txtConfig.Text = txtConfig.Text.BeautifyXML(); // XmlFormattingUtils.NormalizeXML(txtConfig.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(string.Format("Error formatting xml\r\n{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            IsSaveEnabled();
        }
        private void cboClass_TextChanged(object sender, EventArgs e)
        {
            IsSaveEnabled();
        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            IsSaveEnabled();
        }
        private void txtConfig_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            IsSaveEnabled();
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
        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmdFormat_Click(null, null);
        }
        #endregion

        private void llblVariableTip_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.ShowTextDialog tipWindow = new Forms.ShowTextDialog();
            tipWindow.Height = 200;
            tipWindow.ShowScrollbars = false;
            tipWindow.TextAlign = HorizontalAlignment.Center;
            tipWindow.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            tipWindow.TopMost = true;
            tipWindow.ShowText("Variables tip", "\r\nYou can set up variables that will be use to prompt you for a value when use the template.\r\n\r\nUse [[Variable Name]] to create a variable named 'Variable Name'\r\n\r\nTo specify a default value use [[Variable Name:default value]]", true);
        }
    }
}
