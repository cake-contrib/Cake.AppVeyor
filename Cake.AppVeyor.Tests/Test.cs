using NUnit.Framework;
using System;
using System.Linq;
using Cake.AppVeyor;

namespace Cake.AppVeyor.Tests
{
    [TestFixture]
    public class Test
    {
        const string accountName = "Redth";
        const string projectSlug = "cake-json";

        FakeCakeContext context;
        readonly string apiToken = Keys.AppVeyorApiToken;

        [SetUp]
        public void Setup ()
        {
            context = new FakeCakeContext ();           
        }

        [TearDown]
        public void Teardown ()
        {
            context.DumpLogs ();
        }

        [Test]
        public void GetProjects ()
        {
            var projects = context.CakeContext.AppVeyorProjects (apiToken);

            Assert.IsNotNull (projects);
            Assert.Greater (projects.Count, 0);
        }

        [Test]
        public void GetProjectHistoryWithPaging ()
        {
            const int pageSize = 2;

            var pageOne = context.CakeContext.AppVeyorProjectHistory (apiToken, accountName, projectSlug, pageSize);
            Assert.IsNotNull (pageOne);
            Assert.Greater (pageOne.Builds.Count, 0);
            Console.WriteLine (string.Join (", ", from b in pageOne.Builds select b.BuildId));

            var lastBuild = pageOne.Builds.Last ();

            var pageTwo = context.CakeContext.AppVeyorProjectHistory (apiToken, accountName, projectSlug, pageSize, lastBuild.BuildId);
            Assert.IsNotNull (pageTwo);
            Assert.Greater (pageTwo.Builds.Count, 0);
            Console.WriteLine (string.Join (", ", from b in pageTwo.Builds select b.BuildId));

            var allOnOne = context.CakeContext.AppVeyorProjectHistory (apiToken, accountName, projectSlug, pageSize * 2);
            Assert.IsNotNull (allOnOne);
            Assert.Greater (allOnOne.Builds.Count, 0);
            Assert.AreEqual (pageOne.Builds.Count + pageTwo.Builds.Count, allOnOne.Builds.Count);
            Console.WriteLine (string.Join (", ", from b in allOnOne.Builds select b.BuildId));
        }

        [Test]
        public void GetProjectLastSuccessfulBuild ()
        {
            var last = context.CakeContext.AppVeyorProjectLastSuccessfulBuild (apiToken, accountName, projectSlug, null, 2350947);

            Assert.IsNotNull (last);
            Assert.AreEqual (2331918, last.Build.BuildId);
        }

        [Test]
        public void GetEnvironments ()
        {
            var environments = context.CakeContext.AppVeyorEnvironments (apiToken);

            Assert.IsNotNull (environments);
            Assert.Greater (environments.Count, 0);
        }

        [Test]
        public void GetProjectLastBuildBranch ()
        {
            var build = context.CakeContext.AppVeyorProjectLastBranchBuild (apiToken, accountName, projectSlug, "master"); 

            Assert.IsNotNull (build);
            Assert.AreEqual (build.Build.Branch, "master");
        }

        [Test]
        public void GetProjectBuildByVersion ()
        {
            var build = context.CakeContext.AppVeyorProjectBuildByVersion (apiToken, accountName, projectSlug, "1.0.2.1");

            Assert.IsNotNull (build);
            Assert.AreEqual (build.Build.Status, "success");
        }

        [Test]
        public void GetDeployment ()
        {
            var deployment = context.CakeContext.AppVeyorDeployment (apiToken, 202857);
            Assert.AreEqual (projectSlug, deployment.Project.Slug);
            Assert.AreEqual ("NuGet", deployment.Deployment.Environment.Provider);
            Assert.IsNotNull (deployment);
        }

        [Test]
        public void GetProjectDeployments ()
        {
            var projectDeployments = context.CakeContext.AppVeyorProjectDeployments (apiToken, accountName, projectSlug);

            Assert.IsNotNull (projectDeployments);
            Assert.IsNotNull (projectDeployments.Project);
            Assert.IsNotNull (projectDeployments.Deployments);
            Assert.Greater (projectDeployments.Deployments.Count, 0);

            Assert.True (projectDeployments.Deployments.Any (d => d != null && d.Deployment != null && d.Deployment.DeploymentId == 202857));
            Assert.AreEqual (projectSlug, projectDeployments.Project.Slug);

            Assert.True (projectDeployments.Deployments.Any (d => d != null && d.Environment != null && d.Environment.Provider == "NuGet"));
        }

        [Test]
        public void GetEnvironmentDeployments ()
        {
            var envDeployments = context.CakeContext.AppVeyorEnvironmentDeployments (apiToken, 6662);

            Assert.IsNotNull (envDeployments);
            Assert.IsNotNull (envDeployments.Environment);
            Assert.IsNotNull (envDeployments.Deployments);
            Assert.Greater (envDeployments.Deployments.Count, 0);

            Assert.True (envDeployments.Deployments.Any (d => d != null && d.Project.Slug == projectSlug));
            Assert.True (envDeployments.Deployments.Any (d => d != null && d.Deployment.DeploymentId == 202857));
        }
    }
}

