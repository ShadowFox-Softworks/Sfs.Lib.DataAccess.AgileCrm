namespace SFS.AgileCRM.Library.Logic.Internal
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using SFS.AgileCRM.Library.Data.Configurations;
    using SFS.AgileCRM.Library.Interfaces.Internal;
    using SFS.AgileCRM.Library.Logic.Internal.Helpers;

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
        /// Initializes a new instance of the <see cref="HttpClientWrapper" /> class.
        /// </summary>
        /// <param name="agileCrmConfiguration">The agile CRM configuration.</param>
        public HttpClientWrapper(
            AgileCrmConfiguration agileCrmConfiguration)
        {
            agileCrmConfiguration.EnsureNotNull();

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
        public async Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            httpClient.DefaultRequestHeaders.Clear();

            var httpResponseMessage = await httpClient.DeleteAsync($"{this.baseUri}{requestUri}").ConfigureAwait(false);

            return httpResponseMessage;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add(Accept, MediaType);

            var httpResponseMessage = await httpClient.GetAsync($"{this.baseUri}{requestUri}").ConfigureAwait(false);

            return httpResponseMessage;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> PostAsync(
            string requestUri, StringContent stringContent)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add(Accept, MediaType);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation(ContentType, MediaType);

            var httpResponseMessage = await httpClient.PostAsync($"{this.baseUri}{requestUri}", stringContent).ConfigureAwait(false);

            return httpResponseMessage;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> PutAsync(string requestUri, StringContent stringContent)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add(Accept, MediaType);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation(ContentType, MediaType);

            var httpResponseMessage = await httpClient.PutAsync($"{this.baseUri}{requestUri}", stringContent).ConfigureAwait(false);

            return httpResponseMessage;
        }
    }
}