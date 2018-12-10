namespace Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers
{
    using System;

    /// <summary>
    /// The Null Extentions.
    /// </summary>
    internal static class NullExtentions
    {
        /// <summary>
        /// Ensures the argument is not null.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <exception cref="ArgumentNullException">argument.</exception>
        public static void EnsureNotNull(this object argument)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(nameof(argument));
            }
        }
    }
}