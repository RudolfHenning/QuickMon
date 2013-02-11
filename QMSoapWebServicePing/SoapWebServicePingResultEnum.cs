using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public enum SoapWebServicePingResultEnum
    {
        CheckAvailabilityOnly = 0, //only report failure if service is not available at all
        FailOnNoValue, //report failure if no (null or empty) value is returned
        FailOnSpecifiedValue
    }
}
