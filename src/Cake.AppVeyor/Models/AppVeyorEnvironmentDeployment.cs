
namespace Cake.AppVeyor
{
    /// <summary>
    /// Environment Deployment information.
    /// </summary>
    public class AppVeyorEnvironmentDeployment
    {
        /// <summary>
        /// Gets or sets the environment.
        /// </summary>
        /// <value>The environment.</value>
        public AppVeyorEnvironment Environment { get; set; }
        /// <summary>
        /// Gets or sets the deployment.
        /// </summary>
        /// <value>The deployment.</value>
        public AppVeyorDeployment Deployment { get; set; }
    }
}
