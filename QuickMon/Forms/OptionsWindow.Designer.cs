namespace QuickMon
{
    partial class OptionsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsWindow));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownPollFrequency = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chkDisablePollingOnError = new System.Windows.Forms.CheckBox();
            this.concurrencyLevelNnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPollFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.concurrencyLevelNnumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(207, 104);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(126, 104);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Polling frequency";
            // 
            // numericUpDownPollFrequency
            // 
            this.numericUpDownPollFrequency.Location = new System.Drawing.Point(129, 16);
            this.numericUpDownPollFrequency.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericUpDownPollFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPollFrequency.Name = "numericUpDownPollFrequency";
            this.numericUpDownPollFrequency.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownPollFrequency.TabIndex = 1;
            this.numericUpDownPollFrequency.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seconds";
            // 
            // chkDisablePollingOnError
            // 
            this.chkDisablePollingOnError.AutoSize = true;
            this.chkDisablePollingOnError.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDisablePollingOnError.Location = new System.Drawing.Point(28, 81);
            this.chkDisablePollingOnError.Name = "chkDisablePollingOnError";
            this.chkDisablePollingOnError.Size = new System.Drawing.Size(132, 17);
            this.chkDisablePollingOnError.TabIndex = 5;
            this.chkDisablePollingOnError.Text = "Disable polling on error";
            this.chkDisablePollingOnError.UseVisualStyleBackColor = true;
            // 
            // concurrencyLevelNnumericUpDown
            // 
            this.concurrencyLevelNnumericUpDown.Location = new System.Drawing.Point(129, 42);
            this.concurrencyLevelNnumericUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.concurrencyLevelNnumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.concurrencyLevelNnumericUpDown.Name = "concurrencyLevelNnumericUpDown";
            this.concurrencyLevelNnumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.concurrencyLevelNnumericUpDown.TabIndex = 4;
            this.concurrencyLevelNnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Concurrency level";
            // 
            // OptionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 139);
            this.Controls.Add(this.concurrencyLevelNnumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkDisablePollingOnError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownPollFrequency);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPollFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.concurrencyLevelNnumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownPollFrequency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkDisablePollingOnError;
        private System.Windows.Forms.NumericUpDown concurrencyLevelNnumericUpDown;
        private System.Windows.Forms.Label label3;
    }
}