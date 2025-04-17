# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

# Define build arguments for username and password
ARG BUILD_ID
ARG BUILD_CONFIGURATION=Release

COPY ["Src/Presentation/WebApi/WebApi.csproj", "Src/Presentation/WebApi/"]
COPY ["Src/Core/Application/Application.csproj", "Src/Core/Application/"]
COPY ["Src/Core/Domain/Domain.csproj", "Src/Core/Domain/"]
COPY ["Src/Infrastructure/Infrastructure.Persistence/Infrastructure.Persistence.csproj", "Src/Infrastructure/Infrastructure.Persistence/"]
COPY ["Tests/FunctionalTests/FunctionalTests.csproj", "Tests/FunctionalTests/"]
COPY ["Tests/IntegrationTests/IntegrationTests.csproj", "Tests/IntegrationTests/"]
COPY ["Tests/UnitTests/UnitTests.csproj", "Tests/UnitTests/"]

# Restore dependencies
RUN dotnet restore "Src/Presentation/WebApi/WebApi.csproj"

COPY . .
RUN dotnet build "Src/Presentation/WebApi/WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build


FROM build AS publish
RUN dotnet publish "Src/Presentation/WebApi/WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "WebApi.dll"]