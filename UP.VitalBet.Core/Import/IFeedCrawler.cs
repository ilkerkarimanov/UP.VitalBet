using System.Collections.Generic;
using System.Threading.Tasks;
using UP.VitalBet.Model;

namespace UP.VitalBet.Core.Import
{
    public interface IFeedCrawler
    {
        Task<FeedResult> Crawl();
    }
}
