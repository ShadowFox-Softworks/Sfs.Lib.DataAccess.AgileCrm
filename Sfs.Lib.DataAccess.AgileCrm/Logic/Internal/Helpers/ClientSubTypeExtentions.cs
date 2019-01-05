namespace Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers
{
    using Sfs.Lib.DataAccess.AgileCrm.Entities;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Internal;

    /// <summary>
    /// The Client Sub Type Extentions.
    /// </summary>
    internal static class ClientSubTypeExtentions
    {
        /// <summary>
        /// Returns the field value where the field name matches the argument.
        /// </summary>
        /// <param name="subType">Type of the sub.</param>
        /// <returns>
        ///   <see cref="string"/>.
        /// </returns>
        public static string ToPropertyValue(this AgileCrmClientSubType subType)
        {
            // Gets the field value in PropertySubType.cs where the field name is equal to that
            // of the "subType" argument enum as a string and returns the value of the field as
            // a string.

            return typeof(PropertySubType).GetField(subType.ToString()).GetValue(null).ToString();
        }
    }
}