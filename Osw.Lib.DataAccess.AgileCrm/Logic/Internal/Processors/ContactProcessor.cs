namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Processors
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Entity;
    using Entity.Internal.Responses;
    using Helpers;
    using Interface.Internal;
    using Interface.Internal.Processors;
    using JetBrains.Annotations;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Resolvers.Requests;
    using Resolvers.Responses;

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
        /// Initializes a new instance of the <see cref="ContactProcessor"/> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="searchProcessor">The search processor.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <exception cref="ArgumentNullException">
        /// loggerFactory
        /// or
        /// searchProcessor
        /// or
        /// httpClient
        /// </exception>
        public ContactProcessor(
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] ISearchProcessor searchProcessor,
            [NotNull] IHttpClient httpClient)
        {
            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            if (searchProcessor == null)
            {
                throw new ArgumentNullException(nameof(searchProcessor));
            }

            if (httpClient == null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }

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

            const string Uri = "dev/api/contacts";

            try
            {
                var contactRequestEntity = contactEntity.ResolveToCrmRequest();

                var serializedRequest = JsonConvert.SerializeObject(contactRequestEntity, SerializerSettings);

                var stringContent = new StringContent(serializedRequest, EncodingType, MediaType);

                var httpResponseMessage = await this.httpClient.PostAsync(
                    Uri, stringContent, cancellationToken).ConfigureAwait(false);

                HttpCodeHelper.Check(httpResponseMessage.StatusCode, ClassName);
            }
            catch (Exception e)
            {
                this.logger.LogException(e, ClassName, MethodName);
                throw;
            }

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

                var uri = $"dev/api/contacts/{contactId}";

                var httpResponseMessage = await this.httpClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);

                HttpCodeHelper.Check(httpResponseMessage.StatusCode, ClassName, HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                this.logger.LogException(e, ClassName, MethodName);
                throw;
            }

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

                var uri = $"/dev/api/contacts/{contactId}";

                var httpResponseMessage = await this.httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

                HttpCodeHelper.Check(httpResponseMessage.StatusCode, ClassName);

                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                var contactResponseEntity = JsonConvert.DeserializeObject<ContactResponseEntity>(httpContentAsString);

                agileCrmContactEntity = contactResponseEntity.ResolveFromCrmResponse();
            }
            catch (Exception e)
            {
                this.logger.LogException(e, ClassName, MethodName);
                throw;
            }

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

            const string Uri = "dev/api/contacts/edit-properties";

            try
            {
                var contactRequestEntity = contactEntity.ResolveToCrmRequest();

                var contactId = await this.searchProcessor.GetContactIdAsync(emailAddress, cancellationToken)
                    .ConfigureAwait(false);

                contactRequestEntity.Id = contactId;

                var serializedRequest = JsonConvert.SerializeObject(contactRequestEntity, SerializerSettings);

                var stringContent = new StringContent(serializedRequest, EncodingType, MediaType);

                var httpResponseMessage = await this.httpClient.PutAsync(Uri, stringContent, cancellationToken).ConfigureAwait(false);

                HttpCodeHelper.Check(httpResponseMessage.StatusCode, ClassName);
            }
            catch (Exception e)
            {
                this.logger.LogException(e, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }
    }
}