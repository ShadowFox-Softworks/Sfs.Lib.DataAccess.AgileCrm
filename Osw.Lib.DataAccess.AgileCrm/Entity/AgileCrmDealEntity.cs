namespace Osw.Lib.DataAccess.AgileCrm.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The AgileCRM Deal Entity
    /// </summary>
    public sealed class AgileCrmDealEntity
    {
        // TODO: Match entity model to deal creation in AgileCRM

        /// <summary>
        /// Gets or sets the close date.
        /// </summary>
        [Range(typeof(DateTime), "2018-01-01", "2099-01-01")]
        public DateTime CloseDate { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [StringLength(255)]
        public string DealSource { get; set; }

        /// <summary>
        /// Gets or sets the milestone.
        /// </summary>
        [StringLength(255)]
        public string Milestone { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the probability.
        /// </summary>
        [Range(0, 100)]
        public int Probability { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        [StringLength(255)]
        public string Product { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [StringLength(255)]
        public ICollection<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [Range(0, double.MaxValue)]
        public double Value { get; set; }
    }
}