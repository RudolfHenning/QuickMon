using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Utils
{
    public class InPutValidationException : Exception
    {
        public InPutValidationException(string message, object validatedObject)
            : base(message)
        {
            ValidatedObject = validatedObject;
        }
        public object ValidatedObject { get; set; }
    }
}
