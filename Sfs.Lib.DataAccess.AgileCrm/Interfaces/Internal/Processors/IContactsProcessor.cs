namespace Sfs.Lib.DataAccess.AgileCrm.Interfaces.Internal.Processors
{
    using System.Threading;
    using System.Threading.Tasks;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Contacts;

    /// <summary>
    /// The Contacts Processor.
    /// </summary>
    internal interface IContactsProcessor
    {
        /// <summary>
        /// Creates a new contact.
        /// </summary>
        /// <param name="agileCrmClientContactEntity">The AgileCRM client contact entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        Task CreateContactAsync(
            AgileCrmClientContactEntity agileCrmClientContactEntity,
            CancellationToken cancellationToken);

        /// <summary>
        /// Deletes an existing contact via their identifier.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        Task DeleteContactAsync(
            long contactId,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets an existing contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />.
        /// </returns>
        Task<AgileCrmServerContactEntity> GetContactAsync(
            string emailAddress,
            CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing contact via their identifier.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="agileCrmClientContactEntity">The AgileCRM client contact entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        Task UpdateContactAsync(
            long contactId,
            AgileCrmClientContactEntity agileCrmClientContactEntity,
            CancellationToken cancellationToken);
    }
}