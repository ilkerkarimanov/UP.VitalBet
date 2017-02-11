using System;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index.IndexHandlers
{

    public class SportIndexHandler : IndexHandlerBase
    {
        private readonly IEntityIndexer<Sport> _sportIndexer;

        public SportIndexHandler(IEntityIndexer<Sport> sportIndexer)
        {
            _sportIndexer = sportIndexer;
        }
        public override void IndexRequest(FeedResult feed)
        {
            _sportIndexer.Index(feed.Sports);
            if (successor != null) successor.IndexRequest(feed);
        }
    }
}
