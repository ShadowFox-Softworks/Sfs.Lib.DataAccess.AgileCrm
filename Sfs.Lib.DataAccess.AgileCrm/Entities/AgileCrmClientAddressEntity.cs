namespace Osw.Lib.DataAccess.AgileCrm.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The AgileCRM Client Address Entity.
    /// </summary>
    public class AgileCrmClientAddressEntity
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        [Required]
        public AgileCrmClientSubTypeEntity Address { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the postal/zip.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 10, MinimumLength = 6, ErrorMessage = "Must be between 5 and 10 characters.")]
        public string ZipCode { get; set; }
    }
}