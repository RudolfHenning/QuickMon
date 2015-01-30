using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public enum TemplateType
    {
        MonitorPack,
        CollectorHost,
        CollectorAgent,
        NotifierHost,
        NotifierAgent
    }
    public static class TemplateTypeConverter
    {
        public static TemplateType FromText(string templateTypeName)
        {
            switch (templateTypeName.ToLower())
            {
                case "monitorpack" :
                    return TemplateType.MonitorPack;
                case "collectorhost":
                    return TemplateType.CollectorHost;
                case "collectoragent":
                    return TemplateType.CollectorAgent;
                case "notifierhost":
                    return TemplateType.NotifierHost;
                case "notifieragent":
                    return TemplateType.NotifierAgent;
                default:
                    return TemplateType.MonitorPack;
            }
        }

    }
}
