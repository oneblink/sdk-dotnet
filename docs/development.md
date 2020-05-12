# OneBlink .Net SDK | Development

## Prerequisites

-   Docker for [Mac](https://docs.docker.com/docker-for-mac/) or [Windows](https://docs.docker.com/docker-for-windows/) can be used to run `dotnet` CLI commands:

## Configuring Local Scripts

Create a file called `.env` in the root directory with the following values configured (NOTE: Keys are available from 1Blink E2E Tests (DO NOT DELETE) organisation in https://console-test.oneblink.io/):

```sh
ACCESS_KEY=YOUR_ACCESS_KEY
SECRET_KEY=YOUR_SECRET_KEY
ONEBLINK_API_ORIGIN=https://auth-api-test.blinkm.io
ONEBLINK_PDF_API_ORIGIN=https://pdf-test.blinkm.io
```

You will also need to include on your script

```
using dotenv.net;

...

DotEnv.Config();
```

## Run Tests

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
docker run -it --rm -v "$PWD":/usr/src/oneblink-sdk-dotnet -w  /usr/src/oneblink-sdk-dotnet mcr.microsoft.com/dotnet/core/sdk:2.2 dotnet dotnet test
```
