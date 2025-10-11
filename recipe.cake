#load nuget:https://pkgs.dev.azure.com/cake-contrib/Home/_packaging/addins/nuget/v3/index.json?package=Cake.Recipe&version=4.1.0-alpha0036

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "Cake.AppVeyor",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.AppVeyor",
                            appVeyorAccountName: "cakecontrib",
                            shouldRunDotNetPack: true,
                            shouldRunInspectCode: false,
                            testFilePattern: "DO_NOT_RUN_TESTS",
                            preferredBuildProviderType: BuildProviderType.GitHubActions);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* -[FakeItEasy]*",
                            testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
                            testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");
Build.RunDotNet();
