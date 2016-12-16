namespace QuickMon
{
    partial class EditActionScript
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditActionScript));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.optDOS = new System.Windows.Forms.RadioButton();
            this.optPowerShell = new System.Windows.Forms.RadioButton();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboWindowSizeStyle = new System.Windows.Forms.ComboBox();
            this.chkAdminMode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(85, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(387, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type";
            // 
            // optDOS
            // 
            this.optDOS.AutoSize = true;
            this.optDOS.Checked = true;
            this.optDOS.Location = new System.Drawing.Point(85, 39);
            this.optDOS.Name = "optDOS";
            this.optDOS.Size = new System.Drawing.Size(122, 17);
            this.optDOS.TabIndex = 3;
            this.optDOS.TabStop = true;
            this.optDOS.Text = "DOS (command line)";
            this.optDOS.UseVisualStyleBackColor = true;
            // 
            // optPowerShell
            // 
            this.optPowerShell.AutoSize = true;
            this.optPowerShell.Location = new System.Drawing.Point(213, 39);
            this.optPowerShell.Name = "optPowerShell";
            this.optPowerShell.Size = new System.Drawing.Size(78, 17);
            this.optPowerShell.TabIndex = 4;
            this.optPowerShell.Text = "PowerShell";
            this.optPowerShell.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(85, 89);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(387, 61);
            this.txtDescription.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Description";
            // 
            // txtScript
            // 
            this.txtScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScript.Location = new System.Drawing.Point(85, 156);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScript.Size = new System.Drawing.Size(387, 167);
            this.txtScript.TabIndex = 11;
            this.txtScript.TextChanged += new System.EventHandler(this.txtScript_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Script";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(397, 329);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 13;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(316, 329);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 12;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Window size";
            // 
            // cboWindowSizeStyle
            // 
            this.cboWindowSizeStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWindowSizeStyle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboWindowSizeStyle.FormattingEnabled = true;
            this.cboWindowSizeStyle.Items.AddRange(new object[] {
            "Normal",
            "Hidden",
            "Minimized",
            "Maximized"});
            this.cboWindowSizeStyle.Location = new System.Drawing.Point(85, 62);
            this.cboWindowSizeStyle.Name = "cboWindowSizeStyle";
            this.cboWindowSizeStyle.Size = new System.Drawing.Size(125, 21);
            this.cboWindowSizeStyle.TabIndex = 6;
            // 
            // chkAdminMode
            // 
            this.chkAdminMode.AutoSize = true;
            this.chkAdminMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkAdminMode.Location = new System.Drawing.Point(216, 64);
            this.chkAdminMode.Name = "chkAdminMode";
            this.chkAdminMode.Size = new System.Drawing.Size(116, 17);
            this.chkAdminMode.TabIndex = 7;
            this.chkAdminMode.Text = "Run in Admin mode";
            this.chkAdminMode.UseVisualStyleBackColor = true;
            // 
            // EditActionScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.chkAdminMode);
            this.Controls.Add(this.cboWindowSizeStyle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.optPowerShell);
            this.Controls.Add(this.optDOS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "EditActionScript";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Action Script";
            this.Load += new System.EventHandler(this.EditActionScript_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton optDOS;
        private System.Windows.Forms.RadioButton optPowerShell;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboWindowSizeStyle;
        private System.Windows.Forms.CheckBox chkAdminMode;
    }
}