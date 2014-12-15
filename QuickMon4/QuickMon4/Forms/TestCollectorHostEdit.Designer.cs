namespace QuickMon
{
    partial class TestCollectorHostEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestCollectorHostEdit));
            this.button1 = new System.Windows.Forms.Button();
            this.txtConfig = new FastColoredTextBoxNS.FastColoredTextBox();
            this.configEditContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfig)).BeginInit();
            this.configEditContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Edit Collector Host";
            this.button1.UseVisualStyleBackColor = true;
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
            this.txtConfig.AutoScrollMinSize = new System.Drawing.Size(0, 280);
            this.txtConfig.BackBrush = null;
            this.txtConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfig.CharHeight = 14;
            this.txtConfig.CharWidth = 8;
            this.txtConfig.CommentPrefix = null;
            this.txtConfig.ContextMenuStrip = this.configEditContextMenuStrip;
            this.txtConfig.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfig.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtConfig.IsReplaceMode = false;
            this.txtConfig.Language = FastColoredTextBoxNS.Language.XML;
            this.txtConfig.LeftBracket = '<';
            this.txtConfig.LeftBracket2 = '(';
            this.txtConfig.Location = new System.Drawing.Point(4, 41);
            this.txtConfig.Name = "txtConfig";
            this.txtConfig.Paddings = new System.Windows.Forms.Padding(0);
            this.txtConfig.RightBracket = '>';
            this.txtConfig.RightBracket2 = ')';
            this.txtConfig.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtConfig.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtConfig.ServiceColors")));
            this.txtConfig.Size = new System.Drawing.Size(561, 388);
            this.txtConfig.TabIndex = 1;
            this.txtConfig.Text = resources.GetString("txtConfig.Text");
            this.txtConfig.WordWrap = true;
            this.txtConfig.Zoom = 100;
            // 
            // configEditContextMenuStrip
            // 
            this.configEditContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.formatToolStripMenuItem});
            this.configEditContextMenuStrip.Name = "configEditContextMenuStrip";
            this.configEditContextMenuStrip.Size = new System.Drawing.Size(123, 92);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.formatToolStripMenuItem.Text = "Format";
            this.formatToolStripMenuItem.Click += new System.EventHandler(this.formatToolStripMenuItem_Click);
            // 
            // TestCollectorHostEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 431);
            this.Controls.Add(this.txtConfig);
            this.Controls.Add(this.button1);
            this.Name = "TestCollectorHostEdit";
            this.Text = "TestCollectorHostEdit";
            this.Load += new System.EventHandler(this.TestCollectorHostEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtConfig)).EndInit();
            this.configEditContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private FastColoredTextBoxNS.FastColoredTextBox txtConfig;
        private System.Windows.Forms.ContextMenuStrip configEditContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
    }
}