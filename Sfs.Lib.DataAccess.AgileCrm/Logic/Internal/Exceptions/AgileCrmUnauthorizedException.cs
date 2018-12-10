namespace Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The AgileCRM Unauthorized Exception.
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    internal sealed class AgileCrmUnauthorizedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgileCrmUnauthorizedException"/> class.
        /// </summary>
        public AgileCrmUnauthorizedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgileCrmUnauthorizedException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AgileCrmUnauthorizedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgileCrmUnauthorizedException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public AgileCrmUnauthorizedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgileCrmUnauthorizedException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        private AgileCrmUnauthorizedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}