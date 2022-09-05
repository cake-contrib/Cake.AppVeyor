using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Cake.AppVeyor
{
    /// <summary>
    /// The default message handler used by <cref>AppVeyorClient</cref>.
    /// </summary>
    public class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticatedHttpClientHandler"/> class.
        /// </summary>
        /// <param name="authToken">The API Key for accessing AppVeyor.</param>
        public AuthenticatedHttpClientHandler(string authToken)
        {
            AuthToken = authToken;
        }

        /// <summary>
        /// Gets or sets the API Key used to communicate with AppVeyor.
        /// </summary>
        public string AuthToken { get; set; }

        /// <summary>
        /// Sends a message, asynchronously, to AppVeyor.
        /// </summary>
        /// <param name="request">The <cref>HttpRequestMessage</cref> to send to AppVeyor.</param>
        /// <param name="cancellationToken">The <cref>CancellationToken</cref> for the operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation to send a request to AppVeyor.</returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
