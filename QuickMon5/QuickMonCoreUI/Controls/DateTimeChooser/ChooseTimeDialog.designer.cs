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
            this.cmdNow = new System.Windows.Forms.Button();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.lbl11 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl12 = new System.Windows.Forms.Label();
            this.clockControl1 = new HenIT.Controls.ClockControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(154, 239);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(73, 239);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl12);
            this.panel1.Controls.Add(this.lbl5);
            this.panel1.Controls.Add(this.lbl4);
            this.panel1.Controls.Add(this.lbl3);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.lbl11);
            this.panel1.Controls.Add(this.lbl10);
            this.panel1.Controls.Add(this.lbl9);
            this.panel1.Controls.Add(this.lbl8);
            this.panel1.Controls.Add(this.lbl7);
            this.panel1.Controls.Add(this.lbl6);
            this.panel1.Controls.Add(this.chkPM);
            this.panel1.Controls.Add(this.clockControl1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 232);
            this.panel1.TabIndex = 0;
            // 
            // chkPM
            // 
            this.chkPM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPM.AutoSize = true;
            this.chkPM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkPM.Location = new System.Drawing.Point(5, 210);
            this.chkPM.Name = "chkPM";
            this.chkPM.Size = new System.Drawing.Size(41, 17);
            this.chkPM.TabIndex = 1;
            this.chkPM.Text = "PM";
            this.chkPM.UseVisualStyleBackColor = true;
            this.chkPM.CheckedChanged += new System.EventHandler(this.chkPM_CheckedChanged);
            // 
            // cmdNow
            // 
            this.cmdNow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNow.Location = new System.Drawing.Point(12, 239);
            this.cmdNow.Name = "cmdNow";
            this.cmdNow.Size = new System.Drawing.Size(47, 23);
            this.cmdNow.TabIndex = 0;
            this.cmdNow.Text = "Now";
            this.cmdNow.UseVisualStyleBackColor = true;
            this.cmdNow.Click += new System.EventHandler(this.cmdNow_Click);
            // 
            // lbl6
            // 
            this.lbl6.BackColor = System.Drawing.Color.Transparent;
            this.lbl6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl6.Location = new System.Drawing.Point(112, 210);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(10, 15);
            this.lbl6.TabIndex = 14;
            this.lbl6.Text = "o";
            this.lbl6.Click += new System.EventHandler(this.cmd6_Click);
            // 
            // lbl7
            // 
            this.lbl7.BackColor = System.Drawing.Color.Transparent;
            this.lbl7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl7.Location = new System.Drawing.Point(62, 198);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(10, 15);
            this.lbl7.TabIndex = 15;
            this.lbl7.Text = "o";
            this.lbl7.Click += new System.EventHandler(this.cmd7_Click);
            // 
            // lbl8
            // 
            this.lbl8.BackColor = System.Drawing.Color.Transparent;
            this.lbl8.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl8.Location = new System.Drawing.Point(24, 161);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(10, 15);
            this.lbl8.TabIndex = 16;
            this.lbl8.Text = "o";
            this.lbl8.Click += new System.EventHandler(this.cmd8_Click);
            // 
            // lbl9
            // 
            this.lbl9.BackColor = System.Drawing.Color.Transparent;
            this.lbl9.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl9.Location = new System.Drawing.Point(10, 108);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(10, 15);
            this.lbl9.TabIndex = 17;
            this.lbl9.Text = "o";
            this.lbl9.Click += new System.EventHandler(this.cmd21_Click);
            // 
            // lbl10
            // 
            this.lbl10.BackColor = System.Drawing.Color.Transparent;
            this.lbl10.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl10.Location = new System.Drawing.Point(23, 56);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(10, 15);
            this.lbl10.TabIndex = 18;
            this.lbl10.Text = "o";
            this.lbl10.Click += new System.EventHandler(this.cmd10_Click);
            // 
            // lbl11
            // 
            this.lbl11.BackColor = System.Drawing.Color.Transparent;
            this.lbl11.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl11.Location = new System.Drawing.Point(62, 17);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(10, 15);
            this.lbl11.TabIndex = 19;
            this.lbl11.Text = "o";
            this.lbl11.Click += new System.EventHandler(this.cmd11_Click);
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl1.Location = new System.Drawing.Point(165, 18);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(10, 15);
            this.lbl1.TabIndex = 20;
            this.lbl1.Text = "o";
            this.lbl1.Click += new System.EventHandler(this.cmd1_Click);
            // 
            // lbl2
            // 
            this.lbl2.BackColor = System.Drawing.Color.Transparent;
            this.lbl2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl2.Location = new System.Drawing.Point(204, 54);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(10, 15);
            this.lbl2.TabIndex = 21;
            this.lbl2.Text = "o";
            this.lbl2.Click += new System.EventHandler(this.cmd2_Click);
            // 
            // lbl3
            // 
            this.lbl3.BackColor = System.Drawing.Color.Transparent;
            this.lbl3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl3.Location = new System.Drawing.Point(214, 108);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(10, 15);
            this.lbl3.TabIndex = 22;
            this.lbl3.Text = "o";
            this.lbl3.Click += new System.EventHandler(this.cmd3_Click);
            // 
            // lbl4
            // 
            this.lbl4.BackColor = System.Drawing.Color.Transparent;
            this.lbl4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl4.Location = new System.Drawing.Point(204, 161);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(10, 15);
            this.lbl4.TabIndex = 23;
            this.lbl4.Text = "o";
            this.lbl4.Click += new System.EventHandler(this.cmd4_Click);
            // 
            // lbl5
            // 
            this.lbl5.BackColor = System.Drawing.Color.Transparent;
            this.lbl5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl5.Location = new System.Drawing.Point(165, 198);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(10, 15);
            this.lbl5.TabIndex = 24;
            this.lbl5.Text = "o";
            this.lbl5.Click += new System.EventHandler(this.cmd5_Click);
            // 
            // lbl12
            // 
            this.lbl12.BackColor = System.Drawing.Color.Transparent;
            this.lbl12.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl12.Location = new System.Drawing.Point(112, 5);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(10, 15);
            this.lbl12.TabIndex = 25;
            this.lbl12.Text = "o";
            this.lbl12.Click += new System.EventHandler(this.cmd12_Click);
            // 
            // clockControl1
            // 
            this.clockControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clockControl1.ClockBorder = System.Drawing.Color.DarkGray;
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
            this.clockControl1.Size = new System.Drawing.Size(228, 224);
            this.clockControl1.TabIndex = 0;
            this.clockControl1.Text = "clockControl1";
            this.clockControl1.AMPMChanged += new HenIT.Controls.AMPMChangedDelegate(this.clockControl1_AMPMChanged);
            this.clockControl1.TimeChanged += new HenIT.Controls.TimeChangedDelegate(this.clockControl1_TimeChanged);
            // 
            // ChooseTimeDialog
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(237, 268);
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
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl12;
    }
}