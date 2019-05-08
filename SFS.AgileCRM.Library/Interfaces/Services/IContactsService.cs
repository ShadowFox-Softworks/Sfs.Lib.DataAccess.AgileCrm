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
    public interface IContactsService
    {
        /// <summary>
        /// Creates a new contact.
        /// </summary>
        /// <param name="agileCrmContactModel">The AgileCRM contact model.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task CreateAsync(AgileCrmContactRequest agileCrmContactModel);

        /// <summary>
        /// Deletes an existing contact via their identifier.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task DeleteAsync(long contactId);

        /// <summary>
        /// Gets an existing contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<AgileCrmContactEntity> GetAsync(string emailAddress);

        /// <summary>
        /// Updates an existing contact via their identifier.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="agileCrmContactModel">The AgileCRM contact model.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task UpdateAsync(long contactId, AgileCrmContactRequest agileCrmContactModel);
    }
}