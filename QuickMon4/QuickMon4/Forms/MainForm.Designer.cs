﻿namespace QuickMon
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("COLLECTORS");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cmdTestRun1 = new System.Windows.Forms.Button();
            this.cmdTestRun2 = new System.Windows.Forms.Button();
            this.cmdTestEdit = new System.Windows.Forms.Button();
            this.llblMonitorPack = new System.Windows.Forms.LinkLabel();
            this.masterSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tvwCollectors = new QuickMon.Controls.TreeViewExBase();
            this.treeImageList = new System.Windows.Forms.ImageList(this.components);
            this.agentSeparatorBox = new System.Windows.Forms.PictureBox();
            this.llblNotifierViewToggle = new System.Windows.Forms.LinkLabel();
            this.lblNoNotifiersYet = new System.Windows.Forms.Label();
            this.lvwNotifiers = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.adminModeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTest = new System.Windows.Forms.Panel();
            this.recentMonitorPacksHideTimer = new System.Windows.Forms.Timer(this.components);
            this.recentMonitorPacksShowTimer = new System.Windows.Forms.Timer(this.components);
            this.mainToolbarShrinkTimer = new System.Windows.Forms.Timer(this.components);
            this.resizeRecentDropDownListWidthTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.recentMonitorPacksPanel = new System.Windows.Forms.Panel();
            this.cmdRecentMonitorPacks = new System.Windows.Forms.Button();
            this.cboRecentMonitorPacks = new System.Windows.Forms.ComboBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.mainToolStrip = new QuickMon.Controls.ToolStripEx();
            this.newMonitorPackToolStripMenuItem2 = new System.Windows.Forms.ToolStripButton();
            this.openMonitorPackToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveAsMonitorPackToolStripMenuItem = new System.Windows.Forms.ToolStripSplitButton();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.agentsToolStripButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.addCollectorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCollectorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCollectorDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.addNotifierToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNotifierToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showDefaultNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllNotifiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeAllChildWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalSettingsToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.pollingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pollingDisabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollingSlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollingNormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollingFastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customPollingFrequencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartInAdminModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripButton();
            this.openFileDialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSave = new System.Windows.Forms.SaveFileDialog();
            this.mainRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.notifiersImageList = new System.Windows.Forms.ImageList(this.components);
            this.showCollectorContextMenuTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.masterSplitContainer)).BeginInit();
            this.masterSplitContainer.Panel1.SuspendLayout();
            this.masterSplitContainer.Panel2.SuspendLayout();
            this.masterSplitContainer.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentSeparatorBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panelTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.recentMonitorPacksPanel.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdTestRun1
            // 
            this.cmdTestRun1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdTestRun1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTestRun1.Location = new System.Drawing.Point(3, 5);
            this.cmdTestRun1.Name = "cmdTestRun1";
            this.cmdTestRun1.Size = new System.Drawing.Size(75, 23);
            this.cmdTestRun1.TabIndex = 19;
            this.cmdTestRun1.Text = "Test run 1";
            this.cmdTestRun1.UseVisualStyleBackColor = true;
            this.cmdTestRun1.Click += new System.EventHandler(this.cmdTestRun1_Click);
            // 
            // cmdTestRun2
            // 
            this.cmdTestRun2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdTestRun2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTestRun2.Location = new System.Drawing.Point(84, 5);
            this.cmdTestRun2.Name = "cmdTestRun2";
            this.cmdTestRun2.Size = new System.Drawing.Size(75, 23);
            this.cmdTestRun2.TabIndex = 20;
            this.cmdTestRun2.Text = "Test run 2";
            this.cmdTestRun2.UseVisualStyleBackColor = true;
            this.cmdTestRun2.Click += new System.EventHandler(this.cmdTestRun2_Click);
            // 
            // cmdTestEdit
            // 
            this.cmdTestEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdTestEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTestEdit.Location = new System.Drawing.Point(165, 5);
            this.cmdTestEdit.Name = "cmdTestEdit";
            this.cmdTestEdit.Size = new System.Drawing.Size(75, 23);
            this.cmdTestEdit.TabIndex = 21;
            this.cmdTestEdit.Text = "Test edit";
            this.cmdTestEdit.UseVisualStyleBackColor = true;
            this.cmdTestEdit.Click += new System.EventHandler(this.cmdTestEdit_Click);
            // 
            // llblMonitorPack
            // 
            this.llblMonitorPack.BackColor = System.Drawing.Color.Transparent;
            this.llblMonitorPack.Dock = System.Windows.Forms.DockStyle.Top;
            this.llblMonitorPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblMonitorPack.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblMonitorPack.Location = new System.Drawing.Point(0, 72);
            this.llblMonitorPack.Name = "llblMonitorPack";
            this.llblMonitorPack.Padding = new System.Windows.Forms.Padding(10, 3, 0, 0);
            this.llblMonitorPack.Size = new System.Drawing.Size(502, 23);
            this.llblMonitorPack.TabIndex = 23;
            this.llblMonitorPack.TabStop = true;
            this.llblMonitorPack.Text = "Click here to set the monitor pack name.";
            this.llblMonitorPack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblMonitorPack_LinkClicked);
            this.llblMonitorPack.MouseEnter += new System.EventHandler(this.llblMonitorPack_MouseEnter);
            // 
            // masterSplitContainer
            // 
            this.masterSplitContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.masterSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterSplitContainer.Location = new System.Drawing.Point(0, 105);
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
            this.masterSplitContainer.Panel2.Controls.Add(this.panel2);
            this.masterSplitContainer.Size = new System.Drawing.Size(502, 371);
            this.masterSplitContainer.SplitterDistance = 251;
            this.masterSplitContainer.SplitterWidth = 6;
            this.masterSplitContainer.TabIndex = 44;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tvwCollectors);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 5, 3, 3);
            this.panel3.Size = new System.Drawing.Size(502, 221);
            this.panel3.TabIndex = 1;
            // 
            // tvwCollectors
            // 
            this.tvwCollectors.AllowDrop = true;
            this.tvwCollectors.AutoScrollToSelectedNodeWaitTimeMS = 500;
            this.tvwCollectors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvwCollectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwCollectors.DragColor = System.Drawing.Color.Aquamarine;
            this.tvwCollectors.EnableAutoScrollToSelectedNode = false;
            this.tvwCollectors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwCollectors.FullRowSelect = true;
            this.tvwCollectors.HideSelection = false;
            this.tvwCollectors.ImageIndex = 0;
            this.tvwCollectors.ImageList = this.treeImageList;
            this.tvwCollectors.Indent = 20;
            this.tvwCollectors.ItemHeight = 22;
            this.tvwCollectors.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tvwCollectors.Location = new System.Drawing.Point(10, 5);
            this.tvwCollectors.Margin = new System.Windows.Forms.Padding(5);
            this.tvwCollectors.Name = "tvwCollectors";
            treeNode1.BackColor = System.Drawing.Color.White;
            treeNode1.Name = "root";
            treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.Text = "COLLECTORS";
            this.tvwCollectors.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvwCollectors.RootAlwaysExpanded = false;
            this.tvwCollectors.SelectedImageIndex = 0;
            this.tvwCollectors.ShowRootLines = false;
            this.tvwCollectors.Size = new System.Drawing.Size(489, 213);
            this.tvwCollectors.TabIndex = 1;
            this.tvwCollectors.EnterKeyDown += new System.Windows.Forms.KeyEventHandler(this.tvwCollectors_EnterKeyDown);
            this.tvwCollectors.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwCollectors_AfterSelect);
            this.tvwCollectors.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tvwCollectors_MouseMove);
            this.tvwCollectors.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvwCollectors_MouseUp);
            // 
            // treeImageList
            // 
            this.treeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImageList.ImageStream")));
            this.treeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImageList.Images.SetKeyName(0, "open_folder_blue.ico");
            this.treeImageList.Images.SetKeyName(1, "my_documents2.ico");
            this.treeImageList.Images.SetKeyName(2, "helpbwy24x24.png");
            this.treeImageList.Images.SetKeyName(3, "ok.png");
            this.treeImageList.Images.SetKeyName(4, "triang_yellow.png");
            this.treeImageList.Images.SetKeyName(5, "Error24x24.png");
            this.treeImageList.Images.SetKeyName(6, "ok3.png");
            this.treeImageList.Images.SetKeyName(7, "triang_yellow2.png");
            this.treeImageList.Images.SetKeyName(8, "Error2_24x24.png");
            this.treeImageList.Images.SetKeyName(9, "ForbiddenNot16x16.png");
            this.treeImageList.Images.SetKeyName(10, "bullet_ball_glass_blue.ico");
            // 
            // agentSeparatorBox
            // 
            this.agentSeparatorBox.BackColor = System.Drawing.Color.Transparent;
            this.agentSeparatorBox.BackgroundImage = global::QuickMon.Properties.Resources.MenuBlueShade;
            this.agentSeparatorBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.agentSeparatorBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.agentSeparatorBox.Location = new System.Drawing.Point(0, 221);
            this.agentSeparatorBox.Name = "agentSeparatorBox";
            this.agentSeparatorBox.Size = new System.Drawing.Size(502, 10);
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
            this.llblNotifierViewToggle.Size = new System.Drawing.Size(502, 20);
            this.llblNotifierViewToggle.TabIndex = 38;
            this.llblNotifierViewToggle.TabStop = true;
            this.llblNotifierViewToggle.Text = "Show Notifiers";
            this.llblNotifierViewToggle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNotifierViewToggle_LinkClicked);
            // 
            // lblNoNotifiersYet
            // 
            this.lblNoNotifiersYet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNoNotifiersYet.Location = new System.Drawing.Point(91, 12);
            this.lblNoNotifiersYet.Name = "lblNoNotifiersYet";
            this.lblNoNotifiersYet.Size = new System.Drawing.Size(330, 90);
            this.lblNoNotifiersYet.TabIndex = 1;
            this.lblNoNotifiersYet.Text = "No Notifiers added yet!\r\nDouble-Click here to add a new Notifier.";
            this.lblNoNotifiersYet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvwNotifiers
            // 
            this.lvwNotifiers.AutoResizeColumnEnabled = false;
            this.lvwNotifiers.AutoResizeColumnIndex = 0;
            this.lvwNotifiers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwNotifiers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader});
            this.lvwNotifiers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwNotifiers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwNotifiers.FullRowSelect = true;
            this.lvwNotifiers.HideSelection = false;
            this.lvwNotifiers.Location = new System.Drawing.Point(5, 0);
            this.lvwNotifiers.Margin = new System.Windows.Forms.Padding(8, 5, 5, 5);
            this.lvwNotifiers.Name = "lvwNotifiers";
            this.lvwNotifiers.Size = new System.Drawing.Size(497, 114);
            this.lvwNotifiers.TabIndex = 0;
            this.lvwNotifiers.UseCompatibleStateImageBehavior = false;
            this.lvwNotifiers.View = System.Windows.Forms.View.List;
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 121;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 114);
            this.panel2.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminModeToolStripStatusLabel,
            this.toolStripStatusLabelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 517);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(502, 22);
            this.statusStrip1.TabIndex = 46;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // adminModeToolStripStatusLabel
            // 
            this.adminModeToolStripStatusLabel.Image = global::QuickMon.Properties.Resources.OUTLLIBR_9825;
            this.adminModeToolStripStatusLabel.Name = "adminModeToolStripStatusLabel";
            this.adminModeToolStripStatusLabel.Size = new System.Drawing.Size(16, 17);
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.AutoSize = false;
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(471, 17);
            this.toolStripStatusLabelStatus.Spring = true;
            this.toolStripStatusLabelStatus.Text = ".";
            this.toolStripStatusLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelTest
            // 
            this.panelTest.Controls.Add(this.cmdTestEdit);
            this.panelTest.Controls.Add(this.cmdTestRun1);
            this.panelTest.Controls.Add(this.cmdTestRun2);
            this.panelTest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTest.Location = new System.Drawing.Point(0, 476);
            this.panelTest.Name = "panelTest";
            this.panelTest.Size = new System.Drawing.Size(502, 31);
            this.panelTest.TabIndex = 47;
            // 
            // recentMonitorPacksHideTimer
            // 
            this.recentMonitorPacksHideTimer.Interval = 500;
            this.recentMonitorPacksHideTimer.Tick += new System.EventHandler(this.recentMonitorPacksVisibleTimer_Tick);
            // 
            // recentMonitorPacksShowTimer
            // 
            this.recentMonitorPacksShowTimer.Interval = 200;
            this.recentMonitorPacksShowTimer.Tick += new System.EventHandler(this.recentMonitorPacksShowTimer_Tick);
            // 
            // mainToolbarShrinkTimer
            // 
            this.mainToolbarShrinkTimer.Tick += new System.EventHandler(this.mainToolbarShrinkTimer_Tick);
            // 
            // resizeRecentDropDownListWidthTimer
            // 
            this.resizeRecentDropDownListWidthTimer.Interval = 300;
            this.resizeRecentDropDownListWidthTimer.Tick += new System.EventHandler(this.resizeRecentDropDownListWidthTimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::QuickMon.Properties.Resources.MenuBlueShade;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 507);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(502, 10);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::QuickMon.Properties.Resources.MenuBlueShade;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Location = new System.Drawing.Point(0, 95);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(502, 10);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 43;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::QuickMon.Properties.Resources.BlueHeader1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.recentMonitorPacksPanel);
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.mainToolStrip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 72);
            this.panel1.TabIndex = 22;
            this.panel1.MouseEnter += new System.EventHandler(this.HideRecentDropDownList);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe WP", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(278, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Alpha!!!";
            // 
            // recentMonitorPacksPanel
            // 
            this.recentMonitorPacksPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recentMonitorPacksPanel.BackColor = System.Drawing.Color.Transparent;
            this.recentMonitorPacksPanel.Controls.Add(this.cmdRecentMonitorPacks);
            this.recentMonitorPacksPanel.Controls.Add(this.cboRecentMonitorPacks);
            this.recentMonitorPacksPanel.Location = new System.Drawing.Point(3, 43);
            this.recentMonitorPacksPanel.Name = "recentMonitorPacksPanel";
            this.recentMonitorPacksPanel.Size = new System.Drawing.Size(487, 26);
            this.recentMonitorPacksPanel.TabIndex = 5;
            this.recentMonitorPacksPanel.MouseEnter += new System.EventHandler(this.recentMonitorPacksPanel_MouseEnter);
            // 
            // cmdRecentMonitorPacks
            // 
            this.cmdRecentMonitorPacks.BackgroundImage = global::QuickMon.Properties.Resources.folderWLightning;
            this.cmdRecentMonitorPacks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdRecentMonitorPacks.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdRecentMonitorPacks.FlatAppearance.BorderSize = 0;
            this.cmdRecentMonitorPacks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRecentMonitorPacks.Location = new System.Drawing.Point(0, 0);
            this.cmdRecentMonitorPacks.Name = "cmdRecentMonitorPacks";
            this.cmdRecentMonitorPacks.Size = new System.Drawing.Size(30, 26);
            this.cmdRecentMonitorPacks.TabIndex = 5;
            this.cmdRecentMonitorPacks.UseVisualStyleBackColor = true;
            this.cmdRecentMonitorPacks.Click += new System.EventHandler(this.recentMonitorPackToolStripMenuItem1_Click);
            this.cmdRecentMonitorPacks.MouseHover += new System.EventHandler(this.cboRecentMonitorPacks_MouseHover);
            // 
            // cboRecentMonitorPacks
            // 
            this.cboRecentMonitorPacks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRecentMonitorPacks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRecentMonitorPacks.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboRecentMonitorPacks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRecentMonitorPacks.FormattingEnabled = true;
            this.cboRecentMonitorPacks.Location = new System.Drawing.Point(30, 2);
            this.cboRecentMonitorPacks.Name = "cboRecentMonitorPacks";
            this.cboRecentMonitorPacks.Size = new System.Drawing.Size(454, 23);
            this.cboRecentMonitorPacks.TabIndex = 0;
            this.cboRecentMonitorPacks.SelectedIndexChanged += new System.EventHandler(this.cboRecentMonitorPacks_SelectedIndexChanged);
            this.cboRecentMonitorPacks.MouseLeave += new System.EventHandler(this.cboRecentMonitorPacks_MouseLeave);
            this.cboRecentMonitorPacks.MouseHover += new System.EventHandler(this.cboRecentMonitorPacks_MouseHover);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblVersion.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblVersion.Location = new System.Drawing.Point(448, 16);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(51, 23);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "vX.X";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblVersion.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            this.lblVersion.MouseEnter += new System.EventHandler(this.HideRecentDropDownList);
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMonitorPackToolStripMenuItem2,
            this.openMonitorPackToolStripButton,
            this.saveAsMonitorPackToolStripMenuItem,
            this.refreshToolStripButton1,
            this.agentsToolStripButton,
            this.generalSettingsToolStripSplitButton,
            this.aboutToolStripMenuItem1});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(260, 35);
            this.mainToolStrip.TabIndex = 1;
            this.mainToolStrip.TabStop = true;
            this.mainToolStrip.MouseEnter += new System.EventHandler(this.mainToolStrip_MouseEnter);
            this.mainToolStrip.MouseLeave += new System.EventHandler(this.mainToolStrip_MouseLeave);
            // 
            // newMonitorPackToolStripMenuItem2
            // 
            this.newMonitorPackToolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newMonitorPackToolStripMenuItem2.Image = global::QuickMon.Properties.Resources.doc_new;
            this.newMonitorPackToolStripMenuItem2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newMonitorPackToolStripMenuItem2.Name = "newMonitorPackToolStripMenuItem2";
            this.newMonitorPackToolStripMenuItem2.Size = new System.Drawing.Size(32, 32);
            this.newMonitorPackToolStripMenuItem2.Text = "New";
            this.newMonitorPackToolStripMenuItem2.ToolTipText = "Create new monitor pack (Ctrl + N)";
            this.newMonitorPackToolStripMenuItem2.Click += new System.EventHandler(this.newMonitorPackToolStripMenuItem2_Click);
            // 
            // openMonitorPackToolStripButton
            // 
            this.openMonitorPackToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openMonitorPackToolStripButton.Image = global::QuickMon.Properties.Resources.folderOpen;
            this.openMonitorPackToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openMonitorPackToolStripButton.Name = "openMonitorPackToolStripButton";
            this.openMonitorPackToolStripButton.Size = new System.Drawing.Size(32, 32);
            this.openMonitorPackToolStripButton.Text = "Monitor Pack Actions";
            this.openMonitorPackToolStripButton.ToolTipText = "Open monitor pack file (Ctrl + O)";
            this.openMonitorPackToolStripButton.Click += new System.EventHandler(this.openMonitorPackToolStripButton_Click);
            // 
            // saveAsMonitorPackToolStripMenuItem
            // 
            this.saveAsMonitorPackToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveAsMonitorPackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem});
            this.saveAsMonitorPackToolStripMenuItem.Image = global::QuickMon.Properties.Resources.save;
            this.saveAsMonitorPackToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsMonitorPackToolStripMenuItem.Name = "saveAsMonitorPackToolStripMenuItem";
            this.saveAsMonitorPackToolStripMenuItem.Size = new System.Drawing.Size(44, 32);
            this.saveAsMonitorPackToolStripMenuItem.Text = "Save Monitor Pack";
            this.saveAsMonitorPackToolStripMenuItem.ToolTipText = "Save monitor pack";
            this.saveAsMonitorPackToolStripMenuItem.ButtonClick += new System.EventHandler(this.saveAsMonitorPackToolStripMenuItem_ButtonClick);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.save;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // refreshToolStripButton1
            // 
            this.refreshToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton1.Image = global::QuickMon.Properties.Resources.refresh;
            this.refreshToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton1.Name = "refreshToolStripButton1";
            this.refreshToolStripButton1.Size = new System.Drawing.Size(32, 32);
            this.refreshToolStripButton1.Text = "Refresh";
            this.refreshToolStripButton1.ToolTipText = "Refresh (F5)";
            this.refreshToolStripButton1.Click += new System.EventHandler(this.refreshToolStripButton1_Click);
            // 
            // agentsToolStripButton
            // 
            this.agentsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.agentsToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCollectorToolStripMenuItem1,
            this.editCollectorToolStripMenuItem,
            this.removeCollectorToolStripMenuItem1,
            this.viewCollectorDetailsToolStripMenuItem,
            this.toolStripMenuItem5,
            this.addNotifierToolStripMenuItem1,
            this.editNotifierToolStripMenuItem,
            this.removeNotifierToolStripMenuItem1,
            this.showDefaultNotifierToolStripMenuItem,
            this.showAllNotifiersToolStripMenuItem,
            this.toolStripMenuItem2,
            this.closeAllChildWindowsToolStripMenuItem});
            this.agentsToolStripButton.Image = global::QuickMon.Properties.Resources.cubes3;
            this.agentsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.agentsToolStripButton.Name = "agentsToolStripButton";
            this.agentsToolStripButton.Size = new System.Drawing.Size(41, 32);
            this.agentsToolStripButton.Text = "Agents";
            // 
            // addCollectorToolStripMenuItem1
            // 
            this.addCollectorToolStripMenuItem1.Image = global::QuickMon.Properties.Resources.add;
            this.addCollectorToolStripMenuItem1.Name = "addCollectorToolStripMenuItem1";
            this.addCollectorToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            this.addCollectorToolStripMenuItem1.Text = "Add Collector";
            this.addCollectorToolStripMenuItem1.Click += new System.EventHandler(this.addCollectorToolStripMenuItem1_Click);
            // 
            // editCollectorToolStripMenuItem
            // 
            this.editCollectorToolStripMenuItem.Enabled = false;
            this.editCollectorToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_edit;
            this.editCollectorToolStripMenuItem.Name = "editCollectorToolStripMenuItem";
            this.editCollectorToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.editCollectorToolStripMenuItem.Text = "Edit Collector";
            this.editCollectorToolStripMenuItem.Click += new System.EventHandler(this.editCollectorToolStripMenuItem_Click);
            // 
            // removeCollectorToolStripMenuItem1
            // 
            this.removeCollectorToolStripMenuItem1.Enabled = false;
            this.removeCollectorToolStripMenuItem1.Image = global::QuickMon.Properties.Resources.stop;
            this.removeCollectorToolStripMenuItem1.Name = "removeCollectorToolStripMenuItem1";
            this.removeCollectorToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            this.removeCollectorToolStripMenuItem1.Text = "Remove Collector";
            this.removeCollectorToolStripMenuItem1.Click += new System.EventHandler(this.removeCollectorToolStripMenuItem1_Click);
            // 
            // viewCollectorDetailsToolStripMenuItem
            // 
            this.viewCollectorDetailsToolStripMenuItem.Enabled = false;
            this.viewCollectorDetailsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.comp_search;
            this.viewCollectorDetailsToolStripMenuItem.Name = "viewCollectorDetailsToolStripMenuItem";
            this.viewCollectorDetailsToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.viewCollectorDetailsToolStripMenuItem.Text = "View Collector Details";
            this.viewCollectorDetailsToolStripMenuItem.Click += new System.EventHandler(this.viewCollectorDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(226, 6);
            // 
            // addNotifierToolStripMenuItem1
            // 
            this.addNotifierToolStripMenuItem1.Image = global::QuickMon.Properties.Resources.add;
            this.addNotifierToolStripMenuItem1.Name = "addNotifierToolStripMenuItem1";
            this.addNotifierToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            this.addNotifierToolStripMenuItem1.Text = "Add Notifier";
            this.addNotifierToolStripMenuItem1.Click += new System.EventHandler(this.addNotifierToolStripMenuItem1_Click);
            // 
            // editNotifierToolStripMenuItem
            // 
            this.editNotifierToolStripMenuItem.Enabled = false;
            this.editNotifierToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_edit;
            this.editNotifierToolStripMenuItem.Name = "editNotifierToolStripMenuItem";
            this.editNotifierToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.editNotifierToolStripMenuItem.Text = "Edit Notifier Config";
            this.editNotifierToolStripMenuItem.Click += new System.EventHandler(this.editNotifierToolStripMenuItem_Click);
            // 
            // removeNotifierToolStripMenuItem1
            // 
            this.removeNotifierToolStripMenuItem1.Enabled = false;
            this.removeNotifierToolStripMenuItem1.Image = global::QuickMon.Properties.Resources.stop;
            this.removeNotifierToolStripMenuItem1.Name = "removeNotifierToolStripMenuItem1";
            this.removeNotifierToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            this.removeNotifierToolStripMenuItem1.Text = "Remove Notifier";
            this.removeNotifierToolStripMenuItem1.Click += new System.EventHandler(this.removeNotifierToolStripMenuItem1_Click);
            // 
            // showDefaultNotifierToolStripMenuItem
            // 
            this.showDefaultNotifierToolStripMenuItem.Image = global::QuickMon.Properties.Resources.comp_search;
            this.showDefaultNotifierToolStripMenuItem.Name = "showDefaultNotifierToolStripMenuItem";
            this.showDefaultNotifierToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.showDefaultNotifierToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.showDefaultNotifierToolStripMenuItem.Text = "Show Default Notifier";
            this.showDefaultNotifierToolStripMenuItem.Click += new System.EventHandler(this.showDefaultNotifierToolStripMenuItem_Click);
            // 
            // showAllNotifiersToolStripMenuItem
            // 
            this.showAllNotifiersToolStripMenuItem.Image = global::QuickMon.Properties.Resources.thunderbolt;
            this.showAllNotifiersToolStripMenuItem.Name = "showAllNotifiersToolStripMenuItem";
            this.showAllNotifiersToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.showAllNotifiersToolStripMenuItem.Text = "Show All Notifiers";
            this.showAllNotifiersToolStripMenuItem.Click += new System.EventHandler(this.showAllNotifiersToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(226, 6);
            // 
            // closeAllChildWindowsToolStripMenuItem
            // 
            this.closeAllChildWindowsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.tables;
            this.closeAllChildWindowsToolStripMenuItem.Name = "closeAllChildWindowsToolStripMenuItem";
            this.closeAllChildWindowsToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.closeAllChildWindowsToolStripMenuItem.Text = "Close All Child Windows";
            this.closeAllChildWindowsToolStripMenuItem.Click += new System.EventHandler(this.closeAllChildWindowsToolStripMenuItem_Click);
            // 
            // generalSettingsToolStripSplitButton
            // 
            this.generalSettingsToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.generalSettingsToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pollingToolStripMenuItem1,
            this.manageTemplatesToolStripMenuItem,
            this.restartInAdminModeToolStripMenuItem});
            this.generalSettingsToolStripSplitButton.Image = global::QuickMon.Properties.Resources.tools;
            this.generalSettingsToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.generalSettingsToolStripSplitButton.Name = "generalSettingsToolStripSplitButton";
            this.generalSettingsToolStripSplitButton.Size = new System.Drawing.Size(44, 32);
            this.generalSettingsToolStripSplitButton.Text = "Settings";
            this.generalSettingsToolStripSplitButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.generalSettingsToolStripSplitButton.ToolTipText = "Settings (Ctrl + E)";
            this.generalSettingsToolStripSplitButton.ButtonClick += new System.EventHandler(this.generalSettingsToolStripSplitButton_ButtonClick);
            // 
            // pollingToolStripMenuItem1
            // 
            this.pollingToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pollingDisabledToolStripMenuItem,
            this.pollingSlowToolStripMenuItem,
            this.pollingNormalToolStripMenuItem,
            this.pollingFastToolStripMenuItem,
            this.customPollingFrequencyToolStripMenuItem});
            this.pollingToolStripMenuItem1.Image = global::QuickMon.Properties.Resources.clock;
            this.pollingToolStripMenuItem1.Name = "pollingToolStripMenuItem1";
            this.pollingToolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.pollingToolStripMenuItem1.Text = "Polling";
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
            this.pollingSlowToolStripMenuItem.Text = "Slow (60 Sec)";
            this.pollingSlowToolStripMenuItem.Click += new System.EventHandler(this.pollingSlowToolStripMenuItem_Click);
            // 
            // pollingNormalToolStripMenuItem
            // 
            this.pollingNormalToolStripMenuItem.Name = "pollingNormalToolStripMenuItem";
            this.pollingNormalToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pollingNormalToolStripMenuItem.Text = "Normal (30 Sec)";
            this.pollingNormalToolStripMenuItem.Click += new System.EventHandler(this.pollingNormalToolStripMenuItem_Click);
            // 
            // pollingFastToolStripMenuItem
            // 
            this.pollingFastToolStripMenuItem.Name = "pollingFastToolStripMenuItem";
            this.pollingFastToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pollingFastToolStripMenuItem.Text = "Fast (5 Sec)";
            this.pollingFastToolStripMenuItem.Click += new System.EventHandler(this.pollingFastToolStripMenuItem_Click);
            // 
            // customPollingFrequencyToolStripMenuItem
            // 
            this.customPollingFrequencyToolStripMenuItem.Name = "customPollingFrequencyToolStripMenuItem";
            this.customPollingFrequencyToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.customPollingFrequencyToolStripMenuItem.Text = "Custom Frequency";
            this.customPollingFrequencyToolStripMenuItem.Click += new System.EventHandler(this.customPollingFrequencyToolStripMenuItem_Click);
            // 
            // manageTemplatesToolStripMenuItem
            // 
            this.manageTemplatesToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_new;
            this.manageTemplatesToolStripMenuItem.Name = "manageTemplatesToolStripMenuItem";
            this.manageTemplatesToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.manageTemplatesToolStripMenuItem.Text = "Manage Templates";
            this.manageTemplatesToolStripMenuItem.Click += new System.EventHandler(this.manageTemplatesToolStripMenuItem_Click);
            // 
            // restartInAdminModeToolStripMenuItem
            // 
            this.restartInAdminModeToolStripMenuItem.Image = global::QuickMon.Properties.Resources.OUTLLIBR_9825;
            this.restartInAdminModeToolStripMenuItem.Name = "restartInAdminModeToolStripMenuItem";
            this.restartInAdminModeToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.restartInAdminModeToolStripMenuItem.Text = "Restart in \'Admin\' mode";
            this.restartInAdminModeToolStripMenuItem.Click += new System.EventHandler(this.restartInAdminModeToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutToolStripMenuItem1.Image = global::QuickMon.Properties.Resources.info;
            this.aboutToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(32, 32);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // openFileDialogOpen
            // 
            this.openFileDialogOpen.DefaultExt = "qmp";
            this.openFileDialogOpen.Filter = "QuickMon config files|*.qmp|Old QuickMon config files|*.qmconfig";
            // 
            // saveFileDialogSave
            // 
            this.saveFileDialogSave.DefaultExt = "qmp";
            this.saveFileDialogSave.Filter = "QuickMon config files|*.qmp|Old QuickMon config files|*.qmconfig";
            // 
            // mainRefreshTimer
            // 
            this.mainRefreshTimer.Interval = 10000;
            // 
            // notifiersImageList
            // 
            this.notifiersImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("notifiersImageList.ImageStream")));
            this.notifiersImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.notifiersImageList.Images.SetKeyName(0, "graybox.ico");
            this.notifiersImageList.Images.SetKeyName(1, "042.png");
            this.notifiersImageList.Images.SetKeyName(2, "filesearch.ico");
            // 
            // showCollectorContextMenuTimer
            // 
            this.showCollectorContextMenuTimer.Tick += new System.EventHandler(this.showCollectorContextMenuTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(502, 539);
            this.Controls.Add(this.masterSplitContainer);
            this.Controls.Add(this.panelTest);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.llblMonitorPack);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuickMon 4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.masterSplitContainer.Panel1.ResumeLayout(false);
            this.masterSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.masterSplitContainer)).EndInit();
            this.masterSplitContainer.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agentSeparatorBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.recentMonitorPacksPanel.ResumeLayout(false);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdTestRun1;
        private System.Windows.Forms.Button cmdTestRun2;
        private System.Windows.Forms.Button cmdTestEdit;
        private System.Windows.Forms.Panel panel1;
        private Controls.ToolStripEx mainToolStrip;
        private System.Windows.Forms.ToolStripButton newMonitorPackToolStripMenuItem2;
        private System.Windows.Forms.ToolStripButton openMonitorPackToolStripButton;
        private System.Windows.Forms.ToolStripSplitButton saveAsMonitorPackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton1;
        private System.Windows.Forms.ToolStripDropDownButton agentsToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem addCollectorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCollectorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewCollectorDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem addNotifierToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editNotifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeNotifierToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showDefaultNotifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllNotifiersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem closeAllChildWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton generalSettingsToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem pollingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pollingDisabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollingSlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollingNormalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollingFastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customPollingFrequencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTemplatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartInAdminModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton aboutToolStripMenuItem1;
        private System.Windows.Forms.Panel recentMonitorPacksPanel;
        private System.Windows.Forms.Button cmdRecentMonitorPacks;
        private System.Windows.Forms.ComboBox cboRecentMonitorPacks;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.LinkLabel llblMonitorPack;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.SplitContainer masterSplitContainer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox agentSeparatorBox;
        private System.Windows.Forms.LinkLabel llblNotifierViewToggle;
        private System.Windows.Forms.Label lblNoNotifiersYet;
        private ListViewEx lvwNotifiers;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel adminModeToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.Panel panelTest;
        private Controls.TreeViewExBase tvwCollectors;
        private System.Windows.Forms.Timer recentMonitorPacksHideTimer;
        private System.Windows.Forms.Timer recentMonitorPacksShowTimer;
        private System.Windows.Forms.Timer mainToolbarShrinkTimer;
        private System.Windows.Forms.Timer resizeRecentDropDownListWidthTimer;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList treeImageList;
        private System.Windows.Forms.OpenFileDialog openFileDialogOpen;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSave;
        private System.Windows.Forms.Timer mainRefreshTimer;
        private System.Windows.Forms.ImageList notifiersImageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer showCollectorContextMenuTimer;
    }
}

