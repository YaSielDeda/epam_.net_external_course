using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2._CUSTOM_PAINT.Entities.Exceptions
{
    [Serializable]
    class NegativeArgumentException : ApplicationException
    {
        public NegativeArgumentException()
        {
        }

        public NegativeArgumentException(string message) : base(message)
        {
        }

        public NegativeArgumentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NegativeArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
