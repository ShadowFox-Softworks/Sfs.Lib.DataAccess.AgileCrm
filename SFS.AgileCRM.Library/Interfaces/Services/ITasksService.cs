namespace SFS.AgileCRM.Library.Interfaces.Services
{
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using SFS.AgileCRM.Library.Data.Requests;
    using SFS.AgileCRM.Library.Data.Responses;

    /// <summary>
    /// DO NOT USE.
    /// </summary>
    [Obsolete("DO NOT USE.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITasksService
    {
        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="agileCrmTaskModel">The agile CRM task model.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task CreateAsync(AgileCrmTaskRequest agileCrmTaskModel);

        /// <summary>
        /// Deletes an existing task via its identifier.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task DeleteAsync(long taskId);

        /// <summary>
        /// Gets an existing tals via its email address.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<AgileCrmTaskEntity> GetAsync(long contactId);

        /// <summary>
        /// Updates an existing task via its identifier.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <param name="agileCrmTaskModel">The agile CRM task model.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task UpdateAsync(long taskId, AgileCrmTaskRequest agileCrmTaskModel);
    }
}