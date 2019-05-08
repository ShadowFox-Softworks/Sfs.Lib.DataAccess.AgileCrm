namespace SFS.AgileCRM.Library.Data.Requests
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using SFS.AgileCRM.Library.Data.Static;

    /// <summary>
    /// The AgileCRM Task Request.
    /// </summary>
    public class AgileCrmTaskRequest
    {
        /// <summary>
        /// Gets or sets a value indicating whether the task is complete.
        /// </summary>
        [Required]
        public bool Completed { get; set; }

        /// <summary>
        /// Gets or sets the task's due.
        /// </summary>
        [Required]
        [Range(type: typeof(DateTime), minimum: "2000-01-01", maximum: "2099-01-01", ErrorMessage = "Must be between 2000-01-01 and 2099-01-01 (yyyy-mm-dd).")]
        public DateTime Due { get; set; }

        /// <summary>
        /// Gets or sets the task's priority.
        /// </summary>
        [Required]
        public AgileCrmTaskPriorityType Priority { get; set; }

        /// <summary>
        /// Gets or sets the task's progress.
        /// </summary>
        [Required]
        [Range(minimum: 0, maximum: 100, ErrorMessage = "Must be between 0 and 100.")]
        public int Progress { get; set; }

        /// <summary>
        /// Gets or sets the task's status.
        /// </summary>
        [Required]
        public AgileCrmTaskStatusType Status { get; set; }

        /// <summary>
        /// Gets or sets the task's subject.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255, MinimumLength = 1, ErrorMessage = "Must be between 1 and 255 characters.")]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the task's type.
        /// </summary>
        [Required]
        public AgileCrmTaskType Type { get; set; }
    }
}