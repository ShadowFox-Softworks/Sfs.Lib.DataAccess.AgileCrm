namespace SFS.AgileCRM.Library.Interfaces.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using SFS.AgileCRM.Library.Entities.Notes;

    /// <summary>
    /// DO NOT USE.
    /// </summary>
    [Obsolete("DO NOT USE.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDealNotesService
    {
        /// <summary>
        /// Creates a note and attaches it to a deal via its identifier.
        /// </summary>
        /// <param name="dealId">The deal identifier.</param>
        /// <param name="agileCrmClientNoteEntity">The agile CRM client note entity.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task CreateAsync(long dealId, AgileCrmNoteModel agileCrmClientNoteEntity);

        /// <summary>
        /// Gets all notes related to a deal via its identifier.
        /// </summary>
        /// <param name="dealId">The deal identifier.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<IList<AgileCrmDealNoteEntity>> GetAllAsync(long dealId);
    }
}