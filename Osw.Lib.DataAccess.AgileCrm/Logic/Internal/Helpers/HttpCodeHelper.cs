namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers
{
    using System;
    using System.Net;
    using Exceptions;

    /// <summary>
    /// The HTTP Code Helper
    /// </summary>
    internal static class HttpCodeHelper
    {
        /// <summary>
        /// Checks the parameter HTTP status code isn't an error.
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="originProcessor">The origin processor.</param>
        /// <param name="omittedHttpStatusCode">The omitted HTTP status code.</param>
        public static void Check(
            HttpStatusCode httpStatusCode,
            string originProcessor = null,
            HttpStatusCode? omittedHttpStatusCode = null)
        {
            switch ((int)httpStatusCode)
            {
                // OK
                case 200:
                    break;

                // No Content
                case 204:
                    if (omittedHttpStatusCode == HttpStatusCode.NoContent)
                    {
                        break;
                    }

                    throw new AgileCrmNoContentException();

                // Bad Request
                case 400:
                    if (omittedHttpStatusCode == HttpStatusCode.BadRequest)
                    {
                        break;
                    }

                    throw new AgileCrmBadRequestException();

                // Unauthorized
                case 401:
                    if (omittedHttpStatusCode == HttpStatusCode.Unauthorized)
                    {
                        break;
                    }

                    throw new AgileCrmUnauthorizedException();

                // Not Acceptable
                case 406:
                    if (omittedHttpStatusCode == HttpStatusCode.NotAcceptable)
                    {
                        break;
                    }

                    throw new AgileCrmNotAcceptableException();

                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(httpStatusCode),
                        $"{originProcessor} ({(int)httpStatusCode} {httpStatusCode.ToString()})");
            }
        }
    }
}