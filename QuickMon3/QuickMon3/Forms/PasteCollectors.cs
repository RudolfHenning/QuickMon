using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace QuickMon
{
    public partial class PasteCollectors : Form
    {
        public PasteCollectors()
        {
            InitializeComponent();
        }

        private MonitorPack monitorPack = null;

        public List<CollectorEntry> SelectedCollectors { get; set; }

        #region Form events
        private void PasteCollectors_Load(object sender, EventArgs e)
        {
            if (SelectedCollectors != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (CollectorEntry entry in SelectedCollectors)
                {
                    sb.AppendLine(entry.ToConfig());
                }
                txtConfig.Text = sb.ToString();
                txtConfig.SelectionStart = 0;
                txtConfig.DoCaretVisible();
            }
        } 
        #endregion

        #region Button events
        private void cmdPaste_Click(object sender, EventArgs e)
        {
            if (ParseTest())
            {
                if (monitorPack != null)
                {
                    SelectedCollectors = null;
                    SelectedCollectors = new List<CollectorEntry>();
                    foreach (CollectorEntry entry in monitorPack.Collectors)
                    {
                        SelectedCollectors.Add(entry.Clone());
                    }

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        } 
        private void cmdParse_Click(object sender, EventArgs e)
        {
            ParseTest(true);
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
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtConfig.ShowFindDialog();
        }
        private void findReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtConfig.ShowReplaceDialog();
        }
        #endregion

        #region Private methods
        private bool ParseTest(bool prompt = false)
        {
            //first check it it is valid XML
            string xmlText = @"<monitorPack version=""3.x.x.x"" name=""Test"" enabled=""False"" defaultViewerNotifier="""" runCorrectiveScripts=""False"">\r\n" +
                "<collectorEntries>\r\n" + txtConfig.Text + "\r\n</collectorEntries></monitorPack>";
            try
            {
                XmlDocument textDoc = new XmlDocument();
                textDoc.LoadXml(xmlText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("XML not formatted properly!\r\n" + ex.Message, "XML format", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            try
            {
                monitorPack = null;
                monitorPack = new MonitorPack();
                monitorPack.LoadXml(xmlText);
                if (prompt)
                    MessageBox.Show("Collector config seems to be ok!", "Collector config", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing collector config!\r\n" + ex.Message, "Collector config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        } 
        #endregion

    }
}
