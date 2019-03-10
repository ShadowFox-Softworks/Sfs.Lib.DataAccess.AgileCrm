namespace SFS.AgileCRM.Library.Logic.Internal.Services
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using SFS.AgileCRM.Library.Entities.Companies;
    using SFS.AgileCRM.Library.Entities.Internal;
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
        /// Initializes a new instance of the <see cref="CompaniesService"/> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public CompaniesService(
            ILoggerFactory loggerFactory,
            IHttpClient httpClient)
        {
            loggerFactory.EnsureNotNull();
            httpClient.EnsureNotNull();

            this.logger = loggerFactory.CreateLogger<AgileCrm>();
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task CreateAsync(AgileCrmCompanyModel agileCrmCompanyModel)
        {
            const string MethodName = nameof(this.CreateAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var companyId = default(string);
            try
            {
                // Validate argument entity
                var validationContext = new ValidationContext(agileCrmCompanyModel);

                Validator.ValidateObject(agileCrmCompanyModel, validationContext, true);

                // Prepare entity for transmission
                var agileCrmCompanyEntity = agileCrmCompanyModel.ToCompanyEntity();

                const string Uri = "contacts";

                var serializedEntity = JsonConvert.SerializeObject(agileCrmCompanyEntity, ImplementationFields.SerializerSettings);

                var stringContent = new StringContent(serializedEntity, ImplementationFields.EncodingType, ImplementationFields.MediaType);

                // Send prepared entity to server
                var httpResponseMessage = await this.httpClient.PostAsync(Uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Companies, httpResponseMessage.StatusCode);

                // Retrieve identifier for logging
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                companyId = JsonConvert.DeserializeAnonymousType(httpContentAsString, new { id = default(string) }).id;
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogCreated($"Company ({companyId})");
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
                ResponseAnalyzer.Analyze(ProcessorType.Companies, httpResponseMessage.StatusCode, HttpStatusCode.NoContent);
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogDeleted($"Company ({companyId})");
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
                ResponseAnalyzer.Analyze(ProcessorType.Companies, httpResponseMessage.StatusCode);

                // Return data retrieved from server
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                var httpContentAsJObject = JObject.Parse(httpContentAsString);

                var agileCrmServerPropertyBases = httpContentAsJObject.ToPropertiesCollection();

                httpContentAsJObject.Remove("properties");

                agileCrmServerCompanyEntity = JsonConvert.DeserializeObject<AgileCrmCompanyEntity>(httpContentAsJObject.ToString());

                agileCrmServerCompanyEntity.Properties = agileCrmServerPropertyBases;
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogRetrieved($"Company ({companyId})");
            this.logger.LogMethodEnd(ClassName, MethodName);

            return agileCrmServerCompanyEntity;
        }

        /// <inheritdoc />
        public async Task UpdateAsync(long companyId, AgileCrmCompanyModel agileCrmCompanyModel)
        {
            const string MethodName = nameof(this.UpdateAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                // Validate argument entity
                var validationContext = new ValidationContext(agileCrmCompanyModel);

                Validator.ValidateObject(agileCrmCompanyModel, validationContext, true);

                // Prepare entity for transmission
                var agileCrmCompanyEntity = agileCrmCompanyModel.ToCompanyEntity();

                agileCrmCompanyEntity.Id = companyId;

                const string Uri = "contacts/edit-properties";

                var serializedEntity = JsonConvert.SerializeObject(agileCrmCompanyEntity, ImplementationFields.SerializerSettings);

                var stringContent = new StringContent(serializedEntity, ImplementationFields.EncodingType, ImplementationFields.MediaType);

                // Send prepared entity to server
                var httpResponseMessage = await this.httpClient.PutAsync(Uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Companies, httpResponseMessage.StatusCode);
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogUpdated($"Company ({companyId})");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }
    }
}