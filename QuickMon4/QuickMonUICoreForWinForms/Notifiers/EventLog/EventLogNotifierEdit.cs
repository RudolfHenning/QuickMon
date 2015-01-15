using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Notifiers
{
    public partial class EventLogNotifierEdit : Form, IAgentConfigEntryEditWindow
    {
        public EventLogNotifierEdit()
        {
            InitializeComponent();
        }

        public IAgentConfig SelectedEntry { get; set; }

        public QuickMonDialogResult ShowEditEntry()
        {
            LoadEditData();
            return (QuickMonDialogResult)ShowDialog();
        }

        private void LoadEditData()
        {
            EventLogNotifierConfig selectedEntry = new EventLogNotifierConfig();
            if (SelectedEntry != null)
                selectedEntry = (EventLogNotifierConfig)SelectedEntry;

            if (selectedEntry != null)
            {
                txtMachine.Text = selectedEntry.MachineName;
                txtEventSource.Text = selectedEntry.EventSource;
                successEventIDNumericUpDown.Value = selectedEntry.SuccessEventID;
                warningEventIDNumericUpDown.Value = selectedEntry.WarningEventID;
                errorEventIDNumericUpDown.Value = selectedEntry.ErrorEventID;
            }
            CheckOKEnabled();
        }
        private void CheckOKEnabled()
        {
            cmdOK.Enabled = txtMachine.Text.Trim().Length > 0 && txtEventSource.Text.Trim().Length > 0;
        }

        private void txtMachine_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void txtEventSource_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
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
                EventLogNotifierConfig selectedEntry;
                if (SelectedEntry == null)
                    SelectedEntry = new EventLogNotifierConfig();
                selectedEntry = (EventLogNotifierConfig)SelectedEntry;

                selectedEntry.MachineName = txtMachine.Text;
                selectedEntry.EventSource = txtEventSource.Text;
                selectedEntry.SuccessEventID = (int)successEventIDNumericUpDown.Value;
                selectedEntry.WarningEventID = (int)warningEventIDNumericUpDown.Value;
                selectedEntry.ErrorEventID = (int)errorEventIDNumericUpDown.Value;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
    }
}
