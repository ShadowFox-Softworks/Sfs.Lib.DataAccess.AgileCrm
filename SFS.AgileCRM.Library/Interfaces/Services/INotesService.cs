namespace SFS.AgileCRM.Library.Interfaces.Services
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// DO NOT USE.
    /// </summary>
    [Obsolete("DO NOT USE.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface INotesService
    {
        /// <summary>
        /// Gets the contacts.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IContactNotesService Contacts { get; }

        /// <summary>
        /// Gets the deals.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IDealNotesService Deals { get; }
    }
}