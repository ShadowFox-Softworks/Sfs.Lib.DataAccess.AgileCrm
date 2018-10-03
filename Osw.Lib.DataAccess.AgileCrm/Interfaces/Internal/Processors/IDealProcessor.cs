namespace Osw.Lib.DataAccess.AgileCrm.Interface.Internal.Processors
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Osw.Lib.DataAccess.AgileCrm.Entities;

    /// <summary>
    /// The Deal Processor
    /// </summary>
    internal interface IDealProcessor
    {
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