using System.Collections.Generic;
using System.IO;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Feed.Abstract
{
    public interface IFeedSerializer
    {
        SportsFeedRoot SerializeFeed(Stream stream);
    }
}
