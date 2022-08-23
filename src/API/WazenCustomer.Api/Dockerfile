#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

RUN sed -i "s|MinProtocol = TLSv1.2|MinProtocol = TLSv1|g" /etc/ssl/openssl.cnf && \
    sed -i 's|CipherString = DEFAULT@SECLEVEL=2|CipherString = DEFAULT@SECLEVEL=1|g' /etc/ssl/openssl.cnf

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/API/WazenCustomer.Api/WazenCustomer.Api.csproj", "src/API/WazenCustomer.Api/"]
COPY ["src/Infrastructure/WazenCustomer.Identity/WazenCustomer.Identity.csproj", "src/Infrastructure/WazenCustomer.Identity/"]
COPY ["src/Core/WazenCustomer.Application/WazenCustomer.Application.csproj", "src/Core/WazenCustomer.Application/"]
COPY ["src/Core/WazenCustomer.Domain/WazenCustomer.Domain.csproj", "src/Core/WazenCustomer.Domain/"]
COPY ["src/Infrastructure/WazenCustomer.Infrastructure/WazenCustomer.Infrastructure.csproj", "src/Infrastructure/WazenCustomer.Infrastructure/"]
COPY ["src/Infrastructure/WazenCustomer.Persistence/WazenCustomer.Persistence.csproj", "src/Infrastructure/WazenCustomer.Persistence/"]
RUN dotnet restore "src/API/WazenCustomer.Api/WazenCustomer.Api.csproj"
COPY . .
WORKDIR "/src/src/API/WazenCustomer.Api"
RUN dotnet build "WazenCustomer.Api.csproj" -c Release -o /app/build
#RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf

FROM build AS publish
RUN dotnet publish "WazenCustomer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WazenCustomer.Api.dll"]