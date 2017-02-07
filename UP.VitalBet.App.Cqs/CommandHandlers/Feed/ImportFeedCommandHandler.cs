using System.Threading.Tasks;
using DDD.Common.Cqs.Command;
using UP.VitalBet.Common;
using UP.VitalBet.App.Cqs.Commands.Feed;
using UP.VitalBet.Core.Import;

namespace UP.VitalBet.App.Cqs.CommandHandlers.Feed
{
    public class ImportFeedCommandHandler :
           IAsyncCommandHandler<ImportFeedCommand, Result>
    {
        private readonly IFeedIndexer _feedIndexer;
        private readonly IFeedCrawler _feedCrawler;
        public ImportFeedCommandHandler(IFeedIndexer feedIndexer,
            IFeedCrawler feedCrawler)
        {
            _feedIndexer = feedIndexer;
            _feedCrawler = feedCrawler;
        }
        public async Task<Result> HandleAsync(ImportFeedCommand command)
        {
            var data = await _feedCrawler.Crawl();
            _feedIndexer.Index(data);
            return await Task.FromResult(Result.Ok());
        }
    }
}
