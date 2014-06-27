using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public enum WebServiceValueExpectedReturnTypeEnum
    {
        CheckAvailabilityOnly, 
        SingleValue,
        Array,
        DataSet
    }
    public static class WebServiceValueExpectedReturnTypeConverter
    {
        public static WebServiceValueExpectedReturnTypeEnum FromString(string typeName)
        {
            if (typeName.ToLower() == "checkavailabilityonly")
                return WebServiceValueExpectedReturnTypeEnum.CheckAvailabilityOnly;
            else if (typeName.ToLower() == "singlevalue")
                return WebServiceValueExpectedReturnTypeEnum.SingleValue;
            else if (typeName.ToLower() == "array")
                return WebServiceValueExpectedReturnTypeEnum.Array;
            else if (typeName.ToLower() == "dataSet")
                return WebServiceValueExpectedReturnTypeEnum.DataSet;
            else
                return WebServiceValueExpectedReturnTypeEnum.CheckAvailabilityOnly;
        }
    }
    public enum WebServiceMacroFormatTypeEnum
    {
        None,
        NoValueOnly, 
        Count,
        FirstValue,
        LastValue,
        Length,
        Sum
    }
    public static class WebServiceMacroFormatTypeConverter
    {
        public static WebServiceMacroFormatTypeEnum FromString(string typeName)
        {
            if (typeName.ToLower() == "none")
                return WebServiceMacroFormatTypeEnum.None;
            else if (typeName.ToLower() == "novalueonly")
                return WebServiceMacroFormatTypeEnum.NoValueOnly;
            else if (typeName.ToLower() == "count")
                return WebServiceMacroFormatTypeEnum.Count;
            else if (typeName.ToLower() == "firstvalue")
                return WebServiceMacroFormatTypeEnum.FirstValue;
            else if (typeName.ToLower() == "lastvalue")
                return WebServiceMacroFormatTypeEnum.LastValue;
            else if (typeName.ToLower() == "length")
                return WebServiceMacroFormatTypeEnum.Length;
            else if (typeName.ToLower() == "sum")
                return WebServiceMacroFormatTypeEnum.Sum;            
            else
                return WebServiceMacroFormatTypeEnum.None;
        }
    }

    public enum WebServiceCheckTypeTypeEnum
    {
        CheckAvailabilityOnly, 
        NoValueOnly, 
        SpecifiedValue,
        UseMacro, 
        StringArray, 
        DataSet
    }
}
