namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Processors
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Contacts;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal;
    using Osw.Lib.DataAccess.AgileCrm.Interfaces.Internal;
    using Osw.Lib.DataAccess.AgileCrm.Interfaces.Internal.Processors;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;

    /// <inheritdoc />
    internal sealed class SearchProcessor : ISearchProcessor
    {
        /// <summary>
        /// The class name.
        /// </summary>
        private const string ClassName = nameof(SearchProcessor);

        /// <summary>
        /// The HTTP client.
        /// </summary>
        private readonly IHttpClient httpClient;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchProcessor"/> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public SearchProcessor(
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] IHttpClient httpClient)
        {
            NullGuard.EnsureNotNull(loggerFactory, nameof(loggerFactory));
            NullGuard.EnsureNotNull(httpClient, nameof(httpClient));

            this.logger = loggerFactory.CreateLogger<SearchProcessor>();
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task<string> GetContactIdAsync(
            string emailAddress,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.GetContactIdAsync);
            this.logger.MethodStart(ClassName, MethodName);

            var contactId = default(string);
            try
            {
                var uri = $"contacts/search/email/{emailAddress}";

                var httpResponseMessage = await this.httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                ResponseAnalyzer.Analyze(ProcessorType.Search, httpResponseMessage.StatusCode);

                var httpContentString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                var agileCrmServerContactEntity = JsonConvert.DeserializeObject<AgileCrmServerContactEntity>(httpContentString);

                contactId = agileCrmServerContactEntity.Id;
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);

            return contactId;
        }

        /// <inheritdoc />
        public async Task<string> GetDealIdAsync(
            string emailAddress,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.GetDealIdAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // TODO: GetDealIdAsync implementation
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);

            return dealId;
        }
    }
}