namespace Osw.Lib.DataAccess.AgileCrm.Interface.Internal
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The HTTP Client
    /// </summary>
    internal interface IHttpClient
    {
        /// <summary>
        /// HTTP DELETE method.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />
        /// </returns>
        Task<HttpResponseMessage> DeleteAsync(
            string requestUri,
            CancellationToken cancellationToken);

        /// <summary>
        /// HTTP GET method.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />
        /// </returns>
        Task<HttpResponseMessage> GetAsync(
            string requestUri,
            CancellationToken cancellationToken);

        /// <summary>
        /// HTTP POST method.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="stringContent">Content of the string.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />
        /// </returns>
        Task<HttpResponseMessage> PostAsync(
            string requestUri,
            StringContent stringContent,
            CancellationToken cancellationToken);

        /// <summary>
        /// HTTP PUT method.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="stringContent">Content of the string.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />
        /// </returns>
        Task<HttpResponseMessage> PutAsync(
            string requestUri,
            StringContent stringContent,
            CancellationToken cancellationToken);
    }
}