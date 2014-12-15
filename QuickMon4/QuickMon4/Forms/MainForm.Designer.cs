namespace QuickMon
{
    partial class MainForm
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
            this.cmdTestRun1 = new System.Windows.Forms.Button();
            this.cmdTestRun2 = new System.Windows.Forms.Button();
            this.cmdTestEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdTestRun1
            // 
            this.cmdTestRun1.Location = new System.Drawing.Point(12, 12);
            this.cmdTestRun1.Name = "cmdTestRun1";
            this.cmdTestRun1.Size = new System.Drawing.Size(75, 23);
            this.cmdTestRun1.TabIndex = 19;
            this.cmdTestRun1.Text = "Test run 1";
            this.cmdTestRun1.UseVisualStyleBackColor = true;
            this.cmdTestRun1.Click += new System.EventHandler(this.cmdTestRun1_Click);
            // 
            // cmdTestRun2
            // 
            this.cmdTestRun2.Location = new System.Drawing.Point(93, 12);
            this.cmdTestRun2.Name = "cmdTestRun2";
            this.cmdTestRun2.Size = new System.Drawing.Size(75, 23);
            this.cmdTestRun2.TabIndex = 20;
            this.cmdTestRun2.Text = "Test run 2";
            this.cmdTestRun2.UseVisualStyleBackColor = true;
            this.cmdTestRun2.Click += new System.EventHandler(this.cmdTestRun2_Click);
            // 
            // cmdTestEdit
            // 
            this.cmdTestEdit.Location = new System.Drawing.Point(174, 12);
            this.cmdTestEdit.Name = "cmdTestEdit";
            this.cmdTestEdit.Size = new System.Drawing.Size(75, 23);
            this.cmdTestEdit.TabIndex = 21;
            this.cmdTestEdit.Text = "Test edit";
            this.cmdTestEdit.UseVisualStyleBackColor = true;
            this.cmdTestEdit.Click += new System.EventHandler(this.cmdTestEdit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 242);
            this.Controls.Add(this.cmdTestEdit);
            this.Controls.Add(this.cmdTestRun2);
            this.Controls.Add(this.cmdTestRun1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdTestRun1;
        private System.Windows.Forms.Button cmdTestRun2;
        private System.Windows.Forms.Button cmdTestEdit;
    }
}

