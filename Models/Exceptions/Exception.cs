using System;

namespace WMIEnum.Models
{
    public class WMIEnumException : Exception
    {
        public WMIEnumException(string message) : base(message) { }
        public WMIEnumException(string message, Exception inner) : base(message, inner) { }
    }
}
