using System.Runtime.Serialization;

namespace DnDHitPointsWebApi.Controllers
{
    [Serializable]
    internal class InvalidDamageTypeException : Exception
    {
        public InvalidDamageTypeException()
        {
        }

        public InvalidDamageTypeException(string? message) : base(message)
        {
        }

        public InvalidDamageTypeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidDamageTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}