using Newtonsoft.Json;

namespace Cake.AppVeyor
{
    /// <summary>
    /// Provides a class to describe the properties of a pull request build.
    /// </summary>
    public class AppVeyorBuildRequestPullRequest
    {
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
        /// Gets or sets the Pull Request ID.
        /// </summary>
        [JsonProperty("pullRequestId")]
        public int PullRequestId { get; set; }
    }
}
