using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Description;

namespace QuickMon
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri(Properties.Settings.Default.ServiceURL);
            // Create the ServiceHost.
            using (ServiceHost host = new ServiceHost(typeof(RemoteCollectorHostService), baseAddress))
            {
                // Enable metadata publishing.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);


                ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(IRemoteCollectorHostService), new BasicHttpBinding(), baseAddress);

                List<string> blockedCollectorAgentTypes = new List<string>();
                if (Properties.Settings.Default.BlockedCollectorAgentTypes != null)
                {
                    foreach (string s in Properties.Settings.Default.BlockedCollectorAgentTypes)
                        blockedCollectorAgentTypes.Add(s);
                }
                endpoint.Behaviors.Add(
                    new RemoteCollectorHostServiceInstanceProvider(
                        Properties.Settings.Default.ApplicationMasterKey,
                        Properties.Settings.Default.ApplicationUserNameCacheFilePath,
                        blockedCollectorAgentTypes)
                );
                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                Console.WriteLine("Shutting down...");
                // Close the ServiceHost.
                host.Close();
            }
        }
    }
}
