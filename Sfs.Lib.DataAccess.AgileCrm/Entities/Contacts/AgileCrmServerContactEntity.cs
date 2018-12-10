namespace Sfs.Lib.DataAccess.AgileCrm.Entities.Contacts
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
        /// Gets or sets the contact's company identifier.
        /// </summary>
        [DataMember(Name = "contact_company_id", Order = 4)]
        public long CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the contact's identifier.
        /// </summary>
        [DataMember(Name = "id", Order = 1)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the contact's lead score.
        /// </summary>
        [DataMember(Name = "lead_score", Order = 3)]
        public int LeadScore { get; set; }

        /// <summary>
        /// Gets or sets the contact's properties.
        /// </summary>
        [DataMember(Name = "properties", Order = 5)]
        public IList<AgileCrmServerPropertyBase> Properties { get; set; }

        /// <summary>
        /// Gets or sets the contact's star value.
        /// </summary>
        [DataMember(Name = "star_value", Order = 2)]
        public short StarValue { get; set; }

        /// <summary>
        /// Gets or sets the contact's tags.
        /// </summary>
        [DataMember(Name = "tags", Order = 6)]
        public IList<string> Tags { get; set; }
    }
}