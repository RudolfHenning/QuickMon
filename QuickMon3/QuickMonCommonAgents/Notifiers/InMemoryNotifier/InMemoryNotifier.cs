using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Notifiers
{
     [Description("'In memory' Notifier")]
    public class InMemoryNotifier : NotifierBase
    {
        public List<AlertRaised> Alerts = new List<AlertRaised>();
        public InMemoryNotifier()
        {
            AgentConfig = new InMemoryNotifierConfig();
        }

        public override void RecordMessage(AlertRaised alertRaised)
        {
            Alerts.Add(alertRaised);
            //Cleanup
            InMemoryNotifierConfig config = (InMemoryNotifierConfig)AgentConfig;
            if (config.MaxEntryCount > 0)
            {
                while (Alerts.Count > config.MaxEntryCount)
                {
                    Alerts.RemoveAt(0);
                }
            }
        }
        public override bool HasViewer { get { return true; } }
        public override INotivierViewer GetNotivierViewer()
        {
            return new InMemoryNotifierViewer();
        }
        public override IEditConfigWindow GetEditConfigWindow()
        {
            return new InMemoryNotifierConfigEditor();
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.InMemoryNotifierDefaultConfig;
        }
        public override void SetConfigurationFromXmlString(string configurationString)
        {
            AgentConfig.ReadConfiguration(configurationString);
        }

        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new InMemoryNotifierConfigEditor();
        }
    }
}
