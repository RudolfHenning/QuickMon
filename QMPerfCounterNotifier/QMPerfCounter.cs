using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.Threading;

namespace QuickMon
{
    public class PerformanceCounterNotifier : NotifierBase
    {
        private string category;
        
        private Mutex pcCategoryCreationMutex = new Mutex();
        private List<PerformanceCounter> perfCounterCache = new List<PerformanceCounter>();

        public override void RecordMessage(AlertLevel alertLevel, string collectorType, string collectorName, MonitorStates oldState, MonitorStates newState, CollectorMessage collectorMessage)
        {
            string lastStep = "";
            PerformanceCounter thePCValueInstance = null;
            try
            {
                pcCategoryCreationMutex.WaitOne();
                if (!PerformanceCounterCategory.Exists(category)) //Does performance counter category exists?
                {
                    CounterCreationDataCollection ccdc = new CounterCreationDataCollection(
                        new CounterCreationData[] 
                        {
                            new CounterCreationData("Value", "Raw Value", PerformanceCounterType.NumberOfItems32)
                        }
                        );
                    PerformanceCounterCategory.Create(category, category, PerformanceCounterCategoryType.MultiInstance, ccdc);
                    System.Threading.Thread.Sleep(500); //give moment for internal stuff to do creation of PC
                }
                pcCategoryCreationMutex.ReleaseMutex();
            }
            catch (Exception ex)
            {
                pcCategoryCreationMutex.ReleaseMutex();
                throw new Exception(string.Format("An error occured trying to create the performance counter category  '{0}'", category), ex);
            }
            try
            {
                if (collectorName != null && collectorName.Length > 0)
                {
                    //Zero any disabled collector values
                    if (collectorMessage != null && newState == MonitorStates.Disabled)
                        collectorMessage.LastValue = 0;
                    lastStep = "Retrieving performance counter from cache";
                    thePCValueInstance = (from pc in perfCounterCache
                                          where pc.InstanceName == collectorName
                                          select pc).FirstOrDefault();
                    if (thePCValueInstance == null)
                    {
                        lastStep = "Creating 'Value' performance counter for " + collectorName;
                        thePCValueInstance = new PerformanceCounter(category, "Value", collectorName, false);
                        perfCounterCache.Add(thePCValueInstance);
                    }
                    
                    lastStep = "Reading last value";
                    if (collectorMessage != null && collectorMessage.LastValue != null && collectorMessage.LastValue.IsNumber())
                    {
                        long theValue = 0;
                        double tmpValue = double.Parse(collectorMessage.LastValue.ToString());
                        theValue = (long)tmpValue;
                        lastStep = "Setting performance counter value for " + collectorName;
                        try
                        {
                            thePCValueInstance.BeginInit();
                            thePCValueInstance.RawValue = theValue;
                        }
                        finally
                        {
                            thePCValueInstance.EndInit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error recording message in log file notifier '{0}'\r\nLast step: " + lastStep, ex);
            }
        }

        public override void OpenViewer(string notifierName)
        {
            throw new NotImplementedException();
        }

        public override bool HasViewer
        {
            get { return false; }
        }

        public override string ConfigureAgent(string config)
        {
            XmlDocument configXml = new XmlDocument();
            if (config.Length > 0)
            {
                try
                {
                    configXml.LoadXml(config);
                }
                catch
                {
                    configXml.LoadXml(Properties.Resources.PerfCounterNotifierEmptyConfig);
                }
            }
            else
            {
                configXml.LoadXml(Properties.Resources.PerfCounterNotifierEmptyConfig);
            }
            ReadConfiguration(configXml);

            EditConfig editConfig = new EditConfig();
            editConfig.SelectedCategory = category;
            if (editConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                category = editConfig.SelectedCategory;
                config = GetCustomConfig();
            }                
            return config;
        }
        private string GetCustomConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.PerfCounterNotifierEmptyConfig);
            XmlNode root = config.SelectSingleNode("config/perfCounter");
            root.Attributes["category"].Value = category;
            return config.OuterXml;
        }

        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.PerfCounterNotifierEmptyConfig;
        }

        public override void ReadConfiguration(XmlDocument configDoc)
        {
            XmlElement root = configDoc.DocumentElement;
            XmlNode logFileNode = root.SelectSingleNode("perfCounter");
            category = logFileNode.ReadXmlElementAttr("category", "QuickMon Performance Counter Notifier");
        }
    }
}
