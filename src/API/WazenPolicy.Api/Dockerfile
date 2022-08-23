#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN sed -i "s|MinProtocol = TLSv1.2|MinProtocol = TLSv1|g" /etc/ssl/openssl.cnf && \
    sed -i 's|CipherString = DEFAULT@SECLEVEL=2|CipherString = DEFAULT@SECLEVEL=1|g' /etc/ssl/openssl.cnf

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/API/WazenPolicy.Api/WazenPolicy.Api.csproj", "src/API/WazenPolicy.Api/"]
COPY ["src/Infrastructure/WazenPolicy.Infrastructure/WazenPolicy.Infrastructure.csproj", "src/Infrastructure/WazenPolicy.Infrastructure/"]
COPY ["src/Core/WazenPolicy.Application/WazenPolicy.Application.csproj", "src/Core/WazenPolicy.Application/"]
COPY ["src/Core/WazenPolicy.Domain/WazenPolicy.Domain.csproj", "src/Core/WazenPolicy.Domain/"]
COPY ["src/Infrastructure/WazenPolicy.Identity/WazenPolicy.Identity.csproj", "src/Infrastructure/WazenPolicy.Identity/"]
COPY ["src/Infrastructure/WazenPolicy.Persistence/WazenPolicy.Persistence.csproj", "src/Infrastructure/WazenPolicy.Persistence/"]
RUN dotnet restore "src/API/WazenPolicy.Api/WazenPolicy.Api.csproj"
COPY . .
WORKDIR "/src/src/API/WazenPolicy.Api"
RUN dotnet build "WazenPolicy.Api.csproj" -c Release -o /app/build
#RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf

FROM build AS publish
RUN dotnet publish "WazenPolicy.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WazenPolicy.Api.dll"]
