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
using QuickMon.Controls;
using QuickMon.Forms;
using QuickMon.UI;

namespace QuickMon
{
    public partial class MainForm : FadeSnapForm
    {
        public MainForm()
        {
            InitializeComponent();
            poppedContainerForTreeView = new Controls.CollectorContextMenuControl();
            popperContainerForTreeView = new Controls.PopperContainer(poppedContainerForTreeView);
            poppedContainerForListView = new Controls.NotifierContextMenuControl();
            popperContainerForListView = new Controls.PopperContainer(poppedContainerForListView);
            autoRefreshTimer = new Timer() { Enabled = false, Interval = Properties.Settings.Default.PollFrequencySec * 1000 };
        }

        #region Private vars
        private bool monitorPackChanged = false;
        private bool firstRefresh = true;        
        private bool refreshCycleA = true;
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
        private QuickMon.Controls.CollectorContextMenuControl poppedContainerForTreeView;
        private QuickMon.Controls.PopperContainer popperContainerForTreeView;
        private QuickMon.Controls.NotifierContextMenuControl poppedContainerForListView;
        private QuickMon.Controls.PopperContainer popperContainerForListView;

        #region Copy and Paste of collector hosts
        private List<CollectorHost> copiedCollectorList = new List<CollectorHost>();
        //private List<CollectorStats> collectorStatsWindows = new List<CollectorStats>(); 
        #endregion

        #region Main timer
        private Timer autoRefreshTimer;
        private bool isPollingPaused = false;
        //private bool timerWasEnabledBeforePausing = false;
        #endregion

        private List<CollectorStatusViewer> collectorStatusViews = new List<CollectorStatusViewer>();
        private List<INotivierViewer> agentDetailViews = new List<INotivierViewer>();
        EditTemplates editTemplates = null;
        //private List<NotifierAgentListViewer> notifierDetailViews = new List<NotifierAgentListViewer>();
        #endregion

        #region TreeNodeImage contants
        private readonly int collectorRootImage = 0;
        private readonly int collectorFolderImage = 1;
        private readonly int collectorNAstateImage = 2;
        private readonly int collectorGoodStateImage1 = 3;
        private readonly int collectorGoodStateImage2 = 6;
        private readonly int collectorWarningStateImage1 = 4;
        private readonly int collectorWarningStateImage2 = 7;
        private readonly int collectorErrorStateImage1 = 5;
        private readonly int collectorErrorStateImage2 = 8;
        private readonly int collectorDisabled = 9;
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
            Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = string.Format("v{0}.{1}.{2}", v.Major, v.Minor, v.Build);
            toolTip1.SetToolTip(lblVersion, string.Format("v{0} ({1})", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version, new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).LastWriteTime.ToString("yyyy-MM-dd")));
            tvwCollectors.EnableAutoScrollToSelectedNode = true;
            tvwCollectors.TreeNodeMoved += tvwCollectors_TreeNodeMoved;
            //tvwCollectors.EnterKeyDown += tvwCollectors_EnterKeyDown;
            tvwCollectors.RootAlwaysExpanded = true;
            //tvwCollectors.ContextMenuShowUp += tvwCollectors_ContextMenuShowUp;
            tvwNotifiers.RootAlwaysExpanded = true;
            //lvwNotifiers.SelectedIndexChanged += lvwNotifiers_SelectedIndexChanged;
            adminModeToolStripStatusLabel.Visible = Security.UACTools.IsInAdminMode();
            restartInAdminModeToolStripMenuItem.Visible = !Security.UACTools.IsInAdminMode();

            //this does not work properly on all OS'es. Disabled for now
            restartInNonAdminModeToolStripMenuItem.Visible = false; // Security.IsInAdminMode() && HenIT.Security.AdminModeTools.HasAdminMode();

