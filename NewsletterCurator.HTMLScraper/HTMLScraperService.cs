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
        public async Task<string> ScrapeAsync(string url)
        {
            return await httpClient.GetStringAsync(url);
        }

        public async Task<URLMetadata> ScrapeMetadataAsync(string url)
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
                Title = htmlDoc.DocumentNode.SelectSingleNode("//meta[@property='og:title']")?.GetAttributeValue("content", null) ?? htmlDoc.DocumentNode.SelectSingleNode("//title")?.InnerText,
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
                }).Distinct());
            }

            var tags = htmlDoc.DocumentNode.SelectNodes("//meta[@property='article:tag']");
            if (tags != null)
            {
                urlMetadata.Tags = tags.Select(t => t.GetAttributeValue("content", null)).ToList();
            }

            var faviconTag = htmlDoc.DocumentNode.SelectNodes("/html/head/link[contains(@rel, 'icon') and not(contains(@rel, '-icon'))]")?.FirstOrDefault();
            if (faviconTag != null)
            {
                urlMetadata.FaviconURL = faviconTag.GetAttributeValue("href", null);

                if (!urlMetadata.FaviconURL.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
                {
                    urlMetadata.FaviconURL = new Uri(new Uri(url), urlMetadata.FaviconURL).ToString();
                }
            }

            urlMetadata.Title = HtmlEntity.DeEntitize(urlMetadata.Title);
            urlMetadata.Summary = HtmlEntity.DeEntitize(urlMetadata.Summary);

            return urlMetadata;
        }
    }
}
