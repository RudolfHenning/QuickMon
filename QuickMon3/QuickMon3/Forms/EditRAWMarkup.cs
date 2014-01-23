using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using QuickMon;
using QuickMon.Management;

namespace QuickMon.Forms
{
    public partial class EditRAWMarkup : Form
    {
        public EditRAWMarkup()
        {
            InitializeComponent();
            UseNotifierType = false;
        }

        public string SelectedMarkup { get; set; }
        public string AgentType { get; set; }
        public MonitorPack CurrentMonitorPack { get; set; }
        public bool UseNotifierType { get; set; }

        private void EditRAWMarkup_Load(object sender, EventArgs e)
        {
            if (SelectedMarkup != null)
            {
                txtConfig.Text = XmlFormattingUtils.NormalizeXML(SelectedMarkup);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            XmlDocument testXml = new XmlDocument();
            try
            {
                testXml.LoadXml(txtConfig.Text);
                SelectedMarkup = txtConfig.Text;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error parsing xml\r\n{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtConfig_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            cmdOK.Enabled = txtConfig.Text.Length > 0;
            cmdFormat.Enabled = txtConfig.Text.Length > 0;
        }

        private void llblImportConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ImportCollectorConfig importCollectorConfig = new ImportCollectorConfig();
            importCollectorConfig.IsCollector = !UseNotifierType;
            if (CurrentMonitorPack != null)
            {
                importCollectorConfig.CurrentMonitorPack = CurrentMonitorPack; 
            }
            importCollectorConfig.AgentType = AgentType;
            if (importCollectorConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtConfig.Text = XmlFormattingUtils.NormalizeXML(importCollectorConfig.SelectedConfig);
            }
        }

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

        private void cmdFormat_Click(object sender, EventArgs e)
        {
            txtConfig.Text = XmlFormattingUtils.NormalizeXML(txtConfig.Text);
        }
    }
}
