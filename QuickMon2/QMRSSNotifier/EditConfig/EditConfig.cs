using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class EditConfig : Form
    {
        public EditConfig()
        {
            InitializeComponent();
            RSSConfig = new RSSNotifierConfig()
            {
                RSSFilePath = "rss.xml",
                Title = "QuickMon RSS alerts",
                Language = "en-us",
                Generator = "QuickMon RSS notifier",
                KeepEntriesDays = 10,
                LineTitle = "%CollectorName% - %AlertLevel%",
                LineCategory = "%CurrentState%",
                LineDescription = "<b>Date Time:</b> %DateTime%\r\n" +
                                   "<b>Current state:</b> %CurrentState%\r\n" +
                                   "<b>Collector:</b> %CollectorType%\r\n" +
                                   "<b>Details</b>\r\n" +
                                   "%Details%"
            };
        }

        public RSSNotifierConfig RSSConfig { get; set; }

        private void EditConfig_Load(object sender, EventArgs e)
        {
            txtRSSFilePath.Text = RSSConfig.RSSFilePath;
            txtTitle.Text = RSSConfig.Title;
            txtLink.Text = RSSConfig.Link;
            txtLanguage.Text = RSSConfig.Language;
            txtGenerator.Text = RSSConfig.Generator;
            txtDescription.Text = RSSConfig.Description;
            keepDataDaysNumericUpDown.Value = RSSConfig.KeepEntriesDays;
            txtLineTitle.Text = RSSConfig.LineTitle;
            txtLineCategory.Text = RSSConfig.LineCategory;
            txtLineDescription.Text = RSSConfig.LineDescription;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!txtLineDescription.Text.Contains("%Details%"))
                if (MessageBox.Show("Are you sure you do not want the details displayed in the description?", "Description", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;
            RSSConfig.RSSFilePath = txtRSSFilePath.Text;
            RSSConfig.Title = txtTitle.Text;
            RSSConfig.Link = txtLink.Text;
            RSSConfig.Language = txtLanguage.Text;
            RSSConfig.Generator = txtGenerator.Text;
            RSSConfig.Description = txtDescription.Text;
            RSSConfig.KeepEntriesDays = (int)keepDataDaysNumericUpDown.Value;
            RSSConfig.LineTitle = txtLineTitle.Text;
            RSSConfig.LineCategory = txtLineCategory.Text;
            //RSSConfig.LineComments = txtLineComments.Text;
            RSSConfig.LineDescription = txtLineDescription.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            saveFileDialogLogFile.FileName = txtRSSFilePath.Text;
            if (saveFileDialogLogFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtRSSFilePath.Text = saveFileDialogLogFile.FileName;
            }
        }

        private void CheckOKEnabled()
        {
            cmdOK.Enabled = (txtRSSFilePath.Text.Length > 0) && (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtRSSFilePath.Text)));
        }

        private void txtRSSFilePath_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private void lblLineDescription_DoubleClick(object sender, EventArgs e)
        {
            txtLineDescription.Text = "<b>Date Time:</b> %DateTime%\r\n" +
                                   "<b>Current state:</b> %CurrentState%\r\n" +
                                   "<b>Collector:</b> %CollectorType%\r\n" +
                                   "<b>Details</b>\r\n" +
                                   "%Details%";
        }

        private void lblCategory_DoubleClick(object sender, EventArgs e)
        {
            txtLineCategory.Text = "%CurrentState%, %CollectorType%";
        }

        private void lblLineTitle_DoubleClick(object sender, EventArgs e)
        {
            txtLineTitle.Text = "%CollectorName% - %AlertLevel%";
        }

    }
}
