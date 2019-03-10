namespace SFS.AgileCRM.Library
{
    using System;
    using Microsoft.Extensions.Logging;
    using SFS.AgileCRM.Library.Entities;
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
        /// The local logger factory.
        /// </summary>
        private static ILoggerFactory localLoggerFactory;

        /// <summary>
        /// Creates a new instance of AgileCRM.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="agileCrmConfiguration">The AgileCRM configuration.</param>
        /// <returns>
        ///   <see cref="IAgileCrm"/>.
        /// </returns>
        public static IAgileCrm Create(
            ILoggerFactory loggerFactory,
            AgileCrmConfiguration agileCrmConfiguration)
        {
            loggerFactory.EnsureNotNull();
            agileCrmConfiguration.EnsureNotNull();

            if (localLoggerFactory == null)
            {
                localLoggerFactory = loggerFactory;
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
                localLoggerFactory,
                localAgileCrmConfiguration);

            var companiesService = new CompaniesService(
                localLoggerFactory,
                httpClient);

            var contactsService = new ContactsService(
                localLoggerFactory,
                httpClient);

            var dealsService = new DealsService(
                localLoggerFactory,
                httpClient);

            var contactNotesService = new ContactNotesService(
                localLoggerFactory,
                httpClient);

            var dealNotesService = new DealNotesService(
                localLoggerFactory,
                httpClient);

            var agileCrm = new AgileCrm(
                companiesService,
                contactsService,
                dealsService,
                contactNotesService,
                dealNotesService);

            return agileCrm;
        }
    }
}