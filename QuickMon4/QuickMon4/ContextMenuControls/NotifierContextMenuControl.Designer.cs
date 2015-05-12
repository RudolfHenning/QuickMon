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
            this.cmdEditNotifier = new System.Windows.Forms.Button();
            this.notifierToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmdAddNotifier = new System.Windows.Forms.Button();
            this.cmdDeleteNotifier = new System.Windows.Forms.Button();
            this.cmdDisableNotifier = new System.Windows.Forms.Button();
            this.lblNotifierHeading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDetails.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdViewDetails.Image = global::QuickMon.Properties.Resources.comp_search;
            this.cmdViewDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdViewDetails.Location = new System.Drawing.Point(4, 108);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(210, 43);
            this.cmdViewDetails.TabIndex = 2;
            this.cmdViewDetails.Text = "Details";
            this.notifierToolTip.SetToolTip(this.cmdViewDetails, "View recorded alerts");
            this.cmdViewDetails.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(4, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 1);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add new";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdEditNotifier
            // 
            this.cmdEditNotifier.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdEditNotifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditNotifier.Image = global::QuickMon.Properties.Resources.Blue3DGearEdit;
            this.cmdEditNotifier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditNotifier.Location = new System.Drawing.Point(4, 66);
            this.cmdEditNotifier.Name = "cmdEditNotifier";
            this.cmdEditNotifier.Size = new System.Drawing.Size(210, 42);
            this.cmdEditNotifier.TabIndex = 3;
            this.cmdEditNotifier.Text = "Configuration";
            this.notifierToolTip.SetToolTip(this.cmdEditNotifier, "Edit configuration");
            this.cmdEditNotifier.UseVisualStyleBackColor = true;
            // 
            // cmdAddNotifier
            // 
            this.cmdAddNotifier.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdAddNotifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAddNotifier.Image = global::QuickMon.Properties.Resources.add;
            this.cmdAddNotifier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddNotifier.Location = new System.Drawing.Point(4, 25);
            this.cmdAddNotifier.Name = "cmdAddNotifier";
            this.cmdAddNotifier.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.cmdAddNotifier.Size = new System.Drawing.Size(210, 41);
            this.cmdAddNotifier.TabIndex = 4;
            this.cmdAddNotifier.Text = "&New";
            this.notifierToolTip.SetToolTip(this.cmdAddNotifier, "Add new");
            this.cmdAddNotifier.UseVisualStyleBackColor = true;
            // 
            // cmdDeleteNotifier
            // 
            this.cmdDeleteNotifier.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdDeleteNotifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDeleteNotifier.Image = global::QuickMon.Properties.Resources.stop16x16;
            this.cmdDeleteNotifier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDeleteNotifier.Location = new System.Drawing.Point(4, 178);
            this.cmdDeleteNotifier.Name = "cmdDeleteNotifier";
            this.cmdDeleteNotifier.Size = new System.Drawing.Size(210, 24);
            this.cmdDeleteNotifier.TabIndex = 5;
            this.cmdDeleteNotifier.Text = "Delete";
            this.notifierToolTip.SetToolTip(this.cmdDeleteNotifier, "Delete");
            this.cmdDeleteNotifier.UseVisualStyleBackColor = true;
            // 
            // cmdDisableNotifier
            // 
            this.cmdDisableNotifier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdDisableNotifier.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdDisableNotifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDisableNotifier.Image = global::QuickMon.Properties.Resources.ForbiddenBue16x16;
            this.cmdDisableNotifier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDisableNotifier.Location = new System.Drawing.Point(4, 151);
            this.cmdDisableNotifier.Name = "cmdDisableNotifier";
            this.cmdDisableNotifier.Padding = new System.Windows.Forms.Padding(2);
            this.cmdDisableNotifier.Size = new System.Drawing.Size(210, 27);
            this.cmdDisableNotifier.TabIndex = 6;
            this.cmdDisableNotifier.Text = "Disable";
            this.notifierToolTip.SetToolTip(this.cmdDisableNotifier, "Enable/Disable");
            this.cmdDisableNotifier.UseVisualStyleBackColor = true;
            // 
            // lblNotifierHeading
            // 
            this.lblNotifierHeading.BackColor = System.Drawing.Color.Gainsboro;
            this.lblNotifierHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNotifierHeading.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblNotifierHeading.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNotifierHeading.ForeColor = System.Drawing.Color.White;
            this.lblNotifierHeading.Image = global::QuickMon.Properties.Resources.MenuBlueShade;
            this.lblNotifierHeading.Location = new System.Drawing.Point(4, 4);
            this.lblNotifierHeading.Name = "lblNotifierHeading";
            this.lblNotifierHeading.Size = new System.Drawing.Size(210, 20);
            this.lblNotifierHeading.TabIndex = 0;
            this.lblNotifierHeading.Text = "Notifier";
            this.lblNotifierHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNotifierHeading.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblNotifierHeading_MouseDown);
            // 
            // NotifierContextMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmdDeleteNotifier);
            this.Controls.Add(this.cmdDisableNotifier);
            this.Controls.Add(this.cmdViewDetails);
            this.Controls.Add(this.cmdEditNotifier);
            this.Controls.Add(this.cmdAddNotifier);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNotifierHeading);
            this.Name = "NotifierContextMenuControl";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(218, 209);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button cmdViewDetails;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button cmdEditNotifier;
        public System.Windows.Forms.Label lblNotifierHeading;
        public System.Windows.Forms.Button cmdAddNotifier;
        public System.Windows.Forms.Button cmdDeleteNotifier;
        public System.Windows.Forms.Button cmdDisableNotifier;
        public System.Windows.Forms.ToolTip notifierToolTip;
    }
}
