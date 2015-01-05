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
        private bool monitorPackChanged = false;
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
                ////set Collector Parent if needed
                //if (dragNode.Tag is CollectorEntry)
                //{
                //    if (dragNode.Parent.Tag is CollectorEntry)
                //    {
                //        ((CollectorEntry)dragNode.Tag).ParentCollectorId = ((CollectorEntry)dragNode.Parent.Tag).UniqueId;
                //    }
                //    else
                //        ((CollectorEntry)dragNode.Tag).ParentCollectorId = "";
                //}
                //SetMonitorChanged();
                //DoAutoSave();
            }
        }
        private void tvwCollectors_EnterKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control)
            //{
            //    collectorTreeEditConfigToolStripMenuItem_Click(null, null);
            //}
            //else
            //{
            //    collectorTreeViewDetailsToolStripMenuItem_Click(null, null);
            //}
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
            //CheckCollectorContextMenuEnables();
            //collectorContextMenuLaunchPoint = calcPoint;
            //showCollectorContextMenuTimer.Enabled = false;
            //showCollectorContextMenuTimer.Enabled = true;
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
                //CloseAllDetailWindows();
                //LoadMonitorPack(((QuickMon.Controls.ComboItem)cboRecentMonitorPacks.SelectedItem).Value.ToString());
                //RefreshMonitorPack(true, true);
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


        #region Private methods
        private bool PerformCleanShutdown(bool abortAllowed = false)
        {
            bool notAborted = true;
            try
            {
                //if (monitorPackChanged)
                //{
                //    if (Properties.Settings.Default.AutosaveChanges || MessageBox.Show("Do you want to save changes to the current monitor pack?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                //    {
                //        if (!SaveMonitorPack() && abortAllowed)
                //            return false;
                //    }
                //}

                //UpdateStatusbar("Shutting down...");
                //Application.DoEvents();
                //mainRefreshTimer.Enabled = false;
                //CloseAllDetailWindows();
                //if (monitorPack.BusyPolling)
                //{
                //    monitorPack.AbortPolling = true;
                //    DateTime abortStart = DateTime.Now;
                //    while (monitorPack.BusyPolling && abortStart.AddSeconds(5) > DateTime.Now)
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
                Properties.Settings.Default.Save();
            }
            catch { }
            return notAborted;
        }
        #endregion

        #region Toolbar events
        private void generalSettingsToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            //PausePolling(true);
            //HideCollectorContextMenu();
            GeneralSettings generalSettings = new GeneralSettings();
            generalSettings.PollingFrequencySec = Properties.Settings.Default.PollFrequencySec;
            //generalSettings.PollingEnabled = timerEnabled;
            if (generalSettings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //LoadRecentMonitorPackList();
                this.SnappingEnabled = Properties.Settings.Default.MainFormSnap;
                //if (monitorPack != null)
                //    monitorPack.ConcurrencyLevel = Properties.Settings.Default.ConcurrencyLevel;

                Properties.Settings.Default.PollFrequencySec = generalSettings.PollingFrequencySec;
                //timerEnabled = generalSettings.PollingEnabled;
            }
            //ResumePolling();
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
            //bool timerEnabled = mainRefreshTimer.Enabled;
            //mainRefreshTimer.Enabled = false; //temporary stops it.
            //EditMonitorPackConfig emc = new EditMonitorPackConfig();
            //emc.SelectedMonitorPack = monitorPack;
            //if (emc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    SetMonitorChanged();
            //    SetMonitorPackNameDescription();
            //    DoAutoSave();
            //    if (emc.RequestCollectorsRefresh)
            //    {
            //        foreach (CollectorEntry entry in monitorPack.Collectors)
            //        {
            //            entry.RefreshCollectorConfig(monitorPack.ConfigVariables);
            //            entry.RefreshDetailsIfOpen();
            //        }
            //    }
            //}
            //SetPollingFrequency(timerEnabled);
        }
        private void llblNotifierViewToggle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            masterSplitContainer.Panel2Collapsed = !masterSplitContainer.Panel2Collapsed;
            llblNotifierViewToggle.Text = masterSplitContainer.Panel2Collapsed ? "Show Notifiers" : "Hide Notifiers";
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