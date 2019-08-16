using System;
using System.Threading.Tasks;

namespace NewsletterCurator.Scraper.Contracts
{
    public interface IScraperService
    {
        Task<URLMetadata> ScrapeMetadataAsync(string url);
    }
}
