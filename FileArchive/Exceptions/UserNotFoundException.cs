using System;
using System.Runtime.Serialization;

namespace FileArchive.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException ()
        {
        }

        protected UserNotFoundException (SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UserNotFoundException (string? message) : base(message)
        {
        }

        public UserNotFoundException (string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}