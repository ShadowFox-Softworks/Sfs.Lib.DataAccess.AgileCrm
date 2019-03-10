namespace SFS.AgileCRM.Library.Entities.Companies
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The AgileCRM Company Entity.
    /// </summary>
    public class AgileCrmCompanyEntity
    {
        /// <summary>
        /// Gets or sets the company's identifier.
        /// </summary>
        [DataMember(Name = "id", Order = 1)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the company's lead score.
        /// </summary>
        [DataMember(Name = "lead_score", Order = 3)]
        public int LeadScore { get; set; }

        /// <summary>
        /// Gets or sets the company's properties.
        /// </summary>
        [DataMember(Name = "properties", Order = 4)]
        public IList<AgileCrmPropertyEntityBase> Properties { get; set; }

        /// <summary>
        /// Gets or sets the company's star value.
        /// </summary>
        [DataMember(Name = "star_value", Order = 2)]
        public short StarValue { get; set; }

        /// <summary>
        /// Gets or sets the company's tags.
        /// </summary>
        [DataMember(Name = "tags", Order = 6)]
        public IList<string> Tags { get; set; }
    }
}