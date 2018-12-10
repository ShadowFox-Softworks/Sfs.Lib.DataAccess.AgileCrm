namespace Sfs.Lib.DataAccess.AgileCrm.Interfaces.Internal.Processors
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Notes;

    /// <summary>
    /// The Notes Processor.
    /// </summary>
    internal interface INotesProcessor
    {
        /// <summary>
        /// Creates a note and attaches it to a contact via their identifier.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="agileCrmClientNoteEntity">The agile CRM client note entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        Task CreateContactNoteAsync(
            long contactId,
            AgileCrmClientNoteEntity agileCrmClientNoteEntity,
            CancellationToken cancellationToken);

        /// <summary>
        /// Creates a note and attaches it to a deal via its identifier.
        /// </summary>
        /// <param name="dealId">The deal identifier.</param>
        /// <param name="agileCrmClientNoteEntity">The agile CRM client note entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        Task CreateDealNoteAsync(
            long dealId,
            AgileCrmClientNoteEntity agileCrmClientNoteEntity,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets all notes related to a contact via their identifier.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />.
        /// </returns>
        Task<IList<AgileCrmServerContactNoteEntity>> GetContactNotesAsync(
            long contactId,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets all notes related to a deal via its identifier.
        /// </summary>
        /// <param name="dealId">The deal identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />.
        /// </returns>
        Task<IList<AgileCrmServerDealNoteEntity>> GetDealNotesAsync(
            long dealId,
            CancellationToken cancellationToken);
    }
}