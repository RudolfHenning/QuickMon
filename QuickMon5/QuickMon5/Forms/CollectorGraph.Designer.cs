namespace QuickMon
{
    partial class CollectorGraph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectorGraph));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.showFiltersToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.exportToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvwCollectorStates = new QuickMon.ListViewEx();
            this.PathColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.collectorValueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.collectorListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesCollectorTree = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblResetText = new System.Windows.Forms.Label();
            this.txtTextFilter = new QuickMon.Controls.TextBoxEx();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.nudLastXEntries = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nudinitialMax = new System.Windows.Forms.NumericUpDown();
            this.chkAutoMaxValue = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toDateTimeChooser = new HenIT.Controls.DateTimeChooser();
            this.chkAutoToTime = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fromDateTimeChooser = new HenIT.Controls.DateTimeChooser();
            this.chkAutoFromTime = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.collectorTimeGraph = new HenIT.Windows.Controls.Graphing.TimeGraphControl();
            this.graphContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCollectorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearGraphTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logarithmicGraphTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grapthColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphBackgroundColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGradientColor1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGradientColor2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swapGraphGradientColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGradientDirectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGradientDirectionHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGradientDirectionVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGradientDirectionForwardDiagonalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGradientDirectionBackwardDiagonalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGridColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphAxisLabelColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphSelectionColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphSelectionBarColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphClosestClickedValueColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphClosestClickedColorSameAsSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphClosestClickedColorInvertedColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphClosestClickedColorCustomColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphVisibilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphHeaderVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legendVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphHorisonalGridLinesVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphVerticalGridLinesVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphSelectionbarVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphHighlightClickedSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaBelowSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaBelowSeriesEnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaAlpha16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaAlpha32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaAlpha48ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaAlpha64ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaAlpha128ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaAlpha192ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.seriesColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.collectorListContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLastXEntries)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudinitialMax)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.graphContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripButton,
            this.showFiltersToolStripButton,
            this.exportToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(834, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = global::QuickMon.Properties.Resources.refresh24x24;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.refreshToolStripButton.Text = "Refresh";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // showFiltersToolStripButton
            // 
            this.showFiltersToolStripButton.CheckOnClick = true;
            this.showFiltersToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showFiltersToolStripButton.Image = global::QuickMon.Properties.Resources.tools24x24;
            this.showFiltersToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showFiltersToolStripButton.Name = "showFiltersToolStripButton";
            this.showFiltersToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.showFiltersToolStripButton.Text = "View Filters";
            this.showFiltersToolStripButton.CheckStateChanged += new System.EventHandler(this.showFiltersToolStripButton_CheckStateChanged);
            // 
            // exportToolStripButton
            // 
            this.exportToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportToolStripButton.Image = global::QuickMon.Properties.Resources.folder_stats;
            this.exportToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportToolStripButton.Name = "exportToolStripButton";
            this.exportToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.exportToolStripButton.Text = "Export graph";
            this.exportToolStripButton.Click += new System.EventHandler(this.exportToolStripButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 436);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvwCollectorStates);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.collectorTimeGraph);
            this.splitContainer1.Size = new System.Drawing.Size(834, 405);
            this.splitContainer1.SplitterDistance = 241;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // lvwCollectorStates
            // 
            this.lvwCollectorStates.AutoResizeColumnEnabled = false;
            this.lvwCollectorStates.AutoResizeColumnIndex = 0;
            this.lvwCollectorStates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwCollectorStates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PathColumnHeader,
            this.collectorValueColumnHeader});
            this.lvwCollectorStates.ContextMenuStrip = this.collectorListContextMenuStrip;
            this.lvwCollectorStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwCollectorStates.FullRowSelect = true;
            this.lvwCollectorStates.Location = new System.Drawing.Point(0, 230);
            this.lvwCollectorStates.Name = "lvwCollectorStates";
            this.lvwCollectorStates.Size = new System.Drawing.Size(241, 175);
            this.lvwCollectorStates.SmallImageList = this.imagesCollectorTree;
            this.lvwCollectorStates.TabIndex = 0;
            this.lvwCollectorStates.UseCompatibleStateImageBehavior = false;
            this.lvwCollectorStates.View = System.Windows.Forms.View.Details;
            // 
            // PathColumnHeader
            // 
            this.PathColumnHeader.Text = "Collector";
            this.PathColumnHeader.Width = 153;
            // 
            // collectorValueColumnHeader
            // 
            this.collectorValueColumnHeader.Text = "Value";
            this.collectorValueColumnHeader.Width = 72;
            // 
            // collectorListContextMenuStrip
            // 
            this.collectorListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCollectorToolStripMenuItem,
            this.removeCollectorToolStripMenuItem});
            this.collectorListContextMenuStrip.Name = "collectorListContextMenuStrip";
            this.collectorListContextMenuStrip.Size = new System.Drawing.Size(169, 48);
            // 
            // addCollectorToolStripMenuItem
            // 
            this.addCollectorToolStripMenuItem.Image = global::QuickMon.Properties.Resources.addGreen24x24;
            this.addCollectorToolStripMenuItem.Name = "addCollectorToolStripMenuItem";
            this.addCollectorToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.addCollectorToolStripMenuItem.Text = "Add Collector";
            this.addCollectorToolStripMenuItem.Click += new System.EventHandler(this.addCollectorToolStripMenuItem_Click);
            // 
            // removeCollectorToolStripMenuItem
            // 
            this.removeCollectorToolStripMenuItem.Image = global::QuickMon.Properties.Resources.stop24x24;
            this.removeCollectorToolStripMenuItem.Name = "removeCollectorToolStripMenuItem";
            this.removeCollectorToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.removeCollectorToolStripMenuItem.Text = "Remove Collector";
            this.removeCollectorToolStripMenuItem.Click += new System.EventHandler(this.removeCollectorToolStripMenuItem_Click);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.lblResetText);
            this.panel1.Controls.Add(this.txtTextFilter);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 230);
            this.panel1.TabIndex = 0;
            // 
            // lblResetText
            // 
            this.lblResetText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResetText.AutoSize = true;
            this.lblResetText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblResetText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetText.ForeColor = System.Drawing.Color.Red;
            this.lblResetText.Location = new System.Drawing.Point(224, 207);
            this.lblResetText.Name = "lblResetText";
            this.lblResetText.Size = new System.Drawing.Size(15, 13);
            this.lblResetText.TabIndex = 7;
            this.lblResetText.Text = "X";
            this.toolTip1.SetToolTip(this.lblResetText, "Clear text");
            this.lblResetText.Visible = false;
            this.lblResetText.Click += new System.EventHandler(this.lblResetText_Click);
            // 
            // txtTextFilter
            // 
            this.txtTextFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTextFilter.Location = new System.Drawing.Point(45, 204);
            this.txtTextFilter.Name = "txtTextFilter";
            this.txtTextFilter.Size = new System.Drawing.Size(177, 20);
            this.txtTextFilter.TabIndex = 6;
            this.txtTextFilter.EnterKeyPressed += new System.Windows.Forms.MethodInvoker(this.txtTextFilter_EnterKeyPressed);
            this.txtTextFilter.TextChanged += new System.EventHandler(this.txtTextFilter_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Text";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.nudLastXEntries);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 171);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(241, 29);
            this.panel5.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(138, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Entries";
            // 
            // nudLastXEntries
            // 
            this.nudLastXEntries.Location = new System.Drawing.Point(45, 3);
            this.nudLastXEntries.Name = "nudLastXEntries";
            this.nudLastXEntries.Size = new System.Drawing.Size(87, 20);
            this.nudLastXEntries.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Last";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nudinitialMax);
            this.panel4.Controls.Add(this.chkAutoMaxValue);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 122);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(241, 49);
            this.panel4.TabIndex = 3;
            // 
            // nudinitialMax
            // 
            this.nudinitialMax.Location = new System.Drawing.Point(45, 26);
            this.nudinitialMax.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudinitialMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudinitialMax.Name = "nudinitialMax";
            this.nudinitialMax.Size = new System.Drawing.Size(87, 20);
            this.nudinitialMax.TabIndex = 2;
            this.nudinitialMax.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // chkAutoMaxValue
            // 
            this.chkAutoMaxValue.AutoSize = true;
            this.chkAutoMaxValue.Checked = true;
            this.chkAutoMaxValue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoMaxValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAutoMaxValue.Location = new System.Drawing.Point(45, 3);
            this.chkAutoMaxValue.Name = "chkAutoMaxValue";
            this.chkAutoMaxValue.Size = new System.Drawing.Size(78, 17);
            this.chkAutoMaxValue.TabIndex = 1;
            this.chkAutoMaxValue.Text = "Auto (Initial)";
            this.chkAutoMaxValue.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Max";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.toDateTimeChooser);
            this.panel3.Controls.Add(this.chkAutoToTime);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 71);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(241, 51);
            this.panel3.TabIndex = 2;
            // 
            // toDateTimeChooser
            // 
            this.toDateTimeChooser.AutoSize = true;
            this.toDateTimeChooser.BackColor = System.Drawing.Color.Transparent;
            this.toDateTimeChooser.Location = new System.Drawing.Point(45, 23);
            this.toDateTimeChooser.Name = "toDateTimeChooser";
            this.toDateTimeChooser.SelectedDateTime = new System.DateTime(2020, 12, 20, 23, 59, 0, 0);
            this.toDateTimeChooser.Size = new System.Drawing.Size(146, 25);
            this.toDateTimeChooser.TabIndex = 2;
            // 
            // chkAutoToTime
            // 
            this.chkAutoToTime.AutoSize = true;
            this.chkAutoToTime.Checked = true;
            this.chkAutoToTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoToTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAutoToTime.Location = new System.Drawing.Point(45, 0);
            this.chkAutoToTime.Name = "chkAutoToTime";
            this.chkAutoToTime.Size = new System.Drawing.Size(45, 17);
            this.chkAutoToTime.TabIndex = 1;
            this.chkAutoToTime.Text = "Auto";
            this.chkAutoToTime.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "To";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fromDateTimeChooser);
            this.panel2.Controls.Add(this.chkAutoFromTime);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 51);
            this.panel2.TabIndex = 1;
            // 
            // fromDateTimeChooser
            // 
            this.fromDateTimeChooser.AutoSize = true;
            this.fromDateTimeChooser.BackColor = System.Drawing.Color.Transparent;
            this.fromDateTimeChooser.Location = new System.Drawing.Point(45, 23);
            this.fromDateTimeChooser.Name = "fromDateTimeChooser";
            this.fromDateTimeChooser.SelectedDateTime = new System.DateTime(2020, 12, 20, 23, 59, 0, 0);
            this.fromDateTimeChooser.Size = new System.Drawing.Size(146, 25);
            this.fromDateTimeChooser.TabIndex = 2;
            // 
            // chkAutoFromTime
            // 
            this.chkAutoFromTime.AutoSize = true;
            this.chkAutoFromTime.Checked = true;
            this.chkAutoFromTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoFromTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAutoFromTime.Location = new System.Drawing.Point(45, 0);
            this.chkAutoFromTime.Name = "chkAutoFromTime";
            this.chkAutoFromTime.Size = new System.Drawing.Size(45, 17);
            this.chkAutoFromTime.TabIndex = 1;
            this.chkAutoFromTime.Text = "Auto";
            this.chkAutoFromTime.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "From";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filters";
            // 
            // collectorTimeGraph
            // 
            this.collectorTimeGraph.AxisLabelColor = System.Drawing.Color.Black;
            this.collectorTimeGraph.BackColor = System.Drawing.Color.Black;
            this.collectorTimeGraph.BackgroundColor = System.Drawing.Color.White;
            this.collectorTimeGraph.BackgroundGradientColor1 = System.Drawing.Color.White;
            this.collectorTimeGraph.BackgroundGradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.collectorTimeGraph.BackgroundIsGradient = true;
            this.collectorTimeGraph.ClosestClickedValueColorType = HenIT.Windows.Controls.Graphing.ClosestClickedValueColorType.SeriesColor;
            this.collectorTimeGraph.ClosestClickedValueCustomColor = System.Drawing.Color.White;
            this.collectorTimeGraph.ContextMenuStrip = this.graphContextMenuStrip;
            this.collectorTimeGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collectorTimeGraph.EndDateTime = new System.DateTime(((long)(0)));
            this.collectorTimeGraph.FillAreaBelowGraph = true;
            this.collectorTimeGraph.FillAreaBelowGraphAlpha = 48;
            this.collectorTimeGraph.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.collectorTimeGraph.GraphHeaderFont = new System.Drawing.Font("Verdana", 12F);
            this.collectorTimeGraph.GraphHeaderText = "";
            this.collectorTimeGraph.GraphLineFormatType = HenIT.Windows.Controls.Graphing.GraphLineFormatType.Straight;
            this.collectorTimeGraph.GraphTextFont = new System.Drawing.Font("Verdana", 8F);
            this.collectorTimeGraph.GraphVerticalAxisType = HenIT.Windows.Controls.Graphing.GraphVerticalAxisType.Logarithmic;
            this.collectorTimeGraph.GridColor = System.Drawing.Color.Silver;
            this.collectorTimeGraph.HighlightClickedSeries = true;
            this.collectorTimeGraph.HighlightSeriesWidth = 3;
            this.collectorTimeGraph.InitialMaxGraphValue = ((long)(100));
            this.collectorTimeGraph.LastClickedLocation = null;
            this.collectorTimeGraph.LastClickedTimeSelected = false;
            this.collectorTimeGraph.LastClickedValue = -1D;
            this.collectorTimeGraph.LeftAxisMargin = 25;
            this.collectorTimeGraph.Location = new System.Drawing.Point(0, 0);
            this.collectorTimeGraph.MaxGraphValue = ((long)(1));
            this.collectorTimeGraph.Name = "collectorTimeGraph";
            this.collectorTimeGraph.NoHighlightSeriesWidth = 2;
            this.collectorTimeGraph.RightAxisMargin = 25;
            this.collectorTimeGraph.Series = null;
            this.collectorTimeGraph.ShowClickScanSearchBlock = false;
            this.collectorTimeGraph.ShowClosestClickedValue = true;
            this.collectorTimeGraph.ShowGraphHeader = false;
            this.collectorTimeGraph.ShowHorisontalGridlines = true;
            this.collectorTimeGraph.ShowLastClickedLocation = false;
            this.collectorTimeGraph.ShowLegendText = true;
            this.collectorTimeGraph.ShowSelectionBar = true;
            this.collectorTimeGraph.ShowVerticalGridLines = true;
            this.collectorTimeGraph.Size = new System.Drawing.Size(587, 405);
            this.collectorTimeGraph.StartDateTime = new System.DateTime(((long)(0)));
            this.collectorTimeGraph.TabIndex = 0;
            this.collectorTimeGraph.Text = "timeGraphControl1";
            this.collectorTimeGraph.TimeSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            // 
            // graphContextMenuStrip
            // 
            this.graphContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCollectorToolStripMenuItem1,
            this.toolStripSeparator1,
            this.filtersToolStripMenuItem,
            this.graphTypeToolStripMenuItem,
            this.grapthColorsToolStripMenuItem,
            this.graphVisibilityToolStripMenuItem,
            this.exportGraphToolStripMenuItem});
            this.graphContextMenuStrip.Name = "graphContextMenuStrip";
            this.graphContextMenuStrip.Size = new System.Drawing.Size(153, 164);
            this.graphContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.graphContextMenuStrip_Opening);
            // 
            // addCollectorToolStripMenuItem1
            // 
            this.addCollectorToolStripMenuItem1.Image = global::QuickMon.Properties.Resources.addGreen24x24;
            this.addCollectorToolStripMenuItem1.Name = "addCollectorToolStripMenuItem1";
            this.addCollectorToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.addCollectorToolStripMenuItem1.Text = "Add Collector";
            this.addCollectorToolStripMenuItem1.Click += new System.EventHandler(this.addCollectorToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.Image = global::QuickMon.Properties.Resources.tools16x16;
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.filtersToolStripMenuItem.Text = "Filters";
            this.filtersToolStripMenuItem.Click += new System.EventHandler(this.filtersToolStripMenuItem_Click);
            // 
            // graphTypeToolStripMenuItem
            // 
            this.graphTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linearGraphTypeToolStripMenuItem,
            this.logarithmicGraphTypeToolStripMenuItem});
            this.graphTypeToolStripMenuItem.Name = "graphTypeToolStripMenuItem";
            this.graphTypeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.graphTypeToolStripMenuItem.Text = "Graph Type";
            // 
            // linearGraphTypeToolStripMenuItem
            // 
            this.linearGraphTypeToolStripMenuItem.CheckOnClick = true;
            this.linearGraphTypeToolStripMenuItem.Name = "linearGraphTypeToolStripMenuItem";
            this.linearGraphTypeToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.linearGraphTypeToolStripMenuItem.Text = "Linear Graph Type";
            this.linearGraphTypeToolStripMenuItem.Click += new System.EventHandler(this.linearGraphTypeToolStripMenuItem_Click);
            // 
            // logarithmicGraphTypeToolStripMenuItem
            // 
            this.logarithmicGraphTypeToolStripMenuItem.CheckOnClick = true;
            this.logarithmicGraphTypeToolStripMenuItem.Name = "logarithmicGraphTypeToolStripMenuItem";
            this.logarithmicGraphTypeToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.logarithmicGraphTypeToolStripMenuItem.Text = "Logarithmic Graph Type";
            this.logarithmicGraphTypeToolStripMenuItem.Click += new System.EventHandler(this.logarithmicGraphTypeToolStripMenuItem_Click);
            // 
            // grapthColorsToolStripMenuItem
            // 
            this.grapthColorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphBackgroundColorsToolStripMenuItem,
            this.graphGridColorToolStripMenuItem,
            this.graphAxisLabelColorsToolStripMenuItem,
            this.graphSelectionColorToolStripMenuItem,
            this.seriesColorsToolStripMenuItem});
            this.grapthColorsToolStripMenuItem.Name = "grapthColorsToolStripMenuItem";
            this.grapthColorsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.grapthColorsToolStripMenuItem.Text = "Graph Colors";
            // 
            // graphBackgroundColorsToolStripMenuItem
            // 
            this.graphBackgroundColorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphGradientColor1ToolStripMenuItem,
            this.graphGradientColor2ToolStripMenuItem,
            this.swapGraphGradientColorsToolStripMenuItem,
            this.graphGradientDirectionToolStripMenuItem});
            this.graphBackgroundColorsToolStripMenuItem.Name = "graphBackgroundColorsToolStripMenuItem";
            this.graphBackgroundColorsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.graphBackgroundColorsToolStripMenuItem.Text = "Background Colors";
            // 
            // graphGradientColor1ToolStripMenuItem
            // 
            this.graphGradientColor1ToolStripMenuItem.Name = "graphGradientColor1ToolStripMenuItem";
            this.graphGradientColor1ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.graphGradientColor1ToolStripMenuItem.Text = "Graph Gradient Color 1";
            this.graphGradientColor1ToolStripMenuItem.Click += new System.EventHandler(this.graphGradientColor1ToolStripMenuItem_Click);
            // 
            // graphGradientColor2ToolStripMenuItem
            // 
            this.graphGradientColor2ToolStripMenuItem.Name = "graphGradientColor2ToolStripMenuItem";
            this.graphGradientColor2ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.graphGradientColor2ToolStripMenuItem.Text = "Graph Gradient Color 2";
            this.graphGradientColor2ToolStripMenuItem.Click += new System.EventHandler(this.graphGradientColor2ToolStripMenuItem_Click);
            // 
            // swapGraphGradientColorsToolStripMenuItem
            // 
            this.swapGraphGradientColorsToolStripMenuItem.Name = "swapGraphGradientColorsToolStripMenuItem";
            this.swapGraphGradientColorsToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.swapGraphGradientColorsToolStripMenuItem.Text = "Swap Graph Gradient Colors";
            this.swapGraphGradientColorsToolStripMenuItem.Click += new System.EventHandler(this.swapGraphGradientColorsToolStripMenuItem_Click);
            // 
            // graphGradientDirectionToolStripMenuItem
            // 
            this.graphGradientDirectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphGradientDirectionHorizontalToolStripMenuItem,
            this.graphGradientDirectionVerticalToolStripMenuItem,
            this.graphGradientDirectionForwardDiagonalToolStripMenuItem,
            this.graphGradientDirectionBackwardDiagonalToolStripMenuItem});
            this.graphGradientDirectionToolStripMenuItem.Name = "graphGradientDirectionToolStripMenuItem";
            this.graphGradientDirectionToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.graphGradientDirectionToolStripMenuItem.Text = "Graph Gradient Direction";
            // 
            // graphGradientDirectionHorizontalToolStripMenuItem
            // 
            this.graphGradientDirectionHorizontalToolStripMenuItem.Name = "graphGradientDirectionHorizontalToolStripMenuItem";
            this.graphGradientDirectionHorizontalToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.graphGradientDirectionHorizontalToolStripMenuItem.Text = "Graph Gradient Direction Horizontal";
            this.graphGradientDirectionHorizontalToolStripMenuItem.Click += new System.EventHandler(this.graphGradientDirectionHorizontalToolStripMenuItem_Click);
            // 
            // graphGradientDirectionVerticalToolStripMenuItem
            // 
            this.graphGradientDirectionVerticalToolStripMenuItem.Name = "graphGradientDirectionVerticalToolStripMenuItem";
            this.graphGradientDirectionVerticalToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.graphGradientDirectionVerticalToolStripMenuItem.Text = "Graph Gradient Direction Vertical";
            this.graphGradientDirectionVerticalToolStripMenuItem.Click += new System.EventHandler(this.graphGradientDirectionVerticalToolStripMenuItem_Click);
            // 
            // graphGradientDirectionForwardDiagonalToolStripMenuItem
            // 
            this.graphGradientDirectionForwardDiagonalToolStripMenuItem.Name = "graphGradientDirectionForwardDiagonalToolStripMenuItem";
            this.graphGradientDirectionForwardDiagonalToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.graphGradientDirectionForwardDiagonalToolStripMenuItem.Text = "Graph Gradient Direction Forward Diagonal";
            this.graphGradientDirectionForwardDiagonalToolStripMenuItem.Click += new System.EventHandler(this.graphGradientDirectionForwardDiagonalToolStripMenuItem_Click);
            // 
            // graphGradientDirectionBackwardDiagonalToolStripMenuItem
            // 
            this.graphGradientDirectionBackwardDiagonalToolStripMenuItem.Name = "graphGradientDirectionBackwardDiagonalToolStripMenuItem";
            this.graphGradientDirectionBackwardDiagonalToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.graphGradientDirectionBackwardDiagonalToolStripMenuItem.Text = "Graph Gradient Direction Backward Diagonal";
            this.graphGradientDirectionBackwardDiagonalToolStripMenuItem.Click += new System.EventHandler(this.graphGradientDirectionBackwardDiagonalToolStripMenuItem_Click);
            // 
            // graphGridColorToolStripMenuItem
            // 
            this.graphGridColorToolStripMenuItem.Name = "graphGridColorToolStripMenuItem";
            this.graphGridColorToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.graphGridColorToolStripMenuItem.Text = "Grid Color";
            this.graphGridColorToolStripMenuItem.Click += new System.EventHandler(this.graphGridColorToolStripMenuItem_Click);
            // 
            // graphAxisLabelColorsToolStripMenuItem
            // 
            this.graphAxisLabelColorsToolStripMenuItem.Name = "graphAxisLabelColorsToolStripMenuItem";
            this.graphAxisLabelColorsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.graphAxisLabelColorsToolStripMenuItem.Text = "Axis Label Colors";
            this.graphAxisLabelColorsToolStripMenuItem.Click += new System.EventHandler(this.graphAxisLabelColorsToolStripMenuItem_Click);
            // 
            // graphSelectionColorToolStripMenuItem
            // 
            this.graphSelectionColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphSelectionBarColorToolStripMenuItem,
            this.graphClosestClickedValueColorToolStripMenuItem});
            this.graphSelectionColorToolStripMenuItem.Name = "graphSelectionColorToolStripMenuItem";
            this.graphSelectionColorToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.graphSelectionColorToolStripMenuItem.Text = "Selection Colors";
            // 
            // graphSelectionBarColorToolStripMenuItem
            // 
            this.graphSelectionBarColorToolStripMenuItem.Name = "graphSelectionBarColorToolStripMenuItem";
            this.graphSelectionBarColorToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphSelectionBarColorToolStripMenuItem.Text = "Selection Bar Color";
            this.graphSelectionBarColorToolStripMenuItem.Click += new System.EventHandler(this.graphSelectionBarColorToolStripMenuItem_Click);
            // 
            // graphClosestClickedValueColorToolStripMenuItem
            // 
            this.graphClosestClickedValueColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphClosestClickedColorSameAsSeriesToolStripMenuItem,
            this.graphClosestClickedColorInvertedColorToolStripMenuItem,
            this.graphClosestClickedColorCustomColorToolStripMenuItem});
            this.graphClosestClickedValueColorToolStripMenuItem.Name = "graphClosestClickedValueColorToolStripMenuItem";
            this.graphClosestClickedValueColorToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphClosestClickedValueColorToolStripMenuItem.Text = "Closest Clicked Value Color";
            // 
            // graphClosestClickedColorSameAsSeriesToolStripMenuItem
            // 
            this.graphClosestClickedColorSameAsSeriesToolStripMenuItem.Name = "graphClosestClickedColorSameAsSeriesToolStripMenuItem";
            this.graphClosestClickedColorSameAsSeriesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.graphClosestClickedColorSameAsSeriesToolStripMenuItem.Text = "Same as Series";
            this.graphClosestClickedColorSameAsSeriesToolStripMenuItem.Click += new System.EventHandler(this.graphClosestClickedColorSameAsSeriesToolStripMenuItem_Click);
            // 
            // graphClosestClickedColorInvertedColorToolStripMenuItem
            // 
            this.graphClosestClickedColorInvertedColorToolStripMenuItem.Name = "graphClosestClickedColorInvertedColorToolStripMenuItem";
            this.graphClosestClickedColorInvertedColorToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.graphClosestClickedColorInvertedColorToolStripMenuItem.Text = "Inverted Color";
            this.graphClosestClickedColorInvertedColorToolStripMenuItem.Click += new System.EventHandler(this.graphClosestClickedColorInvertedColorToolStripMenuItem_Click);
            // 
            // graphClosestClickedColorCustomColorToolStripMenuItem
            // 
            this.graphClosestClickedColorCustomColorToolStripMenuItem.Name = "graphClosestClickedColorCustomColorToolStripMenuItem";
            this.graphClosestClickedColorCustomColorToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.graphClosestClickedColorCustomColorToolStripMenuItem.Text = "Custom Color";
            this.graphClosestClickedColorCustomColorToolStripMenuItem.Click += new System.EventHandler(this.graphClosestClickedColorCustomColorToolStripMenuItem_Click);
            // 
            // graphVisibilityToolStripMenuItem
            // 
            this.graphVisibilityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphHeaderVisibleToolStripMenuItem,
            this.legendVisibleToolStripMenuItem,
            this.graphHorisonalGridLinesVisibleToolStripMenuItem,
            this.graphVerticalGridLinesVisibleToolStripMenuItem,
            this.graphSelectionbarVisibleToolStripMenuItem,
            this.graphHighlightClickedSeriesToolStripMenuItem,
            this.graphFillAreaBelowSeriesToolStripMenuItem});
            this.graphVisibilityToolStripMenuItem.Name = "graphVisibilityToolStripMenuItem";
            this.graphVisibilityToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.graphVisibilityToolStripMenuItem.Text = "Visibility";
            // 
            // graphHeaderVisibleToolStripMenuItem
            // 
            this.graphHeaderVisibleToolStripMenuItem.CheckOnClick = true;
            this.graphHeaderVisibleToolStripMenuItem.Name = "graphHeaderVisibleToolStripMenuItem";
            this.graphHeaderVisibleToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphHeaderVisibleToolStripMenuItem.Text = "Header Visible";
            this.graphHeaderVisibleToolStripMenuItem.Click += new System.EventHandler(this.graphHeaderVisibleToolStripMenuItem_Click);
            // 
            // legendVisibleToolStripMenuItem
            // 
            this.legendVisibleToolStripMenuItem.CheckOnClick = true;
            this.legendVisibleToolStripMenuItem.Name = "legendVisibleToolStripMenuItem";
            this.legendVisibleToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.legendVisibleToolStripMenuItem.Text = "Legend Visible";
            this.legendVisibleToolStripMenuItem.Click += new System.EventHandler(this.legendVisibleToolStripMenuItem_Click);
            // 
            // graphHorisonalGridLinesVisibleToolStripMenuItem
            // 
            this.graphHorisonalGridLinesVisibleToolStripMenuItem.CheckOnClick = true;
            this.graphHorisonalGridLinesVisibleToolStripMenuItem.Name = "graphHorisonalGridLinesVisibleToolStripMenuItem";
            this.graphHorisonalGridLinesVisibleToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphHorisonalGridLinesVisibleToolStripMenuItem.Text = "Horisonal Grid Lines Visible";
            this.graphHorisonalGridLinesVisibleToolStripMenuItem.Click += new System.EventHandler(this.graphHorisonalGridLinesVisibleToolStripMenuItem_Click);
            // 
            // graphVerticalGridLinesVisibleToolStripMenuItem
            // 
            this.graphVerticalGridLinesVisibleToolStripMenuItem.CheckOnClick = true;
            this.graphVerticalGridLinesVisibleToolStripMenuItem.Name = "graphVerticalGridLinesVisibleToolStripMenuItem";
            this.graphVerticalGridLinesVisibleToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphVerticalGridLinesVisibleToolStripMenuItem.Text = "Vertical Grid Lines Visible";
            this.graphVerticalGridLinesVisibleToolStripMenuItem.Click += new System.EventHandler(this.graphVerticalGridLinesVisibleToolStripMenuItem_Click);
            // 
            // graphSelectionbarVisibleToolStripMenuItem
            // 
            this.graphSelectionbarVisibleToolStripMenuItem.CheckOnClick = true;
            this.graphSelectionbarVisibleToolStripMenuItem.Name = "graphSelectionbarVisibleToolStripMenuItem";
            this.graphSelectionbarVisibleToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphSelectionbarVisibleToolStripMenuItem.Text = "Selectionbar Visible";
            this.graphSelectionbarVisibleToolStripMenuItem.Click += new System.EventHandler(this.graphSelectionbarVisibleToolStripMenuItem_Click);
            // 
            // graphHighlightClickedSeriesToolStripMenuItem
            // 
            this.graphHighlightClickedSeriesToolStripMenuItem.CheckOnClick = true;
            this.graphHighlightClickedSeriesToolStripMenuItem.Name = "graphHighlightClickedSeriesToolStripMenuItem";
            this.graphHighlightClickedSeriesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphHighlightClickedSeriesToolStripMenuItem.Text = "Highlight Clicked Series";
            this.graphHighlightClickedSeriesToolStripMenuItem.Click += new System.EventHandler(this.graphHighlightClickedSeriesToolStripMenuItem_Click);
            // 
            // graphFillAreaBelowSeriesToolStripMenuItem
            // 
            this.graphFillAreaBelowSeriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphFillAreaBelowSeriesEnabledToolStripMenuItem,
            this.graphFillAreaAlpha16ToolStripMenuItem,
            this.graphFillAreaAlpha32ToolStripMenuItem,
            this.graphFillAreaAlpha48ToolStripMenuItem,
            this.graphFillAreaAlpha64ToolStripMenuItem,
            this.graphFillAreaAlpha128ToolStripMenuItem,
            this.graphFillAreaAlpha192ToolStripMenuItem});
            this.graphFillAreaBelowSeriesToolStripMenuItem.Name = "graphFillAreaBelowSeriesToolStripMenuItem";
            this.graphFillAreaBelowSeriesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphFillAreaBelowSeriesToolStripMenuItem.Text = "Fill Area Below Series";
            // 
            // graphFillAreaBelowSeriesEnabledToolStripMenuItem
            // 
            this.graphFillAreaBelowSeriesEnabledToolStripMenuItem.CheckOnClick = true;
            this.graphFillAreaBelowSeriesEnabledToolStripMenuItem.Name = "graphFillAreaBelowSeriesEnabledToolStripMenuItem";
            this.graphFillAreaBelowSeriesEnabledToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.graphFillAreaBelowSeriesEnabledToolStripMenuItem.Text = "Graph Fill Area Below Series Enabled";
            this.graphFillAreaBelowSeriesEnabledToolStripMenuItem.Click += new System.EventHandler(this.graphFillAreaBelowSeriesEnabledToolStripMenuItem_Click);
            // 
            // graphFillAreaAlpha16ToolStripMenuItem
            // 
            this.graphFillAreaAlpha16ToolStripMenuItem.Name = "graphFillAreaAlpha16ToolStripMenuItem";
            this.graphFillAreaAlpha16ToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.graphFillAreaAlpha16ToolStripMenuItem.Text = "Graph Fill Area Alpha 16";
            this.graphFillAreaAlpha16ToolStripMenuItem.Click += new System.EventHandler(this.graphFillAreaAlpha16ToolStripMenuItem_Click);
            // 
            // graphFillAreaAlpha32ToolStripMenuItem
            // 
            this.graphFillAreaAlpha32ToolStripMenuItem.Name = "graphFillAreaAlpha32ToolStripMenuItem";
            this.graphFillAreaAlpha32ToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.graphFillAreaAlpha32ToolStripMenuItem.Text = "Graph Fill Area Alpha 32";
            this.graphFillAreaAlpha32ToolStripMenuItem.Click += new System.EventHandler(this.graphFillAreaAlpha32ToolStripMenuItem_Click);
            // 
            // graphFillAreaAlpha48ToolStripMenuItem
            // 
            this.graphFillAreaAlpha48ToolStripMenuItem.Name = "graphFillAreaAlpha48ToolStripMenuItem";
            this.graphFillAreaAlpha48ToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.graphFillAreaAlpha48ToolStripMenuItem.Text = "Graph Fill Area Alpha 48";
            this.graphFillAreaAlpha48ToolStripMenuItem.Click += new System.EventHandler(this.graphFillAreaAlpha48ToolStripMenuItem_Click);
            // 
            // graphFillAreaAlpha64ToolStripMenuItem
            // 
            this.graphFillAreaAlpha64ToolStripMenuItem.Name = "graphFillAreaAlpha64ToolStripMenuItem";
            this.graphFillAreaAlpha64ToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.graphFillAreaAlpha64ToolStripMenuItem.Text = "Graph Fill Area Alpha 64";
            this.graphFillAreaAlpha64ToolStripMenuItem.Click += new System.EventHandler(this.graphFillAreaAlpha64ToolStripMenuItem_Click);
            // 
            // graphFillAreaAlpha128ToolStripMenuItem
            // 
            this.graphFillAreaAlpha128ToolStripMenuItem.Name = "graphFillAreaAlpha128ToolStripMenuItem";
            this.graphFillAreaAlpha128ToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.graphFillAreaAlpha128ToolStripMenuItem.Text = "Graph Fill Area Alpha 128";
            this.graphFillAreaAlpha128ToolStripMenuItem.Click += new System.EventHandler(this.graphFillAreaAlpha128ToolStripMenuItem_Click);
            // 
            // graphFillAreaAlpha192ToolStripMenuItem
            // 
            this.graphFillAreaAlpha192ToolStripMenuItem.Name = "graphFillAreaAlpha192ToolStripMenuItem";
            this.graphFillAreaAlpha192ToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.graphFillAreaAlpha192ToolStripMenuItem.Text = "Graph Fill Area Alpha 192";
            this.graphFillAreaAlpha192ToolStripMenuItem.Click += new System.EventHandler(this.graphFillAreaAlpha192ToolStripMenuItem_Click);
            // 
            // exportGraphToolStripMenuItem
            // 
            this.exportGraphToolStripMenuItem.Name = "exportGraphToolStripMenuItem";
            this.exportGraphToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportGraphToolStripMenuItem.Text = "Export Graph";
            this.exportGraphToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripButton_Click);
            // 
            // seriesColorsToolStripMenuItem
            // 
            this.seriesColorsToolStripMenuItem.Name = "seriesColorsToolStripMenuItem";
            this.seriesColorsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.seriesColorsToolStripMenuItem.Text = "Series Colors";
            this.seriesColorsToolStripMenuItem.Click += new System.EventHandler(this.seriesColorsToolStripMenuItem_Click);
            // 
            // CollectorGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 458);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CollectorGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collector Graph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CollectorGraph_FormClosing);
            this.Load += new System.EventHandler(this.CollectorGraph_Load);
            this.Shown += new System.EventHandler(this.CollectorGraph_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.collectorListContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLastXEntries)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudinitialMax)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.graphContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton showFiltersToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private HenIT.Controls.DateTimeChooser toDateTimeChooser;
        private System.Windows.Forms.CheckBox chkAutoToTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private HenIT.Controls.DateTimeChooser fromDateTimeChooser;
        private System.Windows.Forms.CheckBox chkAutoFromTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudLastXEntries;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown nudinitialMax;
        private System.Windows.Forms.CheckBox chkAutoMaxValue;
        private System.Windows.Forms.Label label4;
        private Controls.TextBoxEx txtTextFilter;
        private System.Windows.Forms.Label label7;
        private ListViewEx lvwCollectorStates;
        private System.Windows.Forms.ColumnHeader PathColumnHeader;
        private System.Windows.Forms.ColumnHeader collectorValueColumnHeader;
        private HenIT.Windows.Controls.Graphing.TimeGraphControl collectorTimeGraph;
        private System.Windows.Forms.ToolStripButton exportToolStripButton;
        private System.Windows.Forms.ImageList imagesCollectorTree;
        private System.Windows.Forms.ContextMenuStrip collectorListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCollectorToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip graphContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem graphTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearGraphTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logarithmicGraphTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grapthColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphBackgroundColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGradientColor1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGradientColor2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swapGraphGradientColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGradientDirectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGradientDirectionHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGradientDirectionVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGradientDirectionForwardDiagonalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGradientDirectionBackwardDiagonalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGridColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphAxisLabelColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphSelectionColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphSelectionBarColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphClosestClickedValueColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphClosestClickedColorSameAsSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphClosestClickedColorInvertedColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphClosestClickedColorCustomColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphVisibilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphHeaderVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legendVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphHorisonalGridLinesVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphVerticalGridLinesVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphSelectionbarVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphHighlightClickedSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaBelowSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaBelowSeriesEnabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaAlpha16ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaAlpha32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaAlpha48ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaAlpha64ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaAlpha128ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaAlpha192ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCollectorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblResetText;
        private System.Windows.Forms.ToolStripMenuItem seriesColorsToolStripMenuItem;
    }
}