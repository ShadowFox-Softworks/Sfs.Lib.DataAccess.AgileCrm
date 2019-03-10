namespace SFS.AgileCRM.Library.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The AgileCRM Sub Type Model.
    /// </summary>
    public class AgileCrmSubTypeModel
    {
        /// <summary>
        /// Gets or sets the sub type.
        /// </summary>
        [Required]
        public AgileCrmSubType SubType { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string Value { get; set; }
    }
}