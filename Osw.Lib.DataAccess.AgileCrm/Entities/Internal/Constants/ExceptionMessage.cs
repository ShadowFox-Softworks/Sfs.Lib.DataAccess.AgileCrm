namespace Osw.Lib.DataAccess.AgileCrm.Entities.Internal.Constants
{
    /// <summary>
    /// The Exception Message
    /// </summary>
    internal static class ExceptionMessage
    {
        /// <summary>
        /// The bad request
        /// </summary>
        public const string BadRequest = "400 (Bad Request) : Input in wrong format or entity already exists.";

        /// <summary>
        /// The no content
        /// </summary>
        public const string NoContent = "204 (No Content) : No entity with specified identififer.";

        /// <summary>
        /// The not acceptable
        /// </summary>
        public const string NotAcceptable = "406 (Not Acceptable) : The limit of contacts has been exceeded.";

        /// <summary>
        /// The unauthorized
        /// </summary>
        public const string Unauthorized = "401 (Unauthorized) : Provided configuration is not authorized.";
    }
}