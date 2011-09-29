namespace QuickMon
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.QuickMonServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.QuickMonServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // QuickMonServiceProcessInstaller
            // 
            this.QuickMonServiceProcessInstaller.Password = null;
            this.QuickMonServiceProcessInstaller.Username = null;
            // 
            // QuickMonServiceInstaller
            // 
            this.QuickMonServiceInstaller.DelayedAutoStart = true;
            this.QuickMonServiceInstaller.Description = "QuickMon monitoring and alerting Service";
            this.QuickMonServiceInstaller.DisplayName = "QuickMon Service";
            this.QuickMonServiceInstaller.ServiceName = "QuickMon Service";
            this.QuickMonServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.QuickMonServiceProcessInstaller,
            this.QuickMonServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller QuickMonServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller QuickMonServiceInstaller;
    }
}