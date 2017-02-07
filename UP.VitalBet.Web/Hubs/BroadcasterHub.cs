using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using UP.VitalBet.Common;

namespace UP.VitalBet.Web.Hubs
{
    public class BroadcasterHub: Hub
    {
        private readonly IBroadcaster _broadcaster;

        public BroadcasterHub(IBroadcaster broadcaster)
        {
            _broadcaster = broadcaster;
        }

        public async Task<Result> PullMatches()
        {
            return await _broadcaster.PullMatches(DateTimeProvider.Now);
        }
    }
}