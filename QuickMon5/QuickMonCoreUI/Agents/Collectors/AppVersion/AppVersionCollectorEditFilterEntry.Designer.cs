
namespace QuickMon.UI
{
    partial class AppVersionCollectorEditFilterEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppVersionCollectorEditFilterEntry));
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.txtExpectedVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkFirstValidPath = new System.Windows.Forms.CheckBox();
            this.txtApplicationPaths = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optProductVersion = new System.Windows.Forms.RadioButton();
            this.optFileVersion = new System.Windows.Forms.RadioButton();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkVerifyOnOK = new System.Windows.Forms.CheckBox();
            this.cmdTest = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optDisplayFormatRAW = new System.Windows.Forms.RadioButton();
            this.optDisplayFormatMMB = new System.Windows.Forms.RadioButton();
            this.optDisplayFormatMM = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowse.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBrowse.Location = new System.Drawing.Point(542, 91);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(43, 23);
            this.cmdBrowse.TabIndex = 6;
            this.cmdBrowse.Text = "- - -";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // txtExpectedVersion
            // 
            this.txtExpectedVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpectedVersion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtExpectedVersion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtExpectedVersion.Location = new System.Drawing.Point(107, 252);
            this.txtExpectedVersion.Name = "txtExpectedVersion";
            this.txtExpectedVersion.Size = new System.Drawing.Size(477, 20);
            this.txtExpectedVersion.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Expected version";
            // 
            // chkFirstValidPath
            // 
            this.chkFirstValidPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkFirstValidPath.AutoSize = true;
            this.chkFirstValidPath.Checked = true;
            this.chkFirstValidPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFirstValidPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkFirstValidPath.Location = new System.Drawing.Point(114, 229);
            this.chkFirstValidPath.Name = "chkFirstValidPath";
            this.chkFirstValidPath.Size = new System.Drawing.Size(110, 17);
            this.chkFirstValidPath.TabIndex = 7;
            this.chkFirstValidPath.Text = "Use first valid path";
            this.chkFirstValidPath.UseVisualStyleBackColor = true;
            // 
            // txtApplicationPaths
            // 
            this.txtApplicationPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationPaths.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtApplicationPaths.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtApplicationPaths.Location = new System.Drawing.Point(108, 88);
            this.txtApplicationPaths.Multiline = true;
            this.txtApplicationPaths.Name = "txtApplicationPaths";
            this.txtApplicationPaths.Size = new System.Drawing.Size(428, 135);
            this.txtApplicationPaths.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Application path(s)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optProductVersion);
            this.groupBox1.Controls.Add(this.optFileVersion);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 44);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Version type";
            // 
            // optProductVersion
            // 
            this.optProductVersion.AutoSize = true;
            this.optProductVersion.Checked = true;
            this.optProductVersion.Location = new System.Drawing.Point(13, 16);
            this.optProductVersion.Name = "optProductVersion";
            this.optProductVersion.Size = new System.Drawing.Size(99, 17);
            this.optProductVersion.TabIndex = 0;
            this.optProductVersion.TabStop = true;
            this.optProductVersion.Text = "Product version";
            this.optProductVersion.UseVisualStyleBackColor = true;
            // 
            // optFileVersion
            // 
            this.optFileVersion.AutoSize = true;
            this.optFileVersion.Location = new System.Drawing.Point(118, 16);
            this.optFileVersion.Name = "optFileVersion";
            this.optFileVersion.Size = new System.Drawing.Size(78, 17);
            this.optFileVersion.TabIndex = 1;
            this.optFileVersion.Text = "File version";
            this.optFileVersion.UseVisualStyleBackColor = true;
            // 
            // txtAppName
            // 
            this.txtAppName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAppName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtAppName.Location = new System.Drawing.Point(108, 12);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(477, 20);
            this.txtAppName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application name";
            // 
            // chkVerifyOnOK
            // 
            this.chkVerifyOnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVerifyOnOK.AutoSize = true;
            this.chkVerifyOnOK.Checked = true;
            this.chkVerifyOnOK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerifyOnOK.Location = new System.Drawing.Point(218, 282);
            this.chkVerifyOnOK.Name = "chkVerifyOnOK";
            this.chkVerifyOnOK.Size = new System.Drawing.Size(123, 17);
            this.chkVerifyOnOK.TabIndex = 10;
            this.chkVerifyOnOK.Text = "Test on clicking \'OK\'";
            this.chkVerifyOnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVerifyOnOK.UseVisualStyleBackColor = true;
            // 
            // cmdTest
            // 
            this.cmdTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTest.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTest.Location = new System.Drawing.Point(348, 278);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(75, 23);
            this.cmdTest.TabIndex = 11;
            this.cmdTest.Text = "Test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightSalmon;
            this.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(510, 278);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 13;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(429, 278);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 12;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.optDisplayFormatMM);
            this.groupBox2.Controls.Add(this.optDisplayFormatRAW);
            this.groupBox2.Controls.Add(this.optDisplayFormatMMB);
            this.groupBox2.Location = new System.Drawing.Point(230, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 44);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Display format";
            // 
            // optDisplayFormatRAW
            // 
            this.optDisplayFormatRAW.AutoSize = true;
            this.optDisplayFormatRAW.Checked = true;
            this.optDisplayFormatRAW.Location = new System.Drawing.Point(13, 16);
            this.optDisplayFormatRAW.Name = "optDisplayFormatRAW";
            this.optDisplayFormatRAW.Size = new System.Drawing.Size(51, 17);
            this.optDisplayFormatRAW.TabIndex = 0;
            this.optDisplayFormatRAW.TabStop = true;
            this.optDisplayFormatRAW.Text = "RAW";
            this.optDisplayFormatRAW.UseVisualStyleBackColor = true;
            // 
            // optDisplayFormatMMB
            // 
            this.optDisplayFormatMMB.AutoSize = true;
            this.optDisplayFormatMMB.Location = new System.Drawing.Point(70, 16);
            this.optDisplayFormatMMB.Name = "optDisplayFormatMMB";
            this.optDisplayFormatMMB.Size = new System.Drawing.Size(142, 17);
            this.optDisplayFormatMMB.TabIndex = 1;
            this.optDisplayFormatMMB.Text = "<Major>.<Minor>.<Build>";
            this.optDisplayFormatMMB.UseVisualStyleBackColor = true;
            // 
            // optDisplayFormatMM
            // 
            this.optDisplayFormatMM.AutoSize = true;
            this.optDisplayFormatMM.Location = new System.Drawing.Point(218, 16);
            this.optDisplayFormatMM.Name = "optDisplayFormatMM";
            this.optDisplayFormatMM.Size = new System.Drawing.Size(104, 17);
            this.optDisplayFormatMM.TabIndex = 2;
            this.optDisplayFormatMM.Text = "<Major>.<Minor>";
            this.optDisplayFormatMM.UseVisualStyleBackColor = true;
            // 
            // AppVersionCollectorEditFilterEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(597, 313);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.txtExpectedVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkFirstValidPath);
            this.Controls.Add(this.txtApplicationPaths);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtAppName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkVerifyOnOK);
            this.Controls.Add(this.cmdTest);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "AppVersionCollectorEditFilterEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Version Entry";
            this.Load += new System.EventHandler(this.AppVersionCollectorEditFilterEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkVerifyOnOK;
        private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optProductVersion;
        private System.Windows.Forms.RadioButton optFileVersion;
        private System.Windows.Forms.TextBox txtApplicationPaths;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkFirstValidPath;
        private System.Windows.Forms.TextBox txtExpectedVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optDisplayFormatRAW;
        private System.Windows.Forms.RadioButton optDisplayFormatMMB;
        private System.Windows.Forms.RadioButton optDisplayFormatMM;
    }
}