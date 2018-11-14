namespace Osw.Lib.DataAccess.AgileCrm.Entities.Deals
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The AgileCRM Client Deal Entity.
    /// </summary>
    public class AgileCrmClientDealEntity
    {
        /// <summary>
        /// Gets or sets the close date.
        /// </summary>
        [Required]
        [Range(typeof(DateTime), "2000-01-01", "2099-01-01")]
        public DateTime CloseDate { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string DealSource { get; set; }

        /// <summary>
        /// Gets or sets the milestone.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Milestone { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the probability.
        /// </summary>
        [Required]
        [Range(0, 100)]
        public int Probability { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Product { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [Required]
        [StringLength(255)]
        public IList<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [Required]
        [Range(0, double.MaxValue)]
        public double Value { get; set; }
    }
}