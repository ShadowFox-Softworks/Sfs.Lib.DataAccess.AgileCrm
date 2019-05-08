namespace SFS.AgileCRM.Library.Logic.Internal.Helpers
{
    using System;

    /// <summary>
    /// The Date Time Extensions.
    /// </summary>
    internal static class DateTimeExtensions
    {
        /// <summary>
        /// Returns the argument value represented as epoch.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>
        ///   <see cref="long"/>.
        /// </returns>
        public static long ToEpoch(this DateTime dateTime)
        {
            // Converts a DateTime object to its respective epoch.
            // Epoch is the number of seconds since the 01/01/1970.

            return new DateTimeOffset(dateTime).ToUnixTimeSeconds();
        }
    }
}