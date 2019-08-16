using System;
using System.Threading.Tasks;

namespace NewsletterCurator.HTMLScraper.Contracts
{
    public interface IScraperService
    {
        Task<URLMetadata> ScrapeMetadataAsync(string url);
    }
}
