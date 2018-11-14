namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Processors
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Contacts;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal;
    using Osw.Lib.DataAccess.AgileCrm.Interfaces.Internal;
    using Osw.Lib.DataAccess.AgileCrm.Interfaces.Internal.Processors;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Translators;

    /// <inheritdoc />
    internal sealed class ContactProcessor : IContactsProcessor
    {
        /// <summary>
        /// The class name.
        /// </summary>
        private const string ClassName = nameof(ContactProcessor);

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
        /// The search processor.
        /// </summary>
        private readonly ISearchProcessor searchProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactProcessor" /> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="searchProcessor">The search processor.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public ContactProcessor(
            ILoggerFactory loggerFactory,
            ISearchProcessor searchProcessor,
            IHttpClient httpClient)
        {
            NullGuard.EnsureNotNull(loggerFactory, nameof(loggerFactory));
            NullGuard.EnsureNotNull(searchProcessor, nameof(searchProcessor));
            NullGuard.EnsureNotNull(httpClient, nameof(httpClient));

            this.logger = loggerFactory.CreateLogger<AgileCrmClient>();
            this.searchProcessor = searchProcessor;
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task CreateContactAsync(
            AgileCrmClientContactEntity agileCrmClientContactEntity,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.CreateContactAsync);
            this.logger.MethodStart(ClassName, MethodName);

            const string Uri = "contacts";
            try
            {
                var validationContext = new ValidationContext(agileCrmClientContactEntity);

                Validator.ValidateObject(agileCrmClientContactEntity, validationContext, true);

                var agileCrmServerContactEntity = agileCrmClientContactEntity.ToServerEntity();

                var serializedEntity = JsonConvert.SerializeObject(agileCrmServerContactEntity, SerializerSettings);

                var stringContent = new StringContent(serializedEntity, EncodingType, MediaType);

                var httpResponseMessage = await this.httpClient.PostAsync(Uri, stringContent, cancellationToken).ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                ResponseAnalyzer.Analyze(ProcessorType.Contact, httpResponseMessage.StatusCode);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("AgileCRM : Contact created successfully.");
            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task DeleteContactAsync(
            string contactId,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.UpdateContactAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                var uri = $"contacts/{contactId}";

                var httpResponseMessage = await this.httpClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                ResponseAnalyzer.Analyze(ProcessorType.Contact, httpResponseMessage.StatusCode, HttpStatusCode.NoContent);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("AgileCRM : Contact deleted successfully.");
            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<AgileCrmServerContactEntity> GetContactAsync(
            string emailAddress,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.UpdateContactAsync);
            this.logger.MethodStart(ClassName, MethodName);

            var agileCrmServerContactEntity = default(AgileCrmServerContactEntity);
            try
            {
                var uri = $"contacts/search/email/{emailAddress}";

                var httpResponseMessage = await this.httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                ResponseAnalyzer.Analyze(ProcessorType.Contact, httpResponseMessage.StatusCode);

                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                agileCrmServerContactEntity = JsonConvert.DeserializeObject<AgileCrmServerContactEntity>(httpContentAsString);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("AgileCRM : Contact retrieved successfully.");
            this.logger.MethodEnd(ClassName, MethodName);

            return agileCrmServerContactEntity;
        }

        /// <inheritdoc />
        public async Task UpdateContactAsync(
            string contactId,
            AgileCrmClientContactEntity agileCrmClientContactEntity,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.UpdateContactAsync);
            this.logger.MethodStart(ClassName, MethodName);

            const string Uri = "contacts/edit-properties";
            try
            {
                var validationContext = new ValidationContext(agileCrmClientContactEntity);

                Validator.ValidateObject(agileCrmClientContactEntity, validationContext, true);

                var agileCrmServerContactEntity = agileCrmClientContactEntity.ToServerEntity();

                agileCrmServerContactEntity.Id = contactId;

                var serializedEntity = JsonConvert.SerializeObject(agileCrmServerContactEntity, SerializerSettings);

                var stringContent = new StringContent(serializedEntity, EncodingType, MediaType);

                var httpResponseMessage = await this.httpClient.PutAsync(Uri, stringContent, cancellationToken).ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                ResponseAnalyzer.Analyze(ProcessorType.Contact, httpResponseMessage.StatusCode);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("AgileCRM : Contact updated successfully.");
            this.logger.MethodEnd(ClassName, MethodName);
        }
    }
}