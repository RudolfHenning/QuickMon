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
    public partial class SetTimerConfig : Form
    {
        public SetTimerConfig()
        {
            InitializeComponent();
        }

        public int FrequencySec { get; set; }
        public bool TimerEnabled { get; set; }

        private void SetTimerConfig_Load(object sender, EventArgs e)
        {
            freqSecNumericUpDown.Value = FrequencySec;
            chkEnabled.Checked = TimerEnabled;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            FrequencySec = (int)freqSecNumericUpDown.Value;
            TimerEnabled = chkEnabled.Checked;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

    }
}
