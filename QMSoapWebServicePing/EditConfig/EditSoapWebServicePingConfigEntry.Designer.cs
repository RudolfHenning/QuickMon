namespace QuickMon
{
    partial class EditSoapWebServicePingConfigEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSoapWebServicePingConfigEntry));
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdTestAddress = new System.Windows.Forms.Button();
            this.txtServiceURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.txtMethodName = new System.Windows.Forms.TextBox();
            this.txtParameters = new System.Windows.Forms.TextBox();
            this.cboResultType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboCheckType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtErrorCustomValue2 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cboErrorCustomValue1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Parameters(CSV)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Method";
            // 
            // txtServiceName
            // 
            this.txtServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServiceName.Location = new System.Drawing.Point(113, 38);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(376, 20);
            this.txtServiceName.TabIndex = 3;
            this.txtServiceName.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Service name";
            // 
            // cmdTestAddress
            // 
            this.cmdTestAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTestAddress.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTestAddress.Location = new System.Drawing.Point(252, 183);
            this.cmdTestAddress.Name = "cmdTestAddress";
            this.cmdTestAddress.Size = new System.Drawing.Size(75, 23);
            this.cmdTestAddress.TabIndex = 16;
            this.cmdTestAddress.Text = "Test";
            this.cmdTestAddress.UseVisualStyleBackColor = true;
            this.cmdTestAddress.Click += new System.EventHandler(this.cmdTestAddress_Click);
            // 
            // txtServiceURL
            // 
            this.txtServiceURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServiceURL.Location = new System.Drawing.Point(113, 12);
            this.txtServiceURL.Name = "txtServiceURL";
            this.txtServiceURL.Size = new System.Drawing.Size(376, 20);
            this.txtServiceURL.TabIndex = 1;
            this.txtServiceURL.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service URL";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(414, 183);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 18;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(333, 183);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 17;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtMethodName
            // 
            this.txtMethodName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMethodName.Location = new System.Drawing.Point(113, 63);
            this.txtMethodName.Name = "txtMethodName";
            this.txtMethodName.Size = new System.Drawing.Size(376, 20);
            this.txtMethodName.TabIndex = 5;
            this.txtMethodName.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // txtParameters
            // 
            this.txtParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParameters.Location = new System.Drawing.Point(113, 89);
            this.txtParameters.Name = "txtParameters";
            this.txtParameters.Size = new System.Drawing.Size(376, 20);
            this.txtParameters.TabIndex = 7;
            this.txtParameters.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // cboResultType
            // 
            this.cboResultType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResultType.FormattingEnabled = true;
            this.cboResultType.Items.AddRange(new object[] {
            "Check Availability Only",
            "No/Empty Value",
            "Specified Value",
            "Values in range",
            "Dataset",
            "String array"});
            this.cboResultType.Location = new System.Drawing.Point(333, 115);
            this.cboResultType.Name = "cboResultType";
            this.cboResultType.Size = new System.Drawing.Size(156, 21);
            this.cboResultType.TabIndex = 11;
            this.toolTip1.SetToolTip(this.cboResultType, resources.GetString("cboResultType.ToolTip"));
            this.cboResultType.SelectedIndexChanged += new System.EventHandler(this.cboResultType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(258, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Result type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Custom value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Check type";
            // 
            // cboCheckType
            // 
            this.cboCheckType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheckType.FormattingEnabled = true;
            this.cboCheckType.Items.AddRange(new object[] {
            "Success",
            "Failure"});
            this.cboCheckType.Location = new System.Drawing.Point(113, 115);
            this.cboCheckType.Name = "cboCheckType";
            this.cboCheckType.Size = new System.Drawing.Size(89, 21);
            this.cboCheckType.TabIndex = 9;
            this.cboCheckType.SelectedIndexChanged += new System.EventHandler(this.cboCheckType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(267, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Value 2";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtErrorCustomValue2
            // 
            this.txtErrorCustomValue2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrorCustomValue2.Location = new System.Drawing.Point(333, 142);
            this.txtErrorCustomValue2.Name = "txtErrorCustomValue2";
            this.txtErrorCustomValue2.Size = new System.Drawing.Size(116, 20);
            this.txtErrorCustomValue2.TabIndex = 15;
            this.txtErrorCustomValue2.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // cboErrorCustomValue1
            // 
            this.cboErrorCustomValue1.FormattingEnabled = true;
            this.cboErrorCustomValue1.Items.AddRange(new object[] {
            "[Count]",
            "[FirstValue]",
            "[LastValue]"});
            this.cboErrorCustomValue1.Location = new System.Drawing.Point(113, 142);
            this.cboErrorCustomValue1.Name = "cboErrorCustomValue1";
            this.cboErrorCustomValue1.Size = new System.Drawing.Size(154, 21);
            this.cboErrorCustomValue1.TabIndex = 13;
            this.cboErrorCustomValue1.SelectedIndexChanged += new System.EventHandler(this.cboCheckType_SelectedIndexChanged);
            this.cboErrorCustomValue1.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // EditSoapWebServicePingConfigEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 218);
            this.Controls.Add(this.cboErrorCustomValue1);
            this.Controls.Add(this.txtErrorCustomValue2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboCheckType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboResultType);
            this.Controls.Add(this.txtParameters);
            this.Controls.Add(this.txtMethodName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtServiceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdTestAddress);
            this.Controls.Add(this.txtServiceURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSoapWebServicePingConfigEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Soap Web service ping Entry";
            this.Shown += new System.EventHandler(this.EditSoapWebServicePingConfigEntry_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdTestAddress;
        private System.Windows.Forms.TextBox txtServiceURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TextBox txtMethodName;
        private System.Windows.Forms.TextBox txtParameters;
        private System.Windows.Forms.ComboBox cboResultType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboCheckType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtErrorCustomValue2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cboErrorCustomValue1;
    }
}