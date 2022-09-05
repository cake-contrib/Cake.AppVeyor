using System.Collections.Generic;
using Newtonsoft.Json;

namespace Cake.AppVeyor
{
    /// <summary>
    /// Provides a class to describe the properties of a deployment that should be started.
    /// </summary>
    public class AppVeyorStartDeploymentRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppVeyorStartDeploymentRequest"/> class.
        /// </summary>
        public AppVeyorStartDeploymentRequest()
        {
            EnvironmentVariables = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets the AppVeyor Environment Name.
        /// </summary>
        [JsonProperty("environmentName")]
        public string EnvironmentName { get; set; }

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
        /// Gets or sets the AppVeyor Build Version.
        /// </summary>
        [JsonProperty("buildVersion")]
        public string BuildVersion { get; set; }

        /// <summary>
        /// Gets or sets the AppVeyor Build Job ID.
        /// </summary>
        [JsonProperty("buildJobId")]
        public string BuildJobId { get; set; }

        /// <summary>
        /// Gets or sets the environment variables.
        /// </summary>
        [JsonProperty("environmentVariables")]
        public Dictionary<string, string> EnvironmentVariables { get; set; }
    }
}
