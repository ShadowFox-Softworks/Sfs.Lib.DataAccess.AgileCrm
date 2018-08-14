namespace Osw.Lib.DataAccess.AgileCrm
{
    using System;
    using Entity;
    using Interface;
    using JetBrains.Annotations;
    using Logic;
    using Logic.Internal;
    using Logic.Internal.Processors;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The AgileCRM Client Factory
    /// </summary>
    public static class AgileCrmClientFactory
    {
        /// <summary>
        /// The lazy
        /// </summary>
        private static readonly Lazy<IAgileCrmClient> Lazy = new Lazy<IAgileCrmClient>(Initialize);

        /// <summary>
        /// The local agile CRM configuration
        /// </summary>
        private static AgileCrmConfiguration localAgileCrmConfiguration;

        /// <summary>
        /// The local logger factory
        /// </summary>
        private static ILoggerFactory localLoggerFactory;

        /// <summary>
        /// Creates the specified logger factory.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="agileCrmConfiguration">The agile CRM configuration.</param>
        /// <returns>
        ///   <see cref="IAgileCrmClient"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// loggerFactory
        /// or
        /// agileCrmConfiguration
        /// </exception>
        public static IAgileCrmClient Create(
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] AgileCrmConfiguration agileCrmConfiguration)
        {
            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            if (agileCrmConfiguration == null)
            {
                throw new ArgumentNullException(nameof(agileCrmConfiguration));
            }

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
        ///   <see cref="IAgileCrmClient" />
        /// </returns>
        private static IAgileCrmClient Initialize()
        {
            var httpClientWrapper = new HttpClientWrapper(
                localLoggerFactory,
                localAgileCrmConfiguration);

            var searchProcessor = new SearchProcessor(
                localLoggerFactory,
                httpClientWrapper);

            var contactProcessor = new ContactProcessor(
                localLoggerFactory,
                searchProcessor,
                httpClientWrapper);

            var dealProcessor = new DealProcessor(
                localLoggerFactory,
                searchProcessor,
                httpClientWrapper);

            return new AgileCrmClient(
                contactProcessor,
                dealProcessor);
        }
    }
}