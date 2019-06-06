# .Net OneBlink SDK | Deployment

## Release Process

### Instructions

1.  After cloning the repository, checkout `master` branch

    ```
    git checkout master
    ```

1.  Ensure you have the latest version of code

    ```
    git pull
    ```

1.  Update the [Changelog](../CHANGELOG.md) by replacing `Unreleased` with `1.0.1 (YYYY-MM-DD)`

1.  Update the `<PackageVersion>` tag in `./OneBlink.SDK/OneBlink.SDK.csproj.csproj` with `1.0.1`

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

#### Prerequisites

## Prerequisites

- Docker for [Mac](https://docs.docker.com/docker-for-mac/) or [Windows](https://docs.docker.com/docker-for-windows/)

#### Instructions

1.  Clone this repository

1.  Build source

    ```sh
    docker run -it --rm -v "$PWD":/usr/src/oneblink-sdk-dotnet -w  /usr/src/oneblink-sdk-dotnet mcr.microsoft.com/dotnet/core/sdk:2.2 dotnet build -c Release
    ```

1.  Build NuGet package:

    ```sh
    docker run -it --rm -v "$PWD":/usr/src/oneblink-sdk-dotnet -w  /usr/src/oneblink-sdk-dotnet mcr.microsoft.com/dotnet/core/sdk:2.2 dotnet pack -c Release
    ```

1.  Publish NuGet package:

    ```sh
    docker run -it --rm -v "$PWD":/usr/src/oneblink-sdk-dotnet -w  /usr/src/oneblink-sdk-dotnet mcr.microsoft.com/dotnet/core/sdk:2.2 dotnet nuget push ./OneBlink.SDK/bin/Release/OneBlink.SDK.*.nupkg --api-key [NUGET_API_KEY]
    ```
