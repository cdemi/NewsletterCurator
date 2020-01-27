FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NewsletterCurator.Web/NewsletterCurator.Web.csproj", "NewsletterCurator.Web/"]
COPY ["NewsletterCurator.YouTubeScraper/NewsletterCurator.YouTubeScraper.csproj", "NewsletterCurator.YouTubeScraper/"]
COPY ["NewsletterCurator.Scraper.Contracts/NewsletterCurator.Scraper.Contracts.csproj", "NewsletterCurator.Scraper.Contracts/"]
COPY ["NewsletterCurator.HTMLScraper/NewsletterCurator.HTMLScraper.csproj", "NewsletterCurator.HTMLScraper/"]
COPY ["NewsletterCurator.Data.SqlServer/NewsletterCurator.Data.SqlServer.csproj", "NewsletterCurator.Data.SqlServer/"]
COPY ["NewsletterCurator.Data/NewsletterCurator.Data.csproj", "NewsletterCurator.Data/"]
COPY ["NewsletterCurator.EmailService/NewsletterCurator.EmailService.csproj", "NewsletterCurator.EmailService/"]
RUN dotnet restore "NewsletterCurator.Web/NewsletterCurator.Web.csproj"
COPY . .
WORKDIR "/src/NewsletterCurator.Web"
RUN dotnet build "NewsletterCurator.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NewsletterCurator.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewsletterCurator.Web.dll"]
