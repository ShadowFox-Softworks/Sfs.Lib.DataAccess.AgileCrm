namespace Osw.Lib.DataAccess.AgileCrm.Interface
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Osw.Lib.DataAccess.AgileCrm.Entities;

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
        /// Deletes the newest deal (unless identified) related to a contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="dealId">The deal identifier.</param>
        /// <returns>
        ///   <see cref="Task" />
        /// </returns>
        Task DeleteDealAsync(
            string emailAddress,
            CancellationToken cancellationToken,
            string dealId = default(string));

        /// <summary>
        /// Gets all the deals related to a contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />
        /// </returns>
        Task<List<AgileCrmDealEntity>> GetAllDealsAsync(
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
        /// Gets the newest deal (unless identified) related to a contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="dealId">The deal identifier.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />
        /// </returns>
        Task<AgileCrmDealEntity> GetDealAsync(
            string emailAddress,
            CancellationToken cancellationToken,
            string dealId = default(string));

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
        /// Updates the latest deal (unless identified) related to a contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="dealEntity">The deal entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="dealId">The deal identifier.</param>
        /// <returns>
        ///   <see cref="Task" />
        /// </returns>
        Task UpdateDealAsync(
            string emailAddress,
            AgileCrmDealEntity dealEntity,
            CancellationToken cancellationToken,
            string dealId = default(string));
    }
}