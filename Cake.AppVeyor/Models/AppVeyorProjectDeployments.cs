using System.Collections.Generic;

namespace Cake.AppVeyor
{
    /// <summary>
    /// Project Deployments
    /// </summary>
    public class AppVeyorProjectDeployments
    {
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public AppVeyorProject Project { get; set; }
        /// <summary>
        /// Gets or sets the deployments.
        /// </summary>
        /// <value>The deployments.</value>
        public List<AppVeyorEnvironmentDeployment> Deployments { get; set; }
    }
}
