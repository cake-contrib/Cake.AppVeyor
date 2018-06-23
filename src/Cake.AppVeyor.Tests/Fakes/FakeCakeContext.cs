using System;
using Cake.Core.IO;
using Cake.Core;
using System.Collections.Generic;
using Cake.Core.Tooling;
using Cake.Testing;

namespace Cake.AppVeyor.Fakes
{
internal sealed class CakeDataService : ICakeDataService
    {
        private readonly Dictionary<Type, object> _data;

        public CakeDataService()
        {
            _data = new Dictionary<Type, object>();
        }

        public TData Get<TData>()
            where TData : class
        {
            if (_data.TryGetValue(typeof(TData), out var data))
            {
                if (data is TData typedData)
                {
                    return typedData;
                }
                var message = $"Context data exists but is of the wrong type ({data.GetType().FullName}).";
                throw new InvalidOperationException(message);
            }
            throw new InvalidOperationException("The context data has not been setup.");
        }

        public void Add<TData>(TData value)
            where TData : class
        {
            if (_data.ContainsKey(typeof(TData)))
            {
                var message = $"Context data of type '{typeof(TData).FullName}' has already been registered.";
                throw new InvalidOperationException(message);
            }
            _data.Add(typeof(TData), value);
        }
    }

	public class FakeCakeContext
	{
		ICakeContext context;
		FakeCakeLog log;
		DirectoryPath testsDir;

	

		public FakeCakeContext()
		{
			testsDir = new DirectoryPath(System.IO.Path.GetFullPath(AppContext.BaseDirectory));

			log = new FakeCakeLog();
			var fileSystem = new FileSystem();
			var environment = new CakeEnvironment(new CakePlatform(), new CakeRuntime(), log);
			var globber = new Globber(fileSystem, environment);
			var args = new FakeCakeArguments();
			var processRunner = new ProcessRunner(environment, log);
			var registry = new WindowsRegistry();
			var toolRepo = new ToolRepository(environment);
			var config = new Core.Configuration.CakeConfigurationProvider(fileSystem, environment).CreateConfiguration(testsDir, new Dictionary<string, string>());
			var toolResolutionStrategy = new ToolResolutionStrategy(fileSystem, environment, globber, config);
			var toolLocator = new ToolLocator(environment, toolRepo, toolResolutionStrategy);
			var dataService = new CakeDataService();
			context = new CakeContext(fileSystem, environment, globber, log, args, processRunner, registry, toolLocator, dataService);
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
			return string.Join(Environment.NewLine, log.Messages);
		}

		public void DumpLogs()
		{
			foreach (var m in log.Messages)
				Console.WriteLine(m);
		}
	}
}