#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

RUN sed -i "s|MinProtocol = TLSv1.2|MinProtocol = TLSv1|g" /etc/ssl/openssl.cnf && \
    sed -i 's|CipherString = DEFAULT@SECLEVEL=2|CipherString = DEFAULT@SECLEVEL=1|g' /etc/ssl/openssl.cnf

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/API/WazenTransactions.Api/WazenTransactions.Api.csproj", "src/API/WazenTransactions.Api/"]
COPY ["src/Infrastructure/WazenTransactions.Persistence/WazenTransactions.Persistence.csproj", "src/Infrastructure/WazenTransactions.Persistence/"]
COPY ["src/Core/WazenTransactions.Application/WazenTransactions.Application.csproj", "src/Core/WazenTransactions.Application/"]
COPY ["src/Core/WazenTransactions.Domain/WazenTransactions.Domain.csproj", "src/Core/WazenTransactions.Domain/"]
COPY ["src/Infrastructure/WazenTransactions.Identity/WazenTransactions.Identity.csproj", "src/Infrastructure/WazenTransactions.Identity/"]
COPY ["src/Infrastructure/WazenTransactions.Infrastructure/WazenTransactions.Infrastructure.csproj", "src/Infrastructure/WazenTransactions.Infrastructure/"]
RUN dotnet restore "src/API/WazenTransactions.Api/WazenTransactions.Api.csproj"
COPY . .
WORKDIR "/src/src/API/WazenTransactions.Api"
RUN dotnet build "WazenTransactions.Api.csproj" -c Release -o /app/build
#RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf

FROM build AS publish
RUN dotnet publish "WazenTransactions.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WazenTransactions.Api.dll"]