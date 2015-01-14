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

        private void EditNotifierAgentEntry_Load(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void LoadControls()
        {
            if (SelectedEntry != null)
            {
                txtName.Text = SelectedEntry.Name;
                txtAgentType.Text = SelectedEntry.AgentClassDisplayName;
                if (SelectedEntry.AgentConfig != null && SelectedEntry.AgentConfig.ConfigSummary.Length > 0)
                    llblConfigure.Text = SelectedEntry.AgentConfig.ConfigSummary;
            }
        }
        private void CheckOkEnabled()
        {
            cmdOK.Enabled = txtName.Text.Length > 0 && SelectedEntry != null && SelectedEntry.AgentConfig != null;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }

        private void llblConfigure_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (DetailEditor != null && SelectedEntry != null)
            {
                try
                {
                    DetailEditor.SelectedEntry = SelectedEntry.AgentConfig;
                    if (DetailEditor.ShowEditEntry() == QuickMonDialogResult.Ok)
                    {
                        SelectedEntry.AgentConfig = DetailEditor.SelectedEntry;
                        llblConfigure.Text = SelectedEntry.AgentConfig.ConfigSummary;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (SelectedEntry != null)
            {
                SelectedEntry.Name = txtName.Text;
                SelectedEntry.Enabled = chkEnabled.Checked;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
                
        }

        private void llblRawEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SelectedEntry != null)
            {
                SelectedEntry.Name = txtName.Text;
                SelectedEntry.Enabled = chkEnabled.Checked;
                INotifierConfig conf = (INotifierConfig)SelectedEntry.AgentConfig;

                RAWXmlEditor editor = new RAWXmlEditor();
                string oldMarkUp = conf.ToXml();
                editor.SelectedMarkup = oldMarkUp;
                if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        conf.FromXml(editor.SelectedMarkup);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occured while processing the config!\r\n" + ex.Message, "Edit config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //conf.FromXml(oldMarkUp);
                    }
                    LoadControls();
                }
            }
        }
    }
}
