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
            this.optGraphTypeStandard = new System.Windows.Forms.RadioButton();
            this.optGraphTypeLogarithmic = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optBackgroundGradientDirectionHorizontal = new System.Windows.Forms.RadioButton();
            this.optBackgroundGradientDirectionVertical = new System.Windows.Forms.RadioButton();
            this.optBackgroundGradientDirectionForwardDiagonal = new System.Windows.Forms.RadioButton();
            this.optBackgroundGradientDirectionBackwardDiagonal = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.optClosestClickedValueColorSameAsSeries = new System.Windows.Forms.RadioButton();
            this.optClosestClickedValueColorInvertedColor = new System.Windows.Forms.RadioButton();
            this.optClosestClickedValueColorCustomColor = new System.Windows.Forms.RadioButton();
            this.lblClosestClickedValueCustomColors = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(499, 40);
            this.panel1.TabIndex = 14;
            // 
            // cmdImportSeriesColors
            // 
            this.cmdImportSeriesColors.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
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
            this.cmdClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Location = new System.Drawing.Point(412, 7);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "Cancel";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // cmdExportSeriesColors
            // 
            this.cmdExportSeriesColors.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
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
            this.cmdOKSelect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdOKSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOKSelect.Location = new System.Drawing.Point(331, 7);
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
            this.lvwSeriesColors.Location = new System.Drawing.Point(44, 87);
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
            this.label1.Location = new System.Drawing.Point(41, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Series colors";
            // 
            // cmdAdd
            // 
            this.cmdAdd.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAdd.Image = global::QuickMon.Properties.Resources.Plus16x16;
            this.cmdAdd.Location = new System.Drawing.Point(86, 63);
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
            this.cmdRemove.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cmdRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRemove.Image = global::QuickMon.Properties.Resources.stop16x16;
            this.cmdRemove.Location = new System.Drawing.Point(128, 63);
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
            this.cmdMoveUp.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cmdMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMoveUp.Image = global::QuickMon.Properties.Resources.Up16x16;
            this.cmdMoveUp.Location = new System.Drawing.Point(8, 114);
            this.cmdMoveUp.Name = "cmdMoveUp";
            this.cmdMoveUp.Size = new System.Drawing.Size(30, 23);
            this.cmdMoveUp.TabIndex = 7;
            this.toolTip1.SetToolTip(this.cmdMoveUp, "Move selected series color up");
            this.cmdMoveUp.UseVisualStyleBackColor = true;
            this.cmdMoveUp.Click += new System.EventHandler(this.cmdMoveUp_Click);
            // 
            // cmdMoveDown
            // 
            this.cmdMoveDown.Enabled = false;
            this.cmdMoveDown.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cmdMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMoveDown.Image = global::QuickMon.Properties.Resources.Down16x16;
            this.cmdMoveDown.Location = new System.Drawing.Point(8, 143);
            this.cmdMoveDown.Name = "cmdMoveDown";
            this.cmdMoveDown.Size = new System.Drawing.Size(30, 23);
            this.cmdMoveDown.TabIndex = 8;
            this.toolTip1.SetToolTip(this.cmdMoveDown, "Move selected series color down");
            this.cmdMoveDown.UseVisualStyleBackColor = true;
            this.cmdMoveDown.Click += new System.EventHandler(this.cmdMoveDown_Click);
            // 
            // cmdChange
            // 
            this.cmdChange.Enabled = false;
            this.cmdChange.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cmdChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdChange.Image = global::QuickMon.Properties.Resources.tools16x16;
            this.cmdChange.Location = new System.Drawing.Point(44, 63);
            this.cmdChange.Name = "cmdChange";
            this.cmdChange.Size = new System.Drawing.Size(36, 23);
            this.cmdChange.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cmdChange, "Change selected series color");
            this.cmdChange.UseVisualStyleBackColor = true;
            this.cmdChange.Click += new System.EventHandler(this.cmdChange_Click);
            // 
            // cmdResetSeriesColors
            // 
            this.cmdResetSeriesColors.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cmdResetSeriesColors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdResetSeriesColors.Image = global::QuickMon.Properties.Resources.lightning;
            this.cmdResetSeriesColors.Location = new System.Drawing.Point(170, 63);
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
            this.label2.Location = new System.Drawing.Point(250, 45);
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
            this.lvwGraphComponentColors.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lvwGraphComponentColors.Location = new System.Drawing.Point(253, 87);
            this.lvwGraphComponentColors.Name = "lvwGraphComponentColors";
            this.lvwGraphComponentColors.Size = new System.Drawing.Size(234, 129);
            this.lvwGraphComponentColors.TabIndex = 12;
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
            this.cmdChange2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cmdChange2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdChange2.Image = global::QuickMon.Properties.Resources.tools16x16;
            this.cmdChange2.Location = new System.Drawing.Point(253, 63);
            this.cmdChange2.Name = "cmdChange2";
            this.cmdChange2.Size = new System.Drawing.Size(36, 23);
            this.cmdChange2.TabIndex = 10;
            this.toolTip1.SetToolTip(this.cmdChange2, "Edit graph component colors");
            this.cmdChange2.UseVisualStyleBackColor = true;
            this.cmdChange2.Click += new System.EventHandler(this.cmdChange2_Click);
            // 
            // cmdSwapBackgroundColors
            // 
            this.cmdSwapBackgroundColors.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cmdSwapBackgroundColors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSwapBackgroundColors.Image = global::QuickMon.Properties.Resources.UpDown;
            this.cmdSwapBackgroundColors.Location = new System.Drawing.Point(295, 63);
            this.cmdSwapBackgroundColors.Name = "cmdSwapBackgroundColors";
            this.cmdSwapBackgroundColors.Size = new System.Drawing.Size(36, 23);
            this.cmdSwapBackgroundColors.TabIndex = 11;
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
            this.groupBox1.Size = new System.Drawing.Size(480, 37);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graph type";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optBackgroundGradientDirectionBackwardDiagonal);
            this.groupBox2.Controls.Add(this.optBackgroundGradientDirectionForwardDiagonal);
            this.groupBox2.Controls.Add(this.optBackgroundGradientDirectionVertical);
            this.groupBox2.Controls.Add(this.optBackgroundGradientDirectionHorizontal);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(253, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 70);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Background gradient direction";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblClosestClickedValueCustomColors);
            this.groupBox3.Controls.Add(this.optClosestClickedValueColorCustomColor);
            this.groupBox3.Controls.Add(this.optClosestClickedValueColorInvertedColor);
            this.groupBox3.Controls.Add(this.optClosestClickedValueColorSameAsSeries);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(253, 298);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(234, 67);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Closest clicked value color";
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
            // GraphColorSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(499, 421);
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
    }
}