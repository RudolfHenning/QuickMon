using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuickMon.Management
{
    public partial class MonitorPackManagement : Form
    {
        #region Private
        private MonitorPack monitorPack;
        private int collectorImgIndex = 1;
        private int notifierImgIndex = 2;
        private int collectorRootImgIndex = 4;
        private int notifierRootImgIndex = 5;
        private int folderImgIndex = 6;
        private TreeNode dragNode = null; 
        #endregion

        public string MonitorPackPath { get; private set; }

        public MonitorPackManagement()
        {
            InitializeComponent();
            if (Properties.Settings.Default.recentMonitorPacks == null)
                Properties.Settings.Default.recentMonitorPacks = new System.Collections.Specialized.StringCollection();
        }

        #region Public methods
        public DialogResult ShowMonitorPack(MonitorPack monitorPack)
        {
            this.monitorPack = monitorPack;
            filePathtoolStripStatusLabel.Text = monitorPack.MonitorPackPath;
            return this.ShowDialog();
        } 
        #endregion

        #region Form events
        private void MonitorPackManagement_Load(object sender, EventArgs e)
        {
            txtAgentsRegistrationFile.Text = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            try
            {
                ToolStripManager.LoadSettings(this, "QuickMon.ConfigurationEditorToolbar");
            }
            catch { }
        }
        private void MonitorPackManagement_Shown(object sender, EventArgs e)
        {
            RefreshMonitorPack();
        }
        private void MonitorPackManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ToolStripManager.SaveSettings(this, "QuickMon.ConfigurationEditorToolbar");
            }
            catch { }
        }
        #endregion

        #region Toolbar & context menu & Button events
        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            string oldAgentsAssemblyPath = "";
            if (monitorPack != null && monitorPack.AgentsAssemblyPath.Length > 0)
                oldAgentsAssemblyPath = monitorPack.AgentsAssemblyPath;
            monitorPack = new MonitorPack() { AgentsAssemblyPath = oldAgentsAssemblyPath };
            RefreshMonitorPack();
        }
        private void toolStripoad_Click(object sender, EventArgs e)
        {
            try
            {
                string startUpPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.DoNotVerify), "Hen IT\\QuickMon");
                if (!System.IO.Directory.Exists(startUpPath))
                    System.IO.Directory.CreateDirectory(startUpPath);
                openFileDialogOpen.InitialDirectory = startUpPath;
                openFileDialogOpen.FileName = filePathtoolStripStatusLabel.Text;

                if (openFileDialogOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    monitorPack = new MonitorPack();
                    monitorPack.Load(openFileDialogOpen.FileName);
                    filePathtoolStripStatusLabel.Text = openFileDialogOpen.FileName;
                    RefreshMonitorPack();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Open", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void recentToolStripButton_Click(object sender, EventArgs e)
        {
            RecentMonitorPacks recentMonitorPacks = new RecentMonitorPacks();
            if (recentMonitorPacks.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                monitorPack = new MonitorPack();
                monitorPack.Load(recentMonitorPacks.SelectedPack);
                filePathtoolStripStatusLabel.Text = recentMonitorPacks.SelectedPack;
                RefreshMonitorPack();
            }
        }
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                string startUpPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.DoNotVerify), "Hen IT\\QuickMon");
                if (!System.IO.Directory.Exists(startUpPath))
                    System.IO.Directory.CreateDirectory(startUpPath);
                saveFileDialogSave.InitialDirectory = startUpPath;
                saveFileDialogSave.FileName = filePathtoolStripStatusLabel.Text;
                if (saveFileDialogSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SortItemsByTreeView();
                    monitorPack.Name = txtName.Text;
                    monitorPack.Enabled = chkEnabled.Checked;
                    monitorPack.DefaultViewerNotifier = (from n in monitorPack.Notifiers
                                                         where cboDefaultViewerNotifier.SelectedIndex > -1 &&
                                                            n.Notifier.HasViewer && n.Name == cboDefaultViewerNotifier.SelectedItem.ToString()
                                                         select n).FirstOrDefault();
                    monitorPack.RunCorrectiveScripts = chkRunCorrectiveScripts.Checked;
                    monitorPack.Save(saveFileDialogSave.FileName);
                    filePathtoolStripStatusLabel.Text = saveFileDialogSave.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvwMonPack.SelectedNode;
            if ((currentNode.Tag != null && currentNode.Tag is CollectorEntry) ||
                (currentNode.Tag == null && currentNode.Text == "Collectors"))
            {
                EditCollectorEntry editCollectorEntry = new EditCollectorEntry();
                if (currentNode.Tag is CollectorEntry)
                    editCollectorEntry.SelectedEntry.ParentCollectorId = ((CollectorEntry)currentNode.Tag).UniqueId;
                if (editCollectorEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
                {
                    monitorPack.Collectors.Add(editCollectorEntry.SelectedEntry);
                    if (editCollectorEntry.SelectedEntry.ParentCollectorId != null && editCollectorEntry.SelectedEntry.ParentCollectorId.Length > 0)
                    {
                        TreeNode collectorRootNode = (from TreeNode n in tvwMonPack.Nodes[0].Nodes
                                                  where n.Name == "Collectors"
                                                  select n).First();
                        currentNode = SelectCollectorNodeById(editCollectorEntry.SelectedEntry.ParentCollectorId, collectorRootNode);
                        if (currentNode == null)
                            currentNode = collectorRootNode; //should never happen really but if...
                    }
                    LoadCollectorEntry(editCollectorEntry.SelectedEntry, currentNode);
                    currentNode.Expand();
                }
            }
            else if (currentNode.Tag == null && currentNode.Text == "Notifiers")
            {
                EditNotifierEntry editNotifierEntry = new EditNotifierEntry();
                if (editNotifierEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
                {
                    monitorPack.Notifiers.Add(editNotifierEntry.SelectedEntry);
                    LoadNotifierEntry(editNotifierEntry.SelectedEntry, currentNode);
                    if (editNotifierEntry.SelectedEntry.Notifier!= null && editNotifierEntry.SelectedEntry.Notifier.HasViewer)
                        cboDefaultViewerNotifier.Items.Add(editNotifierEntry.SelectedEntry.Name);
                }
            }
        }
        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvwMonPack.SelectedNode;
            if (currentNode.Tag != null && currentNode.Tag is CollectorEntry)
            {
                CollectorEntry ce = (CollectorEntry)currentNode.Tag;
                EditCollectorEntry editCollectorEntry = new EditCollectorEntry();
                string oldParent = ce.ParentCollectorId;
                editCollectorEntry.SelectedEntry = ce;
                if (editCollectorEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
                {
                    ce = editCollectorEntry.SelectedEntry;
                    string uniqueId = ce.UniqueId;
                    RefreshMonitorPack();
                    TreeNode collectorRootNode = (from TreeNode n in tvwMonPack.Nodes[0].Nodes
                                                  where n.Name == "Collectors"
                                                  select n).First();
                    SelectCollectorNodeById(uniqueId, collectorRootNode);
                }
            }
            else if (currentNode.Tag != null && currentNode.Tag is NotifierEntry)
            {
                NotifierEntry ne = (NotifierEntry)currentNode.Tag; ;
                EditNotifierEntry editNotifierEntry = new EditNotifierEntry();
                editNotifierEntry.SelectedEntry = ne;
                if (editNotifierEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
                {
                    RefreshMonitorPack();
                }
            }
        }
        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvwMonPack.SelectedNode;
            if (currentNode.Tag != null)
            {
                if (currentNode.Tag is CollectorEntry)
                {
                    CollectorEntry ce = (CollectorEntry)currentNode.Tag;
                    ce.Enabled = !ce.Enabled;
                    currentNode.Tag = ce;
                    enableToolStripMenuItem.Text = ce.Enabled ? "Disable" : "Enable";
                    if (!ce.Enabled)
                        currentNode.ForeColor = Color.Gray;
                    else
                        currentNode.ForeColor = SystemColors.WindowText;
                }
                else if (currentNode.Tag is NotifierEntry)
                {
                    NotifierEntry ne = (NotifierEntry)currentNode.Tag;
                    ne.Enabled = !ne.Enabled;
                    currentNode.Tag = ne;
                    enableToolStripMenuItem.Text = ne.Enabled ? "Disable" : "Enable";
                    if (!ne.Enabled)
                        currentNode.ForeColor = Color.Gray;
                    else
                        currentNode.ForeColor = SystemColors.WindowText;
                }
            }
        }
        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvwMonPack.SelectedNode;
            if (currentNode.Tag is CollectorEntry)
            {
                if (MessageBox.Show("Are you sure you want to remove this collector agent(and all possible dependants)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    RemoveCollector(currentNode);
                    RefreshMonitorPack();
                }
            }
            else if (currentNode.Tag is NotifierEntry)
            {
                if (MessageBox.Show("Are you sure you want to remove this notifier agent?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    RemoveNotifier(currentNode);
                    RefreshMonitorPack();
                }
            }
        }
        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvwMonPack.SelectedNode;
            if ((currentNode.ImageIndex == collectorImgIndex || currentNode.ImageIndex == notifierImgIndex || currentNode.ImageIndex == folderImgIndex) && currentNode.Parent.FirstNode != currentNode)
            {
                TreeNode parentNode = currentNode.Parent;
                int currentIndex = currentNode.Index;
                TreeNode siblingAbove = parentNode.Nodes[currentIndex - 1];

                tvwMonPack.BeginUpdate();
                parentNode.Nodes.RemoveAt(currentIndex);
                parentNode.Nodes.RemoveAt(currentIndex - 1);
                parentNode.Nodes.Insert(currentIndex - 1, currentNode);
                parentNode.Nodes.Insert(currentIndex, siblingAbove);
                currentNode.EnsureVisible();
                tvwMonPack.SelectedNode = currentNode;
                tvwMonPack.Focus();
                tvwMonPack.EndUpdate();

                if (currentNode.Tag is CollectorEntry)
                {
                    monitorPack.SwapCollectorEntries((CollectorEntry)currentNode.Tag, (CollectorEntry)siblingAbove.Tag);
                }
                else if (currentNode.Tag is NotifierEntry)
                {
                    monitorPack.SwapNotifierEntries((NotifierEntry)currentNode.Tag, (NotifierEntry)siblingAbove.Tag);
                }
            }
        }
        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvwMonPack.SelectedNode;
            if ((currentNode.ImageIndex == collectorImgIndex || currentNode.ImageIndex == notifierImgIndex || currentNode.ImageIndex == folderImgIndex) && currentNode.Parent.LastNode != currentNode)
            {
                TreeNode parentNode = currentNode.Parent;
                int currentIndex = currentNode.Index;
                TreeNode siblingBelow = parentNode.Nodes[currentIndex + 1];

                tvwMonPack.BeginUpdate();
                parentNode.Nodes.RemoveAt(currentIndex + 1);
                parentNode.Nodes.RemoveAt(currentIndex);                
                parentNode.Nodes.Insert(currentIndex, siblingBelow);
                parentNode.Nodes.Insert(currentIndex + 1, currentNode);
                currentNode.EnsureVisible();
                tvwMonPack.SelectedNode = currentNode;
                tvwMonPack.Focus();
                tvwMonPack.EndUpdate();

                if (currentNode.Tag is CollectorEntry)
                {
                    monitorPack.SwapCollectorEntries((CollectorEntry)siblingBelow.Tag, (CollectorEntry)currentNode.Tag);
                }
                else if (currentNode.Tag is NotifierEntry)
                {
                    monitorPack.SwapNotifierEntries((NotifierEntry)siblingBelow.Tag, (NotifierEntry)currentNode.Tag);
                }
            }
        }
        private void infoToolStripButton_Click(object sender, EventArgs e)
        {
            //string info = string.Format("QuickMon config editor\r\nVersion {0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            //MessageBox.Show(info, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AboutQuickMon aboutQuickMon = new AboutQuickMon();
            aboutQuickMon.ShowDialog();
        }
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = txtAgentsRegistrationFile.Text;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    monitorPack.AgentsAssemblyPath = fbd.SelectedPath;
                    monitorPack.Name = txtName.Text; //in case it was changed
                    monitorPack.Enabled = chkEnabled.Checked;
                    RefreshMonitorPack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loading agents", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //RegisteredAgentsManagement registeredAgentsManagement = new RegisteredAgentsManagement();
            //registeredAgentsManagement.FilePath = monitorPack.AgentRegistrationFile;
            //if (registeredAgentsManagement.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    monitorPack.AgentRegistrationFile = registeredAgentsManagement.FilePath;
            //    monitorPack.Name = txtName.Text; //in case it was changed
            //    monitorPack.Enabled = chkEnabled.Checked;
            //    RefreshMonitorPack();
            //}
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Length == 0)
                {
                    MessageBox.Show("Please specify a name!", "Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtName.Focus();
                    return;
                }
                SortItemsByTreeView();

                monitorPack.Name = txtName.Text.Trim();
                if (monitorPack.MonitorPackPath != null && monitorPack.MonitorPackPath.Length > 0 && monitorPack.Name.Length == 0)
                    monitorPack.Name = System.IO.Path.GetFileNameWithoutExtension(monitorPack.MonitorPackPath);
                monitorPack.Enabled = chkEnabled.Checked;
                monitorPack.DefaultViewerNotifier = (from n in monitorPack.Notifiers
                                                     where cboDefaultViewerNotifier.SelectedIndex > -1 &&
                                                        n.Notifier.HasViewer && n.Name == cboDefaultViewerNotifier.SelectedItem.ToString()
                                                     select n).FirstOrDefault();
                monitorPack.RunCorrectiveScripts = chkRunCorrectiveScripts.Checked;
                //save any changes
                if (monitorPack.MonitorPackPath == null || !monitorPack.Save())
                {
                    string startUpPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.DoNotVerify), "Hen IT\\QuickMon");
                    if (!System.IO.Directory.Exists(startUpPath))
                        System.IO.Directory.CreateDirectory(startUpPath);
                    saveFileDialogSave.InitialDirectory = startUpPath;
                    saveFileDialogSave.FileName = monitorPack.Name;
                    if (saveFileDialogSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {                        
                        monitorPack.Save(saveFileDialogSave.FileName);
                    }
                }
                MonitorPackPath = monitorPack.MonitorPackPath;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region TreeView events
        private void tvwMonPack_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!backgroundWorkerNodeSelection.IsBusy)
            {
                backgroundWorkerNodeSelection.RunWorkerAsync();
            }
        }
        private void tvwMonPack_ItemDrag(object sender, ItemDragEventArgs e)
        {
            dragNode = (TreeNode)e.Item;
            if (dragNode.ImageIndex == folderImgIndex || dragNode.ImageIndex == collectorImgIndex || dragNode.ImageIndex == notifierImgIndex)
                DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private void tvwMonPack_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", true))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = tvwMonPack.GetNodeAt(pt);
                //Select the node currently under the cursor
                if (AllowTreeNodeDrop(dragNode, targetNode))
                {
                    e.Effect = DragDropEffects.Move;
                    return;
                }
            }
            e.Effect = DragDropEffects.None; 
        }
        private void tvwMonPack_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", true))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = tvwMonPack.GetNodeAt(pt);
                if (AllowTreeNodeDrop(dragNode, targetNode))
                {
                    TreeNode oldParent = dragNode.Parent;
                    if (dragNode != targetNode)
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
                    else if (oldParent.Parent.Text == "Monitor Pack Agent Instances")
                    {
                        //do nothing
                    }
                    else //append to parent's parent
                    {
                        oldParent.Nodes.Remove(dragNode);
                        oldParent.Parent.Nodes.Add(dragNode);
                    }
                    tvwMonPack.SelectedNode = dragNode;
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
                }
            }
        }
        private bool AllowTreeNodeDrop(TreeNode dragItem, TreeNode targetItem)
        {
            if (targetItem == null)// || dragItem == targetItem)
                return false;
            int dragImgIndex = dragItem.ImageIndex;
            int targetImgIndex = targetItem.ImageIndex;
            //is collector
            if (dragImgIndex == folderImgIndex || dragImgIndex == collectorImgIndex)
            {
                if (targetImgIndex == collectorRootImgIndex)
                    return true;
                else if (targetImgIndex == folderImgIndex || targetImgIndex == collectorImgIndex)
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
                else
                    return false;
            }
            else if (dragImgIndex == notifierImgIndex)
            {
                if (targetImgIndex == notifierRootImgIndex)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        private void tvwMonPack_DoubleClick(object sender, EventArgs e)
        {
            if (tvwMonPack.SelectedNode != null && (tvwMonPack.SelectedNode.ImageIndex == collectorImgIndex || tvwMonPack.SelectedNode.ImageIndex == folderImgIndex || tvwMonPack.SelectedNode.ImageIndex == notifierImgIndex) &&
                        tvwMonPack.SelectedNode.Nodes.Count == 0)
                ShowEdit();
        }
        private void tvwMonPack_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (tvwMonPack.SelectedNode != null)
            {
                if (tvwMonPack.SelectedNode.ImageIndex <= 0 && !tvwMonPack.SelectedNode.IsExpanded)
                    tvwMonPack.SelectedNode.Expand();
            }
        }
        private void tvwMonPack_EnterKeyPressed()
        {
            ShowEdit();
        }
        private void tvwMonPack_DeleteKeyPressed()
        {
            toolStripButtonRemove_Click(null, null);
        }
        #endregion

        #region Private methods
        private void RefreshMonitorPack()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (monitorPack == null)
                    monitorPack = new MonitorPack();
                txtName.Text = monitorPack.Name;
                chkEnabled.Checked = monitorPack.Enabled;
                txtAgentsRegistrationFile.Text = monitorPack.AgentsAssemblyPath;
                chkRunCorrectiveScripts.Checked = monitorPack.RunCorrectiveScripts;
                TreeNode root = tvwMonPack.Nodes[0];
                tvwMonPack.BeginUpdate();
                root.Expand();

                TreeNode collectorRootNode = (from TreeNode n in root.Nodes
                                              where n.Name == "Collectors"
                                              select n).First();
                collectorRootNode.Nodes.Clear();
                foreach (CollectorEntry ce in monitorPack.GetRootCollectors()) //(from c in monitorPack.Collectors 
                                               //where c.ParentCollectorId.Length == 0
                                               //select c)
                {
                    LoadCollectorEntry(ce, collectorRootNode);
                }
                TreeNode notifierRootNode = (from TreeNode n in root.Nodes
                                             where n.Name == "Notifiers"
                                             select n).First();
                notifierRootNode.Nodes.Clear();
                cboDefaultViewerNotifier.Items.Clear();
                foreach (NotifierEntry ne in monitorPack.Notifiers)
                {
                    LoadNotifierEntry(ne, notifierRootNode);
                    if (ne.Notifier != null && ne.Notifier.HasViewer)
                        cboDefaultViewerNotifier.Items.Add(ne.Name);
                }
                if (monitorPack.DefaultViewerNotifier != null)
                    cboDefaultViewerNotifier.SelectedItem = monitorPack.DefaultViewerNotifier.Name;

                collectorRootNode.Expand();
                notifierRootNode.Expand();
                root.EnsureVisible();
                tvwMonPack.SelectedNode = root;
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tvwMonPack.EndUpdate();
                Cursor.Current = Cursors.Default;
            }
            EnableContextMenus();
            EnableOKButton();
        }
        private void ShowAgentRegistrations(TreeNode root)
        {
            TreeNode agentConfigNode = (from TreeNode n in root.Nodes
                                        where n.Name == "AgentConfig"
                                        select n).First();

            TreeNode AgentRegistrationNode = (from TreeNode n in agentConfigNode.Nodes
                                              where n.Name == "AgentRegistrationFile"
                                                       select n).First();
            AgentRegistrationNode.Text = "Registered Agents Path: " + monitorPack.AgentsAssemblyPath;
            if (!System.IO.Directory.Exists(monitorPack.AgentsAssemblyPath))
                agentConfigNode.Expand();
        }
        private void LoadNotifierEntry(NotifierEntry ne, TreeNode parentNode)
        {
            TreeNode neNode = new TreeNode(ne.NotifierRegistrationName + ": " + ne.Name, 2, 2);
            neNode.Tag = ne;
            parentNode.Nodes.Add(neNode);
            if (monitorPack.AgentRegistrations == null || (from nr in monitorPack.AgentRegistrations
                 where nr.IsNotifier && nr.Name == ne.NotifierRegistrationName
                 select nr).Count() != 1)
            {
                neNode.ForeColor = Color.Red;
            }
            else if (!ne.Enabled)
            {
                neNode.ForeColor = Color.Gray;
            }
        }
        private void LoadCollectorEntry(CollectorEntry ce, TreeNode parentNode)
        {
            TreeNode ceNode;            
            if (ce.IsFolder)
            {
                ceNode = new TreeNode(ce.Name, 6, 6);
            }
            else
                ceNode = new TreeNode(ce.CollectorRegistrationName + ": " + ce.Name, 1, 1);
            ceNode.Tag = ce;
            parentNode.Nodes.Add(ceNode);
            if (!ce.IsFolder && (monitorPack.AgentRegistrations == null || (from cr in monitorPack.AgentRegistrations
                                                           where cr.IsCollector && cr.Name == ce.CollectorRegistrationName
                                                           select cr).Count() != 1))
            {
                ceNode.ForeColor = Color.Red;
            }
            else if (! ce.Enabled)
            {
                ceNode.ForeColor = Color.Gray;
            }

            foreach (CollectorEntry childCollector in monitorPack.GetChildCollectors(ce))
            {
                LoadCollectorEntry(childCollector, ceNode);
            }
        }     
        private void EnableContextMenus()
        {            
            TreeNode currentNode = tvwMonPack.SelectedNode;
            bool hasAgents = monitorPack.AgentRegistrations.Count > 0 && monitorPack.AgentsAssemblyPath.Length > 0;
            bool canAdd = false;
            bool canRemove = false;
            bool canConfig = false;
            bool canMoveUp = false;
            bool canMoveDown = false;
            exportSelectedToolStripMenuItem.Enabled = false;
            if (currentNode != null)
            {
                canAdd = currentNode.ImageIndex == collectorImgIndex || currentNode.ImageIndex == collectorRootImgIndex || currentNode.ImageIndex == notifierRootImgIndex || currentNode.ImageIndex == folderImgIndex;
                canRemove = currentNode.ImageIndex == collectorImgIndex || currentNode.ImageIndex == notifierImgIndex || currentNode.ImageIndex == folderImgIndex;
                canConfig = currentNode.ImageIndex == collectorImgIndex || currentNode.ImageIndex == notifierImgIndex || currentNode.ImageIndex == folderImgIndex; //|| currentNode.ImageIndex == collectorRootImgIndex
                canMoveUp = (currentNode.ImageIndex == collectorImgIndex || currentNode.ImageIndex == notifierImgIndex || currentNode.ImageIndex == folderImgIndex) && currentNode.Parent.FirstNode != currentNode;
                canMoveDown = (currentNode.ImageIndex == collectorImgIndex || currentNode.ImageIndex == notifierImgIndex || currentNode.ImageIndex == folderImgIndex) && currentNode.Parent.LastNode != currentNode;

                if (currentNode.ImageIndex == collectorImgIndex || currentNode.ImageIndex == folderImgIndex)
                {
                    enableToolStripMenuItem.Text = ((CollectorEntry)currentNode.Tag).Enabled ? "Disable" : "Enable";
                    enableToolStripMenuItem.Visible = true;
                    exportSelectedToolStripMenuItem.Enabled = true;
                }
                else if (currentNode.ImageIndex == notifierImgIndex)
                {
                    enableToolStripMenuItem.Text = ((NotifierEntry)currentNode.Tag).Enabled ? "Disable" : "Enable";
                    enableToolStripMenuItem.Visible = true;
                }
                else
                    enableToolStripMenuItem.Visible = false;
            }
            else
                enableToolStripMenuItem.Visible = false;

            toolStripButtonAdd.Enabled = canAdd && hasAgents;
            addToolStripMenuItem.Enabled = canAdd && hasAgents;
            toolStripButtonRemove.Enabled = canRemove && hasAgents;
            removeToolStripMenuItem.Enabled = canRemove && hasAgents;
            toolStripButtonConfigure.Enabled = canConfig && hasAgents;
            configureToolStripMenuItem.Enabled = canConfig && hasAgents;

            moveUpToolStripMenuItem.Enabled = canMoveUp && hasAgents;
            moveUpToolStripButton.Enabled = canMoveUp && hasAgents;
            moveDownToolStripMenuItem.Enabled = canMoveDown && hasAgents;
            moveDownToolStripButton.Enabled = canMoveDown && hasAgents;
        }
        private void EnableOKButton()
        {
            cmdOK.Enabled = monitorPack != null &&
                monitorPack.AgentsAssemblyPath != null && System.IO.Directory.Exists(monitorPack.AgentsAssemblyPath);
        }            
        private void backgroundWorkerNodeSelection_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            try
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    EnableContextMenus();
                });
            }
            catch { }
        }
        private TreeNode SelectCollectorNodeById(string uniqueId, TreeNode parentNode)
        {
            foreach (TreeNode collectorNode in parentNode.Nodes)
            {
                if (collectorNode.Tag is CollectorEntry && ((CollectorEntry)collectorNode.Tag).UniqueId == uniqueId)
                {
                    tvwMonPack.SelectedNode = collectorNode;
                    collectorNode.EnsureVisible();
                    return collectorNode;
                }
                else
                {
                    TreeNode n = SelectCollectorNodeById(uniqueId, collectorNode);
                    if (n != null)
                        return n;
                }
            }
            return null;
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
        private void RemoveNotifier(TreeNode parentNode)
        {
            foreach (TreeNode collectorNode in parentNode.Nodes)
            {
                RemoveCollector(collectorNode);
            }
            NotifierEntry ne = (NotifierEntry)parentNode.Tag;
            monitorPack.Notifiers.Remove(ne);
        }
        private void SortItemsByTreeView()
        {
            
            TreeNode root = tvwMonPack.Nodes[0];
            TreeNode collectorRootNode = (from TreeNode n in root.Nodes
                                          where n.Name == "Collectors"
                                          select n).First();

            List<CollectorEntry> sortedCollectors = new List<CollectorEntry>();
            AppendSortedCollectors(collectorRootNode, sortedCollectors);
            monitorPack.Collectors.Clear();
            //StringBuilder sb = new StringBuilder();
            foreach (CollectorEntry c in sortedCollectors)
            {
                monitorPack.Collectors.Add(c);
            }

            TreeNode notifierRootNode = (from TreeNode n in root.Nodes
                                         where n.Name == "Notifiers"
                                         select n).First();
            monitorPack.Notifiers.Clear();
            foreach (TreeNode childNode in notifierRootNode.Nodes)
            {
                if (childNode.Tag != null && childNode.Tag is NotifierEntry)
                {
                    monitorPack.Notifiers.Add((NotifierEntry)childNode.Tag);
                }
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
        private void ShowEdit()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (tvwMonPack.SelectedNode != null)
                    {
                        TreeNode currentNode = tvwMonPack.SelectedNode;
                        if (currentNode.Tag != null && currentNode.Tag is CollectorEntry)
                        {
                            CollectorEntry ce = (CollectorEntry)currentNode.Tag;
                            EditCollectorEntry editCollectorEntry = new EditCollectorEntry();
                            string oldParent = ce.ParentCollectorId;
                            editCollectorEntry.SelectedEntry = ce;
                            if (editCollectorEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
                            {
                                ce = editCollectorEntry.SelectedEntry;
                                string uniqueId = ce.UniqueId;
                                RefreshMonitorPack();
                                TreeNode collectorRootNode = (from TreeNode n in tvwMonPack.Nodes[0].Nodes
                                                              where n.Name == "Collectors"
                                                              select n).First();
                                SelectCollectorNodeById(uniqueId, collectorRootNode);
                            }
                        }
                        else if (currentNode.Tag != null && currentNode.Tag is NotifierEntry)
                        {
                            NotifierEntry ne = (NotifierEntry)currentNode.Tag; ;
                            EditNotifierEntry editNotifierEntry = new EditNotifierEntry();
                            editNotifierEntry.SelectedEntry = ne;
                            if (editNotifierEntry.ShowDialog(monitorPack) == System.Windows.Forms.DialogResult.OK)
                            {
                                RefreshMonitorPack();
                            }
                        }
                    }
                });
            });
        }
        #endregion

        private void exportSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode currentNode = tvwMonPack.SelectedNode;
                if (currentNode.ImageIndex == collectorImgIndex || currentNode.ImageIndex == folderImgIndex)
                {
                    List<CollectorEntry> list = new List<CollectorEntry>();
                    list.Add(((CollectorEntry)currentNode.Tag).Clone());
                    list[0].ParentCollectorId = "";
                    list.AddRange(monitorPack.GetAllChildCollectors((CollectorEntry)currentNode.Tag));

                    MonitorPack exportPack = new MonitorPack();
                    exportPack.Collectors.AddRange(list);

                    string startUpPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.DoNotVerify), "Hen IT\\QuickMon");
                    if (!System.IO.Directory.Exists(startUpPath))
                        System.IO.Directory.CreateDirectory(startUpPath);
                    saveFileDialogSave.InitialDirectory = startUpPath;
                    saveFileDialogSave.FileName = list[0].Name + " - Exported";
                    if (saveFileDialogSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        exportPack.Name = list[0].Name + " - Export";
                        exportPack.Enabled = true;
                        exportPack.DefaultViewerNotifier = null;
                        exportPack.Save(saveFileDialogSave.FileName);

                        if (MessageBox.Show("Do you want to load this exported monitor pack now?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            monitorPack = new MonitorPack();
                            monitorPack.Load(saveFileDialogSave.FileName);
                            filePathtoolStripStatusLabel.Text = saveFileDialogSave.FileName;
                            RefreshMonitorPack();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
    }
}
