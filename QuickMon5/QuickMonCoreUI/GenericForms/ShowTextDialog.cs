using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public partial class ShowTextDialog : Form
    {
        public ShowTextDialog()
        {
            InitializeComponent();
        }

        public void ShowText(string title, string content)
        {
            this.Text = title;
            txtContent.Text = content;
            txtContent.SelectionLength = 0;
            this.ShowDialog();
        }

        private void ShowTextDialog_Shown(object sender, EventArgs e)
        {
            txtContent.SelectionLength = 0;
        }

        private void ShowTextDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
