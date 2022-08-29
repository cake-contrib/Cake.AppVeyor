using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Cake.AppVeyor
{
    public static class AppVeyorClient
    {
        private const string BaseUrl = "https://ci.appveyor.com";

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
