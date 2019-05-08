namespace SFS.AgileCRM.Library.Data.Requests
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The AgileCRM Contact Request.
    /// </summary>
    public class AgileCrmContactRequest : DemographicRequestBase
    {
        /// <summary>
        /// Gets or sets the company's name.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the contact's first name.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 1, ErrorMessage = "Must be between 1 and 25 characters.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the contact's last name.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 1, ErrorMessage = "Must be between 1 and 25 characters.")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the contact's title.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 4, MinimumLength = 2, ErrorMessage = "Must be between 2 and 4 characters.")]
        public string Title { get; set; }
    }
}