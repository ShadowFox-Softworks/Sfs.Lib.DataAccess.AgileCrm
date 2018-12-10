namespace Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers
{
    using System;

    /// <summary>
    /// The DateTime Extentions.
    /// </summary>
    internal static class DateTimeExtentions
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
            return new DateTimeOffset(dateTime).ToUnixTimeSeconds();
        }
    }
}