using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class TestCollectorHostEdit : Form
    {
        public TestCollectorHostEdit()
        {
            InitializeComponent();
        }

        private void TestCollectorHostEdit_Load(object sender, EventArgs e)
        {

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

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtConfig.Text = XmlFormattingUtils.NormalizeXML(txtConfig.Text);
        }
    }
}
