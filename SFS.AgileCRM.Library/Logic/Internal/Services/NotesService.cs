namespace SFS.AgileCRM.Library.Logic
{
    using SFS.AgileCRM.Library.Interfaces.Services;
    using SFS.AgileCRM.Library.Logic.Internal.Helpers;

    /// <inheritdoc />
    public sealed class NotesService : INotesService
    {
        /// <summary>
        /// The contact notes service.
        /// </summary>
        private readonly IContactNotesService contactNotesService;

        /// <summary>
        /// The deal notes service.
        /// </summary>
        private readonly IDealNotesService dealNotesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesService" /> class.
        /// </summary>
        /// <param name="contactNotesService">The contact notes service.</param>
        /// <param name="dealNotesService">The deal notes service.</param>
        internal NotesService(
            IContactNotesService contactNotesService,
            IDealNotesService dealNotesService)
        {
            contactNotesService.EnsureNotNull();
            dealNotesService.EnsureNotNull();

            this.contactNotesService = contactNotesService;
            this.dealNotesService = dealNotesService;
        }

        /// <inheritdoc />
        public IContactNotesService Contacts => this.contactNotesService;

        /// <inheritdoc />
        public IDealNotesService Deals => this.dealNotesService;
    }
}