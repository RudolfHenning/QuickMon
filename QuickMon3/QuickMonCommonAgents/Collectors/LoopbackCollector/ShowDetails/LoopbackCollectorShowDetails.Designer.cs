namespace QuickMon.Collectors
{
    partial class LoopbackCollectorShowDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoopbackCollectorShowDetails));
            this.lblDisplayedState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwEntries
            // 
            this.lvwEntries.Size = new System.Drawing.Size(494, 277);
            // 
            // lblDisplayedState
            // 
            this.lblDisplayedState.ContextMenuStrip = this.refreshContextMenuStrip;
            this.lblDisplayedState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDisplayedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayedState.Location = new System.Drawing.Point(0, 39);
            this.lblDisplayedState.Name = "lblDisplayedState";
            this.lblDisplayedState.Size = new System.Drawing.Size(494, 277);
            this.lblDisplayedState.TabIndex = 6;
            this.lblDisplayedState.Text = ".";
            this.lblDisplayedState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoopbackCollectorShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 338);
            this.Controls.Add(this.lblDisplayedState);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoopbackCollectorShowDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Details";
            this.Controls.SetChildIndex(this.lvwEntries, 0);
            this.Controls.SetChildIndex(this.lblDisplayedState, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDisplayedState;
    }
}