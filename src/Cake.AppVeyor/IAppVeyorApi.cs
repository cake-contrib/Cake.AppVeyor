using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace Cake.AppVeyor
{
    public interface IAppVeyorApi
    {
        [Delete("/api/projects/{accountName}/{projectSlug}/buildcache")]
        Task ClearCache(string accountName, string projectSlug);

        [Get("/api/projects")]
        Task<List<AppVeyorProject>> GetProjects();

        [Get("/api/projects/{accountName}/{projectSlug}/history")]
        Task<AppVeyorProjectHistory> GetProjectHistory(string accountName, string projectSlug, [AliasAs("recordsNumber")] int recordsPerPage, int? startBuildId = null, string branch = null);

        [Get("/api/projects/{accountName}/{projectSlug}")]
        Task<AppVeyorProjectBuild> GetProjectLastBuild(string accountName, string projectSlug);

        [Get("/api/projects/{accountName}/{projectSlug}/branch/{branchName}")]
        Task<AppVeyorProjectBuild> GetProjectLastBranchBuild(string accountName, string projectSlug, string branchName);

        [Get("/api/projects/{accountName}/{projectSlug}/build/{buildVersion}")]
        Task<AppVeyorProjectBuild> GetProjectBuildByVersion(string accountName, string projectSlug, string buildVersion);

        [Get("/api/projects/{accountName}/{projectSlug}/deployments")]
        Task<AppVeyorProjectDeployments> GetProjectDeployments(string accountName, string projectSlug);

        [Post("/api/builds")]
        Task<AppVeyorBuild> StartBuildLatestCommit([Body] AppVeyorBuildRequestLatestCommit buildRequest);

        [Post("/api/builds")]
        Task<AppVeyorBuild> StartBuildSpecificCommit([Body] AppVeyorBuildRequestSpecificCommit buildRequest);

        [Post("/api/builds")]
        Task<AppVeyorBuild> StartBuildPullRequest([Body] AppVeyorBuildRequestPullRequest buildRequest);

        [Delete("/api/builds/{accountName}/{projectSlug}/{buildVersion}")]
        Task CancelBuild(string accountName, string projectSlug, string buildVersion);

        [Get("/api/deployments/{deploymentId}")]
        Task<AppVeyorProjectDeployment> GetDeployment(int deploymentId);

        [Post("/api/deployments")]
        Task<AppVeyorDeployment> StartDeployment(AppVeyorStartDeploymentRequest startDeploymentRequest);

        [Put("/api/deployments/stop")]
        Task CancelDeployment(AppVeyorCancelDeploymentRequest cancelDeploymentRequest);

        [Get("/api/environments")]
        Task<List<AppVeyorEnvironment>> GetEnvironments();

        [Get("/api/environments/{deploymentEnvironmentId}/deployments")]
        Task<AppVeyorEnvironmentDeployments> GetEnvironmentDeployments(int deploymentEnvironmentId);
    }
}
