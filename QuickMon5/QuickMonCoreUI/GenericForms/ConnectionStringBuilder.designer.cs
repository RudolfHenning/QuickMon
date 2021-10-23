namespace QuickMon.UI
{
    partial class ConnectionStringBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionStringBuilder));
            this.chkTrustedConnection = new System.Windows.Forms.CheckBox();
            this.chkPersistSecurityInfo = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtInitialCatalogue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdReadFromConnString = new System.Windows.Forms.Button();
            this.cmdConstructConnString = new System.Windows.Forms.Button();
            this.llblConnStrTips = new System.Windows.Forms.LinkLabel();
            this.label16 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.cboProvider = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkTrustedConnection
            // 
            this.chkTrustedConnection.AutoSize = true;
            this.chkTrustedConnection.Checked = true;
            this.chkTrustedConnection.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkTrustedConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTrustedConnection.Location = new System.Drawing.Point(343, 155);
            this.chkTrustedConnection.Name = "chkTrustedConnection";
            this.chkTrustedConnection.Size = new System.Drawing.Size(116, 17);
            this.chkTrustedConnection.TabIndex = 16;
            this.chkTrustedConnection.Text = "Trusted Connection";
            this.chkTrustedConnection.ThreeState = true;
            this.chkTrustedConnection.UseVisualStyleBackColor = true;
            // 
            // chkPersistSecurityInfo
            // 
            this.chkPersistSecurityInfo.AutoSize = true;
            this.chkPersistSecurityInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPersistSecurityInfo.Location = new System.Drawing.Point(129, 155);
            this.chkPersistSecurityInfo.Name = "chkPersistSecurityInfo";
            this.chkPersistSecurityInfo.Size = new System.Drawing.Size(116, 17);
            this.chkPersistSecurityInfo.TabIndex = 15;
            this.chkPersistSecurityInfo.Text = "Persist Security Info";
            this.chkPersistSecurityInfo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Server";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(129, 129);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(147, 20);
            this.txtServer.TabIndex = 12;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(343, 129);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(147, 20);
            this.txtDatabase.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(284, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Database";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(415, 309);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 22;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightSalmon;
            this.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(496, 309);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 23;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // txtInitialCatalogue
            // 
            this.txtInitialCatalogue.Location = new System.Drawing.Point(129, 103);
            this.txtInitialCatalogue.Name = "txtInitialCatalogue";
            this.txtInitialCatalogue.Size = new System.Drawing.Size(147, 20);
            this.txtInitialCatalogue.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Initial catalogue";
            // 
            // cmdReadFromConnString
            // 
            this.cmdReadFromConnString.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdReadFromConnString.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdReadFromConnString.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdReadFromConnString.Location = new System.Drawing.Point(200, 184);
            this.cmdReadFromConnString.Name = "cmdReadFromConnString";
            this.cmdReadFromConnString.Size = new System.Drawing.Size(183, 23);
            this.cmdReadFromConnString.TabIndex = 18;
            this.cmdReadFromConnString.Text = "Read from connection string /\\";
            this.cmdReadFromConnString.UseVisualStyleBackColor = true;
            this.cmdReadFromConnString.Click += new System.EventHandler(this.cmdReadFromConnString_Click);
            // 
            // cmdConstructConnString
            // 
            this.cmdConstructConnString.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdConstructConnString.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdConstructConnString.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdConstructConnString.Location = new System.Drawing.Point(11, 184);
            this.cmdConstructConnString.Name = "cmdConstructConnString";
            this.cmdConstructConnString.Size = new System.Drawing.Size(183, 23);
            this.cmdConstructConnString.TabIndex = 17;
            this.cmdConstructConnString.Text = "Construct connection string \\/";
            this.cmdConstructConnString.UseVisualStyleBackColor = true;
            this.cmdConstructConnString.Click += new System.EventHandler(this.cmdConstructConnString_Click);
            // 
            // llblConnStrTips
            // 
            this.llblConnStrTips.AutoSize = true;
            this.llblConnStrTips.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblConnStrTips.Location = new System.Drawing.Point(180, 210);
            this.llblConnStrTips.Name = "llblConnStrTips";
            this.llblConnStrTips.Size = new System.Drawing.Size(194, 13);
            this.llblConnStrTips.TabIndex = 20;
            this.llblConnStrTips.TabStop = true;
            this.llblConnStrTips.Text = "See connectionstrings.com for help/tips";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 210);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "Connection string";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnectionString.Location = new System.Drawing.Point(26, 226);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConnectionString.Size = new System.Drawing.Size(549, 77);
            this.txtConnectionString.TabIndex = 21;
            // 
            // cboProvider
            // 
            this.cboProvider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProvider.FormattingEnabled = true;
            this.cboProvider.Items.AddRange(new object[] {
            "Microsoft.Jet.OLEDB.4.0",
            "sqloledb",
            "msdaora"});
            this.cboProvider.Location = new System.Drawing.Point(129, 50);
            this.cboProvider.Name = "cboProvider";
            this.cboProvider.Size = new System.Drawing.Size(442, 21);
            this.cboProvider.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(129, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(136, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "e.g. c:\\Data\\SomeFile.mdb";
            // 
            // txtDataSource
            // 
            this.txtDataSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataSource.Location = new System.Drawing.Point(129, 11);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(442, 20);
            this.txtDataSource.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data source";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(129, 77);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(147, 20);
            this.txtUserName.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(343, 77);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(147, 20);
            this.txtPassword.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Provider";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // ConnectionStringBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 342);
            this.Controls.Add(this.chkTrustedConnection);
            this.Controls.Add(this.chkPersistSecurityInfo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.txtInitialCatalogue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdReadFromConnString);
            this.Controls.Add(this.cmdConstructConnString);
            this.Controls.Add(this.llblConnStrTips);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.cboProvider);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtDataSource);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 380);
            this.Name = "ConnectionStringBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection String Builder";
            this.Load += new System.EventHandler(this.ConnectionStringBuilder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkTrustedConnection;
        private System.Windows.Forms.CheckBox chkPersistSecurityInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox txtInitialCatalogue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdReadFromConnString;
        private System.Windows.Forms.Button cmdConstructConnString;
        private System.Windows.Forms.LinkLabel llblConnStrTips;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.ComboBox cboProvider;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}