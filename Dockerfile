FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
COPY IsItPayDayApi.sln ./
COPY Core/*.csproj ./Core/
COPY Api/*.csproj ./Api/
COPY Tests.Common/*.csproj ./Tests.Common/
COPY Core.Tests/*.csproj ./Core.Tests/
RUN dotnet restore .

COPY . ./
RUN dotnet test Core.Tests -c Release
RUN dotnet publish Api -c Release -o /out

FROM base AS final
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "Api.dll"]

#docker build -t isitpayday-api .
#docker run -d -p 8080:80 isitpayday-api