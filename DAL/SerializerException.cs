using System;
using System.Runtime.Serialization;

namespace DAL
{
    [Serializable]
    internal class SerializerException : Exception
    {
        private string v1;
        private string v2;

        public SerializerException()
        {
        }

        public SerializerException(string message) : base(message)
        {
        }

        public SerializerException(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public SerializerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SerializerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}