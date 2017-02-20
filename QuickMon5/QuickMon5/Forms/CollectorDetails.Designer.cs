namespace QuickMon
{
    partial class CollectorDetails
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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Parameter 1");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Script 1", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Parameter 1");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Parameter 2");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Script 2", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Agent 1", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectorDetails));
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.statusStripCollector = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.enabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabelEnabled = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelAutoRefresh = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.panelCollectorDetails = new System.Windows.Forms.Panel();
            this.panelEditing = new System.Windows.Forms.Panel();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.panelHistory = new System.Windows.Forms.Panel();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelMetrics = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelAgentStates = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCollectorEdit = new System.Windows.Forms.Button();
            this.cmdActionScriptsVisible = new System.Windows.Forms.Button();
            this.optHistory = new System.Windows.Forms.RadioButton();
            this.optMetrics = new System.Windows.Forms.RadioButton();
            this.optAgentStates = new System.Windows.Forms.RadioButton();
            this.lblCollectorState = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.tvwAgentStates = new QuickMon.Controls.TreeViewExBase();
            this.statusStripCollector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.panelCollectorDetails.SuspendLayout();
            this.panelEditing.SuspendLayout();
            this.panelHistory.SuspendLayout();
            this.panelMetrics.SuspendLayout();
            this.panelAgentStates.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(89, 11);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(651, 15);
            this.txtName.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(8, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 18);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "&Name:";
            // 
            // statusStripCollector
            // 
            this.statusStripCollector.BackColor = System.Drawing.Color.Transparent;
            this.statusStripCollector.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripStatusLabelEnabled,
            this.toolStripStatusLabelAutoRefresh,
            this.toolStripStatusLabel3});
            this.statusStripCollector.Location = new System.Drawing.Point(0, 539);
            this.statusStripCollector.Name = "statusStripCollector";
            this.statusStripCollector.Size = new System.Drawing.Size(784, 22);
            this.statusStripCollector.TabIndex = 7;
            this.statusStripCollector.Text = "statusStrip1";
            this.statusStripCollector.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStripCollector_ItemClicked);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enabledToolStripMenuItem,
            this.autoRefreshToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::QuickMon.Properties.Resources.menu_alt_16b;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // enabledToolStripMenuItem
            // 
            this.enabledToolStripMenuItem.Checked = true;
            this.enabledToolStripMenuItem.CheckOnClick = true;
            this.enabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enabledToolStripMenuItem.Name = "enabledToolStripMenuItem";
            this.enabledToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.enabledToolStripMenuItem.Text = "Enabled";
            // 
            // autoRefreshToolStripMenuItem
            // 
            this.autoRefreshToolStripMenuItem.Checked = true;
            this.autoRefreshToolStripMenuItem.CheckOnClick = true;
            this.autoRefreshToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoRefreshToolStripMenuItem.Name = "autoRefreshToolStripMenuItem";
            this.autoRefreshToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.autoRefreshToolStripMenuItem.Text = "Auto refresh";
            // 
            // toolStripStatusLabelEnabled
            // 
            this.toolStripStatusLabelEnabled.AutoToolTip = true;
            this.toolStripStatusLabelEnabled.DoubleClickEnabled = true;
            this.toolStripStatusLabelEnabled.Image = global::QuickMon.Properties.Resources._131;
            this.toolStripStatusLabelEnabled.Name = "toolStripStatusLabelEnabled";
            this.toolStripStatusLabelEnabled.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabelEnabled.Text = "Enabled";
            this.toolStripStatusLabelEnabled.ToolTipText = "Enabled";
            // 
            // toolStripStatusLabelAutoRefresh
            // 
            this.toolStripStatusLabelAutoRefresh.AutoToolTip = true;
            this.toolStripStatusLabelAutoRefresh.DoubleClickEnabled = true;
            this.toolStripStatusLabelAutoRefresh.Image = global::QuickMon.Properties.Resources._102;
            this.toolStripStatusLabelAutoRefresh.Name = "toolStripStatusLabelAutoRefresh";
            this.toolStripStatusLabelAutoRefresh.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabelAutoRefresh.Text = "Auto Refresh ON";
            this.toolStripStatusLabelAutoRefresh.ToolTipText = "Auto refresh";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.IsLink = true;
            this.toolStripStatusLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusLabel3.Text = "Edit Raw Config";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMain.Location = new System.Drawing.Point(6, 36);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.panelCollectorDetails);
            this.splitContainerMain.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.treeView1);
            this.splitContainerMain.Panel2.Controls.Add(this.panel2);
            this.splitContainerMain.Panel2.Controls.Add(this.label1);
            this.splitContainerMain.Panel2MinSize = 200;
            this.splitContainerMain.Size = new System.Drawing.Size(766, 500);
            this.splitContainerMain.SplitterDistance = 562;
            this.splitContainerMain.TabIndex = 8;
            // 
            // panelCollectorDetails
            // 
            this.panelCollectorDetails.AutoScroll = true;
            this.panelCollectorDetails.Controls.Add(this.panelEditing);
            this.panelCollectorDetails.Controls.Add(this.panelHistory);
            this.panelCollectorDetails.Controls.Add(this.panelMetrics);
            this.panelCollectorDetails.Controls.Add(this.panelAgentStates);
            this.panelCollectorDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCollectorDetails.Location = new System.Drawing.Point(0, 25);
            this.panelCollectorDetails.Name = "panelCollectorDetails";
            this.panelCollectorDetails.Size = new System.Drawing.Size(562, 475);
            this.panelCollectorDetails.TabIndex = 3;
            // 
            // panelEditing
            // 
            this.panelEditing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEditing.Controls.Add(this.cmdOK);
            this.panelEditing.Controls.Add(this.cmdCancel);
            this.panelEditing.Location = new System.Drawing.Point(13, 812);
            this.panelEditing.Name = "panelEditing";
            this.panelEditing.Size = new System.Drawing.Size(500, 191);
            this.panelEditing.TabIndex = 4;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(339, 163);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "Save";
            this.cmdOK.UseVisualStyleBackColor = false;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(420, 163);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // panelHistory
            // 
            this.panelHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHistory.Controls.Add(this.listView2);
            this.panelHistory.Location = new System.Drawing.Point(13, 375);
            this.panelHistory.Name = "panelHistory";
            this.panelHistory.Size = new System.Drawing.Size(500, 191);
            this.panelHistory.TabIndex = 3;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(492, 183);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Time";
            this.columnHeader3.Width = 206;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "State";
            this.columnHeader4.Width = 114;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Duration";
            // 
            // panelMetrics
            // 
            this.panelMetrics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMetrics.Controls.Add(this.listView1);
            this.panelMetrics.Location = new System.Drawing.Point(9, 224);
            this.panelMetrics.Name = "panelMetrics";
            this.panelMetrics.Size = new System.Drawing.Size(500, 125);
            this.panelMetrics.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(492, 183);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Property";
            this.columnHeader1.Width = 206;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 114;
            // 
            // panelAgentStates
            // 
            this.panelAgentStates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAgentStates.Controls.Add(this.tvwAgentStates);
            this.panelAgentStates.Location = new System.Drawing.Point(5, 20);
            this.panelAgentStates.Name = "panelAgentStates";
            this.panelAgentStates.Size = new System.Drawing.Size(520, 198);
            this.panelAgentStates.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdCollectorEdit);
            this.panel1.Controls.Add(this.cmdActionScriptsVisible);
            this.panel1.Controls.Add(this.optHistory);
            this.panel1.Controls.Add(this.optMetrics);
            this.panel1.Controls.Add(this.optAgentStates);
            this.panel1.Controls.Add(this.lblCollectorState);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 25);
            this.panel1.TabIndex = 1;
            // 
            // cmdCollectorEdit
            // 
            this.cmdCollectorEdit.BackColor = System.Drawing.Color.Transparent;
            this.cmdCollectorEdit.BackgroundImage = global::QuickMon.Properties.Resources.doc_edit24x24;
            this.cmdCollectorEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdCollectorEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdCollectorEdit.FlatAppearance.BorderSize = 0;
            this.cmdCollectorEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCollectorEdit.Location = new System.Drawing.Point(508, 0);
            this.cmdCollectorEdit.Name = "cmdCollectorEdit";
            this.cmdCollectorEdit.Size = new System.Drawing.Size(27, 25);
            this.cmdCollectorEdit.TabIndex = 5;
            this.cmdCollectorEdit.UseVisualStyleBackColor = false;
            this.cmdCollectorEdit.Click += new System.EventHandler(this.cmdCollectorEdit_Click);
            // 
            // cmdActionScriptsVisible
            // 
            this.cmdActionScriptsVisible.BackColor = System.Drawing.Color.Transparent;
            this.cmdActionScriptsVisible.BackgroundImage = global::QuickMon.Properties.Resources.scroll24x24;
            this.cmdActionScriptsVisible.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdActionScriptsVisible.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdActionScriptsVisible.FlatAppearance.BorderSize = 0;
            this.cmdActionScriptsVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdActionScriptsVisible.Location = new System.Drawing.Point(535, 0);
            this.cmdActionScriptsVisible.Name = "cmdActionScriptsVisible";
            this.cmdActionScriptsVisible.Size = new System.Drawing.Size(27, 25);
            this.cmdActionScriptsVisible.TabIndex = 4;
            this.cmdActionScriptsVisible.UseVisualStyleBackColor = false;
            this.cmdActionScriptsVisible.Click += new System.EventHandler(this.cmdActionScriptsVisible_Click);
            // 
            // optHistory
            // 
            this.optHistory.AutoSize = true;
            this.optHistory.Dock = System.Windows.Forms.DockStyle.Left;
            this.optHistory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optHistory.Location = new System.Drawing.Point(239, 0);
            this.optHistory.Name = "optHistory";
            this.optHistory.Size = new System.Drawing.Size(98, 25);
            this.optHistory.TabIndex = 2;
            this.optHistory.Text = "Collector history";
            this.optHistory.UseVisualStyleBackColor = true;
            this.optHistory.CheckedChanged += new System.EventHandler(this.optHistory_CheckedChanged);
            // 
            // optMetrics
            // 
            this.optMetrics.AutoSize = true;
            this.optMetrics.Dock = System.Windows.Forms.DockStyle.Left;
            this.optMetrics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optMetrics.Location = new System.Drawing.Point(138, 0);
            this.optMetrics.Name = "optMetrics";
            this.optMetrics.Size = new System.Drawing.Size(101, 25);
            this.optMetrics.TabIndex = 1;
            this.optMetrics.Text = "Collector metrics";
            this.optMetrics.UseVisualStyleBackColor = true;
            this.optMetrics.CheckedChanged += new System.EventHandler(this.optMetrics_CheckedChanged);
            // 
            // optAgentStates
            // 
            this.optAgentStates.AutoSize = true;
            this.optAgentStates.Checked = true;
            this.optAgentStates.Dock = System.Windows.Forms.DockStyle.Left;
            this.optAgentStates.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optAgentStates.Location = new System.Drawing.Point(55, 0);
            this.optAgentStates.Name = "optAgentStates";
            this.optAgentStates.Size = new System.Drawing.Size(83, 25);
            this.optAgentStates.TabIndex = 0;
            this.optAgentStates.TabStop = true;
            this.optAgentStates.Text = "Agent states";
            this.optAgentStates.UseVisualStyleBackColor = true;
            this.optAgentStates.CheckedChanged += new System.EventHandler(this.optAgentStates_CheckedChanged);
            // 
            // lblCollectorState
            // 
            this.lblCollectorState.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCollectorState.Image = global::QuickMon.Properties.Resources.helpbwy16x16;
            this.lblCollectorState.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCollectorState.Location = new System.Drawing.Point(0, 0);
            this.lblCollectorState.Name = "lblCollectorState";
            this.lblCollectorState.Size = new System.Drawing.Size(55, 25);
            this.lblCollectorState.TabIndex = 6;
            this.lblCollectorState.Text = "State";
            this.lblCollectorState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(2, 25);
            this.treeView1.Name = "treeView1";
            treeNode3.Name = "Node1";
            treeNode3.Text = "Parameter 1";
            treeNode4.Name = "Node0";
            treeNode4.Text = "Script 1";
            treeNode5.Name = "Node3";
            treeNode5.Text = "Parameter 1";
            treeNode6.Name = "Node4";
            treeNode6.Text = "Parameter 2";
            treeNode7.Name = "Node2";
            treeNode7.Text = "Script 2";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode7});
            this.treeView1.Size = new System.Drawing.Size(198, 475);
            this.treeView1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 25);
            this.panel2.TabIndex = 3;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = global::QuickMon.Properties.Resources.rungreen24x24;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.Dock = System.Windows.Forms.DockStyle.Right;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(90, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(27, 25);
            this.button5.TabIndex = 8;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = global::QuickMon.Properties.Resources.add;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button4.Dock = System.Windows.Forms.DockStyle.Right;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(117, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(27, 25);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::QuickMon.Properties.Resources.doc_edit24x24;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(144, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 25);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::QuickMon.Properties.Resources.stop24x24;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(171, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 25);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Action scripts";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 500);
            this.label1.TabIndex = 4;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRefresh.BackColor = System.Drawing.Color.Transparent;
            this.cmdRefresh.BackgroundImage = global::QuickMon.Properties.Resources.refresh24x24;
            this.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRefresh.Location = new System.Drawing.Point(746, 5);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(26, 26);
            this.cmdRefresh.TabIndex = 9;
            this.cmdRefresh.UseVisualStyleBackColor = false;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // tvwAgentStates
            // 
            this.tvwAgentStates.AllowKeyBoardNodeReorder = false;
            this.tvwAgentStates.AutoScrollToSelectedNodeWaitTimeMS = 500;
            this.tvwAgentStates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvwAgentStates.CheckBoxEnhancements = false;
            this.tvwAgentStates.DisableCollapseOnDoubleClick = false;
            this.tvwAgentStates.DisableExpandOnDoubleClick = false;
            this.tvwAgentStates.DisableNode0Collapse = false;
            this.tvwAgentStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwAgentStates.DragColor = System.Drawing.Color.Aquamarine;
            this.tvwAgentStates.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvwAgentStates.EnableAutoScrollToSelectedNode = false;
            this.tvwAgentStates.ExtraColumnTextAlign = QuickMon.Controls.TreeViewExExtraColumnTextAlign.Left;
            this.tvwAgentStates.ExtraColumnWidth = 150;
            this.tvwAgentStates.HighLightWholeNode = true;
            this.tvwAgentStates.Location = new System.Drawing.Point(0, 0);
            this.tvwAgentStates.Name = "tvwAgentStates";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Node1";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Agent 1";
            this.tvwAgentStates.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvwAgentStates.RootAlwaysExpanded = false;
            this.tvwAgentStates.ShowColumnSeparatorLine = true;
            this.tvwAgentStates.ShowLines = false;
            this.tvwAgentStates.Size = new System.Drawing.Size(518, 196);
            this.tvwAgentStates.TabIndex = 0;
            // 
            // CollectorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.statusStripCollector);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CollectorDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collector Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CollectorDetails_FormClosing);
            this.Load += new System.EventHandler(this.CollectorDetails_Load);
            this.Shown += new System.EventHandler(this.CollectorDetails_Shown);
            this.statusStripCollector.ResumeLayout(false);
            this.statusStripCollector.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.panelCollectorDetails.ResumeLayout(false);
            this.panelEditing.ResumeLayout(false);
            this.panelHistory.ResumeLayout(false);
            this.panelMetrics.ResumeLayout(false);
            this.panelAgentStates.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.StatusStrip statusStripCollector;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem enabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoRefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEnabled;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAutoRefresh;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private Controls.TreeViewExBase tvwAgentStates;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton optHistory;
        private System.Windows.Forms.RadioButton optMetrics;
        private System.Windows.Forms.RadioButton optAgentStates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdActionScriptsVisible;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdCollectorEdit;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panelAgentStates;
        private System.Windows.Forms.Panel panelMetrics;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panelHistory;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panelEditing;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Panel panelCollectorDetails;
        private System.Windows.Forms.Label lblCollectorState;
    }
}