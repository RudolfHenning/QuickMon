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
    public partial class EditTemplates : Form
    {
        public EditTemplates()
        {
            InitializeComponent();
        }

        #region Form events
        private void EditTemplates_Load(object sender, EventArgs e)
        {
            
            lvwTemplates.Groups.Add(new ListViewGroup("Monitor Pack"));
            lvwTemplates.Groups.Add(new ListViewGroup("Collector Host"));
            lvwTemplates.Groups.Add(new ListViewGroup("Collector Agent"));
            lvwTemplates.Groups.Add(new ListViewGroup("Notifier Host"));
            lvwTemplates.Groups.Add(new ListViewGroup("Notifier Agent"));
        }
        private void EditTemplates_Shown(object sender, EventArgs e)
        {
            cboTypeFilter.SelectedIndex = 5;
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
            IsSaveEnabled();
        }
        private void chkWrapText_CheckedChanged(object sender, EventArgs e)
        {
            txtConfig.WordWrap = chkWrapText.Checked;
        }
        private void cmdFormat_Click(object sender, EventArgs e)
        {
            bool changedBefore = cmdSaveTemplate.Enabled;
            txtConfig.Text = XmlFormattingUtils.NormalizeXML(txtConfig.Text);
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
        #endregion

        #region ListView events
        private void lvwTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedTemplate();
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
                    cboClass.Items.Add(ra.ClassName.Replace("QuickMon.Collectors.", ""));
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
                    cboClass.Items.Add(ra.ClassName.Replace("QuickMon.Notifiers.", ""));
                }
                cboClass.Text = "";
                cboClass.Enabled = true;
            }
        }
        private void LoadTemplates()
        {
            lvwTemplates.Items.Clear();
            foreach(QuickMonTemplate t in QuickMonTemplate.GetAllTemplates())
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
                QuickMonTemplate t = (QuickMonTemplate)lvwTemplates.SelectedItems[0].Tag;
                cboType.SelectedIndex = (int)t.TemplateType;
                txtName.Text = t.Name;
                cboClass.Text = t.ForClass;
                txtDescription.Text = t.Description;
                txtConfig.Text = XmlFormattingUtils.NormalizeXML(t.Config);
                cmdSaveTemplate.Enabled = false;
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

            if (lvwTemplates.SelectedItems.Count == 1 && lvwTemplates.SelectedItems[0].Tag is QuickMonTemplate)
            {
                lvi = lvwTemplates.SelectedItems[0];
                t = (QuickMonTemplate)lvwTemplates.SelectedItems[0].Tag;
            }
            else
            {
                lvi = new ListViewItem(txtName.Text);
                lvi.SubItems.Add(cboClass.Text);
                t = new QuickMonTemplate();
                lvwTemplates.Items.Add(lvi);
                lvwTemplates.SelectedItems.Clear();
                lvi.Selected = true;
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

            lvi.Text = txtName.Text;
            lvi.SubItems[1].Text = cboClass.Text;
            lvi.Group = lg;
            lvi.Tag = t;
            cmdSaveTemplate.Enabled = false;
        }
        private void CreateNewTemplate()
        {
            lvwTemplates.SelectedItems.Clear();
            txtName.Text = "";
            cboClass.Text = "";
            txtDescription.Text = "";
            txtConfig.Text = "";
            cmdSaveTemplate.Enabled = false;
        }
        private void IsSaveEnabled()
        {
            cmdSaveTemplate.Enabled = cboType.SelectedIndex > -1 && txtName.Text.Trim().Length > 0 && cboClass.Text.Trim().Length > 0 && txtConfig.Text.Trim().Length > 0;
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
                        txtConfig.Text = a.AgentConfig.GetDefaultOrEmptyXml();
                        txtConfig.Text = XmlFormattingUtils.NormalizeXML(txtConfig.Text);
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

    }
}

//Monitor Pack
//Collector Host
//Collector Agent
//Notifier Host
//Notifier Agent
//All