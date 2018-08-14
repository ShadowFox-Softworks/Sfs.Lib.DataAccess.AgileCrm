namespace Osw.Lib.DataAccess.AgileCrm.Entity.Internal.Bases
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The Deal Entity Base
    /// </summary>
    [DataContract]
    internal class DealEntityBase
    {
        /// <summary>
        /// Gets or sets the close date.
        /// </summary>
        [DataMember(Name = "close_date", Order = 5)]
        public string CloseDate { get; set; }

        /// <summary>
        /// Gets or sets the contact identifier.
        /// </summary>
        [DataMember(Name = "contact_ids", Order = 8)]
        public List<string> ContactId { get; set; }

        /// <summary>
        /// Gets or sets the custom data.
        /// </summary>
        [DataMember(Name = "custom_data", Order = 9)]
        public List<DealCustomDataEntity> CustomData { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [DataMember(Name = "id", Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the milestone.
        /// </summary>
        [DataMember(Name = "milestone", Order = 7)]
        public string Milestone { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "name", Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the probability.
        /// </summary>
        [DataMember(Name = "probability", Order = 4)]
        public string Probability { get; set; }

        /// <summary>
        /// Gets or sets the track identifier.
        /// </summary>
        [DataMember(Name = "pipeline_id", Order = 6)]
        public string TrackId { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [DataMember(Name = "expected_value", Order = 3)]
        public string Value { get; set; }
    }
}