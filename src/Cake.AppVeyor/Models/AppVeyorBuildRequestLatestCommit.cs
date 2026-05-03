using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("accountName")]
        public string? AccountName { get; set; }

        /// <summary>
        /// Gets or sets the AppVeyor Project Slug.
        /// </summary>
        [JsonPropertyName("projectSlug")]
        public string? ProjectSlug { get; set; }

        /// <summary>
        /// Gets or sets the branch name for the project.
        /// </summary>
        [JsonPropertyName("branch")]
        public string? Branch { get; set; }

        /// <summary>
        /// Gets or sets the environment variables.
        /// </summary>
        [JsonPropertyName("environmentVariables")]
        public Dictionary<string, string> EnvironmentVariables { get; set; }
    }
}
