namespace QuickMon
{
    partial class CollectorHostEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectorHostEditor));
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.panelGeneralSettings = new System.Windows.Forms.Panel();
            this.panelGeneralSettingsContent = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.cmdGeneralSettingsToggle = new System.Windows.Forms.Button();
            this.llblRawEdit = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanelSettings = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAgents = new System.Windows.Forms.Panel();
            this.panelAgentsContent = new System.Windows.Forms.Panel();
            this.cmdAgentsToggle = new System.Windows.Forms.Button();
            this.panelPolling = new System.Windows.Forms.Panel();
            this.panelPollingContent = new System.Windows.Forms.Panel();
            this.cmdPollingToggle = new System.Windows.Forms.Button();
            this.panelRemoteAgent = new System.Windows.Forms.Panel();
            this.panelRemoteAgentContent = new System.Windows.Forms.Panel();
            this.cmdRemoteAgentToggle = new System.Windows.Forms.Button();
            this.panelRunAs = new System.Windows.Forms.Panel();
            this.panelRunAsContent = new System.Windows.Forms.Panel();
            this.cmdRunAsToggle = new System.Windows.Forms.Button();
            this.panelServiceWindows = new System.Windows.Forms.Panel();
            this.panelServiceWindowsContent = new System.Windows.Forms.Panel();
            this.cmdServiceWindowsToggle = new System.Windows.Forms.Button();
            this.panelAlerting = new System.Windows.Forms.Panel();
            this.panelAlertingContent = new System.Windows.Forms.Panel();
            this.cmdAlertingToggle = new System.Windows.Forms.Button();
            this.panelVariables = new System.Windows.Forms.Panel();
            this.panelVariablesContent = new System.Windows.Forms.Panel();
            this.cmdVariablesToggle = new System.Windows.Forms.Button();
            this.panelActionScripts = new System.Windows.Forms.Panel();
            this.panelActionScriptsContent = new System.Windows.Forms.Panel();
            this.cmdActionScriptsToggle = new System.Windows.Forms.Button();
            this.panelGeneralSettings.SuspendLayout();
            this.panelGeneralSettingsContent.SuspendLayout();
            this.flowLayoutPanelSettings.SuspendLayout();
            this.panelAgents.SuspendLayout();
            this.panelPolling.SuspendLayout();
            this.panelRemoteAgent.SuspendLayout();
            this.panelRunAs.SuspendLayout();
            this.panelServiceWindows.SuspendLayout();
            this.panelAlerting.SuspendLayout();
            this.panelVariables.SuspendLayout();
            this.panelActionScripts.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(446, 692);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(527, 692);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            // 
            // panelGeneralSettings
            // 
            this.panelGeneralSettings.BackColor = System.Drawing.Color.Transparent;
            this.panelGeneralSettings.Controls.Add(this.panelGeneralSettingsContent);
            this.panelGeneralSettings.Controls.Add(this.cmdGeneralSettingsToggle);
            this.panelGeneralSettings.Location = new System.Drawing.Point(3, 3);
            this.panelGeneralSettings.Name = "panelGeneralSettings";
            this.panelGeneralSettings.Size = new System.Drawing.Size(582, 152);
            this.panelGeneralSettings.TabIndex = 4;
            // 
            // panelGeneralSettingsContent
            // 
            this.panelGeneralSettingsContent.Controls.Add(this.txtName);
            this.panelGeneralSettingsContent.Controls.Add(this.chkEnabled);
            this.panelGeneralSettingsContent.Controls.Add(this.lblName);
            this.panelGeneralSettingsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGeneralSettingsContent.Location = new System.Drawing.Point(0, 25);
            this.panelGeneralSettingsContent.Name = "panelGeneralSettingsContent";
            this.panelGeneralSettingsContent.Size = new System.Drawing.Size(582, 127);
            this.panelGeneralSettingsContent.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(109, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(398, 22);
            this.txtName.TabIndex = 2;
            // 
            // chkEnabled
            // 
            this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.BackColor = System.Drawing.Color.Transparent;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkEnabled.Location = new System.Drawing.Point(513, 6);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(63, 17);
            this.chkEnabled.TabIndex = 3;
            this.chkEnabled.Text = "&Enabled";
            this.chkEnabled.UseVisualStyleBackColor = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(6, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 18);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "&Name";
            // 
            // cmdGeneralSettingsToggle
            // 
            this.cmdGeneralSettingsToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdGeneralSettingsToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdGeneralSettingsToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdGeneralSettingsToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdGeneralSettingsToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGeneralSettingsToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdGeneralSettingsToggle.Name = "cmdGeneralSettingsToggle";
            this.cmdGeneralSettingsToggle.Size = new System.Drawing.Size(582, 25);
            this.cmdGeneralSettingsToggle.TabIndex = 0;
            this.cmdGeneralSettingsToggle.Text = "General Settings";
            this.cmdGeneralSettingsToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGeneralSettingsToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdGeneralSettingsToggle.UseVisualStyleBackColor = false;
            this.cmdGeneralSettingsToggle.Click += new System.EventHandler(this.cmdGeneralSettingsToggle_Click);
            // 
            // llblRawEdit
            // 
            this.llblRawEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblRawEdit.AutoSize = true;
            this.llblRawEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblRawEdit.Location = new System.Drawing.Point(11, 697);
            this.llblRawEdit.Name = "llblRawEdit";
            this.llblRawEdit.Size = new System.Drawing.Size(86, 13);
            this.llblRawEdit.TabIndex = 5;
            this.llblRawEdit.TabStop = true;
            this.llblRawEdit.Text = "Edit RAW config";
            // 
            // flowLayoutPanelSettings
            // 
            this.flowLayoutPanelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelSettings.AutoScroll = true;
            this.flowLayoutPanelSettings.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelSettings.Controls.Add(this.panelGeneralSettings);
            this.flowLayoutPanelSettings.Controls.Add(this.panelAgents);
            this.flowLayoutPanelSettings.Controls.Add(this.panelPolling);
            this.flowLayoutPanelSettings.Controls.Add(this.panelRemoteAgent);
            this.flowLayoutPanelSettings.Controls.Add(this.panelRunAs);
            this.flowLayoutPanelSettings.Controls.Add(this.panelServiceWindows);
            this.flowLayoutPanelSettings.Controls.Add(this.panelAlerting);
            this.flowLayoutPanelSettings.Controls.Add(this.panelVariables);
            this.flowLayoutPanelSettings.Controls.Add(this.panelActionScripts);
            this.flowLayoutPanelSettings.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanelSettings.Name = "flowLayoutPanelSettings";
            this.flowLayoutPanelSettings.Size = new System.Drawing.Size(612, 684);
            this.flowLayoutPanelSettings.TabIndex = 6;
            this.flowLayoutPanelSettings.Resize += new System.EventHandler(this.flowLayoutPanelSettings_Resize);
            // 
            // panelAgents
            // 
            this.panelAgents.BackColor = System.Drawing.Color.Transparent;
            this.panelAgents.Controls.Add(this.panelAgentsContent);
            this.panelAgents.Controls.Add(this.cmdAgentsToggle);
            this.panelAgents.Location = new System.Drawing.Point(3, 161);
            this.panelAgents.Name = "panelAgents";
            this.panelAgents.Size = new System.Drawing.Size(582, 179);
            this.panelAgents.TabIndex = 5;
            // 
            // panelAgentsContent
            // 
            this.panelAgentsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAgentsContent.Location = new System.Drawing.Point(0, 25);
            this.panelAgentsContent.Name = "panelAgentsContent";
            this.panelAgentsContent.Size = new System.Drawing.Size(582, 154);
            this.panelAgentsContent.TabIndex = 4;
            // 
            // cmdAgentsToggle
            // 
            this.cmdAgentsToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdAgentsToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdAgentsToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAgentsToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdAgentsToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgentsToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdAgentsToggle.Name = "cmdAgentsToggle";
            this.cmdAgentsToggle.Size = new System.Drawing.Size(582, 25);
            this.cmdAgentsToggle.TabIndex = 0;
            this.cmdAgentsToggle.Text = "Agents";
            this.cmdAgentsToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgentsToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAgentsToggle.UseVisualStyleBackColor = false;
            this.cmdAgentsToggle.Click += new System.EventHandler(this.cmdAgentsToggle_Click);
            // 
            // panelPolling
            // 
            this.panelPolling.BackColor = System.Drawing.Color.Transparent;
            this.panelPolling.Controls.Add(this.panelPollingContent);
            this.panelPolling.Controls.Add(this.cmdPollingToggle);
            this.panelPolling.Location = new System.Drawing.Point(3, 346);
            this.panelPolling.Name = "panelPolling";
            this.panelPolling.Size = new System.Drawing.Size(582, 179);
            this.panelPolling.TabIndex = 6;
            // 
            // panelPollingContent
            // 
            this.panelPollingContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPollingContent.Location = new System.Drawing.Point(0, 25);
            this.panelPollingContent.Name = "panelPollingContent";
            this.panelPollingContent.Size = new System.Drawing.Size(582, 154);
            this.panelPollingContent.TabIndex = 4;
            // 
            // cmdPollingToggle
            // 
            this.cmdPollingToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdPollingToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdPollingToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPollingToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdPollingToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPollingToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdPollingToggle.Name = "cmdPollingToggle";
            this.cmdPollingToggle.Size = new System.Drawing.Size(582, 25);
            this.cmdPollingToggle.TabIndex = 0;
            this.cmdPollingToggle.Text = "Polling";
            this.cmdPollingToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPollingToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPollingToggle.UseVisualStyleBackColor = false;
            this.cmdPollingToggle.Click += new System.EventHandler(this.cmdPollingToggle_Click);
            // 
            // panelRemoteAgent
            // 
            this.panelRemoteAgent.BackColor = System.Drawing.Color.Transparent;
            this.panelRemoteAgent.Controls.Add(this.panelRemoteAgentContent);
            this.panelRemoteAgent.Controls.Add(this.cmdRemoteAgentToggle);
            this.panelRemoteAgent.Location = new System.Drawing.Point(3, 531);
            this.panelRemoteAgent.Name = "panelRemoteAgent";
            this.panelRemoteAgent.Size = new System.Drawing.Size(582, 179);
            this.panelRemoteAgent.TabIndex = 7;
            // 
            // panelRemoteAgentContent
            // 
            this.panelRemoteAgentContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRemoteAgentContent.Location = new System.Drawing.Point(0, 25);
            this.panelRemoteAgentContent.Name = "panelRemoteAgentContent";
            this.panelRemoteAgentContent.Size = new System.Drawing.Size(582, 154);
            this.panelRemoteAgentContent.TabIndex = 4;
            // 
            // cmdRemoteAgentToggle
            // 
            this.cmdRemoteAgentToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdRemoteAgentToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdRemoteAgentToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRemoteAgentToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdRemoteAgentToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRemoteAgentToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdRemoteAgentToggle.Name = "cmdRemoteAgentToggle";
            this.cmdRemoteAgentToggle.Size = new System.Drawing.Size(582, 25);
            this.cmdRemoteAgentToggle.TabIndex = 0;
            this.cmdRemoteAgentToggle.Text = "Remote agent";
            this.cmdRemoteAgentToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRemoteAgentToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdRemoteAgentToggle.UseVisualStyleBackColor = false;
            this.cmdRemoteAgentToggle.Click += new System.EventHandler(this.cmdRemoteAgentToggle_Click);
            // 
            // panelRunAs
            // 
            this.panelRunAs.BackColor = System.Drawing.Color.Transparent;
            this.panelRunAs.Controls.Add(this.panelRunAsContent);
            this.panelRunAs.Controls.Add(this.cmdRunAsToggle);
            this.panelRunAs.Location = new System.Drawing.Point(3, 716);
            this.panelRunAs.Name = "panelRunAs";
            this.panelRunAs.Size = new System.Drawing.Size(582, 109);
            this.panelRunAs.TabIndex = 8;
            // 
            // panelRunAsContent
            // 
            this.panelRunAsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRunAsContent.Location = new System.Drawing.Point(0, 25);
            this.panelRunAsContent.Name = "panelRunAsContent";
            this.panelRunAsContent.Size = new System.Drawing.Size(582, 84);
            this.panelRunAsContent.TabIndex = 4;
            // 
            // cmdRunAsToggle
            // 
            this.cmdRunAsToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdRunAsToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdRunAsToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRunAsToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdRunAsToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRunAsToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdRunAsToggle.Name = "cmdRunAsToggle";
            this.cmdRunAsToggle.Size = new System.Drawing.Size(582, 25);
            this.cmdRunAsToggle.TabIndex = 0;
            this.cmdRunAsToggle.Text = "Run as";
            this.cmdRunAsToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRunAsToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdRunAsToggle.UseVisualStyleBackColor = false;
            this.cmdRunAsToggle.Click += new System.EventHandler(this.cmdRunAsToggle_Click);
            // 
            // panelServiceWindows
            // 
            this.panelServiceWindows.BackColor = System.Drawing.Color.Transparent;
            this.panelServiceWindows.Controls.Add(this.panelServiceWindowsContent);
            this.panelServiceWindows.Controls.Add(this.cmdServiceWindowsToggle);
            this.panelServiceWindows.Location = new System.Drawing.Point(3, 831);
            this.panelServiceWindows.Name = "panelServiceWindows";
            this.panelServiceWindows.Size = new System.Drawing.Size(582, 179);
            this.panelServiceWindows.TabIndex = 9;
            // 
            // panelServiceWindowsContent
            // 
            this.panelServiceWindowsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelServiceWindowsContent.Location = new System.Drawing.Point(0, 25);
            this.panelServiceWindowsContent.Name = "panelServiceWindowsContent";
            this.panelServiceWindowsContent.Size = new System.Drawing.Size(582, 154);
            this.panelServiceWindowsContent.TabIndex = 4;
            // 
            // cmdServiceWindowsToggle
            // 
            this.cmdServiceWindowsToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdServiceWindowsToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdServiceWindowsToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdServiceWindowsToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdServiceWindowsToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdServiceWindowsToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdServiceWindowsToggle.Name = "cmdServiceWindowsToggle";
            this.cmdServiceWindowsToggle.Size = new System.Drawing.Size(582, 25);
            this.cmdServiceWindowsToggle.TabIndex = 0;
            this.cmdServiceWindowsToggle.Text = "Service windows";
            this.cmdServiceWindowsToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdServiceWindowsToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdServiceWindowsToggle.UseVisualStyleBackColor = false;
            this.cmdServiceWindowsToggle.Click += new System.EventHandler(this.cmdServiceWindowsToggle_Click);
            // 
            // panelAlerting
            // 
            this.panelAlerting.BackColor = System.Drawing.Color.Transparent;
            this.panelAlerting.Controls.Add(this.panelAlertingContent);
            this.panelAlerting.Controls.Add(this.cmdAlertingToggle);
            this.panelAlerting.Location = new System.Drawing.Point(3, 1016);
            this.panelAlerting.Name = "panelAlerting";
            this.panelAlerting.Size = new System.Drawing.Size(582, 179);
            this.panelAlerting.TabIndex = 10;
            // 
            // panelAlertingContent
            // 
            this.panelAlertingContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAlertingContent.Location = new System.Drawing.Point(0, 25);
            this.panelAlertingContent.Name = "panelAlertingContent";
            this.panelAlertingContent.Size = new System.Drawing.Size(582, 154);
            this.panelAlertingContent.TabIndex = 4;
            // 
            // cmdAlertingToggle
            // 
            this.cmdAlertingToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdAlertingToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdAlertingToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAlertingToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdAlertingToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAlertingToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdAlertingToggle.Name = "cmdAlertingToggle";
            this.cmdAlertingToggle.Size = new System.Drawing.Size(582, 25);
            this.cmdAlertingToggle.TabIndex = 0;
            this.cmdAlertingToggle.Text = "Alerting";
            this.cmdAlertingToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAlertingToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAlertingToggle.UseVisualStyleBackColor = false;
            this.cmdAlertingToggle.Click += new System.EventHandler(this.cmdAlertingToggle_Click);
            // 
            // panelVariables
            // 
            this.panelVariables.BackColor = System.Drawing.Color.Transparent;
            this.panelVariables.Controls.Add(this.panelVariablesContent);
            this.panelVariables.Controls.Add(this.cmdVariablesToggle);
            this.panelVariables.Location = new System.Drawing.Point(3, 1201);
            this.panelVariables.Name = "panelVariables";
            this.panelVariables.Size = new System.Drawing.Size(582, 179);
            this.panelVariables.TabIndex = 11;
            // 
            // panelVariablesContent
            // 
            this.panelVariablesContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVariablesContent.Location = new System.Drawing.Point(0, 25);
            this.panelVariablesContent.Name = "panelVariablesContent";
            this.panelVariablesContent.Size = new System.Drawing.Size(582, 154);
            this.panelVariablesContent.TabIndex = 4;
            // 
            // cmdVariablesToggle
            // 
            this.cmdVariablesToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdVariablesToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdVariablesToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdVariablesToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdVariablesToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdVariablesToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdVariablesToggle.Name = "cmdVariablesToggle";
            this.cmdVariablesToggle.Size = new System.Drawing.Size(582, 25);
            this.cmdVariablesToggle.TabIndex = 0;
            this.cmdVariablesToggle.Text = "Variables";
            this.cmdVariablesToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdVariablesToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdVariablesToggle.UseVisualStyleBackColor = false;
            this.cmdVariablesToggle.Click += new System.EventHandler(this.cmdVariablesToggle_Click);
            // 
            // panelActionScripts
            // 
            this.panelActionScripts.BackColor = System.Drawing.Color.Transparent;
            this.panelActionScripts.Controls.Add(this.panelActionScriptsContent);
            this.panelActionScripts.Controls.Add(this.cmdActionScriptsToggle);
            this.panelActionScripts.Location = new System.Drawing.Point(3, 1386);
            this.panelActionScripts.Name = "panelActionScripts";
            this.panelActionScripts.Size = new System.Drawing.Size(582, 179);
            this.panelActionScripts.TabIndex = 12;
            // 
            // panelActionScriptsContent
            // 
            this.panelActionScriptsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActionScriptsContent.Location = new System.Drawing.Point(0, 25);
            this.panelActionScriptsContent.Name = "panelActionScriptsContent";
            this.panelActionScriptsContent.Size = new System.Drawing.Size(582, 154);
            this.panelActionScriptsContent.TabIndex = 4;
            // 
            // cmdActionScriptsToggle
            // 
            this.cmdActionScriptsToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdActionScriptsToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdActionScriptsToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdActionScriptsToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdActionScriptsToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdActionScriptsToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdActionScriptsToggle.Name = "cmdActionScriptsToggle";
            this.cmdActionScriptsToggle.Size = new System.Drawing.Size(582, 25);
            this.cmdActionScriptsToggle.TabIndex = 0;
            this.cmdActionScriptsToggle.Text = "Action scripts";
            this.cmdActionScriptsToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdActionScriptsToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdActionScriptsToggle.UseVisualStyleBackColor = false;
            this.cmdActionScriptsToggle.Click += new System.EventHandler(this.cmdActionScriptsToggle_Click);
            // 
            // CollectorHostEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::QuickMon.Properties.Resources.QuickMon5Background3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(614, 727);
            this.Controls.Add(this.flowLayoutPanelSettings);
            this.Controls.Add(this.llblRawEdit);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CollectorHostEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collector Host Editor";
            this.Load += new System.EventHandler(this.CollectorHostEditor_Load);
            this.Shown += new System.EventHandler(this.CollectorHostEditor_Shown);
            this.panelGeneralSettings.ResumeLayout(false);
            this.panelGeneralSettingsContent.ResumeLayout(false);
            this.panelGeneralSettingsContent.PerformLayout();
            this.flowLayoutPanelSettings.ResumeLayout(false);
            this.panelAgents.ResumeLayout(false);
            this.panelPolling.ResumeLayout(false);
            this.panelRemoteAgent.ResumeLayout(false);
            this.panelRunAs.ResumeLayout(false);
            this.panelServiceWindows.ResumeLayout(false);
            this.panelAlerting.ResumeLayout(false);
            this.panelVariables.ResumeLayout(false);
            this.panelActionScripts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Panel panelGeneralSettings;
        private System.Windows.Forms.Button cmdGeneralSettingsToggle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.LinkLabel llblRawEdit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSettings;
        private System.Windows.Forms.Panel panelGeneralSettingsContent;
        private System.Windows.Forms.Panel panelAgents;
        private System.Windows.Forms.Panel panelAgentsContent;
        private System.Windows.Forms.Button cmdAgentsToggle;
        private System.Windows.Forms.Panel panelPolling;
        private System.Windows.Forms.Panel panelPollingContent;
        private System.Windows.Forms.Button cmdPollingToggle;
        private System.Windows.Forms.Panel panelRemoteAgent;
        private System.Windows.Forms.Panel panelRemoteAgentContent;
        private System.Windows.Forms.Button cmdRemoteAgentToggle;
        private System.Windows.Forms.Panel panelRunAs;
        private System.Windows.Forms.Panel panelRunAsContent;
        private System.Windows.Forms.Button cmdRunAsToggle;
        private System.Windows.Forms.Panel panelServiceWindows;
        private System.Windows.Forms.Panel panelServiceWindowsContent;
        private System.Windows.Forms.Button cmdServiceWindowsToggle;
        private System.Windows.Forms.Panel panelAlerting;
        private System.Windows.Forms.Panel panelAlertingContent;
        private System.Windows.Forms.Button cmdAlertingToggle;
        private System.Windows.Forms.Panel panelVariables;
        private System.Windows.Forms.Panel panelVariablesContent;
        private System.Windows.Forms.Button cmdVariablesToggle;
        private System.Windows.Forms.Panel panelActionScripts;
        private System.Windows.Forms.Panel panelActionScriptsContent;
        private System.Windows.Forms.Button cmdActionScriptsToggle;
    }
}