using System;
using System.Runtime.Serialization;

namespace AccesoDatos
{
    [Serializable]
    public class DaoException : Exception
    {
        public DaoException()
        {
        }

        public DaoException(string message) : base(message)
        {
        }

        public DaoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DaoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}