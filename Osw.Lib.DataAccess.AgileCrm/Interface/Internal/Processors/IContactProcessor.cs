namespace Osw.Lib.DataAccess.AgileCrm.Interface.Internal.Processors
{
    using System.Threading;
    using System.Threading.Tasks;
    using Entity;

    /// <summary>
    /// The Contact Processor
    /// </summary>
    internal interface IContactProcessor
    {
        /// <summary>
        /// Creates a new contact.
        /// </summary>
        /// <param name="contactEntity">The contact entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />
        /// </returns>
        Task CreateContactAsync(
            AgileCrmContactEntity contactEntity,
            CancellationToken cancellationToken);

        /// <summary>
        /// Deletes an existing contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />
        /// </returns>
        Task DeleteContactAsync(
            string emailAddress,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets an existing contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />
        /// </returns>
        Task<AgileCrmContactEntity> GetContactAsync(
            string emailAddress,
            CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="contactEntity">The contact entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />
        /// </returns>
        Task UpdateContactAsync(
            string emailAddress,
            AgileCrmContactEntity contactEntity,
            CancellationToken cancellationToken);
    }
}