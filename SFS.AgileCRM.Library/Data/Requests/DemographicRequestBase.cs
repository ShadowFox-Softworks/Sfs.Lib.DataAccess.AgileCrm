namespace SFS.AgileCRM.Library.Data.Requests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using SFS.AgileCRM.Library.Data.Static;
    using SFS.AgileCRM.Library.Data.Static.Internal;
    using SFS.AgileCRM.Library.Logic.Internal.Attributes;

    /// <summary>
    /// DO NOT USE. AgileCRM internal use only.
    /// </summary>
    [Obsolete("DO NOT USE. AgileCRM internal use only.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DemographicRequestBase
    {
        /// <summary>
        /// Gets or sets the address's first line.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the type of the address.
        /// </summary>
        [Required]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AgileCrmAddressType AddressType { get; set; }

        /// <summary>
        /// Gets or sets the address's city.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the address's country.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the contact's custom fields
        /// (key must be same as custom field name in AgileCRM).
        /// </summary>
        [Required]
        [StringLengthCollection(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Each item must be between 1 and 50 characters.")]
        [MinLength(length: 1, ErrorMessage = "Collection must have at least one item.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets the contact's email address.
        /// </summary>
        [Required]
        [MinLength(length: 1, ErrorMessage = "Collection must have at least one item.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<AgileCrmEmailType, string> Email { get; set; }

        /// <summary>
        /// Gets or sets the contact's lead score (0 ~ 100).
        /// </summary>
        [Required]
        [Range(minimum: 0, maximum: 100, ErrorMessage = "Must be between 0 and 100.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LeadScore { get; set; }

        /// <summary>
        /// Gets or sets the contact's phone number.
        /// </summary>
        [Required]
        [MinLength(length: 1, ErrorMessage = "Collection must have atleast one item.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<AgileCrmPhoneType, string> Phone { get; set; }

        /// <summary>
        /// Gets or sets the contact's star value (0 ~ 5).
        /// </summary>
        [Required]
        [Range(minimum: 0, maximum: 5, ErrorMessage = "Must be between 0 and 5.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public short StarValue { get; set; }

        /// <summary>
        /// Gets or sets the address's state/county.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the contact's tags.
        /// </summary>
        [Required]
        [StringLengthCollection(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Each item must be between 1 and 50 characters.")]
        [MinLength(length: 1, ErrorMessage = "Collection must have at least one item.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the contact's website address.
        /// </summary>
        [Required]
        [MinLength(length: 1, ErrorMessage = "Collection must have at least one item.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<AgileCrmWebsiteType, string> Website { get; set; }

        /// <summary>
        /// Gets or sets the address's zip/postal code.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 10, MinimumLength = 6, ErrorMessage = "Must be between 5 and 10 characters.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ZipCode { get; set; }
    }
}