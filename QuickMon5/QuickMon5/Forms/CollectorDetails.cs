using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class CollectorDetails : Form
    {
        public CollectorDetails()
        {
            InitializeComponent();
        }

        /// <summary>
        /// If set to true the main window refresh cycle will also trigger a refresh of this window's details (the states/current value/history etc)
        /// </summary>
        public bool AutoRefreshEnabled { get; set; }
        public CollectorHost SelectedCollectorHost { get; set; }

        /// <summary>
        /// reference to MainForm for bidirectional updating
        /// </summary>
        private MainForm mainForm;

        private void chkActionScriptsVisible_CheckedChanged(object sender, EventArgs e)
        {
            splitContainerMain.Panel2Collapsed = !chkActionScriptsVisible.Checked;
        }
    }
}
