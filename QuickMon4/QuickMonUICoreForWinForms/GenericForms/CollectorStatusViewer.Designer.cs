namespace QuickMon.Forms
{
    partial class CollectorStatusViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectorStatusViewer));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeImageList = new System.Windows.Forms.ImageList(this.components);
            this.lblCollectorHostStatusText = new System.Windows.Forms.Label();
            this.lblCollectorHostStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.currentStatusTabPage = new System.Windows.Forms.TabPage();
            this.agentsTabControl = new System.Windows.Forms.TabControl();
            this.agentStatusSummaryTabPage = new System.Windows.Forms.TabPage();
            this.lvwAgents = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.agentDetaildataTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabDataSetViewer = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkRemoteAgentEnabled = new System.Windows.Forms.CheckBox();
            this.remoteportNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRemoteAgentServer = new System.Windows.Forms.TextBox();
            this.currentStatusTabPage2 = new System.Windows.Forms.TabPage();
            this.lvwProperties = new QuickMon.ListViewEx();
            this.propertyNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageHistory = new System.Windows.Forms.TabPage();
            this.lvwHistory = new QuickMon.ListViewEx();
            this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.durationColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.detailsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alertsRaisedColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.executedOncolumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ranAsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageActionScripts = new System.Windows.Forms.TabPage();
            this.lvwActionScripts = new QuickMon.ListViewEx();
            this.actionScriptNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runActionScriptToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.runWithPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.rtxDetails = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.summaryToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.autoRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.currentStatusTabPage.SuspendLayout();
            this.agentsTabControl.SuspendLayout();
            this.agentStatusSummaryTabPage.SuspendLayout();
            this.agentDetaildataTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabDataSetViewer.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remoteportNumericUpDown)).BeginInit();
            this.currentStatusTabPage2.SuspendLayout();
            this.tabPageHistory.SuspendLayout();
            this.tabPageActionScripts.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(89, 5);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(485, 23);
            this.txtName.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 26);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::QuickMon.Properties.Resources.refresh24x24;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // treeImageList
            // 
            this.treeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImageList.ImageStream")));
            this.treeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImageList.Images.SetKeyName(0, "helpbwy24x24.png");
            this.treeImageList.Images.SetKeyName(1, "ok.png");
            this.treeImageList.Images.SetKeyName(2, "triang_yellow.png");
            this.treeImageList.Images.SetKeyName(3, "Error24x24.png");
            this.treeImageList.Images.SetKeyName(4, "ForbiddenGray16x16.png");
            // 
            // lblCollectorHostStatusText
            // 
            this.lblCollectorHostStatusText.AutoSize = true;
            this.lblCollectorHostStatusText.Location = new System.Drawing.Point(135, 38);
            this.lblCollectorHostStatusText.Name = "lblCollectorHostStatusText";
            this.lblCollectorHostStatusText.Size = new System.Drawing.Size(53, 13);
            this.lblCollectorHostStatusText.TabIndex = 4;
            this.lblCollectorHostStatusText.Text = "Unknown";
            // 
            // lblCollectorHostStatus
            // 
            this.lblCollectorHostStatus.Image = global::QuickMon.Properties.Resources.stop16x16;
            this.lblCollectorHostStatus.Location = new System.Drawing.Point(89, 30);
            this.lblCollectorHostStatus.Name = "lblCollectorHostStatus";
            this.lblCollectorHostStatus.Size = new System.Drawing.Size(40, 29);
            this.lblCollectorHostStatus.TabIndex = 3;
            this.lblCollectorHostStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current state:";
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRefresh.Image = global::QuickMon.Properties.Resources.refresh24x24;
            this.cmdRefresh.Location = new System.Drawing.Point(2, 0);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(39, 35);
            this.cmdRefresh.TabIndex = 0;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 62);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.cmdViewDetails);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtxDetails);
            this.splitContainer1.Size = new System.Drawing.Size(576, 446);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.currentStatusTabPage);
            this.tabControl1.Controls.Add(this.currentStatusTabPage2);
            this.tabControl1.Controls.Add(this.tabPageHistory);
            this.tabControl1.Controls.Add(this.tabPageActionScripts);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(576, 230);
            this.tabControl1.TabIndex = 0;
            // 
            // currentStatusTabPage
            // 
            this.currentStatusTabPage.BackColor = System.Drawing.Color.White;
            this.currentStatusTabPage.Controls.Add(this.agentsTabControl);
            this.currentStatusTabPage.Location = new System.Drawing.Point(4, 22);
            this.currentStatusTabPage.Name = "currentStatusTabPage";
            this.currentStatusTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.currentStatusTabPage.Size = new System.Drawing.Size(568, 204);
            this.currentStatusTabPage.TabIndex = 3;
            this.currentStatusTabPage.Text = "Agent";
            // 
            // agentsTabControl
            // 
            this.agentsTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.agentsTabControl.Controls.Add(this.agentStatusSummaryTabPage);
            this.agentsTabControl.Controls.Add(this.agentDetaildataTabPage);
            this.agentsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agentsTabControl.Location = new System.Drawing.Point(3, 3);
            this.agentsTabControl.Multiline = true;
            this.agentsTabControl.Name = "agentsTabControl";
            this.agentsTabControl.SelectedIndex = 0;
            this.agentsTabControl.Size = new System.Drawing.Size(562, 198);
            this.agentsTabControl.TabIndex = 2;
            this.agentsTabControl.SelectedIndexChanged += new System.EventHandler(this.agentsTabControl_SelectedIndexChanged);
            // 
            // agentStatusSummaryTabPage
            // 
            this.agentStatusSummaryTabPage.BackColor = System.Drawing.Color.White;
            this.agentStatusSummaryTabPage.Controls.Add(this.lvwAgents);
            this.agentStatusSummaryTabPage.Location = new System.Drawing.Point(23, 4);
            this.agentStatusSummaryTabPage.Name = "agentStatusSummaryTabPage";
            this.agentStatusSummaryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.agentStatusSummaryTabPage.Size = new System.Drawing.Size(535, 190);
            this.agentStatusSummaryTabPage.TabIndex = 0;
            this.agentStatusSummaryTabPage.Text = "States";
            // 
            // lvwAgents
            // 
            this.lvwAgents.AutoResizeColumnEnabled = false;
            this.lvwAgents.AutoResizeColumnIndex = 0;
            this.lvwAgents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.typeColumnHeader});
            this.lvwAgents.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwAgents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwAgents.FullRowSelect = true;
            this.lvwAgents.HideSelection = false;
            this.lvwAgents.Location = new System.Drawing.Point(3, 3);
            this.lvwAgents.Name = "lvwAgents";
            this.lvwAgents.Size = new System.Drawing.Size(529, 184);
            this.lvwAgents.SmallImageList = this.treeImageList;
            this.lvwAgents.TabIndex = 1;
            this.lvwAgents.UseCompatibleStateImageBehavior = false;
            this.lvwAgents.View = System.Windows.Forms.View.Details;
            this.lvwAgents.SelectedIndexChanged += new System.EventHandler(this.lvwAgents_SelectedIndexChanged);
            this.lvwAgents.DoubleClick += new System.EventHandler(this.lvwAgents_DoubleClick);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Agent Name";
            this.nameColumnHeader.Width = 227;
            // 
            // typeColumnHeader
            // 
            this.typeColumnHeader.Text = "Type";
            this.typeColumnHeader.Width = 205;
            // 
            // agentDetaildataTabPage
            // 
            this.agentDetaildataTabPage.BackColor = System.Drawing.Color.White;
            this.agentDetaildataTabPage.Controls.Add(this.panel2);
            this.agentDetaildataTabPage.Controls.Add(this.panel1);
            this.agentDetaildataTabPage.Location = new System.Drawing.Point(23, 4);
            this.agentDetaildataTabPage.Name = "agentDetaildataTabPage";
            this.agentDetaildataTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.agentDetaildataTabPage.Size = new System.Drawing.Size(535, 190);
            this.agentDetaildataTabPage.TabIndex = 1;
            this.agentDetaildataTabPage.Text = "Details";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabDataSetViewer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(529, 153);
            this.panel2.TabIndex = 4;
            // 
            // tabDataSetViewer
            // 
            this.tabDataSetViewer.Controls.Add(this.tabPage4);
            this.tabDataSetViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDataSetViewer.Location = new System.Drawing.Point(0, 0);
            this.tabDataSetViewer.Multiline = true;
            this.tabDataSetViewer.Name = "tabDataSetViewer";
            this.tabDataSetViewer.SelectedIndex = 0;
            this.tabDataSetViewer.Size = new System.Drawing.Size(529, 153);
            this.tabDataSetViewer.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(521, 127);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Data";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.chkRemoteAgentEnabled);
            this.panel1.Controls.Add(this.remoteportNumericUpDown);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtRemoteAgentServer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 31);
            this.panel1.TabIndex = 3;
            // 
            // chkRemoteAgentEnabled
            // 
            this.chkRemoteAgentEnabled.AutoSize = true;
            this.chkRemoteAgentEnabled.Location = new System.Drawing.Point(12, 6);
            this.chkRemoteAgentEnabled.Name = "chkRemoteAgentEnabled";
            this.chkRemoteAgentEnabled.Size = new System.Drawing.Size(103, 17);
            this.chkRemoteAgentEnabled.TabIndex = 0;
            this.chkRemoteAgentEnabled.Text = "Use remote host";
            this.chkRemoteAgentEnabled.UseVisualStyleBackColor = true;
            this.chkRemoteAgentEnabled.CheckedChanged += new System.EventHandler(this.chkRemoteAgentEnabled_CheckedChanged);
            // 
            // remoteportNumericUpDown
            // 
            this.remoteportNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remoteportNumericUpDown.Enabled = false;
            this.remoteportNumericUpDown.Location = new System.Drawing.Point(441, 5);
            this.remoteportNumericUpDown.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.remoteportNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.remoteportNumericUpDown.Name = "remoteportNumericUpDown";
            this.remoteportNumericUpDown.Size = new System.Drawing.Size(76, 20);
            this.remoteportNumericUpDown.TabIndex = 4;
            this.remoteportNumericUpDown.Value = new decimal(new int[] {
            48181,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(121, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Server name";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(409, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Port";
            // 
            // txtRemoteAgentServer
            // 
            this.txtRemoteAgentServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemoteAgentServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtRemoteAgentServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtRemoteAgentServer.Enabled = false;
            this.txtRemoteAgentServer.Location = new System.Drawing.Point(194, 4);
            this.txtRemoteAgentServer.Name = "txtRemoteAgentServer";
            this.txtRemoteAgentServer.Size = new System.Drawing.Size(209, 20);
            this.txtRemoteAgentServer.TabIndex = 2;
            // 
            // currentStatusTabPage2
            // 
            this.currentStatusTabPage2.BackColor = System.Drawing.Color.White;
            this.currentStatusTabPage2.Controls.Add(this.lvwProperties);
            this.currentStatusTabPage2.Location = new System.Drawing.Point(4, 22);
            this.currentStatusTabPage2.Name = "currentStatusTabPage2";
            this.currentStatusTabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.currentStatusTabPage2.Size = new System.Drawing.Size(568, 204);
            this.currentStatusTabPage2.TabIndex = 0;
            this.currentStatusTabPage2.Text = "Collector details and metrics";
            // 
            // lvwProperties
            // 
            this.lvwProperties.AutoResizeColumnEnabled = false;
            this.lvwProperties.AutoResizeColumnIndex = 0;
            this.lvwProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.propertyNameColumnHeader,
            this.valueColumnHeader});
            this.lvwProperties.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwProperties.FullRowSelect = true;
            this.lvwProperties.HideSelection = false;
            this.lvwProperties.Location = new System.Drawing.Point(3, 3);
            this.lvwProperties.Name = "lvwProperties";
            this.lvwProperties.Size = new System.Drawing.Size(562, 198);
            this.lvwProperties.TabIndex = 0;
            this.lvwProperties.UseCompatibleStateImageBehavior = false;
            this.lvwProperties.View = System.Windows.Forms.View.Details;
            this.lvwProperties.SelectedIndexChanged += new System.EventHandler(this.lvwProperties_SelectedIndexChanged);
            // 
            // propertyNameColumnHeader
            // 
            this.propertyNameColumnHeader.Text = "Property";
            this.propertyNameColumnHeader.Width = 218;
            // 
            // valueColumnHeader
            // 
            this.valueColumnHeader.Text = "Value";
            this.valueColumnHeader.Width = 205;
            // 
            // tabPageHistory
            // 
            this.tabPageHistory.BackColor = System.Drawing.Color.White;
            this.tabPageHistory.Controls.Add(this.lvwHistory);
            this.tabPageHistory.Location = new System.Drawing.Point(4, 22);
            this.tabPageHistory.Name = "tabPageHistory";
            this.tabPageHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHistory.Size = new System.Drawing.Size(568, 204);
            this.tabPageHistory.TabIndex = 1;
            this.tabPageHistory.Text = "History";
            // 
            // lvwHistory
            // 
            this.lvwHistory.AutoResizeColumnEnabled = false;
            this.lvwHistory.AutoResizeColumnIndex = 0;
            this.lvwHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timeColumnHeader,
            this.stateColumnHeader,
            this.durationColumnHeader,
            this.detailsColumnHeader,
            this.alertsRaisedColumnHeader,
            this.executedOncolumnHeader,
            this.ranAsColumnHeader});
            this.lvwHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwHistory.FullRowSelect = true;
            this.lvwHistory.HideSelection = false;
            this.lvwHistory.Location = new System.Drawing.Point(3, 3);
            this.lvwHistory.Name = "lvwHistory";
            this.lvwHistory.Size = new System.Drawing.Size(562, 198);
            this.lvwHistory.SmallImageList = this.treeImageList;
            this.lvwHistory.TabIndex = 2;
            this.lvwHistory.UseCompatibleStateImageBehavior = false;
            this.lvwHistory.View = System.Windows.Forms.View.Details;
            this.lvwHistory.SelectedIndexChanged += new System.EventHandler(this.lvwHistory_SelectedIndexChanged);
            // 
            // timeColumnHeader
            // 
            this.timeColumnHeader.Text = "Time";
            this.timeColumnHeader.Width = 168;
            // 
            // stateColumnHeader
            // 
            this.stateColumnHeader.Text = "State";
            this.stateColumnHeader.Width = 80;
            // 
            // durationColumnHeader
            // 
            this.durationColumnHeader.Text = "Duration (ms)";
            this.durationColumnHeader.Width = 84;
            // 
            // detailsColumnHeader
            // 
            this.detailsColumnHeader.Text = "Details";
            this.detailsColumnHeader.Width = 144;
            // 
            // alertsRaisedColumnHeader
            // 
            this.alertsRaisedColumnHeader.Text = "Alerts";
            this.alertsRaisedColumnHeader.Width = 57;
            // 
            // executedOncolumnHeader
            // 
            this.executedOncolumnHeader.Text = "Executed on";
            this.executedOncolumnHeader.Width = 92;
            // 
            // ranAsColumnHeader
            // 
            this.ranAsColumnHeader.Text = "Ran as";
            this.ranAsColumnHeader.Width = 90;
            // 
            // tabPageActionScripts
            // 
            this.tabPageActionScripts.Controls.Add(this.lvwActionScripts);
            this.tabPageActionScripts.Location = new System.Drawing.Point(4, 22);
            this.tabPageActionScripts.Name = "tabPageActionScripts";
            this.tabPageActionScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageActionScripts.Size = new System.Drawing.Size(568, 204);
            this.tabPageActionScripts.TabIndex = 4;
            this.tabPageActionScripts.Text = "Action scripts";
            this.tabPageActionScripts.UseVisualStyleBackColor = true;
            // 
            // lvwActionScripts
            // 
            this.lvwActionScripts.AutoResizeColumnEnabled = false;
            this.lvwActionScripts.AutoResizeColumnIndex = 2;
            this.lvwActionScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.actionScriptNameColumnHeader,
            this.columnHeader2,
            this.columnHeader1});
            this.lvwActionScripts.ContextMenuStrip = this.contextMenuStrip2;
            this.lvwActionScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwActionScripts.FullRowSelect = true;
            this.lvwActionScripts.Location = new System.Drawing.Point(3, 3);
            this.lvwActionScripts.Name = "lvwActionScripts";
            this.lvwActionScripts.Size = new System.Drawing.Size(562, 198);
            this.lvwActionScripts.TabIndex = 3;
            this.lvwActionScripts.UseCompatibleStateImageBehavior = false;
            this.lvwActionScripts.View = System.Windows.Forms.View.Details;
            this.lvwActionScripts.EnterKeyPressed += new System.Windows.Forms.MethodInvoker(this.lvwActionScripts_EnterKeyPressed);
            this.lvwActionScripts.SelectedIndexChanged += new System.EventHandler(this.lvwActionScripts_SelectedIndexChanged);
            this.lvwActionScripts.DoubleClick += new System.EventHandler(this.lvwActionScripts_DoubleClick);
            // 
            // actionScriptNameColumnHeader
            // 
            this.actionScriptNameColumnHeader.Text = "Name";
            this.actionScriptNameColumnHeader.Width = 226;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 99;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 204;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runActionScriptToolStripMenuItem1,
            this.runWithPauseToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(156, 48);
            // 
            // runActionScriptToolStripMenuItem1
            // 
            this.runActionScriptToolStripMenuItem1.Image = global::QuickMon.Properties.Resources.lightbulb;
            this.runActionScriptToolStripMenuItem1.Name = "runActionScriptToolStripMenuItem1";
            this.runActionScriptToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.runActionScriptToolStripMenuItem1.Text = "Run";
            this.runActionScriptToolStripMenuItem1.Click += new System.EventHandler(this.runActionScriptToolStripMenuItem1_Click);
            // 
            // runWithPauseToolStripMenuItem
            // 
            this.runWithPauseToolStripMenuItem.Image = global::QuickMon.Properties.Resources.lightbulb_off;
            this.runWithPauseToolStripMenuItem.Name = "runWithPauseToolStripMenuItem";
            this.runWithPauseToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.runWithPauseToolStripMenuItem.Text = "Run with Pause";
            this.runWithPauseToolStripMenuItem.Click += new System.EventHandler(this.runWithPauseToolStripMenuItem_Click);
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.BackColor = System.Drawing.Color.DarkGray;
            this.cmdViewDetails.BackgroundImage = global::QuickMon.Properties.Resources.MenuBlueShade;
            this.cmdViewDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdViewDetails.FlatAppearance.BorderSize = 0;
            this.cmdViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDetails.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdViewDetails.Location = new System.Drawing.Point(0, 230);
            this.cmdViewDetails.Margin = new System.Windows.Forms.Padding(0);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(576, 16);
            this.cmdViewDetails.TabIndex = 1;
            this.cmdViewDetails.Text = "ttt";
            this.cmdViewDetails.UseVisualStyleBackColor = false;
            this.cmdViewDetails.Click += new System.EventHandler(this.cmdViewDetails_Click);
            // 
            // rtxDetails
            // 
            this.rtxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxDetails.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxDetails.Location = new System.Drawing.Point(0, 0);
            this.rtxDetails.Name = "rtxDetails";
            this.rtxDetails.ReadOnly = true;
            this.rtxDetails.Size = new System.Drawing.Size(576, 196);
            this.rtxDetails.TabIndex = 0;
            this.rtxDetails.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.summaryToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 511);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(579, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // summaryToolStripStatusLabel
            // 
            this.summaryToolStripStatusLabel.Name = "summaryToolStripStatusLabel";
            this.summaryToolStripStatusLabel.Size = new System.Drawing.Size(564, 17);
            this.summaryToolStripStatusLabel.Spring = true;
            this.summaryToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.BackColor = System.Drawing.Color.Transparent;
            this.chkAutoRefresh.Location = new System.Drawing.Point(488, 37);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(83, 17);
            this.chkAutoRefresh.TabIndex = 12;
            this.chkAutoRefresh.Text = "Auto refresh";
            this.chkAutoRefresh.UseVisualStyleBackColor = false;
            // 
            // autoRefreshTimer
            // 
            this.autoRefreshTimer.Enabled = true;
            this.autoRefreshTimer.Interval = 30000;
            this.autoRefreshTimer.Tick += new System.EventHandler(this.autoRefreshTimer_Tick);
            // 
            // CollectorStatusViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(579, 533);
            this.Controls.Add(this.chkAutoRefresh);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblCollectorHostStatusText);
            this.Controls.Add(this.lblCollectorHostStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(480, 420);
            this.Name = "CollectorStatusViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collector Status Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CollectorStatusViewer_FormClosing);
            this.Load += new System.EventHandler(this.CollectorStatusViewer_Load);
            this.Shown += new System.EventHandler(this.CollectorStatusViewer_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.currentStatusTabPage.ResumeLayout(false);
            this.agentsTabControl.ResumeLayout(false);
            this.agentStatusSummaryTabPage.ResumeLayout(false);
            this.agentDetaildataTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabDataSetViewer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remoteportNumericUpDown)).EndInit();
            this.currentStatusTabPage2.ResumeLayout(false);
            this.tabPageHistory.ResumeLayout(false);
            this.tabPageActionScripts.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage currentStatusTabPage2;
        private System.Windows.Forms.TabPage tabPageHistory;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button cmdViewDetails;
        private System.Windows.Forms.RichTextBox rtxDetails;
        private ListViewEx lvwProperties;
        private System.Windows.Forms.ColumnHeader propertyNameColumnHeader;
        private System.Windows.Forms.ColumnHeader valueColumnHeader;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private ListViewEx lvwHistory;
        private System.Windows.Forms.ColumnHeader timeColumnHeader;
        private System.Windows.Forms.ColumnHeader stateColumnHeader;
        private System.Windows.Forms.ColumnHeader durationColumnHeader;
        private System.Windows.Forms.ColumnHeader detailsColumnHeader;
        private System.Windows.Forms.ColumnHeader executedOncolumnHeader;
        private System.Windows.Forms.ColumnHeader alertsRaisedColumnHeader;
        private System.Windows.Forms.ImageList treeImageList;
        private System.Windows.Forms.TabPage currentStatusTabPage;
        private ListViewEx lvwAgents;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader typeColumnHeader;
        private System.Windows.Forms.Label lblCollectorHostStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCollectorHostStatusText;
        private System.Windows.Forms.TabControl agentsTabControl;
        private System.Windows.Forms.TabPage agentStatusSummaryTabPage;
        private System.Windows.Forms.TabPage agentDetaildataTabPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkRemoteAgentEnabled;
        private System.Windows.Forms.NumericUpDown remoteportNumericUpDown;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRemoteAgentServer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabDataSetViewer;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel summaryToolStripStatusLabel;
        private System.Windows.Forms.ColumnHeader ranAsColumnHeader;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.Timer autoRefreshTimer;
        private System.Windows.Forms.TabPage tabPageActionScripts;
        private ListViewEx lvwActionScripts;
        private System.Windows.Forms.ColumnHeader actionScriptNameColumnHeader;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem runActionScriptToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem runWithPauseToolStripMenuItem;
    }
}