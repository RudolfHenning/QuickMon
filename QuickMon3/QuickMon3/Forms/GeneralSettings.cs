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

        private void GeneralSettings_Load(object sender, EventArgs e)
        {
            loading = true;
            concurrencyLevelNnumericUpDown.Value = Properties.Settings.Default.ConcurrencyLevel;
            chkSnapToDesktop.Checked = Properties.Settings.Default.MainFormSnap;
            chkAutosaveChanges.Checked = Properties.Settings.Default.AutosaveChanges;
            chkPinToTaskbar.Checked = Shortcuts.PinnedToTaskbar();
            chkPinToStartMenu.Checked = Shortcuts.PinnedToStartMenu();
            chkDesktopShortcut.Checked = Shortcuts.DesktopShortCutExists("QuickMon 3");
            loading = false;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ConcurrencyLevel = (int)concurrencyLevelNnumericUpDown.Value;
            Properties.Settings.Default.MainFormSnap = chkSnapToDesktop.Checked;
            Properties.Settings.Default.AutosaveChanges = chkAutosaveChanges.Checked;
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
    }
}
