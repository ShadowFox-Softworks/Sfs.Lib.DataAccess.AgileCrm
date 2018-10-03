namespace Osw.Lib.DataAccess.AgileCrm.Entities.Internal.Bases
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The Deal Custom Data Entity
    /// </summary>
    [DataContract]
    internal sealed class DealCustomDataEntity
    {
        /// <summary>
        /// Gets or sets the field name, as it appears in AgileCRM.
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