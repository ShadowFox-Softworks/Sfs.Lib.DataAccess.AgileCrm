namespace Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Processors
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Companies;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Internal;
    using Sfs.Lib.DataAccess.AgileCrm.Interfaces.Internal;
    using Sfs.Lib.DataAccess.AgileCrm.Interfaces.Internal.Processors;
    using Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;
    using Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Mappers;

    /// <inheritdoc />
    /// <seealso cref="Sfs.Lib.DataAccess.AgileCrm.Interfaces.Internal.Processors.ICompaniesProcessor" />
    internal sealed class CompaniesProcessor : ICompaniesProcessor
    {
        /// <summary>
        /// The class name.
        /// </summary>
        private const string ClassName = nameof(ContactsProcessor);

        /// <summary>
        /// The HTTP client.
        /// </summary>
        private readonly IHttpClient httpClient;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompaniesProcessor"/> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public CompaniesProcessor(
            ILoggerFactory loggerFactory,
            IHttpClient httpClient)
        {
            loggerFactory.EnsureNotNull();
            httpClient.EnsureNotNull();

            this.logger = loggerFactory.CreateLogger<AgileCrmClient>();
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task CreateCompanyAsync(
            AgileCrmClientCompanyEntity agileCrmClientCompanyEntity,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.CreateCompanyAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var companyId = default(string);
            try
            {
                // Validate argument entity
                var validationContext = new ValidationContext(agileCrmClientCompanyEntity);

                Validator.ValidateObject(agileCrmClientCompanyEntity, validationContext, true);

                // Prepare entity for transmission
                var agileCrmServerCompanyEntity = agileCrmClientCompanyEntity.ToServerCompanyEntity();

                const string Uri = "contacts";

                var serializedEntity = JsonConvert.SerializeObject(agileCrmServerCompanyEntity, ProcessorFields.SerializerSettings);

                var stringContent = new StringContent(serializedEntity, ProcessorFields.EncodingType, ProcessorFields.MediaType);

                // Send prepared entity to server
                var httpResponseMessage = await this.httpClient.PostAsync(Uri, stringContent, cancellationToken).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Companies, httpResponseMessage.StatusCode);

                // Retrieve identifier for logging
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                companyId = JsonConvert.DeserializeAnonymousType(httpContentAsString, new { id = default(string) }).id;
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug($"AgileCRM : Company ({companyId}) created successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task DeleteConpanyAsync(
            long companyId,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.DeleteConpanyAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                // Send request to server
                var uri = $"contacts/{companyId}";

                var httpResponseMessage = await this.httpClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Companies, httpResponseMessage.StatusCode, HttpStatusCode.NoContent);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug($"AgileCRM : Company ({companyId}) deleted successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<AgileCrmServerCompanyEntity> GetCompanyAsync(
            long companyId,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.GetCompanyAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var agileCrmServerCompanyEntity = default(AgileCrmServerCompanyEntity);
            try
            {
                // Send request to server
                var uri = $"contacts/{companyId}";

                var httpResponseMessage = await this.httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Companies, httpResponseMessage.StatusCode);

                // Return data retrieved from server
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                var httpContentAsJObject = JObject.Parse(httpContentAsString);

                var agileCrmServerPropertyBases = httpContentAsJObject.ToPropertiesCollection();

                httpContentAsJObject.Remove("properties");

                agileCrmServerCompanyEntity = JsonConvert.DeserializeObject<AgileCrmServerCompanyEntity>(httpContentAsJObject.ToString());

                agileCrmServerCompanyEntity.Properties = agileCrmServerPropertyBases;
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug($"AgileCRM : Company ({companyId}) retrieved successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);

            return agileCrmServerCompanyEntity;
        }

        /// <inheritdoc />
        public async Task UpdateCompanyAsync(
            long companyId,
            AgileCrmClientCompanyEntity agileCrmClientCompanyEntity,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.UpdateCompanyAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                // Validate argument entity
                var validationContext = new ValidationContext(agileCrmClientCompanyEntity);

                Validator.ValidateObject(agileCrmClientCompanyEntity, validationContext, true);

                // Prepare entity for transmission
                var agileCrmServerCompanyEntity = agileCrmClientCompanyEntity.ToServerCompanyEntity();

                agileCrmServerCompanyEntity.Id = companyId;

                const string Uri = "contacts/edit-properties";

                var serializedEntity = JsonConvert.SerializeObject(agileCrmServerCompanyEntity, ProcessorFields.SerializerSettings);

                var stringContent = new StringContent(serializedEntity, ProcessorFields.EncodingType, ProcessorFields.MediaType);

                // Send prepared entity to server
                var httpResponseMessage = await this.httpClient.PutAsync(Uri, stringContent, cancellationToken).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Companies, httpResponseMessage.StatusCode);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug($"AgileCRM : Company ({companyId}) updated successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }
    }
}