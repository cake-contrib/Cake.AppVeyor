using System.Collections.Generic;
using Newtonsoft.Json;

namespace Cake.AppVeyor
{
    class AppVeyorBuildRequestLatestCommit
    {
        public AppVeyorBuildRequestLatestCommit ()
        {
            Branch = "master";
            EnvironmentVariables = new Dictionary<string, string> ();
        }

        [JsonProperty ("accountName")]
        public string AccountName { get; set; }
        [JsonProperty ("projectSlug")]
        public string ProjectSlug { get; set; }
        [JsonProperty ("branch")]
        public string Branch { get; set; }
        [JsonProperty ("environmentVariables")]
        public Dictionary<string, string> EnvironmentVariables { get;set; }
    }
}
