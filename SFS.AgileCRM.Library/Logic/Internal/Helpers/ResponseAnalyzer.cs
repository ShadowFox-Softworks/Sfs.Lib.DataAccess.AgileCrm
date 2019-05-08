namespace SFS.AgileCRM.Library.Logic.Internal.Helpers
{
    using System.Net;
    using System.Net.Http;
    using SFS.AgileCRM.Library.Data.Static.Internal;

    /// <summary>
    /// The Response Analyzer.
    /// </summary>
    internal static class ResponseAnalyzer
    {
        /// <summary>
        /// Analyzes the AgileCRM HTTP response for errors.
        /// </summary>
        /// <param name="httpResponseMessage">The HTTP response message.</param>
        public static void AnalyzeResponseForErrors(this HttpResponseMessage httpResponseMessage)
        {
            var isSuccessStatusCode = httpResponseMessage.EnsureSuccessStatusCode();

            if (!isSuccessStatusCode.)
            {
            }

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