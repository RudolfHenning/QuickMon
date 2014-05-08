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
    public partial class EditConfig : Form
    {
        public EditConfig()
        {
            InitializeComponent();
            SelectedEventLogNotifierConfig = new EventLogNotifierConfig();
        }

        public EventLogNotifierConfig SelectedEventLogNotifierConfig { get; set; }

        private void EditConfig_Load(object sender, EventArgs e)
        {
            txtMachine.Text = SelectedEventLogNotifierConfig.MachineName;
            txtEventSource.Text = SelectedEventLogNotifierConfig.EventSource;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtMachine.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must specify the computer name!", "Computer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMachine.Focus();
            }
            else if (txtEventSource.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must specify the event source!", "Event source", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEventSource.Focus();
            }
            else
            {
                SelectedEventLogNotifierConfig.MachineName = txtMachine.Text;
                SelectedEventLogNotifierConfig.EventSource = txtEventSource.Text;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

    }
}
