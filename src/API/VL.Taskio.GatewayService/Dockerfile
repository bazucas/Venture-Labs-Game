FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80

# Copy GatewayService .csproj file and restore dependencies
COPY src/API/VL.Taskio.GatewayService/VL.Taskio.GatewayService.csproj ./src/API/VL.Taskio.GatewayService/
RUN dotnet restore src/API/VL.Taskio.GatewayService/VL.Taskio.GatewayService.csproj

# Copy the GatewayService source code
COPY src/API/VL.Taskio.GatewayService ./src/API/VL.Taskio.GatewayService

# Compile the GatewayService application
WORKDIR /app/src/API/VL.Taskio.GatewayService
RUN dotnet publish -c Release -o /app/src/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/src/out .
ENTRYPOINT [ "dotnet", "VL.Taskio.GatewayService.dll" ]
