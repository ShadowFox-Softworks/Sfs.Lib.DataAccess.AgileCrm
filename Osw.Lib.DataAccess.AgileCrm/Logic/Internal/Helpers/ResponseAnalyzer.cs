namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers
{
    using System;
    using System.Net;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal.Constants;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Exceptions;

    /// <summary>
    /// The Response Analyzer
    /// </summary>
    internal static class ResponseAnalyzer
    {
        /// <summary>
        /// Analyses the AgileCRM response for errors.
        /// </summary>
        /// <param name="processorType">Type of the processor.</param>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="omittedHttpStatusCode">The omitted HTTP status code.</param>
        public static void Analyse(
            ProcessorType processorType,
            HttpStatusCode httpStatusCode,
            HttpStatusCode omittedHttpStatusCode = default(HttpStatusCode))
        {
            var message = default(string);
            switch (httpStatusCode)
            {
                // 200 (OK)
                case HttpStatusCode.OK:
                    break;

                // 204 (No Content)
                case HttpStatusCode.NoContent:
                    if (omittedHttpStatusCode == HttpStatusCode.NoContent)
                    {
                        break;
                    }

                    switch (processorType)
                    {
                        case ProcessorType.Contact:
                            message = ;
                            break;

                        case ProcessorType.Deal:
                            message = ;
                            break;
                    }

                    throw new AgileCrmNoContentException(message);

                // 400 (Bad Request)
                case HttpStatusCode.BadRequest:
                    if (omittedHttpStatusCode == HttpStatusCode.BadRequest)
                    {
                        break;
                    }

                    switch (processorType)
                    {
                        case ProcessorType.Contact:
                            message = ;
                            break;

                        case ProcessorType.Deal:
                            message = ;
                            break;
                    }

                    throw new AgileCrmBadRequestException(message);

                // 401 (Unauthorized)
                case HttpStatusCode.Unauthorized:
                    if (omittedHttpStatusCode == HttpStatusCode.Unauthorized)
                    {
                        break;
                    }

                    message = ExceptionMessage.Unauthorized;
                    throw new AgileCrmUnauthorizedException(message);

                // 406 (Not Acceptable)
                case HttpStatusCode.NotAcceptable:
                    if (omittedHttpStatusCode == HttpStatusCode.NotAcceptable)
                    {
                        break;
                    }

                    switch (processorType)
                    {
                        case ProcessorType.Contact:
                            message = ;
                            break;

                        case ProcessorType.Deal:
                            message = ;
                            break;
                    }

                    throw new AgileCrmNotAcceptableException(message);

                default:
                    throw new ArgumentOutOfRangeException($"{(int)httpStatusCode} ({httpStatusCode})");
            }
        }
    }
}