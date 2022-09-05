using Newtonsoft.Json;

namespace Cake.AppVeyor
{
    /// <summary>
    /// Provides a class to describe the properties of a deployment to be cancelled.
    /// </summary>
    public class AppVeyorCancelDeploymentRequest
    {
        /// <summary>
        /// Gets or sets of the deployment ID.
        /// </summary>
        [JsonProperty("deploymentId")]
        public int DeploymentId { get; set; }
    }
}
