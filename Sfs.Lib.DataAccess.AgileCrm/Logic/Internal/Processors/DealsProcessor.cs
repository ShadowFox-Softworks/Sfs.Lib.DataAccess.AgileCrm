namespace Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Processors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Deals;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Internal;
    using Sfs.Lib.DataAccess.AgileCrm.Interfaces.Internal;
    using Sfs.Lib.DataAccess.AgileCrm.Interfaces.Internal.Processors;
    using Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;
    using Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Mappers;

    /// <inheritdoc />
    internal sealed class DealsProcessor : IDealsProcessor
    {
        /// <summary>
        /// The class name.
        /// </summary>
        private const string ClassName = nameof(DealsProcessor);

        /// <summary>
        /// The HTTP client.
        /// </summary>
        private readonly IHttpClient httpClient;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DealsProcessor" /> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public DealsProcessor(
            ILoggerFactory loggerFactory,
            IHttpClient httpClient)
        {
            loggerFactory.EnsureNotNull();
            httpClient.EnsureNotNull();

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
            this.logger.LogMethodStart(ClassName, MethodName);

            var dealId = default(string);
            try
            {
                var validationContext = new ValidationContext(agileCrmClientDealEntity);

                Validator.ValidateObject(agileCrmClientDealEntity, validationContext, true);

                var agileCrmServerDealEntity = agileCrmClientDealEntity.ToServerDealEntity();

                var serializedEntity = JsonConvert.SerializeObject(agileCrmServerDealEntity, ProcessorFields.SerializerSettings);

                var uri = $"opportunity/email/{emailAddress}";

                var stringContent = new StringContent(serializedEntity, ProcessorFields.EncodingType, ProcessorFields.MediaType);

                var httpResponseMessage = await this.httpClient.PostAsync(uri, stringContent, cancellationToken).ConfigureAwait(false);

                ResponseAnalyzer.Analyze(ProcessorType.Deals, httpResponseMessage.StatusCode);

                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                dealId = JsonConvert.DeserializeAnonymousType(httpContentAsString, new { id = default(string) }).id;
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug($"AgileCRM : Deal ({dealId}) created successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task DeleteDealAsync(
            long dealId,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.DeleteDealAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                var uri = $"opportunity/{dealId}";

                var httpResponseMessage = await this.httpClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);

                ResponseAnalyzer.Analyze(ProcessorType.Deals, httpResponseMessage.StatusCode);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug($"AgileCRM : Deal ({dealId}) deleted successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<List<AgileCrmServerDealEntity>> GetDealsAsync(
            string emailAddress,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.GetDealsAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var agileCrmServerDealEntities = default(List<AgileCrmServerDealEntity>);
            try
            {
                var uri = $"contacts/search/email/{emailAddress}";

                var httpResponseMessage = await this.httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

                ResponseAnalyzer.Analyze(ProcessorType.Deals, httpResponseMessage.StatusCode);

                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                var contactId = JsonConvert.DeserializeAnonymousType(httpContentAsString, new { id = default(string) });

                uri = $"contacts/{contactId.id}/deals";

                httpResponseMessage = await this.httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

                ResponseAnalyzer.Analyze(ProcessorType.Deals, httpResponseMessage.StatusCode);

                httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                agileCrmServerDealEntities = JsonConvert.DeserializeObject<List<AgileCrmServerDealEntity>>(httpContentAsString);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug($"AgileCRM : Deal (multiple) retrieved successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);

            return agileCrmServerDealEntities;
        }

        /// <inheritdoc />
        public async Task UpdateDealAsync(
            long dealId,
            AgileCrmClientDealEntity agileCrmClientDealEntity,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.UpdateDealAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                var validationContext = new ValidationContext(agileCrmClientDealEntity);

                Validator.ValidateObject(agileCrmClientDealEntity, validationContext, true);

                var agileCrmServerDealEntity = agileCrmClientDealEntity.ToServerDealEntity();

                agileCrmServerDealEntity.Id = dealId;

                const string Uri = "opportunity/partial-update";

                var serializedEntity = JsonConvert.SerializeObject(agileCrmServerDealEntity, ProcessorFields.SerializerSettings);

                var stringContent = new StringContent(serializedEntity, ProcessorFields.EncodingType, ProcessorFields.MediaType);

                var httpResponseMessage = await this.httpClient.PutAsync(Uri, stringContent, cancellationToken).ConfigureAwait(false);

                ResponseAnalyzer.Analyze(ProcessorType.Deals, httpResponseMessage.StatusCode);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug($"AgileCRM : Deal ({dealId}) updated successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }
    }
}