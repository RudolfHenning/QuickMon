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
            this.cboDefaultNotifier = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.collectorStateHistorySizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.freqSecTrackBar = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.freqSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMonitorPackPath = new System.Windows.Forms.Label();
            this.llblEditConfigVars = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.collectorStateHistorySizeNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(312, 279);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(231, 279);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 13;
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
            this.txtName.Size = new System.Drawing.Size(284, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // chkEnabled
            // 
            this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(12, 283);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 11;
            this.chkEnabled.Text = "&Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // chkCorrectiveScripts
            // 
            this.chkCorrectiveScripts.AutoSize = true;
            this.chkCorrectiveScripts.Location = new System.Drawing.Point(103, 67);
            this.chkCorrectiveScripts.Name = "chkCorrectiveScripts";
            this.chkCorrectiveScripts.Size = new System.Drawing.Size(187, 17);
            this.chkCorrectiveScripts.TabIndex = 4;
            this.chkCorrectiveScripts.Text = "&Allow corrective scripts to execute";
            this.chkCorrectiveScripts.UseVisualStyleBackColor = true;
            // 
            // cboDefaultNotifier
            // 
            this.cboDefaultNotifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDefaultNotifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefaultNotifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboDefaultNotifier.FormattingEnabled = true;
            this.cboDefaultNotifier.Location = new System.Drawing.Point(103, 90);
            this.cboDefaultNotifier.Name = "cboDefaultNotifier";
            this.cboDefaultNotifier.Size = new System.Drawing.Size(284, 21);
            this.cboDefaultNotifier.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "&Default notifier";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Collector &history";
            // 
            // collectorStateHistorySizeNumericUpDown
            // 
            this.collectorStateHistorySizeNumericUpDown.Location = new System.Drawing.Point(103, 117);
            this.collectorStateHistorySizeNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.collectorStateHistorySizeNumericUpDown.Name = "collectorStateHistorySizeNumericUpDown";
            this.collectorStateHistorySizeNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.collectorStateHistorySizeNumericUpDown.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "# of collector states to keep";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.freqSecTrackBar);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.freqSecNumericUpDown);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(15, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 110);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Polling";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "If frequency = 0 then application setting is used";
            // 
            // freqSecTrackBar
            // 
            this.freqSecTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.freqSecTrackBar.Location = new System.Drawing.Point(19, 45);
            this.freqSecTrackBar.Maximum = 120;
            this.freqSecTrackBar.Name = "freqSecTrackBar";
            this.freqSecTrackBar.Size = new System.Drawing.Size(347, 45);
            this.freqSecTrackBar.TabIndex = 3;
            this.freqSecTrackBar.TickFrequency = 5;
            this.freqSecTrackBar.Scroll += new System.EventHandler(this.freqSecTrackBar_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sec";
            // 
            // freqSecNumericUpDown
            // 
            this.freqSecNumericUpDown.Location = new System.Drawing.Point(85, 19);
            this.freqSecNumericUpDown.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.freqSecNumericUpDown.Name = "freqSecNumericUpDown";
            this.freqSecNumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.freqSecNumericUpDown.TabIndex = 1;
            this.freqSecNumericUpDown.ValueChanged += new System.EventHandler(this.freqSecNumericUpDown_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Frequency";
            // 
            // txtType
            // 
            this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtType.Location = new System.Drawing.Point(103, 38);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(284, 20);
            this.txtType.TabIndex = 3;
            this.txtType.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "&Type";
            // 
            // lblMonitorPackPath
            // 
            this.lblMonitorPackPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonitorPackPath.ForeColor = System.Drawing.Color.DarkGray;
            this.lblMonitorPackPath.Location = new System.Drawing.Point(10, 256);
            this.lblMonitorPackPath.Name = "lblMonitorPackPath";
            this.lblMonitorPackPath.Size = new System.Drawing.Size(377, 20);
            this.lblMonitorPackPath.TabIndex = 14;
            this.lblMonitorPackPath.Text = " ";
            this.lblMonitorPackPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // llblEditConfigVars
            // 
            this.llblEditConfigVars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblEditConfigVars.AutoSize = true;
            this.llblEditConfigVars.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblEditConfigVars.Location = new System.Drawing.Point(97, 284);
            this.llblEditConfigVars.Name = "llblEditConfigVars";
            this.llblEditConfigVars.Size = new System.Drawing.Size(125, 13);
            this.llblEditConfigVars.TabIndex = 12;
            this.llblEditConfigVars.TabStop = true;
            this.llblEditConfigVars.Text = "Manage Config Variables";
            this.llblEditConfigVars.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblEditConfigVars_LinkClicked);
            // 
            // EditMonitorPackConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(399, 314);
            this.Controls.Add(this.llblEditConfigVars);
            this.Controls.Add(this.lblMonitorPackPath);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.collectorStateHistorySizeNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboDefaultNotifier);
            this.Controls.Add(this.chkCorrectiveScripts);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditMonitorPackConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor pack config";
            this.Load += new System.EventHandler(this.EditMonitorPackConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.collectorStateHistorySizeNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecNumericUpDown)).EndInit();
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
        private System.Windows.Forms.ComboBox cboDefaultNotifier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown collectorStateHistorySizeNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar freqSecTrackBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown freqSecNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMonitorPackPath;
        private System.Windows.Forms.LinkLabel llblEditConfigVars;
    }
}