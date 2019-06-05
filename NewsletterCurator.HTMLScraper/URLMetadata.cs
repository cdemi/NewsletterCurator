using System.Collections.Generic;

namespace NewsletterCurator.HTMLScraper
{
    public class URLMetadata
    {
        public string Title { get; internal set; }
        public List<string> Images { get; internal set; } = new List<string>();
        public string Summary { get; internal set; }
        public string CanonicalURL { get; internal set; }
        public string FaviconURL { get; internal set; }
    }
}
