﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class EditMonitorPackConfig : Form
    {
        public EditMonitorPackConfig()
        {
            InitializeComponent();
        }

        public MonitorPack SelectedMonitorPack { get; set; }

        private bool freChanging = false;

        private void EditMonitorPackConfig_Load(object sender, EventArgs e)
        {
            if (SelectedMonitorPack == null)
                SelectedMonitorPack = new MonitorPack();

            txtName.Text = SelectedMonitorPack.Name;
            chkCorrectiveScripts.Checked = SelectedMonitorPack.RunCorrectiveScripts;
            chkEnabled.Checked = SelectedMonitorPack.Enabled;
            collectorStateHistorySizeNumericUpDown.Value = SelectedMonitorPack.CollectorStateHistorySize;
            SetFrequency(SelectedMonitorPack.PollingFrequencyOverrideSec);
            LoadNotifiers();
        }

        private void LoadNotifiers()
        {
            cboDefaultNotifier.Items.Clear();
            foreach(NotifierEntry n in SelectedMonitorPack.Notifiers)
            {
                cboDefaultNotifier.Items.Add(n);
            }
            cboDefaultNotifier.SelectedItem = SelectedMonitorPack.DefaultViewerNotifier;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if(ValidateInput())
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                SelectedMonitorPack.Name = txtName.Text;
                SelectedMonitorPack.RunCorrectiveScripts = chkCorrectiveScripts.Checked;
                SelectedMonitorPack.Enabled = chkEnabled.Checked;
                SelectedMonitorPack.CollectorStateHistorySize = (int)collectorStateHistorySizeNumericUpDown.Value;
                SelectedMonitorPack.PollingFrequencyOverrideSec = (int)freqSecNumericUpDown.Value;
                if (cboDefaultNotifier.SelectedIndex > -1)
                    SelectedMonitorPack.DefaultViewerNotifier = (NotifierEntry)cboDefaultNotifier.SelectedItem;
                else
                    SelectedMonitorPack.DefaultViewerNotifier = null;
                Close();
            }
        }

        private bool ValidateInput()
        {
            if (txtName.Text.Trim().Length == 0)
            {
                txtName.Focus();
                return false;
            }
            else
                return true;
        }

        private void CheckOkEnable()
        {
            cmdOK.Enabled = (txtName.Text.Trim().Length > 0);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnable();
        }

        private void freqSecNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetFrequency((int)freqSecNumericUpDown.Value);
        }

        private void freqSecTrackBar_Scroll(object sender, EventArgs e)
        {
            SetFrequency(freqSecTrackBar.Value);
        }

        private void SetFrequency(int frequency)
        {
            if (!freChanging)
            {
                freChanging = true;
                if (freqSecNumericUpDown.Maximum >= frequency)
                    freqSecNumericUpDown.Value = frequency;
                else
                    freqSecNumericUpDown.Value = 10;
                freqSecTrackBar.Value = (int)freqSecNumericUpDown.Value;
                freChanging = false;
            }
        }


    }
}
