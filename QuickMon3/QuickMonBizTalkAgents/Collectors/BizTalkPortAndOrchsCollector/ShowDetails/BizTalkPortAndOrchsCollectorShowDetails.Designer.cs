namespace QuickMon.Collectors
{
    partial class BizTalkPortAndOrchsCollectorShowDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BizTalkPortAndOrchsCollectorShowDetails));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvwReceiveLocations = new QuickMon.ListViewEx();
            this.columnHeaderPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDisabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvwSendPorts = new QuickMon.ListViewEx();
            this.columnHeaderSendPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lvwOrchestrations = new QuickMon.ListViewEx();
            this.columnHeaderOrchestration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 409);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvwReceiveLocations);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(561, 258);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Receive Locations";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvwReceiveLocations
            // 
            this.lvwReceiveLocations.AutoResizeColumnEnabled = false;
            this.lvwReceiveLocations.AutoResizeColumnIndex = 0;
            this.lvwReceiveLocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPort,
            this.columnHeaderLocation,
            this.columnHeaderDisabled});
            this.lvwReceiveLocations.ContextMenuStrip = this.refreshContextMenuStrip;
            this.lvwReceiveLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwReceiveLocations.FullRowSelect = true;
            this.lvwReceiveLocations.HideSelection = false;
            this.lvwReceiveLocations.Location = new System.Drawing.Point(3, 3);
            this.lvwReceiveLocations.Name = "lvwReceiveLocations";
            this.lvwReceiveLocations.Size = new System.Drawing.Size(555, 252);
            this.lvwReceiveLocations.TabIndex = 6;
            this.lvwReceiveLocations.UseCompatibleStateImageBehavior = false;
            this.lvwReceiveLocations.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderPort
            // 
            this.columnHeaderPort.Text = "Receive Port";
            this.columnHeaderPort.Width = 189;
            // 
            // columnHeaderLocation
            // 
            this.columnHeaderLocation.Text = "Receive Location";
            this.columnHeaderLocation.Width = 240;
            // 
            // columnHeaderDisabled
            // 
            this.columnHeaderDisabled.Text = "Disabled";
            this.columnHeaderDisabled.Width = 112;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvwSendPorts);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(561, 258);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Send Ports";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvwSendPorts
            // 
            this.lvwSendPorts.AutoResizeColumnEnabled = false;
            this.lvwSendPorts.AutoResizeColumnIndex = 0;
            this.lvwSendPorts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSendPort,
            this.columnHeaderState});
            this.lvwSendPorts.ContextMenuStrip = this.refreshContextMenuStrip;
            this.lvwSendPorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwSendPorts.FullRowSelect = true;
            this.lvwSendPorts.HideSelection = false;
            this.lvwSendPorts.Location = new System.Drawing.Point(3, 3);
            this.lvwSendPorts.Name = "lvwSendPorts";
            this.lvwSendPorts.Size = new System.Drawing.Size(555, 252);
            this.lvwSendPorts.TabIndex = 7;
            this.lvwSendPorts.UseCompatibleStateImageBehavior = false;
            this.lvwSendPorts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderSendPort
            // 
            this.columnHeaderSendPort.Text = "Send Port";
            this.columnHeaderSendPort.Width = 320;
            // 
            // columnHeaderState
            // 
            this.columnHeaderState.Text = "Status";
            this.columnHeaderState.Width = 112;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lvwOrchestrations);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(692, 383);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Orchestrations";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lvwOrchestrations
            // 
            this.lvwOrchestrations.AutoResizeColumnEnabled = false;
            this.lvwOrchestrations.AutoResizeColumnIndex = 0;
            this.lvwOrchestrations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderOrchestration,
            this.columnHeader2});
            this.lvwOrchestrations.ContextMenuStrip = this.refreshContextMenuStrip;
            this.lvwOrchestrations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwOrchestrations.FullRowSelect = true;
            this.lvwOrchestrations.HideSelection = false;
            this.lvwOrchestrations.Location = new System.Drawing.Point(3, 3);
            this.lvwOrchestrations.Name = "lvwOrchestrations";
            this.lvwOrchestrations.Size = new System.Drawing.Size(686, 377);
            this.lvwOrchestrations.TabIndex = 8;
            this.lvwOrchestrations.UseCompatibleStateImageBehavior = false;
            this.lvwOrchestrations.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderOrchestration
            // 
            this.columnHeaderOrchestration.Text = "Orchestration";
            this.columnHeaderOrchestration.Width = 320;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 112;
            // 
            // BizTalkPortAndOrchsCollectorShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 470);
            this.Controls.Add(this.tabControl1);
            this.ExportButtonVisible = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BizTalkPortAndOrchsCollectorShowDetails";
            this.Text = "BizTalk port and orchestration collector details";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ListViewEx lvwReceiveLocations;
        private System.Windows.Forms.ColumnHeader columnHeaderPort;
        private System.Windows.Forms.ColumnHeader columnHeaderLocation;
        private System.Windows.Forms.ColumnHeader columnHeaderDisabled;
        private System.Windows.Forms.TabPage tabPage2;
        private ListViewEx lvwSendPorts;
        private System.Windows.Forms.ColumnHeader columnHeaderSendPort;
        private System.Windows.Forms.ColumnHeader columnHeaderState;
        private System.Windows.Forms.TabPage tabPage3;
        private ListViewEx lvwOrchestrations;
        private System.Windows.Forms.ColumnHeader columnHeaderOrchestration;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}