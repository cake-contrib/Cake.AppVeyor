using Cake.Core;
using Cake.Core.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Cake.AppVeyor.Fakes
{
	[TestFixture]
	public abstract class TestFixtureBase
	{
		FakeCakeContext context;

		public ICakeContext Cake { get { return context.CakeContext; } }

		[OneTimeSetUp]
		public void RunBeforeAnyTests()
		{
			Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(typeof(TestFixtureBase).Assembly.Location);
		}

		[SetUp]
		public void Setup()
		{
			context = new FakeCakeContext();

			//var dp = new DirectoryPath("./testdata");
			//var d = context.CakeContext.FileSystem.GetDirectory(dp);

			//if (d.Exists)
			//	d.Delete(true);

			//d.Create();
		}

		[TearDown]
		public void Teardown()
		{
			context.DumpLogs();
		}
	}
}