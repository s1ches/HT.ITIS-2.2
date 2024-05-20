FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BadWebSite.RazorExample/BadWebSite.RazorExample.csproj", "BadWebSite.RazorExample/"]
RUN dotnet restore "BadWebSite.RazorExample/BadWebSite.RazorExample.csproj"
COPY . .
WORKDIR "/src/BadWebSite.RazorExample"
RUN dotnet build "BadWebSite.RazorExample.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BadWebSite.RazorExample.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BadWebSite.RazorExample.dll"]
