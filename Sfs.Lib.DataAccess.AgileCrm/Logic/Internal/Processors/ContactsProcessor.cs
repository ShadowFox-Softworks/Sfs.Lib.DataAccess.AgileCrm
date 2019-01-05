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
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Contacts;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Internal;
    using Sfs.Lib.DataAccess.AgileCrm.Interfaces.Internal;
    using Sfs.Lib.DataAccess.AgileCrm.Interfaces.Internal.Processors;
    using Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;
    using Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Mappers;

    /// <inheritdoc />
    internal sealed class ContactsProcessor : IContactsProcessor
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
        /// Initializes a new instance of the <see cref="ContactsProcessor" /> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public ContactsProcessor(
            ILoggerFactory loggerFactory,
            IHttpClient httpClient)
        {
            loggerFactory.EnsureNotNull();
            httpClient.EnsureNotNull();

            this.logger = loggerFactory.CreateLogger<AgileCrmClient>();
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task CreateContactAsync(
            AgileCrmClientContactEntity agileCrmClientContactEntity,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.CreateContactAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var contactId = default(string);
            try
            {
                // Validate argument entity
                var validationContext = new ValidationContext(agileCrmClientContactEntity);

                Validator.ValidateObject(agileCrmClientContactEntity, validationContext, true);

                var agileCrmServerContactEntity = agileCrmClientContactEntity.ToServerContactEntity();

                // Prepare entity for transmission
                const string Uri = "contacts";

                var serializedEntity = JsonConvert.SerializeObject(agileCrmServerContactEntity, ProcessorFields.SerializerSettings);

                var stringContent = new StringContent(serializedEntity, ProcessorFields.EncodingType, ProcessorFields.MediaType);

                // Send entity to server
                var httpResponseMessage = await this.httpClient.PostAsync(Uri, stringContent, cancellationToken).ConfigureAwait(false);

                // Analyze response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Contacts, httpResponseMessage.StatusCode);

                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                contactId = JsonConvert.DeserializeAnonymousType(httpContentAsString, new { id = default(string) }).id;
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug($"AgileCRM : Contact ({contactId}) created successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task DeleteContactAsync(
            long contactId,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.DeleteContactAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                // Send request to server
                var uri = $"contacts/{contactId}";

                var httpResponseMessage = await this.httpClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);

                // Analyze response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Contacts, httpResponseMessage.StatusCode, HttpStatusCode.NoContent);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug($"AgileCRM : Contact ({contactId}) deleted successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<AgileCrmServerContactEntity> GetContactAsync(
            string emailAddress,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.GetContactAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var contactId = default(string);
            var agileCrmServerContactEntity = default(AgileCrmServerContactEntity);
            try
            {
                // Send request to server
                var uri = $"contacts/search/email/{emailAddress}";

                var httpResponseMessage = await this.httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

                // Analyze response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Contacts, httpResponseMessage.StatusCode);

                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                contactId = JsonConvert.DeserializeAnonymousType(httpContentAsString, new { id = default(string) }).id;

                var httpContentAsJObject = JObject.Parse(httpContentAsString);

                var agileCrmServerPropertyBases = httpContentAsJObject.ToPropertiesCollection();

                httpContentAsJObject.Remove("properties");

                agileCrmServerContactEntity = JsonConvert.DeserializeObject<AgileCrmServerContactEntity>(httpContentAsJObject.ToString());

                agileCrmServerContactEntity.Properties = agileCrmServerPropertyBases;
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug($"AgileCRM : Contact ({contactId}) retrieved successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);

            return agileCrmServerContactEntity;
        }

        /// <inheritdoc />
        public async Task UpdateContactAsync(
            long contactId,
            AgileCrmClientContactEntity agileCrmClientContactEntity,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.UpdateContactAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                // Validate argument entity
                var validationContext = new ValidationContext(agileCrmClientContactEntity);

                Validator.ValidateObject(agileCrmClientContactEntity, validationContext, true);

                var agileCrmServerContactEntity = agileCrmClientContactEntity.ToServerContactEntity();

                // Prepare entity for transmission
                agileCrmServerContactEntity.Id = contactId;

                const string Uri = "contacts/edit-properties";

                var serializedEntity = JsonConvert.SerializeObject(agileCrmServerContactEntity, ProcessorFields.SerializerSettings);

                var stringContent = new StringContent(serializedEntity, ProcessorFields.EncodingType, ProcessorFields.MediaType);

                // Send entity to server
                var httpResponseMessage = await this.httpClient.PutAsync(Uri, stringContent, cancellationToken).ConfigureAwait(false);

                // Analyze response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Contacts, httpResponseMessage.StatusCode);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug($"AgileCRM : Contact ({contactId}) updated successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }
    }
}