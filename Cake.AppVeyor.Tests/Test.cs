using NUnit.Framework;
using System;
using System.Linq;
using Cake.AppVeyor;

namespace Cake.AppVeyor.Tests
{
    [TestFixture]
    public class Test
    {
        FakeCakeContext context;

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
            var projects = context.CakeContext.AppVeyorProjects (new AppVeyorSettings { ApiToken = Keys.AppVeyorApiToken });

            Assert.IsNotNull (projects);
            Assert.Greater (projects.Count, 0);
        }

        [Test]
        public void GetProjectHistoryWithPaging ()
        {
            const string accountName = "Redth";
            const string projectSlug = "cake-json";
            const int pageSize = 2;

            var s = new AppVeyorSettings {
                ApiToken = Keys.AppVeyorApiToken
            };

            var pageOne = context.CakeContext.AppVeyorProjectHistory (s, accountName, projectSlug, pageSize);
            Assert.IsNotNull (pageOne);
            Assert.Greater (pageOne.Builds.Count, 0);
            Console.WriteLine (string.Join (", ", from b in pageOne.Builds select b.BuildId));

            var lastBuild = pageOne.Builds.Last ();

            var pageTwo = context.CakeContext.AppVeyorProjectHistory (s, accountName, projectSlug, pageSize, lastBuild.BuildId);
            Assert.IsNotNull (pageTwo);
            Assert.Greater (pageTwo.Builds.Count, 0);
            Console.WriteLine (string.Join (", ", from b in pageTwo.Builds select b.BuildId));

            var allOnOne = context.CakeContext.AppVeyorProjectHistory (s, accountName, projectSlug, pageSize * 2);
            Assert.IsNotNull (allOnOne);
            Assert.Greater (allOnOne.Builds.Count, 0);
            Assert.AreEqual (pageOne.Builds.Count + pageTwo.Builds.Count, allOnOne.Builds.Count);
            Console.WriteLine (string.Join (", ", from b in allOnOne.Builds select b.BuildId));
        }

        [Test]
        public void GetProjectLastSuccessfulBuild ()
        {
            const string accountName = "Redth";
            const string projectSlug = "cake-json";

            var s = new AppVeyorSettings {
                ApiToken = Keys.AppVeyorApiToken
            };

            var last = context.CakeContext.AppVeyorProjectLastSuccessfulBuild (s, accountName, projectSlug, null, 2350947);
            Assert.IsNotNull (last);
            Assert.AreEqual (2331918, last.Build.BuildId);
        }
    }
}

