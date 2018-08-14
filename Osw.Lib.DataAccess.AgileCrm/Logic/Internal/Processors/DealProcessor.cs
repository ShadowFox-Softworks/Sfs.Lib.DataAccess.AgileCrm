namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Processors
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Entity;
    using Helpers;
    using Interface.Internal;
    using Interface.Internal.Processors;
    using JetBrains.Annotations;
    using Microsoft.Extensions.Logging;

    /// <inheritdoc />
    internal sealed class DealProcessor : IDealProcessor
    {
        /// <summary>
        /// The class name
        /// </summary>
        private const string ClassName = nameof(DealProcessor);

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
        /// Initializes a new instance of the <see cref="DealProcessor"/> class.
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
        public DealProcessor(
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
        public async Task CreateDealAsync(
            string emailAddress,
            AgileCrmDealEntity dealEntity,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.CreateDealAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // TODO: CreateDealAsync implementation
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task DeleteDealAsync(
            string emailAddress,
            CancellationToken cancellationToken,
            AgileCrmDealFilter dealFilter = default(AgileCrmDealFilter))
        {
            const string MethodName = nameof(this.DeleteDealAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // TODO: DeleteDealAsync implementation
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<AgileCrmDealEntity> GetDealAsync(
            string emailAddress,
            CancellationToken cancellationToken,
            AgileCrmDealFilter dealFilter = default(AgileCrmDealFilter))
        {
            const string MethodName = nameof(this.GetDealAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // TODO: GetDealAsync implementation
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task UpdateDealAsync(
            string emailAddress,
            AgileCrmDealEntity dealEntity,
            CancellationToken cancellationToken,
            AgileCrmDealFilter dealFilter = default(AgileCrmDealFilter))
        {
            const string MethodName = nameof(this.UpdateDealAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // TODO: UpdateDealAsync implementation
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }
    }
}