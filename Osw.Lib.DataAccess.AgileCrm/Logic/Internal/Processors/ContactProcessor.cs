namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Processors
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Osw.Lib.DataAccess.AgileCrm.Entities;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal.Responses;
    using Osw.Lib.DataAccess.AgileCrm.Interface.Internal;
    using Osw.Lib.DataAccess.AgileCrm.Interface.Internal.Processors;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Resolvers.Requests;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Resolvers.Responses;

    /// <inheritdoc />
    internal sealed class ContactProcessor : IContactProcessor
    {
        /// <summary>
        /// The class name
        /// </summary>
        private const string ClassName = nameof(ContactProcessor);

        /// <summary>
        /// The media type
        /// </summary>
        private const string MediaType = "application/json";

        /// <summary>
        /// The encoding type
        /// </summary>
        private static readonly Encoding EncodingType = Encoding.UTF8;

        /// <summary>
        /// The serializer settings
        /// </summary>
        private static readonly JsonSerializerSettings SerializerSettings =
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        /// <summary>
        /// The HTTP client
        /// </summary>
        private readonly IHttpClient httpClient;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The search processor
        /// </summary>
        private readonly ISearchProcessor searchProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactProcessor" /> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="searchProcessor">The search processor.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public ContactProcessor(
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] ISearchProcessor searchProcessor,
            [NotNull] IHttpClient httpClient)
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
            AgileCrmContactEntity contactEntity,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.CreateContactAsync);
            this.logger.MethodStart(ClassName, MethodName);

            const string Uri = "contacts";
            try
            {
                var contactRequestEntity = contactEntity.ResolveToCrmRequest();

                var serializedRequest = JsonConvert.SerializeObject(contactRequestEntity, SerializerSettings);

                var stringContent = new StringContent(serializedRequest, EncodingType, MediaType);

                var httpResponseMessage = await this.httpClient.PostAsync(
                    Uri, stringContent, cancellationToken).ConfigureAwait(false);

                ResponseAnalyzer.Analyse(ProcessorType.Contact, httpResponseMessage.StatusCode);
            }
            catch (Exception e)
            {
                this.logger.LogException(e, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("Contact created in AgileCRM successfully");
            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task DeleteContactAsync(
            string emailAddress,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.UpdateContactAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                var contactId = await this.searchProcessor.GetContactIdAsync(emailAddress, cancellationToken)
                    .ConfigureAwait(false);

                var uri = $"contacts/{contactId}";

                var httpResponseMessage = await this.httpClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);

                ResponseAnalyzer.Analyse(ProcessorType.Contact, httpResponseMessage.StatusCode, HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                this.logger.LogException(e, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("Contact deleted from AgileCRM successfully");
            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<AgileCrmContactEntity> GetContactAsync(
            string emailAddress,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.UpdateContactAsync);
            this.logger.MethodStart(ClassName, MethodName);

            AgileCrmContactEntity agileCrmContactEntity;
            try
            {
                var contactId = await this.searchProcessor.GetContactIdAsync(emailAddress, cancellationToken)
                    .ConfigureAwait(false);

                var uri = $"contacts/{contactId}";

                var httpResponseMessage = await this.httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

                ResponseAnalyzer.Analyse(ProcessorType.Contact, httpResponseMessage.StatusCode);

                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                var contactResponseEntity = JsonConvert.DeserializeObject<ContactResponseEntity>(httpContentAsString);

                agileCrmContactEntity = contactResponseEntity.ResolveFromCrmResponse();
            }
            catch (Exception e)
            {
                this.logger.LogException(e, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("Contact retrieved from AgileCRM successfully");
            this.logger.MethodEnd(ClassName, MethodName);

            return agileCrmContactEntity;
        }

        /// <inheritdoc />
        public async Task UpdateContactAsync(
            string emailAddress,
            AgileCrmContactEntity contactEntity,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.UpdateContactAsync);
            this.logger.MethodStart(ClassName, MethodName);

            const string Uri = "contacts/edit-properties";
            try
            {
                var contactRequestEntity = contactEntity.ResolveToCrmRequest();

                var contactId = await this.searchProcessor.GetContactIdAsync(emailAddress, cancellationToken)
                    .ConfigureAwait(false);

                contactRequestEntity.Id = contactId;

                var serializedRequest = JsonConvert.SerializeObject(contactRequestEntity, SerializerSettings);

                var stringContent = new StringContent(serializedRequest, EncodingType, MediaType);

                var httpResponseMessage = await this.httpClient.PutAsync(Uri, stringContent, cancellationToken).ConfigureAwait(false);

                ResponseAnalyzer.Analyse(ProcessorType.Contact, httpResponseMessage.StatusCode);
            }
            catch (Exception e)
            {
                this.logger.LogException(e, ClassName, MethodName);
                throw;
            }

            this.logger.LogInformation("Contact updated in AgileCRM successfully");
            this.logger.MethodEnd(ClassName, MethodName);
        }
    }
}