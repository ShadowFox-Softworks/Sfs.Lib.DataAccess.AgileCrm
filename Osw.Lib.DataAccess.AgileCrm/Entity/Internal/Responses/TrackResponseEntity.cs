namespace Osw.Lib.DataAccess.AgileCrm.Entity.Internal.Responses
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    /// <summary>
    /// The Track Response Entity
    /// </summary>
    [DataContract]
    internal sealed class TrackResponseEntity
    {
        /// <summary>
        /// Gets or sets the track identifier.
        /// </summary>
        [Required]
        [DataMember(Name = "id", Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the milestones.
        /// </summary>
        [Required]
        [DataMember(Name = "milestones", Order = 2)]
        public string Milestones { get; set; }

        /// <summary>
        /// Gets or sets the track name, as it appears in AgileCRM.
        /// </summary>
        [Required]
        [DataMember(Name = "name", Order = 3)]
        public string Name { get; set; }
    }
}