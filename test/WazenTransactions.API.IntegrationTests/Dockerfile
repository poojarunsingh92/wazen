#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["test/WazenTransactions.API.IntegrationTests/WazenTransactions.API.IntegrationTests.csproj", "test/WazenTransactions.API.IntegrationTests/"]
COPY ["src/Infrastructure/WazenTransactions.Persistence/WazenTransactions.Persistence.csproj", "src/Infrastructure/WazenTransactions.Persistence/"]
COPY ["src/Core/WazenTransactions.Application/WazenTransactions.Application.csproj", "src/Core/WazenTransactions.Application/"]
COPY ["src/Core/WazenTransactions.Domain/WazenTransactions.Domain.csproj", "src/Core/WazenTransactions.Domain/"]
COPY ["src/API/WazenTransactions.Api/WazenTransactions.Api.csproj", "src/API/WazenTransactions.Api/"]
COPY ["src/Infrastructure/WazenTransactions.Infrastructure/WazenTransactions.Infrastructure.csproj", "src/Infrastructure/WazenTransactions.Infrastructure/"]
COPY ["src/Infrastructure/WazenTransactions.Identity/WazenTransactions.Identity.csproj", "src/Infrastructure/WazenTransactions.Identity/"]
RUN dotnet restore "test/WazenTransactions.API.IntegrationTests/WazenTransactions.API.IntegrationTests.csproj"
COPY . .
WORKDIR "/src/test/WazenTransactions.API.IntegrationTests"
RUN dotnet build "WazenTransactions.API.IntegrationTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WazenTransactions.API.IntegrationTests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WazenTransactions.API.IntegrationTests.dll"]
