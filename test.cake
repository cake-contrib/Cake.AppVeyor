#reference "BuildArtifacts/temp/_PublishedLibraries/Cake.AppVeyor/net10.0/Cake.AppVeyor.dll"
#addin nuget:?package=Refit&version=10.1.6

public class BuildData
{
    public string AppVeyorApiToken { get; set; }
    public AppVeyorSettings Settings { get; set; }
    public string AccountName { get; set; }
    public string ProjectSlug { get; set; }

    public BuildData()
    {
        AccountName = "GaryEwanPark";
        ProjectSlug = "resharperreports";
    }
}

Setup<BuildData>(setupContext => {
    var token = EnvironmentVariable<string>("APPVEYOR_API_TOKEN", "");
    return new BuildData()
    {
        AppVeyorApiToken = token,
        Settings = new AppVeyorSettings { ApiToken = token }
    };
});

bool RequireToken(BuildData data)
{
    if (string.IsNullOrEmpty(data.AppVeyorApiToken))
    {
        Error("Unable to find AppVeyor API Token");
        return false;
    }

    return true;
}

Task("Default")
    .IsDependentOn("Get-Projects")
    .IsDependentOn("Get-Projects-WithSettings")
    .IsDependentOn("Get-Project-History")
    .IsDependentOn("Get-Project-History-WithSettings")
    .IsDependentOn("Get-Project-LastBuild")
    .IsDependentOn("Get-Project-LastBuild-WithSettings")
    .IsDependentOn("Get-Project-LastSuccessfulBuild")
    .IsDependentOn("Get-Project-LastSuccessfulBuild-WithSettings")
    .IsDependentOn("Get-Project-LastBranchBuild")
    .IsDependentOn("Get-Project-BuildByVersion")
    .IsDependentOn("Get-Project-Deployments")
    .IsDependentOn("Get-Deployment-ById")
    .IsDependentOn("Get-Environments")
    .IsDependentOn("Get-Environment-Deployments")
    .IsDependentOn("Clear-Cache");

Task("Get-Projects")
    .Does<BuildData>((data) =>
{
    if (!RequireToken(data))
    {
        return;
    }

    var projects = AppVeyorProjects(data.AppVeyorApiToken);
    Information("Found {0} project(s) (token overload).", projects.Count);
    foreach(var project in projects)
    {
        Information("  Name: {0}, Slug: {1}", project.Name, project.Slug);
    }
});

Task("Get-Projects-WithSettings")
    .Does<BuildData>((data) =>
{
    if (!RequireToken(data))
    {
        return;
    }

    var projects = AppVeyorProjects(data.Settings);
    Information("Found {0} project(s) (settings overload).", projects.Count);
});

Task("Get-Project-History")
    .Does<BuildData>((data) =>
{
    if (!RequireToken(data))
    {
        return;
    }

    var history = AppVeyorProjectHistory(data.AppVeyorApiToken, data.AccountName, data.ProjectSlug, 5);
    Information("Project history (token overload): project={0}, builds={1}", history.Project?.Name, history.Builds?.Count);
});

Task("Get-Project-History-WithSettings")
    .Does<BuildData>((data) =>
{
    if (!RequireToken(data))
    {
        return;
    }

    var history = AppVeyorProjectHistory(data.Settings, data.AccountName, data.ProjectSlug, 5);
    Information("Project history (settings overload): project={0}, builds={1}", history.Project?.Name, history.Builds?.Count);
});

Task("Get-Project-LastBuild")
    .Does<BuildData>((data) =>
{
    if (!RequireToken(data))
    {
        return;
    }

    var last = AppVeyorProjectLastBuild(data.AppVeyorApiToken, data.AccountName, data.ProjectSlug);
    Information("Last build (token overload): version={0}, status={1}", last.Build?.Version, last.Build?.Status);
});

Task("Get-Project-LastBuild-WithSettings")
    .Does<BuildData>((data) =>
{
    if (!RequireToken(data))
    {
        return;
    }

    var last = AppVeyorProjectLastBuild(data.Settings, data.AccountName, data.ProjectSlug);
    Information("Last build (settings overload): version={0}, status={1}", last.Build?.Version, last.Build?.Status);
});

Task("Get-Project-LastSuccessfulBuild")
    .Does<BuildData>((data) =>
{
    if (!RequireToken(data))
    {
        return;
    }

    var last = AppVeyorProjectLastSuccessfulBuild(data.AppVeyorApiToken, data.AccountName, data.ProjectSlug);
    Information("Last successful build (token overload): {0}", last?.Build?.Version ?? "(none found)");
});

