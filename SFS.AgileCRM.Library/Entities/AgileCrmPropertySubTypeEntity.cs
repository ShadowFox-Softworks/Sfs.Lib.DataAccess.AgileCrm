namespace SFS.AgileCRM.Library.Entities
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The AgileCRM Property Sub Type Entity.
    /// </summary>
    /// <seealso cref="SFS.AgileCRM.Library.Entities.AgileCrmPropertyEntityBase" />
    [DataContract]
    public class AgileCrmPropertySubTypeEntity : AgileCrmPropertyEntityBase
    {
        /// <summary>
        /// Gets or sets the property's name (as it appears in AgileCRM).
        /// </summary>
        [DataMember(Name = "name", Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the property's sub type.
        /// </summary>
        [DataMember(Name = "subtype", Order = 4)]
        public string SubType { get; set; }

        /// <summary>
        /// Gets or sets the property's type (as it appears in AgileCRM).
        /// </summary>
        [DataMember(Name = "type", Order = 1)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the property's value.
        /// </summary>
        [DataMember(Name = "value", Order = 3)]
        public string Value { get; set; }
    }
}