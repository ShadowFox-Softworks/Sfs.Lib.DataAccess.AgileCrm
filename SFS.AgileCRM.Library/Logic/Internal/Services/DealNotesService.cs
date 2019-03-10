namespace SFS.AgileCRM.Library.Logic.Internal.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using SFS.AgileCRM.Library.Entities.Internal;
    using SFS.AgileCRM.Library.Entities.Notes;
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
        /// Initializes a new instance of the <see cref="DealNotesService"/> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public DealNotesService(
            ILoggerFactory loggerFactory,
            IHttpClient httpClient)
        {
            loggerFactory.EnsureNotNull();
            httpClient.EnsureNotNull();

            this.logger = loggerFactory.CreateLogger<AgileCrm>();
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task CreateAsync(long dealId, AgileCrmNoteModel agileCrmNoteModel)
        {
            const string MethodName = nameof(this.CreateAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            var noteId = default(string);
            try
            {
                // Validate argument entity
                var validationContext = new ValidationContext(agileCrmNoteModel);

                Validator.ValidateObject(agileCrmNoteModel, validationContext, true);

                // Prepare entity for transmission
                var agileCrmDealNoteEntity = agileCrmNoteModel.ToDealNoteEntity();

                agileCrmDealNoteEntity.DealId = new List<string> { dealId.ToString() };

                const string Uri = "opportunity/deals/notes";

                var serializedEntity = JsonConvert.SerializeObject(agileCrmDealNoteEntity, ImplementationFields.SerializerSettings);

                var stringContent = new StringContent(serializedEntity, ImplementationFields.EncodingType, ImplementationFields.MediaType);

                // Send prepared entity to server
                var httpResponseMessage = await this.httpClient.PostAsync(Uri, stringContent).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Notes, httpResponseMessage.StatusCode);

                // Retrieve identifier for logging
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                noteId = JsonConvert.DeserializeAnonymousType(httpContentAsString, new { id = default(string) }).id;
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            this.logger.LogCreated($"Deal note ({noteId})");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<IList<AgileCrmDealNoteEntity>> GetAllAsync(long dealId)
        {
            const string MethodName = nameof(this.GetAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            IList<AgileCrmDealNoteEntity> agileCrmDealNoteEntities;
            try
            {
                // Send request to server
                var uri = $"opportunity/{dealId}/notes";

                var httpResponseMessage = await this.httpClient.GetAsync(uri).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Notes, httpResponseMessage.StatusCode);

                // Return data retrieved from server
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                agileCrmDealNoteEntities = JsonConvert.DeserializeObject<List<AgileCrmDealNoteEntity>>(httpContentAsString, ImplementationFields.SerializerSettings);
            }
            catch (Exception exception)
            {
                this.logger.LogException(ClassName, MethodName, exception);
                throw;
            }

            foreach (var agileCrmDealNoteEntity in agileCrmDealNoteEntities)
            {
                this.logger.LogRetrieved($"Deal note ({agileCrmDealNoteEntity.Id})");
            }

            this.logger.LogMethodEnd(ClassName, MethodName);

            return agileCrmDealNoteEntities;
        }
    }
}