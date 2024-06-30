# reproidentlogging

## Purpose

This repo attempts to reproduce a problem I'm repeatedly having with Web API projects.  In short:

* When building locally and running via Visual Studio 2022, the project works fine.
* When using `dotnet build` however, the `Microsoft.IdentityModel.Logging.dll` pulls in the wrong version.
* Strangely, the problem has to be solved by adding a direct reference in a Test library!


## Steps to Setup this Project

## Phase 1 - Basic App & Verify

* Use Windows
* Launch Visual Studio Community 2022
* Create a New Project
* Choose `ASP.NET Core Web API`
* Leave all defaults
* Immediately build the app, notice it launches just fine from within Visual Studio as expected
* Run the following command via command line (feel free to change the output dir):
    * `dotnet build /p:DeployOnBuild=true /p:WebPublishMethod=Package /p:PackageAsSingleFile=true /p:SkipInvalidConfigurations=true /p:OutDir=%userprofile%\desktop\repro`
* Go into that directory and run the .exe - again it should launch just fine

## Phase 2 - Add sub-projects

* Add a new project of type `MSTest Test Project` named `reproidentlogging.Tests`
* Add a new project of type `Class Library` named `api-logic`
* Add a new project of type `MSTest Test Project` named `api-logic.Tests`
* Add some dummy code in `api-logic` and `api-logic.Tests` and something in the core project that calls into `api-logic`
* Immediately build the app, notice it launches just fine from within Visual Studio as expected
* Run the following command via command line (feel free to change the output dir):
    * `dotnet build /p:DeployOnBuild=true /p:WebPublishMethod=Package /p:PackageAsSingleFile=true /p:SkipInvalidConfigurations=true /p:OutDir=%userprofile%\desktop\repro`
* Go into that directory and run the .exe - again it should launch just fine

## Phase 3 - Add Microsoft.Identity.Web

* In the core `reproidentlogging` API project, add a NuGet reference to `Microsoft.Identity.Web` (currently version 2.20.0)
* Add a line in `Program.cs` (see code) to use this library.
* Setup your appsettings.json for `AzureAd` (see appsettings.json)
* Immediately build the app, notice it launches just fine from within Visual Studio as expected
* Run the following command via command line (feel free to change the output dir):
    * `dotnet build /p:DeployOnBuild=true /p:WebPublishMethod=Package /p:PackageAsSingleFile=true /p:SkipInvalidConfigurations=true /p:OutDir=%userprofile%\desktop\repro`
* Go into that directory and run the .exe - again it should launch just fine
