namespace Sfs.Lib.DataAccess.AgileCrm.Entities.Notes
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The AgileCRM Server Contact Note Entity.
    /// </summary>
    [DataContract]
    public class AgileCrmServerContactNoteEntity
    {
        /// <summary>
        /// Gets or sets the note's contact identifier.
        /// </summary>
        [DataMember(Name = "contact_ids", Order = 4)]
        public IList<string> ContactId { get; set; }

        /// <summary>
        /// Gets or sets the note's description.
        /// </summary>
        [DataMember(Name = "description", Order = 3)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the note's identifier.
        /// </summary>
        [DataMember(Name = "id", Order = 1)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the note's subject.
        /// </summary>
        [DataMember(Name = "subject", Order = 2)]
        public string Subject { get; set; }
    }
}