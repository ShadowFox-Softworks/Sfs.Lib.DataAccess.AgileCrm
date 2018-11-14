﻿namespace Osw.Lib.DataAccess.AgileCrm.Entities.Contacts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Attributes;

    /// <summary>
    /// The AgileCRM Client Contact Entity.
    /// </summary>
    public class AgileCrmClientContactEntity
    {
        /// <summary>
        /// Gets or sets the address information.
        /// </summary>
        [Required]
        public AgileCrmClientAddressEntity AddressInformation { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        [Required]
        [StringLengthCollection(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Each item must be between 1 and 50 characters.")]
        public IDictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "Collection must have atleast one item.")]
        public IList<AgileCrmClientSubTypeEntity> EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 1, ErrorMessage = "Must be between 1 and 25 characters.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 1, ErrorMessage = "Must be between 1 and 25 characters.")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the lead score.
        /// </summary>
        [Required]
        [Range(0, 100, ErrorMessage = "Must be between 0 and 100.")]
        public int LeadScore { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "Collection must have atleast one item.")]
        public IList<AgileCrmClientSubTypeEntity> PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the star value.
        /// </summary>
        [Required]
        [Range(0, 5, ErrorMessage = "Must be between 0 and 5.")]
        public int StarValue { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [Required]
        [StringLengthCollection(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Each item must be between 1 and 50 characters.")]
        [MinLength(1, ErrorMessage = "Collection must have atleast one item.")]
        public IList<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 4, MinimumLength = 2, ErrorMessage = "Must be between 2 and 4 characters.")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "Collection must have atleast one item.")]
        public IList<AgileCrmClientSubTypeEntity> Website { get; set; }
    }
}