using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace NewsletterCurator.HTMLScraper
{
    public class HTMLScraperService
    {
        private readonly HtmlDocument htmlDoc = new HtmlDocument();
        private readonly HttpClient httpClient;

        public HTMLScraperService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<URLMetadata> Scrape(string url)
        {
            var responseString = await httpClient.GetStringAsync(url);
            htmlDoc.LoadHtml(responseString);

            var canonicalUrl = htmlDoc.DocumentNode.SelectSingleNode("//link[@rel='canonical']")?.GetAttributeValue("href", null) ?? htmlDoc.DocumentNode.SelectSingleNode("//meta[@property='og:url']")?.GetAttributeValue("content", null);
            try
            {
                if (canonicalUrl != null && !canonicalUrl.Equals(url, StringComparison.InvariantCultureIgnoreCase))
                {
                    responseString = await httpClient.GetStringAsync(canonicalUrl);
                    htmlDoc.LoadHtml(responseString);
                }
            }
            catch (HttpRequestException)
            {
                canonicalUrl = null;
            }

            var urlMetadata = new URLMetadata
            {
                CanonicalURL = canonicalUrl ?? url,
                Title = "",
                Summary = htmlDoc.DocumentNode.SelectSingleNode("//meta[@property='og:description']")?.GetAttributeValue("content", null) ?? htmlDoc.DocumentNode.SelectSingleNode("//meta[@name='description']")?.GetAttributeValue("content", null)
            };

            if (string.IsNullOrEmpty(urlMetadata.Summary))
            {
                var paragraphs = htmlDoc.DocumentNode.SelectNodes("//p");
                if (paragraphs != null)
                {
                    var longSummary = Regex.Replace(string.Join(' ', paragraphs.Select(p => p.InnerText)), @"\s+", " ");
                    urlMetadata.Summary = new string(longSummary.Take(300).ToArray());
                }
            }

            var ogImage = htmlDoc.DocumentNode.SelectSingleNode("//meta[@property='og:image' or @name='twitter:image']")?.GetAttributeValue("content", null);
            if (!string.IsNullOrEmpty(ogImage))
            {
                urlMetadata.Images.Add(ogImage);
            }

            var articleImages = htmlDoc.DocumentNode.SelectNodes("//img[not(@src='') and @src and not(starts-with(@src,'data:'))]");
            if (articleImages != null)
            {
                urlMetadata.Images.AddRange(articleImages.Select(n =>
                {
                    var imageSrc = n.GetAttributeValue("src", null);
                    if (!imageSrc.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
                    {
                        imageSrc = new Uri(new Uri(url), imageSrc).ToString();
                    }

                    return imageSrc;
                }));
            }

            urlMetadata.Title = HtmlEntity.DeEntitize(urlMetadata.Title);
            urlMetadata.Summary = HtmlEntity.DeEntitize(urlMetadata.Summary);

            return urlMetadata;
        }
    }
}
