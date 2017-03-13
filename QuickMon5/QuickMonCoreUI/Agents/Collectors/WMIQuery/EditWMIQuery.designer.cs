namespace QuickMon.UI
{
    partial class EditWMIQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditWMIQuery));
            this.txtMachine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboNamespace = new System.Windows.Forms.ComboBox();
            this.cmdLoadClasses = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.cmdLoadNameSpaces = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lstProperties = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.cmdTest = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.timerGenerateQuery = new System.Windows.Forms.Timer(this.components);
            this.chkAccessdniedErrors = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtMachine
            // 
            this.txtMachine.Location = new System.Drawing.Point(118, 12);
            this.txtMachine.Name = "txtMachine";
            this.txtMachine.Size = new System.Drawing.Size(187, 20);
            this.txtMachine.TabIndex = 1;
            this.txtMachine.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Machine name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Root namespace";
            // 
            // cboNamespace
            // 
            this.cboNamespace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNamespace.FormattingEnabled = true;
            this.cboNamespace.Location = new System.Drawing.Point(118, 38);
            this.cboNamespace.Name = "cboNamespace";
            this.cboNamespace.Size = new System.Drawing.Size(388, 21);
            this.cboNamespace.Sorted = true;
            this.cboNamespace.TabIndex = 4;
            this.cboNamespace.Text = "root\\CIMV2";
            this.cboNamespace.SelectedIndexChanged += new System.EventHandler(this.cboNamespace_SelectedIndexChanged);
            // 
            // cmdLoadClasses
            // 
            this.cmdLoadClasses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoadClasses.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLoadClasses.Location = new System.Drawing.Point(512, 63);
            this.cmdLoadClasses.Name = "cmdLoadClasses";
            this.cmdLoadClasses.Size = new System.Drawing.Size(58, 23);
            this.cmdLoadClasses.TabIndex = 8;
            this.cmdLoadClasses.Text = "Load";
            this.cmdLoadClasses.UseVisualStyleBackColor = true;
            this.cmdLoadClasses.Click += new System.EventHandler(this.cmdLoadClasses_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Class name";
            // 
            // cboClass
            // 
            this.cboClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Location = new System.Drawing.Point(118, 65);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(388, 21);
            this.cboClass.Sorted = true;
            this.cboClass.TabIndex = 7;
            this.cboClass.SelectedIndexChanged += new System.EventHandler(this.cboClass_SelectedIndexChanged);
            // 
            // cmdLoadNameSpaces
            // 
            this.cmdLoadNameSpaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoadNameSpaces.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLoadNameSpaces.Location = new System.Drawing.Point(512, 36);
            this.cmdLoadNameSpaces.Name = "cmdLoadNameSpaces";
            this.cmdLoadNameSpaces.Size = new System.Drawing.Size(58, 23);
            this.cmdLoadNameSpaces.TabIndex = 5;
            this.cmdLoadNameSpaces.Text = "Load";
            this.cmdLoadNameSpaces.UseVisualStyleBackColor = true;
            this.cmdLoadNameSpaces.Click += new System.EventHandler(this.cmdLoadNameSpaces_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Properties";
            // 
            // lstProperties
            // 
            this.lstProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstProperties.FormattingEnabled = true;
            this.lstProperties.Location = new System.Drawing.Point(118, 98);
            this.lstProperties.Name = "lstProperties";
            this.lstProperties.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstProperties.Size = new System.Drawing.Size(187, 173);
            this.lstProperties.Sorted = true;
            this.lstProperties.TabIndex = 10;
            this.lstProperties.SelectedIndexChanged += new System.EventHandler(this.lstProperties_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Example query";
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.Location = new System.Drawing.Point(323, 114);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(247, 151);
            this.txtQuery.TabIndex = 12;
            // 
            // cmdTest
            // 
            this.cmdTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTest.Enabled = false;
            this.cmdTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTest.Location = new System.Drawing.Point(334, 275);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(75, 23);
            this.cmdTest.TabIndex = 14;
            this.cmdTest.Text = "Test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(496, 275);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 16;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(415, 275);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 15;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(277, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Testing the query will create a CSV file in \'My Documents\'";
            // 
            // timerGenerateQuery
            // 
            this.timerGenerateQuery.Interval = 250;
            this.timerGenerateQuery.Tick += new System.EventHandler(this.timerGenerateQuery_Tick);
            // 
            // chkAccessdniedErrors
            // 
            this.chkAccessdniedErrors.AutoSize = true;
            this.chkAccessdniedErrors.Checked = true;
            this.chkAccessdniedErrors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccessdniedErrors.Location = new System.Drawing.Point(347, 15);
            this.chkAccessdniedErrors.Name = "chkAccessdniedErrors";
            this.chkAccessdniedErrors.Size = new System.Drawing.Size(159, 17);
            this.chkAccessdniedErrors.TabIndex = 2;
            this.chkAccessdniedErrors.Text = "Show \'Access denied\' errors";
            this.chkAccessdniedErrors.UseVisualStyleBackColor = true;
            // 
            // EditWMIQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 312);
            this.Controls.Add(this.chkAccessdniedErrors);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdTest);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstProperties);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdLoadNameSpaces);
            this.Controls.Add(this.cboClass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdLoadClasses);
            this.Controls.Add(this.cboNamespace);
            this.Controls.Add(this.txtMachine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "EditWMIQuery";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WMI Query builder";
            this.Load += new System.EventHandler(this.EditWMIQuery_Load);
            this.Shown += new System.EventHandler(this.EditWMIQuery_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMachine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNamespace;
        private System.Windows.Forms.Button cmdLoadClasses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.Button cmdLoadNameSpaces;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstProperties;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timerGenerateQuery;
        private System.Windows.Forms.CheckBox chkAccessdniedErrors;
    }
}