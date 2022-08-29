using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Cake.AppVeyor
{
    public class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        public AuthenticatedHttpClientHandler(string authToken)
        {
            AuthToken = authToken;
        }

        public string AuthToken { get; set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
