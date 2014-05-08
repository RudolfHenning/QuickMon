namespace QuickMon
{
    partial class AddCounter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCounter));
            this.label1 = new System.Windows.Forms.Label();
            this.txtComputer = new System.Windows.Forms.TextBox();
            this.cmdLoadCategories = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.cboCounter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboInstance = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.backgroundWorkerLoadMachineDetails = new System.ComponentModel.BackgroundWorker();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblWarning = new System.Windows.Forms.Label();
            this.invertValuesCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.errorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.warningNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Computer";
            // 
            // txtComputer
            // 
            this.txtComputer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComputer.Location = new System.Drawing.Point(99, 10);
            this.txtComputer.Name = "txtComputer";
            this.txtComputer.Size = new System.Drawing.Size(200, 20);
            this.txtComputer.TabIndex = 1;
            this.txtComputer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtComputer_KeyUp);
            // 
            // cmdLoadCategories
            // 
            this.cmdLoadCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoadCategories.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLoadCategories.Location = new System.Drawing.Point(305, 8);
            this.cmdLoadCategories.Name = "cmdLoadCategories";
            this.cmdLoadCategories.Size = new System.Drawing.Size(60, 23);
            this.cmdLoadCategories.TabIndex = 2;
            this.cmdLoadCategories.Text = "Load";
            this.cmdLoadCategories.UseVisualStyleBackColor = true;
            this.cmdLoadCategories.Click += new System.EventHandler(this.cmdLoadCategories_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Category";
            // 
            // cboCategory
            // 
            this.cboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(99, 47);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(265, 21);
            this.cboCategory.Sorted = true;
            this.cboCategory.TabIndex = 4;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // cboCounter
            // 
            this.cboCounter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCounter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCounter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboCounter.FormattingEnabled = true;
            this.cboCounter.Location = new System.Drawing.Point(99, 74);
            this.cboCounter.Name = "cboCounter";
            this.cboCounter.Size = new System.Drawing.Size(265, 21);
            this.cboCounter.Sorted = true;
            this.cboCounter.TabIndex = 6;
            this.cboCounter.SelectedIndexChanged += new System.EventHandler(this.cboCounter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Location = new System.Drawing.Point(14, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Counter";
            // 
            // cboInstance
            // 
            this.cboInstance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInstance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboInstance.FormattingEnabled = true;
            this.cboInstance.Location = new System.Drawing.Point(99, 101);
            this.cboInstance.Name = "cboInstance";
            this.cboInstance.Size = new System.Drawing.Size(265, 21);
            this.cboInstance.Sorted = true;
            this.cboInstance.TabIndex = 8;
            this.cboInstance.SelectedIndexChanged += new System.EventHandler(this.cboInstance_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Location = new System.Drawing.Point(14, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Instance";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(209, 201);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 15;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(290, 201);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 16;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // backgroundWorkerLoadMachineDetails
            // 
            this.backgroundWorkerLoadMachineDetails.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoadMachineDetails_DoWork);
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWarning.AutoSize = true;
            this.lblWarning.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(12, 206);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(10, 13);
            this.lblWarning.TabIndex = 14;
            this.lblWarning.Text = ".";
            // 
            // invertValuesCheckBox
            // 
            this.invertValuesCheckBox.AutoSize = true;
            this.invertValuesCheckBox.Checked = true;
            this.invertValuesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.invertValuesCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.invertValuesCheckBox.Location = new System.Drawing.Point(99, 128);
            this.invertValuesCheckBox.Name = "invertValuesCheckBox";
            this.invertValuesCheckBox.Size = new System.Drawing.Size(151, 17);
            this.invertValuesCheckBox.TabIndex = 9;
            this.invertValuesCheckBox.Text = "Success < Warning < Error";
            this.invertValuesCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Location = new System.Drawing.Point(14, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Error";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Location = new System.Drawing.Point(14, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Warning";
            // 
            // errorNumericUpDown
            // 
            this.errorNumericUpDown.Location = new System.Drawing.Point(99, 177);
            this.errorNumericUpDown.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.errorNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.errorNumericUpDown.Name = "errorNumericUpDown";
            this.errorNumericUpDown.Size = new System.Drawing.Size(126, 20);
            this.errorNumericUpDown.TabIndex = 13;
            this.errorNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // warningNumericUpDown
            // 
            this.warningNumericUpDown.Location = new System.Drawing.Point(99, 151);
            this.warningNumericUpDown.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.warningNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.warningNumericUpDown.Name = "warningNumericUpDown";
            this.warningNumericUpDown.Size = new System.Drawing.Size(126, 20);
            this.warningNumericUpDown.TabIndex = 11;
            this.warningNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AddCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(376, 236);
            this.Controls.Add(this.errorNumericUpDown);
            this.Controls.Add(this.warningNumericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.invertValuesCheckBox);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cboInstance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCounter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdLoadCategories);
            this.Controls.Add(this.txtComputer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCounter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Performance Counter";
            this.Load += new System.EventHandler(this.AddCounter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComputer;
        private System.Windows.Forms.Button cmdLoadCategories;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.ComboBox cboCounter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboInstance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoadMachineDetails;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.CheckBox invertValuesCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown errorNumericUpDown;
        private System.Windows.Forms.NumericUpDown warningNumericUpDown;
    }
}