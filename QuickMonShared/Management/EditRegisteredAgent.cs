using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Collections;
 
namespace QuickMon
{
    public partial class EditRegisteredMonitor : Form
    {
        public EditRegisteredMonitor()
        {
            InitializeComponent();
            AgentRegistration = new AgentRegistration();
        }

        public AgentRegistration AgentRegistration { get; set; }

        public new DialogResult ShowDialog()
        {
            txtName.Text = AgentRegistration.Name;
            txtPath.Text = AgentRegistration.AssemblyPath;
            cboClass.Text = AgentRegistration.ClassName;
            optCollector.Checked = AgentRegistration.IsCollector;
            optNotifier.Checked = AgentRegistration.IsNotifier;
            return base.ShowDialog();
        }

        #region Button events
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            openFileDialogMonitor.FileName = txtPath.Text;
            openFileDialogMonitor.InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (openFileDialogMonitor.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = openFileDialogMonitor.FileName;
                try
                {
                    cboClass.Items.Clear();
                    foreach (string s in LoadQuickMonClasses(txtPath.Text))
                        cboClass.Items.Add(s);

                    if (cboClass.Items.Count > 0)
                    {
                        cboClass.Text = cboClass.Items[0].ToString();
                        txtName.Text = cboClass.Items[0].ToString().Replace("QuickMon.", "");
                        optCollector.Checked = IsCollectorClass(txtPath.Text, cboClass.Text);
                        optNotifier.Checked = !optCollector.Checked;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtPath.Text))
            {
                MessageBox.Show("You must specify a valid path to an assembly!", "Path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                System.Reflection.Assembly agentAssembly = System.Reflection.Assembly.LoadFile(txtPath.Text);
                IAgent agent = (IAgent)agentAssembly.CreateInstance(cboClass.Text);
                if (agent == null)
                {
                    MessageBox.Show("Invalid class specified!", "Class", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                agent = null;
                agentAssembly = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading assembly or accessing class!\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AgentRegistration.Name = txtName.Text;
            AgentRegistration.AssemblyPath = txtPath.Text;
            AgentRegistration.ClassName = cboClass.Text;
            AgentRegistration.IsCollector = optCollector.Checked;
            AgentRegistration.IsNotifier = optNotifier.Checked;
            DialogResult = DialogResult.OK;
            Close();
        } 
        #endregion

        #region Private methods
        private bool IsCollectorClass(string assemblyFilePath, string className)
        {
            Assembly quickAsshehe = Assembly.LoadFile(assemblyFilePath);
            Type[] types = quickAsshehe.GetTypes();
            foreach (Type type in types)
            {
                if (type.FullName == className)
                {
                    foreach (Type interfaceType in type.GetInterfaces())
                    {
                        if (interfaceType.FullName == "QuickMon.ICollector")
                            return true;
                    }
                    return false;
                }
            }
            return false;
        }
        private string LoadAssemblyDescription(string assemblyFilePath)
        {
            Assembly quickAsshehe = Assembly.LoadFile(assemblyFilePath);
            AssemblyDescriptionAttribute desc = (AssemblyDescriptionAttribute)
           AssemblyDescriptionAttribute.GetCustomAttribute(
               quickAsshehe, typeof(AssemblyDescriptionAttribute));
            return desc.Description;
        }
        private IEnumerable LoadQuickMonClasses(string assemblyFilePath)
        {
            Assembly quickAsshehe = Assembly.LoadFile(assemblyFilePath);
            Type[] types = quickAsshehe.GetTypes();
            foreach (Type type in types)
            {
                foreach (Type interfaceType in type.GetInterfaces())
                {
                    if (interfaceType.FullName == "QuickMon.IAgent")
                        yield return type.FullName;
                }
            }
        }         
        #endregion
        
    }
}
