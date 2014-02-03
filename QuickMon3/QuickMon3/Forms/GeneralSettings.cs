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

        private void GeneralSettings_Load(object sender, EventArgs e)
        {
            concurrencyLevelNnumericUpDown.Value = Properties.Settings.Default.ConcurrencyLevel;
            chkSnapToDesktop.Checked = Properties.Settings.Default.MainFormSnap;
            chkAutosaveChanges.Checked = Properties.Settings.Default.AutosaveChanges;
            chkPinToTaskbar.Checked = Shortcuts.TaskBarShortCutExists();
            chkPinToStartMenu.Checked = Shortcuts.StartMenuShortCutExists();
            chkDesktopShortcut.Checked = Shortcuts.DesktopShortCutExists();
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
            try
            {
                if (chkDesktopShortcut.Checked)
                    Shortcuts.CreateDesktopShortcut();
                else
                    Shortcuts.DeleteDesktopShortcut();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
