namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Exceptions
{
    using System;

    /// <summary>
    /// The AgileCRM Not Acceptable Exception
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    internal sealed class AgileCrmNotAcceptableException : Exception
    {
        /// <summary>
        /// The exception message
        /// </summary>
        private const string ExceptionMessage =
            "HTTP Code: 406 - Definition: Not Acceptable - Description: The limit of contacts has been exceeded.";

        /// <summary>
        /// Initializes a new instance of the <see cref="AgileCrmNotAcceptableException"/> class.
        /// </summary>
        public AgileCrmNotAcceptableException()
            : base(ExceptionMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgileCrmNotAcceptableException"/> class.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        public AgileCrmNotAcceptableException(Exception innerException)
            : base(ExceptionMessage, innerException)
        {
        }
    }
}