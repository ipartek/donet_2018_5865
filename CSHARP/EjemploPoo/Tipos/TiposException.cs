namespace Tipos
{
    [System.Serializable]
    public class TiposException : System.Exception
    {
        public TiposException() { }
        public TiposException(string message) : base(message) { }
        public TiposException(string message, System.Exception inner) : base(message, inner) { }
        protected TiposException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
