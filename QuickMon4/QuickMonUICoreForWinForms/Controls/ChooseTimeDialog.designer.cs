namespace HenIT.Controls
{
    partial class ChooseTimeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseTimeDialog));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkPM = new System.Windows.Forms.CheckBox();
            this.clockControl1 = new HenIT.Controls.ClockControl();
            this.cmdNow = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(146, 239);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Enabled = false;
            this.cmdOK.Location = new System.Drawing.Point(65, 239);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkPM);
            this.panel1.Controls.Add(this.clockControl1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 232);
            this.panel1.TabIndex = 0;
            // 
            // chkPM
            // 
            this.chkPM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPM.AutoSize = true;
            this.chkPM.Location = new System.Drawing.Point(11, 210);
            this.chkPM.Name = "chkPM";
            this.chkPM.Size = new System.Drawing.Size(42, 17);
            this.chkPM.TabIndex = 1;
            this.chkPM.Text = "PM";
            this.chkPM.UseVisualStyleBackColor = true;
            this.chkPM.CheckedChanged += new System.EventHandler(this.chkPM_CheckedChanged);
            // 
            // clockControl1
            // 
            this.clockControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clockControl1.ClockBorder = System.Drawing.Color.Black;
            this.clockControl1.ClockPadding = 20;
            this.clockControl1.FiveMinuteLines = System.Drawing.Color.Maroon;
            this.clockControl1.HourHandColor = System.Drawing.Color.Red;
            this.clockControl1.IsAM = true;
            this.clockControl1.Location = new System.Drawing.Point(3, 3);
            this.clockControl1.MinuteHandColor = System.Drawing.Color.DimGray;
            this.clockControl1.MinuteLines = System.Drawing.Color.Red;
            this.clockControl1.Name = "clockControl1";
            this.clockControl1.SelectedHour = 0;
            this.clockControl1.SelectedMinute = 0;
            this.clockControl1.Size = new System.Drawing.Size(220, 224);
            this.clockControl1.TabIndex = 0;
            this.clockControl1.Text = "clockControl1";
            this.clockControl1.AMPMChanged += new HenIT.Controls.AMPMChangedDelegate(this.clockControl1_AMPMChanged);
            this.clockControl1.TimeChanged += new HenIT.Controls.TimeChangedDelegate(this.clockControl1_TimeChanged);
            // 
            // cmdNow
            // 
            this.cmdNow.Location = new System.Drawing.Point(12, 239);
            this.cmdNow.Name = "cmdNow";
            this.cmdNow.Size = new System.Drawing.Size(47, 23);
            this.cmdNow.TabIndex = 1;
            this.cmdNow.Text = "Now";
            this.cmdNow.UseVisualStyleBackColor = true;
            this.cmdNow.Click += new System.EventHandler(this.cmdNow_Click);
            // 
            // ChooseTimeDialog
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(229, 268);
            this.ControlBox = false;
            this.Controls.Add(this.cmdNow);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseTimeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ChooseTimeDialog";
            this.Load += new System.EventHandler(this.ChooseTimeDialog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChooseTimeDialog_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private ClockControl clockControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkPM;
        private System.Windows.Forms.Button cmdNow;
    }
}