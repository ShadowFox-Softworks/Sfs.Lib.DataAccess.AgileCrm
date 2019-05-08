namespace SFS.AgileCRM.Library.Logic.Internal.Helpers
{
    using System;
    using Microsoft.Extensions.Logging;
    using SFS.AgileCRM.Library.Data.Static.Internal;

    /// <summary>
    /// The Logging Extensions.
    /// </summary>
    internal static class LoggingExtensions
    {
        /// <summary>
        /// Debug log that the entity was created successfully.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="subjectId">The subject identifier.</param>
        public static void LogCreated(this ILogger logger, ServiceType serviceType, long subjectId)
        {
            logger.LogDebug($"AgileCRM created : {serviceType.ToString()} ({subjectId.ToString()})");
        }

        /// <summary>
        /// Debug log that the entity was deleted successfully.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="subjectId">The subject identifier.</param>
        public static void LogDeleted(this ILogger logger, ServiceType serviceType, long subjectId)
        {
            logger.LogDebug($"AgileCRM deleted : {serviceType.ToString()} ({subjectId.ToString()})");
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
        /// Debug log that the method has ended successfully.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodName">Name of the method.</param>
        public static void LogMethodEnd(this ILogger logger, string className, string methodName)
        {
            logger.LogDebug($"AgileCRM ended : {className}.{methodName}");
        }

        /// <summary>
        /// Debug log that the method has started successfully.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodName">Name of the method.</param>
        public static void LogMethodStart(this ILogger logger, string className, string methodName)
        {
            logger.LogDebug($"AgileCRM started : {className}.{methodName}");
        }

        /// <summary>
        /// Debug log that the entity was retrieved successfully.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="subjectId">The subject identifier.</param>
        public static void LogRetrieved(this ILogger logger, ServiceType serviceType, long subjectId)
        {
            logger.LogDebug($"AgileCRM retrieved : {serviceType.ToString()} ({subjectId.ToString()})");
        }

        /// <summary>
        /// Debug log that the entity was updated successfully.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="subjectId">The subject identifier.</param>
        public static void LogUpdated(this ILogger logger, ServiceType serviceType, long subjectId)
        {
            logger.LogDebug($"AgileCRM updated : {serviceType.ToString()} ({subjectId.ToString()})");
        }
    }
}