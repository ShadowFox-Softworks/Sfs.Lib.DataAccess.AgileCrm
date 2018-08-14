namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Processors
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Entity;
    using Entity.Internal.Responses;
    using Helpers;
    using Interface.Internal;
    using Interface.Internal.Processors;
    using JetBrains.Annotations;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    /// <inheritdoc />
    internal sealed class SearchProcessor : ISearchProcessor
    {
        /// <summary>
        /// The class name
        /// </summary>
        private const string ClassName = nameof(SearchProcessor);

        /// <summary>
        /// The HTTP client
        /// </summary>
        private readonly IHttpClient httpClient;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchProcessor"/> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <exception cref="ArgumentNullException">
        /// loggerFactory
        /// or
        /// httpClient
        /// </exception>
        public SearchProcessor(
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] IHttpClient httpClient)
        {
            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            if (httpClient == null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }

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

            var uri = $"dev/api/contacts/search/email/{emailAddress}";

            try
            {
                var httpResponseMessage = await this.httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

                HttpCodeHelper.Check(httpResponseMessage.StatusCode, ClassName);

                var httpContentString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                var contactResponseEntity = JsonConvert.DeserializeObject<ContactResponseEntity>(httpContentString);

                contactId = contactResponseEntity.Id;
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
            CancellationToken cancellationToken,
            AgileCrmDealFilter dealFilter = default(AgileCrmDealFilter))
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
        }

        /// <inheritdoc />
        public async Task<string> GetTrackIdAsync(
            string trackName,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.GetTrackIdAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // TODO: GetTrackIdAsync implementation
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }
    }
}