using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Controls
{
    public class PoppedContainer : UserControl
    {
        public PoppedContainer()
        {
            InitializeComponent();
        }

        #region Component Designer generated code
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PoppedContainer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PoppedContainer";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.Size = new System.Drawing.Size(40, 32);
            this.ResumeLayout(false);

        }
        #endregion

        protected override bool ProcessDialogKey(Keys keyData)
        {
            // Alt+F4 is to closing
            if ((keyData & Keys.Alt) == Keys.Alt)
                if ((keyData & Keys.F4) == Keys.F4)
                {
                    this.Parent.Hide();
                    return true;
                }

            if ((keyData & Keys.Enter) == Keys.Enter)
            {
                if (this.ActiveControl is Button)
                {
                    (this.ActiveControl as Button).PerformClick();
                    return true;
                }
            }

            return base.ProcessDialogKey(keyData);
        }
    }
}
