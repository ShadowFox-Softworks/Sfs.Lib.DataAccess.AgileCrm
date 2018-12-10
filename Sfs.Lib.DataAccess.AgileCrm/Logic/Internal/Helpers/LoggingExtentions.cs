namespace Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers
{
    using System;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The Logging Extentions.
    /// </summary>
    internal static class LoggingExtentions
    {
        /// <summary>
        /// Critical log that an exception has been thrown.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodName">Name of the method.</param>
        public static void LogException(this ILogger logger, Exception exception, string className, string methodName)
        {
            logger.LogCritical($"AgileCRM exception thrown : {className}.{methodName} : {exception}");
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
    }
}