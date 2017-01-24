using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon5
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Ξ
            if (Properties.Settings.Default.ShowMenuOnStart)
                ShowMenu();
            else
                HideMenu();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            HideMenu();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowMenu();
        }

        private void ShowMenu()
        {
            splitContainer1.Panel1Collapsed = false;
            splitContainer2.Panel1Collapsed = true;
        }
        private void HideMenu()
        {
            splitContainer1.Panel1Collapsed = true;
            splitContainer2.Panel1Collapsed = false;
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool ctrl = ((Control.ModifierKeys & Keys.Control) == Keys.Control);
            if (ctrl)
            {
                if (e.KeyChar == 'M')
                {
                    
                }
            }


        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.M)
                {
                    splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
                    splitContainer2.Panel1Collapsed = !splitContainer2.Panel1Collapsed;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ShowMenuOnStart = splitContainer2.Panel1Collapsed;
            Properties.Settings.Default.Save();
        }
    }
}
