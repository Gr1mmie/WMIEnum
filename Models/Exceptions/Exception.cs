using System;

namespace SharpCIMEnum.Models
{
    public class CIMEnumException : Exception
    {
        public CIMEnumException(string message) : base(message) { }
        public CIMEnumException(string message, Exception inner) : base(message, inner) { }
    }
}
