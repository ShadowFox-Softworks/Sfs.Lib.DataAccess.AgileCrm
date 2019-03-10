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
        /// Gets the contact notes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IContactNotesService Contact { get; }

        /// <summary>
        /// Gets the deal notes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IDealNotesService Deal { get; }
    }
}