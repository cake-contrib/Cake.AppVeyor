using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core.Annotations;
using Cake.Core;

namespace Cake.AppVeyor
{
    /// <summary>
    /// JSON related cake aliases.
    /// </summary>
    [CakeAliasCategory ("AppVeyor")]
    public static class AppVeyorAliases
    {
        /// <summary>
        /// Gets all projects
        /// </summary>
        /// <returns>The projects.</returns>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static List<Project> GetProjects (this ICakeContext context, AppVeyorSettings settings)
        {
            var appVeyor = AppVeyorClient.Create (settings.ApiToken);
            return appVeyor.GetProjects ().Result;
        }

        /// <summary>
        /// Gets the project build history
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
        public static ProjectHistory GetProjectHistory (this ICakeContext context, AppVeyorSettings settings, string accountName, string projectSlug, int recordsPerPage, int? startBuildId = null, string branch = null)
        {
            var appVeyor = AppVeyorClient.Create (settings.ApiToken);
            return appVeyor.GetProjectHistory (accountName, projectSlug, recordsPerPage, startBuildId, branch).Result;
        }

        /// <summary>
        /// Gets the last build of the project
        /// </summary>
        /// <returns>The project's last build.</returns>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        [CakeMethodAlias]
        public static ProjectBuild GetProjectLastBuild (this ICakeContext context, AppVeyorSettings settings, string accountName, string projectSlug)
        {
            var appVeyor = AppVeyorClient.Create (settings.ApiToken);
            return appVeyor.GetProjectLastBuild (accountName, projectSlug).Result;
        }

        /// <summary>
        /// Gets the last successful build of the project
        /// </summary>
        /// <returns>The project's last successful build.</returns>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="projectSlug">The project slug.</param>
        /// <param name="branch">The branch.</param>
        /// <param name="beforeBuildId">The build identifier to start looking for a successful build after.</param>
        [CakeMethodAlias]
        public static ProjectBuild GetProjectLastSuccessfulBuild (this ICakeContext context, AppVeyorSettings settings, string accountName, string projectSlug, string branch = null, int? beforeBuildId = null)
        {
            var appVeyor = AppVeyorClient.Create (settings.ApiToken);

            ProjectBuild lastSuccess = null;
            int? startBuildId = beforeBuildId;

            while (lastSuccess == null) {
                var history = appVeyor.GetProjectHistory (accountName, projectSlug, 2, startBuildId: startBuildId).Result;

                if (history == null || history.Builds == null || history.Builds.Count <= 0)
                    break;

                foreach (var build in history.Builds) {
                    if (build.Status.Equals ("success", StringComparison.InvariantCultureIgnoreCase)) {
                        lastSuccess = new ProjectBuild {
                            Project = history.Project,
                            Build = build,
                        };
                        break;
                    }
                }

                startBuildId = history.Builds.Last ().BuildId;
            }

            return lastSuccess;
        }
    }
}
