using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace NewsletterCurator.HTMLScraper.Tests
{
    [TestClass]
    public class UnitTests
    {
        private readonly IHttpClientFactory httpClientFactory;

        public UnitTests()
        {
            var httpClient = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.None
            });
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36");
            httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");

            var mockFactory = new Mock<IHttpClientFactory>();
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);
            httpClientFactory = mockFactory.Object;
        }

        [TestMethod]
        public async Task ScrapeCdemiBlog()
        {
            var scraperService = new HTMLScraperService(httpClientFactory, new NullLogger<HTMLScraperService>());
            var urlMetaData = await scraperService.ScrapeMetadataAsync(new Uri("https://blog.cdemi.io/whats-coming-in-c-8-0-nullable-reference-types/?src=NewsletterCuratorTest"));

            Assert.AreEqual(urlMetaData.CanonicalURL, "https://blog.cdemi.io/whats-coming-in-c-8-0-nullable-reference-types/");
            Assert.AreEqual(urlMetaData.Images.Count, 2);
            Assert.AreEqual(urlMetaData.Summary, "One of the features being discussed for introduction in C# 8.0 is Nullable Reference Types. A proficient C# Developer might say \"What?! Aren't all reference types nullable?\"");
            Assert.AreEqual(urlMetaData.Title, "What's Coming in C# 8.0? Nullable Reference Types");
            StringAssert.StartsWith(urlMetaData.FaviconURL, "https://blog.cdemi.io/assets/img/favicons/favicon-32x32.png");
            CollectionAssert.Contains(urlMetaData.Tags, "C# 8.0");
            CollectionAssert.Contains(urlMetaData.Tags, "C#");
            CollectionAssert.Contains(urlMetaData.Tags, "Software Development");
            CollectionAssert.Contains(urlMetaData.Tags, ".NET");
        }
    }
}
