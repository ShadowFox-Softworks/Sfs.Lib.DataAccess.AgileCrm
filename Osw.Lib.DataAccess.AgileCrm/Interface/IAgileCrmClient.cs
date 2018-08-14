namespace Osw.Lib.DataAccess.AgileCrm.Interface
{
    using System.Threading;
    using System.Threading.Tasks;
    using Entity;

    /// <summary>
    /// The AgileCRM Client
    /// </summary>
    public interface IAgileCrmClient
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
        /// Creates a deal and attaches it to a contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="dealEntity">The deal entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />
        /// </returns>
        Task CreateDealAsync(
            string emailAddress,
            AgileCrmDealEntity dealEntity,
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
        /// Deletes the latest deal (unless filtered) related to a contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="dealFilter">The deal filter.</param>
        /// <returns>
        ///   <see cref="Task" />
        /// </returns>
        Task DeleteDealAsync(
            string emailAddress,
            CancellationToken cancellationToken,
            AgileCrmDealFilter dealFilter = default(AgileCrmDealFilter));

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
        /// Gets the latest deal (unless filtered) related to a contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="dealFilter">The deal filter.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />
        /// </returns>
        Task<AgileCrmDealEntity> GetDealAsync(
            string emailAddress,
            CancellationToken cancellationToken,
            AgileCrmDealFilter dealFilter = default(AgileCrmDealFilter));

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

        /// <summary>
        /// Updates the latest deal (unless filtered) related to a contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="dealEntity">The deal entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="dealFilter">The deal filter.</param>
        /// <returns>
        ///   <see cref="Task" />
        /// </returns>
        Task UpdateDealAsync(
            string emailAddress,
            AgileCrmDealEntity dealEntity,
            CancellationToken cancellationToken,
            AgileCrmDealFilter dealFilter = default(AgileCrmDealFilter));
    }
}