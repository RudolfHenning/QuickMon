using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace QuickMon.UI
{
    public partial class RAWXmlEditor : Form
    {
        public RAWXmlEditor()
        {
            InitializeComponent();
        }

        public string SelectedMarkup { get; set; }

        private void RAWXmlEditor_Load(object sender, EventArgs e)
        {
            if (SelectedMarkup != null && SelectedMarkup.Length > 0)
            {
                txtConfig.Text = XmlFormattingUtils.NormalizeXML(SelectedMarkup);
            }
        }

        private void txtConfig_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            try
            {
                cmdFormat.Enabled = txtConfig.Text.Length > 0;
                XmlDocument testXml = new XmlDocument();
                testXml.LoadXml(txtConfig.Text);
                cmdOK.Enabled = true;
            }
            catch (Exception)
            {

                cmdOK.Enabled = false;
            }
        }

        private void cmdFormat_Click(object sender, EventArgs e)
        {
            txtConfig.Text = XmlFormattingUtils.NormalizeXML(txtConfig.Text);
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
            txtConfig.Text = XmlFormattingUtils.NormalizeXML(txtConfig.Text);
        }
        #endregion



    }
}
