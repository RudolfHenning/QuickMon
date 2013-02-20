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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditConfig));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCurrentStateFieldName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPreviousStateFieldName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCategoryFieldName = new System.Windows.Forms.TextBox();
            this.lblMessageFieldName = new System.Windows.Forms.Label();
            this.txtDetailsFieldName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCmndValue = new System.Windows.Forms.TextBox();
            this.lblAlertField = new System.Windows.Forms.Label();
            this.txtAlertFieldName = new System.Windows.Forms.TextBox();
            this.chkUseSP = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownCmndTimeOut = new System.Windows.Forms.NumericUpDown();
            this.cmdTest = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageConnection = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIntegratedSec = new System.Windows.Forms.CheckBox();
            this.tabPageCommand = new System.Windows.Forms.TabPage();
            this.txtCollectorType = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPageViewer = new System.Windows.Forms.TabPage();
            this.txtDateTimeFieldName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtViewerName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkUseSP2 = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCmndTimeOut)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageConnection.SuspendLayout();
            this.tabPageCommand.SuspendLayout();
            this.tabPageViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(561, 297);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(480, 297);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(11, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(613, 32);
            this.label12.TabIndex = 17;
            this.label12.Text = "Please remember that the field names used in the logging tab will be used to quer" +
    "y the database in the details view window. Thus if you use a stored proc the par" +
    "ameter names must match.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Current state (tinyint)";
            // 
            // txtCurrentStateFieldName
            // 
            this.txtCurrentStateFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentStateFieldName.Location = new System.Drawing.Point(243, 184);
            this.txtCurrentStateFieldName.Name = "txtCurrentStateFieldName";
            this.txtCurrentStateFieldName.Size = new System.Drawing.Size(381, 20);
            this.txtCurrentStateFieldName.TabIndex = 13;
            this.txtCurrentStateFieldName.Text = "CurrentState";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Previous state (tinyint)";
            // 
            // txtPreviousStateFieldName
            // 
            this.txtPreviousStateFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPreviousStateFieldName.Location = new System.Drawing.Point(243, 158);
            this.txtPreviousStateFieldName.Name = "txtPreviousStateFieldName";
            this.txtPreviousStateFieldName.Size = new System.Drawing.Size(381, 20);
            this.txtPreviousStateFieldName.TabIndex = 11;
            this.txtPreviousStateFieldName.Text = "PreviousState";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Stored proc parameter/Table field names";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Category (nvarchar(255))";
            // 
            // txtCategoryFieldName
            // 
            this.txtCategoryFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategoryFieldName.Location = new System.Drawing.Point(243, 132);
            this.txtCategoryFieldName.Name = "txtCategoryFieldName";
            this.txtCategoryFieldName.Size = new System.Drawing.Size(381, 20);
            this.txtCategoryFieldName.TabIndex = 9;
            this.txtCategoryFieldName.Text = "Category";
            // 
            // lblMessageFieldName
            // 
            this.lblMessageFieldName.AutoSize = true;
            this.lblMessageFieldName.Location = new System.Drawing.Point(26, 213);
            this.lblMessageFieldName.Name = "lblMessageFieldName";
            this.lblMessageFieldName.Size = new System.Drawing.Size(113, 13);
            this.lblMessageFieldName.TabIndex = 14;
            this.lblMessageFieldName.Text = "Details (varchar(MAX))";
            // 
            // txtDetailsFieldName
            // 
            this.txtDetailsFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetailsFieldName.Location = new System.Drawing.Point(243, 210);
            this.txtDetailsFieldName.Name = "txtDetailsFieldName";
            this.txtDetailsFieldName.Size = new System.Drawing.Size(381, 20);
            this.txtDetailsFieldName.TabIndex = 15;
            this.txtDetailsFieldName.Text = "Details";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "SProc/table name";
            // 
            // txtCmndValue
            // 
            this.txtCmndValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmndValue.Location = new System.Drawing.Point(143, 29);
            this.txtCmndValue.Name = "txtCmndValue";
            this.txtCmndValue.Size = new System.Drawing.Size(481, 20);
            this.txtCmndValue.TabIndex = 2;
            this.txtCmndValue.Text = "InsertMessage";
            // 
            // lblAlertField
            // 
            this.lblAlertField.AutoSize = true;
            this.lblAlertField.Location = new System.Drawing.Point(26, 83);
            this.lblAlertField.Name = "lblAlertField";
            this.lblAlertField.Size = new System.Drawing.Size(87, 13);
            this.lblAlertField.TabIndex = 4;
            this.lblAlertField.Text = "Alert type (tinyint)";
            // 
            // txtAlertFieldName
            // 
            this.txtAlertFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlertFieldName.Location = new System.Drawing.Point(243, 80);
            this.txtAlertFieldName.Name = "txtAlertFieldName";
            this.txtAlertFieldName.Size = new System.Drawing.Size(381, 20);
            this.txtAlertFieldName.TabIndex = 5;
            this.txtAlertFieldName.Text = "AlertLevel";
            // 
            // chkUseSP
            // 
            this.chkUseSP.AutoSize = true;
            this.chkUseSP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkUseSP.Location = new System.Drawing.Point(13, 6);
            this.chkUseSP.Name = "chkUseSP";
            this.chkUseSP.Size = new System.Drawing.Size(217, 17);
            this.chkUseSP.TabIndex = 0;
            this.chkUseSP.Text = "Use stored procuredure (Recommended)";
            this.chkUseSP.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Sec";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Time out value";
            // 
            // numericUpDownCmndTimeOut
            // 
            this.numericUpDownCmndTimeOut.Location = new System.Drawing.Point(140, 135);
            this.numericUpDownCmndTimeOut.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericUpDownCmndTimeOut.Name = "numericUpDownCmndTimeOut";
            this.numericUpDownCmndTimeOut.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownCmndTimeOut.TabIndex = 1;
            this.numericUpDownCmndTimeOut.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // cmdTest
            // 
            this.cmdTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTest.Location = new System.Drawing.Point(399, 297);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(75, 23);
            this.cmdTest.TabIndex = 1;
            this.cmdTest.Text = "Test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageConnection);
            this.tabControl1.Controls.Add(this.tabPageCommand);
            this.tabControl1.Controls.Add(this.tabPageViewer);
            this.tabControl1.Location = new System.Drawing.Point(6, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(638, 266);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageConnection
            // 
            this.tabPageConnection.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageConnection.Controls.Add(this.label1);
            this.tabPageConnection.Controls.Add(this.txtPassword);
            this.tabPageConnection.Controls.Add(this.txtServer);
            this.tabPageConnection.Controls.Add(this.label4);
            this.tabPageConnection.Controls.Add(this.label2);
            this.tabPageConnection.Controls.Add(this.txtUserName);
            this.tabPageConnection.Controls.Add(this.txtDatabase);
            this.tabPageConnection.Controls.Add(this.label3);
            this.tabPageConnection.Controls.Add(this.chkIntegratedSec);
            this.tabPageConnection.Controls.Add(this.label5);
            this.tabPageConnection.Controls.Add(this.numericUpDownCmndTimeOut);
            this.tabPageConnection.Controls.Add(this.label6);
            this.tabPageConnection.Location = new System.Drawing.Point(4, 22);
            this.tabPageConnection.Name = "tabPageConnection";
            this.tabPageConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConnection.Size = new System.Drawing.Size(630, 240);
            this.tabPageConnection.TabIndex = 0;
            this.tabPageConnection.Text = "Connection details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Sql Server\\Instance";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(140, 109);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(470, 20);
            this.txtPassword.TabIndex = 17;
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.Location = new System.Drawing.Point(140, 8);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(470, 20);
            this.txtServer.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Database";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(140, 83);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(470, 20);
            this.txtUserName.TabIndex = 15;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabase.Location = new System.Drawing.Point(140, 34);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(470, 20);
            this.txtDatabase.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Username";
            // 
            // chkIntegratedSec
            // 
            this.chkIntegratedSec.AutoSize = true;
            this.chkIntegratedSec.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkIntegratedSec.Location = new System.Drawing.Point(140, 60);
            this.chkIntegratedSec.Name = "chkIntegratedSec";
            this.chkIntegratedSec.Size = new System.Drawing.Size(112, 17);
            this.chkIntegratedSec.TabIndex = 13;
            this.chkIntegratedSec.Text = "Integrated security";
            this.chkIntegratedSec.UseVisualStyleBackColor = true;
            this.chkIntegratedSec.CheckedChanged += new System.EventHandler(this.chkIntegratedSec_CheckedChanged);
            // 
            // tabPageCommand
            // 
            this.tabPageCommand.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPageCommand.Controls.Add(this.txtCollectorType);
            this.tabPageCommand.Controls.Add(this.label15);
            this.tabPageCommand.Controls.Add(this.chkUseSP);
            this.tabPageCommand.Controls.Add(this.label11);
            this.tabPageCommand.Controls.Add(this.txtAlertFieldName);
            this.tabPageCommand.Controls.Add(this.txtCurrentStateFieldName);
            this.tabPageCommand.Controls.Add(this.lblAlertField);
            this.tabPageCommand.Controls.Add(this.label10);
            this.tabPageCommand.Controls.Add(this.txtCmndValue);
            this.tabPageCommand.Controls.Add(this.txtPreviousStateFieldName);
            this.tabPageCommand.Controls.Add(this.label7);
            this.tabPageCommand.Controls.Add(this.label9);
            this.tabPageCommand.Controls.Add(this.txtDetailsFieldName);
            this.tabPageCommand.Controls.Add(this.label8);
            this.tabPageCommand.Controls.Add(this.lblMessageFieldName);
            this.tabPageCommand.Controls.Add(this.txtCategoryFieldName);
            this.tabPageCommand.Location = new System.Drawing.Point(4, 22);
            this.tabPageCommand.Name = "tabPageCommand";
            this.tabPageCommand.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommand.Size = new System.Drawing.Size(630, 240);
            this.tabPageCommand.TabIndex = 1;
            this.tabPageCommand.Text = "Logging details";
            // 
            // txtCollectorType
            // 
            this.txtCollectorType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCollectorType.Location = new System.Drawing.Point(243, 106);
            this.txtCollectorType.Name = "txtCollectorType";
            this.txtCollectorType.Size = new System.Drawing.Size(381, 20);
            this.txtCollectorType.TabIndex = 7;
            this.txtCollectorType.Text = "CollectorType";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(26, 109);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(146, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Collector type (nvarchar(255))";
            // 
            // tabPageViewer
            // 
            this.tabPageViewer.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageViewer.Controls.Add(this.txtDateTimeFieldName);
            this.tabPageViewer.Controls.Add(this.label14);
            this.tabPageViewer.Controls.Add(this.label12);
            this.tabPageViewer.Controls.Add(this.txtViewerName);
            this.tabPageViewer.Controls.Add(this.label13);
            this.tabPageViewer.Controls.Add(this.chkUseSP2);
            this.tabPageViewer.Location = new System.Drawing.Point(4, 22);
            this.tabPageViewer.Name = "tabPageViewer";
            this.tabPageViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageViewer.Size = new System.Drawing.Size(630, 240);
            this.tabPageViewer.TabIndex = 2;
            this.tabPageViewer.Text = "Viewer";
            // 
            // txtDateTimeFieldName
            // 
            this.txtDateTimeFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateTimeFieldName.Location = new System.Drawing.Point(243, 87);
            this.txtDateTimeFieldName.Name = "txtDateTimeFieldName";
            this.txtDateTimeFieldName.Size = new System.Drawing.Size(381, 20);
            this.txtDateTimeFieldName.TabIndex = 19;
            this.txtDateTimeFieldName.Text = "InsertDate";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "Date time field (DateTime)";
            // 
            // txtViewerName
            // 
            this.txtViewerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtViewerName.Location = new System.Drawing.Point(143, 29);
            this.txtViewerName.Name = "txtViewerName";
            this.txtViewerName.Size = new System.Drawing.Size(481, 20);
            this.txtViewerName.TabIndex = 7;
            this.txtViewerName.Text = "QueryMessages";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "SProc/table name";
            // 
            // chkUseSP2
            // 
            this.chkUseSP2.AutoSize = true;
            this.chkUseSP2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkUseSP2.Location = new System.Drawing.Point(13, 6);
            this.chkUseSP2.Name = "chkUseSP2";
            this.chkUseSP2.Size = new System.Drawing.Size(217, 17);
            this.chkUseSP2.TabIndex = 4;
            this.chkUseSP2.Text = "Use stored procuredure (Recommended)";
            this.chkUseSP2.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 302);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(290, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "Tip: see QuickMon.sql example sql script to setup database.";
            // 
            // EditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(648, 332);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdTest);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Config";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCmndTimeOut)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageConnection.ResumeLayout(false);
            this.tabPageConnection.PerformLayout();
            this.tabPageCommand.ResumeLayout(false);
            this.tabPageCommand.PerformLayout();
            this.tabPageViewer.ResumeLayout(false);
            this.tabPageViewer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownCmndTimeOut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkUseSP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCmndValue;
        private System.Windows.Forms.Label lblAlertField;
        private System.Windows.Forms.TextBox txtAlertFieldName;
        private System.Windows.Forms.Label lblMessageFieldName;
        private System.Windows.Forms.TextBox txtDetailsFieldName;
        private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCurrentStateFieldName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPreviousStateFieldName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCategoryFieldName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIntegratedSec;
        private System.Windows.Forms.TabPage tabPageCommand;
        private System.Windows.Forms.TabPage tabPageViewer;
        private System.Windows.Forms.CheckBox chkUseSP2;
        private System.Windows.Forms.TextBox txtViewerName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDateTimeFieldName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCollectorType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}