using System.Threading.Tasks;
using UP.VitalBet.Model;

namespace UP.VitalBet.Core.Import
{
    public interface IFeedClient
    {
        Task<FeedResult> RetrieveSportsFeed();
    }
}
