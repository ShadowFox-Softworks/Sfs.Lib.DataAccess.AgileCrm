namespace SFS.AgileCRM.Library.Logic.Internal.Helpers
{
    using System.Net;
    using SFS.AgileCRM.Library.Entities.Internal;

    /// <summary>
    /// The Response Analyzer.
    /// </summary>
    internal static class ResponseAnalyzer
    {
        /// <summary>
        /// Analyzes the AgileCRM HTTP response for errors.
        /// </summary>
        /// <param name="processorType">Type of the processor.</param>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="omittedHttpStatusCode">The omitted HTTP status code.</param>
        public static void Analyze(
            ProcessorType processorType,
            HttpStatusCode httpStatusCode,
            HttpStatusCode omittedHttpStatusCode = default(HttpStatusCode))
        {
            switch (httpStatusCode)
            {
                // 200 (OK)
                case HttpStatusCode.OK:
                    // Do nothing
                    break;

                // 204 (No Content)
                case HttpStatusCode.NoContent:
                    // Throw exception
                    break;

                // 400 (Bad Request)
                case HttpStatusCode.BadRequest:
                    // Throw exception
                    break;

                // 401 (Unauthorized)
                case HttpStatusCode.Unauthorized:
                    // Throw exception
                    break;

                // 406 (Not Acceptable)
                case HttpStatusCode.NotAcceptable:
                    // Throw exception
                    break;

                default:
                    // Throw exception
                    break;
            }
        }
    }
}