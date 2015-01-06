namespace QuickMon.Forms
{
    partial class CSVEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSVEditor));
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.cmdAddUpdate = new System.Windows.Forms.Button();
            this.lstItem = new System.Windows.Forms.ListBox();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.lblTips = new System.Windows.Forms.Label();
            this.cmdMoveUp = new System.Windows.Forms.Button();
            this.cmdMoveDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(229, 208);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(310, 208);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // lblItemName
            // 
            this.lblItemName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblItemName.Location = new System.Drawing.Point(12, 15);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(79, 18);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "&Item";
            // 
            // txtItem
            // 
            this.txtItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItem.Location = new System.Drawing.Point(94, 12);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(210, 20);
            this.txtItem.TabIndex = 1;
            this.txtItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItem_KeyPress);
            // 
            // cmdAddUpdate
            // 
            this.cmdAddUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAddUpdate.Location = new System.Drawing.Point(310, 10);
            this.cmdAddUpdate.Name = "cmdAddUpdate";
            this.cmdAddUpdate.Size = new System.Drawing.Size(75, 23);
            this.cmdAddUpdate.TabIndex = 2;
            this.cmdAddUpdate.Text = "&Add";
            this.cmdAddUpdate.UseVisualStyleBackColor = true;
            this.cmdAddUpdate.Click += new System.EventHandler(this.cmdAddUpdate_Click);
            // 
            // lstItem
            // 
            this.lstItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstItem.FormattingEnabled = true;
            this.lstItem.Location = new System.Drawing.Point(12, 40);
            this.lstItem.Name = "lstItem";
            this.lstItem.Size = new System.Drawing.Size(292, 145);
            this.lstItem.Sorted = true;
            this.lstItem.TabIndex = 3;
            this.lstItem.SelectedIndexChanged += new System.EventHandler(this.lstItem_SelectedIndexChanged);
            // 
            // cmdNew
            // 
            this.cmdNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNew.Location = new System.Drawing.Point(310, 39);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(75, 23);
            this.cmdNew.TabIndex = 4;
            this.cmdNew.Text = "&New";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemove.Enabled = false;
            this.cmdRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRemove.Location = new System.Drawing.Point(310, 68);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(75, 23);
            this.cmdRemove.TabIndex = 5;
            this.cmdRemove.Text = "&Remove";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // lblTips
            // 
            this.lblTips.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTips.Location = new System.Drawing.Point(17, 204);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(206, 31);
            this.lblTips.TabIndex = 8;
            this.lblTips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdMoveUp
            // 
            this.cmdMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMoveUp.Enabled = false;
            this.cmdMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdMoveUp.Location = new System.Drawing.Point(310, 97);
            this.cmdMoveUp.Name = "cmdMoveUp";
            this.cmdMoveUp.Size = new System.Drawing.Size(75, 23);
            this.cmdMoveUp.TabIndex = 9;
            this.cmdMoveUp.Text = "&Move up";
            this.cmdMoveUp.UseVisualStyleBackColor = true;
            this.cmdMoveUp.Visible = false;
            this.cmdMoveUp.Click += new System.EventHandler(this.cmdMoveUp_Click);
            // 
            // cmdMoveDown
            // 
            this.cmdMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMoveDown.Enabled = false;
            this.cmdMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdMoveDown.Location = new System.Drawing.Point(310, 126);
            this.cmdMoveDown.Name = "cmdMoveDown";
            this.cmdMoveDown.Size = new System.Drawing.Size(75, 23);
            this.cmdMoveDown.TabIndex = 10;
            this.cmdMoveDown.Text = "Move  &down";
            this.cmdMoveDown.UseVisualStyleBackColor = true;
            this.cmdMoveDown.Visible = false;
            this.cmdMoveDown.Click += new System.EventHandler(this.cmdMoveDown_Click);
            // 
            // CSVEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(397, 243);
            this.Controls.Add(this.cmdMoveDown);
            this.Controls.Add(this.cmdMoveUp);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.lblTips);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.lstItem);
            this.Controls.Add(this.cmdAddUpdate);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 260);
            this.Name = "CSVEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSVEditor";
            this.Load += new System.EventHandler(this.CSVEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Button cmdAddUpdate;
        private System.Windows.Forms.ListBox lstItem;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.Button cmdMoveUp;
        private System.Windows.Forms.Button cmdMoveDown;
    }
}