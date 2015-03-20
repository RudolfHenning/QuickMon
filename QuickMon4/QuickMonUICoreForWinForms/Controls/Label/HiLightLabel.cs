using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HenIT.Windows.Controls
{
    public partial class HiLightLabel : UserControl
    {
        public HiLightLabel()
        {
            InitializeComponent();
            HighLightColor = Color.Aqua;
            HighLightBackColor = Color.WhiteSmoke;
            HighLightFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblContent.TextAlign = ContentAlignment.MiddleCenter;
            lblContent.Click += lblContent_Click;
        }

        void lblContent_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
        
        private Color fadedColor = SystemColors.WindowText;
        public Color FadedColor {
            get { return fadedColor; }
            set
            {
                lblContent.ForeColor = value;
                fadedColor = value; 
            }
        }        
        public Color HighLightColor { get; set; }
        private Color fadedBackColor = Color.Transparent;
        public Color FadedBackColor {
            get { return fadedBackColor; }
            set
            {
                lblContent.BackColor = value;
                fadedBackColor = value;
            }
        }
        public Color HighLightBackColor { get; set; }
        public bool BoldHighLighFont { get; set; }
        private Font fadedFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public Font FadedFont {
            get { return fadedFont; }
            set
            {
                lblContent.Font = new System.Drawing.Font(fadedFont, FontStyle.Regular);
                fadedFont = value;
            }
        }
        public Font HighLightFont { get; set; }
        public ContentAlignment TextAlign
        {
            get { return lblContent.TextAlign; }
            set { lblContent.TextAlign = value; }
        }
       [BrowsableAttribute(true)]
        public new string Text
        {
            get
            {
                return lblContent.Text;
            }
            set
            {
                lblContent.Text = value;
            }
        }

        private void lblContent_MouseEnter(object sender, EventArgs e)
        {
            fadeInTimer.Enabled = true;
        }

        private void fadeInTimer_Tick(object sender, EventArgs e)
        {
            fadeInTimer.Enabled = false;
            Application.DoEvents();
            lblContent.ForeColor = HighLightColor;
            lblContent.BackColor = HighLightBackColor;
            if (BoldHighLighFont)
                lblContent.Font = new System.Drawing.Font(HighLightFont, HighLightFont.Style);
            Application.DoEvents();
        }

        private void lblContent_MouseLeave(object sender, EventArgs e)
        {
            fadeOutTtimer.Enabled = true;
        }

        private void fadeOutTtimer_Tick(object sender, EventArgs e)
        {
            fadeOutTtimer.Enabled = false;
            Application.DoEvents();
            lblContent.ForeColor = FadedColor;
            lblContent.BackColor = FadedBackColor;
            lblContent.Font = new System.Drawing.Font(fadedFont, fadedFont.Style);
            Application.DoEvents();
        }
    }
}
