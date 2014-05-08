namespace QuickMon
{
    partial class EditTableSizeEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTableSizeEntry));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDatabase = new System.Windows.Forms.ComboBox();
            this.lvwTables = new System.Windows.Forms.ListView();
            this.tableColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWarning = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderError = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.errorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.warningNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cmdUpdateTable = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIntegratedSec = new System.Windows.Forms.CheckBox();
            this.cmdLoadDatabases = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(401, 327);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 17;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(320, 327);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 16;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sql Server\\Instance";
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.Location = new System.Drawing.Point(142, 12);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(286, 20);
            this.txtServer.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Database";
            // 
            // cboDatabase
            // 
            this.cboDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Location = new System.Drawing.Point(142, 113);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Size = new System.Drawing.Size(286, 21);
            this.cboDatabase.TabIndex = 9;
            this.cboDatabase.SelectedIndexChanged += new System.EventHandler(this.cboDatabase_SelectedIndexChanged);
            // 
            // lvwTables
            // 
            this.lvwTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTables.CheckBoxes = true;
            this.lvwTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tableColumnHeader,
            this.columnHeaderWarning,
            this.columnHeaderError,
            this.columnHeaderCount});
            this.lvwTables.FullRowSelect = true;
            this.lvwTables.HideSelection = false;
            this.lvwTables.Location = new System.Drawing.Point(4, 140);
            this.lvwTables.Name = "lvwTables";
            this.lvwTables.Size = new System.Drawing.Size(477, 125);
            this.lvwTables.TabIndex = 10;
            this.lvwTables.UseCompatibleStateImageBehavior = false;
            this.lvwTables.View = System.Windows.Forms.View.Details;
            this.lvwTables.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwTables_ItemChecked);
            this.lvwTables.SelectedIndexChanged += new System.EventHandler(this.lvwTables_SelectedIndexChanged);
            // 
            // tableColumnHeader
            // 
            this.tableColumnHeader.Text = "Table";
            this.tableColumnHeader.Width = 164;
            // 
            // columnHeaderWarning
            // 
            this.columnHeaderWarning.Text = "Warning";
            this.columnHeaderWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderWarning.Width = 86;
            // 
            // columnHeaderError
            // 
            this.columnHeaderError.Text = "Error";
            this.columnHeaderError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderError.Width = 84;
            // 
            // columnHeaderCount
            // 
            this.columnHeaderCount.Text = "Current count";
            this.columnHeaderCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderCount.Width = 88;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Error";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Warning";
            // 
            // errorNumericUpDown
            // 
            this.errorNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.errorNumericUpDown.Location = new System.Drawing.Point(142, 297);
            this.errorNumericUpDown.Maximum = new decimal(new int[] {
            1073741824,
            0,
            0,
            0});
            this.errorNumericUpDown.Name = "errorNumericUpDown";
            this.errorNumericUpDown.Size = new System.Drawing.Size(93, 20);
            this.errorNumericUpDown.TabIndex = 14;
            this.errorNumericUpDown.ValueChanged += new System.EventHandler(this.errorNumericUpDown_ValueChanged);
            // 
            // warningNumericUpDown
            // 
            this.warningNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.warningNumericUpDown.Location = new System.Drawing.Point(142, 271);
            this.warningNumericUpDown.Maximum = new decimal(new int[] {
            1073741824,
            0,
            0,
            0});
            this.warningNumericUpDown.Name = "warningNumericUpDown";
            this.warningNumericUpDown.Size = new System.Drawing.Size(93, 20);
            this.warningNumericUpDown.TabIndex = 12;
            this.warningNumericUpDown.ValueChanged += new System.EventHandler(this.warningNumericUpDown_ValueChanged);
            // 
            // cmdUpdateTable
            // 
            this.cmdUpdateTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdUpdateTable.Enabled = false;
            this.cmdUpdateTable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdUpdateTable.Location = new System.Drawing.Point(252, 283);
            this.cmdUpdateTable.Name = "cmdUpdateTable";
            this.cmdUpdateTable.Size = new System.Drawing.Size(67, 23);
            this.cmdUpdateTable.TabIndex = 15;
            this.cmdUpdateTable.Text = "Update";
            this.cmdUpdateTable.UseVisualStyleBackColor = true;
            this.cmdUpdateTable.Click += new System.EventHandler(this.cmdUpdateTable_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(142, 87);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(286, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(142, 61);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(286, 20);
            this.txtUserName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Username";
            // 
            // chkIntegratedSec
            // 
            this.chkIntegratedSec.AutoSize = true;
            this.chkIntegratedSec.Checked = true;
            this.chkIntegratedSec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIntegratedSec.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkIntegratedSec.Location = new System.Drawing.Point(142, 38);
            this.chkIntegratedSec.Name = "chkIntegratedSec";
            this.chkIntegratedSec.Size = new System.Drawing.Size(112, 17);
            this.chkIntegratedSec.TabIndex = 2;
            this.chkIntegratedSec.Text = "Integrated security";
            this.chkIntegratedSec.UseVisualStyleBackColor = true;
            this.chkIntegratedSec.CheckedChanged += new System.EventHandler(this.chkIntegratedSec_CheckedChanged);
            // 
            // cmdLoadDatabases
            // 
            this.cmdLoadDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoadDatabases.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLoadDatabases.Location = new System.Drawing.Point(434, 85);
            this.cmdLoadDatabases.Name = "cmdLoadDatabases";
            this.cmdLoadDatabases.Size = new System.Drawing.Size(47, 23);
            this.cmdLoadDatabases.TabIndex = 7;
            this.cmdLoadDatabases.Text = "Load";
            this.cmdLoadDatabases.UseVisualStyleBackColor = true;
            this.cmdLoadDatabases.Click += new System.EventHandler(this.cmdLoadDatabases_Click);
            // 
            // EditTableSizeEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(488, 362);
            this.Controls.Add(this.cmdLoadDatabases);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkIntegratedSec);
            this.Controls.Add(this.cmdUpdateTable);
            this.Controls.Add(this.errorNumericUpDown);
            this.Controls.Add(this.warningNumericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lvwTables);
            this.Controls.Add(this.cboDatabase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "EditTableSizeEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Table Size Entry";
            this.Shown += new System.EventHandler(this.EditTableSizeEntry_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDatabase;
        private System.Windows.Forms.ListView lvwTables;
        private System.Windows.Forms.ColumnHeader tableColumnHeader;
        private System.Windows.Forms.ColumnHeader columnHeaderWarning;
        private System.Windows.Forms.ColumnHeader columnHeaderError;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown errorNumericUpDown;
        private System.Windows.Forms.NumericUpDown warningNumericUpDown;
        private System.Windows.Forms.Button cmdUpdateTable;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIntegratedSec;
        private System.Windows.Forms.Button cmdLoadDatabases;
        private System.Windows.Forms.ColumnHeader columnHeaderCount;
    }
}