namespace SFS.AgileCRM.Library.Data.Responses
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The AgileCRM Deal Note Entity.
    /// </summary>
    [DataContract]
    public class AgileCrmDealNoteEntity
    {
        /// <summary>
        /// Gets or sets the note's deal identifier.
        /// </summary>
        [DataMember(Name = "deal_ids", Order = 4)]
        public IList<string> DealId { get; set; }

        /// <summary>
        /// Gets or sets the note's description.
        /// </summary>
        [DataMember(Name = "description", Order = 3)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the note's identifier.
        /// </summary>
        [DataMember(Name = "id", Order = 1)]
        public long Id { get; protected set; }

        /// <summary>
        /// Gets or sets the note's subject.
        /// </summary>
        [DataMember(Name = "subject", Order = 2)]
        public string Subject { get; set; }
    }
}