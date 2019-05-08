namespace SFS.AgileCRM.Library.Logic.Internal.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using SFS.AgileCRM.Library.Data.Requests;
    using SFS.AgileCRM.Library.Data.Responses;
    using SFS.AgileCRM.Library.Data.Static.Internal;
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
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="logger">The logger.</param>
        public DealsService(
            IHttpClient httpClient,
            ILogger logger)
        {
            httpClient.EnsureNotNull();

            this.httpClient = httpClient;

            if (logger != null)
            {
                this.logger = logger;
            }
        }

        /// <inheritdoc />
        public async Task CreateAsync(string emailAddress, AgileCrmDealRequest agileCrmDealModel)
        {
            const string MethodName = nameof(this.CreateAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var dealId = default(long);
            try
            {
                // Validate argument object
                agileCrmDealModel.ValidateModel();

                // Serialize object to JSON
                var dealEntityBase = agileCrmDealModel.ToDealEntityBase();

                var stringContent = dealEntityBase.ToStringContent();

                // Send JSON to server
                var uri = $"opportunity/email/{emailAddress}";

                var httpResponseMessage = await this.httpClient.PostAsync(uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                httpResponseMessage.EnsureSuccessStatusCode();

                // Retrieve identifier for logging
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                dealId = httpContentAsString.DeserializeJson(new { id = default(long) }).id;
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogCreated(ServiceType.Deal, dealId);
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
                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogDeleted(ServiceType.Deal, dealId);
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<IList<AgileCrmDealEntity>> GetAllAsync(long contactId)
        {
            const string MethodName = nameof(this.GetAllAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var agileCrmDealEntities = default(List<AgileCrmDealEntity>);
            try
            {
                // Send request to server
                var uri = $"contacts/{contactId}/deals";

                var httpResponseMessage = await this.httpClient.GetAsync(uri).ConfigureAwait(false);

                // Analyze server response for errors
                httpResponseMessage.EnsureSuccessStatusCode();

                // Return data retrieved from server
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                agileCrmDealEntities = httpContentAsString.DeserializeJson<List<AgileCrmDealEntity>>();
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            foreach (var agileCrmDealEntity in agileCrmDealEntities)
            {
                this.logger.LogRetrieved(ServiceType.Deal, agileCrmDealEntity.Id);
            }

            this.logger.LogMethodEnd(ClassName, MethodName);

            return agileCrmDealEntities;
        }

        /// <inheritdoc />
        public async Task UpdateAsync(long dealId, AgileCrmDealRequest agileCrmDealModel)
        {
            const string MethodName = nameof(this.UpdateAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                // Validate argument object
                agileCrmDealModel.ValidateModel();

                // Serialize object to JSON
                var dealEntityBase = agileCrmDealModel.ToDealEntityBase();

                dealEntityBase.Id = dealId;

                var stringContent = dealEntityBase.ToStringContent();

                // Send JSON to server
                const string Uri = "opportunity/partial-update";

                var httpResponseMessage = await this.httpClient.PutAsync(Uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogUpdated(ServiceType.Deal, dealId);
            this.logger.LogMethodEnd(ClassName, MethodName);
        }
    }
}