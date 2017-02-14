using HenIT.ShellTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class GeneralSettings : FadeSnapForm
    {
        public GeneralSettings()
        {
            InitializeComponent();
        }

        private bool loading = false;
        private bool freChanging = false;
        private int panelAppSettingsHeight = 0;
        private int panelPollingSettingsHeight = 0;
        private int panelPasswordManagementHeight = 0;

        private void flowLayoutPanelSettings_Resize(object sender, EventArgs e)
        {
            int clientSize= flowLayoutPanelSettings.ClientSize.Width - flowLayoutPanelSettings.Margin.Left - flowLayoutPanelSettings.Margin.Right - 1;
            foreach (Control c in flowLayoutPanelSettings.Controls)
            {
                if (c is Panel)
                {
                    c.Width = clientSize;
                }
            }
        }

        private void GeneralSettings_Load(object sender, EventArgs e)
        {
            this.Size = new Size(550, 450);
            panelAppSettingsHeight = panelAppSettings.Height;
            panelPollingSettingsHeight = panelPollingSettings.Height;
            panelPasswordManagementHeight = panelPasswordManagement.Height;
            //cmdPollingSettingsToggle_Click(null, null);
            cmdPasswordManagementToggle_Click(null, null);

            loading = true;
            concurrencyLevelNnumericUpDown.Value = Properties.Settings.Default.ConcurrencyLevel;
            chkSnapToDesktop.Checked = Properties.Settings.Default.MainFormSnap;
            chkAutosaveChanges.Checked = Properties.Settings.Default.AutosaveChanges;
            chkCreateBackupOnSave.Checked = Properties.Settings.Default.CreateBackupOnSave;
            chkOverridesMonitorPackFrequency.Checked = Properties.Settings.Default.OverridesMonitorPackFrequency;
            if (Properties.Settings.Default.RecentQMConfigFileFilters == null || Properties.Settings.Default.RecentQMConfigFileFilters.Trim() == "")
                txtRecentMonitorPackFilter.Text = "*";
            else
                txtRecentMonitorPackFilter.Text = Properties.Settings.Default.RecentQMConfigFileFilters;
            chkDisplayFullPathForQuickRecentEntries.Checked = Properties.Settings.Default.ShowFullPathForQuickRecentist;
            SetFrequency(Properties.Settings.Default.PollFrequencySec);

            chkUseTemplates.Checked = Properties.Settings.Default.UseTemplatesForNewObjects;
            chkDisableAutoAdminMode.Checked = Properties.Settings.Default.DisableAutoAdminMode;

            txtApplicationMasterKey.Text = Properties.Settings.Default.ApplicationMasterKey;
            txtApplicationMasterKeyFilePath.Text = Properties.Settings.Default.ApplicationUserNameCacheFilePath;
            lvwUserNameCache.Items.Clear();
            if (Properties.Settings.Default.ApplicationUserNameCache != null)
            {
                foreach (string userName in (from string s in Properties.Settings.Default.ApplicationUserNameCache
                                             orderby s
                                             select s))
                {
                    if ((from ListViewItem l in lvwUserNameCache.Items
                         where l.Text == userName
                         select l).Count() == 0)
                    {
                        ListViewItem lvi = lvwUserNameCache.Items.Add(userName);
                        lvi.ImageIndex = 0;
                    }
                }
            }
            loading = false;


        }

        private void GeneralSettings_Shown(object sender, EventArgs e)
        {
            flowLayoutPanelSettings_Resize(null, null);
            lvwUserNameCache.AutoResizeColumnEnabled = true;
        }

        private void cmdAppSettingsToggle_Click(object sender, EventArgs e)
        {
            if(cmdAppSettingsToggle.Height == panelAppSettings.Height)
            {
                panelAppSettings.Height = panelAppSettingsHeight;
                this.cmdAppSettingsToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            }
            else
            {
                panelAppSettings.Height = cmdAppSettingsToggle.Height;
                this.cmdAppSettingsToggle.Image = global::QuickMon.Properties.Resources.icon_expand16x16;
            }
        }

        private void cmdPollingSettingsToggle_Click(object sender, EventArgs e)
        {
            if (cmdPollingSettingsToggle.Height == panelPollingSettings.Height)
            {
                panelPollingSettings.Height = panelPollingSettingsHeight;
                this.cmdPollingSettingsToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            }
            else
            {
                panelPollingSettings.Height = cmdPollingSettingsToggle.Height;
                this.cmdPollingSettingsToggle.Image = global::QuickMon.Properties.Resources.icon_expand16x16;
            }
        }

        private void cmdPasswordManagementToggle_Click(object sender, EventArgs e)
        {
            if (cmdPasswordManagementToggle.Height == panelPasswordManagement.Height)
            {
                panelPasswordManagement.Height = panelPasswordManagementHeight;
                this.cmdPasswordManagementToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
                flowLayoutPanelSettings.ScrollControlIntoView(panelPasswordManagement);
            }
            else
            {
                panelPasswordManagement.Height = cmdPasswordManagementToggle.Height;
                this.cmdPasswordManagementToggle.Image = global::QuickMon.Properties.Resources.icon_expand16x16;
            }
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
                    freqSecNumericUpDown.Value = 30;
                freChanging = false;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (shortcutChanged)
            //    {
            //        Shortcuts.UnPinToTaskBar(); //just to make sure old instance is renewed
            //        Shortcuts.UnPinToStartMenu();
            //        Shortcuts.DeleteDesktopShortcut("", AppGlobals.AppId);

            //        if (chkPinToTaskbar.Checked)
            //        {
            //            if (!Shortcuts.PinToTaskBar())
            //            {
            //                MessageBox.Show("Pin to Taskbar failed!", "Pin to Taskbar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            }
            //        }
            //        if (chkPinToStartMenu.Checked)
            //        {
            //            Shortcuts.PinToStartMenu();
            //        }
            //        if (chkDesktopShortcut.Checked)
            //        {
            //            Shortcuts.CreateDesktopShortcut("", AppGlobals.AppId);
            //        }
            //    }
            //}
            //catch { }
            try
            {
                if (Security.UACTools.IsInAdminMode() && chkDisableAutoAdminMode.Checked)
                {
                    HenIT.Security.AdminModeTools.DeleteAdminLaunchTask(AppGlobals.AppTaskId);
                }
                else if (Security.UACTools.IsInAdminMode() && !HenIT.Security.AdminModeTools.CheckIfAdminLaunchTaskExist(AppGlobals.AppTaskId))
                {
                    HenIT.Security.AdminModeTools.CreateAdminLaunchTask(AppGlobals.AppTaskId);
                }
            }
            catch { }

            Properties.Settings.Default.PollFrequencySec = (int)freqSecNumericUpDown.Value;
            Properties.Settings.Default.ConcurrencyLevel = (int)concurrencyLevelNnumericUpDown.Value;
            Properties.Settings.Default.MainFormSnap = chkSnapToDesktop.Checked;
            Properties.Settings.Default.AutosaveChanges = chkAutosaveChanges.Checked;
            Properties.Settings.Default.CreateBackupOnSave = chkCreateBackupOnSave.Checked;
            Properties.Settings.Default.OverridesMonitorPackFrequency = chkOverridesMonitorPackFrequency.Checked;
            Properties.Settings.Default.ShowFullPathForQuickRecentist = chkDisplayFullPathForQuickRecentEntries.Checked;
            Properties.Settings.Default.UseTemplatesForNewObjects = chkUseTemplates.Checked;
            Properties.Settings.Default.DisableAutoAdminMode = chkDisableAutoAdminMode.Checked;
            if (txtRecentMonitorPackFilter.Text.Trim().Length == 0)
                Properties.Settings.Default.RecentQMConfigFileFilters = "*";
            else
                Properties.Settings.Default.RecentQMConfigFileFilters = txtRecentMonitorPackFilter.Text;

            Properties.Settings.Default.ApplicationMasterKey = txtApplicationMasterKey.Text;
            Properties.Settings.Default.ApplicationUserNameCacheFilePath = txtApplicationMasterKeyFilePath.Text;
            Properties.Settings.Default.ApplicationUserNameCache = new System.Collections.Specialized.StringCollection();
            foreach (ListViewItem userName in lvwUserNameCache.Items)
            {
                Properties.Settings.Default.ApplicationUserNameCache.Add(userName.Text);
            }

            Properties.Settings.Default.Save();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void freqSecNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetFrequency((int)freqSecNumericUpDown.Value);
        }

        #region Shortcuts
        //private void chkPinToTaskbar_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (!loading)
        //        shortcutChanged = true;
        //}
        //private void chkPinToStartMenu_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (!loading)
        //        shortcutChanged = true;
        //}
        //private void chkDesktopShortcut_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (!loading)
        //        shortcutChanged = true;
        //}
        #endregion

        private void cmdEditQuickSelectTypeFilters_Click(object sender, EventArgs e)
        {
            Forms.CSVEditor csvEdit = new Forms.CSVEditor();
            csvEdit.CSVData = txtRecentMonitorPackFilter.Text;
            if (csvEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtRecentMonitorPackFilter.Text = csvEdit.CSVData;
            }
        }
    }
}
