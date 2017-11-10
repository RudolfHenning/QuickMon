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

        private string quickMonOnlineUrl = "https://quickmon.codeplex.com/";

        private void AboutQuickMon_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutQuickMon_Load(object sender, EventArgs e)
        {
            SnappingEnabled = false;
            lblVersionInfo.Text = string.Format("Version {0}", AssemblyVersion);
            lblCoreVersion.Text = string.Format("Core {0}", CoreAssemblyVersion);
            lblCompany.Text = string.Format("Created by {0}", AssemblyCompany);
            lblCreateDate.Text = string.Format("Created on {0}", AssemblyDate);
            //latestVersionCheckBackgroundWorker.RunWorkerAsync();
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        public string CoreAssemblyVersion
        {
            get
            {
                return Assembly.GetAssembly(typeof(MonitorPack)).GetName().Version.ToString();
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
            try
            {
                string url = "https://github.com/RudolfHenning/QuickMon/releases";
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

        private void latestVersionCheckBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string rssAddress = "https://quickmon.codeplex.com/project/feeds/rss?ProjectRSSFeed=codeplex%3a%2f%2frelease%2fquickmon";
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    Stream data = client.OpenRead(rssAddress);
                    StreamReader reader = new StreamReader(data);
                    string rssDoc = reader.ReadToEnd();
                    data.Close();
                    reader.Close();

                    System.Xml.XmlDocument rssXmlDoc = new System.Xml.XmlDocument();
                    rssXmlDoc.LoadXml(rssDoc);
                    System.Xml.XmlNode item1 = rssXmlDoc.SelectSingleNode("rss/channel/item");
                    System.Xml.XmlNode title1 = item1.SelectSingleNode("title");
                    System.Xml.XmlNode link1 = item1.SelectSingleNode("link");
                    string versionInfo = title1.InnerText.Replace("Updated Release:", "").Trim();
                    versionInfo = versionInfo.Replace("Created Release:", "").Trim();
                    if (versionInfo.IndexOf('(') > -1)
                        versionInfo = versionInfo.Substring(0, versionInfo.IndexOf('('));

                    this.Invoke((MethodInvoker)delegate
                    {
                        linkLabel1.Text = "Latest release online: " + versionInfo;
                        quickMonOnlineUrl = link1.InnerText;
                    });
                }
            }
            catch
            {
                linkLabel1.Text = "Get latest version here (CodePlex)";
                quickMonOnlineUrl = "https://github.com/RudolfHenning/QuickMon";
            }
        }

        private void llblChangeLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.ShowTextDialog dlg = new Forms.ShowTextDialog();
            dlg.ShowText("Change log", ChangeLog.GetChangeLog());
        }
    }
}
