using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace Cake.AppVeyor
{
    /// <summary>
    /// Provides the API methods that can be called against AppVeyor via the <cref>AppVeyorClient</cref>.
    /// </summary>
    public interface IAppVeyorApi
    {
        /// <summary>
        /// Clear the cache for a given AppVeyor project.
        /// </summary>
        /// <param name="accountName">The AppVeyor account name.</param>
        /// <param name="projectSlug">The slug for the project.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Delete("/api/projects/{accountName}/{projectSlug}/buildcache")]
        Task ClearCache(string accountName, string projectSlug);

        /// <summary>
        /// Gets a list of projects from AppVeyor.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation with a list of AppVeyor projects.</returns>
        [Get("/api/projects")]
        Task<List<AppVeyorProject>> GetProjects();

        /// <summary>
        /// Gets the history for a given project from AppVeyor.
        /// </summary>
        /// <param name="accountName">The AppVeyor account name.</param>
        /// <param name="projectSlug">The slug for the project.</param>
        /// <param name="recordsPerPage">The numbers of records to return in a page of results.</param>
        /// <param name="startBuildId">The ID for the build to start with.</param>
        /// <param name="branch">The name of the branch to use for the request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation with the project history.</returns>
        [Get("/api/projects/{accountName}/{projectSlug}/history")]
        Task<AppVeyorProjectHistory> GetProjectHistory(string accountName, string projectSlug, [AliasAs("recordsNumber")] int recordsPerPage, int? startBuildId = null, string branch = null);

        /// <summary>
        /// Gets the latest build for a given project.
        /// </summary>
        /// <param name="accountName">The AppVeyor account name.</param>
        /// <param name="projectSlug">The slug for the project.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation with the last build for the project.</returns>
        [Get("/api/projects/{accountName}/{projectSlug}")]
        Task<AppVeyorProjectBuild> GetProjectLastBuild(string accountName, string projectSlug);

        /// <summary>
        /// Gets the latest build for a given project based on branch name.
        /// </summary>
        /// <param name="accountName">The AppVeyor account name.</param>
        /// <param name="projectSlug">The slug for the project.</param>
        /// <param name="branchName">The name of the branch to use for the request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation with the last build for a branch for the project.</returns>
        [Get("/api/projects/{accountName}/{projectSlug}/branch/{branchName}")]
        Task<AppVeyorProjectBuild> GetProjectLastBranchBuild(string accountName, string projectSlug, string branchName);

        /// <summary>
        /// Gets a specific AppVeyor build based on buil version number.
        /// </summary>
        /// <param name="accountName">The AppVeyor account name.</param>
        /// <param name="projectSlug">The slug for the project.</param>
        /// <param name="buildVersion">The build version number.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation with the build for the specified version for the project.</returns>
        [Get("/api/projects/{accountName}/{projectSlug}/build/{buildVersion}")]
        Task<AppVeyorProjectBuild> GetProjectBuildByVersion(string accountName, string projectSlug, string buildVersion);

        /// <summary>
        /// Get the deployments for a given project.
        /// </summary>
        /// <param name="accountName">The AppVeyor account name.</param>
        /// <param name="projectSlug">The slug for the project.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation with a lst of deployments for the project.</returns>
        [Get("/api/projects/{accountName}/{projectSlug}/deployments")]
        Task<AppVeyorProjectDeployments> GetProjectDeployments(string accountName, string projectSlug);

        /// <summary>
        /// Starts a build.
        /// </summary>
        /// <param name="buildRequest">An instance of <cref>AppVeyorBuildRequestLatestCommit</cref> identifying which build to start.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation with the build.</returns>
        [Post("/api/builds")]
        Task<AppVeyorBuild> StartBuildLatestCommit([Body] AppVeyorBuildRequestLatestCommit buildRequest);

        /// <summary>
        /// Starts a build for a given commit.
        /// </summary>
        /// <param name="buildRequest">An instance of <cref>AppVeyorBuildRequestSpecificCommit</cref> identifying which build to start.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation with the build.</returns>
        [Post("/api/builds")]
        Task<AppVeyorBuild> StartBuildSpecificCommit([Body] AppVeyorBuildRequestSpecificCommit buildRequest);

        /// <summary>
        /// Starts a build from a pull request.
        /// </summary>
        /// <param name="buildRequest">An instance of <cref>AppVeyorBuildRequestPullRequest</cref> identifying which build to start.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation with the build.</returns>
        [Post("/api/builds")]
        Task<AppVeyorBuild> StartBuildPullRequest([Body] AppVeyorBuildRequestPullRequest buildRequest);

        /// <summary>
        /// Cancels a build.
        /// </summary>
        /// <param name="accountName">The AppVeyor account name.</param>
        /// <param name="projectSlug">The slug for the project.</param>
        /// <param name="buildVersion">The build version number.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Delete("/api/builds/{accountName}/{projectSlug}/{buildVersion}")]
        Task CancelBuild(string accountName, string projectSlug, string buildVersion);

        /// <summary>
        /// Gets a single deployment.
        /// </summary>
        /// <param name="deploymentId">ID for the deployment to fetch.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation with the specified deployment.</returns>
        [Get("/api/deployments/{deploymentId}")]
        Task<AppVeyorProjectDeployment> GetDeployment(int deploymentId);

        /// <summary>
        /// Starts a deployment.
        /// </summary>
        /// <param name="startDeploymentRequest">An instance of <cref>AppVeyorStartDeploymentRequest</cref> identifying which deployment to start.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation with the deployment that was started.</returns>
        [Post("/api/deployments")]
        Task<AppVeyorDeployment> StartDeployment(AppVeyorStartDeploymentRequest startDeploymentRequest);

        /// <summary>
        /// Cancels a deployment.
        /// </summary>
        /// <param name="cancelDeploymentRequest">An instance of <cref>AppVeyorCancelDeploymentRequest</cref> identifying which deployment to cancel.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Put("/api/deployments/stop")]
        Task CancelDeployment(AppVeyorCancelDeploymentRequest cancelDeploymentRequest);

        /// <summary>
        /// Gets all environemnts.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation with the list of environment.</returns>
        [Get("/api/environments")]
        Task<List<AppVeyorEnvironment>> GetEnvironments();

        /// <summary>
        /// Gets all deployments for a given environment.
        /// </summary>
        /// <param name="deploymentEnvironmentId">The ID of the deployment.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation with the deployment for the environment.</returns>
        [Get("/api/environments/{deploymentEnvironmentId}/deployments")]
        Task<AppVeyorEnvironmentDeployments> GetEnvironmentDeployments(int deploymentEnvironmentId);
    }
}
