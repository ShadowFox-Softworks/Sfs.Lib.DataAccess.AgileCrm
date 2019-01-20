namespace Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Processors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Internal;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Notes;
    using Sfs.Lib.DataAccess.AgileCrm.Interfaces.Internal;
    using Sfs.Lib.DataAccess.AgileCrm.Interfaces.Internal.Processors;
    using Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;
    using Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Mappers;

    /// <inheritdoc />
    /// <seealso cref="Sfs.Lib.DataAccess.AgileCrm.Interfaces.Internal.Processors.INotesProcessor" />
    internal class NotesProcessor : INotesProcessor
    {
        /// <summary>
        /// The class name.
        /// </summary>
        private const string ClassName = nameof(NotesProcessor);

        /// <summary>
        /// The HTTP client.
        /// </summary>
        private readonly IHttpClient httpClient;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesProcessor"/> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public NotesProcessor(
            ILoggerFactory loggerFactory,
            IHttpClient httpClient)
        {
            loggerFactory.EnsureNotNull();
            httpClient.EnsureNotNull();

            this.logger = loggerFactory.CreateLogger<AgileCrmClient>();
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task CreateContactNoteAsync(
            long contactId,
            AgileCrmClientNoteEntity agileCrmClientNoteEntity,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.CreateContactNoteAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                // Validate argument entity
                var validationContext = new ValidationContext(agileCrmClientNoteEntity);

                Validator.ValidateObject(agileCrmClientNoteEntity, validationContext, true);

                // Prepare entity for transmission
                var agileCrmServerContactNoteEntity = agileCrmClientNoteEntity.ToServerContactNoteEntity();

                const string Uri = "notes";

                var serializedEntity = JsonConvert.SerializeObject(agileCrmServerContactNoteEntity, ProcessorFields.SerializerSettings);

                var stringContent = new StringContent(serializedEntity, ProcessorFields.EncodingType, ProcessorFields.MediaType);

                // Send prepared entity to server
                var httpResponseMessage = await this.httpClient.PostAsync(Uri, stringContent, cancellationToken).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Notes, httpResponseMessage.StatusCode);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug("AgileCRM : Contact note created successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task CreateDealNoteAsync(
            long dealId,
            AgileCrmClientNoteEntity agileCrmClientNoteEntity,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.CreateDealNoteAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            try
            {
                // Validate argument entity
                var validationContext = new ValidationContext(agileCrmClientNoteEntity);

                Validator.ValidateObject(agileCrmClientNoteEntity, validationContext, true);

                // Prepare entity for transmission
                var agileCrmServerDealNoteEntity = agileCrmClientNoteEntity.ToServerDealNoteEntity();

                const string Uri = "opportunity/deals/notes";

                var serializedEntity = JsonConvert.SerializeObject(agileCrmServerDealNoteEntity, ProcessorFields.SerializerSettings);

                var stringContent = new StringContent(serializedEntity, ProcessorFields.EncodingType, ProcessorFields.MediaType);

                // Send prepared entity to server
                var httpResponseMessage = await this.httpClient.PostAsync(Uri, stringContent, cancellationToken).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Notes, httpResponseMessage.StatusCode);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug("AgileCRM : Deal note created successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<IList<AgileCrmServerContactNoteEntity>> GetContactNotesAsync(
            long contactId,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.GetContactNotesAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            IList<AgileCrmServerContactNoteEntity> agileCrmServerContactNoteEntities;
            try
            {
                // Send request to server
                var uri = $"contacts/{contactId}/notes";

                var httpResponseMessage = await this.httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Notes, httpResponseMessage.StatusCode);

                // Return data retrieved from server
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                agileCrmServerContactNoteEntities = JsonConvert.DeserializeObject<List<AgileCrmServerContactNoteEntity>>(
                    httpContentAsString, ProcessorFields.SerializerSettings);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug("AgileCRM : Contact note(s) retrieved successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);

            return agileCrmServerContactNoteEntities;
        }

        /// <inheritdoc />
        public async Task<IList<AgileCrmServerDealNoteEntity>> GetDealNotesAsync(
            long dealId,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.GetDealNotesAsync);
            this.logger.LogMethodStart(ClassName, MethodName);

            IList<AgileCrmServerDealNoteEntity> agileCrmServerDealNoteEntities;
            try
            {
                // Send request to server
                var uri = $"opportunity/{dealId}/notes";

                var httpResponseMessage = await this.httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

                // Analyze server response for errors
                ResponseAnalyzer.Analyze(ProcessorType.Notes, httpResponseMessage.StatusCode);

                // Return data retrieved from server
                var httpContentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                agileCrmServerDealNoteEntities = JsonConvert.DeserializeObject<List<AgileCrmServerDealNoteEntity>>(
                    httpContentAsString, ProcessorFields.SerializerSettings);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.LogDebug("AgileCRM : Deal note(s) retrieved successfully.");
            this.logger.LogMethodEnd(ClassName, MethodName);

            return agileCrmServerDealNoteEntities;
        }
    }
}