namespace Osw.Lib.DataAccess.AgileCrm.Entity.Internal.Bases
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The Contact Entity Base
    /// </summary>
    [DataContract]
    internal class ContactEntityBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [DataMember(Name = "id", Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the lead score.
        /// </summary>
        [DataMember(Name = "lead_score", Order = 3)]
        public string LeadScore { get; set; }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        [DataMember(Name = "properties", Order = 4)]
        public List<ContactPropertiesEntity> Properties { get; set; }

        /// <summary>
        /// Gets or sets the star value.
        /// </summary>
        [DataMember(Name = "star_value", Order = 2)]
        public string StarValue { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [DataMember(Name = "tags", Order = 5)]
        public List<string> Tags { get; set; }
    }
}