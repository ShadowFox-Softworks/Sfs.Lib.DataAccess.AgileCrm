namespace SFS.AgileCRM.Library.Logic
{
    using SFS.AgileCRM.Library.Interface;
    using SFS.AgileCRM.Library.Interfaces.Services;
    using SFS.AgileCRM.Library.Logic.Internal.Helpers;

    /// <inheritdoc />
    public sealed class AgileCrm : IAgileCrm
    {
        /// <summary>
        /// The companies service.
        /// </summary>
        private readonly ICompaniesService companiesService;

        /// <summary>
        /// The contact notes service.
        /// </summary>
        private readonly IContactNotesService contactNotesService;

        /// <summary>
        /// The contacts service.
        /// </summary>
        private readonly IContactsService contactsService;

        /// <summary>
        /// The contact notes service.
        /// </summary>
        private readonly IDealNotesService dealNotesService;

        /// <summary>
        /// The deals service.
        /// </summary>
        private readonly IDealsService dealsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AgileCrm" /> class.
        /// </summary>
        /// <param name="companiesService">The companies service.</param>
        /// <param name="contactsService">The contacts service.</param>
        /// <param name="dealsService">The deals service.</param>
        /// <param name="contactNotesService">The contact notes service.</param>
        /// <param name="dealNotesService">The deal notes service.</param>
        internal AgileCrm(
            ICompaniesService companiesService,
            IContactsService contactsService,
            IDealsService dealsService,
            IContactNotesService contactNotesService,
            IDealNotesService dealNotesService)
        {
            companiesService.EnsureNotNull();
            contactsService.EnsureNotNull();
            dealsService.EnsureNotNull();
            contactNotesService.EnsureNotNull();
            dealNotesService.EnsureNotNull();

            this.companiesService = companiesService;
            this.contactsService = contactsService;
            this.dealsService = dealsService;
            this.contactNotesService = contactNotesService;
            this.dealNotesService = dealNotesService;
        }

        /// <inheritdoc />
        public ICompaniesService Companies => this.companiesService;

        /// <inheritdoc />
        public IContactNotesService ContactNotes => this.contactNotesService;

        /// <inheritdoc />
        public IContactsService Contacts => this.contactsService;

        /// <inheritdoc />
        public IDealNotesService DealNotes => this.dealNotesService;

        /// <inheritdoc />
        public IDealsService Deals => this.dealsService;
    }
}