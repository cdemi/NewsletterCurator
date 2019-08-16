using System.Collections.Generic;

namespace NewsletterCurator.Scraper.Contracts
{
    public class URLMetadata
    {
        public string Title { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public string Summary { get; set; }
        public string CanonicalURL { get; set; }
        public string FaviconURL { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
