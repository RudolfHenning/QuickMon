using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Utils;

namespace QuickMon.Collectors
{
    public partial class EditSqlQuery : Form
    {
        public EditSqlQuery()
        {
            InitializeComponent();
        }

        public QueryInstance SelectedQueryInstance { get; set; }

        private void EditDetailQuery_Load(object sender, EventArgs e)
        {
            if (SelectedQueryInstance != null)
                txtDetailQuery.Text = SelectedQueryInstance.DetailQuery;
        }

        private void linkLabelQueryTips_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string outputPath = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.DoNotVerify);
                outputPath = System.IO.Path.Combine(outputPath, "Hen IT\\QuickMon");
                if (!System.IO.Directory.Exists(outputPath))
                    System.IO.Directory.CreateDirectory(outputPath);
                outputPath = System.IO.Path.Combine(outputPath, "SQLQueryTips.htm");
                if (System.IO.File.Exists(outputPath))
                    System.IO.File.Delete(outputPath);
                System.IO.File.WriteAllText(outputPath, Properties.Resources.SQLQueryTips, Encoding.UTF8);
                System.Diagnostics.Process.Start(outputPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Query Tips", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            if (DoValidate())
            {
                string oldQuery = SelectedQueryInstance.DetailQuery;
                bool oldQueryType = SelectedQueryInstance.UseSPForDetail;
                try
                {
                    SelectedQueryInstance.DetailQuery = txtDetailQuery.Text;
                    SelectedQueryInstance.UseSPForDetail = chkUseSPForDetail.Checked;

                    //testing detail query
                    List<DataColumn> columns = new List<DataColumn>(); // = testQueryInstance.GetDetailQueryColumns();                    
                    DataSet ds = SelectedQueryInstance.RunDetailQuery();
                    columns.AddRange((from DataColumn c in ds.Tables[0].Columns
                                      select c).ToArray());

                    MessageBox.Show(string.Format("Success!\r\nDetail row count: {0}\r\nDetail columns returned: {1}", ds.Tables[0].Rows.Count, columns.ToCSVString()), "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Parse", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                SelectedQueryInstance.DetailQuery = oldQuery;
                SelectedQueryInstance.UseSPForDetail = oldQueryType;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (DoValidate())
            {
                if (SelectedQueryInstance != null)
                {
                    SelectedQueryInstance.DetailQuery = txtDetailQuery.Text;
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }

        #region SQL Validation
        private bool DoValidate()
        {
            try
            {
                if (txtDetailQuery.Text.Trim().Length == 0)
                    throw new InPutValidationException("The detail query must be specified!", txtDetailQuery);
                if (!SQLTools.TSQLValid(txtDetailQuery.Text))
                    throw new InPutValidationException("SQL statements may not contain certain keywords (e.g. update, delete, create etc!", txtDetailQuery);



                return true;
            }
            catch (InPutValidationException ex)
            {
                MessageBox.Show(ex.Message, "Input Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        #endregion
    }
}
