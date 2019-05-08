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
    /// The Notes Service.
    /// </summary>
    /// <seealso cref="SFS.AgileCRM.Library.Interfaces.Services.IContactNotesService" />
    internal class ContactNotesService : IContactNotesService
    {
        /// <summary>
        /// The class name.
        /// </summary>
        private const string ClassName = nameof(DealNotesService);

        /// <summary>
        /// The HTTP client.
        /// </summary>
        private readonly IHttpClient httpClient;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactNotesService" /> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="logger">The logger.</param>
        public ContactNotesService(
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
        public async Task CreateAsync(long contactId, AgileCrmNoteRequest agileCrmNoteModel)
        {
            const string MethodName = nameof(this.CreateAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var noteId = default(long);
            try
            {
                // Validate argument object
                agileCrmNoteModel.ValidateModel();

                // Serialize object to JSON
                var contactNoteEntityBase = agileCrmNoteModel.ToContactNoteEntityBase();

                contactNoteEntityBase.ContactId = new List<string> { contactId.ToString() };

                var stringContent = contactNoteEntityBase.ToStringContent();

                // Send JSON to server
                const string Uri = "notes";

                var httpResponseMessage = await this.httpClient.PostAsync(Uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                httpResponseMessage.EnsureSuccessStatusCode();

                // Retrieve identifier for logging
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                noteId = httpContentAsString.DeserializeJson(new { id = default(long) }).id;
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogCreated(ServiceType.Note, noteId);
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task DeleteAllAsync(long contactId)
        {
            const string MethodName = nameof(this.DeleteAllAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var noteId = default(long);
            try
            {
                // Create object
                var contactIdEntity = new { id = contactId };

                // Serialize object to JSON
                var stringContent = contactIdEntity.ToStringContent();

                // Send JSON to server
                const string Uri = "contacts/notes/bulk";

                var httpResponseMessage = await this.httpClient.PostAsync(Uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                httpResponseMessage.EnsureSuccessStatusCode();

                // Retrieve identifier for logging
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                noteId = httpContentAsString.DeserializeJson(new { id = default(long) }).id;
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogDeleted(ServiceType.Note, noteId);
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<IList<AgileCrmContactNoteEntity>> GetAllAsync(long contactId)
        {
            const string MethodName = nameof(this.GetAllAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var agileCrmContactNoteEntities = default(IList<AgileCrmContactNoteEntity>);
            try
            {
                // Send request to server
                var uri = $"contacts/{contactId}/notes";

                var httpResponseMessage = await this.httpClient.GetAsync(uri).ConfigureAwait(false);

                // Analyze server response for errors
                httpResponseMessage.EnsureSuccessStatusCode();

                // Return data retrieved from server
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                agileCrmContactNoteEntities = httpContentAsString.DeserializeJson<List<AgileCrmContactNoteEntity>>();
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            foreach (var agileCrmContactNoteEntity in agileCrmContactNoteEntities)
            {
                this.logger.LogRetrieved(ServiceType.Note, agileCrmContactNoteEntity.Id);
            }

            this.logger.LogMethodEnd(ClassName, MethodName);

            return agileCrmContactNoteEntities;
        }
    }
}