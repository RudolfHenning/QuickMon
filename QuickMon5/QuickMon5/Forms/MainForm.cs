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
    public partial class MainForm : FadeSnapForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Private vars
        private MonitorPack monitorPack;
        private bool monitorPackChanged = false;
        private bool firstRefresh = true;

        #region Copy and Paste of collector hosts
        //private List<CollectorHost> copiedCollectorList = new List<CollectorHost>();
        #endregion

        #region Main timer
        private Timer autoRefreshTimer;
        private bool isPollingPaused = true;
        #endregion

        #region TreeNodeImage contants
        private readonly int collectorFolderImage = 0;
        private readonly int collectorNAstateImage = 1;
        private readonly int collectorGoodStateImage1 = 2;
        private readonly int collectorGoodStateImage2 = 5;
        private readonly int collectorWarningStateImage1 = 3;
        private readonly int collectorWarningStateImage2 = 6;
        private readonly int collectorErrorStateImage1 = 4;
        private readonly int collectorErrorStateImage2 = 7;
        private readonly int collectorDisabled = 8;
        #endregion
        #endregion

        #region Form events
        private void MainForm_Load(object sender, EventArgs e)
        {
            if ((Properties.Settings.Default.MainWindowLocation.X == 0) && (Properties.Settings.Default.MainWindowLocation.Y == 0)
                && (Properties.Settings.Default.MainWindowSize.Width == 0))
            {
                this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            }
            else
            {
                this.Location = Properties.Settings.Default.MainWindowLocation;
                this.Size = Properties.Settings.Default.MainWindowSize;
            }
            SnappingEnabled = Properties.Settings.Default.MainFormSnap;

            //Ξ
            if (Properties.Settings.Default.ShowMenuOnStart)
                ToggleMenuSize();

            tvwCollectors.FullRowSelect = true;
            tvwCollectors.FullRowSelect = false;
            tvwNotifiers.FullRowSelect = true;
            tvwNotifiers.FullRowSelect = false;
            masterSplitContainer.Panel2Collapsed = true;
            Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.LabelText = string.Format("v{0}.{1}.{2}", v.Major, v.Minor, v.Build);
            lblCollectors.LabelText = "Collectors";
            lblNotifiers.LabelText = "Notifiers";
            UpdateNotifiersLabel();
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            UpdatePauseButton();
        }
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool ctrl = ((Control.ModifierKeys & Keys.Control) == Keys.Control);
            if (ctrl)
            {
                if (e.KeyChar == 'M')
                {
                    
                }
            }


        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.M)
                {
                    ToggleMenuSize();
                    e.SuppressKeyPress = true;
                }
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Properties.Settings.Default.Save();

            //if (monitorPack != null)
            //    monitorPack.CloseMonitorPack();
            PerformCleanShutdown();
        }
        #endregion

        #region Menu
        private void cmdMenu_Click(object sender, EventArgs e)
        {
            ToggleMenuSize();
        }
        private void ToggleMenuSize()
        {
            if (panelSlimMenu.Width != 45)
            {
                panelSlimMenu.Width = 45;
                cmdMenu.Text = "";
                cmdNew.Text = "";
                cmdOpen.Text = "";
                splitButtonSave.ButtonText = "";
                splitButtonCollectors.ButtonText = "";
                splitButtonNotifiers.ButtonText = "";
                splitButtonTools.ButtonText = "";
                cmdRemoteHosts.Text = "";
                cmdAbout.Text = "";
            }
            else
            {
                panelSlimMenu.Width = 120;
                cmdMenu.Text = " Menu";
                cmdNew.Text = " New";
                cmdOpen.Text = " Open";
                splitButtonSave.ButtonText = " Save";
                splitButtonCollectors.ButtonText = " Collectors";
                splitButtonNotifiers.ButtonText = " Notifiers";
                splitButtonTools.ButtonText = " Settings";
                cmdRemoteHosts.Text = " Remote Hosts";
                cmdAbout.Text = " About";
            }
        }
        private void cmdNew_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            CloseAllDetailWindows();
            NewMonitorPack();
        }
        private void cmdOpen_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            try
            {
                if (openFileDialogOpen.FileName == null || openFileDialogOpen.FileName.Length == 0)
                {
                    string startUpPath = MonitorPack.GetQuickMonUserDataDirectory();
                    openFileDialogOpen.InitialDirectory = startUpPath;
                }
                else
                {
                    openFileDialogOpen.InitialDirectory = System.IO.Path.GetDirectoryName(openFileDialogOpen.FileName);
                }
                if (openFileDialogOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CloseAllDetailWindows();
                    LoadMonitorPack(openFileDialogOpen.FileName);
                    RefreshMonitorPack(true, true);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Open", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void splitButtonSave_SplitButtonClicked(object sender, EventArgs e)
        {
            saveContextMenuStrip.Show(splitButtonSave, new Point(splitButtonSave.Width, 0));
        }
        private void splitButtonCollectors_SplitButtonClicked(object sender, EventArgs e)
        {
            collectorsContextMenuStrip.Show(splitButtonCollectors, new Point(splitButtonCollectors.Width, 0));
        }
        private void splitButtonCollectors_ButtonClicked(object sender, EventArgs e)
        {
            collectorsContextMenuStrip.Show(splitButtonCollectors, new Point(splitButtonCollectors.Width, 0));
        }
        private void splitButtonNotifiers_SplitButtonClicked(object sender, EventArgs e)
        {
            notifiersContextMenuStrip.Show(splitButtonNotifiers, new Point(splitButtonNotifiers.Width, 0));
        }

        private void splitButtonNotifiers_ButtonClicked(object sender, EventArgs e)
        {
            notifiersContextMenuStrip.Show(splitButtonNotifiers, new Point(splitButtonNotifiers.Width, 0));
        }
        private void splitButtonTools_SplitButtonClicked(object sender, EventArgs e)
        {
            settingsContextMenuStrip.Show(splitButtonTools, new Point(splitButtonTools.Width, 0));
        }
        private void cmdAbout_Click(object sender, EventArgs e)
        {

        }
        private void cmdPauseRunMP_Click(object sender, EventArgs e)
        {
            isPollingPaused = !isPollingPaused;
            UpdatePauseButton();
        }
        #endregion

        private void llblNotifierViewToggle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            masterSplitContainer.Panel2Collapsed = !masterSplitContainer.Panel2Collapsed;
            UpdateNotifiersLabel();
        }
        
        private void llblNotifierViewToggle_DoubleClick(object sender, EventArgs e)
        {
            masterSplitContainer.Panel2Collapsed = !masterSplitContainer.Panel2Collapsed;
            UpdateNotifiersLabel();
        }

        #region Collector and Notifier Context menus
        private void HideCollectorContextMenu()
        {
            try
            {
                //if (popperContainerForTreeView != null)
                //    popperContainerForTreeView.Close();
            }
            catch { }
        }
        private void HideNotifierContextMenu()
        {
            try
            {
                //if (popperContainerForListView != null)
                //    popperContainerForListView.Close();
            }
            catch { }
        }


        #endregion

        #region Private methods
        private bool PerformCleanShutdown(bool abortAllowed = false)
        {
            bool notAborted = true;
            try
            {
                if (monitorPackChanged)
                {
                    if (Properties.Settings.Default.AutosaveChanges || MessageBox.Show("Do you want to save changes to the current monitor pack?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (!SaveMonitorPack() && abortAllowed)
                            return false;
                    }
                }

                UpdateStatusbar("Shutting down...");
                Application.DoEvents();
                PausePolling();
                CloseAllDetailWindows();
                //if (monitorPack.IsBusyPolling)
                //{
                //    monitorPack.AbortPolling = true;
                //    DateTime abortStart = DateTime.Now;
                //    while (monitorPack.IsBusyPolling && abortStart.AddSeconds(5) > DateTime.Now)
                //    {
                //        Application.DoEvents();
                //    }
                //    Cursor.Current = Cursors.WaitCursor;
                //    ClosePerformanceCounters();
                //}

                if (WindowState == FormWindowState.Normal)
                {
                    Properties.Settings.Default.MainWindowLocation = this.Location;
                    Properties.Settings.Default.MainWindowSize = this.Size;
                }
                Properties.Settings.Default.ShowMenuOnStart = (panelSlimMenu.Width != 45);
                Properties.Settings.Default.Save();
            }
            catch { }
            return notAborted;
        }
        private void CloseAllDetailWindows()
        {
            //CloseAllCollectorStatusViews();
            //CloseAllNotifierViewers();
        }
        private void UpdateStatusbar(string msg)
        {
            try
            {
                if (this != null)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            toolStripStatusLabelStatus.Text = msg;
                            toolTip1.SetToolTip(statusStrip1, msg);
                        });
                    }
                    else
                    {
                        toolStripStatusLabelStatus.Text = msg;
                        toolTip1.SetToolTip(statusStrip1, msg);
                    }
                }
            }
            catch { }
        }
        private void UpdateNotifiersLabel()
        {
            TreeNode notifierRoot = tvwNotifiers.Nodes[0];
            llblNotifierViewToggle.Text = masterSplitContainer.Panel2Collapsed ? "► Show Notifiers" : "▼ Hide Notifiers";
            if (notifierRoot.Nodes.Count > 0)
            {
                StringBuilder notSummary = new StringBuilder();
                foreach (TreeNode child in notifierRoot.Nodes)
                {
                    notSummary.AppendLine(child.Text);
                }
                llblNotifierViewToggle.Text += " (" + notifierRoot.Nodes.Count.ToString() + ")";
                toolTip1.SetToolTip(llblNotifierViewToggle, notSummary.ToString());
            }
        }
        private void UpdateAppTitle()
        {
            Text = AppGlobals.AppId;
            if (monitorPackChanged)
                Text += "*";
            if (monitorPack != null)
            {
                if (!monitorPack.Enabled)
                    Text += " - [Disabled]";
                if (monitorPack.Name != null && monitorPack.Name.Length > 0)
                    Text += string.Format(" - [{0}]", monitorPack.Name);
                if (isPollingPaused)
                    Text += " (Paused)";
            }
        }
        #endregion

        #region Monitor pack actions
        private void NewMonitorPack()
        {
            if (monitorPack != null && System.IO.File.Exists(monitorPack.MonitorPackPath) && monitorPackChanged)
            {
                if (Properties.Settings.Default.AutosaveChanges || MessageBox.Show("Do you want to save changes to the current monitor pack?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!SaveMonitorPack())
                        return;
                }
            }
            PausePolling();
            try
            {
                CloseAllDetailWindows();

                monitorPack.CollectorHostStateUpdated -= monitorPack_CollectorHostStateUpdated;
                monitorPack.CloseMonitorPack();
                monitorPack = null;
            }
            catch { }
            monitorPack = new MonitorPack();

            string newMonitorPackConfig = Properties.Resources.BlankMonitorPack;
            //if (Properties.Settings.Default.UseTemplatesForNewObjects && QuickMonTemplate.GetMonitorPackTemplates().Count > 0)
            //{
            //    SelectTemplate selectTemplate = new SelectTemplate();
            //    selectTemplate.FilterTemplatesBy = TemplateType.MonitorPack;
            //    if (selectTemplate.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        newMonitorPackConfig = selectTemplate.SelectedTemplate.Config;
            //    }
            //}

            monitorPack.LoadXml(newMonitorPackConfig);
            monitorPack.MonitorPackPath = "";
            LoadControlsFromMonitorPack();
            monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
            monitorPack.CollectorHostStateUpdated += monitorPack_CollectorHostStateUpdated;
            monitorPackChanged = false;
            EditMonitorSettings();
        }
        private void LoadMonitorPack(string monitorPackPath)
        {
            if (System.IO.File.Exists(monitorPackPath))
            {
                if (monitorPackChanged)
                {
                    if (Properties.Settings.Default.AutosaveChanges || MessageBox.Show("Do you want to save changes to the current monitor pack?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (!SaveMonitorPack())
                        {
                            return;
                        }
                    }
                }
                UpdateStatusbar("Pausing polling...");
                PausePolling(isPollingPaused);
                WaitForPollingToFinish(5);
                UpdateStatusbar("Waiting for loading to finish");

                //InitializeBackgroundWorker();

                if (monitorPack != null)
                {
                    try
                    {
                        CloseAllDetailWindows();
                        WaitForPollingToFinish(5);
                        monitorPack.CloseMonitorPack();
                    }
                    catch { }
                    finally
                    {
                        monitorPack = null;
                    }
                }
                monitorPack = new MonitorPack();

                monitorPack.Load(monitorPackPath);
                LoadControlsFromMonitorPack();
                SetMonitorPackEvents();

                //AddMonitorPackFileToRecentList(monitorPackPath);

                if (!isPollingPaused)
                {
                    UpdateStatusbar("Starting/Resuming polling...");
                    ResumePolling(true);
                }
                else
                    UpdateStatusbar("");
                monitorPackChanged = false;
            }
        }
        private void LoadControlsFromMonitorPack()
        {
        }
        private void SetMonitorPackEvents()
        {
            //if (monitorPack != null)
            //{
            //    monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
            //    monitorPack.CollectorHostStateUpdated += monitorPack_CollectorHostStateUpdated;
            //    monitorPack.OnNotifierError += monitorPack_OnNotifierError;
            //    monitorPack.RunCollectorHostCorrectiveWarningScript += monitorPack_RunCollectorHostCorrectiveWarningScript;
            //    monitorPack.RunCollectorHostCorrectiveErrorScript += monitorPack_RunCollectorHostCorrectiveErrorScript;
            //    monitorPack.RunCollectorHostRestorationScript += monitorPack_RunCollectorHostRestorationScript;
            //    monitorPack.CollectorHostCalled += monitorPack_CollectorHostCalled;
            //    monitorPack.CollectorHostAllAgentsExecutionTime += monitorPack_CollectorHostAllAgentsExecutionTime;
            //    monitorPack.RunningAttended = AttendedOption.OnlyAttended;

            //    monitorPack.ApplicationUserNameCacheFilePath = Properties.Settings.Default.ApplicationUserNameCacheFilePath;
            //    monitorPack.ApplicationUserNameCacheMasterKey = Properties.Settings.Default.ApplicationMasterKey;
            //}
        }
        private bool SaveMonitorPack()
        {
            return true;
        }
        private void EditMonitorSettings()
        {
            HideCollectorContextMenu();
            if (!isPollingPaused)
            {
                UpdateStatusbar("Pausing polling...");
                PausePolling(false);
                WaitForPollingToFinish(5);
                UpdateStatusbar("Waiting for editing to finish");
            }

            //EditMonitorPackConfig emc = new EditMonitorPackConfig();
            //emc.SelectedMonitorPack = monitorPack;
            //if (emc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    SetMonitorChanged();
            //    if (emc.TriggerMonitorPackReload)
            //    {
            //        monitorPack = emc.SelectedMonitorPack;
            //        UpdateStatusbar("Reloading monitor pack...");
            //        SetMonitorPackEvents();
            //        LoadControlsFromMonitorPack();
            //    }
            //    SetMonitorPackNameDescription();
            //    DoAutoSave();
            //}
            if (!isPollingPaused)
            {
                UpdateStatusbar("Starting/Resuming polling...");
                ResumePolling(true);
            }
            else
                UpdateStatusbar("");

        }
        private void SetMonitorPackNameDescription()
        {
            toolTip1.SetToolTip(llblMonitorPack, "");
            llblMonitorPack.Text = "";
            if (monitorPack == null || ((monitorPack.Name == null || monitorPack.Name.Trim().Length == 0)))
            {
                llblMonitorPack.Text = "<New Monitor Pack>";
                toolTip1.SetToolTip(llblMonitorPack, "Click here to set the monitor pack properties.");
            }
            else
            {
                llblMonitorPack.Text = monitorPack.Name;
            }
            if (monitorPack != null)
            {
                if (monitorPack.MonitorPackPath != null)
                    toolTip1.SetToolTip(llblMonitorPack, monitorPack.MonitorPackPath);
                if (!monitorPack.Enabled)
                    llblMonitorPack.Text += " (Disabled)";
            }
            //if still after all of this...
            if (llblMonitorPack.Text == "")
            {
                llblMonitorPack.Text = "<New Monitor Pack>";
                toolTip1.SetToolTip(llblMonitorPack, "Click here to set the monitor pack properties.");
            }
        }
        private void SetMonitorChanged()
        {
            monitorPackChanged = true;
            UpdateAppTitle();
        }
        private void DoAutoSave()
        {
            if (Properties.Settings.Default.AutosaveChanges)
                SaveMonitorPack();
        }
        private void WaitForPollingToFinish(int secondsToWait)
        {
            if (monitorPack != null && monitorPack.IsBusyPolling)
            {
                monitorPack.AbortPolling = true;
                DateTime abortStart = DateTime.Now;
                while (monitorPack.IsBusyPolling && abortStart.AddSeconds(secondsToWait) > DateTime.Now)
                {
                    Application.DoEvents();
                    Cursor.Current = Cursors.WaitCursor;
                }
            }
        }
        private void RefreshMonitorPack(bool disablePollingOverride = false, bool forceUpdateNow = false)
        {
        }

        private void monitorPack_CollectorHostStateUpdated(CollectorHost collectorHost)
        {
            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    if (collectorHost != null && collectorHost.Tag is TreeNode)
                    {
                        System.Diagnostics.Trace.WriteLine("Updating " + collectorHost.Name);
                        TreeNode currentTreeNode = (TreeNode)collectorHost.Tag;

                        bool nodeChanged = false;
                        Color foreColor = currentTreeNode.ForeColor;
                        int imageIndex = currentTreeNode.ImageIndex;

                        if (collectorHost.Enabled && currentTreeNode.ForeColor != SystemColors.WindowText)
                        {
                            nodeChanged = true;
                            foreColor = SystemColors.WindowText;
                        }
                        else if (!collectorHost.Enabled && currentTreeNode.ForeColor != Color.Gray)
                        {
                            nodeChanged = true;
                            foreColor = Color.Gray;
                        }

                        if (collectorHost.CollectorAgents.Count == 0 || collectorHost.CurrentState.State == CollectorState.None)
                        {
                            if (currentTreeNode.ImageIndex != collectorFolderImage)
                            {
                                nodeChanged = true;
                                imageIndex = collectorFolderImage;
                            }
                        }
                        else if (!collectorHost.Enabled || collectorHost.CurrentState.State == CollectorState.Disabled)
                        {
                            if (currentTreeNode.ImageIndex != collectorDisabled)
                            {
                                nodeChanged = true;
                                imageIndex = collectorDisabled;
                            }
                        }
                        else if (collectorHost.CurrentState.State == CollectorState.Error || collectorHost.CurrentState.State == CollectorState.ConfigurationError)
                        {
                            if (currentTreeNode.ImageIndex != collectorErrorStateImage1)
                            {
                                nodeChanged = true;
                                imageIndex = collectorErrorStateImage1;
                                //PCRaiseCollectorErrorState();
                            }
                        }
                        else if (collectorHost.CurrentState.State == CollectorState.Warning)
                        {
                            if (currentTreeNode.ImageIndex != collectorWarningStateImage1)
                            {
                                nodeChanged = true;
                                imageIndex = collectorWarningStateImage1;
                                //PCRaiseCollectorWarningState();
                            }
                        }
                        else if (collectorHost.CurrentState.State == CollectorState.Good)
                        {
                            if (currentTreeNode.ImageIndex != collectorGoodStateImage1)
                            {
                                nodeChanged = true;
                                imageIndex = collectorGoodStateImage1;
                                //PCRaiseCollectorSuccessState();
                            }
                        }
                        else if (currentTreeNode.ImageIndex != collectorNAstateImage)
                        {
                            nodeChanged = true;
                            imageIndex = collectorNAstateImage;
                        }
                        if (nodeChanged)
                        {
                            if (currentTreeNode.ForeColor != foreColor)
                                currentTreeNode.ForeColor = foreColor;
                            if (currentTreeNode.ImageIndex != imageIndex)
                            {
                                currentTreeNode.ImageIndex = imageIndex;
                                currentTreeNode.SelectedImageIndex = imageIndex;
                                if (firstRefresh && (imageIndex == collectorGoodStateImage1 || imageIndex == collectorWarningStateImage1 || imageIndex == collectorErrorStateImage1))
                                {
                                    TreeNode currentFocusNode = tvwCollectors.SelectedNode;
                                    try
                                    {
                                        tvwCollectors.BeginUpdate();

                                        if (collectorHost.ExpandOnStartOption == ExpandOnStartOption.Always)
                                            currentTreeNode.ExpandAllParents();
                                        if (collectorHost.ExpandOnStartOption == ExpandOnStartOption.OnSuccess && collectorHost.CurrentState.State == CollectorState.Good)
                                            currentTreeNode.ExpandAllParents();
                                        else if (collectorHost.ExpandOnStartOption == ExpandOnStartOption.OnNonSuccess && (collectorHost.CurrentState.State == CollectorState.Warning || collectorHost.CurrentState.State == CollectorState.Error))
                                            currentTreeNode.ExpandAllParents();
                                    }
                                    catch { }
                                    finally
                                    {
                                        tvwCollectors.EndUpdate();
                                    }
                                    currentFocusNode.EnsureVisible();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error " + collectorHost.Name + "->" + ex.Message);
                }
            });
        }
        
        #endregion

        #region Auto refreshing timer
        private void autoRefreshTimer_Tick(object sender, EventArgs e)
        {
            //RefreshMonitorPack();
        }
        private void PausePolling(bool resetPauseVar = true)
        {

            //isPollingPaused = true;

            //if (autoRefreshTimer != null)
            //{
            //    autoRefreshTimer.Enabled = false;
            //    try
            //    {
            //        autoRefreshTimer.Stop();
            //        autoRefreshTimer.Tick -= autoRefreshTimer_Tick;
            //    }
            //    catch { }
            //    autoRefreshTimer = null;

            //}
            //UpdateAppTitle();
            //if (!resetPauseVar)
            //{
            //    isPollingPaused = false; //change it back                
            //}
            //else
            //    this.pauseToolStripButton.Image = global::QuickMon.Properties.Resources._135_42;
        }
        private void ResumePolling(bool startImmediately = false)
        {
            //isPollingPaused = false;
            //this.pauseToolStripButton.Image = global::QuickMon.Properties.Resources._221_5;
            //if (autoRefreshTimer != null)
            //{
            //    autoRefreshTimer.Enabled = false;
            //    autoRefreshTimer = null;
            //}

            ////if (!isPollingPaused)
            //{
            //    if (startImmediately)
            //    {
            //        RefreshMonitorPack(false, true);
            //    }
            //    else
            //    {
            //        autoRefreshTimer = new Timer();

            //        if (Properties.Settings.Default.OverridesMonitorPackFrequency || monitorPack == null || monitorPack.PollingFrequencyOverrideSec == 0)
            //            autoRefreshTimer.Interval = Properties.Settings.Default.PollFrequencySec * 1000;
            //        else
            //            autoRefreshTimer.Interval = monitorPack.PollingFrequencyOverrideSec * 1000;
            //        autoRefreshTimer.Tick += autoRefreshTimer_Tick;
            //        autoRefreshTimer.Enabled = true;
            //        autoRefreshTimer.Start();
            //    }
            //}
            //UpdateAppTitle();
        }
        private void SetApplicationPollingFrequency(int frequencySec)
        {
            Properties.Settings.Default.OverridesMonitorPackFrequency = true;
            if (frequencySec > 0)
            {
                Properties.Settings.Default.PollFrequencySec = frequencySec;
                ResumePolling();
            }
            else
                PausePolling();
        }
        private void UpdatePauseButton()
        {
            if (isPollingPaused)
            {
                this.cmdPauseRunMP.BackgroundImage = global::QuickMon.Properties.Resources._141;
                toolTip1.SetToolTip(cmdPauseRunMP, "Auto refresh Paused!");
                cmdPauseRunMP.BackColor = System.Drawing.Color.Gainsboro;
            }
            else
            {
                cmdPauseRunMP.BackgroundImage = global::QuickMon.Properties.Resources._131;
                toolTip1.SetToolTip(cmdPauseRunMP, "Auto refresh Active!");
                cmdPauseRunMP.BackColor = System.Drawing.Color.Transparent;
            }
        }


        #endregion


    }
}
