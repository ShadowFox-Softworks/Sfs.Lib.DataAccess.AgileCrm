namespace SFS.AgileCRM.Library.Logic.Internal.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using SFS.AgileCRM.Library.Data.Requests;
    using SFS.AgileCRM.Library.Data.Responses;
    using SFS.AgileCRM.Library.Interfaces.Internal;
    using SFS.AgileCRM.Library.Interfaces.Services;
    using SFS.AgileCRM.Library.Logic.Internal.Helpers;

    /// <summary>
    /// The Tasks Service.
    /// </summary>
    /// <seealso cref="SFS.AgileCRM.Library.Interfaces.Services.ITasksService" />
    internal sealed class TasksService : ITasksService
    {
        /// <summary>
        /// The class name.
        /// </summary>
        private const string ClassName = nameof(TasksService);

        /// <summary>
        /// The HTTP client.
        /// </summary>
        private readonly IHttpClient httpClient;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TasksService" /> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="logger">The logger.</param>
        public TasksService(
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
        public async Task CreateAsync(AgileCrmTaskRequest agileCrmTaskModel)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(long taskId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<AgileCrmTaskEntity> GetAsync(long contactId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task UpdateAsync(long taskId, AgileCrmTaskRequest agileCrmTaskModel)
        {
            throw new NotImplementedException();
        }
    }
}