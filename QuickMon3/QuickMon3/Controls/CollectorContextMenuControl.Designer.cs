namespace QuickMon.Controls
{
    partial class CollectorContextMenuControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdAddCollector = new System.Windows.Forms.Button();
            this.cmdAddFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdDisableCollector = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdAbout = new System.Windows.Forms.Button();
            this.cmdPollingFrequency = new System.Windows.Forms.Button();
            this.cmdGeneralSettings = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdSaveMonitorPack = new System.Windows.Forms.Button();
            this.cmdLoadRecentMonitorPack = new System.Windows.Forms.Button();
            this.cmdLoadMonitorPack = new System.Windows.Forms.Button();
            this.cmdNewMonitorPack = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdDeleteCollector = new System.Windows.Forms.Button();
            this.cmdEditCollector = new System.Windows.Forms.Button();
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdAddCollector);
            this.panel1.Controls.Add(this.cmdAddFolder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 44);
            this.panel1.TabIndex = 2;
            // 
            // cmdAddCollector
            // 
            this.cmdAddCollector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdAddCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAddCollector.Image = global::QuickMon.Properties.Resources.add;
            this.cmdAddCollector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddCollector.Location = new System.Drawing.Point(92, 0);
            this.cmdAddCollector.Name = "cmdAddCollector";
            this.cmdAddCollector.Size = new System.Drawing.Size(134, 44);
            this.cmdAddCollector.TabIndex = 1;
            this.cmdAddCollector.Text = "&Add";
            this.toolTip1.SetToolTip(this.cmdAddCollector, "Add new collector");
            this.cmdAddCollector.UseVisualStyleBackColor = true;
            // 
            // cmdAddFolder
            // 
            this.cmdAddFolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAddFolder.Image = global::QuickMon.Properties.Resources.folder_add;
            this.cmdAddFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddFolder.Location = new System.Drawing.Point(0, 0);
            this.cmdAddFolder.Name = "cmdAddFolder";
            this.cmdAddFolder.Size = new System.Drawing.Size(92, 44);
            this.cmdAddFolder.TabIndex = 0;
            this.cmdAddFolder.Text = "Folder";
            this.cmdAddFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdAddFolder, "Add folder collector");
            this.cmdAddFolder.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(4, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 1);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add new";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdDisableCollector
            // 
            this.cmdDisableCollector.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdDisableCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDisableCollector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDisableCollector.Location = new System.Drawing.Point(4, 136);
            this.cmdDisableCollector.Name = "cmdDisableCollector";
            this.cmdDisableCollector.Size = new System.Drawing.Size(226, 26);
            this.cmdDisableCollector.TabIndex = 3;
            this.cmdDisableCollector.Text = "Disable";
            this.toolTip1.SetToolTip(this.cmdDisableCollector, "Enable or disable collector");
            this.cmdDisableCollector.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(4, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 1);
            this.label2.TabIndex = 5;
            this.label2.Text = "Add new";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkGray;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(4, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 1);
            this.label3.TabIndex = 7;
            this.label3.Text = "Add new";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdAbout);
            this.panel2.Controls.Add(this.cmdPollingFrequency);
            this.panel2.Controls.Add(this.cmdGeneralSettings);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cmdSaveMonitorPack);
            this.panel2.Controls.Add(this.cmdLoadRecentMonitorPack);
            this.panel2.Controls.Add(this.cmdLoadMonitorPack);
            this.panel2.Controls.Add(this.cmdNewMonitorPack);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 274);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 36);
            this.panel2.TabIndex = 8;
            // 
            // cmdAbout
            // 
            this.cmdAbout.BackgroundImage = global::QuickMon.Properties.Resources.info;
            this.cmdAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdAbout.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdAbout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAbout.Location = new System.Drawing.Point(194, 0);
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Padding = new System.Windows.Forms.Padding(2);
            this.cmdAbout.Size = new System.Drawing.Size(32, 36);
            this.cmdAbout.TabIndex = 11;
            this.toolTip1.SetToolTip(this.cmdAbout, "About QuickMon 3");
            this.cmdAbout.UseVisualStyleBackColor = true;
            // 
            // cmdPollingFrequency
            // 
            this.cmdPollingFrequency.BackgroundImage = global::QuickMon.Properties.Resources.clock;
            this.cmdPollingFrequency.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdPollingFrequency.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdPollingFrequency.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdPollingFrequency.Location = new System.Drawing.Point(162, 0);
            this.cmdPollingFrequency.Name = "cmdPollingFrequency";
            this.cmdPollingFrequency.Padding = new System.Windows.Forms.Padding(2);
            this.cmdPollingFrequency.Size = new System.Drawing.Size(32, 36);
            this.cmdPollingFrequency.TabIndex = 10;
            this.toolTip1.SetToolTip(this.cmdPollingFrequency, "Set polling frequency");
            this.cmdPollingFrequency.UseVisualStyleBackColor = true;
            // 
            // cmdGeneralSettings
            // 
            this.cmdGeneralSettings.BackgroundImage = global::QuickMon.Properties.Resources.tools;
            this.cmdGeneralSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdGeneralSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdGeneralSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGeneralSettings.Location = new System.Drawing.Point(130, 0);
            this.cmdGeneralSettings.Name = "cmdGeneralSettings";
            this.cmdGeneralSettings.Padding = new System.Windows.Forms.Padding(2);
            this.cmdGeneralSettings.Size = new System.Drawing.Size(32, 36);
            this.cmdGeneralSettings.TabIndex = 9;
            this.toolTip1.SetToolTip(this.cmdGeneralSettings, "General settings");
            this.cmdGeneralSettings.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkGray;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(128, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(2, 36);
            this.label5.TabIndex = 8;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdSaveMonitorPack
            // 
            this.cmdSaveMonitorPack.BackgroundImage = global::QuickMon.Properties.Resources.save;
            this.cmdSaveMonitorPack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdSaveMonitorPack.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdSaveMonitorPack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSaveMonitorPack.Location = new System.Drawing.Point(96, 0);
            this.cmdSaveMonitorPack.Name = "cmdSaveMonitorPack";
            this.cmdSaveMonitorPack.Padding = new System.Windows.Forms.Padding(2);
            this.cmdSaveMonitorPack.Size = new System.Drawing.Size(32, 36);
            this.cmdSaveMonitorPack.TabIndex = 7;
            this.toolTip1.SetToolTip(this.cmdSaveMonitorPack, "Save current monitor pack to file");
            this.cmdSaveMonitorPack.UseVisualStyleBackColor = true;
            // 
            // cmdLoadRecentMonitorPack
            // 
            this.cmdLoadRecentMonitorPack.BackgroundImage = global::QuickMon.Properties.Resources.folder_favor;
            this.cmdLoadRecentMonitorPack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdLoadRecentMonitorPack.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdLoadRecentMonitorPack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLoadRecentMonitorPack.Location = new System.Drawing.Point(64, 0);
            this.cmdLoadRecentMonitorPack.Name = "cmdLoadRecentMonitorPack";
            this.cmdLoadRecentMonitorPack.Padding = new System.Windows.Forms.Padding(2);
            this.cmdLoadRecentMonitorPack.Size = new System.Drawing.Size(32, 36);
            this.cmdLoadRecentMonitorPack.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cmdLoadRecentMonitorPack, "Open recent monotor pack file");
            this.cmdLoadRecentMonitorPack.UseVisualStyleBackColor = true;
            // 
            // cmdLoadMonitorPack
            // 
            this.cmdLoadMonitorPack.BackgroundImage = global::QuickMon.Properties.Resources.folder;
            this.cmdLoadMonitorPack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdLoadMonitorPack.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdLoadMonitorPack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLoadMonitorPack.Location = new System.Drawing.Point(32, 0);
            this.cmdLoadMonitorPack.Name = "cmdLoadMonitorPack";
            this.cmdLoadMonitorPack.Padding = new System.Windows.Forms.Padding(2);
            this.cmdLoadMonitorPack.Size = new System.Drawing.Size(32, 36);
            this.cmdLoadMonitorPack.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cmdLoadMonitorPack, "Open existing monitor pack file");
            this.cmdLoadMonitorPack.UseVisualStyleBackColor = true;
            // 
            // cmdNewMonitorPack
            // 
            this.cmdNewMonitorPack.BackgroundImage = global::QuickMon.Properties.Resources.doc_new2;
            this.cmdNewMonitorPack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdNewMonitorPack.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdNewMonitorPack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNewMonitorPack.Location = new System.Drawing.Point(0, 0);
            this.cmdNewMonitorPack.Name = "cmdNewMonitorPack";
            this.cmdNewMonitorPack.Padding = new System.Windows.Forms.Padding(2);
            this.cmdNewMonitorPack.Size = new System.Drawing.Size(32, 36);
            this.cmdNewMonitorPack.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cmdNewMonitorPack, "Create new monitor pack");
            this.cmdNewMonitorPack.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gainsboro;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(4, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "Monitor pack";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRefresh.Image = global::QuickMon.Properties.Resources.refresh;
            this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRefresh.Location = new System.Drawing.Point(4, 207);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(226, 44);
            this.cmdRefresh.TabIndex = 6;
            this.cmdRefresh.Text = "Refresh F5";
            this.toolTip1.SetToolTip(this.cmdRefresh, "Redresh all collector states");
            this.cmdRefresh.UseVisualStyleBackColor = true;
            // 
            // cmdDeleteCollector
            // 
            this.cmdDeleteCollector.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdDeleteCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDeleteCollector.Image = global::QuickMon.Properties.Resources.stop;
            this.cmdDeleteCollector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDeleteCollector.Location = new System.Drawing.Point(4, 162);
            this.cmdDeleteCollector.Name = "cmdDeleteCollector";
            this.cmdDeleteCollector.Size = new System.Drawing.Size(226, 44);
            this.cmdDeleteCollector.TabIndex = 4;
            this.cmdDeleteCollector.Text = "Delete";
            this.toolTip1.SetToolTip(this.cmdDeleteCollector, "Delete collector");
            this.cmdDeleteCollector.UseVisualStyleBackColor = true;
            // 
            // cmdEditCollector
            // 
            this.cmdEditCollector.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdEditCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditCollector.Image = global::QuickMon.Properties.Resources.doc_edit;
            this.cmdEditCollector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditCollector.Location = new System.Drawing.Point(4, 92);
            this.cmdEditCollector.Name = "cmdEditCollector";
            this.cmdEditCollector.Size = new System.Drawing.Size(226, 44);
            this.cmdEditCollector.TabIndex = 2;
            this.cmdEditCollector.Text = "&Edit Configuration";
            this.toolTip1.SetToolTip(this.cmdEditCollector, "Edit collector configuration");
            this.cmdEditCollector.UseVisualStyleBackColor = true;
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
            this.cmdViewDetails.Size = new System.Drawing.Size(226, 43);
            this.cmdViewDetails.TabIndex = 0;
            this.cmdViewDetails.Text = "&View details";
            this.toolTip1.SetToolTip(this.cmdViewDetails, "View collector details");
            this.cmdViewDetails.UseVisualStyleBackColor = true;
            // 
            // CollectorContextMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdDeleteCollector);
            this.Controls.Add(this.cmdDisableCollector);
            this.Controls.Add(this.cmdEditCollector);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdViewDetails);
            this.Name = "CollectorContextMenuControl";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(234, 317);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button cmdViewDetails;
        public System.Windows.Forms.Button cmdAddFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button cmdAddCollector;
        public System.Windows.Forms.Button cmdEditCollector;
        public System.Windows.Forms.Button cmdDisableCollector;
        public System.Windows.Forms.Button cmdDeleteCollector;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button cmdNewMonitorPack;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button cmdSaveMonitorPack;
        public System.Windows.Forms.Button cmdLoadRecentMonitorPack;
        public System.Windows.Forms.Button cmdLoadMonitorPack;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button cmdPollingFrequency;
        public System.Windows.Forms.Button cmdGeneralSettings;
        public System.Windows.Forms.Button cmdAbout;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
