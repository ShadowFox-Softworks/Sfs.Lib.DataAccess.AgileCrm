namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Osw.Lib.DataAccess.AgileCrm.Entities;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal;
    using Osw.Lib.DataAccess.AgileCrm.Interface.Internal;
    using Osw.Lib.DataAccess.AgileCrm.Interface.Internal.Processors;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Resolvers.Requests;

    /// <inheritdoc />
    internal sealed class DealProcessor : IDealProcessor
    {
        /// <summary>
        /// The class name
        /// </summary>
        private const string ClassName = nameof(DealProcessor);

        /// <summary>
        /// The media type
        /// </summary>
        private const string MediaType = "application/json";

        /// <summary>
        /// The encoding type
        /// </summary>
        private static readonly Encoding EncodingType = Encoding.UTF8;

        /// <summary>
        /// The serializer settings
        /// </summary>
        private static readonly JsonSerializerSettings SerializerSettings =
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        /// <summary>
        /// The HTTP client
        /// </summary>
        private readonly IHttpClient httpClient;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The search processor
        /// </summary>
        private readonly ISearchProcessor searchProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="DealProcessor"/> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="searchProcessor">The search processor.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public DealProcessor(
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] ISearchProcessor searchProcessor,
            [NotNull] IHttpClient httpClient)
        {
            NullGuard.EnsureNotNull(loggerFactory, nameof(loggerFactory));
            NullGuard.EnsureNotNull(searchProcessor, nameof(searchProcessor));
            NullGuard.EnsureNotNull(httpClient, nameof(httpClient));

            this.logger = loggerFactory.CreateLogger<AgileCrmClient>();
            this.searchProcessor = searchProcessor;
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task CreateDealAsync(
            string emailAddress,
            AgileCrmDealEntity dealEntity,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.CreateDealAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                var dealRequestEntity = dealEntity.ResolveToCrmRequest();

                var serializedRequest = JsonConvert.SerializeObject(dealRequestEntity, SerializerSettings);

                var uri = $"opportunity/email/{emailAddress}";

                var stringContent = new StringContent(serializedRequest, EncodingType, MediaType);

                var httpResponseMessage = await this.httpClient.PostAsync(
                    uri, stringContent, cancellationToken).ConfigureAwait(false);

                ResponseAnalyzer.Analyse(ProcessorType.Deal, httpResponseMessage.StatusCode);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("Deal created in AgileCRM successfully");
            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task DeleteDealAsync(
            string emailAddress,
            CancellationToken cancellationToken,
            string dealId = default(string))
        {
            const string MethodName = nameof(this.DeleteDealAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // TODO: DeleteDealAsync implementation
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("Deal deleted from AgileCRM successfully");
            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<List<AgileCrmDealEntity>> GetAllDealsAsync(
            string emailAddress,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.GetAllDealsAsync);
            this.logger.MethodStart(ClassName, MethodName);

            var dealResponseEntities = default(List<AgileCrmDealEntity>);
            try
            {
                var contactId = await this.searchProcessor.GetContactIdAsync(
                    emailAddress, cancellationToken).ConfigureAwait(false);

                var uri = $"contacts/{contactId}/deals";

                var httpResponseMessage = await this.httpClient.GetAsync(
                    uri, cancellationToken).ConfigureAwait(false);

                ResponseAnalyzer.Analyse(ProcessorType.Deal, httpResponseMessage.StatusCode);

                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                dealResponseEntities = JsonConvert.DeserializeObject<List<AgileCrmDealEntity>>(httpContentAsString);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("All deals retrieved from AgileCRM successfully");
            this.logger.MethodEnd(ClassName, MethodName);

            return dealResponseEntities;
        }

        /// <inheritdoc />
        public async Task<AgileCrmDealEntity> GetDealAsync(
            string emailAddress,
            CancellationToken cancellationToken,
            string dealId = default(string))
        {
            const string MethodName = nameof(this.GetDealAsync);
            this.logger.MethodStart(ClassName, MethodName);

            var dealResponseEntities = default(List<AgileCrmDealEntity>);
            try
            {
                var contactId = await this.searchProcessor.GetContactIdAsync(
                    emailAddress, cancellationToken).ConfigureAwait(false);

                var uri = $"contacts/{contactId}/deals";

                var httpResponseMessage = await this.httpClient.GetAsync(
                    uri, cancellationToken).ConfigureAwait(false);

                ResponseAnalyzer.Analyse(ProcessorType.Deal, httpResponseMessage.StatusCode);

                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                dealResponseEntities = JsonConvert.DeserializeObject<List<AgileCrmDealEntity>>(httpContentAsString);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("Deal retrieved from AgileCRM successfully");
            this.logger.MethodEnd(ClassName, MethodName);

            return dealResponseEntities[0];
        }

        /// <inheritdoc />
        public async Task UpdateDealAsync(
            string emailAddress,
            AgileCrmDealEntity dealEntity,
            CancellationToken cancellationToken,
            string dealId = default(string))
        {
            const string MethodName = nameof(this.UpdateDealAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // TODO: UpdateDealAsync implementation
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("Deal updated in AgileCRM successfully");
            this.logger.MethodEnd(ClassName, MethodName);
        }
    }
}