
namespace Cake.AppVeyor
{
    /// <summary>
    /// Project Build
    /// </summary>
    public class AppVeyorProjectBuild
    {
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public AppVeyorProject Project { get; set; }
        /// <summary>
        /// Gets or sets the build.
        /// </summary>
        /// <value>The build.</value>
        public AppVeyorBuild Build { get; set; }
    }
}
