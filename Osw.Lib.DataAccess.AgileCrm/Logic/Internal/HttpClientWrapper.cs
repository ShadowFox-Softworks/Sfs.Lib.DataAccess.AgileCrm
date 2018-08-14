namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Entity;
    using Helpers;
    using Interface.Internal;
    using JetBrains.Annotations;
    using Microsoft.Extensions.Logging;

    /// <inheritdoc />
    internal sealed class HttpClientWrapper : IHttpClient
    {
        /// <summary>
        /// The class name
        /// </summary>
        private const string ClassName = nameof(HttpClientWrapper);

        /// <summary>
        /// The lazy client
        /// </summary>
        private static Lazy<HttpClient> lazyHttpClient;

        /// <summary>
        /// The domain
        /// </summary>
        private readonly string domain;

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
            if (agileCrmConfiguration == null)
            {
                throw new ArgumentNullException(nameof(agileCrmConfiguration));
            }

            this.logger = loggerFactory.CreateLogger<HttpClientWrapper>();
            this.domain = agileCrmConfiguration.Domain;

            if (lazyHttpClient == null)
            {
                var httpClientHandler = new HttpClientHandler
                {
                    Credentials = new NetworkCredential(
                        agileCrmConfiguration.Username,
                        agileCrmConfiguration.ApiKey)
                };

                lazyHttpClient = new Lazy<HttpClient>(() => new HttpClient(httpClientHandler));
            }
        }

        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        private static HttpClient HttpClient => lazyHttpClient.Value;

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
                httpResponseMessage = await HttpClient.DeleteAsync(
                    $"https://{this.domain}.agilecrm.com/{requestUri}", cancellationToken).ConfigureAwait(false);
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
                HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                httpResponseMessage = await HttpClient.GetAsync(
                    $"https://{this.domain}.agilecrm.com/{requestUri}", cancellationToken).ConfigureAwait(false);
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

            var httpResponseMessage = new HttpResponseMessage();
            try
            {
                HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                httpResponseMessage = await HttpClient.PostAsync(
                    $"https://{this.domain}.agilecrm.com/{requestUri}", stringContent, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                this.logger.LogException(e, ClassName, MethodName);
            }

            return httpResponseMessage;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> PutAsync(
            string requestUri,
            StringContent stringContent,
            CancellationToken cancellationToken)
        {
            const string MethodName = nameof(this.GetAsync);

            var httpResponseMessage = new HttpResponseMessage();
            try
            {
                HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                httpResponseMessage = await HttpClient.PutAsync(
                    $"https://{this.domain}.agilecrm.com/{requestUri}",
                    stringContent,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                this.logger.LogException(e, ClassName, MethodName);
            }

            return httpResponseMessage;
        }
    }
}