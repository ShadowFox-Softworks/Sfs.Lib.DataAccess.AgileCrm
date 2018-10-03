namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Microsoft.Extensions.Logging;
    using Osw.Lib.DataAccess.AgileCrm.Entities;
    using Osw.Lib.DataAccess.AgileCrm.Interface.Internal;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;

    /// <inheritdoc />
    internal sealed class HttpClientWrapper : IHttpClient
    {
        /// <summary>
        /// The class name
        /// </summary>
        private const string ClassName = nameof(HttpClientWrapper);

        /// <summary>
        /// The media type
        /// </summary>
        private const string MediaType = "application/json";

        /// <summary>
        /// The base URI
        /// </summary>
        private readonly string baseUri;

        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        private readonly HttpClient httpClient;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientWrapper" /> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="agileCrmConfiguration">The agile CRM configuration.</param>
        public HttpClientWrapper(
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] AgileCrmConfiguration agileCrmConfiguration)
        {
            NullGuard.EnsureNotNull(loggerFactory, nameof(loggerFactory));
            NullGuard.EnsureNotNull(agileCrmConfiguration, nameof(agileCrmConfiguration));

            this.logger = loggerFactory.CreateLogger<HttpClientWrapper>();
            this.baseUri = $"https://{agileCrmConfiguration.Domain}.agilecrm.com/dev/api/";

            this.httpClient = new HttpClient(new HttpClientHandler
            {
                Credentials = new NetworkCredential(
                    agileCrmConfiguration.Username,
                    agileCrmConfiguration.ApiKey)
            });
        }

        /// <inheritdoc />https://{domain}.agilecrm.com
        public async Task<HttpResponseMessage> DeleteAsync(
            string requestUri,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.DeleteAsync);
            this.logger.MethodStart(ClassName, MethodName);

            var httpResponseMessage = new HttpResponseMessage();
            try
            {
                httpResponseMessage = await this.httpClient.DeleteAsync(
                    $"{this.baseUri}{requestUri}", cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                this.logger.LogException(e, ClassName, MethodName);
            }

            this.logger.MethodEnd(ClassName, MethodName);
            return httpResponseMessage;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> GetAsync(
            string requestUri,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.GetAsync);
            this.logger.MethodStart(ClassName, MethodName);

            var httpResponseMessage = new HttpResponseMessage();
            try
            {
                this.httpClient.DefaultRequestHeaders.Add("Accept", MediaType);

                httpResponseMessage = await this.httpClient.GetAsync(
                    $"{this.baseUri}{requestUri}", cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                this.logger.LogException(e, ClassName, MethodName);
            }

            this.logger.MethodEnd(ClassName, MethodName);
            return httpResponseMessage;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> PostAsync(
            string requestUri,
            StringContent stringContent,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.GetAsync);
            this.logger.MethodStart(ClassName, MethodName);

            var httpResponseMessage = new HttpResponseMessage();
            try
            {
                this.httpClient.DefaultRequestHeaders.Add("Accept", MediaType);
                this.httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", MediaType);

                httpResponseMessage = await this.httpClient.PostAsync(
                    $"{this.baseUri}{requestUri}", stringContent, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                this.logger.LogException(e, ClassName, MethodName);
            }

            this.logger.MethodEnd(ClassName, MethodName);
            return httpResponseMessage;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> PutAsync(
            string requestUri,
            StringContent stringContent,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.GetAsync);
            this.logger.MethodStart(ClassName, MethodName);

            var httpResponseMessage = new HttpResponseMessage();
            try
            {
                this.httpClient.DefaultRequestHeaders.Add("Accept", MediaType);
                this.httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", MediaType);

                httpResponseMessage = await this.httpClient.PutAsync(
                    $"{this.baseUri}{requestUri}", stringContent, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                this.logger.LogException(e, ClassName, MethodName);
            }

            this.logger.MethodEnd(ClassName, MethodName);
            return httpResponseMessage;
        }
    }
}