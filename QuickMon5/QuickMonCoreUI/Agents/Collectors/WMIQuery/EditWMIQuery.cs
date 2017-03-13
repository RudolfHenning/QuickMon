using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using HenIT.WMI;

namespace QuickMon.UI
{
    public partial class EditWMIQuery : Form
    {
        private bool loading = false;
        public EditWMIQuery()
        {
            InitializeComponent();
        }

        public string MachineName { get; set; }
        public string RootNameSpace { get; set; }
        public string QueryText { get; set; }

        #region Form events
        private void EditWMIQuery_Load(object sender, EventArgs e)
        {
           
        }
        private void EditWMIQuery_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            txtMachine.Text = MachineName;
            cboNamespace.Text = RootNameSpace;
            txtQuery.Text = QueryText;
            LoadNameSpaces();
            LoadClasses();
            CheckOKEnabled();
            try
            {
                loading = true;
                WMIQueryParser wmiQueryParser = new WMIQueryParser();
                wmiQueryParser.QueryText = txtQuery.Text;
                if (wmiQueryParser.IsParsed)
                {
                    cboClass.Text = wmiQueryParser.TableName;
                    for (int i = 0; i < lstProperties.Items.Count; i++)
                    {
                        if (wmiQueryParser.Fields.Contains(lstProperties.Items[i].ToString()))
                        {
                            lstProperties.SelectedIndices.Add(i);
                        }
                    }
                }
            }
            catch { }
            loading = false;
            Cursor.Current = Cursors.Default;
        } 
        #endregion

