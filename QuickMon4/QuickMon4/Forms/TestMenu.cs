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
    public partial class TestMenu : Form
    {
        public TestMenu()
        {
            InitializeComponent();
        }

        #region Test stuff
        private void cmdTestRun1_Click(object sender, EventArgs e)
        {
            TestRun1 tr1 = new TestRun1();
            tr1.Show();
        }
        private void cmdTestRun2_Click(object sender, EventArgs e)
        {
            TestRun2Notifiers tr2 = new TestRun2Notifiers();
            tr2.Show();
        }
        private void cmdTestEdit_Click(object sender, EventArgs e)
        {
            TestCollectorHostEdit tce = new TestCollectorHostEdit();
            tce.Show();
        }
        #endregion
    }
}
