FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base

EXPOSE $APP_PORT_EXTERNAL

WORKDIR /app

COPY . .
RUN dotnet restore FileArchive.csproj
RUN dotnet build FileArchive.csproj
RUN dotnet publish FileArchive.csproj -c Release -o /publish

WORKDIR /publish

ENTRYPOINT ["dotnet", "FileArchive.dll"]