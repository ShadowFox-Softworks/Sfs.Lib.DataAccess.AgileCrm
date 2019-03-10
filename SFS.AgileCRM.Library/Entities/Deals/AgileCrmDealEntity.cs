namespace SFS.AgileCRM.Library.Entities.Deals
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The AgileCRM Deal Entity.
    /// </summary>
    [DataContract]
    public sealed class AgileCrmDealEntity
    {
        /// <summary>
        /// Gets or sets the deal's close date.
        /// </summary>
        [DataMember(Name = "close_date", Order = 5)]
        public long CloseDate { get; set; }

        /// <summary>
        /// Gets or sets the deal's contact identifier.
        /// </summary>
        [DataMember(Name = "contact_ids", Order = 8)]
        public IList<string> ContactId { get; set; }

        /// <summary>
        /// Gets or sets the deal's custom data.
        /// </summary>
        [DataMember(Name = "custom_data", Order = 9)]
        public IList<AgileCrmCustomDataEntity> CustomData { get; set; }

        /// <summary>
        /// Gets or sets the deal's identifier.
        /// </summary>
        [DataMember(Name = "id", Order = 1)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the deal's milestone.
        /// </summary>
        [DataMember(Name = "milestone", Order = 7)]
        public string Milestone { get; set; }

        /// <summary>
        /// Gets or sets the deal's name.
        /// </summary>
        [DataMember(Name = "name", Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the deal's probability.
        /// </summary>
        [DataMember(Name = "probability", Order = 4)]
        public int Probability { get; set; }

        /// <summary>
        /// Gets or sets the deal's track identifier.
        /// </summary>
        [DataMember(Name = "pipeline_id", Order = 6)]
        public long TrackId { get; set; }

        /// <summary>
        /// Gets or sets the deal's value.
        /// </summary>
        [DataMember(Name = "expected_value", Order = 3)]
        public double Value { get; set; }
    }
}