Task("Get-Project-LastSuccessfulBuild-WithSettings")
    .Does<BuildData>((data) =>
{
    if (!RequireToken(data))
    {
        return;
    }

    var last = AppVeyorProjectLastSuccessfulBuild(data.Settings, data.AccountName, data.ProjectSlug);
    Information("Last successful build (settings overload): {0}", last?.Build?.Version ?? "(none found)");
});

Task("Get-Project-LastBranchBuild")
    .Does<BuildData>((data) =>
{
    if (!RequireToken(data))
    {
        return;
    }

    var build = AppVeyorProjectLastBranchBuild(data.AppVeyorApiToken, data.AccountName, data.ProjectSlug, "master");
    Information("Last build on master: version={0}, status={1}", build?.Build?.Version, build?.Build?.Status);
});

Task("Get-Project-BuildByVersion")
    .IsDependentOn("Get-Project-LastBuild")
    .Does<BuildData>((data) =>
{
    if (!RequireToken(data))
    {
        return;
    }

    var lastVersion = AppVeyorProjectLastBuild(data.AppVeyorApiToken, data.AccountName, data.ProjectSlug)?.Build?.Version;
    if (string.IsNullOrEmpty(lastVersion))
    {
        Information("Skipping — no recent build version available.");
        return;
    }

    var build = AppVeyorProjectBuildByVersion(data.AppVeyorApiToken, data.AccountName, data.ProjectSlug, lastVersion);
    Information("Build by version {0}: status={1}", lastVersion, build?.Build?.Status);
});

Task("Get-Project-Deployments")
    .Does<BuildData>((data) =>
{
    if (!RequireToken(data))
    {
        return;
    }

    var deployments = AppVeyorProjectDeployments(data.AppVeyorApiToken, data.AccountName, data.ProjectSlug);
    Information("Project deployments: project={0}, count={1}", deployments?.Project?.Name, deployments?.Deployments?.Count);
});

Task("Get-Deployment-ById")
    .IsDependentOn("Get-Environments")
    .Does<BuildData>((data) =>
{
    if (!RequireToken(data))
    {
        return;
    }

    // Source a real deployment ID from the env-level query, since the project-level
    // deployment list doesn't always include the inner AppVeyorDeployment object.
    var envs = AppVeyorEnvironments(data.AppVeyorApiToken);
    var firstEnv = envs?.FirstOrDefault();
    AppVeyorDeployment firstDeployment = null;
    if (firstEnv != null)
    {
        var envDeployments = AppVeyorEnvironmentDeployments(data.AppVeyorApiToken, firstEnv.DeploymentEnvironmentId);
        firstDeployment = envDeployments?.Deployments?.FirstOrDefault()?.Deployment;
    }

    if (firstDeployment == null)
    {
        Information("Skipping — no deployment available to fetch.");
        return;
    }

    var deployment = AppVeyorDeployment(data.AppVeyorApiToken, firstDeployment.DeploymentId);
    Information("Deployment {0}: project={1}, status={2}",
        firstDeployment.DeploymentId, deployment?.Project?.Name, deployment?.Deployment?.Status);
});

Task("Get-Environments")
    .Does<BuildData>((data) =>
{
    if (!RequireToken(data))
    {
        return;
    }

    var envs = AppVeyorEnvironments(data.AppVeyorApiToken);
    Information("Found {0} environment(s) (token overload).", envs.Count);
    foreach(var environment in envs)
    {
        Information("  Name: {0}, Provider: {1}", environment.Name, environment.Provider);
    }
});

Task("Get-Environment-Deployments")
    .IsDependentOn("Get-Environments")
    .Does<BuildData>((data) =>
{
    if (!RequireToken(data))
    {
        return;
    }

    var envs = AppVeyorEnvironments(data.AppVeyorApiToken);
    var first = envs?.FirstOrDefault();
    if (first == null)
    {
        Information("Skipping — no environment available.");
        return;
    }

    var envDeployments = AppVeyorEnvironmentDeployments(data.AppVeyorApiToken, first.DeploymentEnvironmentId);
    Information("Environment {0} deployments: count={1}", first.Name, envDeployments?.Deployments?.Count);
});

Task("Clear-Cache")
    .Does<BuildData>((data) =>
{
    if (!RequireToken(data))
    {
        return;
    }

    Information("Clearing project cache for {0}/{1}...", data.AccountName, data.ProjectSlug);
    AppVeyorClearCache(data.AppVeyorApiToken, data.AccountName, data.ProjectSlug);
});

RunTarget("Default");
