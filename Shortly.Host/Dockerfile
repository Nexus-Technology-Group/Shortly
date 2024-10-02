FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Shortly.Host/Shortly.Host.csproj", "Shortly.Host/"]
COPY ["Shortly.Codes.DAL.Mongo/Shortly.Codes.DAL.Mongo.csproj", "Shortly.Codes.DAL.Mongo/"]
COPY ["Shortly.Codes.DAL.Abstractions/Shortly.Codes.DAL.Abstractions.csproj", "Shortly.Codes.DAL.Abstractions/"]
COPY ["Shortly.Codes.Application/Shortly.Codes.Application.csproj", "Shortly.Codes.Application/"]
COPY ["Shortly.Codes.Domain/Shortly.Codes.Domain.csproj", "Shortly.Codes.Domain/"]
RUN dotnet restore "Shortly.Host/Shortly.Host.csproj"
COPY . .
WORKDIR "/src/Shortly.Host"
RUN dotnet build "Shortly.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Shortly.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shortly.Host.dll"]
