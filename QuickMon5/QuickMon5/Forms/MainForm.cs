﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            autoRefreshTimer = new Timer() { Enabled = false, Interval = Properties.Settings.Default.PollFrequencySec * 1000 };
        }

        #region Private vars
        private MonitorPack monitorPack;
        private bool monitorPackChanged = false;
        private bool firstRefresh = true;
        private bool refreshCycleA = true;

        #region Copy and Paste of collector hosts
        //private List<CollectorHost> copiedCollectorList = new List<CollectorHost>();
        #endregion

        #region Main timer
        private Timer autoRefreshTimer;
        //private bool isPollingPaused = false;
        private bool isPollingEnabled = true;
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
            cboRecentMonitorPacks.Visible = false;
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            
            try
            {
                //InitializeGlobalPerformanceCounters();
                if (Properties.Settings.Default.LastMonitorPack != null && System.IO.File.Exists(Properties.Settings.Default.LastMonitorPack))
                {
                    LoadMonitorPack(Properties.Settings.Default.LastMonitorPack);
                    System.Threading.Thread.Sleep(100);
                    RefreshMonitorPack();
                }
                else
                {
                    monitorPack = null;
                    NewMonitorPack();
                }
                monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
                UpdatePauseButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tvwCollectors.Focus();
            ResumePolling();
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
                else if (e.KeyCode == Keys.O)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    cmdOpen_Click(sender, e);
                }
                else if (e.KeyCode == Keys.T)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    cmdRecentMonitorPacks_Click(null, null);
                }
                else if (e.KeyCode == Keys.N)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    cmdNew_Click(sender, e);
                }
                else if (e.KeyCode == Keys.E)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    //generalSettingsToolStripSplitButton_ButtonClick(sender, e);
                }
            }
            else if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                InitializeBackgroundWorker();
                RefreshMonitorPack(true, true);
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (monitorPack != null)
                monitorPack.CloseMonitorPack();
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
        private void splitButtonSave_ButtonClicked(object sender, EventArgs e)
        {
            SaveMonitorPack();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsMonitorPack();
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
            if (isPollingEnabled)
            {
                PausePolling();
            }
            else
            {
                ResumePolling(true);
            }
            //isPollingEnabled = !isPollingEnabled;
            UpdatePauseButton();
        }
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            InitializeBackgroundWorker();
            RefreshMonitorPack(true, true);
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
                if (monitorPack.IsBusyPolling)
                {
                    monitorPack.AbortPolling = true;
                    DateTime abortStart = DateTime.Now;
                    while (monitorPack.IsBusyPolling && abortStart.AddSeconds(5) > DateTime.Now)
                    {
                        Application.DoEvents();
                    }
                    Cursor.Current = Cursors.WaitCursor;
                    //ClosePerformanceCounters();
                }

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
            //TreeNode notifierRoot = tvwNotifiers.Nodes[0];
            llblNotifierViewToggle.Text = masterSplitContainer.Panel2Collapsed ? "► Show Notifiers" : "▼ Hide Notifiers";
            if (tvwNotifiers.Nodes.Count > 0)
            {
                StringBuilder notSummary = new StringBuilder();
                foreach (TreeNode child in tvwNotifiers.Nodes)
                {
                    notSummary.AppendLine(child.Text);
                }
                llblNotifierViewToggle.Text += " (" + tvwNotifiers.Nodes.Count.ToString() + ")";
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
                if (!isPollingEnabled)
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
                PausePolling(false);
                WaitForPollingToFinish(5);
                UpdateStatusbar("Waiting for loading to finish");

                InitializeBackgroundWorker();

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

                AddMonitorPackFileToRecentList(monitorPackPath);

                if (isPollingEnabled)
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
            firstRefresh = true;
            SetMonitorPackNameDescription();
            tvwCollectors.Nodes.Clear();
            lblCollectors.LabelText = "Collectors - Loading...";
            
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;

            #region Load Collectors
            if (monitorPack != null)
            {
                List<CollectorHost> noDependantCollectors = monitorPack.GetRootCollectorHosts();
                foreach (CollectorHost collector in noDependantCollectors)
                {
                    LoadCollectorNode(null, collector);
                }
            }
            lblCollectors.LabelText = "Collectors";
            #endregion

            #region Load Notifiers
            tvwNotifiers.Nodes.Clear();            
            if (monitorPack != null && monitorPack.NotifierHosts != null && monitorPack.NotifierHosts.Count > 0)
            {
                foreach (NotifierHost n in monitorPack.NotifierHosts)
                {
                    LoadNotifierNode(n);
                }
            }            

            UpdateNotifiersLabel();
            #endregion

            UpdateAppTitle();

            if (monitorPack != null)
            {
                UpdateStatusbar(string.Format("{0} collector(s), {1} notifier(s)",
                     monitorPack.CollectorHosts.Count,
                     monitorPack.NotifierHosts.Count));
            }

            //tvwCollectors.SelectedNode = root;
            //root.EnsureVisible();

            Cursor.Current = Cursors.Default;
            Application.DoEvents();
        }
        private void LoadCollectorNode(TreeNode root, CollectorHost collector)
        {
            TreeNode collectorNode;
            if (collector.CollectorAgents == null || collector.CollectorAgents.Count == 0)
            {
                collectorNode = new TreeNode(collector.DisplayName, 1, 1);
                collectorNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            }
            else
                collectorNode = new TreeNode(collector.DisplayName, 2, 2);
            collectorNode.Tag = collector;
            collector.Tag = collectorNode;
            collectorNode.ForeColor = collector.Enabled ? SystemColors.WindowText : Color.Gray;
            foreach (CollectorHost childCollector in (from c in monitorPack.CollectorHosts
                                                      where c.ParentCollectorId == collector.UniqueId &&
                                                      c.ParentCollectorId != c.UniqueId
                                                      select c))
            {
                LoadCollectorNode(collectorNode, childCollector);
            }
            if (root == null)
            {
                tvwCollectors.Nodes.Add(collectorNode);
            }
            else 
                root.Nodes.Add(collectorNode);
            if (collector.Enabled)
            {
                if (collector.ExpandOnStartOption == ExpandOnStartOption.Auto || collector.ExpandOnStartOption == ExpandOnStartOption.Always)
                {
                    collectorNode.Expand();
                }
            }
        }
        private void LoadNotifierNode(NotifierHost n)
        {
            //TreeNode notifierRoot = tvwNotifiers.Nodes[0];
            TreeNode notifierHostNode = new TreeNode(n.Name);
            if (n.Enabled)
            {
                notifierHostNode.ImageIndex = 1;
            }
            else
            {
                notifierHostNode.ImageIndex = 2;
            }
            notifierHostNode.SelectedImageIndex = notifierHostNode.ImageIndex;
            notifierHostNode.Tag = n;
            LoadNotifierAgents(notifierHostNode, n);
            tvwNotifiers.Nodes.Add(notifierHostNode);
        }
        private void LoadNotifierAgents(TreeNode notifierHostNode, NotifierHost n)
        {
            foreach (INotifier nAgent in n.NotifierAgents)
            {
                TreeNode notifierAgentNode = new TreeNode(nAgent.Name);
                try
                {
                    if (UI.RegisteredAgentUIMapper.HasAgentViewer(nAgent))
                        notifierAgentNode.ImageIndex = 3;
                    else
                        notifierAgentNode.ImageIndex = 4;
                }
                catch
                {
                    notifierAgentNode.ImageIndex = 4;
                }
                notifierAgentNode.SelectedImageIndex = notifierAgentNode.ImageIndex;
                notifierAgentNode.Tag = nAgent;
                notifierHostNode.Nodes.Add(notifierAgentNode);
            }
            notifierHostNode.Expand();
        }
        private void SetMonitorPackEvents()
        {
            if (monitorPack != null)
            {
                monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
                monitorPack.CollectorHostStateUpdated += monitorPack_CollectorHostStateUpdated;
            //    monitorPack.RunCollectorHostCorrectiveWarningScript += monitorPack_RunCollectorHostCorrectiveWarningScript;
            //    monitorPack.RunCollectorHostCorrectiveErrorScript += monitorPack_RunCollectorHostCorrectiveErrorScript;
            //    monitorPack.RunCollectorHostRestorationScript += monitorPack_RunCollectorHostRestorationScript;
                monitorPack.RunningAttended = AttendedOption.OnlyAttended;

                monitorPack.ApplicationUserNameCacheFilePath = Properties.Settings.Default.ApplicationUserNameCacheFilePath;
                monitorPack.ApplicationUserNameCacheMasterKey = Properties.Settings.Default.ApplicationMasterKey;
            }
        }
        private bool SaveMonitorPack()
        {
            bool success = false;
            try
            {
                if (monitorPack != null && monitorPack.MonitorPackPath != null && monitorPack.MonitorPackPath.Length > 0 && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(monitorPack.MonitorPackPath)))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    SortItemsByTreeView();
                    if (Properties.Settings.Default.CreateBackupOnSave)
                        monitorPack.BackupSavedFile();
                    monitorPack.Save();
                    Properties.Settings.Default.LastMonitorPack = monitorPack.MonitorPackPath;
                    monitorPackChanged = false;
                    success = true;
                    AddMonitorPackFileToRecentList(monitorPack.MonitorPackPath);
                }
                else
                {
                    success = SaveAsMonitorPack();
                }
                UpdateAppTitle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
            return success;
        }
        private bool SaveAsMonitorPack()
        {
            bool success = false;
            try
            {
                bool canAutoSave = false;
                if (monitorPack == null)
                    monitorPack = new MonitorPack();
                if (monitorPack.MonitorPackPath != null && System.IO.File.Exists(monitorPack.MonitorPackPath))
                {
                    canAutoSave = Properties.Settings.Default.AutosaveChanges;
                    saveFileDialogSave.FileName = monitorPack.MonitorPackPath;                    
                    try
                    {
                        saveFileDialogSave.InitialDirectory = System.IO.Path.GetDirectoryName(monitorPack.MonitorPackPath);
                    }
                    catch { }
                }
                else
                {
                    saveFileDialogSave.InitialDirectory = MonitorPack.GetQuickMonUserDataDirectory();
                }
                if (saveFileDialogSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    monitorPack.MonitorPackPath = saveFileDialogSave.FileName;
                    success = SaveMonitorPack();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return success;
        }
        private void EditMonitorSettings()
        {
            HideCollectorContextMenu();
            if (!isPollingEnabled)
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
            if (isPollingEnabled)
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
        private void SortItemsByTreeView()
        {
            List<CollectorHost> sortedCollectors = new List<CollectorHost>();
            foreach (TreeNode childNode in tvwCollectors.Nodes)
            {
                if (childNode.Tag != null && childNode.Tag is CollectorHost)
                {
                    sortedCollectors.Add((CollectorHost)childNode.Tag);
                    AppendSortedCollectors(childNode, sortedCollectors);
                }
            }
            monitorPack.CollectorHosts.Clear();
            foreach (CollectorHost c in sortedCollectors)
            {
                monitorPack.CollectorHosts.Add(c);
            }
        }
        private void AppendSortedCollectors(TreeNode treeNode, List<CollectorHost> sortedCollectors)
        {
            foreach (TreeNode childNode in treeNode.Nodes)
            {
                if (childNode.Tag != null && childNode.Tag is CollectorHost)
                {
                    sortedCollectors.Add((CollectorHost)childNode.Tag);
                    AppendSortedCollectors(childNode, sortedCollectors);
                }
            }
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

        #region Refresh collector statusses
        private void InitializeBackgroundWorker()
        {
            try
            {
                if (refreshBackgroundWorker.IsBusy)
                    refreshBackgroundWorker.CancelAsync();
            }
            catch { }
            refreshBackgroundWorker = null;
            refreshBackgroundWorker = new BackgroundWorker();
            refreshBackgroundWorker.DoWork += refreshBackgroundWorker_DoWork;
        }
        private void RefreshMonitorPack(bool disablePollingOverride = false, bool forceUpdateNow = false)
        {
            //PausePolling(isPollingPaused);
            DateTime abortStart = DateTime.Now;
            try
            {
                //Stopping timer to avoid duplicate updates
                if (autoRefreshTimer != null)
                {
                    autoRefreshTimer.Enabled = false;
                    try
                    {
                        autoRefreshTimer.Stop();                        
                    }
                    catch { }
                }

                while (!forceUpdateNow && refreshBackgroundWorker.IsBusy && abortStart.AddSeconds(5) > DateTime.Now)
                {
                    Application.DoEvents();
                }
                if (forceUpdateNow || !refreshBackgroundWorker.IsBusy)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    refreshBackgroundWorker.RunWorkerAsync(disablePollingOverride);
                }
            }
            catch { }
            finally
            {
                if (isPollingEnabled)
                {
                    if (autoRefreshTimer == null)
                    {
                        autoRefreshTimer = new Timer();
                        autoRefreshTimer.Tick += autoRefreshTimer_Tick;
                    }

                    if (Properties.Settings.Default.OverridesMonitorPackFrequency || monitorPack == null || monitorPack.PollingFrequencyOverrideSec == 0)
                        autoRefreshTimer.Interval = Properties.Settings.Default.PollFrequencySec * 1000;
                    else
                        autoRefreshTimer.Interval = monitorPack.PollingFrequencyOverrideSec * 1000;
                    
                    autoRefreshTimer.Enabled = true;
                    autoRefreshTimer.Start();
                }
                //if (!isPollingPaused)
                //    ResumePolling();
            }
        }
        private void refreshBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool disablePollingOverride = false;
            if (e.Argument != null && e.Argument is bool)
                disablePollingOverride = (bool)e.Argument;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (monitorPack != null && monitorPack.Enabled)
                {
                    WaitForPollingToFinish(5);
                    Cursor.Current = Cursors.WaitCursor;

                    tvwCollectors.Invoke((MethodInvoker)delegate
                    {
                        try
                        {
                            tvwCollectors.BeginUpdate();
                            SetNodesToBeingRefreshed();
                        }
                        catch { }
                        finally
                        {
                            tvwCollectors.EndUpdate();
                            tvwCollectors.Refresh();
                            Application.DoEvents();
                            Cursor.Current = Cursors.WaitCursor;
                        }
                    });

                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    Cursor.Current = Cursors.WaitCursor;
                    CollectorState globalState = monitorPack.RefreshStates(disablePollingOverride);
                    sw.Stop();
                    Cursor.Current = Cursors.WaitCursor;
                    //PCSetCollectorsQueryTime(sw.ElapsedMilliseconds);
                    SetAppIcon(monitorPack.CurrentState);

                    string refreshIntervalStr = autoRefreshTimer == null ? "N/A" : (autoRefreshTimer.Interval / 1000).ToString();
                    UpdateStatusbar(string.Format("Global state: {0}, Updated: {1}, Duration: {2} sec, Cur Freq: {3}",
                        globalState,
                        DateTime.Now.ToString("HH:mm:ss"),
                        (sw.ElapsedMilliseconds / 1000.00).ToString("F2"),
                        refreshIntervalStr
                        ));
                }
                else
                {
                    SetAppIcon(CollectorState.NotAvailable);
                    UpdateStatusbar("Polling disabled");
                }
            }
            catch (Exception ex)
            {
                UpdateStatusbar("Error: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                firstRefresh = false;
            }
        }
        private void SetNodesToBeingRefreshed(TreeNode root = null)
        {
            if (root != null && root.Tag != null && root.Tag is CollectorHost)
            {
                CollectorHost collector = (CollectorHost)root.Tag;
                if (collector.CollectorAgents.Count > 0 && collector.Enabled)
                {
                    if (root.ImageIndex == collectorGoodStateImage1)
                    {
                        root.ImageIndex = collectorGoodStateImage2;
                        root.SelectedImageIndex = collectorGoodStateImage2;
                    }
                    else if (root.ImageIndex == collectorWarningStateImage1)
                    {
                        root.ImageIndex = collectorWarningStateImage2;
                        root.SelectedImageIndex = collectorWarningStateImage2;
                    }
                    else if (root.ImageIndex == collectorErrorStateImage1)
                    {
                        root.ImageIndex = collectorErrorStateImage2;
                        root.SelectedImageIndex = collectorErrorStateImage2;
                    }
                }
            }
            if (root == null)
                foreach (TreeNode childNode in tvwCollectors.Nodes)
                    SetNodesToBeingRefreshed(childNode);
            else
                foreach (TreeNode childNode in root.Nodes)
                    SetNodesToBeingRefreshed(childNode);
        }
        private void SetAppIcon(CollectorState state)
        {
            refreshCycleA = !refreshCycleA;
            try
            {
                Icon icon;
                if (state == CollectorState.Error)
                {
                    if (refreshCycleA)
                        icon = Properties.Resources.QM4BlueStateErrA;
                    else
                        icon = Properties.Resources.QM4BlueStateErrB;
                }
                else if (state == CollectorState.Warning)
                {
                    if (refreshCycleA)
                        icon = Properties.Resources.QM4BlueStateWarnA;
                    else
                        icon = Properties.Resources.QM4BlueStateWarnB;
                }
                else if (state == CollectorState.Good)
                {
                    if (refreshCycleA)
                        icon = Properties.Resources.QM4BlueStateGoodA;
                    else
                        icon = Properties.Resources.QM4BlueStateGoodB;
                }
                else
                {
                    if (refreshCycleA)
                        icon = Properties.Resources.QM4BlueStateNAA;
                    else
                        icon = Properties.Resources.QM4BlueStateNAB;
                }
                Icon oldIcon = this.Icon;
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        this.Icon = icon;
                    }
                    );
                }
                else
                {
                    this.Icon = icon;
                }
                oldIcon.Dispose();
            }
            catch (Exception)
            {
                //to be added
                if (refreshCycleA)
                    this.Icon = Properties.Resources.QM4BlueStateNAA;
                else
                    this.Icon = Properties.Resources.QM4BlueStateNAB;
            }
        }
        #endregion

        #region Auto refreshing timer
        private void autoRefreshTimer_Tick(object sender, EventArgs e)
        {
            if (isPollingEnabled)
                RefreshMonitorPack();
        }
        private void PausePolling(bool disablePolling = true)
        {
            if (disablePolling)
                isPollingEnabled = false;

            if (autoRefreshTimer != null)
            {
                autoRefreshTimer.Enabled = false;
                try
                {
                    autoRefreshTimer.Stop();
                    autoRefreshTimer.Tick -= autoRefreshTimer_Tick;
                }
                catch { }
                autoRefreshTimer = null;

            }
            UpdateAppTitle();
            UpdatePauseButton();
            //if (!resetPauseVar)
            //{
            //    isPollingPaused = false; //change it back                
            //}
            //else
            //{
            //    //this.pauseToolStripButton.Image = global::QuickMon.Properties.Resources._135_42;
            //}
        }
        private void ResumePolling(bool startImmediately = false)
        {
            isPollingEnabled = true;
            //this.pauseToolStripButton.Image = global::QuickMon.Properties.Resources._221_5;
            if (autoRefreshTimer != null)
            {
                autoRefreshTimer.Enabled = false;
                autoRefreshTimer = null;
            }

            if (startImmediately)
            {
                RefreshMonitorPack(false, true);
            }
            else
            {
                autoRefreshTimer = new Timer();

                if (Properties.Settings.Default.OverridesMonitorPackFrequency || monitorPack == null || monitorPack.PollingFrequencyOverrideSec == 0)
                    autoRefreshTimer.Interval = Properties.Settings.Default.PollFrequencySec * 1000;
                else
                    autoRefreshTimer.Interval = monitorPack.PollingFrequencyOverrideSec * 1000;
                autoRefreshTimer.Tick += autoRefreshTimer_Tick;
                autoRefreshTimer.Enabled = true;
                autoRefreshTimer.Start();
            }
            UpdateAppTitle();
            UpdatePauseButton();
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
            if (!isPollingEnabled)
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

        #region RecentMonitorPackList
        private void AddMonitorPackFileToRecentList(string monitorPackPath)
        {
            if (Properties.Settings.Default.RecentQMConfigFiles == null)
                Properties.Settings.Default.RecentQMConfigFiles = new System.Collections.Specialized.StringCollection();
            if ((from string f in Properties.Settings.Default.RecentQMConfigFiles
                 where f.ToUpper() == monitorPackPath.ToUpper()
                 select f).Count() == 0)
            {
                Properties.Settings.Default.RecentQMConfigFiles.Add(monitorPackPath);
            }
            Properties.Settings.Default.LastMonitorPack = monitorPackPath;
            //LoadRecentMonitorPackList();
        }
        private void LoadRecentMonitorPackList()
        {
            cboRecentMonitorPacks.Items.Clear();
            cboRecentMonitorPacks.Items.Add(new QuickMon.Controls.ComboItem("", ""));

            try
            {
                List<string> allowFilters = new List<string>();
                List<string> disallowFilters = new List<string>();
                string typeFilters = Properties.Settings.Default.RecentQMConfigFileFilters;
                if (typeFilters.Trim().Length == 0)
                    typeFilters = "*";
                foreach (string typeFilter in typeFilters.Split(','))
                {
                    if (typeFilter.Trim().StartsWith("!"))
                        disallowFilters.Add(typeFilter.Trim(' ', '!'));
                    else
                        allowFilters.Add(typeFilter.Trim());
                }

                foreach (string filePath in (from string s in Properties.Settings.Default.RecentQMConfigFiles
                                             orderby s
                                             select s))
                {
                    bool mpVisible = false;
                    if (System.IO.File.Exists(filePath))
                    {
                        MonitorPack.NameAndTypeSummary summary = MonitorPack.GetMonitorPackTypeName(filePath);
                        if ((from string s in allowFilters
                             where s == "*" || s.ToLower() == summary.TypeName.ToLower()
                             select s).Count() > 0)
                            mpVisible = true;
                        if ((from string s in disallowFilters
                             where s.ToLower() == summary.TypeName.ToLower()
                             select s).Count() > 0)
                            mpVisible = false;
                        if (mpVisible)
                        {
                            string entryDisplayName = filePath;
                            if (!Properties.Settings.Default.ShowFullPathForQuickRecentist)
                                entryDisplayName = summary.Name;

                            if (cboRecentMonitorPacks.DropDownWidth < TextRenderer.MeasureText(entryDisplayName + "........", cboRecentMonitorPacks.Font).Width && entryDisplayName.Length > 20)
                            {
                                string ellipseText = entryDisplayName.Substring(0, 20) + "....";
                                string tmpStr = entryDisplayName.Substring(4);
                                while (TextRenderer.MeasureText(ellipseText + tmpStr, cboRecentMonitorPacks.Font).Width > cboRecentMonitorPacks.DropDownWidth)
                                {
                                    tmpStr = tmpStr.Substring(1);
                                }
                                cboRecentMonitorPacks.Items.Add(new QuickMon.Controls.ComboItem(ellipseText + tmpStr, summary));
                            }
                            else
                            {
                                cboRecentMonitorPacks.Items.Add(new QuickMon.Controls.ComboItem(entryDisplayName, summary));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void recentMonitorPackToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //HideCollectorContextMenu();
        //SelectRecentMonitorPackDialog rmp = new SelectRecentMonitorPackDialog();
        //if (rmp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //{
        //    CloseAllDetailWindows();
        //    LoadMonitorPack(rmp.SelectedMonitorPack);
        //    RefreshMonitorPack(true, true);
        //}
        //else
        //{
        //    LoadRecentMonitorPackList();
        //}  
        //}

        private void cmdRecentMonitorPacks_Click(object sender, EventArgs e)
        {
            cboRecentMonitorPacks.Visible = true;
            llblMonitorPack.Visible = false;
            cboRecentMonitorPacks.Dock = DockStyle.Fill;
            LoadRecentMonitorPackList();
            cboRecentMonitorPacks.Focus();
            SendKeys.Send("{F4}");
        }

        private void cboRecentMonitorPacks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboRecentMonitorPacks.SelectedIndex > 0 && cboRecentMonitorPacks.SelectedItem is QuickMon.Controls.ComboItem)
            {
                llblMonitorPack.Visible = true;
                cboRecentMonitorPacks.Visible = false;                
                cboRecentMonitorPacks.Dock = DockStyle.Left;

                CloseAllDetailWindows();
                MonitorPack.NameAndTypeSummary summary = (MonitorPack.NameAndTypeSummary)((QuickMon.Controls.ComboItem)cboRecentMonitorPacks.SelectedItem).Value;

                LoadMonitorPack(summary.Path);
                RefreshMonitorPack(true, true);
            }
            else
            {
                llblMonitorPack.Visible = true;
                cboRecentMonitorPacks.Visible = false;
                cboRecentMonitorPacks.Dock = DockStyle.Left;
            }
        }

        private void cboRecentMonitorPacks_DropDownClosed(object sender, EventArgs e)
        {
            llblMonitorPack.Visible = true;
            cboRecentMonitorPacks.Visible = false;
            cboRecentMonitorPacks.Dock = DockStyle.Left;
        }
        #endregion
    }
}
