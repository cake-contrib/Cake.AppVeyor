using System.Collections.Generic;

namespace Cake.AppVeyor
{
    /// <summary>
    /// Project History.
    /// </summary>
    public class AppVeyorProjectHistory
    {
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public AppVeyorProject Project { get; set; }

        /// <summary>
        /// Gets or sets the builds.
        /// </summary>
        /// <value>The builds.</value>
        public List<AppVeyorBuild> Builds { get; set; }
    }
}
