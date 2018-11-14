namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Processors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Deals;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal;
    using Osw.Lib.DataAccess.AgileCrm.Interfaces.Internal;
    using Osw.Lib.DataAccess.AgileCrm.Interfaces.Internal.Processors;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Resolvers.Requests;

    /// <inheritdoc />
    internal sealed class DealProcessor : IDealsProcessor
    {
        /// <summary>
        /// The class name.
        /// </summary>
        private const string ClassName = nameof(DealProcessor);

        /// <summary>
        /// The media type.
        /// </summary>
        private const string MediaType = "application/json";

        /// <summary>
        /// The encoding type.
        /// </summary>
        private static readonly Encoding EncodingType = Encoding.UTF8;

        /// <summary>
        /// The serializer settings.
        /// </summary>
        private static readonly JsonSerializerSettings SerializerSettings =
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        /// <summary>
        /// The HTTP client.
        /// </summary>
        private readonly IHttpClient httpClient;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DealProcessor" /> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public DealProcessor(
            ILoggerFactory loggerFactory,
            IHttpClient httpClient)
        {
            NullGuard.EnsureNotNull(loggerFactory, nameof(loggerFactory));
            NullGuard.EnsureNotNull(httpClient, nameof(httpClient));

            this.logger = loggerFactory.CreateLogger<AgileCrmClient>();
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task CreateDealAsync(
            string emailAddress,
            AgileCrmClientDealEntity agileCrmClientDealEntity,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.CreateDealAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                var validationContext = new ValidationContext(agileCrmClientDealEntity);

                Validator.ValidateObject(agileCrmClientDealEntity, validationContext, true);

                var agileCrmServerDealEntity = agileCrmClientDealEntity.ToServerEntity();

                var serializedEntity = JsonConvert.SerializeObject(agileCrmServerDealEntity, SerializerSettings);

                var uri = $"opportunity/email/{emailAddress}";

                var stringContent = new StringContent(serializedEntity, EncodingType, MediaType);

                var httpResponseMessage = await this.httpClient.PostAsync(uri, stringContent, cancellationToken).ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                ResponseAnalyzer.Analyze(ProcessorType.Deal, httpResponseMessage.StatusCode);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("AgileCRM : Deal created successfully.");
            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task DeleteDealAsync(
            string dealId,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.DeleteDealAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                var uri = $"opportunity/{dealId}";

                var httpResponseMessage = await this.httpClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                ResponseAnalyzer.Analyze(ProcessorType.Deal, httpResponseMessage.StatusCode);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("AgileCRM : Deal deleted successfully.");
            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<List<AgileCrmServerDealEntity>> GetDealsAsync(
            string emailAddress,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.GetDealsAsync);
            this.logger.MethodStart(ClassName, MethodName);

            var agileCrmServerDealEntities = default(List<AgileCrmServerDealEntity>);
            try
            {
                var uri = $"contacts/search/email/{emailAddress}";

                var httpResponseMessage = await this.httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                ResponseAnalyzer.Analyze(ProcessorType.Deal, httpResponseMessage.StatusCode);

                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                var contactId = JsonConvert.DeserializeAnonymousType(httpContentAsString, new { id = default(string) });

                uri = $"contacts/{contactId.id}/deals";

                httpResponseMessage = await this.httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                ResponseAnalyzer.Analyze(ProcessorType.Deal, httpResponseMessage.StatusCode);

                httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                agileCrmServerDealEntities = JsonConvert.DeserializeObject<List<AgileCrmServerDealEntity>>(httpContentAsString);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("AgileCRM : Deals retrieved successfully.");
            this.logger.MethodEnd(ClassName, MethodName);

            return agileCrmServerDealEntities;
        }

        /// <inheritdoc />
        public async Task UpdateDealAsync(
            string dealId,
            AgileCrmClientDealEntity agileCrmClientDealEntity,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.UpdateDealAsync);
            this.logger.MethodStart(ClassName, MethodName);

            const string Uri = "opportunity/partial-update";
            try
            {
                var validationContext = new ValidationContext(agileCrmClientDealEntity);

                Validator.ValidateObject(agileCrmClientDealEntity, validationContext, true);

                var agileCrmServerDealEntity = agileCrmClientDealEntity.ToServerEntity();

                agileCrmServerDealEntity.Id = dealId;

                var serializedEntity = JsonConvert.SerializeObject(agileCrmServerDealEntity, SerializerSettings);

                var stringContent = new StringContent(serializedEntity, EncodingType, MediaType);

                var httpResponseMessage = await this.httpClient.PutAsync(Uri, stringContent, cancellationToken).ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                ResponseAnalyzer.Analyze(ProcessorType.Deal, httpResponseMessage.StatusCode);
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