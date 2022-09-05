using System;
using Cake.Core.IO;
using Cake.Core;
using System.Collections.Generic;
using Cake.Core.Tooling;
using Cake.Testing;
using NSubstitute;

namespace Cake.AppVeyor.Fakes
{
    public class FakeCakeContext
    {
        private ICakeContext context;
        private FakeLog log;
        private DirectoryPath testsDir;

        public FakeCakeContext()
        {
            testsDir = new DirectoryPath(System.IO.Path.GetFullPath(AppContext.BaseDirectory));

            log = new FakeLog();
            var fileSystem = new FileSystem();
            var environment = new CakeEnvironment(new CakePlatform(), new CakeRuntime());
            var globber = new Globber(fileSystem, environment);
            var args = new FakeCakeArguments();
            var registry = new WindowsRegistry();
            var toolRepo = new ToolRepository(environment);
            var config = new Core.Configuration.CakeConfigurationProvider(fileSystem, environment).CreateConfiguration(testsDir, new Dictionary<string, string>());
            var toolResolutionStrategy = new ToolResolutionStrategy(fileSystem, environment, globber, config, log);
            var toolLocator = new ToolLocator(environment, toolRepo, toolResolutionStrategy);
            var processRunner = new ProcessRunner(fileSystem, environment, log, toolLocator, config);
            var data = Substitute.For<ICakeDataService>();
            context = new CakeContext(fileSystem, environment, globber, log, args, processRunner, registry, toolLocator, data, config);
            context.Environment.WorkingDirectory = testsDir;
        }

        public DirectoryPath WorkingDirectory
        {
            get { return testsDir; }
        }

        public ICakeContext CakeContext
        {
            get { return context; }
        }

        public string GetLogs()
        {
            return string.Join(Environment.NewLine, log.Entries);
        }

        public void DumpLogs()
        {
            foreach (var m in log.Entries)
            {
                Console.WriteLine(m);
            }
        }
    }
}
