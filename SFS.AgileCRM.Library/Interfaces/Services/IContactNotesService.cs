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
    public interface IContactNotesService
    {
        /// <summary>
        /// Creates a note and attaches it to a contact via their identifier.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="agileCrmClientNoteEntity">The agile CRM client note entity.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task CreateAsync(long contactId, AgileCrmNoteModel agileCrmClientNoteEntity);

        /// <summary>
        /// Gets all notes related to a contact via their identifier.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<IList<AgileCrmContactNoteEntity>> GetAllAsync(long contactId);
    }
}