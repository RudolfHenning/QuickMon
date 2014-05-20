using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon
{
    public partial class MainForm : FadeSnapForm
    {
        public MainForm()
        {
            InitializeComponent();

            popedContainerForTreeView = new Controls.CollectorContextMenuControl();
            poperContainerForTreeView = new Controls.PoperContainer(popedContainerForTreeView);
            popedContainerForListView = new Controls.NotifierContextMenuControl();
            poperContainerForListView = new Controls.PoperContainer(popedContainerForListView);
        }

        #region Private vars
        private int refreshCycleCounter = 0;
        private bool monitorPackChanged = false;
        private int rootImgIndex = -1;
        private MonitorPack monitorPack;
        private string quickMonPCCategory = "QuickMon 3 UI Client";
        private Point collectorContextMenuLaunchPoint = new Point();
        private Point notifierContextMenuLaunchPoint = new Point();
        #region Performance Counter Vars
        private PerformanceCounter collectorErrorStatePerSec = null;
        private PerformanceCounter collectorWarningStatePerSec = null;
        private PerformanceCounter collectorInfoStatePerSec = null;
        private PerformanceCounter collectorsQueriedPerSecond = null;
        private PerformanceCounter collectorsQueryTime = null;
        private PerformanceCounter selectedCollectorsQueryTime = null;
        #endregion

        private QuickMon.Controls.CollectorContextMenuControl popedContainerForTreeView;//a user control that is derievd from PopedContainer; it can contain any type of controls and you design it as if you design a form!!!
        private QuickMon.Controls.PoperContainer poperContainerForTreeView;//the container... which displays previous user control as a context poped up menu
        private QuickMon.Controls.NotifierContextMenuControl popedContainerForListView;
        private QuickMon.Controls.PoperContainer poperContainerForListView;

        private List<CollectorEntry> copiedCollectorList = new List<CollectorEntry>();
        private List<CollectorStats> collectorStatsWindows = new List<CollectorStats>();
        #endregion       

        #region Form events
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblNoNotifiersYet.Dock = DockStyle.Fill;
            popedContainerForTreeView.cmdCopy.Enabled = false;
            popedContainerForTreeView.cmdPaste.Enabled = false;
            popedContainerForTreeView.cmdPasteWithEdit.Enabled = false;
            popedContainerForTreeView.cmdStats.Enabled = false;
            popedContainerForTreeView.cmdCopy.Click += new System.EventHandler(collectorContextMenuCmdCopy_Click);
            popedContainerForTreeView.cmdPaste.Click += new System.EventHandler(collectorContextMenuCmdPaste_Click);
            popedContainerForTreeView.cmdPasteWithEdit.Click += new System.EventHandler(collectorContextMenuCmdPasteWithEdit_Click);
            popedContainerForTreeView.cmdViewDetails.Click += new System.EventHandler(collectorTreeViewDetailsToolStripMenuItem_Click);
            popedContainerForTreeView.cmdAddFolder.Click += new System.EventHandler(addCollectorFolderToolStripMenuItem_Click);
            popedContainerForTreeView.cmdAddCollector.Click += new System.EventHandler(addCollectorToolStripMenuItem_Click);
            popedContainerForTreeView.cmdEditCollector.Click += new System.EventHandler(collectorTreeEditConfigToolStripMenuItem_Click);
            popedContainerForTreeView.cmdDisableCollector.Click += new System.EventHandler(disableCollectorTreeToolStripMenuItem_Click);
            popedContainerForTreeView.cmdDeleteCollector.Click += new System.EventHandler(removeCollectorToolStripMenuItem_Click);
            popedContainerForTreeView.cmdStats.Click += new System.EventHandler(cmdStats_Click);
            popedContainerForTreeView.cmdRefresh.Click += new EventHandler(refreshToolStripButton_Click);
            popedContainerForTreeView.cmdNewMonitorPack.Click += new EventHandler(newMonitorPackToolStripMenuItem_Click);
            popedContainerForTreeView.cmdLoadMonitorPack.Click += new EventHandler(openMonitorPackToolStripButton_ButtonClick);
            popedContainerForTreeView.cmdLoadRecentMonitorPack.Click += new EventHandler(recentMonitorPackToolStripMenuItem1_Click);
            popedContainerForTreeView.cmdSaveMonitorPack.Click += new EventHandler(saveAsMonitorPackToolStripMenuItem_ButtonClick);
            popedContainerForTreeView.cmdGeneralSettings.Click += new EventHandler(generalSettingsToolStripSplitButton_ButtonClick);
            popedContainerForTreeView.cmdRemoteAgents.Click += new System.EventHandler(this.knownRemoteAgentsToolStripMenuItem_Click);
            popedContainerForTreeView.cmdAbout.Click += new EventHandler(aboutToolStripMenuItem_Click);            

            popedContainerForListView.cmdViewDetails.Click += new System.EventHandler(notifierViewerToolStripMenuItem_Click);
            popedContainerForListView.cmdAddNotifier.Click += new System.EventHandler(addNotifierToolStripMenuItem_Click);
            popedContainerForListView.cmdEditNotifier.Click += new System.EventHandler(notifierConfigurationToolStripMenuItem_Click);
            popedContainerForListView.cmdDisableNotifier.Click += new System.EventHandler(disableNotifierToolStripMenuItem_Click);
            popedContainerForListView.cmdDisableNotifier.BackColor = Color.DarkGray;
            popedContainerForListView.cmdDeleteNotifier.Click += new System.EventHandler(removeNotifierToolStripMenuItem_Click);

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
            masterSplitContainer.Panel2Collapsed = true;
            MainForm_Resize(null, null);
            lblVersion.Text = string.Format("v{0}.{1}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor);
            toolTip1.SetToolTip(lblVersion, string.Format("v{0} ({1})", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version, new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).LastWriteTime.ToString("yyyy-MM-dd")));
            tvwCollectors.EnableAutoScrollToSelectedNode = true;
            tvwCollectors.TreeNodeMoved += tvwCollectors_TreeNodeMoved;
            tvwCollectors.EnterKeyDown += tvwCollectors_EnterKeyDown;
            tvwCollectors.RootAlwaysExpanded = true;
            tvwCollectors.ContextMenuShowUp += tvwCollectors_ContextMenuShowUp;
            adminModeToolStripStatusLabel.Visible = HenIT.Security.AdminModeTools.IsInAdminMode();
            restartInAdminModeToolStripMenuItem.Visible = !HenIT.Security.AdminModeTools.IsInAdminMode();
        }        
        private void MainForm_Resize(object sender, EventArgs e)
        {

        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                InitializeGlobalPerformanceCounters();

                mainRefreshTimer.Interval = Properties.Settings.Default.PollFrequencySec * 1000;

                if (Properties.Settings.Default.LastMonitorPack != null && System.IO.File.Exists(Properties.Settings.Default.LastMonitorPack))
                {
                    LoadMonitorPack(Properties.Settings.Default.LastMonitorPack);
                    System.Threading.Thread.Sleep(100);
                    RefreshMonitorPack();
                }
                else
                {
                    monitorPack = new MonitorPack();
                    monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
                    monitorPack.CollectorCurrentStateReported += monitorPack_CollectorCurrentStateReported;
                    monitorPack.OnNotifierError += monitorPack_RaiseNotifierError;
                    monitorPack.RunCollectorCorrectiveWarningScript += monitorPack_RunCollectorCorrectiveWarningScript;
                    monitorPack.RunCollectorCorrectiveErrorScript += monitorPack_RunCollectorCorrectiveErrorScript;
                    monitorPack.RunRestorationScript += monitorPack_RunRestorationScript;
                    monitorPack.CollectorCalled += monitorPack_CollectorCalled;
                    lblNoNotifiersYet.Visible = true;
                }
                monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tvwCollectors.Focus();
            SetPollingFrequency();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PerformCleanShutdown();
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                RefreshMonitorPack(true);
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                openMonitorPackToolStripButton_ButtonClick(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.T)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                recentMonitorPackToolStripMenuItem1_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                newMonitorPackToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                generalSettingsToolStripSplitButton_ButtonClick(sender, e);
            }
            
        }
        #endregion

        #region Toolbar events
        private void openMonitorPackToolStripButton_ButtonClick(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            try
            {
                string startUpPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.DoNotVerify), "Hen IT\\QuickMon");
                if (!System.IO.Directory.Exists(startUpPath))
                    System.IO.Directory.CreateDirectory(startUpPath);
                openFileDialogOpen.InitialDirectory = startUpPath;
                if (openFileDialogOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CloseAllDetailWindows();
                    LoadMonitorPack(openFileDialogOpen.FileName);
                    RefreshMonitorPack();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Open", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void recentMonitorPackToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            RecentMonitorPacks recentMonitorPacks = new RecentMonitorPacks();
            if (recentMonitorPacks.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CloseAllDetailWindows();
                LoadMonitorPack(recentMonitorPacks.SelectedPack);
                RefreshMonitorPack();
            }            
        }
        private void newMonitorPackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            CloseAllDetailWindows();
            NewMonitorPack();            
        }
        private void saveAsMonitorPackToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            SaveAsMonitorPack();
        }
        private void saveAsMonitorPackToolStripMenuItem_ButtonClick(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            SaveMonitorPack();            
        }
        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            RefreshMonitorPack(true);
        }
        private void showDefaultNotifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (monitorPack != null && monitorPack.DefaultViewerNotifier != null)
            {
                monitorPack.DefaultViewerNotifier.ShowViewer();
            }
        }
        private void showAllNotifiersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            masterSplitContainer.Panel2Collapsed = false;
            llblNotifierViewToggle.Text = masterSplitContainer.Panel2Collapsed ? "Show Notifiers" : "Hide Notifiers";
        }
        private void generalSettingsToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            bool timerEnabled = mainRefreshTimer.Enabled;
            HideCollectorContextMenu();
            GeneralSettings generalSettings = new GeneralSettings();
            generalSettings.PollingFrequencySec = Properties.Settings.Default.PollFrequencySec;
            generalSettings.PollingEnabled = timerEnabled;
            mainRefreshTimer.Enabled = false; //temporary stops it.
            if (generalSettings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.SnappingEnabled = Properties.Settings.Default.MainFormSnap;
                if (monitorPack != null)
                    monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;

                Properties.Settings.Default.PollFrequencySec = generalSettings.PollingFrequencySec;                
                timerEnabled = generalSettings.PollingEnabled;                
            }
            SetPollingFrequency(timerEnabled);
        }
        private void pollingDisabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainRefreshTimer.Enabled = false;
            SetAppIcon(CollectorState.NotAvailable);
            toolStripStatusLabelStatus.Text = "Polling disabled";
        }
        private void pollingSlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainRefreshTimer.Enabled = false;
            Properties.Settings.Default.OverridesMonitorPackFrequency = true;
            Properties.Settings.Default.PollFrequencySec = 60000;
            SetPollingFrequency();
            //mainRefreshTimer.Interval = 60000;
            //mainRefreshTimer.Enabled = true;
            toolStripStatusLabelStatus.Text = "Polling set to slow";
        }
        private void pollingNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainRefreshTimer.Enabled = false;
            Properties.Settings.Default.OverridesMonitorPackFrequency = true;
            Properties.Settings.Default.PollFrequencySec = 30000;
            SetPollingFrequency();
            //mainRefreshTimer.Interval = 30000;
            //mainRefreshTimer.Enabled = true;
            toolStripStatusLabelStatus.Text = "Polling set to normal";
        }
        private void pollingFastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainRefreshTimer.Enabled = false;
            Properties.Settings.Default.OverridesMonitorPackFrequency = true;
            Properties.Settings.Default.PollFrequencySec = 5000;
            SetPollingFrequency();
            //mainRefreshTimer.Interval = 5000;
            //mainRefreshTimer.Enabled = true;
            toolStripStatusLabelStatus.Text = "Polling set to fast";
        }
        private void customPollingFrequencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            generalSettingsToolStripSplitButton_ButtonClick(sender, e);
            //SetTimerConfig setTimerConfig = new SetTimerConfig();
            //setTimerConfig.FrequencySec = (mainRefreshTimer.Interval / 1000);
            //setTimerConfig.TimerEnabled = mainRefreshTimer.Enabled;
            //if (setTimerConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    mainRefreshTimer.Interval = setTimerConfig.FrequencySec * 1000;
            //    mainRefreshTimer.Enabled = setTimerConfig.TimerEnabled;
            //}
        }
        private void closeAllChildWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllDetailWindows();
        }
        private void restartInAdminModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PerformCleanShutdown(true))
                return;
            HenIT.Security.AdminModeTools.RestartInAdminMode();
        }
        private void knownRemoteAgentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuickMon.Forms.RemoteAgentsManager ram = new Forms.RemoteAgentsManager();
            ram.ShowDialog();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            AboutQuickMon aboutQuickMon = new AboutQuickMon();
            aboutQuickMon.ShowDialog();
        }      
        #endregion

        #region Label clicks
        private void llblMonitorPack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool timerEnabled = mainRefreshTimer.Enabled;
            mainRefreshTimer.Enabled = false; //temporary stops it.
            EditMonitorPackConfig emc = new EditMonitorPackConfig();
            emc.SelectedMonitorPack = monitorPack;
            if (emc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SetMonitorChanged();
                SetMonitorPackNameDescription();                
            }
            SetPollingFrequency(timerEnabled);
        }
        private void llblNotifierViewToggle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            masterSplitContainer.Panel2Collapsed = !masterSplitContainer.Panel2Collapsed;
            llblNotifierViewToggle.Text = masterSplitContainer.Panel2Collapsed ? "Show Notifiers" : "Hide Notifiers";
        }
        #endregion

        #region Collector TreeView events
        private void tvwCollectors_TreeNodeMoved(TreeNode dragNode)
        {
            if (dragNode != null)
            {
                //set Collector Parent if needed
                if (dragNode.Tag is CollectorEntry)
                {
                    if (dragNode.Parent.Tag is CollectorEntry)
                    {
                        ((CollectorEntry)dragNode.Tag).ParentCollectorId = ((CollectorEntry)dragNode.Parent.Tag).UniqueId;
                    }
                    else
                        ((CollectorEntry)dragNode.Tag).ParentCollectorId = "";
                }
                SetMonitorChanged();
                DoAutoSave();
            }
        }
        private void tvwCollectors_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
                ShowCollectorConfig();
            else
                ShowCollectorDetails();
        }
        private void tvwCollectors_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CheckCollectorContextMenuEnables();
        }
        private void tvwCollectors_ContextMenuShowUp()
        {
            Point topabsolute = this.PointToScreen(tvwCollectors.Location);
            Point topRelative = this.PointToClient(tvwCollectors.Location);
            Point calcPoint;
            if (tvwCollectors.SelectedNode != null)
            {
                calcPoint = new Point(tvwCollectors.Location.X + tvwCollectors.SelectedNode.Bounds.Location.X, GetControlLocationWithinParent(tvwCollectors).Y + tvwCollectors.SelectedNode.Bounds.Location.Y + 20 - this.Top);
            }
            else
            {
                calcPoint = new Point(tvwCollectors.Location.X + (tvwCollectors.Width / 2), tvwCollectors.Location.Y + (tvwCollectors.Height / 2));
            }
            CheckCollectorContextMenuEnables();
            collectorContextMenuLaunchPoint = calcPoint;
            showCollectorContextMenuTimer.Enabled = false;
            showCollectorContextMenuTimer.Enabled = true;
        }
        private void tvwCollectors_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point topabsolute = this.PointToScreen(panel1.Location);
                Point topRelative = new Point(topabsolute.X - this.Location.X, topabsolute.Y - this.Location.Y);
                Point calcPoint = new Point(Cursor.Position.X - tvwCollectors.Location.X - this.Left, Cursor.Position.Y - topRelative.Y - this.Top + 10);
                collectorContextMenuLaunchPoint = calcPoint;
                CheckCollectorContextMenuEnables();

                showCollectorContextMenuTimer.Enabled = false;
                showCollectorContextMenuTimer.Enabled = true;
            }
        }
        private void tvwCollectors_EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                collectorTreeEditConfigToolStripMenuItem_Click(null, null);
            }
            else
            {
                collectorTreeViewDetailsToolStripMenuItem_Click(null, null);
            }
        }
        private Point GetControlLocationWithinParent(Control control)
        {
            Point location;
            if (control.Parent != null)
            {
                Point parentLocation = GetControlLocationWithinParent(control.Parent);
                location = new Point(parentLocation.X + control.Location.X, parentLocation.Y + control.Location.Y);
            }
            else
            {
                location = control.Location;
            }
            return location;
        }
        #endregion

        #region Notifier ListView events
        private void lvwNotifiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckNotifierContextMenuEnables();
        }
        private void lvwNotifiers_DoubleClick(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
                notifierConfigurationToolStripMenuItem_Click(null, null);
            else
                notifierViewerToolStripMenuItem_Click(null, null);
        }
        private void lvwNotifiers_Resize(object sender, EventArgs e)
        {
            lvwNotifiers.Columns[0].Width = lvwNotifiers.ClientSize.Width;
        }
        private void lvwNotifiers_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                showNotifierContextMenuTimer.Enabled = false;
                showNotifierContextMenuTimer.Enabled = true;

                Point topabsolute = this.PointToScreen(panel1.Location);
                Point topRelative = new Point(topabsolute.X - this.Location.X, topabsolute.Y - this.Location.Y);
                Point calcPoint = new Point(Cursor.Position.X - lvwNotifiers.Location.X - this.Left, Cursor.Position.Y - topRelative.Y - this.Top + 10);
                notifierContextMenuLaunchPoint = calcPoint;
                CheckNotifierContextMenuEnables();
            }
        }
        #endregion

        #region Private methods
        private void SetPollingFrequency(bool enabledAfterWards = true)
        {
            mainRefreshTimer.Enabled = false;
            if (Properties.Settings.Default.OverridesMonitorPackFrequency || monitorPack == null || monitorPack.PollingFrequencyOverrideSec == 0)
                mainRefreshTimer.Interval = Properties.Settings.Default.PollFrequencySec * 1000;
            else
                mainRefreshTimer.Interval = monitorPack.PollingFrequencyOverrideSec * 1000;
            mainRefreshTimer.Enabled = enabledAfterWards;
        }
        private void SetAppIcon(CollectorState state)
        {
            refreshCycleCounter++;
            if (refreshCycleCounter > 1)
                refreshCycleCounter = 0;

            try
            {
                Icon icon;
                if (state == CollectorState.Error)
                {
                    if (refreshCycleCounter == 0)
                        icon = Properties.Resources.QMstateErrorSml;
                    else
                        icon = Properties.Resources.QMstateError;
                }
                else if (state == CollectorState.Warning)
                {
                    if (refreshCycleCounter == 0)
                        icon = Properties.Resources.QMstateWarningSml;
                    else
                        icon = Properties.Resources.QMstateWarning;
                }
                else if (state == CollectorState.Good)
                {
                    if (refreshCycleCounter == 0)
                        icon = Properties.Resources.QMstateGoodSml;
                    else
                        icon = Properties.Resources.QMstateGood;
                }
                else
                {
                    if (refreshCycleCounter == 0)
                        icon = Properties.Resources.QMstateDisabledSml;
                    else
                        icon = Properties.Resources.QMstateDisabled;
                }
                Icon oldIcon = this.Icon;
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate()
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
                if (refreshCycleCounter == 0)
                    this.Icon = Properties.Resources.QMstateNASml;
                else
                    this.Icon = Properties.Resources.QMstateNA;
            }
        }   
        private void UpdateAppTitle()
        {
            Text = "QuickMon 3";
            if (monitorPackChanged)
                Text += "*";
            if (monitorPack != null)
            {
                if (!monitorPack.Enabled)
                    Text += " - [Disabled]";
                if (monitorPack.Name != null && monitorPack.Name.Length > 0)
                    Text += string.Format(" - [{0}]", monitorPack.Name);
                //if (monitorPack.MonitorPackPath != null && monitorPack.MonitorPackPath.Length > 0)
                //    Text += string.Format(" - {0}", monitorPack.MonitorPackPath);
            }
        }
        private void CloseAllDetailWindows()
        {
            if (monitorPack != null)
            {
                if (monitorPack.Collectors != null)
                {
                    foreach (CollectorEntry entry in monitorPack.Collectors)
                    {
                        entry.CloseDetails();
                    }
                }
                if (monitorPack.Notifiers != null)
                {
                    foreach (NotifierEntry entry in monitorPack.Notifiers)
                    {
                        entry.CloseViewer();
                    }
                }
            }
            foreach (var cs in collectorStatsWindows)
            {
                if (cs.IsStillVisible())
                    cs.Close();
            }
            collectorStatsWindows.Clear();
        }
        private void DoAutoSave()
        {
            if (Properties.Settings.Default.AutosaveChanges)
                SaveAsMonitorPack();
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
        private void SortItemsByTreeView()
        {
            TreeNode collectorRootNode = tvwCollectors.Nodes[0];
            List<CollectorEntry> sortedCollectors = new List<CollectorEntry>();
            AppendSortedCollectors(collectorRootNode, sortedCollectors);
            monitorPack.Collectors.Clear();
            foreach (CollectorEntry c in sortedCollectors)
            {
                monitorPack.Collectors.Add(c);
            }

        }
        private void AppendSortedCollectors(TreeNode treeNode, List<CollectorEntry> sortedCollectors)
        {
            foreach (TreeNode childNode in treeNode.Nodes)
            {
                if (childNode.Tag != null && childNode.Tag is CollectorEntry)
                {
                    sortedCollectors.Add((CollectorEntry)childNode.Tag);
                    AppendSortedCollectors(childNode, sortedCollectors);
                }
            }
        }
        private void NewMonitorPack()
        {
            if (monitorPack != null && System.IO.File.Exists(monitorPack.MonitorPackPath) && monitorPackChanged)
            {
                if (Properties.Settings.Default.AutosaveChanges || MessageBox.Show("Do you want to save changes to the current monitor pack?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!SaveAsMonitorPack())
                        return;
                }
            }

            mainRefreshTimer.Enabled = false;
            try
            {
                monitorPack.CollectorCurrentStateReported -= monitorPack_CollectorCurrentStateReported;

                monitorPack.ClosePerformanceCounters();
                monitorPack = null;
            }
            catch { }
            monitorPack = new MonitorPack();
            monitorPack.LoadXml(Properties.Resources.BlankMonitorPack);
            monitorPack.MonitorPackPath = "";
            LoadTreeFromMonitorPack();
            monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
            monitorPack.CollectorCurrentStateReported += monitorPack_CollectorCurrentStateReported;
            if (monitorPack.Notifiers != null && monitorPack.Notifiers.Count == 0)
                lblNoNotifiersYet.Visible = true;
            mainRefreshTimer.Enabled = true;
            monitorPackChanged = false;
        }
        private void LoadMonitorPack(string monitorPackPath)
        {
            if (System.IO.File.Exists(monitorPackPath))
            {
                if (monitorPackChanged)
                {
                    if (Properties.Settings.Default.AutosaveChanges || MessageBox.Show("Do you want to save changes to the current monitor pack?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (!SaveAsMonitorPack())
                            return;
                    }
                }
                mainRefreshTimer.Enabled = false;
                try
                {
                    monitorPack.CollectorCurrentStateReported -= monitorPack_CollectorCurrentStateReported;
                    monitorPack.CollecterLoading -= monitorPack_CollecterLoading;
                    monitorPack.OnNotifierError -= monitorPack_RaiseNotifierError;
                    monitorPack.RunCollectorCorrectiveWarningScript -= monitorPack_RunCollectorCorrectiveWarningScript;
                    monitorPack.RunCollectorCorrectiveErrorScript -= monitorPack_RunCollectorCorrectiveErrorScript;
                    monitorPack.RunRestorationScript -= monitorPack_RunRestorationScript;
                    monitorPack.CollectorCalled -= monitorPack_CollectorCalled;
                    monitorPack.CollectorExecutionTimeEvent -= monitorPack_CollectorExecutionTimeEvent;
                    
                    //monitorPack.RaiseNotifierError -= new RaiseNotifierErrorDelegare(monitorPack_RaiseNotifierError);
                    //monitorPack.CollectorCalled -= new RaiseCollectorCalledDelegate(monitorPack_CollectorCalled);
                    //monitorPack.CollectorExecutionTimeEvent -= new CollectorExecutionTimeDelegate(monitorPack_CollectorExecutionTimeEvent);
                    monitorPack.ClosePerformanceCounters();
                }
                catch { }
                finally
                {
                    monitorPack = null;
                }

                TreeNode root = tvwCollectors.Nodes[0];
                root.Nodes.Clear();

                root.Text = "Collectors - Loading...";
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;

                monitorPack = new MonitorPack();
                monitorPack.CollecterLoading += monitorPack_CollecterLoading;

                monitorPack.Load(monitorPackPath);
                LoadTreeFromMonitorPack();
                monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
                monitorPack.CollectorCurrentStateReported += monitorPack_CollectorCurrentStateReported;
                monitorPack.OnNotifierError += monitorPack_RaiseNotifierError;
                monitorPack.RunCollectorCorrectiveWarningScript += monitorPack_RunCollectorCorrectiveWarningScript;
                monitorPack.RunCollectorCorrectiveErrorScript += monitorPack_RunCollectorCorrectiveErrorScript;
                monitorPack.RunRestorationScript += monitorPack_RunRestorationScript;
                monitorPack.CollectorCalled += monitorPack_CollectorCalled;
                monitorPack.CollectorExecutionTimeEvent += monitorPack_CollectorExecutionTimeEvent;

                Cursor.Current = Cursors.Default;
                tvwCollectors.Nodes[0].Text = "Collectors";
                Application.DoEvents();

                AddMonitorPackFileToRecentList(monitorPackPath);

                lblNoNotifiersYet.Visible = monitorPack.Notifiers.Count == 0;
                mainRefreshTimer.Enabled = true;
                monitorPackChanged = false;
            }
        }        

        private void LoadTreeFromMonitorPack()
        {
            SetMonitorPackNameDescription();
            TreeNode root = tvwCollectors.Nodes[0];
            root.Nodes.Clear();
            List<CollectorEntry> noDependantCollectors = (from c in monitorPack.Collectors
                                                          where c.ParentCollectorId.Length == 0
                                                          select c).ToList();
            foreach (CollectorEntry collector in noDependantCollectors)
            {
                LoadCollectorNode(root, collector);
            }
            root.Expand();

            UpdateAppTitle();
            LoadNotifiersList();
            try
            {
                showDefaultNotifierToolStripMenuItem.Enabled = false;
                if (monitorPack != null)
                {
                    toolStripStatusLabelStatus.Text = string.Format("{0} collector(s), {1} notifier(s)",
                         monitorPack.Collectors.Count,
                         monitorPack.Notifiers.Count);
                    showDefaultNotifierToolStripMenuItem.Enabled = monitorPack.DefaultViewerNotifier != null;
                }
            }
            catch { }
            tvwCollectors.SelectedNode = root;
            root.EnsureVisible();
        }
        private void SetMonitorPackNameDescription()
        {
            toolTip1.SetToolTip(llblMonitorPack, "");
            llblMonitorPack.Text = "";
            if (monitorPack == null || ((monitorPack.Name == null || monitorPack.Name.Trim().Length == 0)))
            {
                llblMonitorPack.Text = "Click here to set the monitor pack name.";
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
                llblMonitorPack.Text = "Click here to set the monitor pack name.";
        }
        private void LoadNotifiersList()
        {
            lvwNotifiers.Items.Clear();
            if (monitorPack.Notifiers != null && monitorPack.Notifiers.Count > 0)
            {
                foreach (NotifierEntry n in monitorPack.Notifiers)
                {
                    ListViewItem lvi = new ListViewItem(n.Name);
                    lvi.ImageIndex = (n.Notifier != null && n.Notifier.HasViewer) ? 1 : 0;
                    lvi.Tag = n;
                    lvi.ForeColor = n.Enabled ? SystemColors.WindowText : Color.Gray;
                    lvwNotifiers.Items.Add(lvi);
                }
            }
            lblNoNotifiersYet.Visible = monitorPack.Notifiers.Count == 0;
        }
        private void llbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender is LinkLabel && ((LinkLabel)sender).Tag is NotifierEntry)
            {
                NotifierEntry n = (NotifierEntry)((LinkLabel)sender).Tag;
                Management.EditNotifierEntry editNotifierEntry = new Management.EditNotifierEntry();
                editNotifierEntry.SelectedEntry = n;
                if (editNotifierEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
                {
                    n.CloseViewer();
                    ((LinkLabel)sender).Text = n.Name;                    
                }
            }
        }
        private void LoadCollectorNode(TreeNode root, CollectorEntry collector)
        {
            TreeNode collectorNode;
            if (collector.IsFolder)
                collectorNode = new TreeNode(collector.Name, 1, 1);
            else
                collectorNode = new TreeNode(collector.Name, 2, 2);
            collectorNode.Tag = collector;
            collector.Tag = collectorNode;
            collectorNode.ForeColor = collector.Enabled ? SystemColors.WindowText : Color.Gray;
            if (collector.EnableRemoteExecute || collector.ForceRemoteExcuteOnChildCollectors)
            {
                collectorNode.Text += string.Format(" [{0}:{1}]", (collector.ForceRemoteExcuteOnChildCollectors ? "!" : "") + collector.RemoteAgentHostAddress, collector.RemoteAgentHostPort);
            }
            foreach (CollectorEntry childCollector in (from c in monitorPack.Collectors
                                                       where c.ParentCollectorId == collector.UniqueId &&
                                                       c.ParentCollectorId != c.UniqueId
                                                       select c))
            {
                LoadCollectorNode(collectorNode, childCollector);
            }
            root.Nodes.Add(collectorNode);
            if (collector.Enabled)
                collectorNode.Expand();
        }
       
        private void AddMonitorPackFileToRecentList(string monitorPackPath)
        {
            if ((from string f in Properties.Settings.Default.RecentQMConfigFiles
                 where f.ToUpper() == monitorPackPath.ToUpper()
                 select f).Count() == 0)
            {
                Properties.Settings.Default.RecentQMConfigFiles.Add(monitorPackPath);
            }
            Properties.Settings.Default.LastMonitorPack = monitorPackPath;
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
                        });
                    }
                    else
                        toolStripStatusLabelStatus.Text = msg;
                }
            }
            catch { }
        }
        private void RemoveCollector(TreeNode parentNode)
        {
            foreach (TreeNode collectorNode in parentNode.Nodes)
            {
                RemoveCollector(collectorNode);
            }
            CollectorEntry ce = (CollectorEntry)parentNode.Tag;
            monitorPack.Collectors.Remove(ce);
        }
        private void ShowCollectorDetails()
        {
            try
            {
                if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
                {
                    CollectorEntry entry = (CollectorEntry)tvwCollectors.SelectedNode.Tag;
                    if (!entry.IsFolder)
                    {
                        if (entry.Collector == null)
                        {
                            //attempt to create it.
                            monitorPack.ApplyCollectorConfig(entry);
                        }
                        entry.ShowDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
        private void ShowCollectorConfig()
        {
            try
            {
                if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
                {
                    CollectorEntry collectorEntry = (CollectorEntry)tvwCollectors.SelectedNode.Tag;
                    QuickMon.Forms.EditCollectorConfig editCollectorEntry = new Forms.EditCollectorConfig();
                    editCollectorEntry.KnownRemoteHosts = (from string krh in Properties.Settings.Default.KnownRemoteHosts
                                                           select krh).ToList();
                    editCollectorEntry.SelectedEntry = collectorEntry;
                    if (editCollectorEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
                    {
                        SetMonitorChanged();
                        tvwCollectors.SelectedNode.Text = editCollectorEntry.SelectedEntry.Name;
                        if (editCollectorEntry.SelectedEntry.EnableRemoteExecute || editCollectorEntry.SelectedEntry.ForceRemoteExcuteOnChildCollectors)
                        {
                            tvwCollectors.SelectedNode.Text += string.Format(" [{0}:{1}]", (editCollectorEntry.SelectedEntry.ForceRemoteExcuteOnChildCollectors ? "!" : "") + editCollectorEntry.SelectedEntry.RemoteAgentHostAddress, editCollectorEntry.SelectedEntry.RemoteAgentHostPort);
                        }

                        //check if parent collector has changed
                        TreeNode currentNode = tvwCollectors.SelectedNode;
                        if (editCollectorEntry.SelectedEntry.ParentCollectorId == null || editCollectorEntry.SelectedEntry.ParentCollectorId == "")
                        {
                            if (currentNode.Parent != tvwCollectors.Nodes[0])
                            {
                                currentNode.Parent.Nodes.Remove(currentNode);
                                tvwCollectors.Nodes[0].Nodes.Add(currentNode);
                            }
                        }
                        else
                        {
                            if (currentNode.Parent == tvwCollectors.Nodes[0])
                            {
                                LoadTreeFromMonitorPack();
                            }
                            else if (((CollectorEntry)currentNode.Parent.Tag).UniqueId != editCollectorEntry.SelectedEntry.ParentCollectorId)
                            {
                                LoadTreeFromMonitorPack();
                            }
                        }

                        if (!editCollectorEntry.SelectedEntry.IsFolder)
                            editCollectorEntry.SelectedEntry.RefreshDetailsIfOpen();

                        DoAutoSave();

                        Properties.Settings.Default.KnownRemoteHosts.AddRange((from string krh in editCollectorEntry.KnownRemoteHosts
                                                                               where !Properties.Settings.Default.KnownRemoteHosts.Contains(krh)
                                                                               select krh).ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowAddCollector(bool folder = false)
        {
            try
            {
                QuickMon.Forms.AgentTypeSelect agentTypeSelect = new QuickMon.Forms.AgentTypeSelect();
                if (folder || agentTypeSelect.ShowCollectorSelection("") == System.Windows.Forms.DialogResult.OK)
                {
                    CollectorEntry newCollectorEntry = new CollectorEntry();
                   
                    if (folder)
                    {
                        newCollectorEntry.IsFolder = true;
                        newCollectorEntry.Collector = null;
                        newCollectorEntry.CollectorRegistrationDisplayName = "Folder";
                        newCollectorEntry.CollectorRegistrationName = "Folder";
                        newCollectorEntry.InitialConfiguration = "";
                    }
                    else
                    {
                        RegisteredAgent ar = agentTypeSelect.SelectedAgent;
                        if (ar.ClassName != "QuickMon.Collectors.Folder")
                        {
                            ICollector c = CollectorEntry.CreateCollectorEntry(ar);
                            newCollectorEntry.Collector = c;
                            newCollectorEntry.InitialConfiguration = c.GetDefaultOrEmptyConfigString();
                        }
                        else
                        {
                            newCollectorEntry.IsFolder = true;
                        }
                        newCollectorEntry.CollectorRegistrationDisplayName = ar.DisplayName;
                        newCollectorEntry.CollectorRegistrationName = ar.Name;
                    }

                    CollectorEntry parentCollectorEntry = null;
                    if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
                    {
                        parentCollectorEntry = (CollectorEntry)tvwCollectors.SelectedNode.Tag;
                        newCollectorEntry.ParentCollectorId = parentCollectorEntry.UniqueId;
                    }


                    QuickMon.Forms.EditCollectorConfig editCollectorEntry = new Forms.EditCollectorConfig();
                    editCollectorEntry.SelectedEntry = newCollectorEntry;
                    editCollectorEntry.KnownRemoteHosts = (from string krh in Properties.Settings.Default.KnownRemoteHosts
                                                          select krh).ToList();
                    editCollectorEntry.LaunchAddEntry = !agentTypeSelect.ImportConfigAfterSelect;
                    editCollectorEntry.ImportConfigAfterSelect = agentTypeSelect.ImportConfigAfterSelect;

                    if (editCollectorEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
                    {
                        SetMonitorChanged();
                        monitorPack.Collectors.Add(editCollectorEntry.SelectedEntry);
                        TreeNode root = tvwCollectors.Nodes[0];
                        if (parentCollectorEntry != null)
                        {
                            root = tvwCollectors.SelectedNode;
                        }
                        LoadCollectorNode(root, editCollectorEntry.SelectedEntry);
                        root.Expand();
                        DoAutoSave();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CheckCollectorContextMenuEnables()
        {
            if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
            {
                CollectorEntry entry = (CollectorEntry)tvwCollectors.SelectedNode.Tag;

                popedContainerForTreeView.cmdViewDetails.Enabled = !entry.IsFolder;
                popedContainerForTreeView.cmdEditCollector.Enabled = true;
                popedContainerForTreeView.cmdDeleteCollector.Enabled = true;
                popedContainerForTreeView.cmdDisableCollector.Enabled = true;
                popedContainerForTreeView.cmdDisableCollector.BackColor = entry.Enabled ? SystemColors.Control : Color.DarkGray;
                popedContainerForTreeView.cmdDisableCollector.Text = entry.Enabled ? "Disable" : "Enable";

                collectorTreeViewDetailsToolStripMenuItem.Enabled = !entry.IsFolder;
                viewCollectorDetailsToolStripMenuItem.Enabled = !entry.IsFolder;
                collectorTreeEditConfigToolStripMenuItem.Enabled = true;
                editCollectorToolStripMenuItem.Enabled = true;
                removeCollectorToolStripMenuItem1.Enabled = true;
                disableCollectorTreeToolStripMenuItem.Enabled = true;
                removeCollectorToolStripMenuItem.Enabled = true;
                disableCollectorTreeToolStripMenuItem.Text = entry.Enabled ? "Disable" : "Enable";

                popedContainerForTreeView.cmdCopy.Enabled = true;
                popedContainerForTreeView.cmdStats.Enabled = !entry.IsFolder;
                collectorStatisticsToolStripMenuItem.Enabled = !entry.IsFolder;
            }
            else
            {
                popedContainerForTreeView.cmdViewDetails.Enabled = false;
                popedContainerForTreeView.cmdEditCollector.Enabled = false;
                popedContainerForTreeView.cmdDeleteCollector.Enabled = false;
                popedContainerForTreeView.cmdDisableCollector.Enabled = false;

                collectorTreeViewDetailsToolStripMenuItem.Enabled = false;
                viewCollectorDetailsToolStripMenuItem.Enabled = false;
                collectorTreeEditConfigToolStripMenuItem.Enabled = false;
                editCollectorToolStripMenuItem.Enabled = false;
                disableCollectorTreeToolStripMenuItem.Enabled = false;
                popedContainerForTreeView.cmdDisableCollector.BackColor = Color.DarkGray;
                removeCollectorToolStripMenuItem.Enabled = false;
                removeCollectorToolStripMenuItem1.Enabled = false;

                popedContainerForTreeView.cmdCopy.Enabled = false;
                popedContainerForTreeView.cmdStats.Enabled = false;
                collectorStatisticsToolStripMenuItem.Enabled = false;
            }
        }
        private void CheckNotifierContextMenuEnables()
        {
            NotifierEntry entry = null;
            if (lvwNotifiers.SelectedItems.Count > 0)
            {
                entry = (NotifierEntry)lvwNotifiers.SelectedItems[0].Tag;
                disableNotifierToolStripMenuItem.Text = entry.Enabled ? "Disable notifier" : "Enable notifier";
                popedContainerForListView.cmdDisableNotifier.Text = entry.Enabled ? "Disable" : "Enable";
            }
            notifierViewerToolStripMenuItem.Enabled = lvwNotifiers.SelectedItems.Count > 0 && lvwNotifiers.SelectedItems[0].ImageIndex > 0;
            notifierConfigurationToolStripMenuItem.Enabled = lvwNotifiers.SelectedItems.Count == 1;
            editNotifierToolStripMenuItem.Enabled = lvwNotifiers.SelectedItems.Count == 1;
            removeNotifierToolStripMenuItem.Enabled = lvwNotifiers.SelectedItems.Count > 0;
            removeNotifierToolStripMenuItem1.Enabled = lvwNotifiers.SelectedItems.Count > 0;
            disableNotifierToolStripMenuItem.Enabled = lvwNotifiers.SelectedItems.Count == 1;

            popedContainerForListView.cmdViewDetails.Enabled = lvwNotifiers.SelectedItems.Count > 0 && lvwNotifiers.SelectedItems[0].ImageIndex > 0;
            popedContainerForListView.cmdEditNotifier.Enabled = lvwNotifiers.SelectedItems.Count == 1;
            popedContainerForListView.cmdDisableNotifier.Enabled = lvwNotifiers.SelectedItems.Count == 1;
            popedContainerForListView.cmdDeleteNotifier.Enabled = lvwNotifiers.SelectedItems.Count > 0;
        }
        private void CopySelectedCollectorAndDependants()
        {
            if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
            {
                CollectorEntry entry = (CollectorEntry)tvwCollectors.SelectedNode.Tag;
                List<CollectorEntry> sourceList = monitorPack.GetAllChildCollectors(entry);
                copiedCollectorList = new List<CollectorEntry>();
                copiedCollectorList.Add(entry.Clone());
                foreach (CollectorEntry en in sourceList)
                {
                    //Copy as is with same IDs
                    copiedCollectorList.Add(en.Clone());
                }

                popedContainerForTreeView.cmdPaste.Enabled = true;
                popedContainerForTreeView.cmdPasteWithEdit.Enabled = true;
            }
        }
        private void PasteSelectedCollectorAndDependant(bool showEditList)
        {
            try
            {
                if (copiedCollectorList != null && copiedCollectorList.Count > 0)
                {
                    if (showEditList)
                    {
                        PasteCollectors pasteCollectors = new PasteCollectors();
                        pasteCollectors.SelectedCollectors = copiedCollectorList;
                        if (pasteCollectors.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            copiedCollectorList = pasteCollectors.SelectedCollectors;
                        }
                        else
                            return;
                    }

                    if (copiedCollectorList != null && copiedCollectorList.Count > 0)
                    {
                        SetMonitorChanged();
                        for (int i = 0; i < copiedCollectorList.Count; i++)
                        {
                            string newId = Guid.NewGuid().ToString();
                            string oldId = copiedCollectorList[i].UniqueId;
                            for (int j = 0; j < copiedCollectorList.Count; j++)
                            {
                                if (i != j && copiedCollectorList[j].ParentCollectorId == oldId)
                                {
                                    copiedCollectorList[j].ParentCollectorId = newId;
                                }
                            }
                            copiedCollectorList[i].UniqueId = newId;
                        }

                        if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
                        {
                            copiedCollectorList[0].ParentCollectorId = ((CollectorEntry)tvwCollectors.SelectedNode.Tag).UniqueId;
                        }
                        else
                            copiedCollectorList[0].ParentCollectorId = "";
                        CollectorEntry rootChild = null;
                        for (int i = 0; i < copiedCollectorList.Count; i++)
                        {
                            CollectorEntry newChild = copiedCollectorList[i].Clone();
                            if (rootChild == null)
                                rootChild = newChild;
                            monitorPack.Collectors.Add(newChild);
                        }
                        TreeNode root = tvwCollectors.Nodes[0];
                        if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
                        {
                            root = tvwCollectors.SelectedNode;
                        }

                        LoadCollectorNode(root, rootChild);
                        root.Expand();
                        DoAutoSave();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetNodesToBeingRefreshed(TreeNode root = null)
        {
            if (root == null)
                root = tvwCollectors.Nodes[0];

            if (root.Tag != null && root.Tag is CollectorEntry)
            {
                CollectorEntry collector = (CollectorEntry)root.Tag;
                if (!collector.IsFolder && collector.Enabled)
                {
                    //root.ForeColor = Color.DarkRed; //13,14,15
                    if (root.ImageIndex == 3)
                    {
                        root.ImageIndex = 13;
                        root.SelectedImageIndex = 13;
                    }
                    else if (root.ImageIndex == 4)
                    {
                        root.ImageIndex = 14;
                        root.SelectedImageIndex = 14;
                    }
                    else if (root.ImageIndex == 5)
                    {
                        root.ImageIndex = 15;
                        root.SelectedImageIndex = 15;
                    }
                }                
            }
            foreach (TreeNode childNode in root.Nodes)
                SetNodesToBeingRefreshed(childNode);
        }
        private void SetMonitorChanged()
        {
            monitorPackChanged = true;
            UpdateAppTitle();
        }
        private bool PerformCleanShutdown(bool abortAllowed = false)
        {
            bool notAborted = true;
            try
            {
                if (monitorPackChanged)
                {
                    if (Properties.Settings.Default.AutosaveChanges || MessageBox.Show("Do you want to save changes to the current monitor pack?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (!SaveAsMonitorPack() && abortAllowed)
                            return false;
                    }
                }

                toolStripStatusLabelStatus.Text = "Shutting down...";
                Application.DoEvents();
                //if (mainRefreshTimer.Enabled)
                //{
                //    Properties.Settings.Default.PollFrequencySec = mainRefreshTimer.Interval / 1000;
                //}
                mainRefreshTimer.Enabled = false;
                CloseAllDetailWindows();
                if (monitorPack.BusyPolling)
                {
                    monitorPack.AbortPolling = true;
                    DateTime abortStart = DateTime.Now;
                    while (monitorPack.BusyPolling && abortStart.AddSeconds(5) > DateTime.Now)
                    {
                        Application.DoEvents();
                    }
                    Cursor.Current = Cursors.WaitCursor;
                    ClosePerformanceCounters();
                }

                if (WindowState == FormWindowState.Normal)
                {
                    Properties.Settings.Default.MainWindowLocation = this.Location;
                    Properties.Settings.Default.MainWindowSize = this.Size;
                }
                Properties.Settings.Default.Save();
            }
            catch { }
            return notAborted;
        }
        #endregion

        #region Monitor pack events
        public void monitorPack_CollectorCurrentStateReported(CollectorEntry collectorEntry)
        {
            this.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        if (collectorEntry != null && collectorEntry.Tag is TreeNode)
                        {
                            System.Diagnostics.Trace.WriteLine("Updating " + collectorEntry.Name);
                            TreeNode currentTreeNode = (TreeNode)collectorEntry.Tag;                            

                            bool nodeChanged = false;
                            Color foreColor = currentTreeNode.ForeColor;
                            int imageIndex = currentTreeNode.ImageIndex;

                            if (collectorEntry.Enabled && currentTreeNode.ForeColor != SystemColors.WindowText)
                            {
                                nodeChanged = true;
                                foreColor = SystemColors.WindowText;                                
                            }
                            else if (!collectorEntry.Enabled && currentTreeNode.ForeColor != Color.Gray)
                            {
                                nodeChanged = true;
                                foreColor = Color.Gray;
                            }

                            if (collectorEntry.IsFolder || collectorEntry.CurrentState.State == CollectorState.Folder)
                            {
                                if (currentTreeNode.ImageIndex != 1)
                                {
                                    nodeChanged = true;
                                    imageIndex = 1;
                                }
                            }
                            else if (!collectorEntry.Enabled || collectorEntry.CurrentState.State == CollectorState.Disabled)
                            {
                                if (currentTreeNode.ImageIndex != 2)
                                {
                                    nodeChanged = true;
                                    imageIndex = 2;
                                }
                            }
                            else if (collectorEntry.CurrentState.State == CollectorState.Error || collectorEntry.CurrentState.State == CollectorState.ConfigurationError)
                            {
                                if (currentTreeNode.ImageIndex != 5)
                                {
                                    nodeChanged = true;
                                    imageIndex = 5;
                                    PCRaiseCollectorErrorState();
                                }
                            }
                            else if (collectorEntry.CurrentState.State == CollectorState.Warning)
                            {
                                if (currentTreeNode.ImageIndex != 4)
                                {
                                    nodeChanged = true;
                                    imageIndex = 4;
                                    PCRaiseCollectorWarningState();
                                }
                            }
                            else if (collectorEntry.CurrentState.State == CollectorState.Good)
                            {
                                if (currentTreeNode.ImageIndex != 3)
                                {
                                    nodeChanged = true;
                                    imageIndex = 3;
                                    PCRaiseCollectorSuccessState();
                                }
                            }
                            else if (currentTreeNode.ImageIndex != 2)
                            {
                                nodeChanged = true;
                                imageIndex = 2;
                            }
                            if (nodeChanged)
                            {
                                if (currentTreeNode.ForeColor != foreColor)
                                    currentTreeNode.ForeColor = foreColor;
                                if (currentTreeNode.ImageIndex != imageIndex)
                                {
                                    currentTreeNode.ImageIndex = imageIndex;
                                    currentTreeNode.SelectedImageIndex = imageIndex;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine("Error " + collectorEntry.Name + "->" + ex.Message);
                    }
                });
        }
        private void monitorPack_CollecterLoading(string collectorName)
        {
            toolStripStatusLabelStatus.Text = collectorName;
            Application.DoEvents();
        }
        private void monitorPack_RaiseNotifierError(NotifierEntry notifier, string errorMessage)
        {
            toolStripStatusLabelStatus.Text = string.Format("Notifier error: {0} - {1}", notifier.Name, errorMessage);
        }
        private void monitorPack_RunCollectorCorrectiveErrorScript(CollectorEntry collectorEntry)
        {
            if (collectorEntry != null && !collectorEntry.CorrectiveScriptDisabled)
                RunCorrectiveScript(collectorEntry.CorrectiveScriptOnErrorPath);
        }
        private void monitorPack_RunCollectorCorrectiveWarningScript(CollectorEntry collectorEntry)
        {
            if (collectorEntry != null && !collectorEntry.CorrectiveScriptDisabled)
                RunCorrectiveScript(collectorEntry.CorrectiveScriptOnWarningPath);
        }
        private void monitorPack_RunRestorationScript(CollectorEntry collectorEntry)
        {
            if (collectorEntry != null && !collectorEntry.CorrectiveScriptDisabled)
                RunCorrectiveScript(collectorEntry.RestorationScriptPath);
        }
        private void RunCorrectiveScript(string scriptPath)
        {
            try
            {
                if (System.IO.File.Exists(scriptPath))
                {
                    if (scriptPath.ToLower().EndsWith(".ps1"))
                    {
                        RunPSScript(scriptPath);
                    }
                    else
                    {
                        Process p = new Process();
                        p.StartInfo = new ProcessStartInfo(scriptPath);
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        p.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabelStatus.Text = "Corrective script error:" + ex.Message;
            }
        }
        private void monitorPack_CollectorCalled(CollectorEntry collectorEntry)
        {
            PCRaiseCollectorsQueried();
        }
        private void monitorPack_CollectorExecutionTimeEvent(CollectorEntry collector, long msTime)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
                        {
                            CollectorEntry tvcollector = (CollectorEntry)tvwCollectors.SelectedNode.Tag;
                            if (tvcollector.UniqueId == collector.UniqueId)
                            {
                                PCSetSelectedCollectorsQueryTime(msTime);
                                return;
                            }
                        }
                        else
                            PCSetSelectedCollectorsQueryTime(0);
                    }
                    );
                }
                else
                {
                    if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
                    {
                        CollectorEntry tvcollector = (CollectorEntry)tvwCollectors.SelectedNode.Tag;
                        if (tvcollector.UniqueId == collector.UniqueId)
                        {
                            PCSetSelectedCollectorsQueryTime(msTime);
                            return;
                        }
                    }
                    else
                        PCSetSelectedCollectorsQueryTime(0);
                }
            }
            catch { }
        }
        #endregion

        #region Collector context menus
        private void showCollectorContextMenuTimer_Tick(object sender, EventArgs e)
        {
            showCollectorContextMenuTimer.Enabled = false;
            poperContainerForTreeView.Show(this, collectorContextMenuLaunchPoint);
        }
        private void HideCollectorContextMenu()
        {
            try
            {
                if (poperContainerForTreeView != null)
                    poperContainerForTreeView.Close();
            }
            catch { }
        }

        private void collectorContextMenuCmdCopy_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            CopySelectedCollectorAndDependants();
        }
        private void collectorContextMenuCmdPaste_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            PasteSelectedCollectorAndDependant(false);
        }  
        private void collectorContextMenuCmdPasteWithEdit_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            PasteSelectedCollectorAndDependant(true);
        }  
        private void collectorTreeViewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            ShowCollectorDetails();
        }
        private void collectorTreeEditConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            ShowCollectorConfig();
        }
        private void disableCollectorTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            try
            {
                if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
                {
                    SetMonitorChanged();
                    CollectorEntry entry = (CollectorEntry)tvwCollectors.SelectedNode.Tag;
                    entry.Enabled = !entry.Enabled;
                    disableCollectorTreeToolStripMenuItem.Text = entry.Enabled ? "Disable collector" : "Enable collector";
                    tvwCollectors.SelectedNode.ForeColor = entry.Enabled ? SystemColors.WindowText : Color.Gray;
                    if (!entry.Enabled)
                    {
                        tvwCollectors.SelectedNode.ImageIndex = 2;
                        tvwCollectors.SelectedNode.SelectedImageIndex = 2;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void addCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            ShowAddCollector();
        }
        private void addCollectorFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            ShowAddCollector(true);
        }
        private void removeCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            TreeNode currentNode = tvwCollectors.SelectedNode;
            if (currentNode.Tag is CollectorEntry)
            {
                if (MessageBox.Show("Are you sure you want to remove this collector agent(and all possible dependants)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    SetMonitorChanged();
                    RemoveCollector(currentNode);
                    RefreshMonitorPack();
                    if(currentNode.Parent != null)
                    {
                        currentNode.Parent.Nodes.Remove(currentNode);
                    }
                    DoAutoSave();
                }
            }
        }
        private void cmdStats_Click(object sender, EventArgs e)
        {
            try
            {
                HideCollectorContextMenu();
                if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
                {
                    CollectorEntry ce = (CollectorEntry)tvwCollectors.SelectedNode.Tag;
                    CollectorStats collectorStats = (from cs in collectorStatsWindows
                                                     where cs.SelectedEntry.UniqueId == ce.UniqueId
                                                     select cs).FirstOrDefault();
                    if (collectorStats != null && !collectorStats.IsStillVisible())
                    {
                        collectorStatsWindows.Remove(collectorStats);
                        collectorStats = null;
                    }
                    if (collectorStats == null)
                    {
                        collectorStats = new CollectorStats();
                        collectorStats.SelectedEntry = ce;
                        collectorStatsWindows.Add(collectorStats);
                        collectorStats.Show();
                    }
                    else
                    {
                        if (collectorStats.WindowState == FormWindowState.Minimized)
                            collectorStats.WindowState = FormWindowState.Normal;
                        collectorStats.Show();
                        collectorStats.TopMost = true;
                        collectorStats.TopMost = false;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
        #endregion

        #region Notifier context menu
        private void showNotifierContextMenuTimer_Tick(object sender, EventArgs e)
        {
            showNotifierContextMenuTimer.Enabled = false;
            poperContainerForListView.Show(this, notifierContextMenuLaunchPoint);
        }
        private void HideNotifierContextMenu()
        {
            try
            {
                if (poperContainerForListView != null)
                    poperContainerForListView.Close();
            }
            catch { }
        }

        private void notifierViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideNotifierContextMenu();
            try
            {
                if (lvwNotifiers.SelectedItems.Count > 0 && lvwNotifiers.SelectedItems[0].Tag is NotifierEntry)
                {
                    NotifierEntry n = (NotifierEntry)lvwNotifiers.SelectedItems[0].Tag;
                    n.ShowViewer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        private void notifierConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideNotifierContextMenu();
            if (lvwNotifiers.SelectedItems.Count > 0 && lvwNotifiers.SelectedItems[0].Tag is NotifierEntry)
            {
                NotifierEntry n = (NotifierEntry)lvwNotifiers.SelectedItems[0].Tag;
                Management.EditNotifierEntry editNotifierEntry = new Management.EditNotifierEntry();
                editNotifierEntry.SelectedEntry = n;
                if (editNotifierEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
                {
                    SetMonitorChanged();
                    lvwNotifiers.SelectedItems[0].Text = n.Name;
                    lvwNotifiers.SelectedItems[0].ForeColor = n.Enabled ? SystemColors.WindowText : Color.Gray;
                    n.CloseViewer();                    
                }
            }
        }
        private void addNotifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideNotifierContextMenu();
            try
            {
                Management.EditNotifierEntry editNotifierEntry = new Management.EditNotifierEntry();
                editNotifierEntry.LaunchAddEntry = true;
                if (editNotifierEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
                {
                    SetMonitorChanged();
                    monitorPack.Notifiers.Add(editNotifierEntry.SelectedEntry);
                    if (monitorPack.Notifiers.Count == 1)
                        monitorPack.DefaultViewerNotifier = editNotifierEntry.SelectedEntry;
                    LoadNotifiersList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void removeNotifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideNotifierContextMenu();
            if (lvwNotifiers.SelectedItems.Count > 0 && MessageBox.Show("Are you sure you want to remove the selected notifiers?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                SetMonitorChanged();
                ListView.SelectedIndexCollection idxes = lvwNotifiers.SelectedIndices;
                foreach (int i in idxes)
                {
                    ListViewItem lvi = lvwNotifiers.Items[i];
                    if (lvi.Tag is NotifierEntry)
                    {
                        NotifierEntry n = (NotifierEntry)lvi.Tag;
                        n.CloseViewer();
                        monitorPack.Notifiers.Remove(n);
                    }
                    lvwNotifiers.Items.RemoveAt(i);
                }
                lblNoNotifiersYet.Visible = monitorPack.Notifiers.Count == 0;
            }
            
        }
        private void disableNotifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideNotifierContextMenu();
            if (lvwNotifiers.SelectedItems.Count == 1)
            {
                NotifierEntry entry = (NotifierEntry)lvwNotifiers.SelectedItems[0].Tag;
                entry.Enabled = !entry.Enabled;
                lvwNotifiers.SelectedItems[0].ForeColor = entry.Enabled ? SystemColors.WindowText : Color.Gray;
                disableNotifierToolStripMenuItem.Text = entry.Enabled ? "Disable notifier" : "Enable notifier";
            }
        }
        #endregion

        #region Timer events
        private void mainRefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshMonitorPack();
        }
        #endregion

        #region Refreshing
        private void RefreshMonitorPack(bool disablePollingOverride = false)
        {
            bool timerEnabled = mainRefreshTimer.Enabled;
            DateTime abortStart = DateTime.Now;
            try
            {
                mainRefreshTimer.Enabled = false; //temporary stops it.
                while (refreshBackgroundWorker.IsBusy && abortStart.AddSeconds(5) > DateTime.Now)
                {
                    Application.DoEvents();
                }
                if (!refreshBackgroundWorker.IsBusy)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    refreshBackgroundWorker.RunWorkerAsync(disablePollingOverride);
                }
            }
            catch { }
            finally
            {
                mainRefreshTimer.Enabled = timerEnabled;
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
                    if (monitorPack.BusyPolling)
                    {
                        monitorPack.AbortPolling = true;
                        DateTime abortStart = DateTime.Now;
                        while (monitorPack.BusyPolling && abortStart.AddSeconds(5) > DateTime.Now)
                        {
                            Application.DoEvents();
                        }
                        Cursor.Current = Cursors.WaitCursor;
                    }

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
                    PCSetCollectorsQueryTime(sw.ElapsedMilliseconds);
                    SetAppIcon(monitorPack.CurrentState);
                    UpdateStatusbar(string.Format("Global state: {0}, Updated: {1}, Duration: {2} sec", globalState, DateTime.Now.ToString("HH:mm:ss"), (sw.ElapsedMilliseconds / 1000.00).ToString("F2")));
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
            }
        }                 
        #endregion

        #region Performance counters
        private void InitializeGlobalPerformanceCounters()
        {
            try
            {
                CounterCreationData[] quickMonCreationData = new CounterCreationData[]
                    {
                        new CounterCreationData("Collector success states/Sec", "Collector successful states per second", PerformanceCounterType.RateOfCountsPerSecond32),
                        new CounterCreationData("Collector warning states/Sec", "Collector warning states per second", PerformanceCounterType.RateOfCountsPerSecond32),
                        new CounterCreationData("Collector error states/Sec", "Collector error states per second", PerformanceCounterType.RateOfCountsPerSecond32),                        
                        new CounterCreationData("Collectors queried/Sec", "Number of Collectors queried per second", PerformanceCounterType.RateOfCountsPerSecond32),
                        new CounterCreationData("Collectors query time", "Collector total query time (ms)", PerformanceCounterType.NumberOfItems32),
                        new CounterCreationData("Selected Collector query time", "Selected Collector query time (ms)", PerformanceCounterType.NumberOfItems32)
                    };

                if (PerformanceCounterCategory.Exists(quickMonPCCategory))
                {
                    PerformanceCounterCategory pcC = new PerformanceCounterCategory(quickMonPCCategory);
                    if (pcC.GetCounters().Count() != quickMonCreationData.Length)
                    {
                        PerformanceCounterCategory.Delete(quickMonPCCategory);
                    }
                }

                if (!PerformanceCounterCategory.Exists(quickMonPCCategory))
                {
                    PerformanceCounterCategory.Create(quickMonPCCategory, "QuickMon", PerformanceCounterCategoryType.SingleInstance, new CounterCreationDataCollection(quickMonCreationData));
                }
                try
                {
                    collectorErrorStatePerSec = InitializePerfCounterInstance(quickMonPCCategory, "Collector error states/Sec");
                    collectorWarningStatePerSec = InitializePerfCounterInstance(quickMonPCCategory, "Collector warning states/Sec");
                    collectorInfoStatePerSec = InitializePerfCounterInstance(quickMonPCCategory, "Collector success states/Sec");
                    collectorsQueriedPerSecond = InitializePerfCounterInstance(quickMonPCCategory, "Collectors queried/Sec");
                    collectorsQueryTime = InitializePerfCounterInstance(quickMonPCCategory, "Collectors query time");
                    selectedCollectorsQueryTime = InitializePerfCounterInstance(quickMonPCCategory, "Selected Collector query time");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error initializing application performance counters\r\n" + ex.Message, "Performance Counters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Requested registry access is not allowed"))
                {
                    if (HenIT.Security.AdminModeTools.IsInAdminMode())
                        MessageBox.Show(string.Format("Could not create performance counters! Please use a user account that has the proper rights.\r\nMore details{0}:", ex.Message), "Performance Counters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else //try launching in admin mode
                    {
                        MessageBox.Show("QuickMon 3 needs to restart in 'Admin' mode to set up its performance counters on this computer.", "Restart in Admin mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Properties.Settings.Default.Save();
                        HenIT.Security.AdminModeTools.RestartInAdminMode();
                    }
                }
                else
                    MessageBox.Show("Error creating application performance counters\r\n" + ex.Message, "Performance Counters", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ClosePerformanceCounters()
        {
            SetCounterValue(collectorsQueryTime, 0, "Collector total query time (ms)");
            SetCounterValue(selectedCollectorsQueryTime, 0, "Selected collector query time (ms)");
        }
        private PerformanceCounter InitializePerfCounterInstance(string categoryName, string counterName)
        {
            PerformanceCounter counter = new PerformanceCounter(categoryName, counterName, false);
            counter.BeginInit();
            counter.RawValue = 0;
            counter.EndInit();
            return counter;
        }
        private void SetCounterValue(PerformanceCounter counter, long value, string description)
        {
            try
            {
                if (counter == null)
                {
                    toolStripStatusLabelStatus.Text = "Performance counter not set up or installed! : " + description;
                }
                else
                {
                    counter.RawValue = value;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabelStatus.Text = string.Format("Increment performance counter error! : {0}\r\n{1}", description, ex.ToString());
            }
        }
        private void IncrementCounter(PerformanceCounter counter, string description)
        {
            try
            {
                if (counter == null)
                {
                    toolStripStatusLabelStatus.Text = "Performance counter not set up or installed! : " + description;
                }
                else
                {
                    counter.Increment();
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabelStatus.Text = string.Format("Increment performance counter error! : {0}\r\n{1}", description, ex.ToString());
            }
        }
        private void PCRaiseCollectorSuccessState()
        {
            IncrementCounter(collectorInfoStatePerSec, "Collector successful states per second");
        }
        private void PCRaiseCollectorWarningState()
        {
            IncrementCounter(collectorWarningStatePerSec, "Collector warning states per second");
        }
        private void PCRaiseCollectorErrorState()
        {
            IncrementCounter(collectorErrorStatePerSec, "Collector error states per second");
        }
        private void PCRaiseCollectorsQueried()
        {
            IncrementCounter(collectorsQueriedPerSecond, "Collectors queried per second");
        }
        private void PCSetCollectorsQueryTime(long time)
        {
            SetCounterValue(collectorsQueryTime, time, "Collector total query time (ms)");
        }
        private void PCSetSelectedCollectorsQueryTime(long time)
        {
            SetCounterValue(selectedCollectorsQueryTime, time, "Selected collector query time (ms)");
        }
        #endregion

        #region PowerShell Runner
        /// <summary>
        /// Run PowerShell script. Cannot use System.Management.Automation as it may not be installed on older systems.
        /// </summary>
        /// <param name="testScript"></param>
        /// <returns></returns>
        private void RunPSScript(string testScript)
        {
            string psExe = System.Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\system32\\WindowsPowerShell\\v1.0\\powershell.exe";
            if (System.IO.File.Exists(psExe))
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(psExe);
                p.StartInfo.Arguments = testScript;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
            }
            else
            {
                throw new Exception("PowerShell not found! It may not be installed on this computer.");
            }
        }
        #endregion

    }
}
