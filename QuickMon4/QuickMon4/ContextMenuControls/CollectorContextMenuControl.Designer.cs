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
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdPasteWithEdit = new System.Windows.Forms.Button();
            this.cmdPaste = new System.Windows.Forms.Button();
            this.cmdCopy = new System.Windows.Forms.Button();
            this.cmdEditCollector = new System.Windows.Forms.Button();
            this.cmdAddCollector = new System.Windows.Forms.Button();
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.cmdDisableCollector = new System.Windows.Forms.Button();
            this.cmdDeleteCollector = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblCollectorHeading = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkGray;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(4, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 1);
            this.label3.TabIndex = 8;
            this.label3.Text = "Add new";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cmdPaste.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdPaste.Image = global::QuickMon.Properties.Resources.paste;
            this.cmdPaste.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPaste.Location = new System.Drawing.Point(76, 0);
            this.cmdPaste.Name = "cmdPaste";
            this.cmdPaste.Padding = new System.Windows.Forms.Padding(2, 2, 1, 2);
            this.cmdPaste.Size = new System.Drawing.Size(71, 27);
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
            this.cmdCopy.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdCopy.Image = global::QuickMon.Properties.Resources.copy;
            this.cmdCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCopy.Location = new System.Drawing.Point(0, 0);
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Padding = new System.Windows.Forms.Padding(2, 2, 1, 2);
            this.cmdCopy.Size = new System.Drawing.Size(76, 27);
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
            this.cmdEditCollector.Image = global::QuickMon.Properties.Resources.Blue3DGearEdit;
            this.cmdEditCollector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditCollector.Location = new System.Drawing.Point(4, 68);
            this.cmdEditCollector.Name = "cmdEditCollector";
            this.cmdEditCollector.Padding = new System.Windows.Forms.Padding(2);
            this.cmdEditCollector.Size = new System.Drawing.Size(228, 44);
            this.cmdEditCollector.TabIndex = 2;
            this.cmdEditCollector.Text = "&Configuration";
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
            this.cmdAddCollector.Padding = new System.Windows.Forms.Padding(2);
            this.cmdAddCollector.Size = new System.Drawing.Size(228, 44);
            this.cmdAddCollector.TabIndex = 1;
            this.cmdAddCollector.Text = "&New";
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
            this.cmdViewDetails.Padding = new System.Windows.Forms.Padding(2);
            this.cmdViewDetails.Size = new System.Drawing.Size(228, 44);
            this.cmdViewDetails.TabIndex = 3;
            this.cmdViewDetails.Text = "&Details";
            this.toolTip1.SetToolTip(this.cmdViewDetails, "View collector details");
            this.cmdViewDetails.UseVisualStyleBackColor = true;
            // 
            // cmdDisableCollector
            // 
            this.cmdDisableCollector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdDisableCollector.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdDisableCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDisableCollector.Image = global::QuickMon.Properties.Resources.ForbiddenBue16x16;
            this.cmdDisableCollector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDisableCollector.Location = new System.Drawing.Point(4, 184);
            this.cmdDisableCollector.Name = "cmdDisableCollector";
            this.cmdDisableCollector.Padding = new System.Windows.Forms.Padding(2);
            this.cmdDisableCollector.Size = new System.Drawing.Size(228, 27);
            this.cmdDisableCollector.TabIndex = 5;
            this.cmdDisableCollector.Text = "Disable";
            this.toolTip1.SetToolTip(this.cmdDisableCollector, "Enable/Disable");
            this.cmdDisableCollector.UseVisualStyleBackColor = true;
            // 
            // cmdDeleteCollector
            // 
            this.cmdDeleteCollector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdDeleteCollector.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdDeleteCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDeleteCollector.Image = global::QuickMon.Properties.Resources.stop16x16;
            this.cmdDeleteCollector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDeleteCollector.Location = new System.Drawing.Point(4, 211);
            this.cmdDeleteCollector.Name = "cmdDeleteCollector";
            this.cmdDeleteCollector.Padding = new System.Windows.Forms.Padding(2);
            this.cmdDeleteCollector.Size = new System.Drawing.Size(228, 27);
            this.cmdDeleteCollector.TabIndex = 6;
            this.cmdDeleteCollector.Text = "Delete";
            this.toolTip1.SetToolTip(this.cmdDeleteCollector, "Delete collector");
            this.cmdDeleteCollector.UseVisualStyleBackColor = true;
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
            this.panel4.TabIndex = 4;
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
            this.Controls.Add(this.cmdDeleteCollector);
            this.Controls.Add(this.cmdDisableCollector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.cmdViewDetails);
            this.Controls.Add(this.cmdEditCollector);
            this.Controls.Add(this.cmdAddCollector);
            this.Controls.Add(this.lblCollectorHeading);
            this.Name = "CollectorContextMenuControl";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(236, 241);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Button cmdCopy;
        public System.Windows.Forms.Button cmdPaste;
        public System.Windows.Forms.Button cmdPasteWithEdit;
        private System.Windows.Forms.Label lblCollectorHeading;
        public System.Windows.Forms.Button cmdEditCollector;
        public System.Windows.Forms.Button cmdAddCollector;
        public System.Windows.Forms.Button cmdViewDetails;
        public System.Windows.Forms.Button cmdDisableCollector;
        public System.Windows.Forms.Button cmdDeleteCollector;
    }
}
