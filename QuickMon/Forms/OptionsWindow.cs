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
    public partial class OptionsWindow : Form
    {
        public OptionsWindow()
        {
            InitializeComponent();
        }

        private void OptionsWindow_Load(object sender, EventArgs e)
        {
            numericUpDownPollFrequency.Value = Properties.Settings.Default.PollFrequency / 1000;
            chkDisablePollingOnError.Checked = Properties.Settings.Default.DisablePollingOnError;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PollFrequency = (int)numericUpDownPollFrequency.Value * 1000;
            Properties.Settings.Default.DisablePollingOnError = chkDisablePollingOnError.Checked;
            Properties.Settings.Default.Save();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
