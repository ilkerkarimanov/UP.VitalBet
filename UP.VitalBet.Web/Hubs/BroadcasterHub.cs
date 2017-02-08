using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;
using UP.VitalBet.Core;

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
            try
            {
                return await _broadcaster.PullMatches(DateTimeProvider.Now);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Result.Fail("Internal server error."));
            }
        }
    }
}