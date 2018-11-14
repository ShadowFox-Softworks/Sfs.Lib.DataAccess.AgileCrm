namespace Osw.Lib.DataAccess.AgileCrm.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The AgileCRM Client Sub Type Entity.
    /// </summary>
    public class AgileCrmClientSubTypeEntity
    {
        /// <summary>
        /// Gets or sets the sub type.
        /// </summary>
        [Required]
        public AgileCrmClientSubType SubType { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string Value { get; set; }
    }
}