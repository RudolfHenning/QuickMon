namespace QuickMon.Forms
{
    partial class TestMenu
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
            this.panelTest = new System.Windows.Forms.Panel();
            this.cmdTestEdit = new System.Windows.Forms.Button();
            this.cmdTestRun1 = new System.Windows.Forms.Button();
            this.cmdTestRun2 = new System.Windows.Forms.Button();
            this.panelTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTest
            // 
            this.panelTest.Controls.Add(this.cmdTestEdit);
            this.panelTest.Controls.Add(this.cmdTestRun1);
            this.panelTest.Controls.Add(this.cmdTestRun2);
            this.panelTest.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTest.Location = new System.Drawing.Point(0, 0);
            this.panelTest.Name = "panelTest";
            this.panelTest.Size = new System.Drawing.Size(284, 34);
            this.panelTest.TabIndex = 48;
            // 
            // cmdTestEdit
            // 
            this.cmdTestEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdTestEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTestEdit.Location = new System.Drawing.Point(165, 8);
            this.cmdTestEdit.Name = "cmdTestEdit";
            this.cmdTestEdit.Size = new System.Drawing.Size(75, 23);
            this.cmdTestEdit.TabIndex = 21;
            this.cmdTestEdit.Text = "Test edit";
            this.cmdTestEdit.UseVisualStyleBackColor = true;
            this.cmdTestEdit.Click += new System.EventHandler(this.cmdTestEdit_Click);
            // 
            // cmdTestRun1
            // 
            this.cmdTestRun1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdTestRun1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTestRun1.Location = new System.Drawing.Point(3, 8);
            this.cmdTestRun1.Name = "cmdTestRun1";
            this.cmdTestRun1.Size = new System.Drawing.Size(75, 23);
            this.cmdTestRun1.TabIndex = 19;
            this.cmdTestRun1.Text = "Test run 1";
            this.cmdTestRun1.UseVisualStyleBackColor = true;
            this.cmdTestRun1.Click += new System.EventHandler(this.cmdTestRun1_Click);
            // 
            // cmdTestRun2
            // 
            this.cmdTestRun2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdTestRun2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTestRun2.Location = new System.Drawing.Point(84, 8);
            this.cmdTestRun2.Name = "cmdTestRun2";
            this.cmdTestRun2.Size = new System.Drawing.Size(75, 23);
            this.cmdTestRun2.TabIndex = 20;
            this.cmdTestRun2.Text = "Test run 2";
            this.cmdTestRun2.UseVisualStyleBackColor = true;
            this.cmdTestRun2.Click += new System.EventHandler(this.cmdTestRun2_Click);
            // 
            // TestMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 73);
            this.Controls.Add(this.panelTest);
            this.Name = "TestMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestMenu";
            this.panelTest.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTest;
        private System.Windows.Forms.Button cmdTestEdit;
        private System.Windows.Forms.Button cmdTestRun1;
        private System.Windows.Forms.Button cmdTestRun2;
    }
}