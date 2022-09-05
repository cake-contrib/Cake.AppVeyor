using System.Collections.Generic;

namespace Cake.AppVeyor
{
    /// <summary>
    /// Environment Deployments.
    /// </summary>
    public class AppVeyorEnvironmentDeployments
    {
        /// <summary>
        /// Gets or sets the environment.
        /// </summary>
        /// <value>The environment.</value>
        public AppVeyorEnvironment Environment { get; set; }

        /// <summary>
        /// Gets or sets the deployments.
        /// </summary>
        /// <value>The deployments.</value>
        public List<AppVeyorProjectDeployment> Deployments { get; set; }
    }
}
