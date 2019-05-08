namespace SFS.AgileCRM.Library.Logic.Internal.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json.Linq;
    using SFS.AgileCRM.Library.Data.Requests;
    using SFS.AgileCRM.Library.Data.Responses;
    using SFS.AgileCRM.Library.Data.Static.Internal;
    using SFS.AgileCRM.Library.Interfaces.Internal;
    using SFS.AgileCRM.Library.Interfaces.Services;
    using SFS.AgileCRM.Library.Logic.Internal.Helpers;
    using SFS.AgileCRM.Library.Logic.Internal.Mappers;

    /// <summary>
    /// The Companies Service.
    /// </summary>
    /// <seealso cref="SFS.AgileCRM.Library.Interfaces.Services.ICompaniesService" />
    internal sealed class CompaniesService : ICompaniesService
    {
        /// <summary>
        /// The class name.
        /// </summary>
        private const string ClassName = nameof(CompaniesService);

        /// <summary>
        /// The HTTP client.
        /// </summary>
        private readonly IHttpClient httpClient;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompaniesService" /> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="logger">The logger.</param>
        public CompaniesService(
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
        public async Task CreateAsync(AgileCrmCompanyRequest agileCrmCompanyModel)
        {
            const string MethodName = nameof(this.CreateAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var companyId = default(long);
            try
            {
                // Validate argument object
                agileCrmCompanyModel.ValidateModel();

                // Serialize object to JSON
                var companyEntityBase = agileCrmCompanyModel.ToCompanyEntityBase();

                var stringContent = companyEntityBase.ToStringContent();

                // Send JSON to server
                const string Uri = "contacts";

                var httpResponseMessage = await this.httpClient.PostAsync(Uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                httpResponseMessage.EnsureSuccessStatusCode();

                // Retrieve identifier for logging
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                companyId = httpContentAsString.DeserializeJson(new { id = default(long) }).id;
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogCreated(ServiceType.Company, companyId);
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(long companyId)
        {
            const string MethodName = nameof(this.DeleteAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                // Send request to server
                var uri = $"contacts/{companyId}";

                var httpResponseMessage = await this.httpClient.DeleteAsync(uri).ConfigureAwait(false);

                // Analyze server response for errors
                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogDeleted(ServiceType.Company, companyId);
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<AgileCrmCompanyEntity> GetAsync(long companyId)
        {
            const string MethodName = nameof(this.GetAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var agileCrmServerCompanyEntity = default(AgileCrmCompanyEntity);
            try
            {
                // Send request to server
                var uri = $"contacts/{companyId}";

                var httpResponseMessage = await this.httpClient.GetAsync(uri).ConfigureAwait(false);

                // Analyze server response for errors
                httpResponseMessage.EnsureSuccessStatusCode();

                // Return data retrieved from server
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                var httpContentAsJObject = JObject.Parse(httpContentAsString);

                var agileCrmServerPropertyBases = httpContentAsJObject.ToPropertiesCollection();

                httpContentAsJObject.Remove("properties");

                agileCrmServerCompanyEntity = httpContentAsJObject.ToString().DeserializeJson<AgileCrmCompanyEntity>();

                agileCrmServerCompanyEntity.Properties = agileCrmServerPropertyBases;
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogRetrieved(ServiceType.Company, companyId);
            this.logger.LogMethodEnd(ClassName, MethodName);

            return agileCrmServerCompanyEntity;
        }

        /// <inheritdoc />
        public async Task UpdateAsync(long companyId, AgileCrmCompanyRequest agileCrmCompanyModel)
        {
            const string MethodName = nameof(this.UpdateAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                // Validate argument object
                agileCrmCompanyModel.ValidateModel();

                // Serialize object to JSON
                var companyEntityBase = agileCrmCompanyModel.ToCompanyEntityBase();

                companyEntityBase.Id = companyId;

                var stringContent = companyEntityBase.ToStringContent();

                // Send JSON to server
                const string Uri = "contacts/edit-properties";

                var httpResponseMessage = await this.httpClient.PutAsync(Uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogUpdated(ServiceType.Company, companyId);
            this.logger.LogMethodEnd(ClassName, MethodName);
        }
    }
}