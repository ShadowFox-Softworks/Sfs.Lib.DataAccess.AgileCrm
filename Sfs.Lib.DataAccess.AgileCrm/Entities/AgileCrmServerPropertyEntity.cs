namespace Osw.Lib.DataAccess.AgileCrm.Entities
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The AgileCRM Server Property Entity.
    /// </summary>
    [DataContract]
    public class AgileCrmServerPropertyEntity
    {
        /// <summary>
        /// Gets or sets the property name (as it appears in AgileCRM).
        /// </summary>
        [DataMember(Name = "name", Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the property type (SYSTEM or CUSTOM).
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