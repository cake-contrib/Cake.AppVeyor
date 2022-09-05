using System;
using System.Collections.Generic;

namespace Cake.AppVeyor
{
    /// <summary>
    /// Build.
    /// </summary>
    public class AppVeyorBuild
    {
        /// <summary>
        /// Gets or sets the build identifier.
        /// </summary>
        /// <value>The build identifier.</value>
        public int BuildId { get; set; }

        /// <summary>
        /// Gets or sets the jobs.
        /// </summary>
        /// <value>The jobs.</value>
        public List<AppVeyorJob> Jobs { get; set; }

        /// <summary>
        /// Gets or sets the build number.
        /// </summary>
        /// <value>The build number.</value>
        public int BuildNumber { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the branch.
        /// </summary>
        /// <value>The branch.</value>
        public string Branch { get; set; }

        /// <summary>
        /// Gets or sets the commit identifier (md5 hash).
        /// </summary>
        /// <value>The commit identifier.</value>
        public string CommitId { get; set; }

        /// <summary>
        /// Gets or sets the name of the author.
        /// </summary>
        /// <value>The name of the author.</value>
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets the author username.
        /// </summary>
        /// <value>The author username.</value>
        public string AuthorUsername { get; set; }

        /// <summary>
        /// Gets or sets the name of the committer.
        /// </summary>
        /// <value>The name of the committer.</value>
        public string CommitterName { get; set; }

        /// <summary>
        /// Gets or sets the committer username.
        /// </summary>
        /// <value>The committer username.</value>
        public string CommitterUsername { get; set; }

        /// <summary>
        /// Gets or sets the time of the commit.
        /// </summary>
        /// <value>The time of the commit.</value>
        public DateTime? Committed { get; set; }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>The messages.</value>
        public List<string> Messages { get; set; }

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
        /// <value>The finished.</value>
        public DateTime? Finished { get; set; }

        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        /// <value>The created time.</value>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets the updated time.
        /// </summary>
        /// <value>The updated time.</value>
        public DateTime? Updated { get; set; }
    }
}
