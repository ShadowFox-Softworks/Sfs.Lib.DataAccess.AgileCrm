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
    /// The Deal Notes Service.
    /// </summary>
    /// <seealso cref="SFS.AgileCRM.Library.Interfaces.Services.IDealNotesService" />
    internal class DealNotesService : IDealNotesService
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
        /// Initializes a new instance of the <see cref="DealNotesService" /> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="logger">The logger.</param>
        public DealNotesService(
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
        public async Task CreateAsync(long dealId, AgileCrmNoteRequest agileCrmNoteModel)
        {
            const string MethodName = nameof(this.CreateAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var noteId = default(long);
            try
            {
                // Validate argument object
                agileCrmNoteModel.ValidateModel();

                // Serialize object to JSON
                var dealNoteEntityBase = agileCrmNoteModel.ToDealNoteEntityBase();

                dealNoteEntityBase.DealId = new List<string> { dealId.ToString() };

                var stringContent = dealNoteEntityBase.ToStringContent();

                // Send JSON to server
                const string Uri = "opportunity/deals/notes";

                var httpResponseMessage = await this.httpClient.PostAsync(Uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                httpResponseMessage.EnsureSuccessStatusCode();

                // Retrieve identifier for logging
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                noteId = JsonConvert.DeserializeAnonymousType(httpContentAsString, new { id = default(long) }).id;
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
        public async Task DeleteAllAsync(long dealId)
        {
            const string MethodName = nameof(this.DeleteAllAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var noteId = default(long);
            try
            {
                // Create object
                var dealIdEntity = new { id = dealId };

                // Serialize object to JSON
                var stringContent = dealIdEntity.ToStringContent();

                // Send JSON to server
                const string Uri = "contacts/notes/bulk";

                var httpResponseMessage = await this.httpClient.PostAsync(Uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                httpResponseMessage.EnsureSuccessStatusCode();

                // Retrieve identifier for logging
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                noteId = JsonConvert.DeserializeAnonymousType(httpContentAsString, new { id = default(long) }).id;
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
        public async Task<IList<AgileCrmDealNoteEntity>> GetAllAsync(long dealId)
        {
            const string MethodName = nameof(this.GetAllAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var agileCrmDealNoteEntities = default(IList<AgileCrmDealNoteEntity>);
            try
            {
                // Send request to server
                var uri = $"opportunity/{dealId}/notes";

                var httpResponseMessage = await this.httpClient.GetAsync(uri).ConfigureAwait(false);

                // Analyze server response for errors
                httpResponseMessage.EnsureSuccessStatusCode();

                // Return data retrieved from server
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                agileCrmDealNoteEntities = httpContentAsString.DeserializeJson<List<AgileCrmDealNoteEntity>>();
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            foreach (var agileCrmDealNoteEntity in agileCrmDealNoteEntities)
            {
                this.logger.LogRetrieved(ServiceType.Note, agileCrmDealNoteEntity.Id);
            }

            this.logger.LogMethodEnd(ClassName, MethodName);

            return agileCrmDealNoteEntities;
        }
    }
}