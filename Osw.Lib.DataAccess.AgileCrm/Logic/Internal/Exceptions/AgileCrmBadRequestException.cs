namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Exceptions
{
    using System;

    /// <summary>
    /// The AgileCRM Bad Request Exception
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    internal sealed class AgileCrmBadRequestException : Exception
    {
        /// <summary>
        /// The predefined message
        /// </summary>
        private const string PredefinedMessage =
            "HTTP Code: 400 - Definition: Bad Request - Description: Input in wrong format or entity already exists.";

        /// <summary>
        /// Initializes a new instance of the <see cref="AgileCrmBadRequestException" /> class.
        /// </summary>
        public AgileCrmBadRequestException()
            : base(PredefinedMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgileCrmBadRequestException"/> class.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        public AgileCrmBadRequestException(Exception innerException)
            : base(PredefinedMessage, innerException)
        {
        }
    }
}