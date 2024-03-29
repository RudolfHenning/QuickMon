﻿namespace QuickMon
{
    partial class AboutQuickMon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutQuickMon));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVersionInfo = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblCoreVersion = new System.Windows.Forms.Label();
            this.latestVersionCheckBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lblReleaseState = new System.Windows.Forms.Label();
            this.llblChangeLog = new System.Windows.Forms.LinkLabel();
            this.cmdClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::QuickMon.Properties.Resources.QM5;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(345, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 119);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCreateDate.BackColor = System.Drawing.Color.Transparent;
            this.lblCreateDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateDate.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCreateDate.Location = new System.Drawing.Point(12, 286);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(366, 21);
            this.lblCreateDate.TabIndex = 5;
            this.lblCreateDate.Text = "Created on";
            this.lblCreateDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCompany
            // 
            this.lblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCompany.BackColor = System.Drawing.Color.Transparent;
            this.lblCompany.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCompany.Location = new System.Drawing.Point(12, 257);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(365, 21);
            this.lblCompany.TabIndex = 4;
            this.lblCompany.Text = "Created by";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(99, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "QuickMon";
            // 
            // lblVersionInfo
            // 
            this.lblVersionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersionInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblVersionInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionInfo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblVersionInfo.Location = new System.Drawing.Point(107, 66);
            this.lblVersionInfo.Name = "lblVersionInfo";
            this.lblVersionInfo.Size = new System.Drawing.Size(183, 21);
            this.lblVersionInfo.TabIndex = 1;
            this.lblVersionInfo.Text = "Version";
            this.lblVersionInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.DarkBlue;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.MediumBlue;
            this.linkLabel1.Location = new System.Drawing.Point(107, 328);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(183, 18);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Check for latest version";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblCoreVersion
            // 
            this.lblCoreVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCoreVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblCoreVersion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoreVersion.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCoreVersion.Location = new System.Drawing.Point(107, 95);
            this.lblCoreVersion.Name = "lblCoreVersion";
            this.lblCoreVersion.Size = new System.Drawing.Size(183, 21);
            this.lblCoreVersion.TabIndex = 2;
            this.lblCoreVersion.Text = "Core";
            this.lblCoreVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // latestVersionCheckBackgroundWorker
            // 
            this.latestVersionCheckBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.latestVersionCheckBackgroundWorker_DoWork);
            // 
            // lblReleaseState
            // 
            this.lblReleaseState.AutoSize = true;
            this.lblReleaseState.BackColor = System.Drawing.Color.Transparent;
            this.lblReleaseState.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReleaseState.ForeColor = System.Drawing.Color.Red;
            this.lblReleaseState.Location = new System.Drawing.Point(145, 229);
            this.lblReleaseState.Name = "lblReleaseState";
            this.lblReleaseState.Size = new System.Drawing.Size(98, 25);
            this.lblReleaseState.TabIndex = 3;
            this.lblReleaseState.Text = "Release";
            this.lblReleaseState.Visible = false;
            // 
            // llblChangeLog
            // 
            this.llblChangeLog.BackColor = System.Drawing.Color.Transparent;
            this.llblChangeLog.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblChangeLog.Location = new System.Drawing.Point(111, 330);
            this.llblChangeLog.Name = "llblChangeLog";
            this.llblChangeLog.Size = new System.Drawing.Size(179, 23);
            this.llblChangeLog.TabIndex = 8;
            this.llblChangeLog.TabStop = true;
            this.llblChangeLog.Text = "Change log";
            this.llblChangeLog.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.llblChangeLog.Visible = false;
            this.llblChangeLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblChangeLog_LinkClicked);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmdClose.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cmdClose.Location = new System.Drawing.Point(363, -1);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(27, 27);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "X";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // AboutQuickMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::QuickMon.Properties.Resources.QMSplash;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(390, 356);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lblReleaseState);
            this.Controls.Add(this.lblCoreVersion);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCreateDate);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVersionInfo);
            this.Controls.Add(this.llblChangeLog);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "AboutQuickMon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About QuickMon";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.AboutQuickMon_Load);
            this.Click += new System.EventHandler(this.AboutQuickMon_Click);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AboutQuickMon_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AboutQuickMon_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AboutQuickMon_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AboutQuickMon_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersionInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblCreateDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblCoreVersion;
        private System.ComponentModel.BackgroundWorker latestVersionCheckBackgroundWorker;
        private System.Windows.Forms.Label lblReleaseState;
        private System.Windows.Forms.LinkLabel llblChangeLog;
        private System.Windows.Forms.Button cmdClose;
    }
}