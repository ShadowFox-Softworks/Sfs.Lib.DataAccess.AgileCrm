namespace SFS.AgileCRM.Library.Entities.Deals
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The AgileCRM Custom Data Entity.
    /// </summary>
    [DataContract]
    public sealed class AgileCrmCustomDataEntity
    {
        /// <summary>
        /// Gets or sets the field name.
        /// </summary>
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the field value.
        /// </summary>
        [DataMember(Name = "value", Order = 2)]
        public string Value { get; set; }
    }
}