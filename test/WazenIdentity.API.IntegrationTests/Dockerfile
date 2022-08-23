#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["test/WazenIdentity.API.IntegrationTests/WazenIdentity.API.IntegrationTests.csproj", "test/WazenIdentity.API.IntegrationTests/"]
COPY ["src/Infrastructure/WazenIdentity.Persistence/WazenIdentity.Persistence.csproj", "src/Infrastructure/WazenIdentity.Persistence/"]
COPY ["src/Core/WazenIdentity.Application/WazenIdentity.Application.csproj", "src/Core/WazenIdentity.Application/"]
COPY ["src/Core/WazenIdentity.Domain/WazenIdentity.Domain.csproj", "src/Core/WazenIdentity.Domain/"]
COPY ["src/API/WazenIdentity.Api/WazenIdentity.Api.csproj", "src/API/WazenIdentity.Api/"]
COPY ["src/Infrastructure/WazenIdentity.Infrastructure/WazenIdentity.Infrastructure.csproj", "src/Infrastructure/WazenIdentity.Infrastructure/"]
COPY ["src/Infrastructure/WazenIdentity.Identity/WazenIdentity.Identity.csproj", "src/Infrastructure/WazenIdentity.Identity/"]
RUN dotnet restore "test/WazenIdentity.API.IntegrationTests/WazenIdentity.API.IntegrationTests.csproj"
COPY . .
WORKDIR "/src/test/WazenIdentity.API.IntegrationTests"
RUN dotnet build "WazenIdentity.API.IntegrationTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WazenIdentity.API.IntegrationTests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WazenIdentity.API.IntegrationTests.dll"]
