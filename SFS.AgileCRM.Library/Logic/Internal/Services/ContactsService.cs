namespace SFS.AgileCRM.Library.Logic.Internal.Services
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using SFS.AgileCRM.Library.Data.Requests;
    using SFS.AgileCRM.Library.Data.Responses;
    using SFS.AgileCRM.Library.Data.Static.Internal;
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
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="logger">The logger.</param>
        public ContactsService(
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
        public async Task CreateAsync(AgileCrmContactRequest agileCrmContactModel)
        {
            const string MethodName = nameof(this.CreateAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var contactId = default(long);
            try
            {
                // Validate argument object
                agileCrmContactModel.ValidateModel();

                // Serialize object to JSON
                var contactEntityBase = agileCrmContactModel.ToContactEntityBase();

                var stringContent = contactEntityBase.ToStringContent();

                // Send JSON to server
                const string Uri = "contacts";

                var httpResponseMessage = await this.httpClient.PostAsync(Uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                httpResponseMessage.EnsureSuccessStatusCode();

                // Retrieve identifier for logging
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                contactId = JsonConvert.DeserializeAnonymousType(httpContentAsString, new { id = default(long) }).id;
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogCreated(ServiceType.Contact, contactId);
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
                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogDeleted(ServiceType.Contact, contactId);
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
                httpResponseMessage.EnsureSuccessStatusCode();

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

            this.logger.LogRetrieved(ServiceType.Contact, agileCrmContactEntity.Id);
            this.logger.LogMethodEnd(ClassName, MethodName);

            return agileCrmContactEntity;
        }

        /// <inheritdoc />
        public async Task UpdateAsync(long contactId, AgileCrmContactRequest agileCrmContactModel)
        {
            const string MethodName = nameof(this.UpdateAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                // Validate argument object
                agileCrmContactModel.ValidateModel();

                // Serialize object to JSON
                var contactEntityBase = agileCrmContactModel.ToContactEntityBase();

                contactEntityBase.Id = contactId;

                var stringContent = contactEntityBase.ToStringContent();

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

            this.logger.LogUpdated(ServiceType.Contact, contactId);
            this.logger.LogMethodEnd(ClassName, MethodName);
        }
    }
}