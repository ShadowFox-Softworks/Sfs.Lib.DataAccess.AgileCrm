namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Exceptions
{
    using System;

    /// <summary>
    /// The AgileCRM No Content Exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    internal sealed class AgileCrmNoContentException : Exception
    {
        /// <summary>
        /// The predefined message
        /// </summary>
        private const string PredefinedMessage =
            "HTTP Code: 204 - Definition: No Content - Description: No entity with specified identififer.";

        /// <summary>
        /// Initializes a new instance of the <see cref="AgileCrmNoContentException"/> class.
        /// </summary>
        public AgileCrmNoContentException()
            : base(PredefinedMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgileCrmNoContentException"/> class.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        public AgileCrmNoContentException(Exception innerException)
            : base(PredefinedMessage, innerException)
        {
        }
    }
}