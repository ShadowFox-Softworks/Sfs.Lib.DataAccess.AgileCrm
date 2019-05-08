namespace SFS.AgileCRM.Library.Data.Responses
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The AgileCRM Task Entity.
    /// </summary>
    [DataContract]
    public class AgileCrmTaskEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether the task is complete.
        /// </summary>
        [DataMember(Name = "is_complete", Order = 6)]
        public bool Completed { get; set; }

        /// <summary>
        /// Gets or sets the task's created time.
        /// </summary>
        [DataMember(Name = "created_time", Order = 5)]
        public long Created { get; set; }

        /// <summary>
        /// Gets or sets the task's due.
        /// </summary>
        [DataMember(Name = "due", Order = 4)]
        public long Due { get; set; }

        /// <summary>
        /// Gets or sets the task's identifier.
        /// </summary>
        [DataMember(Name = "id", Order = 1)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the task's priority.
        /// </summary>
        [DataMember(Name = "priority_type", Order = 3)]
        public string Priority { get; set; }

        /// <summary>
        /// Gets or sets the task's progress.
        /// </summary>
        [DataMember(Name = "progress", Order = 8)]
        public int Progress { get; set; }

        /// <summary>
        /// Gets or sets the task's status.
        /// </summary>
        [DataMember(Name = "status", Order = 9)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the task's subject.
        /// </summary>
        [DataMember(Name = "subject", Order = 7)]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the task's type.
        /// </summary>
        [DataMember(Name = "type", Order = 2)]
        public string Type { get; set; }
    }
}