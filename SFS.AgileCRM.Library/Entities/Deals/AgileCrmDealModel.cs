namespace SFS.AgileCRM.Library.Entities.Deals
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using SFS.AgileCRM.Library.Logic.Internal.Attributes;

    /// <summary>
    /// The AgileCRM Deal Model.
    /// </summary>
    public class AgileCrmDealModel
    {
        /// <summary>
        /// Gets or sets the deal's close date.
        /// </summary>
        [Required]
        [Range(typeof(DateTime), "2000-01-01", "2099-01-01", ErrorMessage = "Must be between 2000-01-01 and 2099-01-01")]
        public DateTime CloseDate { get; set; }

        /// <summary>
        /// Gets or sets the contact's custom fields
        /// (key must be same as custom field name in AgileCRM).
        /// </summary>
        [Required]
        [StringLengthCollection(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Each item must be between 1 and 50 characters.")]
        [MinLength(1, ErrorMessage = "Collection must have atleast one item.")]
        public IDictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets the deal's milestone (as it appears in AgileCRM).
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string Milestone { get; set; }

        /// <summary>
        /// Gets or sets the deal's name.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the deal's probability.
        /// </summary>
        [Required]
        [Range(0, 100, ErrorMessage = "Must be between 0 and 100.")]
        public int Probability { get; set; }

        /// <summary>
        /// Gets or sets the deal's product name (as it appears in AgileCRM).
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the deal's tags.
        /// </summary>
        [Required]
        [StringLengthCollection(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Each item must be between 1 and 50 characters.")]
        [MinLength(1, ErrorMessage = "Collection must have atleast one item.")]
        public IList<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the deal's value.
        /// </summary>
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Must be between 0 and double.MaxValue.")]
        public double Value { get; set; }
    }
}