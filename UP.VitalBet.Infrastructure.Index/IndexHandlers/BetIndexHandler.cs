using System;
using System.Linq;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index.IndexHandlers
{

    public class BetIndexHandler : IndexHandlerBase
    {

        private readonly IEntityIndexer<Bet> _betIndexer;

        public BetIndexHandler(IEntityIndexer<Bet> betIndexer)
        {
            _betIndexer = betIndexer;
        }
        public override void IndexRequest(Feed feed)
        {
            _betIndexer.Index(feed.Sports.
            SelectMany(x => x.Events)
            .SelectMany(z => z.Matches)
            .SelectMany(c => c.Bets));
            if (successor != null) successor.IndexRequest(feed);
        }
    }
}
