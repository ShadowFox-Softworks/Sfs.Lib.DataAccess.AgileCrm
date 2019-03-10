namespace SFS.AgileCRM.Library.Logic.Internal.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using SFS.AgileCRM.Library.Entities.Deals;
    using SFS.AgileCRM.Library.Entities.Internal;
    using SFS.AgileCRM.Library.Interfaces.Internal;
    using SFS.AgileCRM.Library.Interfaces.Services;
    using SFS.AgileCRM.Library.Logic.Internal.Helpers;
    using SFS.AgileCRM.Library.Logic.Internal.Mappers;

    /// <summary>
    /// The Deals Service.
    /// </summary>
    /// <seealso cref="SFS.AgileCRM.Library.Interfaces.Services.IDealsService" />
    internal sealed class DealsService : IDealsService
    {
        /// <summary>
        /// The class name.
        /// </summary>
        private const string ClassName = nameof(DealsService);

        /// <summary>
        /// The HTTP client.
        /// </summary>
        private readonly IHttpClient httpClient;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DealsService" /> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public DealsService(
            ILoggerFactory loggerFactory,
            IHttpClient httpClient)
        {
            loggerFactory.EnsureNotNull();
            httpClient.EnsureNotNull();

            this.logger = loggerFactory.CreateLogger<AgileCrm>();
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task CreateAsync(string emailAddress, AgileCrmDealModel agileCrmDealModel)
        {
            const string MethodName = nameof(this.CreateAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var dealId = default(string);
            try
            {
                // Validate argument entity
                var validationContext = new ValidationContext(agileCrmDealModel);

                Validator.ValidateObject(agileCrmDealModel, validationContext, true);

                // Prepare entity for transmission
                var agileCrmDealEntity = agileCrmDealModel.ToDealEntity();

                var serializedEntity = JsonConvert.SerializeObject(agileCrmDealEntity, ImplementationFields.SerializerSettings);

                var uri = $"opportunity/email/{emailAddress}";

                var stringContent = new StringContent(serializedEntity, ImplementationFields.EncodingType, ImplementationFields.MediaType);

                // Send prepared entity to server
                var httpResponseMessage = await this.httpClient.PostAsync(uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Deals, httpResponseMessage.StatusCode);

                // Retrieve identifier for logging
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                dealId = JsonConvert.DeserializeAnonymousType(httpContentAsString, new { id = default(string) }).id;
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogCreated($"Deal ({dealId})");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(long dealId)
        {
            const string MethodName = nameof(this.DeleteAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                // Send request to server
                var uri = $"opportunity/{dealId}";

                var httpResponseMessage = await this.httpClient.DeleteAsync(uri).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Deals, httpResponseMessage.StatusCode);
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogDeleted($"Deal ({dealId})");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<IList<AgileCrmDealEntity>> GetAllAsync(string emailAddress)
        {
            const string MethodName = nameof(this.GetAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var agileCrmDealEntities = default(List<AgileCrmDealEntity>);
            try
            {
                // Send request to server
                var uri = $"contacts/search/email/{emailAddress}";

                var httpResponseMessage = await this.httpClient.GetAsync(uri).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Deals, httpResponseMessage.StatusCode);

                // Return data retrieved from server
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                var contactId = JsonConvert.DeserializeAnonymousType(httpContentAsString, new { id = default(string) });

                uri = $"contacts/{contactId.id}/deals";

                httpResponseMessage = await this.httpClient.GetAsync(uri).ConfigureAwait(false);

                ResponseAnalyzer.Analyze(ProcessorType.Deals, httpResponseMessage.StatusCode);

                httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                agileCrmDealEntities = JsonConvert.DeserializeObject<List<AgileCrmDealEntity>>(httpContentAsString);
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            foreach (var agileCrmDealEntity in agileCrmDealEntities)
            {
                this.logger.LogRetrieved($"Deal ({agileCrmDealEntity.Id})");
            }

            this.logger.LogMethodEnd(ClassName, MethodName);

            return agileCrmDealEntities;
        }

        /// <inheritdoc />
        public async Task UpdateAsync(long dealId, AgileCrmDealModel agileCrmDealModel)
        {
            const string MethodName = nameof(this.UpdateAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                // Validate argument entity
                var validationContext = new ValidationContext(agileCrmDealModel);

                Validator.ValidateObject(agileCrmDealModel, validationContext, true);

                // Prepare entity for transmission
                var agileCrmDealEntity = agileCrmDealModel.ToDealEntity();

                agileCrmDealEntity.Id = dealId;

                const string Uri = "opportunity/partial-update";

                var serializedEntity = JsonConvert.SerializeObject(agileCrmDealEntity, ImplementationFields.SerializerSettings);

                var stringContent = new StringContent(serializedEntity, ImplementationFields.EncodingType, ImplementationFields.MediaType);

                // Send prepared entity to server
                var httpResponseMessage = await this.httpClient.PutAsync(Uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Deals, httpResponseMessage.StatusCode);
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogUpdated($"Deal ({dealId})");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }
    }
}