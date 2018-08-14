namespace Osw.Lib.DataAccess.AgileCrm.Interface.Internal.Processors
{
    using System.Threading;
    using System.Threading.Tasks;
    using Entity;

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