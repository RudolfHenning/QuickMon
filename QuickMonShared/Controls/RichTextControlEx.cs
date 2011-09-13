using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HenIT.Controls
{
    public partial class RichTextControlEx : UserControl
    {
        public RichTextControlEx()
        {
            InitializeComponent();
        }

        private Font defaultFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
        public Font DefaultRTFFont 
        {
            get { return defaultFont; }
            set { defaultFont = value; }
        }

        public RichTextBox BaseControl 
        {
            get
            {
                return this.richTextBox1;
            }
            set
            {
                this.richTextBox1 = value;
            }
        }

        public void AppendText(string text)
        {
            AppendText(text, defaultFont.Style);
        }

        public void AppendText(string text, FontStyle fs)
        {
            richTextBox1.AppendText(text);
            if (text.Replace("\r", "").Replace("\n", "").Length > 0)
            {
                richTextBox1.SelectionStart = richTextBox1.Text.Length - text.Replace("\r", "").Replace("\n", "").Length;
                richTextBox1.SelectionLength = text.Replace("\r", "").Replace("\n", "").Length;
                richTextBox1.SelectionFont = new Font(defaultFont.FontFamily, 8, fs);
            }
        }

        public override Color BackColor
        {
            get
            {
                return richTextBox1.BackColor;
            }
            set
            {
                richTextBox1.BackColor = value;
            }
        }

        public override ContextMenu ContextMenu
        {
            get
            {
                return richTextBox1.ContextMenu;
            }
            set
            {
                richTextBox1.ContextMenu = value;
                
            }
        }

        public RichTextBoxScrollBars ScrollBars
        {
            get
            {
                return richTextBox1.ScrollBars;
            }
            set
            {
                richTextBox1.ScrollBars = value;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return richTextBox1.ReadOnly;
            }
            set
            {
                richTextBox1.ReadOnly = value;
            }
        }

        public new BorderStyle BorderStyle
        {
            get
            {
                return richTextBox1.BorderStyle;
            }
            set
            {
                richTextBox1.BorderStyle = value;   
            }
        }

        public override string Text
        {
            get { return richTextBox1.Text; }
            set { richTextBox1.Text = value; }
        }

        public int SelectionStart
        {
            get { return richTextBox1.SelectionStart; }
            set { richTextBox1.SelectionStart = value; }
        }

        public int SelectionLength
        {
            get { return richTextBox1.SelectionLength; }
            set { richTextBox1.SelectionLength = value; }
        }

    }
}
