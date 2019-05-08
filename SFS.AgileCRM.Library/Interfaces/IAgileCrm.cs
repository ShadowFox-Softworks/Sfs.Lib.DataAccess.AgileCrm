namespace SFS.AgileCRM.Library.Interface
{
    using SFS.AgileCRM.Library.Interfaces.Services;

    /// <summary>
    /// The AgileCRM.
    /// </summary>
    public interface IAgileCrm
    {
        /// <summary>
        /// Gets the companies.
        /// </summary>
        ICompaniesService Companies { get; }

        /// <summary>
        /// Gets the contacts.
        /// </summary>
        IContactsService Contacts { get; }

        /// <summary>
        /// Gets the deals.
        /// </summary>
        IDealsService Deals { get; }

        /// <summary>
        /// Gets the notes.
        /// </summary>
        INotesService Notes { get; }

        /// <summary>
        /// Gets the tasks.
        /// </summary>
        ITasksService Tasks { get; }
    }
}