using System;
using System.Linq;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index.IndexHandlers
{

    public class MatchIndexHandler : IndexHandlerBase
    {
        private readonly IEntityIndexer<Match> _matchIndexer;

        public MatchIndexHandler(IEntityIndexer<Match> matchIndexer)
        {
            _matchIndexer = matchIndexer;
        }

        public override void IndexRequest(Feed feed)
        {
            _matchIndexer.Index(feed.Sports.
            SelectMany(x => x.Events)
            .SelectMany(z => z.Matches));
            if (successor != null) successor.IndexRequest(feed);
        }
    }
}
