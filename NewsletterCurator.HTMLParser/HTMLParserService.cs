using System;
using System.Linq;
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
            var urlMetadata = new URLMetadata
            {
                Title = doc.DocumentNode.SelectSingleNode("/html/head/meta[@property='og:title']")?.GetAttributeValue("content", null) ?? doc.DocumentNode.SelectSingleNode("/html/head/title")?.InnerText,
                Summary = doc.DocumentNode.SelectSingleNode("/html/head/meta[@property='og:description']")?.GetAttributeValue("content", null) ?? doc.DocumentNode.SelectSingleNode("/html/head/meta[@name='description']")?.GetAttributeValue("content", null)
            };

            var ogImage = doc.DocumentNode.SelectSingleNode("/html/head/meta[@property='og:image']")?.GetAttributeValue("content", null);
            if (!string.IsNullOrEmpty(ogImage))
            {
                urlMetadata.Images.Add(ogImage);
            }

            urlMetadata.Images.AddRange(doc.DocumentNode.SelectNodes("//img[not(@src='')]").Select(n =>
            {
                var imageSrc = n.GetAttributeValue("src", null);
                if (!imageSrc.StartsWith("http", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    imageSrc = new Uri(new Uri(url), imageSrc).ToString();
                }

                return imageSrc;
            }));

            return urlMetadata;
        }
    }
}
