namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Exceptions
{
    using System;

    /// <summary>
    /// The AgileCRM Unauthorized Exception
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    internal sealed class AgileCrmUnauthorizedException : Exception
    {
        /// <summary>
        /// The predefined message
        /// </summary>
        private const string PredefinedMessage =
            "HTTP Code: 401 - Definition: Unauthorized - Description: Provided configuration is not authorized.";

        /// <summary>
        /// Initializes a new instance of the <see cref="AgileCrmUnauthorizedException" /> class.
        /// </summary>
        public AgileCrmUnauthorizedException()
            : base(PredefinedMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgileCrmUnauthorizedException"/> class.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        public AgileCrmUnauthorizedException(Exception innerException)
            : base(PredefinedMessage, innerException)
        {
        }
    }
}