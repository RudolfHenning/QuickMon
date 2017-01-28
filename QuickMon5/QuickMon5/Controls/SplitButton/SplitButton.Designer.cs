namespace QuickMon5.Controls.SplitButton
{
    partial class SplitButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmdMainButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdSideButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdMainButton
            // 
            this.cmdMainButton.BackColor = System.Drawing.Color.Transparent;
            this.cmdMainButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdMainButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMainButton.FlatAppearance.BorderSize = 0;
            this.cmdMainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMainButton.Location = new System.Drawing.Point(0, 0);
            this.cmdMainButton.Name = "cmdMainButton";
            this.cmdMainButton.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdMainButton.Size = new System.Drawing.Size(59, 31);
            this.cmdMainButton.TabIndex = 0;
            this.cmdMainButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdMainButton.UseVisualStyleBackColor = false;
            this.cmdMainButton.Click += new System.EventHandler(this.cmdMainButton_Click);
            // 
            // cmdSideButton
            // 
            this.cmdSideButton.BackColor = System.Drawing.Color.Transparent;
            this.cmdSideButton.BackgroundImage = global::QuickMon5.Properties.Resources.smlrightTriangle;
            this.cmdSideButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdSideButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdSideButton.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdSideButton.FlatAppearance.BorderSize = 0;
            this.cmdSideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSideButton.Location = new System.Drawing.Point(59, 0);
            this.cmdSideButton.Margin = new System.Windows.Forms.Padding(0);
            this.cmdSideButton.Name = "cmdSideButton";
            this.cmdSideButton.Size = new System.Drawing.Size(10, 31);
            this.cmdSideButton.TabIndex = 1;
            this.cmdSideButton.UseVisualStyleBackColor = false;
            this.cmdSideButton.Click += new System.EventHandler(this.cmdSideButton_Click);
            // 
            // SplitButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdMainButton);
            this.Controls.Add(this.cmdSideButton);
            this.Name = "SplitButton";
            this.Size = new System.Drawing.Size(69, 31);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSideButton;
        private System.Windows.Forms.Button cmdMainButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
