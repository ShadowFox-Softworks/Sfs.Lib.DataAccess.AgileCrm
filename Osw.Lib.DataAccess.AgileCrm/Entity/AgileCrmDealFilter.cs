namespace Osw.Lib.DataAccess.AgileCrm.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The AgileCRM Deal Filter
    /// </summary>
    public sealed class AgileCrmDealFilter
    {
        /// <summary>
        /// Gets or sets the milestone of the deal.
        /// </summary>
        [Required]
        public string Milestone { get; set; }

        /// <summary>
        /// Gets or sets the name of the deal.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the track identifier of the deal.
        /// </summary>
        [Required]
        public string TrackId { get; set; }
    }
}