namespace Osw.Lib.DataAccess.AgileCrm.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The AgileCRM Contact Entity
    /// </summary>
    public sealed class AgileCrmContactEntity
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        [StringLength(255)]
        public IEnumerable<string> Address { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [StringLength(255)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        [StringLength(255)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        [StringLength(255)]
        public IDictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [StringLength(255)]
        public ICollection<string> EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [StringLength(255)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [StringLength(255)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the lead score.
        /// </summary>
        [Range(0, 100)]
        public int LeadScore { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [StringLength(20)]
        public ICollection<string> PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the star value.
        /// </summary>
        [Range(0, 5)]
        public int StarValue { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [StringLength(255)]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [StringLength(255)]
        public ICollection<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        [StringLength(10)]
        public string ZipCode { get; set; }
    }
}