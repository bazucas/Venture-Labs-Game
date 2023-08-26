FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80

# Copy TaskService .csproj file and restore dependencies
COPY src/Core/VL.Taskio.Application/VL.Taskio.Application.csproj ./src/Core/VL.Taskio.Application/
COPY src/Core/VL.Taskio.Domain/VL.Taskio.Domain.csproj ./src/Core/VL.Taskio.Domain/
COPY src/Infrastructure/VL.Taskio.Identity/VL.Taskio.Identity.csproj ./src/Infrastructure/VL.Taskio.Identity/
COPY src/Infrastructure/VL.Taskio.Infrastructure/VL.Taskio.Infrastructure.csproj ./src/Infrastructure/VL.Taskio.Infrastructure/
COPY src/Infrastructure/VL.Taskio.Persistence/VL.Taskio.Persistence.csproj ./src/Infrastructure/VL.Taskio.Persistence/
COPY src/API/VL.Taskio.TaskService/VL.Taskio.TaskService.csproj ./src/API/VL.Taskio.TaskService/
RUN dotnet restore src/Core/VL.Taskio.Application/VL.Taskio.Application.csproj
RUN dotnet restore src/Core/VL.Taskio.Domain/VL.Taskio.Domain.csproj
RUN dotnet restore src/Infrastructure/VL.Taskio.Identity/VL.Taskio.Identity.csproj
RUN dotnet restore src/Infrastructure/VL.Taskio.Infrastructure/VL.Taskio.Infrastructure.csproj
RUN dotnet restore src/Infrastructure/VL.Taskio.Persistence/VL.Taskio.Persistence.csproj
RUN dotnet restore src/API/VL.Taskio.TaskService/VL.Taskio.TaskService.csproj

# Copy the TaskService source code
COPY src/API/VL.Taskio.TaskService ./src/API/VL.Taskio.TaskService
COPY src/Core/VL.Taskio.Application ./src/Core/VL.Taskio.Application
COPY src/Core/VL.Taskio.Domain ./src/Core/VL.Taskio.Domain
COPY src/Infrastructure/VL.Taskio.Identity ./src/Infrastructure/VL.Taskio.Identity
COPY src/Infrastructure/VL.Taskio.Infrastructure ./src/Infrastructure/VL.Taskio.Infrastructure
COPY src/Infrastructure/VL.Taskio.Persistence ./src/Infrastructure/VL.Taskio.Persistence

# Compile the TaskService application
WORKDIR /app/src/API/VL.Taskio.TaskService
RUN dotnet publish -c Release -o /app/src/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/src/out .
ENTRYPOINT [ "dotnet", "VL.Taskio.TaskService.dll" ]