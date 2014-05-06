namespace QuickMon.Collectors
{
    partial class PowerShellScriptRunnerShowDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PowerShellScriptRunnerShowDetails));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvwScripts = new QuickMon.ListViewEx();
            this.statesImageList = new System.Windows.Forms.ImageList(this.components);
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtPSScriptResults = new System.Windows.Forms.TextBox();
            this.selectItemRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdRunScript = new System.Windows.Forms.Button();
            this.txtPSScript = new System.Windows.Forms.TextBox();
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvwScripts);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(720, 370);
            this.splitContainer1.SplitterDistance = 251;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 13;
            // 
            // lvwScripts
            // 
            this.lvwScripts.AutoResizeColumnEnabled = false;
            this.lvwScripts.AutoResizeColumnIndex = 0;
            this.lvwScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader});
            this.lvwScripts.ContextMenuStrip = this.refreshContextMenuStrip;
            this.lvwScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwScripts.Location = new System.Drawing.Point(0, 0);
            this.lvwScripts.Name = "lvwScripts";
            this.lvwScripts.Size = new System.Drawing.Size(251, 370);
            this.lvwScripts.SmallImageList = this.statesImageList;
            this.lvwScripts.TabIndex = 0;
            this.lvwScripts.UseCompatibleStateImageBehavior = false;
            this.lvwScripts.View = System.Windows.Forms.View.Details;
            this.lvwScripts.SelectedIndexChanged += new System.EventHandler(this.lvwScripts_SelectedIndexChanged);
            // 
            // statesImageList
            // 
            this.statesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("statesImageList.ImageStream")));
            this.statesImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.statesImageList.Images.SetKeyName(0, "GUnknown.ico");
            this.statesImageList.Images.SetKeyName(1, "GRunning.ico");
            this.statesImageList.Images.SetKeyName(2, "GPaused.ico");
            this.statesImageList.Images.SetKeyName(3, "GStopped.ico");
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Script name";
            this.nameColumnHeader.Width = 178;
            // 
            // txtPSScriptResults
            // 
            this.txtPSScriptResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPSScriptResults.Location = new System.Drawing.Point(0, 16);
            this.txtPSScriptResults.Multiline = true;
            this.txtPSScriptResults.Name = "txtPSScriptResults";
            this.txtPSScriptResults.ReadOnly = true;
            this.txtPSScriptResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPSScriptResults.Size = new System.Drawing.Size(463, 164);
            this.txtPSScriptResults.TabIndex = 0;
            this.txtPSScriptResults.WordWrap = false;
            // 
            // selectItemRefreshTimer
            // 
            this.selectItemRefreshTimer.Interval = 200;
            this.selectItemRefreshTimer.Tick += new System.EventHandler(this.selectItemRefreshTimer_Tick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtPSScript);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtPSScriptResults);
            this.splitContainer2.Panel2.Controls.Add(this.cmdViewDetails);
            this.splitContainer2.Size = new System.Drawing.Size(463, 370);
            this.splitContainer2.SplitterDistance = 184;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmdRunScript);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 25);
            this.panel1.TabIndex = 0;
            // 
            // cmdRunScript
            // 
            this.cmdRunScript.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdRunScript.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRunScript.Location = new System.Drawing.Point(0, 0);
            this.cmdRunScript.Name = "cmdRunScript";
            this.cmdRunScript.Size = new System.Drawing.Size(67, 25);
            this.cmdRunScript.TabIndex = 0;
            this.cmdRunScript.Text = "Run script";
            this.cmdRunScript.UseVisualStyleBackColor = true;
            this.cmdRunScript.Click += new System.EventHandler(this.cmdRunScript_Click);
            // 
            // txtPSScript
            // 
            this.txtPSScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPSScript.Location = new System.Drawing.Point(0, 0);
            this.txtPSScript.Multiline = true;
            this.txtPSScript.Name = "txtPSScript";
            this.txtPSScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPSScript.Size = new System.Drawing.Size(463, 159);
            this.txtPSScript.TabIndex = 1;
            this.txtPSScript.WordWrap = false;
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.BackColor = System.Drawing.Color.DarkGray;
            this.cmdViewDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdViewDetails.FlatAppearance.BorderSize = 0;
            this.cmdViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDetails.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdViewDetails.Location = new System.Drawing.Point(0, 0);
            this.cmdViewDetails.Margin = new System.Windows.Forms.Padding(0);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(463, 16);
            this.cmdViewDetails.TabIndex = 10;
            this.cmdViewDetails.Text = "uuu";
            this.cmdViewDetails.UseVisualStyleBackColor = false;
            this.cmdViewDetails.Click += new System.EventHandler(this.cmdViewDetails_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(73, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please note changes to the script are not saved.!";
            // 
            // PowerShellScriptRunnerShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 431);
            this.Controls.Add(this.splitContainer1);
            this.ExportButtonVisible = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(550, 360);
            this.Name = "PowerShellScriptRunnerShowDetails";
            this.Text = "PowerShellScriptRunnerShowDetails";
            this.Load += new System.EventHandler(this.PowerShellScriptRunnerShowDetails_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ListViewEx lvwScripts;
        private System.Windows.Forms.ImageList statesImageList;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.TextBox txtPSScriptResults;
        private System.Windows.Forms.Timer selectItemRefreshTimer;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtPSScript;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdRunScript;
        private System.Windows.Forms.Button cmdViewDetails;
        private System.Windows.Forms.Label label1;
    }
}