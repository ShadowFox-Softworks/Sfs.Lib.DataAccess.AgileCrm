namespace Osw.Lib.DataAccess.AgileCrm.Entities.Internal.Bases
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The Contact Properties Entity
    /// </summary>
    [DataContract]
    internal sealed class ContactPropertiesEntity
    {
        /// <summary>
        /// Gets or sets the property name, as it appears in AgileCRM.
        /// </summary>
        [DataMember(Name = "name", Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type", Order = 1)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        [DataMember(Name = "value", Order = 3)]
        public string Value { get; set; }
    }
}