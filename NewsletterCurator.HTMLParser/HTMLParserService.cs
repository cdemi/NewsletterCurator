using System.Threading.Tasks;
using HtmlAgilityPack;

namespace NewsletterCurator.HTMLParser
{
    public class HTMLParserService
    {
        private readonly HtmlWeb htmlWeb = new HtmlWeb();
        public async Task<URLMetadata> Parse(string url)
        {
            var doc = await htmlWeb.LoadFromWebAsync(url);
            return new URLMetadata
            {
                Title = doc.DocumentNode.SelectSingleNode("/html/head/title").InnerText
            };
        }
    }
}
