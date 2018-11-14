namespace Osw.Lib.DataAccess.AgileCrm.Entities.Contacts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The AgileCRM Server Contact Entity.
    /// </summary>
    [DataContract]
    public class AgileCrmServerContactEntity
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        [DataMember(Name = "contact_company_id", Order = 4)]
        public string CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [DataMember(Name = "id", Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the lead score.
        /// </summary>
        [DataMember(Name = "lead_score", Order = 3)]
        public int LeadScore { get; set; }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        [DataMember(Name = "properties", Order = 5)]
        public IList<AgileCrmServerPropertyEntity> Properties { get; set; }

        /// <summary>
        /// Gets or sets the star value.
        /// </summary>
        [DataMember(Name = "star_value", Order = 2)]
        public int StarValue { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [DataMember(Name = "tags", Order = 6)]
        public IList<string> Tags { get; set; }
    }
}