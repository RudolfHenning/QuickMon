using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Notifiers
{
    public partial class InMemoryNotifierEdit : Form, IAgentConfigEntryEditWindow
    {
        public InMemoryNotifierEdit()
        {
            InitializeComponent();
        }

        public IAgentConfig SelectedEntry { get; set; }

        public QuickMonDialogResult ShowEditEntry()
        {
            if (SelectedEntry != null)
            {
                maxCountNumericUpDown.SaveValueSet(((InMemoryNotifierConfig) SelectedEntry).MaxEntryCount);
            }            
            return (QuickMonDialogResult)ShowDialog();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (SelectedEntry == null)
                SelectedEntry = new InMemoryNotifierConfig();
            ((InMemoryNotifierConfig)SelectedEntry).MaxEntryCount = (int)maxCountNumericUpDown.Value;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
