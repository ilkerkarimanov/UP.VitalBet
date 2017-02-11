using System;
using System.Linq;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index.IndexHandlers
{

    public class OddIndexHandler : IndexHandlerBase
    {
        private readonly IEntityIndexer<Odd> _oddIndexer;

        public OddIndexHandler(IEntityIndexer<Odd> oddIndexer)
        {
            _oddIndexer = oddIndexer;
        }

        public override void IndexRequest(FeedResult feed)
        {
            _oddIndexer.Index(feed.Sports.
            SelectMany(x => x.Events)
            .SelectMany(z => z.Matches)
            .SelectMany(c => c.Bets)
            .SelectMany(v => v.Odds));
            if (successor != null) successor.IndexRequest(feed);
        }
    }
}
