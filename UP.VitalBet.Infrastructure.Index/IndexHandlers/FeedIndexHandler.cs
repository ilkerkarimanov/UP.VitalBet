using System;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index.IndexHandlers
{

    public interface IFeedIndexHandler: IIndexHandler { }

    public class FeedIndexHandler : IndexHandlerBase, IFeedIndexHandler
    {
        public override void IndexRequest(Feed feed)
        {
            if (successor != null) successor.IndexRequest(feed);
        }
    }
}
