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
    public partial class SelectTemplate : Form
    {
        public SelectTemplate()
        {
            InitializeComponent();
        }

        public QuickMonTemplate SelectedTemplate { get; set; }
        public TemplateType FilterTemplatesBy { get; set; }

        private void SelectTemplate_Load(object sender, EventArgs e)
        {
            lvwTemplates.AutoResizeColumnIndex = 1;
            lvwTemplates.AutoResizeColumnEnabled = true;
        }
        private void SelectTemplate_Shown(object sender, EventArgs e)
        {
            LoadTemplates();
        }

        private void LoadTemplates()
        {
            Text = "Select Template - ";
            switch (FilterTemplatesBy)
            {
                case TemplateType.CollectorHost:
                    Text += "Collector Host";
                    break;
                case TemplateType.CollectorAgent:
                    Text += "Collector Agent";
                    break;
                case TemplateType.NotifierHost:
                    Text += "Notifier Host";
                    break;
                case TemplateType.NotifierAgent:
                    Text += "Notifier Agent";
                    break;
                default:
                    Text += "Monitor pack";
                    break;
            }
            lvwTemplates.Items.Clear();
            foreach (QuickMonTemplate template in (from p in QuickMonTemplate.GetAllTemplates()
                                                   where p.TemplateType == FilterTemplatesBy
                                                   orderby p.Name
                                                   select p))
            {
                try
                {
                    ListViewItem lvi = new ListViewItem(template.Name);
                    lvi.ImageIndex = 0;
                    string details = template.Description.Trim().Length == 0 ? template.Config : template.Description;
                    lvi.SubItems.Add(details);
                    lvi.Tag = template;
                    lvwTemplates.Items.Add(lvi);
                }
                catch { }
            }
        }
        private void lvwTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = lvwTemplates.SelectedItems.Count == 1;
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lvwTemplates.SelectedItems.Count == 1)
            {
                SelectedTemplate = (QuickMonTemplate)lvwTemplates.SelectedItems[0].Tag;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void lvwTemplates_DoubleClick(object sender, EventArgs e)
        {
            cmdOK_Click(null, null);
        }

        private void lvwTemplates_EnterKeyPressed()
        {
            cmdOK_Click(null, null);
        }
    }
}
