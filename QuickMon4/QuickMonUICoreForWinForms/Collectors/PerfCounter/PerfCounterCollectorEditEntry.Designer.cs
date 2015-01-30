namespace QuickMon.Collectors
{
    partial class PerfCounterCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerfCounterCollectorEditEntry));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdEditPerfCounter = new System.Windows.Forms.Button();
            this.txtPerfCounter = new System.Windows.Forms.TextBox();
            this.cmdSample = new System.Windows.Forms.Button();
            this.optCustom = new System.Windows.Forms.RadioButton();
            this.cboPerformanceCounter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComputerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.optCommon = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.errorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.warningNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmdEditPerfCounter);
            this.groupBox1.Controls.Add(this.txtPerfCounter);
            this.groupBox1.Controls.Add(this.cmdSample);
            this.groupBox1.Controls.Add(this.optCustom);
            this.groupBox1.Controls.Add(this.cboPerformanceCounter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtComputerName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.optCommon);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 155);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Performance counter definition";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Performance counter";
            // 
            // cmdEditPerfCounter
            // 
            this.cmdEditPerfCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEditPerfCounter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditPerfCounter.Location = new System.Drawing.Point(473, 114);
            this.cmdEditPerfCounter.Name = "cmdEditPerfCounter";
            this.cmdEditPerfCounter.Size = new System.Drawing.Size(41, 23);
            this.cmdEditPerfCounter.TabIndex = 8;
            this.cmdEditPerfCounter.Text = "- - -";
            this.cmdEditPerfCounter.UseVisualStyleBackColor = true;
            this.cmdEditPerfCounter.Click += new System.EventHandler(this.cmdEditPerfCounter_Click);
            // 
            // txtPerfCounter
            // 
            this.txtPerfCounter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerfCounter.Location = new System.Drawing.Point(164, 116);
            this.txtPerfCounter.Name = "txtPerfCounter";
            this.txtPerfCounter.ReadOnly = true;
            this.txtPerfCounter.Size = new System.Drawing.Size(303, 20);
            this.txtPerfCounter.TabIndex = 7;
            this.txtPerfCounter.TextChanged += new System.EventHandler(this.txtPerfCounter_TextChanged);
            // 
            // cmdSample
            // 
            this.cmdSample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSample.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSample.Location = new System.Drawing.Point(460, 13);
            this.cmdSample.Name = "cmdSample";
            this.cmdSample.Size = new System.Drawing.Size(54, 23);
            this.cmdSample.TabIndex = 9;
            this.cmdSample.Text = "Test";
            this.cmdSample.UseVisualStyleBackColor = true;
            this.cmdSample.Click += new System.EventHandler(this.cmdSample_Click);
            // 
            // optCustom
            // 
            this.optCustom.AutoSize = true;
            this.optCustom.Location = new System.Drawing.Point(9, 99);
            this.optCustom.Name = "optCustom";
            this.optCustom.Size = new System.Drawing.Size(60, 17);
            this.optCustom.TabIndex = 5;
            this.optCustom.TabStop = true;
            this.optCustom.Text = "Custom";
            this.optCustom.UseVisualStyleBackColor = true;
            // 
            // cboPerformanceCounter
            // 
            this.cboPerformanceCounter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPerformanceCounter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerformanceCounter.FormattingEnabled = true;
            this.cboPerformanceCounter.Location = new System.Drawing.Point(164, 66);
            this.cboPerformanceCounter.Name = "cboPerformanceCounter";
            this.cboPerformanceCounter.Size = new System.Drawing.Size(350, 21);
            this.cboPerformanceCounter.TabIndex = 4;
            this.cboPerformanceCounter.SelectedIndexChanged += new System.EventHandler(this.cboPerformanceCounter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Performance counter";
            // 
            // txtComputerName
            // 
            this.txtComputerName.Location = new System.Drawing.Point(164, 40);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.Size = new System.Drawing.Size(152, 20);
            this.txtComputerName.TabIndex = 2;
            this.txtComputerName.Text = "localhost";
            this.txtComputerName.TextChanged += new System.EventHandler(this.txtComputerName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Computer name";
            // 
            // optCommon
            // 
            this.optCommon.AutoSize = true;
            this.optCommon.Location = new System.Drawing.Point(9, 19);
            this.optCommon.Name = "optCommon";
            this.optCommon.Size = new System.Drawing.Size(66, 17);
            this.optCommon.TabIndex = 0;
            this.optCommon.TabStop = true;
            this.optCommon.Text = "Common";
            this.optCommon.UseVisualStyleBackColor = true;
            this.optCommon.CheckedChanged += new System.EventHandler(this.optCommon_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.errorNumericUpDown);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.warningNumericUpDown);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(3, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 57);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alert triggering";
            // 
            // errorNumericUpDown
            // 
            this.errorNumericUpDown.DecimalPlaces = 3;
            this.errorNumericUpDown.Location = new System.Drawing.Point(269, 19);
            this.errorNumericUpDown.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.errorNumericUpDown.Name = "errorNumericUpDown";
            this.errorNumericUpDown.Size = new System.Drawing.Size(126, 20);
            this.errorNumericUpDown.TabIndex = 3;
            this.errorNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Location = new System.Drawing.Point(11, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Warning";
            // 
            // warningNumericUpDown
            // 
            this.warningNumericUpDown.DecimalPlaces = 3;
            this.warningNumericUpDown.Location = new System.Drawing.Point(92, 19);
            this.warningNumericUpDown.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.warningNumericUpDown.Name = "warningNumericUpDown";
            this.warningNumericUpDown.Size = new System.Drawing.Size(126, 20);
            this.warningNumericUpDown.TabIndex = 1;
            this.warningNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Location = new System.Drawing.Point(234, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Error";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(442, 234);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(361, 234);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // PerfCounterCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(529, 269);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PerfCounterCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PerfCounterCollectorEditEntry";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboPerformanceCounter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComputerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton optCommon;
        private System.Windows.Forms.RadioButton optCustom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdEditPerfCounter;
        private System.Windows.Forms.TextBox txtPerfCounter;
        private System.Windows.Forms.Button cmdSample;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown errorNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown warningNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
    }
}