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
            this.freqSecTrackBar = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.freqSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.cmdCancel.Location = new System.Drawing.Point(272, 232);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(191, 232);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 10;
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
            this.txtName.Size = new System.Drawing.Size(244, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // chkEnabled
            // 
            this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(12, 236);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 9;
            this.chkEnabled.Text = "&Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // chkCorrectiveScripts
            // 
            this.chkCorrectiveScripts.AutoSize = true;
            this.chkCorrectiveScripts.Location = new System.Drawing.Point(103, 38);
            this.chkCorrectiveScripts.Name = "chkCorrectiveScripts";
            this.chkCorrectiveScripts.Size = new System.Drawing.Size(187, 17);
            this.chkCorrectiveScripts.TabIndex = 2;
            this.chkCorrectiveScripts.Text = "&Allow corrective scripts to execute";
            this.chkCorrectiveScripts.UseVisualStyleBackColor = true;
            // 
            // cboDefaultNotifier
            // 
            this.cboDefaultNotifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefaultNotifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboDefaultNotifier.FormattingEnabled = true;
            this.cboDefaultNotifier.Location = new System.Drawing.Point(103, 61);
            this.cboDefaultNotifier.Name = "cboDefaultNotifier";
            this.cboDefaultNotifier.Size = new System.Drawing.Size(244, 21);
            this.cboDefaultNotifier.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "&Default notifier";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Collector &history";
            // 
            // collectorStateHistorySizeNumericUpDown
            // 
            this.collectorStateHistorySizeNumericUpDown.Location = new System.Drawing.Point(103, 88);
            this.collectorStateHistorySizeNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.collectorStateHistorySizeNumericUpDown.Name = "collectorStateHistorySizeNumericUpDown";
            this.collectorStateHistorySizeNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.collectorStateHistorySizeNumericUpDown.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 7;
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
            this.groupBox2.Location = new System.Drawing.Point(15, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 110);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Polling";
            // 
            // freqSecTrackBar
            // 
            this.freqSecTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.freqSecTrackBar.Location = new System.Drawing.Point(19, 45);
            this.freqSecTrackBar.Maximum = 120;
            this.freqSecTrackBar.Name = "freqSecTrackBar";
            this.freqSecTrackBar.Size = new System.Drawing.Size(307, 45);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "If frequency = 0 then application setting is used";
            // 
            // EditMonitorPackConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(359, 267);
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
    }
}