using System;
using System.Threading.Tasks;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Net.Http.Headers;

namespace Cake.AppVeyor
{
    public static class AppVeyorClient
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

    public interface IAppVeyorApi
    {
        [Delete("/api/projects/{accountName}/{projectSlug}/buildcache")]
        Task ClearCache (string accountName, string projectSlug);

        [Get("/api/projects")]
        Task<List<AppVeyorProject>> GetProjects ();

        [Get ("/api/projects/{accountName}/{projectSlug}/history")]
        Task<AppVeyorProjectHistory> GetProjectHistory (string accountName, string projectSlug, [AliasAs ("recordsNumber")]int recordsPerPage, int? startBuildId = null, string branch = null);

        [Get ("/api/projects/{accountName}/{projectSlug}")]
        Task<AppVeyorProjectBuild> GetProjectLastBuild (string accountName, string projectSlug);

        [Get ("/api/projects/{accountName}/{projectSlug}/branch/{branchName}")]
        Task<AppVeyorProjectBuild> GetProjectLastBranchBuild (string accountName, string projectSlug, string branchName);

        [Get ("/api/projects/{accountName}/{projectSlug}/build/{buildVersion}")]
        Task<AppVeyorProjectBuild> GetProjectBuildByVersion (string accountName, string projectSlug, string buildVersion);

        [Get ("/api/projects/{accountName}/{projectSlug}/deployments")]
        Task<AppVeyorProjectDeployments> GetProjectDeployments (string accountName, string projectSlug);

        [Post ("/api/builds")]
        Task<AppVeyorBuild> StartBuildLatestCommit ([Body]AppVeyorBuildRequestLatestCommit buildRequest);

        [Post ("/api/builds")]
        Task<AppVeyorBuild> StartBuildSpecificCommit ([Body]AppVeyorBuildRequestSpecificCommit buildRequest);

        [Post ("/api/builds")]
        Task<AppVeyorBuild> StartBuildPullRequest ([Body]AppVeyorBuildRequestPullRequest buildRequest);

        [Delete ("/api/builds/{accountName}/{projectSlug}/{buildVersion}")]
        Task CancelBuild (string accountName, string projectSlug, string buildVersion);

        [Get ("/api/deployments/{deploymentId}")]
        Task<AppVeyorProjectDeployment> GetDeployment (int deploymentId);

        [Post ("/api/deployments")]
        Task<AppVeyorDeployment> StartDeployment (AppVeyorStartDeploymentRequest startDeploymentRequest);

        [Put ("/api/deployments/stop")]
        Task CancelDeployment (AppVeyorCancelDeploymentRequest cancelDeploymentRequest);

        [Get ("/api/environments")]
        Task<List<AppVeyorEnvironment>> GetEnvironments ();

        [Get ("/api/environments/{deploymentEnvironmentId}/deployments")]
        Task<AppVeyorEnvironmentDeployments> GetEnvironmentDeployments (int deploymentEnvironmentId);
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

