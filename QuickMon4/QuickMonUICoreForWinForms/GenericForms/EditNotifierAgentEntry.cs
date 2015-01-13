using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class EditNotifierAgentEntry : Form
    {
        public EditNotifierAgentEntry()
        {
            InitializeComponent();
        }

        public IAgentConfigEntryEditWindow DetailEditor { get; set; }
        public INotifier SelectedEntry { get; set; }


    }
}
