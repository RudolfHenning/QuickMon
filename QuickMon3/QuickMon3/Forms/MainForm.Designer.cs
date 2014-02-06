namespace QuickMon
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Collectors");
            this.mainRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.openMonitorPackToolStripButton = new System.Windows.Forms.ToolStripSplitButton();
            this.newMonitorPackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.recentMonitorPackToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editMonitorPackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMonitorPackToolStripMenuItem = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.collectorToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.addCollectorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCollectorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCollectorDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultNotifierViewerToolStripSplitButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.showDefaultNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllNotifiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.addNotifierToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNotifierToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.generalSettingsToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.pollingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollingDisabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollingSlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollingNormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollingFastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customPollingFrequencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.knownRemoteAgentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllChildWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.refreshBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialogSave = new System.Windows.Forms.SaveFileDialog();
            this.collectorTreeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.collectorTreeViewDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCollectorFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collectorTreeEditConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableCollectorTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.monitorPackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMonitorPackToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openMonitorPackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentMonitorPacksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMonitorPackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollingFrequencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeImageList = new System.Windows.Forms.ImageList(this.components);
            this.llblMonitorPack = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tvwCollectors = new QuickMon.TreeViewEx();
            this.masterSplitContainer = new System.Windows.Forms.SplitContainer();
            this.agentSeparatorBox = new System.Windows.Forms.PictureBox();
            this.llblNotifierViewToggle = new System.Windows.Forms.LinkLabel();
            this.lblNoNotifiersYet = new System.Windows.Forms.Label();
            this.lvwNotifiers = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notifiersImageList = new System.Windows.Forms.ImageList(this.components);
            this.notifiersContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifierViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifierConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.showCollectorContextMenuTimer = new System.Windows.Forms.Timer(this.components);
            this.showNotifierContextMenuTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.collectorTreeContextMenuStrip.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterSplitContainer)).BeginInit();
            this.masterSplitContainer.Panel1.SuspendLayout();
            this.masterSplitContainer.Panel2.SuspendLayout();
            this.masterSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentSeparatorBox)).BeginInit();
            this.notifiersContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainRefreshTimer
            // 
            this.mainRefreshTimer.Interval = 10000;
            this.mainRefreshTimer.Tick += new System.EventHandler(this.mainRefreshTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::QuickMon.Properties.Resources.OrangeHeader1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.mainToolStrip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 61);
            this.panel1.TabIndex = 27;
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMonitorPackToolStripButton,
            this.saveAsMonitorPackToolStripMenuItem,
            this.refreshToolStripButton,
            this.collectorToolStripDropDownButton,
            this.defaultNotifierViewerToolStripSplitButton,
            this.generalSettingsToolStripSplitButton});
            this.mainToolStrip.Location = new System.Drawing.Point(4, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mainToolStrip.Size = new System.Drawing.Size(261, 39);
            this.mainToolStrip.TabIndex = 28;
            // 
            // openMonitorPackToolStripButton
            // 
            this.openMonitorPackToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openMonitorPackToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMonitorPackToolStripMenuItem,
            this.toolStripSeparator1,
            this.recentMonitorPackToolStripMenuItem1,
            this.editMonitorPackToolStripMenuItem});
            this.openMonitorPackToolStripButton.Image = global::QuickMon.Properties.Resources.folder;
            this.openMonitorPackToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openMonitorPackToolStripButton.Name = "openMonitorPackToolStripButton";
            this.openMonitorPackToolStripButton.Size = new System.Drawing.Size(48, 36);
            this.openMonitorPackToolStripButton.Text = "Monitor Pack Actions";
            this.openMonitorPackToolStripButton.ButtonClick += new System.EventHandler(this.openMonitorPackToolStripButton_ButtonClick);
            // 
            // newMonitorPackToolStripMenuItem
            // 
            this.newMonitorPackToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_new2;
            this.newMonitorPackToolStripMenuItem.Name = "newMonitorPackToolStripMenuItem";
            this.newMonitorPackToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.newMonitorPackToolStripMenuItem.Text = "New";
            this.newMonitorPackToolStripMenuItem.Click += new System.EventHandler(this.newMonitorPackToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(107, 6);
            // 
            // recentMonitorPackToolStripMenuItem1
            // 
            this.recentMonitorPackToolStripMenuItem1.Image = global::QuickMon.Properties.Resources.folder_favor;
            this.recentMonitorPackToolStripMenuItem1.Name = "recentMonitorPackToolStripMenuItem1";
            this.recentMonitorPackToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.recentMonitorPackToolStripMenuItem1.Text = "Recent";
            this.recentMonitorPackToolStripMenuItem1.Click += new System.EventHandler(this.recentMonitorPackToolStripMenuItem1_Click);
            // 
            // editMonitorPackToolStripMenuItem
            // 
            this.editMonitorPackToolStripMenuItem.Image = global::QuickMon.Properties.Resources.QEdit3;
            this.editMonitorPackToolStripMenuItem.Name = "editMonitorPackToolStripMenuItem";
            this.editMonitorPackToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.editMonitorPackToolStripMenuItem.Text = "Edit";
            this.editMonitorPackToolStripMenuItem.Visible = false;
            // 
            // saveAsMonitorPackToolStripMenuItem
            // 
            this.saveAsMonitorPackToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveAsMonitorPackToolStripMenuItem.Image = global::QuickMon.Properties.Resources.save;
            this.saveAsMonitorPackToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsMonitorPackToolStripMenuItem.Name = "saveAsMonitorPackToolStripMenuItem";
            this.saveAsMonitorPackToolStripMenuItem.Size = new System.Drawing.Size(36, 36);
            this.saveAsMonitorPackToolStripMenuItem.Text = "Save Monitor Pack as";
            this.saveAsMonitorPackToolStripMenuItem.Click += new System.EventHandler(this.saveAsMonitorPackToolStripMenuItem_Click);
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = global::QuickMon.Properties.Resources.refresh;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.refreshToolStripButton.Text = "Refresh";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // collectorToolStripDropDownButton
            // 
            this.collectorToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.collectorToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCollectorToolStripMenuItem1,
            this.addFolderCollectorToolStripMenuItem,
            this.editCollectorToolStripMenuItem,
            this.removeCollectorToolStripMenuItem1,
            this.viewCollectorDetailsToolStripMenuItem});
            this.collectorToolStripDropDownButton.Image = global::QuickMon.Properties.Resources.comp_search;
            this.collectorToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.collectorToolStripDropDownButton.Name = "collectorToolStripDropDownButton";
            this.collectorToolStripDropDownButton.Size = new System.Drawing.Size(45, 36);
            this.collectorToolStripDropDownButton.Text = "Collectors";
            // 
            // addCollectorToolStripMenuItem1
            // 
            this.addCollectorToolStripMenuItem1.Image = global::QuickMon.Properties.Resources.add;
            this.addCollectorToolStripMenuItem1.Name = "addCollectorToolStripMenuItem1";
            this.addCollectorToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.addCollectorToolStripMenuItem1.Text = "Add Collector";
            this.addCollectorToolStripMenuItem1.Click += new System.EventHandler(this.addCollectorToolStripMenuItem_Click);
            // 
            // addFolderCollectorToolStripMenuItem
            // 
            this.addFolderCollectorToolStripMenuItem.Image = global::QuickMon.Properties.Resources.folder_add;
            this.addFolderCollectorToolStripMenuItem.Name = "addFolderCollectorToolStripMenuItem";
            this.addFolderCollectorToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.addFolderCollectorToolStripMenuItem.Text = "Add Folder Collector";
            this.addFolderCollectorToolStripMenuItem.Click += new System.EventHandler(this.addCollectorFolderToolStripMenuItem_Click);
            // 
            // editCollectorToolStripMenuItem
            // 
            this.editCollectorToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_edit;
            this.editCollectorToolStripMenuItem.Name = "editCollectorToolStripMenuItem";
            this.editCollectorToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editCollectorToolStripMenuItem.Text = "Edit Collector";
            this.editCollectorToolStripMenuItem.Click += new System.EventHandler(this.collectorTreeEditConfigToolStripMenuItem_Click);
            // 
            // removeCollectorToolStripMenuItem1
            // 
            this.removeCollectorToolStripMenuItem1.Image = global::QuickMon.Properties.Resources.stop;
            this.removeCollectorToolStripMenuItem1.Name = "removeCollectorToolStripMenuItem1";
            this.removeCollectorToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.removeCollectorToolStripMenuItem1.Text = "Remove Collector";
            this.removeCollectorToolStripMenuItem1.Click += new System.EventHandler(this.removeCollectorToolStripMenuItem_Click);
            // 
            // viewCollectorDetailsToolStripMenuItem
            // 
            this.viewCollectorDetailsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.comp_search;
            this.viewCollectorDetailsToolStripMenuItem.Name = "viewCollectorDetailsToolStripMenuItem";
            this.viewCollectorDetailsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.viewCollectorDetailsToolStripMenuItem.Text = "View Collector Details";
            this.viewCollectorDetailsToolStripMenuItem.Click += new System.EventHandler(this.collectorTreeViewDetailsToolStripMenuItem_Click);
            // 
            // defaultNotifierViewerToolStripSplitButton
            // 
            this.defaultNotifierViewerToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.defaultNotifierViewerToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDefaultNotifierToolStripMenuItem,
            this.showAllNotifiersToolStripMenuItem,
            this.toolStripMenuItem2,
            this.addNotifierToolStripMenuItem1,
            this.editNotifierToolStripMenuItem,
            this.removeNotifierToolStripMenuItem1});
            this.defaultNotifierViewerToolStripSplitButton.Image = global::QuickMon.Properties.Resources.onebit_20;
            this.defaultNotifierViewerToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.defaultNotifierViewerToolStripSplitButton.Name = "defaultNotifierViewerToolStripSplitButton";
            this.defaultNotifierViewerToolStripSplitButton.Size = new System.Drawing.Size(45, 36);
            this.defaultNotifierViewerToolStripSplitButton.Text = "Notifiers";
            // 
            // showDefaultNotifierToolStripMenuItem
            // 
            this.showDefaultNotifierToolStripMenuItem.Image = global::QuickMon.Properties.Resources.comp_search;
            this.showDefaultNotifierToolStripMenuItem.Name = "showDefaultNotifierToolStripMenuItem";
            this.showDefaultNotifierToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.showDefaultNotifierToolStripMenuItem.Text = "Show Default Notifier";
            this.showDefaultNotifierToolStripMenuItem.Click += new System.EventHandler(this.showDefaultNotifierToolStripMenuItem_Click);
            // 
            // showAllNotifiersToolStripMenuItem
            // 
            this.showAllNotifiersToolStripMenuItem.Image = global::QuickMon.Properties.Resources.thunderbolt;
            this.showAllNotifiersToolStripMenuItem.Name = "showAllNotifiersToolStripMenuItem";
            this.showAllNotifiersToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.showAllNotifiersToolStripMenuItem.Text = "Show All Notifiers";
            this.showAllNotifiersToolStripMenuItem.Click += new System.EventHandler(this.showAllNotifiersToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(184, 6);
            // 
            // addNotifierToolStripMenuItem1
            // 
            this.addNotifierToolStripMenuItem1.Image = global::QuickMon.Properties.Resources.add;
            this.addNotifierToolStripMenuItem1.Name = "addNotifierToolStripMenuItem1";
            this.addNotifierToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.addNotifierToolStripMenuItem1.Text = "Add Notifier";
            this.addNotifierToolStripMenuItem1.Click += new System.EventHandler(this.addNotifierToolStripMenuItem_Click);
            // 
            // editNotifierToolStripMenuItem
            // 
            this.editNotifierToolStripMenuItem.Enabled = false;
            this.editNotifierToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_edit;
            this.editNotifierToolStripMenuItem.Name = "editNotifierToolStripMenuItem";
            this.editNotifierToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.editNotifierToolStripMenuItem.Text = "Edit Notifier Config";
            this.editNotifierToolStripMenuItem.Click += new System.EventHandler(this.notifierConfigurationToolStripMenuItem_Click);
            // 
            // removeNotifierToolStripMenuItem1
            // 
            this.removeNotifierToolStripMenuItem1.Enabled = false;
            this.removeNotifierToolStripMenuItem1.Image = global::QuickMon.Properties.Resources.stop;
            this.removeNotifierToolStripMenuItem1.Name = "removeNotifierToolStripMenuItem1";
            this.removeNotifierToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.removeNotifierToolStripMenuItem1.Text = "Remove Notifier";
            this.removeNotifierToolStripMenuItem1.Click += new System.EventHandler(this.removeNotifierToolStripMenuItem_Click);
            // 
            // generalSettingsToolStripSplitButton
            // 
            this.generalSettingsToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.generalSettingsToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pollingToolStripMenuItem,
            this.knownRemoteAgentsToolStripMenuItem,
            this.closeAllChildWindowsToolStripMenuItem});
            this.generalSettingsToolStripSplitButton.Image = global::QuickMon.Properties.Resources.tools;
            this.generalSettingsToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.generalSettingsToolStripSplitButton.Name = "generalSettingsToolStripSplitButton";
            this.generalSettingsToolStripSplitButton.Size = new System.Drawing.Size(48, 36);
            this.generalSettingsToolStripSplitButton.Text = "Tools";
            this.generalSettingsToolStripSplitButton.ButtonClick += new System.EventHandler(this.generalSettingsToolStripSplitButton_ButtonClick);
            // 
            // pollingToolStripMenuItem
            // 
            this.pollingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pollingDisabledToolStripMenuItem,
            this.pollingSlowToolStripMenuItem,
            this.pollingNormalToolStripMenuItem,
            this.pollingFastToolStripMenuItem,
            this.customPollingFrequencyToolStripMenuItem});
            this.pollingToolStripMenuItem.Image = global::QuickMon.Properties.Resources.clock;
            this.pollingToolStripMenuItem.Name = "pollingToolStripMenuItem";
            this.pollingToolStripMenuItem.Size = new System.Drawing.Size(219, 38);
            this.pollingToolStripMenuItem.Text = "Polling";
            // 
            // pollingDisabledToolStripMenuItem
            // 
            this.pollingDisabledToolStripMenuItem.Name = "pollingDisabledToolStripMenuItem";
            this.pollingDisabledToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pollingDisabledToolStripMenuItem.Text = "Disabled";
            this.pollingDisabledToolStripMenuItem.Click += new System.EventHandler(this.pollingDisabledToolStripMenuItem_Click);
            // 
            // pollingSlowToolStripMenuItem
            // 
            this.pollingSlowToolStripMenuItem.Name = "pollingSlowToolStripMenuItem";
            this.pollingSlowToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pollingSlowToolStripMenuItem.Text = "Slow";
            this.pollingSlowToolStripMenuItem.Click += new System.EventHandler(this.pollingSlowToolStripMenuItem_Click);
            // 
            // pollingNormalToolStripMenuItem
            // 
            this.pollingNormalToolStripMenuItem.Name = "pollingNormalToolStripMenuItem";
            this.pollingNormalToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pollingNormalToolStripMenuItem.Text = "Normal";
            this.pollingNormalToolStripMenuItem.Click += new System.EventHandler(this.pollingNormalToolStripMenuItem_Click);
            // 
            // pollingFastToolStripMenuItem
            // 
            this.pollingFastToolStripMenuItem.Name = "pollingFastToolStripMenuItem";
            this.pollingFastToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pollingFastToolStripMenuItem.Text = "Fast";
            this.pollingFastToolStripMenuItem.Click += new System.EventHandler(this.pollingFastToolStripMenuItem_Click);
            // 
            // customPollingFrequencyToolStripMenuItem
            // 
            this.customPollingFrequencyToolStripMenuItem.Name = "customPollingFrequencyToolStripMenuItem";
            this.customPollingFrequencyToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.customPollingFrequencyToolStripMenuItem.Text = "Custom Frequency";
            this.customPollingFrequencyToolStripMenuItem.Click += new System.EventHandler(this.customPollingFrequencyToolStripMenuItem_Click);
            // 
            // knownRemoteAgentsToolStripMenuItem
            // 
            this.knownRemoteAgentsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.Charon;
            this.knownRemoteAgentsToolStripMenuItem.Name = "knownRemoteAgentsToolStripMenuItem";
            this.knownRemoteAgentsToolStripMenuItem.Size = new System.Drawing.Size(219, 38);
            this.knownRemoteAgentsToolStripMenuItem.Text = "Known Remote Agents";
            this.knownRemoteAgentsToolStripMenuItem.Click += new System.EventHandler(this.knownRemoteAgentsToolStripMenuItem_Click);
            // 
            // closeAllChildWindowsToolStripMenuItem
            // 
            this.closeAllChildWindowsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.tables;
            this.closeAllChildWindowsToolStripMenuItem.Name = "closeAllChildWindowsToolStripMenuItem";
            this.closeAllChildWindowsToolStripMenuItem.Size = new System.Drawing.Size(219, 38);
            this.closeAllChildWindowsToolStripMenuItem.Text = "Close All Child Windows";
            this.closeAllChildWindowsToolStripMenuItem.Click += new System.EventHandler(this.closeAllChildWindowsToolStripMenuItem_Click);
            // 
            // openFileDialogOpen
            // 
            this.openFileDialogOpen.DefaultExt = "qmconfig";
            this.openFileDialogOpen.Filter = "QuickMon config files|*.qmconfig";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 473);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(461, 22);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(446, 17);
            this.toolStripStatusLabelStatus.Spring = true;
            this.toolStripStatusLabelStatus.Text = ".";
            this.toolStripStatusLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // refreshBackgroundWorker
            // 
            this.refreshBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.refreshBackgroundWorker_DoWork);
            // 
            // saveFileDialogSave
            // 
            this.saveFileDialogSave.DefaultExt = "qmconfig";
            this.saveFileDialogSave.Filter = "QuickMon config files|*.qmconfig";
            // 
            // collectorTreeContextMenuStrip
            // 
            this.collectorTreeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collectorTreeViewDetailsToolStripMenuItem,
            this.toolStripSeparator2,
            this.addCollectorToolStripMenuItem,
            this.addCollectorFolderToolStripMenuItem,
            this.collectorTreeEditConfigToolStripMenuItem,
            this.disableCollectorTreeToolStripMenuItem,
            this.removeCollectorToolStripMenuItem,
            this.toolStripMenuItem3,
            this.monitorPackToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.toolStripMenuItem4,
            this.refreshToolStripMenuItem});
            this.collectorTreeContextMenuStrip.Name = "collectorTileContextMenuStrip";
            this.collectorTreeContextMenuStrip.Size = new System.Drawing.Size(169, 220);
            // 
            // collectorTreeViewDetailsToolStripMenuItem
            // 
            this.collectorTreeViewDetailsToolStripMenuItem.Enabled = false;
            this.collectorTreeViewDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collectorTreeViewDetailsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.comp_search;
            this.collectorTreeViewDetailsToolStripMenuItem.Name = "collectorTreeViewDetailsToolStripMenuItem";
            this.collectorTreeViewDetailsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.collectorTreeViewDetailsToolStripMenuItem.Text = "View details";
            this.collectorTreeViewDetailsToolStripMenuItem.Click += new System.EventHandler(this.collectorTreeViewDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // addCollectorToolStripMenuItem
            // 
            this.addCollectorToolStripMenuItem.Image = global::QuickMon.Properties.Resources.add;
            this.addCollectorToolStripMenuItem.Name = "addCollectorToolStripMenuItem";
            this.addCollectorToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.addCollectorToolStripMenuItem.Text = "Add Collector";
            this.addCollectorToolStripMenuItem.Click += new System.EventHandler(this.addCollectorToolStripMenuItem_Click);
            // 
            // addCollectorFolderToolStripMenuItem
            // 
            this.addCollectorFolderToolStripMenuItem.Image = global::QuickMon.Properties.Resources.folder_add;
            this.addCollectorFolderToolStripMenuItem.Name = "addCollectorFolderToolStripMenuItem";
            this.addCollectorFolderToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.addCollectorFolderToolStripMenuItem.Text = "Add Folder";
            this.addCollectorFolderToolStripMenuItem.Click += new System.EventHandler(this.addCollectorFolderToolStripMenuItem_Click);
            // 
            // collectorTreeEditConfigToolStripMenuItem
            // 
            this.collectorTreeEditConfigToolStripMenuItem.Enabled = false;
            this.collectorTreeEditConfigToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_edit;
            this.collectorTreeEditConfigToolStripMenuItem.Name = "collectorTreeEditConfigToolStripMenuItem";
            this.collectorTreeEditConfigToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.collectorTreeEditConfigToolStripMenuItem.Text = "Edit Config";
            this.collectorTreeEditConfigToolStripMenuItem.Click += new System.EventHandler(this.collectorTreeEditConfigToolStripMenuItem_Click);
            // 
            // disableCollectorTreeToolStripMenuItem
            // 
            this.disableCollectorTreeToolStripMenuItem.Enabled = false;
            this.disableCollectorTreeToolStripMenuItem.Name = "disableCollectorTreeToolStripMenuItem";
            this.disableCollectorTreeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.disableCollectorTreeToolStripMenuItem.Text = "Disable Collector";
            this.disableCollectorTreeToolStripMenuItem.Click += new System.EventHandler(this.disableCollectorTreeToolStripMenuItem_Click);
            // 
            // removeCollectorToolStripMenuItem
            // 
            this.removeCollectorToolStripMenuItem.Enabled = false;
            this.removeCollectorToolStripMenuItem.Image = global::QuickMon.Properties.Resources.whack;
            this.removeCollectorToolStripMenuItem.Name = "removeCollectorToolStripMenuItem";
            this.removeCollectorToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.removeCollectorToolStripMenuItem.Text = "Remove Collector";
            this.removeCollectorToolStripMenuItem.Click += new System.EventHandler(this.removeCollectorToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(165, 6);
            // 
            // monitorPackToolStripMenuItem
            // 
            this.monitorPackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMonitorPackToolStripMenuItem1,
            this.openMonitorPackToolStripMenuItem,
            this.recentMonitorPacksToolStripMenuItem,
            this.saveMonitorPackToolStripMenuItem});
            this.monitorPackToolStripMenuItem.Name = "monitorPackToolStripMenuItem";
            this.monitorPackToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.monitorPackToolStripMenuItem.Text = "Monitor pack";
            // 
            // newMonitorPackToolStripMenuItem1
            // 
            this.newMonitorPackToolStripMenuItem1.Image = global::QuickMon.Properties.Resources.doc_new2;
            this.newMonitorPackToolStripMenuItem1.Name = "newMonitorPackToolStripMenuItem1";
            this.newMonitorPackToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.newMonitorPackToolStripMenuItem1.Text = "New";
            this.newMonitorPackToolStripMenuItem1.Click += new System.EventHandler(this.newMonitorPackToolStripMenuItem_Click);
            // 
            // openMonitorPackToolStripMenuItem
            // 
            this.openMonitorPackToolStripMenuItem.Image = global::QuickMon.Properties.Resources.folder;
            this.openMonitorPackToolStripMenuItem.Name = "openMonitorPackToolStripMenuItem";
            this.openMonitorPackToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.openMonitorPackToolStripMenuItem.Text = "Open";
            this.openMonitorPackToolStripMenuItem.Click += new System.EventHandler(this.openMonitorPackToolStripButton_ButtonClick);
            // 
            // recentMonitorPacksToolStripMenuItem
            // 
            this.recentMonitorPacksToolStripMenuItem.Image = global::QuickMon.Properties.Resources.folder_favor;
            this.recentMonitorPacksToolStripMenuItem.Name = "recentMonitorPacksToolStripMenuItem";
            this.recentMonitorPacksToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.recentMonitorPacksToolStripMenuItem.Text = "Recent";
            this.recentMonitorPacksToolStripMenuItem.Click += new System.EventHandler(this.recentMonitorPackToolStripMenuItem1_Click);
            // 
            // saveMonitorPackToolStripMenuItem
            // 
            this.saveMonitorPackToolStripMenuItem.Image = global::QuickMon.Properties.Resources.save;
            this.saveMonitorPackToolStripMenuItem.Name = "saveMonitorPackToolStripMenuItem";
            this.saveMonitorPackToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.saveMonitorPackToolStripMenuItem.Text = "Save";
            this.saveMonitorPackToolStripMenuItem.Click += new System.EventHandler(this.saveAsMonitorPackToolStripMenuItem_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalSettingsToolStripMenuItem,
            this.pollingFrequencyToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // generalSettingsToolStripMenuItem
            // 
            this.generalSettingsToolStripMenuItem.Name = "generalSettingsToolStripMenuItem";
            this.generalSettingsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.generalSettingsToolStripMenuItem.Text = "General Settings";
            this.generalSettingsToolStripMenuItem.Click += new System.EventHandler(this.generalSettingsToolStripSplitButton_ButtonClick);
            // 
            // pollingFrequencyToolStripMenuItem
            // 
            this.pollingFrequencyToolStripMenuItem.Name = "pollingFrequencyToolStripMenuItem";
            this.pollingFrequencyToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.pollingFrequencyToolStripMenuItem.Text = "Polling Frequency";
            this.pollingFrequencyToolStripMenuItem.Click += new System.EventHandler(this.customPollingFrequencyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(165, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::QuickMon.Properties.Resources.refresh;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // treeImageList
            // 
            this.treeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImageList.ImageStream")));
            this.treeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImageList.Images.SetKeyName(0, "Files.ico");
            this.treeImageList.Images.SetKeyName(1, "tangerine.ico");
            this.treeImageList.Images.SetKeyName(2, "bullet_ball_glass_blue.ico");
            this.treeImageList.Images.SetKeyName(3, "ok.png");
            this.treeImageList.Images.SetKeyName(4, "triang_yellow.png");
            this.treeImageList.Images.SetKeyName(5, "error.png");
            this.treeImageList.Images.SetKeyName(6, "23_6.ico");
            this.treeImageList.Images.SetKeyName(7, "Folder.ico");
            this.treeImageList.Images.SetKeyName(8, "Reaper2.png");
            this.treeImageList.Images.SetKeyName(9, "folder.png");
            this.treeImageList.Images.SetKeyName(10, "bullet_ball_glass_green.ico");
            this.treeImageList.Images.SetKeyName(11, "bullet_ball_glass_yellow.ico");
            this.treeImageList.Images.SetKeyName(12, "bullet_ball_glass_red.ico");
            // 
            // llblMonitorPack
            // 
            this.llblMonitorPack.Dock = System.Windows.Forms.DockStyle.Top;
            this.llblMonitorPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblMonitorPack.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblMonitorPack.Location = new System.Drawing.Point(0, 61);
            this.llblMonitorPack.Name = "llblMonitorPack";
            this.llblMonitorPack.Padding = new System.Windows.Forms.Padding(10, 3, 0, 0);
            this.llblMonitorPack.Size = new System.Drawing.Size(461, 23);
            this.llblMonitorPack.TabIndex = 32;
            this.llblMonitorPack.TabStop = true;
            this.llblMonitorPack.Text = "No name specified";
            this.llblMonitorPack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblMonitorPack_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tvwCollectors);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 5, 3, 3);
            this.panel3.Size = new System.Drawing.Size(461, 221);
            this.panel3.TabIndex = 33;
            // 
            // tvwCollectors
            // 
            this.tvwCollectors.AllowDrop = true;
            this.tvwCollectors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvwCollectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwCollectors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwCollectors.FullRowSelect = true;
            this.tvwCollectors.HideSelection = false;
            this.tvwCollectors.ImageIndex = 0;
            this.tvwCollectors.ImageList = this.treeImageList;
            this.tvwCollectors.ItemHeight = 22;
            this.tvwCollectors.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tvwCollectors.Location = new System.Drawing.Point(10, 5);
            this.tvwCollectors.Margin = new System.Windows.Forms.Padding(5);
            this.tvwCollectors.Name = "tvwCollectors";
            treeNode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            treeNode1.Name = "root";
            treeNode1.Text = "Collectors";
            this.tvwCollectors.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvwCollectors.SelectedImageIndex = 0;
            this.tvwCollectors.ShowRootLines = false;
            this.tvwCollectors.Size = new System.Drawing.Size(448, 213);
            this.tvwCollectors.TabIndex = 31;
            this.tvwCollectors.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwCollectors_BeforeCollapse);
            this.tvwCollectors.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvwCollectors_ItemDrag);
            this.tvwCollectors.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwCollectors_AfterSelect);
            this.tvwCollectors.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwCollectors_NodeMouseDoubleClick);
            this.tvwCollectors.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvwCollectors_DragDrop);
            this.tvwCollectors.DragOver += new System.Windows.Forms.DragEventHandler(this.tvwCollectors_DragOver);
            this.tvwCollectors.DragLeave += new System.EventHandler(this.tvwCollectors_DragLeave);
            this.tvwCollectors.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tvwCollectors_KeyUp);
            this.tvwCollectors.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwCollectors_MouseDown);
            this.tvwCollectors.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvwCollectors_MouseUp);
            // 
            // masterSplitContainer
            // 
            this.masterSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterSplitContainer.Location = new System.Drawing.Point(0, 94);
            this.masterSplitContainer.Name = "masterSplitContainer";
            this.masterSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // masterSplitContainer.Panel1
            // 
            this.masterSplitContainer.Panel1.Controls.Add(this.panel3);
            this.masterSplitContainer.Panel1.Controls.Add(this.agentSeparatorBox);
            this.masterSplitContainer.Panel1.Controls.Add(this.llblNotifierViewToggle);
            // 
            // masterSplitContainer.Panel2
            // 
            this.masterSplitContainer.Panel2.Controls.Add(this.lblNoNotifiersYet);
            this.masterSplitContainer.Panel2.Controls.Add(this.lvwNotifiers);
            this.masterSplitContainer.Size = new System.Drawing.Size(461, 369);
            this.masterSplitContainer.SplitterDistance = 251;
            this.masterSplitContainer.SplitterWidth = 6;
            this.masterSplitContainer.TabIndex = 36;
            // 
            // agentSeparatorBox
            // 
            this.agentSeparatorBox.BackColor = System.Drawing.Color.Transparent;
            this.agentSeparatorBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.agentSeparatorBox.Image = global::QuickMon.Properties.Resources.CometSeparator;
            this.agentSeparatorBox.Location = new System.Drawing.Point(0, 221);
            this.agentSeparatorBox.Name = "agentSeparatorBox";
            this.agentSeparatorBox.Size = new System.Drawing.Size(461, 10);
            this.agentSeparatorBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.agentSeparatorBox.TabIndex = 39;
            this.agentSeparatorBox.TabStop = false;
            // 
            // llblNotifierViewToggle
            // 
            this.llblNotifierViewToggle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llblNotifierViewToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblNotifierViewToggle.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.llblNotifierViewToggle.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblNotifierViewToggle.Location = new System.Drawing.Point(0, 231);
            this.llblNotifierViewToggle.Name = "llblNotifierViewToggle";
            this.llblNotifierViewToggle.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.llblNotifierViewToggle.Size = new System.Drawing.Size(461, 20);
            this.llblNotifierViewToggle.TabIndex = 38;
            this.llblNotifierViewToggle.TabStop = true;
            this.llblNotifierViewToggle.Text = "Show Notifiers";
            this.llblNotifierViewToggle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNotifierViewToggle_LinkClicked);
            // 
            // lblNoNotifiersYet
            // 
            this.lblNoNotifiersYet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoNotifiersYet.Location = new System.Drawing.Point(0, 0);
            this.lblNoNotifiersYet.Name = "lblNoNotifiersYet";
            this.lblNoNotifiersYet.Size = new System.Drawing.Size(461, 112);
            this.lblNoNotifiersYet.TabIndex = 1;
            this.lblNoNotifiersYet.Text = "No Notifiers added yet!\r\nDouble-Click here to add a new Notifier.";
            this.lblNoNotifiersYet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoNotifiersYet.DoubleClick += new System.EventHandler(this.addNotifierToolStripMenuItem_Click);
            this.lblNoNotifiersYet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwNotifiers_MouseUp);
            // 
            // lvwNotifiers
            // 
            this.lvwNotifiers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwNotifiers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwNotifiers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader});
            this.lvwNotifiers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwNotifiers.FullRowSelect = true;
            this.lvwNotifiers.HideSelection = false;
            this.lvwNotifiers.Location = new System.Drawing.Point(17, 3);
            this.lvwNotifiers.Margin = new System.Windows.Forms.Padding(8, 5, 5, 5);
            this.lvwNotifiers.Name = "lvwNotifiers";
            this.lvwNotifiers.Size = new System.Drawing.Size(444, 75);
            this.lvwNotifiers.SmallImageList = this.notifiersImageList;
            this.lvwNotifiers.TabIndex = 0;
            this.lvwNotifiers.UseCompatibleStateImageBehavior = false;
            this.lvwNotifiers.View = System.Windows.Forms.View.List;
            this.lvwNotifiers.SelectedIndexChanged += new System.EventHandler(this.lvwNotifiers_SelectedIndexChanged);
            this.lvwNotifiers.DoubleClick += new System.EventHandler(this.lvwNotifiers_DoubleClick);
            this.lvwNotifiers.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwNotifiers_MouseUp);
            this.lvwNotifiers.Resize += new System.EventHandler(this.lvwNotifiers_Resize);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 121;
            // 
            // notifiersImageList
            // 
            this.notifiersImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("notifiersImageList.ImageStream")));
            this.notifiersImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.notifiersImageList.Images.SetKeyName(0, "graybox.ico");
            this.notifiersImageList.Images.SetKeyName(1, "042.png");
            this.notifiersImageList.Images.SetKeyName(2, "filesearch.ico");
            // 
            // notifiersContextMenuStrip
            // 
            this.notifiersContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifierViewerToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addNotifierToolStripMenuItem,
            this.notifierConfigurationToolStripMenuItem,
            this.disableNotifierToolStripMenuItem,
            this.removeNotifierToolStripMenuItem});
            this.notifiersContextMenuStrip.Name = "notifiersContextMenuStrip";
            this.notifiersContextMenuStrip.Size = new System.Drawing.Size(162, 120);
            // 
            // notifierViewerToolStripMenuItem
            // 
            this.notifierViewerToolStripMenuItem.Enabled = false;
            this.notifierViewerToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifierViewerToolStripMenuItem.Image = global::QuickMon.Properties.Resources.comp_search;
            this.notifierViewerToolStripMenuItem.Name = "notifierViewerToolStripMenuItem";
            this.notifierViewerToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.notifierViewerToolStripMenuItem.Text = "Notifier Viewer";
            this.notifierViewerToolStripMenuItem.Click += new System.EventHandler(this.notifierViewerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // addNotifierToolStripMenuItem
            // 
            this.addNotifierToolStripMenuItem.Image = global::QuickMon.Properties.Resources.add;
            this.addNotifierToolStripMenuItem.Name = "addNotifierToolStripMenuItem";
            this.addNotifierToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addNotifierToolStripMenuItem.Text = "Add Notifier";
            this.addNotifierToolStripMenuItem.Click += new System.EventHandler(this.addNotifierToolStripMenuItem_Click);
            // 
            // notifierConfigurationToolStripMenuItem
            // 
            this.notifierConfigurationToolStripMenuItem.Enabled = false;
            this.notifierConfigurationToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_edit;
            this.notifierConfigurationToolStripMenuItem.Name = "notifierConfigurationToolStripMenuItem";
            this.notifierConfigurationToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.notifierConfigurationToolStripMenuItem.Text = "Edit Config";
            this.notifierConfigurationToolStripMenuItem.Click += new System.EventHandler(this.notifierConfigurationToolStripMenuItem_Click);
            // 
            // disableNotifierToolStripMenuItem
            // 
            this.disableNotifierToolStripMenuItem.Enabled = false;
            this.disableNotifierToolStripMenuItem.Name = "disableNotifierToolStripMenuItem";
            this.disableNotifierToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.disableNotifierToolStripMenuItem.Text = "Disable Notifier";
            this.disableNotifierToolStripMenuItem.Click += new System.EventHandler(this.disableNotifierToolStripMenuItem_Click);
            // 
            // removeNotifierToolStripMenuItem
            // 
            this.removeNotifierToolStripMenuItem.Enabled = false;
            this.removeNotifierToolStripMenuItem.Image = global::QuickMon.Properties.Resources.stop;
            this.removeNotifierToolStripMenuItem.Name = "removeNotifierToolStripMenuItem";
            this.removeNotifierToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.removeNotifierToolStripMenuItem.Text = "Remove Notifier";
            this.removeNotifierToolStripMenuItem.Click += new System.EventHandler(this.removeNotifierToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Image = global::QuickMon.Properties.Resources.CometSeparator;
            this.pictureBox1.Location = new System.Drawing.Point(0, 463);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(461, 10);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = global::QuickMon.Properties.Resources.CometSeparator;
            this.pictureBox2.Location = new System.Drawing.Point(0, 84);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(461, 10);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // showCollectorContextMenuTimer
            // 
            this.showCollectorContextMenuTimer.Tick += new System.EventHandler(this.showCollectorContextMenuTimer_Tick);
            // 
            // showNotifierContextMenuTimer
            // 
            this.showNotifierContextMenuTimer.Tick += new System.EventHandler(this.showNotifierContextMenuTimer_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.toolStrip1.Location = new System.Drawing.Point(265, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(57, 25);
            this.toolStrip1.TabIndex = 29;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutToolStripMenuItem.Image = global::QuickMon.Properties.Resources.info;
            this.aboutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(23, 22);
            this.aboutToolStripMenuItem.Text = "toolStripButton1";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(461, 495);
            this.Controls.Add(this.masterSplitContainer);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.llblMonitorPack);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "QuickMon 3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.collectorTreeContextMenuStrip.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.masterSplitContainer.Panel1.ResumeLayout(false);
            this.masterSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.masterSplitContainer)).EndInit();
            this.masterSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agentSeparatorBox)).EndInit();
            this.notifiersContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer mainRefreshTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripSplitButton openMonitorPackToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem newMonitorPackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentMonitorPackToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem editMonitorPackToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton generalSettingsToolStripSplitButton;
        private System.Windows.Forms.OpenFileDialog openFileDialogOpen;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ToolStripMenuItem pollingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollingSlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollingNormalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollingFastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customPollingFrequencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollingDisabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.ComponentModel.BackgroundWorker refreshBackgroundWorker;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSave;
        private TreeViewEx tvwCollectors;
        private System.Windows.Forms.ImageList treeImageList;
        private System.Windows.Forms.ContextMenuStrip collectorTreeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem collectorTreeViewDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collectorTreeEditConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableCollectorTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllChildWindowsToolStripMenuItem;
        private System.Windows.Forms.LinkLabel llblMonitorPack;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer masterSplitContainer;
        private System.Windows.Forms.LinkLabel llblNotifierViewToggle;
        private System.Windows.Forms.ListView lvwNotifiers;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ContextMenuStrip notifiersContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem notifierViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notifierConfigurationToolStripMenuItem;
        private System.Windows.Forms.ImageList notifiersImageList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNotifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeNotifierToolStripMenuItem;
        private System.Windows.Forms.PictureBox agentSeparatorBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton saveAsMonitorPackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCollectorFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton collectorToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem addCollectorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCollectorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addFolderCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCollectorDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton defaultNotifierViewerToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem showAllNotifiersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDefaultNotifierToolStripMenuItem;
        private System.Windows.Forms.Label lblNoNotifiersYet;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem addNotifierToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editNotifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeNotifierToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem disableNotifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem monitorPackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMonitorPackToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openMonitorPackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentMonitorPacksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMonitorPackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem generalSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollingFrequencyToolStripMenuItem;
        private System.Windows.Forms.Timer showCollectorContextMenuTimer;
        private System.Windows.Forms.Timer showNotifierContextMenuTimer;
        private System.Windows.Forms.ToolStripMenuItem knownRemoteAgentsToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton aboutToolStripMenuItem;
    }
}

