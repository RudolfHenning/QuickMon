﻿namespace QuickMon.UI
{
    partial class RAWXmlEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RAWXmlEditor));
            this.cmdFormat = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.llblImportConfig = new System.Windows.Forms.LinkLabel();
            this.txtConfig = new FastColoredTextBoxNS.FastColoredTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdFormat
            // 
            this.cmdFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFormat.Enabled = false;
            this.cmdFormat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdFormat.Location = new System.Drawing.Point(341, 386);
            this.cmdFormat.Name = "cmdFormat";
            this.cmdFormat.Size = new System.Drawing.Size(75, 23);
            this.cmdFormat.TabIndex = 6;
            this.cmdFormat.Text = "Format";
            this.cmdFormat.UseVisualStyleBackColor = true;
            this.cmdFormat.Click += new System.EventHandler(this.cmdFormat_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(503, 386);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 8;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(422, 386);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 7;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // llblImportConfig
            // 
            this.llblImportConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblImportConfig.AutoSize = true;
            this.llblImportConfig.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblImportConfig.Location = new System.Drawing.Point(12, 391);
            this.llblImportConfig.Name = "llblImportConfig";
            this.llblImportConfig.Size = new System.Drawing.Size(97, 13);
            this.llblImportConfig.TabIndex = 9;
            this.llblImportConfig.TabStop = true;
            this.llblImportConfig.Text = "Import from existing";
            // 
            // txtConfig
            // 
            this.txtConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfig.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtConfig.AutoIndentCharsPatterns = "";
            this.txtConfig.AutoScrollMinSize = new System.Drawing.Size(0, 14);
            this.txtConfig.BackBrush = null;
            this.txtConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfig.CharHeight = 14;
            this.txtConfig.CharWidth = 8;
            this.txtConfig.CommentPrefix = null;
            this.txtConfig.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfig.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtConfig.IsReplaceMode = false;
            this.txtConfig.Language = FastColoredTextBoxNS.Language.XML;
            this.txtConfig.LeftBracket = '<';
            this.txtConfig.LeftBracket2 = '(';
            this.txtConfig.Location = new System.Drawing.Point(-1, -1);
            this.txtConfig.Name = "txtConfig";
            this.txtConfig.Paddings = new System.Windows.Forms.Padding(0);
            this.txtConfig.RightBracket = '>';
            this.txtConfig.RightBracket2 = ')';
            this.txtConfig.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtConfig.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtConfig.ServiceColors")));
            this.txtConfig.Size = new System.Drawing.Size(589, 359);
            this.txtConfig.TabIndex = 10;
            this.txtConfig.WordWrap = true;
            this.txtConfig.Zoom = 100;
            this.txtConfig.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.txtConfig_TextChangedDelayed);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(8, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(569, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "Warning: Manual editing can break config. Please be careful.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RAWXmlEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 418);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConfig);
            this.Controls.Add(this.llblImportConfig);
            this.Controls.Add(this.cmdFormat);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 380);
            this.Name = "RAWXmlEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RAWXmlEditor";
            this.Load += new System.EventHandler(this.RAWXmlEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtConfig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdFormat;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.LinkLabel llblImportConfig;
        private FastColoredTextBoxNS.FastColoredTextBox txtConfig;
        private System.Windows.Forms.Label label1;
    }
}