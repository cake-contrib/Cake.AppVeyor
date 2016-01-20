using System;
using System.Threading.Tasks;
using Refit;
using System.Collections.Generic;
using Cake.AppVeyor.Models;
using System.Net.Http;
using System.Threading;
using System.Net.Http.Headers;

namespace Cake.AppVeyor
{
    static class AppVeyorClient
    {
        const string baseUrl = "https://ci.appveyor.com";

        public static IAppVeyorApi Create (string authToken)
        {
            return RestService.For<IAppVeyorApi> (
                new HttpClient(new AuthenticatedHttpClientHandler (authToken)) { 
                    BaseAddress = new Uri(baseUrl) 
                });
        }
    }

    interface IAppVeyorApi
    {
        [Get("/api/projects")]
        Task<List<Project>> GetProjects ();

        [Get ("/api/projects/{accountName}/{projectSlug}/history")]
        Task<ProjectHistory> GetProjectHistory (string accountName, string projectSlug, [AliasAs ("recordsNumber")]int recordsPerPage, int? startBuildId = null, string branch = null);

        [Get ("/api/projects/{accountName}/{projectSlug}")]
        Task<ProjectBuild> GetProjectLastBuild (string accountName, string projectSlug);
    }

    class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        public string AuthToken { get; set; }

        public AuthenticatedHttpClientHandler (string authToken)
        {
            AuthToken = authToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue ("Bearer", AuthToken);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}

