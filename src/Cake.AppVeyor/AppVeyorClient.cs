using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Cake.AppVeyor
{
    /// <summary>
    /// Provides a class for sending HTTP requests to AppVeyor.
    /// </summary>
    public static class AppVeyorClient
    {
        private const string BaseUrl = "https://ci.appveyor.com";

        /// <summary>
        /// Create a new instance of <cref>IAppVeyorApi</cref> for interacting with the available methods against AppVeyor REST API.
        /// </summary>
        /// <param name="authToken">The API Key to use.</param>
        /// <returns>An instance of <cref>IAppVeyorApi</cref> to allow communication to AppVeyor REST API.</returns>
        public static IAppVeyorApi Create(string authToken)
        {
            return RestService.For<IAppVeyorApi>(
                new HttpClient(new AuthenticatedHttpClientHandler(authToken))
                {
                    BaseAddress = new Uri(BaseUrl),
                });
        }
    }
}
