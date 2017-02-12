using System;
using System.Linq;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index.IndexHandlers
{

    public class EventIndexHandler : IndexHandlerBase
    {
        private readonly IEntityIndexer<Event> _eventIndexer;

        public EventIndexHandler(IEntityIndexer<Event> eventIndexer)
        {
            _eventIndexer = eventIndexer;
        }

        public override void IndexRequest(Feed feed)
        {
            _eventIndexer.Index(feed.Sports.
                SelectMany(x => x.Events));
            if (successor != null) successor.IndexRequest(feed);
        }
    }
}
