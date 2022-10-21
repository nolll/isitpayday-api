# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /Api
    
# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore
    
COPY . ./
RUN dotnet publish -c Release -o out
    
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /Api
COPY --from=build-env /Api/out .
ENTRYPOINT ["dotnet", "isitpaydayapi.dll"]
