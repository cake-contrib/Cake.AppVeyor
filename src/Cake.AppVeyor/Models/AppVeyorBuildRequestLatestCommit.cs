using System.Collections.Generic;
using Newtonsoft.Json;

namespace Cake.AppVeyor
{
    /// <summary>
    /// Provides a class to describe the properties of the latest commit of an AppVeyor build.
    /// </summary>
    public class AppVeyorBuildRequestLatestCommit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppVeyorBuildRequestLatestCommit"/> class.
        /// </summary>
        public AppVeyorBuildRequestLatestCommit()
        {
            Branch = "master";
            EnvironmentVariables = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets the AppVeyor Account Name.
        /// </summary>
        [JsonProperty("accountName")]
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the AppVeyor Project Slug.
        /// </summary>
        [JsonProperty("projectSlug")]
        public string ProjectSlug { get; set; }

        /// <summary>
        /// Gets or sets the branch name for the project.
        /// </summary>
        [JsonProperty("branch")]
        public string Branch { get; set; }

        /// <summary>
        /// Gets or sets the environment variables.
        /// </summary>
        [JsonProperty("environmentVariables")]
        public Dictionary<string, string> EnvironmentVariables { get; set; }
    }
}
