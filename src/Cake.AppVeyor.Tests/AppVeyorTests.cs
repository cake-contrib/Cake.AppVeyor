using Xunit;
using System;
using System.Linq;
using Cake.AppVeyor;
using Cake.AppVeyor.Fakes;

namespace Cake.AppVeyor.Tests
{
    public class AppVeyorTests : IDisposable
    {
        FakeCakeContext context;

        const string accountName = "Redth";
        const string projectSlug = "cake-json";

        readonly string apiToken = Keys.AppVeyorApiToken;

        public AppVeyorTests()
        {
            context = new FakeCakeContext();
        }

        public void Dispose()
        {
            context.DumpLogs();
        }

        [Fact]
        public void GetProjects ()
        {
            var projects = context.CakeContext.AppVeyorProjects (apiToken);

            Assert.NotNull (projects);
            Assert.NotEmpty (projects);
        }

        [Fact]
        public void GetProjectHistoryWithPaging ()
        {
            const int pageSize = 2;

            var pageOne = context.CakeContext.AppVeyorProjectHistory (apiToken, accountName, projectSlug, pageSize);
            Assert.NotNull (pageOne);
            Assert.NotEmpty(pageOne.Builds);
            Console.WriteLine (string.Join (", ", from b in pageOne.Builds select b.BuildId));

            var lastBuild = pageOne.Builds.Last ();

            var pageTwo = context.CakeContext.AppVeyorProjectHistory (apiToken, accountName, projectSlug, pageSize, lastBuild.BuildId);
            Assert.NotNull (pageTwo);
            Assert.NotEmpty(pageTwo.Builds);
            Console.WriteLine (string.Join (", ", from b in pageTwo.Builds select b.BuildId));

            var allOnOne = context.CakeContext.AppVeyorProjectHistory (apiToken, accountName, projectSlug, pageSize * 2);
            Assert.NotNull (allOnOne);
            Assert.NotEmpty (allOnOne.Builds);
            Assert.Equal (pageOne.Builds.Count + pageTwo.Builds.Count, allOnOne.Builds.Count);
            Console.WriteLine (string.Join (", ", from b in allOnOne.Builds select b.BuildId));
        }

        [Fact]
        public void GetProjectLastSuccessfulBuild ()
        {
            var last = context.CakeContext.AppVeyorProjectLastSuccessfulBuild (apiToken, accountName, projectSlug, null, 2350947);

            Assert.NotNull (last);
            Assert.Equal (2331918, last.Build.BuildId);
        }

        [Fact]
        public void GetEnvironments ()
        {
            var environments = context.CakeContext.AppVeyorEnvironments (apiToken);

            Assert.NotNull (environments);
            Assert.NotEmpty (environments);
        }

        [Fact]
        public void GetProjectLastBuildBranch ()
        {
            var build = context.CakeContext.AppVeyorProjectLastBranchBuild (apiToken, accountName, projectSlug, "master"); 

            Assert.NotNull (build);
            Assert.Equal ("master", build.Build.Branch);
        }

        [Fact]
        public void GetProjectBuildByVersion ()
        {
            var build = context.CakeContext.AppVeyorProjectBuildByVersion (apiToken, accountName, projectSlug, "1.0.2.1");

            Assert.NotNull (build);
            Assert.Equal ("success", build.Build.Status);
        }

        [Fact]
        public void GetDeployment ()
        {
            var deployment = context.CakeContext.AppVeyorDeployment (apiToken, 202857);
            Assert.Equal (projectSlug, deployment.Project.Slug);
            Assert.Equal ("NuGet", deployment.Deployment.Environment.Provider);
            Assert.NotNull (deployment);
        }

        [Fact]
        public void GetProjectDeployments ()
        {
            var projectDeployments = context.CakeContext.AppVeyorProjectDeployments (apiToken, accountName, projectSlug);

            Assert.NotNull (projectDeployments);
            Assert.NotNull (projectDeployments.Project);
            Assert.NotNull (projectDeployments.Deployments);
            Assert.NotEmpty (projectDeployments.Deployments);

            Assert.Equal (projectSlug, projectDeployments.Project.Slug);

            Assert.Contains(projectDeployments.Deployments, d => d != null && d.Environment != null && d.Environment.Provider == "NuGet");
        }

        [Fact]
        public void GetEnvironmentDeployments ()
        {
            var envDeployments = context.CakeContext.AppVeyorEnvironmentDeployments (apiToken, 6662);

            Assert.NotNull (envDeployments);
            Assert.NotNull (envDeployments.Environment);
            Assert.NotNull (envDeployments.Deployments);
            Assert.NotEmpty (envDeployments.Deployments);

            Assert.Contains(envDeployments.Deployments, d => d != null && d.Project.Slug == projectSlug);
        }
    }
}

