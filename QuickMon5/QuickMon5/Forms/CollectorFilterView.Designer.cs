namespace QuickMon
{
    partial class CollectorFilterView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectorFilterView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblResetText = new QuickMon.Controls.LinkLabelEx();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.txtFilter = new QuickMon.Controls.TextBoxEx();
            this.cboStateFilter = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboFilterType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.includeEmptyfolderCollectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.itemCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.agentStateSplitContainer = new System.Windows.Forms.SplitContainer();
            this.lvwCollectorStates = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PathColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.collectorValueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.collectorContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.collectorDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesCollectorTree = new System.Windows.Forms.ImageList(this.components);
            this.llblDetails = new System.Windows.Forms.LinkLabel();
            this.rtxDetails = new System.Windows.Forms.RichTextBox();
            this.rawViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rawViewCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawViewSelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentStateSplitContainer)).BeginInit();
            this.agentStateSplitContainer.Panel1.SuspendLayout();
            this.agentStateSplitContainer.Panel2.SuspendLayout();
            this.agentStateSplitContainer.SuspendLayout();
            this.collectorContextMenuStrip.SuspendLayout();
            this.rawViewContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblResetText);
            this.panel1.Controls.Add(this.cmdRefresh);
            this.panel1.Controls.Add(this.txtFilter);
            this.panel1.Controls.Add(this.cboStateFilter);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboFilterType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(735, 33);
            this.panel1.TabIndex = 0;
            // 
            // lblResetText
            // 
            this.lblResetText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResetText.AutoSize = true;
            this.lblResetText.BackColorOnEnter = System.Drawing.Color.LightCyan;
            this.lblResetText.BackColorOnLeave = System.Drawing.Color.White;
            this.lblResetText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblResetText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetText.ForeColor = System.Drawing.Color.Red;
            this.lblResetText.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblResetText.LinkColor = System.Drawing.Color.Red;
            this.lblResetText.Location = new System.Drawing.Point(539, 10);
            this.lblResetText.Name = "lblResetText";
            this.lblResetText.Size = new System.Drawing.Size(15, 13);
            this.lblResetText.TabIndex = 6;
            this.lblResetText.TabStop = true;
            this.lblResetText.Text = "X";
            this.toolTip1.SetToolTip(this.lblResetText, "Clear filter test");
            this.lblResetText.Visible = false;
            this.lblResetText.Click += new System.EventHandler(this.lblResetText_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackColor = System.Drawing.Color.Transparent;
            this.cmdRefresh.BackgroundImage = global::QuickMon.Properties.Resources.refresh24x24;
            this.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdRefresh.FlatAppearance.BorderSize = 0;
            this.cmdRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRefresh.Location = new System.Drawing.Point(707, 0);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(28, 33);
            this.cmdRefresh.TabIndex = 5;
            this.cmdRefresh.UseVisualStyleBackColor = false;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.HideSelection = false;
            this.txtFilter.Location = new System.Drawing.Point(175, 6);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(361, 21);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.EnterKeyPressed += new System.Windows.Forms.MethodInvoker(this.txtFilter_EnterKeyPressed);
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // cboStateFilter
            // 
            this.cboStateFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStateFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStateFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStateFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStateFilter.FormattingEnabled = true;
            this.cboStateFilter.Items.AddRange(new object[] {
            "All",
            "Good",
            "Warning",
            "Error",
            "Warn & Err"});
            this.cboStateFilter.Location = new System.Drawing.Point(605, 5);
            this.cboStateFilter.Name = "cboStateFilter";
            this.cboStateFilter.Size = new System.Drawing.Size(92, 23);
            this.cboStateFilter.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(560, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "State";
            // 
            // cboFilterType
            // 
            this.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFilterType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFilterType.FormattingEnabled = true;
            this.cboFilterType.Items.AddRange(new object[] {
            "All",
            "Collector name",
            "Category",
            "Value"});
            this.cboFilterType.Location = new System.Drawing.Point(60, 5);
            this.cboFilterType.Name = "cboFilterType";
            this.cboFilterType.Size = new System.Drawing.Size(109, 23);
            this.cboFilterType.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Filters";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.selectedCountToolStripStatusLabel,
            this.toolStripStatusLabel1,
            this.itemCountToolStripStatusLabel,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 457);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(735, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.includeEmptyfolderCollectorsToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(143, 20);
            this.toolStripSplitButton1.Text = "Advanced filter options";
            // 
            // includeEmptyfolderCollectorsToolStripMenuItem
            // 
            this.includeEmptyfolderCollectorsToolStripMenuItem.CheckOnClick = true;
            this.includeEmptyfolderCollectorsToolStripMenuItem.Name = "includeEmptyfolderCollectorsToolStripMenuItem";
            this.includeEmptyfolderCollectorsToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.includeEmptyfolderCollectorsToolStripMenuItem.Text = "Include empty/folder collectors";
            this.includeEmptyfolderCollectorsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.includeEmptyfolderCollectorsToolStripMenuItem_CheckedChanged);
            // 
            // selectedCountToolStripStatusLabel
            // 
            this.selectedCountToolStripStatusLabel.Name = "selectedCountToolStripStatusLabel";
            this.selectedCountToolStripStatusLabel.Size = new System.Drawing.Size(13, 17);
            this.selectedCountToolStripStatusLabel.Text = "0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(51, 17);
            this.toolStripStatusLabel1.Text = "Selected";
            // 
            // itemCountToolStripStatusLabel
            // 
            this.itemCountToolStripStatusLabel.Name = "itemCountToolStripStatusLabel";
            this.itemCountToolStripStatusLabel.Size = new System.Drawing.Size(13, 17);
            this.itemCountToolStripStatusLabel.Text = "0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel2.Text = "Item(s)";
            // 
            // agentStateSplitContainer
            // 
            this.agentStateSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agentStateSplitContainer.Location = new System.Drawing.Point(0, 33);
            this.agentStateSplitContainer.Name = "agentStateSplitContainer";
            this.agentStateSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // agentStateSplitContainer.Panel1
            // 
            this.agentStateSplitContainer.Panel1.Controls.Add(this.lvwCollectorStates);
            this.agentStateSplitContainer.Panel1.Controls.Add(this.llblDetails);
            // 
            // agentStateSplitContainer.Panel2
            // 
            this.agentStateSplitContainer.Panel2.Controls.Add(this.rtxDetails);
            this.agentStateSplitContainer.Panel2.Controls.Add(this.label3);
            this.agentStateSplitContainer.Size = new System.Drawing.Size(735, 424);
            this.agentStateSplitContainer.SplitterDistance = 254;
            this.agentStateSplitContainer.SplitterWidth = 8;
            this.agentStateSplitContainer.TabIndex = 14;
            // 
            // lvwCollectorStates
            // 
            this.lvwCollectorStates.AutoResizeColumnEnabled = false;
            this.lvwCollectorStates.AutoResizeColumnIndex = 1;
            this.lvwCollectorStates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwCollectorStates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.PathColumnHeader,
            this.collectorValueColumnHeader});
            this.lvwCollectorStates.ContextMenuStrip = this.collectorContextMenuStrip;
            this.lvwCollectorStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwCollectorStates.FullRowSelect = true;
            this.lvwCollectorStates.HideSelection = false;
            this.lvwCollectorStates.Location = new System.Drawing.Point(0, 0);
            this.lvwCollectorStates.Name = "lvwCollectorStates";
            this.lvwCollectorStates.Size = new System.Drawing.Size(735, 236);
            this.lvwCollectorStates.SmallImageList = this.imagesCollectorTree;
            this.lvwCollectorStates.TabIndex = 0;
            this.lvwCollectorStates.UseCompatibleStateImageBehavior = false;
            this.lvwCollectorStates.View = System.Windows.Forms.View.Details;
            this.lvwCollectorStates.SelectedIndexChanged += new System.EventHandler(this.lvwCollectorStates_SelectedIndexChanged);
            this.lvwCollectorStates.DoubleClick += new System.EventHandler(this.collectorDetailToolStripMenuItem_Click);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 242;
            // 
            // PathColumnHeader
            // 
            this.PathColumnHeader.Text = "Path";
            this.PathColumnHeader.Width = 299;
            // 
            // collectorValueColumnHeader
            // 
            this.collectorValueColumnHeader.Text = "Value";
            this.collectorValueColumnHeader.Width = 157;
            // 
            // collectorContextMenuStrip
            // 
            this.collectorContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.collectorContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collectorDetailToolStripMenuItem,
            this.viewGraphToolStripMenuItem,
            this.toolStripSeparator1,
            this.addCategoriesToolStripMenuItem,
            this.removeCategoriesToolStripMenuItem});
            this.collectorContextMenuStrip.Name = "collectorContextMenuStrip";
            this.collectorContextMenuStrip.Size = new System.Drawing.Size(185, 130);
            // 
            // collectorDetailToolStripMenuItem
            // 
            this.collectorDetailToolStripMenuItem.Image = global::QuickMon.Properties.Resources.comp_search24;
            this.collectorDetailToolStripMenuItem.Name = "collectorDetailToolStripMenuItem";
            this.collectorDetailToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.collectorDetailToolStripMenuItem.Text = "Details";
            this.collectorDetailToolStripMenuItem.Click += new System.EventHandler(this.collectorDetailToolStripMenuItem_Click);
            // 
            // viewGraphToolStripMenuItem
            // 
            this.viewGraphToolStripMenuItem.Image = global::QuickMon.Properties.Resources.LineGraph;
            this.viewGraphToolStripMenuItem.Name = "viewGraphToolStripMenuItem";
            this.viewGraphToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.viewGraphToolStripMenuItem.Text = "View Graph";
            this.viewGraphToolStripMenuItem.Click += new System.EventHandler(this.viewGraphToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // addCategoriesToolStripMenuItem
            // 
            this.addCategoriesToolStripMenuItem.Image = global::QuickMon.Properties.Resources.add;
            this.addCategoriesToolStripMenuItem.Name = "addCategoriesToolStripMenuItem";
            this.addCategoriesToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.addCategoriesToolStripMenuItem.Text = "Add Categories";
            this.addCategoriesToolStripMenuItem.Click += new System.EventHandler(this.addCategoriesToolStripMenuItem_Click);
            // 
            // removeCategoriesToolStripMenuItem
            // 
            this.removeCategoriesToolStripMenuItem.Image = global::QuickMon.Properties.Resources.stop24x24;
            this.removeCategoriesToolStripMenuItem.Name = "removeCategoriesToolStripMenuItem";
            this.removeCategoriesToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.removeCategoriesToolStripMenuItem.Text = "Remove Categories";
            this.removeCategoriesToolStripMenuItem.Click += new System.EventHandler(this.removeCategoriesToolStripMenuItem_Click);
            // 
            // imagesCollectorTree
            // 
            this.imagesCollectorTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesCollectorTree.ImageStream")));
            this.imagesCollectorTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesCollectorTree.Images.SetKeyName(0, "open_folder_blue24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(1, "helpbwy24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(2, "ok.png");
            this.imagesCollectorTree.Images.SetKeyName(3, "triang_yellow.png");
            this.imagesCollectorTree.Images.SetKeyName(4, "triang_red24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(5, "ok3.png");
            this.imagesCollectorTree.Images.SetKeyName(6, "triang_yellow2.png");
            this.imagesCollectorTree.Images.SetKeyName(7, "triang_red24x24faded.png");
            this.imagesCollectorTree.Images.SetKeyName(8, "ForbiddenBW16x16.png");
            this.imagesCollectorTree.Images.SetKeyName(9, "clock1.png");
            this.imagesCollectorTree.Images.SetKeyName(10, "Error24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(11, "Error2_24x24.png");
            // 
            // llblDetails
            // 
            this.llblDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.llblDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.llblDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llblDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llblDetails.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblDetails.Location = new System.Drawing.Point(0, 236);
            this.llblDetails.Name = "llblDetails";
            this.llblDetails.Size = new System.Drawing.Size(735, 18);
            this.llblDetails.TabIndex = 1;
            this.llblDetails.TabStop = true;
            this.llblDetails.Text = "Details";
            this.llblDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblDetails_LinkClicked);
            // 
            // rtxDetails
            // 
            this.rtxDetails.ContextMenuStrip = this.rawViewContextMenuStrip;
            this.rtxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxDetails.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxDetails.HideSelection = false;
            this.rtxDetails.Location = new System.Drawing.Point(0, 1);
            this.rtxDetails.Name = "rtxDetails";
            this.rtxDetails.ReadOnly = true;
            this.rtxDetails.Size = new System.Drawing.Size(735, 161);
            this.rtxDetails.TabIndex = 3;
            this.rtxDetails.Text = "";
            // 
            // rawViewContextMenuStrip
            // 
            this.rawViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rawViewCopyToolStripMenuItem,
            this.rawViewSelectAllToolStripMenuItem});
            this.rawViewContextMenuStrip.Name = "rawViewContextMenuStrip";
            this.rawViewContextMenuStrip.Size = new System.Drawing.Size(123, 48);
            // 
            // rawViewCopyToolStripMenuItem
            // 
            this.rawViewCopyToolStripMenuItem.Name = "rawViewCopyToolStripMenuItem";
            this.rawViewCopyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.rawViewCopyToolStripMenuItem.Text = "C&opy";
            this.rawViewCopyToolStripMenuItem.Click += new System.EventHandler(this.rawViewCopyToolStripMenuItem_Click);
            // 
            // rawViewSelectAllToolStripMenuItem
            // 
            this.rawViewSelectAllToolStripMenuItem.Name = "rawViewSelectAllToolStripMenuItem";
            this.rawViewSelectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.rawViewSelectAllToolStripMenuItem.Text = "Select &All";
            this.rawViewSelectAllToolStripMenuItem.Click += new System.EventHandler(this.rawViewSelectAllToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(735, 1);
            this.label3.TabIndex = 1;
            // 
            // CollectorFilterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(735, 479);
            this.Controls.Add(this.agentStateSplitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "CollectorFilterView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collector states by filter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CollectorFilterView_FormClosing);
            this.Load += new System.EventHandler(this.CollectorFilterView_Load);
            this.Shown += new System.EventHandler(this.CollectorFilterView_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.agentStateSplitContainer.Panel1.ResumeLayout(false);
            this.agentStateSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agentStateSplitContainer)).EndInit();
            this.agentStateSplitContainer.ResumeLayout(false);
            this.collectorContextMenuStrip.ResumeLayout(false);
            this.rawViewContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer agentStateSplitContainer;
        private System.Windows.Forms.RichTextBox rtxDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboFilterType;
        private System.Windows.Forms.ComboBox cboStateFilter;
        private System.Windows.Forms.Label label5;
        private Controls.TextBoxEx txtFilter;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.ImageList imagesCollectorTree;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem includeEmptyfolderCollectorsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip collectorContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem collectorDetailToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addCategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCategoriesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip rawViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem rawViewCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawViewSelectAllToolStripMenuItem;
        private System.Windows.Forms.LinkLabel llblDetails;
        private QuickMon.Controls.LinkLabelEx lblResetText;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripStatusLabel selectedCountToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel itemCountToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem viewGraphToolStripMenuItem;
        private ListViewEx lvwCollectorStates;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader PathColumnHeader;
        private System.Windows.Forms.ColumnHeader collectorValueColumnHeader;
    }
}