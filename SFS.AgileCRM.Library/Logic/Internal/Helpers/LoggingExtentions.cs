namespace SFS.AgileCRM.Library.Logic.Internal.Helpers
{
    using System;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The Logging Extentions.
    /// </summary>
    internal static class LoggingExtentions
    {
        /// <summary>
        /// Debug log that the domain object was created.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="description">The description.</param>
        public static void LogCreated(this ILogger logger, string description)
        {
            logger.LogDebug($"AgileCRM : {description} created successfully.");
        }

        /// <summary>
        /// Debug log that the domain object was deleted.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="description">The description.</param>
        public static void LogDeleted(this ILogger logger, string description)
        {
            logger.LogDebug($"AgileCRM : {description} deleted successfully.");
        }

        /// <summary>
        /// Critical log that an exception has been thrown.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="exception">The exception.</param>
        public static void LogException(this ILogger logger, string className, string methodName, Exception exception)
        {
            logger.LogCritical($"AgileCRM exception : {className}.{methodName} : {exception}");
        }

        /// <summary>
        /// Debug log that the method has ended.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodName">Name of the method.</param>
        public static void LogMethodEnd(this ILogger logger, string className, string methodName)
        {
            logger.LogDebug($"AgileCRM method end : {className}.{methodName}");
        }

        /// <summary>
        /// Debug log that the method has started.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodName">Name of the method.</param>
        public static void LogMethodStart(this ILogger logger, string className, string methodName)
        {
            logger.LogDebug($"AgileCRM method start : {className}.{methodName}");
        }

        /// <summary>
        /// Debug log that the domain object was retrieved.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="description">The description.</param>
        public static void LogRetrieved(this ILogger logger, string description)
        {
            logger.LogDebug($"AgileCRM : {description} retrieved successfully.");
        }

        /// <summary>
        /// Debug log that the domain object was updated.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="description">The description.</param>
        public static void LogUpdated(this ILogger logger, string description)
        {
            logger.LogDebug($"AgileCRM : {description} updated successfully.");
        }
    }
}