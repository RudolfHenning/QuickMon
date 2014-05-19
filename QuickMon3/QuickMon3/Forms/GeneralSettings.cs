using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HenIT.ShellTools;

namespace QuickMon
{
    public partial class GeneralSettings : Form
    {
        public GeneralSettings()
        {
            InitializeComponent();
        }

        private bool loading = false;
        private bool freChanging = false;

        public int PollingFrequencySec { get; set; }
        public bool PollingEnabled { get; set; }

        private void GeneralSettings_Load(object sender, EventArgs e)
        {
            loading = true;
            concurrencyLevelNnumericUpDown.Value = Properties.Settings.Default.ConcurrencyLevel;
            chkSnapToDesktop.Checked = Properties.Settings.Default.MainFormSnap;
            chkAutosaveChanges.Checked = Properties.Settings.Default.AutosaveChanges;
            chkOverridesMonitorPackFrequency.Checked = Properties.Settings.Default.OverridesMonitorPackFrequency;
            chkPinToTaskbar.Checked = Shortcuts.PinnedToTaskbar();
            chkPinToStartMenu.Checked = Shortcuts.PinnedToStartMenu();
            chkDesktopShortcut.Checked = Shortcuts.DesktopShortCutExists("QuickMon 3");
            SetFrequency(PollingFrequencySec);
            
            chkPollingEnabled.Checked = PollingEnabled;
            loading = false;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            PollingFrequencySec = (int)freqSecNumericUpDown.Value;
            PollingEnabled = chkPollingEnabled.Checked;
            Properties.Settings.Default.ConcurrencyLevel = (int)concurrencyLevelNnumericUpDown.Value;
            Properties.Settings.Default.MainFormSnap = chkSnapToDesktop.Checked;
            Properties.Settings.Default.AutosaveChanges = chkAutosaveChanges.Checked;
            Properties.Settings.Default.OverridesMonitorPackFrequency = chkOverridesMonitorPackFrequency.Checked;
            Properties.Settings.Default.Save();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void chkPinToTaskbar_CheckedChanged(object sender, EventArgs e)
        {
            if (loading)
                return;
            try
            {
                if (!chkPinToTaskbar.Checked)
                    Shortcuts.UnPinToTaskBar();
                else
                    Shortcuts.PinToTaskBar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkPinToStartMenu_CheckedChanged(object sender, EventArgs e)
        {
            if (loading)
                return;
            try
            {
                if (!chkPinToStartMenu.Checked)
                    Shortcuts.UnPinToStartMenu();
                else
                    Shortcuts.PinToStartMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkDesktopShortcut_CheckedChanged(object sender, EventArgs e)
        {
            if (loading)
                return;
            try
            {
                if (chkDesktopShortcut.Checked)
                    Shortcuts.CreateDesktopShortcut("", "QuickMon 3");
                else
                    Shortcuts.DeleteDesktopShortcut("", "QuickMon 3");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llblPollingFreq_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetTimerConfig setTimerConfig = new SetTimerConfig();
            setTimerConfig.FrequencySec = PollingFrequencySec;
            setTimerConfig.TimerEnabled = PollingEnabled;
            if (setTimerConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PollingFrequencySec = setTimerConfig.FrequencySec;
                PollingEnabled = setTimerConfig.TimerEnabled;
            }
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
                if (frequency == 0)
                    frequency = 1;
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
