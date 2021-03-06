﻿using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UP.VitalBet.Core;
using UP.VitalBet.Core.Configuration;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Infrastructure.Feed.Abstract;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Feed
{
    public class FeedClient : IFeedClient
    {
        private readonly IFeedSerializer _feedSerializer;
        private readonly IConfiguration _config;

        private const string feedClientConfigKey = "feedClientUrl";
        public FeedClient(IFeedSerializer feedSerializer,
            IConfiguration config)
        {
            _feedSerializer = feedSerializer;
            _config = config;
        }
        public async Task<Model.Feed> RetrieveSportsFeed()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            if (!_config.HasProperty(feedClientConfigKey)) throw new Failure("[feedClientUrl] config is null.");
            string url = _config.ReadProperty(feedClientConfigKey);
            Model.Feed result = new Model.Feed();
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await httpClient.SendAsync(request);
                using (var content = await response.Content.ReadAsStreamAsync())
                {
                    result.Sports = _feedSerializer.SerializeFeed(content);
                        

                }

            }
            stopwatch.Stop();
            return result;
        }
    }
}
