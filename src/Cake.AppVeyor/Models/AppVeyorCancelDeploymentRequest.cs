using Newtonsoft.Json;

namespace Cake.AppVeyor
{
    class AppVeyorCancelDeploymentRequest
    {
        [JsonProperty ("deploymentId")]
        public int DeploymentId { get; set; }
    }
}
