# Contributing

## Using Test Environment

To use the test environment, use the \*Client constructor that includes passing in the apiOrigin, e.g.

```c#
FormsClient formsClient = new FormsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
```

## Running Tests

### Prerequisites

- .Net runtime installed (at least one of .Net 8.0, .Net 9.0)

## Security linter

- Install [Microsoft DevSkim](https://github.com/Microsoft/DevSkim) for inline linting

### Environment variables

Create a file called `.env` in the root directory with the following values configured:

**NOTE**: Key secret is available in the [1Blink E2E Tests (DO NOT DELETE)](https://console.test.oneblink.io/organisations/5c58beb2ff59481100000002/keys) account. Find the matching key based on the id below:

```sh
ACCESS_KEY=5cf9d5e60bf82f1100000001
SECRET_KEY=YOUR_SECRET_KEY
```

### Target frameworks

By default the tests will run against runtimes .Net 8.0, and .Net 9.0
You can modify the `<TargetFramework>` value in ./OneBlink.SDK.Tests/OneBlink.SDK.Tests.csProj to the runtime/s you have available eg. `net8.0`

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

1.  Install the latest OneBlink Release CLI

    ```
    npm i -g @oneblink/release-cli@3.x.x
    ```

1.  Release the repository. Ensure you use a `beta` pre-release e.g. `1.0.0-beta.1` if releasing a Beta version.

    ```
    oneblink-release repository
    ```

## Deployment

### Automated

The release process will trigger the build and deployment process.

### Manual

#### Prerequisites

- .Net SDK installed (at least one of .Net 8.0, .Net 9.0)

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
