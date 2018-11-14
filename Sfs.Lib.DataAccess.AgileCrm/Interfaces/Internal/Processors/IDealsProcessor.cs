namespace Osw.Lib.DataAccess.AgileCrm.Interfaces.Internal.Processors
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Deals;

    /// <summary>
    /// The Deals Processor.
    /// </summary>
    internal interface IDealsProcessor
    {
        /// <summary>
        /// Creates a new deal and attaches it to a contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="agileCrmClientDealEntity">The AgileCRM client deal entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        Task CreateDealAsync(
            string emailAddress,
            AgileCrmClientDealEntity agileCrmClientDealEntity,
            CancellationToken cancellationToken);

        /// <summary>
        /// Deletes an existing deal via its unique identifier.
        /// </summary>
        /// <param name="dealId">The deal identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        Task DeleteDealAsync(
            string dealId,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets all existing deals related to a contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />.
        /// </returns>
        Task<List<AgileCrmServerDealEntity>> GetDealsAsync(
            string emailAddress,
            CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing deal via its unique identifier.
        /// </summary>
        /// <param name="dealId">The deal identifier.</param>
        /// <param name="agileCrmClientDealEntity">The AgileCRM client deal entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        Task UpdateDealAsync(
            string dealId,
            AgileCrmClientDealEntity agileCrmClientDealEntity,
            CancellationToken cancellationToken);
    }
}