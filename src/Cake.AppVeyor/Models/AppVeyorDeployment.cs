using System;
using System.Collections.Generic;

namespace Cake.AppVeyor
{
    /// <summary>
    /// Deployment.
    /// </summary>
    public class AppVeyorDeployment
    {
        /// <summary>
        /// Gets or sets the deployment identifier.
        /// </summary>
        /// <value>The deployment identifier.</value>
        public int DeploymentId { get; set; }

        /// <summary>
        /// Gets or sets the build.
        /// </summary>
        /// <value>The build.</value>
        public AppVeyorBuild Build { get; set; }

        /// <summary>
        /// Gets or sets the environment.
        /// </summary>
        /// <value>The environment.</value>
        public AppVeyorEnvironment Environment { get; set; }

        /// <summary>
        /// Gets or sets the jobs.
        /// </summary>
        /// <value>The jobs.</value>
        public List<AppVeyorJob> Jobs { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        public DateTime? Started { get; set; }

        /// <summary>
        /// Gets or sets the finish time.
        /// </summary>
        /// <value>The finish time.</value>
        public DateTime? Finished { get; set; }

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
