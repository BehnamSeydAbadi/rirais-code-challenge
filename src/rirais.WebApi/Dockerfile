FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY Directory.Build.props . 
COPY Directory.Packages.props . 

COPY ["rirais.WebApi/rirais.WebApi.csproj", "rirais.WebApi/"]
COPY ["rirais.Infrastructure/rirais.Infrastructure.csproj", "rirais.Infrastructure/"]
COPY ["rirais.Application/rirais.Application.csproj", "rirais.Application/"]
COPY ["rirais.Domain/rirais.Domain.csproj", "rirais.Domain/"]
RUN dotnet restore "rirais.WebApi/rirais.WebApi.csproj"
COPY . .
WORKDIR "/src/rirais.WebApi"
RUN dotnet build "./rirais.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./rirais.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY rirais.WebApi/https/aspnetapp.pfx /rirais.WebApi/https/aspnetapp.pfx 
ENTRYPOINT ["dotnet", "rirais.WebApi.dll"]
