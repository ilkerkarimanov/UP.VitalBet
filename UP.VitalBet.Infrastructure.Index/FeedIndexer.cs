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
        private readonly IEnumerable<IndexHandlerBase> _handlers;

        public FeedIndexer(IEnumerable<IndexHandlerBase> handlers)
        {
            _handlers = handlers;
        }

        public void Index(FeedResult data)
        {
            foreach(var handler in _handlers)
            {
                handler.IndexRequest(data);
            }
        }
    }
}
