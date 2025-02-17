using System;
using System.Runtime.Serialization;

namespace ChessLibrary
{
    /// <summary>
    /// Exception for invalid movements.
    /// </summary>
    [Serializable]
    public class InvalidMovementException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMovementException"/> class.
        /// </summary>
        public InvalidMovementException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMovementException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidMovementException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMovementException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public InvalidMovementException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMovementException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
#pragma warning disable SYSLIB0051 // Le type ou le membre est obsol�te
        protected InvalidMovementException(SerializationInfo info, StreamingContext context) : base(info, context)
#pragma warning restore SYSLIB0051 // Le type ou le membre est obsol�te
        {
        }

        /// <summary>
        /// Returns a string that represents the current exception.
        /// </summary>
        /// <returns>A string that represents the current exception.</returns>
        public override string ToString()
        {
            return Message;
        }
    }
}
