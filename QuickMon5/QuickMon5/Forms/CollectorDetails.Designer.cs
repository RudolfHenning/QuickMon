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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectorDetails));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Parameter 1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Script 1", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Parameter 1");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Parameter 2");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Script 2", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            HenIT.Windows.Controls.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new HenIT.Windows.Controls.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.statusStripCollector = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelEnabled = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelAutoRefresh = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRawEdit = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.collectorDetailSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panelCollectorDetails = new System.Windows.Forms.Panel();
            this.panelEditing = new System.Windows.Forms.Panel();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.panelMetrics = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelAgentStates = new System.Windows.Forms.Panel();
            this.agentStateSplitContainer = new System.Windows.Forms.SplitContainer();
            this.imagesCollectorTree = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.optHistoricStateView = new System.Windows.Forms.RadioButton();
            this.optCurrentStateView = new System.Windows.Forms.RadioButton();
            this.rtxDetails = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdActionScriptsVisible = new System.Windows.Forms.Button();
            this.optMetrics = new System.Windows.Forms.RadioButton();
            this.optAgentStates = new System.Windows.Forms.RadioButton();
            this.cmdCollectorEdit = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCollectorState = new System.Windows.Forms.Label();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.chkRAWDetails = new System.Windows.Forms.CheckBox();
            this.tlvAgentStates = new HenIT.Windows.Controls.TreeListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwHistory = new QuickMon.ListViewEx();
            this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.durationColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alertCountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.executedOnColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ranAsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.collectorValueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStripCollector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collectorDetailSplitContainer)).BeginInit();
            this.collectorDetailSplitContainer.Panel1.SuspendLayout();
            this.collectorDetailSplitContainer.Panel2.SuspendLayout();
            this.collectorDetailSplitContainer.SuspendLayout();
            this.panelCollectorDetails.SuspendLayout();
            this.panelEditing.SuspendLayout();
            this.panelMetrics.SuspendLayout();
            this.panelAgentStates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentStateSplitContainer)).BeginInit();
            this.agentStateSplitContainer.Panel1.SuspendLayout();
            this.agentStateSplitContainer.Panel2.SuspendLayout();
            this.agentStateSplitContainer.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.txtName.Location = new System.Drawing.Point(97, 11);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(918, 15);
            this.txtName.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(39, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 18);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "&Name:";
            // 
            // statusStripCollector
            // 
            this.statusStripCollector.BackColor = System.Drawing.Color.Transparent;
            this.statusStripCollector.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelEnabled,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelAutoRefresh,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelRawEdit,
            this.toolStripStatusLabel3});
            this.statusStripCollector.Location = new System.Drawing.Point(0, 586);
            this.statusStripCollector.Name = "statusStripCollector";
            this.statusStripCollector.Size = new System.Drawing.Size(1059, 22);
            this.statusStripCollector.TabIndex = 7;
            this.statusStripCollector.Text = "statusStrip1";
            this.statusStripCollector.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStripCollector_ItemClicked);
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
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
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
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabelRawEdit
            // 
            this.toolStripStatusLabelRawEdit.IsLink = true;
            this.toolStripStatusLabelRawEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.toolStripStatusLabelRawEdit.Name = "toolStripStatusLabelRawEdit";
            this.toolStripStatusLabelRawEdit.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusLabelRawEdit.Text = "Edit Raw Config";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMain.Location = new System.Drawing.Point(7, 36);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.collectorDetailSplitContainer);
            this.splitContainerMain.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.treeView1);
            this.splitContainerMain.Panel2.Controls.Add(this.panel2);
            this.splitContainerMain.Panel2.Controls.Add(this.label1);
            this.splitContainerMain.Panel2MinSize = 200;
            this.splitContainerMain.Size = new System.Drawing.Size(1045, 547);
            this.splitContainerMain.SplitterDistance = 841;
            this.splitContainerMain.TabIndex = 8;
            // 
            // collectorDetailSplitContainer
            // 
            this.collectorDetailSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collectorDetailSplitContainer.Location = new System.Drawing.Point(0, 25);
            this.collectorDetailSplitContainer.Name = "collectorDetailSplitContainer";
            this.collectorDetailSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // collectorDetailSplitContainer.Panel1
            // 
            this.collectorDetailSplitContainer.Panel1.Controls.Add(this.panelCollectorDetails);
            // 
            // collectorDetailSplitContainer.Panel2
            // 
            this.collectorDetailSplitContainer.Panel2.Controls.Add(this.rtxDetails);
            this.collectorDetailSplitContainer.Size = new System.Drawing.Size(841, 522);
            this.collectorDetailSplitContainer.SplitterDistance = 319;
            this.collectorDetailSplitContainer.TabIndex = 4;
            // 
            // panelCollectorDetails
            // 
            this.panelCollectorDetails.AutoScroll = true;
            this.panelCollectorDetails.Controls.Add(this.panelEditing);
            this.panelCollectorDetails.Controls.Add(this.panelMetrics);
            this.panelCollectorDetails.Controls.Add(this.panelAgentStates);
            this.panelCollectorDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCollectorDetails.Location = new System.Drawing.Point(0, 0);
            this.panelCollectorDetails.Name = "panelCollectorDetails";
            this.panelCollectorDetails.Size = new System.Drawing.Size(841, 319);
            this.panelCollectorDetails.TabIndex = 3;
            // 
            // panelEditing
            // 
            this.panelEditing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEditing.Controls.Add(this.cmdOK);
            this.panelEditing.Controls.Add(this.cmdCancel);
            this.panelEditing.Location = new System.Drawing.Point(13, 991);
            this.panelEditing.Name = "panelEditing";
            this.panelEditing.Size = new System.Drawing.Size(500, 394);
            this.panelEditing.TabIndex = 4;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(339, 366);
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
            this.cmdCancel.Location = new System.Drawing.Point(420, 366);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // panelMetrics
            // 
            this.panelMetrics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMetrics.Controls.Add(this.listView1);
            this.panelMetrics.Location = new System.Drawing.Point(9, 326);
            this.panelMetrics.Name = "panelMetrics";
            this.panelMetrics.Size = new System.Drawing.Size(654, 125);
            this.panelMetrics.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(652, 123);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Property";
            this.columnHeader1.Width = 211;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 198;
            // 
            // panelAgentStates
            // 
            this.panelAgentStates.Controls.Add(this.agentStateSplitContainer);
            this.panelAgentStates.Controls.Add(this.panel3);
            this.panelAgentStates.Location = new System.Drawing.Point(5, 8);
            this.panelAgentStates.Name = "panelAgentStates";
            this.panelAgentStates.Size = new System.Drawing.Size(740, 276);
            this.panelAgentStates.TabIndex = 1;
            // 
            // agentStateSplitContainer
            // 
            this.agentStateSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agentStateSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.agentStateSplitContainer.Name = "agentStateSplitContainer";
            this.agentStateSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // agentStateSplitContainer.Panel1
            // 
            this.agentStateSplitContainer.Panel1.Controls.Add(this.tlvAgentStates);
            // 
            // agentStateSplitContainer.Panel2
            // 
            this.agentStateSplitContainer.Panel2.Controls.Add(this.lvwHistory);
            this.agentStateSplitContainer.Panel2.Controls.Add(this.label3);
            this.agentStateSplitContainer.Size = new System.Drawing.Size(740, 248);
            this.agentStateSplitContainer.SplitterDistance = 124;
            this.agentStateSplitContainer.TabIndex = 3;
            // 
            // imagesCollectorTree
            // 
            this.imagesCollectorTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesCollectorTree.ImageStream")));
            this.imagesCollectorTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesCollectorTree.Images.SetKeyName(0, "open_folder_blue24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(1, "helpbwy24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(2, "ok.png");
            this.imagesCollectorTree.Images.SetKeyName(3, "triang_yellow.png");
            this.imagesCollectorTree.Images.SetKeyName(4, "Error24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(5, "ok3.png");
            this.imagesCollectorTree.Images.SetKeyName(6, "triang_yellow2.png");
            this.imagesCollectorTree.Images.SetKeyName(7, "Error2_24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(8, "ForbiddenBW16x16.png");
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(740, 1);
            this.label3.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkRAWDetails);
            this.panel3.Controls.Add(this.optHistoricStateView);
            this.panel3.Controls.Add(this.optCurrentStateView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 248);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(740, 28);
            this.panel3.TabIndex = 2;
            // 
            // optHistoricStateView
            // 
            this.optHistoricStateView.AutoSize = true;
            this.optHistoricStateView.Dock = System.Windows.Forms.DockStyle.Left;
            this.optHistoricStateView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optHistoricStateView.Location = new System.Drawing.Point(58, 0);
            this.optHistoricStateView.Name = "optHistoricStateView";
            this.optHistoricStateView.Size = new System.Drawing.Size(59, 28);
            this.optHistoricStateView.TabIndex = 2;
            this.optHistoricStateView.Text = "Historic";
            this.optHistoricStateView.UseVisualStyleBackColor = true;
            this.optHistoricStateView.CheckedChanged += new System.EventHandler(this.optHistoricStateView_CheckedChanged);
            // 
            // optCurrentStateView
            // 
            this.optCurrentStateView.AutoSize = true;
            this.optCurrentStateView.Checked = true;
            this.optCurrentStateView.Dock = System.Windows.Forms.DockStyle.Left;
            this.optCurrentStateView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optCurrentStateView.Location = new System.Drawing.Point(0, 0);
            this.optCurrentStateView.Name = "optCurrentStateView";
            this.optCurrentStateView.Size = new System.Drawing.Size(58, 28);
            this.optCurrentStateView.TabIndex = 1;
            this.optCurrentStateView.TabStop = true;
            this.optCurrentStateView.Text = "Current";
            this.optCurrentStateView.UseVisualStyleBackColor = true;
            this.optCurrentStateView.CheckedChanged += new System.EventHandler(this.optCurrentStateView_CheckedChanged);
            // 
            // rtxDetails
            // 
            this.rtxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxDetails.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxDetails.Location = new System.Drawing.Point(0, 0);
            this.rtxDetails.Name = "rtxDetails";
            this.rtxDetails.ReadOnly = true;
            this.rtxDetails.Size = new System.Drawing.Size(841, 199);
            this.rtxDetails.TabIndex = 2;
            this.rtxDetails.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdActionScriptsVisible);
            this.panel1.Controls.Add(this.optMetrics);
            this.panel1.Controls.Add(this.optAgentStates);
            this.panel1.Controls.Add(this.cmdCollectorEdit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 25);
            this.panel1.TabIndex = 1;
            // 
            // cmdActionScriptsVisible
            // 
            this.cmdActionScriptsVisible.BackColor = System.Drawing.Color.Transparent;
            this.cmdActionScriptsVisible.BackgroundImage = global::QuickMon.Properties.Resources.scroll24x24;
            this.cmdActionScriptsVisible.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdActionScriptsVisible.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdActionScriptsVisible.FlatAppearance.BorderSize = 0;
            this.cmdActionScriptsVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdActionScriptsVisible.Location = new System.Drawing.Point(787, 0);
            this.cmdActionScriptsVisible.Name = "cmdActionScriptsVisible";
            this.cmdActionScriptsVisible.Size = new System.Drawing.Size(27, 25);
            this.cmdActionScriptsVisible.TabIndex = 4;
            this.cmdActionScriptsVisible.UseVisualStyleBackColor = false;
            this.cmdActionScriptsVisible.Click += new System.EventHandler(this.cmdActionScriptsVisible_Click);
            // 
            // optMetrics
            // 
            this.optMetrics.AutoSize = true;
            this.optMetrics.Dock = System.Windows.Forms.DockStyle.Left;
            this.optMetrics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optMetrics.Location = new System.Drawing.Point(83, 0);
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
            this.optAgentStates.Location = new System.Drawing.Point(0, 0);
            this.optAgentStates.Name = "optAgentStates";
            this.optAgentStates.Size = new System.Drawing.Size(83, 25);
            this.optAgentStates.TabIndex = 0;
            this.optAgentStates.TabStop = true;
            this.optAgentStates.Text = "Agent states";
            this.optAgentStates.UseVisualStyleBackColor = true;
            this.optAgentStates.CheckedChanged += new System.EventHandler(this.optAgentStates_CheckedChanged);
            // 
            // cmdCollectorEdit
            // 
            this.cmdCollectorEdit.BackColor = System.Drawing.Color.Transparent;
            this.cmdCollectorEdit.BackgroundImage = global::QuickMon.Properties.Resources.doc_edit24x24;
            this.cmdCollectorEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdCollectorEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdCollectorEdit.FlatAppearance.BorderSize = 0;
            this.cmdCollectorEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCollectorEdit.Location = new System.Drawing.Point(814, 0);
            this.cmdCollectorEdit.Name = "cmdCollectorEdit";
            this.cmdCollectorEdit.Size = new System.Drawing.Size(27, 25);
            this.cmdCollectorEdit.TabIndex = 5;
            this.cmdCollectorEdit.UseVisualStyleBackColor = false;
            this.cmdCollectorEdit.Click += new System.EventHandler(this.cmdCollectorEdit_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(2, 25);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Parameter 1";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Script 1";
            treeNode3.Name = "Node3";
            treeNode3.Text = "Parameter 1";
            treeNode4.Name = "Node4";
            treeNode4.Text = "Parameter 2";
            treeNode5.Name = "Node2";
            treeNode5.Text = "Script 2";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode5});
            this.treeView1.Size = new System.Drawing.Size(198, 522);
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
            this.label1.Size = new System.Drawing.Size(2, 547);
            this.label1.TabIndex = 4;
            // 
            // lblCollectorState
            // 
            this.lblCollectorState.Image = global::QuickMon.Properties.Resources.helpbwy16x16;
            this.lblCollectorState.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCollectorState.Location = new System.Drawing.Point(7, 6);
            this.lblCollectorState.Name = "lblCollectorState";
            this.lblCollectorState.Size = new System.Drawing.Size(26, 25);
            this.lblCollectorState.TabIndex = 6;
            this.lblCollectorState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRefresh.BackColor = System.Drawing.Color.Transparent;
            this.cmdRefresh.BackgroundImage = global::QuickMon.Properties.Resources.refresh24x24;
            this.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRefresh.FlatAppearance.BorderSize = 0;
            this.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRefresh.Location = new System.Drawing.Point(1021, 5);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(26, 26);
            this.cmdRefresh.TabIndex = 9;
            this.cmdRefresh.UseVisualStyleBackColor = false;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // chkRAWDetails
            // 
            this.chkRAWDetails.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRAWDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkRAWDetails.FlatAppearance.BorderSize = 0;
            this.chkRAWDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRAWDetails.Image = global::QuickMon.Properties.Resources._131;
            this.chkRAWDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkRAWDetails.Location = new System.Drawing.Point(645, 0);
            this.chkRAWDetails.Name = "chkRAWDetails";
            this.chkRAWDetails.Size = new System.Drawing.Size(95, 28);
            this.chkRAWDetails.TabIndex = 3;
            this.chkRAWDetails.Text = "More details";
            this.chkRAWDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkRAWDetails.UseVisualStyleBackColor = true;
            this.chkRAWDetails.CheckedChanged += new System.EventHandler(this.chkRAWDetails_CheckedChanged);
            // 
            // tlvAgentStates
            // 
            this.tlvAgentStates.AllowSorting = false;
            this.tlvAgentStates.AutoResizeColumnEnabled = false;
            this.tlvAgentStates.AutoResizeColumnIndex = 0;
            this.tlvAgentStates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlvAgentStates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.valueColumnHeader});
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.None;
            this.tlvAgentStates.Comparer = treeListViewItemCollectionComparer1;
            this.tlvAgentStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlvAgentStates.HideSelection = false;
            this.tlvAgentStates.Location = new System.Drawing.Point(0, 0);
            this.tlvAgentStates.MultiSelect = false;
            this.tlvAgentStates.Name = "tlvAgentStates";
            this.tlvAgentStates.Size = new System.Drawing.Size(740, 124);
            this.tlvAgentStates.SmallImageList = this.imagesCollectorTree;
            this.tlvAgentStates.Sorting = System.Windows.Forms.SortOrder.None;
            this.tlvAgentStates.TabIndex = 1;
            this.tlvAgentStates.UseCompatibleStateImageBehavior = false;
            this.tlvAgentStates.SelectedIndexChanged += new System.EventHandler(this.tlvAgentStates_SelectedIndexChanged);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 325;
            // 
            // valueColumnHeader
            // 
            this.valueColumnHeader.Text = "Value";
            this.valueColumnHeader.Width = 150;
            // 
            // lvwHistory
            // 
            this.lvwHistory.AutoResizeColumnEnabled = false;
            this.lvwHistory.AutoResizeColumnIndex = 6;
            this.lvwHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timeColumnHeader,
            this.stateColumnHeader,
            this.durationColumnHeader,
            this.alertCountColumnHeader,
            this.executedOnColumnHeader,
            this.ranAsColumnHeader,
            this.collectorValueColumnHeader});
            this.lvwHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwHistory.FullRowSelect = true;
            this.lvwHistory.Location = new System.Drawing.Point(0, 1);
            this.lvwHistory.Name = "lvwHistory";
            this.lvwHistory.Size = new System.Drawing.Size(740, 119);
            this.lvwHistory.SmallImageList = this.imagesCollectorTree;
            this.lvwHistory.TabIndex = 0;
            this.lvwHistory.UseCompatibleStateImageBehavior = false;
            this.lvwHistory.View = System.Windows.Forms.View.Details;
            this.lvwHistory.SelectedIndexChanged += new System.EventHandler(this.lvwHistory_SelectedIndexChanged);
            // 
            // timeColumnHeader
            // 
            this.timeColumnHeader.Text = "Time";
            this.timeColumnHeader.Width = 153;
            // 
            // stateColumnHeader
            // 
            this.stateColumnHeader.Text = "State";
            this.stateColumnHeader.Width = 85;
            // 
            // durationColumnHeader
            // 
            this.durationColumnHeader.Text = "Duration (ms)";
            this.durationColumnHeader.Width = 87;
            // 
            // alertCountColumnHeader
            // 
            this.alertCountColumnHeader.Text = "Alerts";
            this.alertCountColumnHeader.Width = 48;
            // 
            // executedOnColumnHeader
            // 
            this.executedOnColumnHeader.Text = "Executed on";
            this.executedOnColumnHeader.Width = 88;
            // 
            // ranAsColumnHeader
            // 
            this.ranAsColumnHeader.Text = "Ran as";
            this.ranAsColumnHeader.Width = 103;
            // 
            // collectorValueColumnHeader
            // 
            this.collectorValueColumnHeader.Text = "Value";
            this.collectorValueColumnHeader.Width = 150;
            // 
            // CollectorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1059, 608);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.statusStripCollector);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCollectorState);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
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
            this.collectorDetailSplitContainer.Panel1.ResumeLayout(false);
            this.collectorDetailSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collectorDetailSplitContainer)).EndInit();
            this.collectorDetailSplitContainer.ResumeLayout(false);
            this.panelCollectorDetails.ResumeLayout(false);
            this.panelEditing.ResumeLayout(false);
            this.panelMetrics.ResumeLayout(false);
            this.panelAgentStates.ResumeLayout(false);
            this.agentStateSplitContainer.Panel1.ResumeLayout(false);
            this.agentStateSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agentStateSplitContainer)).EndInit();
            this.agentStateSplitContainer.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEnabled;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAutoRefresh;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panelEditing;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRawEdit;
        private System.Windows.Forms.Panel panelCollectorDetails;
        private System.Windows.Forms.Label lblCollectorState;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ImageList imagesCollectorTree;
        private HenIT.Windows.Controls.TreeListView tlvAgentStates;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader valueColumnHeader;
        private System.Windows.Forms.SplitContainer agentStateSplitContainer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton optHistoricStateView;
        private System.Windows.Forms.RadioButton optCurrentStateView;
        private ListViewEx lvwHistory;
        private System.Windows.Forms.ColumnHeader timeColumnHeader;
        private System.Windows.Forms.ColumnHeader stateColumnHeader;
        private System.Windows.Forms.ColumnHeader durationColumnHeader;
        private System.Windows.Forms.ColumnHeader alertCountColumnHeader;
        private System.Windows.Forms.ColumnHeader executedOnColumnHeader;
        private System.Windows.Forms.ColumnHeader ranAsColumnHeader;
        private System.Windows.Forms.ColumnHeader collectorValueColumnHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer collectorDetailSplitContainer;
        private System.Windows.Forms.RichTextBox rtxDetails;
        private System.Windows.Forms.CheckBox chkRAWDetails;
    }
}