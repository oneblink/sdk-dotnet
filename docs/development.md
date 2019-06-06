# .Net OneBlink SDK | Development

## Prerequisites

- Docker for [Mac](https://docs.docker.com/docker-for-mac/) or [Windows](https://docs.docker.com/docker-for-windows/) can be used to run `dotnet` CLI commands:

## Run Tests

```
docker run -it --rm -v "$PWD":/usr/src/oneblink-sdk-dotnet -w  /usr/src/oneblink-sdk-dotnet mcr.microsoft.com/dotnet/core/sdk:2.2 dotnet build -c Release
docker run -it --rm -v "$PWD":/usr/src/oneblink-sdk-dotnet -w  /usr/src/oneblink-sdk-dotnet mcr.microsoft.com/dotnet/core/sdk:2.2 dotnet dotnet test
```
