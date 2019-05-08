namespace SFS.AgileCRM.Library.Data.Requests
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The AgileCRM Company Request.
    /// </summary>
    public class AgileCrmCompanyRequest : DemographicRequestBase
    {
        /// <summary>
        /// Gets or sets the  company's name.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the company's URL.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string URL { get; set; }
    }
}