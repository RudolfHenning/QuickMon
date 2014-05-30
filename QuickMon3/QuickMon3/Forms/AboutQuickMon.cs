using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class AboutQuickMon : FadeSnapForm
    {
        public AboutQuickMon()
        {
            InitializeComponent();
            FadeInTime = 500;
        }

        private void AboutQuickMon_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutQuickMon_Load(object sender, EventArgs e)
        {
            SnappingEnabled = false;
            lblVersionInfo.Text = string.Format("Version {0}", AssemblyVersion);
            lblCompany.Text = string.Format("Created by {0}", AssemblyCompany);
            lblCreateDate.Text = string.Format("Created on {0}", AssemblyDate);
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        public string AssemblyDate
        {
            get
            {
                return new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime.ToString("yyyy-MM-dd");
            }
        }
        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutQuickMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://quickmon.codeplex.com/";
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo(url);
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblThree_Click(object sender, EventArgs e)
        {
//#if DEBUG
//            string progDataPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Hen IT\\QuickMon 3");
//            try
//            {
//                System.IO.Directory.CreateDirectory(progDataPath);
//            }
//            catch { }

//            foreach (RegisteredAgent ra in RegisteredAgentCache.Agents)
//            {
//                IAgent c;
//                if (ra.IsCollector)
//                    c = CollectorEntry.CreateCollectorEntry(ra);
//                else
//                    c = NotifierEntry.CreateNotifierEntry(ra);

//                string presetfile = System.IO.Path.Combine(progDataPath, ra.Name + ".qps");
//                List<AgentPresetConfig> apcs = c.GetPresets();
//                foreach (AgentPresetConfig apc in apcs)
//                {
//                    apc.AgentClassName = ra.Name;
//                }
//                AgentPresetConfig.SavePresetsToFile(presetfile, apcs);
//            }
//#endif
        }
    }
}
