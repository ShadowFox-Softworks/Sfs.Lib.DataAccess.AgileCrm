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
    using Osw.Lib.DataAccess.AgileCrm.Interfaces.Internal;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;

    /// <inheritdoc />
    internal sealed class HttpClientWrapper : IHttpClient
    {
        /// <summary>
        /// The class name.
        /// </summary>
        private const string ClassName = nameof(HttpClientWrapper);

        /// <summary>
        /// The media type.
        /// </summary>
        private const string MediaType = "application/json";

        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        private static HttpClient httpClient;

        /// <summary>
        /// The base URI.
        /// </summary>
        private readonly string baseUri;

        /// <summary>
        /// The logger.
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

            httpClient = new HttpClient(new HttpClientHandler
            {
                Credentials = new NetworkCredential(
                    agileCrmConfiguration.Username,
                    agileCrmConfiguration.ApiKey)
            });
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> DeleteAsync(
            string requestUri,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.DeleteAsync);
            this.logger.MethodStart(ClassName, MethodName);

            var httpResponseMessage = new HttpResponseMessage();
            try
            {
                httpClient.DefaultRequestHeaders.Clear();

                httpResponseMessage = await httpClient.DeleteAsync(
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
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Accept", MediaType);

                httpResponseMessage = await httpClient.GetAsync(
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
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Accept", MediaType);
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", MediaType);

                httpResponseMessage = await httpClient.PostAsync(
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
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Accept", MediaType);
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", MediaType);

                httpResponseMessage = await httpClient.PutAsync(
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