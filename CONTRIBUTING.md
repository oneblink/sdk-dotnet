# Contributing

## Using Test Environment

To use the test environment, use the \*Client constructor that includes passing in the apiOrigin, e.g.

```c#
FormsClient formsClient = new FormsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
```

## Running Tests

### Prerequisites

-   .Net runtime installed (at least one of .Net Core 3.1, .Net 5.0, .Net 6.0)

### Environment variables

Create a file called `.env` in the root directory with the following values configured:

**NOTE**: Key secret is available in the [1Blink E2E Tests (DO NOT DELETE)](https://console.test.oneblink.io/organisations/5c58beb2ff59481100000002/keys) account. Find the matching key based on the id below:

```sh
ACCESS_KEY=5cf9d5e60bf82f1100000001
SECRET_KEY=YOUR_SECRET_KEY
```

### Target frameworks

By default the tests will run agaisnt runtimes .Net Core 3.1, .Net 5.0, and .Net 6.0
You can modify the `<TargetFramework>` value in ./OneBlink.SDK.Tests/OneBlink.SDK.Tests.csProj to the runtime/s you have available eg. `net6.0`

### Running tests

```
dotnet test
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

    1.  Update the `<PackageVersion>` tag in [`OneBlink.SDK.csproj`](./OneBlink.SDK/OneBlink.SDK.csproj) with `1.0.1`

    1.  Update the `<AssemblyVersion>` tag in [`OneBlink.SDK.csproj`](./OneBlink.SDK/OneBlink.SDK.csproj) with `1.0.1.0`

    #### Beta Release

    1.  Update the `<PackageVersion>` tag in [`OneBlink.SDK.csproj`](./OneBlink.SDK/OneBlink.SDK.csproj) with `1.0.1-beta.1`

    1.  Update the `<AssemblyVersion>` tag in [`OneBlink.SDK.csproj`](./OneBlink.SDK/OneBlink.SDK.csproj) with `1.0.1.1`

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

-   .Net SDK installed (at least one of .Net Core 3.1, .Net 5.0, .Net 6.0)

1.  Clone this repository

1.  Remove any existing builds locally by deleting the `./OneBlink.SDK/bin` directory

1.  Build NuGet package:

    ```
    dotnet pack -c Release
    ```

1.  Publish NuGet package, replacing `[NUGET_API_KEY]` with an authorised API key:

    ```sh
    dotnet nuget push ./OneBlink.SDK/bin/Release/OneBlink.SDK.*.nupkg --api-key [NUGET_API_KEY]
    ```
