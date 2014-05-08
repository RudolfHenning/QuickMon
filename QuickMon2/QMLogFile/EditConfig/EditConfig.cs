using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace QuickMon
{
    public partial class EditConfig : Form
    {
        public EditConfig()
        {
            InitializeComponent();
        }

        public string CustomConfig { get; set; }

        public DialogResult ShowConfig()
        {
            if (CustomConfig.Length > 0)
            {
                try
                {
                    XmlDocument config = new XmlDocument();
                    config.LoadXml(CustomConfig);
                    XmlNode logfileNode = config.SelectSingleNode("config/logFile");
                    txtLogFilePath.Text = logfileNode.ReadXmlElementAttr("path");
                    numericUpDownCreateNewFileSizeKB.Value = long.Parse(logfileNode.ReadXmlElementAttr("createNewFileSizeKB", "0"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ShowDialog();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            saveFileDialogLogFile.FileName = txtLogFilePath.Text;
            if (saveFileDialogLogFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtLogFilePath.Text = saveFileDialogLogFile.FileName;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtLogFilePath.Text)))
            {
                XmlDocument config = new XmlDocument();
                config.LoadXml(Properties.Resources.LogFileEmptyConfig_xml);
                XmlNode root = config.SelectSingleNode("config/logFile");
                root.Attributes["path"].Value = txtLogFilePath.Text;
                if (numericUpDownCreateNewFileSizeKB.Value > 0 && numericUpDownCreateNewFileSizeKB.Value < 5)
                {
                    MessageBox.Show("Please be reasonable! A log file must be bigger than 50KB (other than 0)", "Too small", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    numericUpDownCreateNewFileSizeKB.Value = 50;
                }
                root.Attributes["createNewFileSizeKB"].Value = numericUpDownCreateNewFileSizeKB.Value.ToString("0");
                CustomConfig = config.OuterXml;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Invalid log file path specified!", "Path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
