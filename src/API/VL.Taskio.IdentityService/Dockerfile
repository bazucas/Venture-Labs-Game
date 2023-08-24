FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80

# Copy IdentityService .csproj file and restore dependencies
COPY src/API/VL.Taskio.IdentityService/VL.Taskio.IdentityService.csproj ./src/API/VL.Taskio.IdentityService/
RUN dotnet restore src/API/VL.Taskio.IdentityService/VL.Taskio.IdentityService.csproj

# Copy the IdentityService source code
COPY src/API/VL.Taskio.IdentityService ./src/API/VL.Taskio.IdentityService

# Compile the IdentityService application
WORKDIR /app/src/API/VL.Taskio.IdentityService
RUN dotnet publish -c Release -o /app/src/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/src/out .
ENTRYPOINT [ "dotnet", "VL.Taskio.IdentityService.dll" ]
