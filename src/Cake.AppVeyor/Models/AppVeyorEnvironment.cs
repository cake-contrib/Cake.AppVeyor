using System;

namespace Cake.AppVeyor
{
    /// <summary>
    /// Environment
    /// </summary>
    public class AppVeyorEnvironment
    {
        /// <summary>
        /// Gets or sets the deployment environment identifier.
        /// </summary>
        /// <value>The deployment environment identifier.</value>
        public int DeploymentEnvironmentId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public string Provider { get; set; }
        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>The create time.</value>
        public DateTime? Created { get; set; }
        /// <summary>
        /// Gets or sets the update time.
        /// </summary>
        /// <value>The update time.</value>
        public DateTime? Updated { get; set; }
    }
}
