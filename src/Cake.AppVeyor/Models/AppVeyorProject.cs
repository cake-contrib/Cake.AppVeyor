using System;
using System.Collections.Generic;

namespace Cake.AppVeyor
{
    /// <summary>
    /// Project.
    /// </summary>
    public class AppVeyorProject
    {
        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>The project identifier.</value>
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>The account identifier.</value>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>The name of the account.</value>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the builds.
        /// </summary>
        /// <value>The builds.</value>
        public List<AppVeyorBuild> Builds { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        /// <value>The slug.</value>
        public string Slug { get; set; }

        /// <summary>
        /// Gets or sets the type of the repository.
        /// </summary>
        /// <value>The type of the repository.</value>
        public string RepositoryType { get; set; }

        /// <summary>
        /// Gets or sets the repository SCM.
        /// </summary>
        /// <value>The repository SCM.</value>
        public string RepositoryScm { get; set; }

        /// <summary>
        /// Gets or sets the name of the repository.
        /// </summary>
        /// <value>The name of the repository.</value>
        public string RepositoryName { get; set; }

        /// <summary>
        /// Gets or sets the repository branch.
        /// </summary>
        /// <value>The repository branch.</value>
        public string RepositoryBranch { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is private.
        /// </summary>
        /// <value><c>true</c> if this instance is private; otherwise, <c>false</c>.</value>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Cake.AppVeyor.AppVeyorProject"/> should skip branches
        /// without appveyor yml.
        /// </summary>
        /// <value><c>true</c> if skip branches without appveyor yml; otherwise, <c>false</c>.</value>
        public bool SkipBranchesWithoutAppveyorYml { get; set; }

        /// <summary>
        /// Gets or sets the nu get feed.
        /// </summary>
        /// <value>The nu get feed.</value>
        public AppVeyorNuGetFeed NuGetFeed { get; set; }

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>The create time.</value>
        public DateTime? Created { get; set; }
    }
}
