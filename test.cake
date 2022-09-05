#reference "BuildArtifacts/temp/_PublishedLibraries/Cake.AppVeyor/net6.0/Cake.AppVeyor.dll"
#addin nuget:?package=Refit&version=4.6.58
#addin nuget:?package=Newtonsoft.Json&version=11.0.2

public class BuildData
{
    public string AppVeyorApiToken { get; set; }
    public string AccountName { get; set; }
    public string ProjectSlug { get; set; }

    public BuildData()
    {
        AccountName = "GaryEwanPark";
        ProjectSlug = "resharperreports";
    }
}

Setup<BuildData>(setupContext => {
    return new BuildData() 
    {
        AppVeyorApiToken = EnvironmentVariable<string>("APPVEYOR_API_TOKEN", "")
    };
});

Task("Default")
    .IsDependentOn("Get-Projects")
    .IsDependentOn("Get-Environments")
    .IsDependentOn("Clear-Cache");

Task("Get-Projects")
    .Does<BuildData>((data) =>
{
    if (string.IsNullOrEmpty(data.AppVeyorApiToken))
    {
        Error("Unable to find AppVeyor API Token");
        return;
    }

    Information("Found the following projects:");

    foreach(var project in AppVeyorProjects(data.AppVeyorApiToken))
    {
        Information("Name: {0}, Repository: {1}, Slug: {2}", project.Name, project.RepositoryName, project.Slug);
    }
});

Task("Get-Environments")
    .Does<BuildData>((data) =>
{
    if (string.IsNullOrEmpty(data.AppVeyorApiToken))
    {
        Error("Unable to find AppVeyor API Token");
        return;
    }

    Information("Found the following environments:");

    foreach(var environment in AppVeyorEnvironments(data.AppVeyorApiToken))
    {
        Information("Name: {0}, Provider: {1}", environment.Name, environment.Provider);
    }
});

Task("Clear-Cache")
    .Does<BuildData>((data) =>
{
    if (string.IsNullOrEmpty(data.AppVeyorApiToken))
    {
        Error("Unable to find AppVeyor API Token");
        return;
    }

    Information("Clearing Project Cache...");

    AppVeyorClearCache(data.AppVeyorApiToken, data.AccountName, data.ProjectSlug);
});

RunTarget("Default");