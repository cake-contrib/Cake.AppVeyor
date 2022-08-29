using Newtonsoft.Json;

namespace Cake.AppVeyor
{
    public class AppVeyorCancelDeploymentRequest
    {
        [JsonProperty("deploymentId")]
        public int DeploymentId { get; set; }
    }
}
