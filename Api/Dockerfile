FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
    
COPY Api/*.csproj ./Api
RUN dotnet restore Api/Api.csproj
    
COPY . ./
RUN dotnet publish Api/Api.csproj -c Release -o out
    
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "isitpaydayapi.dll"]
