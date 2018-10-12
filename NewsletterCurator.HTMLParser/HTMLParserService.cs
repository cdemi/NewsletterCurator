using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace NewsletterCurator.HTMLParser
{
    public class HTMLParserService
    {
        private readonly HtmlDocument htmlDoc = new HtmlDocument();
        private readonly HttpClient httpClient;

        public HTMLParserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<URLMetadata> Parse(string url)
        {
            var responseString = await httpClient.GetStringAsync(url);
            htmlDoc.LoadHtml(responseString);
            var urlMetadata = new URLMetadata
            {
                Title = htmlDoc.DocumentNode.SelectSingleNode("/html/head/meta[@property='og:title']")?.GetAttributeValue("content", null) ?? htmlDoc.DocumentNode.SelectSingleNode("/html/head/title")?.InnerText,
                Summary = htmlDoc.DocumentNode.SelectSingleNode("/html/head/meta[@property='og:description']")?.GetAttributeValue("content", null) ?? htmlDoc.DocumentNode.SelectSingleNode("/html/head/meta[@name='description']")?.GetAttributeValue("content", null)
            };

            var ogImage = htmlDoc.DocumentNode.SelectSingleNode("/html/head/meta[@property='og:image']")?.GetAttributeValue("content", null);
            if (!string.IsNullOrEmpty(ogImage))
            {
                urlMetadata.Images.Add(ogImage);
            }

            urlMetadata.Images.AddRange(htmlDoc.DocumentNode.SelectNodes("//img[not(@src='')]").Select(n =>
            {
                var imageSrc = n.GetAttributeValue("src", null);
                if (!imageSrc.StartsWith("http", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    imageSrc = new Uri(new Uri(url), imageSrc).ToString();
                }

                return imageSrc;
            }));

            urlMetadata.Title = HtmlEntity.DeEntitize(urlMetadata.Title);
            urlMetadata.Summary = HtmlEntity.DeEntitize(urlMetadata.Summary);

            return urlMetadata;
        }
    }
}
