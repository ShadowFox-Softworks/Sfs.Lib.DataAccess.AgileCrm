namespace Sfs.Lib.DataAccess.AgileCrm
{
    using System;
    using Microsoft.Extensions.Logging;
    using Sfs.Lib.DataAccess.AgileCrm.Entities;
    using Sfs.Lib.DataAccess.AgileCrm.Interface;
    using Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;

    /// <summary>
    /// The AgileCRM Client Factory.
    /// </summary>
    public static class AgileCrmClientFactory
    {
        /// <summary>
        /// The lazy.
        /// </summary>
        private static readonly Lazy<IAgileCrmClient> Lazy = new Lazy<IAgileCrmClient>(Initialize);

        /// <summary>
        /// The local agile CRM configuration.
        /// </summary>
        private static AgileCrmConfiguration localAgileCrmConfiguration;

        /// <summary>
        /// The local logger factory.
        /// </summary>
        private static ILoggerFactory localLoggerFactory;

        /// <summary>
        /// Creates the specified logger factory.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="agileCrmConfiguration">The agile CRM configuration.</param>
        /// <returns>
        ///   <see cref="IAgileCrmClient"/>.
        /// </returns>
        public static IAgileCrmClient Create(
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
        /// Initializes this instance.
        /// </summary>
        /// <returns>
        ///   <see cref="IAgileCrmClient" />.
        /// </returns>
        private static IAgileCrmClient Initialize()
        {
            // TODO: Initialize client factory (NOTE: Maybe instantiate processors independently)
        }
    }
}