using System;

namespace Cake.AppVeyor
{
    /// <summary>
    /// Job
    /// </summary>
    public class AppVeyorJob
    {
        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>The job identifier.</value>
        public string JobId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Cake.AppVeyor.AppVeyorJob"/> allows failure.
        /// </summary>
        /// <value><c>true</c> if allow failure; otherwise, <c>false</c>.</value>
        public bool AllowFailure { get; set; }
        /// <summary>
        /// Gets or sets the messages count.
        /// </summary>
        /// <value>The messages count.</value>
        public int MessagesCount { get; set; }
        /// <summary>
        /// Gets or sets the compilation messages count.
        /// </summary>
        /// <value>The compilation messages count.</value>
        public int CompilationMessagesCount { get; set; }
        /// <summary>
        /// Gets or sets the compilation errors count.
        /// </summary>
        /// <value>The compilation errors count.</value>
        public int CompilationErrorsCount { get; set; }
        /// <summary>
        /// Gets or sets the compilation warnings count.
        /// </summary>
        /// <value>The compilation warnings count.</value>
        public int CompilationWarningsCount { get; set; }
        /// <summary>
        /// Gets or sets the tests count.
        /// </summary>
        /// <value>The tests count.</value>
        public int TestsCount { get; set; }
        /// <summary>
        /// Gets or sets the passed tests count.
        /// </summary>
        /// <value>The passed tests count.</value>
        public int PassedTestsCount { get; set; }
        /// <summary>
        /// Gets or sets the failed tests count.
        /// </summary>
        /// <value>The failed tests count.</value>
        public int FailedTestsCount { get; set; }
        /// <summary>
        /// Gets or sets the artifacts count.
        /// </summary>
        /// <value>The artifacts count.</value>
        public int ArtifactsCount { get; set; }
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
