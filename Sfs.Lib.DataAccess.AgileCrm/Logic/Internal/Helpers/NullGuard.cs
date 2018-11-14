namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers
{
    using System;

    /// <summary>
    /// The Null Guard.
    /// </summary>
    internal static class NullGuard
    {
        /// <summary>
        /// Ensures the not null.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">Name of the argument.</param>
        public static void EnsureNotNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                if (argument == null)
                {
                    throw new ArgumentNullException(argumentName);
                }
            }
        }

        public static void IfIsNull(object assignee, object argument)
        {
            if (argument == null)
            {
                if (argument == null)
                {
                    throw new ArgumentNullException(argumentName);
                }
            }
        }
    }
}