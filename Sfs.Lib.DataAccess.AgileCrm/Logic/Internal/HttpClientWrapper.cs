namespace Sfs.Lib.DataAccess.AgileCrm.Logic.Internal
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Sfs.Lib.DataAccess.AgileCrm.Entities;
    using Sfs.Lib.DataAccess.AgileCrm.Interfaces.Internal;
    using Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;

    /// <inheritdoc />
    internal sealed class HttpClientWrapper : IHttpClient
    {
        /// <summary>
        /// The HTTP accept header name.
        /// </summary>
        private const string Accept = "Accept";

        /// <summary>
        /// The HTTP content type header name.
        /// </summary>
        private const string ContentType = "Content-Type";

        /// <summary>
        /// The HTTP contect media type.
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
            ILoggerFactory loggerFactory,
            AgileCrmConfiguration agileCrmConfiguration)
        {
            loggerFactory.EnsureNotNull();
            agileCrmConfiguration.EnsureNotNull();

            this.logger = loggerFactory.CreateLogger<HttpClientWrapper>();
            this.baseUri = $"https://{agileCrmConfiguration.Domain}.agilecrm.com/dev/api/";

            // HttpClient instantiated with AgileCRM account credentials
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
            httpClient.DefaultRequestHeaders.Clear();

            var httpResponseMessage = await httpClient.DeleteAsync(
                $"{this.baseUri}{requestUri}", cancellationToken).ConfigureAwait(false);

            return httpResponseMessage;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> GetAsync(
            string requestUri,
            CancellationToken cancellationToken)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add(Accept, MediaType);

            var httpResponseMessage = await httpClient.GetAsync(
                $"{this.baseUri}{requestUri}", cancellationToken).ConfigureAwait(false);

            return httpResponseMessage;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> PostAsync(
            string requestUri,
            StringContent stringContent,
            CancellationToken cancellationToken)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add(Accept, MediaType);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation(ContentType, MediaType);

            var httpResponseMessage = await httpClient.PostAsync(
                $"{this.baseUri}{requestUri}", stringContent, cancellationToken).ConfigureAwait(false);

            return httpResponseMessage;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> PutAsync(
            string requestUri,
            StringContent stringContent,
            CancellationToken cancellationToken)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add(Accept, MediaType);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation(ContentType, MediaType);

            var httpResponseMessage = await httpClient.PutAsync(
                $"{this.baseUri}{requestUri}", stringContent, cancellationToken).ConfigureAwait(false);

            return httpResponseMessage;
        }
    }
}