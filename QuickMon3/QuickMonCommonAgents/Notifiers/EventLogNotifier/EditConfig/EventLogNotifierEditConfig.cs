using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Notifiers
{
    public partial class EventLogNotifierEditConfig : SimpleNotifierEditConfig
    {
        public EventLogNotifierEditConfig()
        {
            InitializeComponent();
            //this.Size = new Size(570, 270);
        }

        public override void LoadEditData()
        {
            EventLogNotifierConfig selectedEntry;
            if (SelectedEntry != null)
                selectedEntry = (EventLogNotifierConfig)SelectedEntry;
            else
                selectedEntry = (EventLogNotifierConfig)SelectedConfig;

            if (selectedEntry != null)
            {
                txtMachine.Text = selectedEntry.MachineName;
                txtEventSource.Text = selectedEntry.EventSource;
                successEventIDNumericUpDown.Value = selectedEntry.SuccessEventID;
                warningEventIDNumericUpDown.Value = selectedEntry.WarningEventID;
                errorEventIDNumericUpDown.Value = selectedEntry.ErrorEventID;
            }
            CheckOKEnabled();
            base.LoadEditData();
        }
        public override void OkClicked()
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
                if (SelectedEntry != null)
                    selectedEntry = (EventLogNotifierConfig)SelectedEntry;
                else
                    selectedEntry = (EventLogNotifierConfig)SelectedConfig;

                selectedEntry.MachineName = txtMachine.Text;
                selectedEntry.EventSource = txtEventSource.Text;
                selectedEntry.SuccessEventID = (int)successEventIDNumericUpDown.Value;
                selectedEntry.WarningEventID = (int)warningEventIDNumericUpDown.Value;
                selectedEntry.ErrorEventID = (int)errorEventIDNumericUpDown.Value;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void txtMachine_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private void txtEventSource_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void CheckOKEnabled()
        {
            SetOKEnabled(txtMachine.Text.Trim().Length > 0 && txtEventSource.Text.Trim().Length > 0);
        }

    }
}
