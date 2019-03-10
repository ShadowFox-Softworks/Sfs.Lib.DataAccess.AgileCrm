namespace SFS.AgileCRM.Library.Entities.Companies
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using SFS.AgileCRM.Library.Logic.Internal.Attributes;

    /// <summary>
    /// The AgileCRM Company Model.
    /// </summary>
    public class AgileCrmCompanyModel
    {
        /// <summary>
        /// Gets or sets the address information.
        /// </summary>
        [Required]
        public AgileCrmAddressModel AddressInformation { get; set; }

        /// <summary>
        /// Gets or sets the company's custom fields.
        /// </summary>
        [Required]
        [StringLengthCollection(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Each item must be between 1 and 50 characters.")]
        [MinLength(1, ErrorMessage = "Collection must have atleast one item.")]
        public IDictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets the company's email address.
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "Collection must have at least one item.")]
        public IList<AgileCrmSubTypeModel> EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the company's lead score.
        /// </summary>
        [Required]
        [Range(0, 100, ErrorMessage = "Must be between 0 and 100.")]
        public int LeadScore { get; set; }

        /// <summary>
        /// Gets or sets the  company's name.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the company's phone number.
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "Collection must have at least one item.")]
        public IList<AgileCrmSubTypeModel> PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the company's star value.
        /// </summary>
        [Required]
        [Range(0, 5, ErrorMessage = "Must be between 0 and 5.")]
        public short StarValue { get; set; }

        /// <summary>
        /// Gets or sets company's the tags.
        /// </summary>
        [Required]
        [StringLengthCollection(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Each item must be between 1 and 50 characters.")]
        [MinLength(1, ErrorMessage = "Collection must have at least one item.")]
        public IList<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the company's URL.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string URL { get; set; }

        /// <summary>
        /// Gets or sets company's the website.
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "Collection must have at least one item.")]
        public IList<AgileCrmSubTypeModel> Website { get; set; }
    }
}