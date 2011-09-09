namespace HenIT.Controls
{
    partial class DateTimeChooser
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
            this.panelTime = new System.Windows.Forms.Panel();
            this.txtMinute = new System.Windows.Forms.TextBox();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.cmdTimePicker = new System.Windows.Forms.Button();
            this.panelTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTime
            // 
            this.panelTime.BackColor = System.Drawing.SystemColors.Window;
            this.panelTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTime.Controls.Add(this.txtMinute);
            this.panelTime.Controls.Add(this.txtHour);
            this.panelTime.Controls.Add(this.label2);
            this.panelTime.Location = new System.Drawing.Point(84, 1);
            this.panelTime.Name = "panelTime";
            this.panelTime.Size = new System.Drawing.Size(40, 21);
            this.panelTime.TabIndex = 12;
            // 
            // txtMinute
            // 
            this.txtMinute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMinute.Location = new System.Drawing.Point(18, 2);
            this.txtMinute.Name = "txtMinute";
            this.txtMinute.Size = new System.Drawing.Size(15, 13);
            this.txtMinute.TabIndex = 10;
            this.txtMinute.Text = "59";
            this.txtMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinute.TextChanged += new System.EventHandler(this.txtMinute_TextChanged);
            this.txtMinute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMinute_KeyDown);
            this.txtMinute.Leave += new System.EventHandler(this.txtMinute_Leave);
            // 
            // txtHour
            // 
            this.txtHour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHour.Location = new System.Drawing.Point(0, 2);
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(15, 13);
            this.txtHour.TabIndex = 8;
            this.txtHour.Text = "23";
            this.txtHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHour.TextChanged += new System.EventHandler(this.txtHour_TextChanged);
            this.txtHour.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHour_KeyDown);
            this.txtHour.Leave += new System.EventHandler(this.txtHour_Leave);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(8, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = ":";
            // 
            // dtDate
            // 
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(0, 1);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(85, 20);
            this.dtDate.TabIndex = 11;
            this.dtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtDate_KeyDown);
            // 
            // cmdTimePicker
            // 
            this.cmdTimePicker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTimePicker.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdTimePicker.Location = new System.Drawing.Point(123, 1);
            this.cmdTimePicker.Name = "cmdTimePicker";
            this.cmdTimePicker.Size = new System.Drawing.Size(20, 20);
            this.cmdTimePicker.TabIndex = 13;
            this.cmdTimePicker.Text = "·";
            this.cmdTimePicker.UseVisualStyleBackColor = true;
            this.cmdTimePicker.Click += new System.EventHandler(this.cmdTimePicker_Click);
            // 
            // DateTimeChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmdTimePicker);
            this.Controls.Add(this.panelTime);
            this.Controls.Add(this.dtDate);
            this.Name = "DateTimeChooser";
            this.Size = new System.Drawing.Size(146, 25);
            this.panelTime.ResumeLayout(false);
            this.panelTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTime;
        private System.Windows.Forms.TextBox txtMinute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHour;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Button cmdTimePicker;
    }
}
