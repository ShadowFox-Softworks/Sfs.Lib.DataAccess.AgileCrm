namespace SFS.AgileCRM.Library.Logic.Internal.Helpers
{
    using SFS.AgileCRM.Library.Entities;
    using SFS.AgileCRM.Library.Entities.Internal;

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
        public static string ToPropertyValue(this AgileCrmSubType subType)
        {
            // Gets the field value in PropertySubType.cs where the field name is equal to that
            // of the "subType" argument enum (as a string) and returns the value of the field (as
            // a string).

            return typeof(PropertySubType).GetField(subType.ToString()).GetValue(null).ToString();
        }
    }
}