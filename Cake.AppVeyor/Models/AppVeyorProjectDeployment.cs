
namespace Cake.AppVeyor
{
    /// <summary>
    /// Project Deployment
    /// </summary>
    public class AppVeyorProjectDeployment
    {
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public AppVeyorProject Project { get; set; }
        /// <summary>
        /// Gets or sets the deployment.
        /// </summary>
        /// <value>The deployment.</value>
        public AppVeyorDeployment Deployment { get; set; }
    }
}
