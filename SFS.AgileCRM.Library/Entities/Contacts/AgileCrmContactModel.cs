namespace SFS.AgileCRM.Library.Entities.Contacts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using SFS.AgileCRM.Library.Logic.Internal.Attributes;

    /// <summary>
    /// The AgileCRM Contact Model.
    /// </summary>
    public class AgileCrmContactModel
    {
        /// <summary>
        /// Gets or sets the contact's address information.
        /// </summary>
        [Required]
        public AgileCrmAddressModel AddressInformation { get; set; }

        /// <summary>
        /// Gets or sets the company's name.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the contact's custom fields
        /// (key must be same as custom field name in AgileCRM).
        /// </summary>
        [Required]
        [StringLengthCollection(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Each item must be between 1 and 50 characters.")]
        [MinLength(1, ErrorMessage = "Collection must have at least one item.")]
        public IDictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets the contact's email address.
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "Collection must have at least one item.")]
        public IList<AgileCrmSubTypeModel> EmailAddress { get; set; }

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
        /// Gets or sets the contact's lead score.
        /// </summary>
        [Required]
        [Range(0, 100, ErrorMessage = "Must be between 0 and 100.")]
        public int LeadScore { get; set; }

        /// <summary>
        /// Gets or sets the contact's phone number.
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "Collection must have atleast one item.")]
        public IList<AgileCrmSubTypeModel> PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the contact's star value.
        /// </summary>
        [Required]
        [Range(0, 5, ErrorMessage = "Must be between 0 and 5.")]
        public short StarValue { get; set; }

        /// <summary>
        /// Gets or sets the contact's tags.
        /// </summary>
        [Required]
        [StringLengthCollection(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Each item must be between 1 and 50 characters.")]
        [MinLength(1, ErrorMessage = "Collection must have at least one item.")]
        public IList<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the contact's title.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 4, MinimumLength = 2, ErrorMessage = "Must be between 2 and 4 characters.")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the contact's website.
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "Collection must have at least one item.")]
        public IList<AgileCrmSubTypeModel> Website { get; set; }
    }
}