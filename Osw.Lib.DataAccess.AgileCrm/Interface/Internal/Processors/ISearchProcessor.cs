namespace Osw.Lib.DataAccess.AgileCrm.Interface.Internal.Processors
{
    using System.Threading;
    using System.Threading.Tasks;
    using Entity;

    /// <summary>
    /// The Search Processor
    /// </summary>
    internal interface ISearchProcessor
    {
        /// <summary>
        /// Get a contact's unique identifier via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />
        /// </returns>
        Task<string> GetContactIdAsync(
            string emailAddress,
            CancellationToken cancellationToken);

        /// <summary>
        /// Get a deal's unique identifier via a contact's email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="dealFilter">The deal filter.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />
        /// </returns>
        Task<string> GetDealIdAsync(
            string emailAddress,
            CancellationToken cancellationToken,
            AgileCrmDealFilter dealFilter = default(AgileCrmDealFilter));

        /// <summary>
        /// Gets a track's unique identifier via the track's name as it appears in AgileCRM.
        /// </summary>
        /// <param name="trackName">Name of the track.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />
        /// </returns>
        Task<string> GetTrackIdAsync(
            string trackName,
            CancellationToken cancellationToken);
    }
}