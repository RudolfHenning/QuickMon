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
        public MainForm()
        {
            InitializeComponent();
        }

        #region Private vars
        private bool monitorPackChanged = false;
        private bool firstRefresh = true;
        private bool timerWasEnabledBeforePausing = false;
        private MonitorPack monitorPack;
        private string quickMonPCCategory = "QuickMon 4 UI Client";
        #region Performance Counter Vars
        private PerformanceCounter collectorErrorStatePerSec = null;
        private PerformanceCounter collectorWarningStatePerSec = null;
        private PerformanceCounter collectorInfoStatePerSec = null;
        private PerformanceCounter collectorsQueriedPerSecond = null;
        private PerformanceCounter collectorsQueryTime = null;
        private PerformanceCounter selectedCollectorsQueryTime = null;
        #endregion

        private Point collectorContextMenuLaunchPoint = new Point();
        private Point notifierContextMenuLaunchPoint = new Point();
        private QuickMon.Controls.CollectorContextMenuControl popepdContainerForTreeView;
        private QuickMon.Controls.PopperContainer popperContainerForTreeView;
        //private QuickMon.Controls.NotifierContextMenuControl popedContainerForListView;
        private QuickMon.Controls.PopperContainer poperContainerForListView;
        #endregion

        #region Form events
        private void MainForm_Load(object sender, EventArgs e)
        {
            cboRecentMonitorPacks.Visible = false;
            cmdRecentMonitorPacks.Visible = false;
            lblNoNotifiersYet.Dock = DockStyle.Fill;
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
            adminModeToolStripStatusLabel.Visible = Security.IsInAdminMode();
            restartInAdminModeToolStripMenuItem.Visible = !Security.IsInAdminMode();
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
                    monitorPack = null;
                    NewMonitorPack();                    
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
        private void MainForm_Resize(object sender, EventArgs e)
        {
            try
            {
                cboRecentMonitorPacks.DropDownWidth = this.ClientSize.Width - cboRecentMonitorPacks.Left - recentMonitorPacksPanel.Left;
                resizeRecentDropDownListWidthTimer.Enabled = false;
                resizeRecentDropDownListWidthTimer.Enabled = true;
            }
            catch { }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PerformCleanShutdown();
        }
        #endregion

        #region Collector TreeView events
        private void tvwCollectors_TreeNodeMoved(TreeNode dragNode)
        {
            if (dragNode != null)
            {
                //set Collector Parent if needed
                if (dragNode.Tag is CollectorHost)
                {
                    if (dragNode.Parent.Tag is CollectorHost)
                    {
                        ((CollectorHost)dragNode.Tag).ParentCollectorId = ((CollectorHost)dragNode.Parent.Tag).UniqueId;
                    }
                    else
                        ((CollectorHost)dragNode.Tag).ParentCollectorId = "";
                }
                SetMonitorChanged();
                DoAutoSave();
            }
        }
        private void tvwCollectors_EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                editCollectorToolStripMenuItem_Click(null, null);
            }
            else
            {
                //collectorTreeViewDetailsToolStripMenuItem_Click(null, null);
            }
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
        private void tvwCollectors_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CheckCollectorContextMenuEnables();            
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

        #region Recent monitor packs drop down and toolbar effects
        private void HideRecentDropDownList(object sender, EventArgs e)
        {
            recentMonitorPacksHideTimer.Enabled = false;
            recentMonitorPacksHideTimer.Enabled = true;
            recentMonitorPacksShowTimer.Enabled = false;
        }
        private void mainToolStrip_MouseLeave(object sender, EventArgs e)
        {
            mainToolbarShrinkTimer.Enabled = false;
            mainToolbarShrinkTimer.Enabled = true;
        }
        private void mainToolStrip_MouseEnter(object sender, EventArgs e)
        {
            mainToolbarShrinkTimer.Enabled = false;
            mainToolStrip.BackColor = Color.FromArgb(64, Color.White);
            HideRecentDropDownList(sender, e);
        }
        private void recentMonitorPacksPanel_MouseEnter(object sender, EventArgs e)
        {
            recentMonitorPacksHideTimer.Enabled = false;
            recentMonitorPacksShowTimer.Enabled = true;
        }
        //private void lblMonitorPackPath_MouseEnter(object sender, EventArgs e)
        //{
        //    recentMonitorPacksHideTimer.Enabled = false;
        //    recentMonitorPacksShowTimer.Enabled = true;
        //}
        private void cboRecentMonitorPacks_MouseHover(object sender, EventArgs e)
        {
            recentMonitorPacksHideTimer.Enabled = false;
        }
        private void cboRecentMonitorPacks_MouseLeave(object sender, EventArgs e)
        {
            HideRecentDropDownList(sender, e);
        }
        private void cboRecentMonitorPacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRecentMonitorPacks.SelectedIndex > 0 && cboRecentMonitorPacks.SelectedItem is QuickMon.Controls.ComboItem)
            {
                CloseAllDetailWindows();
                LoadMonitorPack(((QuickMon.Controls.ComboItem)cboRecentMonitorPacks.SelectedItem).Value.ToString());
                RefreshMonitorPack(true, true);
            }
            HideRecentDropDownList(sender, e);
        }
        private void tvwCollectors_MouseMove(object sender, MouseEventArgs e)
        {
            HideRecentDropDownList(sender, e);
        }
        private void llblMonitorPack_MouseEnter(object sender, EventArgs e)
        {
            HideRecentDropDownList(sender, e);
        }
        private void resizeRecentDropDownListWidthTimer_Tick(object sender, EventArgs e)
        {
            resizeRecentDropDownListWidthTimer.Enabled = false;
            //LoadRecentMonitorPackList();
        }
        private void recentMonitorPacksShowTimer_Tick(object sender, EventArgs e)
        {
            recentMonitorPacksShowTimer.Enabled = false;
            cboRecentMonitorPacks.Visible = true;
            cmdRecentMonitorPacks.Visible = true;
        }
        private void recentMonitorPacksVisibleTimer_Tick(object sender, EventArgs e)
        {
            recentMonitorPacksHideTimer.Enabled = false;
            System.Threading.Thread.Sleep(100);
            cboRecentMonitorPacks.Visible = false;
            cmdRecentMonitorPacks.Visible = false;
        }
        private void mainToolbarShrinkTimer_Tick(object sender, EventArgs e)
        {
            mainToolbarShrinkTimer.Enabled = false;
            mainToolStrip.BackColor = Color.Transparent;
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

            mainRefreshTimer.Enabled = false;
            try
            {
                monitorPack.CollectorHostStateUpdated -= monitorPack_CollectorHostStateUpdated;
                monitorPack.ClosePerformanceCounters();
                monitorPack = null;
            }
            catch { }
            monitorPack = new MonitorPack();
            monitorPack.LoadXml(Properties.Resources.BlankMonitorPack);
            monitorPack.MonitorPackPath = "";
            LoadControlsFromMonitorPack();
            monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
            monitorPack.CollectorHostStateUpdated += monitorPack_CollectorHostStateUpdated;
            monitorPack.OnNotifierError += monitorPack_OnNotifierError;
            monitorPack.RunCollectorHostCorrectiveWarningScript += monitorPack_RunCollectorHostCorrectiveWarningScript;
            monitorPack.RunCollectorHostCorrectiveErrorScript += monitorPack_RunCollectorHostCorrectiveErrorScript;
            monitorPack.RunCollectorHostRestorationScript += monitorPack_RunCollectorHostRestorationScript;
            monitorPack.CollectorHostCalled += monitorPack_CollectorHostCalled;
            monitorPack.CollectorHostAllAgentsExecutionTime += monitorPack_CollectorHostAllAgentsExecutionTime;
            if (monitorPack.NotifierHosts != null && monitorPack.NotifierHosts.Count == 0)
                lblNoNotifiersYet.Visible = true;
            else
                lblNoNotifiersYet.Visible = false;
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
                        if (!SaveMonitorPack())
                        {
                            return;
                        }
                    }
                }
                PausePolling(true);
                if (monitorPack != null)
                {
                    try
                    {
                        WaitForPollingToFinish(5);
                        monitorPack.ClosePerformanceCounters();
                    }
                    catch { }
                    finally
                    {
                        monitorPack = null;
                    }
                }
                monitorPack = new MonitorPack();
                //monitorPack.CollecterLoading += monitorPack_CollecterLoading;

                monitorPack.Load(monitorPackPath);
                LoadControlsFromMonitorPack();
                monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
                monitorPack.CollectorHostStateUpdated += monitorPack_CollectorHostStateUpdated;
                monitorPack.OnNotifierError += monitorPack_OnNotifierError;
                monitorPack.RunCollectorHostCorrectiveWarningScript += monitorPack_RunCollectorHostCorrectiveWarningScript;
                monitorPack.RunCollectorHostCorrectiveErrorScript += monitorPack_RunCollectorHostCorrectiveErrorScript;
                monitorPack.RunCollectorHostRestorationScript += monitorPack_RunCollectorHostRestorationScript;
                monitorPack.CollectorHostCalled += monitorPack_CollectorHostCalled;
                monitorPack.CollectorHostAllAgentsExecutionTime += monitorPack_CollectorHostAllAgentsExecutionTime;
                monitorPack.RunningAttended = AttendedOption.OnlyAttended;

                AddMonitorPackFileToRecentList(monitorPackPath);
                
                ResumePolling();
                monitorPackChanged = false;
            }
        }
        private void LoadControlsFromMonitorPack()
        {
            firstRefresh = true;
            SetMonitorPackNameDescription();
            TreeNode root = tvwCollectors.Nodes[0];
            root.Nodes.Clear();
            root.Text = "COLLECTORS - Loading...";
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;

            #region Load Collectors
            if (monitorPack != null)
            {
                List<CollectorHost> noDependantCollectors = (from c in monitorPack.CollectorHosts
                                                             where c.ParentCollectorId.Length == 0
                                                             select c).ToList();
                foreach (CollectorHost collector in noDependantCollectors)
                {
                    LoadCollectorNode(root, collector);
                }                
            }
            root.Expand();
            #endregion

            #region Load Notifiers
            lvwNotifiers.Items.Clear();
            if (monitorPack != null && monitorPack.NotifierHosts != null && monitorPack.NotifierHosts.Count > 0)
            {
                foreach (NotifierHost n in monitorPack.NotifierHosts)
                {
                    ListViewItem lvi = new ListViewItem(n.Name);
                    lvi.ImageIndex = 0; // (n..Notifier != null && n.Notifier.HasViewer) ? 1 : 0;
                    lvi.Tag = n;
                    lvi.ForeColor = n.Enabled ? SystemColors.WindowText : Color.Gray;
                    lvwNotifiers.Items.Add(lvi);
                }
            }
            lblNoNotifiersYet.Visible = monitorPack.NotifierHosts.Count == 0;
            #endregion

            UpdateAppTitle();
            try
            {
                showDefaultNotifierToolStripMenuItem.Enabled = false;
                if (monitorPack != null)
                {
                    UpdateStatusbar(string.Format("{0} collector(s), {1} notifier(s)",
                         monitorPack.CollectorHosts.Count,
                         monitorPack.NotifierHosts.Count));
                    showDefaultNotifierToolStripMenuItem.Enabled = monitorPack.DefaultViewerNotifier != null;
                }
            }
            catch { }
            tvwCollectors.SelectedNode = root;
            root.EnsureVisible();

            Cursor.Current = Cursors.Default;
            root.Text = "COLLECTOR";
            Application.DoEvents();
        }
        private void LoadCollectorNode(TreeNode root, CollectorHost collector)
        {
            TreeNode collectorNode;
            if (collector.CollectorAgents == null || collector.CollectorAgents.Count == 0)
            {
                collectorNode = new TreeNode(collector.Name, 1, 1);
                collectorNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            }
            else
                collectorNode = new TreeNode(collector.Name, 2, 2);
            collectorNode.Tag = collector;
            collector.Tag = collectorNode;
            collectorNode.ForeColor = collector.Enabled ? SystemColors.WindowText : Color.Gray;
            if (collector.EnableRemoteExecute || collector.ForceRemoteExcuteOnChildCollectors)
            {
                collectorNode.Text += string.Format(" [{0}:{1}]", (collector.ForceRemoteExcuteOnChildCollectors ? "!" : "") + collector.RemoteAgentHostAddress, collector.RemoteAgentHostPort);
            }
            foreach (CollectorHost childCollector in (from c in monitorPack.CollectorHosts
                                                       where c.ParentCollectorId == collector.UniqueId &&
                                                       c.ParentCollectorId != c.UniqueId
                                                       select c))
            {
                LoadCollectorNode(collectorNode, childCollector);
            }
            root.Nodes.Add(collectorNode);
            if (collector.Enabled && collector.ExpandOnStart)
                collectorNode.Expand();
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
        private void RefreshMonitorPack(bool disablePollingOverride = false, bool forceUpdateNow = false)
        {
            //PausePolling();
            //DateTime abortStart = DateTime.Now;
            //try
            //{
            //    while (!forceUpdateNow && refreshBackgroundWorker.IsBusy && abortStart.AddSeconds(5) > DateTime.Now)
            //    {
            //        Application.DoEvents();
            //    }
            //    if (forceUpdateNow || !refreshBackgroundWorker.IsBusy)
            //    {
            //        Cursor.Current = Cursors.WaitCursor;
            //        refreshBackgroundWorker.RunWorkerAsync(disablePollingOverride);
            //    }
            //}
            //catch { }
            //finally
            //{
            //    mainRefreshTimer.Enabled = timerEnabled;
            //    ResumePolling();
            //}
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
                    if (saveFileDialogSave.FileName.ToLower().EndsWith(".qmconfig"))
                    {
                        saveFileDialogSave.FileName = saveFileDialogSave.FileName.Replace(".qmconfig", ".qmp");
                    }
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
        private void DoAutoSave()
        {
            if (Properties.Settings.Default.AutosaveChanges)
                SaveMonitorPack();
        }
        private void SortItemsByTreeView()
        {
            TreeNode collectorRootNode = tvwCollectors.Nodes[0];
            List<CollectorHost> sortedCollectors = new List<CollectorHost>();
            AppendSortedCollectors(collectorRootNode, sortedCollectors);
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
        private void SetMonitorChanged()
        {
            monitorPackChanged = true;
            UpdateAppTitle();
        }
        private void monitorPack_CollectorHostStateUpdated(CollectorHost collectorHost)
        {
            throw new NotImplementedException();
        }
        private void monitorPack_CollectorHostCalled(CollectorHost collectorHost)
        {
            throw new NotImplementedException();
        }
        private void monitorPack_RunCollectorHostRestorationScript(CollectorHost collectorHost)
        {
            throw new NotImplementedException();
        }
        private void monitorPack_RunCollectorHostCorrectiveErrorScript(CollectorHost collectorHost)
        {
            throw new NotImplementedException();
        }
        private void monitorPack_RunCollectorHostCorrectiveWarningScript(CollectorHost collectorHost)
        {
            throw new NotImplementedException();
        }
        private void monitorPack_CollectorHostAllAgentsExecutionTime(CollectorHost collectorHost, long msTime)
        {
            throw new NotImplementedException();
        }        
        private void monitorPack_OnNotifierError(NotifierHost notifierHost, string message)
        {
            throw new NotImplementedException();
        }
        private void RemoveCollector(TreeNode parentNode)
        {
            foreach (TreeNode collectorNode in parentNode.Nodes)
            {
                RemoveCollector(collectorNode);
            }
            CollectorHost ce = (CollectorHost)parentNode.Tag;
            monitorPack.CollectorHosts.Remove(ce);
        }
        #endregion

        #region Collector editing actions
        private void CreateNewCollector()
        {
            try
            {
                HideCollectorContextMenu();
                CollectorHost newCollectorEntry = new CollectorHost();
                EditCollectorHost editCollectorHost = new EditCollectorHost();
                newCollectorEntry.ParentCollectorId = "";
                if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag is CollectorHost)
                {
                    CollectorHost parentCollectorEntry = (CollectorHost)tvwCollectors.SelectedNode.Tag;
                    newCollectorEntry.ParentCollectorId = parentCollectorEntry.UniqueId;
                }

                editCollectorHost.KnownRemoteHosts = (from string krh in Properties.Settings.Default.KnownRemoteHosts
                                                      select krh).ToList();
                if (editCollectorHost.ShowDialog(newCollectorEntry, monitorPack) == System.Windows.Forms.DialogResult.OK)
                {
                    SetMonitorChanged();
                    newCollectorEntry.ReconfigureFromXml(editCollectorHost.SelectedConfig, monitorPack.ConfigVariables, true);
                    monitorPack.CollectorHosts.Add(newCollectorEntry);
                    TreeNode parentNode = tvwCollectors.Nodes[0];
                    if (newCollectorEntry.ParentCollectorId != null && newCollectorEntry.ParentCollectorId.Length > 0)
                    {
                        parentNode = GetNodeByCollectorId(newCollectorEntry.ParentCollectorId);
                        if (parentNode == null)
                            parentNode = tvwCollectors.Nodes[0];
                    }
                    LoadCollectorNode(parentNode, newCollectorEntry);
                    parentNode.Expand();
                    DoAutoSave();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "New Collector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditCollectorConfig()
        {
            PausePolling();
            try
            {
                if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag is CollectorHost)
                {
                    TreeNode currentNode = tvwCollectors.SelectedNode;
                    CollectorHost collectorEntry = (CollectorHost)currentNode.Tag;
                    EditCollectorHost editCollectorHost = new EditCollectorHost();
                    editCollectorHost.KnownRemoteHosts = (from string krh in Properties.Settings.Default.KnownRemoteHosts
                                                    select krh).ToList();
                    if (editCollectorHost.ShowDialog(collectorEntry, monitorPack) == System.Windows.Forms.DialogResult.OK)
                    {
                        SetMonitorChanged();
                        collectorEntry.ReconfigureFromXml(editCollectorHost.SelectedConfig, monitorPack.ConfigVariables, true);
                        //currentNode.Tag = collectorEntry;
                        currentNode.Text = collectorEntry.Name;
                        if (collectorEntry.EnableRemoteExecute || collectorEntry.ForceRemoteExcuteOnChildCollectors)
                        {
                            tvwCollectors.SelectedNode.Text += string.Format(" [{0}:{1}]", (collectorEntry.ForceRemoteExcuteOnChildCollectors ? "!" : "") + collectorEntry.RemoteAgentHostAddress, collectorEntry.RemoteAgentHostPort);
                        }
                        //correcting for parent node changes
                        if (collectorEntry.ParentCollectorId == null || collectorEntry.ParentCollectorId == "")
                        {
                            if (currentNode.Parent != tvwCollectors.Nodes[0])
                            {
                                currentNode.Parent.Nodes.Remove(currentNode);
                                tvwCollectors.Nodes[0].Nodes.Add(currentNode);
                            }
                        }
                        else
                        {
                            TreeNode parentNode = GetNodeByCollectorId(collectorEntry.ParentCollectorId);
                            if (currentNode.Parent != parentNode)
                            {
                                currentNode.Parent.Nodes.Remove(currentNode);
                                parentNode.Nodes.Add(currentNode);
                            }
                        }
                        //Ensure it is still visible and selected
                        currentNode.EnsureVisible();
                        tvwCollectors.SelectedNode = currentNode;

                        //if (!collectorEntry.IsFolder)
                        //    collectorEntry.RefreshDetailsIfOpen();

                        //if autosaving is enabled
                        DoAutoSave();

                        //add any new remote host entries
                        if (collectorEntry.RemoteAgentHostAddress != null && collectorEntry.RemoteAgentHostAddress.Length > 0 && collectorEntry.EnableRemoteExecute)
                        {
                            if (!Properties.Settings.Default.KnownRemoteHosts.Contains(collectorEntry.ToRemoteHostName()))
                                Properties.Settings.Default.KnownRemoteHosts.Add(collectorEntry.ToRemoteHostName());
                        }
                    }

                    //AgentHelper.KnownRemoteHosts = (from string krh in Properties.Settings.Default.KnownRemoteHosts
                    //                                select krh).ToList();
                    //if (AgentHelper.EditCollectorEntry(collectorEntry, monitorPack) == System.Windows.Forms.DialogResult.OK)
                    //{
                    //    SetMonitorChanged();
                    //    currentNode.Text = collectorEntry.Name;
                    //    if (collectorEntry.EnableRemoteExecute || collectorEntry.ForceRemoteExcuteOnChildCollectors)
                    //    {
                    //        tvwCollectors.SelectedNode.Text += string.Format(" [{0}:{1}]", (collectorEntry.ForceRemoteExcuteOnChildCollectors ? "!" : "") + collectorEntry.RemoteAgentHostAddress, collectorEntry.RemoteAgentHostPort);
                    //    }

                    //    //correcting for parent node changes
                    //    if (collectorEntry.ParentCollectorId == null || collectorEntry.ParentCollectorId == "")
                    //    {
                    //        if (currentNode.Parent != tvwCollectors.Nodes[0])
                    //        {
                    //            currentNode.Parent.Nodes.Remove(currentNode);
                    //            tvwCollectors.Nodes[0].Nodes.Add(currentNode);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        TreeNode parentNode = GetNodeByCollectorId(collectorEntry.ParentCollectorId);
                    //        if (currentNode.Parent != parentNode)
                    //        {
                    //            currentNode.Parent.Nodes.Remove(currentNode);
                    //            parentNode.Nodes.Add(currentNode);
                    //        }
                    //    }
                    //    //Ensure it is still visible and selected
                    //    currentNode.EnsureVisible();
                    //    tvwCollectors.SelectedNode = currentNode;

                    //    if (!collectorEntry.IsFolder)
                    //        collectorEntry.RefreshDetailsIfOpen();

                    //    //if autosaving is enabled
                    //    DoAutoSave();

                    //    //add any new remote host entries
                    //    if (collectorEntry.RemoteAgentHostAddress != null && collectorEntry.RemoteAgentHostAddress.Length > 0 && collectorEntry.EnableRemoteExecute)
                    //    {
                    //        if (!Properties.Settings.Default.KnownRemoteHosts.Contains(collectorEntry.ToRemoteHostName()))
                    //            Properties.Settings.Default.KnownRemoteHosts.Add(collectorEntry.ToRemoteHostName());
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ResumePolling();
        }
        private void DeleteCollector()
        {
            TreeNode currentNode = tvwCollectors.SelectedNode;
            if (currentNode.Tag is CollectorHost)
            {
                if (MessageBox.Show("Are you sure you want to remove this collector (and all possible dependants)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    SetMonitorChanged();
                    RemoveCollector(currentNode);
                    RefreshMonitorPack(true, true);
                    if (currentNode.Parent != null)
                    {
                        currentNode.Parent.Nodes.Remove(currentNode);
                    }
                    DoAutoSave();
                }
            }
        }
        private TreeNode GetNodeByCollectorId(string uniqueId, TreeNode root = null)
        {
            if (root == null)
            {
                root = tvwCollectors.Nodes[0];
            }
            foreach (TreeNode childNode in root.Nodes)
            {
                if (childNode.Tag != null && childNode.Tag is CollectorHost)
                {
                    CollectorHost theEntry = (CollectorHost)childNode.Tag;
                    if (theEntry.UniqueId == uniqueId)
                        return childNode;
                }
                TreeNode testGrandChild = GetNodeByCollectorId(uniqueId, childNode);
                if (testGrandChild != null)
                    return testGrandChild;
            }
            return null;
        }
        #endregion

        #region RecentMonitorPackList
        private void AddMonitorPackFileToRecentList(string monitorPackPath)
        {
            if ((from string f in Properties.Settings.Default.RecentQMConfigFiles
                 where f.ToUpper() == monitorPackPath.ToUpper()
                 select f).Count() == 0)
            {
                Properties.Settings.Default.RecentQMConfigFiles.Add(monitorPackPath);
            }
            Properties.Settings.Default.LastMonitorPack = monitorPackPath;
            LoadRecentMonitorPackList();
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
                        string typeName = MonitorPack.GetMonitorPackTypeName(filePath);
                        if ((from string s in allowFilters
                             where s == "*" || s.ToLower() == typeName.ToLower()
                             select s).Count() > 0)
                            mpVisible = true;
                        if ((from string s in disallowFilters
                             where s.ToLower() == typeName.ToLower()
                             select s).Count() > 0)
                            mpVisible = false;
                    }
                    else
                        mpVisible = false;

                    if (mpVisible)
                    {
                        string entryDisplayName = filePath;
                        if (!Properties.Settings.Default.ShowFullPathForQuickRecentist)
                            entryDisplayName = System.IO.Path.GetFileNameWithoutExtension(filePath);

                        if (cboRecentMonitorPacks.DropDownWidth < TextRenderer.MeasureText(entryDisplayName + "........", cboRecentMonitorPacks.Font).Width)
                        {
                            string ellipseText = entryDisplayName.Substring(0, 20) + "....";
                            string tmpStr = entryDisplayName.Substring(4);
                            while (TextRenderer.MeasureText(ellipseText + tmpStr, cboRecentMonitorPacks.Font).Width > cboRecentMonitorPacks.DropDownWidth)
                            {
                                tmpStr = tmpStr.Substring(1);
                            }
                            cboRecentMonitorPacks.Items.Add(new QuickMon.Controls.ComboItem(ellipseText + tmpStr, filePath));
                        }
                        else
                        {
                            cboRecentMonitorPacks.Items.Add(new QuickMon.Controls.ComboItem(entryDisplayName, filePath));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void recentMonitorPackToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            QuickMon.Forms.RecentMonitorPacks recentMonitorPacks = new QuickMon.Forms.RecentMonitorPacks();
            if (recentMonitorPacks.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CloseAllDetailWindows();
                LoadMonitorPack(recentMonitorPacks.SelectedPack);
                RefreshMonitorPack(true, true);
            }   
        }
        #endregion

        #region Private methods
        private void PausePolling(bool forcePause = false)
        {
            if (forcePause || Properties.Settings.Default.PausePollingDuringEditConfig)
            {
                timerWasEnabledBeforePausing = mainRefreshTimer.Enabled;
                mainRefreshTimer.Enabled = false;
            }
        }
        private void ResumePolling()
        {
            SetPollingFrequency(timerWasEnabledBeforePausing);
        }
        private void SetPollingFrequency(bool enabledAfterWards = true)
        {
            mainRefreshTimer.Enabled = false;
            if (Properties.Settings.Default.OverridesMonitorPackFrequency || monitorPack == null || monitorPack.PollingFrequencyOverrideSec == 0)
                mainRefreshTimer.Interval = Properties.Settings.Default.PollFrequencySec * 1000;
            else
                mainRefreshTimer.Interval = monitorPack.PollingFrequencyOverrideSec * 1000;
            mainRefreshTimer.Enabled = enabledAfterWards;
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
                        if (!SaveMonitorPack() && abortAllowed)
                            return false;
                    }
                }

                UpdateStatusbar("Shutting down...");
                Application.DoEvents();
                mainRefreshTimer.Enabled = false;
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
        private void HideCollectorContextMenu()
        {
            
        }  
        private void CloseAllDetailWindows()
        {
        
        }
        private void UpdateAppTitle()
        {
            Text = "QuickMon 4";
            if (monitorPackChanged)
                Text += "*";
            if (monitorPack != null)
            {
                if (!monitorPack.Enabled)
                    Text += " - [Disabled]";
                if (monitorPack.Name != null && monitorPack.Name.Length > 0)
                    Text += string.Format(" - [{0}]", monitorPack.Name);
            }
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
        #endregion

        #region Toolbar events
        private void newMonitorPackToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            CloseAllDetailWindows();
            NewMonitorPack();   
        }
        private void openMonitorPackToolStripButton_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            try
            {
                string startUpPath = MonitorPack.GetQuickMonUserDataDirectory();
                openFileDialogOpen.InitialDirectory = startUpPath;
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
        private void saveAsMonitorPackToolStripMenuItem_ButtonClick(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            SaveMonitorPack();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            SaveAsMonitorPack();
        }
        private void refreshToolStripButton1_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            RefreshMonitorPack(true, true);
        }
        private void addCollectorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            CreateNewCollector();
        }
        private void editCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            EditCollectorConfig();
        }
        private void removeCollectorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            DeleteCollector();
        }
        private void viewCollectorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void addNotifierToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void editNotifierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void removeNotifierToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void showDefaultNotifierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void showAllNotifiersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void closeAllChildWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void generalSettingsToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            PausePolling(true);
            HideCollectorContextMenu();
            GeneralSettings generalSettings = new GeneralSettings();
            generalSettings.PollingFrequencySec = Properties.Settings.Default.PollFrequencySec;
            generalSettings.PollingEnabled = timerWasEnabledBeforePausing;
            if (generalSettings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadRecentMonitorPackList();
                this.SnappingEnabled = Properties.Settings.Default.MainFormSnap;
                if (monitorPack != null)
                    monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;

                Properties.Settings.Default.PollFrequencySec = generalSettings.PollingFrequencySec;
                timerWasEnabledBeforePausing = generalSettings.PollingEnabled;
            }
            ResumePolling();
        }
        private void pollingDisabledToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void pollingSlowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void pollingNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void pollingFastToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void customPollingFrequencyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void manageTemplatesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void restartInAdminModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PerformCleanShutdown(true))
                return;
            Security.RestartInAdminMode(Application.ExecutablePath);
        }
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //HideCollectorContextMenu();
            AboutQuickMon aboutQuickMon = new AboutQuickMon();
            aboutQuickMon.ShowDialog();
        }
        #endregion

        #region Label clicks
        private void llblMonitorPack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool timerEnabled = mainRefreshTimer.Enabled;
            mainRefreshTimer.Enabled = false; //temporary stops it.

            UpdateStatusbar("Stopping polling...");
            WaitForPollingToFinish(5);
            UpdateStatusbar("Waiting for editing to finish");

            EditMonitorPackConfig emc = new EditMonitorPackConfig();
            emc.SelectedMonitorPack = monitorPack;
            if (emc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {                
                SetMonitorChanged();                
                if (emc.TriggerMonitorPackReload)
                {
                    monitorPack = emc.SelectedMonitorPack;
                    UpdateStatusbar("Reloading monitor pack...");
                    LoadControlsFromMonitorPack();
                }
                SetMonitorPackNameDescription();                
                DoAutoSave();
            }
            if (timerEnabled)
                UpdateStatusbar("Resuming polling...");
            else
                UpdateStatusbar("");
            SetPollingFrequency(timerEnabled);
        }
        private void llblNotifierViewToggle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            masterSplitContainer.Panel2Collapsed = !masterSplitContainer.Panel2Collapsed;
            llblNotifierViewToggle.Text = masterSplitContainer.Panel2Collapsed ? "Show Notifiers" : "Hide Notifiers";
        }
        #endregion

        #region Performance counters
        private void InitializeGlobalPerformanceCounters()
        {
            try
            {
                CounterCreationData[] quickMonCreationData = new CounterCreationData[]
                    {
                        new CounterCreationData("Collector Host success states/Sec", "Collector successful states per second", PerformanceCounterType.RateOfCountsPerSecond32),
                        new CounterCreationData("Collector Host warning states/Sec", "Collector warning states per second", PerformanceCounterType.RateOfCountsPerSecond32),
                        new CounterCreationData("Collector Host error states/Sec", "Collector error states per second", PerformanceCounterType.RateOfCountsPerSecond32),                        
                        new CounterCreationData("Collector Hosts queried/Sec", "Number of Collectors queried per second", PerformanceCounterType.RateOfCountsPerSecond32),
                        new CounterCreationData("Collector Hosts query time", "Collector total query time (ms)", PerformanceCounterType.NumberOfItems32),
                        new CounterCreationData("Selected Collector Host query time", "Selected Collector query time (ms)", PerformanceCounterType.NumberOfItems32)
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
                    collectorErrorStatePerSec = InitializePerfCounterInstance(quickMonPCCategory, "Collector Host error states/Sec");
                    collectorWarningStatePerSec = InitializePerfCounterInstance(quickMonPCCategory, "Collector Host warning states/Sec");
                    collectorInfoStatePerSec = InitializePerfCounterInstance(quickMonPCCategory, "Collector Host success states/Sec");
                    collectorsQueriedPerSecond = InitializePerfCounterInstance(quickMonPCCategory, "Collector Hosts queried/Sec");
                    collectorsQueryTime = InitializePerfCounterInstance(quickMonPCCategory, "Collector Hosts query time");
                    selectedCollectorsQueryTime = InitializePerfCounterInstance(quickMonPCCategory, "Selected Collector Host query time");
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
                    if (Security.IsInAdminMode())
                        MessageBox.Show(string.Format("Could not create performance counters! Please use a user account that has the proper rights.\r\nMore details{0}:", ex.Message), "Performance Counters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else //try launching in admin mode
                    {
                        MessageBox.Show("QuickMon 3 needs to restart in 'Admin' mode to set up its performance counters on this computer.", "Restart in Admin mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Properties.Settings.Default.Save();
                        Security.RestartInAdminMode(Application.ExecutablePath);
                    }
                }
                else
                    MessageBox.Show("Error creating application performance counters\r\n" + ex.Message, "Performance Counters", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private PerformanceCounter InitializePerfCounterInstance(string categoryName, string counterName)
        {
            PerformanceCounter counter = new PerformanceCounter(categoryName, counterName, false);
            counter.BeginInit();
            counter.RawValue = 0;
            counter.EndInit();
            return counter;
        }
        public void ClosePerformanceCounters()
        {
            SetCounterValue(collectorsQueryTime, 0, "Collector total query time (ms)");
            SetCounterValue(selectedCollectorsQueryTime, 0, "Selected collector query time (ms)");
        }
        private void SetCounterValue(PerformanceCounter counter, long value, string description)
        {
            try
            {
                if (counter == null)
                {
                    UpdateStatusbar("Performance counter not set up or installed! : " + description);
                }
                else
                {
                    counter.RawValue = value;
                }
            }
            catch (Exception ex)
            {
                UpdateStatusbar(string.Format("Increment performance counter error! : {0}\r\n{1}", description, ex.ToString()));
            }
        }
        private void IncrementCounter(PerformanceCounter counter, string description)
        {
            try
            {
                if (counter == null)
                {
                    UpdateStatusbar("Performance counter not set up or installed! : " + description);
                }
                else
                {
                    counter.Increment();
                }
            }
            catch (Exception ex)
            {
                UpdateStatusbar(string.Format("Increment performance counter error! : {0}\r\n{1}", description, ex.ToString()));
            }
        }
        #endregion

        #region Test stuff
        private void cmdTestRun1_Click(object sender, EventArgs e)
        {
            TestRun1 tr1 = new TestRun1();
            tr1.Show();
        }
        private void cmdTestRun2_Click(object sender, EventArgs e)
        {
            TestRun2Notifiers tr2 = new TestRun2Notifiers();
            tr2.Show();
        }

        private void cmdTestEdit_Click(object sender, EventArgs e)
        {
            TestCollectorHostEdit tce = new TestCollectorHostEdit();
            tce.Show();
        } 
        #endregion

        private void CheckCollectorContextMenuEnables()
        {
            //editCollectorToolStripMenuItem
            if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorHost)
            {
                CollectorHost entry = (CollectorHost)tvwCollectors.SelectedNode.Tag;

                //popedContainerForTreeView.cmdViewDetails.Enabled = !entry.IsFolder;
                //popedContainerForTreeView.cmdEditCollector.Enabled = true;
                //popedContainerForTreeView.cmdDeleteCollector.Enabled = true;
                //popedContainerForTreeView.cmdDisableCollector.Enabled = true;
                //popedContainerForTreeView.cmdDisableCollector.BackColor = entry.Enabled ? SystemColors.Control : Color.WhiteSmoke;
                //popedContainerForTreeView.cmdDisableCollector.BackgroundImage = entry.Enabled ? global::QuickMon.Properties.Resources.Forbidden16x16 : global::QuickMon.Properties.Resources.ForbiddenNot16x16;

                //collectorTreeViewDetailsToolStripMenuItem.Enabled = !entry.IsFolder;
                viewCollectorDetailsToolStripMenuItem.Enabled = true;
                //collectorTreeEditConfigToolStripMenuItem.Enabled = true;
                editCollectorToolStripMenuItem.Enabled = true;
                removeCollectorToolStripMenuItem1.Enabled = true;
                //disableCollectorTreeToolStripMenuItem.Enabled = true;
                //removeCollectorToolStripMenuItem.Enabled = true;
                //disableCollectorTreeToolStripMenuItem.Text = entry.Enabled ? "Disable" : "Enable";

                //popedContainerForTreeView.cmdCopy.Enabled = true;
                //popedContainerForTreeView.cmdStats.Enabled = !entry.IsFolder;
                //collectorStatisticsToolStripMenuItem.Enabled = !entry.IsFolder;
            }
            else
            {
                //popedContainerForTreeView.cmdViewDetails.Enabled = false;
                //popedContainerForTreeView.cmdEditCollector.Enabled = false;
                //popedContainerForTreeView.cmdDeleteCollector.Enabled = false;
                //popedContainerForTreeView.cmdDisableCollector.Enabled = false;

                //collectorTreeViewDetailsToolStripMenuItem.Enabled = false;
                viewCollectorDetailsToolStripMenuItem.Enabled = false;
                //collectorTreeEditConfigToolStripMenuItem.Enabled = false;
                editCollectorToolStripMenuItem.Enabled = false;
                //disableCollectorTreeToolStripMenuItem.Enabled = false;
                //popedContainerForTreeView.cmdDisableCollector.BackgroundImage = global::QuickMon.Properties.Resources.ForbiddenNot16x16;
                //removeCollectorToolStripMenuItem.Enabled = false;
                removeCollectorToolStripMenuItem1.Enabled = false;

                //popedContainerForTreeView.cmdCopy.Enabled = false;
                //popedContainerForTreeView.cmdStats.Enabled = false;
                //collectorStatisticsToolStripMenuItem.Enabled = false;
            }
            //popedContainerForTreeView.cmdPaste.Enabled = false;
            //popedContainerForTreeView.cmdPasteWithEdit.Enabled = false;
            if (Clipboard.ContainsText())
            {
                string clipboardTest = Clipboard.GetText().Trim(' ', '\r', '\n');
                if (clipboardTest.StartsWith("<collectorHosts>") && clipboardTest.EndsWith("</collectorHosts>"))
                {
                    //try
                    //{
                    //    List<CollectorHost> pastedCollectorEntries = CollectorHost.GetCollectorEntriesFromString(clipboardTest);
                    //    popedContainerForTreeView.cmdPaste.Enabled = true;
                    //    popedContainerForTreeView.cmdPasteWithEdit.Enabled = true;
                    //    copiedCollectorList = pastedCollectorEntries;
                    //}
                    //catch (Exception ex)
                    //{
                    //    System.Diagnostics.Trace.WriteLine(ex.ToString());
                    //}
                }
            }
        }

        private void showCollectorContextMenuTimer_Tick(object sender, EventArgs e)
        {
            showCollectorContextMenuTimer.Enabled = false;
            popperContainerForTreeView.Show(this, collectorContextMenuLaunchPoint);
        }


    }
}


#region Test code
//        private void button1_Click(object sender, EventArgs e)
//        {
//            RegisteredAgentCache.LoadAgentsOverride();
//            try
//            {
//                MonitorPack m = new MonitorPack();
//                string mconfig = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
//                        "defaultNotifier=\"Default notifiers\" runCorrectiveScripts=\"True\" " +
//                        "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
//                        "<configVars>\r\n" +
//                            "<configVar find=\"localhost\" replace=\"%LocalHost%\" />\r\n" +
//                        "</configVars>\r\n" +
//                        "<collectorHosts>\r\n" +
//                            "<collectorHost uniqueId=\"123\" name=\"Ping test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
//                               "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
//                               "repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
//                               "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
//                               "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
//                               "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
//                               "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" " +
//                               "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" " +
//                               "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
//                               "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
//                               "pollSlideFrequencyAfterThirdRepeatSec=\"30\" alertsPaused=\"False\">\r\n" +
//                               "<collectorAgents>\r\n" +
//                                   "<collectorAgent type=\"PingCollector\">\r\n" +
//                                        "<config>\r\n" +
//                                            "<entries>\r\n" +
//                                                "<entry pingMethod=\"Ping\" address=\"localhost\" />\r\n" +
//                                            "</entries>\r\n" +
//                                        "</config>\r\n" +
//                                   "</collectorAgent>\r\n" +
//                               "</collectorAgents>\r\n" +
//                            "</collectorHost>\r\n" +
//                        "</collectorHosts>\r\n" +
//                        "<notifierHosts>\r\n" +
//                            "<notifierHost name=\"Default notifiers\" enabled=\"True\" alertLevel=\"Info\" detailLevel=\"Detail\" " +
//                                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
//                                "<notifierAgents>\r\n" +
//                                    "<notifierAgent type=\"InMemoryNotifier\">\r\n" +
//                                        "<config><inMemory maxEntryCount=\"99999\" /></config>\r\n" +
//                                    "</notifierAgent>\r\n" +
//                                "</notifierAgents>\r\n" +
//                            "</notifierHost>\r\n" +
//                        "</notifierHosts>\r\n" +
//                       "</monitorPack>";
//                m.LoadXml(mconfig);
//                m.CollectorHost_AlertRaised_Good += m_CollectorHost_AlertRaised_Good;
//                m.CollectorHost_AlertRaised_NoStateChanged += m_CollectorHost_AlertRaised_NoStateChanged;
//                m.CollectorHost_AlertRaised_Warning += m_CollectorHost_AlertRaised_Warning;
//                m.CollectorHost_AlertRaised_Error += m_CollectorHost_AlertRaised_Error;

//                MessageBox.Show(string.Format("Initial: {0}", m.CollectorHosts[0].CollectorAgents[0].InitialConfiguration), "Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                MessageBox.Show(string.Format("Active: {0}", m.CollectorHosts[0].CollectorAgents[0].ActiveConfiguration), "Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
//                //MessageBox.Show(string.Format("Calling Agent directly\r\nPing status: {0}",  m.CollectorHosts[0].CollectorAgents[0].GetState().State), "Ping me", MessageBoxButtons.OK, MessageBoxIcon.Information);

//                MonitorState ms = m.CollectorHosts[0].RefreshCurrentState();
//                MessageBox.Show(string.Format("Calling via CollectorHost\r\nPing status: " + ms.State), "Ping me", MessageBoxButtons.OK, MessageBoxIcon.Information);


//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void AppendOutput(string message)
//        {
//            lock (txtAlerts)
//            {
//                txtAlerts.Text += string.Format("\r\n{0}", message);
//                txtAlerts.SelectionStart = txtAlerts.Text.Length - 1;
//                txtAlerts.ScrollToCaret();
//            }
//        }

//        void m_CollectorHost_AlertRaised_Error(CollectorHost collectorHost)
//        {
//            AppendOutput(string.Format("Error:\r\nFor: {0}\r\nDetails: {1}", collectorHost.Name, collectorHost.CurrentState.ReadAllRawDetails()));
//        }

//        void m_CollectorHost_AlertRaised_Warning(CollectorHost collectorHost)
//        {
//            AppendOutput(string.Format("Warning:\r\nFor: {0}\r\nDetails: {1}", collectorHost.Name, collectorHost.CurrentState.ReadAllRawDetails()));
//        }

//        private void m_CollectorHost_AlertRaised_NoStateChanged(CollectorHost collectorHost)
//        {
//            //AppendOutput(string.Format("No State changed:\r\nFor: {0}\r\nDetails: {1}", collectorHost.Name, collectorHost.CurrentState.ReadAllRawDetails()));
//        }

//        private void m_CollectorHost_AlertRaised_Good(CollectorHost collectorHost)
//        {
//            //AppendOutput(string.Format("Good:\r\nFor: {0}\r\nDetails: {1}", collectorHost.Name, collectorHost.CurrentState.ReadAllRawDetails()));
//        }

//        private void button2_Click(object sender, EventArgs e)
//        {
//            string configXml = "<collectorHosts>\r\n" +
//                        "<collectorHost uniqueId=\"123\" name=\"Ping test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
//                           "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
//                           "repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
//                           "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
//                           "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
//                           "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
//                           "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" " +
//                           "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" " +
//                           "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
//                           "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
//                           "pollSlideFrequencyAfterThirdRepeatSec=\"30\">\r\n" +
//                           "<collectorAgents>\r\n" +
//                               "<collectorAgent type=\"PingCollector\">\r\n" +
//                                    "<config>\r\n" +
//                                        "<entries>\r\n" +
//                                            "<entry pingMethod=\"Ping\" address=\"localhost\" />\r\n" +
//                                        "</entries>\r\n" +
//                                    "</config>\r\n" +
//                               "</collectorAgent>\r\n" +
//                           "</collectorAgents>\r\n" +
//                        "</collectorHost>\r\n" +
//                    "</collectorHosts>";
//            List<CollectorHost> chList = CollectorHost.GetCollectorHostsFromString(configXml);
//            if (chList != null)
//            {
//                StringBuilder rebuildXml = new StringBuilder();
//                rebuildXml.AppendLine("<collectorHosts>");
//                foreach (CollectorHost ch in chList)
//                {
//                    rebuildXml.AppendLine(ch.ToXml());
//                }
//                rebuildXml.AppendLine("</collectorHosts>");

//                chList = CollectorHost.GetCollectorHostsFromString(configXml);

//                rebuildXml = new StringBuilder();
//                rebuildXml.AppendLine("<collectorHosts>");
//                foreach (CollectorHost ch in chList)
//                {
//                    rebuildXml.Append(ch.ToXml());
//                }
//                rebuildXml.AppendLine("</collectorHosts>");
//                MessageBox.Show(rebuildXml.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }

//        }

//        private void button3_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                MonitorState ms = new MonitorState();
//                ms.ExecutedOnHostComputer = "localhost";
//                ms.CurrentValue = 1;
//                ms.RawDetails = "This is a test";
//                ms.HtmlDetails = "<p>This is a test</p>";
//                ms.State = CollectorState.NotAvailable;
//                ms.Timestamp = DateTime.Now;
//                ms.StateChangedTime = DateTime.Now;
//                ms.CallDurationMS = 1001;
//                ms.AlertsRaised.Add("Test alert");
//                ms.ChildStates.Add(new MonitorState() { State = CollectorState.Good, RawDetails = "Child test" });
//                ms.ChildStates.Add(new MonitorState() { State = CollectorState.Good, RawDetails = "Child test2" });

//                string msSerialized = ms.ToXml();
//                Clipboard.SetText(msSerialized);
//                MessageBox.Show(msSerialized);
//                ms.FromXml(ms.ToXml());
//                Clipboard.SetText(ms.ToXml());
//                MessageBox.Show("Reserialized:\r\n" + ms.ToXml());
//                if (msSerialized.Equals(ms.ToXml()))
//                    MessageBox.Show("Serialization/Deserialization success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                else
//                    MessageBox.Show("Serialization/Deserialization failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void button4_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                MonitorPack m = new MonitorPack();
//                string mconfig = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
//                        "defaultNotifier=\"Default notifiers\" runCorrectiveScripts=\"True\" " +
//                        "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
//                        "<configVars />\r\n" +
//                        "<collectorHosts>\r\n" +
//                            "<collectorHost uniqueId=\"123\" name=\"Ping test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
//                               "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
//                               "repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
//                               "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
//                               "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
//                               "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
//                               "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" " +
//                               "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" " +
//                               "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
//                               "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
//                               "pollSlideFrequencyAfterThirdRepeatSec=\"30\">\r\n" +
//                               "<collectorAgents>\r\n" +
//                                   "<collectorAgent type=\"PingCollector\">\r\n" +
//                                        "<config>\r\n" +
//                                            "<entries>\r\n" +
//                                                "<entry pingMethod=\"Ping\" address=\"NoPlaceLikeHome\" />\r\n" +
//                                            "</entries>\r\n" +
//                                        "</config>\r\n" +
//                                   "</collectorAgent>\r\n" +
//                               "</collectorAgents>\r\n" +
//                            "</collectorHost>\r\n" +
//                        "</collectorHosts>\r\n" +
//                        "<notifierHosts>\r\n" +
//                            "<notifierHost name=\"Default notifiers\" enabled=\"True\" alertLevel=\"Info\" detailLevel=\"Detail\" " +
//                                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
//                                "<notifierAgents>\r\n" +
//                                    "<notifierAgent type=\"InMemoryNotifier\">\r\n" +
//                                        "<config><inMemory maxEntryCount=\"99999\" /></config>\r\n" +
//                                    "</notifierAgent>\r\n" +
//                                "</notifierAgents>\r\n" +
//                            "</notifierHost>\r\n" +
//                        "</notifierHosts>\r\n" +
//                       "</monitorPack>";
//                m.LoadXml(mconfig);
//                m.CollectorHost_AlertRaised_Good += m_CollectorHost_AlertRaised_Good;
//                m.CollectorHost_AlertRaised_NoStateChanged += m_CollectorHost_AlertRaised_NoStateChanged;
//                m.CollectorHost_AlertRaised_Warning += m_CollectorHost_AlertRaised_Warning;
//                m.CollectorHost_AlertRaised_Error += m_CollectorHost_AlertRaised_Error;

//                MonitorState ms = m.CollectorHosts[0].RefreshCurrentState();

//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void button5_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                MonitorPack m = new MonitorPack();
//                string mconfig = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
//                        "defaultNotifier=\"Default notifiers\" runCorrectiveScripts=\"True\" " +
//                        "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
//                        "<configVars />\r\n" +
//                        "<collectorHosts>\r\n" +
//                            "<collectorHost uniqueId=\"123\" name=\"Ping test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
//                               "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
//                               "repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
//                               "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
//                               "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
//                               "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
//                               "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" " +
//                               "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" " +
//                               "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
//                               "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
//                               "pollSlideFrequencyAfterThirdRepeatSec=\"30\">\r\n" +
//                               "<collectorAgents>\r\n" +
//                                   "<collectorAgent type=\"PingCollector\">\r\n" +
//                                        "<config>\r\n" +
//                                            "<entries>\r\n" +
//                                                "<entry pingMethod=\"Ping\" address=\"NoPlaceLikeHome\" />\r\n" +
//                                                "<entry pingMethod=\"Ping\" address=\"localhost\" />\r\n" +
//                                            "</entries>\r\n" +
//                                        "</config>\r\n" +
//                                   "</collectorAgent>\r\n" +
//                                   "<collectorAgent type=\"PingCollector\">\r\n" +
//                                        "<config>\r\n" +
//                                            "<entries>\r\n" +
//                                                "<entry pingMethod=\"Ping\" address=\"localhost\" />\r\n" +
//                                            "</entries>\r\n" +
//                                        "</config>\r\n" +
//                                   "</collectorAgent>\r\n" +
//                               "</collectorAgents>\r\n" +
//                            "</collectorHost>\r\n" +
//                        "</collectorHosts>\r\n" +
//                        "<notifierHosts>\r\n" +
//                            "<notifierHost name=\"Default notifiers\" enabled=\"True\" alertLevel=\"Info\" detailLevel=\"Detail\" " +
//                                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
//                                "<notifierAgents>\r\n" +
//                                    "<notifierAgent type=\"InMemoryNotifier\">\r\n" +
//                                        "<config><inMemory maxEntryCount=\"99999\" /></config>\r\n" +
//                                    "</notifierAgent>\r\n" +
//                                    "<notifierAgent type=\"LogFileNotifier\">\r\n" +
//                                        "<config><logFile path=\"c:\\Temp\\QuickMon4Test.log\" createNewFileSizeKB=\"0\" /></config>\r\n" +
//                                    "</notifierAgent>\r\n" +
//                                "</notifierAgents>\r\n" +
//                            "</notifierHost>\r\n" +
//                        "</notifierHosts>\r\n" +
//                       "</monitorPack>";
//                m.LoadXml(mconfig);
//                m.CollectorHost_AlertRaised_Good += m_CollectorHost_AlertRaised_Good;
//                m.CollectorHost_AlertRaised_NoStateChanged += m_CollectorHost_AlertRaised_NoStateChanged;
//                m.CollectorHost_AlertRaised_Warning += m_CollectorHost_AlertRaised_Warning;
//                m.CollectorHost_AlertRaised_Error += m_CollectorHost_AlertRaised_Error;

//                MonitorState ms = m.CollectorHosts[0].RefreshCurrentState();

//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }


//        private MonitorPack persistentTest = new MonitorPack();
//        private void button6_Click(object sender, EventArgs e)
//        {            
//            try
//            {
//                txtAlerts.Text = "";
//                //string mconfig = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
//                //        "defaultNotifier=\"Default notifiers\" runCorrectiveScripts=\"True\" " +
//                //        "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
//                //        "<configVars />\r\n" +
//                //        "<collectorHosts>\r\n" +
//                //            "<collectorHost uniqueId=\"123\" name=\"Ping test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
//                //               "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
//                //               "repeatAlertInXMin=\"1\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
//                //               "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
//                //               "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
//                //               "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
//                //               "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" " +
//                //               "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" " +
//                //               "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
//                //               "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
//                //               "pollSlideFrequencyAfterThirdRepeatSec=\"30\">\r\n" +
//                //               "<collectorAgents>\r\n" +
//                //                   "<collectorAgent type=\"PingCollector\">\r\n" +
//                //                        "<config>\r\n" +
//                //                            "<entries>\r\n" +
//                //                                "<entry pingMethod=\"Ping\" address=\"" + txtHostName.Text + "\" />\r\n" +
//                //                            "</entries>\r\n" +
//                //                        "</config>\r\n" +
//                //                   "</collectorAgent>\r\n" +
//                //               "</collectorAgents>\r\n" +
//                //            "</collectorHost>\r\n" +
//                //        "</collectorHosts>\r\n" +
//                //        "<notifierHosts>\r\n" +
//                //            "<notifierHost name=\"Default notifiers\" enabled=\"True\" alertLevel=\"Info\" detailLevel=\"Detail\" " +
//                //                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
//                //                "<notifierAgents>\r\n" +
//                //                    "<notifierAgent type=\"InMemoryNotifier\">\r\n" +
//                //                        "<config><inMemory maxEntryCount=\"99999\" /></config>\r\n" +
//                //                    "</notifierAgent>\r\n" +
//                //                    "<notifierAgent type=\"LogFileNotifier\">\r\n" +
//                //                        "<config><logFile path=\"c:\\Temp\\QuickMon4Test.log\" createNewFileSizeKB=\"0\" /></config>\r\n" +
//                //                    "</notifierAgent>\r\n" +
//                //                "</notifierAgents>\r\n" +
//                //            "</notifierHost>\r\n" +
//                //            "<notifierHost name=\"Non-Default notifiers\" enabled=\"True\" alertLevel=\"Warning\" detailLevel=\"Detail\" " +
//                //                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
//                //                "<notifierAgents>\r\n" +
//                //                    "<notifierAgent type=\"LogFileNotifier\">\r\n" +
//                //                        "<config><logFile path=\"c:\\Temp\\QuickMon4ErrorTest.log\" createNewFileSizeKB=\"0\" /></config>\r\n" +
//                //                    "</notifierAgent>\r\n" +
//                //                    "<notifierAgent type=\"EventLogNotifier\">\r\n" +
//                //                        "<config><eventLog computer=\".\" eventSource=\"QuickMon4\" successEventID=\"0\" warningEventID=\"1\" errorEventID=\"2\" /></config>\r\n" +
//                //                    "</notifierAgent>\r\n" +
//                //                "</notifierAgents>\r\n" +
//                //            "</notifierHost>\r\n" +
//                //        "</notifierHosts>\r\n" +
//                //       "</monitorPack>";

//                 string mconfig = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
//                        "defaultNotifier=\"Default notifiers\" runCorrectiveScripts=\"True\" " +
//                        "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
//                        "<configVars />\r\n" +
//                        "<collectorHosts>\r\n";
//                 if (txtHostName.Text.Trim().Length > 0)
//                 {
//                     string[] hostnames = txtHostName.Text.Split(',', ' ');
//                     foreach (string hostname in hostnames)
//                     {
//                         mconfig += "<collectorHost uniqueId=\"123\" name=\"Ping " + hostname.EscapeXml().Trim() + "\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
//                                "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
//                                "repeatAlertInXMin=\"1\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
//                                "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
//                                "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
//                                "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
//                                "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" " +
//                                "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" " +
//                                "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
//                                "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
//                                "pollSlideFrequencyAfterThirdRepeatSec=\"30\" alertsPaused=\"" + (chkPauseAlerts.Checked ? "True" : "False") + "\">\r\n" +
//                                "<collectorAgents>\r\n" +
//                                    "<collectorAgent type=\"PingCollector\">\r\n" +
//                                         "<config>\r\n" +
//                                             "<entries>\r\n" +
//                                                 "<entry pingMethod=\"Ping\" address=\"" + hostname.EscapeXml().Trim() + "\" />\r\n" +
//                                             "</entries>\r\n" +
//                                         "</config>\r\n" +
//                                    "</collectorAgent>\r\n" +
//                                "</collectorAgents>\r\n" +
//                             "</collectorHost>\r\n";
//                     }
//                 }
//                 mconfig += "</collectorHosts>\r\n" +
//                        "<notifierHosts>\r\n" +
//                            "<notifierHost name=\"Default notifiers\" enabled=\"True\" alertLevel=\"Info\" detailLevel=\"Detail\" " +
//                                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
//                                "<notifierAgents>\r\n" +
//                                    "<notifierAgent type=\"InMemoryNotifier\">\r\n" +
//                                        "<config><inMemory maxEntryCount=\"99999\" /></config>\r\n" +
//                                    "</notifierAgent>\r\n" +
//                                    //"<notifierAgent type=\"LogFileNotifier\">\r\n" +
//                                    //    "<config><logFile path=\"c:\\Temp\\QuickMon4Test.log\" createNewFileSizeKB=\"0\" /></config>\r\n" +
//                                    //"</notifierAgent>\r\n" +
//                                "</notifierAgents>\r\n" +
//                            "</notifierHost>\r\n" +
//                            "<notifierHost name=\"Non-Default notifiers\" enabled=\"True\" alertLevel=\"Warning\" detailLevel=\"Detail\" " +
//                                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
//                                "<notifierAgents>\r\n" +
//                                    "<notifierAgent type=\"LogFileNotifier\">\r\n" +
//                                        "<config><logFile path=\"c:\\Temp\\QuickMon4ErrorTest.log\" createNewFileSizeKB=\"0\" /></config>\r\n" +
//                                    "</notifierAgent>\r\n" +
//                                    "<notifierAgent type=\"EventLogNotifier\">\r\n" +
//                                        "<config><eventLog computer=\".\" eventSource=\"QuickMon4\" successEventID=\"0\" warningEventID=\"1\" errorEventID=\"2\" /></config>\r\n" +
//                                    "</notifierAgent>\r\n" +
//                                "</notifierAgents>\r\n" +
//                            "</notifierHost>\r\n" +
//                        "</notifierHosts>\r\n" +
//                       "</monitorPack>";


//                persistentTest = new MonitorPack();
//                persistentTest.ConcurrencyLevel = (int)nudConcurency.Value;
//                persistentTest.LoadXml(mconfig);
//                persistentTest.CollectorHost_AlertRaised_Good += m_CollectorHost_AlertRaised_Good;
//                persistentTest.CollectorHost_AlertRaised_NoStateChanged += m_CollectorHost_AlertRaised_NoStateChanged;
//                persistentTest.CollectorHost_AlertRaised_Warning += m_CollectorHost_AlertRaised_Warning;
//                persistentTest.CollectorHost_AlertRaised_Error += m_CollectorHost_AlertRaised_Error;
//                Application.DoEvents();

//                persistentTest.RefreshStates(true);

//                Application.DoEvents();
//                StringBuilder alertSummary = new StringBuilder();
//                foreach (CollectorHost ch in persistentTest.CollectorHosts)
//                {
//                    alertSummary.AppendLine(string.Format("\r\n\tCollector host: {0}\r\n\tState: {1}", ch.Name, ch.CurrentState.State));
//                    List<string> alertsRaised = ch.CurrentState.AlertsRaised;
//                    if (alertsRaised.Count > 0)
//                    {
//                        alertSummary.AppendLine("\tNotifiers:");
//                        alertsRaised.ForEach(a => alertSummary.AppendLine("\t\t" + a));
//                    }
//                }
//                AppendOutput(string.Format("{0}\r\nDuration: {1}ms\r\nResulting state: {2}\r\nAlert Info: {3}",
//                        (new string('-', 80)),
//                        persistentTest.LastRefreshDurationMS,
//                        persistentTest.CurrentState,
//                        alertSummary.ToString()));


//                //MonitorState ms = persistentTest.CollectorHosts[0].CurrentState;

//                //Application.DoEvents();
//                //List<string> alertsRaised = ms.AlertsRaised;
//                //StringBuilder alertSummary = new StringBuilder();
//                //alertsRaised.ForEach(a => alertSummary.AppendLine(a));
//                ////if (alertSummary.ToString().Length > 0)
//                ////{
//                ////    txtAlerts.Text += string.Format("\r\nAlerts raised\r\n{0}", alertSummary);
//                ////    txtAlerts.SelectionStart = txtAlerts.Text.Length - 1;
//                ////    txtAlerts.ScrollToCaret();

//                ////    //MessageBox.Show("Alerts raised\r\n" + alertSummary.ToString(), "Alerts raised", MessageBoxButtons.OK, (ms.State == CollectorState.Error) ? MessageBoxIcon.Error : (ms.State == CollectorState.Warning) ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
//                ////}
//                //AppendOutput(string.Format("Duration: {0}ms\r\nResulting state: {1}\r\nPrevious state: {2}\r\nAlert Info: {3}",
//                //        ms.CallDurationMS,
//                //        ms.State,
//                //        persistentTest.CollectorHosts[0].PreviousState.State,
//                //        alertSummary.ToString()));

//                //txtAlerts.Text += string.Format("\r\nDuration: {0}ms\r\nResulting state: {1}\r\nPrevious state: {2}\r\nAlert Info: {3}",
//                //        ms.CallDurationMS,
//                //        ms.State,
//                //        persistentTest.CollectorHosts[0].PreviousState.State,
//                //        alertSummary.ToString());

//                //if (persistentTest.CollectorHosts[0].StateHistory.Count > 0)
//                //{
//                //    txtAlerts.Text += string.Format("\r\nPrevious state: {0}", persistentTest.CollectorHosts[0].StateHistory.Last().State);
//                //    txtAlerts.SelectionStart = txtAlerts.Text.Length - 1;
//                //    txtAlerts.ScrollToCaret();
//                //    //MessageBox.Show(string.Format("Previous state: {0}\r\nWait here for repeatAlertInXMin test", persistentTest.CollectorHosts[0].StateHistory.Last().State), "Previous", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                //}

//                ////seconds time
//                //ms = persistentTest.CollectorHosts[0].RefreshCurrentState();

//                //Application.DoEvents();
//                //alertsRaised = ms.AlertsRaised;
//                //alertSummary = new StringBuilder();
//                //alertsRaised.ForEach(a => alertSummary.AppendLine(a));
//                //if (alertSummary.ToString().Length > 0)
//                //    MessageBox.Show("Alerts raised\r\n" + alertSummary.ToString(), "Alerts raised", MessageBoxButtons.OK, (ms.State == CollectorState.Error) ? MessageBoxIcon.Error : (ms.State == CollectorState.Warning) ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

//                //if (persistentTest.CollectorHosts[0].StateHistory.Count > 0)
//                //{
//                //    MessageBox.Show(string.Format("Previous state: {0}", persistentTest.CollectorHosts[0].StateHistory.Last().State), "Previous", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                //}
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void button7_Click(object sender, EventArgs e)
//        {
//            if (persistentTest.CollectorHosts.Count > 0)
//            {
                
//                //string newConfig = "<config>\r\n" +
//                //                            "<entries>\r\n" +
//                //                            "</entries>\r\n" +
//                //                        "</config>";

//                //if (txtHostName.Text.Trim().Length > 0)
//                //{
                    
//                //    string[] hostnames = txtHostName.Text.Split(',', ' ');
//                //    foreach (string hostname in hostnames)
//                //    {
//                //        if (hostname.Trim().Length > 0)
//                //            newConfig = newConfig.Replace("</entries>", "<entry pingMethod=\"Ping\" address=\"" + hostname.Trim() + "\" />\r\n</entries>");
//                //    }
//                //}

//                txtAlerts.Text += "\r\n" + (new string('*', 80));
//                persistentTest.ConcurrencyLevel = (int)nudConcurency.Value;

//                foreach (CollectorHost ch in persistentTest.CollectorHosts)
//                {
//                    ch.AlertsPaused = chkPauseAlerts.Checked;
//                }

//                //persistentTest.CollectorHosts[0].CollectorAgents[0].AgentConfig.FromXml(newConfig);
//                persistentTest.RefreshStates();
//                Application.DoEvents();

//                //MonitorState ms = persistentTest.CurrentState;

//                StringBuilder alertSummary = new StringBuilder();
//                foreach (CollectorHost ch in persistentTest.CollectorHosts)
//                {
//                    alertSummary.AppendLine(string.Format("\r\n\tCollector host: {0}\r\n\tState: {1}", ch.Name, ch.CurrentState.State));
//                    List<string> alertsRaised = ch.CurrentState.AlertsRaised;
//                    if (alertsRaised.Count > 0)
//                    {
//                        alertSummary.AppendLine("\tNotifiers:");
//                        alertsRaised.ForEach(a => alertSummary.AppendLine("\t\t" + a));
//                    }
//                }
//                AppendOutput(string.Format("{0}\r\nDuration: {1}ms\r\nResulting state: {2}\r\nAlert Info: {3}",
//                        (new string('-', 80)),
//                        persistentTest.LastRefreshDurationMS,
//                        persistentTest.CurrentState,
//                        alertSummary.ToString()));

//                //txtAlerts.Text += string.Format("\r\n{0}\r\nDuration: {1}ms\r\nResulting state: {2}\r\nAlert Info: {3}",
//                //        (new string('-', 80)),
//                //        persistentTest.LastRefreshDurationMS,
//                //        persistentTest.CurrentState,
//                //        alertSummary.ToString());
//                //txtAlerts.SelectionStart = txtAlerts.Text.Length - 1;
//                //txtAlerts.ScrollToCaret();

//                //MessageBox.Show(string.Format("Resulting state: {0}\r\nPrevious state: {1}\r\nAlert Info: {2}",
////                        ms.State,
//                        //persistentTest.CollectorHosts[0].PreviousState.State,
////                        alertSummary.ToString()), "Result", MessageBoxButtons.OK,
//                        //(ms.State == CollectorState.Error) ? MessageBoxIcon.Error : (ms.State == CollectorState.Warning) ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
//            }
//        }

//        private void cmdClear_Click(object sender, EventArgs e)
//        {
//            txtAlerts.Text = "";
//        }

//        private void button8_Click(object sender, EventArgs e)
//        {
//            if (!chkRemoteHost.Checked || txtHostName.Text.Trim().Length > 0)
//            {

//                string configXml = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
//                        "defaultNotifier=\"Default notifiers\" runCorrectiveScripts=\"True\" " +
//                        "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
//                        "<configVars />\r\n" +
//                        "<collectorHosts>\r\n";
//                string[] hostnames = txtHostName.Text.Split(',', ' ');
//                foreach (string hostname in hostnames)
//                {
//                    configXml += "<collectorHost uniqueId=\"Ping" + hostname.EscapeXml() + "\" name=\"Ping " + hostname.EscapeXml() + " tests\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
//                        "agentCheckSequence=\"" + (chkFirstSuccess.Checked ? "FirstSuccess" : chkFirstError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
//                           "enableRemoteExecute=\"" + (chkRemoteHost.Checked ? "True" : "False") + "\" " +
//                           "forceRemoteExcuteOnChildCollectors=\"False\" remoteAgentHostAddress=\"" + txtRemoteHost.Text.EscapeXml() + "\" remoteAgentHostPort=\"48181\" " +
//                           "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" >\r\n" +
//                           "<collectorAgents>\r\n" +
//                                "<collectorAgent type=\"PingCollector\">\r\n" +
//                                    "<config>\r\n" +
//                                        "<entries>\r\n" +
//                                            "<entry pingMethod=\"Ping\" address=\"" + hostname.EscapeXml() + "\" />\r\n" +
//                                            "</entries>\r\n" +
//                                    "</config>\r\n" +
//                                "</collectorAgent>\r\n" +
//                            "</collectorAgents>\r\n" +
//                        "</collectorHost>\r\n";

//                    configXml += "<collectorHost uniqueId=\"Services" + hostname.EscapeXml() + "\" name=\"Services " + hostname.EscapeXml() + " tests\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"Ping" + hostname.EscapeXml() + "\" " +
//                       "agentCheckSequence=\"" + (chkFirstSuccess.Checked ? "FirstSuccess" : chkFirstError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
//                          "enableRemoteExecute=\"" + (chkRemoteHost.Checked ? "True" : "False") + "\" " +
//                          "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"" + txtRemoteHost.Text.EscapeXml() + "\" remoteAgentHostPort=\"48181\" " +
//                          "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" >\r\n" +
//                          "<collectorAgents>\r\n" +
//                            "<collectorAgent type=\"WindowsServiceStateCollector\">\r\n" +
//                                "<config>\r\n" +
//                                    "<machine name=\"" + hostname.EscapeXml() + "\">\r\n" +
//                                        "<service name=\"QuickMon 3 Service\" />\r\n" +
//                                    "</machine>\r\n" +
//                                "</config>\r\n" +
//                            "</collectorAgent>\r\n" +
//                          "</collectorAgents>\r\n" +
//                        "</collectorHost>\r\n";


//                    configXml += "<collectorHost uniqueId=\"Perf" + hostname.EscapeXml() + "\" name=\"Perfs " + hostname.EscapeXml() + " tests\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"Ping" + hostname.EscapeXml() + "\" " +
//                       "agentCheckSequence=\"" + (chkFirstSuccess.Checked ? "FirstSuccess" : chkFirstError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
//                          "enableRemoteExecute=\"" + (chkRemoteHost.Checked ? "True" : "False") + "\" " +
//                          "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"" + txtRemoteHost.Text.EscapeXml() + "\" remoteAgentHostPort=\"48181\" " +
//                          "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" >\r\n" +
//                          "<collectorAgents>\r\n" +
//                            "<collectorAgent name=\"CPU\" type=\"PerfCounterCollector\" enabled=\"True\">\r\n" +
//                                "<config>\r\n" +
//                                    "<performanceCounters>\r\n" +
//                                        "<performanceCounter computer=\"" + hostname.EscapeXml() + "\" category=\"Processor\" counter=\"% Processor Time\" instance=\"_Total\" returnValueInverted=\"False\" warningValue=\"90\" errorValue=\"99\" />\r\n" +
//                                    "</performanceCounters>\r\n" +
//                                "</config>\r\n" +
//                            "</collectorAgent>\r\n" +
//                            "<collectorAgent name=\"Memory\" type=\"PerfCounterCollector\" enabled=\"False\">\r\n" +
//                                "<config>\r\n" +
//                                    "<performanceCounters>\r\n" +
//                                        "<performanceCounter computer=\"" + hostname.EscapeXml() + "\" category=\"Memory\" counter=\"% Committed Bytes In Use\" instance=\"\" returnValueInverted=\"False\" warningValue=\"80\" errorValue=\"90\" />\r\n" +
//                                    "</performanceCounters>\r\n" +
//                                "</config>\r\n" +
//                            "</collectorAgent>\r\n" +
//                          "</collectorAgents>\r\n" +
//                        "</collectorHost>\r\n";


//                    configXml += "<collectorHost uniqueId=\"Folder" + hostname.EscapeXml() + "\" name=\"C drive " + hostname.EscapeXml() + " tests\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"Ping" + hostname.EscapeXml() + "\" " +
//                       "agentCheckSequence=\"" + (chkFirstSuccess.Checked ? "FirstSuccess" : chkFirstError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
//                          "enableRemoteExecute=\"" + (chkRemoteHost.Checked ? "True" : "False") + "\" " +
//                          "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"" + txtRemoteHost.Text.EscapeXml() + "\" remoteAgentHostPort=\"48181\" " +
//                          "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" >\r\n" +
//                          "<collectorAgents>\r\n" +
//                            "<collectorAgent name=\"Does C drive exist\" type=\"FileSystemCollector\" enabled=\"True\">\r\n" +
//                                "<config>\r\n" +
//                                    "<directoryList>\r\n" +
//                                        "<directory directoryPathFilter=\"\\\\" + hostname.EscapeXml() + "\\c$\\Test\\Test.txt\" testDirectoryExistOnly=\"False\" testFilesExistOnly=\"False\" " +
//                                        "errorOnFilesExist=\"True\" warningFileCountMax=\"2\" errorFileCountMax=\"3\" warningFileSizeMaxKB=\"0\" errorFileSizeMaxKB=\"0\" " +
//                                        "fileMinAgeMin=\"0\" fileMaxAgeMin=\"86400\" fileMinSizeKB=\"0\" fileMaxSizeKB=\"0\" />\r\n" +
//                                    "</directoryList>\r\n" +
//                                "</config>\r\n" +
//                            "</collectorAgent>\r\n" +
//                          "</collectorAgents>\r\n" +
//                        "</collectorHost>\r\n";

//                    configXml += "<collectorHost uniqueId=\"EventLog" + hostname.EscapeXml() + "\" name=\"Application Eventlog " + hostname.EscapeXml() + " tests\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"Ping" + hostname.EscapeXml() + "\" " +
//                       "agentCheckSequence=\"" + (chkFirstSuccess.Checked ? "FirstSuccess" : chkFirstError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
//                          "enableRemoteExecute=\"" + (chkRemoteHost.Checked ? "True" : "False") + "\" " +
//                          "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"" + txtRemoteHost.Text.EscapeXml() + "\" remoteAgentHostPort=\"48181\" " +
//                          "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" >\r\n" +
//                          "<collectorAgents>\r\n" +
//                            "<collectorAgent name=\"Errors in Evewntlog\" type=\"EventLogCollector\" enabled=\"True\">\r\n" +
//                                "<config>\r\n" +
//                                    "<eventlogs>\r\n" +
//                                        "<log computer=\"" + hostname.EscapeXml() + "\" eventLog=\"Application\" typeInfo=\"False\" typeWarn=\"True\" typeErr=\"True\" containsText=\"False\" textFilter=\"\" " +
//                                            "withInLastXEntries=\"100\" withInLastXMinutes=\"1440\" warningValue=\"1\" errorValue=\"50\">\r\n" +
//                                            "<sources />\r\n" + 
//                                            "<eventIds />\r\n" +                                            
//                                         "</log>\r\n" +                                        
//                                    "</eventlogs>\r\n" +
//                                "</config>\r\n" +
//                            "</collectorAgent>\r\n" +
//                          "</collectorAgents>\r\n" +
//                        "</collectorHost>\r\n";
//                }
//                configXml += "</collectorHosts>" +
//                            "<notifierHosts>\r\n" +
//                            "<notifierHost name=\"Default notifiers\" enabled=\"True\" alertLevel=\"Info\" detailLevel=\"Detail\" " +
//                                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
//                                "<notifierAgents>\r\n" +
//                                    "<notifierAgent type=\"InMemoryNotifier\">\r\n" +
//                                        "<config><inMemory maxEntryCount=\"99999\" /></config>\r\n" +
//                                    "</notifierAgent>\r\n" +
//                                    "<notifierAgent name=\"Email\" type=\"SMTPNotifier\">\r\n" +
//                                        "<config>\r\n" +
//                                            
//                                        "</config>\r\n" +
//                                    "</notifierAgent>\r\n" +
//                                "</notifierAgents>\r\n" +
//                            "</notifierHost>\r\n" +
//                        "</notifierHosts>\r\n" +
//                       "</monitorPack>";

//                MonitorPack m = new MonitorPack();
//                m.ConcurrencyLevel = 1;
//                m.LoadXml(configXml);
//                m.RefreshStates();
//                txtAlerts.Text = "";
//                foreach (CollectorHost ch in m.CollectorHosts)
//                {
//                    MonitorState ms = ch.CurrentState;
//                    txtAlerts.Text += string.Format("Collector host: {0}\r\n", ch.Name);
//                    txtAlerts.Text += string.Format("Run on host: {0}\r\n", ms.ExecutedOnHostComputer);
//                    txtAlerts.Text += string.Format("State: {0}\r\n{1}\r\n", ms.State, XmlFormattingUtils.NormalizeXML(ms.ReadAllRawDetails('\t')));
//                }
//            }
//        }

//        private void button9_Click(object sender, EventArgs e)
//        {
//            string configXml = "<collectorHosts>\r\n" +
//                        "<collectorHost uniqueId=\"1234\" name=\"Services test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
//                        "agentCheckSequence=\"" + (chkFirstSuccess.Checked ? "FirstSuccess" : chkFirstError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
//                           "repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
//                           "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
//                           "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
//                           "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
//                           "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"rhenning\" remoteAgentHostPort=\"48181\" " +
//                           "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" " +
//                           "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
//                           "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
//                           "pollSlideFrequencyAfterThirdRepeatSec=\"30\">\r\n" +
//                           "<collectorAgents>\r\n";
//            if (txtHostName.Text.Trim().Length > 0)
//            {
//                string[] hostnames = txtHostName.Text.Split(',', ' ');
//                foreach (string hostname in hostnames)
//                {
//                    configXml +=
//                        "<collectorAgent type=\"WindowsServiceStateCollector\">\r\n" +
//                            "<config>\r\n" +
//                                "<machine name=\"" + hostname.EscapeXml() + "\">\r\n" +
//                                    "<service name=\"QuickMon 3 Service\" />\r\n" +
//                                "</machine>\r\n" +
//                            "</config>\r\n" +
//                        "</collectorAgent>\r\n";
//                }
//            }

//            configXml +=
//                           "</collectorAgents>\r\n" +
//                        "</collectorHost>\r\n" +
//                    "</collectorHosts>";
//            List<CollectorHost> chList = CollectorHost.GetCollectorHostsFromString(configXml);
//            if (chList != null)
//            {
//                MonitorState ms = chList[0].RefreshCurrentState();
//                MessageBox.Show(XmlFormattingUtils.NormalizeXML(ms.ToXml()), "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

//            }
//        }

//        private void button10_Click(object sender, EventArgs e)
//        {
//            string configXml = "<collectorHosts>\r\n" +
//                        "<collectorHost uniqueId=\"1234\" name=\"PerfCounterCollector test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
//                        "agentCheckSequence=\"" + (chkFirstSuccess.Checked ? "FirstSuccess" : chkFirstError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
//                           "repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
//                           "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
//                           "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
//                           "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
//                           "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"rhenning-vm\" remoteAgentHostPort=\"48181\" " +
//                           "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" " +
//                           "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
//                           "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
//                           "pollSlideFrequencyAfterThirdRepeatSec=\"30\">\r\n" +
//                           "<collectorAgents>\r\n";
//            if (txtHostName.Text.Trim().Length > 0)
//            {
//                string[] hostnames = txtHostName.Text.Split(',', ' ');
//                foreach (string hostname in hostnames)
//                {
//                    configXml +=
//                        "<collectorAgent type=\"PerfCounterCollector\">\r\n" +
//                            "<config>\r\n" +
//                                "<performanceCounters>\r\n" +
//                                    "<performanceCounter computer=\"" + hostname.EscapeXml() + "\" category=\"Processor\" counter=\"% Processor Time\" instance=\"_Total\" returnValueInverted=\"False\" warningValue=\"90\" errorValue=\"99\" />\r\n" +
//                                "</performanceCounters>\r\n" +
//                            "</config>\r\n" +
//                        "</collectorAgent>\r\n";
//                }
//            }

//            configXml +=
//                           "</collectorAgents>\r\n" +
//                        "</collectorHost>\r\n" +
//                    "</collectorHosts>";
//            List<CollectorHost> chList = CollectorHost.GetCollectorHostsFromString(configXml);
//            if (chList != null)
//            {
//                MonitorState ms = chList[0].RefreshCurrentState();
//                MessageBox.Show(string.Format("State: {0}\r\n{1}", ms.State, XmlFormattingUtils.NormalizeXML(ms.ReadAllRawDetails())), "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

//            }
//        }
#endregion