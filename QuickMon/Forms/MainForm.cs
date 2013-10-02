using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

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
        }

        #region Private vars
        private bool mainTimerEnabled = true;
        private MonitorStates globalState = MonitorStates.NotAvailable;
        private bool glassIcon = true;
        private MonitorPack monitorPack = new MonitorPack();
        private int folderImgIndex = 5;
        private System.Timers.Timer mainRefreshTimer;
        private string quickMonPCCategory = "QuickMon UI Client";

        #region Performance Counter Vars
        private PerformanceCounter collectorErrorStatePerSec = null;
        private PerformanceCounter collectorWarningStatePerSec = null;
        private PerformanceCounter collectorInfoStatePerSec = null;
        private PerformanceCounter collectorsQueriedPerSecond = null;
        private PerformanceCounter collectorsQueryTime = null;
        private PerformanceCounter selectedCollectorsQueryTime = null;
        #endregion
        #endregion

        #region Form events
        private void MainForm_Load(object sender, EventArgs e)
        {
            if ((Properties.Settings.Default.MainWindowLocation.X == 0) && (Properties.Settings.Default.MainWindowLocation.Y == 0))
            {
                this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            }
            else
            {
                this.Location = Properties.Settings.Default.MainWindowLocation;
                this.Size = Properties.Settings.Default.MainWindowSize;
            }
            SnappingEnabled = Properties.Settings.Default.MainFormSnap;
            monitorPack.Enabled = false;
            monitorPack.MonitorPackPathChanged += new MonitorPackPathChangedDelegate(monitorPack_MonitorPackPathChanged);
            mainRefreshTimer = new System.Timers.Timer();
            mainRefreshTimer.Elapsed += new System.Timers.ElapsedEventHandler(mainRefreshTimer_Elapsed);
            mainRefreshTimer.Interval = Properties.Settings.Default.PollFrequency;
            mainRefreshTimer.Enabled = true;
            try
            {
                ToolStripManager.LoadSettings(this, "QuickMon.MainToolbar");
            }
            catch { }
        }
        
        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitializeGlobalPerformanceCounters();
            if (Properties.Settings.Default.LastMonitorPack != null)
            {
                LoadMonitorPack(Properties.Settings.Default.LastMonitorPack);
                System.Threading.Thread.Sleep(100);
            }
            backgroundWorkerRefresh.RunWorkerAsync();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (monitorPack != null )
                {
                    if (monitorPack.BusyPolling) //still busy with previous polling instance
                    {
                        //Attempting to abort it.
                        monitorPack.AbortPolling = true;
                    }
                    if (System.IO.File.Exists(Properties.Settings.Default.LastMonitorPack))
                        monitorPack.Save(Properties.Settings.Default.LastMonitorPack);
                    monitorPack.ClosePerformanceCounters();
                }
                ClosePerformanceCounters();
                ToolStripManager.SaveSettings(this, "QuickMon.MainToolbar");
            }
            catch { }
            if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.MainWindowLocation = this.Location;
                Properties.Settings.Default.MainWindowSize = this.Size;
            }
            Properties.Settings.Default.Save();
        }
        #endregion

        #region Toolbar events
        private void toolStripButtonLoad_Click(object sender, EventArgs e)
        {
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
                    backgroundWorkerRefresh.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Open", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripButtonRecentFiles_Click(object sender, EventArgs e)
        {
            RecentMonitorPacks recentMonitorPacks = new RecentMonitorPacks();
            if (recentMonitorPacks.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CloseAllDetailWindows();
                LoadMonitorPack(recentMonitorPacks.SelectedPack);
                backgroundWorkerRefresh.RunWorkerAsync();
            }
        }
        private void toolStripButtonConfigPack_Click(object sender, EventArgs e)
        {
            mainTimerEnabled = false;
            mainRefreshTimer.Enabled = false;
            QuickMon.Management.MonitorPackManagement monitorPackManagement = new Management.MonitorPackManagement();
            if (monitorPackManagement.ShowMonitorPack(monitorPack) == System.Windows.Forms.DialogResult.OK)
            {
                CloseAllDetailWindows();
                Properties.Settings.Default.LastMonitorPack = monitorPackManagement.MonitorPackPath;
                LoadMonitorPack(Properties.Settings.Default.LastMonitorPack);
                try
                {
                    if (!backgroundWorkerRefresh.IsBusy)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        backgroundWorkerRefresh.RunWorkerAsync();
                    }
                }
                catch { }
            }
            mainTimerEnabled = true;
            mainRefreshTimer.Enabled = true;   
        }
        private void toolStripButtonOptions_Click(object sender, EventArgs e)
        {
            OptionsWindow optionsWindow = new OptionsWindow();
            //timerMain.Enabled = false;
            mainRefreshTimer.Enabled = false; 
            if (optionsWindow.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mainRefreshTimer.Elapsed -= new System.Timers.ElapsedEventHandler(mainRefreshTimer_Elapsed);
                mainRefreshTimer = null;
                Application.DoEvents();
                mainRefreshTimer = new System.Timers.Timer();
                mainRefreshTimer.Elapsed += new System.Timers.ElapsedEventHandler(mainRefreshTimer_Elapsed);
                mainRefreshTimer.Interval = Properties.Settings.Default.PollFrequency;

                monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;

                //try
                //{
                //    this.timerMain.Tick -= new System.EventHandler(this.timerMain_Tick);
                //}
                //catch { }
                //timerMain.Interval = Properties.Settings.Default.PollFrequency;
                //try
                //{
                //    this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
                //}
                //catch { }
            }
            //timerMain.Enabled = true;
            mainRefreshTimer.Enabled = true; 
        }
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorkerRefresh.IsBusy)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    backgroundWorkerRefresh.RunWorkerAsync();
                }
            }
            catch { }
        }
        private void toolStripButtonNotifiers_Click(object sender, EventArgs e)
        {
            if (monitorPack != null && monitorPack.DefaultViewerNotifier != null)
            {
                monitorPack.DefaultViewerNotifier.OpenViewer();
            }
            else
            {
                NotifiersListWindow notifiersListWindow = new NotifiersListWindow();
                notifiersListWindow.SelectedMonitorPack = monitorPack;
                notifiersListWindow.Show();
            }
        }
        private void infoToolStripButton_Click(object sender, EventArgs e)
        {
            AboutQuickMon aboutQuickMon = new AboutQuickMon();
            aboutQuickMon.ShowDialog();
        }
        #endregion

        #region Timer events
        private void mainRefreshTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                RefreshMonitorPack();
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.DisablePollingOnError)
                    monitorPack.Enabled = false;
                toolStripStatusLabelStatus.Text = ex.Message;
                toolStripStatusLabelStatus.ToolTipText = ex.Message;
            }
            SetEnableDisablePolling();
        }
        //private void timerMain_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        RefreshMonitorPack();
        //    }
        //    catch (Exception ex)
        //    {
        //        if (Properties.Settings.Default.DisablePollingOnError)
        //            monitorPack.Enabled = false;
        //        toolStripStatusLabelStatus.Text = ex.Message;
        //        toolStripStatusLabelStatus.ToolTipText = ex.Message;
        //    }
        //    SetEnableDisablePolling();
        //}
        private void timerAppIconRefresher_Tick(object sender, EventArgs e)
        {
            UpdateAppIcon();
        }
        #endregion

        #region Tree view events
        private void tvwCollectors_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.ImageIndex > 0)
            {
                showDetailsToolStripMenuItem.Enabled = tvwCollectors.SelectedNode.ImageIndex != folderImgIndex;
                showCollectorDetailsToolStripMenuItem.Enabled = tvwCollectors.SelectedNode.ImageIndex != folderImgIndex;
                configureCollectorToolStripMenuItem.Enabled = true;
                configureCollectorToolStripMenuItem1.Enabled = true;
                if (tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
                {
                    CollectorEntry collector = (CollectorEntry)tvwCollectors.SelectedNode.Tag;
                    disableCollectorToolStripMenuItem.Enabled = true;
                    if (collector.Enabled)
                        disableCollectorToolStripMenuItem.Text = "Disable collector";
                    else
                        disableCollectorToolStripMenuItem.Text = "Enable collector";
                }
            }
            else
            {
                showDetailsToolStripMenuItem.Enabled = false;
                showCollectorDetailsToolStripMenuItem.Enabled = false;
                disableCollectorToolStripMenuItem.Enabled = false;
                configureCollectorToolStripMenuItem.Enabled = false;
                configureCollectorToolStripMenuItem1.Enabled = false;
            }            
        }
        private void tvwCollectors_DoubleClick(object sender, EventArgs e)
        {
            showCollectorDetailsToolStripMenuItem_Click(sender, e);
        }
        private void tvwCollectors_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Parent == null)
                e.Cancel = true;
        }
        #endregion

        #region Context menu events
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.ImageIndex != folderImgIndex && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
            {
                try
                {
                    CollectorEntry collector = (CollectorEntry)tvwCollectors.SelectedNode.Tag;
                    collector.ShowStatusDetails();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void showCollectorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.ImageIndex != folderImgIndex && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
                {
                    CollectorEntry collectorEntry = (CollectorEntry)tvwCollectors.SelectedNode.Tag;
                    collectorEntry.ShowDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void disableCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
            {
                CollectorEntry collector = (CollectorEntry)tvwCollectors.SelectedNode.Tag;
                if (disableCollectorToolStripMenuItem.Text == "Disable collector")
                {
                    collector.Enabled = false;
                    if (!collector.IsFolder)
                    {
                        tvwCollectors.SelectedNode.ImageIndex = 1;
                        tvwCollectors.SelectedNode.SelectedImageIndex = 1;
                    }
                    tvwCollectors.SelectedNode.ForeColor = Color.Gray;
                }
                else
                {
                    collector.Enabled = true;
                    tvwCollectors.SelectedNode.ForeColor = SystemColors.WindowText;
                }
            }            
        }
        private void configureCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorEntry)
            {
                CollectorEntry collectorEntry = (CollectorEntry)tvwCollectors.SelectedNode.Tag;
                QuickMon.Management.EditCollectorEntry editCollectorEntry = new QuickMon.Management.EditCollectorEntry();
                editCollectorEntry.AllowCollectorChange = false;
                editCollectorEntry.SelectedEntry = collectorEntry;
                if (editCollectorEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
                {
                    collectorEntry = editCollectorEntry.SelectedEntry;
                    monitorPack.ApplyCollectorConfig(collectorEntry);
                    tvwCollectors.SelectedNode.Tag = collectorEntry;
                    tvwCollectors.SelectedNode.Text = collectorEntry.Name;
                    if (!collectorEntry.Enabled)
                    {
                        if (!collectorEntry.IsFolder)
                        {
                            tvwCollectors.SelectedNode.ImageIndex = 1;
                            tvwCollectors.SelectedNode.SelectedImageIndex = 1;
                        }
                        tvwCollectors.SelectedNode.ForeColor = Color.Gray;
                    }
                    else
                    {
                        tvwCollectors.SelectedNode.ForeColor = SystemColors.WindowText;
                        if (!collectorEntry.IsFolder)
                            collectorEntry.RefreshDetailsIfOpen();
                    }
                }
            }
        }
        private void disablePollingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            monitorPack.Enabled = !monitorPack.Enabled;
            SetEnableDisablePolling();
            UpdateAppTitle();            
            if (!monitorPack.Enabled)
                globalState = MonitorStates.Disabled;
            UpdateAppIcon();
        }
        private void notifiersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotifiersListWindow notifiersListWindow = new NotifiersListWindow();
            notifiersListWindow.SelectedMonitorPack = monitorPack;
            notifiersListWindow.Show();
        }
        private void defaultNotifierViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (monitorPack != null && monitorPack.DefaultViewerNotifier != null)
            {
                monitorPack.DefaultViewerNotifier.OpenViewer();
            }
        }
        #endregion

        #region monitorPack events
        private void UpdateTreeNodeStates(CollectorEntry collector, MonitorStates currentState)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //tvwCollectors.BeginUpdate();
                if (collector.Tag != null && collector.Tag is TreeNode)
                {
                    SetTreeNodeState((TreeNode)collector.Tag, collector, currentState);
                }
                else //scan for the node (old way)
                {
                    UpdateCollectorNode(tvwCollectors.Nodes[0], collector, currentState);
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabelStatus.Text = ex.Message;
            }
            finally
            {
                //tvwCollectors.EndUpdate();
            }
        }
        private void monitorPack_RaiseCurrentState(CollectorEntry collector, MonitorStates currentState)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateTreeNodeStates(collector, currentState);
                });
            }
            else
                UpdateTreeNodeStates(collector, currentState);

        }
        private void ShowNotifierError(NotifierEntry notifier, string errorMessage)
        {
            if (MessageBox.Show(string.Format("There was a problem recording an alert with notifier {0}\r\nDo you want to disable it?\r\n{1}", notifier.Name, errorMessage), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
            {
                notifier.Enabled = false;
            }
        }
        private void monitorPack_RaiseNotifierError(NotifierEntry notifier, string errorMessage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    ShowNotifierError(notifier, errorMessage);
                });
            }
            else
                ShowNotifierError(notifier, errorMessage);
        }
        private void monitorPack_MonitorPackPathChanged(string newMonitorPackPath)
        {
            Properties.Settings.Default.LastMonitorPack = newMonitorPackPath;
        }
        private void monitorPack_CollectorCalled(CollectorEntry collector)
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
        private void SetTreeNodeState(TreeNode treeNode, CollectorEntry collector, MonitorStates currentState)
        {
            if (currentState == MonitorStates.Disabled || currentState == MonitorStates.NotAvailable)
            {
                treeNode.ImageIndex = 1;
                treeNode.SelectedImageIndex = 1;
            }
            else if (currentState == MonitorStates.Good)
            {
                treeNode.ImageIndex = 2;
                treeNode.SelectedImageIndex = 2;
                PCRaiseCollectorSuccessState();
            }
            else if (currentState == MonitorStates.Warning)
            {
                treeNode.ImageIndex = 3;
                treeNode.SelectedImageIndex = 3;
                PCRaiseCollectorWarningState();
            }
            else
            {
                treeNode.ImageIndex = 4;
                treeNode.SelectedImageIndex = 4;
                PCRaiseCollectorErrorState();
            }
            if (collector.Enabled)
                treeNode.ForeColor = SystemColors.WindowText;
            else
                treeNode.ForeColor = Color.Gray;
        }
        private bool UpdateCollectorNode(TreeNode treeNode, CollectorEntry collector, MonitorStates currentState)
        {
            foreach (TreeNode childNode in treeNode.Nodes)
            {
                if (childNode.Text == collector.Name)
                {
                    SetTreeNodeState(childNode, collector, currentState);
                    return true;
                }
                if (UpdateCollectorNode(childNode, collector, currentState))
                    return true;
            }
            return false;
        }
        private void monitorPack_RunCollectorCorrectiveWarningScript(CollectorEntry collector)
        {
            try
            {
                if (collector != null && 
                    System.IO.File.Exists(collector.CorrectiveScriptOnWarningPath))
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo(collector.CorrectiveScriptOnWarningPath);
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabelStatus.Text = "Corrective script error:" + ex.Message;
            }
        }
        private void monitorPack_RunCollectorCorrectiveErrorScript(CollectorEntry collector)
        {
            try
            {
                if (collector != null && 
                    System.IO.File.Exists(collector.CorrectiveScriptOnErrorPath))
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo(collector.CorrectiveScriptOnErrorPath);
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabelStatus.Text = "Corrective script error:" + ex.Message;
            }
        }
        #endregion

        #region Refreshing list
        private void backgroundWorkerRefresh_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                RefreshMonitorPack();
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.DisablePollingOnError)
                    monitorPack.Enabled = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshMonitorPack()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        mainRefreshTimer.Enabled = false; 
                    }
                    );
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    mainRefreshTimer.Enabled = false; 
                }
            }
            catch { }
            try
            {
                
                if (monitorPack.Enabled)
                {
                    if (monitorPack.BusyPolling) //still busy with previous polling instance
                    {
                        //Attempting to abort it.
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
                    globalState = monitorPack.RefreshStates();
                    sw.Stop();
                    PCSetCollectorsQueryTime(sw.ElapsedMilliseconds);
                }
                else
                    globalState = MonitorStates.Disabled;

                UpdateAppIcon();
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        lastUpdateToolStripStatusLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    );
                }
                else
                {
                    lastUpdateToolStripStatusLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("Collection was modified; enumeration operation may not execute."))
                {
                    if (Properties.Settings.Default.DisablePollingOnError)
                        monitorPack.Enabled = false;
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                mainRefreshTimer.Enabled = mainTimerEnabled; 
            }
        }
        #endregion

        #region Private methods
        private void LoadMonitorPack(string monitorPackPath)
        {
            if (System.IO.File.Exists(monitorPackPath))
            {
                mainRefreshTimer.Enabled = false;
                try
                {
                    monitorPack.RaiseCurrentState -= new RaiseCurrentStateDelegate(monitorPack_RaiseCurrentState);
                    monitorPack.RaiseNotifierError -= new RaiseNotifierErrorDelegare(monitorPack_RaiseNotifierError);
                    monitorPack.CollectorCalled -= new RaiseCollectorCalledDelegate(monitorPack_CollectorCalled);
                    monitorPack.CollectorExecutionTimeEvent -= new CollectorExecutionTimeDelegate(monitorPack_CollectorExecutionTimeEvent);
                    monitorPack.ClosePerformanceCounters();
                    monitorPack = null;
                }
                catch { }
                TreeNode root = tvwCollectors.Nodes[0];
                root.Nodes.Clear();
                monitorPack = new MonitorPack();
                monitorPack.Load(monitorPackPath);
                monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
                if (monitorPack.AgentLoadingErrors != null && monitorPack.AgentLoadingErrors.Length > 0)
                {
                    MessageBox.Show(monitorPack.AgentLoadingErrors, "Loading errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SetEnableDisablePolling();

                List<CollectorEntry> noDependantCollectors = (from c in monitorPack.Collectors
                                                              where c.ParentCollectorId.Length == 0
                                                              select c).ToList();
                foreach (CollectorEntry collector in noDependantCollectors)
                {
                    LoadCollectorNode(root, collector);
                }
                root.Expand();

                monitorPack.RaiseCurrentState += new RaiseCurrentStateDelegate(monitorPack_RaiseCurrentState);
                monitorPack.RaiseNotifierError += new RaiseNotifierErrorDelegare(monitorPack_RaiseNotifierError);
                monitorPack.CollectorCalled += new RaiseCollectorCalledDelegate(monitorPack_CollectorCalled);
                monitorPack.CollectorExecutionTimeEvent += new CollectorExecutionTimeDelegate(monitorPack_CollectorExecutionTimeEvent);
                monitorPack.RunCollectorCorrectiveWarningScript += new RaiseCollectorCalledDelegate(monitorPack_RunCollectorCorrectiveWarningScript);
                monitorPack.RunCollectorCorrectiveErrorScript += new RaiseCollectorCalledDelegate(monitorPack_RunCollectorCorrectiveErrorScript);
                monitorPack.MonitorPackPathChanged += new MonitorPackPathChangedDelegate(monitorPack_MonitorPackPathChanged);
                globalState = MonitorStates.NotAvailable;
                
                UpdateAppTitle();
                try
                {
                    defaultNotifierViewerToolStripMenuItem.Enabled = false;
                    if (monitorPack != null)
                    {
                        toolStripStatusLabelStatus.Text = string.Format("{0} collectors, {1} notifiers",
                             monitorPack.Collectors.Count,
                             monitorPack.Notifiers.Count);
                        defaultNotifierViewerToolStripMenuItem.Enabled = monitorPack.DefaultViewerNotifier != null;
                    }
                }
                catch { }
                tvwCollectors.SelectedNode = root;
                root.EnsureVisible();
                AddMonitorPackFileToRecentList(monitorPackPath);
                mainRefreshTimer.Enabled = true; 
            }
        }
        private void AddMonitorPackFileToRecentList(string monitorPackPath)
        {
            if ((from string f in Properties.Settings.Default.RecentQMConfigFiles
                 where f.ToUpper() == monitorPackPath.ToUpper()
                 select f).Count() == 0)
            {
                Properties.Settings.Default.RecentQMConfigFiles.Add(monitorPackPath);
            }
        }
        private void LoadCollectorNode(TreeNode root, CollectorEntry collector)
        {
            TreeNode collectorNode;
            if (collector.IsFolder)
                collectorNode = new TreeNode(collector.Name, 5, 5);
            else
                collectorNode = new TreeNode(collector.Name, 1, 1);
            collectorNode.Tag = collector;
            collector.Tag = collectorNode;
            collectorNode.ForeColor = collector.Enabled ? SystemColors.WindowText : Color.Gray;
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
        private void UpdateAppIcon()
        {
            try
            {
                Icon icon;
                if (globalState == MonitorStates.NotAvailable || globalState == MonitorStates.Disabled)
                {
                    if (glassIcon)
                        icon = Properties.Resources.QMon_Blue;// .bullet_ball_blue;
                    else
                        icon = Properties.Resources.QMon_Blue2;//.bullet_ball_glass_blue;
                }
                else if (globalState == MonitorStates.Good)
                {
                    if (glassIcon)
                        icon = Properties.Resources.QMon_Green;//.bullet_ball_green;
                    else
                        icon = Properties.Resources.QMon_Green2;//.bullet_ball_glass_green;
                }
                else if (globalState == MonitorStates.Warning)
                {
                    if (glassIcon)
                        icon = Properties.Resources.QMon_Yellow;//.bullet_ball_yellow;
                    else
                        icon = Properties.Resources.QMon_Yellow2;//.bullet_ball_glass_yellow;
                }
                else
                {
                    if (glassIcon)
                        icon = Properties.Resources.QMon_Red;//.bullet_ball_red;
                    else
                        icon = Properties.Resources.QMon_Red2;//.bullet_ball_glass_red;
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
                glassIcon = !glassIcon;
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.DisablePollingOnError)
                    monitorPack.Enabled = false;
                toolStripStatusLabelStatus.Text = ex.Message;
                toolStripStatusLabelStatus.ToolTipText = ex.Message;
            }
        } 
        private void SetEnableDisablePolling()
        {
            disablePollingToolStripMenuItem.Text = monitorPack.Enabled ? "Disable polling" : "Enable polling";
        }
        private void UpdateAppTitle()
        {
            Text = "Quick Monitor 2";
            if (monitorPack != null)
            {
                if (!monitorPack.Enabled)
                    Text += " - [Disabled]";
                if (monitorPack.Name.Length > 0 && Properties.Settings.Default.LastMonitorPack != null)
                    Text += string.Format(" - [{0}] - {1}", monitorPack.Name, System.IO.Path.GetDirectoryName(Properties.Settings.Default.LastMonitorPack));
                else if (Properties.Settings.Default.LastMonitorPack != null)
                    Text += string.Format(" - [{0}] - {1}", System.IO.Path.GetFileNameWithoutExtension(Properties.Settings.Default.LastMonitorPack), System.IO.Path.GetDirectoryName(Properties.Settings.Default.LastMonitorPack));
            }
        }
        private void CloseAllDetailWindows(TreeNode parent = null)
        {
            if (parent == null)
            {
                CloseAllDetailWindows(tvwCollectors.Nodes[0]);
            }
            else
            {
                foreach (TreeNode child in parent.Nodes)
                {
                    if (child.Tag is CollectorEntry)
                    {
                        CollectorEntry childCollector = (CollectorEntry)child.Tag;
                        childCollector.CloseDetails();
                    }
                    CloseAllDetailWindows(child);
                }
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
            SetCounterValue(selectedCollectorsQueryTime, 0,"Selected collector query time (ms)");
        }
        private PerformanceCounter InitializePerfCounterInstance(string categoryName, string counterName)
        {
            PerformanceCounter counter = new PerformanceCounter(categoryName, counterName, false);
            counter.BeginInit();
            counter.RawValue = 0;
            counter.EndInit();
            return counter;
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


    }
}