        #region Control events
        private void cboNamespace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNamespace.SelectedIndex > -1 && !loading)
            {
                LoadClasses();
                CheckOKEnabled();
            }
        } 

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
            CheckOKEnabled();
        }
        
        private void lstProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                timerGenerateQuery.Enabled = false;
                timerGenerateQuery.Enabled = true;
            }
        }
        #endregion

        #region Button events
        private void cmdLoadNameSpaces_Click(object sender, EventArgs e)
        {
            LoadNameSpaces();
        }
        private void cmdLoadClasses_Click(object sender, EventArgs e)
        {
            LoadClasses();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            MachineName = txtMachine.Text;
            RootNameSpace = cboNamespace.Text;
            QueryText = txtQuery.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        private void cmdTest_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                WMIQueryParser wmiQueryParser = new WMIQueryParser();
                wmiQueryParser.QueryText = txtQuery.Text;
                if (wmiQueryParser.IsParsed)
                {

                    wmiQueryParser.Machines.Add(txtMachine.Text);
                    wmiQueryParser.Namespace = cboNamespace.Text;
                    DataSet queryData = wmiQueryParser.RunQuery();
                    StringBuilder sb = new StringBuilder();

                    if (queryData != null && queryData.Tables.Count > 0)
                    {
                        bool first = true;
                        int colCount = queryData.Tables[0].Columns.Count;
                        foreach (DataColumn col in queryData.Tables[0].Columns)
                        {
                            sb.Append((first ? "" : ",") + "\"" + col.ColumnName + "\"");
                            first = false;
                        }
                        sb.AppendLine();
                        foreach (DataRow r in queryData.Tables[0].Rows)
                        {
                            first = true;
                            for (int i = 0; i < colCount; i++)
                            {
                                if (r[i].GetType().IsArray)
                                {
                                    string outValue = "";
                                    if (r[i].GetType().ToString().ToLower().Contains("uint16"))
                                    {
                                        UInt16[] intArr = (UInt16[])r[i];
                                        for (int ii = 0; ii < intArr.Length; ii++)
                                        {
                                            outValue += intArr[ii].ToString() + ";";
                                        }
                                    }
                                    else
                                    {
                                        string[] theArr = (string[])r[i];
                                        for (int ii = 0; ii < theArr.Length; ii++)
                                        {
                                            outValue += theArr[ii].ToString() + ";";
                                        }
                                    }
            
                                    outValue = outValue.Trim(';');
                                    sb.Append((first ? "" : ",") + "\"" + outValue + "\"");
                                }
                                else
                                    sb.Append((first ? "" : ",") + "\"" + r[i].ToString() + "\"");
                                first = false;
                            }
                            sb.AppendLine();
                        }
                    }
                    string outputFileName = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "QMWMIQuery.csv");
                    System.IO.File.WriteAllText(outputFileName, sb.ToString());
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo = new System.Diagnostics.ProcessStartInfo();
                    p.StartInfo.FileName = outputFileName;
                    p.Start();
                }
                else
                {
                    MessageBox.Show("Query could not be parsed!\r\nCheck query syntax", "Parse", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        #endregion

        private void LoadNameSpaces()
        {
            loading = true;
            try
            {
                if (txtMachine.Text == null || txtMachine.Text.Length == 0 || txtMachine.Text == ".")
                {
                    txtMachine.Text = System.Environment.MachineName;
                }
                
                cboNamespace.Items.Clear();

                LoadNameSpaceClasses("root", ! chkAccessdniedErrors.Checked);
                if (RootNameSpace != null && RootNameSpace.Length > 0)
                {
                    object sel = (from object li in cboNamespace.Items
                                                 where ((string)li).ToLower() == RootNameSpace.ToLower()
                                                 select li).FirstOrDefault();
                    cboNamespace.SelectedItem = sel;
                }
                CheckOKEnabled();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loading = false;
        }
        private void LoadNameSpaceClasses(string parentPath, bool hideAccessErrors)
        {
            string strScope = string.Format(@"\\{0}\" + parentPath, txtMachine.Text);
            try
            {
                ManagementClass nsClass =
                    new ManagementClass(
                    new ManagementScope(strScope),
                    new ManagementPath("__namespace"),
                    null);

                foreach (ManagementObject ns in nsClass.GetInstances())
                {
                    string fullNS = parentPath + "\\" + ns["Name"].ToString();
                    cboNamespace.Items.Add(fullNS);
                    LoadNameSpaceClasses(fullNS, hideAccessErrors);
                }
            }
            catch (Exception ex)
            {
                if ((!ex.Message.Contains("Access denied") || !hideAccessErrors))
                    throw;
            }
            
        }

        private void LoadClasses()
        {
            try
            {
                if (cboNamespace.Text != null && cboNamespace.Text.Length > 0)
                {
                    string strScope = string.Format(@"\\{0}\" + cboNamespace.Text, txtMachine.Text);
                    ManagementObjectSearcher searcher =
                        new ManagementObjectSearcher(
                        new ManagementScope(
                        strScope),
                        new WqlObjectQuery(
                        "select * from meta_class"),
                        null);
                    cboClass.Items.Clear();
                    foreach (ManagementClass wmiClass in searcher.Get())
                    {
                        foreach (QualifierData qd in wmiClass.Qualifiers)
                        {
                            // If the class is dynamic, add it to the list.
                            if (qd.Name.Equals("dynamic") || qd.Name.Equals("static"))
                            {
                                cboClass.Items.Add(
                                    wmiClass["__CLASS"].ToString());
                            }
                        }
                    }
                    LoadProperties();
                    CheckOKEnabled();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadProperties()
        {
            try
            {
                lstProperties.Items.Clear();
                

                if (txtMachine.Text != null && txtMachine.Text.Length > 0 &&
                    cboNamespace.Text != null && cboNamespace.Text.Length > 0 &&
                    cboClass.Text != null && cboClass.Text.Length > 0)
                {
                    string strScope = string.Format(@"\\{0}\" + cboNamespace.Text, txtMachine.Text);
                    // Gets the property qualifiers.
                    ObjectGetOptions op = new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);

                    ManagementClass mc = new ManagementClass(strScope, cboClass.Text, op);
                    mc.Options.UseAmendedQualifiers = true;
                    try
                    {
                        if (mc.Properties != null)
                        {
                            lstProperties.Items.Add("*");
                            foreach (PropertyData dataObject in mc.Properties)
                            {
                                lstProperties.Items.Add(dataObject.Name);
                            }
                        }
                    }
                    catch { }
                    CheckOKEnabled();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerGenerateQuery_Tick(object sender, EventArgs e)
        {
            timerGenerateQuery.Enabled = false;
            GenerateQuery();
        }
        private void GenerateQuery()
        {
            if (txtMachine.Text != null && txtMachine.Text.Length > 0 &&
                    cboNamespace.Text != null && cboNamespace.Text.Length > 0 &&
                    cboClass.Text != null && cboClass.Text.Length > 0)
            {
                string oldTable = "";
                string oldWhere = "";
                //First check if Table stayed the same to try and preserve WHERE clause
                try
                {
                    WMIQueryParser wmiQueryParser = new WMIQueryParser();
                    wmiQueryParser.QueryText = txtQuery.Text;
                    if (wmiQueryParser.IsParsed)
                    {
                        oldTable = wmiQueryParser.TableName;
                        oldWhere = wmiQueryParser.WhereText;
                    }
                }
                catch { }

                StringBuilder queryText = new StringBuilder();
                queryText.Append("select ");
                StringBuilder propertyList = new StringBuilder();
                if (lstProperties.SelectedIndices == null || lstProperties.SelectedIndices.Count == 0)
                    propertyList.Append("*");
                else
                {
                    foreach (string p in lstProperties.SelectedItems)
                    {
                        propertyList.Append(p + ",");
                    }
                }
                queryText.Append(propertyList.ToString().TrimEnd(','));
                queryText.Append(" from " + cboClass.Text);
                txtQuery.Text = queryText.ToString();

                if (oldWhere.Length > 0 && oldTable.ToLower() == cboClass.Text.ToLower())
                {
                    txtQuery.Text += " where " + oldWhere;
                }
                CheckOKEnabled();

            }
        }
        private void CheckOKEnabled()
        {
            cmdOK.Enabled = (txtQuery.Text.Length > 0);
            cmdTest.Enabled = (txtMachine.Text != null && txtMachine.Text.Length > 0 &&
                    cboNamespace.Text != null && cboNamespace.Text.Length > 0 && 
                    txtQuery.Text.Length > 0); //
                    //cboClass.Text != null && cboClass.Text.Length > 0 &&
        }
    }
}
