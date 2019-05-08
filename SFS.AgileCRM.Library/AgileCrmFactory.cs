namespace SFS.AgileCRM.Library
{
    using System;
    using Microsoft.Extensions.Logging;
    using SFS.AgileCRM.Library.Data.Configurations;
    using SFS.AgileCRM.Library.Interface;
    using SFS.AgileCRM.Library.Logic;
    using SFS.AgileCRM.Library.Logic.Internal;
    using SFS.AgileCRM.Library.Logic.Internal.Helpers;
    using SFS.AgileCRM.Library.Logic.Internal.Services;

    /// <summary>
    /// The AgileCRM Factory.
    /// </summary>
    public static class AgileCrmFactory
    {
        /// <summary>
        /// The lazy.
        /// </summary>
        private static readonly Lazy<IAgileCrm> Lazy = new Lazy<IAgileCrm>(Initialize);

        /// <summary>
        /// The local AgileCRM configuration.
        /// </summary>
        private static AgileCrmConfiguration localAgileCrmConfiguration;

        /// <summary>
        /// The local logger.
        /// </summary>
        private static ILogger localLogger;

        /// <summary>
        /// Creates a new instance of AgileCRM.
        /// </summary>
        /// <param name="agileCrmConfiguration">The AgileCRM configuration.</param>
        /// <param name="loggerFactory">[Optional] The logger factory.</param>
        /// <returns>
        ///   <see cref="IAgileCrm" />.
        /// </returns>
        public static IAgileCrm Create(
            AgileCrmConfiguration agileCrmConfiguration,
            ILoggerFactory loggerFactory = null)
        {
            loggerFactory.EnsureNotNull();
            agileCrmConfiguration.EnsureNotNull();

            if (localLogger == null)
            {
                localLogger = loggerFactory.CreateLogger<AgileCrm>();
            }

            if (localAgileCrmConfiguration == null)
            {
                localAgileCrmConfiguration = agileCrmConfiguration;
            }

            return Lazy.Value;
        }

        /// <summary>
        /// Initializes a new instance of AgileCrm.
        /// </summary>
        /// <returns>
        ///   <see cref="IAgileCrm" />.
        /// </returns>
        private static IAgileCrm Initialize()
        {
            var httpClient = new HttpClientWrapper(
                localAgileCrmConfiguration);

            var companiesService = new CompaniesService(
                httpClient,
                localLogger);

            var contactsService = new ContactsService(
                httpClient,
                localLogger);

            var dealsService = new DealsService(
                httpClient,
                localLogger);

            var contactNotesService = new ContactNotesService(
                httpClient,
                localLogger);

            var dealNotesService = new DealNotesService(
                httpClient,
                localLogger);

            var notesService = new NotesService(
                contactNotesService,
                dealNotesService);

            var tasksService = new TasksService(
                httpClient,
                localLogger);

            var agileCrm = new AgileCrm(
                companiesService,
                contactsService,
                dealsService,
                notesService,
                tasksService);

            return agileCrm;
        }
    }
}