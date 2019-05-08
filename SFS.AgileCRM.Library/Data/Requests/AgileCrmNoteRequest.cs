namespace SFS.AgileCRM.Library.Data.Requests
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The AgileCRM Note Request.
    /// </summary>
    public class AgileCrmNoteRequest
    {
        /// <summary>
        /// Gets or sets the note's description.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255, MinimumLength = 1, ErrorMessage = "Must be between 1 and 255 characters.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the note's subject.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255, MinimumLength = 1, ErrorMessage = "Must be between 1 and 255 characters.")]
        public string Subject { get; set; }
    }
}