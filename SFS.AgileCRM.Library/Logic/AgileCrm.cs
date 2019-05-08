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
        /// The contacts service.
        /// </summary>
        private readonly IContactsService contactsService;

        /// <summary>
        /// The deals service.
        /// </summary>
        private readonly IDealsService dealsService;

        /// <summary>
        /// The notes service.
        /// </summary>
        private readonly INotesService notesService;

        /// <summary>
        /// The tasks service.
        /// </summary>
        private readonly ITasksService tasksService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AgileCrm" /> class.
        /// </summary>
        /// <param name="companiesService">The companies service.</param>
        /// <param name="contactsService">The contacts service.</param>
        /// <param name="dealsService">The deals service.</param>
        /// <param name="notesService">The notes service.</param>
        /// <param name="tasksService">The tasks service.</param>
        internal AgileCrm(
            ICompaniesService companiesService,
            IContactsService contactsService,
            IDealsService dealsService,
            INotesService notesService,
            ITasksService tasksService)
        {
            companiesService.EnsureNotNull();
            contactsService.EnsureNotNull();
            dealsService.EnsureNotNull();
            notesService.EnsureNotNull();
            tasksService.EnsureNotNull();

            this.companiesService = companiesService;
            this.contactsService = contactsService;
            this.dealsService = dealsService;
            this.notesService = notesService;
            this.tasksService = tasksService;
        }

        /// <inheritdoc />
        public ICompaniesService Companies => this.companiesService;

        /// <inheritdoc />
        public IContactsService Contacts => this.contactsService;

        /// <inheritdoc />
        public IDealsService Deals => this.dealsService;

        /// <inheritdoc />
        public INotesService Notes => this.notesService;

        /// <inheritdoc />
        public ITasksService Tasks => this.tasksService;
    }
}