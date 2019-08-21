FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS build

WORKDIR /app
COPY *.sln ./
COPY src/SpotifyStatus.App/*.csproj ./src/SpotifyStatus.App/
RUN dotnet restore -r alpine-x64

WORKDIR /app
COPY src/SpotifyStatus.App/. ./src/SpotifyStatus.App/
RUN dotnet publish -c Release -r alpine-x64 -o /out/app

FROM mcr.microsoft.com/dotnet/core/runtime:2.2-alpine3.9 AS runtime
WORKDIR /app
COPY --from=build /out/app ./
ENTRYPOINT ["dotnet", "SpotifyStatus.App.dll"]