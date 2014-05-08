using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public enum SoapWebServicePingCheckType
    {
        Success,
        Failure
    }
    public enum SoapWebServicePingResultEnum
    {
        CheckAvailabilityOnly, //only report true if service is not available at all
        NoValueOnly, //report true if no (null or empty) value is returned
        SpecifiedValue, //report true if specific value (interpreted as a string or the word DataSet)
        InValueRange, //report true if returned value is between 1st and 2nd custom values
        DataSet, // enables you test the value of the first column from the first row
        StringArray // enables you test the value of the first row
    }
}
