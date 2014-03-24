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

namespace QuickMon
{
    public partial class MainForm : FadeSnapForm
    {
        #region External calls
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        [System.Runtime.InteropServices.DllImport("User32")]
        private static extern int SetForegroundWindow(IntPtr hwnd);
        #endregion

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
        #endregion       

        #region Form events
        private void MainForm_Load(object sender, EventArgs e)
        {
            popedContainerForTreeView.cmdViewDetails.Click += new System.EventHandler(collectorTreeViewDetailsToolStripMenuItem_Click);
            popedContainerForTreeView.cmdAddFolder.Click += new System.EventHandler(addCollectorFolderToolStripMenuItem_Click);
            popedContainerForTreeView.cmdAddCollector.Click += new System.EventHandler(addCollectorToolStripMenuItem_Click);
            popedContainerForTreeView.cmdEditCollector.Click += new System.EventHandler(collectorTreeEditConfigToolStripMenuItem_Click);
            popedContainerForTreeView.cmdDisableCollector.Click += new System.EventHandler(disableCollectorTreeToolStripMenuItem_Click);
            popedContainerForTreeView.cmdDeleteCollector.Click += new System.EventHandler(removeCollectorToolStripMenuItem_Click);
            popedContainerForTreeView.cmdRefresh.Click += new EventHandler(refreshToolStripButton_Click);
            popedContainerForTreeView.cmdNewMonitorPack.Click += new EventHandler(newMonitorPackToolStripMenuItem_Click);
            popedContainerForTreeView.cmdLoadMonitorPack.Click += new EventHandler(openMonitorPackToolStripButton_ButtonClick);
            popedContainerForTreeView.cmdLoadRecentMonitorPack.Click += new EventHandler(recentMonitorPackToolStripMenuItem1_Click);
            popedContainerForTreeView.cmdSaveMonitorPack.Click += new EventHandler(saveAsMonitorPackToolStripMenuItem_ButtonClick);
            popedContainerForTreeView.cmdGeneralSettings.Click += new EventHandler(generalSettingsToolStripSplitButton_ButtonClick);
            popedContainerForTreeView.cmdPollingFrequency.Click += new EventHandler(customPollingFrequencyToolStripMenuItem_Click);
            popedContainerForTreeView.cmdRemoteAgents.Click += new System.EventHandler(this.knownRemoteAgentsToolStripMenuItem_Click);

            popedContainerForListView.cmdViewDetails.Click += new System.EventHandler(notifierViewerToolStripMenuItem_Click);
            popedContainerForListView.cmdAddNotifier.Click += new System.EventHandler(addNotifierToolStripMenuItem_Click);
            popedContainerForListView.cmdEditNotifier.Click += new System.EventHandler(notifierConfigurationToolStripMenuItem_Click);
            popedContainerForListView.cmdDisableNotifier.Click += new System.EventHandler(disableNotifierToolStripMenuItem_Click);
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
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            //mainToolStrip.Left = (this.ClientSize.Width - mainToolStrip.Width) / 2;
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            mainRefreshTimer.Enabled = true;
        }

        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (monitorPackChanged)
                {
                    if (Properties.Settings.Default.AutosaveChanges || MessageBox.Show("Do you want to save changes to the current monitor pack?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    {
                        SaveAsMonitorPack();                      
                    }
                }

                toolStripStatusLabelStatus.Text = "Shutting down...";
                Application.DoEvents();
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
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                RefreshMonitorPack();
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
            RefreshMonitorPack();
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
            HideCollectorContextMenu();
            GeneralSettings generalSettings = new GeneralSettings();
            if (generalSettings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.SnappingEnabled = Properties.Settings.Default.MainFormSnap;
                if (monitorPack != null)
                    monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
            }
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
            mainRefreshTimer.Interval = 60000;
            mainRefreshTimer.Enabled = true;
            toolStripStatusLabelStatus.Text = "Polling set to slow";
        }
        private void pollingNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainRefreshTimer.Enabled = false;
            mainRefreshTimer.Interval = 10000;
            mainRefreshTimer.Enabled = true;
            toolStripStatusLabelStatus.Text = "Polling set to normal";
        }
        private void pollingFastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainRefreshTimer.Enabled = false;
            mainRefreshTimer.Interval = 1000;
            mainRefreshTimer.Enabled = true;
            toolStripStatusLabelStatus.Text = "Polling set to fast";
        }
        private void customPollingFrequencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            SetTimerConfig setTimerConfig = new SetTimerConfig();
            setTimerConfig.FrequencySec = (mainRefreshTimer.Interval / 1000);
            setTimerConfig.TimerEnabled = mainRefreshTimer.Enabled;
            if (setTimerConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mainRefreshTimer.Interval = setTimerConfig.FrequencySec * 1000;
                mainRefreshTimer.Enabled = setTimerConfig.TimerEnabled;
            }
        }
        private void closeAllChildWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (monitorPack != null)
            {
                if (monitorPack.Collectors != null)
                    foreach (CollectorEntry entry in monitorPack.Collectors)
                    {
                        entry.CloseDetails();
                    }
                if (monitorPack.Notifiers != null)
                    foreach (NotifierEntry entry in monitorPack.Notifiers)
                    {
                        entry.CloseViewer();
                    }
            }
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
            EditMonitorPackConfig emc = new EditMonitorPackConfig();
            emc.SelectedMonitorPack = monitorPack;
            if (emc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                monitorPackChanged = true;
                UpdateAppTitle();
                SetMonitorPackNameDescription();
            }
        }
        private void llblNotifierViewToggle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            masterSplitContainer.Panel2Collapsed = !masterSplitContainer.Panel2Collapsed;
            llblNotifierViewToggle.Text = masterSplitContainer.Panel2Collapsed ? "Show Notifiers" : "Hide Notifiers";
        }
        #endregion

        #region Collector TreeView events
        private void tvwCollectors_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
                ShowCollectorConfig();
            else
                ShowCollectorDetails();
        }
        private void tvwCollectors_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (!(e.Node.Tag is CollectorEntry))
            {
                e.Cancel = true;
                
            }
        }
        private void tvwCollectors_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CheckCollectorContextMenuEnables();
        }
        private void tvwCollectors_MouseDown(object sender, MouseEventArgs e)
        {
            tvwCollectors.SelectedNode = tvwCollectors.GetNodeAt(e.X, e.Y);
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
        private void tvwCollectors_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Shift && e.KeyCode == Keys.F10) || e.KeyCode == Keys.Apps)
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

        #region Timer events
        private void mainRefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshMonitorPack();
            //DateTime waitTimeout = DateTime.Now;
            //while (autoRefrshBackgroundWorker.IsBusy && waitTimeout.AddSeconds(5) > DateTime.Now)
            //{
            //    Application.DoEvents();
            //}
            //autoRefrshBackgroundWorker.RunWorkerAsync();
        }
        #endregion

        #region Private methods
        private void RefreshMonitorPack()
        {
            DateTime abortStart = DateTime.Now;
            while (refreshBackgroundWorker.IsBusy &&  abortStart.AddSeconds(5) > DateTime.Now)
            {
                Application.DoEvents();
            }
            if (!refreshBackgroundWorker.IsBusy)
            {
                Cursor.Current = Cursors.WaitCursor;
                refreshBackgroundWorker.RunWorkerAsync();
            }
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
            if (monitorPack != null)
            {
                if (!monitorPack.Enabled)
                    Text += " - [Disabled]";
                if (monitorPack.Name != null && monitorPack.Name.Length > 0)
                    Text += string.Format(" - [{0}]", monitorPack.Name);
                if (monitorPack.MonitorPackPath != null && monitorPack.MonitorPackPath.Length > 0)
                    Text += string.Format(" - {0}", System.IO.Path.GetDirectoryName(monitorPack.MonitorPackPath));
            }
        }
        private void CloseAllDetailWindows()
        {
            foreach (CollectorEntry entry in monitorPack.Collectors)
            {
                entry.CloseDetails();
            }
            foreach (NotifierEntry entry in monitorPack.Notifiers)
            {
                entry.CloseViewer();
            }
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
                }
                else
                {
                    success = SaveAsMonitorPack();
                }
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
            monitorPack.MonitorPackPath = "";
            LoadTreeFromMonitorPack();
            monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
            monitorPack.CollectorCurrentStateReported += monitorPack_CollectorCurrentStateReported;
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
            if (monitorPack == null || monitorPack.Name == null)
            {
                llblMonitorPack.Text = "No or new monitor pack. Please set name.";
            }
            else if (monitorPack.MonitorPackPath == null)
                llblMonitorPack.Text = monitorPack.Name;
            else
            {
                llblMonitorPack.Text = monitorPack.Name.Trim().Length == 0 ? System.IO.Path.GetFileName(monitorPack.MonitorPackPath) : monitorPack.Name;
                if (!monitorPack.Enabled)
                    llblMonitorPack.Text += " (Disabled)";
            }
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
            if (collector.EnableRemoteExecute)
                collectorNode.Text += string.Format(" [{0}:{1}]", collector.RemoteAgentHostAddress, collector.RemoteAgentHostPort);
            foreach (CollectorEntry childCollector in (from c in monitorPack.Collectors
                                                       where c.ParentCollectorId == collector.UniqueId
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
                    editCollectorEntry.SelectedEntry = collectorEntry;
                    if (editCollectorEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
                    {
                        monitorPackChanged = true;
                        tvwCollectors.SelectedNode.Text = editCollectorEntry.SelectedEntry.Name;
                        if (editCollectorEntry.SelectedEntry.EnableRemoteExecute)
                            tvwCollectors.SelectedNode.Text += string.Format(" [{0}:{1}]", editCollectorEntry.SelectedEntry.RemoteAgentHostAddress, editCollectorEntry.SelectedEntry.RemoteAgentHostPort);

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
                    editCollectorEntry.LaunchAddEntry = true;
                    if (editCollectorEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
                    {
                        monitorPackChanged = true;
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
                popedContainerForTreeView.cmdDisableCollector.Text = entry.Enabled ? "Disable" : "Enable";

                collectorTreeViewDetailsToolStripMenuItem.Enabled = !entry.IsFolder;
                viewCollectorDetailsToolStripMenuItem.Enabled = !entry.IsFolder;
                collectorTreeEditConfigToolStripMenuItem.Enabled = true;
                editCollectorToolStripMenuItem.Enabled = true;
                removeCollectorToolStripMenuItem1.Enabled = true;
                disableCollectorTreeToolStripMenuItem.Enabled = true;
                removeCollectorToolStripMenuItem.Enabled = true;
                disableCollectorTreeToolStripMenuItem.Text = entry.Enabled ? "Disable" : "Enable";
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
                removeCollectorToolStripMenuItem.Enabled = false;
                removeCollectorToolStripMenuItem1.Enabled = false;
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
                            if (collectorEntry.Enabled && currentTreeNode.ForeColor != SystemColors.WindowText)
                                currentTreeNode.ForeColor = SystemColors.WindowText;
                            else if (!collectorEntry.Enabled && currentTreeNode.ForeColor != Color.Gray)
                                currentTreeNode.ForeColor = Color.Gray;

                            if (collectorEntry.IsFolder || collectorEntry.CurrentState.State == CollectorState.Folder)
                            {
                                if (currentTreeNode.ImageIndex != 1)
                                {
                                    currentTreeNode.ImageIndex = 1;
                                    currentTreeNode.SelectedImageIndex = 1;
                                }
                            }
                            else if (!collectorEntry.Enabled || collectorEntry.CurrentState.State == CollectorState.Disabled)
                            {
                                if (currentTreeNode.ImageIndex != 2)
                                {
                                    currentTreeNode.ImageIndex = 2;
                                    currentTreeNode.SelectedImageIndex = 2;
                                }
                            }
                            else if (collectorEntry.CurrentState.State == CollectorState.Error || collectorEntry.CurrentState.State == CollectorState.ConfigurationError)
                            {
                                if (currentTreeNode.ImageIndex != 5)
                                {
                                    currentTreeNode.ImageIndex = 5;
                                    currentTreeNode.SelectedImageIndex = 5;
                                    PCRaiseCollectorErrorState();
                                }
                            }
                            else if (collectorEntry.CurrentState.State == CollectorState.Warning)
                            {
                                if (currentTreeNode.ImageIndex != 4)
                                {
                                    currentTreeNode.ImageIndex = 4;
                                    currentTreeNode.SelectedImageIndex = 4;
                                    PCRaiseCollectorWarningState();
                                }
                            }
                            else if (collectorEntry.CurrentState.State == CollectorState.Good)
                            {
                                if (currentTreeNode.ImageIndex != 3)
                                {
                                    currentTreeNode.ImageIndex = 3;
                                    currentTreeNode.SelectedImageIndex = 3;
                                    PCRaiseCollectorSuccessState();
                                }
                            }
                            else if (currentTreeNode.ImageIndex != 2)
                            {
                                currentTreeNode.ImageIndex = 2;
                                currentTreeNode.SelectedImageIndex = 2;
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
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo(scriptPath);
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();
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
                    monitorPackChanged = true;
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
                    monitorPackChanged = true;
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
                    monitorPackChanged = true;
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
                    monitorPackChanged = true;
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
                monitorPackChanged = true;
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

        #region Refreshing
        private void refreshBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
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

                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    Cursor.Current = Cursors.WaitCursor;
                    CollectorState globalState = monitorPack.RefreshStates();
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

        #region Collector tree drag and dropping
        private TreeNode dragNode = null;
        private void tvwCollectors_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", true))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = tvwCollectors.GetNodeAt(pt);
                if (AllowTreeNodeDrop(dragNode, targetNode))
                {
                    TreeNode oldParent = dragNode.Parent;
                    if (targetNode == null)
                    {
                        oldParent.Nodes.Remove(dragNode);
                        tvwCollectors.Nodes[0].Nodes.Add(dragNode);
                    }
                    else if (dragNode != targetNode)
                    {
                        oldParent.Nodes.Remove(dragNode);
                        int index = targetNode.Index;
                        targetNode.Nodes.Insert(index - 1, dragNode);
                    }
                    else if (oldParent.LastNode != dragNode) //append to parent
                    {
                        oldParent.Nodes.Remove(dragNode);
                        oldParent.Nodes.Add(dragNode);
                    }
                    else if (oldParent.Parent == null) // oldParent.Parent.Text == "Monitor Pack Agent Instances")
                    {
                        //do nothing
                    }
                    else //append to parent's parent
                    {
                        oldParent.Nodes.Remove(dragNode);
                        oldParent.Parent.Nodes.Add(dragNode);
                    }
                    tvwCollectors.SelectedNode = dragNode;
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
                    monitorPackChanged = true;
                    DoAutoSave();
                }
            }
            ClearBackground();
        }

        private void tvwCollectors_ItemDrag(object sender, ItemDragEventArgs e)
        {
            dragNode = (TreeNode)e.Item;
            if (dragNode.ImageIndex != rootImgIndex)
                DoDragDrop(e.Item, DragDropEffects.Move);

        }

        private void tvwCollectors_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", true))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = tvwCollectors.GetNodeAt(pt);

                if (targetNode != null)
                {
                    if (targetNode.PrevVisibleNode != null)
                    {
                        if (!targetNode.PrevVisibleNode.Equals(tvwCollectors.Nodes[0]))
                            targetNode.PrevVisibleNode.BackColor = Color.White;
                    }
                    if (targetNode.NextVisibleNode != null)
                    {
                        if (!targetNode.NextVisibleNode.Equals(tvwCollectors.Nodes[0]))
                            targetNode.NextVisibleNode.BackColor = Color.White;
                    }
                    if (!targetNode.Equals(tvwCollectors.Nodes[0]))
                        targetNode.BackColor = Color.Aquamarine;
                }
                else
                    ClearBackground();

                //Select the node currently under the cursor
                if (AllowTreeNodeDrop(dragNode, targetNode))
                {
                    e.Effect = DragDropEffects.Move;
                    return;
                }


            }
            e.Effect = DragDropEffects.None;
        }
        private bool AllowTreeNodeDrop(TreeNode dragItem, TreeNode targetItem)
        { 
            int dragImgIndex = dragItem.ImageIndex;
            if (dragImgIndex == rootImgIndex)
                return false;
            if (targetItem == null) // blank area
                return true;

            int targetImgIndex = targetItem.ImageIndex;
            //is collector
            if (dragImgIndex != rootImgIndex)
            {
                if (targetImgIndex == rootImgIndex)
                    return true;
                else //if (targetImgIndex == folderImgIndex || targetImgIndex == collectorImgIndex)
                {
                    //check that targetItem is not a child of dragItem
                    TreeNode parent = targetItem.Parent;
                    while (parent != null)
                    {
                        if (parent == dragItem)
                            return false;
                        parent = parent.Parent;
                    }
                    return true;
                }
                //else
                //    return false;
            }
            //else if (dragImgIndex == notifierImgIndex)
            //{
            //    if (targetImgIndex == notifierRootImgIndex)
            //        return true;
            //    else
            //        return false;
            //}
            else
                return true;// false;
        }
        private void tvwCollectors_DragLeave(object sender, EventArgs e)
        {
            ClearBackground();
        }
        private void ClearBackground(TreeNodeCollection nodes = null)
        {
            if (nodes == null)
                nodes = tvwCollectors.Nodes;
            foreach (TreeNode node in nodes)
            {
                if (!node.Equals(tvwCollectors.Nodes[0]))
                    node.BackColor = Color.White;
                ClearBackground(node.Nodes);
            }
        }
        #endregion   

        #region Admin Mode utils
        bool IsAdmin()
        {
            string strIdentity;
            try
            {
                AppDomain.CurrentDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
                System.Security.Principal.WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();
                System.Security.Principal.WindowsPrincipal wp = new System.Security.Principal.WindowsPrincipal(wi);
                strIdentity = wp.Identity.Name;

                if (wp.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }
        private void RestartInAdminMode()
        {
            Properties.Settings.Default.Save();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Application.ExecutablePath;
            startInfo.Verb = "runas";
            try
            {
                Process p = Process.Start(startInfo);
                System.Threading.Thread.Sleep(1000);
                ShowWindow(p.MainWindowHandle, 5);
                p.WaitForInputIdle(); //this is the key!!
                System.Threading.Thread.Sleep(500);
                SetForegroundWindow(p.MainWindowHandle);
            }
            catch (System.ComponentModel.Win32Exception) // ex)
            {
                return;
            }

            Application.Exit();
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
                    if (IsAdmin())
                        MessageBox.Show(string.Format("Could not create performance counters! Please use a user account that has the proper rights.\r\nMore details{0}:", ex.Message), "Performance Counters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else //try launching in admin mode
                    {
                        RestartInAdminMode();
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

        #region Testing
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 0)
        //    {
        //        Management.EditCollectorEntry editCollectorEntry = new Management.EditCollectorEntry();
        //        editCollectorEntry.SelectedEntry = monitorPack.Collectors[0];
        //        editCollectorEntry.AllowCollectorChange = false;
        //        if (editCollectorEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
        //        {
        //            if (!editCollectorEntry.SelectedEntry.IsFolder)
        //                editCollectorEntry.SelectedEntry.RefreshDetailsIfOpen();
        //        }
        //    }
        //}
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 0)
        //    {
        //        //lblDetails.Text = monitorPack.Collectors[0].GetCurrentState().State.ToString();
        //    }
        //}
        //private void button4_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 1)
        //    {
        //        Management.EditCollectorEntry editCollectorEntry = new Management.EditCollectorEntry();
        //        editCollectorEntry.SelectedEntry = monitorPack.Collectors[1];
        //        editCollectorEntry.AllowCollectorChange = false;
        //        if (editCollectorEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
        //        {
        //            if (!editCollectorEntry.SelectedEntry.IsFolder)
        //                editCollectorEntry.SelectedEntry.RefreshDetailsIfOpen();
        //        }
        //    }
        //}
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 1)
        //    {
        //        //lblDetails.Text = monitorPack.Collectors[1].GetCurrentState().State.ToString();
        //    }
        //}
        //private void cmdView_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 0)
        //    {
        //        monitorPack.Collectors[0].ShowDetails();
        //    }
        //}
        //private void button5_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 1)
        //    {
        //        monitorPack.Collectors[1].ShowDetails();
        //    }
        //}
        //private void cmdCloseAll_Click(object sender, EventArgs e)
        //{
        //    foreach (CollectorEntry entry in monitorPack.Collectors)
        //    {
        //        entry.CloseDetails();
        //    }
        //    foreach (NotifierEntry entry in monitorPack.Notifiers)
        //    {
        //        entry.CloseViewer();
        //    }
        //}
        //private void button6_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Notifiers.Count > 0)
        //    {
        //        Management.EditNotifierEntry editNotifierEntry = new Management.EditNotifierEntry();
        //        editNotifierEntry.SelectedEntry = monitorPack.Notifiers[0];
        //        if (editNotifierEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
        //        {
        //            monitorPack.Notifiers[0].CloseViewer();
        //           // lblDetails.Text = editNotifierEntry.SelectedEntry.Notifier.AgentConfig.ToConfig();
        //        }
        //    }
        //}
        //private void button7_Click(object sender, EventArgs e)
        //{
        //    Management.EditCollectorEntry editCollectorEntry = new Management.EditCollectorEntry();
        //    editCollectorEntry.AllowCollectorChange = true;
        //    if (editCollectorEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
        //    {
        //        //lblDetails.Text = editCollectorEntry.SelectedEntry.Collector.AgentConfig.ToConfig();
        //    }
        //}
        //private void button8_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show(monitorPack.RefreshStates().ToString());
        //}
        //private void button9_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Notifiers.Count > 0)
        //    {
        //        if (monitorPack.Notifiers[0].Notifier.HasViewer)
        //        {
        //            monitorPack.Notifiers[0].ShowViewer();
        //        }
        //    }
        //}
        //private void button10_Click(object sender, EventArgs e)
        //{
        //    monitorPack.RefreshStates();
        //    SetAppIcon(monitorPack.CurrentState);
        //}
        //private void button11_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 0)
        //    {
        //        monitorPack.Collectors[0].Collector.SetConfigurationFromXmlString("<config><loopback returnState=\"Good\" /></config>");
        //    }
        //}
        //private void button12_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 0)
        //    {
        //        monitorPack.Collectors[0].Collector.SetConfigurationFromXmlString("<config><loopback returnState=\"Warning\" /></config>");
        //    }
        //}
        //private void button13_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 0)
        //    {
        //        monitorPack.Collectors[0].Collector.SetConfigurationFromXmlString("<config><loopback returnState=\"Error\" /></config>");
        //    }
        //}
        //private void button16_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 1)
        //    {
        //        monitorPack.Collectors[1].Collector.SetConfigurationFromXmlString("<config><loopback returnState=\"Good\" /></config>");
        //    }
        //}
        //private void button15_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 1)
        //    {
        //        monitorPack.Collectors[1].Collector.SetConfigurationFromXmlString("<config><loopback returnState=\"Warning\" /></config>");
        //    }
        //}
        //private void button14_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 1)
        //    {
        //        monitorPack.Collectors[1].Collector.SetConfigurationFromXmlString("<config><loopback returnState=\"Error\" /></config>");
        //    }
        //}
        //private void button22_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 2)
        //    {
        //        Management.EditCollectorEntry editCollectorEntry = new Management.EditCollectorEntry();
        //        editCollectorEntry.SelectedEntry = monitorPack.Collectors[2];
        //        editCollectorEntry.AllowCollectorChange = false;
        //        if (editCollectorEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
        //        {
        //            if (!editCollectorEntry.SelectedEntry.IsFolder)
        //                editCollectorEntry.SelectedEntry.RefreshDetailsIfOpen();
        //        }
        //    }
        //}
        //private void button21_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 2)
        //    {
        //        //lblDetails.Text = monitorPack.Collectors[2].GetCurrentState().State.ToString();
        //    }
        //}
        //private void button20_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 2)
        //    {
        //        monitorPack.Collectors[2].ShowDetails();
        //    }
        //}
        //private void button19_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 2)
        //    {
        //        monitorPack.Collectors[2].Collector.SetConfigurationFromXmlString("<config><loopback returnState=\"Good\" /></config>");
        //    }
        //}
        //private void button18_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 2)
        //    {
        //        monitorPack.Collectors[2].Collector.SetConfigurationFromXmlString("<config><loopback returnState=\"Warning\" /></config>");
        //    }
        //}
        //private void button17_Click(object sender, EventArgs e)
        //{
        //    if (monitorPack.Collectors.Count > 2)
        //    {
        //        monitorPack.Collectors[2].Collector.SetConfigurationFromXmlString("<config><loopback returnState=\"Error\" /></config>");
        //    }
        //} 
        //private void button23_Click(object sender, EventArgs e)
        //{
        //    string testConfig = "<monitorPack version=\"3.0\" name=\"Blank\" enabled=\"True\" defaultViewerNotifier=\"\" runCorrectiveScripts=\"False\">" +
        //          "<collectorEntries>" +

        //          "<collectorEntry name=\"Test\"  uniqueID=\"ffd85fc7-0f02-4b22-b390-a0b98d886500\" " +
        //          "enabled=\"True\" isFolder=\"False\" collector=\"LoopbackCollector\" " +
        //          "collectOnParentWarning=\"False\" repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
        //          "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\">" +
        //          "<config><loopback returnState=\"Good\" /></config>" +
        //          "<serviceWindows></serviceWindows>" +
        //          "</collectorEntry>" +

        //          "<collectorEntry name=\"Test 2\"  uniqueID=\"ffd85fc7-0f02-4b22-b390-a0b98d886501\" " +
        //          "enabled=\"True\" isFolder=\"False\" collector=\"LoopbackCollector\" " +
        //          "collectOnParentWarning=\"False\" repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
        //          "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\">" +
        //          "<config><loopback returnState=\"Good\" /></config>" +
        //          "<serviceWindows></serviceWindows>" +
        //          "</collectorEntry>" +

        //          "<collectorEntry name=\"Test 3\"  uniqueID=\"ffd85fc7-0f02-4b22-b390-a0b98d886502\" " +
        //          "enabled=\"True\" isFolder=\"False\" collector=\"LoopbackCollector\" " +
        //          "collectOnParentWarning=\"False\" repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
        //          "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\">" +
        //          "<config><loopback returnState=\"Good\" /></config>" +
        //          "<serviceWindows></serviceWindows>" +
        //          "</collectorEntry>" +

        //          "<collectorEntry name=\"Ping test\"  uniqueID=\"ffd85fc7-0f02-4b22-b390-a0b98d886503\" " +
        //          "enabled=\"True\" isFolder=\"False\" collector=\"PingCollector\" " +
        //          "collectOnParentWarning=\"False\" repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
        //          "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\">" +
        //          "<config><hosts><host hostName=\"rudolfc2d\" description=\"\" maxTime=\"100\" timeOut=\"5000\" />	</hosts></config>" +
        //          "<serviceWindows></serviceWindows>" +
        //          "</collectorEntry>" +

        //          "</collectorEntries>" +
        //          "<notifierEntries>" +
        //          "<notifierEntry name=\"Test\" notifier=\"InMemoryNotifier\" enabled=\"True\" alertLevel=\"Warning\" detailLevel=\"Detail\">" +
        //          "<config>	<inMemory maxEntryCount=\"15\" /></config>" +
        //          "<collectors />" +
        //          "</notifierEntry>" +
        //          "</notifierEntries>" +
        //          "</monitorPack>";
        //    System.IO.File.WriteAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.DoNotVerify), "Hen IT\\QuickMon", "QuickMon3Test.qmconfig"), testConfig);
        //    //System.IO.File.WriteAllText(@"C:\Users\rhenning.SHOPRITE\AppData\Local\Hen IT\QuickMon\QuickMon3Test.qmconfig", testConfig);
        //    monitorPack.LoadXml(testConfig);
        //}
        #endregion
    }
}
