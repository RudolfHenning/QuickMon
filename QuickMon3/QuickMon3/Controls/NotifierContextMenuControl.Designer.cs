namespace QuickMon.Controls
{
    partial class NotifierContextMenuControl
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
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdAddNotifier = new System.Windows.Forms.Button();
            this.cmdDeleteNotifier = new System.Windows.Forms.Button();
            this.cmdDisableNotifier = new System.Windows.Forms.Button();
            this.cmdEditNotifier = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDetails.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdViewDetails.Image = global::QuickMon.Properties.Resources.comp_search;
            this.cmdViewDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdViewDetails.Location = new System.Drawing.Point(4, 4);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(210, 43);
            this.cmdViewDetails.TabIndex = 1;
            this.cmdViewDetails.Text = "View details";
            this.toolTip1.SetToolTip(this.cmdViewDetails, "View recorded alerts by this notifier ");
            this.cmdViewDetails.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(4, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 1);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add new";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdAddNotifier
            // 
            this.cmdAddNotifier.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdAddNotifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAddNotifier.Image = global::QuickMon.Properties.Resources.add;
            this.cmdAddNotifier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddNotifier.Location = new System.Drawing.Point(4, 48);
            this.cmdAddNotifier.Name = "cmdAddNotifier";
            this.cmdAddNotifier.Size = new System.Drawing.Size(210, 44);
            this.cmdAddNotifier.TabIndex = 5;
            this.cmdAddNotifier.Text = "Add";
            this.toolTip1.SetToolTip(this.cmdAddNotifier, "Add new notifier");
            this.cmdAddNotifier.UseVisualStyleBackColor = true;
            // 
            // cmdDeleteNotifier
            // 
            this.cmdDeleteNotifier.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdDeleteNotifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDeleteNotifier.Image = global::QuickMon.Properties.Resources.stop;
            this.cmdDeleteNotifier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDeleteNotifier.Location = new System.Drawing.Point(4, 162);
            this.cmdDeleteNotifier.Name = "cmdDeleteNotifier";
            this.cmdDeleteNotifier.Size = new System.Drawing.Size(210, 44);
            this.cmdDeleteNotifier.TabIndex = 8;
            this.cmdDeleteNotifier.Text = "Delete";
            this.toolTip1.SetToolTip(this.cmdDeleteNotifier, "Delete notifier");
            this.cmdDeleteNotifier.UseVisualStyleBackColor = true;
            // 
            // cmdDisableNotifier
            // 
            this.cmdDisableNotifier.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdDisableNotifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDisableNotifier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDisableNotifier.Location = new System.Drawing.Point(4, 136);
            this.cmdDisableNotifier.Name = "cmdDisableNotifier";
            this.cmdDisableNotifier.Size = new System.Drawing.Size(210, 26);
            this.cmdDisableNotifier.TabIndex = 7;
            this.cmdDisableNotifier.Text = "Disable";
            this.toolTip1.SetToolTip(this.cmdDisableNotifier, "Enable or disable notifier");
            this.cmdDisableNotifier.UseVisualStyleBackColor = true;
            // 
            // cmdEditNotifier
            // 
            this.cmdEditNotifier.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdEditNotifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditNotifier.Image = global::QuickMon.Properties.Resources.doc_edit;
            this.cmdEditNotifier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditNotifier.Location = new System.Drawing.Point(4, 92);
            this.cmdEditNotifier.Name = "cmdEditNotifier";
            this.cmdEditNotifier.Size = new System.Drawing.Size(210, 44);
            this.cmdEditNotifier.TabIndex = 6;
            this.cmdEditNotifier.Text = "Edit Configuration";
            this.toolTip1.SetToolTip(this.cmdEditNotifier, "Edit notifier configuration");
            this.cmdEditNotifier.UseVisualStyleBackColor = true;
            // 
            // NotifierContextMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdDeleteNotifier);
            this.Controls.Add(this.cmdDisableNotifier);
            this.Controls.Add(this.cmdEditNotifier);
            this.Controls.Add(this.cmdAddNotifier);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdViewDetails);
            this.Name = "NotifierContextMenuControl";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(218, 209);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button cmdViewDetails;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button cmdAddNotifier;
        public System.Windows.Forms.Button cmdDeleteNotifier;
        public System.Windows.Forms.Button cmdDisableNotifier;
        public System.Windows.Forms.Button cmdEditNotifier;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
