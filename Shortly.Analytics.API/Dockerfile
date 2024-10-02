FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Shortly.Analytics.API/Shortly.Analytics.API.csproj", "Shortly.Analytics.API/"]
RUN dotnet restore "Shortly.Analytics.API/Shortly.Analytics.API.csproj"
COPY . .
WORKDIR "/src/Shortly.Analytics.API"
RUN dotnet build "Shortly.Analytics.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Shortly.Analytics.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shortly.Analytics.API.dll"]
