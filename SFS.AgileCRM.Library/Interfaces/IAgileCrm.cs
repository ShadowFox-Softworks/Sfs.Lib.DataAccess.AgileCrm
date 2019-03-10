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
        /// Gets the contact notes.
        /// </summary>
        IContactNotesService ContactNotes { get; }

        /// <summary>
        /// Gets the contacts.
        /// </summary>
        IContactsService Contacts { get; }

        /// <summary>
        /// Gets the deal notes.
        /// </summary>
        IDealNotesService DealNotes { get; }

        /// <summary>
        /// Gets the deals.
        /// </summary>
        IDealsService Deals { get; }
    }
}