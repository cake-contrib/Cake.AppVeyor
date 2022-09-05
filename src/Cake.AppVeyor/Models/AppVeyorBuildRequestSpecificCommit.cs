using Newtonsoft.Json;

namespace Cake.AppVeyor
{
    /// <summary>
    /// Provides a class to describe the properties of a specific commit of an AppVeyor build.
    /// </summary>
    public class AppVeyorBuildRequestSpecificCommit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppVeyorBuildRequestSpecificCommit"/> class.
        /// </summary>
        public AppVeyorBuildRequestSpecificCommit()
        {
            Branch = "master";
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
        /// Gets or sets the SHA identifying a specific commit.
        /// </summary>
        [JsonProperty("commitId")]
        public string CommitId { get; set; }
    }
}
