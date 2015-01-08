using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Controls
{
    public partial class CollectorContextMenuControl
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
            this.cmdDeleteCollector = new System.Windows.Forms.Button();
            this.cmdDisableCollector = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdAbout = new System.Windows.Forms.Button();
            this.cmdGeneralSettings = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdSaveMonitorPack = new System.Windows.Forms.Button();
            this.cmdLoadRecentMonitorPack = new System.Windows.Forms.Button();
            this.cmdLoadMonitorPack = new System.Windows.Forms.Button();
            this.cmdNewMonitorPack = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdPasteWithEdit = new System.Windows.Forms.Button();
            this.cmdPaste = new System.Windows.Forms.Button();
            this.cmdCopy = new System.Windows.Forms.Button();
            this.cmdEditCollector = new System.Windows.Forms.Button();
            this.cmdAddCollector = new System.Windows.Forms.Button();
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblCollectorHeading = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdDeleteCollector);
            this.panel1.Controls.Add(this.cmdDisableCollector);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 27);
            this.panel1.TabIndex = 2;
            // 
            // cmdDeleteCollector
            // 
            this.cmdDeleteCollector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdDeleteCollector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdDeleteCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDeleteCollector.Image = global::QuickMon.Properties.Resources.stop16x16;
            this.cmdDeleteCollector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDeleteCollector.Location = new System.Drawing.Point(115, 0);
            this.cmdDeleteCollector.Name = "cmdDeleteCollector";
            this.cmdDeleteCollector.Padding = new System.Windows.Forms.Padding(0, 2, 5, 0);
            this.cmdDeleteCollector.Size = new System.Drawing.Size(113, 27);
            this.cmdDeleteCollector.TabIndex = 10;
            this.cmdDeleteCollector.Text = "Delete";
            this.cmdDeleteCollector.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdDeleteCollector, "Delete collector");
            this.cmdDeleteCollector.UseVisualStyleBackColor = true;
            // 
            // cmdDisableCollector
            // 
            this.cmdDisableCollector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdDisableCollector.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdDisableCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDisableCollector.Image = global::QuickMon.Properties.Resources.ForbiddenBue16x16;
            this.cmdDisableCollector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDisableCollector.Location = new System.Drawing.Point(0, 0);
            this.cmdDisableCollector.Name = "cmdDisableCollector";
            this.cmdDisableCollector.Padding = new System.Windows.Forms.Padding(2);
            this.cmdDisableCollector.Size = new System.Drawing.Size(115, 27);
            this.cmdDisableCollector.TabIndex = 1;
            this.cmdDisableCollector.Text = "Disable";
            this.cmdDisableCollector.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdDisableCollector, "Enable/Disable");
            this.cmdDisableCollector.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkGray;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(4, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 1);
            this.label3.TabIndex = 8;
            this.label3.Text = "Add new";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdAbout);
            this.panel2.Controls.Add(this.cmdGeneralSettings);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cmdSaveMonitorPack);
            this.panel2.Controls.Add(this.cmdLoadRecentMonitorPack);
            this.panel2.Controls.Add(this.cmdLoadMonitorPack);
            this.panel2.Controls.Add(this.cmdNewMonitorPack);
            this.panel2.Controls.Add(this.cmdRefresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 235);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 28);
            this.panel2.TabIndex = 6;
            // 
            // cmdAbout
            // 
            this.cmdAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdAbout.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdAbout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAbout.Image = global::QuickMon.Properties.Resources.info16x16;
            this.cmdAbout.Location = new System.Drawing.Point(194, 0);
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Padding = new System.Windows.Forms.Padding(2);
            this.cmdAbout.Size = new System.Drawing.Size(32, 28);
            this.cmdAbout.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cmdAbout, "About QuickMon 3");
            this.cmdAbout.UseVisualStyleBackColor = true;
            // 
            // cmdGeneralSettings
            // 
            this.cmdGeneralSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdGeneralSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdGeneralSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGeneralSettings.Image = global::QuickMon.Properties.Resources.tools16x16;
            this.cmdGeneralSettings.Location = new System.Drawing.Point(162, 0);
            this.cmdGeneralSettings.Name = "cmdGeneralSettings";
            this.cmdGeneralSettings.Padding = new System.Windows.Forms.Padding(2);
            this.cmdGeneralSettings.Size = new System.Drawing.Size(32, 28);
            this.cmdGeneralSettings.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cmdGeneralSettings, "General settings");
            this.cmdGeneralSettings.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkGray;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(160, 0);
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
            this.cmdSaveMonitorPack.Location = new System.Drawing.Point(128, 0);
            this.cmdSaveMonitorPack.Name = "cmdSaveMonitorPack";
            this.cmdSaveMonitorPack.Padding = new System.Windows.Forms.Padding(2);
            this.cmdSaveMonitorPack.Size = new System.Drawing.Size(32, 28);
            this.cmdSaveMonitorPack.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cmdSaveMonitorPack, "Save current monitor pack to file");
            this.cmdSaveMonitorPack.UseVisualStyleBackColor = true;
            // 
            // cmdLoadRecentMonitorPack
            // 
            this.cmdLoadRecentMonitorPack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdLoadRecentMonitorPack.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdLoadRecentMonitorPack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLoadRecentMonitorPack.Image = global::QuickMon.Properties.Resources.folderWLightning16x16;
            this.cmdLoadRecentMonitorPack.Location = new System.Drawing.Point(96, 0);
            this.cmdLoadRecentMonitorPack.Name = "cmdLoadRecentMonitorPack";
            this.cmdLoadRecentMonitorPack.Padding = new System.Windows.Forms.Padding(2);
            this.cmdLoadRecentMonitorPack.Size = new System.Drawing.Size(32, 28);
            this.cmdLoadRecentMonitorPack.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cmdLoadRecentMonitorPack, "Open recent monotor pack file");
            this.cmdLoadRecentMonitorPack.UseVisualStyleBackColor = true;
            // 
            // cmdLoadMonitorPack
            // 
            this.cmdLoadMonitorPack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdLoadMonitorPack.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdLoadMonitorPack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLoadMonitorPack.Image = global::QuickMon.Properties.Resources.folderOpen16x16;
            this.cmdLoadMonitorPack.Location = new System.Drawing.Point(64, 0);
            this.cmdLoadMonitorPack.Name = "cmdLoadMonitorPack";
            this.cmdLoadMonitorPack.Padding = new System.Windows.Forms.Padding(2);
            this.cmdLoadMonitorPack.Size = new System.Drawing.Size(32, 28);
            this.cmdLoadMonitorPack.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cmdLoadMonitorPack, "Open existing monitor pack file");
            this.cmdLoadMonitorPack.UseVisualStyleBackColor = true;
            // 
            // cmdNewMonitorPack
            // 
            this.cmdNewMonitorPack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdNewMonitorPack.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdNewMonitorPack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNewMonitorPack.Image = global::QuickMon.Properties.Resources.doc_new16x16;
            this.cmdNewMonitorPack.Location = new System.Drawing.Point(32, 0);
            this.cmdNewMonitorPack.Name = "cmdNewMonitorPack";
            this.cmdNewMonitorPack.Padding = new System.Windows.Forms.Padding(2);
            this.cmdNewMonitorPack.Size = new System.Drawing.Size(32, 28);
            this.cmdNewMonitorPack.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cmdNewMonitorPack, "Create new monitor pack");
            this.cmdNewMonitorPack.UseVisualStyleBackColor = true;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackgroundImage = global::QuickMon.Properties.Resources.refresh24x24;
            this.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRefresh.Location = new System.Drawing.Point(0, 0);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Padding = new System.Windows.Forms.Padding(2);
            this.cmdRefresh.Size = new System.Drawing.Size(32, 28);
            this.cmdRefresh.TabIndex = 0;
            this.toolTip1.SetToolTip(this.cmdRefresh, "Refresh");
            this.cmdRefresh.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gainsboro;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Image = global::QuickMon.Properties.Resources.MenuBlueShade;
            this.label4.Location = new System.Drawing.Point(4, 211);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Monitor pack";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdPasteWithEdit
            // 
            this.cmdPasteWithEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdPasteWithEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdPasteWithEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdPasteWithEdit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdPasteWithEdit.Image = global::QuickMon.Properties.Resources.pastewithedit;
            this.cmdPasteWithEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPasteWithEdit.Location = new System.Drawing.Point(147, 0);
            this.cmdPasteWithEdit.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.cmdPasteWithEdit.Name = "cmdPasteWithEdit";
            this.cmdPasteWithEdit.Padding = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.cmdPasteWithEdit.Size = new System.Drawing.Size(81, 27);
            this.cmdPasteWithEdit.TabIndex = 3;
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
            this.cmdPaste.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdPaste.Image = global::QuickMon.Properties.Resources.paste;
            this.cmdPaste.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPaste.Location = new System.Drawing.Point(76, 0);
            this.cmdPaste.Name = "cmdPaste";
            this.cmdPaste.Padding = new System.Windows.Forms.Padding(2, 2, 1, 2);
            this.cmdPaste.Size = new System.Drawing.Size(71, 27);
            this.cmdPaste.TabIndex = 2;
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
            this.cmdCopy.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdCopy.Image = global::QuickMon.Properties.Resources.copy;
            this.cmdCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCopy.Location = new System.Drawing.Point(0, 0);
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Padding = new System.Windows.Forms.Padding(2, 2, 1, 2);
            this.cmdCopy.Size = new System.Drawing.Size(76, 27);
            this.cmdCopy.TabIndex = 1;
            this.cmdCopy.Text = "Copy";
            this.cmdCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdCopy, "Copy selected Collector (and dependants)");
            this.cmdCopy.UseVisualStyleBackColor = true;
            // 
            // cmdEditCollector
            // 
            this.cmdEditCollector.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdEditCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditCollector.Image = global::QuickMon.Properties.Resources.Blue3DGearEdit;
            this.cmdEditCollector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditCollector.Location = new System.Drawing.Point(4, 68);
            this.cmdEditCollector.Name = "cmdEditCollector";
            this.cmdEditCollector.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.cmdEditCollector.Size = new System.Drawing.Size(228, 44);
            this.cmdEditCollector.TabIndex = 4;
            this.cmdEditCollector.Text = "&Edit configuration";
            this.toolTip1.SetToolTip(this.cmdEditCollector, "Edit collector configuration");
            this.cmdEditCollector.UseVisualStyleBackColor = true;
            // 
            // cmdAddCollector
            // 
            this.cmdAddCollector.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdAddCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAddCollector.Image = global::QuickMon.Properties.Resources.add;
            this.cmdAddCollector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddCollector.Location = new System.Drawing.Point(4, 24);
            this.cmdAddCollector.Name = "cmdAddCollector";
            this.cmdAddCollector.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.cmdAddCollector.Size = new System.Drawing.Size(228, 44);
            this.cmdAddCollector.TabIndex = 10;
            this.cmdAddCollector.Text = "&Add new";
            this.toolTip1.SetToolTip(this.cmdAddCollector, "Add new collector");
            this.cmdAddCollector.UseVisualStyleBackColor = true;
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDetails.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdViewDetails.Image = global::QuickMon.Properties.Resources.comp_search;
            this.cmdViewDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdViewDetails.Location = new System.Drawing.Point(4, 112);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.cmdViewDetails.Size = new System.Drawing.Size(228, 44);
            this.cmdViewDetails.TabIndex = 11;
            this.cmdViewDetails.Text = "&Details";
            this.toolTip1.SetToolTip(this.cmdViewDetails, "View collector details");
            this.cmdViewDetails.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmdPasteWithEdit);
            this.panel4.Controls.Add(this.cmdPaste);
            this.panel4.Controls.Add(this.cmdCopy);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 156);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(228, 27);
            this.panel4.TabIndex = 1;
            // 
            // lblCollectorHeading
            // 
            this.lblCollectorHeading.BackColor = System.Drawing.Color.Gainsboro;
            this.lblCollectorHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCollectorHeading.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCollectorHeading.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCollectorHeading.ForeColor = System.Drawing.Color.White;
            this.lblCollectorHeading.Image = global::QuickMon.Properties.Resources.MenuBlueShade;
            this.lblCollectorHeading.Location = new System.Drawing.Point(4, 4);
            this.lblCollectorHeading.Name = "lblCollectorHeading";
            this.lblCollectorHeading.Size = new System.Drawing.Size(228, 20);
            this.lblCollectorHeading.TabIndex = 0;
            this.lblCollectorHeading.Text = "Collector";
            this.lblCollectorHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCollectorHeading.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblCollectorHeading_MouseDown);
            // 
            // CollectorContextMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.cmdViewDetails);
            this.Controls.Add(this.cmdEditCollector);
            this.Controls.Add(this.cmdAddCollector);
            this.Controls.Add(this.lblCollectorHeading);
            this.Name = "CollectorContextMenuControl";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(236, 264);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Button cmdCopy;
        public System.Windows.Forms.Button cmdPaste;
        public System.Windows.Forms.Button cmdPasteWithEdit;
        private System.Windows.Forms.Label lblCollectorHeading;
        public System.Windows.Forms.Button cmdEditCollector;
        public System.Windows.Forms.Button cmdRefresh;
        public System.Windows.Forms.Button cmdDeleteCollector;
        public System.Windows.Forms.Button cmdDisableCollector;
        public System.Windows.Forms.Button cmdAddCollector;
        public System.Windows.Forms.Button cmdViewDetails;
    }
}
