using System;
using System.Runtime.Serialization;

namespace WAESAssignment.Diff.Api.Service
{
    [Serializable]
    internal class NonExistentComparissonException : Exception
    {
        public NonExistentComparissonException() : base("There are no sides to comparisson for that ID")
        {
        }

        public NonExistentComparissonException(string message) : base(message)
        {
        }

        public NonExistentComparissonException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NonExistentComparissonException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}