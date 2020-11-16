# Contributing

## Prerequisites

-   Docker for [Mac](https://docs.docker.com/docker-for-mac/) or [Windows](https://docs.docker.com/docker-for-windows/) can be used to run `dotnet` CLI commands:

## Using Test Environment

To use the test environment, use the \*Client constructor that includes passing in the apiOrigin, e.g.

```c#
string apiOrigin = "https://auth-api-test.blinkm.io"
FormsClient formsClient = new FormsClient(ACCESS_KEY, SECRET_KEY, apiOrigin);
```

## Running Tests

Create a file called `.env` in the root directory with the following values configured

**NOTE**: Keys are available in the [1Blink E2E Tests (DO NOT DELETE)](https://console-test.oneblink.io/organisations/5c58beb2ff59481100000002/keys) account.

```sh
ACCESS_KEY=YOUR_ACCESS_KEY
SECRET_KEY=YOUR_SECRET_KEY
ONEBLINK_API_ORIGIN=https://auth-api-test.blinkm.io
ONEBLINK_PDF_API_ORIGIN=https://pdf-test.blinkm.io
```

Run in the project directory

```
dotnet restore
dotnet test
```

can be run if you have .Net Core Runtime 2.2.0 installed.
You can also switch the `<TargetFramework>` value in ./OneBlink.SDK.Tests/OneBlink.SDK.Tests.csProj to the version you have installed eg. `netcoreapp3.1` to get testing working

Otherwise

```
docker run -it --rm -v "$PWD":/usr/src/oneblink-sdk-dotnet -w  /usr/src/oneblink-sdk-dotnet mcr.microsoft.com/dotnet/core/sdk:2.2 dotnet build -c Release
docker run -it --rm -v "$PWD":/usr/src/oneblink-sdk-dotnet -w  /usr/src/oneblink-sdk-dotnet mcr.microsoft.com/dotnet/core/sdk:2.2 dotnet test
```

## Release Process

1.  After cloning the repository, checkout `master` branch

    ```
    git checkout master
    ```

1.  Ensure you have the latest version of code

    ```
    git pull
    ```

1.  Update SDK Version

    #### Production Release

    1.  Update the [Changelog](./CHANGELOG.md) by replacing `Unreleased` with `1.0.1 (YYYY-MM-DD)`

    1.  Update the `<PackageVersion>` tag in `./OneBlink.SDK/OneBlink.SDK.csproj` with `1.0.1`

    1.  Update the `<AssemblyVersion>` tag in `./OneBlink.SDK/OneBlink.SDK.csproj` with `1.0.1.0`

    #### Beta Release

    1.  Update the `<PackageVersion>` tag in `./OneBlink.SDK/OneBlink.SDK.csproj` with `1.0.1-beta.1`

    1.  Update the `<AssemblyVersion>` tag in `./OneBlink.SDK/OneBlink.SDK.csproj` with `1.0.0.2`

1.  Push changes to the `master` branch

    ```
    git add -A
    git commit -m "[RELEASE] 1.0.1"
    git push
    ```

1.  Follow the steps below for automated or manual deployments

## Deployment

### Automated

1.  Create a **Git Tag** to trigger the build and deployment process e.g. `1.0.1`

### Manual

1.  Clone this repository

1.  Remove any existing builds locally by deleting the `./OneBlink.SDK/bin` directory

1.  Build source

    ```sh
    docker run -it --rm -v "$PWD":/usr/src/oneblink-sdk-dotnet -w  /usr/src/oneblink-sdk-dotnet mcr.microsoft.com/dotnet/core/sdk:2.2 dotnet build -c Release
    ```

1.  Build NuGet package:

    ```sh
    docker run -it --rm -v "$PWD":/usr/src/oneblink-sdk-dotnet -w  /usr/src/oneblink-sdk-dotnet mcr.microsoft.com/dotnet/core/sdk:2.2 dotnet pack -c Release
    ```

1.  Publish NuGet package, replacing `[NUGET_API_KEY]` with an authorised API key:

    ```sh
    docker run -it --rm -v "$PWD":/usr/src/oneblink-sdk-dotnet -w  /usr/src/oneblink-sdk-dotnet mcr.microsoft.com/dotnet/core/sdk:2.2 dotnet nuget push ./OneBlink.SDK/bin/Release/OneBlink.SDK.*.nupkg --api-key [NUGET_API_KEY]
    ```
