using QuickMon.Notifiers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.UI
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
                txtEventLogName.Text = selectedEntry.EventLogName;
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
                selectedEntry.EventLogName = txtEventLogName.Text;
                selectedEntry.EventSource = txtEventSource.Text;
                selectedEntry.SuccessEventID = (int)successEventIDNumericUpDown.Value;
                selectedEntry.WarningEventID = (int)warningEventIDNumericUpDown.Value;
                selectedEntry.ErrorEventID = (int)errorEventIDNumericUpDown.Value;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            string machineName = txtMachine.Text;
            string eventLogName = txtEventLogName.Text;
            string currentEventSource = txtEventSource.Text.Replace("%CollectorName%", "CollectorNameHere");
            try
            {
                if (!System.Diagnostics.EventLog.SourceExists(currentEventSource, machineName))
                {
                    System.Diagnostics.EventSourceCreationData escd = new System.Diagnostics.EventSourceCreationData(currentEventSource, eventLogName);
                    escd.MachineName = machineName;
                    System.Diagnostics.EventLog.CreateEventSource(escd);
                }
                try
                {
                    //in case some admin created the source in a different event log
                    eventLogName = System.Diagnostics.EventLog.LogNameFromSourceName(currentEventSource, machineName);
                }
                catch { }

                if (eventLogName.ToLower() != txtEventLogName.Text.ToLower())
                {
                    if (MessageBox.Show("Specified Event Source is associated with the Event log '" + eventLogName + "'!\r\nDo you want to automatically change the correct Log name?", "Test", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    {
                        txtEventLogName.Text = eventLogName;
                    }
                }

                System.Diagnostics.EventLog outputLog = new System.Diagnostics.EventLog(eventLogName, machineName, currentEventSource);
                outputLog.WriteEntry("Example success entry", System.Diagnostics.EventLogEntryType.Information, (int)successEventIDNumericUpDown.Value);
                outputLog.WriteEntry("Example warning entry", System.Diagnostics.EventLogEntryType.Warning, (int)warningEventIDNumericUpDown.Value);
                outputLog.WriteEntry("Example error entry", System.Diagnostics.EventLogEntryType.Error, (int)errorEventIDNumericUpDown.Value);
                MessageBox.Show("Events were successfully written. Please check the Event Log.", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