            SetUpContextMenus();
        }        
        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                InitializeGlobalPerformanceCounters();
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
            ResumePolling();
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
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                InitializeBackgroundWorker();
                RefreshMonitorPack(true, true);
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                openMonitorPackToolStripButton_Click(sender, e);
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
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else
            {
                ViewCollectorDetails();
                //collectorTreeViewDetailsToolStripMenuItem_Click(null, null);
            }
        }
        private void tvwCollectors_EnterKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                //editCollectorToolStripMenuItem_Click(null, null);
               
                //
            }
        }
        //private void tvwCollectors_ContextMenuShowUp()
        //{
        //    Point topabsolute = this.PointToScreen(tvwCollectors.Location);
        //    Point topRelative = this.PointToClient(tvwCollectors.Location);
        //    Point calcPoint;
        //    if (tvwCollectors.SelectedNode != null)
        //    {
        //        calcPoint = new Point(tvwCollectors.Location.X + tvwCollectors.SelectedNode.Bounds.Location.X, GetControlLocationWithinParent(tvwCollectors).Y + tvwCollectors.SelectedNode.Bounds.Location.Y + 20 - this.Top);
        //    }
        //    else
        //    {
        //        calcPoint = new Point(tvwCollectors.Location.X + (tvwCollectors.Width / 2), tvwCollectors.Location.Y + (tvwCollectors.Height / 2));
        //    }
        //    CheckCollectorContextMenuEnables();
        //    collectorContextMenuLaunchPoint = calcPoint;
        //    showCollectorContextMenuTimer.Enabled = false;
        //    showCollectorContextMenuTimer.Enabled = true;
        //}
        private void tvwCollectors_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CheckCollectorContextMenuEnables();            
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
        private void tvwCollectors_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                EditCollectorConfig();
            }
            else
            {
                ViewCollectorDetails();
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
        private void tvwCollectors_FunctionKeyUp(int functionKey, KeyEventArgs e)
        {
 
        }
        private void tvwCollectors_ContextMenuShowUp()
        {
            Point topabsolute = this.PointToScreen(panel1.Location);
            Point topRelative = new Point(topabsolute.X - this.Location.X, topabsolute.Y - this.Location.Y);
            Point calcPoint = new Point(Cursor.Position.X - tvwCollectors.Location.X - this.Left, Cursor.Position.Y - topRelative.Y - this.Top + 10);
            collectorContextMenuLaunchPoint = calcPoint;
            CheckCollectorContextMenuEnables();

            showCollectorContextMenuTimer.Enabled = false;
            showCollectorContextMenuTimer.Enabled = true;
        }
        #endregion

        #region Notifier TreeView events
        private void tvwNotifiers_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                EditNotifierConfig();
            }
            else
                ViewNotifierDetails();
        } 
        private void tvwNotifiers_DoubleClick(object sender, EventArgs e)
        {
            
        }
        private void tvwNotifiers_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point topabsolute = this.PointToScreen(panel1.Location);
                Point topRelative = new Point(topabsolute.X - this.Location.X, topabsolute.Y - this.Location.Y);
                Point calcPoint = new Point(Cursor.Position.X - tvwNotifiers.Location.X - this.Left, Cursor.Position.Y - topRelative.Y - this.Top + 10);
                notifierContextMenuLaunchPoint = calcPoint;
                CheckNotifierContextMenuEnables();
                showNotifierContextMenuTimer.Enabled = false;
                showNotifierContextMenuTimer.Enabled = true;
            }
        }
        private void tvwNotifiers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CheckNotifierContextMenuEnables();
        }
        private void tvwNotifiers_ContextMenuShowUp()
        {
            Point topabsolute = this.PointToScreen(panel1.Location);
            Point topRelative = new Point(topabsolute.X - this.Location.X, topabsolute.Y - this.Location.Y);
            Point calcPoint = new Point(Cursor.Position.X - tvwNotifiers.Location.X - this.Left, Cursor.Position.Y - topRelative.Y - this.Top + 10);
            notifierContextMenuLaunchPoint = calcPoint;
            CheckNotifierContextMenuEnables();
            showNotifierContextMenuTimer.Enabled = false;
            showNotifierContextMenuTimer.Enabled = true;
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
                MonitorPack.NameAndTypeSummary summary = (MonitorPack.NameAndTypeSummary)((QuickMon.Controls.ComboItem)cboRecentMonitorPacks.SelectedItem).Value;
                LoadMonitorPack(summary.Path);
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
            PausePolling();
            try
            {
                CloseAllDetailWindows();
                monitorPack.CollectorHostStateUpdated -= monitorPack_CollectorHostStateUpdated;
                monitorPack.ClosePerformanceCounters();
                monitorPack = null;
            }
            catch { }
            monitorPack = new MonitorPack();

            string newMonitorPackConfig = Properties.Resources.BlankMonitorPack;
            if (Properties.Settings.Default.UseTemplatesForNewObjects && QuickMonTemplate.GetMonitorPackTemplates().Count > 0)
            {
                SelectTemplate selectTemplate = new SelectTemplate();
                selectTemplate.FilterTemplatesBy = TemplateType.MonitorPack;
                if (selectTemplate.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    newMonitorPackConfig = selectTemplate.SelectedTemplate.Config;
                }
            }

            monitorPack.LoadXml(newMonitorPackConfig);
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
                PausePolling();
                InitializeBackgroundWorker();                

                if (monitorPack != null)
                {
                    try
                    {
                        CloseAllDetailWindows();
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

                monitorPack.Load(monitorPackPath);
                LoadControlsFromMonitorPack();
                SetMonitorPackEvents();

                AddMonitorPackFileToRecentList(monitorPackPath);
                
                ResumePolling();
                monitorPackChanged = false;
            }
        }
        private void SetMonitorPackEvents()
        {
            if (monitorPack != null)
            {
                monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
                monitorPack.CollectorHostStateUpdated += monitorPack_CollectorHostStateUpdated;
                monitorPack.OnNotifierError += monitorPack_OnNotifierError;
                monitorPack.RunCollectorHostCorrectiveWarningScript += monitorPack_RunCollectorHostCorrectiveWarningScript;
                monitorPack.RunCollectorHostCorrectiveErrorScript += monitorPack_RunCollectorHostCorrectiveErrorScript;
                monitorPack.RunCollectorHostRestorationScript += monitorPack_RunCollectorHostRestorationScript;
                monitorPack.CollectorHostCalled += monitorPack_CollectorHostCalled;
                monitorPack.CollectorHostAllAgentsExecutionTime += monitorPack_CollectorHostAllAgentsExecutionTime;
                monitorPack.RunningAttended = AttendedOption.OnlyAttended;

                monitorPack.ApplicationUserNameCacheFilePath = Properties.Settings.Default.ApplicationUserNameCacheFilePath;
                monitorPack.ApplicationUserNameCacheMasterKey = Properties.Settings.Default.ApplicationMasterKey;
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
                List<CollectorHost> noDependantCollectors = monitorPack.GetRootCollectorHosts();
                foreach (CollectorHost collector in noDependantCollectors)
                {
                    LoadCollectorNode(root, collector);
                }                
            }
            root.Expand();
            root.Text = "COLLECTORS";
            #endregion

            #region Load Notifiers
            TreeNode notifierRoot = tvwNotifiers.Nodes[0];
            notifierRoot.Nodes.Clear();
            if (monitorPack != null && monitorPack.NotifierHosts != null && monitorPack.NotifierHosts.Count > 0)
            {
                foreach (NotifierHost n in monitorPack.NotifierHosts)
                {
                    LoadNotifierNode(n);                    
                }
            }
            notifierRoot.Expand();

            lblNoNotifiersYet.Visible = monitorPack.NotifierHosts.Count == 0;
            #endregion

            UpdateAppTitle();

            if (monitorPack != null)
            {
                UpdateStatusbar(string.Format("{0} collector(s), {1} notifier(s)",
                     monitorPack.CollectorHosts.Count,
                     monitorPack.NotifierHosts.Count));
            }

            tvwCollectors.SelectedNode = root;
            root.EnsureVisible();

            Cursor.Current = Cursors.Default;            
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
        private void LoadNotifierNode(NotifierHost n)
        {
            TreeNode notifierRoot = tvwNotifiers.Nodes[0];
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
            notifierRoot.Nodes.Add(notifierHostNode);
        }
        private void LoadNotifierAgents(TreeNode notifierHostNode,NotifierHost n)
        {
            foreach (INotifier nAgent in n.NotifierAgents)
            {
 	            TreeNode notifierAgentNode = new TreeNode(nAgent.Name);
                try
                {
                    if (RegisteredAgentUIMapper.HasAgentViewer(nAgent))
                        notifierAgentNode.ImageIndex = 3;
                    else
                        notifierAgentNode.ImageIndex = 4;
                    //WinFormsUINotifierBase agentUI = RegisteredAgentUIMapper.GetNotifierUIClass(nAgent);
                    //if (agentUI == null)
                    //{
                    //    notifierAgentNode.ImageIndex = 4;
                    //}
                    //else if (!agentUI.HasDetailView)
                    //{
                    //    notifierAgentNode.ImageIndex = 4;
                    //}
                    //else
                    //{
                    //    notifierAgentNode.ImageIndex = 3;
                    //}
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
        private void EditMonitorSettings()
        {
            UpdateStatusbar("Stopping polling...");
            PausePolling();
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
                    SetMonitorPackEvents();
                    LoadControlsFromMonitorPack();
                }
                SetMonitorPackNameDescription();
                DoAutoSave();
            }
            if (!isPollingPaused)
            {
                UpdateStatusbar("Resuming polling...");
            }
            else
                UpdateStatusbar("");
            ResumePolling(true);
        }
        private void SetMonitorPackNameDescription()
        {
            toolTip1.SetToolTip(llblMonitorPack, "");
            llblMonitorPack.Text = "";
            if (monitorPack == null || ((monitorPack.Name == null || monitorPack.Name.Trim().Length == 0)))
            {
                llblMonitorPack.Text = "Click here to set the monitor pack properties.";
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
                    if (saveFileDialogSave.FileName.ToLower().EndsWith(".qmconfig"))
                    {
                        saveFileDialogSave.FileName = saveFileDialogSave.FileName.Replace(".qmconfig", ".qmp4");
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
                                if (firstRefresh && (imageIndex == collectorWarningStateImage1 || imageIndex == collectorErrorStateImage1))
                                {
                                    TreeNode currentFocusNode = tvwCollectors.SelectedNode;
                                    try
                                    {
                                        tvwCollectors.BeginUpdate();
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
        private void monitorPack_CollectorHostCalled(CollectorHost collectorHost)
        {
            
        }
        private void monitorPack_RunCollectorHostRestorationScript(CollectorHost collectorHost)
        {
            if (collectorHost != null && !collectorHost.CorrectiveScriptDisabled)
                RunCorrectiveScript(collectorHost.RestorationScriptPath);
        }
        private void monitorPack_RunCollectorHostCorrectiveErrorScript(CollectorHost collectorHost)
        {
            if (collectorHost != null && !collectorHost.CorrectiveScriptDisabled)
                RunCorrectiveScript(collectorHost.CorrectiveScriptOnErrorPath);
        }
        private void monitorPack_RunCollectorHostCorrectiveWarningScript(CollectorHost collectorHost)
        {
            if (collectorHost != null && !collectorHost.CorrectiveScriptDisabled)
                RunCorrectiveScript(collectorHost.CorrectiveScriptOnWarningPath);
        }
        private void monitorPack_CollectorHostAllAgentsExecutionTime(CollectorHost collectorHost, long msTime)
        {
            
        }        
        private void monitorPack_OnNotifierError(NotifierHost notifierHost, string message)
        {
            
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
            PausePolling();
            DateTime abortStart = DateTime.Now;
            try
            {
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
                ResumePolling();
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
                    UpdateStatusbar(string.Format("Global state: {0}, Updated: {1}, Duration: {2} sec, Cur Freq: {3}",
                        globalState,
                        DateTime.Now.ToString("HH:mm:ss"),
                        (sw.ElapsedMilliseconds / 1000.00).ToString("F2"),
                        (autoRefreshTimer.Interval / 1000).ToString()
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
            if (root == null)
                root = tvwCollectors.Nodes[0];

            if (root.Tag != null && root.Tag is CollectorHost)
            {
                CollectorHost collector = (CollectorHost)root.Tag;
                if (collector.CollectorAgents.Count > 0 && collector.Enabled)
                {
                    //root.ForeColor = Color.DarkRed; //13,14,15
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
                if (refreshCycleA)
                    this.Icon = Properties.Resources.QM4BlueStateNAA;
                else
                    this.Icon = Properties.Resources.QM4BlueStateNAB;
            }
        } 
        #endregion        

        #endregion

        #region Collector editing actions
        private void CreateNewCollector()
        {
            HideCollectorContextMenu();
            if (Properties.Settings.Default.PausePollingDuringEditConfig)
                PausePolling();
            try
            {
                CollectorHost newCollectorEntry = new CollectorHost();
                EditCollectorHost editCollectorHost = new EditCollectorHost();
                if (Properties.Settings.Default.UseTemplatesForNewObjects && QuickMonTemplate.GetCollectorHostTemplates().Count > 0)
                {
                    SelectTemplate selectTemplate = new SelectTemplate();
                    selectTemplate.FilterTemplatesBy = TemplateType.CollectorHost;
                    if (selectTemplate.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {                        
                        newCollectorEntry = CollectorHost.FromXml(selectTemplate.SelectedTemplate.Config);
                        newCollectorEntry.UniqueId = Guid.NewGuid().ToString();
                    }
                }
                else
                    editCollectorHost.ShowAddAgentsOnStart = true;
                
                newCollectorEntry.ParentCollectorId = "";                
                if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag is CollectorHost)
                {
                    CollectorHost parentCollectorEntry = (CollectorHost)tvwCollectors.SelectedNode.Tag;
                    newCollectorEntry.ParentCollectorId = parentCollectorEntry.UniqueId;
                }

                editCollectorHost.KnownRemoteHosts = (from string krh in Properties.Settings.Default.KnownRemoteHosts
                                                      select krh).ToList();
                editCollectorHost.HostingMonitorPack = monitorPack;
                if (editCollectorHost.ShowDialog(newCollectorEntry, monitorPack) == System.Windows.Forms.DialogResult.OK)
                {
                    SetMonitorChanged();
                    newCollectorEntry.ReconfigureFromXml(editCollectorHost.SelectedConfig, monitorPack.ConfigVariables, true);
                    monitorPack.AddCollectorHost(newCollectorEntry);
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
            if (Properties.Settings.Default.PausePollingDuringEditConfig)
                ResumePolling(true);
        }
        private void EditCollectorConfig()
        {
            HideCollectorContextMenu();
            if (Properties.Settings.Default.PausePollingDuringEditConfig)
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Properties.Settings.Default.PausePollingDuringEditConfig)
                ResumePolling(true);
        }
        private void DeleteCollector()
        {
            HideCollectorContextMenu();
            if (Properties.Settings.Default.PausePollingDuringEditConfig)
                PausePolling();
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
            if (Properties.Settings.Default.PausePollingDuringEditConfig)
                ResumePolling();
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

        #region Collector viewing actions
        private void ViewCollectorDetails()
        {
            HideCollectorContextMenu();
            if (tvwCollectors.SelectedNode.Tag is CollectorHost)
            {
                CollectorHost currentCollectorHost = (CollectorHost)tvwCollectors.SelectedNode.Tag;
                CleanCollectorStatusViews();
                CollectorStatusViewer collectorStatusView = (from c in collectorStatusViews
                                                             where c.SelectedCollectorHost.UniqueId == currentCollectorHost.UniqueId &&
                                                                c.IsStillVisible()
                                                             select c).FirstOrDefault();
                if (collectorStatusView == null)
                {
                    collectorStatusView = new CollectorStatusViewer();
                    collectorStatusView.SelectedCollectorHost = currentCollectorHost;
                    collectorStatusViews.Add(collectorStatusView);
                    collectorStatusView.Show();
                }
                else
                {
                    if (collectorStatusView.WindowState == FormWindowState.Minimized)
                        collectorStatusView.WindowState = FormWindowState.Normal;
                    collectorStatusView.Show();
                    collectorStatusView.TopMost = true;
                    collectorStatusView.TopMost = false;
                }
                collectorStatusView.RefreshStats();
            }
        }
        private void CleanCollectorStatusViews()
        {
            if (collectorStatusViews == null)
            {
                collectorStatusViews = new List<CollectorStatusViewer>();
            }

            List<CollectorStatusViewer> viewsToRemove = (from v in collectorStatusViews
                                                         where !v.IsStillVisible()
                                                         select v).ToList();
            foreach (CollectorStatusViewer collectorStatusView in viewsToRemove)
            {
                collectorStatusViews.Remove(collectorStatusView);
            }
        }
        private void CloseAllCollectorStatusViews()
        {
            if (collectorStatusViews == null)
            {
                collectorStatusViews = new List<CollectorStatusViewer>();
            }
            foreach (CollectorStatusViewer collectorStatusView in (from v in collectorStatusViews
                                                                   where v.IsStillVisible()
                                                                   select v).ToList())
            {
                collectorStatusView.Close();
            }
            collectorStatusViews = new List<CollectorStatusViewer>();
        }
        #endregion

        #region Notifier editing actions
        private void CreateNewNotifier()
        {
            HideNotifierContextMenu();
            if (Properties.Settings.Default.PausePollingDuringEditConfig)
                PausePolling();
            try
            {
                if (tvwNotifiers.SelectedNode != null && (tvwNotifiers.SelectedNode.Tag is NotifierHost ||  tvwNotifiers.SelectedNode.Tag is INotifier))
                {
                    #region create Notifier Agent
                    NotifierHost parentNotifierHost;
                    if (tvwNotifiers.SelectedNode.Tag is NotifierHost)
                        parentNotifierHost = (NotifierHost)tvwNotifiers.SelectedNode.Tag;
                    else
                        parentNotifierHost = (NotifierHost)tvwNotifiers.SelectedNode.Parent.Tag;

                    SelectNewAgentType selectNewAgentType = new SelectNewAgentType();
                    if (selectNewAgentType.ShowNotifierSelection() == System.Windows.Forms.DialogResult.OK)
                    {
                        INotifier agent = (INotifier)selectNewAgentType.SelectedAgent;
                        if (agent.Name == null || agent.Name.Length == 0)
                            agent.Name = agent.AgentClassDisplayName;
                        agent.Enabled = true;
                        WinFormsUINotifierBase agentEditor = (WinFormsUINotifierBase)RegisteredAgentUIMapper.GetUIClass(agent);
                        if (agentEditor != null)
                        {
                            IAgentConfigEntryEditWindow detailEditor = agentEditor.DetailEditor;
                            detailEditor.SelectedEntry = agent.AgentConfig;
                            if (detailEditor.ShowEditEntry() == QuickMonDialogResult.Ok)
                            {
                                SetMonitorChanged();
                                agent.AgentConfig.FromXml(agent.AgentConfig.ToXml());
                                parentNotifierHost.NotifierAgents.Add(agent);
                                if (tvwNotifiers.SelectedNode.Tag is INotifier)
                                    tvwNotifiers.SelectedNode = tvwNotifiers.SelectedNode.Parent;
                                tvwNotifiers.SelectedNode.Nodes.Clear();
                                LoadNotifierAgents(tvwNotifiers.SelectedNode, parentNotifierHost);
                                DoAutoSave();
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is no registered UI editor for this type of agent yet! Please contact the creator of the agent type.", "Agent type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    #endregion
                }
                else
                {
                    #region create Notifier Host
                    NotifierHost newNotifierHost = new NotifierHost();
                    EditNotifierHost editNotifierHost = new EditNotifierHost();

                    if (Properties.Settings.Default.UseTemplatesForNewObjects && QuickMonTemplate.GetNotifierHostTemplates().Count > 0)
                    {
                        SelectTemplate selectTemplate = new SelectTemplate();
                        selectTemplate.FilterTemplatesBy = TemplateType.NotifierHost;
                        if (selectTemplate.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            newNotifierHost = NotifierHost.FromXml(selectTemplate.SelectedTemplate.Config);
                        }
                    }

                    if (editNotifierHost.ShowDialog(newNotifierHost, monitorPack) == System.Windows.Forms.DialogResult.OK)
                    {
                        SetMonitorChanged();
                        newNotifierHost.ReconfigureFromXml(editNotifierHost.SelectedConfig, monitorPack.ConfigVariables, true);
                        monitorPack.AddNotifierHost(newNotifierHost);

                        LoadNotifierNode(newNotifierHost);
                        DoAutoSave();
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "New Notifier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Properties.Settings.Default.PausePollingDuringEditConfig)
                ResumePolling();
        }
        private void EditNotifierConfig()
        {
            HideNotifierContextMenu();
            if (Properties.Settings.Default.PausePollingDuringEditConfig)
                PausePolling();
            try
            {                
                if (tvwNotifiers.SelectedNode != null && tvwNotifiers.Nodes[0] != tvwNotifiers.SelectedNode)
                {
                    NotifierHost notifierHost = null;
                    if (tvwNotifiers.SelectedNode.Tag is NotifierHost)
                    {
                        #region Edit Notifier Host
                        notifierHost = (NotifierHost)tvwNotifiers.SelectedNode.Tag;
                        EditNotifierHost editNotifierHost = new EditNotifierHost();
                        if (editNotifierHost.ShowDialog(notifierHost, monitorPack) == System.Windows.Forms.DialogResult.OK)
                        {
                            CloseNotifierHostViewers(notifierHost);
                            SetMonitorChanged();
                            notifierHost.ReconfigureFromXml(editNotifierHost.SelectedConfig, monitorPack.ConfigVariables, true);

                            if (tvwNotifiers.SelectedNode.Parent.Tag is NotifierHost)
                                tvwNotifiers.SelectedNode = tvwNotifiers.SelectedNode.Parent;
                            if (tvwNotifiers.SelectedNode.Tag is NotifierHost)
                            {
                                tvwNotifiers.SelectedNode.Text = notifierHost.Name;
                                tvwNotifiers.SelectedNode.Nodes.Clear();
                                LoadNotifierAgents(tvwNotifiers.SelectedNode, notifierHost);
                            }
                            DoAutoSave();
                        } 
                        #endregion
                    }
                    else if (tvwNotifiers.SelectedNode.Tag is INotifier)
                    {
                        #region Edit Notifier Agent
                        notifierHost = (NotifierHost)tvwNotifiers.SelectedNode.Parent.Tag;
                        INotifier agent = (INotifier)tvwNotifiers.SelectedNode.Tag;
                        WinFormsUINotifierBase agentEditor = (WinFormsUINotifierBase)RegisteredAgentUIMapper.GetUIClass(agent);
                        if (agentEditor != null)
                        {
                            IAgentConfigEntryEditWindow detailEditor = agentEditor.DetailEditor;
                            detailEditor.SelectedEntry = agent.AgentConfig;
                            if (detailEditor.ShowEditEntry() == QuickMonDialogResult.Ok)
                            {
                                CloseNotifierAgentViewer(agent);
                                SetMonitorChanged();
                                agent.AgentConfig.FromXml(agent.AgentConfig.ToXml());
                                DoAutoSave();
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is no registered UI editor for this type of agent yet! Please contact the creator of the agent type.", "Agent type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        } 
                        #endregion
                    }
                    RefreshNotifierAgents(notifierHost);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Properties.Settings.Default.PausePollingDuringEditConfig)
                ResumePolling();
        }
        private void DeleteNotifier()
        {
            HideNotifierContextMenu();
            if (Properties.Settings.Default.PausePollingDuringEditConfig)
                PausePolling();
            if (tvwNotifiers.SelectedNode != null && tvwNotifiers.Nodes[0] != tvwNotifiers.SelectedNode)
            {
                if (tvwNotifiers.SelectedNode.Tag is NotifierHost)
                {
                    if (MessageBox.Show("Are you sure you want to remove the selected notifier?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        SetMonitorChanged();
                        NotifierHost removedItem = (NotifierHost)tvwNotifiers.SelectedNode.Tag;
                        CloseNotifierHostViewers(removedItem);
                        monitorPack.NotifierHosts.Remove(removedItem);
                        tvwNotifiers.Nodes[0].Nodes.Remove(tvwNotifiers.SelectedNode);
                        RefreshMonitorPack(true, true);
                        DoAutoSave();
                    }
                }                
                else if (tvwNotifiers.SelectedNode.Tag is INotifier)
                {
                    if (MessageBox.Show("Are you sure you want to remove the selected notifier agent?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        SetMonitorChanged();
                        NotifierHost removedItem = (NotifierHost)tvwNotifiers.SelectedNode.Parent.Tag;
                        INotifier removedAgent = (INotifier)tvwNotifiers.SelectedNode.Tag;
                        CloseNotifierAgentViewer(removedAgent);
                        removedItem.NotifierAgents.Remove(removedAgent);
                        tvwNotifiers.SelectedNode.Parent.Nodes.Remove(tvwNotifiers.SelectedNode);
                        tvwNotifiers.SelectedNode = tvwNotifiers.SelectedNode.Parent;
                        RefreshMonitorPack(true, true);
                        DoAutoSave();
                    }
                }
            }
            if (Properties.Settings.Default.PausePollingDuringEditConfig)
                ResumePolling();
        }
        private void EnableDisableNotifier()
        {
            HideNotifierContextMenu();
            PausePolling();
            try
            {
                if (tvwNotifiers.SelectedNode != null && tvwNotifiers.Nodes[0] != tvwNotifiers.SelectedNode)
                {
                    if (tvwNotifiers.SelectedNode.Tag is NotifierHost)
                    {
                        SetMonitorChanged();
                        NotifierHost item = (NotifierHost)tvwNotifiers.SelectedNode.Tag;
                        item.Enabled = !item.Enabled;
                        if (item.Enabled)
                        {
                            tvwNotifiers.SelectedNode.ImageIndex = 1;
                        }
                        else
                        {
                            tvwNotifiers.SelectedNode.ImageIndex = 2;
                        }
                        tvwNotifiers.SelectedNode.SelectedImageIndex = tvwNotifiers.SelectedNode.ImageIndex;
                        DoAutoSave();
                    }
                    else if (tvwNotifiers.SelectedNode.Tag is INotifier)
                    {
                        SetMonitorChanged();
                        INotifier agent = (INotifier)tvwNotifiers.SelectedNode.Tag;
                        agent.Enabled = !agent.Enabled;
                        if (agent.Enabled)
                        {
                            if (RegisteredAgentUIMapper.HasAgentViewer(agent))
                                tvwNotifiers.SelectedNode.ImageIndex = 3;
                            else
                                tvwNotifiers.SelectedNode.ImageIndex = 4;
                        }
                        else
                        {
                            tvwNotifiers.SelectedNode.ImageIndex = 4;
                        }
                        tvwNotifiers.SelectedNode.SelectedImageIndex = tvwNotifiers.SelectedNode.ImageIndex;
                        DoAutoSave();
                    }
                }


                //if (lvwNotifiers.SelectedItems.Count == 1 && lvwNotifiers.SelectedItems[0].Tag is NotifierHost)
                //{
                //    SetMonitorChanged();
                //    ListViewItem lvi = lvwNotifiers.SelectedItems[0];
                //    NotifierHost notifierHost = (NotifierHost)lvi.Tag;
                //    notifierHost.Enabled = !notifierHost.Enabled;
                //    lvi.ForeColor = notifierHost.Enabled ? SystemColors.WindowText : Color.Gray;
                //    CheckNotifierContextMenuEnables();
                //    //if autosaving is enabled
                //    DoAutoSave();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ResumePolling();
        }
        #endregion

        #region Notifier Viewer actions
        private void ViewNotifierDetails()
        {
            HideNotifierContextMenu();
            if (tvwNotifiers.SelectedNode != null && tvwNotifiers.Nodes[0] != tvwNotifiers.SelectedNode && tvwNotifiers.SelectedNode.Tag is INotifier)
            {
                INotifier agent = (INotifier)tvwNotifiers.SelectedNode.Tag;
                CleanNotifierViewers();
                INotivierViewer currentNotivierViewer = (from v in agentDetailViews
                                                         where v.SelectedNotifier == agent
                                                         select v).FirstOrDefault();

                if (currentNotivierViewer == null)
                {
                    WinFormsUINotifierBase agentUI = RegisteredAgentUIMapper.GetNotifierUIClass(agent);
                    if (agentUI != null && agentUI.HasDetailView && agentUI.Viewer != null)
                    {
                        currentNotivierViewer = agentUI.Viewer;
                        currentNotivierViewer.SelectedNotifier = agent;
                        agentDetailViews.Add(currentNotivierViewer);
                    }
                }
                if (currentNotivierViewer != null)
                    currentNotivierViewer.ShowNotifierViewer();
            }
        }
        private void RefreshNotifierAgents(NotifierHost notifierHost)
        {
            CleanNotifierViewers();
            if (notifierHost != null)
            {
                foreach (INotifier agent in notifierHost.NotifierAgents)
                {
                    INotivierViewer currentNotivierViewer = (from v in agentDetailViews
                                                             where v.SelectedNotifier == agent
                                                             select v).FirstOrDefault();
                    if (currentNotivierViewer != null)
                    {
                        currentNotivierViewer.ShowNotifierViewer();
                    }
                }
            }
        }
        private void CleanNotifierViewers()
        {
            if (agentDetailViews == null)
            {
                agentDetailViews = new List<INotivierViewer>();
                //notifierDetailViews = new List<NotifierAgentListViewer>();
            }
            List<INotivierViewer> viewsToRemove = (from v in agentDetailViews
                                                   where !v.IsViewerStillVisible()
                                                   select v).ToList();
            foreach(INotivierViewer viewer in viewsToRemove)
            {
                agentDetailViews.Remove(viewer);
            }  
        }
        private void CloseAllNotifierViewers()
        {
            if (agentDetailViews == null)
            {
                agentDetailViews = new List<INotivierViewer>();
            }
            foreach (INotivierViewer viewer in (from v in agentDetailViews
                                                                   where v.IsViewerStillVisible()
                                                                   select v).ToList())
            {
                viewer.CloseViewer();
            }
            agentDetailViews = new List<INotivierViewer>();
        }
        private void CloseNotifierHostViewers(NotifierHost notifierHost)
        {
            CleanNotifierViewers();
            if (notifierHost != null)
            {
                foreach (INotifier agent in notifierHost.NotifierAgents)
                {
                    INotivierViewer currentNotivierViewer = (from v in agentDetailViews
                                                             where v.SelectedNotifier == agent
                                                             select v).FirstOrDefault();
                    if (currentNotivierViewer != null)
                    {
                        currentNotivierViewer.CloseViewer();
                    }
                }
            }
        }
        private void CloseNotifierAgentViewer(INotifier agent)
        {
            CleanNotifierViewers();
            if (agent != null)
            {
                INotivierViewer currentNotivierViewer = (from v in agentDetailViews
                                                         where v.SelectedNotifier == agent
                                                         select v).FirstOrDefault();
                if (currentNotivierViewer != null)
                {
                    currentNotivierViewer.CloseViewer();
                }
            }
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

                            if (cboRecentMonitorPacks.DropDownWidth < TextRenderer.MeasureText(entryDisplayName + "........", cboRecentMonitorPacks.Font).Width)
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
            else
            {
                LoadRecentMonitorPackList();
            }
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
            try
            {
                if (popperContainerForTreeView != null)
                    popperContainerForTreeView.Close();
            }
            catch { }
        }
        private void HideNotifierContextMenu()
        {
            try
            {
                if (popperContainerForListView != null)
                    popperContainerForListView.Close();
            }
            catch { }
        }
        private void CloseAllDetailWindows()
        {
            CloseAllCollectorStatusViews();
            CloseAllNotifierViewers();            
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
        private void SetUpContextMenus()
        {
            poppedContainerForTreeView.cmdCopy.Enabled = false;
            poppedContainerForTreeView.cmdPaste.Enabled = false;
            poppedContainerForTreeView.cmdPasteWithEdit.Enabled = false;
            poppedContainerForTreeView.cmdCopy.Click += cmdCopy_Click;
            poppedContainerForTreeView.cmdPaste.Click += cmdPaste_Click;
            poppedContainerForTreeView.cmdPasteWithEdit.Click += cmdPasteWithEdit_Click;
            poppedContainerForTreeView.cmdViewDetails.Click += cmdViewDetails_Click;
            poppedContainerForTreeView.cmdAddCollector.Click += new System.EventHandler(addCollectorToolStripMenuItem_Click);
            poppedContainerForTreeView.cmdEditCollector.Click += new System.EventHandler(editCollectorToolStripMenuItem_Click);
            poppedContainerForTreeView.cmdDisableCollector.Click += cmdDisableCollector_Click;
            poppedContainerForTreeView.cmdDeleteCollector.Click += new System.EventHandler(removeCollectorToolStripMenuItem_Click);

            poppedContainerForListView.cmdViewDetails.Click += cmdShowNortifierViewer_Click; 
            poppedContainerForListView.cmdAddNotifier.Click += cmdAddNotifier_Click;
            poppedContainerForListView.cmdEditNotifier.Click += cmdEditNotifier_Click;
            poppedContainerForListView.cmdDisableNotifier.Click += cmdDisableNotifier_Click;
            poppedContainerForListView.cmdDeleteNotifier.Click += cmdDeleteNotifier_Click;
        }

        private void CheckCollectorContextMenuEnables()
        {
            if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorHost)
            {
                CollectorHost entry = (CollectorHost)tvwCollectors.SelectedNode.Tag;

                poppedContainerForTreeView.cmdViewDetails.Enabled = true;
                poppedContainerForTreeView.cmdEditCollector.Enabled = true;
                poppedContainerForTreeView.cmdDeleteCollector.Enabled = true;
                poppedContainerForTreeView.cmdDisableCollector.Enabled = true;
                poppedContainerForTreeView.cmdDisableCollector.BackColor = entry.Enabled ? SystemColors.Control : Color.WhiteSmoke;
                poppedContainerForTreeView.cmdDisableCollector.Image = entry.Enabled ? global::QuickMon.Properties.Resources.ForbiddenBue16x16 : global::QuickMon.Properties.Resources.ForbiddenGray16x16;
                poppedContainerForTreeView.cmdDisableCollector.Text = entry.Enabled ? "Disable" : "Enable";                
                viewCollectorDetailsToolStripMenuItem.Enabled = true;                
                editCollectorToolStripMenuItem.Enabled = true;
                removeCollectorToolStripMenuItem1.Enabled = true;
                poppedContainerForTreeView.cmdCopy.Enabled = true;                
            }
            else
            {
                poppedContainerForTreeView.cmdViewDetails.Enabled = false;
                poppedContainerForTreeView.cmdEditCollector.Enabled = false;
                poppedContainerForTreeView.cmdDeleteCollector.Enabled = false;
                poppedContainerForTreeView.cmdDisableCollector.Enabled = false;
                viewCollectorDetailsToolStripMenuItem.Enabled = false;
                editCollectorToolStripMenuItem.Enabled = false;
                poppedContainerForTreeView.cmdDisableCollector.Image = global::QuickMon.Properties.Resources.ForbiddenGray16x16;
                poppedContainerForTreeView.cmdDisableCollector.Text = "Disable";
                removeCollectorToolStripMenuItem1.Enabled = false;
                poppedContainerForTreeView.cmdCopy.Enabled = false;
            }
            poppedContainerForTreeView.cmdPaste.Enabled = false;
            poppedContainerForTreeView.cmdPasteWithEdit.Enabled = false;
            if (Clipboard.ContainsText())
            {
                string clipboardTest = Clipboard.GetText().Trim(' ', '\r', '\n');
                if (clipboardTest.StartsWith("<collectorHosts>") && clipboardTest.EndsWith("</collectorHosts>"))
                {
                    try
                    {
                        //List<CollectorHost> pastedCollectorEntries = CollectorHost.GetCollectorEntriesFromString(clipboardTest);
                        poppedContainerForTreeView.cmdPaste.Enabled = true;
                        poppedContainerForTreeView.cmdPasteWithEdit.Enabled = true;
                        //copiedCollectorList = pastedCollectorEntries;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(ex.ToString());
                    }
                }
            }
        }
        private void CheckNotifierContextMenuEnables()
        {
            NotifierHost entry = null;
            INotifier agent = null;
            if (tvwNotifiers.SelectedNode != null && tvwNotifiers.Nodes[0] != tvwNotifiers.SelectedNode )
            {
                if (tvwNotifiers.SelectedNode.Tag is NotifierHost)
                {
                    entry = (NotifierHost)tvwNotifiers.SelectedNode.Tag;
                }
                else if (tvwNotifiers.SelectedNode.Parent.Tag is NotifierHost)
                {
                    entry = (NotifierHost)tvwNotifiers.SelectedNode.Parent.Tag;
                    agent = (INotifier)tvwNotifiers.SelectedNode.Tag;
                }  
            }  
            if (entry == null)
            {
                addNotifierToolStripMenuItem.Text = "Add Notifier";
                editNotifierToolStripMenuItem.Text = "Edit Notifier";
                removeNotifierToolStripMenuItem1.Text = "Delete Notifier";
                poppedContainerForListView.lblNotifierHeading.Text = "Notifier";
                poppedContainerForListView.cmdDisableNotifier.Image = global::QuickMon.Properties.Resources.ForbiddenBue16x16;
                poppedContainerForListView.cmdDisableNotifier.Text = "Disable";
                poppedContainerForListView.cmdAddNotifier.Text = "Add Notifier";
                poppedContainerForListView.cmdEditNotifier.Text = "Edit Notifier";
                poppedContainerForListView.cmdViewDetails.Text = "View";
                poppedContainerForListView.cmdDeleteNotifier.Text = "Delete Notifier";
            }
            else if (entry != null && agent == null)
            {
                addNotifierToolStripMenuItem.Text = "Add Notifier Agent";
                editNotifierToolStripMenuItem.Text = "Edit Notifier";
                removeNotifierToolStripMenuItem1.Text = "Delete Notifier";
                poppedContainerForListView.lblNotifierHeading.Text = "Notifier";
                poppedContainerForListView.cmdDisableNotifier.Image = entry.Enabled ? global::QuickMon.Properties.Resources.ForbiddenBue16x16 : global::QuickMon.Properties.Resources.ForbiddenGray16x16;
                poppedContainerForListView.cmdDisableNotifier.Text = entry.Enabled ? "Disable Notifier" : "Enable Notifier";
                poppedContainerForListView.cmdAddNotifier.Text = "Add Notifier Agent";
                poppedContainerForListView.cmdEditNotifier.Text = "Edit Notifier";
                poppedContainerForListView.cmdViewDetails.Text = "View";
                poppedContainerForListView.cmdDeleteNotifier.Text = "Delete Notifier";
            }
            else
            {
                addNotifierToolStripMenuItem.Text = "Add Notifier Agent";
                editNotifierToolStripMenuItem.Text = "Edit Notifier Agent";
                removeNotifierToolStripMenuItem1.Text = "Delete Notifier Agent";
                poppedContainerForListView.lblNotifierHeading.Text = "Notifier Agent";
                poppedContainerForListView.cmdDisableNotifier.Image = agent.Enabled ? global::QuickMon.Properties.Resources.ForbiddenBue16x16 : global::QuickMon.Properties.Resources.ForbiddenGray16x16;
                poppedContainerForListView.cmdDisableNotifier.Text = agent.Enabled ? "Disable Agent" : "Enable Agent";
                poppedContainerForListView.cmdAddNotifier.Text = "Add Agent";
                poppedContainerForListView.cmdEditNotifier.Text = "Edit Agent";
                poppedContainerForListView.cmdViewDetails.Text = "View Agent";
                poppedContainerForListView.cmdDeleteNotifier.Text = "Delete Agent";
            }

            editNotifierToolStripMenuItem.Enabled = entry != null;
            removeNotifierToolStripMenuItem1.Enabled = entry != null;
            viewNotifierAgentToolStripMenuItem.Enabled = agent != null && RegisteredAgentUIMapper.HasAgentViewer(agent);
            poppedContainerForListView.cmdDisableNotifier.Enabled = entry != null;
            poppedContainerForListView.cmdViewDetails.Enabled = agent != null && RegisteredAgentUIMapper.HasAgentViewer(agent);
            poppedContainerForListView.cmdEditNotifier.Enabled = entry != null;
            poppedContainerForListView.cmdDisableNotifier.Enabled = entry != null;
            poppedContainerForListView.cmdDeleteNotifier.Enabled = entry != null;
        }

        private void CopySelectedCollectorAndDependants()
        {
            if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorHost)
            {
                CollectorHost entry = (CollectorHost)tvwCollectors.SelectedNode.Tag;
                List<CollectorHost> sourceList = monitorPack.GetAllChildCollectorHosts(entry);
                copiedCollectorList = new List<CollectorHost>();
                copiedCollectorList.Add(entry.Clone());
                foreach (CollectorHost en in sourceList)
                {
                    //Copy as is with same IDs
                    copiedCollectorList.Add(en.Clone());
                }
                Clipboard.SetText(CollectorHost.CollectorHostListToString(copiedCollectorList));

                poppedContainerForTreeView.cmdPaste.Enabled = true;
                poppedContainerForTreeView.cmdPasteWithEdit.Enabled = true;
            }
        }
        private void PasteSelectedCollectorAndDependant(bool showEditList)
        {
            try
            {
                if (Clipboard.ContainsText() && Clipboard.GetText().StartsWith("<collectorHosts"))
                {
                    copiedCollectorList = CollectorHost.GetCollectorHostsFromString(Clipboard.GetText());
                }

                if (copiedCollectorList != null && copiedCollectorList.Count > 0)
                {
                    if (showEditList)
                    {
                        RAWXmlEditor editor = new RAWXmlEditor();
                        editor.SelectedMarkup = CollectorHost.CollectorHostListToString(copiedCollectorList);
                        if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            copiedCollectorList = CollectorHost.GetCollectorHostsFromString(editor.SelectedMarkup);
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

                        if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorHost)
                        {
                            copiedCollectorList[0].ParentCollectorId = ((CollectorHost)tvwCollectors.SelectedNode.Tag).UniqueId;
                        }
                        else
                            copiedCollectorList[0].ParentCollectorId = "";
                        CollectorHost rootChild = null;
                        for (int i = 0; i < copiedCollectorList.Count; i++)
                        {
                            CollectorHost newChild = copiedCollectorList[i].Clone();
                            if (rootChild == null)
                                rootChild = newChild;
                            monitorPack.AddCollectorHost(newChild);
                        }
                        TreeNode root = tvwCollectors.Nodes[0];
                        if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorHost)
                        {
                            root = tvwCollectors.SelectedNode;
                        }

                        LoadCollectorNode(root, rootChild);
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
        #endregion

        #region Context menu events
        private void showCollectorContextMenuTimer_Tick(object sender, EventArgs e)
        {
            showCollectorContextMenuTimer.Enabled = false;
            popperContainerForTreeView.Show(this, collectorContextMenuLaunchPoint);
        }
        private void showNotifierContextMenuTimer_Tick(object sender, EventArgs e)
        {
            showNotifierContextMenuTimer.Enabled = false;
            popperContainerForListView.Show(this, notifierContextMenuLaunchPoint);
        }
        private void cmdViewDetails_Click(object sender, EventArgs e)
        {
            ViewCollectorDetails();
        }
        private void cmdShowNortifierViewer_Click(object sender, EventArgs e)
        {
            ViewNotifierDetails();
        }
        private void cmdDisableCollector_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            try
            {
                if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag is CollectorHost)
                {
                    SetMonitorChanged();
                    CollectorHost entry = (CollectorHost)tvwCollectors.SelectedNode.Tag;
                    entry.Enabled = !entry.Enabled;
                    poppedContainerForTreeView.cmdDisableCollector.Text = entry.Enabled ? "Disable" : "Enable";
                    poppedContainerForTreeView.cmdDisableCollector.Image = entry.Enabled ? global::QuickMon.Properties.Resources.ForbiddenBue16x16 : global::QuickMon.Properties.Resources.ForbiddenGray16x16;
                    tvwCollectors.SelectedNode.ForeColor = entry.Enabled ? SystemColors.WindowText : Color.Gray;
                    if (!entry.Enabled)
                    {
                        tvwCollectors.SelectedNode.ImageIndex = collectorDisabled;
                        tvwCollectors.SelectedNode.SelectedImageIndex = collectorDisabled;
                    }
                    DoAutoSave();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdCopy_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            CopySelectedCollectorAndDependants();
        }
        private void cmdPaste_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            PasteSelectedCollectorAndDependant(false);
        }
        private void cmdPasteWithEdit_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            PasteSelectedCollectorAndDependant(true);
        }
        private void cmdAddNotifier_Click(object sender, EventArgs e)
        {
            CreateNewNotifier();
        }
        private void cmdEditNotifier_Click(object sender, EventArgs e)
        {
            EditNotifierConfig();
        }
        private void cmdDeleteNotifier_Click(object sender, EventArgs e)
        {
            DeleteNotifier();
        }
        private void cmdDisableNotifier_Click(object sender, EventArgs e)
        {
            EnableDisableNotifier();
        }
        #endregion

        #region Toolbar events
        private void newMonitorPackToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            InitializeBackgroundWorker();
            RefreshMonitorPack(true, true);
        }
        private void addCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            CreateNewCollector();
        }
        private void editCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            EditCollectorConfig();
        }        
        private void removeCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DeleteCollector();
        }
        private void viewCollectorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCollectorDetails();
        }
        private void addNotifierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateNewNotifier();
        }
        private void editNotifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNotifierConfig();
        }
        private void removeNotifierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteNotifier();
        }
        private void showDefaultNotifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewNotifierDetails();
        }
        private void closeAllChildWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllDetailWindows();
        }
        private void generalSettingsToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            HideCollectorContextMenu();
            PausePolling();            
            GeneralSettings generalSettings = new GeneralSettings();
            generalSettings.PollingFrequencySec = Properties.Settings.Default.PollFrequencySec;
            generalSettings.PollingEnabled = !isPollingPaused;
            if (generalSettings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadRecentMonitorPackList();
                this.SnappingEnabled = Properties.Settings.Default.MainFormSnap;
                if (monitorPack != null)
                    monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;

                Properties.Settings.Default.PollFrequencySec = generalSettings.PollingFrequencySec;
                isPollingPaused = !generalSettings.PollingEnabled;
            }

            ResumePolling();
        }
        private void pollingDisabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PausePolling();
        }
        private void pollingSlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetApplicationPollingFrequency(60);
        }
        private void pollingNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetApplicationPollingFrequency(30);
        }
        private void pollingFastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetApplicationPollingFrequency(5);
        }
        private void manageTemplatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editTemplates == null || !editTemplates.IsStillVisible())
                editTemplates = new EditTemplates();
            if (editTemplates.WindowState == FormWindowState.Minimized)
                editTemplates.WindowState = FormWindowState.Normal;
            editTemplates.Show();
            editTemplates.TopMost = true;
            editTemplates.TopMost = false;
        }
        private void restartInAdminModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PerformCleanShutdown(true))
                return;
            if (!HenIT.Security.AdminModeTools.IsInAdminMode())
            {
                Properties.Settings.Default.Save();
                HenIT.Security.AdminModeTools.RestartInAdminMode(AppGlobals.AppTaskId);
            }
            //Security.RestartInAdminMode(Application.ExecutablePath);
        }
        private void restartInNonAdminModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HenIT.Security.AdminModeTools.IsInAdminMode() && HenIT.Security.AdminModeTools.HasAdminMode())
            {
                Properties.Settings.Default.Save();
                HenIT.Security.AdminModeTools.RestartInNonAdminMode();
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutQuickMon aboutQuickMon = new AboutQuickMon();
            aboutQuickMon.ShowDialog();
        }
        #endregion

        #region Label clicks
        private void llblMonitorPack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditMonitorSettings();            
        }
        private void llblNotifierViewToggle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            masterSplitContainer.Panel2Collapsed = !masterSplitContainer.Panel2Collapsed;
            llblNotifierViewToggle.Text = masterSplitContainer.Panel2Collapsed ? "Show Notifiers" : "Hide Notifiers";
        }
        private void llblNotifierViewToggle_DoubleClick(object sender, EventArgs e)
        {
            llblNotifierViewToggle_LinkClicked(null, null);
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
                    if (Security.UACTools.IsInAdminMode())
                        MessageBox.Show(string.Format("Could not create performance counters! Please use a user account that has the proper rights.\r\nMore details{0}:", ex.Message), "Performance Counters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else //try launching in admin mode
                    {
                        MessageBox.Show("QuickMon 4 needs to restart in 'Admin' mode to set up its performance counters on this computer.", "Restart in Admin mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Properties.Settings.Default.Save();
                        Security.UACTools.RestartInAdminMode(Application.ExecutablePath);
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

        #region Auto refreshing timer
        private void autoRefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshMonitorPack();
        }
        private void PausePolling()
        {
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
        }
        private void ResumePolling(bool startImmediately = false)
        {
            if (autoRefreshTimer != null)
            {
                autoRefreshTimer.Enabled = false;
                autoRefreshTimer = null;
            }

            if (!isPollingPaused)
            {
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
            }
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
                isPollingPaused = true;            
        }
        #endregion

        #region Corrective Scripts
        private void RunCorrectiveScript(string scriptPath)
        {
            try
            {
                if (scriptPath.Contains("%"))
                {
                    scriptPath = Environment.ExpandEnvironmentVariables(scriptPath);
                }
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
                else
                    UpdateStatusbar(string.Format( "Could not find the corrective script {0}", scriptPath));
            }
            catch (Exception ex)
            {
                UpdateStatusbar("Corrective script error:" + ex.Message);
            }
        }
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

        private void label1_Click(object sender, EventArgs e)
        {
#if DEBUG
            //QuickMon.Forms.TestMenu tm = new Forms.TestMenu();
            //tm.Show();
#endif
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