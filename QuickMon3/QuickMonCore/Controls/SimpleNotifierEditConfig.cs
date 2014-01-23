using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public class SimpleNotifierEditConfig : Form, IEditConfigWindow
    {
        public SimpleNotifierEditConfig()
        {
            LocalInitializeComponent();
            
        }

        #region UI Components
        public System.Windows.Forms.Button cmdCancel;
        public System.Windows.Forms.Button cmdOK;
        private System.ComponentModel.IContainer components = null;
        private void LocalInitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(511, 321);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 21;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(430, 321);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 20;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);

            // 
            // EditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Name = "EditConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Confiig";
            this.Load += new System.EventHandler(this.SimpleNotifierEditConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private void SimpleNotifierEditConfig_Load(object sender, EventArgs e)
        {
            LoadEditData();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            OkClicked();
        }        

        #region IEditConfigWindow Members
        public IAgentConfig SelectedConfig { get; set; }
        public DialogResult ShowConfig()
        {
            return ShowDialog();
        }
        public void SetTitle(string title)
        {
            Text = title;
        }
        #endregion

        public virtual void LoadEditData()
        {
            
        }
        public virtual void OkClicked()
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        public virtual void SetOKEnabled(bool enabled)
        {
            this.cmdOK.Enabled = enabled;
        }
    }
}
