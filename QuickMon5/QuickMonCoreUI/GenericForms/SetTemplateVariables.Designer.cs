namespace QuickMon.UI
{
    partial class SetTemplateVariables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetTemplateVariables));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdNextVar = new System.Windows.Forms.Button();
            this.cmdPrevVar = new System.Windows.Forms.Button();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvwVariables = new QuickMon.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtVariableValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVariableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdNextVar);
            this.panel1.Controls.Add(this.cmdPrevVar);
            this.panel1.Controls.Add(this.cmdAccept);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 312);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 35);
            this.panel1.TabIndex = 4;
            // 
            // cmdNextVar
            // 
            this.cmdNextVar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNextVar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdNextVar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.cmdNextVar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.cmdNextVar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNextVar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNextVar.Location = new System.Drawing.Point(132, 4);
            this.cmdNextVar.Name = "cmdNextVar";
            this.cmdNextVar.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.cmdNextVar.Size = new System.Drawing.Size(33, 27);
            this.cmdNextVar.TabIndex = 1;
            this.cmdNextVar.Text = "►";
            this.cmdNextVar.UseVisualStyleBackColor = true;
            this.cmdNextVar.Click += new System.EventHandler(this.cmdNextVar_Click);
            // 
            // cmdPrevVar
            // 
            this.cmdPrevVar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrevVar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdPrevVar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.cmdPrevVar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.cmdPrevVar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPrevVar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrevVar.Location = new System.Drawing.Point(93, 4);
            this.cmdPrevVar.Name = "cmdPrevVar";
            this.cmdPrevVar.Size = new System.Drawing.Size(33, 27);
            this.cmdPrevVar.TabIndex = 0;
            this.cmdPrevVar.Text = "◄";
            this.cmdPrevVar.UseVisualStyleBackColor = true;
            this.cmdPrevVar.Click += new System.EventHandler(this.cmdPrevVar_Click);
            // 
            // cmdAccept
            // 
            this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAccept.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdAccept.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.cmdAccept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.cmdAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAccept.Location = new System.Drawing.Point(300, 4);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(75, 27);
            this.cmdAccept.TabIndex = 2;
            this.cmdAccept.Text = "Accept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvwVariables);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtVariableValue);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txtVariableName);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(384, 312);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 5;
            // 
            // lvwVariables
            // 
            this.lvwVariables.AutoResizeColumnEnabled = false;
            this.lvwVariables.AutoResizeColumnIndex = 1;
            this.lvwVariables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwVariables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwVariables.FullRowSelect = true;
            this.lvwVariables.HideSelection = false;
            this.lvwVariables.Location = new System.Drawing.Point(0, 0);
            this.lvwVariables.MultiSelect = false;
            this.lvwVariables.Name = "lvwVariables";
            this.lvwVariables.Size = new System.Drawing.Size(384, 225);
            this.lvwVariables.TabIndex = 6;
            this.lvwVariables.UseCompatibleStateImageBehavior = false;
            this.lvwVariables.View = System.Windows.Forms.View.Details;
            this.lvwVariables.SelectedIndexChanged += new System.EventHandler(this.lvwVariables_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Variable";
            this.columnHeader1.Width = 171;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 199;
            // 
            // txtVariableValue
            // 
            this.txtVariableValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVariableValue.Location = new System.Drawing.Point(93, 31);
            this.txtVariableValue.Multiline = true;
            this.txtVariableValue.Name = "txtVariableValue";
            this.txtVariableValue.Size = new System.Drawing.Size(279, 46);
            this.txtVariableValue.TabIndex = 3;
            this.txtVariableValue.TextChanged += new System.EventHandler(this.txtVariableValue_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Value";
            // 
            // txtVariableName
            // 
            this.txtVariableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVariableName.Location = new System.Drawing.Point(93, 5);
            this.txtVariableName.Name = "txtVariableName";
            this.txtVariableName.ReadOnly = true;
            this.txtVariableName.Size = new System.Drawing.Size(279, 20);
            this.txtVariableName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Variable";
            // 
            // SetTemplateVariables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 347);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetTemplateVariables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Variables";
            this.Load += new System.EventHandler(this.SetTemplateVariables_Load);
            this.Shown += new System.EventHandler(this.SetTemplateVariables_Shown);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ListViewEx lvwVariables;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtVariableValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVariableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdNextVar;
        private System.Windows.Forms.Button cmdPrevVar;
    }
}