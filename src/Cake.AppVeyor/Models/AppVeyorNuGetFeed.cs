using System;

namespace Cake.AppVeyor
{
    /// <summary>
    /// NuGet Feed
    /// </summary>
    public class AppVeyorNuGetFeed
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Cake.AppVeyor.AppVeyorNuGetFeed"/> publishing enabled.
        /// </summary>
        /// <value><c>true</c> if publishing enabled; otherwise, <c>false</c>.</value>
        public bool PublishingEnabled { get; set; }
        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>The create time</value>
        public DateTime? Created { get; set; }
    }
}
