FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 50192
EXPOSE 50193

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["NewsletterCurator.Web/NewsletterCurator.Web.csproj", "NewsletterCurator.Web/"]
COPY ["NewsletterCurator.HTMLScraper/NewsletterCurator.HTMLScraper.csproj", "NewsletterCurator.HTMLScraper/"]
COPY ["NewsletterCurator.Data.SqlServer/NewsletterCurator.Data.SqlServer.csproj", "NewsletterCurator.Data.SqlServer/"]
COPY ["NewsletterCurator.Data/NewsletterCurator.Data.csproj", "NewsletterCurator.Data/"]
RUN dotnet restore "NewsletterCurator.Web/NewsletterCurator.Web.csproj"
COPY . .
WORKDIR "/src/NewsletterCurator.Web"
RUN dotnet build "NewsletterCurator.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NewsletterCurator.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NewsletterCurator.Web.dll"]
