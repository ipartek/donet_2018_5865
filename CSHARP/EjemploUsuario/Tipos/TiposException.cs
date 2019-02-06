using System;
using System.Runtime.Serialization;

namespace Tipos
{
    [Serializable]
    internal class TiposException : Exception
    {
        public TiposException()
        {
        }

        public TiposException(string message) : base(message)
        {
        }

        public TiposException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TiposException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}