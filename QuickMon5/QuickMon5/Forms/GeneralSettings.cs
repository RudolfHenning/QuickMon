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

        //private bool loading = false;
        private bool freChanging = false;
        private int panelAppSettingsHeight = 0;
        private int panelPollingSettingsHeight = 0;
        private int panelPasswordManagementHeight = 0;
        private int panelRemoteHostServiceAndFirewallHeight = 0;

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
            this.Size = new Size(600, 500);
            panelAppSettingsHeight = panelAppSettings.Height;
            panelPollingSettingsHeight = panelPollingSettings.Height;
            panelPasswordManagementHeight = panelPasswordManagement.Height;
            panelRemoteHostServiceAndFirewallHeight = panelRemoteHostServiceAndFirewall.Height;
            //cmdPollingSettingsToggle_Click(null, null);
            cmdPasswordManagementToggle_Click(null, null);
            cmdRemoteHostServiceAndFirewallToggle_Click(null, null);

            //loading = true;
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
            nudMainWindowTreeViewExtraColumnSize.SaveValueSet(Properties.Settings.Default.MainWindowTreeViewExtraColumnSize);
            optTvwDetailLeftAlign.Checked = Properties.Settings.Default.MainWindowTreeViewExtraColumnTextAlign == 0;
            optTvwDetailRightAlign.Checked = Properties.Settings.Default.MainWindowTreeViewExtraColumnTextAlign != 0;

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

            flowLayoutPanelSettingsContent.Enabled = Security.UACTools.IsInAdminMode();
            CheckQuickMonServiceInstalled();
            CheckMonitorPackListExists();
            CheckQuickMonRemoteHostFirewallPort();
        }
        private void GeneralSettings_Shown(object sender, EventArgs e)
        {
            flowLayoutPanelSettings_Resize(null, null);
            lvwUserNameCache.AutoResizeColumnEnabled = true;
        }


        private void CheckQuickMonServiceInstalled()
        {
            bool isInstalled = false;
            try
            {
                Microsoft.Win32.RegistryKey svcsInstalled = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\QuickMon 5 Service");
                if (svcsInstalled.GetValue("DisplayName").ToString() == "QuickMon 5 Service")
                {
                    isInstalled = true;
                    System.ServiceProcess.ServiceController qsvrc = new System.ServiceProcess.ServiceController("QuickMon 5 Service");
                    lblServiceState.Text = qsvrc.Status.ToString();
                    if (qsvrc.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                        llblServiceState.Text = "Start";
                    else
                        llblServiceState.Text = "Stop";
                }
            }
            catch { }
            lblIsQuickMonServiceInstalled.Text = isInstalled ? "Yes" : "No";
            llblInstallQuickMonService.Enabled = lblIsQuickMonServiceInstalled.Text == "No";
            llblServiceState.Enabled = lblIsQuickMonServiceInstalled.Text == "Yes";
        }
        private void CheckQuickMonRemoteHostFirewallPort()
        {
            bool isFWRuleInstalled = false;
            try
            {
                Microsoft.Win32.RegistryKey fwrules = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\SharedAccess\Parameters\FirewallPolicy\FirewallRules");
                object regVal = fwrules.GetValue("{F811AB2E-286C-4DB6-8512-4C991A8A55EA}");
                if (regVal != null)
                {
                    string quickMonRule = regVal.ToString();
                    if (quickMonRule.Length > 0)
                        isFWRuleInstalled = true;
                }
            }
            catch { }
            lblFirewallPortRuleInstalled.Text = isFWRuleInstalled ? "Yes" : "No";
            llblInstallFirewallPortRule.Enabled = !isFWRuleInstalled;
        }
        private void CheckMonitorPackListExists()
        {
            bool found = false;
            string filePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\MonitorPackList.txt";
            if (System.IO.File.Exists(filePath))
                found = true;
            else
            {
                filePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Hen IT\\QuickMon 5\\MonitorPackList.txt";
                if (System.IO.File.Exists(filePath))
                    found = true;
                else
                {
                    filePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Hen IT\\QuickMon 5\\MonitorPackList.txt";
                    if (System.IO.File.Exists(filePath))
                        found = true;
                }
            }
            lblMonitorPackListExists.Text = found ? "Found" : "No found";
            llblEditMonitorPackList.Enabled = found;
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
            Properties.Settings.Default.MainWindowTreeViewExtraColumnSize = (int)nudMainWindowTreeViewExtraColumnSize.Value;
            Properties.Settings.Default.MainWindowTreeViewExtraColumnTextAlign = optTvwDetailRightAlign.Checked ? 1 : 0;
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

        private void cmdRemoteHostServiceAndFirewallToggle_Click(object sender, EventArgs e)
        {
            if (cmdRemoteHostServiceAndFirewallToggle.Height == panelRemoteHostServiceAndFirewall.Height)
            {
                panelRemoteHostServiceAndFirewall.Height = panelRemoteHostServiceAndFirewallHeight;
                this.cmdRemoteHostServiceAndFirewallToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
                flowLayoutPanelSettings.ScrollControlIntoView(panelRemoteHostServiceAndFirewall);
            }
            else
            {
                panelRemoteHostServiceAndFirewall.Height = cmdRemoteHostServiceAndFirewallToggle.Height;
                this.cmdRemoteHostServiceAndFirewallToggle.Image = global::QuickMon.Properties.Resources.icon_expand16x16;
            }
            
        }

        private void lblServiceState_DoubleClick(object sender, EventArgs e)
        {
            CheckQuickMonServiceInstalled();
        }

        private void llblInstallQuickMonService_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string localPath = Environment.CurrentDirectory;
            string serviceEXE = System.IO.Path.Combine(localPath, "QuickMonService.exe");
            quickMonServiceOpenFileDialog.FileName = serviceEXE;
            quickMonServiceOpenFileDialog.InitialDirectory = localPath;
            if (quickMonServiceOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo();
                p.StartInfo.FileName = quickMonServiceOpenFileDialog.FileName;
                p.StartInfo.Arguments = "-install";
                p.StartInfo.Verb = "runas";
                try
                {
                    p.Start();
                    p.WaitForExit();
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.ToString());
                }

                try
                {
                    System.ServiceProcess.ServiceController qsvrc = new System.ServiceProcess.ServiceController("QuickMon 5 Service");
                    if (qsvrc.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                    {
                        qsvrc.Start();
                        qsvrc.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
                    }

                    lblServiceState.Text = qsvrc.Status.ToString();
                }
                catch { }
            }
        }

        private void llblServiceState_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Application.DoEvents();
                this.Cursor = Cursors.WaitCursor;
                System.ServiceProcess.ServiceController qsvrc = new System.ServiceProcess.ServiceController("QuickMon 5 Service");
                lblServiceState.Text = qsvrc.Status.ToString();
                if (llblServiceState.Text == "Start" && qsvrc.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                {
                    qsvrc.Start();
                    qsvrc.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
                }
                else if (llblServiceState.Text == "Stop" && qsvrc.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                {
                    qsvrc.Stop();
                    qsvrc.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped);
                }
                lblServiceState.Text = qsvrc.Status.ToString();
                CheckQuickMonServiceInstalled();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void llblInstallFirewallPortRule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string regfile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "QuickMon5FirewallRule.reg");
            try
            {
                if (System.IO.File.Exists(regfile))
                    System.IO.File.Delete(regfile);
                System.IO.File.WriteAllText(regfile, Properties.Resources.FireWallRule);
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo();
                p.StartInfo.FileName = "REGEDIT.EXE";
                p.StartInfo.Arguments = "/S " + regfile;
                p.StartInfo.Verb = "runas";
                try
                {
                    p.Start();
                    p.WaitForExit();
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.ToString());
                }

                try
                {
                    System.ServiceProcess.ServiceController firewallSrvs = new System.ServiceProcess.ServiceController("Windows Firewall");
                    if (firewallSrvs.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                    {
                        firewallSrvs.Stop();
                        firewallSrvs.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 30));
                        firewallSrvs.Start();
                        firewallSrvs.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running, new TimeSpan(0, 0, 30));
                    }
                    CheckQuickMonRemoteHostFirewallPort();
                }
                catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llblEditMonitorPackList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool found = false;
            string filePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\MonitorPackList.txt";
            if (System.IO.File.Exists(filePath))
                found = true;
            else
            {
                filePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Hen IT\\QuickMon 5\\MonitorPackList.txt";
                if (System.IO.File.Exists(filePath))
                    found = true;
                else
                {
                    filePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Hen IT\\QuickMon 5\\MonitorPackList.txt";
                    if (System.IO.File.Exists(filePath))
                        found = true;
                }
            }
            if (found)
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo("notepad.exe");
                p.StartInfo.Arguments = filePath;
                p.Start();
            }
        }

        private void lblMonitorPackListFile_DoubleClick(object sender, EventArgs e)
        {
            CheckMonitorPackListExists();
        }
    }
}
