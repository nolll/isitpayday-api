# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
    
# Copy csproj and restore as distinct layers
COPY Api/*.csproj ./Api
RUN dotnet restore Api/Api.csproj
    
COPY . ./
RUN dotnet publish Api/Api.csproj -c Release -o out
    
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "isitpaydayapi.dll"]
