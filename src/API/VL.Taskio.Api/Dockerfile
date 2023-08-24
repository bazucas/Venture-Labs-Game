FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80

# copy all .csproj files and restore as distinct layers.   Use of the same COPY command
# for every dockerfile in the project to take advantage of docker caching
COPY VL.Taskio.sln VL.Taskio.sln
COPY src/API/VL.Taskio.Api/VL.Taskio.Api.csproj src/API/VL.Taskio.Api/VL.Taskio.Api.csproj
COPY src/Core/VL.Taskio.Application/VL.Taskio.Application.csproj src/Core/VL.Taskio.Application/VL.Taskio.Application.csproj
COPY src/Core/VL.Taskio.Domain/VL.Taskio.Domain.csproj src/Core/VL.Taskio.Domain/VL.Taskio.Domain.csproj
COPY src/Infrastructure/VL.Taskio.Identity/VL.Taskio.Identity.csproj src/Infrastructure/VL.Taskio.Identity/VL.Taskio.Identity.csproj
COPY src/Infrastructure/VL.Taskio.Infrastructure/VL.Taskio.Infrastructure.csproj src/Infrastructure/VL.Taskio.Infrastructure/VL.Taskio.Infrastructure.csproj
COPY src/Infrastructure/VL.Taskio.Persistence/VL.Taskio.Persistence.csproj src/Infrastructure/VL.Taskio.Persistence/VL.Taskio.Persistence.csproj

COPY tests/VL.Taskio.Persistence.IntegrationTests tests/VL.Taskio.Persistence.IntegrationTests
COPY tests/VL.Taskio.Application.UnitTests tests/VL.Taskio.Application.UnitTests


# Restore package deps
RUN dotnet restore VL.Taskio.sln

# Copy the app folders over
COPY src/API/VL.Taskio.Api src/API/VL.Taskio.Api
COPY src/Core/VL.Taskio.Application src/Core/VL.Taskio.Application
COPY src/Infrastructure/VL.Taskio.Infrastructure src/Infrastructure/VL.Taskio.Infrastructure
COPY src/Infrastructure/VL.Taskio.Identity src/Infrastructure/VL.Taskio.Identity
COPY src/Infrastructure/VL.Taskio.Persistence src/Infrastructure/VL.Taskio.Persistence

WORKDIR /app/src/API/VL.Taskio.Api
RUN dotnet publish -c Release -o /app/src/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/src/out .
ENTRYPOINT [ "dotnet", "VL.Taskio.Api.dll" ]