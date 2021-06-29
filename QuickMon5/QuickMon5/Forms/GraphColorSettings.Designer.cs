namespace QuickMon
{
    partial class GraphColorSettings
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Item1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Item2");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Item3");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Item4");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Item5");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphColorSettings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdImportSeriesColors = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdExportSeriesColors = new System.Windows.Forms.Button();
            this.cmdOKSelect = new System.Windows.Forms.Button();
            this.lvwSeriesColors = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colorColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdMoveUp = new System.Windows.Forms.Button();
            this.cmdMoveDown = new System.Windows.Forms.Button();
            this.cmdChange = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.cmdResetSeriesColors = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lvwGraphComponentColors = new System.Windows.Forms.ListView();
            this.nameColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colorColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdChange2 = new System.Windows.Forms.Button();
            this.cmdSwapBackgroundColors = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optGraphTypeLogarithmic = new System.Windows.Forms.RadioButton();
            this.optGraphTypeStandard = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optBackgroundGradientDirectionBackwardDiagonal = new System.Windows.Forms.RadioButton();
            this.optBackgroundGradientDirectionForwardDiagonal = new System.Windows.Forms.RadioButton();
            this.optBackgroundGradientDirectionVertical = new System.Windows.Forms.RadioButton();
            this.optBackgroundGradientDirectionHorizontal = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblClosestClickedValueCustomColors = new System.Windows.Forms.Label();
            this.optClosestClickedValueColorCustomColor = new System.Windows.Forms.RadioButton();
            this.optClosestClickedValueColorInvertedColor = new System.Windows.Forms.RadioButton();
            this.optClosestClickedValueColorSameAsSeries = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.chkHeaderVisible = new System.Windows.Forms.CheckBox();
            this.chkLegendVisible = new System.Windows.Forms.CheckBox();
            this.chkHorisontalGridLinesVisible = new System.Windows.Forms.CheckBox();
            this.chkVerticalGridLinesVisible = new System.Windows.Forms.CheckBox();
            this.chkSelectionBarVisible = new System.Windows.Forms.CheckBox();
            this.chkHighlighClickedValueVisible = new System.Windows.Forms.CheckBox();
            this.chkEnableFillAreaBelowSeries = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.optGraphFillAreaBelowSeriesAlpha192 = new System.Windows.Forms.RadioButton();
            this.optGraphFillAreaBelowSeriesAlpha128 = new System.Windows.Forms.RadioButton();
            this.optGraphFillAreaBelowSeriesAlpha64 = new System.Windows.Forms.RadioButton();
            this.optGraphFillAreaBelowSeriesAlpha48 = new System.Windows.Forms.RadioButton();
            this.optGraphFillAreaBelowSeriesAlpha32 = new System.Windows.Forms.RadioButton();
            this.optGraphFillAreaBelowSeriesAlpha16 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdImportSeriesColors);
            this.panel1.Controls.Add(this.cmdClose);
            this.panel1.Controls.Add(this.cmdExportSeriesColors);
            this.panel1.Controls.Add(this.cmdOKSelect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 381);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 40);
            this.panel1.TabIndex = 24;
            // 
            // cmdImportSeriesColors
            // 
            this.cmdImportSeriesColors.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdImportSeriesColors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdImportSeriesColors.Image = global::QuickMon.Properties.Resources.page_white_get;
            this.cmdImportSeriesColors.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImportSeriesColors.Location = new System.Drawing.Point(88, 7);
            this.cmdImportSeriesColors.Name = "cmdImportSeriesColors";
            this.cmdImportSeriesColors.Size = new System.Drawing.Size(71, 23);
            this.cmdImportSeriesColors.TabIndex = 1;
            this.cmdImportSeriesColors.Text = "Import";
            this.cmdImportSeriesColors.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdImportSeriesColors.UseVisualStyleBackColor = true;
            this.cmdImportSeriesColors.Click += new System.EventHandler(this.cmdImportSeriesColors_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Location = new System.Drawing.Point(556, 7);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "Cancel";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // cmdExportSeriesColors
            // 
            this.cmdExportSeriesColors.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdExportSeriesColors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExportSeriesColors.Image = global::QuickMon.Properties.Resources.save16x16;
            this.cmdExportSeriesColors.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExportSeriesColors.Location = new System.Drawing.Point(12, 7);
            this.cmdExportSeriesColors.Name = "cmdExportSeriesColors";
            this.cmdExportSeriesColors.Size = new System.Drawing.Size(70, 23);
            this.cmdExportSeriesColors.TabIndex = 0;
            this.cmdExportSeriesColors.Text = "Export";
            this.cmdExportSeriesColors.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExportSeriesColors.UseVisualStyleBackColor = true;
            this.cmdExportSeriesColors.Click += new System.EventHandler(this.cmdExportSeriesColors_Click);
            // 
            // cmdOKSelect
            // 
            this.cmdOKSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOKSelect.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdOKSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOKSelect.Location = new System.Drawing.Point(475, 7);
            this.cmdOKSelect.Name = "cmdOKSelect";
            this.cmdOKSelect.Size = new System.Drawing.Size(75, 23);
            this.cmdOKSelect.TabIndex = 2;
            this.cmdOKSelect.Text = "OK";
            this.cmdOKSelect.UseVisualStyleBackColor = true;
            this.cmdOKSelect.Click += new System.EventHandler(this.cmdOKSelect_Click);
            // 
            // lvwSeriesColors
            // 
            this.lvwSeriesColors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwSeriesColors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.colorColumnHeader});
            this.lvwSeriesColors.HideSelection = false;
            this.lvwSeriesColors.Location = new System.Drawing.Point(8, 87);
            this.lvwSeriesColors.Name = "lvwSeriesColors";
            this.lvwSeriesColors.Size = new System.Drawing.Size(181, 287);
            this.lvwSeriesColors.TabIndex = 2;
            this.lvwSeriesColors.UseCompatibleStateImageBehavior = false;
            this.lvwSeriesColors.View = System.Windows.Forms.View.Details;
            this.lvwSeriesColors.SelectedIndexChanged += new System.EventHandler(this.lvwSeriesColors_SelectedIndexChanged);
            this.lvwSeriesColors.DoubleClick += new System.EventHandler(this.cmdChange_Click);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 85;
            // 
            // colorColumnHeader
            // 
            this.colorColumnHeader.Text = "Color";
            this.colorColumnHeader.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Series colors";
            // 
            // cmdAdd
            // 
            this.cmdAdd.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAdd.Image = global::QuickMon.Properties.Resources.Plus16x16;
            this.cmdAdd.Location = new System.Drawing.Point(50, 63);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(36, 23);
            this.cmdAdd.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cmdAdd, "Add new series color");
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Enabled = false;
            this.cmdRemove.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRemove.Image = global::QuickMon.Properties.Resources.stop16x16;
            this.cmdRemove.Location = new System.Drawing.Point(92, 63);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(36, 23);
            this.cmdRemove.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cmdRemove, "Delete selected series color");
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdMoveUp
            // 
            this.cmdMoveUp.Enabled = false;
            this.cmdMoveUp.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMoveUp.Image = global::QuickMon.Properties.Resources.Up16x16;
            this.cmdMoveUp.Location = new System.Drawing.Point(191, 191);
            this.cmdMoveUp.Name = "cmdMoveUp";
            this.cmdMoveUp.Size = new System.Drawing.Size(27, 25);
            this.cmdMoveUp.TabIndex = 7;
            this.toolTip1.SetToolTip(this.cmdMoveUp, "Move selected series color up");
            this.cmdMoveUp.UseVisualStyleBackColor = true;
            this.cmdMoveUp.Click += new System.EventHandler(this.cmdMoveUp_Click);
            // 
            // cmdMoveDown
            // 
            this.cmdMoveDown.Enabled = false;
            this.cmdMoveDown.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMoveDown.Image = global::QuickMon.Properties.Resources.Down16x16;
            this.cmdMoveDown.Location = new System.Drawing.Point(191, 220);
            this.cmdMoveDown.Name = "cmdMoveDown";
            this.cmdMoveDown.Size = new System.Drawing.Size(27, 25);
            this.cmdMoveDown.TabIndex = 8;
            this.toolTip1.SetToolTip(this.cmdMoveDown, "Move selected series color down");
            this.cmdMoveDown.UseVisualStyleBackColor = true;
            this.cmdMoveDown.Click += new System.EventHandler(this.cmdMoveDown_Click);
            // 
            // cmdChange
            // 
            this.cmdChange.Enabled = false;
            this.cmdChange.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdChange.Image = global::QuickMon.Properties.Resources.tools16x16;
            this.cmdChange.Location = new System.Drawing.Point(8, 63);
            this.cmdChange.Name = "cmdChange";
            this.cmdChange.Size = new System.Drawing.Size(36, 23);
            this.cmdChange.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cmdChange, "Change selected series color");
            this.cmdChange.UseVisualStyleBackColor = true;
            this.cmdChange.Click += new System.EventHandler(this.cmdChange_Click);
            // 
            // cmdResetSeriesColors
            // 
            this.cmdResetSeriesColors.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdResetSeriesColors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdResetSeriesColors.Image = global::QuickMon.Properties.Resources.lightning;
            this.cmdResetSeriesColors.Location = new System.Drawing.Point(134, 63);
            this.cmdResetSeriesColors.Name = "cmdResetSeriesColors";
            this.cmdResetSeriesColors.Size = new System.Drawing.Size(36, 23);
            this.cmdResetSeriesColors.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cmdResetSeriesColors, "Reset series colors to default");
            this.cmdResetSeriesColors.UseVisualStyleBackColor = true;
            this.cmdResetSeriesColors.Click += new System.EventHandler(this.cmdResetSeriesColors_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Graph component colors";
            // 
            // lvwGraphComponentColors
            // 
            this.lvwGraphComponentColors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader1,
            this.colorColumnHeader1});
            this.lvwGraphComponentColors.HideSelection = false;
            this.lvwGraphComponentColors.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lvwGraphComponentColors.Location = new System.Drawing.Point(224, 87);
            this.lvwGraphComponentColors.Name = "lvwGraphComponentColors";
            this.lvwGraphComponentColors.Size = new System.Drawing.Size(234, 129);
            this.lvwGraphComponentColors.TabIndex = 10;
            this.lvwGraphComponentColors.UseCompatibleStateImageBehavior = false;
            this.lvwGraphComponentColors.View = System.Windows.Forms.View.Details;
            this.lvwGraphComponentColors.SelectedIndexChanged += new System.EventHandler(this.lvwGraphComponentColors_SelectedIndexChanged);
            this.lvwGraphComponentColors.DoubleClick += new System.EventHandler(this.cmdChange2_Click);
            // 
            // nameColumnHeader1
            // 
            this.nameColumnHeader1.Text = "Name";
            this.nameColumnHeader1.Width = 152;
            // 
            // colorColumnHeader1
            // 
            this.colorColumnHeader1.Text = "Color";
            // 
            // cmdChange2
            // 
            this.cmdChange2.Enabled = false;
            this.cmdChange2.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdChange2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdChange2.Image = global::QuickMon.Properties.Resources.tools16x16;
            this.cmdChange2.Location = new System.Drawing.Point(224, 63);
            this.cmdChange2.Name = "cmdChange2";
            this.cmdChange2.Size = new System.Drawing.Size(36, 23);
            this.cmdChange2.TabIndex = 11;
            this.toolTip1.SetToolTip(this.cmdChange2, "Edit graph component colors");
            this.cmdChange2.UseVisualStyleBackColor = true;
            this.cmdChange2.Click += new System.EventHandler(this.cmdChange2_Click);
            // 
            // cmdSwapBackgroundColors
            // 
            this.cmdSwapBackgroundColors.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdSwapBackgroundColors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSwapBackgroundColors.Image = global::QuickMon.Properties.Resources.UpDown;
            this.cmdSwapBackgroundColors.Location = new System.Drawing.Point(266, 63);
            this.cmdSwapBackgroundColors.Name = "cmdSwapBackgroundColors";
            this.cmdSwapBackgroundColors.Size = new System.Drawing.Size(36, 23);
            this.cmdSwapBackgroundColors.TabIndex = 12;
            this.toolTip1.SetToolTip(this.cmdSwapBackgroundColors, "Swap background colors");
            this.cmdSwapBackgroundColors.UseVisualStyleBackColor = true;
            this.cmdSwapBackgroundColors.Click += new System.EventHandler(this.cmdSwapBackgroundColors_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optGraphTypeLogarithmic);
            this.groupBox1.Controls.Add(this.optGraphTypeStandard);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 37);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graph type";
            // 
            // optGraphTypeLogarithmic
            // 
            this.optGraphTypeLogarithmic.AutoSize = true;
            this.optGraphTypeLogarithmic.Checked = true;
            this.optGraphTypeLogarithmic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optGraphTypeLogarithmic.Location = new System.Drawing.Point(90, 14);
            this.optGraphTypeLogarithmic.Name = "optGraphTypeLogarithmic";
            this.optGraphTypeLogarithmic.Size = new System.Drawing.Size(78, 17);
            this.optGraphTypeLogarithmic.TabIndex = 1;
            this.optGraphTypeLogarithmic.TabStop = true;
            this.optGraphTypeLogarithmic.Text = "Logarithmic";
            this.optGraphTypeLogarithmic.UseVisualStyleBackColor = true;
            // 
            // optGraphTypeStandard
            // 
            this.optGraphTypeStandard.AutoSize = true;
            this.optGraphTypeStandard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optGraphTypeStandard.Location = new System.Drawing.Point(16, 14);
            this.optGraphTypeStandard.Name = "optGraphTypeStandard";
            this.optGraphTypeStandard.Size = new System.Drawing.Size(67, 17);
            this.optGraphTypeStandard.TabIndex = 0;
            this.optGraphTypeStandard.Text = "Standard";
            this.optGraphTypeStandard.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optBackgroundGradientDirectionBackwardDiagonal);
            this.groupBox2.Controls.Add(this.optBackgroundGradientDirectionForwardDiagonal);
            this.groupBox2.Controls.Add(this.optBackgroundGradientDirectionVertical);
            this.groupBox2.Controls.Add(this.optBackgroundGradientDirectionHorizontal);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(224, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 70);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Background gradient direction";
            // 
            // optBackgroundGradientDirectionBackwardDiagonal
            // 
            this.optBackgroundGradientDirectionBackwardDiagonal.AutoSize = true;
            this.optBackgroundGradientDirectionBackwardDiagonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optBackgroundGradientDirectionBackwardDiagonal.Location = new System.Drawing.Point(88, 42);
            this.optBackgroundGradientDirectionBackwardDiagonal.Name = "optBackgroundGradientDirectionBackwardDiagonal";
            this.optBackgroundGradientDirectionBackwardDiagonal.Size = new System.Drawing.Size(117, 17);
            this.optBackgroundGradientDirectionBackwardDiagonal.TabIndex = 3;
            this.optBackgroundGradientDirectionBackwardDiagonal.TabStop = true;
            this.optBackgroundGradientDirectionBackwardDiagonal.Text = "Backward Diagonal";
            this.optBackgroundGradientDirectionBackwardDiagonal.UseVisualStyleBackColor = true;
            // 
            // optBackgroundGradientDirectionForwardDiagonal
            // 
            this.optBackgroundGradientDirectionForwardDiagonal.AutoSize = true;
            this.optBackgroundGradientDirectionForwardDiagonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optBackgroundGradientDirectionForwardDiagonal.Location = new System.Drawing.Point(88, 19);
            this.optBackgroundGradientDirectionForwardDiagonal.Name = "optBackgroundGradientDirectionForwardDiagonal";
            this.optBackgroundGradientDirectionForwardDiagonal.Size = new System.Drawing.Size(107, 17);
            this.optBackgroundGradientDirectionForwardDiagonal.TabIndex = 1;
            this.optBackgroundGradientDirectionForwardDiagonal.TabStop = true;
            this.optBackgroundGradientDirectionForwardDiagonal.Text = "Forward Diagonal";
            this.optBackgroundGradientDirectionForwardDiagonal.UseVisualStyleBackColor = true;
            // 
            // optBackgroundGradientDirectionVertical
            // 
            this.optBackgroundGradientDirectionVertical.AutoSize = true;
            this.optBackgroundGradientDirectionVertical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optBackgroundGradientDirectionVertical.Location = new System.Drawing.Point(10, 42);
            this.optBackgroundGradientDirectionVertical.Name = "optBackgroundGradientDirectionVertical";
            this.optBackgroundGradientDirectionVertical.Size = new System.Drawing.Size(59, 17);
            this.optBackgroundGradientDirectionVertical.TabIndex = 2;
            this.optBackgroundGradientDirectionVertical.TabStop = true;
            this.optBackgroundGradientDirectionVertical.Text = "Vertical";
            this.optBackgroundGradientDirectionVertical.UseVisualStyleBackColor = true;
            // 
            // optBackgroundGradientDirectionHorizontal
            // 
            this.optBackgroundGradientDirectionHorizontal.AutoSize = true;
            this.optBackgroundGradientDirectionHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optBackgroundGradientDirectionHorizontal.Location = new System.Drawing.Point(10, 19);
            this.optBackgroundGradientDirectionHorizontal.Name = "optBackgroundGradientDirectionHorizontal";
            this.optBackgroundGradientDirectionHorizontal.Size = new System.Drawing.Size(71, 17);
            this.optBackgroundGradientDirectionHorizontal.TabIndex = 0;
            this.optBackgroundGradientDirectionHorizontal.TabStop = true;
            this.optBackgroundGradientDirectionHorizontal.Text = "Horizontal";
            this.optBackgroundGradientDirectionHorizontal.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblClosestClickedValueCustomColors);
            this.groupBox3.Controls.Add(this.optClosestClickedValueColorCustomColor);
            this.groupBox3.Controls.Add(this.optClosestClickedValueColorInvertedColor);
            this.groupBox3.Controls.Add(this.optClosestClickedValueColorSameAsSeries);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(224, 298);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(234, 67);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Closest clicked value color";
            // 
            // lblClosestClickedValueCustomColors
            // 
            this.lblClosestClickedValueCustomColors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClosestClickedValueCustomColors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblClosestClickedValueCustomColors.Location = new System.Drawing.Point(101, 42);
            this.lblClosestClickedValueCustomColors.Name = "lblClosestClickedValueCustomColors";
            this.lblClosestClickedValueCustomColors.Size = new System.Drawing.Size(36, 17);
            this.lblClosestClickedValueCustomColors.TabIndex = 4;
            this.lblClosestClickedValueCustomColors.DoubleClick += new System.EventHandler(this.lblClosestClickedValueCustomColors_DoubleClick);
            // 
            // optClosestClickedValueColorCustomColor
            // 
            this.optClosestClickedValueColorCustomColor.AutoSize = true;
            this.optClosestClickedValueColorCustomColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optClosestClickedValueColorCustomColor.Location = new System.Drawing.Point(10, 42);
            this.optClosestClickedValueColorCustomColor.Name = "optClosestClickedValueColorCustomColor";
            this.optClosestClickedValueColorCustomColor.Size = new System.Drawing.Size(85, 17);
            this.optClosestClickedValueColorCustomColor.TabIndex = 3;
            this.optClosestClickedValueColorCustomColor.TabStop = true;
            this.optClosestClickedValueColorCustomColor.Text = "Custom color";
            this.optClosestClickedValueColorCustomColor.UseVisualStyleBackColor = true;
            // 
            // optClosestClickedValueColorInvertedColor
            // 
            this.optClosestClickedValueColorInvertedColor.AutoSize = true;
            this.optClosestClickedValueColorInvertedColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optClosestClickedValueColorInvertedColor.Location = new System.Drawing.Point(111, 19);
            this.optClosestClickedValueColorInvertedColor.Name = "optClosestClickedValueColorInvertedColor";
            this.optClosestClickedValueColorInvertedColor.Size = new System.Drawing.Size(89, 17);
            this.optClosestClickedValueColorInvertedColor.TabIndex = 2;
            this.optClosestClickedValueColorInvertedColor.TabStop = true;
            this.optClosestClickedValueColorInvertedColor.Text = "Inverted color";
            this.optClosestClickedValueColorInvertedColor.UseVisualStyleBackColor = true;
            // 
            // optClosestClickedValueColorSameAsSeries
            // 
            this.optClosestClickedValueColorSameAsSeries.AutoSize = true;
            this.optClosestClickedValueColorSameAsSeries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optClosestClickedValueColorSameAsSeries.Location = new System.Drawing.Point(10, 19);
            this.optClosestClickedValueColorSameAsSeries.Name = "optClosestClickedValueColorSameAsSeries";
            this.optClosestClickedValueColorSameAsSeries.Size = new System.Drawing.Size(95, 17);
            this.optClosestClickedValueColorSameAsSeries.TabIndex = 1;
            this.optClosestClickedValueColorSameAsSeries.TabStop = true;
            this.optClosestClickedValueColorSameAsSeries.Text = "Same as series";
            this.optClosestClickedValueColorSameAsSeries.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Graph component visibility";
            // 
            // chkHeaderVisible
            // 
            this.chkHeaderVisible.AutoSize = true;
            this.chkHeaderVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHeaderVisible.Location = new System.Drawing.Point(481, 69);
            this.chkHeaderVisible.Name = "chkHeaderVisible";
            this.chkHeaderVisible.Size = new System.Drawing.Size(58, 17);
            this.chkHeaderVisible.TabIndex = 16;
            this.chkHeaderVisible.Text = "Header";
            this.chkHeaderVisible.UseVisualStyleBackColor = true;
            // 
            // chkLegendVisible
            // 
            this.chkLegendVisible.AutoSize = true;
            this.chkLegendVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLegendVisible.Location = new System.Drawing.Point(481, 92);
            this.chkLegendVisible.Name = "chkLegendVisible";
            this.chkLegendVisible.Size = new System.Drawing.Size(59, 17);
            this.chkLegendVisible.TabIndex = 17;
            this.chkLegendVisible.Text = "Legend";
            this.chkLegendVisible.UseVisualStyleBackColor = true;
            // 
            // chkHorisontalGridLinesVisible
            // 
            this.chkHorisontalGridLinesVisible.AutoSize = true;
            this.chkHorisontalGridLinesVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHorisontalGridLinesVisible.Location = new System.Drawing.Point(481, 115);
            this.chkHorisontalGridLinesVisible.Name = "chkHorisontalGridLinesVisible";
            this.chkHorisontalGridLinesVisible.Size = new System.Drawing.Size(114, 17);
            this.chkHorisontalGridLinesVisible.TabIndex = 18;
            this.chkHorisontalGridLinesVisible.Text = "Horisontal grid lines";
            this.chkHorisontalGridLinesVisible.UseVisualStyleBackColor = true;
            // 
            // chkVerticalGridLinesVisible
            // 
            this.chkVerticalGridLinesVisible.AutoSize = true;
            this.chkVerticalGridLinesVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVerticalGridLinesVisible.Location = new System.Drawing.Point(481, 138);
            this.chkVerticalGridLinesVisible.Name = "chkVerticalGridLinesVisible";
            this.chkVerticalGridLinesVisible.Size = new System.Drawing.Size(102, 17);
            this.chkVerticalGridLinesVisible.TabIndex = 19;
            this.chkVerticalGridLinesVisible.Text = "Vertical grid lines";
            this.chkVerticalGridLinesVisible.UseVisualStyleBackColor = true;
            // 
            // chkSelectionBarVisible
            // 
            this.chkSelectionBarVisible.AutoSize = true;
            this.chkSelectionBarVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSelectionBarVisible.Location = new System.Drawing.Point(481, 161);
            this.chkSelectionBarVisible.Name = "chkSelectionBarVisible";
            this.chkSelectionBarVisible.Size = new System.Drawing.Size(82, 17);
            this.chkSelectionBarVisible.TabIndex = 20;
            this.chkSelectionBarVisible.Text = "Selectionbar";
            this.chkSelectionBarVisible.UseVisualStyleBackColor = true;
            // 
            // chkHighlighClickedValueVisible
            // 
            this.chkHighlighClickedValueVisible.AutoSize = true;
            this.chkHighlighClickedValueVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHighlighClickedValueVisible.Location = new System.Drawing.Point(481, 184);
            this.chkHighlighClickedValueVisible.Name = "chkHighlighClickedValueVisible";
            this.chkHighlighClickedValueVisible.Size = new System.Drawing.Size(130, 17);
            this.chkHighlighClickedValueVisible.TabIndex = 21;
            this.chkHighlighClickedValueVisible.Text = "Highlight clicked value";
            this.chkHighlighClickedValueVisible.UseVisualStyleBackColor = true;
            // 
            // chkEnableFillAreaBelowSeries
            // 
            this.chkEnableFillAreaBelowSeries.AutoSize = true;
            this.chkEnableFillAreaBelowSeries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEnableFillAreaBelowSeries.Location = new System.Drawing.Point(481, 207);
            this.chkEnableFillAreaBelowSeries.Name = "chkEnableFillAreaBelowSeries";
            this.chkEnableFillAreaBelowSeries.Size = new System.Drawing.Size(120, 17);
            this.chkEnableFillAreaBelowSeries.TabIndex = 22;
            this.chkEnableFillAreaBelowSeries.Text = "Fill area below series";
            this.chkEnableFillAreaBelowSeries.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.optGraphFillAreaBelowSeriesAlpha192);
            this.groupBox4.Controls.Add(this.optGraphFillAreaBelowSeriesAlpha128);
            this.groupBox4.Controls.Add(this.optGraphFillAreaBelowSeriesAlpha64);
            this.groupBox4.Controls.Add(this.optGraphFillAreaBelowSeriesAlpha48);
            this.groupBox4.Controls.Add(this.optGraphFillAreaBelowSeriesAlpha32);
            this.groupBox4.Controls.Add(this.optGraphFillAreaBelowSeriesAlpha16);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Location = new System.Drawing.Point(491, 229);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(138, 88);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fill area (transparency)";
            // 
            // optGraphFillAreaBelowSeriesAlpha192
            // 
            this.optGraphFillAreaBelowSeriesAlpha192.AutoSize = true;
            this.optGraphFillAreaBelowSeriesAlpha192.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optGraphFillAreaBelowSeriesAlpha192.Location = new System.Drawing.Point(62, 65);
            this.optGraphFillAreaBelowSeriesAlpha192.Name = "optGraphFillAreaBelowSeriesAlpha192";
            this.optGraphFillAreaBelowSeriesAlpha192.Size = new System.Drawing.Size(42, 17);
            this.optGraphFillAreaBelowSeriesAlpha192.TabIndex = 6;
            this.optGraphFillAreaBelowSeriesAlpha192.Text = "192";
            this.optGraphFillAreaBelowSeriesAlpha192.UseVisualStyleBackColor = true;
            // 
            // optGraphFillAreaBelowSeriesAlpha128
            // 
            this.optGraphFillAreaBelowSeriesAlpha128.AutoSize = true;
            this.optGraphFillAreaBelowSeriesAlpha128.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optGraphFillAreaBelowSeriesAlpha128.Location = new System.Drawing.Point(62, 42);
            this.optGraphFillAreaBelowSeriesAlpha128.Name = "optGraphFillAreaBelowSeriesAlpha128";
            this.optGraphFillAreaBelowSeriesAlpha128.Size = new System.Drawing.Size(42, 17);
            this.optGraphFillAreaBelowSeriesAlpha128.TabIndex = 5;
            this.optGraphFillAreaBelowSeriesAlpha128.Text = "128";
            this.optGraphFillAreaBelowSeriesAlpha128.UseVisualStyleBackColor = true;
            // 
            // optGraphFillAreaBelowSeriesAlpha64
            // 
            this.optGraphFillAreaBelowSeriesAlpha64.AutoSize = true;
            this.optGraphFillAreaBelowSeriesAlpha64.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optGraphFillAreaBelowSeriesAlpha64.Location = new System.Drawing.Point(62, 19);
            this.optGraphFillAreaBelowSeriesAlpha64.Name = "optGraphFillAreaBelowSeriesAlpha64";
            this.optGraphFillAreaBelowSeriesAlpha64.Size = new System.Drawing.Size(36, 17);
            this.optGraphFillAreaBelowSeriesAlpha64.TabIndex = 4;
            this.optGraphFillAreaBelowSeriesAlpha64.Text = "64";
            this.optGraphFillAreaBelowSeriesAlpha64.UseVisualStyleBackColor = true;
            // 
            // optGraphFillAreaBelowSeriesAlpha48
            // 
            this.optGraphFillAreaBelowSeriesAlpha48.AutoSize = true;
            this.optGraphFillAreaBelowSeriesAlpha48.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optGraphFillAreaBelowSeriesAlpha48.Location = new System.Drawing.Point(10, 65);
            this.optGraphFillAreaBelowSeriesAlpha48.Name = "optGraphFillAreaBelowSeriesAlpha48";
            this.optGraphFillAreaBelowSeriesAlpha48.Size = new System.Drawing.Size(36, 17);
            this.optGraphFillAreaBelowSeriesAlpha48.TabIndex = 3;
            this.optGraphFillAreaBelowSeriesAlpha48.Text = "48";
            this.optGraphFillAreaBelowSeriesAlpha48.UseVisualStyleBackColor = true;
            // 
            // optGraphFillAreaBelowSeriesAlpha32
            // 
            this.optGraphFillAreaBelowSeriesAlpha32.AutoSize = true;
            this.optGraphFillAreaBelowSeriesAlpha32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optGraphFillAreaBelowSeriesAlpha32.Location = new System.Drawing.Point(10, 42);
            this.optGraphFillAreaBelowSeriesAlpha32.Name = "optGraphFillAreaBelowSeriesAlpha32";
            this.optGraphFillAreaBelowSeriesAlpha32.Size = new System.Drawing.Size(36, 17);
            this.optGraphFillAreaBelowSeriesAlpha32.TabIndex = 2;
            this.optGraphFillAreaBelowSeriesAlpha32.Text = "32";
            this.optGraphFillAreaBelowSeriesAlpha32.UseVisualStyleBackColor = true;
            // 
            // optGraphFillAreaBelowSeriesAlpha16
            // 
            this.optGraphFillAreaBelowSeriesAlpha16.AutoSize = true;
            this.optGraphFillAreaBelowSeriesAlpha16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optGraphFillAreaBelowSeriesAlpha16.Location = new System.Drawing.Point(10, 19);
            this.optGraphFillAreaBelowSeriesAlpha16.Name = "optGraphFillAreaBelowSeriesAlpha16";
            this.optGraphFillAreaBelowSeriesAlpha16.Size = new System.Drawing.Size(36, 17);
            this.optGraphFillAreaBelowSeriesAlpha16.TabIndex = 1;
            this.optGraphFillAreaBelowSeriesAlpha16.Text = "16";
            this.optGraphFillAreaBelowSeriesAlpha16.UseVisualStyleBackColor = true;
            // 
            // GraphColorSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(643, 421);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.chkEnableFillAreaBelowSeries);
            this.Controls.Add(this.chkHighlighClickedValueVisible);
            this.Controls.Add(this.chkSelectionBarVisible);
            this.Controls.Add(this.chkVerticalGridLinesVisible);
            this.Controls.Add(this.chkHorisontalGridLinesVisible);
            this.Controls.Add(this.chkLegendVisible);
            this.Controls.Add(this.chkHeaderVisible);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdSwapBackgroundColors);
            this.Controls.Add(this.cmdChange2);
            this.Controls.Add(this.lvwGraphComponentColors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdResetSeriesColors);
            this.Controls.Add(this.cmdChange);
            this.Controls.Add(this.cmdMoveDown);
            this.Controls.Add(this.cmdMoveUp);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwSeriesColors);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GraphColorSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph Settings";
            this.Load += new System.EventHandler(this.GraphColorSettings_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdOKSelect;
        private System.Windows.Forms.ListView lvwSeriesColors;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader colorColumnHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdMoveUp;
        private System.Windows.Forms.Button cmdMoveDown;
        private System.Windows.Forms.Button cmdChange;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button cmdResetSeriesColors;
        private System.Windows.Forms.Button cmdExportSeriesColors;
        private System.Windows.Forms.Button cmdImportSeriesColors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvwGraphComponentColors;
        private System.Windows.Forms.ColumnHeader nameColumnHeader1;
        private System.Windows.Forms.ColumnHeader colorColumnHeader1;
        private System.Windows.Forms.Button cmdChange2;
        private System.Windows.Forms.Button cmdSwapBackgroundColors;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optGraphTypeStandard;
        private System.Windows.Forms.RadioButton optGraphTypeLogarithmic;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optBackgroundGradientDirectionHorizontal;
        private System.Windows.Forms.RadioButton optBackgroundGradientDirectionVertical;
        private System.Windows.Forms.RadioButton optBackgroundGradientDirectionForwardDiagonal;
        private System.Windows.Forms.RadioButton optBackgroundGradientDirectionBackwardDiagonal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton optClosestClickedValueColorCustomColor;
        private System.Windows.Forms.RadioButton optClosestClickedValueColorInvertedColor;
        private System.Windows.Forms.RadioButton optClosestClickedValueColorSameAsSeries;
        private System.Windows.Forms.Label lblClosestClickedValueCustomColors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkHeaderVisible;
        private System.Windows.Forms.CheckBox chkLegendVisible;
        private System.Windows.Forms.CheckBox chkHorisontalGridLinesVisible;
        private System.Windows.Forms.CheckBox chkVerticalGridLinesVisible;
        private System.Windows.Forms.CheckBox chkSelectionBarVisible;
        private System.Windows.Forms.CheckBox chkHighlighClickedValueVisible;
        private System.Windows.Forms.CheckBox chkEnableFillAreaBelowSeries;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton optGraphFillAreaBelowSeriesAlpha192;
        private System.Windows.Forms.RadioButton optGraphFillAreaBelowSeriesAlpha128;
        private System.Windows.Forms.RadioButton optGraphFillAreaBelowSeriesAlpha64;
        private System.Windows.Forms.RadioButton optGraphFillAreaBelowSeriesAlpha48;
        private System.Windows.Forms.RadioButton optGraphFillAreaBelowSeriesAlpha32;
        private System.Windows.Forms.RadioButton optGraphFillAreaBelowSeriesAlpha16;
    }
}