using System;
using System.Collections.Generic;

namespace Cake.AppVeyor
{
    public class Build
    {
        public int BuildId { get; set; }
        public List<Job> Jobs { get; set; }
        public int BuildNumber { get; set; }
        public string Version { get; set; }
        public string Message { get; set; }
        public string Branch { get; set; }
        public string CommitId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorUsername { get; set; }
        public string CommitterName { get; set; }
        public string CommitterUsername { get; set; }
        public string Committed { get; set; }
        public List<string> Messages { get; set; }
        public string Status { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Finished { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }

    public class NuGetFeed
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool PublishingEnabled { get; set; }
        public DateTime? Created { get; set; }
    }

    public class Project
    {
        public int ProjectId { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public List<Build> Builds { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string RepositoryType { get; set; }
        public string RepositoryScm { get; set; }
        public string RepositoryName { get; set; }
        public string RepositoryBranch { get; set; }
        public bool IsPrivate { get; set; }
        public bool SkipBranchesWithoutAppveyorYml { get; set; }
        public NuGetFeed NuGetFeed { get; set; }
        public DateTime? Created { get; set; }
    }

    public class Job
    {
        public string JobId { get; set; }
        public string Name { get; set; }
        public bool AllowFailure { get; set; }
        public int MessagesCount { get; set; }
        public int CompilationMessagesCount { get; set; }
        public int CompilationErrorsCount { get; set; }
        public int CompilationWarningsCount { get; set; }
        public int TestsCount { get; set; }
        public int PassedTestsCount { get; set; }
        public int FailedTestsCount { get; set; }
        public int ArtifactsCount { get; set; }
        public string Status { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Finished { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }

    public class ProjectHistory
    {
        public Project Project { get; set; }
        public List<Build> Builds { get; set; }
    }

    public class ProjectBuild
    {
        public Project Project { get; set; }
        public Build Build { get; set; }
    }
}

