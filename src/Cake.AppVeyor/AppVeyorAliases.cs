using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.AppVeyor
{
    /// <summary>
    /// <para>AppVeyor API related cake aliases.</para>
    /// <para>
    ///  In order to use aliases from this addin, you will need to also reference Refit and Newtonsoft.Json as an addin.
    ///  Here is what including Cake.AppVeyor in your script should look like:
    /// <code>
    /// #addin package:?Cake.AppVeyor
    /// #addin package:?Refit&amp;version=4.6.58
    /// #addin package:?Newtonsoft.Json&amp;version=11.0.2
    /// </code>
    /// </para>
    /// </summary>
    [CakeAliasCategory("AppVeyor")]
    public static class AppVeyorAliases
    {
        /// <summary>
        /// Clears the AppVeyor Cache using additional settings in <cref>AppVeyorSettings</cref>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        [CakeMethodAlias]
        public static void AppVeyorClearCache(this ICakeContext context, AppVeyorSettings settings, string accountName, string projectSlug)
        {
            var appVeyor = AppVeyorClient.Create(settings.ApiToken);
            appVeyor.ClearCache(accountName, projectSlug).Wait();
        }

        /// <summary>
        /// Clears the AppVeyor Cache.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API Token.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        [CakeMethodAlias]
        public static void AppVeyorClearCache(this ICakeContext context, string appVeyorApiToken, string accountName, string projectSlug)
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            appVeyor.ClearCache(accountName, projectSlug).Wait();
        }

        /// <summary>
        /// Gets all projects using additional settings in <cref>AppVeyorSettings</cref>.
        /// </summary>
        /// <returns>The projects.</returns>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static List<AppVeyorProject> AppVeyorProjects(this ICakeContext context, AppVeyorSettings settings)
        {
            var appVeyor = AppVeyorClient.Create(settings.ApiToken);
            return appVeyor.GetProjects().Result;
        }

        /// <summary>
        /// Gets all projects.
        /// </summary>
        /// <returns>The projects.</returns>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API Token.</param>
        [CakeMethodAlias]
        public static List<AppVeyorProject> AppVeyorProjects(this ICakeContext context, string appVeyorApiToken)
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            return appVeyor.GetProjects().Result;
        }

        /// <summary>
        /// Gets the project build history using additional settings in <cref>AppVeyorSettings</cref>.
        /// </summary>
        /// <returns>The project build history.</returns>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        /// <param name="recordsPerPage">The number of records to return.</param>
        /// <param name="startBuildId">The build identifier to start returning records after.</param>
        /// <param name="branch">The branch.</param>
        [CakeMethodAlias]
        public static AppVeyorProjectHistory AppVeyorProjectHistory(this ICakeContext context, AppVeyorSettings settings, string accountName, string projectSlug, int recordsPerPage, int? startBuildId = null, string branch = null)
        {
            var appVeyor = AppVeyorClient.Create(settings.ApiToken);
            return appVeyor.GetProjectHistory(accountName, projectSlug, recordsPerPage, startBuildId, branch).Result;
        }

        /// <summary>
        /// Gets the project build history.
        /// </summary>
        /// <returns>The project build history.</returns>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API Token.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        /// <param name="recordsPerPage">The number of records to return.</param>
        /// <param name="startBuildId">The build identifier to start returning records after.</param>
        /// <param name="branch">The branch.</param>
        [CakeMethodAlias]
        public static AppVeyorProjectHistory AppVeyorProjectHistory(this ICakeContext context, string appVeyorApiToken, string accountName, string projectSlug, int recordsPerPage, int? startBuildId = null, string branch = null)
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            return appVeyor.GetProjectHistory(accountName, projectSlug, recordsPerPage, startBuildId, branch).Result;
        }

        /// <summary>
        /// Gets the last build of the project using additional settings in <cref>AppVeyorSettings</cref>.
        /// </summary>
        /// <returns>The project's last build.</returns>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        [CakeMethodAlias]
        public static AppVeyorProjectBuild AppVeyorProjectLastBuild(this ICakeContext context, AppVeyorSettings settings, string accountName, string projectSlug)
        {
            var appVeyor = AppVeyorClient.Create(settings.ApiToken);
            return appVeyor.GetProjectLastBuild(accountName, projectSlug).Result;
        }

        /// <summary>
        /// Gets the last build of the project.
        /// </summary>
        /// <returns>The project's last build.</returns>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API Token.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        [CakeMethodAlias]
        public static AppVeyorProjectBuild AppVeyorProjectLastBuild(this ICakeContext context, string appVeyorApiToken, string accountName, string projectSlug)
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            return appVeyor.GetProjectLastBuild(accountName, projectSlug).Result;
        }

        /// <summary>
        /// Gets the last successful build of the project using additional settings in <cref>AppVeyorSettings</cref>.
        /// </summary>
        /// <returns>The project's last successful build.</returns>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        /// <param name="branch">The branch.</param>
        /// <param name="beforeBuildId">The build identifier to start looking for a successful build after.</param>
        [CakeMethodAlias]
        public static AppVeyorProjectBuild AppVeyorProjectLastSuccessfulBuild(this ICakeContext context, AppVeyorSettings settings, string accountName, string projectSlug, string branch = null, int? beforeBuildId = null)
        {
            var appVeyor = AppVeyorClient.Create(settings.ApiToken);

            AppVeyorProjectBuild lastSuccess = null;
            int? startBuildId = beforeBuildId;

            while (lastSuccess == null)
            {
                var history = appVeyor.GetProjectHistory(accountName, projectSlug, 2, startBuildId: startBuildId).Result;

                if (history == null || history.Builds == null || history.Builds.Count <= 0)
                {
                    break;
                }

                foreach (var build in history.Builds)
                {
                    if (build.Status.Equals("success", StringComparison.OrdinalIgnoreCase))
                    {
                        lastSuccess = new AppVeyorProjectBuild
                        {
                            Project = history.Project,
                            Build = build,
                        };
                        break;
                    }
                }

                startBuildId = history.Builds.Last().BuildId;
            }

            return lastSuccess;
        }

        /// <summary>
        /// Gets the last successful build of the project.
        /// </summary>
        /// <returns>The project's last successful build.</returns>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API Token.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        /// <param name="branch">The branch.</param>
        /// <param name="beforeBuildId">The build identifier to start looking for a successful build after.</param>
        [CakeMethodAlias]
        public static AppVeyorProjectBuild AppVeyorProjectLastSuccessfulBuild(this ICakeContext context, string appVeyorApiToken, string accountName, string projectSlug, string branch = null, int? beforeBuildId = null)
        {
            return AppVeyorProjectLastSuccessfulBuild(context, new AppVeyorSettings { ApiToken = appVeyorApiToken }, accountName, projectSlug, branch, beforeBuildId);
        }

        /// <summary>
        /// Gets the last build on the specified branch of the project.
        /// </summary>
        /// <returns>The project's last successful build on the branch.</returns>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API Token.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        /// <param name="branch">The branch.</param>
        [CakeMethodAlias]
        public static AppVeyorProjectBuild AppVeyorProjectLastBranchBuild(this ICakeContext context, string appVeyorApiToken, string accountName, string projectSlug, string branch)
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            return appVeyor.GetProjectLastBranchBuild(accountName, projectSlug, branch).Result;
        }

        /// <summary>
        /// Gets the project build by version.
        /// </summary>
        /// <returns>The veyor project build by version.</returns>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API token.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        /// <param name="buildVersion">The build version.</param>
        [CakeMethodAlias]
        public static AppVeyorProjectBuild AppVeyorProjectBuildByVersion(this ICakeContext context, string appVeyorApiToken, string accountName, string projectSlug, string buildVersion)
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            return appVeyor.GetProjectBuildByVersion(accountName, projectSlug, buildVersion).Result;
        }

        /// <summary>
        /// Starts a build from the latest commit.
        /// </summary>
        /// <returns>The build that was started.</returns>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API token.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        /// <param name="branch">The branch.</param>
        /// <param name="environmentVariables">The environment variables.</param>
        [CakeMethodAlias]
        public static AppVeyorBuild AppVeyorStartBuildLatestCommit(this ICakeContext context, string appVeyorApiToken, string accountName, string projectSlug, string branch = null, Dictionary<string, string> environmentVariables = null)
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            return appVeyor.StartBuildLatestCommit(new AppVeyorBuildRequestLatestCommit
            {
                AccountName = accountName,
                Branch = branch,
                EnvironmentVariables = environmentVariables ?? new Dictionary<string, string>(),
                ProjectSlug = projectSlug,
            }).Result;
        }

        /// <summary>
        /// Starts a build for a specific commit.
        /// </summary>
        /// <returns>The build that was started.</returns>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API token.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        /// <param name="commitId">The commit hash to build.</param>
        /// <param name="branch">The branch.</param>
        [CakeMethodAlias]
        public static AppVeyorBuild AppVeyorStartBuildSpecificCommit(this ICakeContext context, string appVeyorApiToken, string accountName, string projectSlug, string commitId, string branch = "master")
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            return appVeyor.StartBuildSpecificCommit(new AppVeyorBuildRequestSpecificCommit
            {
                AccountName = accountName,
                Branch = branch ?? "master",
                CommitId = commitId,
                ProjectSlug = projectSlug,
            }).Result;
        }

        /// <summary>
        /// Starts a build for the given GitHub pull request.
        /// </summary>
        /// <returns>The build that was started.</returns>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API token.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        /// <param name="pullRequestId">The GitHub pull request id.</param>
        [CakeMethodAlias]
        public static AppVeyorBuild AppVeyorStartBuildPullRequest(this ICakeContext context, string appVeyorApiToken, string accountName, string projectSlug, int pullRequestId)
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            return appVeyor.StartBuildPullRequest(new AppVeyorBuildRequestPullRequest
            {
                AccountName = accountName,
                PullRequestId = pullRequestId,
                ProjectSlug = projectSlug,
            }).Result;
        }

        /// <summary>
        /// Cancels a build.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API token.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        /// <param name="buildVersion">The build version of the build to cancel.</param>
        [CakeMethodAlias]
        public static void AppVeyorCancelBuild(this ICakeContext context, string appVeyorApiToken, string accountName, string projectSlug, string buildVersion)
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            appVeyor.CancelBuild(accountName, projectSlug, buildVersion).Wait();
        }

        /// <summary>
        /// Gets the specified Deployment.
        /// </summary>
        /// <returns>The deployment.</returns>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API token.</param>
        /// <param name="deploymentId">The id of the deployment to get.</param>
        [CakeMethodAlias]
        public static AppVeyorProjectDeployment AppVeyorDeployment(this ICakeContext context, string appVeyorApiToken, int deploymentId)
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            return appVeyor.GetDeployment(deploymentId).Result;
        }

        /// <summary>
        /// Gets the Deployments for a given project.
        /// </summary>
        /// <returns>The project's Deployments.</returns>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API token.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        [CakeMethodAlias]
        public static AppVeyorProjectDeployments AppVeyorProjectDeployments(this ICakeContext context, string appVeyorApiToken, string accountName, string projectSlug)
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            return appVeyor.GetProjectDeployments(accountName, projectSlug).Result;
        }

        /// <summary>
        /// Starts a Deployment.
        /// </summary>
        /// <returns>The deployment that was started.</returns>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API token.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        /// <param name="environmentName">The environment name to deploy to.</param>
        /// <param name="buildVersion">The build version to deploy.</param>
        /// <param name="buildJobId">The build job identifier (optional).</param>
        /// <param name="environmentVariables">The environment variables.</param>
        [CakeMethodAlias]
        public static AppVeyorDeployment AppVeyorStartDeployment(this ICakeContext context, string appVeyorApiToken, string accountName, string projectSlug, string environmentName, string buildVersion, string buildJobId = null, Dictionary<string, string> environmentVariables = null)
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            return appVeyor.StartDeployment(new AppVeyorStartDeploymentRequest
            {
                AccountName = accountName,
                BuildJobId = buildJobId,
                BuildVersion = buildVersion,
                EnvironmentName = environmentName,
                EnvironmentVariables = environmentVariables ?? new Dictionary<string, string>(),
                ProjectSlug = projectSlug,
            }).Result;
        }

        /// <summary>
        /// Cancels a Deployment.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API token.</param>
        /// <param name="deploymentId">The identifier of the Deployment to cancel.</param>
        [CakeMethodAlias]
        public static void AppVeyorCancelDeployment(this ICakeContext context, string appVeyorApiToken, int deploymentId)
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            appVeyor.CancelDeployment(new AppVeyorCancelDeploymentRequest
            {
                DeploymentId = deploymentId,
            }).Wait();
        }

        /// <summary>
        /// Gets Environments.
        /// </summary>
        /// <returns>The environments.</returns>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API token.</param>
        [CakeMethodAlias]
        public static List<AppVeyorEnvironment> AppVeyorEnvironments(this ICakeContext context, string appVeyorApiToken)
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            return appVeyor.GetEnvironments().Result;
        }

        /// <summary>
        /// Gets Deployments for the given Environment.
        /// </summary>
        /// <returns>The deployments for the given environment.</returns>
        /// <param name="context">The context.</param>
        /// <param name="appVeyorApiToken">The API token.</param>
        /// <param name="deploymentEnvironmentId">The identifier of the environment to get deployments of.</param>
        [CakeMethodAlias]
        public static AppVeyorEnvironmentDeployments AppVeyorEnvironmentDeployments(this ICakeContext context, string appVeyorApiToken, int deploymentEnvironmentId)
        {
            var appVeyor = AppVeyorClient.Create(appVeyorApiToken);
            return appVeyor.GetEnvironmentDeployments(deploymentEnvironmentId).Result;
        }
    }
}
