using Microsoft.WindowsAPICodePack.Taskbar;
using MS.WindowsAPICodePack.Internal;
using QuickMon.UI;
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
    public partial class MainForm : FadeSnapForm, IParentWindow
    {
        public MainForm()
        {
            InitializeComponent();

            //try
            //{
            //    if (CoreHelpers.RunningOnWin7)
            //    {
            //        windowsTaskbar = TaskbarManager.Instance;
            //        // Set the application specific id
            //        windowsTaskbar.ApplicationId = Application.ProductName;                    
            //    }
            //}
            //catch { }
        }

        #region Private vars
        private MonitorPack monitorPack;
        private bool monitorPackChanged = false;
        private bool firstRefresh = true;
        private bool refreshCycleA = true;

        #region Copy and Paste of collector hosts
        private List<CollectorHost> copiedCollectorList = new List<CollectorHost>();
        #endregion

        #region Main timer
        private Timer autoRefreshTimer = new Timer() { Enabled = false, Interval = Properties.Settings.Default.PollFrequencySec * 1000 };
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
        private readonly int collectorOutOfServiceWindowstateImage = 9;
        #endregion

        #region Performance Counter Vars
        private string quickMonPCCategory = "QuickMon 5 UI Client";
        private PerformanceCounter collectorErrorStatePerSec = null;
        private PerformanceCounter collectorWarningStatePerSec = null;
        private PerformanceCounter collectorInfoStatePerSec = null;
        private PerformanceCounter collectorsQueriedPerSecond = null;
        private PerformanceCounter collectorsQueryTime = null;
        private PerformanceCounter selectedCollectorsQueryTime = null;
        #endregion

        private List<IChildWindowIdentity> childWindows = new List<IChildWindowIdentity>();

        #region JumpList
        //private string appId = "QuickMon";
        //private TaskbarManager windowsTaskbar;
        //private JumpList jumpList;
        //private JumpListCustomCategory jumplistCatTools = new JumpListCustomCategory("Quick Actions");
        #endregion
        #endregion

        public bool StartWithNewMonitorPack { get; set; }
        public bool StartWithSelectRecent { get; set; }

        #region Public methods
        public void SetMonitorChanged()
        {
            monitorPackChanged = true;
            UpdateAppTitle();
        }
        public void UpdateCollectorDisplayText(CollectorHost collectorHost)
        {
            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    if (collectorHost != null && collectorHost.Tag is TreeNodeEx)
                    {
                        Trace.WriteLine("Updating " + collectorHost.Name);

                        TreeNodeEx currentTreeNode = (TreeNodeEx)collectorHost.Tag;
                        try
                        {
                            if (currentTreeNode.Text != collectorHost.DisplayName)
                                currentTreeNode.Text = collectorHost.DisplayName;

                        }
                        catch { }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error " + collectorHost.Name + "->" + ex.Message);
                }
            });
        }
        public void UpdateCollector(CollectorHost collectorHost, bool setChanged = false)
        {
            monitorPack_CollectorHostStateUpdated(collectorHost);
            if (setChanged)
                SetMonitorChanged();
        }
        public void RefreshCollector(CollectorHost collectorHost)
        {
            if (collectorHost != null && collectorHost.Tag is TreeNodeEx)
            {
                TreeNode tn = (TreeNode)collectorHost.Tag;
                SetNodesToBeingRefreshed(tn);
                WaitForPollingToFinish(5);
                Cursor.Current = Cursors.WaitCursor;
                monitorPack.ForceCollectorHostRefreshState(collectorHost);
            }
        }
        public void ShowCollectorDetails(CollectorHost collectorHost)
        {
            if (collectorHost != null && collectorHost.Tag is TreeNodeEx)
            {
                TreeNode tn = (TreeNode)collectorHost.Tag;
                tvwCollectors.SelectedNode = tn;

                EditCollector();
            }
        }
        public void ShowCollectorGraph(List<CollectorHost> list)
        {
            if (list != null && list.Count > 0)
            {
                CollectorGraph cg = new CollectorGraph();
                cg.HostingMonitorPack = monitorPack;
                cg.SelectedCollectors = list;
                cg.Identifier = "CollectorGraph";
                cg.ShowChildWindow(this);
            }
        }
        #endregion

        #region Form events
        private void MainForm_Load(object sender, EventArgs e)
        {
            bool stickyLocationUsed = false;
            if (!StartWithNewMonitorPack && 
                Properties.Settings.Default.LastMonitorPack != null && 
                System.IO.File.Exists(Properties.Settings.Default.LastMonitorPack))
            {
                stickyLocationUsed = MPStickyLoad(Properties.Settings.Default.LastMonitorPack);
            }

            if (!stickyLocationUsed)
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
            }
            SnappingEnabled = Properties.Settings.Default.MainFormSnap;

            //Ξ
            if (Properties.Settings.Default.ShowMenuOnStart)
                ToggleMenuSize();
            collectorQuickToolStrip.Visible = Properties.Settings.Default.MainWindowCollectorQuickToolbarVisible;
            notifierQuickToolStrip.Visible = Properties.Settings.Default.MainWindowCollectorQuickToolbarVisible;

            SetCollectorTreeViewProperties();
            tvwNotifiers.FullRowSelect = true;
            tvwNotifiers.FullRowSelect = false;
            masterSplitContainer.Panel2Collapsed = true;
            Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.LabelText = string.Format("v{0}.{1}.{2}", v.Major, v.Minor, v.Build);
            lblCollectors.LabelText = "Collectors";
            lblNotifiers.LabelText = "Notifiers";
            UpdateNotifiersLabel();
            cboRecentMonitorPacks.Dock = DockStyle.Left;
            cboRecentMonitorPacks.Visible = false;
            pollingToolStripMenuItem.Visible = false;
            adminModeToolStripStatusLabel.Visible = Security.UACTools.IsInAdminMode();
            adminModeToolStripMenuItem.Visible = !Security.UACTools.IsInAdminMode();
            cmdAdminMode.Visible = !Security.UACTools.IsInAdminMode();

            //if (StartWithSelectRecent)
            //{
            //    SelectRecentMonitorPackDialog selectRecentMonitorPackDialog = new SelectRecentMonitorPackDialog();
            //    if (selectRecentMonitorPackDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        Properties.Settings.Default.LastMonitorPack = selectRecentMonitorPackDialog.SelectedMonitorPack;
            //    }                
            //}
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            CreateJumplist();
            try
            {
                InitializeGlobalPerformanceCounters();
                if (!StartWithNewMonitorPack && Properties.Settings.Default.LastMonitorPack != null && System.IO.File.Exists(Properties.Settings.Default.LastMonitorPack))
                {
                    LoadMonitorPack(Properties.Settings.Default.LastMonitorPack);
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

        private static void CreateJumplist()
        {
            try
            {
                if (TaskbarManager.IsPlatformSupported)
                {
                    JumpList recentJumpList = null;
                    JumpList frequentJumpList = null;
                    JumpList jumpList = null;

                    TaskbarManager.Instance.ApplicationId = Application.ProductName;

                    JumpListCustomCategory jumplistCatTools = new JumpListCustomCategory("Quick Actions");
                    jumpList = JumpList.CreateJumpList();
                    jumpList.AddCustomCategories(jumplistCatTools);
                    jumplistCatTools.AddJumpListItems(new JumpListLink(Application.ExecutablePath, "New Monitor pack")
                    {
                        IconReference = new Microsoft.WindowsAPICodePack.Shell.IconReference(Application.ExecutablePath, 0),
                        Arguments = "-new"
                    });
                    jumplistCatTools.AddJumpListItems(new JumpListLink(Application.ExecutablePath, "Select recent Monitor pack")
                    {
                        IconReference = new Microsoft.WindowsAPICodePack.Shell.IconReference(Application.ExecutablePath, 0),
                        Arguments = "-selectrecent"
                    });

                    jumpList.AddUserTasks(new JumpListSeparator());
                    jumpList.KnownCategoryOrdinalPosition = 1;
                    if (Properties.Settings.Default.UseFrequentJumpList)
                        jumpList.KnownCategoryToDisplay = JumpListKnownCategoryType.Frequent;
                    else
                        jumpList.KnownCategoryToDisplay = JumpListKnownCategoryType.Recent;
                    jumpList.Refresh();
                }
            }
            catch { }
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
                else if (e.KeyCode == Keys.S)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    splitButtonSave_ButtonClicked(null, null);
                }
                else if (e.KeyCode == Keys.R)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    ShowRecentMonitorPacksWindow();
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
                else if (e.KeyCode == Keys.T)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    ShowTemplates();
                }
                else if (e.KeyCode == Keys.D1)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    Properties.Settings.Default.MainWindowCollectorQuickToolbarVisible = !Properties.Settings.Default.MainWindowCollectorQuickToolbarVisible;
                    collectorQuickToolStrip.Visible = Properties.Settings.Default.MainWindowCollectorQuickToolbarVisible;
                    notifierQuickToolStrip.Visible = Properties.Settings.Default.MainWindowCollectorQuickToolbarVisible;
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
            {
                MPStickySave();
                monitorPack.CloseMonitorPack();
            }
            PerformCleanShutdown();
        }
        #endregion

        #region Menu
        private void cmdMenu_Click(object sender, EventArgs e)
        {
            ToggleMenuSize();
        }
        private void cmdNew_Click(object sender, EventArgs e)
        {
            //CloseAllDetailWindows();
            CloseAllMPDetailWindows();
            NewMonitorPack();
        }
        private void cmdOpen_Click(object sender, EventArgs e)
        {
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
                    //CloseAllDetailWindows();
                    CloseAllMPDetailWindows();
                    LoadMonitorPack(openFileDialogOpen.FileName);
                    RefreshMonitorPack(true, true);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Open", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void splitButtonRecent_ButtonClicked(object sender, EventArgs e)
        {
            ShowRecentMonitorPackDropdown();
        }
        private void splitButtonRecent_SplitButtonClicked(object sender, EventArgs e)
        {
            recentMPContextMenuStrip.Show(splitButtonRecent, new Point(splitButtonRecent.Width, 0));
        }
        private void splitButtonSave_SplitButtonClicked(object sender, EventArgs e)
        {
            saveContextMenuStrip.Show(splitButtonSave, new Point(splitButtonSave.Width, 0));
        }
        private void splitButtonCollectors_SplitButtonClicked(object sender, EventArgs e)
        {
            collectorsContextMenuStrip.Show(splitButtonCollectors, new Point(splitButtonCollectors.Width, 0));
        }
        private void fullRecentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectRecentMonitorPackDialog selectRecentMonitorPackDialog = new SelectRecentMonitorPackDialog();
            if (selectRecentMonitorPackDialog.ShowDialog() == DialogResult.OK)
            {
                LoadMonitorPack(selectRecentMonitorPackDialog.SelectedMonitorPack);
                RefreshMonitorPack(true, true);
            }
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
        private void cmdSettings_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }
        private void splitButtonTools_ButtonClicked(object sender, EventArgs e)
        {
            GeneralSettings generalSettings = new GeneralSettings();
            if (generalSettings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CreateJumplist();
                LoadRecentMonitorPackList();
                this.SnappingEnabled = Properties.Settings.Default.MainFormSnap;
                if (monitorPack != null)
                    monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
                SetCollectorTreeViewProperties();
            }
        }
        private void splitButtonTools_SplitButtonClicked(object sender, EventArgs e)
        {
            //settingsContextMenuStrip.Show(splitButtonTools, new Point(splitButtonTools.Width, 0));
        }
        private void templatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IChildWindowIdentity childWindow = GetChildWindowByIdentity("TemplateEditor");
            if (childWindow == null)
            {
                TemplateEditor templateEditor = new TemplateEditor();
                templateEditor.Identifier = "TemplateEditor";
                //templateEditor.ParentWindow = this;
                templateEditor.ShowChildWindow(this);
                templateEditor.RefreshDetails();
            }
            else
            {
                Form childForm = ((Form)childWindow);
                if (childForm.WindowState == FormWindowState.Minimized)
                    childForm.WindowState = FormWindowState.Normal;
                childForm.Focus();
                childWindow.RefreshDetails();
            }
        }
        private void adminModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PerformCleanShutdown(true))
                return;
            if (!HenIT.Security.AdminModeTools.IsInAdminMode())
            {
                Properties.Settings.Default.Save();
                HenIT.Security.AdminModeTools.RestartInAdminMode(AppGlobals.AppTaskId);
            }
        }
        private void cmdTemplates_Click(object sender, EventArgs e)
        {
            ShowTemplates();
        }
        private void cmdRemoteHosts_Click(object sender, EventArgs e)
        {            
            IChildWindowIdentity childWindow = GetChildWindowByIdentity("RemoteAgentHostManagement");
            if (childWindow == null) {
                RemoteAgentHostManagement newRemoteAgentHostManagement = new RemoteAgentHostManagement();
                newRemoteAgentHostManagement.Identifier = "RemoteAgentHostManagement";
                //newRemoteAgentHostManagement.ParentWindow = this;
                newRemoteAgentHostManagement.ShowChildWindow(this);
                newRemoteAgentHostManagement.RefreshDetails();
            }
            else
            {
                Form childForm = ((Form)childWindow);
                if (childForm.WindowState == FormWindowState.Minimized)
                    childForm.WindowState = FormWindowState.Normal;
                childForm.Focus();
                childWindow.RefreshDetails();
            }
        }
        private void cmdAbout_Click(object sender, EventArgs e)
        {
            try
            {
                AboutQuickMon aboutQuickMon = new AboutQuickMon();
                aboutQuickMon.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdAdminMode_Click(object sender, EventArgs e)
        {
            StartAdminMode();
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
            InitializeBackgroundWorker();
            RefreshMonitorPack(true, true);
        }
        #endregion

        #region Labels
        private void llblMonitorPack_Click(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.MouseEventArgs)e).Button == MouseButtons.Right)
            {
                ShowRecentMonitorPackDropdown();
            }
        }    
         private void llblMonitorPack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditMonitorSettings();
        }
        private void lblCollectors_Click(object sender, EventArgs e)
        {
            tvwCollectors.SelectedNode = null;
        }          
        private void llblNotifierViewToggle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            masterSplitContainer.Panel2Collapsed = !masterSplitContainer.Panel2Collapsed;
            if (!masterSplitContainer.Panel2Collapsed && masterSplitContainer.Height > 300)
            {
                masterSplitContainer.SplitterDistance = masterSplitContainer.Height - 200;
            }
            UpdateNotifiersLabel();
        }
        private void llblNotifierViewToggle_DoubleClick(object sender, EventArgs e)
        {
            masterSplitContainer.Panel2Collapsed = !masterSplitContainer.Panel2Collapsed;
            UpdateNotifiersLabel();
        }
        private void lblNotifiers_Click(object sender, EventArgs e)
        {
            tvwNotifiers.SelectedNode = null;
        }
        #endregion

        #region Collector and Notifier Context menus
        private void collectorsContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            SetCollectorMenuItemStates();
        }
        private void notifiersContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            SetNotifierMenuItemStates();
        }
        private void addCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode parentNode = tvwCollectors.SelectedNode;
            CollectorHost newCh = null;
            bool editAfterCreation = false;
            if (Properties.Settings.Default.UseTemplatesForNewObjects)
            {
                SelectNewEntityType newType = new SelectNewEntityType();
                newType.ShowEditAfterCreation = true;
                newType.ShowRAWEditing = Properties.Settings.Default.EnableRawEditing;
                if (newType.ShowCollectorHostSelection() == DialogResult.OK)
                {
                    editAfterCreation = newType.EditAfterCreation;
                    if (newType.SelectedCollectorHost != null)
                        newCh = newType.SelectedCollectorHost;
                    else
                        newCh = new CollectorHost() { Name = "Folder" };
                }
            }
            else
            {
                newCh = new CollectorHost() { Name = "Folder" };
            }
            if (newCh != null)
            {
                if (parentNode != null)
                {
                    newCh.ParentCollectorId = ((CollectorHost)(parentNode.Tag)).UniqueId;
                }
                else
                    newCh.ParentCollectorId = "";
                monitorPack.AddCollectorHost(newCh);
                LoadCollectorNode(parentNode, newCh);
                tvwCollectors.SelectedNode = (TreeNodeEx)newCh.Tag;
                if (parentNode != null)
                    UpdateParentFolderNode((TreeNodeEx)parentNode);
                if (editAfterCreation)
                    EditCollector(true);

                SetMonitorChanged();
                DoAutoSave();
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCollector();            
        }
        private void disableCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvwCollectors.SelectedNode;
            if (currentNode != null && currentNode.Tag is CollectorHost)
            {
                CollectorHost ch = (CollectorHost)currentNode.Tag;
                ch.Enabled = !ch.Enabled;
                UpdateCollector(ch, true);
                DoAutoSave();
            }                
        }
        private void graphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvwCollectors.SelectedNode;
            if (currentNode != null && currentNode.Tag is CollectorHost)
            {
                CollectorHost ch = (CollectorHost)currentNode.Tag;
                List<CollectorHost> collectors = new List<CollectorHost>();
                collectors.Add(ch);
                ShowCollectorGraph(collectors);
            }
        }
        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCollector();
        }
        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCollector(true);
        }
        private void copyCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopySelectedCollectorAndDependants();
        }
        private void pasteCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteSelectedCollectorAndDependant(false);
        }
        private void pasteAndEditCollectorConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteSelectedCollectorAndDependant(true);
        }
        private void historyToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportSelectedCollectorHistoryToCSV();
        }
        private void allHistoryToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportAllCollectorsHistoryToCSV();
        }
        private void collectorHistoryToXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportSelectedCollectorHistoryToXML();
        }
        private void allHistoryToXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportAllCollectorsHistoryToXML();
        }
        private void globalHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowGlobalHistory();
        }
        private void viewByFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCollectorFilterView();
        }
        private void addNotifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNotifier();
        }
        private void editNotifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNotifier();
        }
        private void deleteNotifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteNotifier();
        }
        private void enableNotifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableDisableNotifier();
        }        
        private void viewNotifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewNotifierDetails();
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
                Properties.Settings.Default.ShowMenuOnStart = (panelSlimMenu.Width != 45);
                Properties.Settings.Default.Save();
            }
            catch { }
            return notAborted;
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
        private void SetCollectorTreeViewProperties()
        {
            if (Properties.Settings.Default.MainWindowTreeViewExtraColumnSize > 0)
                tvwCollectors.ExtraColumnWidth = Properties.Settings.Default.MainWindowTreeViewExtraColumnSize;
            else
                tvwCollectors.ExtraColumnWidth = 100;
            tvwCollectors.ExtraColumnTextAlign = Properties.Settings.Default.MainWindowTreeViewExtraColumnTextAlign == 1 ? QuickMon.Controls.TreeViewExExtraColumnTextAlign.Right : QuickMon.Controls.TreeViewExExtraColumnTextAlign.Left;
            tvwCollectors.Refresh();
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

                string output = "";
                try
                {
                    output = CollectorHost.CollectorHostListToString(copiedCollectorList).BeautifyXML();
                    Application.DoEvents();
                    Clipboard.SetText(output);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Error formatting xml\r\nMessage: {0}\r\nData: {1}", ex.Message, output), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                try
                {
                    output = CollectorHost.CollectorHostListToString(copiedCollectorList).BeautifyXML();
                    try
                    {
                        Clipboard.SetText(output);
                    }
                    catch
                    {
                        try
                        {
                            Application.DoEvents();
                            Clipboard.SetText(output);
                        }
                        catch { }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Error formatting xml\r\nMessage: {0}\r\nData: {1}", ex.Message, output), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void PasteSelectedCollectorAndDependant(bool showEditList)
        {
            try
            {
                TreeNodeEx currentlySelected = (TreeNodeEx)(tvwCollectors.SelectedNode);
                if (Clipboard.ContainsText() && Clipboard.GetText().ContainsCaseInsensitive("<collectorHosts"))
                {
                    copiedCollectorList = CollectorHost.GetCollectorHostsFromString(Clipboard.GetText());
                }

                if (copiedCollectorList != null && copiedCollectorList.Count > 0)
                {
                    if (showEditList)
                    {
                        RAWXmlEditor editor = new RAWXmlEditor();
                        editor.SelectedMarkup = CollectorHost.CollectorHostListToString(copiedCollectorList);
                        if (editor.ShowDialog() == DialogResult.OK)
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

                        if (currentlySelected != null && currentlySelected.Tag != null && currentlySelected.Tag is CollectorHost)
                        {
                            copiedCollectorList[0].ParentCollectorId = ((CollectorHost)currentlySelected.Tag).UniqueId;
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
                        TreeNodeEx root = null;
                        if (currentlySelected != null && currentlySelected.Tag != null && currentlySelected.Tag is CollectorHost)
                        {
                            root = currentlySelected;
                        }                        

                        LoadCollectorNode(root, rootChild);
                        UpdateParentFolderNode(root);
                        if (root != null)
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
        private void ShowRecentMonitorPackDropdown()
        {
            cboRecentMonitorPacks.Visible = true;
            llblMonitorPack.Visible = false;
            cboRecentMonitorPacks.Dock = DockStyle.Fill;
            LoadRecentMonitorPackList();
            cboRecentMonitorPacks.Focus();
            SendKeys.Send("{F4}");
        }
        private void EditCollector(bool editmode = false)
        {
            if (tvwCollectors.SelectedNode != null)
            {
                TreeNode collectorNode = tvwCollectors.SelectedNode;
                if (collectorNode.Tag != null && collectorNode.Tag is CollectorHost)
                {
                    CollectorHost ch = (CollectorHost)collectorNode.Tag;
                    IChildWindowIdentity childWindow = GetChildWindowByIdentity(ch.UniqueId);
                    if (childWindow == null)
                    {
                        CollectorDetails collectorDetails = new CollectorDetails();
                        collectorDetails.SelectedCollectorHost = ch;
                        collectorDetails.Identifier = ch.UniqueId;
                        collectorDetails.StartWithEditMode = editmode;
                        collectorDetails.ShowChildWindow(this);
                    }
                    else
                    {
                        Form childForm = ((Form)childWindow);
                        if (childForm.WindowState == FormWindowState.Minimized)
                            childForm.WindowState = FormWindowState.Normal;
                        childForm.Focus();
                        if (editmode)
                            ((CollectorDetails)childForm).StartEditMode();
                    }
                }
            }
        }
        private void ShowGlobalHistory()
        {
            if (monitorPack != null)
            {
                IChildWindowIdentity childWindow = GetChildWindowByIdentity("GlobalAgentHistory");
                if (childWindow == null)
                {
                    GlobalAgentHistory globalAgentHistory = new GlobalAgentHistory();
                    globalAgentHistory.HostingMonitorPack = monitorPack;
                    globalAgentHistory.Identifier = "GlobalAgentHistory";
                    globalAgentHistory.ShowChildWindow(this);
                }
                else
                {
                    Form childForm = ((Form)childWindow);
                    if (childForm.WindowState == FormWindowState.Minimized)
                        childForm.WindowState = FormWindowState.Normal;
                    childForm.Focus();                    
                }
            }
        }
        private void ShowCollectorFilterView()
        {
            if (monitorPack != null)
            {
                IChildWindowIdentity childWindow = GetChildWindowByIdentity("CollectorFilterView");
                if (childWindow == null)
                {
                    CollectorFilterView collectorFilterView = new CollectorFilterView();
                    collectorFilterView.HostingMonitorPack = monitorPack;
                    collectorFilterView.Identifier = "CollectorFilterView";
                    collectorFilterView.ShowChildWindow(this);
                }
                else
                {
                    Form childForm = ((Form)childWindow);
                    if (childForm.WindowState == FormWindowState.Minimized)
                        childForm.WindowState = FormWindowState.Normal;
                    childForm.Focus();
                }
            }
        }
        private void DeleteCollector()
        {
            TreeNode currentNode = tvwCollectors.SelectedNode;
            if (currentNode != null && currentNode.Tag is CollectorHost)
            {
                if (MessageBox.Show("Are you sure you want to remove this collector (and all possible dependants)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    SetMonitorChanged();
                    RemoveCollector(currentNode);
                    RefreshMonitorPack(true, true);
                    if (currentNode.Parent != null)
                    {
                        TreeNodeEx parent = (TreeNodeEx)currentNode.Parent;
                        parent.Nodes.Remove(currentNode);
                        UpdateParentFolderNode(parent);
                    }
                    else
                    {
                        tvwCollectors.Nodes.Remove(currentNode);
                    }
                    SetMonitorChanged();
                    DoAutoSave();
                }
            }
        }
        private void ViewNotifierDetails()
        {
            if (tvwNotifiers.SelectedNode != null && tvwNotifiers.SelectedNode.Tag is INotifier && 
               tvwNotifiers.SelectedNode.Parent != null && tvwNotifiers.SelectedNode.Parent.Tag != null && tvwNotifiers.SelectedNode.Parent.Tag is NotifierHost)
            {
                INotifier agent = (INotifier)tvwNotifiers.SelectedNode.Tag;
                NotifierHost nh = (NotifierHost)tvwNotifiers.SelectedNode.Parent.Tag;                

                IChildWindowIdentity childWindow = GetChildWindowByIdentity(agent.RunTimeUniqueId);
                if (childWindow == null)
                {
                    WinFormsUINotifierBase agentUI = RegisteredAgentUIMapper.GetNotifierUIClass(agent);
                    if (agentUI != null && agentUI.HasDetailView && agentUI.Viewer != null)
                    {
                        agentUI.Viewer.SelectedNotifier = agent;
                        childWindow = (IChildWindowIdentity)agentUI.Viewer;
                        ((INotivierViewer)childWindow).SelectedNotifier = agent;
                        childWindow.Identifier = agent.RunTimeUniqueId;
                        //childWindow.ParentWindow = this;
                        childWindow.ShowChildWindow(this);
                    }
                }
                else
                {
                    Form childForm = ((Form)childWindow);
                    if (childForm.WindowState == FormWindowState.Minimized)
                        childForm.WindowState = FormWindowState.Normal;
                    childForm.Focus();
                }                
            }
        }
        private void AddNotifier()
        {
            TreeNode parentNode = tvwNotifiers.SelectedNode;
            SelectNewEntityType newType = new SelectNewEntityType();
            newType.ShowEditAfterCreation = true;
            newType.ShowRAWEditing = Properties.Settings.Default.EnableRawEditing;
            if (parentNode == null)
            {
                NotifierHost newNh = null;
                if (Properties.Settings.Default.UseTemplatesForNewObjects)
                {
                    if (newType.ShowNotifierHostSelection() == DialogResult.OK)
                    {
                        if (newType.SelectedNotifierHost != null)
                            newNh = newType.SelectedNotifierHost;
                        else
                            newNh = NotifierHost.FromXml("<notifierHost name=\"Default Notifier\" enabled=\"True\" alertLevel=\"Warning\" detailLevel=\"Detail\" attendedOptionOverride=\"OnlyAttended\"><notifierAgents><notifierAgent name=\"Memory agent\" type=\"QuickMon.Notifiers.InMemoryNotifier\" enabled=\"True\"><config><inMemory maxEntryCount=\"99999\" /></config></notifierAgent></notifierAgents></notifierHost>");
                    }
                }
                else
                {
                    newNh = NotifierHost.FromXml("<notifierHost name=\"Default Notifier\" enabled=\"True\" alertLevel=\"Warning\" detailLevel=\"Detail\" attendedOptionOverride=\"OnlyAttended\"><notifierAgents><notifierAgent name=\"Memory agent\" type=\"QuickMon.Notifiers.InMemoryNotifier\" enabled=\"True\"><config><inMemory maxEntryCount=\"99999\" /></config></notifierAgent></notifierAgents></notifierHost>");
                }
                if (newNh != null)
                {
                    monitorPack.AddNotifierHost(newNh);
                    LoadNotifierNode(newNh);
                    tvwNotifiers.SelectedNode = (TreeNodeEx)newNh.Tag;
                    if (newType.EditAfterCreation)
                        EditNotifier();
                    SetMonitorChanged();
                    DoAutoSave();
                }                
            }
            else if (parentNode.Tag is NotifierHost)
            {
                NotifierHost parentNh = (NotifierHost)parentNode.Tag;
                if (newType.ShowNotifierAgentSelection() == DialogResult.OK)
                {
                    IAgent newNa = newType.SelectedAgent;
                    if (newNa != null)
                    {
                        newNa.Enabled = true;
                        if (newNa.Name == null || newNa.Name.Trim().Length == 0)
                            newNa.Name = newNa.AgentClassDisplayName;

                        parentNh.NotifierAgents.Add((INotifier)newNa);
                        LoadNotifierAgents(parentNode, parentNh);

                        if (newType.EditAfterCreation)
                            EditNotifier();
                        SetMonitorChanged();
                        DoAutoSave();
                    }
                }
            }           
        }
        private void EditNotifier()
        {
            if (tvwNotifiers.SelectedNode != null && tvwNotifiers.SelectedNode.Tag is NotifierHost)
            {
                NotifierHost notifierHost = (NotifierHost)tvwNotifiers.SelectedNode.Tag;
                EditNotifierHost editNotifierHost = new EditNotifierHost();
                if (editNotifierHost.ShowDialog(notifierHost, monitorPack) == DialogResult.OK)
                {
                    foreach(INotifier agent in notifierHost.NotifierAgents)
                    {
                        IChildWindowIdentity childWindow = GetChildWindowByIdentity(agent.RunTimeUniqueId);
                        if (childWindow != null)
                        {
                            Form childForm = ((Form)childWindow);
                            childForm.Close();
                        }
                    }
                    SetMonitorChanged();
                    notifierHost.ReconfigureFromXml(editNotifierHost.SelectedConfig);
                    if (tvwNotifiers.SelectedNode.Tag is NotifierHost)
                    {
                        tvwNotifiers.SelectedNode.Text = notifierHost.Name;
                        tvwNotifiers.SelectedNode.Nodes.Clear();
                        LoadNotifierAgents(tvwNotifiers.SelectedNode, notifierHost);
                        SetNotifierEnableIcon(tvwNotifiers.SelectedNode);
                    }
                    DoAutoSave();
                }
            }
            else if (tvwNotifiers.SelectedNode != null && tvwNotifiers.SelectedNode.Tag is INotifier &&
               tvwNotifiers.SelectedNode.Parent != null && tvwNotifiers.SelectedNode.Parent.Tag != null && tvwNotifiers.SelectedNode.Parent.Tag is NotifierHost)
            {
                INotifier agent = (INotifier)tvwNotifiers.SelectedNode.Tag;
                WinFormsUINotifierBase agentEditor = RegisteredAgentUIMapper.GetNotifierUIClass(agent);
                if (agentEditor != null && agentEditor.DetailEditor != null) // agentEditor.HasDetailView && agentEditor.Viewer != null)
                {
                    IAgentConfigEntryEditWindow detailEditor = agentEditor.DetailEditor;
                    detailEditor.SelectedEntry = agent.AgentConfig;
                    if (detailEditor.ShowEditEntry() == QuickMonDialogResult.Ok)
                    {
                        SetMonitorChanged();
                        agent.AgentConfig.FromXml(detailEditor.SelectedEntry.ToXml());
                        tvwNotifiers.SelectedNode.Tag = agent;
                        DoAutoSave();
                    }
                }
            }

        }
        private void DeleteNotifier()
        {
            TreeNode currentNode = tvwNotifiers.SelectedNode;
            if (currentNode != null)
            {
                if (currentNode.Tag is NotifierHost)
                {
                    if (MessageBox.Show("Are you sure you want to remove this notifier?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        NotifierHost ce = (NotifierHost)currentNode.Tag;
                        monitorPack.NotifierHosts.Remove(ce);
                        tvwNotifiers.Nodes.Remove(currentNode);
                        SetMonitorChanged();
                        DoAutoSave();
                    }
                }
                else if (currentNode.Tag is INotifier)
                {
                    if (MessageBox.Show("Are you sure you want to remove this notifier agent?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        INotifier agent = (INotifier)currentNode.Tag;
                        TreeNode parentNode = currentNode.Parent;
                        if (parentNode.Tag is NotifierHost)
                        {
                            NotifierHost ce = (NotifierHost)parentNode.Tag;
                            ce.NotifierAgents.Remove(agent);
                            parentNode.Nodes.Remove(currentNode);
                            SetMonitorChanged();
                            DoAutoSave();
                        }
                    }
                }
            }
        }
        private void EnableDisableNotifier()
        {
            TreeNode currentNode = tvwNotifiers.SelectedNode;
            if (currentNode != null)
            {
                if (currentNode.Tag is NotifierHost)
                {
                    NotifierHost ce = (NotifierHost)currentNode.Tag;
                    ce.Enabled = !ce.Enabled;
                }
                else if (currentNode.Tag is INotifier)
                {
                    INotifier agent = (INotifier)currentNode.Tag;
                    agent.Enabled = !agent.Enabled;
                }
                SetNotifierEnableIcon(currentNode);
                SetMonitorChanged();
                DoAutoSave();
            }
        }
        private void SetNotifierEnableIcon(TreeNode currentNode)
        {
            if (currentNode != null)
            {
                if (currentNode.Tag is NotifierHost)
                {
                    NotifierHost ce = (NotifierHost)currentNode.Tag;
                    if (ce.Enabled)
                    {
                        currentNode.ImageIndex = 1;
                    }
                    else
                    {
                        currentNode.ImageIndex = 2;
                    }
                    currentNode.SelectedImageIndex = currentNode.ImageIndex;
                }
                else if (currentNode.Tag is INotifier)
                {
                    INotifier agent = (INotifier)currentNode.Tag;
                    if (UI.RegisteredAgentUIMapper.HasAgentViewer(agent) && agent.Enabled)
                        currentNode.ImageIndex = 3;
                    else
                        currentNode.ImageIndex = 4;
                    currentNode.SelectedImageIndex = currentNode.ImageIndex;
                }
            }
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
                splitButtonRecent.ButtonText = "";
                cmdSettings.Text = "";
                cmdTemplates.Text = "";                
                cmdRemoteHosts.Text = "";
                cmdAbout.Text = "";
                cmdAdminMode.Text = "";
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
                splitButtonRecent.ButtonText = " Recent";
                cmdSettings.Text = " Settings";
                cmdTemplates.Text = " Templates";                
                cmdRemoteHosts.Text = " Remote Hosts";
                cmdAbout.Text = " About";
                cmdAdminMode.Text = " Admin Mode";
            }
        }
        private void ShowTemplates()
        {
            IChildWindowIdentity childWindow = GetChildWindowByIdentity("TemplateEditor");
            if (childWindow == null)
            {
                TemplateEditor templateEditor = new TemplateEditor();
                templateEditor.Identifier = "TemplateEditor";
                templateEditor.ShowChildWindow(this);
                templateEditor.RefreshDetails();
            }
            else
            {
                Form childForm = ((Form)childWindow);
                if (childForm.WindowState == FormWindowState.Minimized)
                    childForm.WindowState = FormWindowState.Normal;
                childForm.Focus();
                childWindow.RefreshDetails();
            }
        }
        private void StartAdminMode()
        {
            if (!PerformCleanShutdown(true))
                return;
            if (!HenIT.Security.AdminModeTools.IsInAdminMode())
            {
                Properties.Settings.Default.Save();
                HenIT.Security.AdminModeTools.RestartInAdminMode(AppGlobals.AppTaskId);
            }
        }
        private void ShowSettings()
        {
            GeneralSettings generalSettings = new GeneralSettings();
            if (generalSettings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadRecentMonitorPackList();
                this.SnappingEnabled = Properties.Settings.Default.MainFormSnap;
                collectorQuickToolStrip.Visible = Properties.Settings.Default.MainWindowCollectorQuickToolbarVisible;
                notifierQuickToolStrip.Visible = Properties.Settings.Default.MainWindowCollectorQuickToolbarVisible;
                if (monitorPack != null)
                {
                    monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
                    monitorPack.ScriptsRepositoryDirectory = Properties.Settings.Default.ScriptRepositoryDirectory;
                }
                SetCollectorTreeViewProperties();
            }
        }
        private void SetCollectorMenuItemStates()
        {
            if (lblCollectors.Focused)
            {
                tvwCollectors.SelectedNode = null;
            }

            if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorHost)
            {
                CollectorHost ch = (CollectorHost)tvwCollectors.SelectedNode.Tag;
                disableCollectorToolStripMenuItem.Text = ch.Enabled ? "Disable" : "Enable";
                enableDisableCollectorToolStripButton.Text = ch.Enabled ? "Disable Collector" : "Enable Collector";
            }
            detailsToolStripMenuItem.Enabled = tvwCollectors.SelectedNode != null;
            collectorDetailToolStripButton.Enabled = tvwCollectors.SelectedNode != null;
            configureToolStripMenuItem.Enabled = tvwCollectors.SelectedNode != null;
            editCollectorToolStripButton.Enabled = tvwCollectors.SelectedNode != null;
            deleteToolStripMenuItem.Enabled = tvwCollectors.SelectedNode != null;
            deleteCollectorToolStripButton.Enabled = tvwCollectors.SelectedNode != null;
            disableCollectorToolStripMenuItem.Enabled = tvwCollectors.SelectedNode != null;
            enableDisableCollectorToolStripButton.Enabled = tvwCollectors.SelectedNode != null;
            graphToolStripMenuItem.Enabled = tvwCollectors.SelectedNode != null;

            copyCollectorToolStripMenuItem.Enabled = tvwCollectors.SelectedNode != null;
            copyCollectorToolStripButton.Enabled = tvwCollectors.SelectedNode != null;
            historyToCSVToolStripMenuItem.Enabled = tvwCollectors.SelectedNode != null;
            collectorHistoryToCSVToolStripMenuItem.Enabled = tvwCollectors.SelectedNode != null;
            collectorHistoryToXMLToolStripMenuItem.Enabled = tvwCollectors.SelectedNode != null;
            collectorHistoryToXMLToolStripMenuItem1.Enabled = tvwCollectors.SelectedNode != null;

            if (monitorPack != null && !monitorPack.IsBusyPolling)
                refreshToolStripMenuItem.Enabled = true;
            else
                refreshToolStripMenuItem.Enabled = false;

            SetCollectorPasteMenuStates();
        }
        private void SetCollectorPasteMenuStates()
        {
            pasteAndEditCollectorConfigToolStripMenuItem.Visible = Properties.Settings.Default.EnableRawEditing;
            pasteWithEditCollectorToolStripButton.Visible = Properties.Settings.Default.EnableRawEditing;
            if (Clipboard.ContainsText() &&
                Clipboard.GetText(TextDataFormat.Text).Trim(' ', '\r', '\n').ContainsCaseInsensitive("<collectorHosts") &&
                Clipboard.GetText(TextDataFormat.Text).Trim(' ', '\r', '\n').EndsWith("</collectorHosts>", StringComparison.InvariantCulture))
            {
                pasteCollectorToolStripButton.Enabled = true;
                pasteCollectorToolStripMenuItem.Enabled = true;
                pasteWithEditCollectorToolStripButton.Enabled = Properties.Settings.Default.EnableRawEditing;
                pasteAndEditCollectorConfigToolStripMenuItem.Enabled = Properties.Settings.Default.EnableRawEditing;

            }
            else
            {
                pasteCollectorToolStripButton.Enabled = false;
                pasteCollectorToolStripMenuItem.Enabled = false;
                pasteWithEditCollectorToolStripButton.Enabled = false;
                pasteAndEditCollectorConfigToolStripMenuItem.Enabled = false;
            }
        }
        private void SetNotifierMenuItemStates()
        {
            TreeNode notifierSelected = null;
            if (lblNotifiers.Focused)
            {
                tvwNotifiers.SelectedNode = null;
                notifierSelected = null;
            }
            else
            {
                notifierSelected = tvwNotifiers.SelectedNode;
            }

            addNotifierToolStripMenuItem.Enabled = true;
            addNotofierToolStripButton.Enabled = true;
            editNotifierToolStripMenuItem.Enabled = notifierSelected != null;
            editNotifierToolStripButton.Enabled = notifierSelected != null;
            deleteNotifierToolStripMenuItem.Enabled = notifierSelected != null;
            deleteNotifierToolStripButton.Enabled = notifierSelected != null;
            if (notifierSelected != null && notifierSelected.Tag != null)
            {
                enableNotifierToolStripMenuItem.Enabled = true;
                enableDisableNotifierToolStripButton.Enabled = true;
                if (notifierSelected.Tag is NotifierHost)
                {
                    NotifierHost nh = (NotifierHost)notifierSelected.Tag;
                    enableNotifierToolStripMenuItem.Text = nh.Enabled ? "Disable" : "Enable";
                    enableDisableNotifierToolStripButton.Text = nh.Enabled ? "Disable Notifier" : "Enable Notifier";
                }
                else if (notifierSelected.Tag is INotifier)
                {
                    INotifier agent = (INotifier)notifierSelected.Tag;
                    enableNotifierToolStripMenuItem.Text = agent.Enabled ? "Disable" : "Enable";
                    addNotifierToolStripMenuItem.Enabled = false;
                    enableDisableNotifierToolStripButton.Text = agent.Enabled ? "Disable Notifier agent" : "Enable Notifier agent";
                }
            }
            else
            {
                enableNotifierToolStripMenuItem.Enabled = false;
                enableDisableNotifierToolStripButton.Enabled = false;
            }
            viewNotifierToolStripMenuItem.Enabled = notifierSelected != null && notifierSelected.Tag != null && notifierSelected.Tag is INotifier && RegisteredAgentUIMapper.HasAgentViewer(((INotifier)notifierSelected.Tag));
            viewNotifierToolStripButton.Enabled = notifierSelected != null && notifierSelected.Tag != null && notifierSelected.Tag is INotifier && RegisteredAgentUIMapper.HasAgentViewer(((INotifier)notifierSelected.Tag));
        }
        private void ShowRecentMonitorPacksWindow()
        {
            SelectRecentMonitorPackDialog selectRecentMonitorPackDialog = new SelectRecentMonitorPackDialog();
            if (selectRecentMonitorPackDialog.ShowDialog() == DialogResult.OK)
            {                
                LoadMonitorPack(selectRecentMonitorPackDialog.SelectedMonitorPack);
                RefreshMonitorPack(true, true);
            }
        }
        private bool MPStickyLoad(string monitorPackPath = "")
        {
            bool loaded = false;
            try
            {
                if (monitorPackPath == "" & monitorPack != null)
                {
                    monitorPackPath = monitorPack.MonitorPackPath;
                }
                //if (monitorPack != null && monitorPack.EnableStickyMainWindowLocation)
                {
                    string qmAppDataPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "Hen IT", "QuickMon 5");
                    string mpUISettingsName = System.IO.Path.GetFileNameWithoutExtension(monitorPackPath);
                    string mpUISettingsPath = System.IO.Path.Combine(qmAppDataPath, mpUISettingsName + ".uisettings");
                    if (System.IO.File.Exists(mpUISettingsPath))
                    {
                        MonitorPackUISettings mpUISettings = new MonitorPackUISettings();
                        mpUISettings.Load(mpUISettingsPath);
                        if (
                            (mpUISettings.Width > 0) && (mpUISettings.Height > 0)
                            )
                        {
                            this.Location = new Point(mpUISettings.LocationX, mpUISettings.LocationY);
                            this.Size = new Size(mpUISettings.Width, mpUISettings.Height);
                            loaded = true;
                        }
                    }
                }
            }
            catch { }
            return loaded;
        }
        private void MPStickySave()
        {
            try
            {
                if (monitorPack != null && monitorPack.EnableStickyMainWindowLocation && System.IO.File.Exists(monitorPack.MonitorPackPath))
                {
                    string qmAppDataPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "Hen IT", "QuickMon 5");
                    string mpUISettingsName = System.IO.Path.GetFileNameWithoutExtension(monitorPack.MonitorPackPath);
                    string mpUISettingsPath = System.IO.Path.Combine(qmAppDataPath, mpUISettingsName + ".uisettings");
                    MonitorPackUISettings mpUISettings = new MonitorPackUISettings();
                    mpUISettings.LocationX = this.Location.X;
                    mpUISettings.LocationY = this.Location.Y;
                    mpUISettings.Width = this.Size.Width;
                    mpUISettings.Height = this.Size.Height;
                    mpUISettings.Save(mpUISettingsPath);
                }
            }
            catch { }
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
            PausePolling(false);
            try
            {
                if (monitorPack != null)
                {
                    CloseAllMPDetailWindows();
                    MPStickySave();

                    monitorPack.CloseMonitorPack();
                    monitorPack = null;
                }
            }
            catch { }

            if (Properties.Settings.Default.UseTemplatesForNewObjects)
            {
                SelectNewEntityType snet = new SelectNewEntityType();
                if (snet.ShowMonitorPackSelection() == DialogResult.OK && snet.SelectedMonitorPack != null)
                {
                    monitorPack = snet.SelectedMonitorPack;
                }
                else
                {
                    monitorPack = new MonitorPack();
                    monitorPack.LoadXml(Properties.Resources.BlankMonitorPack);
                }
            }
            else
            {
                monitorPack = new MonitorPack();

                string newMonitorPackConfig = Properties.Resources.BlankMonitorPack;
                monitorPack.LoadXml(newMonitorPackConfig);
            }
            monitorPack.MonitorPackPath = "";
            LoadControlsFromMonitorPack();
            monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;
            monitorPack.ScriptsRepositoryDirectory = Properties.Settings.Default.ScriptRepositoryDirectory;
            SetMonitorPackEvents();
            monitorPackChanged = false;
            if (!Properties.Settings.Default.UseTemplatesForNewObjects)
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
                        CloseAllMPDetailWindows();
                        WaitForPollingToFinish(5);
                        MPStickySave();
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
                monitorPack.ScriptsRepositoryDirectory = Properties.Settings.Default.ScriptRepositoryDirectory;
                foreach (var ch in monitorPack.CollectorHosts.GroupBy(c => c.UniqueId))
                {
                    if (ch.Count() > 1)
                    {
                        string names = "";
                        foreach(var c in ch)
                        {
                            names += c.Name + "\r\n";
                        }
                        MessageBox.Show("There are multiple Collector hosts with the unique ID '" + ch.Key + "'. This is not supported. Please change each ID to be unique.\r\n" + names, "Unique ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                MPStickyLoad();
                LoadControlsFromMonitorPack();
                SetMonitorPackEvents();

                AddMonitorPackFileToRecentList(monitorPackPath);
                try
                {
                    if (TaskbarManager.IsPlatformSupported)
                        JumpList.AddToRecent(monitorPackPath);
                }
                catch { }

                if (isPollingEnabled)
                {
                    UpdateStatusbar("Starting/Resuming polling...");
                    ResumePolling(true);
                }
                else
                    UpdateStatusbar("");
                monitorPackChanged = false;
                UpdateAppTitle();
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
            if (tvwCollectors.Nodes.Count > 0)
            {
                tvwCollectors.SelectedNode = tvwCollectors.Nodes[0];
                tvwCollectors.Nodes[0].EnsureVisible();
            }

            Cursor.Current = Cursors.Default;
            Application.DoEvents();
        }
        private void LoadCollectorNode(TreeNode root, CollectorHost collector)
        {
            TreeNodeEx collectorNode;
            if (collector.CollectorAgents == null || collector.CollectorAgents.Count == 0)
            {
                collectorNode = new TreeNodeEx(collector.DisplayName, collectorFolderImage, collectorFolderImage);
                collectorNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            }
            else
            {
                collectorNode = new TreeNodeEx(collector.DisplayName, collectorNAstateImage, collectorNAstateImage);
                collectorNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular);
            }
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
            if (collector.CollectorAgents.Count == 0)
                collectorNode.DisplayValue = "Child collectors: " + collectorNode.Nodes.GetAllChileNodeCount().ToString();
            if (root == null)
            {
                tvwCollectors.Nodes.Add(collectorNode);
            }
            else 
                root.Nodes.Add(collectorNode);
            if (collectorNode.Nodes.Count > 0 && collector.Enabled)
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
                monitorPack.NotifierAgentAlertRaised += MonitorPack_NotifierAgentAlertRaised;

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
                if (success)
                {
                    try
                    {
                        if (TaskbarManager.IsPlatformSupported)
                            JumpList.AddToRecent(monitorPack.MonitorPackPath);
                    }
                    catch { }
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
            if (!isPollingEnabled)
            {
                UpdateStatusbar("Pausing polling...");
                PausePolling(false);
                WaitForPollingToFinish(5);
                UpdateStatusbar("Waiting for editing to finish");
            }

            MonitorPackEditor mpEdit = new MonitorPackEditor();

            //EditMonitorPackConfig emc = new EditMonitorPackConfig();
            mpEdit.SelectedMonitorPack = monitorPack;
            if (mpEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SetMonitorChanged();
                if (mpEdit.TriggerMonitorPackReload)
                {
                    //CloseAllDetailWindows();
                    CloseAllMPDetailWindows();
                    monitorPack = mpEdit.SelectedMonitorPack;
                    UpdateStatusbar("Reloading monitor pack...");
                    SetMonitorPackEvents();
                    LoadControlsFromMonitorPack();
                }
                SetMonitorPackNameDescription();
                DoAutoSave();
            }
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
                    if (collectorHost != null && collectorHost.Tag is TreeNodeEx)
                    {
                        Trace.WriteLine("Updating " + collectorHost.Name);
                        
                        TreeNodeEx currentTreeNode = (TreeNodeEx)collectorHost.Tag;
                        try
                        {
                            if (currentTreeNode.Text != collectorHost.DisplayName)
                                currentTreeNode.Text = collectorHost.DisplayName;
                            if (currentTreeNode.IsSelected)
                                SetCounterValue(selectedCollectorsQueryTime, collectorHost.CurrentState.CallDurationMS, "Selected collector query time (ms)");
                        }
                        catch { }

                        if (collectorHost.CollectorAgents == null || collectorHost.CollectorAgents.Count == 0)
                        {
                            currentTreeNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                        }
                        else
                        {
                            currentTreeNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular);
                        }

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
                                PCRaiseCollectorErrorState();
                            }
                        }
                        else if (collectorHost.CurrentState.State == CollectorState.Warning)
                        {
                            if (currentTreeNode.ImageIndex != collectorWarningStateImage1)
                            {
                                nodeChanged = true;
                                imageIndex = collectorWarningStateImage1;
                                PCRaiseCollectorWarningState();
                            }
                        }
                        else if (collectorHost.CurrentState.State == CollectorState.Good)
                        {
                            if (currentTreeNode.ImageIndex != collectorGoodStateImage1)
                            {
                                nodeChanged = true;
                                imageIndex = collectorGoodStateImage1;
                                PCRaiseCollectorSuccessState();
                            }
                        }
                        else if (collectorHost.CurrentState.State == CollectorState.NotInServiceWindow)
                        {
                            nodeChanged = true;
                            imageIndex = collectorOutOfServiceWindowstateImage;
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

                                if (collectorHost.CollectorAgents.Count > 0)
                                {
                                    currentTreeNode.DisplayValue = collectorHost.CurrentState.ReadPrimaryOrFirstUIValue();
                                }                                
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

                            IChildWindowIdentity detailWindow = GetChildWindowByIdentity(collectorHost.UniqueId);
                            if (detailWindow != null && detailWindow.AutoRefreshEnabled)
                            {
                                detailWindow.RefreshDetails();
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
        private void MonitorPack_NotifierAgentAlertRaised(INotifier notifier, AlertRaised alertRaised)
        {
            IChildWindowIdentity childWindow = GetChildWindowByIdentity(notifier.RunTimeUniqueId);
            if (childWindow != null)
            {
                this.Invoke((MethodInvoker) delegate{
                    Form childForm = ((Form)childWindow);
                    if (childWindow.AutoRefreshEnabled)
                        childWindow.RefreshDetails();
                });
            }
        }
        private void UpdateParentFolderNode(TreeNodeEx parentNode)
        {
            if (parentNode != null && parentNode.Tag != null && parentNode.Tag is CollectorHost)
            {
                CollectorHost collectorHost = (CollectorHost)(parentNode.Tag);
                if (collectorHost.CollectorAgents.Count == 0)
                {
                    ((TreeNodeEx)parentNode).DisplayValue = "Child collectors: " + parentNode.Nodes.GetAllChileNodeCount().ToString();
                    tvwCollectors.Refresh();
                }
            }
        }
        private void RemoveCollector(TreeNode parentNode)
        {
            foreach (TreeNode collectorNode in parentNode.Nodes)
            {
                RemoveCollector(collectorNode);
            }
            CollectorHost ce = (CollectorHost)parentNode.Tag;
            IChildWindowIdentity childWindow = GetChildWindowByIdentity(ce.UniqueId);
            if (childWindow != null)
            {
                ((Form)childWindow).Close();
            }
            monitorPack.CollectorHosts.Remove(ce);
            
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
                    PCSetCollectorsQueryTime(sw.ElapsedMilliseconds);
                    SetAppIcon(monitorPack.CurrentState);

                    string refreshIntervalStr = autoRefreshTimer == null ? "N/A" : (autoRefreshTimer.Interval / 1000).ToString();
                    UpdateStatusbar(string.Format("Global state: {0}, Updated: {1}, Duration: {2} sec, Cur Freq: {3}",
                        globalState,
                        DateTime.Now.ToString("HH:mm:ss"),
                        (sw.ElapsedMilliseconds / 1000.00).ToString("F2"),
                        refreshIntervalStr
                        ));

                    RefreshGlobalAgentHistory();
                    RefreshCollectorFilterViews();
                    RefreshCollectorGraphWindows();
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
        private void RefreshGlobalAgentHistory()
        {
            try
            {
                IChildWindowIdentity childWindow = GetChildWindowByIdentity("GlobalAgentHistory");
                if (childWindow != null)
                {
                    GlobalAgentHistory globalAgentHistory = (GlobalAgentHistory)childWindow;
                    globalAgentHistory.RefreshDetails();
                }
            }
            catch(Exception ex) { System.Diagnostics.Trace.WriteLine(ex.Message); }
        }
        private void RefreshCollectorFilterViews()
        {
            try
            {
                IChildWindowIdentity childWindow = GetChildWindowByIdentity("CollectorFilterView");
                if (childWindow != null)
                {
                    CollectorFilterView collectorFilterView = (CollectorFilterView)childWindow;
                    collectorFilterView.RefreshDetails();
                }
            }
            catch (Exception ex) { System.Diagnostics.Trace.WriteLine(ex.Message); }
        }
        private void RefreshCollectorGraphWindows()
        {
            foreach (IChildWindowIdentity childWindow in GetAllChildWindowByIdentityFilter("CollectorGraph"))
            {
                childWindow.RefreshDetails();
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
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorHost && monitorPack != null)
                {
                    SetNodesToBeingRefreshed(tvwCollectors.SelectedNode);
                    CollectorHost ch = (CollectorHost)tvwCollectors.SelectedNode.Tag;
                    WaitForPollingToFinish(5);
                    Cursor.Current = Cursors.WaitCursor;
                    monitorPack.ForceCollectorHostRefreshState(ch);
                }
                else
                {
                    cmdRefresh_Click(null, null);
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

        #region Auto refreshing timer
        private void autoRefreshTimer_Tick(object sender, EventArgs e)
        {
            if (isPollingEnabled)
                RefreshMonitorPack();
        }
        public void PausePolling(bool disablePolling = true)
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
        public void ResumePolling(bool startImmediately = false)
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
            List<string> recentList = new List<string>();
            recentList.Add(monitorPackPath);

            if (Properties.Settings.Default.RecentQMConfigFiles == null)
                Properties.Settings.Default.RecentQMConfigFiles = new System.Collections.Specialized.StringCollection();
            foreach (string recentItem in Properties.Settings.Default.RecentQMConfigFiles)
            {
                if ((from string f in recentList
                     where f.ToUpper() == recentItem.ToUpper()
                     select f).Count() == 0)
                {
                    recentList.Add(recentItem);
                }
            }
            Properties.Settings.Default.RecentQMConfigFiles = new System.Collections.Specialized.StringCollection();
            foreach (string recentItem in recentList)
            {
                Properties.Settings.Default.RecentQMConfigFiles.Add(recentItem);
            }                
            Properties.Settings.Default.LastMonitorPack = monitorPackPath;            
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

                List<MonitorPack.NameAndTypeSummary> summaryList = new List<MonitorPack.NameAndTypeSummary>();
                foreach(string filePath in Properties.Settings.Default.RecentQMConfigFiles)
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        MonitorPack.NameAndTypeSummary summary = MonitorPack.GetMonitorPackTypeName(filePath);
                        summaryList.Add(summary);
                    }
                }

                List<MonitorPack.NameAndTypeSummary> orderedList = new List<MonitorPack.NameAndTypeSummary>();
                if (Properties.Settings.Default.SortQuickRecentList)
                    orderedList.AddRange((from MonitorPack.NameAndTypeSummary s in summaryList
                                          orderby s.Name
                                          select s));
                else
                    orderedList.AddRange((from MonitorPack.NameAndTypeSummary s in summaryList
                                          select s));
                foreach(MonitorPack.NameAndTypeSummary recentItem in orderedList)
                {
                    bool mpVisible = false;
                    if ((from string s in allowFilters
                         where s == "*" || s.ToLower() == recentItem.TypeName.ToLower()
                         select s).Count() > 0)
                        mpVisible = true;
                    if ((from string s in disallowFilters
                         where s.ToLower() == recentItem.TypeName.ToLower()
                         select s).Count() > 0)
                        mpVisible = false;
                    if (mpVisible)
                    {
                        string entryDisplayName;
                        if (Properties.Settings.Default.ShowFullPathForQuickRecentList)
                            entryDisplayName = recentItem.Name + " (" + recentItem.Path + ")";
                        else
                            entryDisplayName = recentItem.Name;

                        if (cboRecentMonitorPacks.DropDownWidth < TextRenderer.MeasureText(entryDisplayName + "........", cboRecentMonitorPacks.Font).Width && entryDisplayName.Length > 20)
                        {
                            string ellipseText = entryDisplayName.Substring(0, 20) + "....";
                            string tmpStr = entryDisplayName.Substring(4);
                            while (TextRenderer.MeasureText(ellipseText + tmpStr, cboRecentMonitorPacks.Font).Width > cboRecentMonitorPacks.DropDownWidth && tmpStr.Length > 0)
                            {
                                tmpStr = tmpStr.Substring(1);
                            }
                            cboRecentMonitorPacks.Items.Add(new QuickMon.Controls.ComboItem(ellipseText + tmpStr, recentItem));
                        }
                        else
                        {
                            cboRecentMonitorPacks.Items.Add(new QuickMon.Controls.ComboItem(entryDisplayName, recentItem));
                        }
                    }
                }


                //foreach (string filePath in orderedList)
                //{
                //    bool mpVisible = false;
                //    if (System.IO.File.Exists(filePath))
                //    {
                //        MonitorPack.NameAndTypeSummary summary = MonitorPack.GetMonitorPackTypeName(filePath);
                //        if ((from string s in allowFilters
                //             where s == "*" || s.ToLower() == summary.TypeName.ToLower()
                //             select s).Count() > 0)
                //            mpVisible = true;
                //        if ((from string s in disallowFilters
                //             where s.ToLower() == summary.TypeName.ToLower()
                //             select s).Count() > 0)
                //            mpVisible = false;
                //        if (mpVisible)
                //        {
                //            string entryDisplayName;
                //            if (Properties.Settings.Default.ShowFullPathForQuickRecentList)
                //                entryDisplayName = summary.Name + " (" + filePath + ")";
                //            else
                //                entryDisplayName = summary.Name;

                //            if (cboRecentMonitorPacks.DropDownWidth < TextRenderer.MeasureText(entryDisplayName + "........", cboRecentMonitorPacks.Font).Width && entryDisplayName.Length > 20)
                //            {
                //                string ellipseText = entryDisplayName.Substring(0, 20) + "....";
                //                string tmpStr = entryDisplayName.Substring(4);
                //                while (TextRenderer.MeasureText(ellipseText + tmpStr, cboRecentMonitorPacks.Font).Width > cboRecentMonitorPacks.DropDownWidth && tmpStr.Length > 0)
                //                {
                //                    tmpStr = tmpStr.Substring(1);
                //                }
                //                cboRecentMonitorPacks.Items.Add(new QuickMon.Controls.ComboItem(ellipseText + tmpStr, summary));
                //            }
                //            else
                //            {
                //                cboRecentMonitorPacks.Items.Add(new QuickMon.Controls.ComboItem(entryDisplayName, summary));
                //            }
                //        }
                //    }
                //}
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
            ShowRecentMonitorPacksWindow();
        }
        private void cboRecentMonitorPacks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboRecentMonitorPacks.SelectedIndex > 0 && cboRecentMonitorPacks.SelectedItem is QuickMon.Controls.ComboItem)
            {
                llblMonitorPack.Visible = true;
                cboRecentMonitorPacks.Visible = false;                
                cboRecentMonitorPacks.Dock = DockStyle.Left;

                //CloseAllDetailWindows();
                CloseAllMPDetailWindows();
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

        #region Collector Tree events
        private void tvwCollectors_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeViewHitTestInfo tvi = tvwCollectors.HitTest(e.Location);
            if (tvi.Node != null && tvi.Location == TreeViewHitTestLocations.RightOfLabel)
                tvwCollectors.SelectedNode = tvi.Node;
        }
        private void tvwCollectors_TreeNodeMoved(TreeNode dragNode)
        {
            if (dragNode != null)
            {
                //set Collector Parent if needed
                if (dragNode.Tag is CollectorHost)
                {
                    if (dragNode.Parent != null && dragNode.Parent.Tag is CollectorHost)
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
        private void tvwCollectors_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetCollectorMenuItemStates();
        }
        private void tvwCollectors_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            detailsToolStripMenuItem_Click(null, null);
        }
        private void tvwCollectors_MouseClick(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo ht = tvwCollectors.HitTest(e.Location);
            if (ht.Node == null)
            {
                tvwCollectors.SelectedNode = null;
            }
        }
        private void tvwCollectors_MouseUp(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo ht = tvwCollectors.HitTest(e.Location);
            if (ht.Node == null)
            {
                tvwCollectors.SelectedNode = null;
            }
        }
        private void tvwCollectors_NoNodeSelected()
        {
            SetCollectorMenuItemStates();
            //detailsToolStripMenuItem.Enabled = false;
            //collectorDetailToolStripButton.Enabled = false;
            //configureToolStripMenuItem.Enabled = false;
            //editCollectorToolStripButton.Enabled = false;
            //deleteToolStripMenuItem.Enabled = false;
            //deleteCollectorToolStripButton.Enabled = false;
            //disableCollectorToolStripMenuItem.Enabled = false;
            //enableDisableCollectorToolStripButton.Enabled = false;
            //copyCollectorToolStripMenuItem.Enabled = false;
            //copyCollectorToolStripButton.Enabled = false;            
        }
        private void tvwCollectors_MouseHover(object sender, EventArgs e)
        {
            SetCollectorPasteMenuStates();
        }
        #endregion

        #region Child Window Management
        public void RegisterChildWindow(IChildWindowIdentity child)
        {
            childWindows.Add(child);
        }
        public void RemoveChildWindow(IChildWindowIdentity childWindow)
        {
            IChildWindowIdentity child = (from IChildWindowIdentity c in childWindows

                                          where c.Identifier == childWindow.Identifier
                                          select c).FirstOrDefault();
            if (child != null)
            {
                childWindows.Remove(child);
            }
        }
        private void CloseAllMPDetailWindows()
        {
            IChildWindowIdentity child = childWindows.FirstOrDefault(w => !(new String[] { "TemplateEditor", "RemoteAgentHostManagement" }).Contains(w.Identifier));

            while (child != null) // childWindows.Where(w => !(new String[] { "TemplateEditor", "RemoteAgentHostManagement" }).Contains(w.Identifier)).Count() > 0)
            {
                ((Form)child).Close();
                child = childWindows.FirstOrDefault(w => !(new String[] { "TemplateEditor", "RemoteAgentHostManagement", "GlobalAgentHistory", "CollectorFilterView" }).Contains(w.Identifier));

                //if (child != null)
                //{
                //    ((Form)child).Close();
                //}
            }
        }
        private void CloseAllDetailWindows()
        {
            while (childWindows.Count > 0)
                ((Form)childWindows[0]).Close();

            //This code cause an exeption because the Close() method causes items to be removed from the childWindows List
            //foreach (Form child in childWindows)
            //{
            //    child.Close();
            //}

            //CloseAllCollectorStatusViews();
            //CloseAllNotifierViewers();
        }
        private IChildWindowIdentity GetChildWindowByIdentity(string identifier)
        {
            IChildWindowIdentity child = (from IChildWindowIdentity c in childWindows
                                          where c.Identifier == identifier
                                          select c).FirstOrDefault();
            try
            {
                if (child != null && (((Form)child).IsDisposed))
                {
                    child = null;
                }
            }
            catch { }
            return child;
        }
        private List<IChildWindowIdentity> GetAllChildWindowByIdentityFilter(string identifier)
        {
            List<IChildWindowIdentity> list = new List<IChildWindowIdentity>();
            foreach (IChildWindowIdentity child in childWindows)
            {
                if (child.Identifier.StartsWith(identifier))
                    list.Add(child);
            }
            return list;
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
                        MessageBox.Show("QuickMon 5 needs to restart in 'Admin' mode to set up its performance counters on this computer.", "Restart in Admin mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void PCRaiseCollectorSuccessState()
        {
            IncrementCounter(collectorInfoStatePerSec, "Collector Host info states/Sec");
            IncrementCounter(collectorsQueriedPerSecond, "Collector Hosts queried/Sec");
        }
        private void PCRaiseCollectorWarningState()
        {
            IncrementCounter(collectorWarningStatePerSec, "Collector Host warning states/Sec");
            IncrementCounter(collectorsQueriedPerSecond, "Collector Hosts queried/Sec");
        }
        private void PCRaiseCollectorErrorState()
        {
            IncrementCounter(collectorErrorStatePerSec, "Collector Host error states/Sec");
            IncrementCounter(collectorsQueriedPerSecond, "Collector Hosts queried/Sec");
        }
        private void PCSetCollectorsQueryTime(long elapsedMilliseconds)
        {
            SetCounterValue(collectorsQueryTime, elapsedMilliseconds, "Collector Hosts query time (ms)");
        }

        #endregion

        #region Notifier treeview events
        private void tvwNotifiers_DoubleClick(object sender, EventArgs e)
        {
            ViewNotifierDetails();
        }
        private void tvwNotifiers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetNotifierMenuItemStates();
        }
        private void tvwNotifiers_NoNodeSelected()
        {
            SetNotifierMenuItemStates();
        }
        #endregion

        #region Export Collector history
        private string lastExportCollectorHistoryPathCSV = "";
        private string lastExportCollectorHistoryPathXML = "";
        private void ExportSelectedCollectorHistoryToCSV()
        {
            if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorHost)
            {
                try
                {
                    CollectorHost entry = (CollectorHost)tvwCollectors.SelectedNode.Tag;
                    string exportedData = entry.ExportHistoryToCSV(true);
                    SaveFileDialog fs = new SaveFileDialog();
                    fs.Title = "Export Collector metric history to CSV";
                    fs.Filter = "CSV Files|*.csv";
                    fs.FileName = lastExportCollectorHistoryPathCSV;
                    if (fs.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(fs.FileName, exportedData,Encoding.UTF8);
                        lastExportCollectorHistoryPathCSV = fs.FileName;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Export Collector history", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ExportAllCollectorsHistoryToCSV()
        {
            if (monitorPack != null)
            {
                try
                {
                    SaveFileDialog fs = new SaveFileDialog();
                    fs.Title = "Export Collector metric history to CSV";
                    fs.Filter = "CSV Files|*.csv";
                    fs.FileName = lastExportCollectorHistoryPathCSV;
                    string exportedData = monitorPack.ExportCollectorHistoryToCSV();
                    if (fs.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(fs.FileName, exportedData, Encoding.UTF8);
                        lastExportCollectorHistoryPathCSV = fs.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Export all Collectors history", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
        private void ExportSelectedCollectorHistoryToXML()
        {
            if (tvwCollectors.SelectedNode != null && tvwCollectors.SelectedNode.Tag != null && tvwCollectors.SelectedNode.Tag is CollectorHost)
            {
                try
                {
                    CollectorHost entry = (CollectorHost)tvwCollectors.SelectedNode.Tag;
                    string exportedData = entry.ExportHistoryToXML();
                    SaveFileDialog fs = new SaveFileDialog();
                    fs.Title = "Export Collector metric history to XML";
                    fs.Filter = "XML Files|*.xml";
                    fs.FileName = lastExportCollectorHistoryPathXML;
                    if (fs.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(fs.FileName, exportedData, Encoding.UTF8);
                        lastExportCollectorHistoryPathXML = fs.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Export Collector history", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ExportAllCollectorsHistoryToXML()
        {
            if (monitorPack != null)
            {
                try
                {
                    SaveFileDialog fs = new SaveFileDialog();
                    fs.Title = "Export Collector metric history to XML";
                    fs.Filter = "XML Files|*.xml";
                    fs.FileName = lastExportCollectorHistoryPathXML;
                    string exportedData = monitorPack.ExportCollectorHistoryToXML();
                    if (fs.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(fs.FileName, exportedData, Encoding.UTF8);
                        lastExportCollectorHistoryPathXML = fs.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Export all Collectors history", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        #endregion

        private void llblMonitorPack_MouseEnter(object sender, EventArgs e)
        {
            recentListTimer.Enabled = false;
            recentListTimer.Enabled = true;
        }

        private void llblMonitorPack_MouseLeave(object sender, EventArgs e)
        {
            recentListTimer.Enabled = false;
        }

        private void recentListTimer_Tick(object sender, EventArgs e)
        {
            ShowRecentMonitorPackDropdown();
        }


    }
}
