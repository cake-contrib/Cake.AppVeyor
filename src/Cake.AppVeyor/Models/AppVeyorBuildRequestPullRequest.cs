using Newtonsoft.Json;

namespace Cake.AppVeyor
{
    public class AppVeyorBuildRequestPullRequest
    {
        [JsonProperty("accountName")]
        public string AccountName { get; set; }

        [JsonProperty("projectSlug")]
        public string ProjectSlug { get; set; }

        [JsonProperty("pullRequestId")]
        public int PullRequestId { get; set; }
    }
}
