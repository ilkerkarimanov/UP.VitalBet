using System;
using System.Collections.Generic;
using System.Linq;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Infrastructure.Index.IndexHandlers;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index
{
    public class FeedIndexer : IFeedIndexer
    {
        private readonly IFeedIndexHandler _feedHandler;

        public FeedIndexer(IFeedIndexHandler feedHandler)
        {
            _feedHandler = feedHandler;
        }

        public void Index(Feed data)
        {
            _feedHandler.IndexRequest(data);
        }
    }
}
