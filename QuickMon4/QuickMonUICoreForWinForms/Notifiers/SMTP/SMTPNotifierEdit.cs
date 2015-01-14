using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Notifiers
{
    public partial class SMTPNotifierEdit : Form, IAgentConfigEntryEditWindow
    {
        public SMTPNotifierEdit()
        {
            InitializeComponent();
        }

        public IAgentConfig SelectedEntry { get; set; }

        public QuickMonDialogResult ShowEditEntry()
        {
            throw new NotImplementedException();
        }
    }
}
