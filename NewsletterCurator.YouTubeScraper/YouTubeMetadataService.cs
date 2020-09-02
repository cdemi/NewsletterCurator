using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Extensions.Logging;
using NewsletterCurator.Scraper.Contracts;

namespace NewsletterCurator.YouTubeScraper
{
    public class YouTubeMetadataService : IScraperService
    {
        private readonly ILogger<YouTubeMetadataService> logger;
        private readonly YouTubeService youtubeService;

        public YouTubeMetadataService(ILogger<YouTubeMetadataService> logger, BaseClientService.Initializer baseClientServiceInitializer)
        {
            this.logger = logger;
            youtubeService = new YouTubeService(baseClientServiceInitializer);
        }

        public async Task<URLMetadata> ScrapeMetadataAsync(Uri uri)
        {
            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = uri.ToString();
            searchListRequest.MaxResults = 1;
            searchListRequest.Type = "video";

            var searchListResponse = await searchListRequest.ExecuteAsync();
            string videoID;
            if (searchListResponse.Items.Count > 0)
                videoID = searchListResponse.Items.First().Id.VideoId;
            else
                videoID = System.Web.HttpUtility.ParseQueryString(uri.Query).Get("v");

            var videosListRequest = youtubeService.Videos.List("snippet");
            videosListRequest.Id = videoID;
            videosListRequest.MaxResults = 1;

            var videoListResponse = await videosListRequest.ExecuteAsync();

            var images = new List<string>();

            if (videoListResponse.Items.First().Snippet.Thumbnails.Maxres!=null)
            {
                images.Add(videoListResponse.Items.First().Snippet.Thumbnails.Maxres.Url);
            }
            if (videoListResponse.Items.First().Snippet.Thumbnails.High != null)
            {
                images.Add(videoListResponse.Items.First().Snippet.Thumbnails.High.Url);
            }
            if (videoListResponse.Items.First().Snippet.Thumbnails.Medium != null)
            {
                images.Add(videoListResponse.Items.First().Snippet.Thumbnails.Medium.Url);
            }
            if (videoListResponse.Items.First().Snippet.Thumbnails.Standard != null)
            {
                images.Add(videoListResponse.Items.First().Snippet.Thumbnails.Standard.Url);
            }

            URLMetadata metadata = new URLMetadata()
            {
                CanonicalURL = "https://youtu.be/" + videoID,
                FaviconURL = "https://www.youtube.com/favicon.ico",
                Title = videoListResponse.Items.First().Snippet.Title,
                Summary = videoListResponse.Items.First().Snippet.Description,
                Tags = videoListResponse.Items.First().Snippet.Tags?.ToList(),
                Images = images
            };

            return metadata;
        }
    }
}
