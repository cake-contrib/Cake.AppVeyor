using Newtonsoft.Json;

namespace Cake.AppVeyor
{
    public class AppVeyorBuildRequestSpecificCommit
    {
        public AppVeyorBuildRequestSpecificCommit ()
        {
            Branch = "master";
        }

        [JsonProperty ("accountName")]
        public string AccountName { get; set; }
        [JsonProperty ("projectSlug")]
        public string ProjectSlug { get; set; }
        [JsonProperty ("branch")]
        public string Branch { get; set; }
        [JsonProperty ("commitId")]
        public string CommitId { get;set; }
    }
}
