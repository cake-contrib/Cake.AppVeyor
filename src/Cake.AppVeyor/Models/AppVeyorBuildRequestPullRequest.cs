using System.Text.Json.Serialization;

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
        [JsonPropertyName("accountName")]
        public string? AccountName { get; set; }

        /// <summary>
        /// Gets or sets the AppVeyor Project Slug.
        /// </summary>
        [JsonPropertyName("projectSlug")]
        public string? ProjectSlug { get; set; }

        /// <summary>
        /// Gets or sets the Pull Request ID.
        /// </summary>
        [JsonPropertyName("pullRequestId")]
        public int PullRequestId { get; set; }
    }
}
