namespace QuickMon
{
    partial class EditMonitorPackConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMonitorPackConfig));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.chkCorrectiveScripts = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.collectorStateHistorySizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMonitorPackPath = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneric = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pollingGroupBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.freqSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tabAdvancedConfig = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.label42 = new System.Windows.Forms.Label();
            this.txtConfigVarReplaceByValue = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtConfigVarSearchFor = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.lvwConfigVars = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label37 = new System.Windows.Forms.Label();
            this.llblRawEdit = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.collectorStateHistorySizeNumericUpDown)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGeneric.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pollingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecNumericUpDown)).BeginInit();
            this.tabAdvancedConfig.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(508, 309);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(427, 309);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "&Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(103, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(373, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // chkEnabled
            // 
            this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.BackColor = System.Drawing.Color.Transparent;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkEnabled.Location = new System.Drawing.Point(486, 15);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(63, 17);
            this.chkEnabled.TabIndex = 2;
            this.chkEnabled.Text = "&Enabled";
            this.chkEnabled.UseVisualStyleBackColor = false;
            // 
            // chkCorrectiveScripts
            // 
            this.chkCorrectiveScripts.AutoSize = true;
            this.chkCorrectiveScripts.Location = new System.Drawing.Point(9, 22);
            this.chkCorrectiveScripts.Name = "chkCorrectiveScripts";
            this.chkCorrectiveScripts.Size = new System.Drawing.Size(187, 17);
            this.chkCorrectiveScripts.TabIndex = 0;
            this.chkCorrectiveScripts.Text = "&Allow corrective scripts to execute";
            this.chkCorrectiveScripts.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Collector &history";
            // 
            // collectorStateHistorySizeNumericUpDown
            // 
            this.collectorStateHistorySizeNumericUpDown.Location = new System.Drawing.Point(88, 53);
            this.collectorStateHistorySizeNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.collectorStateHistorySizeNumericUpDown.Name = "collectorStateHistorySizeNumericUpDown";
            this.collectorStateHistorySizeNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.collectorStateHistorySizeNumericUpDown.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "# of collector states to keep";
            // 
            // txtType
            // 
            this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtType.Location = new System.Drawing.Point(94, 8);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(479, 20);
            this.txtType.TabIndex = 1;
            this.txtType.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "&Type";
            // 
            // lblMonitorPackPath
            // 
            this.lblMonitorPackPath.AutoEllipsis = true;
            this.lblMonitorPackPath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblMonitorPackPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMonitorPackPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblMonitorPackPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonitorPackPath.ForeColor = System.Drawing.Color.DarkGray;
            this.lblMonitorPackPath.Location = new System.Drawing.Point(3, 216);
            this.lblMonitorPackPath.Name = "lblMonitorPackPath";
            this.lblMonitorPackPath.Size = new System.Drawing.Size(575, 20);
            this.lblMonitorPackPath.TabIndex = 14;
            this.lblMonitorPackPath.Text = " ";
            this.lblMonitorPackPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMonitorPackPath.DoubleClick += new System.EventHandler(this.lblMonitorPackPath_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabGeneric);
            this.tabControl1.Controls.Add(this.tabAdvancedConfig);
            this.tabControl1.Location = new System.Drawing.Point(1, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(589, 265);
            this.tabControl1.TabIndex = 3;
            // 
            // tabGeneric
            // 
            this.tabGeneric.BackColor = System.Drawing.Color.White;
            this.tabGeneric.Controls.Add(this.lblMonitorPackPath);
            this.tabGeneric.Controls.Add(this.groupBox1);
            this.tabGeneric.Controls.Add(this.pollingGroupBox);
            this.tabGeneric.Controls.Add(this.txtType);
            this.tabGeneric.Controls.Add(this.label7);
            this.tabGeneric.Location = new System.Drawing.Point(4, 22);
            this.tabGeneric.Name = "tabGeneric";
            this.tabGeneric.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneric.Size = new System.Drawing.Size(581, 239);
            this.tabGeneric.TabIndex = 0;
            this.tabGeneric.Text = "Generic";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.collectorStateHistorySizeNumericUpDown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkCorrectiveScripts);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 99);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Collectors and Notifiers";
            // 
            // pollingGroupBox
            // 
            this.pollingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pollingGroupBox.Controls.Add(this.label6);
            this.pollingGroupBox.Controls.Add(this.label4);
            this.pollingGroupBox.Controls.Add(this.label5);
            this.pollingGroupBox.Controls.Add(this.freqSecNumericUpDown);
            this.pollingGroupBox.Location = new System.Drawing.Point(6, 139);
            this.pollingGroupBox.Name = "pollingGroupBox";
            this.pollingGroupBox.Size = new System.Drawing.Size(569, 60);
            this.pollingGroupBox.TabIndex = 3;
            this.pollingGroupBox.TabStop = false;
            this.pollingGroupBox.Text = "Polling";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Frequency";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "If frequency = 0 then application setting is used";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sec";
            // 
            // freqSecNumericUpDown
            // 
            this.freqSecNumericUpDown.Location = new System.Drawing.Point(88, 18);
            this.freqSecNumericUpDown.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.freqSecNumericUpDown.Name = "freqSecNumericUpDown";
            this.freqSecNumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.freqSecNumericUpDown.TabIndex = 1;
            // 
            // tabAdvancedConfig
            // 
            this.tabAdvancedConfig.BackColor = System.Drawing.Color.White;
            this.tabAdvancedConfig.Controls.Add(this.groupBox5);
            this.tabAdvancedConfig.Location = new System.Drawing.Point(4, 22);
            this.tabAdvancedConfig.Name = "tabAdvancedConfig";
            this.tabAdvancedConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdvancedConfig.Size = new System.Drawing.Size(581, 239);
            this.tabAdvancedConfig.TabIndex = 1;
            this.tabAdvancedConfig.Text = "Advanced Config settings";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.toolStrip1);
            this.groupBox5.Controls.Add(this.label42);
            this.groupBox5.Controls.Add(this.txtConfigVarReplaceByValue);
            this.groupBox5.Controls.Add(this.label41);
            this.groupBox5.Controls.Add(this.txtConfigVarSearchFor);
            this.groupBox5.Controls.Add(this.label40);
            this.groupBox5.Controls.Add(this.lvwConfigVars);
            this.groupBox5.Controls.Add(this.label37);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(575, 233);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addConfigVarToolStripButton,
            this.deleteConfigVarToolStripButton,
            this.toolStripSeparator1,
            this.moveUpConfigVarToolStripButton,
            this.moveDownConfigVarToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(569, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addConfigVarToolStripButton
            // 
            this.addConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.Plus16x16;
            this.addConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addConfigVarToolStripButton.Name = "addConfigVarToolStripButton";
            this.addConfigVarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addConfigVarToolStripButton.Text = "Create new";
            this.addConfigVarToolStripButton.ToolTipText = "Add entry";
            this.addConfigVarToolStripButton.Click += new System.EventHandler(this.addConfigVarToolStripButton_Click);
            // 
            // deleteConfigVarToolStripButton
            // 
            this.deleteConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteConfigVarToolStripButton.Enabled = false;
            this.deleteConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.whack;
            this.deleteConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteConfigVarToolStripButton.Name = "deleteConfigVarToolStripButton";
            this.deleteConfigVarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteConfigVarToolStripButton.Text = "Delete selected item(s)";
            this.deleteConfigVarToolStripButton.Click += new System.EventHandler(this.deleteConfigVarToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // moveUpConfigVarToolStripButton
            // 
            this.moveUpConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveUpConfigVarToolStripButton.Enabled = false;
            this.moveUpConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.Up16x16;
            this.moveUpConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveUpConfigVarToolStripButton.Name = "moveUpConfigVarToolStripButton";
            this.moveUpConfigVarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.moveUpConfigVarToolStripButton.Text = "Move selected item up";
            this.moveUpConfigVarToolStripButton.Click += new System.EventHandler(this.moveUpConfigVarToolStripButton_Click);
            // 
            // moveDownConfigVarToolStripButton
            // 
            this.moveDownConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownConfigVarToolStripButton.Enabled = false;
            this.moveDownConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.Down16x16;
            this.moveDownConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownConfigVarToolStripButton.Name = "moveDownConfigVarToolStripButton";
            this.moveDownConfigVarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.moveDownConfigVarToolStripButton.Text = "Move selected item down";
            this.moveDownConfigVarToolStripButton.Click += new System.EventHandler(this.moveDownConfigVarToolStripButton_Click);
            // 
            // label42
            // 
            this.label42.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(6, 201);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(563, 29);
            this.label42.TabIndex = 6;
            this.label42.Text = "Suggestions: Use \'variable\' names that are unique in the config XML. e.g. %SomeVa" +
    "lue%. Be careful when using quotes/doublequotes or any other characters that are" +
    " \'special\' in XML.";
            // 
            // txtConfigVarReplaceByValue
            // 
            this.txtConfigVarReplaceByValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtConfigVarReplaceByValue.Location = new System.Drawing.Point(335, 177);
            this.txtConfigVarReplaceByValue.Name = "txtConfigVarReplaceByValue";
            this.txtConfigVarReplaceByValue.Size = new System.Drawing.Size(173, 20);
            this.txtConfigVarReplaceByValue.TabIndex = 5;
            this.txtConfigVarReplaceByValue.TextChanged += new System.EventHandler(this.txtConfigVarReplaceByValue_TextChanged);
            // 
            // label41
            // 
            this.label41.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(260, 180);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(69, 13);
            this.label41.TabIndex = 4;
            this.label41.Text = "Replace with";
            // 
            // txtConfigVarSearchFor
            // 
            this.txtConfigVarSearchFor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtConfigVarSearchFor.Location = new System.Drawing.Point(81, 177);
            this.txtConfigVarSearchFor.Name = "txtConfigVarSearchFor";
            this.txtConfigVarSearchFor.Size = new System.Drawing.Size(173, 20);
            this.txtConfigVarSearchFor.TabIndex = 3;
            this.txtConfigVarSearchFor.TextChanged += new System.EventHandler(this.txtConfigVarSearchFor_TextChanged);
            // 
            // label40
            // 
            this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(6, 180);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(56, 13);
            this.label40.TabIndex = 2;
            this.label40.Text = "Search for";
            // 
            // lvwConfigVars
            // 
            this.lvwConfigVars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwConfigVars.AutoResizeColumnEnabled = false;
            this.lvwConfigVars.AutoResizeColumnIndex = 0;
            this.lvwConfigVars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.valueColumnHeader});
            this.lvwConfigVars.FullRowSelect = true;
            this.lvwConfigVars.Location = new System.Drawing.Point(3, 44);
            this.lvwConfigVars.Name = "lvwConfigVars";
            this.lvwConfigVars.Size = new System.Drawing.Size(566, 127);
            this.lvwConfigVars.TabIndex = 1;
            this.lvwConfigVars.UseCompatibleStateImageBehavior = false;
            this.lvwConfigVars.View = System.Windows.Forms.View.Details;
            this.lvwConfigVars.SelectedIndexChanged += new System.EventHandler(this.lvwConfigVars_SelectedIndexChanged);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Search for";
            this.nameColumnHeader.Width = 243;
            // 
            // valueColumnHeader
            // 
            this.valueColumnHeader.Text = "Replace by";
            this.valueColumnHeader.Width = 262;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(6, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(98, 13);
            this.label37.TabIndex = 0;
            this.label37.Text = "Config variables";
            // 
            // llblRawEdit
            // 
            this.llblRawEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblRawEdit.AutoSize = true;
            this.llblRawEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblRawEdit.Location = new System.Drawing.Point(9, 314);
            this.llblRawEdit.Name = "llblRawEdit";
            this.llblRawEdit.Size = new System.Drawing.Size(86, 13);
            this.llblRawEdit.TabIndex = 4;
            this.llblRawEdit.TabStop = true;
            this.llblRawEdit.Text = "Edit RAW config";
            this.llblRawEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRawEdit_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QuickMon.Properties.Resources.BlueArcTopRight;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(555, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 42);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // EditMonitorPackConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(595, 344);
            this.Controls.Add(this.llblRawEdit);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditMonitorPackConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor pack config";
            this.Load += new System.EventHandler(this.EditMonitorPackConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.collectorStateHistorySizeNumericUpDown)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGeneric.ResumeLayout(false);
            this.tabGeneric.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pollingGroupBox.ResumeLayout(false);
            this.pollingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecNumericUpDown)).EndInit();
            this.tabAdvancedConfig.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.CheckBox chkCorrectiveScripts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown collectorStateHistorySizeNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMonitorPackPath;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneric;
        private System.Windows.Forms.TabPage tabAdvancedConfig;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addConfigVarToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteConfigVarToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton moveUpConfigVarToolStripButton;
        private System.Windows.Forms.ToolStripButton moveDownConfigVarToolStripButton;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtConfigVarReplaceByValue;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtConfigVarSearchFor;
        private System.Windows.Forms.Label label40;
        private ListViewEx lvwConfigVars;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader valueColumnHeader;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown freqSecNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel llblRawEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox pollingGroupBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}