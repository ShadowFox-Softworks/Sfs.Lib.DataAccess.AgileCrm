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
    using SFS.AgileCRM.Library.Entities.Contacts;
    using SFS.AgileCRM.Library.Entities.Internal;
    using SFS.AgileCRM.Library.Interfaces.Internal;
    using SFS.AgileCRM.Library.Interfaces.Services;
    using SFS.AgileCRM.Library.Logic.Internal.Helpers;
    using SFS.AgileCRM.Library.Logic.Internal.Mappers;

    /// <summary>
    /// The Contacts Service.
    /// </summary>
    /// <seealso cref="SFS.AgileCRM.Library.Interfaces.Services.IContactsService" />
    internal sealed class ContactsService : IContactsService
    {
        /// <summary>
        /// The class name.
        /// </summary>
        private const string ClassName = nameof(ContactsService);

        /// <summary>
        /// The HTTP client.
        /// </summary>
        private readonly IHttpClient httpClient;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactsService" /> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public ContactsService(
            ILoggerFactory loggerFactory,
            IHttpClient httpClient)
        {
            loggerFactory.EnsureNotNull();
            httpClient.EnsureNotNull();

            this.logger = loggerFactory.CreateLogger<AgileCrm>();
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task CreateAsync(AgileCrmContactModel agileCrmContactModel)
        {
            const string MethodName = nameof(this.CreateAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var contactId = default(string);
            try
            {
                // Validate argument entity
                var validationContext = new ValidationContext(agileCrmContactModel);

                Validator.ValidateObject(agileCrmContactModel, validationContext, true);

                // Prepare entity for transmission
                var agileCrmContactEntity = agileCrmContactModel.ToContactEntity();

                const string Uri = "contacts";

                var serializedEntity = JsonConvert.SerializeObject(agileCrmContactEntity, ImplementationFields.SerializerSettings);

                var stringContent = new StringContent(serializedEntity, ImplementationFields.EncodingType, ImplementationFields.MediaType);

                // Send prepared entity to server
                var httpResponseMessage = await this.httpClient.PostAsync(Uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Contacts, httpResponseMessage.StatusCode);

                // Retrieve identifier for logging
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                contactId = JsonConvert.DeserializeAnonymousType(httpContentAsString, new { id = default(string) }).id;
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogCreated($"Contact ({contactId})");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(long contactId)
        {
            const string MethodName = nameof(this.DeleteAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                // Send request to server
                var uri = $"contacts/{contactId}";

                var httpResponseMessage = await this.httpClient.DeleteAsync(uri).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Contacts, httpResponseMessage.StatusCode, HttpStatusCode.NoContent);
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogDeleted($"Contact ({contactId})");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<AgileCrmContactEntity> GetAsync(string emailAddress)
        {
            const string MethodName = nameof(this.GetAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var agileCrmContactEntity = default(AgileCrmContactEntity);
            try
            {
                // Send request to server
                var uri = $"contacts/search/email/{emailAddress}";

                var httpResponseMessage = await this.httpClient.GetAsync(uri).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Contacts, httpResponseMessage.StatusCode);

                // Return data retrieved from server
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                var httpContentAsJObject = JObject.Parse(httpContentAsString);

                var agileCrmServerPropertyBaseEntities = httpContentAsJObject.ToPropertiesCollection();

                httpContentAsJObject.Remove("properties");

                agileCrmContactEntity = JsonConvert.DeserializeObject<AgileCrmContactEntity>(httpContentAsJObject.ToString());

                agileCrmContactEntity.Properties = agileCrmServerPropertyBaseEntities;
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogRetrieved($"Contact ({agileCrmContactEntity.Id})");
            this.logger.LogMethodEnd(ClassName, MethodName);

            return agileCrmContactEntity;
        }

        /// <inheritdoc />
        public async Task UpdateAsync(long contactId, AgileCrmContactModel agileCrmContactModel)
        {
            const string MethodName = nameof(this.UpdateAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                // Validate argument entity
                var validationContext = new ValidationContext(agileCrmContactModel);

                Validator.ValidateObject(agileCrmContactModel, validationContext, true);

                // Prepare entity for transmission
                var agileCrmContactEntity = agileCrmContactModel.ToContactEntity();

                agileCrmContactEntity.Id = contactId;

                const string Uri = "contacts/edit-properties";

                var serializedEntity = JsonConvert.SerializeObject(agileCrmContactEntity, ImplementationFields.SerializerSettings);

                var stringContent = new StringContent(serializedEntity, ImplementationFields.EncodingType, ImplementationFields.MediaType);

                // Send prepared entity to server
                var httpResponseMessage = await this.httpClient.PutAsync(Uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Contacts, httpResponseMessage.StatusCode);
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogUpdated($"Contact ({contactId})");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }
    }
}