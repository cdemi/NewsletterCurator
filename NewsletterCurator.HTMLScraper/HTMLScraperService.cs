using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using NewsletterCurator.Scraper.Contracts;

namespace NewsletterCurator.HTMLScraper
{
    public class HTMLScraperService : IScraperService
    {
        private readonly HtmlDocument htmlDoc = new HtmlDocument();
        private readonly HttpClient httpClient;
        private readonly ILogger<HTMLScraperService> logger;

        public HTMLScraperService(IHttpClientFactory httpClientFactory, ILogger<HTMLScraperService> logger)
        {
            this.httpClient = httpClientFactory.CreateClient("httpClient");
            this.logger = logger;
        }
        public async Task<string> ScrapeAsync(Uri uri)
        {
            return await httpClient.GetStringAsync(uri);
        }

        public async Task<URLMetadata> ScrapeMetadataAsync(Uri uri)
        {
            var response = await httpClient.GetAsync(uri.GetLeftPart(UriPartial.Query));
            var responseString = await response.Content.ReadAsStringAsync();
            htmlDoc.LoadHtml(responseString);

            var canonicalUrl = htmlDoc.DocumentNode.SelectSingleNode("//link[@rel='canonical']")?.GetAttributeValue("href", null) ?? htmlDoc.DocumentNode.SelectSingleNode("//meta[@property='og:url']")?.GetAttributeValue("content", null);
            try
            {
                if (canonicalUrl != null)
                {
                    if (!canonicalUrl.StartsWith("http"))
                    {
                        canonicalUrl = new Uri(response.RequestMessage.RequestUri, canonicalUrl).ToString();
                    }
                    if (canonicalUrl != null && !canonicalUrl.Equals(response.RequestMessage.RequestUri.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        response = await httpClient.GetAsync(canonicalUrl);
                        responseString = await response.Content.ReadAsStringAsync();
                        htmlDoc.LoadHtml(responseString);
                    }
                }
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is HttpRequestException)
            {
                logger.LogError(ex, "Error trying to load canonical URL. Using current URL instead");
                canonicalUrl = null;
            }

            var urlMetadata = new URLMetadata
            {
                CanonicalURL = canonicalUrl ?? response.RequestMessage.RequestUri.ToString(),
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
                        try
                        {
                            imageSrc = new Uri(response.RequestMessage.RequestUri, imageSrc).ToString();
                        }
                        catch
                        {
                            imageSrc = "";
                        }
                    }

                    return imageSrc;
                }).Distinct());
            }

            var tags = htmlDoc.DocumentNode.SelectNodes("//meta[@property='article:tag']");
            if (tags != null)
            {
                urlMetadata.Tags.AddRange(tags.Select(t => t.GetAttributeValue("content", null)).ToList());
            }

            var keywords = htmlDoc.DocumentNode.SelectNodes("//meta[@name='news_keywords' or @name='keywords']");
            if (keywords != null)
            {
                foreach (var newsKeyword in keywords)
                {
                    urlMetadata.Tags.AddRange(newsKeyword.GetAttributeValue("content", null).Split(",").Select(t => t.Trim()));
                }
            }

            urlMetadata.Tags = urlMetadata.Tags.Distinct().ToList();

            var faviconTag = htmlDoc.DocumentNode.SelectNodes("//link[contains(@rel, 'icon') and not(contains(@rel, '-icon'))]")?.LastOrDefault();
            if (faviconTag != null)
            {
                urlMetadata.FaviconURL = faviconTag.GetAttributeValue("href", null);

                if (!String.IsNullOrEmpty(urlMetadata.FaviconURL) && !urlMetadata.FaviconURL.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
                {
                    urlMetadata.FaviconURL = new Uri(response.RequestMessage.RequestUri, urlMetadata.FaviconURL).ToString();
                }
            }

            if (String.IsNullOrEmpty(urlMetadata.FaviconURL))
            {
                logger.LogInformation("No favicons found in metadata. Trying to get default favicon from: " + new Uri(response.RequestMessage.RequestUri, "/favicon.ico").ToString());
                try
                {
                    HttpClient faviconClient = new HttpClient();
                    var faviconResponse = await faviconClient.GetAsync(new Uri(response.RequestMessage.RequestUri, "/favicon.ico"), HttpCompletionOption.ResponseHeadersRead);
                    if (faviconResponse.IsSuccessStatusCode)
                        urlMetadata.FaviconURL = new Uri(response.RequestMessage.RequestUri, "/favicon.ico").ToString();
                }
                catch (Exception ex)
                {
                    //Leave without favicon if something's wrong
                    logger.LogError(ex, "Error trying to retrieve favicon. Ignoring favicons");
                }
            }

            urlMetadata.Title = HtmlEntity.DeEntitize(urlMetadata.Title);
            urlMetadata.Summary = HtmlEntity.DeEntitize(urlMetadata.Summary);

            return urlMetadata;
        }
    }
}
