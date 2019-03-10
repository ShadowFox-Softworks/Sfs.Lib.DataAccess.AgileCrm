namespace SFS.AgileCRM.Library.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The AgileCRM Address Model.
    /// </summary>
    public class AgileCrmAddressModel
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the address's city.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the address's country.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the address's state.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the address's sub type.
        /// </summary>
        [Required]
        public AgileCrmSubType SubType { get; set; }

        /// <summary>
        /// Gets or sets the address's postal/zip code.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 10, MinimumLength = 6, ErrorMessage = "Must be between 5 and 10 characters.")]
        public string ZipCode { get; set; }
    }
}