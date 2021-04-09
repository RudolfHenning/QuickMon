using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class SetTemplateVariables : Form
    {
        public SetTemplateVariables()
        {
            InitializeComponent();
        }
        public string InputConfig { get; set; } = "";
        public string FormattedConfig { get; set; } = "";
        public List<ConfigVariable> SelectedVariables { get; set; }

        private bool loadingVar = false;
        public bool ContainVariables()
        {
            if (InputConfig == "")
                return false;
            else
            {
                System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex("(\\[\\[).*?(\\]\\])", System.Text.RegularExpressions.RegexOptions.Multiline);
                SelectedVariables = new List<ConfigVariable>();
                foreach (var m in re.Matches(InputConfig))
                {
                    string variableUnformatted = m.ToString();
                    string initialValue = "";
                    if (variableUnformatted.Contains(":"))
                    {
                        initialValue = variableUnformatted.Substring(variableUnformatted.IndexOf(':') + 1).TrimEnd(']');
                    }
                    ConfigVariable cv = (from ConfigVariable c in SelectedVariables
                                         where c.FindValue == variableUnformatted
                                         select c).FirstOrDefault();
                    if (cv == null)
                    {
                        cv = new ConfigVariable() { FindValue = variableUnformatted, ReplaceValue = initialValue };
                        cv.FindValue = variableUnformatted;
                        SelectedVariables.Add(cv);
                    }
                }
                if (SelectedVariables.Count == 0)
                    return false;
                else
                    return true;
            }
        }

        public DialogResult FormatVariables()
        {
            if (InputConfig == "" && !ContainVariables())
            {
                return DialogResult.Cancel;
            }
            else
            {
                if (SelectedVariables.Count > 0)
                {
                    foreach (ConfigVariable cv in SelectedVariables)
                    {
                        ListViewItem lvi = new ListViewItem(cv.FindValue);
                        lvi.SubItems.Add(cv.ReplaceValue);
                        lvi.Tag = cv;
                        lvwVariables.Items.Add(lvi);
                    }
                }
                return ShowDialog();
            }
        }
        private void SetTemplateVariables_Load(object sender, EventArgs e)
        {
            lvwVariables.AutoResizeColumnEnabled = true;
        }

        private void lvwVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwVariables.SelectedItems.Count > 0)
            {
                loadingVar = true;
                ConfigVariable cv = (ConfigVariable)lvwVariables.SelectedItems[0].Tag;
                txtVariableName.Text = cv.FindValue;
                txtVariableValue.Text = cv.ReplaceValue;
                txtVariableValue.ReadOnly = false;
                txtVariableValue.Focus();
                loadingVar = false;
            }
            else
            {
                loadingVar = true;
                txtVariableName.Text = "";
                txtVariableValue.Text = "";
                txtVariableValue.ReadOnly = true;
                loadingVar = false;
            }
        }

        private void txtVariableValue_TextChanged(object sender, EventArgs e)
        {
            if (!loadingVar == true && lvwVariables.SelectedItems.Count > 0)
            {
                ConfigVariable cv = (ConfigVariable)lvwVariables.SelectedItems[0].Tag;
                if (txtVariableName.Text == cv.FindValue)
                {
                    cv.ReplaceValue = txtVariableValue.Text;
                    lvwVariables.SelectedItems[0].SubItems[1].Text = txtVariableValue.Text;
                }
            }
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            SelectedVariables = new List<ConfigVariable>();
            lvwVariables.Focus(); //make sure any last changes have been saved in list
            Application.DoEvents();
            foreach (ListViewItem lvi in lvwVariables.Items)
            {
                ConfigVariable cv = (ConfigVariable)lvi.Tag;
                if (cv.ReplaceValue.Length == 0)
                {
                    if (MessageBox.Show($"The variable '{cv.FindValue}' has no value! Do you want to accept this?", "Accept", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                SelectedVariables.Add(cv);
            }

            string modifiedConfig = InputConfig;
            foreach (ConfigVariable cv in SelectedVariables)
            {
                modifiedConfig = cv.ApplyOn(modifiedConfig);
            }
            FormattedConfig = modifiedConfig;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SetTemplateVariables_Shown(object sender, EventArgs e)
        {
            if (lvwVariables.Items.Count > 0)
            {
                lvwVariables.Items[0].Selected = true;
            }
        }
    }
}
