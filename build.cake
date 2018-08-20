//////////////////////////////////////////////////////////////////////
// TOOLS
//////////////////////////////////////////////////////////////////////
#tool "nuget:?package=GitVersion.CommandLine&version=4.0.0-beta0011"
#addin "nuget:?package=Cake.Npm&version=0.14.0"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

///////////////////////////////////////////////////////////////////////////////
// GLOBAL VARIABLES
///////////////////////////////////////////////////////////////////////////////
var artifactsDir = "./artifacts/";
GitVersion gitVersionInfo;
string nugetVersion;

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////
Setup(context =>
{
    gitVersionInfo = GitVersion(new GitVersionSettings {
        OutputType = GitVersionOutput.Json
    });

  
    nugetVersion = gitVersionInfo.NuGetVersion;

    if(BuildSystem.IsRunningOnAppVeyor)
        BuildSystem.AppVeyor.UpdateBuildVersion(nugetVersion);

    Information("Building Feedz.Client v{0}", nugetVersion);
    Information("Informational Version {0}", gitVersionInfo.InformationalVersion);
});

Teardown(context =>
{
    Information("Finished running tasks.");
});

//////////////////////////////////////////////////////////////////////
//  PRIVATE TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() => {
		CleanDirectory(artifactsDir);
		CleanDirectory("./output");
		CleanDirectories("./src/**/bin");
		CleanDirectories("./src/**/obj");
	});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() => {
		DotNetCoreRestore("./src");
    });

Task("Build")
    .IsDependentOn("Restore")
    .IsDependentOn("Clean")
    .Does(() => {
		DotNetCoreBuild("./src", new DotNetCoreBuildSettings
		{
			Configuration = configuration,
			ArgumentCustomization = args => args.Append($"/p:Version={nugetVersion}")
		});
	});

Task("Pack")
    .IsDependentOn("Build")
    .Does(() => {
        DotNetCorePack("./src/Client", new DotNetCorePackSettings
        {
            Configuration = configuration,
            NoBuild = true,
            OutputDirectory = artifactsDir,
            ArgumentCustomization = args => args.Append($"/p:Version={nugetVersion}")
        });
    });

Task("Publish")
    .WithCriteria(BuildSystem.IsRunningOnAppVeyor)
    .IsDependentOn("Pack")
    .Does(() =>
    {
        NuGetPush($"{artifactsDir}Feedz.Client.{nugetVersion}.nupkg", new NuGetPushSettings {
            Source = "https://f.feedz.io/feedz-io/public/nuget",
            ApiKey = EnvironmentVariable("FeedzApiKey")
        });

        if (string.IsNullOrWhiteSpace(gitVersionInfo.PreReleaseLabel))
        {
            NuGetPush($"{artifactsDir}Feedz.Client.{nugetVersion}.nupkg", new NuGetPushSettings {
                Source = "https://www.nuget.org/api/v2/package",
                ApiKey = EnvironmentVariable("NuGetApiKey")
            });
        }
    });

Task("Default")
    .IsDependentOn("Publish");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////
RunTarget(target);
