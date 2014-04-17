namespace QuickMon.Collectors
{
    partial class EditSqlQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSqlQuery));
            this.cmdTest = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.txtDetailQuery = new FastColoredTextBoxNS.FastColoredTextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.chkUseSPForDetail = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmdTest
            // 
            this.cmdTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTest.Location = new System.Drawing.Point(470, 395);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(75, 23);
            this.cmdTest.TabIndex = 4;
            this.cmdTest.Text = "Parse";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(632, 395);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(551, 395);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtDetailQuery
            // 
            this.txtDetailQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetailQuery.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.txtDetailQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetailQuery.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDetailQuery.HighlightingRangeType = FastColoredTextBoxNS.HighlightingRangeType.AllTextRange;
            this.txtDetailQuery.Language = FastColoredTextBoxNS.Language.SQL;
            this.txtDetailQuery.Location = new System.Drawing.Point(8, 37);
            this.txtDetailQuery.Name = "txtDetailQuery";
            this.txtDetailQuery.PreferredLineWidth = 0;
            this.txtDetailQuery.Size = new System.Drawing.Size(705, 352);
            this.txtDetailQuery.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(147, 21);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(207, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "click here to see query tips and restrictions";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelQueryTips_LinkClicked);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "SQL Query for detail";
            // 
            // chkUseSPForDetail
            // 
            this.chkUseSPForDetail.AutoSize = true;
            this.chkUseSPForDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkUseSPForDetail.Location = new System.Drawing.Point(5, 1);
            this.chkUseSPForDetail.Name = "chkUseSPForDetail";
            this.chkUseSPForDetail.Size = new System.Drawing.Size(135, 17);
            this.chkUseSPForDetail.TabIndex = 0;
            this.chkUseSPForDetail.Text = "Use stored procuredure";
            this.chkUseSPForDetail.UseVisualStyleBackColor = true;
            // 
            // EditSqlQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 427);
            this.Controls.Add(this.cmdTest);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtDetailQuery);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chkUseSPForDetail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "EditSqlQuery";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Sql query  text";
            this.Load += new System.EventHandler(this.EditDetailQuery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private FastColoredTextBoxNS.FastColoredTextBox txtDetailQuery;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkUseSPForDetail;
    }
}