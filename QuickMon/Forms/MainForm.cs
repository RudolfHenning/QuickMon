using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private MonitorStates globalState = MonitorStates.NotAvailable;
        private bool glassIcon = true;
        private MonitorPack monitorPack = new MonitorPack();
        private System.Threading.Mutex updateTreeNode = new System.Threading.Mutex();
        private int folderImgIndex = 5;
        private System.Timers.Timer mainRefreshTimer;
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
            mainRefreshTimer = new System.Timers.Timer();
            mainRefreshTimer.Elapsed += new System.Timers.ElapsedEventHandler(mainRefreshTimer_Elapsed);
            mainRefreshTimer.Interval = Properties.Settings.Default.PollFrequency;
            mainRefreshTimer.Enabled = true;

            if (Properties.Settings.Default.LastMonitorPack != null)
            {
                LoadMonitorPack(Properties.Settings.Default.LastMonitorPack);
            }
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
        private void MainForm_Shown(object sender, EventArgs e)
        {
            backgroundWorkerRefresh.RunWorkerAsync();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(Properties.Settings.Default.LastMonitorPack))
                    monitorPack.Save(Properties.Settings.Default.LastMonitorPack);
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
                LoadMonitorPack(recentMonitorPacks.SelectedPack);
                backgroundWorkerRefresh.RunWorkerAsync();
            }
        }
        private void toolStripButtonConfigPack_Click(object sender, EventArgs e)
        {
            //timerMain.Enabled = false;
            mainRefreshTimer.Enabled = false;
            QuickMon.Management.MonitorPackManagement monitorPackManagement = new Management.MonitorPackManagement();
            if (monitorPackManagement.ShowMonitorPack(monitorPack) == System.Windows.Forms.DialogResult.OK)
            {
                Properties.Settings.Default.LastMonitorPack = monitorPackManagement.MonitorPackPath;
                LoadMonitorPack(Properties.Settings.Default.LastMonitorPack);
                backgroundWorkerRefresh.RunWorkerAsync();
            }
            //timerMain.Enabled = true;
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
            if (!backgroundWorkerRefresh.IsBusy)
            {
                Cursor.Current = Cursors.WaitCursor;
                backgroundWorkerRefresh.RunWorkerAsync();
            }
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
        private void timerMain_Tick(object sender, EventArgs e)
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
                disableCollectorToolStripMenuItem.Enabled = false;
                configureCollectorToolStripMenuItem.Enabled = false;
                configureCollectorToolStripMenuItem1.Enabled = false;
            }            
        }
        private void tvwCollectors_DoubleClick(object sender, EventArgs e)
        {
            showDetailsToolStripMenuItem_Click(sender, e);
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
                CollectorEntry collector = (CollectorEntry)tvwCollectors.SelectedNode.Tag;
                QuickMon.Management.EditCollectorEntry editCollectorEntry = new QuickMon.Management.EditCollectorEntry();
                editCollectorEntry.AllowCollectorChange = false;
                editCollectorEntry.SelectedEntry = collector;
                if (editCollectorEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
                {
                    collector = editCollectorEntry.SelectedEntry;
                    monitorPack.ApplyCollectorConfig(collector);
                    tvwCollectors.SelectedNode.Tag = collector;
                    tvwCollectors.SelectedNode.Text = collector.Name;
                    if (!collector.Enabled)
                    {
                        if (!collector.IsFolder)
                        {
                            tvwCollectors.SelectedNode.ImageIndex = 1;
                            tvwCollectors.SelectedNode.SelectedImageIndex = 1;
                        }
                        tvwCollectors.SelectedNode.ForeColor = Color.Gray;
                    }
                    else
                        tvwCollectors.SelectedNode.ForeColor = SystemColors.WindowText;
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
            }
            else if (currentState == MonitorStates.Warning)
            {
                treeNode.ImageIndex = 3;
                treeNode.SelectedImageIndex = 3;
            }
            else
            {
                treeNode.ImageIndex = 4;
                treeNode.SelectedImageIndex = 4;
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
                        //tvwCollectors.BeginUpdate();
                    }
                    );
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    mainRefreshTimer.Enabled = false; 
                    //tvwCollectors.BeginUpdate();
                }
                if (monitorPack.Enabled)
                {
                    globalState = monitorPack.RefreshStates();
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
                if (Properties.Settings.Default.DisablePollingOnError)
                    monitorPack.Enabled = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //if (this.InvokeRequired)
                //{
                //    this.Invoke((MethodInvoker)delegate()
                //    {
                //        //tvwCollectors.EndUpdate();
                //    }
                //    );
                //}
                //else
                //{
                //    //tvwCollectors.EndUpdate();
                //}
                Cursor.Current = Cursors.Default;
                mainRefreshTimer.Enabled = true; 
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
                globalState = MonitorStates.NotAvailable;
                Properties.Settings.Default.LastMonitorPack = monitorPackPath;
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
            root.Expand();
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
        #endregion                        
        
    }
}
