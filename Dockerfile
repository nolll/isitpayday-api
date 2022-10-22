FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY IsItPayDayApi.sln ./
COPY Core/*.csproj ./Core/
COPY Api/*.csproj ./Api/
COPY Tests.Common/*.csproj ./Tests.Common/
COPY Core.Tests/*.csproj ./Core.Tests/

RUN dotnet restore .
COPY . .
WORKDIR /Core
RUN dotnet build -c Release -o /app

WORKDIR /Api
RUN dotnet build -c Release -o /app

WORKDIR /Tests.Common
RUN dotnet build -c Release -o /app

WORKDIR /Core.Tests
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Api.dll"]

#docker build --t isitpayday-api .
#docker run -d -p 8080:80 isitpayday-api