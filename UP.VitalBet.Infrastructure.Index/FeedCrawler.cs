using System.Collections.Generic;
using System.Threading.Tasks;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index
{
    public class FeedCrawler : IFeedCrawler
    {
        private readonly IFeedClient _feedClient;
        public FeedCrawler(IFeedClient feedClient,
            IFeedIndexer feedGraphTracker)
        {
            _feedClient = feedClient;
        }

        public async Task<IEnumerable<Sport>> Crawl()
        {
            var feedResult = await _feedClient.RetrieveSportsFeed();
            return await Task.FromResult(feedResult.Sports);
        }
    }
}
