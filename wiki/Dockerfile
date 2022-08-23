#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN sed -i "s|MinProtocol = TLSv1.2|MinProtocol = TLSv1|g" /etc/ssl/openssl.cnf && \
    sed -i 's|CipherString = DEFAULT@SECLEVEL=2|CipherString = DEFAULT@SECLEVEL=1|g' /etc/ssl/openssl.cnf

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/API/WazenAdmin.Api/WazenAdmin.Api.csproj", "src/API/WazenAdmin.Api/"]
COPY ["src/Infrastructure/WazenAdmin.Infrastructure/WazenAdmin.Infrastructure.csproj", "src/Infrastructure/WazenAdmin.Infrastructure/"]
COPY ["src/Core/WazenAdmin.Application/WazenAdmin.Application.csproj", "src/Core/WazenAdmin.Application/"]
COPY ["src/Core/WazenAdmin.Domain/WazenAdmin.Domain.csproj", "src/Core/WazenAdmin.Domain/"]
COPY ["src/Infrastructure/WazenAdmin.Identity/WazenAdmin.Identity.csproj", "src/Infrastructure/WazenAdmin.Identity/"]
COPY ["src/Infrastructure/WazenAdmin.Persistence/WazenAdmin.Persistence.csproj", "src/Infrastructure/WazenAdmin.Persistence/"]
RUN dotnet restore "src/API/WazenAdmin.Api/WazenAdmin.Api.csproj"
COPY . .
WORKDIR "/src/src/API/WazenAdmin.Api"
RUN dotnet build "WazenAdmin.Api.csproj" -c Release -o /app/build
#RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf

FROM build AS publish
RUN dotnet publish "WazenAdmin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WazenAdmin.Api.dll"]
