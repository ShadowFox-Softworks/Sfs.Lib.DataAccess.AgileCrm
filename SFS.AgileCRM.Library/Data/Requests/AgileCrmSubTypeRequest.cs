namespace SFS.AgileCRM.Library.Data.Requests
{
    using System.ComponentModel.DataAnnotations;
    using SFS.AgileCRM.Library.Data.Static;

    /// <summary>
    /// The AgileCRM Sub Type Request.
    /// </summary>
    public class AgileCrmSubTypeRequest
    {
        /// <summary>
        /// Gets or sets the sub type.
        /// </summary>
        [Required]
        public AgileCrmPropertySubType SubType { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public string Value { get; set; }
    }
}