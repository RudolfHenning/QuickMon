using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HenIT.Controls
{
    public partial class ChooseTimeDialog : Form
    {
        public ChooseTimeDialog()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(int x, int y)
        {
            //Rectangle currentScreen = Screen.FromControl(this).WorkingArea;

            //if (x + this.Width > currentScreen.Left + currentScreen.Width)
            //{
            //    x = currentScreen.Left + currentScreen.Width - this.Width;
            //}
            //if (y + this.Height > currentScreen.Height)
            //{
            //    y = Screen.FromControl(this).WorkingArea.Top + Screen.FromControl(this).WorkingArea.Height - this.Height;
            //}

            this.Left = x;
            this.Top = y;
            return this.ShowDialog();
        }

        public int SelectedHour
        {
            get { return clockControl1.SelectedHour; }
            set { clockControl1.SelectedHour = value; }
        }
        public int SelectedMinute
        {
            get { return clockControl1.SelectedMinute; }
            set { clockControl1.SelectedMinute = value; }
        }


        private void chkPM_CheckedChanged(object sender, EventArgs e)
        {
            clockControl1.IsAM = !chkPM.Checked;
        }

        private void clockControl1_AMPMChanged(bool isAM)
        {
            chkPM.Checked = !clockControl1.IsAM;
        }        

        private void ChooseTimeDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp)
            {
                DateTime tm = new DateTime(2000, 1, 1, clockControl1.SelectedHour, clockControl1.SelectedMinute, 0).AddMinutes(1);
                clockControl1.SelectedMinute = tm.Minute;
                clockControl1.SelectedHour = tm.Hour;
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                DateTime tm = new DateTime(2000, 1, 1, clockControl1.SelectedHour, clockControl1.SelectedMinute, 0).AddMinutes(-1);
                clockControl1.SelectedMinute = tm.Minute;
                clockControl1.SelectedHour = tm.Hour;
            }
        }

        private void clockControl1_TimeChanged(DateTime time)
        {
            cmdOK.Enabled = true;
        }

        private void ChooseTimeDialog_Load(object sender, EventArgs e)
        {

        }

        private void cmdNow_Click(object sender, EventArgs e)
        {
            clockControl1.SelectedHour = DateTime.Now.Hour;
            clockControl1.SelectedMinute = DateTime.Now.Minute;
        }

        private void cmd12_Click(object sender, EventArgs e)
        {
            clockControl1.SelectedHour = clockControl1.IsAM ? 0 : 12;
            clockControl1.SelectedMinute = 0;
        }

        private void cmd6_Click(object sender, EventArgs e)
        {
            clockControl1.SelectedHour = clockControl1.IsAM ? 6 : 18;
            clockControl1.SelectedMinute = 0;
        }

        private void cmd3_Click(object sender, EventArgs e)
        {
            clockControl1.SelectedHour = clockControl1.IsAM ? 3 : 15;
            clockControl1.SelectedMinute = 0;
        }

        private void cmd21_Click(object sender, EventArgs e)
        {
            clockControl1.SelectedHour = clockControl1.IsAM ? 9 : 21;
            clockControl1.SelectedMinute = 0;
        }

        private void cmd1_Click(object sender, EventArgs e)
        {
            clockControl1.SelectedHour = clockControl1.IsAM ? 1 : 13;
            clockControl1.SelectedMinute = 0;
        }

        private void cmd2_Click(object sender, EventArgs e)
        {
            clockControl1.SelectedHour = clockControl1.IsAM ? 2 : 14;
            clockControl1.SelectedMinute = 0;
        }

        private void cmd4_Click(object sender, EventArgs e)
        {
            clockControl1.SelectedHour = clockControl1.IsAM ? 4 : 16;
            clockControl1.SelectedMinute = 0;
        }

        private void cmd5_Click(object sender, EventArgs e)
        {
            clockControl1.SelectedHour = clockControl1.IsAM ? 5 : 17;
            clockControl1.SelectedMinute = 0;
        }

        private void cmd7_Click(object sender, EventArgs e)
        {
            clockControl1.SelectedHour = clockControl1.IsAM ? 7 : 19;
            clockControl1.SelectedMinute = 0;
        }

        private void cmd8_Click(object sender, EventArgs e)
        {
            clockControl1.SelectedHour = clockControl1.IsAM ? 8 : 20;
            clockControl1.SelectedMinute = 0;
        }

        private void cmd10_Click(object sender, EventArgs e)
        {
            clockControl1.SelectedHour = clockControl1.IsAM ? 10 : 22;
            clockControl1.SelectedMinute = 0;
        }

        private void cmd11_Click(object sender, EventArgs e)
        {
            clockControl1.SelectedHour = clockControl1.IsAM ? 11 : 23;
            clockControl1.SelectedMinute = 0;
        }
    }
}
