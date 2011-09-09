namespace QuickMon
{
    partial class EditConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditConfig));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdTest = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIntegratedSec = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownCmndTimeOut = new System.Windows.Forms.NumericUpDown();
            this.lvwDatabases = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWarning = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderError = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdAddUpdateDB = new System.Windows.Forms.Button();
            this.errorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.warningNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cboDatabase = new System.Windows.Forms.ComboBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkAdUpdateEnabletimer = new System.Windows.Forms.Timer(this.components);
            this.okEnabledtimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCmndTimeOut)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(597, 317);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdTest
            // 
            this.cmdTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTest.Enabled = false;
            this.cmdTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTest.Location = new System.Drawing.Point(435, 317);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(75, 23);
            this.cmdTest.TabIndex = 10;
            this.cmdTest.Text = "Test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(516, 317);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 11;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sql Server\\Instance";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(143, 87);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(529, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.Location = new System.Drawing.Point(143, 12);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(529, 20);
            this.txtServer.TabIndex = 1;
            this.txtServer.TextChanged += new System.EventHandler(this.txtServer_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(143, 61);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(529, 20);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Username";
            // 
            // chkIntegratedSec
            // 
            this.chkIntegratedSec.AutoSize = true;
            this.chkIntegratedSec.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkIntegratedSec.Location = new System.Drawing.Point(143, 38);
            this.chkIntegratedSec.Name = "chkIntegratedSec";
            this.chkIntegratedSec.Size = new System.Drawing.Size(111, 17);
            this.chkIntegratedSec.TabIndex = 2;
            this.chkIntegratedSec.Text = "Integrated security";
            this.chkIntegratedSec.UseVisualStyleBackColor = true;
            this.chkIntegratedSec.CheckedChanged += new System.EventHandler(this.chkIntegratedSec_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Time out value";
            // 
            // numericUpDownCmndTimeOut
            // 
            this.numericUpDownCmndTimeOut.Location = new System.Drawing.Point(143, 113);
            this.numericUpDownCmndTimeOut.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericUpDownCmndTimeOut.Name = "numericUpDownCmndTimeOut";
            this.numericUpDownCmndTimeOut.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownCmndTimeOut.TabIndex = 8;
            this.numericUpDownCmndTimeOut.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // lvwDatabases
            // 
            this.lvwDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDatabases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderWarning,
            this.columnHeaderError});
            this.lvwDatabases.FullRowSelect = true;
            this.lvwDatabases.HideSelection = false;
            this.lvwDatabases.Location = new System.Drawing.Point(6, 49);
            this.lvwDatabases.Name = "lvwDatabases";
            this.lvwDatabases.Size = new System.Drawing.Size(568, 117);
            this.lvwDatabases.TabIndex = 7;
            this.lvwDatabases.UseCompatibleStateImageBehavior = false;
            this.lvwDatabases.View = System.Windows.Forms.View.Details;
            this.lvwDatabases.SelectedIndexChanged += new System.EventHandler(this.lvwDatabases_SelectedIndexChanged);
            this.lvwDatabases.Resize += new System.EventHandler(this.lvwDatabases_Resize);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 333;
            // 
            // columnHeaderWarning
            // 
            this.columnHeaderWarning.Text = "Warning size (MB)";
            this.columnHeaderWarning.Width = 115;
            // 
            // columnHeaderError
            // 
            this.columnHeaderError.Text = "Error size (MB)";
            this.columnHeaderError.Width = 94;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmdRemove);
            this.groupBox1.Controls.Add(this.cmdAddUpdateDB);
            this.groupBox1.Controls.Add(this.errorNumericUpDown);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.warningNumericUpDown);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboDatabase);
            this.groupBox1.Controls.Add(this.lblDatabase);
            this.groupBox1.Controls.Add(this.lvwDatabases);
            this.groupBox1.Location = new System.Drawing.Point(10, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 172);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database(s)";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(554, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "MB";
            // 
            // cmdRemove
            // 
            this.cmdRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemove.Enabled = false;
            this.cmdRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRemove.Location = new System.Drawing.Point(580, 49);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(75, 23);
            this.cmdRemove.TabIndex = 8;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdAddUpdateDB
            // 
            this.cmdAddUpdateDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddUpdateDB.Enabled = false;
            this.cmdAddUpdateDB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAddUpdateDB.Location = new System.Drawing.Point(581, 17);
            this.cmdAddUpdateDB.Name = "cmdAddUpdateDB";
            this.cmdAddUpdateDB.Size = new System.Drawing.Size(75, 23);
            this.cmdAddUpdateDB.TabIndex = 6;
            this.cmdAddUpdateDB.Text = "Add/Update";
            this.cmdAddUpdateDB.UseVisualStyleBackColor = true;
            this.cmdAddUpdateDB.Click += new System.EventHandler(this.cmdAddUpdateDB_Click);
            // 
            // errorNumericUpDown
            // 
            this.errorNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorNumericUpDown.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.errorNumericUpDown.Location = new System.Drawing.Point(477, 20);
            this.errorNumericUpDown.Maximum = new decimal(new int[] {
            1073741824,
            0,
            0,
            0});
            this.errorNumericUpDown.Name = "errorNumericUpDown";
            this.errorNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.errorNumericUpDown.TabIndex = 5;
            this.errorNumericUpDown.Value = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(398, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "MB, Error size:";
            // 
            // warningNumericUpDown
            // 
            this.warningNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.warningNumericUpDown.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.warningNumericUpDown.Location = new System.Drawing.Point(322, 20);
            this.warningNumericUpDown.Maximum = new decimal(new int[] {
            1073741824,
            0,
            0,
            0});
            this.warningNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.warningNumericUpDown.Name = "warningNumericUpDown";
            this.warningNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.warningNumericUpDown.TabIndex = 3;
            this.warningNumericUpDown.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Warning size:";
            // 
            // cboDatabase
            // 
            this.cboDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Location = new System.Drawing.Point(76, 19);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Size = new System.Drawing.Size(164, 21);
            this.cboDatabase.Sorted = true;
            this.cboDatabase.TabIndex = 1;
            this.cboDatabase.DropDown += new System.EventHandler(this.cboDatabase_DropDown);
            this.cboDatabase.TextChanged += new System.EventHandler(this.cboDatabase_TextChanged);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(10, 22);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(53, 13);
            this.lblDatabase.TabIndex = 0;
            this.lblDatabase.Text = "Database";
            this.lblDatabase.DoubleClick += new System.EventHandler(this.lblDatabase_DoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(216, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Sec";
            // 
            // checkAdUpdateEnabletimer
            // 
            this.checkAdUpdateEnabletimer.Interval = 200;
            this.checkAdUpdateEnabletimer.Tick += new System.EventHandler(this.checkAdUpdateEnabletimer_Tick);
            // 
            // okEnabledtimer
            // 
            this.okEnabledtimer.Interval = 200;
            this.okEnabledtimer.Tick += new System.EventHandler(this.okEnabledtimer_Tick);
            // 
            // EditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 352);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkIntegratedSec);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownCmndTimeOut);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdTest);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 390);
            this.Name = "EditConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Config";
            this.Load += new System.EventHandler(this.EditConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCmndTimeOut)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIntegratedSec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownCmndTimeOut;
        private System.Windows.Forms.ListView lvwDatabases;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdAddUpdateDB;
        private System.Windows.Forms.NumericUpDown errorNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown warningNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboDatabase;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderWarning;
        private System.Windows.Forms.ColumnHeader columnHeaderError;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer checkAdUpdateEnabletimer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer okEnabledtimer;
    }
}