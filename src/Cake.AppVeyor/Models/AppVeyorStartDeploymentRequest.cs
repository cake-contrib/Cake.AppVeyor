using System.Collections.Generic;
using Newtonsoft.Json;

namespace Cake.AppVeyor
{
    public class AppVeyorStartDeploymentRequest
    {
        public AppVeyorStartDeploymentRequest()
        {
            EnvironmentVariables = new Dictionary<string, string>();
        }

        [JsonProperty("environmentName")]
        public string EnvironmentName { get; set; }

        [JsonProperty("accountName")]
        public string AccountName { get; set; }

        [JsonProperty("projectSlug")]
        public string ProjectSlug { get; set; }

        [JsonProperty("buildVersion")]
        public string BuildVersion { get; set; }

        [JsonProperty("buildJobId")]
        public string BuildJobId { get; set; }

        [JsonProperty("environmentVariables")]
        public Dictionary<string, string> EnvironmentVariables { get; set; }
    }
}
