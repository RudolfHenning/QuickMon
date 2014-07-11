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
            this.cmdAddFolder = new System.Windows.Forms.Button();
            this.cmdAddCollector = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdAbout = new System.Windows.Forms.Button();
            this.cmdRemoteAgents = new System.Windows.Forms.Button();
            this.cmdGeneralSettings = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdSaveMonitorPack = new System.Windows.Forms.Button();
            this.cmdLoadRecentMonitorPack = new System.Windows.Forms.Button();
            this.cmdLoadMonitorPack = new System.Windows.Forms.Button();
            this.cmdNewMonitorPack = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdDeleteCollector = new System.Windows.Forms.Button();
            this.cmdDisableCollector = new System.Windows.Forms.Button();
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.cmdPasteWithEdit = new System.Windows.Forms.Button();
            this.cmdPaste = new System.Windows.Forms.Button();
            this.cmdCopy = new System.Windows.Forms.Button();
            this.cmdEditCollector = new System.Windows.Forms.Button();
            this.cmdStats = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdAddFolder);
            this.panel1.Controls.Add(this.cmdAddCollector);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 44);
            this.panel1.TabIndex = 3;
            // 
            // cmdAddFolder
            // 
            this.cmdAddFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAddFolder.Image = global::QuickMon.Properties.Resources.folder_add;
            this.cmdAddFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddFolder.Location = new System.Drawing.Point(112, 0);
            this.cmdAddFolder.Name = "cmdAddFolder";
            this.cmdAddFolder.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.cmdAddFolder.Size = new System.Drawing.Size(114, 44);
            this.cmdAddFolder.TabIndex = 1;
            this.cmdAddFolder.Text = "Folder";
            this.cmdAddFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdAddFolder, "Add folder collector");
            this.cmdAddFolder.UseVisualStyleBackColor = true;
            // 
            // cmdAddCollector
            // 
            this.cmdAddCollector.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdAddCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAddCollector.Image = global::QuickMon.Properties.Resources.add;
            this.cmdAddCollector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddCollector.Location = new System.Drawing.Point(0, 0);
            this.cmdAddCollector.Name = "cmdAddCollector";
            this.cmdAddCollector.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.cmdAddCollector.Size = new System.Drawing.Size(112, 44);
            this.cmdAddCollector.TabIndex = 0;
            this.cmdAddCollector.Text = "&Add";
            this.cmdAddCollector.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdAddCollector, "Add new collector");
            this.cmdAddCollector.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(4, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 1);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add new";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(4, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 2);
            this.label2.TabIndex = 5;
            this.label2.Text = "Add new";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkGray;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(4, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 1);
            this.label3.TabIndex = 8;
            this.label3.Text = "Add new";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdAbout);
            this.panel2.Controls.Add(this.cmdRemoteAgents);
            this.panel2.Controls.Add(this.cmdGeneralSettings);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cmdSaveMonitorPack);
            this.panel2.Controls.Add(this.cmdLoadRecentMonitorPack);
            this.panel2.Controls.Add(this.cmdLoadMonitorPack);
            this.panel2.Controls.Add(this.cmdNewMonitorPack);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 301);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 28);
            this.panel2.TabIndex = 8;
            // 
            // cmdAbout
            // 
            this.cmdAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdAbout.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdAbout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAbout.Image = global::QuickMon.Properties.Resources.infoOrange16x16;
            this.cmdAbout.Location = new System.Drawing.Point(194, 0);
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Padding = new System.Windows.Forms.Padding(2);
            this.cmdAbout.Size = new System.Drawing.Size(32, 28);
            this.cmdAbout.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cmdAbout, "About QuickMon 3");
            this.cmdAbout.UseVisualStyleBackColor = true;
            // 
            // cmdRemoteAgents
            // 
            this.cmdRemoteAgents.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdRemoteAgents.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdRemoteAgents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRemoteAgents.Image = global::QuickMon.Properties.Resources.Charon16x16;
            this.cmdRemoteAgents.Location = new System.Drawing.Point(162, 0);
            this.cmdRemoteAgents.Name = "cmdRemoteAgents";
            this.cmdRemoteAgents.Padding = new System.Windows.Forms.Padding(2);
            this.cmdRemoteAgents.Size = new System.Drawing.Size(32, 28);
            this.cmdRemoteAgents.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cmdRemoteAgents, "Remote agent hosts");
            this.cmdRemoteAgents.UseVisualStyleBackColor = true;
            // 
            // cmdGeneralSettings
            // 
            this.cmdGeneralSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdGeneralSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdGeneralSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGeneralSettings.Image = global::QuickMon.Properties.Resources.tools16x16;
            this.cmdGeneralSettings.Location = new System.Drawing.Point(130, 0);
            this.cmdGeneralSettings.Name = "cmdGeneralSettings";
            this.cmdGeneralSettings.Padding = new System.Windows.Forms.Padding(2);
            this.cmdGeneralSettings.Size = new System.Drawing.Size(32, 28);
            this.cmdGeneralSettings.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cmdGeneralSettings, "General settings");
            this.cmdGeneralSettings.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkGray;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(128, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(2, 28);
            this.label5.TabIndex = 8;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdSaveMonitorPack
            // 
            this.cmdSaveMonitorPack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdSaveMonitorPack.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdSaveMonitorPack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSaveMonitorPack.Image = global::QuickMon.Properties.Resources.save16x16;
            this.cmdSaveMonitorPack.Location = new System.Drawing.Point(96, 0);
            this.cmdSaveMonitorPack.Name = "cmdSaveMonitorPack";
            this.cmdSaveMonitorPack.Padding = new System.Windows.Forms.Padding(2);
            this.cmdSaveMonitorPack.Size = new System.Drawing.Size(32, 28);
            this.cmdSaveMonitorPack.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cmdSaveMonitorPack, "Save current monitor pack to file");
            this.cmdSaveMonitorPack.UseVisualStyleBackColor = true;
            // 
            // cmdLoadRecentMonitorPack
            // 
            this.cmdLoadRecentMonitorPack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdLoadRecentMonitorPack.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdLoadRecentMonitorPack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLoadRecentMonitorPack.Image = global::QuickMon.Properties.Resources.folderWLightning16x16;
            this.cmdLoadRecentMonitorPack.Location = new System.Drawing.Point(64, 0);
            this.cmdLoadRecentMonitorPack.Name = "cmdLoadRecentMonitorPack";
            this.cmdLoadRecentMonitorPack.Padding = new System.Windows.Forms.Padding(2);
            this.cmdLoadRecentMonitorPack.Size = new System.Drawing.Size(32, 28);
            this.cmdLoadRecentMonitorPack.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cmdLoadRecentMonitorPack, "Open recent monotor pack file");
            this.cmdLoadRecentMonitorPack.UseVisualStyleBackColor = true;
            // 
            // cmdLoadMonitorPack
            // 
            this.cmdLoadMonitorPack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdLoadMonitorPack.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdLoadMonitorPack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLoadMonitorPack.Image = global::QuickMon.Properties.Resources.folder16x16;
            this.cmdLoadMonitorPack.Location = new System.Drawing.Point(32, 0);
            this.cmdLoadMonitorPack.Name = "cmdLoadMonitorPack";
            this.cmdLoadMonitorPack.Padding = new System.Windows.Forms.Padding(2);
            this.cmdLoadMonitorPack.Size = new System.Drawing.Size(32, 28);
            this.cmdLoadMonitorPack.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cmdLoadMonitorPack, "Open existing monitor pack file");
            this.cmdLoadMonitorPack.UseVisualStyleBackColor = true;
            // 
            // cmdNewMonitorPack
            // 
            this.cmdNewMonitorPack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdNewMonitorPack.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdNewMonitorPack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNewMonitorPack.Image = global::QuickMon.Properties.Resources.doc_new16x16;
            this.cmdNewMonitorPack.Location = new System.Drawing.Point(0, 0);
            this.cmdNewMonitorPack.Name = "cmdNewMonitorPack";
            this.cmdNewMonitorPack.Padding = new System.Windows.Forms.Padding(2);
            this.cmdNewMonitorPack.Size = new System.Drawing.Size(32, 28);
            this.cmdNewMonitorPack.TabIndex = 0;
            this.toolTip1.SetToolTip(this.cmdNewMonitorPack, "Create new monitor pack");
            this.cmdNewMonitorPack.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gainsboro;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Image = global::QuickMon.Properties.Resources.MenuOrangeShade;
            this.label4.Location = new System.Drawing.Point(4, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Monitor pack";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRefresh.Image = global::QuickMon.Properties.Resources.refresh;
            this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRefresh.Location = new System.Drawing.Point(4, 257);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(226, 44);
            this.cmdRefresh.TabIndex = 7;
            this.cmdRefresh.Text = "Refresh F5";
            this.toolTip1.SetToolTip(this.cmdRefresh, "Redresh all collector states");
            this.cmdRefresh.UseVisualStyleBackColor = true;
            // 
            // cmdDeleteCollector
            // 
            this.cmdDeleteCollector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdDeleteCollector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdDeleteCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDeleteCollector.Image = global::QuickMon.Properties.Resources.stop;
            this.cmdDeleteCollector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDeleteCollector.Location = new System.Drawing.Point(112, 0);
            this.cmdDeleteCollector.Name = "cmdDeleteCollector";
            this.cmdDeleteCollector.Padding = new System.Windows.Forms.Padding(0, 2, 15, 0);
            this.cmdDeleteCollector.Size = new System.Drawing.Size(114, 44);
            this.cmdDeleteCollector.TabIndex = 1;
            this.cmdDeleteCollector.Text = "Delete";
            this.cmdDeleteCollector.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdDeleteCollector, "Delete collector");
            this.cmdDeleteCollector.UseVisualStyleBackColor = true;
            // 
            // cmdDisableCollector
            // 
            this.cmdDisableCollector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdDisableCollector.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdDisableCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDisableCollector.Image = global::QuickMon.Properties.Resources.Forbidden32x32;
            this.cmdDisableCollector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDisableCollector.Location = new System.Drawing.Point(0, 0);
            this.cmdDisableCollector.Name = "cmdDisableCollector";
            this.cmdDisableCollector.Padding = new System.Windows.Forms.Padding(0, 2, 15, 0);
            this.cmdDisableCollector.Size = new System.Drawing.Size(112, 44);
            this.cmdDisableCollector.TabIndex = 0;
            this.cmdDisableCollector.Text = "Enable";
            this.cmdDisableCollector.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdDisableCollector, "Enable/Disable collector");
            this.cmdDisableCollector.UseVisualStyleBackColor = true;
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDetails.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdViewDetails.Image = global::QuickMon.Properties.Resources.comp_search;
            this.cmdViewDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdViewDetails.Location = new System.Drawing.Point(0, 0);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.cmdViewDetails.Size = new System.Drawing.Size(112, 44);
            this.cmdViewDetails.TabIndex = 0;
            this.cmdViewDetails.Text = "&Details";
            this.cmdViewDetails.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdViewDetails, "View collector details");
            this.cmdViewDetails.UseVisualStyleBackColor = true;
            // 
            // cmdPasteWithEdit
            // 
            this.cmdPasteWithEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdPasteWithEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdPasteWithEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdPasteWithEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdPasteWithEdit.Image = global::QuickMon.Properties.Resources.pastewithedit;
            this.cmdPasteWithEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPasteWithEdit.Location = new System.Drawing.Point(147, 0);
            this.cmdPasteWithEdit.Name = "cmdPasteWithEdit";
            this.cmdPasteWithEdit.Padding = new System.Windows.Forms.Padding(1);
            this.cmdPasteWithEdit.Size = new System.Drawing.Size(78, 33);
            this.cmdPasteWithEdit.TabIndex = 2;
            this.cmdPasteWithEdit.Text = "Paste+";
            this.cmdPasteWithEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdPasteWithEdit, "Edit and Paste copied Collector and dependents");
            this.cmdPasteWithEdit.UseVisualStyleBackColor = true;
            // 
            // cmdPaste
            // 
            this.cmdPaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdPaste.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdPaste.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdPaste.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdPaste.Image = global::QuickMon.Properties.Resources.paste;
            this.cmdPaste.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPaste.Location = new System.Drawing.Point(66, 0);
            this.cmdPaste.Name = "cmdPaste";
            this.cmdPaste.Padding = new System.Windows.Forms.Padding(2);
            this.cmdPaste.Size = new System.Drawing.Size(81, 33);
            this.cmdPaste.TabIndex = 1;
            this.cmdPaste.Text = "Paste";
            this.cmdPaste.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdPaste, "Paste copied Collector and dependents");
            this.cmdPaste.UseVisualStyleBackColor = true;
            // 
            // cmdCopy
            // 
            this.cmdCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdCopy.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCopy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdCopy.Image = global::QuickMon.Properties.Resources.copy;
            this.cmdCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCopy.Location = new System.Drawing.Point(0, 0);
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Padding = new System.Windows.Forms.Padding(2);
            this.cmdCopy.Size = new System.Drawing.Size(64, 33);
            this.cmdCopy.TabIndex = 0;
            this.cmdCopy.Text = "Copy";
            this.cmdCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdCopy, "Copy selected Collector (and dependants)");
            this.cmdCopy.UseVisualStyleBackColor = true;
            // 
            // cmdEditCollector
            // 
            this.cmdEditCollector.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdEditCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditCollector.Image = global::QuickMon.Properties.Resources.doc_edit;
            this.cmdEditCollector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditCollector.Location = new System.Drawing.Point(4, 193);
            this.cmdEditCollector.Name = "cmdEditCollector";
            this.cmdEditCollector.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.cmdEditCollector.Size = new System.Drawing.Size(226, 44);
            this.cmdEditCollector.TabIndex = 9;
            this.cmdEditCollector.Text = "&Edit configuration";
            this.toolTip1.SetToolTip(this.cmdEditCollector, "Edit collector configuration");
            this.cmdEditCollector.UseVisualStyleBackColor = true;
            // 
            // cmdStats
            // 
            this.cmdStats.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdStats.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdStats.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdStats.Image = global::QuickMon.Properties.Resources.doc_stats;
            this.cmdStats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdStats.Location = new System.Drawing.Point(112, 0);
            this.cmdStats.Name = "cmdStats";
            this.cmdStats.Padding = new System.Windows.Forms.Padding(2, 2, 15, 2);
            this.cmdStats.Size = new System.Drawing.Size(114, 44);
            this.cmdStats.TabIndex = 6;
            this.cmdStats.Text = "Statistics";
            this.cmdStats.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdStats, "Statistics about collector");
            this.cmdStats.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmdStats);
            this.panel3.Controls.Add(this.cmdViewDetails);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(4, 101);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(226, 44);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmdPasteWithEdit);
            this.panel4.Controls.Add(this.cmdPaste);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.cmdCopy);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(226, 33);
            this.panel4.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DimGray;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(64, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(2, 33);
            this.label6.TabIndex = 3;
            this.label6.Text = "label6";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cmdDeleteCollector);
            this.panel5.Controls.Add(this.cmdDisableCollector);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(4, 147);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(226, 44);
            this.panel5.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Gainsboro;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Image = global::QuickMon.Properties.Resources.MenuOrangeShade;
            this.label7.Location = new System.Drawing.Point(4, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(226, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Collector";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CollectorContextMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdEditCollector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label7);
            this.Name = "CollectorContextMenuControl";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(234, 332);
            this.Load += new System.EventHandler(this.CollectorContextMenuControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button cmdAddFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button cmdAddCollector;
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
        public System.Windows.Forms.Button cmdAbout;
        public System.Windows.Forms.Button cmdGeneralSettings;
        public System.Windows.Forms.Button cmdRemoteAgents;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Button cmdViewDetails;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Button cmdCopy;
        public System.Windows.Forms.Button cmdPaste;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button cmdPasteWithEdit;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Button cmdDeleteCollector;
        public System.Windows.Forms.Button cmdDisableCollector;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button cmdStats;
        public System.Windows.Forms.Button cmdEditCollector;
    }
}
