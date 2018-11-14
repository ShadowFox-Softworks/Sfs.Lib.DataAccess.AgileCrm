namespace Osw.Lib.DataAccess.AgileCrm.Interfaces.Internal.Processors
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The Search Processor.
    /// </summary>
    internal interface ISearchProcessor
    {
        /// <summary>
        /// Get a contact's unique identifier via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />.
        /// </returns>
        Task<string> GetContactIdAsync(
            string emailAddress,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets the newest deal's unique identifier via a contact's email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />.
        /// </returns>
        Task<string> GetDealIdAsync(
            string emailAddress,
            CancellationToken cancellationToken);
    }
}